<%@ Page language="c#" Codebehind="PenilaianJaminanRUKO.aspx.cs" AutoEventWireup="True" Inherits="SME.Appraisal.PenilaianJaminanRUKO" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Penilaian Jaminan RUKO</title>
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
					<td class="tdHeader1" colSpan="4"><STRONG>PENILAIAN JAMINAN RUMAH TOKO</STRONG></td>
				</tr>
				<tr>
					<td width="25%">Nama Debitur</td>
					<td width="25%"><asp:textbox onkeypress="return kutip_satu()" id="txt_AR_NMDEBITUR" runat="server" Width="100%"
							ReadOnly="True"></asp:textbox></td>
					<td width="25%">Tanggal/Tahun Pemeriksaan</td>
					<td width="25%"><asp:textbox onkeypress="return numbersonly()" id="txt_AR_APPRDATE_DD" Width="25px" MaxLength="2"
							Runat="server" Columns="2" CssClass="mandatory"></asp:textbox><asp:dropdownlist id="ddl_AR_APPRDATE_MM" Runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="txt_AR_APPRDATE_YY" Width="40px" MaxLength="4"
							Runat="server" Columns="4" CssClass="mandatory"></asp:textbox></td>
				</tr>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Penilai 1</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AR_APPRBY1" runat="server" Width="100%"
							CssClass="mandatory"></asp:textbox></TD>
				</TR>
				<TR>
					<TD><STRONG>Lokasi Angunan:</STRONG></TD>
					<TD></TD>
					<TD>Penilai 2</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AR_APPRBY2" runat="server" Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD>Jl.</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AR_LOKJLN" runat="server" Width="100%"
							CssClass="mandatory"></asp:textbox></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD>Desa/Kel.</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AR_LOKDESA" runat="server" Width="100%"
							CssClass="mandatory"></asp:textbox></TD>
					<TD>Kecamatan</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AR_LOKKEC" runat="server" Width="100%"
							CssClass="mandatory"></asp:textbox></TD>
				</TR>
				<TR>
					<TD>Kab/Kodya</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AR_LOKKAB" runat="server" Width="100%"
							CssClass="mandatory"></asp:textbox></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD colSpan="4"><asp:label id="lbl_CL_SEQ" runat="server" Visible="False"></asp:label><asp:label id="lbl_CU_REF" runat="server" Visible="False"></asp:label><asp:label id="lbl_AP_REGNO" runat="server" Visible="False"></asp:label><asp:label id="lbl_UpdateStatus" runat="server" Visible="False"></asp:label><asp:label id="lbl_TC" runat="server" Visible="False"></asp:label><asp:label id="lbl_MC" runat="server" Visible="False"></asp:label><asp:label id="lbl_GRP_CO" runat="server" Visible="False"></asp:label><asp:label id="lbl_GRP_COOFF" runat="server" Visible="False"></asp:label></TD>
				</TR>
				<TR>
					<TD class="tdHeader1" colSpan="4">I. PENELITIAN FISIK</TD>
				</TR>
				<TR>
					<TD>Luas Tanah/Bangunan</TD>
					<TD><asp:textbox onkeypress="return numbersonly()" id="txt_AR_LUASBANGUN" runat="server" Width="60px"
							MaxLength="6" CssClass="mandatory"></asp:textbox>M<SUP>2</SUP></TD>
					<TD>Tahun Pembuatan</TD>
					<TD><asp:textbox onkeypress="return numbersonly()" id="txt_AR_THNBUAT" runat="server" Width="60px"
							MaxLength="4" CssClass="mandatory"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 22px">Pengembang</TD>
					<TD style="HEIGHT: 22px"><asp:textbox onkeypress="return kutip_satu()" id="txt_AR_PENGEMBANG" runat="server" Width="100%"></asp:textbox></TD>
					<TD style="HEIGHT: 22px">Pembelian baru</TD>
					<TD style="HEIGHT: 22px"><asp:dropdownlist id="ddl_AR_ISNEW" runat="server" Width="60px">
							<asp:ListItem Value="0">Ya</asp:ListItem>
							<asp:ListItem Value="1" Selected="True">Tidak</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD>Jalan</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AR_JALAN" runat="server" Width="100px"
							ReadOnly="True"></asp:textbox><asp:textbox onkeypress="return numbersonly()" id="txt_AR_KETJALAN" runat="server" Width="60px"
							MaxLength="2" CssClass="mandatory"></asp:textbox>M</TD>
					<TD>Wilayah</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AR_WILAYAH" runat="server" Width="100%"
							ReadOnly="True"></asp:textbox></TD>
				</TR>
				<TR>
					<TD>Jaringan Listrik</TD>
					<TD><asp:dropdownlist id="ddl_AR_LISTRIK" runat="server" Width="60px">
							<asp:ListItem Value="0">Ya</asp:ListItem>
							<asp:ListItem Value="1">Tidak</asp:ListItem>
						</asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="txt_AR_KETLISTRIK" runat="server" Width="60px"
							MaxLength="4">0</asp:textbox>Watt</TD>
					<TD>Lingkungan</TD>
					<TD><asp:dropdownlist id="ddl_AR_LINGKUNGAN" runat="server" Width="100%"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD>Jaringan Telepon</TD>
					<TD><asp:dropdownlist id="ddl_AR_TELPFAX" runat="server" Width="60px">
							<asp:ListItem Value="0">Ya</asp:ListItem>
							<asp:ListItem Value="1">Tidak</asp:ListItem>
						</asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="txt_AR_KETTELPFAX" runat="server" Width="60px"
							MaxLength="2">0</asp:textbox>Line</TD>
					<TD><STRONG>Resiko:</STRONG></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD>Jaringan Air</TD>
					<TD><asp:dropdownlist id="ddl_AR_AIR" runat="server" Width="60px">
							<asp:ListItem Value="0">Ya</asp:ListItem>
							<asp:ListItem Value="1">Tidak</asp:ListItem>
						</asp:dropdownlist><asp:dropdownlist id="ddl_AR_KETAIR" runat="server" Width="60px"></asp:dropdownlist></TD>
					<TD>- Daerah Rawan Banjir</TD>
					<TD><asp:dropdownlist id="ddl_AR_BANJIR" runat="server" Width="60px">
							<asp:ListItem Value="0">Ya</asp:ListItem>
							<asp:ListItem Value="1">Tidak</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD>Alat Pendingin</TD>
					<TD><asp:dropdownlist id="ddl_AR_AC" runat="server" Width="60px">
							<asp:ListItem Value="0">Ya</asp:ListItem>
							<asp:ListItem Value="1">Tidak</asp:ListItem>
						</asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="txt_AR_KETAC" runat="server" Width="60px"
							MaxLength="2">0</asp:textbox>Unit</TD>
					<TD>- Daerah Tegangan Tinggi</TD>
					<TD><asp:dropdownlist id="ddl_AR_TEGANGAN" runat="server" Width="60px">
							<asp:ListItem Value="0">Ya</asp:ListItem>
							<asp:ListItem Value="1">Tidak</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD>Prasarana Umum</TD>
					<TD><asp:dropdownlist id="ddl_AR_PRASARANAUMUM" runat="server" Width="100%"></asp:dropdownlist></TD>
					<TD>- Daerah Rawan Longsor/Gempa Bumi</TD>
					<TD><asp:dropdownlist id="ddl_AR_TNHLONGSOR" runat="server" Width="60px">
							<asp:ListItem Value="0">Ya</asp:ListItem>
							<asp:ListItem Value="1">Tidak</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD>Bangunan</TD>
					<TD><asp:dropdownlist id="ddl_AR_BANGUNAN" runat="server" Width="100%"></asp:dropdownlist></TD>
					<TD>- Daerah Pencemaran/Polusi</TD>
					<TD><asp:dropdownlist id="ddl_AR_PENCEMARAN" runat="server" Width="60px">
							<asp:ListItem Value="0">Ya</asp:ListItem>
							<asp:ListItem Value="1">Tidak</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD>Kualitas Bangunan</TD>
					<TD><asp:dropdownlist id="ddl_AR_KUALITAS" runat="server" Width="100%" Height="56px"></asp:dropdownlist></TD>
					<TD>Kondisi</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AR_KONDISI" runat="server" Width="100%"
							ReadOnly="True"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Perawatan/Pemeliharaan
					</TD>
					<TD><asp:dropdownlist id="ddl_AR_PERAWATAN" runat="server" Width="100%" Height="56px"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD><STRONG>Score Penelitian Fisik</STRONG></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR class="TDBGColor11">
					<TD align="center">Wilayah<asp:dropdownlist id="ddl_AR_SWILAYAH" runat="server" Width="60px" CssClass="mandatory" AutoPostBack="True" onselectedindexchanged="ddl_AR_SWILAYAH_SelectedIndexChanged">
							<asp:ListItem Value="0">--Pilih--</asp:ListItem>
							<asp:ListItem Value="Kota Besar">1</asp:ListItem>
							<asp:ListItem Value="Kota Sedang">2</asp:ListItem>
							<asp:ListItem Value="Kota Kecil">3</asp:ListItem>
							<asp:ListItem Value="Pedesaan">4</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD align="center">Lokasi<asp:dropdownlist id="ddl_AR_SLOKASI" runat="server" Width="60px" CssClass="mandatory" AutoPostBack="True" onselectedindexchanged="ddl_AR_SLOKASI_SelectedIndexChanged">
							<asp:ListItem Value="0">--Pilih--</asp:ListItem>
							<asp:ListItem Value="Jalan Utama">1</asp:ListItem>
							<asp:ListItem Value="Jalan Lingkungan &gt;=5M">2</asp:ListItem>
							<asp:ListItem Value="Jalan Lingkungan &lt; 5M">3</asp:ListItem>
							<asp:ListItem Value="Gang">4</asp:ListItem>
							<asp:ListItem Value="Tidak Ada Jalan">5</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD align="center">Bangunan
						<asp:dropdownlist id="ddl_AR_SBANGUNAN" runat="server" Width="60px" CssClass="mandatory" AutoPostBack="True" onselectedindexchanged="ddl_AR_SBANGUNAN_SelectedIndexChanged">
							<asp:ListItem Value="0">--Pilih--</asp:ListItem>
							<asp:ListItem Value="Sangat Baik">1</asp:ListItem>
							<asp:ListItem Value="Baik">2</asp:ListItem>
							<asp:ListItem Value="Sedang">3</asp:ListItem>
							<asp:ListItem Value="Jelek">4</asp:ListItem>
							<asp:ListItem Value="Sangat Jelek">5</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD align="center">Lingkungan &nbsp;
						<asp:dropdownlist id="ddl_AR_SLINGKUNGAN" runat="server" Width="60px" CssClass="mandatory" AutoPostBack="True" onselectedindexchanged="ddl_AR_SLINGKUNGAN_SelectedIndexChanged">
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
					<TD class="TDBGColor" align="center"><STRONG>Score
							<asp:textbox id="txt_Score" runat="server" Width="60px" Enabled="False"></asp:textbox></STRONG></TD>
				</TR>
				<TR>
					<TD colSpan="4"></TD>
				</TR>
				<TR>
					<TD class="tdHeader1" colSpan="4">II. PENELITIAN YURIDIS
					</TD>
				</TR>
				<TR class="TDBGColor11">
					<TD style="HEIGHT: 12px"><STRONG>Bukti Kepemilikan</STRONG></TD>
					<TD style="HEIGHT: 12px"><asp:dropdownlist id="ddl_AR_BKTYPE" runat="server" Width="100%"></asp:dropdownlist></TD>
					<TD style="HEIGHT: 12px">Nomor</TD>
					<TD style="HEIGHT: 12px"><asp:textbox onkeypress="return kutip_satu()" id="txt_AR_BKNO" runat="server" Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Atas Nama</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AR_BKNAMA" runat="server" Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Akte Jual Beli</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AR_BKAKTA" runat="server" Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Berlaku s/d</TD>
					<TD><asp:textbox onkeypress="return numbersonly()" id="txt_AR_BKDATE_DD" Width="25px" MaxLength="2"
							Runat="server" Columns="2"></asp:textbox><asp:dropdownlist id="ddl_AR_BKDATE_MM" Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="txt_AR_BKDATE_YY" Width="40px" MaxLength="4"
							Runat="server" Columns="4"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Notaris</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AR_BKNOTARIS" runat="server" Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR class="TDBGColor11">
					<TD><STRONG>Ikatan Jaminan</STRONG></TD>
					<TD><asp:dropdownlist id="ddl_AR_IJTYPE" runat="server" Width="100%">
							<asp:ListItem Value="0">Terikat</asp:ListItem>
							<asp:ListItem Value="1">Bebas Ikatan</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD>No. Akta</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AR_IJNOAKTA" runat="server" Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Sertifikat Hak Tanggugan</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AR_IJSERTIFIKAT" runat="server" Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Nilai Penikatan (Rp)</TD>
					<TD><asp:textbox onkeypress="return numbersonly()" id="txt_AR_IJNILAI" runat="server" Width="100%"
							MaxLength="10"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Notaris</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AR_IJNOTARIS" runat="server" Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Pada</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AR_IJPADA" runat="server" Width="100%"></asp:textbox></TD>
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
					<TD rowSpan="2"><asp:textbox onkeypress="return kutip_satu()" id="txt_AR_ABHASIL" runat="server" Width="100%"
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
					<TD><asp:textbox onkeypress="return numbersonly()" id="txt_AR_ABDATE_DD" Width="25px" MaxLength="2"
							Runat="server" Columns="2"></asp:textbox><asp:dropdownlist id="ddl_AR_ABDATE_MM" Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="txt_AR_ABDATE_YY" Width="40px" MaxLength="4"
							Runat="server" Columns="4"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Kantor BPN</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AR_ABKANTOR" runat="server" Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Pejabat BPN</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AR_ABPEJABAT" runat="server" Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR class="TDBGColor11">
					<TD><STRONG>Ijin Mendirikan Bangunan</STRONG></TD>
					<TD><asp:dropdownlist id="ddl_AR_IMBSTAT" runat="server" Width="100%">
							<asp:ListItem Value="0">Ada</asp:ListItem>
							<asp:ListItem Value="1">Tidak</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD>Nomor</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AR_IMBNO" runat="server" Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Dikeluarkan</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AR_IMBDKELUARK" runat="server" Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Tanggal</TD>
					<TD><asp:textbox onkeypress="return numbersonly()" id="txt_AR_IMBDATE_DD" Width="25px" MaxLength="2"
							Runat="server" Columns="2"></asp:textbox><asp:dropdownlist id="ddl_AR_IMBDATE_MM" Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="txt_AR_IMBDATE_YY" Width="40px" MaxLength="4"
							Runat="server" Columns="4"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR class="TDBGColor11">
					<TD><STRONG>Asuransi</STRONG></TD>
					<TD><asp:dropdownlist id="ddl_AR_INSRSTAT" runat="server" Width="100%">
							<asp:ListItem Value="0">Tercover</asp:ListItem>
							<asp:ListItem Value="1">Tidak</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD>Jenis Penutupan Asuransi</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AR_INSRTUTUP" runat="server" Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Nilai Pertanggungan (Rp)</TD>
					<TD><asp:textbox onkeypress="return numbersonly()" id="txt_AR_INSRAMOUNT" runat="server" Width="100%"
							MaxLength="10"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Polis Berlaku s/d</TD>
					<TD><asp:textbox onkeypress="return numbersonly()" id="txt_AR_INSRDATE_DD" Width="25px" MaxLength="2"
							Runat="server" Columns="2"></asp:textbox><asp:dropdownlist id="ddl_AR_INSRDATE_MM" Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="txt_AR_INSRDATE_YY" Width="40px" MaxLength="4"
							Runat="server" Columns="4"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Perusahaan Asuransi</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AR_INSRCOMP" runat="server" Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD colSpan="4"></TD>
				</TR>
				<TR>
					<TD class="tdHeader1" colSpan="4">III. PERHITUNGAN PASAR WAJAR YANG DAPAT DITERIMA 
						BANK
					</TD>
				</TR>
				<TR>
					<TD>Tujuan Penilaian</TD>
					<TD><asp:dropdownlist id="ddl_Tujuan" runat="server" Width="100%"></asp:dropdownlist></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD colSpan="4"><STRONG>Informasi/Data Harga Pasar</STRONG></TD>
				</TR>
				<TR class="TDBGColor11">
					<TD>Data I Minimum
					</TD>
					<TD><asp:textbox onkeypress="return numbersonly()" id="txt_AR_DATA1" runat="server" Width="100%"
							MaxLength="10" CssClass="mandatory"></asp:textbox></TD>
					<TD>Jenis Informasi Harga
					</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AR_INFO1" runat="server" Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Sumber Data
					</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AR_SUMBERD1" runat="server" Width="100%"
							Height="50px" TextMode="MultiLine"></asp:textbox></TD>
				</TR>
				<TR class="TDBGColor11">
					<TD>Data II Median</TD>
					<TD><asp:textbox onkeypress="return numbersonly()" id="txt_AR_DATA2" runat="server" Width="100%"
							MaxLength="10" CssClass="mandatory"></asp:textbox></TD>
					<TD>Jenis Informasi Harga</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AR_INFO2" runat="server" Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Sumber Data</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AR_SUMBERD2" runat="server" Width="100%"
							Height="50px" TextMode="MultiLine"></asp:textbox></TD>
				</TR>
				<TR class="TDBGColor11">
					<TD>Data III Maximum</TD>
					<TD><asp:textbox onkeypress="return numbersonly()" id="txt_AR_DATA3" runat="server" Width="100%"
							MaxLength="10" CssClass="mandatory"></asp:textbox></TD>
					<TD>Jenis Informasi Harga</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AR_INFO3" runat="server" Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Sumber Data</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AR_SUMBERD3" runat="server" Width="100%"
							Height="50px" TextMode="MultiLine"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD><STRONG>Harga Pasar Keseluruhan</STRONG></TD>
					<TD><asp:textbox id="txt_AR_HRGPASAR" runat="server" Width="100%" ReadOnly="True"></asp:textbox></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD><STRONG>Safety Margin</STRONG></TD>
					<TD><asp:textbox id="txt_AR_SFTYMARGIN" runat="server" Width="64px" ReadOnly="True"></asp:textbox></TD>
					<TD align="right"><STRONG>Score</STRONG></TD>
					<TD><asp:textbox id="txt_Score2" runat="server" Width="50px" ReadOnly="True"></asp:textbox>&nbsp;
						<asp:button id="btn_Calc" runat="server" CssClass="Button1" Text="Calculate" onclick="btn_Calc_Click"></asp:button></TD>
				</TR>
				<TR>
					<TD><STRONG>Nilai Pasar Wajar yang Dapat Diterima Bank</STRONG></TD>
					<TD><asp:textbox id="txt_AR_HRGWAJAR" runat="server" Width="100%" ReadOnly="True"></asp:textbox></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD colSpan="4"></TD>
				</TR>
				<TR>
					<TD class="tdHeader1" colSpan="4">IV. KESIMPULAN
					</TD>
				</TR>
				<TR>
					<TD>Marketability
					</TD>
					<TD><asp:dropdownlist id="ddl_AR_MARKET" runat="server" Width="216px"></asp:dropdownlist></TD>
					<TD>Permasalahan</TD>
					<TD><asp:dropdownlist id="ddl_AR_MASALAH" runat="server" Width="216px"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD>Pengikatan Sempurna</TD>
					<TD><asp:dropdownlist id="ddl_AR_IKAT" runat="server" Width="216px"></asp:dropdownlist></TD>
					<TD>Penguasaan</TD>
					<TD><asp:dropdownlist id="ddl_AR_KUASA" runat="server" Width="216px"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD>Lain-Lain</TD>
					<TD colSpan="3"><asp:textbox onkeypress="return kutip_satu()" id="txt_AR_LAIN" runat="server" Width="100%" Height="50px"
							TextMode="MultiLine"></asp:textbox></TD>
				</TR>
				<TR id="TR_TOMBOL">
					<TD class="TDBGColor2" colSpan="4"><asp:button id="btn_Reentry" runat="server" CssClass="Button1" Visible="False" Text="Re-Entry" onclick="btn_Reentry_Click"></asp:button>&nbsp;<asp:button id="btn_Save" runat="server" CssClass="Button1" Text="Save" onclick="btn_Save_Click"></asp:button>&nbsp;<asp:button id="btn_Delete" runat="server" CssClass="Button1" Text="Delete" onclick="btn_Delete_Click"></asp:button>&nbsp;<asp:button id="btn_UpdateStatus" runat="server" CssClass="Button1" Text="Update Status" onclick="btn_UpdateStatus_Click"></asp:button>&nbsp;<INPUT class="Button1" id="BTN_PRINT" onclick="cetak()" type="button" value="Print" name="BTN_PRINT"></TD>
				</TR>
			</table>
		</form>
	</body>
</HTML>
