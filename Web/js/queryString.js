(function(){var a=window.nehnre;a=a||{};a.common=a.common||{};a.queryString=a.common.queryString=function(){if(a._args)return a._args;var c=location.search.length>0?location.search.substring(1):"";a._args={};c=c.split("&");var b=null,e=null;b=null;for(var d=0;d<c.length;d++){b=c[d].split("=");e=decodeURIComponent(b[0]);b=decodeURIComponent(b[1]);a._args[e]=b}return a._args};window.nehnre=a})();