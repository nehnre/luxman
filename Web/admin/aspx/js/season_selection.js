$(function(){
    _list = window._list || {Table:[]};
    loadList(_list);
    $("#btnSearch").click(function(){
        var ssType1 = $("#ssType1").val();
        var ssType2 = $("#ssType2").val();
        var data = "method=list&ajax=true";
        if(ssType1){
           data += "&ssType1=" + ssType1;
        }
        if(ssType2){
           data += "&ssType2=" + ssType2;
        }
        $.ajax({
            url:"../ashx/seasonselection.ashx",
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
        location.href="EditSeasonSelection.aspx?_" + nehnre.timeRandom();
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
        children.eq(0).html("【<a href='EditSeasonSelection.aspx?ssId={0}'>{1}</a>】".format(this.ss_id, this.ss_id.substring(0,this.ss_id.indexOf("-"))));
        children.eq(1).html(this.ss_type1);
        children.eq(2).html(this.ss_type2);
        children.eq(3).html(this.ss_content?this.ss_content.replace(/<[^>]+>/ig,""):"&nbsp;");
        children.eq(4).find("img").attr("ssId", this.ss_id).click(function(){
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
    var data = "method=delete&ssId=" + $(obj).attr("ssId");
    
    $.ajax({
        url:"../ashx/seasonselection.ashx",
        type:"POST",
        data: data,
        success: function(){
            $(obj).parents(".model1").remove();
        }
    });
}