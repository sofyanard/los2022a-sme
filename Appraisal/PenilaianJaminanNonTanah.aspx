<%@ Page language="c#" Codebehind="PenilaianJaminanNonTanah.aspx.cs" AutoEventWireup="True" Inherits="SME.Appraisal.PenilaianJaminanNonTanah" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Penilaian Jaminan Kendaraan</title>
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
					<td class="tdHeader1" colSpan="4">
						<P>PENILAIAN JAMINAN KENDARAAN</P>
					</td>
				</tr>
				<tr>
					<td width="25%">Nama Debitur</td>
					<td width="25%"><asp:textbox onkeypress="return kutip_satu()" id="txt_AK_NMDEBITUR" runat="server" ReadOnly="True"
							Width="100%"></asp:textbox></td>
					<td width="25%">Tanggal/Tahun Pemeriksaan</td>
					<td width="25%"><asp:textbox onkeypress="return numbersonly()" id="txt_AK_APPRDATE_DD" Width="25px" CssClass="mandatory"
							MaxLength="2" Runat="server" Columns="2"></asp:textbox><asp:dropdownlist id="ddl_AK_APPRDATE_MM" CssClass="mandatory" Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="txt_AK_APPRDATE_YY" Width="40px" CssClass="mandatory"
							MaxLength="4" Runat="server" Columns="4"></asp:textbox></td>
				</tr>
				<tr>
					<td></td>
					<td></td>
					<td>Penilai 1</td>
					<td><asp:textbox onkeypress="return kutip_satu()" id="txt_AK_APPRBY1" runat="server" Width="100%"
							CssClass="mandatory"></asp:textbox></td>
				</tr>
				<tr>
					<td><STRONG>Lokasi Angunan:</STRONG></td>
					<td></td>
					<td>Penilai 2</td>
					<td><asp:textbox onkeypress="return kutip_satu()" id="txt_AK_APPRBY2" runat="server" Width="100%"></asp:textbox></td>
				</tr>
				<tr>
					<td>Jl.</td>
					<td><asp:textbox onkeypress="return kutip_satu()" id="txt_AK_LOKJLN" runat="server" Width="100%"
							CssClass="mandatory"></asp:textbox></td>
					<td></td>
					<td></td>
				</tr>
				<tr>
					<td>Desa/Kel.</td>
					<td><asp:textbox onkeypress="return kutip_satu()" id="txt_AK_LOKDESA" runat="server" Width="100%"
							CssClass="mandatory"></asp:textbox></td>
					<td>Kecamatan</td>
					<td><asp:textbox onkeypress="return kutip_satu()" id="txt_AK_LOKKEC" runat="server" Width="100%"
							CssClass="mandatory"></asp:textbox></td>
				</tr>
				<tr>
					<td>Kab/Kodya</td>
					<td><asp:textbox onkeypress="return kutip_satu()" id="txt_AK_LOKKAB" runat="server" Width="100%"
							CssClass="mandatory"></asp:textbox></td>
					<td></td>
					<td></td>
				</tr>
				<tr>
					<td colSpan="4"><asp:label id="lbl_CL_SEQ" runat="server" Visible="False"></asp:label><asp:label id="lbl_CU_REF" runat="server" Visible="False"></asp:label><asp:label id="lbl_AP_REGNO" runat="server" Visible="False"></asp:label><asp:label id="lbl_UpdateStatus" runat="server" Visible="False"></asp:label><asp:label id="lbl_TC" runat="server" Visible="False"></asp:label><asp:label id="lbl_MC" runat="server" Visible="False"></asp:label><asp:label id="lbl_GRP_COOFF" runat="server" Visible="False"></asp:label><asp:label id="lbl_GRP_CO" runat="server" Visible="False"></asp:label></td>
				</tr>
				<tr>
					<td class="tdHeader1" colSpan="4">I. PENELITIAN FISIK</td>
				</tr>
				<tr>
					<td style="HEIGHT: 16px">Jenis Obyek</td>
					<td style="HEIGHT: 16px"><asp:dropdownlist id="ddl_AK_JNSAGUNAN" runat="server" Width="100%"></asp:dropdownlist></td>
					<td style="HEIGHT: 16px">Tahun Pembelian</td>
					<td style="HEIGHT: 16px"><asp:textbox onkeypress="return numbersonly()" id="txt_AK_THNBELI" runat="server" Width="60px"
							CssClass="mandatory" MaxLength="4"></asp:textbox></td>
				</tr>
				<tr>
					<td>Pembelian</td>
					<td><asp:dropdownlist id="ddl_AK_ISNEW" runat="server" Width="100%">
							<asp:ListItem Value="0">Baru</asp:ListItem>
							<asp:ListItem Value="1">Bekas</asp:ListItem>
						</asp:dropdownlist></td>
					<td>Kondisi</td>
					<td><asp:dropdownlist id="ddl_AK_KONDISI" runat="server" Width="100%" CssClass="mandatory" Height="56px"></asp:dropdownlist></td>
				</tr>
				<tr>
					<td>Umur</td>
					<td><asp:dropdownlist id="ddl_AK_UMUR" runat="server" Width="100%"></asp:dropdownlist></td>
					<td>Perawatan/Pemeliharaan</td>
					<td><asp:dropdownlist id="ddl_AK_PERWATAN" runat="server" Width="100%" CssClass="mandatory" Height="56px"></asp:dropdownlist></td>
				</tr>
				<tr>
					<td>Merk</td>
					<td><asp:textbox onkeypress="return kutip_satu()" id="txt_AK_MERK" runat="server" Width="100%"></asp:textbox></td>
					<td><STRONG>Resiko: </STRONG>
					</td>
					<td></td>
				</tr>
				<TR>
					<TD>Tipe</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AK_TIPE" runat="server" Width="100%"></asp:textbox></TD>
					<TD>– Kebanjiran</TD>
					<TD><asp:dropdownlist id="ddl_AK_BANJIR" runat="server" Width="100%"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD>Jenis</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AK_JENIS" runat="server" Width="100%"></asp:textbox></TD>
					<TD>– Pencurian</TD>
					<TD><asp:dropdownlist id="ddl_AK_PENCURIAN" runat="server" Width="100%"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>– Kebakaran</TD>
					<TD><asp:dropdownlist id="ddl_AK_KEBAKARAN" runat="server" Width="100%"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD colSpan="4"></TD>
				</TR>
				<TR>
					<TD class="tdHeader1" colSpan="4">II. PENELITIAN YURIDIS
					</TD>
				</TR>
				<TR class="TDBGColor11">
					<TD><STRONG>Bukti Kepemilikan</STRONG></TD>
					<TD><asp:dropdownlist id="ddl_AK_BPKB" runat="server" Width="100%"></asp:dropdownlist></TD>
					<TD>Nomor</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AK_BKNO" runat="server" Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Atas Nama</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AK_FAKTURBRG" runat="server" Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Tanggal</TD>
					<TD><asp:textbox onkeypress="return numbersonly()" id="txt_AK_BKDATE_DD" Width="25px" MaxLength="2"
							Runat="server" Columns="2"></asp:textbox><asp:dropdownlist id="ddl_AK_BKDATE_MM" Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="txt_AK_BKDATE_YY" Width="40px" MaxLength="4"
							Runat="server" Columns="4"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR class="TDBGColor11">
					<TD><STRONG>Ikatan Jaminan</STRONG></TD>
					<TD><asp:dropdownlist id="ddl_AK_IKATSTAT" runat="server" Width="100%">
							<asp:ListItem Value="0">Terikat</asp:ListItem>
							<asp:ListItem Value="1">Bebas Ikatan</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD>No. Akta</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AK_IKATNO" runat="server" Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Sertifikat FEO</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AK_IKATFEO" runat="server" Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Nilai Pengikatan (Rp)</TD>
					<TD><asp:textbox onkeypress="return numbersonly()" id="txt_AK_IKATNILAI" runat="server" Width="100%"
							MaxLength="10"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Notaris
					</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AK_IKATNOTARIS" runat="server" Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Tanggal
					</TD>
					<TD><asp:textbox onkeypress="return numbersonly()" id="txt_AK_IKATDATE_DD" Width="25px" MaxLength="2"
							Runat="server" Columns="2"></asp:textbox><asp:dropdownlist id="ddl_AK_IKATDATE_MM" Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="txt_AK_IKATDATE_YY" Width="40px" MaxLength="4"
							Runat="server" Columns="4"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Pada</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AK_IKATPADA" runat="server" Width="100%"></asp:textbox></TD>
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
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AK_ABHASIL" runat="server" Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Tanggal Pengecekan</TD>
					<TD><asp:textbox onkeypress="return numbersonly()" id="txt_AK_ABDATE_DD" Width="25px" MaxLength="2"
							Runat="server" Columns="2"></asp:textbox><asp:dropdownlist id="ddl_AK_ABDATE_MM" Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="txt_AK_ABDATE_YY" Width="40px" MaxLength="4"
							Runat="server" Columns="4"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Instansi/Kantor</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AK_ABKANTOR" runat="server" Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Pejabat
					</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AK_ABPEJABAT" runat="server" Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR class="TDBGColor11">
					<TD><STRONG>Asuransi</STRONG></TD>
					<TD><asp:dropdownlist id="ddl_AK_INSRSTATUS" runat="server" Width="100%">
							<asp:ListItem Value="0">Tercover</asp:ListItem>
							<asp:ListItem Value="1">Tidak</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD>Jenis Penutupan Asuransi</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AK_INSRCOVER" runat="server" Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Nilai Pertanggungan (Rp)</TD>
					<TD><asp:textbox onkeypress="return numbersonly()" id="txt_AK_INSRAMOUNT" runat="server" Width="100%"
							MaxLength="10"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Berlaku s/d</TD>
					<TD><asp:textbox onkeypress="return numbersonly()" id="txt_AK_INSRDATE_DD" Width="25px" MaxLength="2"
							Runat="server" Columns="2"></asp:textbox><asp:dropdownlist id="ddl_AK_INSRDATE_MM" Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="txt_AK_INSRDATE_YY" Width="40px" MaxLength="4"
							Runat="server" Columns="4"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Perusahaan Asuransi</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AK_INSRCOMP" runat="server" Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD colSpan="4"></TD>
				</TR>
				<TR>
					<TD class="tdHeader1" colSpan="4">III. PERHITUNGAN NILAI PASAR YANG DAPAT DITERIMA 
						BANK</TD>
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
								<TD>Data I Terendah</TD>
								<TD><asp:textbox onkeypress="return numbersonly()" id="txt_AK_DATA1" runat="server" Width="100%"
										CssClass="mandatory" MaxLength="10"></asp:textbox></TD>
								<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AK_NAMA1" runat="server" Width="100%"></asp:textbox></TD>
								<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AK_ALAMAT1" runat="server" Width="100%"></asp:textbox></TD>
								<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AK_TGL1" Width="100%" MaxLength="10" Runat="server"
										Columns="4"></asp:textbox></TD>
							</TR>
							<TR>
								<TD></TD>
								<TD></TD>
								<TD></TD>
								<TD></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD>Data II Median</TD>
								<TD><asp:textbox onkeypress="return numbersonly()" id="txt_AK_DATA2" runat="server" Width="100%"
										CssClass="mandatory" MaxLength="10"></asp:textbox></TD>
								<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AK_NAMA2" runat="server" Width="100%"></asp:textbox></TD>
								<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AK_ALAMAT2" runat="server" Width="100%"></asp:textbox></TD>
								<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AK_TGL2" Width="100%" MaxLength="10" Runat="server"
										Columns="4"></asp:textbox></TD>
							</TR>
							<TR>
								<TD></TD>
								<TD></TD>
								<TD></TD>
								<TD></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD>Data III Tertinggi</TD>
								<TD><asp:textbox onkeypress="return numbersonly()" id="txt_AK_DATA3" runat="server" Width="100%"
										CssClass="mandatory" MaxLength="10"></asp:textbox></TD>
								<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AK_NAMA3" runat="server" Width="100%"></asp:textbox></TD>
								<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AK_ALAMAT3" runat="server" Width="100%"></asp:textbox></TD>
								<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AK_TGL3" Width="100%" MaxLength="10" Runat="server"
										Columns="4"></asp:textbox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD><STRONG>Harga Pasar keseluruhan</STRONG></TD>
					<TD><asp:textbox id="txt_AK_HRGPASAR" runat="server" ReadOnly="True" Width="100%"></asp:textbox></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 28px"><STRONG>Safety Margin</STRONG></TD>
					<TD style="HEIGHT: 28px"><asp:textbox id="txt_AK_SFTYMARGIN" runat="server" ReadOnly="True" Width="60px"></asp:textbox></TD>
					<TD style="HEIGHT: 28px" align="right"><STRONG>Score </STRONG>
					</TD>
					<TD style="HEIGHT: 28px"><asp:textbox id="txt_Score" runat="server" ReadOnly="True" Width="60px"></asp:textbox>&nbsp;
						<asp:button id="btn_Calc" runat="server" CssClass="Button1" Text="Calculate" onclick="btn_Calc_Click"></asp:button></TD>
				</TR>
				<TR>
					<TD><STRONG>Nilai Pasar Wajar yang Dapat Diterima Bank</STRONG></TD>
					<TD><asp:textbox id="txt_AK_HRGWAJAR" runat="server" ReadOnly="True" Width="100%"></asp:textbox></TD>
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
					<TD><asp:dropdownlist id="ddl_AK_MARKET" runat="server" Width="100%"></asp:dropdownlist></TD>
					<TD>Permasalahan</TD>
					<TD><asp:dropdownlist id="ddl_AK_MASALAH" runat="server" Width="100%"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD>Pengikatan Sempurna</TD>
					<TD><asp:dropdownlist id="ddl_AK_IKATAN" runat="server" Width="100%"></asp:dropdownlist></TD>
					<TD>Penguasaan</TD>
					<TD><asp:dropdownlist id="ddl_AK_KUASA" runat="server" Width="100%"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD>Lain-Lain</TD>
					<TD colSpan="3"><asp:textbox onkeypress="return kutip_satu()" id="txt_AK_LAIN" runat="server" Width="100%" Height="50px"
							TextMode="MultiLine"></asp:textbox></TD>
				</TR>
				<TR>
					<TD colSpan="4"></TD>
				</TR>
				<TR>
					<TD class="tdHeader1" colSpan="4">V. PENDAPAT/REKOMENDASI</TD>
				</TR>
				<TR>
					<TD colSpan="4"><asp:textbox onkeypress="return kutip_satu()" id="txt_AK_PENDAPAT" runat="server" Width="100%"
							Height="50px" TextMode="MultiLine"></asp:textbox></TD>
				</TR>
				<TR id="TR_TOMBOL">
					<TD class="TDBGColor2" colSpan="4"><asp:button id="btn_Reentry" runat="server" CssClass="Button1" Visible="False" Text="Re-Entry"></asp:button>&nbsp;
						<asp:button id="btn_Save" runat="server" CssClass="Button1" Text="Save" onclick="btn_Save_Click"></asp:button>&nbsp;
						<asp:button id="btn_Delete" runat="server" CssClass="Button1" Text="Delete" onclick="btn_Delete_Click"></asp:button>&nbsp;
						<asp:button id="btn_UpdateStatus" runat="server" CssClass="Button1" Text="Update Status" onclick="btn_UpdateStatus_Click"></asp:button>&nbsp;<INPUT class="Button1" id="BTN_PRINT" onclick="cetak()" type="button" value="Print" name="BTN_PRINT"></TD>
				</TR>
			</table>
		</form>
	</body>
</HTML>
