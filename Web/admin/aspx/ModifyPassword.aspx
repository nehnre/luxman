<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"> 
<html>
<head>
	<meta http-equiv="content-type" content="text/html;charset=gbk" />
    <script src="./ashx/login.ashx?method=check&_<%= System.DateTime.Now.ToString("yyyyMMddHHmmssffff") %>" type="text/javascript"></script>
	<link rel="stylesheet" href="../../css/main.css" type="text/css" />
	<title>修改密码</title>
	<script type="text/javascript" src="../../js/jquery-1.6.2.min.js"></script>
	<script type="text/javascript" src="../../js/core.js"></script>
	<script type="text/javascript">
	    $(function(){
	        $("#btnSubmit").click(function(){
	             var oldPassword = $("#oldPassword").val();
	             var newPassword = $("#newPassword").val();
	             var repPassword = $("#repPassword").val();
	             if(!oldPassword){
	                alert("请输入原密码！");
	                $("#oldPassword").focus();
	                return ;
	             }
	             if(!newPassword){
	                alert("请输入新密码！");
	                $("#newPassword").focus();
	                return ;
	             }
	             if(newPassword.length < 5){
	                alert("新密码太短，要大于6位！");
	                return;
	             }
	             if(newPassword != repPassword){
	                alert("两次输入的密码不一样！");
	                return;
	             }
	             
	             var data = "method=modPassword";
	             data += "&oldPassword=" + oldPassword;
	             data += "&newPassword=" + newPassword;
	             $.ajax({
	                url:"../ashx/login.ashx",
	                data: data,
	                type: "POST",
	                success: function(json){
	                    json = nehnre.parseJSON(json);
	                    alert(json.msg);
	                    
	                },
	                error:function(){
	                    alert("系统出现故障！");
	                }
	             });
	        });
	    });
	</script>
</head>
<body >
	<table border="0" class="table" cellpadding="0" cellspacing="0"  >
		<tr >
			<td>
				<img src="../../images/mainpage/n_01.jpg" alt=""/>
			</td>
			<td class="navigation_middle" >
				您现在的位置： 系统管理 》 修改密码
			</td>
			<td>
				<img src="../../images/mainpage/n_03.jpg" alt="" />
			</td>
		</tr>
	</table>
			<table class="its" cellspacing="1" cellpadding="5" id="ufile" border="0">
			        <tr  class="odd"><td colspan="2" height="10"></td></tr>
					<tr  class="odd">
					    <td width="200px" align="right">旧密码：</td>
					    <td  align="left"><input type="password" name="oldPassword" id="oldPassword" /></td>
					</tr>
					<tr  class="odd">
					    <td width="200px" align="right">新密码：</td>
					    <td  align="left"><input type="password" name="newPassword" id="newPassword" />
					    </td>
					</tr>
					<tr class="odd">
					    <td  align="right">重复新密码：</td>
					    <td  align="left"><input type="password" name="repPassword" id="repPassword" /></td>
					</tr>
			        <tr  class="odd">
			            <td colspan="2">
			                <input type="button" value="修 改" id="btnSubmit" class="shortbutton" onmouseover="this.className='shortbutton_mouseover'" onmouseout="this.className='shortbutton'"/>
			            </td>
			        </tr>
			</table>
	</body>

</html>
