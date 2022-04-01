<%@ Page language="c#" Codebehind="PenilaianJaminanSPBU.aspx.cs" AutoEventWireup="True" Inherits="SME.Appraisal.PenilaianJaminanSPBU" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Penilaian Jaminan SPBU</title>
		<meta content="False" name="vs_showGrid">
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
					<td class="tdHeader1" colSpan="4">PENILAIAN JAMINAN SPBU</td>
				</tr>
				<tr>
					<td width="25%">Nama Debitur</td>
					<td width="25%"><asp:textbox onkeypress="return kutip_satu()" id="txt_AS_NMDEBITUR" runat="server" ReadOnly="True"
							Width="100%"></asp:textbox></td>
					<td width="25%">Tanggal/Tahun Pemeriksaan</td>
					<td width="25%"><asp:textbox onkeypress="return numbersonly()" id="txt_AS_APPRDATE_dd" Width="25px" Columns="2"
							Runat="server" MaxLength="2" CssClass="mandatory"></asp:textbox><asp:dropdownlist id="ddl_AS_APPRDATE_mm" Runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="txt_AS_APPRDATE_yy" Width="40px" Columns="4"
							Runat="server" MaxLength="4" CssClass="mandatory"></asp:textbox></td>
				</tr>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Penilai 1</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AS_APPRBY1" runat="server" Width="100%"
							CssClass="mandatory"></asp:textbox></TD>
				</TR>
				<TR>
					<TD><STRONG>Lokasi Angunan:</STRONG></TD>
					<TD></TD>
					<TD>Penilai 2</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AS_APPRBY2" runat="server" Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD>Jl.</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AS_LOKJLN" runat="server" Width="100%"
							CssClass="mandatory"></asp:textbox></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD>Desa/Kel.</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AS_LOKDESA" runat="server" Width="100%"
							CssClass="mandatory"></asp:textbox></TD>
					<TD>Kecamatan</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AS_LOKKEC" runat="server" Width="100%"
							CssClass="mandatory"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 21px">Kab/Kodya</TD>
					<TD style="HEIGHT: 21px"><asp:textbox onkeypress="return kutip_satu()" id="txt_AS_LOKKAB" runat="server" Width="100%"
							CssClass="mandatory"></asp:textbox></TD>
					<TD style="HEIGHT: 21px"></TD>
					<TD style="HEIGHT: 21px"></TD>
				</TR>
				<TR>
					<TD colSpan="4"><asp:label id="lbl_AP_REGNO" runat="server" Visible="False"></asp:label><asp:label id="lbl_CU_REF" runat="server" Visible="False"></asp:label><asp:label id="lbl_CL_SEQ" runat="server" Visible="False"></asp:label><asp:label id="lbl_UpdateStatus" runat="server" Visible="False"></asp:label><asp:label id="lbl_TC" runat="server" Visible="False"></asp:label><asp:label id="lbl_MC" runat="server" Visible="False"></asp:label><asp:label id="lbl_GRP_CO" runat="server" Visible="False"></asp:label><asp:label id="lbl_GRP_COOFF" runat="server" Visible="False"></asp:label></TD>
				</TR>
				<TR>
					<TD class="tdHeader1" colSpan="4">I. PENELITIAN FISIK</TD>
				</TR>
				<TR>
					<TD>Luas Tanah</TD>
					<TD><asp:textbox onkeypress="return numbersonly()" id="txt_AS_LUASTNH" runat="server" Width="60px"
							MaxLength="6" CssClass="mandatory"></asp:textbox>M<SUP>2</SUP></TD>
					<TD>Wilayah</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AS_WILAYAH" runat="server" ReadOnly="True"
							Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD><STRONG>Fasilitas Umum:</STRONG></TD>
					<TD></TD>
					<TD>Lingkungan</TD>
					<TD><asp:dropdownlist id="ddl_AS_LINGKUNGAN" runat="server" Width="100%"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD>Jalan/Lebar</TD>
					<TD><asp:dropdownlist id="ddl_AS_JALAN" runat="server" Width="100px"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="txt_AS_KETJALAN" runat="server" Width="60px"
							MaxLength="2" CssClass="mandatory"></asp:textbox>M
					</TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD>Jenis Jalan</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AS_JNSJALAN" runat="server" ReadOnly="True"
							Width="100%"></asp:textbox></TD>
					<TD><STRONG>Resiko:</STRONG></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD>Jaringan Listrik</TD>
					<TD><asp:dropdownlist id="ddl_AS_LISTRIK" runat="server" Width="60px">
							<asp:ListItem Value="0">Ya</asp:ListItem>
							<asp:ListItem Value="1">Tidak</asp:ListItem>
						</asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="txt_AS_KETLISTRIK" runat="server" Width="60px"
							MaxLength="4">0</asp:textbox>Watt
					</TD>
					<TD>- Daerah Rawan Banjir</TD>
					<TD><asp:dropdownlist id="ddl_AS_BANJIR" runat="server" Width="72px">
							<asp:ListItem Value="0">Ya</asp:ListItem>
							<asp:ListItem Value="1">Tidak</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD>Jaringan Telepon</TD>
					<TD><asp:dropdownlist id="ddl_AS_TELP" runat="server" Width="60px">
							<asp:ListItem Value="0">Ya</asp:ListItem>
							<asp:ListItem Value="1">Tidak</asp:ListItem>
						</asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="txt_AS_KETTELP" runat="server" Width="60px"
							MaxLength="2">0</asp:textbox>Line
					</TD>
					<TD>- Daerah Tegangan Tinggi
					</TD>
					<TD><asp:dropdownlist id="ddl_AS_TEGANGAN" runat="server" Width="72px">
							<asp:ListItem Value="0">Ya</asp:ListItem>
							<asp:ListItem Value="1">Tidak</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD>Jaringan PAM</TD>
					<TD><asp:dropdownlist id="ddl_AS_PAM" runat="server" Width="60px">
							<asp:ListItem Value="0">Ya</asp:ListItem>
							<asp:ListItem Value="1">Tidak</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD>- Daerah Rawan Longsor/Gempa Bumi</TD>
					<TD><asp:dropdownlist id="ddl_AS_LONGSOR" runat="server" Width="72px">
							<asp:ListItem Value="0">Ya</asp:ListItem>
							<asp:ListItem Value="1">Tidak</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD>Frekuensi Kendaraan</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AS_FREKKDRN" runat="server" ReadOnly="True"
							Width="100%"></asp:textbox></TD>
					<TD>- Daerah Pencemaran/Polusi</TD>
					<TD><asp:dropdownlist id="ddl_AS_POLUSI" runat="server" Width="72px">
							<asp:ListItem Value="0">Ya</asp:ListItem>
							<asp:ListItem Value="1">Tidak</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD>Kodisi</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AS_KONDISI" runat="server" ReadOnly="True"
							Width="100%"></asp:textbox></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD>Perawatan</TD>
					<TD><asp:dropdownlist id="ddl_AS_PERAWATAN" runat="server" Width="100%" Height="56px"></asp:dropdownlist></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD><STRONG>Score Penelitian Fisik</STRONG></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD align="center">Wilayah
						<asp:dropdownlist id="ddl_AS_SWILAYAH" runat="server" Width="60px" CssClass="mandatory" AutoPostBack="True" onselectedindexchanged="ddl_AS_SWILAYAH_SelectedIndexChanged">
							<asp:ListItem Value="0">--Pilih--</asp:ListItem>
							<asp:ListItem Value="Kota Besar">1</asp:ListItem>
							<asp:ListItem Value="Kota Sedang">2</asp:ListItem>
							<asp:ListItem Value="Kota Kecil">3</asp:ListItem>
							<asp:ListItem Value="Pedesaan">4</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD align="center">Lokasi
						<asp:dropdownlist id="ddl_AS_SLOKASI" runat="server" Width="60px" CssClass="mandatory" AutoPostBack="True" onselectedindexchanged="ddl_AS_SLOKASI_SelectedIndexChanged">
							<asp:ListItem Value="0">--Pilih--</asp:ListItem>
							<asp:ListItem Value="Pinggir Kota">1</asp:ListItem>
							<asp:ListItem Value="Dalam Kota">2</asp:ListItem>
							<asp:ListItem Value="Luar Kota">3</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD align="center">Frekuensi
						<asp:dropdownlist id="ddl_AS_SFREK" runat="server" Width="60px" CssClass="mandatory" AutoPostBack="True" onselectedindexchanged="ddl_AS_SFREK_SelectedIndexChanged">
							<asp:ListItem Value="0">--Pilih--</asp:ListItem>
							<asp:ListItem Value="Sangat Tinggi">1</asp:ListItem>
							<asp:ListItem Value="Tinggi">2</asp:ListItem>
							<asp:ListItem Value="Cukup Tinggi">3</asp:ListItem>
							<asp:ListItem Value="Kurang">4</asp:ListItem>
							<asp:ListItem Value="Sangat Kurang">5</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD align="center">Kondisi
						<asp:dropdownlist id="ddl_AS_SKONDISI" runat="server" Width="60px" CssClass="mandatory" Height="56px"
							AutoPostBack="True" onselectedindexchanged="ddl_AS_SKONDISI_SelectedIndexChanged">
							<asp:ListItem Value="0">--Pilih--</asp:ListItem>
							<asp:ListItem Value="Sangat Baik">1</asp:ListItem>
							<asp:ListItem Value="Baik">2</asp:ListItem>
							<asp:ListItem Value="Cukup/Sedang">3</asp:ListItem>
							<asp:ListItem Value="Jelek">4</asp:ListItem>
							<asp:ListItem Value="Sangat Jelek">5</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD colSpan="4"></TD>
				</TR>
				<TR>
					<TD class="tdHeader1" colSpan="4">II. PENELITIAN YURIDIS</TD>
				</TR>
				<TR class="TDBGColor11">
					<TD><STRONG>A. Bukti Kepemilikan</STRONG></TD>
					<TD><asp:dropdownlist id="ddl_AS_BKTYPE" runat="server" Width="100%"></asp:dropdownlist></TD>
					<TD>Nomor</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AS_BKNO" runat="server" Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Atas Nama</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AS_BKNAMA" runat="server" Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Akta Jual Beli</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AS_BKAKTA" runat="server" Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Berlaku s/d</TD>
					<TD><asp:textbox onkeypress="return numbersonly()" id="txt_AS_BKDATE_dd" Width="25px" Columns="2"
							Runat="server" MaxLength="2"></asp:textbox><asp:dropdownlist id="ddl_AS_BKDATE_mm" Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="txt_AS_BKDATE_yy" Width="40px" Columns="4"
							Runat="server" MaxLength="4"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Notaris</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AS_BKNOTARIS" runat="server" Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR class="TDBGColor11">
					<TD><STRONG>B. Ikatan Jaminan</STRONG></TD>
					<TD><asp:dropdownlist id="ddl_AS_IJTYPE" runat="server" Width="100%">
							<asp:ListItem Value="0">Terikat</asp:ListItem>
							<asp:ListItem Value="1">Bebas Ikatan</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD>No. Akta</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AS_IJNO" runat="server" Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Sertifikat Hak Tanggungan</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AS_IJSERTIFIKAT" runat="server" Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Nilai Pengikatan (Rp)</TD>
					<TD><asp:textbox onkeypress="return numbersonly()" id="txt_AS_IJNILAI" runat="server" Width="100%"
							MaxLength="10"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Notaris</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AS_IJNOTARIS" runat="server" Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Pada</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AS_IJPADA" runat="server" Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR class="TDBGColor11">
					<TD><STRONG>C. Pengecekan Keabsahan</STRONG></TD>
					<TD></TD>
					<TD>Hasil Pengecekan</TD>
					<TD rowSpan="2"><asp:textbox onkeypress="return kutip_satu()" id="txt_AS_ABHASIL" runat="server" Width="100%"
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
					<TD>Tanggal Pengecekan
					</TD>
					<TD><asp:textbox onkeypress="return numbersonly()" id="txt_AS_ABDATE_dd" Width="25px" Columns="2"
							Runat="server" MaxLength="2"></asp:textbox><asp:dropdownlist id="ddl_AS_ABDATE_mm" Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="txt_AS_ABDATE_yy" Width="40px" Columns="4"
							Runat="server" MaxLength="4"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Kanton BPN</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AS_ABKANTOR" runat="server" Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Pejabat BPN</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AS_ABPEJABAT" runat="server" Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR class="TDBGColor11">
					<TD><STRONG>D. Peijinan SPBU</STRONG>
					</TD>
					<TD><asp:dropdownlist id="ddl_AS_PSSTAT" runat="server" Width="100%">
							<asp:ListItem Value="0">Ada</asp:ListItem>
							<asp:ListItem Value="1">Tidak</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD>Nomor</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AS_PSNO" runat="server" Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Atas Nama</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AS_PSNAMA" runat="server" Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Tanggal</TD>
					<TD><asp:textbox onkeypress="return numbersonly()" id="txt_AS_PSDATE_dd" Width="25px" Columns="2"
							Runat="server" MaxLength="2"></asp:textbox><asp:dropdownlist id="ddl_AS_PSDATE_mm" Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="txt_AS_PSDATE_yy" Width="40px" Columns="4"
							Runat="server" MaxLength="4"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR class="TDBGColor11">
					<TD><STRONG>E. Ijin Mendirikan Bangunan</STRONG></TD>
					<TD><asp:dropdownlist id="ddl_AS_IMBSTAT" runat="server" Width="100%">
							<asp:ListItem Value="0">Ada</asp:ListItem>
							<asp:ListItem Value="1">Tidak</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD>Nomor</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AS_IMBNO" runat="server" Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Dikeluarkan</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AS_IMBDKELUARK" runat="server" Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Tanggal</TD>
					<TD><asp:textbox onkeypress="return numbersonly()" id="txt_AS_IMBDATE_dd" Width="25px" Columns="2"
							Runat="server" MaxLength="2"></asp:textbox><asp:dropdownlist id="ddl_AS_IMBDATE_mm" Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="txt_AS_IMBDATE_yy" Width="40px" Columns="4"
							Runat="server" MaxLength="4"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR class="TDBGColor11">
					<TD><STRONG>F. Asuransi</STRONG>
					</TD>
					<TD><asp:dropdownlist id="ddl_AS_INSRSTAT" runat="server" Width="100%">
							<asp:ListItem Value="0">Tercover</asp:ListItem>
							<asp:ListItem Value="1">Tidak</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD>Jenis Penutupan Asuransi
					</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AS_INSRTUTUP" runat="server" Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Nilai Pertanggungan (Rp)
					</TD>
					<TD><asp:textbox onkeypress="return numbersonly()" id="txt_AS_INSRNILAI" runat="server" Width="100%"
							MaxLength="10"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Berlakunya Polis s/d
					</TD>
					<TD><asp:textbox onkeypress="return numbersonly()" id="txt_AS_INSRDATE_dd" Width="25px" Columns="2"
							Runat="server" MaxLength="2"></asp:textbox><asp:dropdownlist id="ddl_AS_INSRDATE_mm" Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="txt_AS_INSRDATE_yy" Width="40px" Columns="4"
							Runat="server" MaxLength="4"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Perusahaan Asuransi
					</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AS_INSRCOMP" runat="server" Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD colSpan="4"></TD>
				</TR>
				<TR>
					<TD class="tdHeader1" colSpan="4">III. PERHITUNGAN PASAR WAJAR YANG DAPAT DITERIMA 
						BANK</TD>
				</TR>
				<TR>
					<TD>Tujuan Penilaian
					</TD>
					<TD><asp:dropdownlist id="ddl_Tujuan" runat="server" Width="100%"></asp:dropdownlist></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD colSpan="4"><STRONG>Informasi/Data Harga Pasar</STRONG>
					</TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR class="TDBGColor11">
					<TD>Metode I</TD>
					<TD><asp:textbox onkeypress="return numbersonly()" id="txt_AS_DATA1" runat="server" Width="100%"
							MaxLength="10" CssClass="mandatory"></asp:textbox></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR class="TDBGColor11">
					<TD>Metode II
					</TD>
					<TD><asp:textbox onkeypress="return numbersonly()" id="txt_AS_DATA2" runat="server" Width="100%"
							MaxLength="10" CssClass="mandatory"></asp:textbox></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD>Harga Pasar keseluruhan
					</TD>
					<TD><asp:textbox id="txt_AS_HRGPASAR" runat="server" ReadOnly="True" Width="100%"></asp:textbox></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD>Safety Margin
					</TD>
					<TD><asp:textbox id="txt_AS_SFTYMARGIN" runat="server" ReadOnly="True" Width="60px" Height="20px"></asp:textbox></TD>
					<TD align="right"><STRONG>Score</STRONG></TD>
					<TD><asp:textbox id="txt_Score" runat="server" ReadOnly="True" Width="60px"></asp:textbox>&nbsp;<asp:button id="btn_Calc" runat="server" CssClass="Button1" Text="Calculate" onclick="btn_Calc_Click"></asp:button></TD>
				</TR>
				<TR>
					<TD>Nilai Pasar Wajar yang Dapat Diterima Bank
					</TD>
					<TD><asp:textbox id="txt_AS_HRGWAJAR" runat="server" ReadOnly="True" Width="100%"></asp:textbox></TD>
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
					<TD>Marketability
					</TD>
					<TD><asp:dropdownlist id="ddl_AS_MARKET" runat="server" Width="100%"></asp:dropdownlist></TD>
					<TD>Permasalahan
					</TD>
					<TD><asp:dropdownlist id="ddl_AS_MASALAH" runat="server" Width="100%"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD>Pengikatan Sempurna</TD>
					<TD><asp:dropdownlist id="ddl_AS_IKAT" runat="server" Width="100%"></asp:dropdownlist></TD>
					<TD>Penguasaan
					</TD>
					<TD><asp:dropdownlist id="ddl_AS_KUASA" runat="server" Width="100%"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD>Lain-Lain
					</TD>
					<TD colSpan="3"><asp:textbox onkeypress="return kutip_satu()" id="txt_AS_LAIN" runat="server" Width="100%" Height="50px"
							TextMode="MultiLine"></asp:textbox></TD>
				</TR>
				<TR id="TR_TOMBOL">
					<TD class="TDBGColor2" colSpan="4"><asp:button id="btn_Reentry" runat="server" CssClass="Button1" Visible="False" Text="Re-Entry" onclick="btn_Reentry_Click"></asp:button>&nbsp;
						<asp:button id="btn_Save" runat="server" CssClass="Button1" Text="Save" onclick="btn_Save_Click"></asp:button>&nbsp;
						<asp:Button id="btn_Delete" runat="server" CssClass="button1" Text="Delete" onclick="btn_Delete_Click"></asp:Button>&nbsp;
						<asp:button id="btn_UpdateStatus" runat="server" CssClass="Button1" Text="Update Status" onclick="btn_UpdateStatus_Click"></asp:button>&nbsp;<INPUT class="Button1" id="BTN_PRINT" onclick="cetak()" type="button" value="Print" name="BTN_PRINT"></TD>
				</TR>
			</table>
		</form>
	</body>
</HTML>
