<%@ Page language="c#" Codebehind="Kendaraan_Entry.aspx.cs" AutoEventWireup="True" Inherits="SME.Appraisal.Kendaraan_Entry" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Kendaraan_Entry</title>
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
				<TABLE cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder">
							<TABLE id="Table2">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Appraisal : Kendaraan</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right">
							<asp:ImageButton id="BTN_BACK" runat="server" ImageUrl="../Image/back.jpg" onclick="BTN_BACK_Click"></asp:ImageButton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
				</TABLE>
				<TABLE cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdHeader1" vAlign="top" align="center"><B>Penilaian Jaminan (Non Tanah &amp; 
								Bangunan)</B></TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top">
							<TABLE cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="200">Nama Pemeriksa</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:TextBox ID="TXT_AK_APPRBY" Runat="server" Visible="False"></asp:TextBox>
										<asp:TextBox ID="TXT_AK_APPRNM" Runat="server" Columns="35" ReadOnly></asp:TextBox>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Cabang/CBC/Group</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:TextBox ID="TXT_AK_APPRBR" Runat="server" Columns="35" ReadOnly></asp:TextBox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tanggal</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:TextBox ID="TXT_AK_APPRDATEDAY" Runat="server" Columns="2" MaxLength="2" CssClass="mandatory"
											onKeypress="return numbersonly()"></asp:TextBox>
										<asp:DropDownList Runat="server" ID="DDL_AK_APPRDATEMONTH"></asp:DropDownList>
										<asp:TextBox ID="TXT_AK_APPRDATEYEAR" Runat="server" Columns="4" MaxLength="4" CssClass="mandatory"
											onKeypress="return numbersonly()"></asp:TextBox>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top">
							<TABLE cellSpacing="0" cellPadding="2" width="100%">
								<tr>
									<td width="50%" valign="top">
										<TABLE cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD class="TDBGColor1" width="200">Nama Nasabah</TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue"><asp:TextBox ID="TXT_CU_NAME" ReadOnly Runat="server" Columns="35"></asp:TextBox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Telepon</TD>
												<TD></TD>
												<TD class="TDBGColorValue">
													<asp:TextBox ID="TXT_AK_PHNAREA" Runat="server" MaxLength="5" Columns="5" onKeypress="return numbersonly()"></asp:TextBox>
													<asp:TextBox ID="TXT_AK_PHNNUM" Runat="server" MaxLength="15" Columns="15" onKeypress="return numbersonly()"></asp:TextBox>
													<asp:TextBox ID="TXT_AK_PHNEXT" Runat="server" MaxLength="5" Columns="5" onKeypress="return numbersonly()"></asp:TextBox>
												</TD>
											</TR>
										</TABLE>
									</td>
									<td valign="top">
										<TABLE cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD class="TDBGColor1" width="200">Alamat</TD>
												<TD width="15"></TD>
												<TD class="TDBGColorValue"></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Jl.</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:TextBox ID="TXT_AK_ADDRJLN" Runat="server" MaxLength="100" Columns="40" onKeypress="return kutip_satu()"></asp:TextBox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Desa</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:TextBox ID="TXT_AK_ADDRDESA" Runat="server" MaxLength="50" Columns="40" onKeypress="return kutip_satu()"></asp:TextBox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Kecamatan</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:TextBox ID="TXT_AK_ADDRKEC" Runat="server" MaxLength="50" Columns="40" onKeypress="return kutip_satu()"></asp:TextBox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Kab/Kodya</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:TextBox ID="TXT_AK_ADDRKAB" Runat="server" MaxLength="50" Columns="40" onKeypress="return kutip_satu()"></asp:TextBox></TD>
											</TR>
										</TABLE>
									</td>
								</tr>
							</TABLE>
						</TD>
					</TR>
					<tr>
						<td class="td" valign="top" width="100%">
							<table cellpadding="0" cellspacing="0" width="100%">
								<tr>
									<TD class="TDBGColor1" width="200">Informasi Jaminan</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue"><asp:DropDownList ID="DDL_AK_COLCLASSIFY" Runat="server"></asp:DropDownList></TD>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<td class="td" valign="top">
							<table cellpadding="0" cellspacing="0" width="100%">
								<tr>
									<TD class="TDBGColor1" width="200">Jenis Barang</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue" width="250"><asp:DropDownList ID="DDL_AK_JNSAGUNAN" Runat="server"></asp:DropDownList></TD>
									<td rowspan="2" width="10">&nbsp;</td>
									<td rowspan="2" valign="top">
										<asp:TextBox Height="50" TextMode="MultiLine" Rows="4" Columns="50" ID="TXT_AK_KETAGUNAN" Runat="server"
											onKeypress="return kutip_satu()"></asp:TextBox>
									</td>
								</tr>
								<tr>
									<TD class="TDBGColor1">Pembelian Baru</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:DropDownList ID="DDL_AK_ISNEW" Runat="server"></asp:DropDownList></TD>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<td class="td" valign="top">
							<table cellpadding="0" cellspacing="0" width="100%">
								<tr>
									<td valign="top" width="50%">
										<table cellpadding="0" cellspacing="0" width="100%">
											<tr>
												<TD class="TDBGColor1" width="200">Lokasi Jaminan</TD>
												<TD width="15"></TD>
												<TD class="TDBGColorValue"></TD>
											</tr>
											<tr>
												<TD class="TDBGColor1">Jl.</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:TextBox Runat="server" ID="TXT_AK_LOKJLN" MaxLength="100" Columns="40" onKeypress="return kutip_satu()"></asp:TextBox></TD>
											</tr>
											<tr>
												<TD class="TDBGColor1">Desa</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:TextBox Runat="server" ID="TXT_AK_LOKDESA" MaxLength="50" Columns="40" onKeypress="return kutip_satu()"></asp:TextBox></TD>
											</tr>
											<tr>
												<TD class="TDBGColor1">Kecamatan</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:TextBox Runat="server" ID="TXT_AK_LOKKEC" MaxLength="50" Columns="40" onKeypress="return kutip_satu()"></asp:TextBox></TD>
											</tr>
											<tr>
												<TD class="TDBGColor1">Kab/Kodya</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:TextBox Runat="server" ID="TXT_AK_LOKKAB" MaxLength="50" Columns="40" onKeypress="return kutip_satu()"></asp:TextBox></TD>
											</tr>
										</table>
									</td>
									<td valign="top">
										<table cellpadding="0" cellspacing="0">
											<tr>
												<TD class="TDBGColor1">Telpon</TD>
												<TD></TD>
												<TD class="TDBGColorValue">
													<asp:TextBox Runat="server" ID="TXT_AK_LOKPHNAREA" MaxLength="5" Columns="5" onKeypress="return numbersonly()"></asp:TextBox>
													<asp:TextBox Runat="server" ID="TXT_AK_LOKPHNNUM" MaxLength="15" Columns="15" onKeypress="return numbersonly()"></asp:TextBox>
													<asp:TextBox Runat="server" ID="TXT_AK_LOKPHNEXT" MaxLength="5" Columns="5" onKeypress="return numbersonly()"></asp:TextBox>
												</TD>
											</tr>
											<tr>
												<TD class="TDBGColor1" width="200" valign="top">Bukti Kepemilikan</TD>
												<TD width="15"></TD>
												<TD class="TDBGColorValue"><asp:CheckBox ID="CHB_AK_BPKB" Runat="server" Text="BPKB"></asp:CheckBox>
													<asp:CheckBox ID="CHB_AK_FAKTURBRG" Runat="server" Text="Faktur Barang"></asp:CheckBox>
													<asp:CheckBox ID="CHB_AK_BUKTILAIN" Runat="server" Text="Lainnya"></asp:CheckBox><br>
													<asp:TextBox ID="TXT_AK_KETBUKTILAIN" Rows="4" Height="50" Columns="40" MaxLength="100" Runat="server"
														TextMode="MultiLine"></asp:TextBox>
												</TD>
											</tr>
										</table>
									</td>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<td class="td" valign="top" width="100%">
							<table cellpadding="0" cellspacing="0" width="100%">
								<tr>
									<TD class="TDBGColor1" width="200">Kondisi</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue"><asp:DropDownList ID="DDL_AK_KONDISI" Runat="server"></asp:DropDownList></TD>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<td class="td" valign="top" width="100%">
							<table cellpadding="0" cellspacing="0" width="100%">
								<tr>
									<TD class="TDBGColor1" width="200">Umur</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue"><asp:DropDownList ID="DDL_AK_UMUR" Runat="server"></asp:DropDownList></TD>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<td class="td" valign="top" width="100%">
							<table cellpadding="0" cellspacing="0" width="100%">
								<tr>
									<TD class="TDBGColor1" valign="top" width="200">Pengecekan Keabsahan Dokumen</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue">
										<asp:CheckBox ID="CHB_AK_KEPOLISIAN" Runat="server" Text="Kepolisian"></asp:CheckBox>
										<asp:CheckBox ID="CHB_AK_SUPPLIER" Runat="server" Text="Supplier"></asp:CheckBox>
										<asp:CheckBox ID="CHB_AK_CEKLAIN" Runat="server" Text="Lainnya"></asp:CheckBox><br>
										<asp:TextBox ID="TXT_AK_KETCEKLAIN" Rows="4" Columns="40" Height="50" TextMode="MultiLine" onKeypress="return kutip_satu()"
											Runat="server"></asp:TextBox>
									</TD>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<td valign="top" width="100%" class="td">
							<table cellpadding="0" cellspacing="0" width="100%">
								<tr>
									<td class="TDBGColor1" width="200">Status Asuransi</td>
									<td width="15"></td>
									<TD class="TDBGColorValue">
										<asp:DropDownList ID="DDL_AK_INSRSTATUS" Runat="server"></asp:DropDownList>
									</TD>
									<td rowspan="3" width="15"></td>
									<td rowspan="3"><asp:TextBox Height="80" TextMode="MultiLine" Rows="6" Columns="40" ID="TXT_AK_KETINSR" Runat="server"
											onKeypress="return kutip_satu()"></asp:TextBox></td>
								</tr>
								<tr>
									<td class="TDBGColor1">Nilai Pertanggungan</td>
									<td></td>
									<TD class="TDBGColorValue"><asp:TextBox ID="TXT_AK_INSRAMOUNT" MaxLength="21" Columns="25" onKeypress="return numbersonly()"
											Runat="server" CssClass="angka"></asp:TextBox></TD>
								</tr>
								<tr>
									<td class="TDBGColor1">Perusahaan Asuransi</td>
									<td></td>
									<TD class="TDBGColorValue"><asp:TextBox ID="TXT_AK_INSRCOMP" MaxLength="50" Columns="40" onKeypress="return kutip_satu()"
											Runat="server"></asp:TextBox></TD>
								</tr>
								<tr>
									<td class="TDBGColor1">Masa Laku</td>
									<td></td>
									<TD class="TDBGColorValue">
										<asp:TextBox ID="TXT_AK_EXPDATEDAY" MaxLength="2" Columns="2" onKeypress="return numbersonly()"
											Runat="server"></asp:TextBox>
										<asp:DropDownList ID="DDL_AK_EXPDATEMONTH" Runat="server"></asp:DropDownList>
										<asp:TextBox ID="TXT_AK_EXPDATEYEAR" MaxLength="4" Columns="4" onKeypress="return numbersonly()"
											Runat="server"></asp:TextBox>
									</TD>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<td class="td" valign="top" width="100%">
							<table cellpadding="0" cellspacing="0" width="100%">
								<tr>
									<td class="TDBGColor1" width="200">Resiko Kebanjiran</td>
									<td width="15"></td>
									<TD class="TDBGColorValue"><asp:DropDownList ID="DDL_AK_BANJIR" Runat="server"></asp:DropDownList></TD>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<td class="td" valign="top" width="100%">
							<table cellpadding="0" cellspacing="0" width="100%">
								<tr>
									<td class="TDBGColor1" width="200">Resiko Pencurian</td>
									<td width="15"></td>
									<TD class="TDBGColorValue"><asp:DropDownList ID="DDL_AK_PENCURIAN" Runat="server"></asp:DropDownList></TD>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<td class="td" valign="top" width="100%">
							<table cellpadding="0" cellspacing="0" width="100%">
								<tr>
									<td class="TDBGColor1" width="200">Resiko Kebakaran</td>
									<td width="15"></td>
									<TD class="TDBGColorValue"><asp:DropDownList ID="DDL_AK_KEBAKARAN" Runat="server"></asp:DropDownList></TD>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<td class="td" valign="top" width="100%">
							<table cellpadding="0" cellspacing="0" width="100%">
								<tr>
									<td class="TDBGColor1" width="200">Gambar Lokasi dan Foto Terlampir</td>
									<td width="15"></td>
									<TD class="TDBGColorValue"><asp:DropDownList ID="DDL_AK_FOTO" Runat="server"></asp:DropDownList></TD>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<TD class="td" vAlign="top" width="100%">
							<table cellpadding="0" cellspacing="0" width="100%">
								<tr>
									<td class="TDBGColor1" width="400">Perhitungan Harga Taksasi:</td>
									<td width="15"></td>
									<TD></TD>
								</tr>
								<tr>
									<td class="TDBGColor1">- Harga Pasar Showroom/Dealer/Distributor</td>
									<td></td>
									<TD class="TDBGColorValue"><asp:TextBox ID="TXT_AK_HRGPASAR" MaxLength="21" Columns="25" CssClass="angka" onKeypress="return numbersonly()"
											Runat="server"></asp:TextBox></TD>
								</tr>
								<tr>
									<td class="TDBGColor1">- Harga Bea Balik Nama dari Instansi Terkait (Khusus 
										Kendaraan)</td>
									<td></td>
									<TD class="TDBGColorValue"><asp:TextBox ID="TXT_AK_HRGBALIKNM" MaxLength="21" Columns="25" CssClass="angka" onKeypress="return numbersonly()"
											Runat="server"></asp:TextBox></TD>
								</tr>
								<tr>
									<td class="TDBGColor1">- Harga dariSumber Secundair (Perantara, Media Massa dll)</td>
									<td></td>
									<TD class="TDBGColorValue"><asp:TextBox ID="TXT_AK_HRGSMBRLN" MaxLength="21" Columns="25" CssClass="angka" onKeypress="return numbersonly()"
											Runat="server"></asp:TextBox></TD>
								</tr>
								<tr>
									<td class="TDBGColor1">Harga Taksasi Sebelum Safety Margin</td>
									<td></td>
									<TD class="TDBGColorValue"><asp:TextBox ID="TXT_AK_SBLMSMARGIN" MaxLength="21" Columns="25" CssClass="angka" onKeypress="return numbersonly()"
											Runat="server"></asp:TextBox></TD>
								</tr>
								<tr>
									<td class="TDBGColor1">Safety Margin</td>
									<td></td>
									<TD class="TDBGColorValue"><asp:TextBox ID="TXT_AK_SFTYMARGIN" MaxLength="6" Columns="6" CssClass="angka" onKeypress="return numbersonly()"
											Runat="server"></asp:TextBox></TD>
								</tr>
								<tr>
									<td class="TDBGColor1">Harga Taksasi Setelah Safety Margin</td>
									<td></td>
									<TD class="TDBGColorValue"><asp:TextBox ID="TXT_AK_STLHSMARGIN" MaxLength="21" Columns="25" CssClass="angka" onKeypress="return numbersonly()"
											Runat="server"></asp:TextBox></TD>
								</tr>
							</table>
						</TD>
					</tr>
					<tr>
						<td class="td" valign="top" width="100%">
							<table cellpadding="0" cellspacing="0" width="100%">
								<tr>
									<td class="TDBGColor1" valign="top" width="200">Keterangan Lain Tentang Jaminan</td>
									<td width="15"></td>
									<TD class="TDBGColorValue"><asp:TextBox ID="TXT_AK_KETJAMINAN" Rows="4" Height="50" TextMode="MultiLine" MaxLength="100"
											Columns="40" onKeypress="return kutip_satu()" Runat="server"></asp:TextBox></TD>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<td align="center">
							<input type="button" value="Simpan" onclick="document.Form1.V_STA.value=1; return cek_mandatory(document.Form1);"
								class="button1">&nbsp;
							<asp:Button id="Button1" runat="server" CssClass="Button1" Text="Lanjutkan" onclick="Button1_Click"></asp:Button>
							<input type="hidden" name="V_STA">
							<asp:Label ID="LBL_REGNO" Visible="False" Runat="server"></asp:Label>
							<asp:Label ID="LBL_CUREF" Visible="False" Runat="server"></asp:Label>
							<asp:Label ID="LBL_TC" Visible="False" Runat="server"></asp:Label>
							<asp:Label ID="LBL_CL_SEQ" Visible="False" Runat="server"></asp:Label>
							<asp:Label ID="LBL_STA" Visible="False" Runat="server"></asp:Label>
						</td>
					</tr>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
