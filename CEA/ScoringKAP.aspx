<%@ Page language="c#" Codebehind="ScoringKAP.aspx.cs" AutoEventWireup="True" Inherits="SME.CEA.ScoringKAP" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ScoringKAP</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function keluar()
		{
			if (confirm("Are you sure want to finish ?"))
				document.Fmain.submit();
		}
		
			
		</script>
		<!-- #include  file="../include/cek_entries.html" -->
		<!-- #include  file="../include/cek_mandatory.html" -->
		<!-- #include  file="../include/cek_mandatoryOnly.html" -->
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Fmain" name="Fmain" action="SearchCustomer.aspx?mc=030" method="post" target="main">
		</form>
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder">
							<TABLE id="Table8">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B> Scoring - KAP</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">General Information</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px; HEIGHT: 17px">Kantor Pusat/Kanwil</TD>
									<TD style="WIDTH: 15px; HEIGHT: 17px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_AREAID" runat="server" ReadOnly="True" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nama User</TD>
									<TD></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_AP_RELMNGR" runat="server" Width="200px" BorderStyle="None"></asp:textbox><asp:label id="LBL_AP_RELMNGR" runat="server" Visible="False"></asp:label></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="150">Tanggal Aplikasi</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_AP_SIGNDATE_DAY" runat="server" Width="24px"
											Columns="4" MaxLength="2"></asp:textbox><asp:dropdownlist id="DDL_AP_SIGNDATE_MONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_AP_SIGNDATE_YEAR" runat="server" Width="36px"
											Columns="4" MaxLength="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="150">Tanggal Penerusan</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="Textbox2" runat="server" Width="24px" Columns="4"
											MaxLength="2"></asp:textbox><asp:dropdownlist id="Dropdownlist1" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="Textbox1" runat="server" Width="36px" Columns="4"
											MaxLength="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="150">Application No.</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_AP_REGNO" runat="server" ReadOnly="True" Width="200px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD width="150"></TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_REF" runat="server" Visible="False"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="tdHeader1" vAlign="top" width="50%" colSpan="2">Scoring KAP<asp:label id="lbl_no_registrasi" runat="server" Visible="False"></asp:label><asp:label id="lbl_cu_nama" runat="server"></asp:label><asp:label id="lbl_cu_kota" runat="server" Visible="False"></asp:label><asp:label id="lbl_comkota" runat="server" Visible="False"></asp:label></TD>
					</TR>
					<TR>
						<TD vAlign="top" width="50%" colSpan="2">
							<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR id="TR_PERSONAL" runat="server">
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table20" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 297px">Pengalaman Managing Partner</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return kutip_satu()" id="Textbox3" runat="server" Width="152px" MaxLength="15"></asp:textbox>Tahun</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 297px">Jumlah Partner</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return kutip_satu()" id="Textbox4" runat="server" Width="152px" MaxLength="15"></asp:textbox>Orang</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 297px">Jumlah Izin Akuntan Publik</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return kutip_satu()" id="Textbox6" runat="server" Width="152px" MaxLength="15"></asp:textbox>Orang</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 297px">Jumlah Tenaga Auditor</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return kutip_satu()" id="Textbox18" runat="server" Width="152px" MaxLength="15"></asp:textbox>Orang</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 297px">Jumlah Tenaga Auditor Tetap</TD>
									<TD></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px">
										<asp:textbox onkeypress="return kutip_satu()" id="Textbox20" runat="server" Width="152px" MaxLength="15"></asp:textbox>Orang</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 297px">Jumlah Akuntan Publik berijin dengan 
										pengalaman min. 8 tahun</TD>
									<TD></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px">
										<asp:textbox onkeypress="return kutip_satu()" id="Textbox19" runat="server" Width="152px" MaxLength="15"></asp:textbox>Orang</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 297px">Jumlah Partner yang terdaftar di 
										Bapepam</TD>
									<TD></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px">
										<asp:textbox onkeypress="return kutip_satu()" id="Textbox5" runat="server" Width="153px" MaxLength="15"></asp:textbox>Orang</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 297px">
										Jumlah Cabang</TD>
									<TD></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px">
										<asp:textbox onkeypress="return kutip_satu()" id="Textbox7" runat="server" Width="152px" MaxLength="15"></asp:textbox>Kantor</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 297px">Jumlah Klien dengan Asset yang diaudit 
										&gt; Rp. 300 M dan atau perusahaan Tbk.</TD>
									<TD></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px">
										<asp:textbox onkeypress="return kutip_satu()" id="Textbox8" runat="server" Width="152px" MaxLength="15"></asp:textbox></TD>
								</TR> <!-- Additional Field : Right --></TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" runat="server">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 360px; HEIGHT: 21px">Terdapat Partner yang 
										Terdaftar di Bapepam</TD>
									<TD style="HEIGHT: 21px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 21px">
										<asp:radiobutton id="Radiobutton15" runat="server" GroupName="OPT_LMP_D" Text="Ada"></asp:radiobutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:radiobutton id="Radiobutton14" runat="server" GroupName="OPT_LMP_D" Text="Tidak Ada" Checked="True"></asp:radiobutton></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 360px; HEIGHT: 21px">Afiliasi dengan Kantor 
										Akuntan Publik Asing (KAPA) atau Organisasi Audit Asing (OAA)</TD>
									<TD style="HEIGHT: 21px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 21px">
										<asp:radiobutton id="Radiobutton11" runat="server" GroupName="OPT_LMP_D" Text="Ada"></asp:radiobutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:radiobutton id="Radiobutton10" runat="server" GroupName="OPT_LMP_D" Text="Tidak Ada" Checked="True"></asp:radiobutton></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 360px; HEIGHT: 21px">Afiliasi dengan Pihak 
										Lain</TD>
									<TD style="HEIGHT: 21px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 21px">
										<asp:radiobutton id="Radiobutton13" runat="server" GroupName="OPT_LMP_D" Text="Ada"></asp:radiobutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:radiobutton id="Radiobutton12" runat="server" GroupName="OPT_LMP_D" Text="Tidak Ada" Checked="True"></asp:radiobutton></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 360px; HEIGHT: 21px">Reputasi</TD>
									<TD style="HEIGHT: 21px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 21px">
										<asp:radiobutton id="Radiobutton4" runat="server" Text="Baik" GroupName="OPT_LMP_D"></asp:radiobutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:radiobutton id="Radiobutton3" runat="server" Text="Cukup" GroupName="OPT_LMP_D" Checked="True"></asp:radiobutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:radiobutton id="Radiobutton5" runat="server" Text="Kurang" GroupName="OPT_LMP_D"></asp:radiobutton></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 360px">Kinerja Pembayaran Klaim</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:radiobutton id="Radiobutton6" runat="server" Text="Baik" GroupName="OPT_LMP_D"></asp:radiobutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:radiobutton id="Radiobutton2" runat="server" Text="Cukup" GroupName="OPT_LMP_D" Checked="True"></asp:radiobutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:radiobutton id="Radiobutton1" runat="server" Text="Kurang" GroupName="OPT_LMP_D"></asp:radiobutton></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 360px">Pelayanan</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:radiobutton id="Radiobutton9" runat="server" Text="Baik" GroupName="OPT_LMP_D"></asp:radiobutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:radiobutton id="Radiobutton8" runat="server" Text="Cukup" GroupName="OPT_LMP_D" Checked="True"></asp:radiobutton>&nbsp;&nbsp;&nbsp;&nbsp; 
										&nbsp;
										<asp:radiobutton id="Radiobutton7" runat="server" Text="Kurang" GroupName="OPT_LMP_D"></asp:radiobutton></TD>
								</TR> <!-- Additional Field : Right --></TABLE>
						</TD>
					</TR>
					<TR width="100%">
						<TD colSpan="2"></TD>
					</TR>
					<tr>
						<td class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2"><asp:button id="BTN_SAVEQUAL" runat="server" CssClass="Button1" Text="Hitung"></asp:button>&nbsp;&nbsp;&nbsp;
							<asp:button id="Button1" runat="server" CssClass="Button1" Text="Clear"></asp:button>&nbsp;&nbsp;
							<asp:button id="Button2" runat="server" CssClass="Button1" Text="Print"></asp:button></td>
					</tr>
					<tr>
						<td class="td" align="center" colSpan="2"></td>
					</tr>
					<tr>
						<td class="td" colSpan="2">
							<table width="100%">
								<tr>
									<TD class="TDBGColor1" width="20%">
										Skor Quantitatif</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue" width="30%"></TD>
									<TD class="TDBGColor1" width="20%">
										Total Skor</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue" width="30%">
										<asp:label id="LBL_QSCORE" runat="server"></asp:label></TD>
								</tr>
								<TR>
									<TD class="TDBGColor1" width="20%">Skor Qualitatif</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue" width="30%"></TD>
									<TD class="TDBGColor1" width="20%">Rekomendasi</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue" width="30%">
										<asp:label id="LBL_QREC" runat="server"></asp:label></TD>
								</TR>
							</table>
						</td>
					</tr>
					<tr>
						<td class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2"></td>
					</tr>
					<tr>
						<td class="td" colSpan="2">
							<table width="100%">
							</table>
						</td>
					</tr>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
