<%@ Page language="c#" Codebehind="CollateralData.aspx.cs" AutoEventWireup="True" Inherits="SME.MAS.CollateralAdministration.AcceptanceDataInput.CollateralData" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CollateralData</title>
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
						<TD class="tdNoBorder">
							<TABLE id="Table8">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>COLLATERAL DATA</B></TD>
								</TR>
							</TABLE>
						</TD>
						<td align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg" CausesValidation="False" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../../../Body.aspx"><IMG src="../../../Image/MainMenu.jpg"></A><A href="../../../Logout.aspx" target="_top"><IMG src="../../../Image/Logout.jpg"></A></td>
					</TR>
					<tr>
						<td></td>
					</tr>
					<TR>
						<TD class="tdHeader1" colSpan="2">GENERAL INFO</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Account Number</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_ACC_NUMBER" runat="server" BorderStyle="None" ReadOnly="True" Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Customer Name</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CUST_NAME" runat="server" BorderStyle="None" ReadOnly="True" Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Account Status</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_ACC_STATUS" runat="server" BorderStyle="None" ReadOnly="True" Width="300px"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1">District</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_DISTRIK_CODE" runat="server" ReadOnly="True" Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Cluster</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CLUSTER_CODE" runat="server" ReadOnly="True" Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Unit</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_UNIT_CODE" runat="server" ReadOnly="True" Width="300px"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR id="tr1" runat="server" Visible="false">
						<TD class="tdHeader1" colSpan="2">COLLATERAL</TD>
					</TR>
					<TR id="tr2" runat="server" Visible="false">
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table4" cellSpacing="1" cellPadding="2" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 262px; HEIGHT: 31px">Asuransi Jiwa</TD>
									<TD style="WIDTH: 15px; HEIGHT: 31px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 31px" align="left"><asp:radiobuttonlist id="RDO_LIFE_INS" runat="server" Width="150px" RepeatDirection="Horizontal" AutoPostBack="True">
											<asp:ListItem Value="1">Ya</asp:ListItem>
											<asp:ListItem Value="0">Tidak</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">No. Polis Ass. Jiwa</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_POLIS_LIFE" runat="server" Width="300px"
											MaxLength="100"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Life Insurance Name</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_LIFE_INS_NAME" runat="server" Width="300px"
											MaxLength="100"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 262px; HEIGHT: 31px">Polis Diterima</TD>
									<TD style="WIDTH: 15px; HEIGHT: 31px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 31px" align="left"><asp:radiobuttonlist id="RDO_TERIMA_LIFE_POLIS" runat="server" Width="150px" RepeatDirection="Horizontal"
											AutoPostBack="True">
											<asp:ListItem Value="1">Ya</asp:ListItem>
											<asp:ListItem Value="0">Tidak</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 262px; HEIGHT: 31px">Agunan</TD>
									<TD style="WIDTH: 15px; HEIGHT: 31px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 31px" align="left"><asp:radiobuttonlist id="RDO_AGUNAN" runat="server" Width="150px" RepeatDirection="Horizontal" AutoPostBack="True">
											<asp:ListItem Value="1">Ya</asp:ListItem>
											<asp:ListItem Value="0">Tidak</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Posisi Agunan</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:dropdownlist id="DDL_POSISI_AGUNAN" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">No BAST ke CA</TD>
									<TD style="WIDTH: 15px; HEIGHT: 22px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 22px"><asp:textbox onkeypress="return kutip_satu()" id="TXT_BAST_KE_CA" runat="server" Width="300px"
											MaxLength="100"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">No BAST dari&nbsp;CA</TD>
									<TD style="WIDTH: 15px; HEIGHT: 22px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_BAST_DARI_CA" runat="server" Width="300px"
											MaxLength="100"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jenis Agunan</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:dropdownlist id="DDL_COLLATERAL_TYPE" runat="server"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table65" cellSpacing="1" cellPadding="2" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 262px; HEIGHT: 17px">Nama Agunan</TD>
									<TD style="WIDTH: 15px; HEIGHT: 17px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox onkeypress="return kutip_satu()" id="TXT_AGUNAN_NAME" runat="server" Width="300px"
											MaxLength="100"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Asuransi Kerugian</TD>
									<TD style="WIDTH: 15px; HEIGHT: 39px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 39px" align="left"><asp:radiobuttonlist id="RDO_GENERAL_INS" runat="server" Width="150px" RepeatDirection="Horizontal" AutoPostBack="True">
											<asp:ListItem Value="1">Ya</asp:ListItem>
											<asp:ListItem Value="0">Tidak</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">No. Polis Ass. Kerugian</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_POLIS_GENERAL" runat="server" Width="300px"
											MaxLength="100"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Insurance Name</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_GENERAL_INS_NM" runat="server" Width="300px"
											MaxLength="100"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Polis Ass. Kerugian&nbsp;Diterima</TD>
									<TD style="WIDTH: 15px; HEIGHT: 39px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 39px" align="left"><asp:radiobuttonlist id="RDO_TERIMA_GENERAL_POLIS" runat="server" Width="150px" RepeatDirection="Horizontal"
											AutoPostBack="True">
											<asp:ListItem Value="1">Ya</asp:ListItem>
											<asp:ListItem Value="0">Tidak</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Pengikatan Notarial</TD>
									<TD style="WIDTH: 15px; HEIGHT: 39px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 39px" align="left"><asp:radiobuttonlist id="RDO_PENGIKATAN_NOTARIAL" runat="server" Width="150px" RepeatDirection="Horizontal"
											AutoPostBack="True">
											<asp:ListItem Value="1">Ya</asp:ListItem>
											<asp:ListItem Value="0">Tidak</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jenis Pengikatan</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:dropdownlist id="DDL_PENGIKATAN_TYPE" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nama Notaris</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_NOTARIS_NAME" runat="server" Width="300px"
											MaxLength="100"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Pengikatan Diterima</TD>
									<TD style="WIDTH: 15px; HEIGHT: 39px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 39px" align="left"><asp:radiobuttonlist id="RDO_TERIMA_PENGIKATAN" runat="server" Width="150px" RepeatDirection="Horizontal"
											AutoPostBack="True">
											<asp:ListItem Value="1">Ya</asp:ListItem>
											<asp:ListItem Value="0">Tidak</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<tr id="tr3a" align="center" runat="server" Visible="false">
						<td class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2"><asp:button id="BTN_SAVE" runat="server" Width="65px" CssClass="Button1" Text="SAVE" onclick="BTN_SAVE_Click"></asp:button>&nbsp;&nbsp;
							<asp:button id="BTN_FINISH" runat="server" Width="82px" CssClass="Button1" Text="FINISH" onclick="BTN_FINISH_Click"></asp:button>&nbsp;&nbsp;
							<asp:button id="BTN_TO_MKA" runat="server" Width="122px" CssClass="Button1" Text="RETURN TO MKA" onclick="BTN_TO_MKA_Click"></asp:button></td>
					</tr>
					<tr>
						<td></td>
					</tr>
					<TR runat="server" id="trcolreq" Visible="false">
						<TD class="tdHeader1" colSpan="2">COLLATERAL REQUEST</TD>
					</TR>
					<TR runat="server" id="trcolreq2" Visible="false">
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table4" cellSpacing="1" cellPadding="2" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 141px">Nama Agunan</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_AGUNAN_NM" runat="server" ReadOnly="True"
											Width="300px" MaxLength="100"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 141px">No BAST dari CA</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_BAST_DR_CA" runat="server" ReadOnly="True"
											Width="300px" MaxLength="100"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table65" cellSpacing="1" cellPadding="2" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 254px; HEIGHT: 17px">Tgl. Kirim</TD>
									<TD style="WIDTH: 7px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_KIRIM" runat="server" ReadOnly="True"
											Width="24px" MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_BLN_KIRIM" runat="server" Enabled="False"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_KIRIM" runat="server" ReadOnly="True"
											Width="36px" MaxLength="4" Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 254px">Request Reason</TD>
									<TD style="WIDTH: 7px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:dropdownlist id="DDL_REASON" runat="server" Enabled="False"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<tr>
						<td></td>
					</tr>
					<TR id="tra" runat="server" Visible="false">
						<TD class="tdHeader1" colSpan="2">STATUS REQUEST</TD>
					</TR>
					<TR id="trb" runat="server" Visible="false">
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table4" cellSpacing="1" cellPadding="2" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 144px; HEIGHT: 23px" width="145">Pick Up Date</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_PICK_UP" runat="server" Width="24px"
											MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_BLN_PICK_UP" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_PICK_UP" runat="server" Width="36px"
											MaxLength="4" Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">No BAST ke CA</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_BAST_KE_CA_REQ" runat="server" Width="300px"
											MaxLength="100"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table65" cellSpacing="1" cellPadding="2" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 262px; HEIGHT: 17px">Tgl. Kirim ke Unit</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_KIRIM_UNIT" runat="server" Width="24px"
											MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_BLN_KIRIM_UNIT" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_KIRIM_UNIT" runat="server" Width="36px"
											MaxLength="4" Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Catatan</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CAT_ATAS_REQUEST" runat="server" Width="300px"
											MaxLength="100"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<tr align="center" runat="server" id="trprocess" Visible="false">
						<td class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2"><asp:dropdownlist id="ddl_process1" runat="server"></asp:dropdownlist><asp:button id="btn_process1" runat="server" CssClass="button1" Text="Proses" onclick="btn_process1_Click"></asp:button>
							<asp:button id="BTN_ACCEPT" runat="server" Width="65px" Visible="False" CssClass="Button1" Text="ACCEPT" onclick="BTN_ACCEPT_Click"></asp:button>&nbsp;&nbsp;
							<asp:button id="BTN_RETURN_TO_CA" runat="server" Width="110px" Visible="False" CssClass="Button1"
								Text="RETURN TO CA" onclick="BTN_RETURN_TO_CA_Click"></asp:button></td>
					</tr>
					<TR id="TR_FIND" runat="server" Visible="False">
						<TD class="tdNoBorder" vAlign="top" width="50%">
							<TABLE id="Table20" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="129">CA Name :</TD>
									<TD style="WIDTH: 8px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:dropdownlist id="DDL_CA_NAME" runat="server"></asp:dropdownlist><asp:button id="BTN_SEND" Text="Send" Runat="server" onclick="BTN_SEND_Click"></asp:button></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" vAlign="top" width="50%"></TD>
					</TR>
					<tr align="center">
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="PH_SUBMENU" runat="server"></asp:placeholder></TD>
					</tr>
					<tr align="center">
						<td width="100%" colSpan="2"><IFRAME id="scol" style="BORDER-RIGHT: black thin solid; BORDER-TOP: black thin solid; BORDER-LEFT: black thin solid; BORDER-BOTTOM: black thin solid"
								name="scol" frameBorder="0" width="100%" scrolling="auto" height="750"> </IFRAME>
						</td>
					</tr>
					<tr>
						<td><asp:label id="LBL_DISTRIK" Visible="False" Runat="server"></asp:label></td>
						<td><asp:label id="LBL_CLUSTER" Visible="False" Runat="server"></asp:label><asp:label id="Label1" Visible="False" Runat="server"></asp:label></td>
					</tr>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
