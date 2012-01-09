<html>
	<head>
		<meta http-equiv="content-type" content="text/html; charset=UTF-8" />
		<title>LUXMAN==登录</title>
		<link rel="stylesheet" href="../css/jyb.css" type="text/css" />
		<script type="text/javascript" src="../js/jquery-1.6.2.min.js"></script>
		<script type="text/javascript" src="../js/core.js"></script>
		<style type="text/css">
		    div
		    {
		    	height:40px
		    }
		    body
		    {
		    	margin-top:100px;
		</style>
		<script type="text/javascript">
		    $(function(){
		        $("#btnSubmit").click(function(){
		            var usUserName = $("#usUserName").val();
		            var usPassword = $("#usPassword").val();
		            if(!$.trim(usUserName) || !$.trim(usPassword)){
		                alert("用户名密码都不能为空！");
		                return;
		            }
		            
		            var data = "method=login&usUserName={0}&usPassword={1}".format(usUserName, usPassword);
		            $.ajax({
		                url:"./ashx/login.ashx",
		                data: data,
		                type: "POST",
		                success: function(json){
		                    console.log(json);
		                    json = nehnre.parseJSON(json);
		                    if(json.success){
		                        location.href = "index.aspx?_" + nehnre.timeRandom();
		                    } else {
		                        alert(json.msg);
		                    }
		                },
		                error: function(){
		                    alert("服务器出现故障！");
		                }
		            });
		            
		        });
		    });
		</script>
	</head>
	<body>
	    <div style="height:80px; font-size:40px; font-weight:bold;">系统登录</div>
		<div>用户名：<input type="text" name="usUserName" id="usUserName"  style="width:200px;"/></div>
		<div>密　码：<input type="password" name="usPassword" id="usPassword" style="width:200px;"/></div>
		<div><input type="button" id="btnSubmit" value="登 录" /></div>
	</body>
</html>
