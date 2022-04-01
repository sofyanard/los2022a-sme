<%@ Page language="c#" Codebehind="RejectApplication.aspx.cs" AutoEventWireup="True" Inherits="SME.ITTP.RejectApplication" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RejectApplication</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include  file="../include/cek_entries.html" -->
		<!-- #include  file="../include/cek_mandatoryOnly.html" -->
		<!-- #include  file="../include/ConfirmBox.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" action="RejectApplication.aspx" method="post" runat="server">
			<center>
				<TABLE id="Table4" width="100%" border="0">
					<TR>
						<TD class="tdNoBorder" width="421"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
							<TABLE id="Table6">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Reject Application</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD align="center" colSpan="2">
							<TABLE class="td" id="Table1" cellSpacing="1" cellPadding="1" width="500" border="1">
								<TR>
									<TD class="tdHeader1" colSpan="2">Search Criteria</TD>
								</TR>
								<TR>
									<TD vAlign="top" align="center" colSpan="2">
										<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD class="TDBGColor1" width="197">Nomor Aplikasi</TD>
												<TD width="9">:</TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_APPNO" runat="server" Width="200px" MaxLength="20"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="197" height="20">Nama</TD>
												<TD width="9" height="20">:</TD>
												<TD class="TDBGColorValue" width="342" height="20"><asp:textbox onkeypress="return kutip_satu()" id="TXT_NAME" runat="server" Width="200px" MaxLength="20"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="197" height="20">Tipe Pelanggan</TD>
												<TD width="9" height="20">:</TD>
												<TD class="TDBGColorValue" width="342" height="20"><asp:radiobutton id="RB_PERSONAL" runat="server" AutoPostBack="True" Text="Personal" GroupName="kriteria" oncheckedchanged="RB_PERSONAL_CheckedChanged"></asp:radiobutton>&nbsp;
													<asp:radiobutton id="RB_COMPANY" runat="server" AutoPostBack="True" Text="Company" GroupName="kriteria" oncheckedchanged="RB_COMPANY_CheckedChanged"></asp:radiobutton></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="197">Tanggal Aplikasi</TD>
												<TD width="9">:</TD>
												<TD class="TDBGColorValue" width="342"><asp:textbox onkeypress="return digitsonly()" id="TXT_DATE" runat="server" MaxLength="2" Columns="3"></asp:textbox><asp:dropdownlist id="DDL_MONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return digitsonly()" id="TXT_YEAR" runat="server" MaxLength="4" Columns="4"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="197">Nomor ID</TD>
												<TD width="9">:</TD>
												<TD class="TDBGColorValue" width="342"><asp:textbox onkeypress="return kutip_satu()" id="TXT_IDNUMBER" runat="server" Width="200px"
														MaxLength="30"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 24px" width="197">Area</TD>
												<TD style="HEIGHT: 24px" width="9">:</TD>
												<TD class="TDBGColorValue" style="HEIGHT: 24px" width="342"><asp:dropdownlist id="DDL_AREA" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_AREA_SelectedIndexChanged"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="197">Cabang/CBC/Group</TD>
												<TD width="9">:</TD>
												<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_BRANCH" runat="server" onselectedindexchanged="DDL_AREA_SelectedIndexChanged"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD vAlign="top" align="center" width="100%" colSpan="3"><asp:button id="BTN_FIND" runat="server" Width="75px" Text="Find" CssClass="button1" onclick="BTN_FIND_Click"></asp:button>&nbsp;
													<asp:button id="BTN_CLEAR" runat="server" Width="75px" Text="Clear" CssClass="button1" onclick="BTN_CLEAR_Click"></asp:button><asp:label id="Label1" runat="server" Visible="False"></asp:label></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<tr>
						<td colSpan="2"><asp:table id="oTable" runat="server" Width="100%" CellSpacing="0" CellPadding="0">
								<asp:TableRow>
									<asp:TableCell Text="Nomor Aplikasi" CssClass="tdSmallHeader"></asp:TableCell>
									<asp:TableCell Text="Nomor Referensi" CssClass="tdSmallHeader"></asp:TableCell>
									<asp:TableCell Text="Nama" CssClass="tdSmallHeader"></asp:TableCell>
									<asp:TableCell Text="Nama RM" CssClass="tdSmallHeader"></asp:TableCell>
									<asp:TableCell Text="Tanggal Aplikasi" CssClass="tdSmallHeader"></asp:TableCell>
									<asp:TableCell Text=" " CssClass="tdSmallHeader"></asp:TableCell>
								</asp:TableRow>
							</asp:table></td>
					</tr>
					<TR>
						<TD class="tdH" align="left" colSpan="2"></TD>
					</TR>
					<TR>
						<TD class="tdH" align="left" colSpan="2"><asp:label id="LBL_TEKS" runat="server" Visible="False" Font-Bold="True">Nomor Aplikasi :</asp:label><asp:label id="LBL_APREGNO" runat="server" Visible="False" Font-Bold="True"></asp:label><asp:label id="LBL_STA" runat="server" Visible="False" Font-Bold="True"></asp:label></TD>
					</TR>
					<TR>
						<TD class="tdH" align="center" colSpan="2"><asp:table id="oTable1" runat="server" Width="100%" Visible="False" CellSpacing="0" CellPadding="0">
								<asp:TableRow>
									<asp:TableCell Text="No" CssClass="tdSmallHeader"></asp:TableCell>
									<asp:TableCell Text="Product ID" CssClass="tdSmallHeader"></asp:TableCell>
									<asp:TableCell Text="Product" CssClass="tdSmallHeader"></asp:TableCell>
									<asp:TableCell Text=" " CssClass="tdSmallHeader"></asp:TableCell>
								</asp:TableRow>
							</asp:table></TD>
					</TR>
					<TR>
						<TD class="tdH" align="center" colSpan="2"></TD>
					</TR>
					<tr>
						<td class="tdH" align="center" colSpan="2">
							<TABLE class="td" id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="1">
								<TR>
									<TD vAlign="top" align="center">
										<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD class="TDBGColor1" width="200">Tipe Proses</TD>
												<TD width="13">:</TD>
												<TD class="TDBGColorValue">
													<P><asp:radiobuttonlist id="RB_PROSES" runat="server" AutoPostBack="True" RepeatLayout="Flow" RepeatDirection="Horizontal" onselectedindexchanged="RadioButtonList2_SelectedIndexChanged">
															<asp:ListItem Value="0" Selected="True">Aplikasi Ditolak</asp:ListItem>
															<asp:ListItem Value="1">Aplikasi Dibatalkan</asp:ListItem>
														</asp:radiobuttonlist></P>
												</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1"><asp:label id="LBL_PROSES" runat="server">Alasan Ditolak</asp:label></TD>
												<TD>:</TD>
												<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_REJECT" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox id="TXT_JML" runat="server" MaxLength="4" Columns="4" Visible="False"></asp:textbox><asp:textbox id="TXT_TAMPIL" runat="server" Columns="4" Visible="False"></asp:textbox><asp:textbox id="TXT_TAMPIL1" runat="server" Columns="4" Visible="False"></asp:textbox></TD>
											</TR>
										</TABLE>
									</TD>
								<tr>
									<td align="center"><asp:button id="Button2" runat="server" Text="PROSES" CssClass="button1" onclick="Button2_Click"></asp:button>&nbsp;</td>
								</tr>
							</TABLE>
						</td>
					</tr>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
