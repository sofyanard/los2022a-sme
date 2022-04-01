<%@ Page language="c#" Codebehind="ScoringBrokerAsuransi.aspx.cs" AutoEventWireup="True" Inherits="SME.CEA.ScoringBrokerAsuransi" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ScoringBrokerAsuransi</title>
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
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Scoring - Broker Asuransi</B></TD>
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
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_AREAID" runat="server" Width="100%" ReadOnly="True"></asp:textbox></TD>
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
											MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_AP_SIGNDATE_MONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_AP_SIGNDATE_YEAR" runat="server" Width="36px"
											MaxLength="4" Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="150">Tanggal Penerusan</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="Textbox2" runat="server" Width="24px" MaxLength="2"
											Columns="4"></asp:textbox><asp:dropdownlist id="Dropdownlist1" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="Textbox1" runat="server" Width="36px" MaxLength="4"
											Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="150">Application No.</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_AP_REGNO" runat="server" Width="200px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
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
						<TD class="tdHeader1" vAlign="top" width="50%" colSpan="2">Scoring Broker Asuransi<asp:label id="lbl_no_registrasi" runat="server" Visible="False"></asp:label><asp:label id="lbl_cu_nama" runat="server"></asp:label><asp:label id="lbl_cu_kota" runat="server" Visible="False"></asp:label><asp:label id="lbl_comkota" runat="server" Visible="False"></asp:label></TD>
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
									<TD class="TDBGColor1">Pengalaman Pengurus/Manajemen</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="Textbox3" runat="server" Width="144px" MaxLength="15"></asp:textbox>Tahun</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jumlah Kantor Cabang/Perwakilan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="Textbox4" runat="server" Width="144px" MaxLength="15"></asp:textbox>Kantor</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jumlah Tenaga Ahli (Bersertifikat bidang Asuransi)</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="cu_gelarssdh" runat="server" Width="144px"
											MaxLength="50"></asp:textbox>Orang</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 21px">Jumlah Modal Sendiri</TD>
									<TD style="HEIGHT: 21px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 21px"><asp:textbox onkeypress="return kutip_satu()" id="Textbox5" runat="server" Width="296px" MaxLength="15"
											Height="20px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 24px">Pendapatan Komisi</TD>
									<TD style="HEIGHT: 24px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 24px"><asp:textbox onkeypress="return kutip_satu()" id="Textbox8" runat="server" Width="296px" MaxLength="15"></asp:textbox></TD>
								</TR> <!-- Additional Field : Right --></TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" runat="server">
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 20px">Profit Margin</TD>
									<TD style="WIDTH: 15px; HEIGHT: 20px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:textbox onkeypress="return kutip_satu()" id="Textbox6" runat="server" Width="155px" MaxLength="15"></asp:textbox>%</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Perijinan dan Legalitas</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:radiobutton id="Radiobutton12" runat="server" GroupName="OPT_LMP_D" Text="Lengkap"></asp:radiobutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:radiobutton id="Radiobutton11" runat="server" GroupName="OPT_LMP_D" Text="Kurang Lengkap" Checked="True"></asp:radiobutton></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Sarana Pendukung Usaha</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:radiobutton id="Radiobutton15" runat="server" GroupName="OPT_LMP_D" Text="Baik"></asp:radiobutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:radiobutton id="Radiobutton14" runat="server" GroupName="OPT_LMP_D" Text="Cukup" Checked="True"></asp:radiobutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:radiobutton id="Radiobutton13" runat="server" GroupName="OPT_LMP_D" Text="Kurang"></asp:radiobutton></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Kinerja Perusahaan</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:radiobutton id="Radiobutton18" runat="server" GroupName="OPT_LMP_D" Text="Baik"></asp:radiobutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:radiobutton id="Radiobutton17" runat="server" GroupName="OPT_LMP_D" Text="Cukup" Checked="True"></asp:radiobutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:radiobutton id="Radiobutton16" runat="server" GroupName="OPT_LMP_D" Text="Kurang"></asp:radiobutton></TD>
								</TR> <!-- Additional Field : Right --></TABLE>
						</TD>
					</TR>
					<TR width="100%">
						<TD colSpan="2"></TD>
					</TR>
					<tr>
						<td class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2"><asp:button id="BTN_SAVEQUAL" runat="server" Text="Hitung" CssClass="Button1"></asp:button>&nbsp;&nbsp;&nbsp;
							<asp:button id="Button1" runat="server" Text="Clear" CssClass="Button1"></asp:button>&nbsp;&nbsp;
							<asp:button id="Button2" runat="server" Text="Print" CssClass="Button1"></asp:button></td>
					</tr>
					<tr>
						<td class="td" align="center" colSpan="2"></td>
					</tr>
					<tr>
						<td class="td" colSpan="2">
							<table width="100%">
								<tr>
									<TD class="TDBGColor1" width="20%">Total Skor</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue" width="30%"><asp:label id="LBL_QSCORE" runat="server"></asp:label></TD>
									<TD class="TDBGColor1" width="20%">Rekomendasi</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue" width="30%"><asp:label id="LBL_QREC" runat="server"></asp:label></TD>
								</tr>
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
