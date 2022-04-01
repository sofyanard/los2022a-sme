<%@ Page language="c#" Codebehind="Kios_Entry.aspx.cs" AutoEventWireup="True" Inherits="SME.Appraisal.Kios_Entry" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Kios_Entry</title>
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
				<TABLE cellSpacing="2" cellPadding="0" width="100%">
					<TR>
						<TD class="tdNoBorder">
							<TABLE id="Table2">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Appraisal : Kios</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right">
							<asp:ImageButton id="BTN_BACK" runat="server" ImageUrl="../Image/back.jpg" onclick="BTN_BACK_Click"></asp:ImageButton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" vAlign="top" colSpan="2" align="center"><B>Penilaian Jaminan 
								Kios/Stand Pasar</B></TD>
					</TR>
				</TABLE>
				<TABLE cellSpacing="2" cellPadding="0" width="100%">
					<TR>
						<TD class="td" vAlign="top" width="100%">
							<TABLE cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="200">Nama Pemeriksa
									</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
										<asp:TextBox ID="TXT_AK_APPRBY" Runat="server" Visible="False"></asp:TextBox>
										<asp:TextBox ID="TXT_AK_APPRNM" Runat="server" Columns="35" ReadOnly></asp:TextBox>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Cabang/CBC/Group</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:TextBox ID="TXT_AK_APPRBR" Runat="server" ReadOnly Columns="35"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tanggal</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:TextBox ID="TXT_AK_APPRDATEDAY" Runat="server" Columns="2" MaxLength="2" CssClass="mandatory"></asp:TextBox>
										<asp:DropDownList Runat="server" ID="DDL_AK_APPRDATEMONTH" CssClass="mandatory"></asp:DropDownList>
										<asp:TextBox ID="TXT_AK_APPRDATEYEAR" Runat="server" Columns="4" MaxLength="4" CssClass="mandatory"></asp:TextBox>
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
													<asp:TextBox ID="TXT_AK_PHNAREA" Runat="server" MaxLength="5" Columns="5" onKeypress="return numbersonly()"></asp:TextBox>
													<asp:TextBox ID="TXT_AK_PHNNUM" Runat="server" MaxLength="15" Columns="15" onKeypress="return numbersonly()"></asp:TextBox>
													<asp:TextBox ID="TXT_AK_PHNEXT" Runat="server" MaxLength="5" Columns="5" onKeypress="return numbersonly()"></asp:TextBox>
												</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Obyek Pemeriksaan</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:DropDownList ID="DDL_AK_COLCLASSIFY" Runat="server"></asp:DropDownList></TD>
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
															<TD class="TDBGColor1" width="200">Pasar/Mall</TD>
															<TD width="15"></TD>
															<TD class="TDBGColorValue"><asp:TextBox ID="TXT_AK_PASARMALL" Runat="server" MaxLength="50" Columns="40" onKeypress="return kutip_satu()"></asp:TextBox></TD>
														</tr>
														<tr>
															<TD class="TDBGColor1">Jl</TD>
															<TD></TD>
															<TD class="TDBGColorValue"><asp:TextBox ID="TXT_AK_LOKJLN" Runat="server" MaxLength="100" Columns="40" onKeypress="return kutip_satu()"></asp:TextBox></TD>
														</tr>
														<tr>
															<TD class="TDBGColor1">Desa</TD>
															<TD></TD>
															<TD class="TDBGColorValue"><asp:TextBox ID="TXT_AK_LOKDESA" Runat="server" MaxLength="50" Columns="40" onKeypress="return kutip_satu()"></asp:TextBox></TD>
														</tr>
														<tr>
															<TD class="TDBGColor1">Kecamatan</TD>
															<TD></TD>
															<TD class="TDBGColorValue"><asp:TextBox ID="TXT_AK_LOKKEC" Runat="server" MaxLength="50" Columns="40" onKeypress="return kutip_satu()"></asp:TextBox></TD>
														</tr>
														<tr>
															<TD class="TDBGColor1">Kab/Kodya</TD>
															<TD></TD>
															<TD class="TDBGColorValue"><asp:TextBox ID="TXT_AK_LOKKAB" Runat="server" MaxLength="50" Columns="40" onKeypress="return kutip_satu()"></asp:TextBox></TD>
														</tr>
													</TABLE>
												</td>
												<td valign="top">
													<TABLE cellSpacing="0" cellPadding="0" width="100%">
														<tr>
															<TD class="TDBGColor1" width="200">Blok/Los</TD>
															<TD width="15"></TD>
															<TD class="TDBGColorValue"><asp:TextBox ID="TXT_AK_BLOKLOS" Runat="server" MaxLength="5" Columns="5" onKeypress="return kutip_satu()"></asp:TextBox></TD>
														</tr>
														<tr>
															<TD class="TDBGColor1">Luas Bangunan</TD>
															<TD></TD>
															<TD class="TDBGColorValue"><asp:TextBox ID="TXT_AK_LUASBANGUN" Runat="server" MaxLength="5" Columns="5" CssClass="angka"
																	onKeypress="return numbersonly()"></asp:TextBox></TD>
														</tr>
														<tr>
															<TD class="TDBGColor1">Pengelola Pasar/Mall</TD>
															<TD></TD>
															<TD class="TDBGColorValue"><asp:TextBox ID="TXT_AK_PENGELOLA" Runat="server" MaxLength="50" Columns="40" onKeypress="return kutip_satu()"></asp:TextBox></TD>
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
													<asp:DropDownList ID="DDL_AK_LINGKUNGAN" Runat="server"></asp:DropDownList>
													<asp:TextBox ID="TXT_AK_KETLINGKUNGAN" Rows="4" Height="50" Columns="100" TextMode="MultiLine"
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
												<TD class="TDBGColorValue"><asp:DropDownList ID="DDL_AK_PENGUASAAN" Runat="server"></asp:DropDownList></TD>
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
													<asp:CheckBox ID="CHB_AK_LISTRIK" Runat="server" Text="Listrik"></asp:CheckBox>
													<asp:TextBox ID="TXT_AK_KETLISTRIK" Runat="server" MaxLength="10" onKeypress="return numbersonly()"
														Columns="10" CssClass="angka"></asp:TextBox>Watt<br>
													<asp:CheckBox ID="CHB_AK_AC" Runat="server" Text="AC"></asp:CheckBox>
													<asp:TextBox ID="TXT_AK_KETAC" Runat="server" MaxLength="10" onKeypress="return numbersonly()"
														Columns="10" CssClass="angka"></asp:TextBox>Unit<br>
													<asp:CheckBox ID="CHB_AK_AIR" Runat="server" Text="Air PAM/Non PAM"></asp:CheckBox>
													<asp:TextBox ID="TXT_AK_KETAIR" Runat="server" MaxLength="10" onKeypress="return kutip_satu()"
														Columns="10"></asp:TextBox><br>
													<asp:CheckBox ID="CHB_AK_TELPFAX" Runat="server" Text="Telepon/Fax"></asp:CheckBox>
													<asp:TextBox ID="TXT_AK_KETTELPFAX" Runat="server" MaxLength="10" onKeypress="return numbersonly()"
														Columns="10" CssClass="angka"></asp:TextBox>Saluran<br>
													<asp:CheckBox ID="CHB_AK_PRASARANALAIN" Runat="server" Text="Lainnya"></asp:CheckBox>
													<asp:TextBox ID="TXT_AK_KETPRASARANALAIN" Runat="server" MaxLength="10" onKeypress="return numbersonly()"
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
															<TD class="TDBGColorValue"><asp:DropDownList id="DDL_AK_BANJIR" Runat="server"></asp:DropDownList></TD>
														</tr>
														<tr>
															<TD class="TDBGColor1">Daerah Tegangan Tinggi</TD>
															<TD></TD>
															<TD class="TDBGColorValue"><asp:DropDownList id="DDL_AK_TEGANGAN" Runat="server"></asp:DropDownList></TD>
														</tr>
														<tr>
															<TD class="TDBGColor1">Rawan Tanah Longsor</TD>
															<TD></TD>
															<TD class="TDBGColorValue"><asp:DropDownList id="DDL_AK_TNHLONGSOR" Runat="server"></asp:DropDownList></TD>
														</tr>
													</TABLE>
												</td>
												<td valign="top">
													<TABLE cellSpacing="0" cellPadding="0" width="100%">
														<tr>
															<TD class="TDBGColor1">Daerah Pencemaran</TD>
															<TD></TD>
															<TD class="TDBGColorValue"><asp:DropDownList id="DDL_AK_PENCEMARAN" Runat="server"></asp:DropDownList></TD>
														</tr>
														<tr>
															<TD class="TDBGColor1">Lain-lain</TD>
															<TD></TD>
															<TD class="TDBGColorValue"><asp:TextBox id="TXT_AK_RESLAIN" Runat="server" MaxLength="100" Columns="40" onKeypress="return kutip_satu()"></asp:TextBox></TD>
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
												<TD class="TDBGColorValue"><asp:DropDownList ID="DDL_AK_PEMELIHARAANBGN" Runat="server"></asp:DropDownList></TD>
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
												<TD class="TDBGColorValue"><asp:DropDownList ID="DDL_AK_JNSHAK" Runat="server"></asp:DropDownList>
													<asp:TextBox ID="TXT_AK_KETJNSHAK" MaxLength="100" Columns="40" Runat="server" onKeypress="return kutip_satu()"></asp:TextBox>
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
															<TD class="TDBGColorValue"><asp:DropDownList ID="DDL_AK_INSRSTATUS" Runat="server"></asp:DropDownList></TD>
														</tr>
													</TABLE>
												</td>
												<td valign="top">
													<TABLE cellSpacing="0" cellPadding="0" width="100%">
														<tr>
															<TD class="TDBGColor1" width="200">Ditutup Asuransi</TD>
															<TD width="15"></TD>
															<TD class="TDBGColorValue"><asp:TextBox ID="TXT_AK_INSRTUTUP" MaxLength="21" Columns="25" CssClass="angka" Runat="server"
																	onKeypress="return numbersonly()"></asp:TextBox></TD>
														</tr>
														<tr>
															<TD class="TDBGColor1">Nilai</TD>
															<TD></TD>
															<TD class="TDBGColorValue"><asp:TextBox ID="TXT_AK_INSRAMOUNT" MaxLength="21" Columns="25" CssClass="angka" Runat="server"
																	onKeypress="return numbersonly()"></asp:TextBox></TD>
														</tr>
														<tr>
															<TD class="TDBGColor1">Masa laku s/d</TD>
															<TD></TD>
															<TD class="TDBGColorValue">
																<asp:TextBox ID="TXT_AK_INSREXPDATEDAY" MaxLength="2" Columns="2" CssClass="angka" Runat="server"
																	onKeypress="return numbersonly()"></asp:TextBox>
																<asp:DropDownList ID="DDL_AK_INSREXPDATEMONTH" Runat="server"></asp:DropDownList>
																<asp:TextBox ID="TXT_AK_INSREXPDATEYEAR" MaxLength="4" Columns="4" CssClass="angka" Runat="server"
																	onKeypress="return numbersonly()"></asp:TextBox>
															</TD>
														</tr>
														<tr>
															<TD class="TDBGColor1">Nama Perusahaan</TD>
															<TD></TD>
															<TD class="TDBGColorValue"><asp:TextBox ID="TXT_AK_INSRCOMP" MaxLength="50" Columns="25" Runat="server" onKeypress="return kutip_satu()"></asp:TextBox></TD>
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
									<td valign="top"><asp:CheckBox ID="CHB_AK_SERTIFIKAT" Runat="server" Text="Sertifikat"></asp:CheckBox></td>
									<td valign="top">
										<table cellpadding="0" cellspacing="0" width="100%">
											<tr>
												<td class="TDBGColor1" width="200">Nomor</td>
												<td width="15"></td>
												<td class="TDBGColorValue"><asp:TextBox ID="TXT_AK_SERTNO" Runat="server" Columns="25" MaxLength="20" onKeypress="return kutip_satu()"></asp:TextBox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Berlaku s/d</td>
												<td></td>
												<td class="TDBGColorValue">
													<asp:TextBox ID="TXT_AK_SERTEXPDATEDAY" Columns="2" Runat="server" MaxLength="2" onKeypress="return numbersonly()"></asp:TextBox>
													<asp:DropDownList ID="DDL_AK_SERTEXPDATEMONTH" Runat="server"></asp:DropDownList>
													<asp:TextBox ID="TXT_AK_SERTEXPDATEYEAR" Columns="4" Runat="server" MaxLength="4" onKeypress="return numbersonly()"></asp:TextBox>
												</td>
											</tr>
											<tr>
												<td class="TDBGColor1">Atas Nama</td>
												<td></td>
												<td class="TDBGColorValue"><asp:TextBox ID="TXT_AK_SERTATASNAMA" Columns="25" MaxLength="50" Runat="server" onKeypress="return kutip_satu()"></asp:TextBox></td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td></td>
									<td></td>
									<td><asp:CheckBox ID="CHB_AK_AKTEJLBL" Runat="server" Text="Akte Jual Beli"></asp:CheckBox></td>
									<td>
										<table cellpadding="0" cellspacing="0" width="100%">
											<tr>
												<td class="TDBGColor1" width="200">Nomor</td>
												<td width="15"></td>
												<td class="TDBGColorValue"><asp:TextBox ID="TXT_AK_AKTEJLBLNO" Runat="server" Columns="25" MaxLength="20" onKeypress="return kutip_satu()"></asp:TextBox></td>
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
												<td class="TDBGColor1" width="365">Hasil pengecekan keabsahan ke pengelola 
													pasar/mall</td>
												<td width="15"></td>
												<td class="TDBGColorValue"><asp:TextBox ID="TXT_AK_CEKPENGELOLAHSL" Runat="server" Columns="25" MaxLength="50" onKeypress="return kutip_satu()"></asp:TextBox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Tanggal Pengecekan</td>
												<td></td>
												<td class="TDBGColorValue">
													<asp:TextBox ID="TXT_AK_CEKPENGELOLADATEDAY" Runat="server" Columns="2" MaxLength="2" onKeypress="return numbersonly()"></asp:TextBox>
													<asp:DropDownList ID="DDL_AK_CEKPENGELOLADATEMONTH" Runat="server"></asp:DropDownList>
													<asp:TextBox ID="TXT_AK_CEKPENGELOLADATEYEAR" Runat="server" Columns="4" MaxLength="4" onKeypress="return numbersonly()"></asp:TextBox>
												</td>
											</tr>
											<tr>
												<td class="TDBGColor1">Pejabat BPN/Instansi yang Menyatakan</td>
												<td></td>
												<td class="TDBGColorValue"><asp:TextBox ID="TXT_AK_PEJABAT" Runat="server" Columns="25" MaxLength="50" onKeypress="return kutip_satu()"></asp:TextBox></td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td valign="top">2.</td>
									<td valign="top">Ikatan Jaminan</td>
									<td valign="top"><asp:CheckBox ID="CHB_AK_BEBASIKAT" Runat="server" Text="Bebas Ikatan"></asp:CheckBox></td>
									<td valign="top">
										<table cellpadding="0" cellspacing="0" width="100%">
											<tr>
												<td class="TDBGColor1" width="200">No. Akte</td>
												<td width="15"></td>
												<td class="TDBGColorValue"><asp:TextBox ID="TXT_AK_AKTEIKATNO" Runat="server" Columns="25" MaxLength="50" onKeypress="return kutip_satu()"></asp:TextBox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Pada</td>
												<td></td>
												<td class="TDBGColorValue"><asp:TextBox ID="TXT_AK_AKTEIKATADDR" Runat="server" Columns="25" MaxLength="50" onKeypress="return kutip_satu()"></asp:TextBox></td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td valign="top">3.</td>
									<td valign="top">Permasalahan Yuridis</td>
									<td><asp:DropDownList ID="DDL_AK_MSLHYURIDIS" Runat="server"></asp:DropDownList></td>
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
												<td class="TDBGColor1">Harga resmi yang dikeluarkan oleh pengelola pasar/mall</td>
												<td width="15"></td>
												<td class="TDBGColorValue"><asp:TextBox ID="TXT_AK_HRGPENGELOLA" Runat="server" Columns="25" MaxLength="21" onKeypress="return numbersonly()"
														CssClass="angka"></asp:TextBox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Informasi harga pasar (developer media massa dll) atau 
													transaksi terbaru</td>
												<td></td>
												<td class="TDBGColorValue"><asp:TextBox ID="TXT_AK_HRGPASAR" Runat="server" Columns="25" MaxLength="21" onKeypress="return numbersonly()"
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
												<td class="TDBGColorValue"><asp:TextBox ID="TXT_AK_HRGTAKSASI" Runat="server" Columns="25" MaxLength="21" onKeypress="return numbersonly()"
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
												<td class="TDBGColor1" width="200">a. Kualitas bangunan kios</td>
												<td width="15"></td>
												<td class="TDBGColorValue"><asp:DropDownList ID="DDL_AK_KUALITAS" Runat="server"></asp:DropDownList></td>
											</tr>
											<tr>
												<td class="TDBGColor1">b. Marketability</td>
												<td></td>
												<td class="TDBGColorValue"><asp:DropDownList ID="DDL_AK_MARKETABILITY" Runat="server"></asp:DropDownList></td>
											</tr>
											<tr>
												<td class="TDBGColor1">c. Sisa jangka waktu sewa kios</td>
												<td></td>
												<td class="TDBGColorValue"><asp:DropDownList ID="DDL_AK_SISAWAKTU" Runat="server"></asp:DropDownList>
													Tahun</td>
											</tr>
											<tr>
												<td class="TDBGColor1">d. Safety Margin</td>
												<td></td>
												<td class="TDBGColorValue"><asp:TextBox ID="TXT_AK_SFTYMARGIN" Runat="server" Columns="6" MaxLength="10" onKeypress="return numbersonly()"
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
												<td class="TDBGColorValue"><asp:TextBox ID="TXT_AK_TAKSASISTLHSMARGIN" Runat="server" Columns="25" MaxLength="21" onKeypress="return numbersonly()"
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
												<td class="TDBGColorValue"><asp:DropDownList ID="DDL_AK_FOTO" Runat="server"></asp:DropDownList></td>
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
												<td class="TDBGColorValue"><asp:TextBox ID="TXT_AK_KETJAMINAN" Runat="server" Columns="40" MaxLength="100" Rows="4" Height="50"
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
									<td valign="top"><asp:CheckBox ID="CHB_AK_MARKETSALE" Runat="server" Text="Marketable dan saleable"></asp:CheckBox></td>
								</tr>
								<tr>
									<td valign="top"></td>
									<td valign="top"><asp:CheckBox ID="CHB_AK_MARKET" Runat="server" Text="Marketable"></asp:CheckBox></td>
								</tr>
								<tr>
									<td valign="top"></td>
									<td valign="top"><asp:CheckBox ID="CHB_AK_BISAIKAT" Runat="server" Text="Bisa dilakukan pengikatan secara sempurna"></asp:CheckBox></td>
								</tr>
								<tr>
									<td valign="top"></td>
									<td valign="top"><asp:CheckBox ID="CHB_AK_BLMBISAIKAT" Runat="server" Text="Belum bisa dilakukan pengikatan secara sempurna"></asp:CheckBox></td>
								</tr>
								<tr>
									<td valign="top"></td>
									<td valign="top"><asp:CheckBox ID="CHB_AK_SENGKETA" Runat="server" Text="Bermasalah/dalam sengketa"></asp:CheckBox></td>
								</tr>
								<tr>
									<td valign="top"></td>
									<td valign="top">
										<asp:CheckBox ID="CHB_AK_KESLAIN" Runat="server" Text="Lain-lain"></asp:CheckBox>
										<asp:TextBox ID="TXT_AK_KETKESLAIN" MaxLength="100" Columns="40" Rows="4" Height="50" onKeypress="return kutip_satu()"
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
