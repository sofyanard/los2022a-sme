<%@ Page language="c#" Codebehind="CollateralData.aspx.cs" AutoEventWireup="True" Inherits="SME.MAS.CollateralAdministration.InputNewCollateral.CollateralData" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CollateralData</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../Style.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function keluar()
		{
			if (confirm("Are you sure want to finish ?"))
				document.Fmain.submit();
		}
		
			
		</script>
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder" style="WIDTH: 482px">
							<TABLE id="Table8">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>COLLATERAL DATA</B></TD>
								</TR>
							</TABLE>
						</TD>
						<td align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg" CausesValidation="False" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../../../Body.aspx"><IMG src="../../../Image/MainMenu.jpg"></A><A href="../../../Logout.aspx" target="_top"><IMG src="../../../Image/Logout.jpg"></A></td>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="PH_SUBMENU2" runat="server" Visible="False"></asp:placeholder></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">GENERAL INFO</TD>
					</TR>
					<TR>
						<TD class="td" style="WIDTH: 483px" vAlign="top" width="483"><TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Account Number</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_ACC_NUMBER" runat="server" Width="300px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Customer Name</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CUST_NAME" runat="server" Width="300px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Account Status</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_ACC_STATUS" runat="server" Width="300px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
								</TR>
							</TABLE>
							<asp:Button id="Button1" runat="server" Visible="False" Text="Button" onclick="Button1_Click"></asp:Button>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1">District</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_DISTRIK_CODE" runat="server" Width="300px" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Cluster</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CLUSTER_CODE" runat="server" Width="300px" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Unit</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_UNIT_CODE" runat="server" Width="300px" ReadOnly="True"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<tr>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="PH_SUBMENU" runat="server"></asp:placeholder></TD>
					</tr>
					<tr runat="server" id="pnl_detail" Visible="False">
						<td colspan="2" width="100%">
							<asp:Panel Runat="server" ID="pnl_detail2" Visible="False">
								<TABLE>
									<TR>
										<TD class="tdHeader1" colSpan="2">
											<asp:label id="LBL_UPLOAD_DATE" Visible="False" Runat="server">LBL_UPLOAD_DATE</asp:label>COLLATERAL</TD>
									</TR>
									<TR>
										<TD class="td" style="WIDTH: 483px" vAlign="top" width="483">
											<TABLE id="Table4" cellSpacing="1" cellPadding="2" width="100%">
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 262px; HEIGHT: 31px">Asuransi Jiwa</TD>
													<TD style="WIDTH: 15px; HEIGHT: 31px">:</TD>
													<TD class="TDBGColorValue" style="HEIGHT: 31px" align="left">
														<asp:radiobuttonlist id="RDO_LIFE_INS" runat="server" Width="150px" AutoPostBack="True" RepeatDirection="Horizontal">
															<asp:ListItem Value="1" Selected="True">Ya</asp:ListItem>
														</asp:radiobuttonlist></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">No. Polis Ass. Jiwa</TD>
													<TD style="WIDTH: 15px">:</TD>
													<TD class="TDBGColorValue">
														<asp:textbox onkeypress="return kutip_satu()" id="TXT_POLIS_LIFE" runat="server" Width="300px"
															MaxLength="100"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Life Insurance Name</TD>
													<TD style="WIDTH: 15px">:</TD>
													<TD class="TDBGColorValue">
														<asp:textbox onkeypress="return kutip_satu()" id="TXT_LIFE_INS_NAME" runat="server" Width="300px"
															MaxLength="100"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 262px; HEIGHT: 31px">Polis Diterima</TD>
													<TD style="WIDTH: 15px; HEIGHT: 31px">:</TD>
													<TD class="TDBGColorValue" style="HEIGHT: 31px" align="left">
														<asp:radiobuttonlist id="RDO_TERIMA_LIFE_POLIS" runat="server" Width="150px" AutoPostBack="True" RepeatDirection="Horizontal">
															<asp:ListItem Value="1">Ya</asp:ListItem>
															<asp:ListItem Value="0">Tidak</asp:ListItem>
														</asp:radiobuttonlist></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 262px; HEIGHT: 31px">Agunan</TD>
													<TD style="WIDTH: 15px; HEIGHT: 31px">:</TD>
													<TD class="TDBGColorValue" style="HEIGHT: 31px" align="left">
														<asp:radiobuttonlist id="RDO_AGUNAN" runat="server" Width="150px" AutoPostBack="True" RepeatDirection="Horizontal">
															<asp:ListItem Value="1">Ya</asp:ListItem>
															<asp:ListItem Value="0">Tidak</asp:ListItem>
														</asp:radiobuttonlist></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Posisi Agunan</TD>
													<TD style="WIDTH: 15px">:</TD>
													<TD class="TDBGColorValue" style="HEIGHT: 20px">
														<asp:dropdownlist id="DDL_POSISI_AGUNAN" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">No BAST ke CA</TD>
													<TD style="WIDTH: 15px; HEIGHT: 22px">:</TD>
													<TD class="TDBGColorValue" style="HEIGHT: 22px">
														<asp:textbox onkeypress="return kutip_satu()" id="TXT_BAST_KE_CA" runat="server" Width="300px"
															MaxLength="100"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">No BAST dari&nbsp;CA</TD>
													<TD style="WIDTH: 15px; HEIGHT: 22px">:</TD>
													<TD class="TDBGColorValue">
														<asp:textbox onkeypress="return kutip_satu()" id="TXT_BAST_DARI_CA" runat="server" Width="300px"
															MaxLength="100"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Jenis Agunan</TD>
													<TD style="WIDTH: 15px">:</TD>
													<TD class="TDBGColorValue" style="HEIGHT: 20px">
														<asp:dropdownlist id="DDL_COLLATERAL_TYPE" runat="server"></asp:dropdownlist></TD>
												</TR>
											</TABLE>
										</TD>
										<TD class="td" vAlign="top" width="50%">
											<TABLE id="Table65" cellSpacing="1" cellPadding="2" width="100%">
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 262px; HEIGHT: 17px">Nama Agunan</TD>
													<TD style="WIDTH: 15px; HEIGHT: 17px">:</TD>
													<TD class="TDBGColorValue" style="HEIGHT: 17px">
														<asp:textbox onkeypress="return kutip_satu()" id="TXT_AGUNAN_NAME" runat="server" Width="300px"
															MaxLength="100"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Asuransi Kerugian</TD>
													<TD style="WIDTH: 15px; HEIGHT: 39px">:</TD>
													<TD class="TDBGColorValue" style="HEIGHT: 39px" align="left">
														<asp:radiobuttonlist id="RDO_GENERAL_INS" runat="server" Width="150px" AutoPostBack="True" RepeatDirection="Horizontal">
															<asp:ListItem Value="1">Ya</asp:ListItem>
															<asp:ListItem Value="0">Tidak</asp:ListItem>
														</asp:radiobuttonlist></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">No. Polis Ass. Kerugian</TD>
													<TD style="WIDTH: 15px">:</TD>
													<TD class="TDBGColorValue">
														<asp:textbox onkeypress="return kutip_satu()" id="TXT_POLIS_GENERAL" runat="server" Width="300px"
															MaxLength="100"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Insurance Name</TD>
													<TD style="WIDTH: 15px">:</TD>
													<TD class="TDBGColorValue">
														<asp:textbox onkeypress="return kutip_satu()" id="TXT_GENERAL_INS_NM" runat="server" Width="300px"
															MaxLength="100"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Polis Ass. Kerugian&nbsp;Diterima</TD>
													<TD style="WIDTH: 15px; HEIGHT: 39px">:</TD>
													<TD class="TDBGColorValue" style="HEIGHT: 39px" align="left">
														<asp:radiobuttonlist id="RDO_TERIMA_GENERAL_POLIS" runat="server" Width="150px" AutoPostBack="True" RepeatDirection="Horizontal">
															<asp:ListItem Value="1">Ya</asp:ListItem>
															<asp:ListItem Value="0">Tidak</asp:ListItem>
														</asp:radiobuttonlist></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Jenis Pengikatan</TD>
													<TD style="WIDTH: 15px">:</TD>
													<TD class="TDBGColorValue" style="HEIGHT: 20px">
														<asp:dropdownlist id="DDL_PENGIKATAN_TYPE" runat="server"></asp:dropdownlist></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Pengikatan Notarial</TD>
													<TD style="WIDTH: 15px; HEIGHT: 39px">:</TD>
													<TD class="TDBGColorValue" style="HEIGHT: 39px" align="left">
														<asp:radiobuttonlist id="RDO_PENGIKATAN_NOTARIAL" runat="server" Width="150px" AutoPostBack="True" RepeatDirection="Horizontal">
															<asp:ListItem Value="1">Ya</asp:ListItem>
															<asp:ListItem Value="0">Tidak</asp:ListItem>
														</asp:radiobuttonlist></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Nama Notaris</TD>
													<TD style="WIDTH: 15px">:</TD>
													<TD class="TDBGColorValue">
														<asp:textbox onkeypress="return kutip_satu()" id="TXT_NOTARIS_NAME" runat="server" Width="300px"
															MaxLength="100"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Pengikatan Diterima</TD>
													<TD style="WIDTH: 15px; HEIGHT: 39px">:</TD>
													<TD class="TDBGColorValue" style="HEIGHT: 39px" align="left">
														<asp:radiobuttonlist id="RDO_TERIMA_PENGIKATAN" runat="server" Width="150px" AutoPostBack="True" RepeatDirection="Horizontal">
															<asp:ListItem Value="1">Ya</asp:ListItem>
															<asp:ListItem Value="0">Tidak</asp:ListItem>
														</asp:radiobuttonlist></TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
								</TABLE>
							</asp:Panel>
						</td>
					</tr>
					<TR>
						<TD width="100%" colspan="2"><IFRAME id="scol" name="scol" frameBorder="0" width="100%" scrolling="auto" height="750"
								style="BORDER-RIGHT: black thin solid; BORDER-TOP: black thin solid; BORDER-LEFT: black thin solid; BORDER-BOTTOM: black thin solid">
							</IFRAME>
						</TD>
					</TR>
					<TR class="TDBGColor2" vAlign="top" align="center" runat="server" Visible="False" id="trrr">
						<TD vAlign="top" align="center" width="100%" colSpan="2">
							<asp:button id="BTN_SAVE" runat="server" Width="65px" Text="SAVE" CssClass="Button1" Visible="False"></asp:button>&nbsp;&nbsp;
							<asp:button id="BTN_FINISH" runat="server" Width="106px" Text="FINISH" CssClass="Button1" onclick="BTN_FINISH_Click"></asp:button></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 482px"></TD>
					</TR>
					<TR id="TR_FIND" runat="server" Visible="False">
						<TD class="tdNoBorder" style="WIDTH: 483px" vAlign="top" width="483">
							<TABLE id="Table20" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="129">CAO Name :</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 20px">
										<asp:dropdownlist id="DDL_CAO_NAME" runat="server"></asp:dropdownlist>
										<asp:button id="BTN_SEND" Runat="server" Text="Send" onclick="BTN_SEND_Click"></asp:button></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" vAlign="top" width="50%"></TD>
					</TR>
					<TR>
						<TD>
							<asp:Label id="LBL_DISTRIK" Runat="server" Visible="False"></asp:Label></TD>
						<TD>
							<asp:Label id="LBL_CLUSTER" Runat="server" Visible="False"></asp:Label>
							<asp:label id="LBL_DTBO" Runat="server" Visible="False"></asp:label>
							<asp:label id="LBL_REGNO" Runat="server" Visible="False"></asp:label><asp:label id="LBL_CUREF" Runat="server" Visible="False"></asp:label><asp:label id="LBL_TC" Runat="server" Visible="False"></asp:label>
						</TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
