<!DOCTYPE html >
<html>
<head>
	<meta http-equiv="content-type" content="text/html;charset=gbk" />
	<link rel="stylesheet" href="../../css/main.css" type="text/css" />
	<title>Ʒ���̵�</title>
	<script type="text/javascript" src="../../js/jquery-1.6.2.min.js"></script>
	<script type="text/javascript" src="../../js/core.js"></script>
	<script type="text/javascript" src="../ashx/brandstore.ashx?method=list&_<%= System.DateTime.Now.ToString("yyyyMMddHHmmssffff") %>"></script>
	<script type="text/javascript" src="./js/brand_store.js"></script>
</head>
<body >
	<table border="0" class="table" cellpadding="0" cellspacing="0"  >
		<tr >
			<td>
				<img src="../../images/mainpage/n_01.jpg" alt=""/>
			</td>
			<td class="navigation_middle" >
				�����ڵ�λ�ã� ģ�鷢������ ��Ʒ���̵�
			</td>
			<td>
				<img src="../../images/mainpage/n_03.jpg" alt=""></img>
			</td>
		</tr>
	</table>
	
				<table cellpadding="0" cellspacing="0" class="table" border="0" style="padding-bottom: 5px;padding-top: 5px" >
				<tr>
					<td style="width:200px;">
							���ڹ��ң�
							<select style="width:100px;" name="bsCountry" id="bsCountry">
							    <option value="">ȫ��</option>
							    <option value="�й�">�й�</option>
							    <option value="����">����</option>
							</select>
							
					</td>
					<td style="width:200px;">
							���ڳ��У�
							<select style="width:100px;" name="bsCity" id="bsCity">
							    <option value="">ȫ��</option>
							    <option value="����">����</option>
							    <option value="�Ϻ�">�Ϻ�</option>
							</select>
					</td>
					<td>		
						<input type="button" value=" �� ѯ " id="btnSearch" class="shortbutton" onmouseover="this.className='shortbutton_mouseover'" onmouseout="this.className='shortbutton'"/>
						<input type="button" value=" �� �� " id="btnNew" class="shortbutton" onmouseover="this.className='shortbutton_mouseover'" onmouseout="this.className='shortbutton'"/>
					</td>
				</tr>
			</table>
			<table class="its" cellspacing="1" id="ufile" border="0">
					<tr >
						<th nowrap="nowrap" width="200px;" >
							���
						</th>
						<th nowrap="nowrap" width="200px;" >
							���ڹ���
						</th>
						<th nowrap="nowrap" width="200px;" >
							���ڳ���
						</th>
						<th nowrap="nowrap">
							����ժҪ
						</th>
						<th nowrap="nowrap" width="40px;">
							����
						</th>
					</tr>
					
					    <!-- odd even-->
						<tr class="model">
		  					<td>
								<a href="#">��233302��</a>
							</td>
		  					<td>
								����1
							</td>
		  					<td>
								����2
							</td>
							<td>
							</td>
							<td><img src="../../images/del.gif" alt="ɾ��" title="ɾ��" style="cursor:pointer" /></td>
		    			</tr>
		    			<tr class="odd none"><td colspan="5" style="color:Gray">û�п���չʾ����Ŀ</td></tr>
		    		
		    		  
 
			</table>
	</body>

</html>
