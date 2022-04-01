<%@ Page language="c#" Codebehind="Notaris.aspx.cs" AutoEventWireup="false" Inherits="dbrbm.Data_Entry.Notaris" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Notaris</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<asp:button id="save_notaris" style="Z-INDEX: 101; LEFT: 440px; POSITION: absolute; TOP: 296px"
					runat="server" Width="75px" CssClass="button1" Text="Save"></asp:button>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder">
							<TABLE id="Table8">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B> Notaris</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg"></asp:imagebutton><A href="../Body.aspx"><IMG src="../../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:hyperlink id="HL_ACCOUNT" runat="server" Visible="False" NavigateUrl="CustomerInfo.aspx">Info Rekanan</asp:hyperlink><asp:hyperlink id="Hyperlink1" runat="server" Visible="False" NavigateUrl="DTBO\ListDTBO.aspx"> Perijinan</asp:hyperlink><asp:hyperlink id="Hyperlink2" runat="server" Visible="False" NavigateUrl="InfoPerusahaan.aspx">Data Perusahaan</asp:hyperlink><asp:hyperlink id="Hyperlink4" runat="server" Visible="False" NavigateUrl="TenagaAhli.aspx">Struktur Organisasi</asp:hyperlink><asp:hyperlink id="HL_HISTORY" runat="server" Visible="False" NavigateUrl="CustHistory.aspx"> Notaris</asp:hyperlink></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">Data Notaris</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px; HEIGHT: 23px">Rekening Pasar Modal</TD>
									<TD style="WIDTH: 15px; HEIGHT: 23px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 23px"><asp:textbox onkeypress="return kutip_satu()" id="rek_notaris" runat="server" Width="300px" MaxLength="100"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px; HEIGHT: 16px">Tgl. Rekening Pasar Modal</TD>
									<TD style="WIDTH: 15px; HEIGHT: 16px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 16px"><asp:textbox onkeypress="return numbersonly()" id="tglday_PM_notaris" runat="server" MaxLength="2"
											CssClass="mandatory" Columns="2"></asp:textbox><asp:dropdownlist id="tglbln_PM_notaris" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="tglth_PM_notaris" runat="server" MaxLength="4"
											CssClass="mandatory" Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px; HEIGHT: 22px">Limit Tertinggi</TD>
									<TD style="WIDTH: 15px; HEIGHT: 22px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 22px"><asp:textbox onkeypress="return kutip_satu()" id="limit_notaris" runat="server" Width="300px"
											MaxLength="100"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px; HEIGHT: 12px">SK Notaris</TD>
									<TD style="WIDTH: 15px; HEIGHT: 12px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 12px"><asp:textbox onkeypress="return kutip_satu()" id="sk_notaris" runat="server" Width="300px" MaxLength="100"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px; HEIGHT: 32px">Tanggal SK Notaris</TD>
									<TD style="WIDTH: 15px; HEIGHT: 32px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 32px"><asp:textbox onkeypress="return numbersonly()" id="tglhr_SK_notaris" runat="server" MaxLength="2"
											CssClass="mandatory" Columns="2"></asp:textbox><asp:dropdownlist id="tglbln_SK_notaris" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="tglth_SK_notaris" runat="server" MaxLength="4"
											CssClass="mandatory" Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Kota Notaris</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="kota_notaris" runat="server" Width="300px"
											MaxLength="100"></asp:textbox></TD>
								</TR> <!-- Additional Field : Right --></TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1">SK PPAT</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="SK_ppat_notaris" runat="server" Width="300px"
											MaxLength="100"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tanggal PPAT</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="tglhr_PPAT_notaris" runat="server" MaxLength="2"
											CssClass="mandatory" Columns="2"></asp:textbox><asp:dropdownlist id="tglbln_PPAT_notaris" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="tglth_PPAT_notaris" runat="server" MaxLength="4"
											CssClass="mandatory" Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Wilayah Kerja PPAT</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="wilayah_PPAT_notaris" runat="server" Width="300px"
											MaxLength="100"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Sumpah Notaris</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="sumpah_notaris" runat="server" Width="300px"
											MaxLength="100"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 20px">Tgl. Sumpah Notaris</TD>
									<TD style="WIDTH: 15px; HEIGHT: 20px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:textbox onkeypress="return numbersonly()" id="tglhr_sumpah_notaris" runat="server" MaxLength="2"
											CssClass="mandatory" Columns="2"></asp:textbox><asp:dropdownlist id="tglbln_sumpah_notaris" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="tglth_sumpah_notaris" runat="server" MaxLength="4"
											CssClass="mandatory" Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Remark</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="remark_notaris" runat="server" Width="300px"
											MaxLength="100"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TABLE>
			</center>
			<asp:Button id="clear_notaris" style="Z-INDEX: 102; LEFT: 528px; POSITION: absolute; TOP: 296px"
				runat="server" Width="75px" CssClass="button1" Text="Clear"></asp:Button>
		</form>
	</body>
</HTML>
