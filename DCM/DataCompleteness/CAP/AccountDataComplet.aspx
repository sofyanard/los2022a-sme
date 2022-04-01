<%@ Page language="c#" Codebehind="AccountDataComplet.aspx.cs" AutoEventWireup="True" Inherits="SME.DCM.DataCompleteness.CAP.AccountDataComplet" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>AccountDataComplet</TITLE>
		<META content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../Style.css" type="text/css" rel="stylesheet">
		<STYLE type="text/css">.pl { MARGIN-RIGHT: 3px }
		</STYLE>
	</HEAD>
	<BODY MS_POSITIONING="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<CENTER>
				<TABLE width="100%" border="0">
					<TR>
						<TD align="left" colspan="2">
							<TABLE id="Table1">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Account Data Completeness</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../../../Body.aspx"><IMG src="../../../Image/MainMenu.jpg"></A><A href="../../../Logout.aspx" target="_top"><IMG src="../../../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="3"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="3">Account Data</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="33%">
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:Label id="LBL_TXT_NOMOR_REKENING" runat="server">Nomor Rekening :</asp:Label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NOMOR_REKENING" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:Label id="LBL_DDL_LOAN_TYPE" runat="server">Loan Type :</asp:Label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_LOAN_TYPE" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:Label id="LBL_DDL_SIFAT_KREDIT" runat="server">Sifat Kredit :</asp:Label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_SIFAT_KREDIT" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:Label id="LBL_DDL_JENIS_PENGGUNAAN" runat="server">Jenis Penggunaan :</asp:Label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_JENIS_PENGGUNAAN" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:Label id="LBL_DDL_ORIENTASI" runat="server">Orientasi Penggunaan :</asp:Label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_ORIENTASI" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:Label id="LBL_DDL_GOL_KREDIT" runat="server">Golongan Kredit :</asp:Label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_GOL_KREDIT" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:Label id="LBL_DDL_JENIS_KREDIT" runat="server">Jenis Kredit :</asp:Label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_JENIS_KREDIT" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:Label id="LBL_DDL_FAS_DANA" runat="server">Fas. Penyediaan Dana :</asp:Label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_FAS_DANA" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:Label id="LBL_DDL_BANK_SINDIKASI" runat="server">Bank Utama Sindikasi :</asp:Label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_BANK_SINDIKASI" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:Label id="LBL_DDL_LOKASI_PROYEK" runat="server">Lokasi Proyek :</asp:Label></TD>
									<TD class='A"TDBGColorValue"'><asp:DropDownList id="DDL_LOKASI_PROYEK" runat="server" Width="100%"></asp:DropDownList></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:Label id="LBL_TXT_ALAMATPROJ" runat="server">Alamat Proyek :</asp:Label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_ALAMATPROJ" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:Label id="LBL_DDL_NILAI_PROYEK" runat="server">Nilai Proyek :</asp:Label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_NILAI_PROYEK" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:Label id="LBL_DDL_NEGARAASAL" runat="server">Negara Asal :</asp:Label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_NEGARAASAL" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:Label id="LBL_TXT_JMLREK" runat="server">Jumlah Rekening :</asp:Label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_JMLREK" runat="server" Width="50%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:Label id="LBL_TXT_STATUSDEBITUR" runat="server">Status Debitur :</asp:Label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_STATUSDEBITUR" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:Label id="LBL_TXT_KTGR_DEBTR" runat="server">Kategori Debitur :</asp:Label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_KTGR_DEBTR" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:Label id="LBL_TXT_KTGR_PORT" runat="server">Kategori Portofolio :</asp:Label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_KTGR_PORT" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:Label id="LBL_DDL_JNSVALIND" runat="server">Jenis Valuta Induk :</asp:Label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_JNSVALIND" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:Label id="LBL_DDL_JNSVALFAL" runat="server">Jenis Valuta Fasilitas :</asp:Label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_JNSVALFAL" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:Label id="LBL_TXT_TGKNPOKOK" runat="server">Tunggakan Pokok :</asp:Label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_TGKNPOKOK" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:Label id="LBL_TXT_TGLTGKN" runat="server">Tanggal Tunggakan :</asp:Label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_TGLTGKN" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:Label id="LBL_TXT_FREKTGKPOKOK" runat="server">Frek. Tunggakan Pokok :</asp:Label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_FREKTGKPOKOK" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="33%">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:Label id="LBL_DDL_GOL_PENJAMIN" runat="server">Golongan Penjamin :</asp:Label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_GOL_PENJAMIN" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:Label id="LBL_TXT_BAGYGDIJMN" runat="server">Bagian yang Dijamin :</asp:Label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_BAGYGDIJMN" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:Label id="LBL_DDL_KSEBI1" runat="server">KSEBI 1 :</asp:Label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_KSEBI1" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:Label id="LBL_DDL_KSEBI2" runat="server">KSEBI 2 :</asp:Label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_KSEBI2" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:Label id="LBL_DDL_KSEBI3" runat="server">KSEBI 3 :</asp:Label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_KSEBI3" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:Label id="LBL_DDL_KSEBI4" runat="server">KSEBI 4 :</asp:Label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_KSEBI4" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:Label id="LBL_DDL_BULAN_PKPERTAMA" runat="server">Tanggal PK Pertama :</asp:Label></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return numbersonly()" id="TXT_TANGGAL_PKPERTAMA" runat="server" MaxLength="2"
											Columns="2" CssClass="pl"></asp:textbox>
										<asp:dropdownlist id="DDL_BULAN_PKPERTAMA" runat="server" CssClass="pl"></asp:dropdownlist>
										<asp:textbox onkeypress="return numbersonly()" id="TXT_TAHUN_PKPERTAMA" runat="server" MaxLength="4"
											Columns="4"></asp:textbox>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:Label id="LBL_TXT_NOPKPERTAMA" runat="server">No PK Pertama :</asp:Label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NOPKPERTAMA" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:Label id="LBL_DDL_BULAN_PKAKHIR" runat="server">Tanggal PK Terakhir :</asp:Label></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return numbersonly()" id="TXT_TANGGAL_PKAKHIR" runat="server" MaxLength="2"
											Columns="2" CssClass="pl"></asp:textbox>
										<asp:dropdownlist id="DDL_BULAN_PKAKHIR" runat="server" CssClass="pl"></asp:dropdownlist>
										<asp:textbox onkeypress="return numbersonly()" id="TXT_TAHUN_PKAKHIR" runat="server" MaxLength="4"
											Columns="4"></asp:textbox>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:Label id="LBL_TXT_NOPKTERAKHIR" runat="server">No PK Terakhir :</asp:Label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NOPKTERAKHIR" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:Label id="LBL_DDL_KOLEKTIBILITAS" runat="server">Kolektibilitas :</asp:Label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_KOLEKTIBILITAS" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:Label id="LBL_RDO_PERHT_PPA" runat="server">Perhitungan PPA :</asp:Label></TD>
									<TD class="TDBGColorValue" vAlign="middle" align="left">
										<asp:radiobuttonlist id="RDO_PERHT_PPA" runat="server" RepeatDirection="Horizontal">
											<asp:ListItem Value="0" Selected="True">Yes</asp:ListItem>
											<asp:ListItem Value="1">No</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:Label id="LBL_RDO_OTOM_KOL" runat="server">Otomatis Kolektibilitas :</asp:Label></TD>
									<TD class="TDBGColorValue" vAlign="middle" align="left">
										<asp:radiobuttonlist id="RDO_OTOM_KOL" runat="server" RepeatDirection="Horizontal">
											<asp:ListItem Value="0" Selected="True">Yes</asp:ListItem>
											<asp:ListItem Value="1">No</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:Label id="LBL_TXT_CTGRPENGUKURAN" runat="server">Kategori Pengukuran :</asp:Label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CTGRPENGUKURAN" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:Label id="LBL_TXT_SUKBUNGINDUK" runat="server">TK. Suku Bunga Induk :</asp:Label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_SUKBUNGINDUK" runat="server" Width="50px"></asp:textbox>%</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:Label id="LBL_TXT_SUKBUNGPERFAL" runat="server">TK. Suku Bunga Perfasilitas :</asp:Label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_SUKBUNGPERFAL" runat="server" Width="50px"></asp:textbox>%</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:Label id="LBL_DDL_JNS_SUKBUNG" runat="server">Jenis Suku Bunga :</asp:Label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_JNS_SUKBUNG" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:Label id="LBL_TXT_PLFINDUK" runat="server">Plafond Induk :</asp:Label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PLFINDUK" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:Label id="LBL_TXT_PLAFOND" runat="server">Plafond :</asp:Label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PLAFOND" runat="server" Width="100%" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:Label id="LBL_TXT_TGKNBUNGAINTRA" runat="server">Tunggakan Bunga Intra :</asp:Label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_TGKNBUNGAINTRA" runat="server" Width="100%" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:Label id="LBL_TXT_TGKNBNGEKSTRA" runat="server">Tunggakan Bunga Ekstra :</asp:Label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_TGKNBNGEKSTRA" runat="server" Width="100%" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:Label id="LBL_TXT_FREKTGKNBNG" runat="server">Frek. Tunggakan Bunga :</asp:Label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_FREKTGKNBNG" runat="server" Width="100%" ReadOnly="True"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="33%">
							<TABLE id="Table4" cellPadding="0" cellSpacing="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:Label id="LBL_RDO_ONEENTITY" runat="server">One Entity Flag :</asp:Label></TD>
									<TD class="TDBGColorValue" align="left">
										<asp:radiobuttonlist id="RDO_ONEENTITY" runat="server" RepeatDirection="Horizontal">
											<asp:ListItem Value="Y" Selected="True">Yes</asp:ListItem>
											<asp:ListItem Value="N">No</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:Label id="LBL_RDO_RESTRUKTURISASI" runat="server">Restrukturisasi :</asp:Label></TD>
									<TD class="TDBGColorValue" align="left">
										<asp:radiobuttonlist id="RDO_RESTRUKTURISASI" runat="server" RepeatDirection="Horizontal">
											<asp:ListItem Value="Y" Selected="True">Yes</asp:ListItem>
											<asp:ListItem Value="N">No</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:Label id="LBL_DDL_JENISRESTRU" runat="server">Jenis Restru :</asp:Label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_JENISRESTRU" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:Label id="LBL_DDL_MM_RESTRUAWAL" runat="server">Tgl Restru Awal :</asp:Label>&nbsp;</TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return numbersonly()" id="TXT_DD_RESTRUAWAL" runat="server" MaxLength="2"
											Columns="2" CssClass="pl"></asp:textbox>
										<asp:dropdownlist id="DDL_MM_RESTRUAWAL" runat="server" CssClass="pl"></asp:dropdownlist>
										<asp:textbox onkeypress="return numbersonly()" id="TXT_YY_RESTRUAWAL" runat="server" MaxLength="4"
											Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:Label id="LBL_DDL_MM_RESTRUAKHIR" runat="server">Tgl Restru Akhir :</asp:Label></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return numbersonly()" id="TXT_DD_RESTRUAKHIR" runat="server" MaxLength="2"
											Columns="2" CssClass="pl"></asp:textbox>
										<asp:dropdownlist id="DDL_MM_RESTRUAKHIR" runat="server" CssClass="pl"></asp:dropdownlist>
										<asp:textbox onkeypress="return numbersonly()" id="TXT_YY_RESTRUAKHIR" runat="server" MaxLength="4"
											Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:Label id="LBL_DDL_MM_RESTRUREVIEW" runat="server">Tgl Review Restru :</asp:Label>&nbsp;</TD>
									<TD class="TDBGColorValue" align="left">
										<asp:textbox onkeypress="return numbersonly()" id="TXT_DD_RESTRUREVIEW" runat="server" MaxLength="2"
											Columns="2" CssClass="pl"></asp:textbox>
										<asp:dropdownlist id="DDL_MM_RESTRUREVIEW" runat="server" CssClass="pl"></asp:dropdownlist>
										<asp:textbox onkeypress="return numbersonly()" id="TXT_YY_RESTRUREVIEW" runat="server" MaxLength="4"
											Columns="4"></asp:textbox>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:Label id="LBL_TXT_RESTRUKE" runat="server">Restrukturisasi ke- :</asp:Label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_RESTRUKE" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:Label id="LBL_DDL_KETRESTRU" runat="server">Ket. Restrukturisasi :</asp:Label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_KETRESTRU" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:Label id="LBL_DDL_SANDIKODEPOSISI" runat="server">Sandi/Kode Posisi :</asp:Label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_SANDIKODEPOSISI" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:Label id="LBL_DDL_MM_TGLPOSISI" runat="server">Tgl Posisi :</asp:Label></TD>
									<TD class="TDBGColorValue" align="left">
										<asp:textbox onkeypress="return numbersonly()" id="TXT_DD_TGLPOSISI" runat="server" MaxLength="2"
											Columns="2" CssClass="pl"></asp:textbox>
										<asp:dropdownlist id="DDL_MM_TGLPOSISI" runat="server" CssClass="pl"></asp:dropdownlist>
										<asp:textbox onkeypress="return numbersonly()" id="TXT_YY_TGLPOSISI" runat="server" MaxLength="4"
											Columns="4"></asp:textbox>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:Label id="LBL_DDL_SEBABMACET" runat="server">Sebab Macet :</asp:Label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_SEBABMACET" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:Label id="LBL_DDL_MM_TGLMACET" runat="server">Tanggal Macet :</asp:Label></TD>
									<TD class="TDBGColorValue" align="left">
										<asp:textbox onkeypress="return numbersonly()" id="TXT_DD_TGLMACET" runat="server" MaxLength="2"
											Columns="2" CssClass="pl"></asp:textbox>
										<asp:dropdownlist id="DDL_MM_TGLMACET" runat="server" CssClass="pl"></asp:dropdownlist>
										<asp:textbox onkeypress="return numbersonly()" id="TXT_YY_TGLMACET" runat="server" MaxLength="4"
											Columns="4"></asp:textbox>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:Label id="LBL_TXT_BAKIDEBET" runat="server">Baki Debet :</asp:Label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_BAKIDEBET" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:Label id="LBL_RDO_COMMITTED" runat="server">Committed :</asp:Label></TD>
									<TD class="TDBGColorValue" align="left">
										<asp:radiobuttonlist id="RDO_COMMITTED" runat="server" RepeatDirection="Horizontal">
											<asp:ListItem Value="Y" Selected="True">Yes</asp:ListItem>
											<asp:ListItem Value="N">No</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:Label id="LBL_RDO_UNCOMMITED" runat="server">Uncommitted :</asp:Label></TD>
									<TD class="TDBGColorValue" align="left">
										<asp:radiobuttonlist id="RDO_UNCOMMITED" runat="server" RepeatDirection="Horizontal">
											<asp:ListItem Value="Y" Selected="True">Yes</asp:ListItem>
											<asp:ListItem Value="N">No</asp:ListItem>
										</asp:radiobuttonlist>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:Label id="LBL_TXT_PDPTBUNGAYAD" runat="server">Pendpt Bunga YAD :</asp:Label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PDPTBUNGAYAD" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:Label id="LBL_TXT_PDPTDITANGGUHKAN" runat="server">Pendpt ditangguhkan :</asp:Label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PDPTDITANGGUHKAN" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:Label id="LBL_RDO_INDIVIDUAL" runat="server">Individual :</asp:Label></TD>
									<TD class="TDBGColorValue" align="left">
										<asp:radiobuttonlist id="RDO_INDIVIDUAL" runat="server" RepeatDirection="Horizontal">
											<asp:ListItem Value="Y" Selected="True">Yes</asp:ListItem>
											<asp:ListItem Value="N">No</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:Label id="LBL_RDO_KOLEKTIF" runat="server">Kolektif :</asp:Label></TD>
									<TD class="TDBGColorValue" align="left">
										<asp:radiobuttonlist id="RDO_KOLEKTIF" runat="server" RepeatDirection="Horizontal">
											<asp:ListItem Value="Y" Selected="True">Yes</asp:ListItem>
											<asp:ListItem Value="N">No</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:Label id="LBL_RDO_JNSPENGAJUAN" runat="server">Jenis Pengajuan :</asp:Label></TD>
									<TD class="TDBGColorValue" align="left">
										<asp:radiobuttonlist id="RDO_JNSPENGAJUAN" runat="server" RepeatDirection="Horizontal">
											<asp:ListItem Value="Y" Selected="True">Baru</asp:ListItem>
											<asp:ListItem Value="N">Renewal</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" align="center" colSpan="3">
							<asp:button id="BTN_SAVE" Runat="server" CssClass="button1" Width="76px" Text="SAVE"></asp:button>&nbsp;&nbsp;
							<asp:button id="BTN_CLR" Runat="server" CssClass="button1" Width="76px" Text="CLEAR"></asp:button>
						</TD>
					</TR>
				</TABLE>
			</CENTER>
		</FORM>
	</BODY>
</HTML>
