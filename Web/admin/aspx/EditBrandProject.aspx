<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"> 
<html>
<head>
	<meta http-equiv="content-type" content="text/html;charset=gbk" />
	<link rel="stylesheet" href="../../css/main.css" type="text/css" />
	<title>品牌项目</title>
	<script type="text/javascript" src="../../js/jquery-1.6.2.min.js"></script>
	<script type="text/javascript" src="../../js/ajaxupload.js"></script>
	<script type="text/javascript" src="../../js/core.js"></script>
	<script type="text/javascript" src="../../js/queryString.js"></script>
	<script type="text/javascript" src="../../js/kindeditor/kindeditor-min.js"></script>
	<script type="text/javascript" src="./js/edit_brand_project.js"></script>
	<style type="text/css">
	    .picmodel{
	        display:none;
	    }
	    .picmodel1{
	    }
	</style>
</head>
<body >
	<table border="0" class="table" cellpadding="0" cellspacing="0"  >
		<tr >
			<td>
				<img src="../../images/mainpage/n_01.jpg" alt=""/>
			</td>
			<td class="navigation_middle" >
				您现在的位置： 模块发布管理 》品牌项目
			</td>
			<td>
				<img src="../../images/mainpage/n_03.jpg" alt="" />
			</td>
		</tr>
	</table>
			<table class="its" cellspacing="1" cellpadding="5" id="ufile" border="0">
			        <tr  class="odd"><td colspan="2" height="10"></td></tr>
					<tr  class="odd">
					    <td width="200px" align="right">类型：</td>
					    <td  align="left">
					        <select name="bpType" id="bpType">
					            <option value="星级酒店">星级酒店</option>
					            <option value="星级会所">星级会所</option>
					            <option value="星级住所">星级住所</option>
					        </select>
					    </td>
					</tr>
					<tr class="odd">
					    <td  align="right">内容：</td>
					    <td  align="left"><textarea cols="100" rows="8"style="width:100%;height:300px;visibility:hidden;" id="bpContent" name="bpContent"></textarea></td>
					</tr>
					<tr class="odd">
					    <td  align="right">展示图片：</td>
					    <td  align="left"><input type="file" name="pic" id="pic" /></td>
					</tr>
					<tr class="odd picmodel">
					    <td  align="right">&nbsp;</td>
					    <td  align="left"><table border="0" cellpadding="0" cellspacing="0" width="100%">
					        <tr>
					            <td></td>
					            <td width="300" align="left"></td>
					        </tr>
					    </table></td>
					</tr>
			        <tr  class="odd">
			            <td colspan="2">
			                <input type="button" value="提 交" id="btnSubmit" class="shortbutton" onmouseover="this.className='shortbutton_mouseover'" onmouseout="this.className='shortbutton'"/>
			                <input type="button" value="取 消" id="btnCancle" class="shortbutton" onmouseover="this.className='shortbutton_mouseover'" onmouseout="this.className='shortbutton'"/>
			                
			            </td>
			        </tr>
			</table>
	</body>

</html>
