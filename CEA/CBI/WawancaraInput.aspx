<%@ Page language="c#" Codebehind="WawancaraInput.aspx.cs" AutoEventWireup="True" Inherits="SME.CEA.CBI.WawancaraInput" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>WawancaraInput</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../../include/cek_mandatory.html" -->
		<!-- #include file="../../include/cek_entries.html" -->
		<!-- #include file="../../include/popup.html" -->
		<!-- #include file="../../include/cek_all.html" -->
		<!-- #include file="../../include/onepost.html" -->
		<!-- #include file="../../include/ConfirmBox.html" -->
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
				<TABLE id="Table13" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder" style="WIDTH: 1021px">
							<TABLE id="Table8">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Wawancara</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../../Body.aspx"><IMG src="../../Image/MainMenu.jpg"></A><A href="../../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<tr>
						<td class="tdHeader1" colSpan="2">Laporan Hasil Wawancara</td>
					</tr>
					<TR>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="150">Tanggal Wawancara</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_DAY" runat="server" CssClass="Mandatory"
											MaxLength="2" Columns="2"></asp:textbox><asp:dropdownlist id="DDL_IVW_MONTH" runat="server" CssClass="Mandatory"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_YEAR" runat="server" CssClass="Mandatory"
											MaxLength="4" Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Dilaksanakan Oleh</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_DILAKSANAKAN1" runat="server" CssClass="Mandatory" Height="16px" Width="300px"
											BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"></TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_DILAKSANAKAN2" runat="server" Height="16px" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="150">Nama Peserta</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PESERTA1" runat="server" CssClass="Mandatory" Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="150"></TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PESERTA2" runat="server" Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="150"></TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PESERTA3" runat="server" Width="300px"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="td" colSpan="2"><FONT size="2"><STRONG>1. Non Substansi Presentasi :</STRONG></FONT>
						</TD>
					</TR>
					<TR>
						<TD colSpan="2"><ASP:DATAGRID id="DGR_IVW" runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="1"
								AllowPaging="True">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="ID_MATERI" HeaderText="No.">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="REGNUM"></asp:BoundColumn>
									<asp:BoundColumn DataField="DESC_MATERI" HeaderText="Materi">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PERSEN_BOBOT" HeaderText="Bobot (%)">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="NILAI_BOBOT"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="ISCOMPLY"></asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Skala">
										<HeaderStyle Width="10%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:radiobuttonlist id="RBL_IVW" runat="server" RepeatDirection="Horizontal">
												<asp:ListItem Value="1">1</asp:ListItem>
												<asp:ListItem Value="2">2</asp:ListItem>
												<asp:ListItem Value="3">3</asp:ListItem>
												<asp:ListItem Value="4">4</asp:ListItem>
												<asp:ListItem Value="5">5</asp:ListItem>
											</asp:radiobuttonlist>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="SCORE" HeaderText="Total">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
					<TR>
						<TD class="TDBGColor1" colSpan="2"><STRONG>SUB TOTAL SCORE I (Score x 30%)</STRONG>&nbsp;:<asp:textbox id="TXT_SUM" runat="server" Width="320px" ReadOnly="True"></asp:textbox></TD>
					</TR>
					<TR>
						<TD class="td" colSpan="2"><STRONG><FONT size="2">2. Substansi Presentasi</FONT></STRONG></TD>
					</TR>
					<TR align="center">
						<TD class="td" align="center" colSpan="2">
							<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" align="left" border="1">
								<TR>
									<TD style="WIDTH: 36px" align="center" bgColor="#b5c7e7"><STRONG>NO</STRONG></TD>
									<TD style="WIDTH: 344px" align="center" bgColor="#b5c7e7"><STRONG>Materi</STRONG></TD>
									<TD style="WIDTH: 132px" align="center" bgColor="#b5c7e7"><STRONG>Bobot (%)</STRONG></TD>
									<TD style="WIDTH: 105px" align="center" bgColor="#b5c7e7"><STRONG>1</STRONG></TD>
									<TD style="WIDTH: 106px" align="center" bgColor="#b5c7e7"><STRONG>2</STRONG></TD>
									<TD style="WIDTH: 108px" align="center" bgColor="#b5c7e7"><STRONG>3</STRONG></TD>
									<TD style="WIDTH: 109px" align="center" bgColor="#b5c7e7"><STRONG>4</STRONG></TD>
									<TD style="WIDTH: 124px" align="center" bgColor="#b5c7e7"><STRONG>5</STRONG></TD>
									<TD align="center" bgColor="#b5c7e7"><STRONG>Total</STRONG></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 36px">1</TD>
									<TD style="WIDTH: 344px"><SPAN style="FONT-SIZE: 10pt; FONT-FAMILY: 'Arial','sans-serif'; mso-fareast-font-family: 'Times New Roman'; mso-bidi-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA; mso-bidi-font-weight: bold">Pengalaman 
											kerja / keahlian khusus calon rekanan</SPAN></TD>
									<TD style="WIDTH: 132px" align="center">30</TD>
									<TD style="WIDTH: 105px"><asp:radiobutton id="SUB11" runat="server" align="center" GroupName="1" value="1"></asp:radiobutton></TD>
									<TD style="WIDTH: 106px"><asp:radiobutton id="SUB12" runat="server" align="center" GroupName="1" value="2"></asp:radiobutton></TD>
									<TD style="WIDTH: 108px"><asp:radiobutton id="SUB13" runat="server" align="center" GroupName="1" value="3"></asp:radiobutton></TD>
									<TD style="WIDTH: 109px"><asp:radiobutton id="SUB14" runat="server" align="center" GroupName="1" value="4"></asp:radiobutton></TD>
									<TD style="WIDTH: 124px"><asp:radiobutton id="SUB15" runat="server" align="center" GroupName="1" value="5"></asp:radiobutton></TD>
									<TD><asp:textbox id="SUB_TOT1" runat="server" Height="32px" Width="140px" BorderStyle="None" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 36px; HEIGHT: 17px"></TD>
									<TD style="WIDTH: 344px; HEIGHT: 17px">Komentar :</TD>
									<TD style="WIDTH: 132px; HEIGHT: 17px" align="center" colSpan="6"><asp:textbox id="COMENT1" runat="server" Height="43px" Width="700px" TextMode="MultiLine"></asp:textbox></TD>
									<TD style="HEIGHT: 17px"></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 36px">2</TD>
									<TD style="WIDTH: 344px"><SPAN style="FONT-SIZE: 10pt; FONT-FAMILY: 'Arial','sans-serif'; mso-fareast-font-family: 'Times New Roman'; mso-bidi-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA; mso-bidi-font-weight: bold">Kondisi 
											tenaga ahli / tenaga kerja calon rekanan</SPAN></TD>
									<TD style="WIDTH: 132px" align="center">30</TD>
									<TD style="WIDTH: 105px"><asp:radiobutton id="SUB21" runat="server" align="center" GroupName="2" value="1"></asp:radiobutton></TD>
									<TD style="WIDTH: 106px"><asp:radiobutton id="SUB22" runat="server" align="center" GroupName="2" value="2"></asp:radiobutton></TD>
									<TD style="WIDTH: 108px"><asp:radiobutton id="SUB23" runat="server" align="center" GroupName="2" value="3"></asp:radiobutton></TD>
									<TD style="WIDTH: 109px"><asp:radiobutton id="SUB24" runat="server" align="center" GroupName="2" value="4"></asp:radiobutton></TD>
									<TD style="WIDTH: 124px"><asp:radiobutton id="SUB25" runat="server" align="center" GroupName="2" value="5"></asp:radiobutton></TD>
									<TD><asp:textbox id="SUB_TOT2" runat="server" Height="32px" Width="140px" BorderStyle="None" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 36px; HEIGHT: 16px"></TD>
									<TD style="WIDTH: 344px; HEIGHT: 16px">Komentar :</TD>
									<TD style="WIDTH: 132px; HEIGHT: 16px" align="center" colSpan="6"><asp:textbox id="COMENT2" runat="server" Height="43px" Width="700px" TextMode="MultiLine"></asp:textbox></TD>
									<TD style="HEIGHT: 16px"></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 36px">3</TD>
									<TD style="WIDTH: 344px"><SPAN style="FONT-SIZE: 10pt; FONT-FAMILY: 'Arial','sans-serif'; mso-fareast-font-family: 'Times New Roman'; mso-bidi-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA; mso-bidi-font-weight: bold">Pengendalian 
											mutu yang dimiliki oleh calon rekanan</SPAN></TD>
									<TD style="WIDTH: 132px" align="center">20</TD>
									<TD style="WIDTH: 105px"><asp:radiobutton id="SUB31" runat="server" align="center" GroupName="3" value="1"></asp:radiobutton></TD>
									<TD style="WIDTH: 106px"><asp:radiobutton id="SUB32" runat="server" align="center" GroupName="3" value="2"></asp:radiobutton></TD>
									<TD style="WIDTH: 108px"><asp:radiobutton id="SUB33" runat="server" align="center" GroupName="3" value="3"></asp:radiobutton></TD>
									<TD style="WIDTH: 109px"><asp:radiobutton id="SUB34" runat="server" align="center" GroupName="3" value="4"></asp:radiobutton></TD>
									<TD style="WIDTH: 124px"><asp:radiobutton id="SUB35" runat="server" align="center" GroupName="3" value="5"></asp:radiobutton></TD>
									<TD><asp:textbox id="SUB_TOT3" runat="server" Height="32px" Width="140px" BorderStyle="None" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 36px; HEIGHT: 2px"></TD>
									<TD style="WIDTH: 344px; HEIGHT: 2px">Komentar :</TD>
									<TD style="WIDTH: 132px; HEIGHT: 2px" align="center" colSpan="6"><asp:textbox id="COMENT3" runat="server" Height="43px" Width="700px" TextMode="MultiLine"></asp:textbox></TD>
									<TD style="HEIGHT: 2px"></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 36px; HEIGHT: 37px">4</TD>
									<TD style="WIDTH: 344px; HEIGHT: 37px"><SPAN style="FONT-SIZE: 10pt; FONT-FAMILY: 'Arial','sans-serif'; mso-fareast-font-family: 'Times New Roman'; mso-bidi-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA; mso-bidi-font-weight: bold">Daya 
											saing biaya yang dikenakan dalam mengerjakan suatu proyek /pekerjaan 
											dibandingkan dgn perusahaan lain</SPAN></TD>
									<TD style="WIDTH: 132px; HEIGHT: 37px" align="center">10</TD>
									<TD style="WIDTH: 105px; HEIGHT: 37px"><asp:radiobutton id="SUB41" runat="server" align="center" GroupName="4" value="1"></asp:radiobutton></TD>
									<TD style="WIDTH: 106px; HEIGHT: 37px"><asp:radiobutton id="SUB42" runat="server" align="center" GroupName="4" value="2"></asp:radiobutton></TD>
									<TD style="WIDTH: 108px; HEIGHT: 37px"><asp:radiobutton id="SUB43" runat="server" align="center" GroupName="4" value="3"></asp:radiobutton></TD>
									<TD style="WIDTH: 109px; HEIGHT: 37px"><asp:radiobutton id="SUB44" runat="server" align="center" GroupName="4" value="4"></asp:radiobutton></TD>
									<TD style="WIDTH: 124px; HEIGHT: 37px"><asp:radiobutton id="SUB45" runat="server" align="center" GroupName="4" value="5"></asp:radiobutton></TD>
									<TD style="HEIGHT: 37px"><asp:textbox id="SUB_TOT4" runat="server" Height="32px" Width="140px" BorderStyle="None" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 36px; HEIGHT: 12px"></TD>
									<TD style="WIDTH: 344px; HEIGHT: 12px">Komentar :</TD>
									<TD style="WIDTH: 132px; HEIGHT: 12px" align="center" colSpan="6"><asp:textbox id="COMENT4" runat="server" Height="43px" Width="700px" TextMode="MultiLine"></asp:textbox></TD>
									<TD style="HEIGHT: 12px"></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 36px">5</TD>
									<TD style="WIDTH: 344px"><SPAN style="FONT-SIZE: 10pt; FONT-FAMILY: 'Arial','sans-serif'; mso-fareast-font-family: 'Times New Roman'; mso-bidi-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA; mso-bidi-font-weight: bold">Lain-lain 
											(Kerjasama dgn instansi lain, organisasi asing, jaringan kerja)</SPAN></TD>
									<TD style="WIDTH: 132px" align="center">10</TD>
									<TD style="WIDTH: 105px"><asp:radiobutton id="SUB51" runat="server" align="center" GroupName="5" value="1"></asp:radiobutton></TD>
									<TD style="WIDTH: 106px"><asp:radiobutton id="SUB52" runat="server" align="center" GroupName="5" value="2"></asp:radiobutton></TD>
									<TD style="WIDTH: 108px"><asp:radiobutton id="SUB53" runat="server" align="center" GroupName="5" value="3"></asp:radiobutton></TD>
									<TD style="WIDTH: 109px"><asp:radiobutton id="SUB54" runat="server" align="center" GroupName="5" value="4"></asp:radiobutton></TD>
									<TD style="WIDTH: 124px"><asp:radiobutton id="SUB55" runat="server" align="center" GroupName="5" value="5"></asp:radiobutton></TD>
									<TD><asp:textbox id="SUB_TOT5" runat="server" Height="32px" Width="140px" BorderStyle="None" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 36px; HEIGHT: 19px"></TD>
									<TD style="WIDTH: 344px; HEIGHT: 19px">Komentar :</TD>
									<TD style="WIDTH: 132px; HEIGHT: 19px" align="center" colSpan="6"><asp:textbox id="COMENT5" runat="server" Height="43px" Width="700px" TextMode="MultiLine"></asp:textbox></TD>
									<TD style="HEIGHT: 19px"></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 36px; HEIGHT: 44px"></TD>
									<TD style="WIDTH: 344px; HEIGHT: 44px">Catatan Khusus</TD>
									<TD style="WIDTH: 132px; HEIGHT: 44px" align="center" colSpan="6"><asp:textbox id="CAT" runat="server" Height="150px" Width="700px" TextMode="MultiLine"></asp:textbox></TD>
									<TD style="HEIGHT: 44px"><asp:label id="Label6" runat="server" Width="48px" align="center"></asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 36px" align="center"></TD>
									<TD style="WIDTH: 344px" align="center"><STRONG>SUB TOTAL SCORE II (Score x 70%)</STRONG></TD>
									<TD style="WIDTH: 132px" align="center"></TD>
									<TD style="WIDTH: 568px" colSpan="5"></TD>
									<TD><asp:label id="SUB_TOT" runat="server" Width="48px"></asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 36px" align="center"></TD>
									<TD style="WIDTH: 344px" align="center"><STRONG>TOTAL SCORE (Total I + Total II)</STRONG></TD>
									<TD style="WIDTH: 132px" align="center"></TD>
									<TD style="WIDTH: 568px" colSpan="5"></TD>
									<TD><asp:label id="TOT" runat="server" Width="48px"></asp:label></TD>
								</TR>
							</TABLE>
					<TR>
						<td style="WIDTH: 1021px">Pembobotan : 1 = Kurang Sekali&nbsp;&nbsp; 2 = 
							Kurang&nbsp;&nbsp; 3 = Sedang&nbsp;&nbsp; 4 = Baik&nbsp;&nbsp; 5 = Baik Sekali<br>
							Hasil wawancara score &gt; 3 dilanjutkan ketahap selanjutnya<br>
							Hasil wawancara score &lt; 3 tidak dapat ditindaklanjuti ketahap berikutnya
						</td>
					</TR>
					<TR width="100%">
						<TD colSpan="2"></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">Document Upload</TD>
					</TR>
					<tr>
						<TD vAlign="top" width="50%">
							<table cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="75">File</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><INPUT id="TXT_FILE_UPLOAD" type="file" size="30" name="File1" runat="Server"></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Status</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:label id="LBL_STATUS" runat="server" ForeColor="Red"></asp:label><asp:regularexpressionvalidator id="Regularexpressionvalidator1" runat="server" ErrorMessage="Only xls, doc, txt, pdf, docx or zip files are allowed!"
											ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.xls|.XLS|.doc|.DOC|.txt|.TXT|.zip|.ZIP|.pdf|.PDF|.docx|DOCX)$" ControlToValidate="TXT_FILE_UPLOAD"></asp:regularexpressionvalidator></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"></TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:label id="LBL_STATUSREPORT" runat="server" ForeColor="Red"></asp:label></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 21px" align="center" colSpan="3"><asp:label id="LBL_SUMBERDATA" runat="server"></asp:label></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="3"><asp:button id="UPLOAD" runat="server" Text="Upload"></asp:button></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="3"></TD>
								</TR>
								<TR>
									<TD align="left" colSpan="3"><FONT color="#0000ff">Note : disarankan utk mempercepat 
											proses tidak meng-klik tulisan download, tp di klik kanan saja dari tulisan 
											download tersebut, kemudian pilih "save target as"...simpan di lokal komputer</FONT></TD>
								</TR>
							</table>
						</TD>
						<TD vAlign="top" width="50%" rowSpan="2">
							<table cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD><ASP:DATAGRID id="DATA_EXPORT" runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="1"
											PageSize="5" AllowPaging="True">
											<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
											<Columns>
												<asp:BoundColumn Visible="False" DataField="ID_UPLOAD_REKANAN" HeaderText="No">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle Width="10px"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="FILE_UPLOAD_REKANAN_NAME" HeaderText="Destination File">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												</asp:BoundColumn>
												<asp:TemplateColumn>
													<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
													<ItemTemplate>
														<asp:HyperLink id="UPL_REKANAN_DOWNLOAD" runat="server" Target="_blank">Download</asp:HyperLink>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn>
													<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
													<ItemTemplate>
														<asp:LinkButton id="UPL_REKANAN_DELETE" runat="server" CommandName="delete">Delete</asp:LinkButton>
													</ItemTemplate>
												</asp:TemplateColumn>
											</Columns>
											<PagerStyle Mode="NumericPages"></PagerStyle>
										</ASP:DATAGRID></TD>
								</TR>
							</table>
						</TD>
						<!--<td></td>--></tr>
					<tr align="center">
						<td class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2"><asp:button id="BTN_SAVE" runat="server" CssClass="Button1" Text="Save" onclick="BTN_SAVE_Click"></asp:button>&nbsp;&nbsp;&nbsp;
							<asp:button id="BTN_CLEAR" runat="server" CssClass="Button1" Text="Clear" onclick="BTN_CLEAR_Click"></asp:button>&nbsp;&nbsp;
							<asp:button id="BTN_PRINT" runat="server" CssClass="Button1" Text="Print" onclick="BTN_PRINT_Click"></asp:button></td>
					</tr>
					<TR>
						<TD colSpan="2"><ASP:DATAGRID id="DGR_SUM" runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="1">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="SUM"></asp:BoundColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
					<TR>
						<TD colSpan="2"><ASP:DATAGRID id="DGR_TOT" runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="1">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="S_TOT"></asp:BoundColumn>
								</Columns>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="SC_TOTAL"></asp:BoundColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
