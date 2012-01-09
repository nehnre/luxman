//编辑器

KE.show({
    id:"bsContent",
	items : [
		'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
		'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
		'insertunorderedlist', '|', 'link']
});
$(function(){
    var bsId = nehnre.queryString()["bsId"];
    loadData(bsId);
    $("#btnCancle").click(function(){
        location.href="BrandStore.aspx?_" + new Date().getTime();
    });
    $("#btnSubmit").click(function(){
        var data = "method=save";
        if(bsId){
            data += "&bsId=" + bsId;
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
        
        data += "&bsCountry=" + $("#bsCountry").val();
        data += "&bsCity=" + $("#bsCity").val();
        data += "&bsContent=" + nehnre.encode(KE.html("bsContent"));
        $.ajax({
            url:"../ashx/brandstore.ashx",
            data:data,
            type: "POST",
            success:function(){
                alert("提交成功");
                location.href="BrandStore.aspx?_" + new Date().getTime();
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

function loadData(bsId){
    if(!bsId) return;
    var data = "method=detail&ajax=true&bsId=" + bsId;
    $.ajax({
        url:"../ashx/brandstore.ashx",
        cache:false,
        type:"POST",
        data: data,
        success:function(json){
            fillData(json);
        }
    });
}
function fillData(json){
    console.log(json);
    if(!json) return;
    json = nehnre.parseJSON(json);
    
    var data = json[0].Table[0];
    $("#bsCountry").val(data.bs_country);
    $("#bsCity").val(data.bs_city);
    (function(){
        KE.html("bsContent", data.bs_content);
        if(!KE.html("bsContent") && data.bs_content){
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