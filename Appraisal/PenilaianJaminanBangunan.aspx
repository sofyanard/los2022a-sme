<%@ Page language="c#" Codebehind="PenilaianJaminanBangunan.aspx.cs" AutoEventWireup="True" Inherits="SME.Appraisal.PenilaianJaminanBangunan" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Penilaian Jaminan Bangunan</title>
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
					<td class="tdHeader1" colSpan="4">PENILAIAN JAMINAN BANGUNAN</td>
				</tr>
				<tr>
					<td width="25%">Nama Debitur</td>
					<td width="25%"><asp:textbox onkeypress="return kutip_satu()" id="txt_AB_NMDEBITUR" runat="server" Width="100%"
							ReadOnly="True"></asp:textbox></td>
					<td width="25%">Tanggal/Tahun Pemeriksaan</td>
					<td width="25%"><asp:textbox onkeypress="return numbersonly()" id="txt_AB_TGLPERIKSA_DD" Width="25px" MaxLength="2"
							Runat="server" Columns="2" CssClass="mandatory"></asp:textbox><asp:dropdownlist id="ddl_AB_TGLPERIKSA_MM" Runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="txt_AB_TGLPERIKSA_YY" Width="40px" MaxLength="4"
							Runat="server" Columns="4" CssClass="mandatory"></asp:textbox></td>
				</tr>
				<tr>
					<td></td>
					<td></td>
					<td>Penilai 1</td>
					<td><asp:textbox onkeypress="return kutip_satu()" id="txt_AB_PENILAI1" runat="server" Width="100%"
							CssClass="mandatory"></asp:textbox></td>
				</tr>
				<tr>
					<td><STRONG>Lokasi Angunan:</STRONG></td>
					<td></td>
					<td>Penilai 2</td>
					<td><asp:textbox onkeypress="return kutip_satu()" id="txt_AB_PENILAI2" runat="server" Width="100%"></asp:textbox></td>
				</tr>
				<tr>
					<td>Jl.</td>
					<td><asp:textbox onkeypress="return kutip_satu()" id="txt_AB_LOKJALAN" runat="server" Width="100%"
							CssClass="mandatory"></asp:textbox></td>
					<td></td>
					<td></td>
				</tr>
				<tr>
					<td>Desa/Kel.</td>
					<td><asp:textbox onkeypress="return kutip_satu()" id="txt_AB_LOKKEL" runat="server" Width="100%"
							CssClass="mandatory"></asp:textbox></td>
					<td>Kecamatan</td>
					<td><asp:textbox onkeypress="return kutip_satu()" id="txt_AB_LOKKEC" runat="server" Width="100%"
							CssClass="mandatory"></asp:textbox></td>
				</tr>
				<tr>
					<td>Kab/Kodya</td>
					<td><asp:textbox onkeypress="return kutip_satu()" id="txt_AB_LOKKOD" runat="server" Width="100%"
							CssClass="mandatory"></asp:textbox></td>
					<td></td>
					<td></td>
				</tr>
				<tr>
					<td colSpan="4"><asp:label id="lbl_CL_SEQ" runat="server" Visible="False"></asp:label><asp:label id="lbl_CU_REF" runat="server" Visible="False"></asp:label><asp:label id="lbl_AP_REGNO" runat="server" Visible="False"></asp:label><asp:label id="lbl_UpdateStatus" runat="server" Visible="False"></asp:label><asp:label id="lbl_TC" runat="server" Visible="False"></asp:label><asp:label id="lbl_MC" runat="server" Visible="False"></asp:label><asp:label id="lbl_GRP_CO" runat="server" Visible="False"></asp:label><asp:label id="lbl_GRP_COOFF" runat="server" Visible="False"></asp:label></td>
				</tr>
				<tr>
					<td class="tdHeader1" colSpan="4">I. PENELITIAN FISIK
					</td>
				</tr>
				<tr>
					<td>Luas Bangunan</td>
					<td><asp:textbox onkeypress="return numbersonly()" id="txt_AB_LUASBANGUN" runat="server" Width="60px"
							MaxLength="6" CssClass="mandatory"></asp:textbox>M<SUP>2</SUP></td>
					<td>Tahun Pembangunan</td>
					<td><asp:textbox onkeypress="return numbersonly()" id="txt_AB_THNBUAT" runat="server" Width="60px"
							MaxLength="4" CssClass="mandatory"></asp:textbox></td>
				</tr>
				<tr>
					<td></td>
					<td></td>
					<td>Tahun Renovasi Terakhir</td>
					<td><asp:textbox onkeypress="return numbersonly()" id="txt_AB_THNRENOVASI" runat="server" Width="60px"
							MaxLength="4"></asp:textbox></td>
				</tr>
				<tr>
					<td>Penggunaan Bangunan</td>
					<td><asp:dropdownlist id="ddl_AB_GUNA" runat="server" Width="100px"></asp:dropdownlist><asp:textbox onkeypress="return kutip_satu()" id="txt_AB_GUNAKET" runat="server" Width="60px"></asp:textbox></td>
					<td></td>
					<td></td>
				</tr>
				<tr>
					<td><STRONG>Prasarana:</STRONG></td>
					<td></td>
					<td><STRONG>Kualitas Bangunan:</STRONG></td>
					<td></td>
				</tr>
				<tr>
					<td>- Jaringan Listrik</td>
					<td><asp:dropdownlist id="ddl_AB_LISTRIK" runat="server" Width="60px">
							<asp:ListItem Value="0">Ya</asp:ListItem>
							<asp:ListItem Value="1">Tidak</asp:ListItem>
						</asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="txt_AB_KETLISTRIK" runat="server" Width="60px"
							MaxLength="4">0</asp:textbox>Watt
					</td>
					<td>- Pondasi dan Konstruksi
					</td>
					<td><asp:dropdownlist id="ddl_AB_KONTRUKSI" runat="server" Width="100%"></asp:dropdownlist></td>
				</tr>
				<tr>
					<td>- Jaringan Telepon/Fax</td>
					<td><asp:dropdownlist id="ddl_AB_TELPFAX" runat="server" Width="60px">
							<asp:ListItem Value="0">Ya</asp:ListItem>
							<asp:ListItem Value="1">Tidak</asp:ListItem>
						</asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="txt_AB_KETTELPFAX" runat="server" Width="60px"
							MaxLength="2">0</asp:textbox>Line
					</td>
					<td>- Dinding</td>
					<td><asp:dropdownlist id="ddl_AB_DINDING" runat="server" Width="100%"></asp:dropdownlist></td>
				</tr>
				<tr>
					<td>- Jaringan Air</td>
					<td><asp:dropdownlist id="ddl_AB_AIR" runat="server" Width="60px">
							<asp:ListItem Value="0">Ya</asp:ListItem>
							<asp:ListItem Value="1">Tidak</asp:ListItem>
						</asp:dropdownlist><asp:dropdownlist id="ddl_AB_KETAIR" runat="server" Width="60px"></asp:dropdownlist></td>
					<td>- Atap</td>
					<td><asp:dropdownlist id="ddl_AB_ATAP" runat="server" Width="100%"></asp:dropdownlist></td>
				</tr>
				<tr>
					<td>- Alat Pendingin/AC</td>
					<td><asp:dropdownlist id="ddl_AB_AC" runat="server" Width="60px">
							<asp:ListItem Value="0">Ya</asp:ListItem>
							<asp:ListItem Value="1">Tidak</asp:ListItem>
						</asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="txt_AB_KETAC" runat="server" Width="60px"
							MaxLength="2">0</asp:textbox>Unit
					</td>
					<td>- Lantai</td>
					<td><asp:dropdownlist id="ddl_AB_LANTAI" runat="server" Width="100%"></asp:dropdownlist></td>
				</tr>
				<tr>
					<td>- Lainnya</td>
					<td><asp:dropdownlist id="ddl_AB_PRASARANALAIN" runat="server" Width="60px">
							<asp:ListItem Value="0">Ya</asp:ListItem>
							<asp:ListItem Value="1">Tidak</asp:ListItem>
						</asp:dropdownlist><asp:textbox onkeypress="return kutip_satu()" id="txt_AB_KETPRASARANALAIN" runat="server" Width="100px"></asp:textbox></td>
					<td>- Pintu/Jendela</td>
					<td><asp:dropdownlist id="ddl_AB_PINTU" runat="server" Width="100%"></asp:dropdownlist></td>
				</tr>
				<tr>
					<td>Jenis Bangunan</td>
					<td><asp:dropdownlist id="ddl_AB_JENISBANGUNAN" runat="server" Width="100%"></asp:dropdownlist></td>
					<td>Kondisi
					</td>
					<td><nobr><asp:dropdownlist id="ddl_AB_KONDISI" runat="server" Width="100%" CssClass="mandatory"></asp:dropdownlist></nobr></td>
				</tr>
				<tr>
					<td></td>
					<td></td>
					<td>Perawatan/Pemeliharaan</td>
					<td><nobr><asp:dropdownlist id="ddl_AB_PEMELIHARAANBGN" runat="server" Width="100%" CssClass="mandatory"></asp:dropdownlist></nobr></td>
				</tr>
				<tr>
					<td></td>
					<td></td>
					<td>Lokasi Bangunan
					</td>
					<td><asp:dropdownlist id="ddl_AB_LOKASI" runat="server" Width="100%"></asp:dropdownlist></td>
				</tr>
				<tr>
					<td colSpan="4"></td>
				</tr>
				<tr>
					<td class="tdHeader1" colSpan="4">II. PENELITIAN YURIDIS</td>
				</tr>
				<tr class="TDBGColor11">
					<td><STRONG>Ijin Mendirikan Bangunan</STRONG>
					</td>
					<td><asp:dropdownlist id="ddl_AB_IJINSTAT" runat="server" Width="100%">
							<asp:ListItem Value="0">Ada</asp:ListItem>
							<asp:ListItem Value="1">Tidak</asp:ListItem>
						</asp:dropdownlist></td>
					<td>Nomor
					</td>
					<td><asp:textbox onkeypress="return kutip_satu()" id="txt_AB_IJINNO" runat="server" Width="100%"></asp:textbox></td>
				</tr>
				<tr>
					<td></td>
					<td></td>
					<td>Dikeluarkan
					</td>
					<td><asp:textbox onkeypress="return kutip_satu()" id="txt_AB_IJINDKELUARK" runat="server" Width="100%"></asp:textbox></td>
				</tr>
				<tr>
					<td></td>
					<td></td>
					<td>Tanggal
					</td>
					<td><asp:textbox onkeypress="return numbersonly()" id="txt_AB_IJINDATE_DD" Width="25px" MaxLength="2"
							Runat="server" Columns="2"></asp:textbox><asp:dropdownlist id="ddl_AB_IJINDATE_MM" Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="txt_AB_IJINDATE_YY" Width="40px" MaxLength="4"
							Runat="server" Columns="4"></asp:textbox></td>
				</tr>
				<tr>
					<td></td>
					<td></td>
					<td>Luas
					</td>
					<td><asp:textbox onkeypress="return numbersonly()" id="txt_AB_IJINLUAS" runat="server" Width="60px"
							MaxLength="6"></asp:textbox>M<SUP>2</SUP>
					</td>
				</tr>
				<tr>
					<td></td>
					<td></td>
					<td></td>
					<td></td>
				</tr>
				<tr class="TDBGColor11">
					<td><STRONG>Asuransi </STRONG>
					</td>
					<td><asp:dropdownlist id="ddl_AB_INSRSTATUS" runat="server" Width="100%">
							<asp:ListItem Value="0">Tercover</asp:ListItem>
							<asp:ListItem Value="1">Tidak</asp:ListItem>
						</asp:dropdownlist></td>
					<td>Jenis Penutupan Asuransi
					</td>
					<td><asp:textbox onkeypress="return kutip_satu()" id="txt_AB_INSRTUTUP" runat="server" Width="100%"></asp:textbox></td>
				</tr>
				<tr>
					<td></td>
					<td></td>
					<td>Nilai Pertanggungan (Rp)
					</td>
					<td><asp:textbox onkeypress="return numbersonly()" id="txt_AB_INSRAMOUNT" runat="server" Width="100%"
							MaxLength="10"></asp:textbox></td>
				</tr>
				<tr>
					<td></td>
					<td></td>
					<td>Pertanggungan Berlaku s/d</td>
					<td><asp:textbox onkeypress="return numbersonly()" id="txt_AB_INSREXPDATE_DD" Width="25px" MaxLength="2"
							Runat="server" Columns="2"></asp:textbox><asp:dropdownlist id="ddl_AB_INSREXPDATE_MM" Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="txt_AB_INSREXPDATE_YY" Width="40px" MaxLength="4"
							Runat="server" Columns="4"></asp:textbox></td>
				</tr>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Perusahaan Asuransi</TD>
					<TD><asp:textbox onkeypress="return kutip_satu()" id="txt_AB_INSRCOMP" runat="server" Width="100%"></asp:textbox></TD>
				</TR>
				<tr>
					<td colSpan="4"></td>
				</tr>
				<tr>
					<td class="tdHeader1" colSpan="4">III. PERHITUNGAN PASAR WAJAR YANG DAPAT DITERIMA 
						BANK
					</td>
				</tr>
				<tr>
					<td>Tujuan Penilaian</td>
					<td><asp:dropdownlist id="ddl_Tujuan" runat="server" Width="100%"></asp:dropdownlist></td>
					<td></td>
					<td></td>
				</tr>
				<tr>
					<td></td>
					<td></td>
					<td></td>
					<td></td>
				</tr>
				<tr>
					<td colSpan="4"><STRONG>Informasi/Data Harga Pasar</STRONG></td>
				</tr>
				<tr>
					<td>Informasi Biaya Pembangunan Baru/M<SUP>2</SUP> (Rp)</td>
					<td><asp:textbox onkeypress="return numbersonly()" id="txt_AB_HRGBARUM2" runat="server" Width="100%"
							MaxLength="10" CssClass="mandatory"></asp:textbox></td>
					<td>Sumber Data</td>
					<td></td>
				</tr>
				<tr>
					<td>Biaya Pembangunan Baru (Rp)</td>
					<td><asp:textbox id="txt_AB_HRGBANGUNBARU" runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td rowSpan="3"><asp:textbox onkeypress="return kutip_satu()" id="txt_AB_SUMBERDATA" runat="server" Width="100%"
							TextMode="MultiLine" Height="50px"></asp:textbox></td>
					<td></td>
				</tr>
				<tr>
					<td>Umur Ekonomis
					</td>
					<td><asp:textbox onkeypress="return numbersonly()" id="txt_AB_UMUREKON" runat="server" Width="60px"
							MaxLength="2" CssClass="mandatory"></asp:textbox>Tahun
					</td>
					<td></td>
				</tr>
				<tr>
					<td>Umur Efektif
					</td>
					<td><asp:textbox id="txt_AB_UMUREFEKTIF" runat="server" Width="60px" ReadOnly="True"></asp:textbox>Tahun
					</td>
					<td></td>
				</tr>
				<tr>
					<td>Penyusutan Pertahun</td>
					<td><asp:textbox id="txt_AB_SUSUTPERTHN" runat="server" Width="60px" ReadOnly="True"></asp:textbox></td>
					<td></td>
					<td></td>
				</tr>
				<tr>
					<td>Akumulasi Penyusutan (Rp)</td>
					<td><asp:textbox id="txt_AB_AKUMSUSUT" runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<TD><asp:textbox id="txt_AB_AKUMSUSUTP" runat="server" Width="60px" ReadOnly="True"></asp:textbox></TD>
					<TD><asp:textbox id="txt_Score1" runat="server" Width="25px" Enabled="False"></asp:textbox></TD>
				</tr>
				<TR>
					<TD><STRONG>Nilai Pasar Bangunan (Rp)</STRONG></TD>
					<TD><asp:textbox id="txt_AB_HRGBANGUNAN" runat="server" Width="100%" ReadOnly="True"></asp:textbox></TD>
					<TD></TD>
					<TD><asp:textbox id="txt_Score2" runat="server" Width="25px" Enabled="False"></asp:textbox></TD>
				</TR>
				<TR>
					<TD><STRONG>Safety Margin</STRONG></TD>
					<TD><asp:textbox id="txt_AB_SFTYMARGIN" runat="server" Width="60px" ReadOnly="True"></asp:textbox></TD>
					<TD align="right"><STRONG>&nbsp;Total Score</STRONG></TD>
					<TD><asp:textbox id="txt_TOTALSCORE" runat="server" Width="60px" ReadOnly="True"></asp:textbox>&nbsp;
						<asp:button id="btn_Calc" runat="server" CssClass="Button1" Text="Calculate" onclick="btn_Calc_Click"></asp:button></TD>
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
					<TD class="tdHeader1" colSpan="4">IV. KESIMPULAN</TD>
				</TR>
				<TR>
					<TD align="center" colSpan="4"><asp:textbox onkeypress="return kutip_satu()" id="txt_AB_KESIMPULAN" runat="server" Width="100%"
							TextMode="MultiLine" Height="50px"></asp:textbox></TD>
				</TR>
				<TR id="TR_TOMBOL">
					<TD class="TDBGColor2" colSpan="4"><asp:button id="btn_Reentry" runat="server" CssClass="Button1" Visible="False" Text="Re-Entry" onclick="btn_Reentry_Click"></asp:button>&nbsp;
						<asp:button id="btn_Save" runat="server" CssClass="Button1" Text="Save" onclick="btn_Save_Click"></asp:button>&nbsp;
						<asp:button id="btn_Delete" runat="server" CssClass="Button1" Text="Delete" onclick="btn_Delete_Click"></asp:button>&nbsp;
						<asp:button id="btn_UpdateStatus" runat="server" CssClass="Button1" Text="Update Status" onclick="btn_UpdateStatus_Click"></asp:button>&nbsp;<INPUT class="Button1" id="BTN_PRINT" onclick="cetak()" type="button" value="Print" name="BTN_PRINT">
					</TD>
				</TR>
				<TR>
					<TD colSpan="4"></TD>
				</TR>
			</table>
		</form>
	</body>
</HTML>
