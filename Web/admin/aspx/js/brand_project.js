$(function(){
    _list = window._list || {Table:[]};
    loadList(_list);
    $("#btnSearch").click(function(){
        var bpType = $("#bpType").val();
        var data = "method=list&ajax=true";
        if(bpType){
           data += "&bpType=" + bpType;
        }
        $.ajax({
            url:"../ashx/brandstore.ashx",
            data:data,
            cache:false,
            type:"POST",
            success:function(json){
                json = nehnre.parseJSON(json);
                loadList(json);
            }
        });
    });
    
    $("#btnNew").click(function(){
        location.href="EditBrandProject.aspx?_" + nehnre.timeRandom();
    });
});
function loadList(list){
    if(!list) return;
    $.each($(".model1"),function(){
        $(this).remove();
    });
    var table = list.Table;
    if(table.length <= 0){
        $(".none").show();
        return;
    } else {
        $(".none").hide();
    }
	var tr = $(".model");
    $.each(table,function(i){
        var onerow = tr.clone();
	    var children = onerow.children();
	    
	    //载入数据
        children.eq(0).html("【<a href='EditBrandProject.aspx?bpId={0}'>{1}</a>】".format(this.bp_id, this.bp_id.substring(0,this.bp_id.indexOf("-"))));
        children.eq(1).html(this.bp_type);
        children.eq(2).html(this.bp_content?this.bp_content.replace(/<[^>]+>/ig,""):"&nbsp;");
        children.eq(3).find("img").attr("bpId", this.bp_id).click(function(){
            del.call(this,this);
        });
        var className = i%2?"even":"odd";
        
        onerow.removeClass("model");
        onerow.addClass("model1");
        onerow.addClass(className);
        if($(".model1").size() > 0){
            $(".model1").last().after(onerow);
        } else {
            $(".model").last().after(onerow)
        }
    
    });
}

function del(obj){
    if(!confirm("你确定要删除这条记录吗？")) return;
    var data = "method=delete&bpId=" + $(obj).attr("bpId");
    
    $.ajax({
        url:"../ashx/brandproject.ashx",
        type:"POST",
        data: data,
        success: function(){
            $(obj).parents(".model1").remove();
        }
    });
}