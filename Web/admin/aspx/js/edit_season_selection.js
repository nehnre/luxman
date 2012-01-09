//编辑器

KE.show({
    id:"ssContent",
	items : [
		'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
		'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
		'insertunorderedlist', '|', 'link']
});
$(function(){
    var ssId = nehnre.queryString()["ssId"];
    loadData(ssId);
    $("#btnCancle").click(function(){
        location.href="SeasonSelection.aspx?_" + new Date().getTime();
    });
    $("#btnSubmit").click(function(){
        var data = "method=save";
        if(ssId){
            data += "&ssId=" + ssId;
        }
        var pics = "";
        var disc = "";
        $(".picmodel1 a[operate='insert']").each(function(i){
            if(i > 0){
                pics += ",";
                disc += ",";
            }
            pics += $(this).attr("href");
            disc += $(this).text();
        });
        if(pics){
            data += "&pics=" + pics;
        }
        if(disc){
            data += "&disc=" + disc;
        }
        
        var delPic = "";
        $(".picmodel1 a[operate='delete']").each(function(i){
            if(i > 0){
                delPic += ",";
            }
            delPic += $(this).attr("picId");
        });
        
        if(delPic){
            data += "&delPic=" + delPic;
        }
        
        data += "&ssType1=" + $("#ssType1").val();
        data += "&ssType2=" + $("#ssType2").val();
        data += "&ssContent=" + nehnre.encode(KE.html("ssContent"));
        $.ajax({
            url:"../ashx/seasonselection.ashx",
            data:data,
            type: "POST",
            success:function(){
                alert("提交成功");
                location.href="SeasonSelection.aspx?_" + new Date().getTime();
            }
        });
    });
    
    



    //上传图片
    new AjaxUpload('pic', {
	    action: '../../Common/AjaxHandler.ashx',
	    name: 'upload',
	    responseType: 'json',
        onSubmit: function(file, extension){
    	    return filterPic.apply(this, Array.prototype.slice.call(arguments,0));
        },
	    onComplete : function(file, result){
	        var path = result.msg.split(";")[0];
	        var title = result.msg.split(";")[1];
	        var onerow = $(".picmodel").clone();
	        onerow.removeClass("picmodel");
	        onerow.addClass("picmodel1");
	        onerow.children().eq(1).find("td").eq(0).html("<a href='{0}' target='_blank' operate='insert'>{1}</a>".format(path, title));
	        onerow.children().eq(1).find("td").eq(1).html("<img src='../../images/del.png' style='cursor:pointer' alt='删除'/>");
            if( $(".picmodel1").size()>0){
                $(".picmodel1").last().after(onerow);
            } else {
                $(".picmodel").after(onerow);
            }
	    }	
    });    
});

function loadData(ssId){
    if(!ssId) return;
    var data = "method=detail&ajax=true&ssId=" + ssId;
    $.ajax({
        url:"../ashx/seasonselection.ashx",
        cache:false,
        type:"POST",
        data: data,
        success:function(json){
            fillData(json);
        }
    });
}
function fillData(json){
    if(!json) return;
    json = nehnre.parseJSON(json);
    
    var data = json[0].Table[0];
    $("#ssType1").val(data.ss_type1);
    $("#ssType2").val(data.ss_type2);
    (function(){
        KE.html("ssContent", data.ss_content);
        if(!KE.html("ssContent") && data.ss_content){
            setTimeout(arguments.callee, 500);
        }
    })(KE);
    
    var picData = json[1].Table;
    if(picData.length > 0){
        $.each(picData, function(){
	        var onerow = $(".picmodel").clone();
	        onerow.removeClass("picmodel");
	        onerow.addClass("picmodel1");
	        onerow.children().eq(1).find("td").eq(0).html("<a href='{0}' target='_blank' picId='{1}'>{2}</a>".format(this.pic_path, this.pic_id, this.pic_descrip));
	        onerow.children().eq(1).find("td").eq(1).html("<img src='../../images/del.png' style='cursor:pointer' alt='删除' onclick='delPic(this)'/>");
            if( $(".picmodel1").size()>0){
                $(".picmodel1").last().after(onerow);
            } else {
                $(".picmodel").after(onerow);
            }
        
        });
    }
}

function delPic(obj){
    if(!confirm("你确定要删除这张图片吗？")) return;
    var onerow = $(obj).parents(".picmodel1");
    var pic = onerow.find("a[picId]");
    var size = pic.size();
    if(size > 0){
        pic.attr("operate","delete");
        onerow.hide();
    } else {
        onerow.remove();
    }
}

//过滤不符合要求的文件
function filterPic(file, extension){
	if(extension){
		extension = extension.toLowerCase();
		if(extension == "jpg" || extension == "gif" || extension == "jpeg" || extension == "png"){
			return true;
		}
	}
	alert("你上传的文件格式不正确！");
	return false;
}