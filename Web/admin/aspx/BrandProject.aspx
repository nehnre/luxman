<!DOCTYPE html >
<html>
<head>
	<meta http-equiv="content-type" content="text/html;charset=gbk" />
	<link rel="stylesheet" href="../../css/main.css" type="text/css" />
	<title>品牌项目</title>
	<script type="text/javascript" src="../../js/jquery-1.6.2.min.js"></script>
	<script type="text/javascript" src="../../js/core.js"></script>
	<script type="text/javascript" src="../ashx/brandproject.ashx?method=list&_<%= System.DateTime.Now.ToString("yyyyMMddHHmmssffff") %>"></script>
	<script type="text/javascript" src="./js/brand_project.js"></script>
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
				<img src="../../images/mainpage/n_03.jpg" alt=""></img>
			</td>
		</tr>
	</table>
	
				<table cellpadding="0" cellspacing="0" class="table" border="0" style="padding-bottom: 5px;padding-top: 5px" >
				<tr>
					<td style="width:200px;">
							分类：
							<select style="width:100px;" name="bsCountry" id="bsCountry">
							    <option value="">全部</option>
							    <option value="星级酒店">星级酒店</option>
							    <option value="星级会所">星级会所</option>
							    <option value="星级住所">星级住所</option>
							</select>
							
					</td>
					<td>		
						<input type="button" value=" 查 询 " id="btnSearch" class="shortbutton" onmouseover="this.className='shortbutton_mouseover'" onmouseout="this.className='shortbutton'"/>
						<input type="button" value=" 新 增 " id="btnNew" class="shortbutton" onmouseover="this.className='shortbutton_mouseover'" onmouseout="this.className='shortbutton'"/>
					</td>
				</tr>
			</table>
			<table class="its" cellspacing="1" id="ufile" border="0">
					<tr >
						<th nowrap="nowrap" width="200px;" >
							编号
						</th>
						<th nowrap="nowrap" width="200px;" >
							分类
						</th>
						<th nowrap="nowrap">
							内容摘要
						</th>
						<th nowrap="nowrap" width="40px;">
							操作
						</th>
					</tr>
					
					    <!-- odd even-->
						<tr class="model">
		  					<td>
								<a href="#">【233302】</a>
							</td>
		  					<td>
								类型1
							</td>
							<td>
							</td>
							<td><img src="../../images/del.gif" alt="删除" title="删除" style="cursor:pointer" /></td>
		    			</tr>
		    			<tr class="odd none"><td colspan="4" style="color:Gray">没有可以展示的项目</td></tr>
		    		
		    		  
 
			</table>
	</body>

</html>
