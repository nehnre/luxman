<!DOCTYPE html >
<html>
<head>
	<meta http-equiv="content-type" content="text/html;charset=gbk" />
	<link rel="stylesheet" href="../../css/main.css" type="text/css" />
	<title>品牌理念</title>
	<script type="text/javascript" src="../../js/jquery-1.6.2.min.js"></script>
	<script type="text/javascript" src="../../js/core.js"></script>
	<script type="text/javascript" src="../ashx/seasonselection.ashx?method=list&_<%= System.DateTime.Now.ToString("yyyyMMddHHmmssffff") %>"></script>
	<script type="text/javascript" src="./js/season_selection.js"></script>
</head>
<body >
	<table border="0" class="table" cellpadding="0" cellspacing="0"  >
		<tr >
			<td>
				<img src="../../images/mainpage/n_01.jpg" alt=""/>
			</td>
			<td class="navigation_middle" >
				您现在的位置： 模块发布管理 》当季精选
			</td>
			<td>
				<img src="../../images/mainpage/n_03.jpg" alt=""></img>
			</td>
		</tr>
	</table>
	
				<table cellpadding="0" cellspacing="0" class="table" border="0" style="padding-bottom: 5px;padding-top: 5px" >
				<tr>
					<td style="width:200px;">
							分类1：
							<select style="width:100px;" name="ssType1" id="ssType1">
							    <option value="">全部</option>
							    <option value="LuxMan服饰">LuxMan服饰</option>
							    <option value="LuxMan-spark服饰">LuxMan-spark服饰</option>
							    <option value="LuxMan家居">LuxMan家居</option>
							</select>
							
					</td>
					<td style="width:200px;">
							
							分类2：
							<select style="width:100px;" name="ssType2" id="ssType2">
							    <option value="">全部</option>
							    <option value="春夏">春夏</option>
							    <option value="秋冬">秋冬</option>
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
							类型1
						</th>
						<th nowrap="nowrap" width="200px;" >
							类型2
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
								类型2
							</td>
							<td>
							</td>
							<td><img src="../../images/del.gif" alt="删除" title="删除" style="cursor:pointer" /></td>
		    			</tr>
		    			<tr class="odd none"><td colspan="5" style="color:Gray">没有可以展示的项目</td></tr>
		    		
		    		  
 
			</table>
	</body>

</html>
