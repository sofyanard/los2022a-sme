<%@ Page language="c#" Codebehind="Listblacklist.aspx.cs" AutoEventWireup="True" Inherits="SME.DTBO.ListBlackList" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ListDTBO</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/SME/style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_all.html" -->
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder"></TD>
						<TD class="tdNoBorder" align="right"><A href="/SME/Body.aspx"><IMG src="/SME/Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="/SME/Image/logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
				</TABLE>
				<TABLE cellSpacing="1" cellPadding="1" width="568" align="center" style="WIDTH: 568px; HEIGHT: 196px"
					height="196" border="1">
					<TR>
						<TD class="tdHeader1" vAlign="top" align="center" colSpan="3" style="HEIGHT: 18px"><B>DATA 
								PEMOHON</B></TD>
					</TR>
					<tr>
						<td width="103" class="TDBGColor1" style="WIDTH: 103px">Nama Pemohon</td>
						<td width="3" style="WIDTH: 3px"></td>
						<td class="TDBGColorValue"><asp:TextBox ID="TXT_CU_NAME" Runat="server" MaxLength="30" Columns="25" onKeypress="return kutip_satu()"></asp:TextBox></td>
					</tr>
					<tr>
						<td class="TDBGColor1" style="WIDTH: 103px">Application #</td>
						<td style="WIDTH: 3px"></td>
						<td class="TDBGColorValue"><asp:TextBox ID="TXT_AP_REGNO" Runat="server" MaxLength="20" Columns="25" onKeypress="return kutip_satu()"></asp:TextBox></td>
					</tr>
					<tr>
						<td class="TDBGColor1" style="WIDTH: 103px">Reference #</td>
						<td style="WIDTH: 3px"></td>
						<td class="TDBGColorValue"><asp:TextBox ID="TXT_CU_REF" Runat="server" MaxLength="20" Columns="25" onKeypress="return kutip_satu()"></asp:TextBox></td>
					</tr>
					<tr>
						<td class="TDBGColor1" style="WIDTH: 103px">Tanggal</td>
						<td style="WIDTH: 3px"></td>
						<td class="TDBGColorValue">
							<asp:TextBox ID="TXT_AP_SIGNDATEDAY1" Runat="server" MaxLength="2" Columns="2" onKeypress="return numbersonly()"></asp:TextBox>
							<asp:DropDownList ID="DDL_AP_SIGNDATEMONTH1" Runat="server"></asp:DropDownList>
							<asp:TextBox ID="TXT_AP_SIGNDATEYEAR1" Runat="server" MaxLength="4" Columns="4" onKeypress="return numbersonly()"></asp:TextBox>
							s/d
							<asp:TextBox ID="TXT_AP_SIGNDATEDAY2" Runat="server" MaxLength="2" Columns="2" onKeypress="return numbersonly()"></asp:TextBox>
							<asp:DropDownList ID="DDL_AP_SIGNDATEMONTH2" Runat="server"></asp:DropDownList>
							<asp:TextBox ID="TXT_AP_SIGNDATEYEAR2" Runat="server" MaxLength="4" Columns="4" onKeypress="return numbersonly()"></asp:TextBox>
						</td>
					</tr>
					<tr>
						<TD class="tdHeader1" vAlign="top" align="center" colSpan="3">
							<asp:Button class="button1" ID="BTN_CARI" Text="Cari" Runat="server" onclick="BTN_CARI_Click"></asp:Button>
							<asp:Label ID="LBL_TC" Runat="server" Visible="False"></asp:Label>
						</TD>
					</tr>
				</TABLE>
				<TABLE cellSpacing="2" cellPadding="2" width="100%" align="center" border="0">
					<tr>
						<td width="100%">
							<asp:DataGrid ID="DGR_LIST" Runat="server" width="100%" CellPadding="1" PageSize="1" AutoGenerateColumns="False" onselectedindexchanged="DGR_LIST_SelectedIndexChanged">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="CU_NAME" HeaderText="Nama Pemohon">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AP_REGNO" HeaderText="Application #">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CU_REF" HeaderText="Reference #">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AP_SIGNDATE" HeaderText="Tgl. Aplikasi">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CU_PHN" HeaderText="No. Telp">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CU_RM" HeaderText="Nama RM">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn>
										<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="Linkbutton2" runat="server" CommandName="view">View</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</asp:DataGrid>
						</td>
					</tr>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
