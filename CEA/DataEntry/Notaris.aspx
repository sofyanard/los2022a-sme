<%@ Page language="c#" Codebehind="Notaris.aspx.cs" AutoEventWireup="True" Inherits="SME.CEA.DataEntry.Notaris" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Notaris</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
				<TR>
					<TD class="tdNoBorder">
						<TABLE id="Table8">
							<TR>
								<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Notaris</B></TD>
							</TR>
						</TABLE>
					</TD>
					<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg"></asp:imagebutton><A href="../Body.aspx"><IMG src="../../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A></TD>
				</TR>
				<TR>
					<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="MenuNotaris" runat="server"></asp:placeholder></TD>
				</TR>
				<TR>
					<TD class="tdHeader1" colSpan="2">Data Notaris</TD>
				</TR>
				<TR>
					<TD class="td" vAlign="top" width="50%">
						<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 177px; HEIGHT: 12px">SK Notaris</TD>
								<TD style="WIDTH: 15px; HEIGHT: 12px"></TD>
								<TD class="TDBGColorValue" style="HEIGHT: 12px"><asp:textbox onkeypress="return kutip_satu()" id="TXT_SK_NOTARIS" runat="server" Width="300px"
										MaxLength="100"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 177px; HEIGHT: 22px">Tanggal SK Notaris</TD>
								<TD style="WIDTH: 15px; HEIGHT: 22px"></TD>
								<TD class="TDBGColorValue" style="HEIGHT: 22px"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_SK" runat="server" MaxLength="2" Columns="2"></asp:textbox><asp:dropdownlist id="DDL_BLN_SK" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_SK" runat="server" MaxLength="4" Columns="4"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Sumpah Notaris</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_SUMPAH_NOTARIS" runat="server" Width="300px"
										MaxLength="100"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="HEIGHT: 20px">Tgl. Sumpah Notaris</TD>
								<TD style="WIDTH: 15px; HEIGHT: 20px"></TD>
								<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_SUMPAH" runat="server" MaxLength="2"
										Columns="2"></asp:textbox><asp:dropdownlist id="DDL_BLN_SUMPAH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_SUMPAH" runat="server" MaxLength="4"
										Columns="4"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 177px">Kota Notaris</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_KOTA_NOTARIS" runat="server" Width="300px"
										MaxLength="100"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 262px; HEIGHT: 39px">Anggota Koperasi</TD>
								<TD style="WIDTH: 15px; HEIGHT: 39px"></TD>
								<TD class="TDBGColorValue" style="HEIGHT: 39px" align="left"><asp:radiobuttonlist id="RDO_KOPERASI" runat="server" Width="150px" RepeatDirection="Horizontal">
										<asp:ListItem Value="Y" Selected="True">Ya</asp:ListItem>
										<asp:ListItem Value="N">Tidak</asp:ListItem>
									</asp:radiobuttonlist></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">No. SK Koperasi</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_NO_KOP" runat="server" Width="300px" MaxLength="100"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Tgl. SK Koperasi</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_KOP" runat="server" MaxLength="2"
										Columns="2"></asp:textbox><asp:dropdownlist id="DDL_BLN_KOP" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_KOP" runat="server" MaxLength="4"
										Columns="4"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 262px; HEIGHT: 39px">Anggota Bapepam</TD>
								<TD style="WIDTH: 15px; HEIGHT: 39px"></TD>
								<TD class="TDBGColorValue" style="HEIGHT: 39px" align="left"><asp:radiobuttonlist id="RDO_BAPEPAM" runat="server" Width="150px" RepeatDirection="Horizontal">
										<asp:ListItem Value="Y" Selected="True">Ya</asp:ListItem>
										<asp:ListItem Value="N">Tidak</asp:ListItem>
									</asp:radiobuttonlist></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">No. SK Bapepam</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_NO_BAPEPAM" runat="server" Width="300px"
										MaxLength="100"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Tgl. SK Bapepam</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_BAPEPAM" runat="server" MaxLength="2"
										Columns="2"></asp:textbox><asp:dropdownlist id="DDL_BLN_BAPEPAM" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_BAPEPAM" runat="server" MaxLength="4"
										Columns="4"></asp:textbox></TD>
							</TR>
						</TABLE>
					</TD>
					<TD class="td" vAlign="top" width="50%">
						<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD class="TDBGColor1">SK PPAT</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_SK_PPAT" runat="server" Width="300px" MaxLength="100"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Tgl. PPAT</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_PPAT" runat="server" MaxLength="2"
										Columns="2"></asp:textbox><asp:dropdownlist id="DDL_BLN_PPAT" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_PPAT" runat="server" MaxLength="4"
										Columns="4"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Sumpah PPAT</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_SUMPAH_PPAT" runat="server" Width="300px"
										MaxLength="100"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Tgl. Sumpah PPAT</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_SUMPAH_PPAT" runat="server" MaxLength="2"
										Columns="2"></asp:textbox><asp:dropdownlist id="DDL_BLN_SUMPAH_PPAT" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_SUMPAH_PPAT" runat="server" MaxLength="4"
										Columns="4"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Wilayah Kerja PPAT</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_PPAT_LOKASI" runat="server" Width="300px"
										MaxLength="100"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 262px; HEIGHT: 39px">Anggota INI</TD>
								<TD style="WIDTH: 15px; HEIGHT: 39px"></TD>
								<TD class="TDBGColorValue" style="HEIGHT: 39px" align="left"><asp:radiobuttonlist id="RDO_INI" runat="server" Width="150px" RepeatDirection="Horizontal">
										<asp:ListItem Value="Y" Selected="True">Ya</asp:ListItem>
										<asp:ListItem Value="N">Tidak</asp:ListItem>
									</asp:radiobuttonlist></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">No. SK INI</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_NO_INI" runat="server" Width="300px" MaxLength="100"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Tgl. SK INI</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_INI" runat="server" MaxLength="2"
										Columns="2"></asp:textbox><asp:dropdownlist id="DDL_BLN_INI" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_BLN_INI" runat="server" MaxLength="4"
										Columns="4"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 177px; HEIGHT: 23px">Rekanan Pasar Modal</TD>
								<TD style="WIDTH: 15px; HEIGHT: 23px"></TD>
								<TD class="TDBGColorValue" style="HEIGHT: 23px"><asp:textbox onkeypress="return kutip_satu()" id="TXT_REK_BURSA" runat="server" Width="300px"
										MaxLength="100"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 177px; HEIGHT: 16px">Tgl. Rekanan Pasar Modal</TD>
								<TD style="WIDTH: 15px; HEIGHT: 16px"></TD>
								<TD class="TDBGColorValue" style="HEIGHT: 16px"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_BURSA" runat="server" MaxLength="2"
										Columns="2"></asp:textbox><asp:dropdownlist id="DDL_BLN_BURSA" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_BURSA" runat="server" MaxLength="4"
										Columns="4"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 177px; HEIGHT: 22px">Limit Tertinggi</TD>
								<TD style="WIDTH: 15px; HEIGHT: 22px"></TD>
								<TD class="TDBGColorValue" style="HEIGHT: 22px"><asp:textbox onkeypress="return kutip_satu()" id="TXT_HIGH_LIMIT" runat="server" Width="300px"
										MaxLength="100"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Remark</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_REMARK" runat="server" Width="300px" MaxLength="100"></asp:textbox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%" colSpan="2"><asp:button id="BTN_SAVE_NOTARIS" runat="server" Text="Save" CssClass="button1" onclick="BTN_SAVE_NOTARIS_Click"></asp:button><asp:button id="BTN_CLEAR_NOTARIS" runat="server" Text="Clear" CssClass="button1" onclick="BTN_CLEAR_NOTARIS_Click"></asp:button></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
