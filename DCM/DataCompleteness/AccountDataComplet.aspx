<%@ Page language="c#" Codebehind="AccountDataComplet.aspx.cs" AutoEventWireup="false" Inherits="SME.DCM.DataCompleteness.AccountDataComplet" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AccountDataComplet</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Style.css" type="text/css" rel="stylesheet">
		<style type="text/css">.pl { MARGIN-RIGHT: 3px }
		</style>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<CENTER>
				<table width="100%" border="0">
					<tr>
						<td align="left">
							<TABLE id="Table31">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Account&nbsp;Data 
											Completeness</B></TD>
								</TR>
							</TABLE>
						</td>
						<TD class="tdNoBorder" align="right"><A href="../../Body.aspx"><IMG src="../../Image/MainMenu.jpg"></A><A href="../../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A></TD>
					</tr>
					<TR>
						<TD class="tdHeader1" colSpan="2">Account&nbsp;Data</TD>
					</TR>
					<TR>
					</TR>
					<tr>
						<td colSpan="2">
							<table>
								<tr>
									<TD class="td" vAlign="top" width="33%">
										<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD class="TDBGColor1">
													<asp:Label id="LBL_TXT_NOMOR_REKENING" runat="server">Nomor Rekening</asp:Label></TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_NOMOR_REKENING" runat="server" BorderStyle="None" Width="100%"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 26px">
													<asp:Label id="LBL_DDL_LOAN_TYPE" runat="server">Loan Type</asp:Label></TD>
												<TD style="WIDTH: 15px; HEIGHT: 26px">:</TD>
												<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_LOAN_TYPE" runat="server" Width="100%"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">
													<asp:Label id="LBL_DDL_SIFAT_KREDIT" runat="server">Sifat Kredit</asp:Label></TD>
												<TD style="WIDTH: 15px; HEIGHT: 17px">:</TD>
												<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_SIFAT_KREDIT" runat="server" Width="100%"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">
													<asp:Label id="LBL_DDL_JENIS_PENGGUNAAN" runat="server">Jenis Penggunaan</asp:Label></TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_JENIS_PENGGUNAAN" runat="server" Width="100%"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">
													<asp:Label id="LBL_DDL_ORIENTASI" runat="server">Orientasi Penggunaan</asp:Label></TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_ORIENTASI" runat="server" Width="100%"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">
													<asp:Label id="LBL_DDL_GOL_KREDIT" runat="server">Golongan Kredit</asp:Label></TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_GOL_KREDIT" runat="server" Width="100%"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 25px">
													<asp:Label id="LBL_DDL_JENIS_KREDIT" runat="server">Jenis Kredit</asp:Label></TD>
												<TD style="WIDTH: 15px; HEIGHT: 25px">:</TD>
												<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_JENIS_KREDIT" runat="server" Width="100%"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">
													<asp:Label id="LBL_DDL_FAS_DANA" runat="server">Fas. Penyediaan Dana</asp:Label></TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_FAS_DANA" runat="server" Width="100%"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">
													<asp:Label id="LBL_DDL_BANK_SINDIKASI" runat="server">Bank Utama Sindikasi </asp:Label></TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_BANK_SINDIKASI" runat="server" Width="100%"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">
													<asp:Label id="LBL_TXT_LOKASIPROYEK" runat="server">Lokasi Proyek</asp:Label></TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_LOKASIPROYEK" runat="server" BorderStyle="None" Width="100%"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">
													<asp:Label id="LBL_TXT_ALAMATPROJ" runat="server">Alamat Proyek</asp:Label></TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_ALAMATPROJ" runat="server" BorderStyle="None" Width="100%"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">
													<asp:Label id="LBL_DDL_NILAIPROJ" runat="server">Nilai Proyek</asp:Label></TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_NILAIPROJ" runat="server" Width="100%"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">
													<asp:Label id="LBL_DDL_NEGARAASAL" runat="server">Negara Asal</asp:Label></TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_NEGARAASAL" runat="server" Width="100%"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">
													<asp:Label id="LBL_TXT_JMLREK" runat="server">Jumlah Rekening</asp:Label></TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_JMLREK" runat="server" BorderStyle="None" Width="100%"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">
													<asp:Label id="LBL_TXT_STATUSDEBITUR" runat="server">Status Debitur</asp:Label></TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_STATUSDEBITUR" runat="server" BorderStyle="None" Width="100%"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">
													<asp:Label id="LBL_TXT_KTGR_DEBTR" runat="server">Kategori Debitur</asp:Label></TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_KTGR_DEBTR" runat="server" BorderStyle="None" Width="100%"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">
													<asp:Label id="LBL_TXT_KTGR_PORT" runat="server">Kategori Portofolio</asp:Label></TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_KTGR_PORT" runat="server" BorderStyle="None" Width="100%"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 22px">
													<asp:Label id="LBL_DDL_JNSVALIND" runat="server">Jenis Valuta Induk</asp:Label></TD>
												<TD style="WIDTH: 15px; HEIGHT: 22px">:</TD>
												<TD class="TDBGColorValue" style="HEIGHT: 26px"><asp:dropdownlist id="DDL_JNSVALIND" runat="server" Width="100%"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">
													<asp:Label id="LBL_DDL_JNSVALFAL" runat="server">Jenis Valuta Fasilitas</asp:Label></TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_JNSVALFAL" runat="server" Width="100%"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">
													<asp:Label id="LBL_TXT_TGKNPOKOK" runat="server">Tunggakan Pokok</asp:Label></TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_TGKNPOKOK" runat="server" BorderStyle="None" Width="100%"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">
													<asp:Label id="LBL_TXT_TGLTGKN" runat="server">Tanggal Tunggakan</asp:Label></TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_TGLTGKN" runat="server" BorderStyle="None" Width="100%"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">
													<asp:Label id="LBL_TXT_FREKTGKPOKOK" runat="server">Frek. Tunggakan Pokok</asp:Label></TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_FREKTGKPOKOK" runat="server" BorderStyle="None" Width="240px"></asp:textbox></TD>
											</TR>
										</TABLE>
									</TD>
									<TD class="td" vAlign="top" width="40%">
										<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD class="TDBGColor1">
													<asp:Label id="LBL_DDL_GOL_PENJAMIN" runat="server">Golongan Penjamin</asp:Label></TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_GOL_PENJAMIN" runat="server" AutoPostBack="True" Width="100%"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">
													<asp:Label id="LBL_TXT_BAGYGDIJMN" runat="server">Bagian yang Dijamin</asp:Label></TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_BAGYGDIJMN" runat="server" BorderStyle="None" Width="100%"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">
													<asp:Label id="LBL_DDL_KSEBI1" runat="server">KSEBI 1</asp:Label></TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_KSEBI1" runat="server" AutoPostBack="True" Width="100%"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">
													<asp:Label id="LBL_DDL_KSEBI2" runat="server">KSEBI 2</asp:Label></TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_KSEBI2" runat="server" AutoPostBack="True" Width="100%"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">
													<asp:Label id="LBL_DDL_KSEBI3" runat="server">KSEBI 3</asp:Label></TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_KSEBI3" runat="server" AutoPostBack="True" Width="100%"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">
													<asp:Label id="LBL_DDL_KSEBI4" runat="server">KSEBI 4</asp:Label></TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_KSEBI4" runat="server" AutoPostBack="True" Width="100%"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">&nbsp;
													<asp:Label id="LBL_DDL_BULAN_PK1" runat="server">Tanggal PK Pertama</asp:Label></TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return numbersonly()" id="Textbox31" runat="server" Width="20%" MaxLength="2"
														Columns="4" CssClass="pl"></asp:textbox><asp:dropdownlist id="DDL_BULAN_PKPERTAMA" runat="server" Width="50%" CssClass="pl"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="Textbox32" runat="server" Width="25%" MaxLength="4"
														Columns="4"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">
													<asp:Label id="LBL_TXT_NOPKPERTAMA" runat="server">No PK Pertama</asp:Label></TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_NOPKPERTAMA" runat="server" BorderStyle="None" Width="100%"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">&nbsp;
													<asp:Label id="LBL_DDL_BULAN_PKAKHIR" runat="server">Tanggal PK Terakhir</asp:Label></TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return numbersonly()" id="Textbox33" runat="server" Width="20%" MaxLength="2"
														Columns="4" CssClass="pl"></asp:textbox><asp:dropdownlist id="DDL_BULAN_PKAKHIR" runat="server" Width="50%" CssClass="pl"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="Textbox34" runat="server" Width="25%" MaxLength="4"
														Columns="4"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">
													<asp:Label id="LBL_TXT_NOPKTERAKHIR" runat="server">No PK Terakhir</asp:Label></TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_NOPKTERAKHIR" runat="server" BorderStyle="None" Width="100%"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">
													<asp:Label id="LBL_DDL_MM_KOLEKTIBILITAS" runat="server">Kolektibilitas</asp:Label>&nbsp;</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue" align="left"><asp:dropdownlist id="DDL_KOLEKTIBILITAS" runat="server" Width="100%"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">
													<asp:Label id="LBL_RDO_PERHT_PPA" runat="server">Perhitungan PPA</asp:Label></TD>
												<TD style="WIDTH: 5px">:</TD>
												<TD class="TDBGColorValue" vAlign="middle" align="left"><asp:radiobuttonlist id="RDO_PERHT_PPA" runat="server" Width="56px" RepeatDirection="Horizontal">
														<asp:ListItem Value="0" Selected="True">Yes</asp:ListItem>
														<asp:ListItem Value="1">No</asp:ListItem>
													</asp:radiobuttonlist>&nbsp;</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">
													<asp:Label id="LBL_RDO_OTOM_KOL" runat="server">Otomatis Kolektibilitas</asp:Label></TD>
												<TD style="WIDTH: 5px">:</TD>
												<TD class="TDBGColorValue" vAlign="middle" align="left"><asp:radiobuttonlist id="RDO_OTOM_KOL" runat="server" Width="56px" RepeatDirection="Horizontal">
														<asp:ListItem Value="0" Selected="True">Yes</asp:ListItem>
														<asp:ListItem Value="1">No</asp:ListItem>
													</asp:radiobuttonlist>&nbsp;</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">
													<asp:Label id="LBL_TXT_CTGRPENGUKURAN" runat="server">Kategori Pengukuran</asp:Label></TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_CTGRPENGUKURAN" runat="server" BorderStyle="None" Width="100%"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">
													<asp:Label id="LBL_TXT_SUKBUNGINDUK" runat="server">TK. Suku Bunga Induk</asp:Label></TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_SUKBUNGINDUK" runat="server" BorderStyle="None" Width="180px"></asp:textbox>&nbsp;%</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">
													<asp:Label id="LBL_TXT_SUKBUNGPERFAL" runat="server">TK. Suku Bunga Perfasilitas</asp:Label></TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_SUKBUNGPERFAL" runat="server" BorderStyle="None" Width="180px"></asp:textbox>&nbsp;%</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">&nbsp;
													<asp:Label id="LBL_DDL_JNS_SUKBUNG" runat="server">Jenis Suku Bunga</asp:Label></TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue" align="left"><asp:dropdownlist id="DDL_JNS_SUKBUNG" runat="server" Width="100%"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">
													<asp:Label id="LBL_TXT_PLFINDUK" runat="server">Plafond Induk</asp:Label></TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_PLFINDUK" runat="server" BorderStyle="None" Width="100%"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">
													<asp:Label id="LBL_TXT_PLAFOND" runat="server">Plafond</asp:Label></TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_PLAFOND" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">
													<asp:Label id="LBL_TXT_TGKNBUNGAINTRA" runat="server">Tunggakan Bunga Intra</asp:Label></TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_TGKNBUNGAINTRA" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">
													<asp:Label id="LBL_TXT_TGKNBNGEKSTRA" runat="server">Tunggakan Bunga Ekstra</asp:Label></TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_TGKNBNGEKSTRA" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">
													<asp:Label id="LBL_TXT_FREKTGKNBNG" runat="server">Frek. Tunggakan Bunga</asp:Label></TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_FREKTGKNBNG" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:textbox></TD>
											</TR>
										</TABLE>
									</TD>
									<TD class="td" vAlign="top" width="40%">
										<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD class="TDBGColor1">
													<asp:Label id="LBL_RDO_ONEENTITY" runat="server">One Entity Flag</asp:Label></TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue" align="left"><asp:radiobuttonlist id="RDO_ONEENTITY" runat="server" Width="150px" RepeatDirection="Horizontal">
														<asp:ListItem Value="Y" Selected="True">Yes</asp:ListItem>
														<asp:ListItem Value="N">No</asp:ListItem>
													</asp:radiobuttonlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">
													<asp:Label id="LBL_RDO_RESTRUKTURISASI" runat="server">Restrukturisasi</asp:Label></TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue" align="left"><asp:radiobuttonlist id="RDO_RESTRUKTURISASI" runat="server" Width="150px" RepeatDirection="Horizontal">
														<asp:ListItem Value="Y" Selected="True">Yes</asp:ListItem>
														<asp:ListItem Value="N">No</asp:ListItem>
													</asp:radiobuttonlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">
													<asp:Label id="LBL_DDL_JENISRESTRU" runat="server">Jenis Restru</asp:Label></TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_JENISRESTRU" runat="server" AutoPostBack="True" Width="100%"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">
													<asp:Label id="Label1" runat="server">Tgl Restru Awal</asp:Label>&nbsp;</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return numbersonly()" id="TXT_DD_RESTRUAWAL" runat="server" Width="20%"
														MaxLength="2" Columns="4" CssClass="pl"></asp:textbox><asp:dropdownlist id="DDL_MM_RESTRUAWAL" runat="server" Width="50%" CssClass="pl"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_YY_RESTRUAWAL" runat="server" Width="25%"
														MaxLength="4" Columns="4"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">
													<asp:Label id="Label2" runat="server"> Tgl Restru Akhir</asp:Label></TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return numbersonly()" id="TXT_DD_RESTRUAKHIR" runat="server" Width="20%"
														MaxLength="2" Columns="4" CssClass="pl"></asp:textbox><asp:dropdownlist id="DDL_MM_RESTRUAKHIR" runat="server" Width="50%" CssClass="pl"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_YY_RESTRUAKHIR" runat="server" Width="25%"
														MaxLength="4" Columns="4"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">
													<asp:Label id="Label3" runat="server">Tgl Review Restru</asp:Label>&nbsp;</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return numbersonly()" id="TXT_DD_RESTRUREVIEW" runat="server" Width="20%"
														MaxLength="2" Columns="4" CssClass="pl"></asp:textbox><asp:dropdownlist id="DDL_MM_RESTRUREVIEW" runat="server" Width="50%" CssClass="pl"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_YY_RESTRUREVIEW" runat="server" Width="25%"
														MaxLength="4" Columns="4"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">
													<asp:Label id="LBL_TXT_RESTRUKE" runat="server">Restrukturisasi ke-</asp:Label></TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_RESTRUKE" runat="server" BorderStyle="None" Width="100%"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">
													<asp:Label id="LBL_DDL_KETRESTRU" runat="server">Ket. Restrukturisasi</asp:Label></TD>
												<TD style="WIDTH: 15px; HEIGHT: 31px">:</TD>
												<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_KETRESTRU" runat="server" AutoPostBack="True" Width="100%"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">
													<asp:Label id="LBL_DDL_SANDIKODEPOSISI" runat="server">Sandi/Kode Posisi</asp:Label></TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_SANDIKODEPOSISI" runat="server" AutoPostBack="True" Width="100%"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 14px">
													<asp:Label id="LBL_DDL_MM_TGLPOSISI" runat="server"> Tgl Posisi</asp:Label></TD>
												<TD style="WIDTH: 15px; HEIGHT: 14px">:</TD>
												<TD class="TDBGColorValue" align="left" style="HEIGHT: 14px"><asp:textbox onkeypress="return numbersonly()" id="TXT_DD_TGLPOSISI" runat="server" Width="20%"
														MaxLength="2" Columns="4" CssClass="pl"></asp:textbox><asp:dropdownlist id="DDL_MM_TGLPOSISI" runat="server" Width="50%" CssClass="pl"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_YY_TGLPOSISI" runat="server" Width="25%"
														MaxLength="4" Columns="4"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 22px">
													<asp:Label id="LBL_DDL_SEBABMACET" runat="server">Sebab Macet</asp:Label></TD>
												<TD style="WIDTH: 15px; HEIGHT: 22px">:</TD>
												<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_SEBABMACET" runat="server" AutoPostBack="True" Width="230px"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">&nbsp;
													<asp:Label id="LBL_DDL_MM_TGLMACET" runat="server">Tanggal Macet</asp:Label></TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return numbersonly()" id="TXT_DD_TGLMACET" runat="server" Width="20%"
														MaxLength="2" Columns="4" CssClass="pl"></asp:textbox><asp:dropdownlist id="DDL_MM_TGLMACET" runat="server" Width="50%" CssClass="pl"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_YY_TGLMACET" runat="server" Width="25%"
														MaxLength="4" Columns="4"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">
													<asp:Label id="LBL_TXT_BAKIDEBET" runat="server">Baki Debet</asp:Label></TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_BAKIDEBET" runat="server" BorderStyle="None" Width="194px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">
													<asp:Label id="LBL_RDO_COMMITTED" runat="server">Committed</asp:Label></TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue" align="left"><asp:radiobuttonlist id="RDO_COMMITTED" runat="server" Width="150px" RepeatDirection="Horizontal">
														<asp:ListItem Value="Y" Selected="True">Yes</asp:ListItem>
														<asp:ListItem Value="N">No</asp:ListItem>
													</asp:radiobuttonlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">
													<asp:Label id="LBL_RDO_UNCOMMITED" runat="server">Uncommitted</asp:Label></TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue" align="left"><asp:radiobuttonlist id="RDO_UNCOMMITED" runat="server" Width="150px" RepeatDirection="Horizontal">
														<asp:ListItem Value="Y" Selected="True">Yes</asp:ListItem>
														<asp:ListItem Value="N">No</asp:ListItem>
													</asp:radiobuttonlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">
													<asp:Label id="LBL_TXT_PDPTBUNGAYAD" runat="server">Pendpt Bunga YAD</asp:Label></TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_PDPTBUNGAYAD" runat="server" BorderStyle="None" Width="100%"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">
													<asp:Label id="LBL_TXT_PDPTDITANGGUHKAN" runat="server">Pendpt ditangguhkan</asp:Label></TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_PDPTDITANGGUHKAN" runat="server" BorderStyle="None" Width="100%"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">
													<asp:Label id="LBL_RDO_INDIVIDUAL" runat="server">Individual</asp:Label></TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue" align="left"><asp:radiobuttonlist id="RDO_INDIVIDUAL" runat="server" Width="150px" RepeatDirection="Horizontal">
														<asp:ListItem Value="Y" Selected="True">Yes</asp:ListItem>
														<asp:ListItem Value="N">No</asp:ListItem>
													</asp:radiobuttonlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">
													<asp:Label id="LBL_RDO_KOLEKTIF" runat="server">Kolektif</asp:Label></TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue" align="left"><asp:radiobuttonlist id="RDO_KOLEKTIF" runat="server" Width="150px" RepeatDirection="Horizontal">
														<asp:ListItem Value="Y" Selected="True">Yes</asp:ListItem>
														<asp:ListItem Value="N">No</asp:ListItem>
													</asp:radiobuttonlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">
													<asp:Label id="LBL_RDO_JNSPENGAJUAN" runat="server">Jenis Pengajuan</asp:Label></TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue" style="HEIGHT: 39px" align="left"><asp:radiobuttonlist id="RDO_JNSPENGAJUAN" runat="server" Width="150px" RepeatDirection="Horizontal">
														<asp:ListItem Value="Y" Selected="True">Baru</asp:ListItem>
														<asp:ListItem Value="N">Renewal</asp:ListItem>
													</asp:radiobuttonlist></TD>
											</TR>
										</TABLE>
									</TD>
								</tr>
							</table>
						</td>
					</tr>
					<TR>
						<TD class="TDBGColor2" align="center" colSpan="2"><asp:button id="BTN_SAVE" Runat="server" CssClass="button1" Text="SAVE"></asp:button>&nbsp;&nbsp;
							<asp:button id="BTN_CLR" Width="68px" Runat="server" CssClass="button1" Text="CLEAR"></asp:button></TD>
					</TR>
				</table>
				</TD></TR><tr>
					<td></td>
				</tr>
				</TABLE></CENTER>
		</form>
	</body>
</HTML>
