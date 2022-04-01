<%@ Page language="c#" Codebehind="Ruko_Entry.aspx.cs" AutoEventWireup="True" Inherits="SME.Appraisal.Ruko_Entry" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Ruko_Entry</title>
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
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder">
							<TABLE id="Table2">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Appraisal : Ruko</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right">
							<asp:ImageButton id="ImageButton1" runat="server" ImageUrl="../Image/back.jpg" onclick="ImageButton1_Click"></asp:ImageButton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" vAlign="top" colSpan="2" align="center"><B>Penilaian Jaminan 
								(Tanah &amp; Bangunan)</B></TD>
					</TR>
				</TABLE>
				<TABLE cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="td" vAlign="top" width="100%">
							<TABLE cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="165">Nama Pemeriksa
									</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
										<asp:TextBox ID="TXT_AR_APPRBY" Runat="server" Visible="False"></asp:TextBox>
										<asp:TextBox ID="TXT_AR_APPRNM" Runat="server" Columns="35"></asp:TextBox>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Cabang/CBC/Group</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:TextBox ID="TXT_AR_APPRBR" Runat="server" Columns="35"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tanggal</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:TextBox ID="TXT_AR_APPRDATEDAY" Runat="server" Columns="2" MaxLength="2" CssClass="mandatory"></asp:TextBox>
										<asp:DropDownList Runat="server" ID="DDL_AR_APPRDATEMONTH" CssClass="mandatory"></asp:DropDownList>
										<asp:TextBox ID="TXT_AR_APPRDATEYEAR" Runat="server" Columns="4" MaxLength="4" CssClass="mandatory"></asp:TextBox>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top">
							<TABLE cellSpacing="0" cellPadding="0" width="100%">
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
													<asp:TextBox ID="TXT_AR_PHNAREA" Runat="server" MaxLength="5" Columns="5" onKeypress="return numbersonly()"></asp:TextBox>
													<asp:TextBox ID="TXT_AR_PHNNUM" Runat="server" MaxLength="15" Columns="15" onKeypress="return numbersonly()"></asp:TextBox>
													<asp:TextBox ID="TXT_AR_PHNEXT" Runat="server" MaxLength="5" Columns="5" onKeypress="return numbersonly()"></asp:TextBox>
												</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Obyek Pemeriksaan</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:DropDownList ID="DDL_AR_COLCLASSIFY" Runat="server"></asp:DropDownList></TD>
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
												<TD class="TDBGColorValue"><asp:TextBox ID="TXT_AR_ADDRJLN" Runat="server" MaxLength="100" Columns="40" onKeypress="return kutip_satu()"></asp:TextBox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Desa</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:TextBox ID="TXT_AR_ADDRDESA" Runat="server" MaxLength="50" Columns="40" onKeypress="return kutip_satu()"></asp:TextBox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Kecamatan</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:TextBox ID="TXT_AR_ADDRKEC" Runat="server" MaxLength="50" Columns="40" onKeypress="return kutip_satu()"></asp:TextBox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Kab/Kodya</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:TextBox ID="TXT_AR_ADDRKAB" Runat="server" MaxLength="50" Columns="40" onKeypress="return kutip_satu()"></asp:TextBox></TD>
											</TR>
										</TABLE>
									</td>
								</tr>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top">
							<TABLE cellSpacing="0" cellPadding="0" width="100%">
								<tr>
									<td valign="top" class="tdHeader1" colSpan="2" align="center">I. Penelitian Phisik</td>
								</tr>
								<tr>
									<td>1.</td>
									<td>Lokasi Terletak di</td>
								</tr>
								<tr>
									<td></td>
									<td>
										<TABLE cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<td valign="top" width="50%">
													<TABLE cellSpacing="0" cellPadding="0" width="100%">
														<tr>
															<TD class="TDBGColor1">Jl</TD>
															<TD></TD>
															<TD class="TDBGColorValue"><asp:TextBox ID="TXT_AR_LOKJLN" Runat="server" MaxLength="100" Columns="40" onKeypress="return kutip_satu()"></asp:TextBox></TD>
														</tr>
														<tr>
															<TD class="TDBGColor1">Desa</TD>
															<TD></TD>
															<TD class="TDBGColorValue"><asp:TextBox ID="TXT_AR_LOKDESA" Runat="server" MaxLength="50" Columns="40" onKeypress="return kutip_satu()"></asp:TextBox></TD>
														</tr>
														<tr>
															<TD class="TDBGColor1">Kecamatan</TD>
															<TD></TD>
															<TD class="TDBGColorValue"><asp:TextBox ID="TXT_AR_LOKKEC" Runat="server" MaxLength="50" Columns="40" onKeypress="return kutip_satu()"></asp:TextBox></TD>
														</tr>
														<tr>
															<TD class="TDBGColor1">Kab/Kodya</TD>
															<TD></TD>
															<TD class="TDBGColorValue"><asp:TextBox ID="TXT_AR_LOKKAB" Runat="server" MaxLength="50" Columns="40" onKeypress="return kutip_satu()"></asp:TextBox></TD>
														</tr>
													</TABLE>
												</td>
												<td valign="top">
													<TABLE cellSpacing="0" cellPadding="0" width="100%">
														<tr>
															<TD class="TDBGColor1" width="200">Lantai/Blok/No</TD>
															<TD width="15"></TD>
															<TD class="TDBGColorValue"><asp:TextBox ID="TXT_AR_LNTBLOK" Runat="server" MaxLength="5" Columns="5" onKeypress="return kutip_satu()"></asp:TextBox></TD>
														</tr>
														<tr>
															<TD class="TDBGColor1">Luas Bangunan</TD>
															<TD></TD>
															<TD class="TDBGColorValue"><asp:TextBox ID="TXT_AR_LUASBANGUN" Runat="server" MaxLength="5" Columns="5" CssClass="angka"
																	onKeypress="return numbersonly()"></asp:TextBox></TD>
														</tr>
														<tr>
															<TD class="TDBGColor1">No. Ijin Bangunan</TD>
															<TD></TD>
															<TD class="TDBGColorValue"><asp:TextBox ID="TXT_AR_IJINNO" Runat="server" MaxLength="50" Columns="40" onKeypress="return kutip_satu()"></asp:TextBox></TD>
														</tr>
														<tr>
															<TD class="TDBGColor1">Dibuat Tahun</TD>
															<TD></TD>
															<TD class="TDBGColorValue"><asp:TextBox ID="TXT_AR_THNBUAT" Runat="server" MaxLength="4" Columns="4" onKeypress="return kutip_satu()"></asp:TextBox></TD>
														</tr>
														<tr>
															<TD class="TDBGColor1">Pengembang</TD>
															<TD></TD>
															<TD class="TDBGColorValue"><asp:TextBox ID="TXT_AR_PENGEMBANG" Runat="server" MaxLength="50" Columns="40" onKeypress="return kutip_satu()"></asp:TextBox></TD>
														</tr>
													</TABLE>
												</td>
											</tr>
										</TABLE>
									</td>
								</tr>
								<tr>
									<td valign="top">2.</td>
									<td>
										<TABLE cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<TD class="TDBGColor1" width="200" valign="top">Lingkungan</TD>
												<TD width="15"></TD>
												<TD class="TDBGColorValue" valign="top">
													<asp:DropDownList ID="DDL_AR_LINGKUNGAN" Runat="server"></asp:DropDownList>
													<asp:TextBox ID="TXT_AR_KETLINGKUNGAN" Rows="4" Height="50" Columns="100" TextMode="MultiLine"
														onKeypress="return kutip_satu()" MaxLength="100" Runat="server"></asp:TextBox>
												</TD>
											</tr>
										</TABLE>
									</td>
								</tr>
								<tr>
									<td>3.</td>
									<td>
										<TABLE cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<TD class="TDBGColor1" width="200">Penguasaan</TD>
												<TD width="15"></TD>
												<TD class="TDBGColorValue"><asp:DropDownList ID="DDL_AR_PENGUASAAN" Runat="server"></asp:DropDownList></TD>
											</tr>
										</TABLE>
									</td>
								</tr>
								<tr>
									<td valign="top">4.</td>
									<td>
										<TABLE cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<TD class="TDBGColor1" width="200" valign="top">Prasarana</TD>
												<TD width="15"></TD>
												<TD class="TDBGColorValue" valign="top">
													<asp:CheckBox ID="CHB_AR_LISTRIK" Runat="server" Text="Listrik"></asp:CheckBox>
													<asp:TextBox ID="TXT_AR_KETLISTRIK" Runat="server" MaxLength="10" onKeypress="return numbersonly()"
														Columns="10" CssClass="angka"></asp:TextBox>Watt<br>
													<asp:CheckBox ID="CHB_AR_AC" Runat="server" Text="AC"></asp:CheckBox>
													<asp:TextBox ID="TXT_AR_KETAC" Runat="server" MaxLength="10" onKeypress="return numbersonly()"
														Columns="10" CssClass="angka"></asp:TextBox>Unit<br>
													<asp:CheckBox ID="CHB_AR_AIR" Runat="server" Text="Air PAM/Non PAM"></asp:CheckBox>
													<asp:TextBox ID="TXT_AR_KETAIR" Runat="server" MaxLength="10" onKeypress="return kutip_satu()"
														Columns="10"></asp:TextBox><br>
													<asp:CheckBox ID="CHB_AR_TELPFAX" Runat="server" Text="Telepon/Fax"></asp:CheckBox>
													<asp:TextBox ID="TXT_AR_KETTELPFAX" Runat="server" MaxLength="10" onKeypress="return numbersonly()"
														Columns="10" CssClass="angka"></asp:TextBox>Saluran<br>
													<asp:CheckBox ID="CHB_AR_PRASARANALAIN" Runat="server" Text="Lainnya"></asp:CheckBox>
													<asp:TextBox ID="TXT_AR_KETPRASARANALAIN" Runat="server" MaxLength="10" onKeypress="return numbersonly()"
														Columns="10" CssClass="angka">Watt</asp:TextBox>
												</TD>
											</tr>
										</TABLE>
									</td>
								</tr>
								<tr>
									<td>5.</td>
									<td>Resiko</td>
								</tr>
								<tr>
									<td></td>
									<td>
										<TABLE cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<td valign="top" width="50%">
													<TABLE cellSpacing="0" cellPadding="0" width="100%">
														<tr>
															<TD class="TDBGColor1" width="200">Daerah Banjir</TD>
															<TD width="15"></TD>
															<TD class="TDBGColorValue"><asp:DropDownList id="DDL_AR_BANJIR" Runat="server"></asp:DropDownList></TD>
														</tr>
														<tr>
															<TD class="TDBGColor1">Daerah Tegangan Tinggi</TD>
															<TD></TD>
															<TD class="TDBGColorValue"><asp:DropDownList id="DDL_AR_TEGANGAN" Runat="server"></asp:DropDownList></TD>
														</tr>
														<tr>
															<TD class="TDBGColor1">Rawan Tanah Longsor</TD>
															<TD></TD>
															<TD class="TDBGColorValue"><asp:DropDownList id="DDL_AR_TNHLONGSOR" Runat="server"></asp:DropDownList></TD>
														</tr>
													</TABLE>
												</td>
												<td valign="top">
													<TABLE cellSpacing="0" cellPadding="0" width="100%">
														<tr>
															<TD class="TDBGColor1">Daerah Pencemaran</TD>
															<TD></TD>
															<TD class="TDBGColorValue"><asp:DropDownList id="DDL_AR_PENCEMARAN" Runat="server"></asp:DropDownList></TD>
														</tr>
														<tr>
															<TD class="TDBGColor1">Lain-lain</TD>
															<TD></TD>
															<TD class="TDBGColorValue"><asp:TextBox id="TXT_AR_RESLAIN" Runat="server" MaxLength="100" Columns="40" onKeypress="return kutip_satu()"></asp:TextBox></TD>
														</tr>
													</TABLE>
												</td>
											</tr>
										</TABLE>
									</td>
								</tr>
								<tr>
									<td>6.</td>
									<td>
										<TABLE cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<TD class="TDBGColor1" width="200">Pemeliharaan Bangunan</TD>
												<TD width="15"></TD>
												<TD class="TDBGColorValue"><asp:DropDownList ID="DDL_AR_PEMELIHARAANBGN" Runat="server"></asp:DropDownList></TD>
											</tr>
										</TABLE>
									</td>
								</tr>
								<tr>
									<td>7.</td>
									<td>
										<TABLE cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<TD class="TDBGColor1" width="200">Jenis Hak</TD>
												<TD width="15"></TD>
												<TD class="TDBGColorValue"><asp:DropDownList ID="DDL_AR_JNSHAK" Runat="server"></asp:DropDownList>
													<asp:TextBox ID="TXT_AR_KETJNSHAK" MaxLength="100" Columns="40" Runat="server" onKeypress="return kutip_satu()"></asp:TextBox>
												</TD>
											</tr>
										</TABLE>
									</td>
								</tr>
								<tr>
									<td valign="top">8.</td>
									<td>
										<TABLE cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<td valign="top">
													<TABLE cellSpacing="0" cellPadding="0" width="100%">
														<tr>
															<TD class="TDBGColor1" width="200">Asuransi</TD>
															<TD width="15"></TD>
															<TD class="TDBGColorValue"><asp:DropDownList ID="DDL_AR_INSRSTATUS" Runat="server"></asp:DropDownList></TD>
														</tr>
													</TABLE>
												</td>
												<td valign="top">
													<TABLE cellSpacing="0" cellPadding="0" width="100%">
														<tr>
															<TD class="TDBGColor1" width="200">Ditutup Asuransi</TD>
															<TD width="15"></TD>
															<TD class="TDBGColorValue"><asp:TextBox ID="TXT_AR_INSRTUTUP" MaxLength="21" Columns="25" CssClass="angka" Runat="server"
																	onKeypress="return numbersonly()"></asp:TextBox></TD>
														</tr>
														<tr>
															<TD class="TDBGColor1">Nilai</TD>
															<TD></TD>
															<TD class="TDBGColorValue"><asp:TextBox ID="TXT_AR_INSRAMOUNT" MaxLength="21" Columns="25" CssClass="angka" Runat="server"
																	onKeypress="return numbersonly()"></asp:TextBox></TD>
														</tr>
														<tr>
															<TD class="TDBGColor1">Masa laku s/d</TD>
															<TD></TD>
															<TD class="TDBGColorValue">
																<asp:TextBox ID="TXT_AR_INSREXPDATEDAY" MaxLength="2" Columns="2" CssClass="angka" Runat="server"
																	onKeypress="return numbersonly()"></asp:TextBox>
																<asp:DropDownList ID="DDL_AR_INSREXPDATEMONTH" Runat="server"></asp:DropDownList>
																<asp:TextBox ID="TXT_AR_INSREXPDATEYEAR" MaxLength="4" Columns="4" CssClass="angka" Runat="server"
																	onKeypress="return numbersonly()"></asp:TextBox>
															</TD>
														</tr>
														<tr>
															<TD class="TDBGColor1">Nama Perusahaan</TD>
															<TD></TD>
															<TD class="TDBGColorValue"><asp:TextBox ID="TXT_AR_INSRCOMP" MaxLength="50" Columns="25" Runat="server" onKeypress="return kutip_satu()"></asp:TextBox></TD>
														</tr>
													</TABLE>
												</td>
											</tr>
										</TABLE>
									</td>
								</tr>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top">
							<TABLE cellSpacing="0" cellPadding="0" width="100%">
								<tr>
									<td valign="top" class="tdHeader1" colSpan="4" align="center">II. Penelitian 
										Yuridis</td>
								</tr>
								<tr>
									<td valign="top">1.</td>
									<td valign="top">Surat-surat Pemilikan</td>
									<td valign="top"><asp:CheckBox ID="CHB_AR_SERTIFIKAT" Runat="server" Text="Sertifikat"></asp:CheckBox></td>
									<td valign="top">
										<table cellpadding="0" cellspacing="0" width="100%">
											<tr>
												<td class="TDBGColor1" width="200">Nomor</td>
												<td width="15"></td>
												<td class="TDBGColorValue"><asp:TextBox ID="TXT_AR_SERTNO" Runat="server" Columns="25" MaxLength="20" onKeypress="return kutip_satu()"></asp:TextBox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Berlaku s/d</td>
												<td></td>
												<td class="TDBGColorValue">
													<asp:TextBox ID="TXT_AR_SERTEXPDATEDAY" Columns="2" Runat="server" MaxLength="2" onKeypress="return numbersonly()"></asp:TextBox>
													<asp:DropDownList ID="DDL_AR_SERTEXPDATEMONTH" Runat="server"></asp:DropDownList>
													<asp:TextBox ID="TXT_AR_SERTEXPDATEYEAR" Columns="4" Runat="server" MaxLength="4" onKeypress="return numbersonly()"></asp:TextBox>
												</td>
											</tr>
											<tr>
												<td class="TDBGColor1">Atas Nama</td>
												<td></td>
												<td class="TDBGColorValue"><asp:TextBox ID="TXT_AR_SERTATASNAMA" Columns="25" MaxLength="50" Runat="server" onKeypress="return kutip_satu()"></asp:TextBox></td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td></td>
									<td></td>
									<td><asp:CheckBox ID="CHB_AR_AKTEJLBL" Runat="server" Text="Akte Jual Beli"></asp:CheckBox></td>
									<td>
										<table cellpadding="0" cellspacing="0" width="100%">
											<tr>
												<td class="TDBGColor1" width="200">Nomor</td>
												<td width="15"></td>
												<td class="TDBGColorValue"><asp:TextBox ID="TXT_AR_AKTEJLBLNO" Runat="server" Columns="25" MaxLength="20" onKeypress="return kutip_satu()"></asp:TextBox></td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td></td>
									<td></td>
									<td colspan="2">
										<table cellpadding="0" cellspacing="0" width="100%">
											<tr>
												<td class="TDBGColor1" width="365">Hasil Pengecekan Keabsahan ke BPN</td>
												<td width="15"></td>
												<td class="TDBGColorValue"><asp:TextBox ID="TXT_AR_CEKBPNHSL" Runat="server" Columns="25" MaxLength="50" onKeypress="return kutip_satu()"></asp:TextBox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Tanggal Pengecekan</td>
												<td></td>
												<td class="TDBGColorValue">
													<asp:TextBox ID="TXT_AR_CEKBPNDATEDAY" Runat="server" Columns="2" MaxLength="2" onKeypress="return numbersonly()"></asp:TextBox>
													<asp:DropDownList ID="DDL_AR_CEKBPNDATEMONTH" Runat="server"></asp:DropDownList>
													<asp:TextBox ID="TXT_AR_CEKBPNDATEYEAR" Runat="server" Columns="4" MaxLength="4" onKeypress="return numbersonly()"></asp:TextBox>
												</td>
											</tr>
											<tr>
												<td class="TDBGColor1">Pejabat BPN/Instansi yang Menyatakan</td>
												<td></td>
												<td class="TDBGColorValue"><asp:TextBox ID="TXT_AR_PEJABAT" Runat="server" Columns="25" MaxLength="50" onKeypress="return kutip_satu()"></asp:TextBox></td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td valign="top">2.</td>
									<td valign="top">Ikatan Jaminan</td>
									<td valign="top"><asp:CheckBox ID="CHB_AR_BEBASIKAT" Runat="server" Text="Bebas Ikatan"></asp:CheckBox></td>
									<td valign="top">
										<table cellpadding="0" cellspacing="0" width="100%">
											<tr>
												<td class="TDBGColor1" width="200">No. Akte</td>
												<td width="15"></td>
												<td class="TDBGColorValue"><asp:TextBox ID="TXT_AR_AKTEIKATNO" Runat="server" Columns="25" MaxLength="50" onKeypress="return kutip_satu()"></asp:TextBox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Pada</td>
												<td></td>
												<td class="TDBGColorValue"><asp:TextBox ID="TXT_AR_AKTEIKATADDR" Runat="server" Columns="25" MaxLength="50" onKeypress="return kutip_satu()"></asp:TextBox></td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td valign="top">3.</td>
									<td valign="top">Permasalahan Yuridis</td>
									<td><asp:DropDownList ID="DDL_AR_MSLHYURIDIS" Runat="server"></asp:DropDownList></td>
									<td></td>
								</tr>
								<tr>
									<td valign="top"></td>
									<td valign="top">Diikat efektif sempurna</td>
									<td><asp:DropDownList ID="DDL_AR_DIIKATEFEKTIF" Runat="server"></asp:DropDownList></td>
									<td></td>
								</tr>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top">
							<TABLE cellSpacing="0" cellPadding="0" width="100%">
								<tr>
									<td valign="top" class="tdHeader1" colSpan="3" align="center">III. Informasi Harga</td>
								</tr>
								<tr>
									<td valign="top">1.</td>
									<td valign="top">Harga total tanah dan bangunan</td>
									<td valign="top">
										<table cellspacing="0" cellpadding="0" width="100%">
											<tr>
												<td class="TDBGColor1">NJOP</td>
												<td width="15"></td>
												<td class="TDBGColorValue"><asp:TextBox ID="TXT_AR_HRGNJOP" Runat="server" Columns="25" MaxLength="21" onKeypress="return numbersonly()"
														CssClass="angka"></asp:TextBox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Informasi Harga Pasar</td>
												<td></td>
												<td class="TDBGColorValue"><asp:TextBox ID="TXT_AR_HRGPASAR" Runat="server" Columns="25" MaxLength="21" onKeypress="return numbersonly()"
														CssClass="angka"></asp:TextBox></td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td></td>
									<td colspan="2" valign="top">
										<table cellspacing="0" cellpadding="0" width="100%">
											<tr>
												<td class="TDBGColor1" width="350">Berdasarkan harga tersebut diperoleh harga 
													taksasi
												</td>
												<td width="15"></td>
												<td class="TDBGColorValue"><asp:TextBox ID="TXT_AR_HRGTAKSASI" Runat="server" Columns="25" MaxLength="21" onKeypress="return numbersonly()"
														CssClass="angka"></asp:TextBox></td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td valign="top">2.</td>
									<td valign="top">Scoring safety margin</td>
									<td></td>
								</tr>
								<tr>
									<td></td>
									<td valign="top" colspan="2">
										<table cellspacing="0" cellpadding="0" width="100%">
											<tr>
												<td class="TDBGColor1" width="200">a. Wilayah</td>
												<td width="15"></td>
												<td class="TDBGColorValue"><asp:DropDownList ID="DDL_AR_WILAYAH" Runat="server"></asp:DropDownList></td>
											</tr>
											<tr>
												<td class="TDBGColor1" width="200">b. Lokasi</td>
												<td width="15"></td>
												<td class="TDBGColorValue"><asp:DropDownList ID="DDL_AR_LOKASI" Runat="server"></asp:DropDownList></td>
											</tr>
											<tr>
												<td class="TDBGColor1">c. Marketability</td>
												<td></td>
												<td class="TDBGColorValue"><asp:DropDownList ID="DDL_AR_MARKETABILITY" Runat="server"></asp:DropDownList></td>
											</tr>
											<tr>
												<td class="TDBGColor1" width="200">d. Kondisi</td>
												<td width="15"></td>
												<td class="TDBGColorValue"><asp:DropDownList ID="DDL_AR_KONDISI" Runat="server"></asp:DropDownList></td>
											</tr>
											<tr>
												<td class="TDBGColor1" width="200">e. Kayu</td>
												<td width="15"></td>
												<td class="TDBGColorValue"><asp:DropDownList ID="DDL_AR_KAYU" Runat="server"></asp:DropDownList></td>
											</tr>
											<tr>
												<td class="TDBGColor1" width="200">f. Lantai</td>
												<td width="15"></td>
												<td class="TDBGColorValue"><asp:DropDownList ID="DDL_AR_LANTAI" Runat="server"></asp:DropDownList></td>
											</tr>
											<tr>
												<td class="TDBGColor1">g. Umur bangunan</td>
												<td></td>
												<td class="TDBGColorValue"><asp:DropDownList ID="DDL_AR_UMUR" Runat="server"></asp:DropDownList>
													Tahun</td>
											</tr>
											<tr>
												<td class="TDBGColor1">d. Safety Margin</td>
												<td></td>
												<td class="TDBGColorValue"><asp:TextBox ID="TXT_AR_SFTYMARGIN" Runat="server" Columns="6" MaxLength="10" onKeypress="return numbersonly()"
														CssClass="angka"></asp:TextBox></td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td valign="top">3.</td>
									<td colspan="2">
										<table cellspacing="0" cellpadding="0" width="100%">
											<tr>
												<td class="TDBGColor1" width="200">Nilai taksasi setelah safety margin</td>
												<td width="15"></td>
												<td class="TDBGColorValue"><asp:TextBox ID="TXT_AR_TAKSASISTLHSMARGIN" Runat="server" Columns="25" MaxLength="21" onKeypress="return numbersonly()"
														CssClass="angka"></asp:TextBox></td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td valign="top">4.</td>
									<td colspan="2">
										<table cellspacing="0" cellpadding="0" width="100%">
											<tr>
												<td class="TDBGColor1" width="200">Gambar lokasi dan foto terlampir</td>
												<td width="15"></td>
												<td class="TDBGColorValue"><asp:DropDownList ID="DDL_AR_FOTO" Runat="server"></asp:DropDownList></td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td valign="top">5.</td>
									<td colspan="2">
										<table cellspacing="0" cellpadding="0" width="100%">
											<tr>
												<td class="TDBGColor1" width="200">Keterangan lain tentang<br>
													bangunan yang<br>
													bersangkutan</td>
												<td width="15"></td>
												<td class="TDBGColorValue"><asp:TextBox ID="TXT_AR_KETJAMINAN" Runat="server" Columns="40" MaxLength="100" Rows="4" Height="50"
														onKeypress="return kutip_satu()"></asp:TextBox></td>
											</tr>
										</table>
									</td>
								</tr>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top">
							<TABLE cellSpacing="0" cellPadding="0" width="100%">
								<tr>
									<td valign="top" class="tdHeader1" colSpan="2" align="center">IV. 
										Kesimpulan/Rekomendasi</td>
								</tr>
								<tr>
									<td valign="top"></td>
									<td valign="top"><asp:CheckBox ID="CHB_AR_MARKETSALE" Runat="server" Text="Marketable dan saleable"></asp:CheckBox></td>
								</tr>
								<tr>
									<td valign="top"></td>
									<td valign="top"><asp:CheckBox ID="CHB_AR_MARKET" Runat="server" Text="Marketable"></asp:CheckBox></td>
								</tr>
								<tr>
									<td valign="top"></td>
									<td valign="top"><asp:CheckBox ID="CHB_AR_BISAIKAT" Runat="server" Text="Bisa dilakukan pengikatan secara sempurna"></asp:CheckBox></td>
								</tr>
								<tr>
									<td valign="top"></td>
									<td valign="top"><asp:CheckBox ID="CHB_AR_BLMBISAIKAT" Runat="server" Text="Belum bisa dilakukan pengikatan secara sempurna"></asp:CheckBox></td>
								</tr>
								<tr>
									<td valign="top"></td>
									<td valign="top"><asp:CheckBox ID="CHB_AR_SENGKETA" Runat="server" Text="Bermasalah/dalam sengketa"></asp:CheckBox></td>
								</tr>
								<tr>
									<td valign="top"></td>
									<td valign="top">
										<asp:CheckBox ID="CHB_AR_KESLAIN" Runat="server" Text="Lain-lain"></asp:CheckBox>
										<asp:TextBox ID="TXT_AR_KETKESLAIN" MaxLength="100" Columns="40" Rows="4" Height="50" onKeypress="return kutip_satu()"
											Runat="server" TextMode="MultiLine"></asp:TextBox>
									</td>
								</tr>
							</TABLE>
						</TD>
					</TR>
					<tr>
						<td align="center">
							<input type="button" value="Simpan" class="button1" onclick="document.Form1.V_STA.value=1; return cek_mandatory(document.Form1)">&nbsp;
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
