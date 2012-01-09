<!DOCTYPE html >
<html>
<head>
	<meta http-equiv="content-type" content="text/html;charset=gbk" />
	<link rel="stylesheet" href="../../css/main.css" type="text/css" />
	<title>品牌理念</title>
	<script type="text/javascript" src="../../js/jquery-1.6.2.min.js"></script>
	<script type="text/javascript" src="../../js/core.js"></script>
	<script type="text/javascript" src="../ashx/brandidea.ashx?method=list&_<%= System.DateTime.Now.ToString("yyyyMMddHHmmssffff") %>"></script>
	<script type="text/javascript" src="./js/brand_idea.js"></script>
</head>
<body >
	<table border="0" class="table" cellpadding="0" cellspacing="0"  >
		<tr >
			<td>
				<img src="../../images/mainpage/n_01.jpg" alt=""/>
			</td>
			<td class="navigation_middle" >
				您现在的位置： 模块发布管理 》品牌理念
			</td>
			<td>
				<img src="../../images/mainpage/n_03.jpg" alt=""></img>
			</td>
		</tr>
	</table>
	
				<table cellpadding="0" cellspacing="0" class="table" border="0" style="padding-bottom: 5px;padding-top: 5px" >
				<tr>
					<td style="width:200px;">
							类型：
							<select style="width:100px;" name="biType" id="biType">
							    <option value="">全部</option>
							    <option value="品牌说明">品牌说明</option>
							    <option value="品牌专注">品牌专注</option>
							    <option value="品牌主张">品牌主张</option>
							</select>
					</td>
					<td>		
						<input type="button" value=" 查 询 " id="btnSearch" class="shortbutton" onmouseover="this.className='shortbutton_mouseover'" onmouseout="this.className='shortbutton'"/>
					</td>
				</tr>
			</table>
			<table class="its" cellspacing="1" id="ufile" border="0">
					<tr >
						<th nowrap >
							编号
						</th>
						<th nowrap >
							类型
						</th>
						<th nowrap>
							内容摘要
						</th>
					</tr>
					
					    <!-- odd even-->
						<tr class="model">
		  					<td width="200px;">
								<a href="#">【233302】</a>
							</td>
		  					<td width="200px;">
								类型1
							</td>
							<td>
								这是一个说法这是一个说法这是一个说法这是一个说法这是一个说法这是一个说法这是一个说法这是一个说法
								这是一个说法这是一个说法这是一个说法这是一个说法这是一个说法这是一个说法这是一个说法这是一个说法
								这是一个说法这是一个说法这是一个说法这是一个说法这是一个说法这是一个说法这是一个说法这是一个说法
								这是一个说法这是一个说法这是一个说法这是一个说法这是一个说法这是一个说法这是一个说法这是一个说法
								这是一个说法这是一个说法这是一个说法这是一个说法这是一个说法这是一个说法这是一个说法这是一个说法
							</td>			
		    			</tr>
		    			<tr class="odd none"><td colspan="3" style="color:Gray">没有可以展示的项目</td></tr>
		    		
		    		  
 
			</table>
	</body>

</html>
