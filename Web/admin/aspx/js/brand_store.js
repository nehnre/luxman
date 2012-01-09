$(function(){
    _list = window._list || {Table:[]};
    loadList(_list);
    $("#btnSearch").click(function(){
        var bsCountry = $("#bsCountry").val();
        var bsCity = $("#bsCity").val();
        var data = "method=list&ajax=true";
        if(bsCountry){
           data += "&bsCountry=" + bsCountry;
        }
        if(bsCity){
           data += "&bsCity=" + bsCity;
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
        location.href="EditBrandStore.aspx?_" + nehnre.timeRandom();
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
        children.eq(0).html("【<a href='EditBrandStore.aspx?bsId={0}'>{1}</a>】".format(this.bs_id, this.bs_id.substring(0,this.bs_id.indexOf("-"))));
        children.eq(1).html(this.bs_country);
        children.eq(2).html(this.bs_city);
        children.eq(3).html(this.bs_content?this.bs_content.replace(/<[^>]+>/ig,""):"&nbsp;");
        children.eq(4).find("img").attr("bsId", this.bs_id).click(function(){
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
    var data = "method=delete&bsId=" + $(obj).attr("bsId");
    
    $.ajax({
        url:"../ashx/brandstore.ashx",
        type:"POST",
        data: data,
        success: function(){
            $(obj).parents(".model1").remove();
        }
    });
}