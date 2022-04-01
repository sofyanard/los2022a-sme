<%@ Page language="c#" Codebehind="UpdateRequestAgunan.aspx.cs" AutoEventWireup="True" Inherits="SME.MAS.CollateralAdministration.PickUpSendCollateral.UpdateRequestAgunan" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>UpdateRequestAgunan</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
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
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>UPDATE&nbsp;REQUEST 
											AGUNAN</B></TD>
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
					<tr>
						<td>
							<asp:Label id="Label1" runat="server" Visible="False">Label</asp:Label></td>
					</tr>
					<TR>
						<TD class="tdHeader1" colSpan="2">COLLATERAL INFO</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table4" cellSpacing="1" cellPadding="2" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 141px">Nama Agunan</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_AGUNAN_NM" runat="server" Width="300px"
											MaxLength="100" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 141px">No BAST dari CA</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_BAST_DR_CA" runat="server" Width="300px"
											MaxLength="100" ReadOnly="True"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table65" cellSpacing="1" cellPadding="2" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 254px; HEIGHT: 17px">
										Tgl. Kirim</TD>
									<TD style="WIDTH: 7px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_KIRIM" runat="server" Width="24px"
											MaxLength="2" Columns="4" ReadOnly="True"></asp:textbox><asp:dropdownlist id="DDL_BLN_KIRIM" runat="server" Enabled="False"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_KIRIM" runat="server" Width="36px"
											MaxLength="4" Columns="4" ReadOnly="True"></asp:textbox></TD>
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
					<TR runat="server" id="trreq1" Visible=False>
						<TD class="tdHeader1" colSpan="2">STATUS REQUEST</TD>
					</TR>
					<TR runat="server" id="trreq2" Visible=False>
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
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_BAST_KE_CA" runat="server" Width="300px"
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
					<tr align="center" runat="server" id="trreq3">
						<td class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2">
							<asp:dropdownlist id="ddl_process1" runat="server" AutoPostBack="True" onselectedindexchanged="ddl_process1_SelectedIndexChanged"></asp:dropdownlist>
							<asp:dropdownlist id="DDL_CAO_NAME" runat="server" Visible="False"></asp:dropdownlist>
							<asp:button id="btn_process1" runat="server" Text="Proses" CssClass="button1" onclick="btn_process1_Click"></asp:button>
							<asp:button id="BTN_SAVE" runat="server" Width="65px" CssClass="Button1" Text="SAVE" Visible="False" onclick="BTN_SAVE_Click"></asp:button>&nbsp;&nbsp;
							<asp:button id="BTN_CLEAR" runat="server" Width="67px" CssClass="Button1" Text="CLEAR" Visible="False" onclick="BTN_CLEAR_Click"></asp:button>&nbsp;&nbsp;
						</td>
					</tr>
					<tr>
						<td></td>
					</tr>
					<TR id="TR_FIND" runat="server" Visible="False">
						<TD class="tdNoBorder" vAlign="top" width="50%">
							<TABLE id="Table20" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="129">CAO Name :</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 20px">
										<asp:dropdownlist id="DDL_CAO_NAME1" runat="server"></asp:dropdownlist>
										<asp:button id="BTN_SEND" Runat="server" Text="Send" onclick="BTN_SEND_Click"></asp:button>
									</TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" vAlign="top" width="50%"></TD>
					</TR>
					<tr>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="PH_SUBMENU" runat="server"></asp:placeholder></TD>
					</tr>
					<TR>
						<TD width="100%" colspan="2"><IFRAME id="scol" name="scol" frameBorder="0" width="100%" scrolling="auto" height="750"
								style="BORDER-RIGHT: black thin solid; BORDER-TOP: black thin solid; BORDER-LEFT: black thin solid; BORDER-BOTTOM: black thin solid">
							</IFRAME>
						</TD>
					</TR>
					<tr>
						<td><asp:Label ID="LBL_DISTRIK" Runat="server" Visible="False"></asp:Label></td>
						<td><asp:Label ID="LBL_CLUSTER" Runat="server" Visible="False"></asp:Label></td>
					</tr>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
