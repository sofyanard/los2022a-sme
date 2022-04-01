<%@ Page language="c#" Codebehind="PenilaianJaminanTanahBangunan.aspx.cs" AutoEventWireup="True" Inherits="SME.Appraisal.PenilaianJaminanTanahBangunan" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Penilaian Jaminan Tanah & Bangunan</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include  file="../include/cek_all.html" -->
		<script language="javascript">
			function update()
			{
				conf = confirm("Are you sure you want to update?");
				if (conf)
				{
					return true;
				}
				else
				{
					return false;
				}
			}

			function cetak()
			{
				TR_TOMBOL.style.display	= "none";
				window.print();
				TR_TOMBOL.style.display	= "";
			}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<!-- HEADER ###################################################################################################################################-->
			<table style="PADDING-RIGHT: 5pt; PADDING-LEFT: 5pt" cellSpacing="0" cellPadding="0" width="100%"
				border="0">
				<tr>
					<td class="tdHeader1" colSpan="4">PENILAIAN JAMINAN TANAH &amp; BANGUNAN</td>
				</tr>
				<tr>
					<td width="25%">Nama Debitur</td>
					<td width="25%"><asp:textbox onkeypress="return kutip_satu()" id="txt_AT_NMDEBITUR" runat="server" Width="100%"
							ReadOnly="True"></asp:textbox></td>
					<td width="25%">Tanggal/Tahun Pemeriksaan</td>
					<td width="25%"><asp:textbox onkeypress="return numbersonly()" id="txt_AT_APPRDATE_dd" Width="25px" CssClass="mandatory"
							MaxLength="2" Runat="server" Columns="2"></asp:textbox><asp:dropdownlist id="ddl_AT_APPRDATE_mm" CssClass="mandatory" Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="txt_AT_APPRDATE_yy" Width="40px" CssClass="mandatory"
							MaxLength="4" Runat="server" Columns="4"></asp:textbox></td>
				</tr>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Penilai 1</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AT_APPRBY1" runat="server" Width="100%"
							CssClass="mandatory"></asp:textbox></TD>
				</TR>
				<TR>
					<TD><STRONG>Lokasi Angunan:</STRONG></TD>
					<TD></TD>
					<TD>Penilai 2</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AT_APPRBY2" runat="server" Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD>Jl.
					</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AT_LOKJLN" runat="server" Width="100%"
							CssClass="mandatory"></asp:textbox></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD>Desa/Kel.
					</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AT_LOKDESA" runat="server" Width="100%"
							CssClass="mandatory"></asp:textbox></TD>
					<TD>Kecamatan</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AT_LOKKEC" runat="server" Width="100%"
							CssClass="mandatory"></asp:textbox></TD>
				</TR>
				<TR>
					<TD>Kab/Kodya</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AT_LOKKAB" runat="server" Width="100%"
							CssClass="mandatory"></asp:textbox></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD colSpan="4"><asp:label id="lbl_CL_SEQ" runat="server" Visible="False"></asp:label><asp:label id="lbl_CU_REF" runat="server" Visible="False"></asp:label><asp:label id="lbl_AP_REGNO" runat="server" Visible="False"></asp:label><asp:label id="lbl_UpdateStatus" runat="server" Visible="False"></asp:label><asp:label id="lbl_TC" runat="server" Visible="False"></asp:label><asp:label id="lbl_MC" runat="server" Visible="False"></asp:label><asp:label id="lbl_GRP_CO" runat="server" Visible="False"></asp:label><asp:label id="lbl_GRP_COOFF" runat="server" Visible="False"></asp:label></TD>
				</TR>
				<TR>
					<TD class="TDBGColor2" colSpan="4"><asp:hyperlink id="hpl_Tanah" runat="server" Font-Bold="True">Tanah</asp:hyperlink>&nbsp;&nbsp;
						<asp:hyperlink id="hpl_Bangunan" runat="server" Font-Bold="True"> Bangunan</asp:hyperlink></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
				</TR>
			</table>
			<!-- TANAH ###################################################################################################################################-->
			<table id="tbl_Tanah" style="PADDING-RIGHT: 5pt; PADDING-LEFT: 5pt" cellSpacing="0" cellPadding="0"
				width="100%" border="0" runat="server">
				<tr>
					<td class="tdHeader1" colSpan="4">PENILAIAN JAMINAN TANAH</td>
				</tr>
				<tr>
					<td class="tdSmallHeader" colSpan="4">I. PENELITIAN FISIK</td>
				</tr>
				<tr>
					<td width="25%">Keadaan Fisik</td>
					<td width="25%"><asp:textbox onkeypress="return kutip_satu()" id="txt_AT_KEADAANFSK" runat="server" Width="100%"></asp:textbox></td>
					<td width="25%">Pembelian Baru</td>
					<td width="25%"><asp:dropdownlist id="ddl_AT_ISNEW" runat="server" Width="60px" Height="26px">
							<asp:ListItem Value="0">Ya</asp:ListItem>
							<asp:ListItem Value="1" Selected="True">Tidak</asp:ListItem>
						</asp:dropdownlist></td>
				</tr>
				<TR>
					<TD>Luas Tanah</TD>
					<TD><asp:textbox onkeypress="return numbersonly()" id="txt_AT_LUASTNH" runat="server" Width="60px"
							CssClass="mandatory" MaxLength="6" AutoPostBack="True"></asp:textbox>M<SUP>2</SUP></TD>
					<TD>Tahun Pembelian</TD>
					<TD><asp:textbox onkeypress="return numbersonly()" id="txt_AT_THNBELI" runat="server" Width="60px"
							CssClass="mandatory" MaxLength="4"></asp:textbox></TD>
				</TR>
				<TR>
					<TD><STRONG>Fasilitas Umum:</STRONG></TD>
					<TD></TD>
					<TD>Wilayah</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AT_WILAYAH" runat="server" Width="100%"
							ReadOnly="True" AutoPostBack="True"></asp:textbox></TD>
				</TR>
				<TR>
					<TD>Jalan/Lebar</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AT_JALAN" runat="server" Width="100px"
							ReadOnly="True"></asp:textbox><asp:textbox onkeypress="return numbersonly()" id="txt_AT_KETJALAN" runat="server" Width="60px"
							CssClass="mandatory" MaxLength="2"></asp:textbox>M</TD>
					<TD>Peruntukan Wilayah</TD>
					<TD><asp:dropdownlist id="ddl_AT_TWILUTK" runat="server" Width="100%"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD>Jaringan Listrik</TD>
					<TD><asp:dropdownlist id="ddl_AT_LISTRIK" runat="server" Width="60px" Height="25px">
							<asp:ListItem Value="0">Ya</asp:ListItem>
							<asp:ListItem Value="1">Tidak</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD><STRONG>Resiko: </STRONG>
					</TD>
					<TD></TD>
				</TR>
				<TR>
					<TD>Jaringan Telepon</TD>
					<TD><asp:dropdownlist id="ddl_AT_TELP" runat="server" Width="60px" Height="25px">
							<asp:ListItem Value="0">Ya</asp:ListItem>
							<asp:ListItem Value="1">Tidak</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD>- Daerah Rawan Banjir</TD>
					<TD><asp:dropdownlist id="ddl_AT_BANJIR" runat="server" Width="60px" Height="25px">
							<asp:ListItem Value="0">Ya</asp:ListItem>
							<asp:ListItem Value="1">Tidak</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD>Fasilitas PAM</TD>
					<TD><asp:dropdownlist id="ddl_AT_TAIR" runat="server" Width="60px" Height="25px">
							<asp:ListItem Value="0">Ya</asp:ListItem>
							<asp:ListItem Value="1">Tidak</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD>- Daerah Tegangan Tinggi</TD>
					<TD><asp:dropdownlist id="ddl_AT_TEGANGAN" runat="server" Width="60px">
							<asp:ListItem Value="0">Ya</asp:ListItem>
							<asp:ListItem Value="1">Tidak</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD>Sekolah</TD>
					<TD><asp:dropdownlist id="ddl_AT_TSEKOLAH" runat="server" Width="60px" Height="25px">
							<asp:ListItem Value="0">Ya</asp:ListItem>
							<asp:ListItem Value="1">Tidak</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD>- Daerah Rawan Longsor/Gempa Bumi
					</TD>
					<TD><asp:dropdownlist id="ddl_AT_TNHLONGSOR" runat="server" Width="60px">
							<asp:ListItem Value="0">Ya</asp:ListItem>
							<asp:ListItem Value="1">Tidak</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD>Pasar/Pembelanjaan</TD>
					<TD><asp:dropdownlist id="ddl_AT_TPASAR" runat="server" Width="60px" Height="25px">
							<asp:ListItem Value="0">Ya</asp:ListItem>
							<asp:ListItem Value="1">Tidak</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD>- Daerah Pencemaran/Polusi</TD>
					<TD><asp:dropdownlist id="ddl_AT_PENCEMARAN" runat="server" Width="60px">
							<asp:ListItem Value="0">Ya</asp:ListItem>
							<asp:ListItem Value="1">Tidak</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD>SPBU</TD>
					<TD><asp:dropdownlist id="ddl_AT_SPBU" runat="server" Width="60px" Height="25px">
							<asp:ListItem Value="0">Ya</asp:ListItem>
							<asp:ListItem Value="1">Tidak</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD>Tempat Ibadah</TD>
					<TD><asp:dropdownlist id="ddl_AT_IBADAH" runat="server" Width="60px" Height="25px">
							<asp:ListItem Value="0">Ya</asp:ListItem>
							<asp:ListItem Value="1">Tidak</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD>Kualitas Tanah</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AT_KUALITAS" runat="server" Width="100%"
							ReadOnly="True"></asp:textbox></TD>
				</TR>
				<TR>
					<TD>Tempat Hiburan</TD>
					<TD><asp:dropdownlist id="ddl_AT_HIBURAN" runat="server" Width="60px" Height="25px">
							<asp:ListItem Value="0">Ya</asp:ListItem>
							<asp:ListItem Value="1">Tidak</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD>Contour Tanah
					</TD>
					<TD><asp:dropdownlist id="ddl_AT_KONTURTNH" runat="server" Width="100%"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD>Tempat Perkuburan</TD>
					<TD><asp:dropdownlist id="ddl_AT_KUBURAN" runat="server" Width="100%"></asp:dropdownlist></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD><STRONG>Score Penelitian Fisik</STRONG></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR class="TDBGColor11">
					<TD align="center">Wilayah
						<asp:dropdownlist id="ddl_AT_SWILAYAH" runat="server" Width="60px" CssClass="mandatory" AutoPostBack="True" onselectedindexchanged="ddl_AT_SWILAYAH_SelectedIndexChanged">
							<asp:ListItem Value="0">--Pilih--</asp:ListItem>
							<asp:ListItem Value="Kota Besar">1</asp:ListItem>
							<asp:ListItem Value="Kota Sedang">2</asp:ListItem>
							<asp:ListItem Value="Kota Kecil">3</asp:ListItem>
							<asp:ListItem Value="Pedesaan">4</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD align="center">Lokasi
						<asp:dropdownlist id="ddl_AT_SLOKASI" runat="server" Width="60px" CssClass="mandatory" AutoPostBack="True" onselectedindexchanged="ddl_AT_SLOKASI_SelectedIndexChanged">
							<asp:ListItem Value="0">--Pilih--</asp:ListItem>
							<asp:ListItem Value="Jalan Utama">1</asp:ListItem>
							<asp:ListItem Value="Jalan Lingkungan &gt;=5M">2</asp:ListItem>
							<asp:ListItem Value="Jalan Lingkungan &lt; 5M">3</asp:ListItem>
							<asp:ListItem Value="Gang">4</asp:ListItem>
							<asp:ListItem Value="Tidak Ada Jalan">5</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD align="center">Kualitas
						<asp:dropdownlist id="ddl_AT_SKUALITAS" runat="server" Width="60px" CssClass="mandatory" AutoPostBack="True" onselectedindexchanged="ddl_AT_SKUALITAS_SelectedIndexChanged">
							<asp:ListItem Value="0">--Pilih--</asp:ListItem>
							<asp:ListItem Value="Sangat Baik">1</asp:ListItem>
							<asp:ListItem Value="Baik">2</asp:ListItem>
							<asp:ListItem Value="Sedang">3</asp:ListItem>
							<asp:ListItem Value="Jelek">4</asp:ListItem>
							<asp:ListItem Value="Sangat Jelek">5</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD align="center">Lingkungan
						<asp:dropdownlist id="ddl_AT_SLINGKUNGAN" runat="server" Width="60px" CssClass="mandatory" AutoPostBack="True" onselectedindexchanged="ddl_AT_SLINGKUNGAN_SelectedIndexChanged">
							<asp:ListItem Value="0">--Pilih--</asp:ListItem>
							<asp:ListItem Value="Sangat Lenkap">1</asp:ListItem>
							<asp:ListItem Value="Lengkap">2</asp:ListItem>
							<asp:ListItem Value="Cukup Lengkap">3</asp:ListItem>
							<asp:ListItem Value="Kurang Lengkap">4</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD align="center" class="TDBGColor"><STRONG>Score</STRONG>
						<asp:textbox id="txt_Score" runat="server" Width="60px" Enabled="False"></asp:textbox></TD>
				</TR>
				<TR>
					<TD colSpan="4"></TD>
				</TR>
				<TR>
					<TD class="tdSmallHeader" colSpan="4">II. PENELITIAN YURIDIS</TD>
				</TR>
				<TR class="TDBGColor11">
					<TD><STRONG>Bukti Kepemilikan</STRONG></TD>
					<TD><asp:dropdownlist id="ddl_AT_BKTYPE" runat="server" Width="100%"></asp:dropdownlist></TD>
					<TD>Nomor</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AT_BKNO" runat="server" Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Atas Nama
					</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AT_BKNAMA" runat="server" Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Berlaku s/d
					</TD>
					<TD><asp:textbox onkeypress="return numbersonly()" id="txt_AT_BKDATE_dd" Width="25px" MaxLength="2"
							Runat="server" Columns="2"></asp:textbox><asp:dropdownlist id="ddl_AT_BKDATE_mm" Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="txt_AT_BKDATE_yy" Width="40px" MaxLength="4"
							Runat="server" Columns="4"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Akte Jual Beli</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AT_BKAKTA" runat="server" Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Notaris
					</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AT_BKNOTARIS" runat="server" Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR class="TDBGColor11">
					<TD><STRONG>Ikatan Jaminan</STRONG></TD>
					<TD><asp:dropdownlist id="ddl_AT_IJTYPE" runat="server" Width="100%">
							<asp:ListItem Value="0">Terikat</asp:ListItem>
							<asp:ListItem Value="1">Bebas Ikatan</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD>No. Akta</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AT_IJNO" runat="server" Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Sertifikat Hak Tanggungan</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AT_IJSERTIFIKAT" runat="server" Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Nilai Pengikatan (Rp)</TD>
					<TD><asp:textbox onkeypress="return numbersonly()" id="txt_AT_IJNILAI" runat="server" Width="100%"
							MaxLength="10"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Notaris</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AT_IJNOTARIS" runat="server" Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Pada</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AT_IJPADA" runat="server" Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR class="TDBGColor11">
					<TD><STRONG>Pengecekan Keabsahan</STRONG></TD>
					<TD></TD>
					<TD>Hasil Pengecekan</TD>
					<TD rowSpan="2"><asp:textbox onkeypress="return kutip_satu()" id="txt_AT_ABHASIL" runat="server" Width="100%"
							Height="50px" TextMode="MultiLine"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Tanggal Pengecekan</TD>
					<TD><asp:textbox onkeypress="return numbersonly()" id="txt_AT_ABDATE_dd" Width="25px" MaxLength="2"
							Runat="server" Columns="2"></asp:textbox><asp:dropdownlist id="ddl_AT_ABDATE_mm" Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="txt_AT_ABDATE_yy" Width="40px" MaxLength="4"
							Runat="server" Columns="4"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Kanton BPN</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AT_ABKANTOR" runat="server" Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Pejabat BPN</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AT_ABPEJABAT" runat="server" Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD colSpan="4"></TD>
				</TR>
				<TR>
					<TD class="tdSmallHeader" colSpan="4">III. PERHITUNGAN PASAR WAJAR YANG DAPAT 
						DITERIMA BANK</TD>
				</TR>
				<TR>
					<TD>Tujuan Penilaian
					</TD>
					<TD><asp:dropdownlist id="ddl_AT_TUJUAN" runat="server" Width="216px"></asp:dropdownlist></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD colSpan="4">
						<P><NOBR><STRONG>Informasi</STRONG></NOBR><NOBR><STRONG>/Data Harga Pasar per M2</STRONG></NOBR></P>
					</TD>
				</TR>
				<TR>
					<TD colSpan="4">
						<TABLE style="PADDING-RIGHT: 5pt; PADDING-LEFT: 5pt" borderColor="black" cellSpacing="0"
							cellPadding="0" width="100%" border="0">
							<TR class="TDBGColor11">
								<TD width="20%"></TD>
								<TD width="20%"></TD>
								<TD align="center" width="25%"><STRONG>Nama/Instansi</STRONG></TD>
								<TD align="center" width="25%"><STRONG>Alamat/Telp</STRONG></TD>
								<TD align="center" width="10%"><STRONG>Tanggal</STRONG></TD>
							</TR>
							<TR>
								<TD>Data Pembanding I</TD>
								<TD><asp:textbox onkeypress="return numbersonly()" id="txt_AT_DATA1" runat="server" Width="100%"
										CssClass="mandatory" MaxLength="10"></asp:textbox></TD>
								<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AT_NAMA1" runat="server" Width="100%"></asp:textbox></TD>
								<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AT_ALAMAT1" runat="server" Width="100%"></asp:textbox></TD>
								<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AT_TGL1" runat="server" Width="100%" MaxLength="10"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>Terendah</TD>
								<TD></TD>
								<TD></TD>
								<TD></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD>Data Pembanding II</TD>
								<TD><asp:textbox onkeypress="return numbersonly()" id="txt_AT_DATA2" runat="server" Width="100%"
										CssClass="mandatory" MaxLength="10"></asp:textbox></TD>
								<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AT_NAMA2" runat="server" Width="100%"></asp:textbox></TD>
								<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AT_ALAMAT2" runat="server" Width="100%"></asp:textbox></TD>
								<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AT_TGL2" runat="server" Width="100%" MaxLength="10"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>Median</TD>
								<TD></TD>
								<TD></TD>
								<TD></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD>Data Pembanding III</TD>
								<TD><asp:textbox onkeypress="return numbersonly()" id="txt_AT_DATA3" runat="server" Width="100%"
										CssClass="mandatory" MaxLength="10"></asp:textbox></TD>
								<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AT_NAMA3" runat="server" Width="100%"></asp:textbox></TD>
								<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AT_ALAMAT3" runat="server" Width="100%"></asp:textbox></TD>
								<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AT_TGL3" runat="server" Width="100%" MaxLength="10"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>Tertinggi</TD>
								<TD></TD>
								<TD></TD>
								<TD></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD></TD>
								<TD></TD>
								<TD></TD>
								<TD></TD>
								<TD></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD><STRONG>Nilai Pasar per M2</STRONG></TD>
					<TD><asp:textbox id="txt_AT_NILPASAR" runat="server" Width="100%" ReadOnly="True"></asp:textbox></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD><STRONG>Harga Pasar keseluruhan </STRONG>
					</TD>
					<TD><asp:textbox id="txt_AT_HRGPASAR" runat="server" Width="100%" ReadOnly="True"></asp:textbox></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD><STRONG>Safety Margin</STRONG></TD>
					<TD><asp:textbox id="txt_AT_SFTYMARGIN" runat="server" Width="60px" ReadOnly="True"></asp:textbox></TD>
					<TD align="right"><STRONG>Score</STRONG></TD>
					<TD><asp:textbox id="txt_ScoreTanah" runat="server" Width="60px" ReadOnly="True"></asp:textbox>&nbsp;<asp:button id="btn_CalcTanah" runat="server" CssClass="Button1" Text="Calculate" onclick="btn_CalcTanah_Click"></asp:button></TD>
				</TR>
				<TR>
					<TD><STRONG>Nilai Pasar Wajar yang Dapat Diterima Bank</STRONG></TD>
					<TD><asp:textbox id="txt_AT_HRGWAJAR" runat="server" Width="100%" ReadOnly="True"></asp:textbox></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD colSpan="4"></TD>
				</TR>
				<TR>
					<TD class="tdSmallHeader" colSpan="4">IV. KESIMPULAN</TD>
				</TR>
				<TR>
					<TD>Marketability</TD>
					<TD><asp:dropdownlist id="ddl_AT_MARKET" runat="server" Width="216px"></asp:dropdownlist></TD>
					<TD>Permasalahan</TD>
					<TD><asp:dropdownlist id="ddl_AT_MASALAH" runat="server" Width="216px"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD>Pengikatan Sempurna</TD>
					<TD><asp:dropdownlist id="ddl_AT_IKAT" runat="server" Width="216px"></asp:dropdownlist></TD>
					<TD>Penguasaan</TD>
					<TD><asp:dropdownlist id="ddl_AT_KUASA" runat="server" Width="216px"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD>Lain-Lain
					</TD>
					<TD colSpan="3"><asp:textbox onkeypress="return kutip_satu()" id="txt_AT_LAIN" runat="server" Width="100%" Height="50px"
							TextMode="MultiLine"></asp:textbox></TD>
				</TR>
			</table>
			<!-- BANGUNAN ###################################################################################################################################-->
			<table id="tbl_Bangunan" style="PADDING-RIGHT: 5pt; PADDING-LEFT: 5pt" cellSpacing="0"
				cellPadding="0" width="100%" border="0" runat="server">
				<tr>
					<td class="tdHeader1" colSpan="4">PENILAIAN JAMINAN BANGUNAN</td>
				</tr>
				<tr>
					<td class="tdSmallHeader" colSpan="4">I. PENELITIAN FISIK</td>
				</tr>
				<tr>
					<td width="25%">Luas Bangunan
					</td>
					<td width="25%"><asp:textbox onkeypress="return numbersonly()" id="txt_AB_LUASBANGUN" runat="server" Width="60px"
							CssClass="mandatory" MaxLength="6"></asp:textbox>M<SUP>2</SUP></td>
					<td width="25%">Tahun Pembangunan</td>
					<td width="25%"><asp:textbox onkeypress="return numbersonly()" id="txt_AB_THNBUAT" runat="server" Width="60px"
							CssClass="mandatory" MaxLength="4"></asp:textbox></td>
				</tr>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Tahun Renovasi Terakhir</TD>
					<TD><asp:textbox onkeypress="return numbersonly()" id="txt_AB_THNRENOVASI" runat="server" Width="60px"
							MaxLength="4"></asp:textbox></TD>
				</TR>
				<TR>
					<TD>Penggunaan Bangunan
					</TD>
					<TD><asp:dropdownlist id="ddl_AB_GUNA" runat="server" Width="100px" Height="30px"></asp:dropdownlist><asp:textbox onkeypress="return kutip_satu()" id="txt_AB_GUNAKET" runat="server" Width="60px"></asp:textbox></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD><STRONG>Prasarana:</STRONG></TD>
					<TD></TD>
					<TD><STRONG>Kualitas Bangunan: </STRONG>
					</TD>
					<TD></TD>
				</TR>
				<TR>
					<TD>Jaringan Listrik
					</TD>
					<TD><asp:dropdownlist id="ddl_AB_LISTRIK" runat="server" Width="60px">
							<asp:ListItem Value="0">Ya</asp:ListItem>
							<asp:ListItem Value="1">Tidak</asp:ListItem>
						</asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="txt_AB_KETLISTRIK" runat="server" Width="60px"
							MaxLength="4">0</asp:textbox>Watt</TD>
					<TD>- Pondasi dan Konstruksi
					</TD>
					<TD><asp:dropdownlist id="ddl_AB_KONTRUKSI" runat="server" Width="100%"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD>Jaringan Telepon/Fax</TD>
					<TD><asp:dropdownlist id="ddl_AB_TELPFAX" runat="server" Width="60px">
							<asp:ListItem Value="0">Ya</asp:ListItem>
							<asp:ListItem Value="1">Tidak</asp:ListItem>
						</asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="txt_AB_KETTELPFAX" runat="server" Width="60px"
							MaxLength="2">0</asp:textbox>Line
					</TD>
					<TD>- Dinding
					</TD>
					<TD><asp:dropdownlist id="ddl_AB_DINDING" runat="server" Width="100%"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD>Jaringan Air
					</TD>
					<TD><asp:dropdownlist id="ddl_AB_AIR" runat="server" Width="60px">
							<asp:ListItem Value="0">Ya</asp:ListItem>
							<asp:ListItem Value="1">Tidak</asp:ListItem>
						</asp:dropdownlist><asp:dropdownlist id="ddl_AB_KETAIR" runat="server" Width="60px"></asp:dropdownlist></TD>
					<TD>- Atap</TD>
					<TD><asp:dropdownlist id="ddl_AB_ATAP" runat="server" Width="100%"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD>Alat Pendingin/AC</TD>
					<TD><asp:dropdownlist id="ddl_AB_AC" runat="server" Width="60px">
							<asp:ListItem Value="0">Ya</asp:ListItem>
							<asp:ListItem Value="1">Tidak</asp:ListItem>
						</asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="txt_AB_KETAC" runat="server" Width="60px"
							MaxLength="2">0</asp:textbox>Unit</TD>
					<TD>- Lantai
					</TD>
					<TD><asp:dropdownlist id="ddl_AB_LANTAI" runat="server" Width="100%"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD>Lainnya
					</TD>
					<TD><asp:dropdownlist id="ddl_AB_PRASARANALAIN" runat="server" Width="60px">
							<asp:ListItem Value="0">Ya</asp:ListItem>
							<asp:ListItem Value="1">Tidak</asp:ListItem>
						</asp:dropdownlist><asp:textbox onkeypress="return kutip_satu()" id="txt_AB_KETPRASARANALAIN" runat="server" Width="100px"></asp:textbox></TD>
					<TD>- Pintu/Jendela
					</TD>
					<TD><asp:dropdownlist id="ddl_AB_PINTU" runat="server" Width="100%"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD>Jenis Bangunan
					</TD>
					<TD><asp:dropdownlist id="ddl_AB_JENISBANGUNAN" runat="server" Width="100%"></asp:dropdownlist></TD>
					<TD>Kondisi
					</TD>
					<TD><asp:dropdownlist id="ddl_AB_KONDISI" runat="server" Width="100%" CssClass="mandatory" Height="56px"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Perawatan/Pemeliharaan
					</TD>
					<TD><asp:dropdownlist id="ddl_AB_PEMELIHARAANBGN" runat="server" Width="100%" CssClass="mandatory" Height="56px"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Lokasi Bangunan</TD>
					<TD><asp:dropdownlist id="ddl_AB_LOKASI" runat="server" Width="100%"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD colSpan="4"></TD>
				</TR>
				<TR>
					<TD class="tdSmallHeader" colSpan="4">II. PENELITIAN YURIDIS</TD>
				</TR>
				<TR class="TDBGColor11">
					<TD>&nbsp;Ijin Mendirikan Bangunan<!-- BANGUNAN ###################################################################################################################################--></TD>
					<TD><asp:dropdownlist id="ddl_AB_IJINSTAT" runat="server" Width="100%">
							<asp:ListItem Value="0">Ada</asp:ListItem>
							<asp:ListItem Value="1">Tidak</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD>Nomor</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AB_IJINNO" runat="server" Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Dikeluarkan</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AB_IJINDKELUARK" runat="server" Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Tanggal</TD>
					<TD><asp:textbox onkeypress="return numbersonly()" id="txt_AB_IJINDATE_DD" Width="25px" MaxLength="2"
							Runat="server" Columns="2"></asp:textbox><asp:dropdownlist id="ddl_AB_IJINDATE_MM" Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="txt_AB_IJINDATE_YY" Width="40px" MaxLength="4"
							Runat="server" Columns="4"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Luas</TD>
					<TD><asp:textbox onkeypress="return numbersonly()" id="txt_AB_IJINLUAS" runat="server" Width="80px"></asp:textbox>M<SUP>2</SUP>
					</TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR class="TDBGColor11">
					<TD>Asuransi</TD>
					<TD><asp:dropdownlist id="ddl_AB_INSRSTATUS" runat="server" Width="100%">
							<asp:ListItem Value="0">Tercover</asp:ListItem>
							<asp:ListItem Value="1">Tidak</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD>Jenis Penutupan Asuransi</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AB_INSRTUTUP" runat="server" Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Nilai Pertanggungan (Rp)</TD>
					<TD><asp:textbox onkeypress="return numbersonly()" id="txt_AB_INSRAMOUNT" runat="server" Width="100%"
							MaxLength="10"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Pertanggungan Berlaku s/d</TD>
					<TD><asp:textbox onkeypress="return numbersonly()" id="txt_AB_INSREXPDATE_DD" Width="25px" MaxLength="2"
							Runat="server" Columns="2"></asp:textbox><asp:dropdownlist id="ddl_AB_INSREXPDATE_MM" Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="txt_AB_INSREXPDATE_YY" Width="40px" MaxLength="4"
							Runat="server" Columns="4"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Perusahaan Asuransi
					</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AB_INSRCOMP" runat="server" Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD colSpan="4"></TD>
				</TR>
				<TR>
					<TD class="tdSmallHeader" colSpan="4">III. PERHITUNGAN PASAR WAJAR YANG DAPAT 
						DITERIMA BANK
					</TD>
				</TR>
				<TR>
					<TD>Tujuan Penilaian
					</TD>
					<TD><asp:dropdownlist id="ddl_AB_TUJUAN" runat="server" Width="100%"></asp:dropdownlist></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD colSpan="4"><STRONG>Informasi/Data Harga Pasar</STRONG></TD>
				</TR>
				<TR>
					<TD>Informasi Harga Pasar Baru /M<SUP>2</SUP> (Rp)</TD>
					<TD><asp:textbox onkeypress="return numbersonly()" id="txt_AB_HRGBARUM2" runat="server" Width="100%"
							CssClass="mandatory" MaxLength="10"></asp:textbox></TD>
					<TD>Sumber Data</TD>
					<TD></TD>
				</TR>
				<TR>
					<TD>Biaya Pembangunan Baru (Rp)</TD>
					<TD><asp:textbox id="txt_AB_HRGBANGUNBARU" runat="server" Width="100%" ReadOnly="True"></asp:textbox></TD>
					<TD rowSpan="3"><asp:textbox onkeypress="return kutip_satu()" id="txt_AB_SUMBERDATA" runat="server" Width="100%"
							Height="50px" TextMode="MultiLine"></asp:textbox></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD>Umur Ekonomis</TD>
					<TD><asp:textbox onkeypress="return numbersonly()" id="txt_AB_UMUREKON" runat="server" Width="60px"
							CssClass="mandatory" MaxLength="2"></asp:textbox>Tahun
					</TD>
					<TD></TD>
				</TR>
				<TR>
					<TD>Umur Efektif
					</TD>
					<TD><asp:textbox id="txt_AB_UMUREFEKTIF" runat="server" Width="60px" ReadOnly="True"></asp:textbox>Tahun
					</TD>
					<TD></TD>
				</TR>
				<TR>
					<TD>Penyusutan Pertahun
					</TD>
					<TD><asp:textbox id="txt_AB_SUSUTPERTHN" runat="server" Width="60px" ReadOnly="True"></asp:textbox></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD>Akumulasi Penyusutan (Rp)</TD>
					<TD><asp:textbox id="txt_AB_AKUMSUSUT" runat="server" Width="100%" ReadOnly="True"></asp:textbox></TD>
					<TD><asp:textbox id="txt_AB_AKUMSUSUTP" runat="server" Width="60px" ReadOnly="True"></asp:textbox></TD>
					<TD>
						<asp:textbox id="txt_Score1" runat="server" Width="25px" DESIGNTIMEDRAGDROP="30544" Enabled="False"></asp:textbox></TD>
				</TR>
				<TR>
					<TD><STRONG>Nilai Pasar Bangunan (Rp)</STRONG></TD>
					<TD><asp:textbox id="txt_AB_HRGBANGUNAN" runat="server" Width="100%" ReadOnly="True"></asp:textbox></TD>
					<TD></TD>
					<TD>
						<asp:textbox id="txt_Score2" runat="server" Width="25px" Enabled="False"></asp:textbox></TD>
				</TR>
				<TR>
					<TD><STRONG>Safety Margin</STRONG></TD>
					<TD><asp:textbox id="txt_AB_SFTYMARGIN" runat="server" Width="60px" ReadOnly="True"></asp:textbox></TD>
					<TD align="right"><STRONG>Total Score</STRONG></TD>
					<TD><asp:textbox id="txt_TOTALSCORE" runat="server" Width="60px" ReadOnly="True"></asp:textbox>&nbsp;<asp:button id="btn_CalcBangunan" runat="server" CssClass="Button1" Text="Calculate" onclick="btn_CalcBangunan_Click"></asp:button></TD>
				</TR>
				<TR>
					<TD><STRONG>Nilai Pasar yang Dapat Diterima Bank (Rp)</STRONG></TD>
					<TD><asp:textbox id="txt_AB_HRGBANK" runat="server" Width="100%" ReadOnly="True"></asp:textbox></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD colSpan="4"></TD>
				</TR>
				<TR>
					<TD class="tdSmallHeader" colSpan="4">IV. KESIMPULAN</TD>
				</TR>
				<TR>
					<TD colSpan="4">
						<asp:textbox onkeypress="return kutip_satu()" id="txt_AB_KESIMPULAN" runat="server" Width="100%"
							Height="50px" TextMode="MultiLine"></asp:textbox></TD>
				</TR>
			</table>
			<!-- FOOTER ###################################################################################################################################-->
			<TABLE id="Akhir" cellSpacing="2" cellPadding="2" width="100%">
				<TR>
					<TD class="TblAlternating" align="center"><STRONG>Total Informasi Pasar yang Dapat 
							Diterima Bank: </STRONG>
						<asp:textbox id="txt_TotHargaBank" runat="server" Width="158px" ReadOnly="True"></asp:textbox></TD>
				</TR>
				<TR id="TR_TOMBOL">
					<TD class="TDBGColor2"><asp:button id="btn_Reentry" runat="server" CssClass="Button1" Visible="False" Text="Re-Entry" onclick="btn_Reentry_Click"></asp:button>&nbsp;
						<asp:button id="btn_Save" runat="server" CssClass="Button1" Text="Save" onclick="btn_Save_Click"></asp:button>&nbsp;
						<asp:button id="btn_UpdateStatus" runat="server" CssClass="Button1" Text="Update Status" onclick="btn_UpdateStatus_Click"></asp:button>&nbsp;<INPUT class="Button1" id="BTN_PRINT" onclick="cetak()" type="button" value="Print" name="BTN_PRINT"></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
