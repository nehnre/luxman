$(function(){
    loadList(_list);
    $("#btnSearch").click(function(){
        var biType = $("#biType").val();
        var data = "method=list&ajax=true";
        if(biType){
           data += "&biType=" + biType;
        }
        $.ajax({
            url:"../ashx/brandidea.ashx",
            data:data,
            cache:false,
            type:"POST",
            success:function(json){
                json = nehnre.parseJSON(json);
                loadList(json);
            }
        });
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
        children.eq(0).html("【<a href='EditBrandIdea.aspx?biId={0}'>{1}</a>】".format(this.bi_id, this.bi_id.substring(0,this.bi_id.indexOf("-"))));
        children.eq(1).html(this.bi_type);
        children.eq(2).html(this.bi_content?this.bi_content.replace(/<[^>]+>/ig,""):"&nbsp;");
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