nehnre = {};
nehnre.encode = function (url){
	url = encodeURIComponent(url);
	url = url.replace(/\%/g,"@");
	return url;
}
nehnre.parseJSON = function(str){
	if(str){
		return eval("(" + str + ")");
	} else {
		return {};
	}
}
nehnre.decode = function(url){
	url = url.replace(/@/g,"%");
	url = decodeURIComponent(url);
	return url;
}
nehnre.timeRandom = function(){
    return new Date().getTime();
}
Date.prototype.format = function(format){ 
  var o = { 
    "M+" : this.getMonth()+1, //month 
    "d+" : this.getDate(),    //day 
    "h+" : this.getHours(),   //hour 
    "m+" : this.getMinutes(), //minute 
    "s+" : this.getSeconds(), //second 
    "q+" : Math.floor((this.getMonth()+3)/3),  //quarter 
    "S" : this.getMilliseconds() //millisecond 
  } 
  if(/(y+)/.test(format)) format=format.replace(RegExp.$1, 
    (this.getFullYear()+"").substr(4 - RegExp.$1.length)); 
  for(var k in o)if(new RegExp("("+ k +")").test(format)) 
    format = format.replace(RegExp.$1, 
      RegExp.$1.length==1 ? o[k] : 
        ("00"+ o[k]).substr((""+ o[k]).length)); 
  return format; 
} 
String.prototype.format = function()
{
    var args = arguments;
    return this.replace(/\{(\d+)\}/g,                
        function(m,i){
            return args[i];
        });
}
var _console = window.console;
console = _console || {};
console.log = console.log || function(){};