<%@ Page language="c#" Codebehind="Bangunan_Entry.aspx.cs" AutoEventWireup="True" Inherits="SME.Appraisal.Bangunan_Entry" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Bangunan_Entry</title>
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
						<TD class="tdNoBorder"></TD>
						<TD class="tdNoBorder" align="right"><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" vAlign="top" align="center" colSpan="2"><B>Penilaian Jaminan 
								Bangunan</B></TD>
					</TR>
				</TABLE>
				<TABLE cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="td" vAlign="top">
							<TABLE cellSpacing="0" cellPadding="0" width="100%">
								<tr>
									<td vAlign="top">1.</td>
									<td vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<td vAlign="top" width="205">Keadaan Fisik</td>
												<td vAlign="top">
													<TABLE cellSpacing="0" cellPadding="0" width="100%">
														<tr>
															<TD class="TDBGColor1" width="200">Luas Tanah</TD>
															<TD width="15"></TD>
															<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_AB_LUASTNH" Columns="5" Runat="server"
																	CssClass="angka" MaxLength="5"></asp:textbox></TD>
														</tr>
														<tr>
															<TD class="TDBGColor1">Luas Bangunan</TD>
															<TD></TD>
															<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_AB_LUASBANGUN" Columns="5" Runat="server"
																	CssClass="angka" MaxLength="5"></asp:textbox></TD>
														</tr>
														<tr>
															<TD class="TDBGColor1">No. Ijin Bangunan</TD>
															<TD></TD>
															<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_AB_IJINNO" Columns="40" Runat="server"
																	MaxLength="50"></asp:textbox>
																Tanggal
																<asp:textbox onkeypress="return numbersonly()" id="TXT_AB_IJINDATEDAY" Columns="2" Runat="server"
																	MaxLength="2"></asp:textbox>
																<asp:DropDownList Runat="server" ID="DDL_AB_IJINDATEMONTH"></asp:DropDownList>
																<asp:textbox onkeypress="return numbersonly()" id="TXT_AB_IJINDATEYEAR" Columns="4" Runat="server"
																	MaxLength="4"></asp:textbox>
															</TD>
														</tr>
														<tr>
															<TD class="TDBGColor1">Dibuat Tahun</TD>
															<TD></TD>
															<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_AB_THNBUAT" Columns="4" Runat="server"
																	MaxLength="4"></asp:textbox></TD>
														</tr>
														<tr>
															<TD class="TDBGColor1">Pengembang</TD>
															<TD></TD>
															<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_AB_PENGEMBANG" Columns="40" Runat="server"
																	MaxLength="50"></asp:textbox></TD>
														</tr>
													</TABLE>
												</td>
											</tr>
										</TABLE>
									</td>
								</tr>
								<tr>
									<td vAlign="top">2.</td>
									<td>
										<TABLE cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<TD class="TDBGColor1" vAlign="top" width="205">Jenis Bangunan</TD>
												<TD width="15"></TD>
												<TD class="TDBGColorValue" vAlign="top"><asp:dropdownlist id="DDL_AB_JENISBANGUNAN" Runat="server"></asp:dropdownlist></TD>
											</tr>
										</TABLE>
									</td>
								</tr>
								<tr>
									<td vAlign="top">3.</td>
									<td>
										<TABLE cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<TD class="TDBGColor1" vAlign="top" width="205">Penghunian</TD>
												<TD width="15"></TD>
												<TD class="TDBGColorValue" vAlign="top"><asp:dropdownlist id="DDL_AB_PENGUASAAN" Runat="server"></asp:dropdownlist></TD>
												<td>
													<TABLE cellSpacing="0" cellPadding="0" width="100%">
														<tr>
															<TD class="TDBGColor1" vAlign="top">Dengan Kontrak Sewa No.</TD>
															<TD width="15"></TD>
															<TD class="TDBGColorValue" vAlign="top">
																<asp:TextBox id="TXT_AB_KONTRAKNO" Columns="20" MaxLength="30" onKeypress="return kutip_satu()"
																	Runat="server"></asp:TextBox>
															</TD>
															<td width="250">
																<TABLE cellSpacing="0" cellPadding="0" width="100%">
																	<tr>
																		<TD class="TDBGColor1" vAlign="top">Tanggal</TD>
																		<TD width="15"></TD>
																		<TD class="TDBGColorValue" vAlign="top">
																			<asp:TextBox id="TXT_AB_KONTRAKDATEDAY" Columns="2" MaxLength="2" onKeypress="return numbersonly()"
																				Runat="server"></asp:TextBox>
																			<asp:DropDownList id="DDL_AB_KONTRAKDATEMONTH" Runat="server"></asp:DropDownList>
																			<asp:TextBox id="TXT_AB_KONTRAKDATEYEAR" Columns="4" MaxLength="4" onKeypress="return numbersonly()"
																				Runat="server"></asp:TextBox>
																		</TD>
																	</tr>
																</TABLE>
															</td>
														</tr>
														<tr>
															<TD class="TDBGColor1" vAlign="top">Mulai sewa dari tanggal</TD>
															<TD width="15"></TD>
															<TD class="TDBGColorValue" vAlign="top" colspan="2">
																<asp:TextBox id="TXT_AB_RENTSTARTDATEDAY" Columns="2" MaxLength="2" onKeypress="return numbersonly()"
																	Runat="server"></asp:TextBox>
																<asp:DropDownList id="DDL_AB_RENTSTARTDATEMONTH" Runat="server"></asp:DropDownList>
																<asp:TextBox id="TXT_AB_RENTSTARTDATEYEAR" Columns="4" MaxLength="4" onKeypress="return numbersonly()"
																	Runat="server"></asp:TextBox>
																s/d
																<asp:TextBox id="TXT_AB_RENTDUEDATEDAY" Columns="2" MaxLength="2" onKeypress="return numbersonly()"
																	Runat="server"></asp:TextBox>
																<asp:DropDownList id="DDL_AB_RENTDUEDATEMONTH" Runat="server"></asp:DropDownList>
																<asp:TextBox id="TXT_AB_RENTDUEDATEYEAR" Columns="4" MaxLength="4" onKeypress="return numbersonly()"
																	Runat="server"></asp:TextBox>
															</TD>
														</tr>
													</TABLE>
												</td>
											</tr>
										</TABLE>
									</td>
								</tr>
								<tr>
									<td>4.</td>
									<td>
										<TABLE cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<TD class="TDBGColor1" width="205">Pemeliharaan Bangunan</TD>
												<TD width="15"></TD>
												<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_AB_PEMELIHARAANBGN" Runat="server"></asp:dropdownlist></TD>
											</tr>
										</TABLE>
									</td>
								</tr>
								<tr>
									<td vAlign="top">5.</td>
									<td vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<TD vAlign="top" width="205">Kwalitas Bangunan</TD>
												<td vAlign="top">
													<table cellSpacing="0" cellPadding="0" width="100%">
														<tr>
															<td class="TDBGColor1" width="200">a. Kontruksi</td>
															<td width="15"></td>
															<td class="TDBGColorValue"><asp:dropdownlist id="DDL_AB_KONTRUKSI" Runat="server" onChange="HitungSM()"></asp:dropdownlist></td>
														</tr>
														<tr>
															<td class="TDBGColor1" width="200">b. Kayu</td>
															<td width="15"></td>
															<td class="TDBGColorValue"><asp:dropdownlist id="DDL_AB_KAYU" Runat="server" onChange="HitungSM()"></asp:dropdownlist></td>
														</tr>
														<tr>
															<td class="TDBGColor1" width="200">c. Lantai</td>
															<td width="15"></td>
															<td class="TDBGColorValue"><asp:dropdownlist id="DDL_AB_LANTAI" Runat="server" onChange="HitungSM()"></asp:dropdownlist></td>
														</tr>
														<tr>
															<td class="TDBGColor1" width="200">d. Kondisi</td>
															<td width="15"></td>
															<td class="TDBGColorValue"><asp:dropdownlist id="DDL_AB_KONDISI" Runat="server" onChange="HitungSM()"></asp:dropdownlist></td>
														</tr>
														<tr>
															<td class="TDBGColor1">e. Umur bangunan</td>
															<td></td>
															<td class="TDBGColorValue"><asp:dropdownlist id="DDL_AB_UMUR" Runat="server" onChange="HitungSM()"></asp:dropdownlist>Tahun</td>
														</tr>
													</table>
												</td>
											</tr>
										</TABLE>
									</td>
								</tr>
								<tr>
									<td vAlign="top">6.</td>
									<td vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<TD vAlign="top" width="205">Prasarana</TD>
												<TD width="15"></TD>
												<TD class="TDBGColorValue" vAlign="top"><asp:checkbox id="CHB_AB_LISTRIK" Runat="server" Text="Listrik"></asp:checkbox><asp:textbox onkeypress="return numbersonly()" id="TXT_AB_KETLISTRIK" Columns="10" Runat="server"
														CssClass="angka" MaxLength="10"></asp:textbox>Watt
												</TD>
											</tr>
											<tr>
												<td></td>
												<td></td>
												<TD class="TDBGColorValue"><asp:checkbox id="CHB_AB_AC" Runat="server" Text="AC"></asp:checkbox><asp:textbox onkeypress="return numbersonly()" id="TXT_AB_KETAC" Columns="10" Runat="server"
														CssClass="angka" MaxLength="10"></asp:textbox>Unit</TD>
											</tr>
											<tr>
												<td></td>
												<td></td>
												<TD class="TDBGColorValue"><asp:checkbox id="CHB_AB_AIR" Runat="server" Text="Air PAM/Non PAM"></asp:checkbox><asp:textbox onkeypress="return kutip_satu()" id="TXT_AB_KETAIR" Columns="10" Runat="server"
														MaxLength="10"></asp:textbox></TD>
											</tr>
											<tr>
												<td></td>
												<td></td>
												<TD class="TDBGColorValue"><asp:checkbox id="CHB_AB_TELPFAX" Runat="server" Text="Telepon/Fax"></asp:checkbox><asp:textbox onkeypress="return numbersonly()" id="TXT_AB_KETTELPFAX" Columns="10" Runat="server"
														CssClass="angka" MaxLength="10"></asp:textbox>Saluran</TD>
											</tr>
											<tr>
												<td></td>
												<td></td>
												<TD class="TDBGColorValue"><asp:checkbox id="CHB_AB_PRASARANALAIN" Runat="server" Text="Lainnya"></asp:checkbox><asp:textbox onkeypress="return kutip_satu()" id="TXT_AB_KETPRASARANALAIN" Columns="10" Runat="server"
														MaxLength="10">Watt</asp:textbox></TD>
											</tr>
										</TABLE>
									</td>
								</tr>
								<tr>
									<td vAlign="top">7.</td>
									<td>
										<TABLE cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<td vAlign="top">
													<TABLE cellSpacing="0" cellPadding="0" width="100%">
														<tr>
															<TD class="TDBGColor1" width="205">Asuransi</TD>
															<TD width="15"></TD>
															<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_AB_INSRSTATUS" Runat="server"></asp:dropdownlist></TD>
														</tr>
													</TABLE>
												</td>
												<td vAlign="top">
													<TABLE cellSpacing="0" cellPadding="0" width="100%">
														<tr>
															<TD class="TDBGColor1" width="200">Ditutup Asuransi</TD>
															<TD width="15"></TD>
															<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_AB_INSRTUTUP" Columns="25" Runat="server"
																	MaxLength="21"></asp:textbox></TD>
														</tr>
														<tr>
															<TD class="TDBGColor1">Nilai</TD>
															<TD></TD>
															<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_AB_INSRAMOUNT" Columns="25" Runat="server"
																	CssClass="angka" MaxLength="21"></asp:textbox></TD>
														</tr>
														<tr>
															<TD class="TDBGColor1">Masa laku s/d</TD>
															<TD></TD>
															<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_AB_INSREXPDATEDAY" Columns="2" Runat="server"
																	CssClass="angka" MaxLength="2"></asp:textbox><asp:dropdownlist id="DDL_AB_INSREXPDATEMONTH" Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_AB_INSREXPDATEYEAR" Columns="4" Runat="server"
																	CssClass="angka" MaxLength="4"></asp:textbox></TD>
														</tr>
														<tr>
															<TD class="TDBGColor1">Nama Perusahaan</TD>
															<TD></TD>
															<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_AB_INSRCOMP" Columns="25" Runat="server"
																	MaxLength="50"></asp:textbox></TD>
														</tr>
													</TABLE>
												</td>
											</tr>
										</TABLE>
									</td>
								</tr>
								<tr>
									<td vAlign="top">8.</td>
									<td vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<TD vAlign="top" width="205">Harga Taksiran</TD>
												<td vAlign="top">
													<table cellSpacing="0" cellPadding="0" width="100%">
														<tr>
															<td class="TDBGColor1">Nilai rata-rata harga bangunan yang diterbitkan oleh 
																departemen PU/Instansi Yang Berwenang <font style="FONT-SIZE: 9px"><b>(Bila tidak ada 
																		harap diisi "0")</b></font>
															</td>
															<td width="15"></td>
															<td class="TDBGColorValue" width="250"><asp:textbox onkeypress="return digitsonly()" id="TXT_AB_HRGINSTANSI" Columns="25" Runat="server"
																	CssClass="angka" MaxLength="21"></asp:textbox>/m2</td>
														</tr>
														<tr>
															<td class="TDBGColor1">Harga Jual Bangunan 
																Developer/Kontraktor/Pemborong/Masyarakat</td>
															<td></td>
															<td class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_AB_HRGPENGEMBANG" Columns="25" Runat="server"
																	CssClass="angka" MaxLength="21"></asp:textbox>/m2</td>
														</tr>
														<tr>
															<td class="TDBGColor1">Harga Jual NJOP</td>
															<td></td>
															<td class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_AB_HRGNJOP" Columns="25" Runat="server"
																	CssClass="angka" MaxLength="21"></asp:textbox>/m2</td>
														</tr>
														<tr>
															<td class="TDBGColor1"><b>Harga Taksasi Bangunan adalah</b></td>
															<td></td>
															<td class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_AB_HRGTAKSASIPERM2" style="text-weight: bold"
																	Columns="25" Runat="server" CssClass="angka" MaxLength="21" ReadOnly></asp:textbox><b>/m2</b></td>
														</tr>
														<tr>
															<td class="TDBGColor1"><b>Harga Taksasi Bangunan adalah</b></td>
															<td></td>
															<td class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_AB_HRGTAKSASI" style="text-weight: bold"
																	Columns="25" Runat="server" CssClass="angka" MaxLength="21" ReadOnly></asp:textbox></td>
														</tr>
														<tr>
															<td class="TDBGColor1"><b>Safety Margin</b></td>
															<td></td>
															<td class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_AB_SFTYMARGIN" style="text-weight: bold"
																	Columns="5" Runat="server" CssClass="angka" MaxLength="6" ReadOnly></asp:textbox>%</td>
														</tr>
														<tr>
															<td class="TDBGColor1"><b>Harga Taksasi Bangunan setelah Safety Margin</b></td>
															<td></td>
															<td class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_AB_TAKSASISTLHSMARGINPERM2" style="text-weight: bold"
																	Columns="25" Runat="server" CssClass="angka" MaxLength="21" ReadOnly></asp:textbox><b>/m2</b></td>
														</tr>
														<tr>
															<td class="TDBGColor1"><b>Harga Taksasi Bangunan setelah SM Keseluruhan</b></td>
															<td></td>
															<td class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_AB_TAKSASISTLHSMARGIN" style="text-weight: bold"
																	Columns="25" Runat="server" CssClass="angka" MaxLength="21" ReadOnly></asp:textbox></td>
														</tr>
													</table>
												</td>
											</tr>
										</TABLE>
									</td>
								</tr>
								<tr>
									<td vAlign="top">9.</td>
									<td>
										<table cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<td class="TDBGColor1" width="205">Gambar lokasi dan foto terlampir</td>
												<td width="15"></td>
												<td class="TDBGColorValue"><asp:dropdownlist id="DDL_AB_FOTO" Runat="server"></asp:dropdownlist></td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td vAlign="top">10.</td>
									<td>
										<table cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<td class="TDBGColor1" valign="top" width="205">Keterangan lain tentang<br>
													bangunan yang bersangkutan</td>
												<td width="15"></td>
												<td class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_AB_KETJAMINAN" Columns="40" Runat="server"
														MaxLength="100" Height="50" Rows="4" TextMode="MultiLine"></asp:textbox></td>
											</tr>
										</table>
									</td>
								</tr>
							</TABLE>
						</TD>
					</TR>
					<tr>
						<td align="center"><input class="button1" onclick="document.Form1.V_STA.value=1; return cek_mandatory(document.Form1)"
								type="button" value="save">&nbsp; <input class="button1" onclick="document.Form1.V_STA.value=2; return cek_mandatory(document.Form1)"
								type="button" value="update">&nbsp; <input type="hidden" name="V_STA">
							<asp:label id="LBL_REGNO" Runat="server" Visible="False"></asp:label><asp:label id="LBL_CUREF" Runat="server" Visible="False"></asp:label><asp:label id="LBL_TC" Runat="server" Visible="False"></asp:label><asp:label id="LBL_CL_SEQ" Runat="server" Visible="False"></asp:label><asp:label id="LBL_STA" Runat="server" Visible="False"></asp:label></td>
					</tr>
				</TABLE>
			</center>
		</form>
		<script language="vbscript">
			function HitungSM()
				setlocale(1033)
				set frm = document.Form1
				v_AB_LUASTNH	= num(frm.TXT_AB_LUASTNH.value)
				v_AB_LUASBANGUN	= num(frm.TXT_AB_LUASBANGUN.value)
				v_AB_KONTRUKSI	= num(frm.DDL_AB_KONTRUKSI.value)
				v_AB_KAYU		= num(frm.DDL_AB_KAYU.value)
				v_AB_LANTAI		= num(frm.DDL_AB_LANTAI.value)
				v_AB_KONDISI	= num(frm.DDL_AB_KONDISI.value)
				v_AB_UMUR		= num(frm.DDL_AB_UMUR.value)
				v_AB_HRGINSTANSI	= num(frm.TXT_AB_HRGINSTANSI.value)
				v_AB_HRGPENGEMBANG	= num(frm.TXT_AB_HRGPENGEMBANG.value)
				v_AB_HRGNJOP		= num(frm.TXT_AB_HRGNJOP.value)
								
				v_kwalitas = v_AB_KONTRUKSI + v_AB_KAYU + v_AB_LANTAI + v_AB_KONDISI + v_AB_UMUR
				if v_kwalitas < 7 then
					v_AB_SFTYMARGIN = 15
				elseif v_kwalitas = 7 then
					v_AB_SFTYMARGIN = 20
				elseif v_kwalitas = 8 then
					v_AB_SFTYMARGIN = 25
				elseif v_kwalitas = 9 then
					v_AB_SFTYMARGIN = 30
				elseif v_kwalitas = 10 then
					v_AB_SFTYMARGIN = 35
				elseif v_kwalitas = 11 then
					v_AB_SFTYMARGIN = 40
				elseif v_kwalitas = 12 then
					v_AB_SFTYMARGIN = 45
				else
					v_AB_SFTYMARGIN = 50
				end if
				
				frm.TXT_AB_SFTYMARGIN.value = v_AB_SFTYMARGIN

				v_AB_HRGTAKSASIPERM2 = 0 + (v_AB_HRGNJOP * 0.3)
				frm.TXT_AB_HRGTAKSASIPERM2.value = v_AB_HRGTAKSASIPERM2
				v_AB_HRGTAKSASI = round(v_AB_HRGTAKSASIPERM2 * v_AB_LUASBANGUN, 0)
				frm.TXT_AB_HRGTAKSASI.value = v_AB_HRGTAKSASI
				
				frm.TXT_AB_TAKSASISTLHSMARGINPERM2.value = v_AB_TAKSASISTLHSMARGINPERM2
				v_AB_TAKSASISTLHSMARGIN = round(v_AB_TAKSASISTLHSMARGINPERM2 * v_AB_HRGTAKSASI, 0)
				frm.TXT_AB_TAKSASISTLHSMARGIN.value = v_AB_TAKSASISTLHSMARGIN
				
				curr(frm.TXT_AB_HRGTAKSASIPERM2)
				curr(frm.TXT_AB_HRGTAKSASI)
				curr(frm.TXT_AB_TAKSASISTLHSMARGINPERM2)
				curr(frm.TXT_AB_TAKSASISTLHSMARGIN)
			end function
		</script>
	</body>
</HTML>
