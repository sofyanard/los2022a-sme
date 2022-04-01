<%@ Page language="c#" Codebehind="SiteVisit2.aspx.cs" AutoEventWireup="True" Inherits="SME.CEA.SiteVisit2" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SiteVisit2</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include  file="../include/cek_all.html" -->
		<script language="javascript">
		  function fillText(sTXT)
		  {
		    objTXT = eval('document.Form1.TXT_' + sTXT)
		    objDDL = eval('document.Form1.DDL_' + sTXT)
		    objTXT.value = objDDL.options[objDDL.selectedIndex].text;
		  }
		</script>
		</SCRIPT>
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder">
							<TABLE id="Table8">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Verification - Site Visit</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="Imagebutton1" runat="server" ImageUrl="/SME/Image/back.jpg"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:hyperlink id="HL_ACCOUNT" runat="server" Visible="False" NavigateUrl="Main.aspx">Main</asp:hyperlink><asp:hyperlink id="Hyperlink1" runat="server" Visible="False" NavigateUrl="DTBO\ListDTBO.aspx">BI Checking Result Entry</asp:hyperlink><asp:hyperlink id="Hyperlink2" runat="server" Visible="False" NavigateUrl="InfoPerusahaan.aspx">Site Visit</asp:hyperlink><asp:hyperlink id="Hyperlink4" runat="server" Visible="False" NavigateUrl="TenagaAhli.aspx"> Interview</asp:hyperlink></TD>
					</TR>
					<TR>
						<TD class="td" width="100%" colSpan="2">
							<table id="FORMAT_H" width="100%" runat="server">
								<!-- -------- rating qualitative new ----------------->
								<TR>
									<TD class="td" colSpan="2">
										<table width="100%">
											<tr>
												<td class="tdHeader1" width="100%" colSpan="2">Laporan Hasil Kunjungan</td>
											</tr>
											<TR>
												<TD class="td" style="WIDTH: 675px" vAlign="top" width="675">
													<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
														<TR>
															<TD class="TDBGColor1" style="WIDTH: 129px">Tanggal Kunjungan</TD>
															<TD style="WIDTH: 15px">:</TD>
															<TD class="TDBGColorValue">
																<asp:textbox onkeypress="return numbersonly()" id="cu_comberdiriday" runat="server" MaxLength="2"
																	Columns="2"></asp:textbox>
																<asp:dropdownlist id="cu_comberdirimonth" runat="server"></asp:dropdownlist>
																<asp:textbox onkeypress="return numbersonly()" id="cu_comberdiriyear" runat="server" MaxLength="4"
																	Columns="4"></asp:textbox></TD>
														</TR>
														<TR>
															<TD class="TDBGColor1">Dilaksanakan Oleh</TD>
															<TD style="WIDTH: 15px">:</TD>
															<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_REF" runat="server" Width="300px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
														</TR>
														<TR>
															<TD class="TDBGColor1"></TD>
															<TD style="WIDTH: 15px">:</TD>
															<TD class="TDBGColorValue"><asp:textbox id="TXT_AP_SIGNDATE" runat="server" Width="300px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
														</TR>
													</TABLE>
													<asp:label id="LBL_CU_CUSTTYPEID" runat="server" Visible="False"></asp:label><asp:label id="LBL_AP_PROG_CODE" runat="server" Visible="False"></asp:label></TD>
												<TD class="td" vAlign="top" width="50%">
													<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
														<TR>
															<TD class="TDBGColor1" width="150">Diterima Oleh</TD>
															<TD style="WIDTH: 15px">:</TD>
															<TD class="TDBGColorValue"><asp:textbox id="TXT_NAME" runat="server" Width="300px" ReadOnly="True"></asp:textbox></TD>
														</TR>
														<TR>
															<TD class="TDBGColor1"></TD>
															<TD style="WIDTH: 15px"></TD>
															<TD class="TDBGColorValue"><asp:textbox id="TXT_ADDRESS1" runat="server" Width="300px" ReadOnly="True"></asp:textbox></TD>
														</TR>
														<!--<TR>
										<TD class="TDBGColor1">Nama Analis</TD>
										<TD>:</TD>
										<TD class="TDBGColorValue"><asp:textbox id="Textbox2" runat="server" Width="175px" ReadOnly="True"></asp:textbox></TD>
									</TR>--></TABLE>
												</TD>
											</TR>
										</table>
								<tr>
									<td class="tdHeader1" style="HEIGHT: 2px" width="100%" colSpan="2"></td>
								</tr>
							</table>
							<TABLE style="WIDTH: 1200px; HEIGHT: 174px">
								<TR>
									<TD class="td" style="WIDTH: 675px" vAlign="top" width="675">
										<TABLE id="Table2" style="WIDTH: 1192px; HEIGHT: 153px" cellSpacing="0" cellPadding="0"
											width="1192" runat="server">
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 251px; HEIGHT: 19px" width="251">Nama Calon 
													Rekanan</TD>
												<TD style="WIDTH: 15px; HEIGHT: 19px"></TD>
												<TD class="TDBGColorValue" style="HEIGHT: 19px">
													<asp:textbox onkeypress="return kutip_satu()" id="Textbox11" runat="server" Width="576px" MaxLength="100"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 251px" width="251">Alamat</TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue">
													<asp:textbox onkeypress="return kutip_satu()" id="Textbox12" runat="server" Width="576px" MaxLength="100"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 251px" width="251">No Telp</TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue">
													<asp:textbox onkeypress="return kutip_satu()" id="Textbox13" runat="server" Width="576px" MaxLength="100"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 251px">No Fax</TD>
												<TD></TD>
												<TD class="TDBGColorValue">
													<asp:textbox onkeypress="return kutip_satu()" id="Textbox14" runat="server" Width="576px" MaxLength="100"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 251px; HEIGHT: 20px">Contact Person</TD>
												<TD style="HEIGHT: 20px"></TD>
												<TD class="TDBGColorValue" style="HEIGHT: 20px">
													<asp:textbox onkeypress="return kutip_satu()" id="Textbox15" runat="server" Width="296px" MaxLength="100"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 251px">Luas Bangunan Tempat Usaha</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="cu_npwp" runat="server" Width="48px" MaxLength="25"></asp:textbox>m2</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 251px">Status Kepemilikan Tempat Usaha</TD>
												<TD></TD>
												<TD class="TDBGColorValue">
													<P><asp:textbox onkeypress="return kutip_satu()" id="cu_ket" runat="server" Width="300px" MaxLength="100"></asp:textbox></P>
												</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 251px; HEIGHT: 21px">Cabang/Perwakilan</TD>
												<TD style="HEIGHT: 21px"></TD>
												<TD class="TDBGColorValue" style="HEIGHT: 21px">
													<asp:dropdownlist id="cu_jenis" runat="server"></asp:dropdownlist>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
													Jumlah
													<asp:textbox onkeypress="return kutip_satu()" id="Textbox1" runat="server" Width="48px" MaxLength="25"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 251px; HEIGHT: 22px">Jumlah Tenaga Kerja</TD>
												<TD style="HEIGHT: 22px"></TD>
												<TD class="TDBGColorValue" style="HEIGHT: 22px">
													<asp:textbox onkeypress="return kutip_satu()" id="Textbox2" runat="server" Width="48px" MaxLength="25"></asp:textbox>&nbsp;Orang&nbsp;&nbsp;&nbsp;
												</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 251px"></TD>
												<TD></TD>
												<TD class="TDBGColorValue">
													<asp:textbox onkeypress="return kutip_satu()" id="Textbox3" runat="server" Width="48px" MaxLength="25"></asp:textbox>&nbsp;Tenaga 
													Ahli&nbsp;&nbsp;&nbsp;&nbsp;
													<asp:textbox onkeypress="return kutip_satu()" id="Textbox4" runat="server" Width="48px" MaxLength="25"></asp:textbox>&nbsp;Tenaga 
													Administrasi&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
													<asp:textbox onkeypress="return kutip_satu()" id="Textbox5" runat="server" Width="48px" MaxLength="25"></asp:textbox>Tenaga 
													tidak tetap</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 251px">Peralatan Kantor</TD>
												<TD></TD>
												<TD class="TDBGColorValue">
													<asp:radiobutton id="OPT_LMP2_FORMAT_D" runat="server" Text="Memadai" GroupName="OPT_LMP_D"></asp:radiobutton>&nbsp;&nbsp;&nbsp;&nbsp;
													<asp:radiobutton id="OPT_LMP1_FORMAT_D" runat="server" Text="Tidak Memadai" GroupName="OPT_LMP_D"
														Checked="True"></asp:radiobutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Keterangan 
													&nbsp;
													<asp:textbox onkeypress="return kutip_satu()" id="Textbox6" runat="server" Width="300px" MaxLength="100"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 251px">Sistem Database yang Dimiliki</TD>
												<TD></TD>
												<TD class="TDBGColorValue">
													<asp:radiobutton id="Radiobutton2" runat="server" Text="Memadai" GroupName="OPT_LMP_D"></asp:radiobutton>&nbsp;&nbsp;&nbsp;&nbsp;
													<asp:radiobutton id="Radiobutton1" runat="server" Text="Tidak Memadai" GroupName="OPT_LMP_D" Checked="True"></asp:radiobutton>&nbsp;&nbsp;&nbsp;&nbsp; 
													Keterangan&nbsp;&nbsp;
													<asp:textbox onkeypress="return kutip_satu()" id="Textbox7" runat="server" Width="300px" MaxLength="100"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 251px; HEIGHT: 21px">Kondisi Gedung</TD>
												<TD style="HEIGHT: 21px"></TD>
												<TD class="TDBGColorValue" style="HEIGHT: 21px">
													<asp:radiobutton id="Radiobutton4" runat="server" Text="Baik" GroupName="OPT_LMP_D"></asp:radiobutton>&nbsp;&nbsp;&nbsp;&nbsp;
													<asp:radiobutton id="Radiobutton3" runat="server" Text="Cukup" GroupName="OPT_LMP_D" Checked="True"></asp:radiobutton>&nbsp;&nbsp;&nbsp;
													<asp:radiobutton id="Radiobutton5" runat="server" Text="Kurang" GroupName="OPT_LMP_D" Checked="True"></asp:radiobutton>&nbsp;&nbsp;&nbsp; 
													Keterangan&nbsp;&nbsp;
													<asp:textbox onkeypress="return kutip_satu()" id="Textbox8" runat="server" Width="300px" MaxLength="100"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 251px; HEIGHT: 25px">Kondisi Ruang Arsip</TD>
												<TD style="HEIGHT: 25px"></TD>
												<TD class="TDBGColorValue" style="HEIGHT: 25px">
													<asp:radiobutton id="Radiobutton8" runat="server" Text="Baik" GroupName="OPT_LMP_D"></asp:radiobutton>&nbsp;&nbsp;&nbsp;&nbsp;
													<asp:radiobutton id="Radiobutton7" runat="server" Text="Cukup" GroupName="OPT_LMP_D" Checked="True"></asp:radiobutton>&nbsp;&nbsp;&nbsp;
													<asp:radiobutton id="Radiobutton6" runat="server" Text="Kurang" GroupName="OPT_LMP_D" Checked="True"></asp:radiobutton>&nbsp;&nbsp;&nbsp; 
													Keterangan&nbsp;&nbsp;
													<asp:textbox onkeypress="return kutip_satu()" id="Textbox9" runat="server" Width="300px" MaxLength="100"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 251px">Kegiatan yang Sedang dilakukan</TD>
												<TD></TD>
												<TD class="TDBGColorValue">
													<asp:textbox onkeypress="return kutip_satu()" id="Textbox10" runat="server" Width="592px" MaxLength="100"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 251px"></TD>
												<TD></TD>
												<TD class="TDBGColorValue"></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 251px">Kesimpulan/Pendapat</TD>
												<TD>:</TD>
												<TD class="TDBGColorValue"></TD>
											</TR> <!-- Additional Field : Right --></TABLE>
									</TD>
								</TR>
								<TR align="center">
									<TD class="td" align="center">
										<TABLE id="Table1" align="center" style="WIDTH: 1056px; HEIGHT: 177px" cellSpacing="1"
											cellPadding="1" width="1056" border="1">
											<TR>
												<TD align="center" bgcolor="#ffff00" style="WIDTH: 344px"><STRONG>Materi</STRONG></TD>
												<TD align="center" bgcolor="#ffff00" style="WIDTH: 132px"><STRONG>Bobot (%)</STRONG></TD>
												<TD align="center" bgcolor="#ffff00" style="WIDTH: 105px"><STRONG>1</STRONG></TD>
												<TD align="center" bgcolor="#ffff00" style="WIDTH: 106px"><STRONG>2</STRONG></TD>
												<TD align="center" bgcolor="#ffff00" style="WIDTH: 108px"><STRONG>3</STRONG></TD>
												<TD align="center" bgcolor="#ffff00" style="WIDTH: 109px"><STRONG>4</STRONG></TD>
												<TD align="center" bgcolor="#ffff00" style="WIDTH: 124px"><STRONG>5</STRONG></TD>
												<TD bgcolor="#ffff00" align="center"><STRONG>Total</STRONG></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 344px">a. Kesesuaian Alamat</TD>
												<TD align="center" style="WIDTH: 132px">10</TD>
												<TD style="WIDTH: 105px">
													<asp:RadioButton id="RadioButton9" align="center" runat="server"></asp:RadioButton></TD>
												<TD style="WIDTH: 106px">
													<asp:RadioButton id="RadioButton10" align="center" runat="server"></asp:RadioButton></TD>
												<TD style="WIDTH: 108px">
													<asp:RadioButton id="RadioButton11" align="center" runat="server"></asp:RadioButton></TD>
												<TD style="WIDTH: 109px">
													<asp:RadioButton id="RadioButton12" align="center" runat="server"></asp:RadioButton></TD>
												<TD style="WIDTH: 124px">
													<asp:RadioButton id="RadioButton13" align="center" runat="server"></asp:RadioButton></TD>
												<TD>
													<asp:Label id="Label1" align="center" runat="server" Width="48px">Label</asp:Label></TD>
											</TR>
											<TR>
												<TD bgcolor="#ffff99" style="WIDTH: 344px">b. Kelayakan sarana &amp; prasarana</TD>
												<TD align="center" bgcolor="#ffff99" style="WIDTH: 132px">20</TD>
												<TD bgcolor="#ffff99" style="WIDTH: 105px">
													<asp:RadioButton id="RadioButton14" align="center" runat="server"></asp:RadioButton></TD>
												<TD bgcolor="#ffff99" style="WIDTH: 106px">
													<asp:RadioButton id="RadioButton15" align="center" runat="server"></asp:RadioButton></TD>
												<TD bgcolor="#ffff99" style="WIDTH: 108px">
													<asp:RadioButton id="RadioButton16" align="center" runat="server"></asp:RadioButton></TD>
												<TD bgcolor="#ffff99" style="WIDTH: 109px">
													<asp:RadioButton id="RadioButton17" align="center" runat="server"></asp:RadioButton></TD>
												<TD bgcolor="#ffff99" style="WIDTH: 124px">
													<asp:RadioButton id="RadioButton18" align="center" runat="server"></asp:RadioButton></TD>
												<TD bgcolor="#ffff99">
													<asp:Label id="Label2" runat="server" Width="48px">Label</asp:Label></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 344px">c. Kelayakan data base</TD>
												<TD align="center" style="WIDTH: 132px">15</TD>
												<TD style="WIDTH: 105px">
													<asp:RadioButton id="RadioButton19" align="center" runat="server"></asp:RadioButton></TD>
												<TD style="WIDTH: 106px">
													<asp:RadioButton id="RadioButton23" align="center" runat="server"></asp:RadioButton></TD>
												<TD style="WIDTH: 108px">
													<asp:RadioButton id="RadioButton27" align="center" runat="server"></asp:RadioButton></TD>
												<TD style="WIDTH: 109px">
													<asp:RadioButton id="RadioButton31" align="center" runat="server"></asp:RadioButton></TD>
												<TD style="WIDTH: 124px">
													<asp:RadioButton id="RadioButton35" align="center" runat="server"></asp:RadioButton></TD>
												<TD>
													<asp:Label id="Label3" align="center" runat="server" Width="48px">Label</asp:Label></TD>
											</TR>
											<TR>
												<TD bgcolor="#ffff99" style="WIDTH: 344px; HEIGHT: 37px">d. Kelayakan ruang arsip, 
													sistem penataan arsip</TD>
												<TD align="center" bgcolor="#ffff99" style="WIDTH: 132px; HEIGHT: 37px">15</TD>
												<TD bgcolor="#ffff99" style="WIDTH: 105px; HEIGHT: 37px">
													<asp:RadioButton id="RadioButton20" align="center" runat="server"></asp:RadioButton></TD>
												<TD bgcolor="#ffff99" style="WIDTH: 106px; HEIGHT: 37px">
													<asp:RadioButton id="RadioButton24" align="center" runat="server"></asp:RadioButton></TD>
												<TD bgcolor="#ffff99" style="WIDTH: 108px; HEIGHT: 37px">
													<asp:RadioButton id="RadioButton28" align="center" runat="server"></asp:RadioButton></TD>
												<TD bgcolor="#ffff99" style="WIDTH: 109px; HEIGHT: 37px">
													<asp:RadioButton id="RadioButton32" align="center" runat="server"></asp:RadioButton></TD>
												<TD bgcolor="#ffff99" style="WIDTH: 124px; HEIGHT: 37px">
													<asp:RadioButton id="RadioButton36" align="center" runat="server"></asp:RadioButton></TD>
												<TD bgcolor="#ffff99" style="HEIGHT: 37px">
													<asp:Label id="Label4" align="center" runat="server" Width="48px">Label</asp:Label></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 344px">e. Kelayakan kondisi gedung</TD>
												<TD align="center" style="WIDTH: 132px">15</TD>
												<TD style="WIDTH: 105px">
													<asp:RadioButton id="RadioButton21" align="center" runat="server"></asp:RadioButton></TD>
												<TD style="WIDTH: 106px">
													<asp:RadioButton id="RadioButton25" align="center" runat="server"></asp:RadioButton></TD>
												<TD style="WIDTH: 108px">
													<asp:RadioButton id="RadioButton29" align="center" runat="server"></asp:RadioButton></TD>
												<TD style="WIDTH: 109px">
													<asp:RadioButton id="RadioButton33" align="center" runat="server"></asp:RadioButton></TD>
												<TD style="WIDTH: 124px">
													<asp:RadioButton id="RadioButton37" align="center" runat="server"></asp:RadioButton></TD>
												<TD>
													<asp:Label id="Label5" align="center" runat="server" Width="48px">Label</asp:Label></TD>
											</TR>
											<TR>
												<TD bgcolor="#ffff99" style="WIDTH: 344px">f. Kelayakan jumlah tenaga kerja</TD>
												<TD align="center" bgcolor="#ffff99" style="WIDTH: 132px">25</TD>
												<TD bgcolor="#ffff99" style="WIDTH: 105px">
													<asp:RadioButton id="RadioButton22" align="center" runat="server"></asp:RadioButton></TD>
												<TD bgcolor="#ffff99" style="WIDTH: 106px">
													<asp:RadioButton id="RadioButton26" align="center" runat="server"></asp:RadioButton></TD>
												<TD bgcolor="#ffff99" style="WIDTH: 108px">
													<asp:RadioButton id="RadioButton30" align="center" runat="server"></asp:RadioButton></TD>
												<TD bgcolor="#ffff99" style="WIDTH: 109px">
													<asp:RadioButton id="RadioButton34" align="center" runat="server"></asp:RadioButton></TD>
												<TD bgcolor="#ffff99" style="WIDTH: 124px">
													<asp:RadioButton id="RadioButton38" align="center" runat="server"></asp:RadioButton></TD>
												<TD bgcolor="#ffff99">
													<asp:Label id="Label6" align="center" runat="server" Width="48px">Label</asp:Label></TD>
											</TR>
											<TR>
												<TD align="center" style="WIDTH: 344px"><STRONG>TOTAL</STRONG></TD>
												<TD align="center" style="WIDTH: 132px">100</TD>
												<TD style="WIDTH: 568px" colSpan="5"></TD>
												<TD>
													<asp:Label id="Label7" runat="server" Width="48px">Label</asp:Label></TD>
											</TR>
										</TABLE>
										<P>Pembobotan : 1 = Kurang Sekali&nbsp;&nbsp; 2 = Kurang&nbsp;&nbsp; 3 = 
											Sedang&nbsp;&nbsp; 4 = Baik&nbsp;&nbsp; 5 = Baik Sekali</P>
									</TD>
								</TR>
							</TABLE>
					<TR width="100%">
						<TD colSpan="2"></TD>
					</TR>
					<tr>
						<td class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2"><asp:button id="BTN_SAVEQUAL" runat="server" CssClass="Button1" Text="Save"></asp:button>&nbsp;&nbsp;&nbsp;
							<asp:button id="Button1" runat="server" CssClass="Button1" Text="Clear"></asp:button>&nbsp;&nbsp;
							<asp:button id="Button2" runat="server" CssClass="Button1" Text="Print"></asp:button></td>
					</tr>
					<tr>
						<td class="td" align="center" colSpan="2"></td>
					</tr>
					<tr>
						<td class="td" colSpan="2">
							<table width="100%">
								<tr>
									<TD class="TDBGColor1" width="20%">
										Total Score</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue" width="30%"><asp:label id="LBL_QSCORE" runat="server"></asp:label></TD>
									<TD class="TDBGColor1" width="20%">Qualitative Recommendation</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue" width="30%"><asp:label id="LBL_QREC" runat="server"></asp:label></TD>
								</tr>
							</table>
						</td>
					</tr>
				</TABLE>
			</TD></TR></TABLE></TD></TR></form>
		</TBODY></TABLE></CENTER>
	</body>
</HTML>
