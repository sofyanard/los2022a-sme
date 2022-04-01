<%@ Page language="c#" Codebehind="LKKN1.aspx.cs" AutoEventWireup="True" Inherits="SME.LKKN1.LKKN1" %>
<%@ Register TagPrefix="uc1" TagName="DocUpload" Src="../CommonForm/DocumentUpload.ascx" %>
<%@ Register TagPrefix="uc1" TagName="DocExport" Src="../CommonForm/DocumentExport.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>LKKN</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_all.html" -->
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE cellSpacing="1" cellPadding="1" width="100%">
					<TR>
						<TD class="tdNoBorder" align="left" width="50%">
							<TABLE id="Table12">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Site Visit</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right" width="50%"><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A>
							<A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A>
						</TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<TR>
						<TD align="right" width="50%" colSpan="2">&nbsp;CBC/Hub/Comm. Branch :
							<asp:textbox onkeypress="return kutip_satu()" id="TXT_BRANCH" runat="server" MaxLength="100"
								Width="200px"></asp:textbox></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" width="50%" colSpan="2">LAPORAN KONTAK/KUNJUNGAN NASABAH</TD>
					</TR>
					<TR>
						<TD vAlign="top" align="center" width="50%">
							<TABLE class="td" style="HEIGHT: 95px" width="100%">
								<TR>
									<TD class="TDBGColor1" width="100">Nama Nasabah</TD>
									<TD width="9">:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CUST_NAME" runat="server" MaxLength="50"
											Width="300px" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 20px">Alamat</TD>
									<TD style="HEIGHT: 20px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:textbox onkeypress="return kutip_satu()" id="TXT_ADDR" runat="server" MaxLength="100" Width="300px"
											ReadOnly="True" Rows="4" TextMode="MultiLine"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">No. Telp</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_PHNAREA" runat="server" MaxLength="5" ReadOnly="True"
											Columns="4"></asp:textbox><asp:textbox onkeypress="return kutip_satu()" id="TXT_PHNNUM" runat="server" MaxLength="15" Width="150px"
											ReadOnly="True" Columns="10"></asp:textbox><asp:textbox onkeypress="return kutip_satu()" id="TXT_PHNEXT" runat="server" MaxLength="5" ReadOnly="True"
											Columns="3"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD vAlign="top" align="center" width="50%">
							<TABLE class="td" style="HEIGHT: 96px" width="100%">
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 25px" width="100">Tgl Kunjungan</TD>
									<TD style="HEIGHT: 25px" width="9">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 25px"><asp:textbox onkeypress="return numbersonly()" id="TXT_VISIT_DAY" runat="server" MaxLength="2"
											Width="24px" Columns="4" CssClass="mandatory"></asp:textbox><asp:dropdownlist id="DDL_VISIT_MONTH" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_VISIT_YEAR" runat="server" MaxLength="4"
											Columns="4" CssClass="mandatory"></asp:textbox><asp:textbox onkeypress="return kutip_satu()" id="TXT_VISITDATE" runat="server" BorderStyle="None"
											ForeColor="White"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 24px">RM/SBO</TD>
									<TD style="HEIGHT: 24px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 24px"><asp:textbox onkeypress="return kutip_satu()" id="TXT_BO" runat="server" MaxLength="100" Width="300px"
											ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Contact Person</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CONTACTPERSON" runat="server" MaxLength="100"
											Width="300px" ReadOnly="True"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 21px" vAlign="top" align="left" width="50%"></TD>
						<TD style="HEIGHT: 21px" vAlign="top" align="center" width="50%"></TD>
					</TR>
				</TABLE>
				<TABLE cellSpacing="2" cellPadding="2" width="100%" align="center" border="1">
					<TR>
						<TD class="tdSmallHeader" align="center" width="100%">Observasi Pribadi 
							Pemohon/Pengurus</TD>
					</TR>
					<TR>
						<TD align="center" width="100%">
							<TABLE class="td" id="Table2" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 268px; HEIGHT: 26px" width="268">Sifat</TD>
									<TD style="HEIGHT: 26px" width="9">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 26px"><asp:radiobuttonlist id="CBL_OP_SIFAT" runat="server" RepeatLayout="Flow" Height="16px" RepeatDirection="Horizontal">
											<asp:ListItem Value="1" Selected="True">Terbuka/jujur</asp:ListItem>
											<asp:ListItem Value="2">berbelit-belit</asp:ListItem>
											<asp:ListItem Value="3">tertutup</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 268px; HEIGHT: 24px">Karakter</TD>
									<TD style="HEIGHT: 24px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 24px"><asp:radiobuttonlist id="CBL_OP_KARAKTER" runat="server" RepeatLayout="Flow" Height="16px" RepeatDirection="Horizontal">
											<asp:ListItem Value="1" Selected="True">Kooperatif</asp:ListItem>
											<asp:ListItem Value="2">Kurang kooperatif</asp:ListItem>
											<asp:ListItem Value="3">Tidak kooperatif</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 268px; HEIGHT: 24px">Pengalaman</TD>
									<TD style="HEIGHT: 24px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 24px"><asp:textbox onkeypress="return numbersonly()" id="TXT_OP_PENGALAMAN" runat="server" MaxLength="3"
											Width="48px"></asp:textbox>&nbsp;tahun</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 268px">Organisasi/pembagian tugas</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:radiobuttonlist id="CBL_OP_ORGANISASI" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
											<asp:ListItem Value="1" Selected="True">ada</asp:ListItem>
											<asp:ListItem Value="2">tidak ada</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 268px">Lain-lain</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_OP_LAIN" runat="server" MaxLength="100"
											Width="400px"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="tdSmallHeader" align="center" width="100%">Observasi Aspek Teknis</TD>
					</TR>
					<TR>
						<TD align="center" width="100%">
							<TABLE class="td" id="Table3" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 292px; HEIGHT: 26px" width="292">Daerah usaha</TD>
									<TD style="WIDTH: 11px; HEIGHT: 26px" width="11">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 26px"><asp:radiobuttonlist id="CBL_OAT_DAERAH" runat="server" RepeatLayout="Flow" Height="16px" RepeatDirection="Horizontal">
											<asp:ListItem Value="1" Selected="True">strategis</asp:ListItem>
											<asp:ListItem Value="2">kurang strategis</asp:ListItem>
											<asp:ListItem Value="3">tidak strategis</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 292px; HEIGHT: 24px">Lokasi usaha</TD>
									<TD style="WIDTH: 11px; HEIGHT: 24px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 24px"><asp:radiobuttonlist id="CBL_OAT_LOKASI" runat="server" RepeatLayout="Flow" Height="16px" RepeatDirection="Horizontal">
											<asp:ListItem Value="1" Selected="True">Jalan raya</asp:ListItem>
											<asp:ListItem Value="2">Perumahan</asp:ListItem>
											<asp:ListItem Value="3" Selected="True">Perkantoran</asp:ListItem>
											<asp:ListItem Value="4">Mall</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 292px">Luas tanah</TD>
									<TD style="WIDTH: 11px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_OAT_LUASTANAH" runat="server" MaxLength="15"
											Width="64px"></asp:textbox>&nbsp;m2&nbsp;
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 292px">Luas&nbsp;bangunan
									</TD>
									<TD style="WIDTH: 11px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_OAT_LUASBANGUNAN" runat="server" MaxLength="15"
											Width="64px"></asp:textbox>&nbsp;m2</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 292px">Kondisi bangunan usaha</TD>
									<TD style="WIDTH: 11px">:</TD>
									<TD class="TDBGColorValue"><asp:radiobuttonlist id="CBL_OAT_KONDISI" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
											<asp:ListItem Value="1" Selected="True">Layak</asp:ListItem>
											<asp:ListItem Value="2">Kurang layak</asp:ListItem>
											<asp:ListItem Value="3">Tidak layak</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 292px">Status bangunan tempat usaha</TD>
									<TD style="WIDTH: 11px">:</TD>
									<TD class="TDBGColorValue"><asp:radiobuttonlist id="CBL_OAT_STATUS" runat="server" RepeatLayout="Flow" Height="16px" RepeatDirection="Horizontal">
											<asp:ListItem Value="1" Selected="True">Milik sendiri</asp:ListItem>
											<asp:ListItem Value="2">Sewa</asp:ListItem>
											<asp:ListItem Value="3">lain-lain</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 292px; HEIGHT: 23px">Utilisasi kapasitas usaha</TD>
									<TD style="WIDTH: 11px; HEIGHT: 23px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 23px"><asp:radiobuttonlist id="CBL_OAT_UTILISASI" runat="server" RepeatLayout="Flow" Height="16px" RepeatDirection="Horizontal">
											<asp:ListItem Value="1" Selected="True">&lt; 50 % terpakai</asp:ListItem>
											<asp:ListItem Value="2">&gt; 50 % terpakai</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 292px">Peralatan usaha</TD>
									<TD style="WIDTH: 11px">:</TD>
									<TD class="TDBGColorValue"><asp:radiobuttonlist id="CBL_OAT_PERALATAN" runat="server" RepeatLayout="Flow" Height="16px" RepeatDirection="Horizontal">
											<asp:ListItem Value="1" Selected="True">lengkap</asp:ListItem>
											<asp:ListItem Value="2">tidak lengkap</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 292px">Prasarana usaha</TD>
									<TD style="WIDTH: 11px">:</TD>
									<TD class="TDBGColorValue"><asp:radiobuttonlist id="CBL_OAT_PRASARANA" runat="server" RepeatLayout="Flow" Height="16px" RepeatDirection="Horizontal">
											<asp:ListItem Value="1" Selected="True">mendukung</asp:ListItem>
											<asp:ListItem Value="2">kurang mendukung</asp:ListItem>
											<asp:ListItem Value="3">tidak mendukung</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 292px">Bahan baku</TD>
									<TD style="WIDTH: 11px">:</TD>
									<TD class="TDBGColorValue"><asp:radiobuttonlist id="CBL_OAT_BAHANBAKU" runat="server" RepeatLayout="Flow" Height="16px" RepeatDirection="Horizontal">
											<asp:ListItem Value="1" Selected="True">tersedia</asp:ListItem>
											<asp:ListItem Value="2">cukup tersedia</asp:ListItem>
											<asp:ListItem Value="3">kurang tersedia</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 292px; HEIGHT: 38px">Proses produksi</TD>
									<TD style="WIDTH: 11px; HEIGHT: 38px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 38px"><asp:textbox onkeypress="return kutip_satu()" id="TXT_OAT_PROSESPROD" runat="server" MaxLength="200"
											Width="480px" TextMode="MultiLine"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 292px">Suplier utama</TD>
									<TD style="WIDTH: 11px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_OAT_SUPLIER" runat="server" MaxLength="50"
											Width="400px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 292px">Realisasi produksi/pembelian 
										rata-rata&nbsp;per bulan</TD>
									<TD style="WIDTH: 11px">:</TD>
									<TD class="TDBGColorValue">dalam kuantum &nbsp;
										<asp:textbox onkeypress="return digitsonly()" id="TXT_OAT_REALISASIKUANTUM" runat="server" MaxLength="15"
											Width="64px"></asp:textbox>&nbsp;Nilai Rp.
										<asp:textbox onkeypress="return numbersonly()" id="TXT_OAT_REALISASINILAI" onblur="FormatCurrency(this)"
											runat="server" MaxLength="15" Width="136px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 292px; HEIGHT: 20px">Target 
										produksi/pembelian&nbsp;per bulan</TD>
									<TD style="WIDTH: 11px; HEIGHT: 20px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 20px">dalam kuantum &nbsp;
										<asp:textbox onkeypress="return digitsonly()" id="TXT_OAT_TARGETKUANTUM" runat="server" MaxLength="15"
											Width="64px"></asp:textbox>&nbsp;Nilai Rp.
										<asp:textbox onkeypress="return numbersonly()" id="TXT_OAT_TARGETNILAI" onblur="FormatCurrency(this)"
											runat="server" MaxLength="15" Width="136px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 292px">
										<P>Biaya umum &amp; Adm (inc biaya hidup)&nbsp;rata-rata per bulan</P>
									</TD>
									<TD style="WIDTH: 11px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_OAT_BIAYA" onblur="FormatCurrency(this)"
											runat="server" MaxLength="15" Width="168px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 292px; HEIGHT: 24px">Jumlah karyawan</TD>
									<TD style="WIDTH: 11px; HEIGHT: 24px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 24px"><asp:textbox onkeypress="return digitsonly()" id="TXT_OAT_KARYAWAN" runat="server" MaxLength="10"
											Width="96px"></asp:textbox>&nbsp;orang</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 292px">Lain-lain</TD>
									<TD style="WIDTH: 11px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_OAT_LAIN" runat="server" MaxLength="100"
											Width="400"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="tdSmallHeader" align="center" width="100%">Observasi Aspek Pemasaran</TD>
					</TR>
					<TR>
						<TD align="center" width="100%">
							<TABLE class="td" id="Table4" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 226px; HEIGHT: 25px" width="226">Produk/jasa 
										yang ditawarkan
									</TD>
									<TD style="WIDTH: 12px; HEIGHT: 25px" width="12">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 25px"><asp:textbox onkeypress="return kutip_satu()" id="TXT_OAP_PRODUK" runat="server" MaxLength="100"
											Width="184px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 226px; HEIGHT: 24px">Prospek penjualan</TD>
									<TD style="WIDTH: 12px; HEIGHT: 24px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 24px"><asp:radiobuttonlist id="CBL_OAP_PROSPEK" runat="server" RepeatLayout="Flow" Height="16px" RepeatDirection="Horizontal">
											<asp:ListItem Value="1" Selected="True">baik</asp:ListItem>
											<asp:ListItem Value="2">cukup baik</asp:ListItem>
											<asp:ListItem Value="3">kurang baik</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 226px">Pelanggan utama/pasar yang dituju</TD>
									<TD style="WIDTH: 12px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_OAP_PELANGGAN" runat="server" MaxLength="100"
											Width="184px"></asp:textbox>&nbsp;</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 226px; HEIGHT: 23px">Tingkat persaingan</TD>
									<TD style="WIDTH: 12px; HEIGHT: 23px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 23px"><asp:radiobuttonlist id="CBL_OAP_PERSAINGAN" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
											<asp:ListItem Value="1" Selected="True">bersaing</asp:ListItem>
											<asp:ListItem Value="2">cukup bersaing</asp:ListItem>
											<asp:ListItem Value="3">kurang bersaing</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 226px">Pesaing utama</TD>
									<TD style="WIDTH: 12px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_OAP_PESAING" runat="server" MaxLength="100"
											Width="184px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 226px">Lokasi pesaing utama</TD>
									<TD style="WIDTH: 12px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_OAP_LOKASIPESAING" runat="server" MaxLength="100"
											Width="184px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 226px">Strategi&nbsp;penetapan harga</TD>
									<TD style="WIDTH: 12px">:</TD>
									<TD class="TDBGColorValue"><asp:radiobuttonlist id="CBL_OAP_HARGA" runat="server" RepeatLayout="Flow" Height="16px" RepeatDirection="Horizontal">
											<asp:ListItem Value="1" Selected="True">diatas harga pasar</asp:ListItem>
											<asp:ListItem Value="2">rata-rata harga pasar</asp:ListItem>
											<asp:ListItem Value="3">dibwh harga pasar</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 226px">Saluran distribusi</TD>
									<TD style="WIDTH: 12px">:</TD>
									<TD class="TDBGColorValue"><asp:radiobuttonlist id="CBL_OAP_DISTRIBUSI" runat="server" RepeatLayout="Flow" Height="16px" RepeatDirection="Horizontal">
											<asp:ListItem Value="1" Selected="True">penjualan langsung</asp:ListItem>
											<asp:ListItem Value="2">via distributor/agen</asp:ListItem>
											<asp:ListItem Value="3">konsinyasi</asp:ListItem>
											<asp:ListItem Value="4">lainnya</asp:ListItem>
										</asp:radiobuttonlist>&nbsp;<asp:textbox onkeypress="return kutip_satu()" id="TXT_OAP_DISTRIBUSILAIN" runat="server" MaxLength="100"
											Width="121px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 226px">Sistem penjualan</TD>
									<TD style="WIDTH: 12px">:</TD>
									<TD class="TDBGColorValue"><asp:radiobuttonlist id="CBL_OAP_PENJUALAN" runat="server" RepeatLayout="Flow" Height="16px" RepeatDirection="Horizontal">
											<asp:ListItem Value="1" Selected="True">tunai</asp:ListItem>
											<asp:ListItem Value="2">kredit</asp:ListItem>
											<asp:ListItem Value="3">lainnya</asp:ListItem>
										</asp:radiobuttonlist>&nbsp;<asp:textbox onkeypress="return kutip_satu()" id="TXT_OAP_PENJUALANLAIN" runat="server" MaxLength="100"
											Width="216px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 226px; HEIGHT: 25px">Strategi promosi</TD>
									<TD style="WIDTH: 12px; HEIGHT: 25px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 25px"><asp:radiobuttonlist id="CBL_OAP_PROMOSI" runat="server" RepeatLayout="Flow" Height="16px" RepeatDirection="Horizontal">
											<asp:ListItem Value="1" Selected="True">langsung</asp:ListItem>
											<asp:ListItem Value="2">brosur/pameran</asp:ListItem>
											<asp:ListItem Value="3">media</asp:ListItem>
											<asp:ListItem Value="4">lainnya</asp:ListItem>
										</asp:radiobuttonlist><asp:textbox onkeypress="return kutip_satu()" id="TXT_OAP_PROMOSILAIN" runat="server" MaxLength="100"
											Width="153px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 226px; HEIGHT: 24px">Realisasi penjualan 
										rata-rata per bulan</TD>
									<TD style="WIDTH: 12px; HEIGHT: 24px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 24px">dalam kuantum &nbsp;
										<asp:textbox onkeypress="return numbersonly()" id="TXT_OAP_JUALKUANTUM" runat="server" MaxLength="15"
											Width="64px"></asp:textbox>&nbsp;Nilai Rp.
										<asp:textbox onkeypress="return numbersonly()" id="TXT_OAP_JUALNILAI" onblur="FormatCurrency(this)"
											runat="server" MaxLength="15" Width="136px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 226px; HEIGHT: 22px">Target penjualan&nbsp;per 
										bulan</TD>
									<TD style="WIDTH: 12px; HEIGHT: 22px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 22px">dalam kuantum &nbsp;
										<asp:textbox onkeypress="return numbersonly()" id="TXT_OAP_TARGETKUANTUM" runat="server" MaxLength="100"
											Width="64px"></asp:textbox>&nbsp;Nilai Rp.
										<asp:textbox onkeypress="return numbersonly()" id="TXT_OAP_TARGETNILAI" onblur="FormatCurrency(this)"
											runat="server" MaxLength="100" Width="136px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 226px">
										<P>Lain-lain</P>
									</TD>
									<TD style="WIDTH: 12px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_OAP_LAIN" runat="server" MaxLength="100"
											Width="400"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="tdSmallHeader" align="center" width="100%">Observasi Aspek Keuangan</TD>
					</TR>
					<TR>
						<TD style="BORDER-TOP-STYLE: inset; BORDER-RIGHT-STYLE: inset; BORDER-LEFT-STYLE: inset; HEIGHT: 17px; BACKGROUND-COLOR: lightcyan; TEXT-ALIGN: left; BORDER-BOTTOM-STYLE: inset"
							align="left" width="100%"><b>a. Untuk permohonan kredit dibawah Rp 100 juta</b></TD>
					</TR>
					<TR>
						<TD align="center" width="100%">
							<TABLE class="td" id="Table5" style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none"
								cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD style="WIDTH: 117px; FONT-STYLE: normal; HEIGHT: 20px; FONT-VARIANT: normal" colSpan="1"><B>Posisi</B></TD>
									<TD style="WIDTH: 7px; HEIGHT: 20px">:</TD>
									<TD style="WIDTH: 206px; HEIGHT: 20px"><asp:textbox onkeypress="return numbersonly()" id="TXT_OAK_POSISI" onblur="FormatCurrency(this)"
											runat="server" MaxLength="100" Width="184px"></asp:textbox></TD>
									<TD style="WIDTH: 107px; HEIGHT: 20px">&nbsp;</TD>
									<TD style="WIDTH: 8px; HEIGHT: 20px"></TD>
									<TD style="HEIGHT: 20px"></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 117px">&nbsp;- Kas dan bank</TD>
									<TD style="WIDTH: 7px">:</TD>
									<TD style="WIDTH: 206px"><asp:textbox onkeypress="return numbersonly()" id="TXT_OAK_KAS" onblur="FormatCurrency(this)"
											runat="server" MaxLength="100" Width="184px"></asp:textbox></TD>
									<TD style="WIDTH: 107px"></TD>
									<TD style="WIDTH: 8px"></TD>
									<TD></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 117px; HEIGHT: 15px">&nbsp;- Piutang dagang</TD>
									<TD style="WIDTH: 7px; HEIGHT: 15px">:</TD>
									<TD style="WIDTH: 206px; HEIGHT: 15px"><asp:textbox onkeypress="return numbersonly()" id="TXT_OAK_PIUTANG" onblur="FormatCurrency(this)"
											runat="server" MaxLength="100" Width="184px"></asp:textbox></TD>
									<TD style="WIDTH: 107px; HEIGHT: 15px"></TD>
									<TD style="WIDTH: 8px; HEIGHT: 15px"></TD>
									<TD style="HEIGHT: 15px"></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 117px">&nbsp;- Persediaan</TD>
									<TD style="WIDTH: 7px">:</TD>
									<TD style="WIDTH: 206px"><asp:textbox onkeypress="return numbersonly()" id="TXT_OAK_PERSEDIAAN" onblur="FormatCurrency(this)"
											runat="server" MaxLength="100" Width="184px"></asp:textbox></TD>
									<TD style="WIDTH: 107px"></TD>
									<TD style="WIDTH: 8px"></TD>
									<TD></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 117px">&nbsp;- Aktiva tetap</TD>
									<TD style="WIDTH: 7px">:</TD>
									<TD style="WIDTH: 206px"><asp:textbox onkeypress="return numbersonly()" id="TXT_OAK_AKTIVATTP" onblur="FormatCurrency(this)"
											runat="server" MaxLength="100" Width="184px"></asp:textbox></TD>
									<TD style="WIDTH: 107px"></TD>
									<TD style="WIDTH: 8px"></TD>
									<TD></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 117px">&nbsp;- Hutang dagang</TD>
									<TD style="WIDTH: 7px">:</TD>
									<TD style="WIDTH: 206px"><asp:textbox onkeypress="return numbersonly()" id="TXT_OAK_HTGDAGANG" onblur="FormatCurrency(this)"
											runat="server" MaxLength="100" Width="184px"></asp:textbox></TD>
									<TD style="WIDTH: 107px"></TD>
									<TD style="WIDTH: 8px"></TD>
									<TD></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 117px">- Hutang bank</TD>
									<TD style="WIDTH: 7px">:</TD>
									<TD style="WIDTH: 206px"><asp:textbox onkeypress="return numbersonly()" id="TXT_OAK_HTGBANK" onblur="FormatCurrency(this)"
											runat="server" MaxLength="100" Width="184px"></asp:textbox></TD>
									<TD style="WIDTH: 107px"></TD>
									<TD style="WIDTH: 8px"></TD>
									<TD></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 117px">- Modal/equality</TD>
									<TD style="WIDTH: 7px">:</TD>
									<TD style="WIDTH: 206px"><asp:textbox onkeypress="return numbersonly()" id="TXT_OAK_MODAL" onblur="FormatCurrency(this)"
											runat="server" MaxLength="100" Width="184px"></asp:textbox></TD>
									<TD style="WIDTH: 107px"></TD>
									<TD style="WIDTH: 8px"></TD>
									<TD></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD style="BACKGROUND-COLOR: #ccffff" align="left" width="100%"><b>b. Untuk permohonan 
								kredit dibawah Rp 100 juta</b></TD>
					</TR>
					<TR>
						<TD align="left" width="100%">* melampirkan data laporan keuangan</TD>
					</TR>
					<TR>
						<TD style="BACKGROUND-COLOR: #ccffff" align="left" width="100%">
							<P><b style="BACKGROUND-COLOR: #ccffff">c. Khusus untuk permohonan KI atau KMK 
									Kontraktor<b></P>
							</B></B></TD>
					</TR>
					<TR>
						<TD align="left" width="100%">
							<TABLE id="Table11" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD>Kalkulasi Biaya Proyek</TD>
									<TD style="WIDTH: 1px">:</TD>
									<TD><asp:textbox onkeypress="return kutip_satu()" id="TXT_OAK_BIAYAPROYEK" runat="server" MaxLength="200"
											Width="388px" Rows="5" TextMode="MultiLine"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					<TR>
						<TD class="tdSmallHeader" align="center" width="100%">Observasi Lain-lain</TD>
					</TR>
					<TR>
						<TD align="center" width="100%">
							<TABLE class="td" id="Table6" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 268px; HEIGHT: 26px" width="268">Jumlah 
										kendaraan operasional</TD>
									<TD style="HEIGHT: 26px" width="9">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 26px"><asp:radiobuttonlist id="CBL_OLL_JUMLAH" runat="server" Width="184px" RepeatLayout="Flow" Height="16px"
											RepeatDirection="Horizontal">
											<asp:ListItem Value="1">Mobil</asp:ListItem>
											<asp:ListItem Value="2">Motor</asp:ListItem>
											<asp:ListItem Value="3">Lain-lain :</asp:ListItem>
										</asp:radiobuttonlist><asp:textbox onkeypress="return kutip_satu()" id="TXT_OLL_JUMLAHLAIN" runat="server" MaxLength="100"
											Width="146px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 268px; HEIGHT: 24px">Keadaan kendaraan 
										operasional</TD>
									<TD style="HEIGHT: 24px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 24px"><asp:radiobuttonlist id="CBL_OLL_KEADAAN" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
											<asp:ListItem Value="1">Layak</asp:ListItem>
											<asp:ListItem Value="2">cukup layak</asp:ListItem>
											<asp:ListItem Value="3">kurang layak</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 268px">Dampak sosial ekonomi &amp; amdal</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:radiobuttonlist id="CBL_OLL_DAMPAK" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
											<asp:ListItem Value="1">positif</asp:ListItem>
											<asp:ListItem Value="2">negatif</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="tdSmallHeader" align="center" width="100%">Observasi Aspek Manajemen</TD>
					</TR>
					<TR>
						<TD align="left" width="100%"><STRONG>a. Kualitas Manajemen :</STRONG></TD>
					</TR>
					<TR>
						<TD align="left" width="100%">
							<TABLE class="td" id="Table1" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 268px; HEIGHT: 22px" width="268">Pengalaman 
										Usaha</TD>
									<TD style="HEIGHT: 22px" width="9">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 22px"><asp:radiobuttonlist id="CBL_KM_PENGALAMAN" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
											<asp:ListItem Value="1" Selected="True">&gt; 5 tahun</asp:ListItem>
											<asp:ListItem Value="2">2-5 tahun</asp:ListItem>
											<asp:ListItem Value="3">&lt; 2 tahun</asp:ListItem>
										</asp:radiobuttonlist>&nbsp;</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 268px; HEIGHT: 24px">Administrasi pencatatan 
										transaksi keuangan</TD>
									<TD style="HEIGHT: 24px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 24px"><asp:radiobuttonlist id="CBL_KM_ADMKEUANGAN" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
											<asp:ListItem Value="1" Selected="True">baik</asp:ListItem>
											<asp:ListItem Value="2">kurang baik</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 268px; HEIGHT: 21px">Kualifikasi keahlian 
										teknik</TD>
									<TD style="HEIGHT: 21px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 21px"><asp:radiobuttonlist id="CBL_KM_KUALIFIKASI" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
											<asp:ListItem Value="1" Selected="True">memadai</asp:ListItem>
											<asp:ListItem Value="2">kurang memadai</asp:ListItem>
											<asp:ListItem Value="3">tidak memadai</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 268px">Lain-lain</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_KM_LAIN" runat="server" MaxLength="100"
											Width="459px" TextMode="MultiLine" Height="50"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="tdSmallHeader" align="left" width="100%">Susunan Pengurus</TD>
					</TR>
					<TR>
						<TD align="center" width="100%"><ASP:DATAGRID id="DATA_PENGURUS" runat="server" Width="935px" CellPadding="1" PageSize="5" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="SEQ" HeaderText="NO">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="LP_NAMA" HeaderText="Nama">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="LP_JABATAN" HeaderText="Jabatan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="LP_JMLSAHAM" HeaderText="Jumlah saham (%)">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="LP_PENDIDIKAN" HeaderText="Pendidikan terakhir">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="LP_BLACKLISTDESC" HeaderText="Daftar hitam (Y/T)">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Function">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="LinkButton3" runat="server" CommandName="view">view</asp:LinkButton>&nbsp;-
											<asp:LinkButton id="LinkButton2" runat="server" CommandName="delete">delete</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn Visible="False" DataField="LP_BLACKLIST"></asp:BoundColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
					<TR>
						<TD align="center" width="100%">
							<TABLE class="td" id="Table10" width="60%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 268px; HEIGHT: 26px" width="268">Nama</TD>
									<TD style="HEIGHT: 26px" width="9">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 26px"><asp:textbox onkeypress="return kutip_satu()" id="TXT_NAMA" runat="server" MaxLength="100" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 268px; HEIGHT: 24px">Jabatan</TD>
									<TD style="HEIGHT: 24px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 24px"><asp:textbox onkeypress="return kutip_satu()" id="TXT_JABATAN" runat="server" MaxLength="100"
											Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 268px">Jumlah saham (%)</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_JUMLAH_SAHAM" runat="server" MaxLength="5"
											Width="50"></asp:textbox><asp:label id="LBL_SEQ" runat="server" Visible="False"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 268px; HEIGHT: 24px">Pendidikan terakhir</TD>
									<TD style="HEIGHT: 24px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 24px"><asp:textbox onkeypress="return kutip_satu()" id="TXT_PENDIDIKAN" runat="server" MaxLength="100"
											Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 268px">Daftar hitam (Y/T)</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_DAFTAR_HITAM" runat="server">
											<asp:ListItem Value="Y">Ya</asp:ListItem>
											<asp:ListItem Value="T" Selected="True">Tidak</asp:ListItem>
										</asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD align="center" width="100%"><asp:button id="Add_Pengurus_Btn" runat="server" Width="83" CssClass="Button1" Text="Add" onclick="Add_Pengurus_Btn_Click"></asp:button>&nbsp;
							<asp:button id="Cancel_Pengurus_Btn" runat="server" Width="84" CssClass="Button1" Visible="False"
								Text="Cancel" onclick="Cancel_Pengurus_Btn_Click"></asp:button></TD>
					</TR>
					<TR>
						<TD class="tdSmallHeader" align="center" width="100%">Observasi Barang Agunan</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 26px" align="center" width="100%"><ASP:DATAGRID id="DATA_COLLATERAL" runat="server" Width="935px" CellPadding="1" PageSize="5" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="SEQ" HeaderText="NO">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="LA_JNSAGUNAN" HeaderText="Jenis Agunan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="LA_NILAI" HeaderText="Nilai" DataFormatString="{0:0,00.00}">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="LA_KETAGUNAN" HeaderText="Lokasi/type/tahun">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="LA_BUKTIPEMILIK" HeaderText="Bukti kepemilikan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="LA_ATASNAMA" HeaderText="Atas nama">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Fungsi">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="LinkButton4" runat="server" CommandName="view">view</asp:LinkButton>&nbsp;-
											<asp:LinkButton id="LinkButton1" runat="server" CommandName="delete">delete</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
					<TR>
						<TD align="center" width="100%">
							<TABLE class="td" id="Table9" width="60%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 268px; HEIGHT: 26px" width="268">Jenis agunan</TD>
									<TD style="HEIGHT: 26px" width="9">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 26px"><asp:textbox onkeypress="return kutip_satu()" id="TXT_JENIS_AGUNAN" runat="server" MaxLength="100"
											Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 268px; HEIGHT: 24px"><asp:label id="LBL_AGN" runat="server" Visible="False"></asp:label>Nilai</TD>
									<TD style="HEIGHT: 24px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 24px"><asp:textbox onkeypress="return numbersonly()" id="TXT_NILAI" onblur="FormatCurrency(this)" runat="server"
											MaxLength="100" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 268px">Lokasi/type/tahun</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_LOKASI" runat="server" MaxLength="100"
											Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 268px; HEIGHT: 28px">Bukti kepemilikan</TD>
									<TD style="HEIGHT: 28px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 28px"><asp:textbox onkeypress="return kutip_satu()" id="TXT_BUKTI_KEPEMILIKAN" runat="server" MaxLength="100"
											Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 268px">Atas nama</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_ATAS_NAMA" runat="server" MaxLength="100"
											Width="100%"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD align="center" width="100%"><asp:button id="Add_Agunan_Btn" runat="server" Width="84px" CssClass="Button1" Text="Add" onclick="Add_Agunan_Btn_Click"></asp:button>&nbsp;
							<asp:button id="Cancel_Agunan" runat="server" Width="84px" CssClass="Button1" Visible="False"
								Text="Cancel" onclick="Cancel_Agunan_Click"></asp:button></TD>
					</TR>
					<TR>
						<TD class="tdSmallHeader" align="center" width="100%">Keterangan lain-lain yang 
							perlu diinformasikan</TD>
					</TR>
					<TR>
						<TD align="center" width="100%"><asp:textbox onkeypress="return kutip_satu()" id="TXT_KETERANGAN" runat="server" Width="98%"
								Rows="5" TextMode="MultiLine"></asp:textbox></TD>
					</TR>
					<TR>
						<TD class="tdSmallHeader" align="center" width="100%">Rencana tindak lanjut dan 
							tanggal penyelesaian</TD>
					</TR>
					<TR>
						<TD tabIndex="3" align="center" width="100%">
							<TABLE id="Table7" cellSpacing="1" cellPadding="1" width="100%" border="0">
								<TR>
									<TD style="WIDTH: 481px"><b>Rencana Tindak Lanjut 
											:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</b></TD>
									<TD><STRONG>Tanggal penyelesaian : </STRONG>
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 485px"><asp:textbox onkeypress="return kutip_satu()" id="TXT_TINDAKLANJUT" runat="server" Width="98%"
											Rows="5" TextMode="MultiLine"></asp:textbox></TD>
									<TD vAlign="top">
										<P><asp:textbox onkeypress="return numbersonly()" id="TXT_TARGET_DATE" runat="server" MaxLength="2"
												Width="24px" Columns="4" CssClass="mandatory"></asp:textbox><asp:dropdownlist id="DDL_TARGET_MONTH" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_TARGET_YEAR" runat="server" MaxLength="4"
												Columns="4" CssClass="mandatory"></asp:textbox></P>
										<P><asp:textbox onkeypress="return numbersonly()" id="TXT_TARGETDATE" runat="server" MaxLength="4"
												Width="136px" Columns="4" BorderStyle="None" ForeColor="White"></asp:textbox></P>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD align="center" width="100%">
							<TABLE id="Table8" style="WIDTH: 703px; HEIGHT: 70px" cellSpacing="1" cellPadding="1" width="703"
								border="0">
								<TR>
									<TD>Mengetahui,</TD>
									<TD></TD>
									<TD style="WIDTH: 11px"></TD>
									<TD style="WIDTH: 87px">&nbsp;</TD>
									<TD>Tanggal</TD>
									<TD>:</TD>
									<TD><asp:textbox onkeypress="return numbersonly()" id="TXT_ENTRYDATE1" runat="server" MaxLength="100"
											Width="146px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD>Atasan langsung</TD>
									<TD>:</TD>
									<TD style="WIDTH: 11px"><asp:textbox onkeypress="return kutip_satu()" id="TXT_ATASAN" runat="server" MaxLength="100"
											Width="146px"></asp:textbox></TD>
									<TD style="WIDTH: 87px"></TD>
									<TD>Dibuat oleh</TD>
									<TD>:</TD>
									<TD><asp:textbox onkeypress="return kutip_satu()" id="TXT_PEMBUAT" runat="server" MaxLength="100"
											Width="146px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD>Tanda tangan</TD>
									<TD>:</TD>
									<TD style="WIDTH: 11px"></TD>
									<TD style="WIDTH: 87px"></TD>
									<TD>Tanda tangan</TD>
									<TD>:</TD>
									<TD><asp:textbox onkeypress="return numbersonly()" id="TXT_ENTRYDATE" runat="server" MaxLength="100"
											Width="146px" BorderStyle="None" ForeColor="White"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 50px" align="center" width="100%">
							<P>&nbsp;</P>
							<P align="center">&nbsp;</P>
						</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 5px" align="center" width="100%"></TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" align="center" width="100%"><asp:button id="BTN_UPDATE" runat="server" CssClass="Button1" Text="Update" Enabled="False" onclick="BTN_UPDATE_Click"></asp:button>&nbsp;<asp:button id="SaveBtn" runat="server" CssClass="Button1" Text="Save" onclick="SaveBtn_Click"></asp:button>&nbsp;
							<asp:button id="ViewBtn" runat="server" CssClass="Button1" Text="View" Enabled="False" onclick="UpdateBtn_Click"></asp:button></TD>
					</TR>
					<tr>
						<td width="100%"></td>
					</tr>
					<TR>
						<TD colSpan="2"><uc1:docexport id="DocExport1" runat="server"></uc1:docexport></TD>
					</TR>
					<TR>
						<TD colSpan="2"><uc1:docupload id="DocUpload1" runat="server"></uc1:docupload></TD>
					</TR>
				</TABLE>
		</form>
		</CENTER>
	</body>
</HTML>
