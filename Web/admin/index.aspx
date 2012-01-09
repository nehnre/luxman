
<html>
	<head>
		<meta http-equiv="content-type" content="text/html; charset=UTF-8" />
		<title>LUXMAN==系统首页</title>
		<link rel="stylesheet" href="../css/jyb.css" type="text/css"></link>
		<script type="text/javascript" src="../js/jquery-1.2.1.js"></script>
        <script src="./ashx/login.ashx?method=loadUser&_<%= System.DateTime.Now.ToString("yyyyMMddHHmmssffff") %>" type="text/javascript"></script>
		<script type="text/javascript" src="../js/onload.js"></script>
	</head>
	<body>
		<table width="100%" height="100%" cellpadding="0" cellspacing="0" style="font-size: 12px;" border="0">
			<tr>
				<td valign="top" align="left" width="100%" colspan="2">
					<table width="100%" cellpadding="0" cellspacing="0"
						style="font-size: 12px;" border="0">
						<tr>
							<td align="left" width="573px" style="background-image: url('../images/jyb/top_01.gif'); height: 71px"></td>
							<td align="left"
								style="background-image: url('../images/jyb/top_02.gif'); height: 71px">
								&nbsp;
							</td>
							<td align="right" width="326px"
								style="background-image: url('../images/jyb/top_04.gif'); width: 328px; height: 71px;">
								<table width="100%" height="98%" cellpadding="0" cellspacing="0" style="font-size: 12px;" border="0">
									<tr>
										<td>
											<table height="100%" cellpadding="0" cellspacing="0" style="font-size: 12px;" border="0">
												<tr>
												    <td width="100"></td>
													<td width="22" height="13" align="left">
														<a href=""><img src="../images/logo.gif"alt="首页"></img></a>
													</td>
													<td width="50" align="left" style="color: #FFFFFF">
														<a href="" style="color: #FFFFFF"> 首 页 </a>
													</td>
													<td width="22" height="13" align="left">
														<a href=""><img src="../images/logo_07.gif"
																alt="注销"></img> </a>
													</td>
													<td align="left" align="left"
														style="color: #FFFFFF">
														<a href="./ashx/login.ashx?method=logout" style="color: #FFFFFF"> 注 销 </a>
													</td>
												</tr>
											</table>
										</td>
									<tr>
										<td>
											<table width="100%" height="100%" cellpadding="0"
												cellspacing="0" style="font-size: 12px;" border="0">
												<tr>
													<td align="left" width="21" height="20">
														<img src="../images/logo_15.gif"></img>
													</td>
													<td colspan="1" align="left" style="color: #FFFFFF;">
														<label id="greet"></label><label id="userName"></label>
													</td>
													<td align="left" width="21" height="20">
														<img src="../images/logo_17.gif"></img>
													</td>
													<td colspan="3" align="left"
														style="color: #FFFFFF; font-weight: bold;">
														<label id="date"></label>
													</td>
												</tr>
											</table>
										</td>
									</tr>
								</table>
							</td>
						</tr>
					</table>
				</td>
			</tr>
			<tr>
				<td valign="top" align="left" width="242" height="100%">
					<div class="menu">
								<ul id="parentUL" class="ui-accordion-container">						
										<li class="catalog" style="display: block">
											<a  href="javascript:ShowCatalog(1)" class="ui-accordion-link">系统管理</a>						
												<ul class="subCatalog" id="catalog_1">												
													<li style="display: block">															
														<a href="./aspx/ModifyPassword.aspx" target="content" onclick="javascript:setCSS(this);" style="color: #585956">修改密码</a>	
													</li>
												 </ul>
										</li>
										<li class="catalog" style="display: block">
											<a  href="javascript:ShowCatalog(2)" class="ui-accordion-link">模块发布管理</a>	
													<ul class="subCatalog" id="catalog_2">
														<li style="display: block">															
																	<a href="./aspx/BrandIdea.aspx" target="content" onclick="javascript:setCSS(this);" style="color: #585956">品牌理念</a>	
														</li>												
														<li style="display: block">															
																	<a href="./aspx/SeasonSelection.aspx" target="content" onclick="javascript:setCSS(this);" style="color: #585956">当季精选</a>	
														</li>
														
														<li style="display: block">															
																	<a href="./aspx/BrandStore.aspx" target="content"  onclick="javascript:setCSS(this);" style="color: #585956">品牌商店</a>														
														</li>
														<li style="display: block">															
																	<a href="./aspx/BrandProject.aspx" target="content" onclick="javascript:setCSS(this);" style="color: #585956">品牌项目</a>														
														</li>
												     </ul>
										</li>
								</ul>
					</div>
				</td>
				<td  valign="top" height="100%">
					<iframe name="content" id="content" width="100%" height="100%" scrolling="yes" frameborder="0" src="default_index.aspx"></iframe>
				</td>
			</tr>
			<tr>
				<td style="width: 242px; height: 29px; margin: 0px; padding: 0px;">
					<div style="background-image: url('../images/jyb/d_18.gif'); width: 242px; height: 29px; margin: 0px; padding: 0px;"></div>
				</td>
				<td
					style="width: 100%; background-image: url('../images/jyb/d_19.gif'); height: 29px; margin: 0px; padding: 0px; color: #FFFFFF;; text-align: center; vertical-align: middle;">
					<a href="#" style="color: #ffffff" >上海科流软件提供开发与技术支持</a>
				</td>
			</tr>
		</table>
		
		
		
	</body>
</html>
