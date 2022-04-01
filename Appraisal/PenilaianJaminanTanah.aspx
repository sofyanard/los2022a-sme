<%@ Page language="c#" Codebehind="PenilaianJaminanTanah.aspx.cs" AutoEventWireup="True" Inherits="SME.Appraisal.PenilaianJaminanTanah" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Penilaian Jaminan Tanah</title>
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
			<table style="PADDING-RIGHT: 5pt; PADDING-LEFT: 5pt" cellSpacing="0" cellPadding="0" width="100%"
				border="0">
				<tr>
					<td class="tdHeader1" colSpan="4"><STRONG> PENILAIAN JAMINAN TANAH</STRONG></td>
				</tr>
				<tr>
					<td width="25%">Nama Debitur</td>
					<td width="25%"><asp:textbox id="txt_AT_NMDEBITUR" runat="server" Width="100%" onkeypress="return kutip_satu()"
							ReadOnly="True"></asp:textbox></td>
					<td width="25%">Tanggal/Tahun Pemeriksaan</td>
					<td width="25%"><asp:textbox onkeypress="return numbersonly()" id="txt_AT_APPRDATE_dd" Width="25px" Columns="2"
							Runat="server" MaxLength="2" CssClass="mandatory"></asp:textbox><asp:dropdownlist id="ddl_AT_APPRDATE_mm" Runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="txt_AT_APPRDATE_yy" Width="40px" Columns="4"
							Runat="server" MaxLength="4" CssClass="mandatory"></asp:textbox></td>
				</tr>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Penilai 1</TD>
					<TD><asp:textbox id="txt_AT_APPRBY1" runat="server" onkeypress="return kutip_satu()" CssClass="mandatory"
							Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD><STRONG>Lokasi Angunan:</STRONG></TD>
					<TD></TD>
					<TD>Penilai 2</TD>
					<TD>
						<asp:textbox id="txt_AT_APPRBY2" runat="server" onkeypress="return kutip_satu()" Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD>Jl.
					</TD>
					<TD>
						<asp:textbox onkeypress="return kutip_satu()" id="txt_AT_LOKJLN" runat="server" Width="100%"
							CssClass="mandatory"></asp:textbox></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD>Desa/Kel.</TD>
					<TD>
						<asp:textbox onkeypress="return kutip_satu()" id="txt_AT_LOKDESA" runat="server" Width="100%"
							CssClass="mandatory"></asp:textbox></TD>
					<TD>Kecamatan</TD>
					<TD>
						<asp:textbox onkeypress="return kutip_satu()" id="txt_AT_LOKKEC" runat="server" Width="100%"
							CssClass="mandatory"></asp:textbox></TD>
				</TR>
				<TR>
					<TD>Kab/Kodya</TD>
					<TD>
						<asp:textbox onkeypress="return kutip_satu()" id="txt_AT_LOKKAB" runat="server" Width="100%"
							CssClass="mandatory"></asp:textbox></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD colSpan="4">
						<asp:label id="lbl_CL_SEQ" runat="server" Visible="False"></asp:label>
						<asp:label id="lbl_CU_REF" runat="server" Visible="False"></asp:label>
						<asp:label id="lbl_AP_REGNO" runat="server" Visible="False"></asp:label>
						<asp:label id="lbl_UpdateStatus" runat="server" Visible="False"></asp:label>
						<asp:Label id="lbl_TC" runat="server" Visible="False"></asp:Label>
						<asp:Label id="lbl_MC" runat="server" Visible="False"></asp:Label>
						<asp:Label id="lbl_GRP_CO" runat="server" Visible="False"></asp:Label>
						<asp:Label id="lbl_GRP_COOFF" runat="server" Visible="False"></asp:Label></TD>
				</TR>
				<TR>
					<TD class="tdHeader1" colSpan="4">I. PENELITIAN FISIK</TD>
				</TR>
				<TR>
					<TD>Keadaan Fisik
					</TD>
					<TD>
						<asp:textbox onkeypress="return kutip_satu()" id="txt_AT_KEADAANFSK" runat="server" Width="100%"></asp:textbox></TD>
					<TD>Pembelian Baru
					</TD>
					<TD>
						<asp:dropdownlist id="ddl_AT_ISNEW" runat="server" Width="60px">
							<asp:ListItem Value="0">Ya</asp:ListItem>
							<asp:ListItem Value="1" Selected="True">Tidak</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD>Luas Tanah</TD>
					<TD>
						<asp:textbox onkeypress="return numbersonly()" id="txt_AT_LUASTNH" runat="server" Width="60px"
							CssClass="mandatory" MaxLength="6" AutoPostBack="True"></asp:textbox>M<SUP>2</SUP></TD>
					<TD>Tahun Pembelian
					</TD>
					<TD>
						<asp:textbox onkeypress="return numbersonly()" id="txt_AT_THNBELI" runat="server" Width="60px"
							CssClass="mandatory" MaxLength="4"></asp:textbox></TD>
				</TR>
				<TR>
					<TD><STRONG>Fasilitas Umum:</STRONG>
					</TD>
					<TD></TD>
					<TD>Wilayah</TD>
					<TD>
						<asp:textbox onkeypress="return kutip_satu()" id="txt_AT_WILAYAH" runat="server" ReadOnly="True"
							Width="100%" AutoPostBack="True"></asp:textbox></TD>
				</TR>
				<TR>
					<TD>Jalan/Lebar
					</TD>
					<TD>
						<asp:textbox onkeypress="return kutip_satu()" id="txt_AT_JALAN" runat="server" ReadOnly="True"
							Width="100px"></asp:textbox>
						<asp:textbox onkeypress="return numbersonly()" id="txt_AT_KETJALAN" runat="server" Width="60px"
							CssClass="mandatory" MaxLength="2"></asp:textbox>M</TD>
					<TD>Peruntukan Wilayah
					</TD>
					<TD>
						<asp:dropdownlist id="ddl_AT_TWILUTK" runat="server" Width="100%"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD>Jaringan Listrik
					</TD>
					<TD>
						<asp:dropdownlist id="ddl_AT_LISTRIK" runat="server" Width="72px">
							<asp:ListItem Value="0">Ya</asp:ListItem>
							<asp:ListItem Value="1">Tidak</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD><STRONG>Resiko:</STRONG></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD>Jaringan Telepon</TD>
					<TD><asp:dropdownlist id="ddl_AT_TELP" runat="server" Width="72px">
							<asp:ListItem Value="0">Ya</asp:ListItem>
							<asp:ListItem Value="1">Tidak</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD>- Daerah Rawan Banjir</TD>
					<TD>
						<asp:dropdownlist id="ddl_AT_BANJIR" runat="server" Width="60px">
							<asp:ListItem Value="0">Ya</asp:ListItem>
							<asp:ListItem Value="1">Tidak</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD>Fasilitas PAM</TD>
					<TD>
						<asp:dropdownlist id="ddl_AT_TAIR" runat="server" Width="72px">
							<asp:ListItem Value="0">Ya</asp:ListItem>
							<asp:ListItem Value="1">Tidak</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD>- Daerah Tegangan Tinggi
					</TD>
					<TD>
						<asp:dropdownlist id="ddl_AT_TEGANGAN" runat="server" Width="60px">
							<asp:ListItem Value="0">Ya</asp:ListItem>
							<asp:ListItem Value="1">Tidak</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD>Sekolah
					</TD>
					<TD>
						<asp:dropdownlist id="ddl_AT_TSEKOLAH" runat="server" Width="72px">
							<asp:ListItem Value="0">Ya</asp:ListItem>
							<asp:ListItem Value="1">Tidak</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD>- Daerah Rawan Longsor/Gempa Bumi
					</TD>
					<TD>
						<asp:dropdownlist id="ddl_AT_TNHLONGSOR" runat="server" Width="60px">
							<asp:ListItem Value="0">Ya</asp:ListItem>
							<asp:ListItem Value="1">Tidak</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD>Pasar/Pembelanjaan
					</TD>
					<TD>
						<asp:dropdownlist id="ddl_AT_TPASAR" runat="server" Width="72px">
							<asp:ListItem Value="0">Ya</asp:ListItem>
							<asp:ListItem Value="1">Tidak</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD>- Daerah Pencemaran/Polusi
					</TD>
					<TD>
						<asp:dropdownlist id="ddl_AT_PENCEMARAN" runat="server" Width="60px">
							<asp:ListItem Value="0">Ya</asp:ListItem>
							<asp:ListItem Value="1">Tidak</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD>SPBU
					</TD>
					<TD>
						<asp:dropdownlist id="ddl_AT_SPBU" runat="server" Width="72px">
							<asp:ListItem Value="0">Ya</asp:ListItem>
							<asp:ListItem Value="1">Tidak</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD>
						&nbsp;
					</TD>
					<TD></TD>
				</TR>
				<TR>
					<TD>Tempat Ibadah
					</TD>
					<TD>
						<asp:dropdownlist id="ddl_AT_IBADAH" runat="server" Width="72px">
							<asp:ListItem Value="0">Ya</asp:ListItem>
							<asp:ListItem Value="1">Tidak</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD>Kualitas Tanah
					</TD>
					<TD>
						<asp:textbox onkeypress="return kutip_satu()" id="txt_AT_KUALITAS" runat="server" ReadOnly="True"
							Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD>Tempat Hiburan</TD>
					<TD>
						<asp:dropdownlist id="ddl_AT_HIBURAN" runat="server" Width="72px">
							<asp:ListItem Value="0">Ya</asp:ListItem>
							<asp:ListItem Value="1">Tidak</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD>Contour Tanah</TD>
					<TD>
						<asp:dropdownlist id="ddl_AT_KONTURTNH" runat="server" Width="100%"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD>Tempat Perkuburan
					</TD>
					<TD>
						<asp:dropdownlist id="ddl_AT_KUBURAN" runat="server" Width="100%"></asp:dropdownlist></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD><STRONG>Score Penelitian Fisik </STRONG>
					</TD>
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
					<TD class="tdHeader1" colSpan="4">II. PENELITIAN YURIDIS</TD>
				</TR>
				<TR class="TDBGColor11">
					<TD><STRONG>Bukti Kepemilikan</STRONG>
					</TD>
					<TD>
						<asp:dropdownlist id="ddl_AT_BKTYPE" runat="server" Width="100%"></asp:dropdownlist></TD>
					<TD>Nomor
					</TD>
					<TD>
						<asp:textbox onkeypress="return kutip_satu()" id="txt_AT_BKNO" runat="server" Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Atas Nama</TD>
					<TD>
						<asp:textbox onkeypress="return kutip_satu()" id="txt_AT_BKNAMA" runat="server" Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Berlaku s/d
					</TD>
					<TD>
						<asp:textbox onkeypress="return numbersonly()" id="txt_AT_BKDATE_dd" Width="25px" MaxLength="2"
							Runat="server" Columns="2"></asp:textbox>
						<asp:dropdownlist id="ddl_AT_BKDATE_mm" Runat="server"></asp:dropdownlist>
						<asp:textbox onkeypress="return numbersonly()" id="txt_AT_BKDATE_yy" Width="40px" MaxLength="4"
							Runat="server" Columns="4"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Akta Jual Beli
					</TD>
					<TD>
						<asp:textbox onkeypress="return kutip_satu()" id="txt_AT_BKAKTA" runat="server" Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Notaris</TD>
					<TD>
						<asp:textbox onkeypress="return kutip_satu()" id="txt_AT_BKNOTARIS" runat="server" Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR class="TDBGColor11">
					<TD><STRONG>Ikatan Jaminan</STRONG>
					</TD>
					<TD>
						<asp:dropdownlist id="ddl_AT_IJTYPE" runat="server" Width="100%">
							<asp:ListItem Value="0">Terikat</asp:ListItem>
							<asp:ListItem Value="1">Bebas Ikatan</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD>No. Akta
					</TD>
					<TD>
						<asp:textbox onkeypress="return kutip_satu()" id="txt_AT_IJNO" runat="server" Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Sertifikat Hak Tanggungan
					</TD>
					<TD>
						<asp:textbox onkeypress="return kutip_satu()" id="txt_AT_IJSERTIFIKAT" runat="server" Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Nilai Pengikatan (Rp)</TD>
					<TD>
						<asp:textbox onkeypress="return numbersonly()" id="txt_AT_IJNILAI" runat="server" Width="100%"
							MaxLength="10"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Notaris</TD>
					<TD>
						<asp:textbox onkeypress="return kutip_satu()" id="txt_AT_IJNOTARIS" runat="server" Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Pada</TD>
					<TD>
						<asp:textbox onkeypress="return kutip_satu()" id="txt_AT_IJPADA" runat="server" Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR class="TDBGColor11">
					<TD><STRONG>Pengecekan Keabsahan </STRONG>
					</TD>
					<TD></TD>
					<TD>Hasil Pengecekan</TD>
					<TD rowspan="2"><asp:textbox id="txt_AT_ABHASIL" runat="server" Width="100%" Height="50px" TextMode="MultiLine"
							onkeypress="return kutip_satu()"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Tanggal Pengecekan</TD>
					<TD><asp:textbox onkeypress="return numbersonly()" id="txt_AT_ABDATE_dd" Width="25px" Columns="2"
							Runat="server" MaxLength="2"></asp:textbox><asp:dropdownlist id="ddl_AT_ABDATE_mm" Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="txt_AT_ABDATE_yy" Width="40px" Columns="4"
							Runat="server" MaxLength="4"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Kanton BPN</TD>
					<TD><asp:textbox id="txt_AT_ABKANTOR" runat="server" Width="184px" onkeypress="return kutip_satu()"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Pejabat BPN</TD>
					<TD><asp:textbox id="txt_AT_ABPEJABAT" runat="server" onkeypress="return kutip_satu()"></asp:textbox></TD>
				</TR>
				<TR>
					<TD colSpan="4"></TD>
				</TR>
				<TR>
					<TD class="tdHeader1" colSpan="4">III. PERHITUNGAN PASAR WAJAR YANG DAPAT DITERIMA 
						BANK</TD>
				</TR>
				<TR>
					<TD>Tujuan Penilaian</TD>
					<TD><asp:dropdownlist id="ddl_Tujuan" runat="server" Width="100%"></asp:dropdownlist></TD>
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
								<TD><asp:textbox id="txt_AT_DATA1" runat="server" Width="100%" onkeypress="return numbersonly()"
										CssClass="mandatory" MaxLength="10"></asp:textbox></TD>
								<TD><asp:textbox id="txt_AT_NAMA1" runat="server" Width="100%" onkeypress="return kutip_satu()"></asp:textbox></TD>
								<TD><asp:textbox id="txt_AT_ALAMAT1" runat="server" Width="100%" onkeypress="return kutip_satu()"></asp:textbox></TD>
								<TD><asp:textbox id="txt_AT_TGL1" runat="server" Width="100%" onkeypress="return kutip_satu()" MaxLength="10"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>Terendah</TD>
								<TD></TD>
								<TD></TD>
								<TD></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD>Data Pembanding II
								</TD>
								<TD><asp:textbox id="txt_AT_DATA2" runat="server" Width="100%" onkeypress="return numbersonly()"
										CssClass="mandatory" MaxLength="10"></asp:textbox></TD>
								<TD><asp:textbox id="txt_AT_NAMA2" runat="server" Width="100%" onkeypress="return kutip_satu()"></asp:textbox></TD>
								<TD><asp:textbox id="txt_AT_ALAMAT2" runat="server" Width="100%" onkeypress="return kutip_satu()"></asp:textbox></TD>
								<TD><asp:textbox id="txt_AT_TGL2" runat="server" Width="100%" onkeypress="return kutip_satu()" MaxLength="10"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>Median
								</TD>
								<TD></TD>
								<TD></TD>
								<TD></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD>Data Pembanding III</TD>
								<TD><asp:textbox id="txt_AT_DATA3" runat="server" Width="100%" onkeypress="return numbersonly()"
										CssClass="mandatory" MaxLength="10"></asp:textbox></TD>
								<TD><asp:textbox id="txt_AT_NAMA3" runat="server" Width="100%" onkeypress="return kutip_satu()"></asp:textbox></TD>
								<TD><asp:textbox id="txt_AT_ALAMAT3" runat="server" Width="100%" onkeypress="return kutip_satu()"></asp:textbox></TD>
								<TD><asp:textbox id="txt_AT_TGL3" runat="server" Width="100%" onkeypress="return kutip_satu()" MaxLength="10"></asp:textbox></TD>
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
					<TD><STRONG>Harga Pasar keseluruhan</STRONG></TD>
					<TD><asp:textbox id="txt_AT_HRGPASAR" runat="server" Width="100%" ReadOnly="True"></asp:textbox></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD><STRONG>Safety Margin</STRONG></TD>
					<TD><asp:textbox id="txt_AT_SFTYMARGIN" runat="server" Width="60px" ReadOnly="True"></asp:textbox></TD>
					<TD align="right"><STRONG>Score</STRONG></TD>
					<TD><asp:textbox id="txt_Score2" runat="server" Width="60px" ReadOnly="True"></asp:textbox>&nbsp;<asp:button id="btn_Calc" runat="server" Text="Calculate" CssClass="Button1" onclick="btn_Calc_Click"></asp:button></TD>
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
					<TD class="tdHeader1" colSpan="4">IV. KESIMPULAN</TD>
				</TR>
				<TR>
					<TD>Marketability</TD>
					<TD><asp:dropdownlist id="ddl_AT_MARKET" runat="server" Width="100%"></asp:dropdownlist></TD>
					<TD>Permasalahan</TD>
					<TD><asp:dropdownlist id="ddl_AT_MASALAH" runat="server" Width="100%"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD>Pengikatan Sempurna</TD>
					<TD><asp:dropdownlist id="ddl_AT_IKAT" runat="server" Width="100%"></asp:dropdownlist></TD>
					<TD>Penguasaan
					</TD>
					<TD><asp:dropdownlist id="ddl_AT_KUASA" runat="server" Width="100%"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD>Lain-Lain</TD>
					<TD colSpan="3"><asp:textbox id="txt_AT_LAIN" runat="server" Width="100%" Height="50px" TextMode="MultiLine"
							onkeypress="return kutip_satu()"></asp:textbox></TD>
				</TR>
				<TR id="TR_TOMBOL">
					<TD class="TDBGColor2" colSpan="4">
						<asp:button id="btn_Reentry" runat="server" CssClass="Button1" Visible="False" Text="Re-Entry" onclick="btn_Reentry_Click"></asp:button>&nbsp;
						<asp:button id="btn_Save" runat="server" Text="Save" CssClass="Button1" onclick="btn_Save_Click"></asp:button>&nbsp;
						<asp:Button id="btn_Delete" runat="server" CssClass="button1" Text="Delete" onclick="btn_Delete_Click"></asp:Button>&nbsp;
						<asp:button id="btn_UpdateStatus" runat="server" Text="Update Status" CssClass="Button1" onclick="btn_UpdateStatus_Click"></asp:button>&nbsp;<INPUT class="Button1" id="BTN_PRINT" onclick="cetak()" type="button" value="Print" name="BTN_PRINT"></TD>
				</TR>
			</table>
		</form>
	</body>
</HTML>
