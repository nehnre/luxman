//编辑器

KE.show({
    id:"biContent",
	items : [
		'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
		'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
		'insertunorderedlist', '|', 'link']
});
$(function(){
    var biId = nehnre.queryString()["biId"];
    loadData(biId);
    $("#btnCancle").click(function(){
        location.href="BrandIdea.aspx?_" + new Date().getTime();
    });
    $("#btnSubmit").click(function(){
        var data = "method=save&biId=" + biId;
        data += "&biContent=" + nehnre.encode(KE.html("biContent"));
        data += "&biType=" + $("#biType").html();
        console.log(data);
        $.ajax({
            url:"../ashx/brandidea.ashx",
            data:data,
            type: "POST",
            success:function(){
                alert("修改成功");
                location.href="BrandIdea.aspx?_" + new Date().getTime();
            }
        });
    });
});

function loadData(biId){
    if(!biId) return;
    var data = "method=detail&ajax=true&biId=" + biId;
    $.ajax({
        url:"../ashx/brandidea.ashx",
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
    var data = json.Table[0];
    $("#biType").html(data.bi_type);
    //$("#biContent").val(data.bi_content);
    (function(){
        KE.html("biContent", data.bi_content);
        if(!KE.html("biContent") && data.bi_content){
            setTimeout(arguments.callee, 500);
        }
        console.log(KE.html("biContent"));
    })(KE);
}