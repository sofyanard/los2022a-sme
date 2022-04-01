<%@ Page language="c#" Codebehind="DetailDataEntry.aspx.cs" AutoEventWireup="false" Inherits="SME.BGSpan.Initiation.DetailDataEntry" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>Detail Data Entry</TITLE>
		<META content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<CENTER>
				<TABLE width="100%" border="0">
					<TR>
						<TD align="left" width="50%">
							<TABLE id="Table1">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Detail Data Entry</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right">
							<A href="CustomerList.aspx?si="></A><A href="../../../Body.aspx"><IMG height="25" src="../../Image/MainMenu.jpg" width="106"></A>
							<A href="../../../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A>
						</TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2">
							<asp:placeholder id="Menu" runat="server"></asp:placeholder>&nbsp;
						</TD>
					</TR>
					<TR>
						<td class="tdHeader1" colSpan="2">GENERAL DATA</td>
					</TR>
					<TR>
						<TD width="50%">
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_NONOTA" runat="server">Nomor Nota:</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NONOTA" runat="server" Enabled="False" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_TGLNOTA" runat="server">Tanggal Nota:</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGLNOTA_DAY" runat="server" Width="24px"
											MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_TGLNOTA_MONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_TGLNOTA_YEAR" runat="server" Width="36px"
											MaxLength="4" Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_NOSURATNSBH" runat="server">Nomor Surat Nasabah/Penawaran:</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NOSURAT" runat="server" Enabled="false" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_TGLSURAT" runat="server">Tanggal Surat:</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGLSURAT_DAY" runat="server" Width="24px"
											MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_TGLSURAT_MONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_TGLSURAT_YEAR" runat="server" Width="36px"
											MaxLength="4" Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_TGLTRIMA" runat="server">Tanggal Terima:</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGLTRIMA_DAY" runat="server" Width="24px"
											MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_TGLTRIMA_MONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_TGLTRIMA_YEAR" runat="server" Width="36px"
											MaxLength="4" Columns="4"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD vAlign="top" width="50%">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_APPNUMBER" runat="server">Nomor Aplikasi IPS:</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_APPNUMBER" runat="server" Enabled="False" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_UNITKERJA" runat="server">Unit Kerja:</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_UNITKERJA" runat="server" Enabled="False" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_PENGUSUL" runat="server">Pengusul:</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PENGUSUL" runat="server" Enabled="False" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_PEMUTUS" runat="server">Pemutus:</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PEMUTUS" runat="server" Enabled="False" Width="100%"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" colSpan="2" height="10"><asp:label id="LBL_SEQ" runat="server" Visible="False"></asp:label><asp:button id="BTN_SAVE" runat="server" Width="100px" CssClass="button1" Text="SAVE"></asp:button>&nbsp;&nbsp;&nbsp;
						</TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2"><asp:label id="LBL_DOCEXPORT" runat="server">Document Lampiran</asp:label></TD>
					</TR>
					<TR>
						<TD vAlign="top" width="50%">
							<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="30%">Nama Dokumen :</TD>
									<TD class="TDBGColorValue" width="50%"><asp:textbox id="txt_nama_doc" runat="server" Enabled="False" width="100%"></asp:textbox></TD>
									<TD class="TDBGColorValue" width="20%"><asp:button id="btn_insert" runat="server" Text="Insert" Font-Bold="True"></asp:button></TD>
								</TR>
								<tr>
									<td colSpan="3"></td>
								</tr>
								<tr>
									<td colSpan="3"></td>
								</tr>
								<TR>
									<TD class="TDBGColor1" colSpan="3"><asp:datagrid id="dg_non_cash" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="True">
											<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
											<Columns>
												<asp:BoundColumn DataField="no" HeaderText="No">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="doc_name" HeaderText="Nama Dokumen">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="fungsi" HeaderText="Function">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
											</Columns>
											<PagerStyle Mode="NumericPages"></PagerStyle>
										</asp:datagrid></TD>
								</TR>
							</TABLE>
						</TD>
						<TD>
							<TABLE cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="30%">File :</TD>
									<TD class="TDBGColorValue" width="50%"><asp:textbox id="txt_filename" runat="server" Enabled="False" width="100%"></asp:textbox></TD>
									<TD class="TDBGColorValue" width="20%"><asp:button id="btn_browse" runat="server" Text="Browse" Font-Bold="True"></asp:button></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="30%">Status :</TD>
									<TD class="TDBGColorValue" width="70%" colSpan="2"><asp:textbox id="txt_status_file" runat="server" Enabled="False" width="100%"></asp:textbox></TD>
								</TR>
								<tr>
									<td colSpan="3"></td>
								</tr>
								<tr>
									<td colSpan="3"><asp:button id="btn_upload" runat="server" Text="Upload" Font-Bold="True"></asp:button></td>
								</tr>
								<TR>
									<TD class="TDBGColor1" colSpan="3"><asp:datagrid id="Datagrid1" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="True">
											<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
											<Columns>
												<asp:BoundColumn DataField="no" HeaderText="No">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="file_dest" HeaderText="File Destination">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn>
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn>
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn>
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
											</Columns>
											<PagerStyle Mode="NumericPages"></PagerStyle>
										</asp:datagrid></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD colSpan="2"></TD>
					</TR>
					<TR>
						<TD colSpan="2"></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">Info Permohonan</TD>
					</TR>
					<TR>
						<td vAlign="top" width="50%">
							<TABLE cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%">Jenis Permohonan :</TD>
									<TD class="TDBGColorValue"><asp:textbox id="txt_jns_permohonan" runat="server" Enabled="False" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%">Jenis Fasilitas :</TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="ddl_jns_fasilitas" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%">Limit Fasilitas :</TD>
									<TD class="TDBGColorValue"><asp:textbox id="txt_limit" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%">Exchange Rate to Rp. :</TD>
									<TD class="TDBGColorValue"><asp:textbox id="txt_exchange" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%">Limit in Rp. :</TD>
									<TD class="TDBGColorValue"><asp:textbox id="txt_limit_rp" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
							</TABLE>
						</td>
						<td vAlign="top" width="50%">
							<TABLE cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1">Jangka Waktu :</TD>
									<TD class="TDBGColorValue"><asp:textbox id="txt_tgl_jangka" runat="server" Width="50%"></asp:textbox><asp:dropdownlist id="ddl_jangka_wkt" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%">Tujuan Penggunaan :</TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="ddl_tujuan_peng" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%">Provisi :</TD>
									<TD class="TDBGColorValue" rowSpan="2"><asp:textbox id="txt_provisi" runat="server" Width="100%" TextMode="MultiLine"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%">Collateral</TD>
									<TD><asp:checkbox id="CHK_COLLATERAL" runat="server" Text="(check for yes)" AutoPostBack="True" Checked="True"></asp:checkbox></TD>
								</TR>
							</TABLE>
						</td>
					</TR>
					<tr>
						<td colSpan="2"><asp:datagrid id="dg_detail" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="True">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="Jaminan" HeaderText="Jenis Jaminan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="ket" HeaderText="Keterangan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="Bukti Kepemilikan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="Bentuk Pengikatan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="Nilai Pasar">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="Nilai Bank">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="Nilai Asuransi">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="Nilai Pengikatan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="Nilai Pengurang PPA">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="Nilai Likuidasi">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="% Use">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="Nilai Akhir">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn>
										<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="Linkbutton2" runat="server" CommandName="delete">Delete</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</asp:datagrid></td>
					</tr>
					<TR>
						<TD colSpan="2"></TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" align="center" colSpan="2">
							<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD width="129" colSpan="3">
										<asp:radiobuttonlist id="RDO_COLLATERAL" runat="server" Width="150px" AutoPostBack="True" RepeatDirection="Horizontal">
											<asp:ListItem Value="1" Selected="True">New</asp:ListItem>
											<asp:ListItem Value="2">Existing</asp:ListItem>
										</asp:radiobuttonlist>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"><asp:label id="Label1" runat="server"></asp:label></TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
										<asp:dropdownlist id="DDL_CL_TYPE" runat="server"></asp:dropdownlist>
										<asp:dropdownlist id="DDL_CL_TYPE_EXISTING" runat="server" Visible="False" AutoPostBack="True"></asp:dropdownlist>
										<asp:label id="LBL_SISAUTILIZATION" runat="server" Visible="False">100</asp:label>
										<asp:textbox onkeypress="return digitsonly()" id="TXT_LC_PERCENTAGE" runat="server" Width="50px"
											MaxLength="3" Visible="False">100</asp:textbox>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"><asp:label id="Label2" runat="server"></asp:label></TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return kutip_satu()" id="TXT_CL_DESC" runat="server" Width="300px" MaxLength="150"
											CssClass="mandatoryColl"></asp:textbox>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">eMAS Colateral ID</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_COL_ID" runat="server" Width="300px" BorderStyle="None" ReadOnly="True"></asp:textbox>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Bukti Kepemilikan</TD>
									<TD style="WIDTH: 15px; HEIGHT: 11px"></TD>
									<TD class="TDBGColorValue">
										<asp:dropdownlist id="DDL_BUKTI_KEPEMILIKAN" runat="server" CssClass="mandatoryColl"></asp:dropdownlist>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Bentuk Pengikatan</TD>
									<TD style="WIDTH: 15px; HEIGHT: 11px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 11px">
										<asp:dropdownlist id="DDL_BENTUK_PENGIKATAN" runat="server" CssClass="mandatoryColl"></asp:dropdownlist>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 11px">Klasifikasi Jaminan</TD>
									<TD style="WIDTH: 15px; HEIGHT: 11px"></TD>
									<TD class="TDBGColorValue">
										<asp:dropdownlist id="DDL_CL_COLCLASSIFY" runat="server" CssClass="mandatoryColl"></asp:dropdownlist>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Currency</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
										<asp:dropdownlist id="DDL_CL_CURRENCY" runat="server" CssClass="mandatoryColl" AutoPostBack="True"></asp:dropdownlist>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Exchange Rate to Rp</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return digitsonly()" id="TXT_CL_EXCHANGERATE" onblur="FormatCurrency(this), FormatCurrency(document.Form1.TXT_CL_VALUE), FormatCurrency(document.Form1.TXT_CL_VALUE2), FormatCurrency(document.Form1.TXT_CL_VALUEINS), FormatCurrency(document.Form1.TXT_CL_VALUEIKAT), FormatCurrency(document.Form1.TXT_CL_VALUEPPA)"
											onkeyup="HitungColValue();HitungColValue2();HitungColValue3();HitungColValue4();HitungColValue5();HitungColValue6();"
											runat="server" Width="100px" MaxLength="10" CssClass="mandatoryColl">1
										</asp:textbox>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="129">Nilai Bank</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return digitsonly()" id="TXT_CL_FOREIGNVAL" onblur="FormatCurrency(this), FormatCurrency(document.Form1.TXT_CL_VALUE)"
											onkeyup="HitungColValue()" runat="server" Width="200px" MaxLength="15" CssClass="mandatoryColl"></asp:textbox>&nbsp;&nbsp;in 
										Rp&nbsp;
										<asp:textbox id="TXT_CL_VALUE" runat="server" Width="200px" BorderStyle="None" ReadOnly="True"></asp:textbox>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nilai Pasar</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return digitsonly()" id="TXT_CL_FOREIGNVAL2" onblur="FormatCurrency(this), FormatCurrency(document.Form1.TXT_CL_VALUE2)"
											onkeyup="HitungColValue2()" runat="server" Width="200px" MaxLength="15" CssClass="mandatoryColl"></asp:textbox>&nbsp;&nbsp;in 
										Rp&nbsp;
										<asp:textbox id="TXT_CL_VALUE2" runat="server" Width="200px" BorderStyle="None" ReadOnly="True"></asp:textbox>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="129">Nilai Asuransi</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return digitsonly()" id="TXT_CL_FOREIGNVALINS" onblur="FormatCurrency(this), FormatCurrency(document.Form1.TXT_CL_VALUEINS)"
											onkeyup="HitungColValue3()" runat="server" Width="200px" MaxLength="15"></asp:textbox>&nbsp;&nbsp;in 
										Rp&nbsp;
										<asp:textbox id="TXT_CL_VALUEINS" runat="server" Width="200px" BorderStyle="None" ReadOnly="True"></asp:textbox>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="129">Nilai Pengikatan</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return digitsonly()" id="TXT_CL_FOREIGNVALIKAT" onblur="FormatCurrency(this), FormatCurrency(document.Form1.TXT_CL_VALUEIKAT)"
											onkeyup="HitungColValue4()" runat="server" Width="200px" MaxLength="15"></asp:textbox>&nbsp;&nbsp;in 
										Rp&nbsp;
										<asp:textbox id="TXT_CL_VALUEIKAT" runat="server" Width="200px" BorderStyle="None" ReadOnly="True"></asp:textbox>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="129">Nilai Pengurang PPA</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return digitsonly()" id="TXT_CL_FOREIGNVALPPA" onblur="FormatCurrency(this), FormatCurrency(document.Form1.TXT_CL_VALUEPPA)"
											onkeyup="HitungColValue5()" runat="server" Width="200px" MaxLength="15"></asp:textbox>&nbsp;&nbsp;in 
										Rp&nbsp;
										<asp:textbox id="TXT_CL_VALUEPPA" runat="server" Width="200px" BorderStyle="None" ReadOnly="True"></asp:textbox>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="129">Nilai Likuidasi</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return digitsonly()" id="TXT_CL_FOREIGNVALLIQ" onblur="FormatCurrency(this), FormatCurrency(document.Form1.TXT_CL_VALUELIQ)"
											onkeyup="HitungColValue6()" runat="server" Width="200px" MaxLength="15"></asp:textbox>&nbsp;&nbsp;in 
										Rp&nbsp;
										<asp:textbox id="TXT_CL_VALUELIQ" runat="server" Width="200px" BorderStyle="None" ReadOnly="True"></asp:textbox>
									</TD>
								</TR>
								<!--<TR>
													<TD class="TDBGColor1">% Use</TD>
													<TD style="WIDTH: 15px"></TD>
													<TD class="TDBGColorValue"></TD>
												</TR>-->
								<TR>
									<TD class="TDBGColor1">Tanggal Penilaian</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_TGLPENILAIAN_DAY" runat="server" MaxLength="2" Columns="4" CssClass="mandatoryColl"></asp:textbox>
										<asp:dropdownlist id="DDL_TGLPENILAIAN_MONTH" runat="server" CssClass="mandatoryColl"></asp:dropdownlist>
										<asp:textbox id="TXT_TGLPENILAIAN_YEAR" runat="server" MaxLength="4" Columns="4" CssClass="mandatoryColl"></asp:textbox>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Penilaian Oleh</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_PENILAI_OLEH" runat="server" CssClass="mandatoryColl"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD align="center" width="50%" colSpan="2"><asp:button id="BTN_INSCOLL" runat="server" CssClass="button1" Text="Tambah Collateral"></asp:button></TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" colSpan="2" height="10">
							<asp:button id="Button1" runat="server" Width="100px" CssClass="button1" Text="SAVE"></asp:button>&nbsp;&nbsp;&nbsp;
						</TD>
					</TR>
					<TR id="TR_COLL4" runat="server">
						<TD class="tdbgcolor2" colSpan="2">
							<asp:button id="BTN_ADD" runat="server" Width="125px" CssClass="button1" Text="Add Request"></asp:button>
							<asp:button id="BTN_CANCEL" runat="server" Width="125px" CssClass="button1" Text="Cancel" Visible="False"></asp:button>
						</TD>
					</TR>
					<TR id="TR_COLL3" runat="server">
						<TD colSpan="2">
							<TABLE class="td" id="Table8" cellSpacing="1" cellPadding="1" width="100%" border="0">
								<TR>
									<TD class="tdheader1">List Request</TD>
								</TR>
								<TR>
									<TD>
										<ASP:DATAGRID id="Datagrid2" runat="server" Width="100%" PageSize="5" AutoGenerateColumns="False"
											AllowPaging="True">
											<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
											<Columns>
												<asp:BoundColumn Visible="False" DataField="AP_REGNO" HeaderText="AP_REGNO"></asp:BoundColumn>
												<asp:BoundColumn DataField="APPTYPEDESC" HeaderText="Transaction Type">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="APPTYPE"></asp:BoundColumn>
												<asp:BoundColumn DataField="PRODUCTDESC" HeaderText="Facility">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="productid"></asp:BoundColumn>
												<asp:BoundColumn DataField="CP_EXLIMITVAL" HeaderText="Amount" DataFormatString="{0:00,00.00}">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="CP_EXRPLIMIT" HeaderText="Exchange Rate">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="CP_LIMIT" HeaderText="Amount in IDR">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="PRODUCTID" HeaderText="PRODUCTID"></asp:BoundColumn>
												<asp:BoundColumn DataField="TENORDESC" HeaderText="Tenor">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="PROD_SEQ" HeaderText="PROD_SEQ"></asp:BoundColumn>
												<asp:TemplateColumn HeaderText="Collateral">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
													<ItemTemplate>
														<asp:LinkButton id="LNK_VIEW" runat="server" CommandName="view">view</asp:LinkButton>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="Function">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
													<ItemTemplate>
														&nbsp;&nbsp;&nbsp;
														<asp:LinkButton id="Linkbutton3" runat="server" CommandName="delete">Delete</asp:LinkButton>
													</ItemTemplate>
												</asp:TemplateColumn>
											</Columns>
											<PagerStyle Mode="NumericPages"></PagerStyle>
										</ASP:DATAGRID></TD>
								</TR>
								<TR id="TR_BUTTONS1" runat="server">
									<TD class="tdbgcolor2">
										<asp:button id="BTN_SAVEREQ" runat="server" Visible="False" Width="180px" Enabled="False" CssClass="button1"
											Text="Save Request"></asp:button>
										<asp:listbox id="ListBox2" runat="server" Visible="False" Height="25px" Width="10px"></asp:listbox>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">Info Nasabah</TD>
					</TR>
					<TR>
						<TD vAlign="top" width="50%" colSpan="2">
							<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD><asp:radiobuttonlist id="RDO_RFCUSTOMERTYPE" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"></asp:radiobuttonlist></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR id="TR_PERSONAL" runat="server">
						<TD class="td" style="WIDTH: 686px" vAlign="top" width="686">
							<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="129">CIF No.</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_CU_CIF_P" runat="server" Width="200px" BorderStyle="None" ReadOnly="True"></asp:textbox>
										<asp:label id="LBL_AP_RELMNGR" runat="server" Visible="False">LBL_AP_RELMNGR</asp:label>
										<asp:label id="TXT_CU_REF" runat="server" Visible="False"></asp:label>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="129">Title Before Name</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_TITLEBEFORENAME" runat="server" Width="200px"
											MaxLength="15"></asp:textbox>
										<asp:label id="TXT_AP_REGNO" runat="server" Visible="False"></asp:label>
										<asp:label id="TXT_AP_RELMNGR" runat="server" Visible="False"></asp:label>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nama Pemohon</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<P><asp:textbox id="TXT_CU_FIRSTNAME" runat="server" Width="300px" MaxLength="50" CssClass="mandatory2"></asp:textbox><asp:label id="TXT_PROG_CODE" runat="server" Visible="False"></asp:label><BR>
											<asp:textbox id="TXT_CU_MIDDLENAME" runat="server" Width="300px" MaxLength="50"></asp:textbox>
										</P>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Title After Name</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_LASTNAME" runat="server" Width="300px" MaxLength="50"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Alamat</TD>
									<TD></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px">
										<asp:textbox id="TXT_CU_ADDR1" runat="server" Width="300px" MaxLength="100" CssClass="mandatory2"></asp:textbox><BR>
										<asp:textbox id="TXT_CU_ADDR2" runat="server" Width="300px" MaxLength="100"></asp:textbox><BR>
										<asp:textbox id="TXT_CU_ADDR3" runat="server" Width="300px" MaxLength="100"></asp:textbox>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Kota</TD>
									<TD></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px">
										<asp:textbox id="TXT_CU_CITY" runat="server" Width="175px" CssClass="mandatory2" ReadOnly="True"></asp:textbox>
										<asp:label id="LBL_CU_CITY" runat="server" Visible="False"></asp:label>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Kode Pos</TD>
									<TD></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px">
										<asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_ZIPCODE" runat="server" MaxLength="6"
											Columns="6" CssClass="mandatory2" AutoPostBack="True"></asp:textbox>
										<asp:button id="BTN_SEARCHPERSONAL" runat="server" Text="Search"></asp:button>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Kepemilikan Rumah</TD>
									<TD></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:dropdownlist id="DDL_CU_HOMESTA" runat="server" CssClass="mandatory2"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">&nbsp;Mulai Menetap</TD>
									<TD></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px">
										<asp:textbox id="TXT_CU_MULAIMENETAPMM" runat="server" MaxLength="2" Columns="2"></asp:textbox>(MM)
										<asp:textbox id="TXT_CU_MULAIMENETAPYY" runat="server" MaxLength="4" Columns="4"></asp:textbox>&nbsp;(YYYY)
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">No. Telepon</TD>
									<TD></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px">
										<asp:textbox id="TXT_CU_PHNAREA" runat="server" MaxLength="5" Columns="4" CssClass="mandatory2"></asp:textbox><asp:textbox id="TXT_CU_PHNNUM" runat="server" Width="100px" MaxLength="15" Columns="10" CssClass="mandatory2"></asp:textbox>&nbsp;Ext.
										<asp:textbox id="TXT_CU_PHNEXT" runat="server" MaxLength="5" Columns="3"></asp:textbox>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">No. Fax</TD>
									<TD></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px">
										<asp:textbox id="TXT_CU_FAXAREA" runat="server" MaxLength="5" Columns="4"></asp:textbox>
										<asp:textbox id="TXT_CU_FAXNUM" runat="server" Width="100px" MaxLength="15" Columns="10"></asp:textbox>&nbsp;Ext.
										<asp:textbox id="TXT_CU_FAXEXT" runat="server" MaxLength="5" Columns="3"></asp:textbox>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tempat Lahir</TD>
									<TD></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_CU_POB" runat="server" Width="300px" MaxLength="50" CssClass="mandatory2"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tanggal Lahir</TD>
									<TD></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px">
										<asp:textbox onkeypress="return numbersonly()" id="TXT_CU_DOB_DAY" runat="server" Width="24px"
											MaxLength="2" Columns="4" CssClass="mandatory2"></asp:textbox>
										<asp:dropdownlist id="DDL_CU_DOB_MONTH" runat="server" CssClass="mandatory2"></asp:dropdownlist>
										<asp:textbox onkeypress="return numbersonly()" id="TXT_CU_DOB_YEAR" runat="server" Width="36px"
											MaxLength="4" Columns="4" CssClass="mandatory2"></asp:textbox>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Status Perkawinan</TD>
									<TD></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:dropdownlist id="DDL_CU_MARITAL" runat="server" CssClass="mandatory2"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD colSpan="3">
										<TABLE id="Table8" cellSpacing="1" cellPadding="1" width="100%" border="0">
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 127px">Spouse Name</TD>
												<TD style="WIDTH: 11px"></TD>
												<TD><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_SPOUSE_FNAME" runat="server" MaxLength="50"
														Columns="40"></asp:textbox><BR>
													<asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_SPOUSE_MNAME" runat="server" MaxLength="50"
														Columns="40"></asp:textbox><BR>
													<asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_SPOUSE_LNAME" runat="server" MaxLength="50"
														Columns="40"></asp:textbox>
												</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 127px">No KTP</TD>
												<TD style="WIDTH: 11px"></TD>
												<TD><asp:textbox id="TXT_CU_SPOUSE_IDCARDNUM" runat="server" MaxLength="50" Columns="40"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 127px">KTP Address</TD>
												<TD style="WIDTH: 11px"></TD>
												<TD><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_SPOUSE_KTPADDR1" runat="server" MaxLength="100"
														Columns="40"></asp:textbox><BR>
													<asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_SPOUSE_KTPADDR2" runat="server" MaxLength="100"
														Columns="40"></asp:textbox><BR>
													<asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_SPOUSE_KTPADDR3" runat="server" MaxLength="100"
														Columns="40"></asp:textbox>
												</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 127px">KTP Issuance Date</TD>
												<TD style="WIDTH: 11px"></TD>
												<TD>
													<asp:textbox onkeypress="return numbersonly()" id="TXT_CU_SPOUSE_KTPISSUEDATE_DAY" runat="server"
														Width="24px" MaxLength="2" Columns="4"></asp:textbox>
													<asp:dropdownlist id="DDL_CU_SPOUSE_KTPISSUEDATE_MONTH" runat="server"></asp:dropdownlist>
													<asp:textbox onkeypress="return numbersonly()" id="TXT_CU_SPOUSE_KTPISSUEDATE_YEAR" runat="server"
														Width="36px" MaxLength="4" Columns="4"></asp:textbox>
												</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 127px">Tanggal Berakhir KTP</TD>
												<TD style="WIDTH: 11px"></TD>
												<TD>
													<asp:textbox onkeypress="return numbersonly()" id="TXT_CU_SPOUSE_KTPEXPDATE_DAY" runat="server"
														Width="24px" MaxLength="2" Columns="4"></asp:textbox>
													<asp:dropdownlist id="DDL_CU_SPOUSE_KTPEXPDATE_MONTH" runat="server"></asp:dropdownlist>
													<asp:textbox onkeypress="return numbersonly()" id="TXT_CU_SPOUSE_KTPEXPDATE_YEAR" runat="server"
														Width="36px" MaxLength="4" Columns="4"></asp:textbox>
												</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 127px">No Kartu Keluarga</TD>
												<TD style="WIDTH: 11px"></TD>
												<TD><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_NOKARTUKELUARGA" runat="server" MaxLength="50"
														Columns="40"></asp:textbox>
												</TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jumlah Anak</TD>
									<TD></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_CHILDREN" runat="server" MaxLength="2"
											Columns="3"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jenis Kelamin</TD>
									<TD></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:dropdownlist id="DDL_CU_SEX" runat="server" CssClass="mandatory2"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Kewarganegaraan</TD>
									<TD></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:dropdownlist id="DDL_CU_CITIZENSHIP" runat="server" CssClass="mandatory2"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table9" cellSpacing="0" cellPadding="0" width="100%" runat="server">
								<TR>
									<TD class="TDBGColor1">No. KTP</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_IDCARDNUM" runat="server" Width="300px" MaxLength="50" CssClass="mandatory2"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tanggal Berakhir KTP</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_IDCARDEXP_DAY" runat="server" Width="24px"
											MaxLength="2" Columns="4" CssClass="mandatory2"></asp:textbox><asp:dropdownlist id="DDL_CU_IDCARDEXP_MONTH" runat="server" CssClass="mandatory2"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_IDCARDEXP_YEAR" runat="server" Width="36px"
											MaxLength="4" Columns="4" CssClass="mandatory2"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">KTP Address</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_KTPADDR1" runat="server" Width="300px" MaxLength="100" CssClass="mandatory2"></asp:textbox><BR>
										<asp:textbox id="TXT_CU_KTPADDR2" runat="server" Width="300px" MaxLength="100"></asp:textbox><BR>
										<asp:textbox id="TXT_CU_KTPADDR3" runat="server" Width="300px" MaxLength="100"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Kota</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_KTPCITY" runat="server" Width="175px" CssClass="mandatory2" ReadOnly="True"></asp:textbox><asp:label id="LBL_CU_KTPCITY" runat="server" Visible="False"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Kode Pos</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_KTPZIPCODE" runat="server" MaxLength="6"
											Columns="6" CssClass="mandatory2" AutoPostBack="True"></asp:textbox><asp:button id="BTN_SEARCHKTPZIP" runat="server" Text="Search"></asp:button></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jenis Alamat</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_JNSALAMAT_P" runat="server" CssClass="mandatory2"></asp:dropdownlist><asp:dropdownlist id="DDL_CU_JNSNASABAH_P" runat="server" Visible="False" CssClass="mandatory"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD></TD>
									<TD style="WIDTH: 15px"></TD>
									<TD></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Pendidikan Terakhir</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CU_EDUCATION" runat="server" CssClass="mandatory2"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jabatan</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CU_JOBTITLE" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Bidang Usaha</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CU_BUSSTYPE" runat="server" CssClass="mandatory2"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Berdiri Sejak</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_ESTABLISHDD" runat="server" MaxLength="2" Columns="2" CssClass="mandatory2"></asp:textbox><asp:dropdownlist id="DDL_CU_ESTABLISHMM" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox id="TXT_CU_ESTABLISHYY" runat="server" MaxLength="4" Columns="4" CssClass="mandatory2"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">NPWP</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_NPWP" runat="server" Width="200px" MaxLength="25"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Pendapatan Bersih/Bulan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CU_NETINCOMEMM" runat="server" Width="300px"
											MaxLength="15">0</asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jumlah Karyawan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_EMPLOYEE" runat="server" MaxLength="4"
											Columns="5" CssClass="mandatory2"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nama Ibu Kandung</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_MOTHER" runat="server" Width="300px" MaxLength="25" CssClass="Mandatory"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nama Pelaporan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_NAMAPELAPORAN" runat="server" Width="300px" MaxLength="100" CssClass="mandatory"></asp:textbox><asp:checkbox id="CHB_CU_NAMAPELAPORAN" Text="Same with Name" AutoPostBack="True" Runat="server"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Negara Domisili</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CU_NEGARADOMISILI" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR id="TR_COMPANY" runat="Server">
						<TD class="td" style="WIDTH: 686px" vAlign="top" width="686">
							<TABLE id="Table10" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">CIF No.</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_CIF_C" runat="server" Width="200px" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Nama Perusahaan</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CU_COMPTYPE" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_COMPNAME" runat="server" Width="200px"
											MaxLength="50" CssClass="mandatory"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Jenis Badan Usaha</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CU_JNSNASABAH" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Berdiri Sejak</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_COMPESTABLISHDD" runat="server" MaxLength="2"
											Columns="2" CssClass="mandatory"></asp:textbox><asp:dropdownlist id="DDL_CU_COMPESTABLISHMM" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_COMPESTABLISHYY" runat="server" MaxLength="4"
											Columns="4" CssClass="mandatory"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Tempat Berdiri Perusahaan</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_COMPPOB" runat="server" Width="200px"
											MaxLength="50" CssClass="mandatory"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Alamat Perusahaan</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_COMPADDR1" runat="server" Width="300px"
											MaxLength="100" CssClass="mandatory"></asp:textbox><BR>
										<asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_COMPADDR2" runat="server" Width="300px"
											MaxLength="100"></asp:textbox><BR>
										<asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_COMPADDR3" runat="server" Width="300px"
											MaxLength="100"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Kota</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_COMPCITY" runat="server" Width="175px" CssClass="mandatory" ReadOnly="True"></asp:textbox><asp:label id="LBL_CU_COMPCITY" runat="server" Visible="False"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Kode Pos</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_COMPZIPCODE" runat="server" MaxLength="6"
											Columns="6" CssClass="mandatory" AutoPostBack="True"></asp:textbox><asp:button id="BTN_SEARCHCOMP" runat="server" Text="Search"></asp:button></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jenis Alamat</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_JNSALAMAT_C" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"></TD>
									<TD></TD>
									<TD class="TDBGColorValue"></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">External Rating Company</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CU_COMPEXTRATING_BY" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Rating Class</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_COMPEXTRATING_CLASS" runat="server" MaxLength="5" Columns="5"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Rating Date</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_COMPEXTRATING_DATE_DAY" runat="server"
											MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_CU_COMPEXTRATING_DATE_MONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_COMPEXTRATING_DATE_YEAR" runat="server"
											MaxLength="4" Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Kode Listing Bursa</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CU_COMPLISTINGCODE" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tanggal Listing Bursa</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_COMPLISTINGDATE_DAY" runat="server"
											MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_CU_COMPLISTINGDATE_MONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_COMPLISTINGDATE_YEAR" runat="server"
											MaxLength="4" Columns="4"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table11" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="129">Bidang Usaha</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CU_COMPBUSSTYPE" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="129">Akta Pendirian</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_COMPAKTAPENDIRIAN" runat="server" Width="296px" MaxLength="20"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="129">Issuance Date</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_COMPTGASURANSI_DAY" runat="server"
											Width="24px" MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_CU_TGASURANSI_MONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_COMPTGASURANSI_YEAR" runat="server"
											Width="36px" MaxLength="4" Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="129">Akta Perubahan Terakhir</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_COMPAKTATERAKHIR_NO" runat="server" Width="296px" MaxLength="20"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="129">Tanggal Perubahan Terakhir</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_COMPAKTATERAKHIR_DATE_DAY" runat="server"
											Width="24px" MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_CU_COMPAKTATERAKHIR_DATE_MONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_COMPAKTATERAKHIR_DATE_YEAR" runat="server"
											Width="36px" MaxLength="4" Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="129">Nama Notaris</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_COMPNOTARYNAME" runat="server" Width="296px" MaxLength="20"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jumlah Karyawan</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_COMPEMPLOYEE" runat="server" MaxLength="4"
											Columns="5">0</asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">No. Telepon</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return numbersonly()" id="TXT_CU_COMPPHNAREA" runat="server" MaxLength="5"
											Columns="4" CssClass="mandatory"></asp:textbox>
										<asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_COMPPHNNUM" runat="server" Width="100px"
											MaxLength="15" Columns="10" CssClass="mandatory"></asp:textbox>&nbsp;Ext.
										<asp:textbox onkeypress="return numbersonly()" id="TXT_CU_COMPPHNEXT" runat="server" MaxLength="5"
											Columns="3"></asp:textbox>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">No. Fax</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return numbersonly()" id="TXT_CU_COMPFAXAREA" runat="server" MaxLength="5"
											Columns="4"></asp:textbox>
										<asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_COMPFAXNUM" runat="server" Width="100px"
											MaxLength="15" Columns="10"></asp:textbox>&nbsp;Ext.
										<asp:textbox onkeypress="return numbersonly()" id="TXT_CU_COMPFAXEXT" runat="server" MaxLength="5"
											Columns="3"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">NPWP</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_COMPNPWP" runat="server" Width="200px"
											MaxLength="25" CssClass="mandatory"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">TDP</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_TDP" runat="server" MaxLength="17" CssClass="mandatory"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tgl Penerbitan</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_TGLTERBIT_DAY" runat="server" Width="24px"
											MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_CU_TGLTERBIT_MONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_TGLTERBIT_YEAR" runat="server" Width="36px"
											MaxLength="4" Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tgl Jatuh Tempo</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_TGLJATUHTEMPO_DAY" runat="server" Width="24px"
											MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_CU_TGLJATUHTEMPO_MONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_TGLJATUHTEMPO_YEAR" runat="server"
											Width="36px" MaxLength="4" Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Contact Person</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_CONTACTPERSON" runat="server" Width="300px"
											MaxLength="100" CssClass="mandatory"></asp:textbox></TD>
								</TR>
								<TR id="TR_telepon" runat="server">
									<TD class="TDBGColor1" width="129">No. Telepon</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return numbersonly()" id="TXT_CU_CONTACTPHNAREA" runat="server" MaxLength="5"
											Columns="4"></asp:textbox>
										<asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_CONTACTPHNNUM" runat="server" Width="100px"
											MaxLength="15" Columns="10"></asp:textbox>&nbsp;Ext.
										<asp:textbox onkeypress="return numbersonly()" id="TXT_CU_CONTACTPHNEXT" runat="server" MaxLength="5"
											Columns="3"></asp:textbox></TD>
								</TR>
								<TR>
									<TD width="129"></TD>
									<TD></TD>
									<TD class="TDBGColorValue"></TD>
								</TR>
								<TR id="TR_koperasi" runat="server">
									<TD align="center" colSpan="3">Untuk Koperasi/Kelompok dan sebagainya</TD>
									<TD></TD>
									<TD class="TDBGColorValue"></TD>
								</TR>
								<TR id="TR_anggota" runat="server">
									<TD class="TDBGColor1" width="129">Jumlah Anggota</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_COMPANGGOTA" runat="server" MaxLength="4"
											Columns="5">0</asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<!-- pipeline -->
					<TR id="TR_sektor" runat="Server">
						<TD class="td" style="WIDTH: 686px" vAlign="top" width="686">
							<TABLE id="Table12" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" align="right" width="180">Group Nasabah</TD>
									<TD class="TDBGColorValue"><asp:textbox id="DDL_groupnasabah" runat="server" Width="300px" AutoPostBack="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" align="right" width="180">Sektor Ekonomi BI 1</TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_bmsektor" runat="server" CssClass="mandatory" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" align="right" width="180">Sektor Ekonomi BI 2</TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_bmsubsektor" runat="server" CssClass="mandatory" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" align="right" width="180">Sektor Ekonomi BI 3</TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_bmsubsubsektor" runat="server" CssClass="mandatory" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" align="right" width="180">Sektor Ekonomi BI 4</TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_SEKTOREKONOMIBI" runat="server" Enabled="False" CssClass="mandatory"></asp:dropdownlist><INPUT id="BTN_PG" onclick="window.open('PG2010.html')" type="button" value="Portfolio Guideline"
											name="BTN_PG">
									</TD>
								</TR>
							</TABLE>
							<asp:label id="temp_userid" runat="server" Visible="False">temp_userid</asp:label><asp:label id="temp_branchcode" runat="server" Visible="False">temp_branchcode</asp:label><asp:label id="temp_areaid" runat="server" Visible="False">temp_areaid</asp:label></TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table13" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" align="right" width="180">Net Income</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return signeddigitsonly()" id="Textbox_netincome" onblur="FormatCurrency(this)"
											runat="server" Width="200px" MaxLength="25" CssClass="mandatory"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" align="right" width="180">Pendapatan Operasional</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return signeddigitsonly()" id="Textbox_pendapatanoperasional" onblur="FormatCurrency(this)"
											runat="server" Width="200px" MaxLength="25"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" align="right" width="180">Pendapatan Non Operasional</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return signeddigitsonly()" id="Textbox_pendapatannon" onblur="FormatCurrency(this)"
											runat="server" Width="200px" MaxLength="25"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" align="right" width="180">Lokasi Pabrik/Kebun/Proyek</TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_lokasiproyek" runat="server" CssClass="mandatory" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" align="right" width="180">Key Person</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="Textbox_keyperson" runat="server" Width="200px"
											MaxLength="25" CssClass="mandatory"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" align="right" width="180">Lokasi Dati II</TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CU_LOKASIDATI2" runat="server" CssClass="mandatory" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" align="right" width="180">Hubungan Nasabah dengan Pejabat 
										Executive BM</TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CU_HUBEXECBM" runat="server"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" colSpan="2"><asp:button id="Button2" runat="server" Width="100px" CssClass="Button1" Text="Save"></asp:button><asp:button id="BTN_SAVECON" runat="server" Width="100px" CssClass="Button1" Text="Save"></asp:button></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" vAlign="top" width="50%" colSpan="2">Hubungan Dengan Bank 
							Mandiri</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table14" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 165px" align="right" width="165">Tabungan 
										Sejak</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return numbersonly()" id="TXT_CI_BMSAVING_DAY" runat="server" Width="24px"
											MaxLength="2" Columns="4"></asp:textbox>
										<asp:dropdownlist id="DDL_CI_BMSAVING_MONTH" runat="server"></asp:dropdownlist>
										<asp:textbox onkeypress="return numbersonly()" id="TXT_CI_BMSAVING_YEAR" runat="server" Width="36px"
											MaxLength="4" Columns="4"></asp:textbox>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 165px; HEIGHT: 22px">Debitur Sejak</TD>
									<TD style="HEIGHT: 22px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 22px"><asp:textbox onkeypress="return numbersonly()" id="TXT_CI_BMDEBITUR_DAY" runat="server" Width="24px"
											MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_CI_BMDEBITUR_MONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CI_BMDEBITUR_YEAR" runat="server" Width="36px"
											MaxLength="4" Columns="4"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table15" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 164px; HEIGHT: 22px" width="164">Giro Sejak</TD>
									<TD style="WIDTH: 15px; HEIGHT: 22px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 22px">
										<asp:textbox onkeypress="return numbersonly()" id="TXT_CI_BMGIRO_DAY" runat="server" Width="24px"
											MaxLength="2" Columns="4"></asp:textbox>
										<asp:dropdownlist id="DDL_CI_BMGIRO_MONTH" runat="server"></asp:dropdownlist>
										<asp:textbox onkeypress="return numbersonly()" id="TXT_CI_BMGIRO_YEAR" runat="server" Width="36px"
											MaxLength="4" Columns="4"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="tdHeader1" vAlign="top" colSpan="2">Fasilitas Di Bank Mandiri</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" colSpan="2">
							<TABLE id="Table17" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD style="HEIGHT: 7px" align="center" colSpan="3"></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 1px" align="center" colSpan="3"></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 2px" align="center" colSpan="3"></TD>
								</TR>
								<TR id="br01" runat="server">
									<TD><asp:label id="LBL_SUBTOTAL" runat="server" Font-Bold="True">Total Limit Nasabah (Rp.)</asp:label>&nbsp;</TD>
									<td></td>
									<td><asp:textbox id="TXT_SUBTOTAL" runat="server" MaxLength="20" CssClass="angka" width="200px" ReadOnly="True"></asp:textbox></td>
								</TR>
								<TR id="br02" runat="server">
									<TD><b>Total Limit Kredit Atas Nama Nasabah dan Group&nbsp; (Rp.) (incl. app. exposure)</b></TD>
									<td></td>
									<td><asp:textbox id="TXT_TOTAL" runat="server" Width="201" MaxLength="20" CssClass="angka" ReadOnly="True"></asp:textbox></td>
								</TR>
								<TR id="br04" runat="server">
									<TD style="HEIGHT: 8px" align="center" colSpan="3"></TD>
								</TR>
								<TR id="br05" runat="server">
									<TD align="center" colSpan="3">
										<TABLE id="Table7" cellSpacing="2" cellPadding="2" width="90%">
											<TR>
												<TD class="td" vAlign="top" width="50%">
													<TABLE id="Table18" cellSpacing="0" cellPadding="0" width="100%">
														<TR>
															<TD class="TDBGColor1" style="WIDTH: 128px" align="right" width="128">Jenis Kredit</TD>
															<TD style="WIDTH: 15px"></TD>
															<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CM_CREDITTYPE" runat="server" CssClass="mandatoryColl"></asp:dropdownlist></TD>
														</TR>
														<TR id="namaPerusahaan" runat="server">
															<TD class="TDBGColor1" style="WIDTH: 128px" align="right" width="128">Nama 
																Perusahaan</TD>
															<TD style="WIDTH: 15px"></TD>
															<TD class="TDBGColorValue"><asp:textbox id="TXT_CM_COMPNAME" runat="server"></asp:textbox></TD>
														</TR>
														<TR>
															<TD class="TDBGColor1" style="WIDTH: 128px" align="right" width="128">Limit Kredit</TD>
															<TD style="WIDTH: 15px"></TD>
															<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CM_LIMIT" onblur="FormatCurrency2(this)"
																	runat="server" Width="180" MaxLength="20" CssClass="angka"></asp:textbox></TD>
														</TR>
														<TR>
															<TD class="TDBGColor1" style="WIDTH: 128px" align="right" width="128">Baki Debet</TD>
															<TD style="WIDTH: 15px"></TD>
															<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CM_OUTSTANDING" onblur="FormatCurrency2(this)"
																	runat="server" Width="180" MaxLength="20" CssClass="angka"></asp:textbox></TD>
														</TR>
														<TR>
															<TD class="TDBGColor1" style="WIDTH: 128px" align="right" width="128">Tunggakan 
																Pokok</TD>
															<TD style="WIDTH: 15px"></TD>
															<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CM_TGKPOKOK" onblur="FormatCurrency2(this)"
																	runat="server" Width="180" MaxLength="20" CssClass="angka"></asp:textbox></TD>
														</TR>
														<TR>
															<TD class="TDBGColor1" style="WIDTH: 128px" align="right" width="128">Posisi 
																Tanggal</TD>
															<TD style="WIDTH: 15px"></TD>
															<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CM_TGLPOSISI_D" runat="server" Width="24px"
																	MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_CM_TGLPOSISI_M" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CM_TGLPOSISI_Y" runat="server" Width="36px"
																	MaxLength="4" Columns="4"></asp:textbox></TD>
														</TR>
													</TABLE>
												</TD>
												<TD class="td" vAlign="top" width="50%">
													<TABLE id="Table19" cellSpacing="0" cellPadding="0" width="100%">
														<TR>
															<TD class="TDBGColor1" style="WIDTH: 142px" align="right" width="142">Tunggakan 
																Bunga</TD>
															<TD style="WIDTH: 15px"></TD>
															<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CM_TGKBUNGA" onblur="FormatCurrency2(this)"
																	runat="server" MaxLength="20" CssClass="angka" width="180"></asp:textbox></TD>
														</TR>
														<TR>
															<TD class="TDBGColor1" style="WIDTH: 142px" align="right" width="142">Lama 
																Tunggakan (bln)</TD>
															<TD style="WIDTH: 15px"></TD>
															<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CM_LAMATGK" runat="server" Width="40px"
																	MaxLength="5" CssClass="angka"></asp:textbox></TD>
														</TR>
														<TR>
															<TD class="TDBGColor1" style="WIDTH: 142px" align="right" width="142">Masa Berlaku 
																s/d</TD>
															<TD style="WIDTH: 15px"></TD>
															<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CM_DUEDATE_DAY" runat="server" Width="24px"
																	MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_CM_DUEDATE_MONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CM_DUEDATE_YEAR" runat="server" Width="36px"
																	MaxLength="4" Columns="4"></asp:textbox></TD>
														</TR>
														<TR>
															<TD class="TDBGColor1" style="WIDTH: 142px" align="right" width="142">Kolektibilitas</TD>
															<TD style="WIDTH: 15px"></TD>
															<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CM_COLLECTABILITY" runat="server"></asp:dropdownlist></TD>
														</TR>
														<TR>
															<TD class="TDBGColor1" style="WIDTH: 142px" align="right" width="142">No Rekening</TD>
															<TD style="WIDTH: 15px"></TD>
															<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CM_ACCNO" runat="server" MaxLength="20"
																	CssClass="mandatoryColl" width="180"></asp:textbox></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD align="center" colSpan="2"><asp:button id="Button3" runat="server" Width="75px" CssClass="button1" Text="Insert"></asp:button></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR id="br08" runat="server">
						<TD class="tdHeader1" vAlign="top" colSpan="2">Fasilitas Nasabah Di Bank Lain</TD>
					</TR>
					<TR id="br09" runat="server">
						<TD vAlign="top" colSpan="2"><ASP:DATAGRID id="DatGridOtherLoan" runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="1"
								PageSize="1">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="CU_REF" HeaderText="curef"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="CO_SEQ" HeaderText="Seq">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CO_CREDTYPE" HeaderText="Jenis Kredit">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="BANKNAME" HeaderText="Nama Bank">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CO_LIMIT" HeaderText="Limit">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CO_BAKIDEBET" HeaderText="Baki Debet">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CO_TGKPOKOK" HeaderText="Tunggakan Pokok">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CO_TGKBUNGA" HeaderText="Tunggakan Bunga">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CO_DUEDATE" HeaderText="Tgl. Jatuh Tempo" DataFormatString="{0:dd/MM/yyyy}">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="COLLECTDESC" HeaderText="Kolektibilitas">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CO_TGLPOSISI" HeaderText="Posisi Pada">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CO_JENISDESC" HeaderText="Jenis Product">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn>
										<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="LNK_DELETE" runat="server" CommandName="delete">Delete</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</ASP:DATAGRID></TD>
					</TR>
					<TR id="br10" runat="server">
						<TD style="HEIGHT: 1px" vAlign="top" colSpan="2"></TD>
					</TR>
					<TR id="br11" runat="server">
						<TD vAlign="top" align="center" colSpan="2">
							<TABLE id="Table20" cellSpacing="2" cellPadding="2" width="90%">
								<TR>
									<TD class="td" vAlign="top" width="50%">
										<TABLE id="Table21" cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 128px" align="right" width="128">Jenis Kredit</TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CO_CREDTYPE" runat="server" MaxLength="30"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 128px" align="right" width="128">Nama Bank</TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CO_BANKNAME" runat="server"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 128px" align="right" width="128">Limit</TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CO_LIMIT" onblur="FormatCurrency2(this)"
														runat="server" MaxLength="20" CssClass="angka"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 128px" align="right" width="128">Baki Debet</TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CO_BAKIDEBET" onblur="FormatCurrency2(this)"
														runat="server" MaxLength="20" CssClass="angka" width="180"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 128px" align="right" width="128">&nbsp;Posisi 
													Tanggal</TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CO_TGLPOSISI_D" runat="server" Width="24px"
														MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_CO_TGLPOSISI_M" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CO_TGLPOSISI_Y" runat="server" Width="36px"
														MaxLength="4" Columns="4"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 128px" align="right" width="128">&nbsp;Debitur 
													Sejak</TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CO_TGLDEBITUR_D" runat="server" Width="24px"
														MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_CO_TGLDEBITUR_M" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CO_TGLDEBITUR_Y" runat="server" Width="36px"
														MaxLength="4" Columns="4"></asp:textbox></TD>
											</TR>
										</TABLE>
									</TD>
									<TD class="td" vAlign="top" width="50%">
										<TABLE id="Table22" cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 142px" align="right" width="142">Tunggakan 
													Pokok</TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CO_TGKPOKOK" onblur="FormatCurrency2(this)"
														runat="server" MaxLength="20" CssClass="angka" width="180"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 142px" align="right" width="142">Tunggakan 
													Bunga</TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CO_TGKBUNGA" onblur="FormatCurrency2(this)"
														runat="server" MaxLength="20" CssClass="angka" width="180"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 142px" align="right" width="142">Tgl. Jatuh 
													Tempo</TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CO_DUEDATE_DAY" runat="server" Width="24px"
														MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_CO_DUEDATE_MONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CO_DUEDATE_YEAR" runat="server" Width="36px"
														MaxLength="4" Columns="4"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 142px" align="right" width="142">Kolektibilitas</TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CO_COLLECTABILITY" runat="server"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 142px" align="right" width="142"></TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue"></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 142px" align="right" width="142">Jenis Produk</TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_RFJENISPRODUCT" runat="server"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 142px" align="left" width="142" colSpan="3"></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD align="center" colSpan="2"><asp:label id="LBL_PAR" runat="server" Visible="False"></asp:label><asp:button id="BtnInsert1" runat="server" Width="75px" CssClass="button1" Text="Insert"></asp:button></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD vAlign="top" align="center" colSpan="2">
							<!--##########################################################################################################-->
							<!--AHMAD-->
							<!--##########################################################################################################--></TD>
					</TR>
					<TR id="brtombol" runat="server">
						<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2"><asp:button id="Button4" runat="server" Width="100px" CssClass="Button1" Text="Save"></asp:button></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" vAlign="top" width="45%" colSpan="2"><b>ANALISA KUALITATIF</b></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" vAlign="top" width="45%" colSpan="2">Aspek Hukum - Data 
							Pengurus</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="45%" colSpan="2"><ASP:DATAGRID id="DatGridPengurus" runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="1"
								PageSize="1">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="CU_REF" HeaderText="curef"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="SEQ" HeaderText="Seq">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CIF" HeaderText="CIF">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="NAMA" HeaderText="NAMA">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="CS_TYPE" HeaderText="Jenis Nasabah">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CS_BOD" HeaderText="BOD/Tgl.Berdiri">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CS_SEX" HeaderText="SEX">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CS_NPWP" HeaderText="CS_NPWP">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CS_STOCKPERC" HeaderText="Saham (%)">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="CS_JENISIDUTAMA" HeaderText="Jenis ID Utama">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="CS_NOIDUTAMA" HeaderText="No ID Utama">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="EXPR_ID" HeaderText="Expired ID Utama">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CS_ALAMAT" HeaderText="Alamat">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CS_KODEPOS" HeaderText="Kode Pos">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="CS_BUC" HeaderText="BUC">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="KODE_HUB" HeaderText="Kode Hubungan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Function">
										<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="LNK_EDIT" runat="server" CommandName="edit">Edit</asp:LinkButton>&nbsp;
											<asp:LinkButton id="Linkbutton1" runat="server" CommandName="delete">Delete</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</ASP:DATAGRID><BR>
							<TABLE id="Table23" cellSpacing="2" cellPadding="2" width="100%" border="0">
								<TR>
									<TD style="HEIGHT: 43px" vAlign="top" width="50%" colSpan="2"><asp:radiobuttonlist id="Radiobuttonlist1" onclick="setMandatory2()" runat="server" AutoPostBack="True"
											RepeatDirection="Horizontal"></asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="td" vAlign="top" width="50%">
										<TABLE id="Table24" cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 129px">CIF NO</TD>
												<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CIF" runat="server" Width="300px" MaxLength="50"
														CssClass="mandatoryColl"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 129px" width="129">Nama</TD>
												<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CS_NAMA" runat="server" Width="300px" MaxLength="50"
														CssClass="mandatoryColl"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 129px">Jenis Nasabah</TD>
												<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CS_TYPE" runat="server" Width="300px" MaxLength="50"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 129px">BOD/Berdiri Sejak</TD>
												<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left"><asp:textbox onkeypress="return numbersonly()" id="TXT_CS_BOD_DAY" runat="server" Width="24px"
														MaxLength="2" Columns="4" CssClass="mandatoryColl"></asp:textbox><asp:dropdownlist id="DDL_CS_BOD_MONTH" runat="server" CssClass="mandatoryColl"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CS_BOD_YEAR" runat="server" Width="36px"
														MaxLength="4" Columns="4" CssClass="mandatoryColl"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Jenis Kelamin</TD>
												<TD class="TDBGColorValue" align="left"><asp:dropdownlist id="DDL_CS_SEX" runat="server"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Share Saham (%)</TD>
												<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return digitsonly()" id="TXT_CS_STOCKPERC" runat="server" Width="48px"
														MaxLength="5" CssClass=""></asp:textbox>&nbsp;%
													<asp:label id="LBL_TOTPERC" runat="server" Visible="False">100</asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 127px">Jenis ID Utama</TD>
												<TD class="TDBGColorValue" align="left"><asp:dropdownlist id="DDL_CS_JENISID" runat="server"></asp:dropdownlist></TD>
											</TR>
										</TABLE>
										<asp:label id="SEQ" runat="server" Visible="False"></asp:label></TD>
									<TD class="td" vAlign="top" align="center">
										<TABLE id="Table25" cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 23px" width="125">NO ID Utama</TD>
												<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CS_NOID" runat="server" Width="300px" MaxLength="50"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 23px" width="125">Expired Date ID Utama</TD>
												<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left"><asp:textbox onkeypress="return numbersonly()" id="TXT_CS_EXPR_DAY" runat="server" Width="24px"
														MaxLength="2" Columns="4" CssClass="mandatoryColl"></asp:textbox><asp:dropdownlist id="DDL_CS_EXPR_MONTH" runat="server" CssClass="mandatoryColl"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CS_EXPR_YEAR" runat="server" Width="36px"
														MaxLength="4" Columns="4" CssClass="mandatoryColl"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="125">Alamat</TD>
												<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CS_ALAMAT" runat="server" Width="300px"
														MaxLength="50"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 127px">Kode Pos</TD>
												<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CS_KODEPOS" runat="server" MaxLength="6"
														Columns="6" AutoPostBack="True"></asp:textbox><asp:button id="Button5" runat="server" Text="Search"></asp:button></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 21px">BUC</TD>
												<TD class="TDBGColorValue" align="left"><asp:dropdownlist id="DDL_CS_BUC" runat="server"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 1px">Kode Hubungan</TD>
												<TD class="TDBGColorValue" style="HEIGHT: 1px" align="left"><asp:dropdownlist id="DDL_KODEHUB" runat="server"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Removed</TD>
												<TD class="TDBGColorValue" align="left"><asp:checkbox id="CHK_REMOVED" runat="server" Text="Yes" AutoPostBack="True"></asp:checkbox></TD>
											</TR>
										</TABLE>
										<BR>
									</TD>
								</TR>
								<TR>
									<TD vAlign="top" align="center" width="50%" colSpan="2"><asp:button id="BTN_STOCKHOLDER" runat="server" CssClass="button1" Text="ADD"></asp:button><asp:button id="BTN_CLEAR" runat="server" CssClass="button1" Text="CLEAR"></asp:button></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="tdHeader1" vAlign="top" width="45%" colSpan="2">Aspek Teknis</TD>
					</TR>
					<TR>
						<TD colSpan="2">
							<asp:dropdownlist id="DDL_BG" runat="server"></asp:dropdownlist>
						</TD>
					</TR>
					<TR>
						<TD width="50%">
							<TABLE id="Tab_TEKNIS1" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%">
										<asp:label id="LBL_TXT_PENERIMABG" runat="server">Penerima Bank Garansi:</asp:label>
									</TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_PENERIMABG" runat="server" Width="100%"></asp:textbox>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%">
										<asp:label id="LBL_TXT_TGLLAKUBG" runat="server">Masa Laku Bank Garansi:</asp:label>
									</TD>
									<TD class="TDBGColorValue" colSpan="2">
										<asp:textbox onkeypress="return numbersonly()" id="TXT_TGLLAKUBG_DAY" runat="server" Width="24px"
											Columns="4" MaxLength="2"></asp:textbox>
										<asp:dropdownlist id="DDL_TGLLAKU_MONTH" runat="server"></asp:dropdownlist>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%">
										<asp:label id="LBL_TXT_NILAIPROYEK" runat="server">Nilai Proyek:</asp:label>
									</TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_NILAIPROYEK" runat="server" Width="100%"></asp:textbox>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%">Sifat Bank Garansi :</TD>
									<TD class="TDBGColorValue">
										<asp:dropdownlist id="DDL_SIFATBG" runat="server" Width="100%"></asp:dropdownlist>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%">Jenis Bank Garansi :</TD>
									<TD class="TDBGColorValue">
										<asp:dropdownlist id="DDL_JenisBG" runat="server" Width="100%"></asp:dropdownlist></T 
										TD <></TD>
								</TR>
							</TABLE>
						</TD>
						<TD width="50%">
							<TABLE id="Tab_TEKNIS2" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%">
										<asp:label id="LBL_TXT_SYARATBG" runat="server">Syarat Penerbitan BG:</asp:label>
									</TD>
									<TD class="TDBGColorValue" colspan='2'>
										<asp:textbox id="TXT_SYARATBG" runat="server" Width="100%"></asp:textbox>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%">
										<asp:label id="LBL_TXT_TTDBG" runat="server">Penandatangan Aplikasi BG:</asp:label>
									</TD>
									<TD class="TDBGColorValue" colspan='2'>
										<asp:textbox id="TXT_TTDBG" runat="server" Width="100%"></asp:textbox>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%">Jabatan :</TD>
									<TD class="TDBGColorValue" colspan='2'>
										<asp:dropdownlist id="DDL_Jabatan" runat="server" Width="100%"></asp:dropdownlist></T 
										TD <></TD>
								<TR>
									<TD class="TDBGColor1" width="50%">
										<asp:label id="LBL_TXT_KEBBG" runat="server">Kebutuhan BG Tender yang disyaratkan:</asp:label>
									</TD>
									<TD class="TDBGColorValue" width="20%">
										<asp:textbox id="TXT_KEBBG" runat="server" Width="100%"></asp:textbox>
									</TD>
									<TD>
										<asp:label id="LBL_persen" runat="server">%</asp:label>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%">
										<asp:label id="LBL_TXT_SETORJAMINAN" runat="server">Setoran Jaminan:</asp:label>
									</TD>
									<TD class="TDBGColorValue" colspan='2'>
										<asp:textbox id="TXT_SETORJAMINAN" runat="server" Width="100%"></asp:textbox>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="tdHeader1" vAlign="top" width="45%" colSpan="2"><b>PEMENUHAN RISK ACCEPTANCE 
								CRITERIA (RAC)</b></TD>
					</TR>
					<TR>
						<TD colSpan="2">&nbsp;<STRONG>Select Aspek :</STRONG>
							<asp:dropdownlist id="DDL_ASPEK" runat="server"></asp:dropdownlist>
							<asp:button id="Button6" runat="server" Text="<< INSERT"></asp:button>
						</TD>
					</TR>
					<TR>
						<TD class="td" width="100%" colSpan="2">
							<table id="FORMAT_G" width="100%" runat="server">
								<TR>
									<TD class="td" colSpan="2">
										<table width="100%">
											<tr>
												<td class="tdHeader1" width="100%" colSpan="2">R A C</td>
											</tr>
											<tr>
												<td class="td" colSpan="2"><asp:datagrid id="DGR_RAC" Width="100%" AutoGenerateColumns="False" CellPadding="1" Runat="server"
														AllowPaging="True" DESIGNTIMEDRAGDROP="2507">
														<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
														<Columns>
															<asp:BoundColumn Visible="False" DataField="RACID"></asp:BoundColumn>
															<asp:BoundColumn DataField="RACDESC" HeaderText="Item">
																<HeaderStyle Width="90%" CssClass="tdSmallHeader"></HeaderStyle>
															</asp:BoundColumn>
															<asp:BoundColumn Visible="False" DataField="ISCOMPLY"></asp:BoundColumn>
															<asp:TemplateColumn HeaderText="Compliance">
																<HeaderStyle Width="10%" CssClass="tdSmallHeader"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
																<ItemTemplate>
																	<asp:radiobuttonlist id="RBL_RAC" runat="server" RepeatDirection="Horizontal">
																		<asp:ListItem Value="1">Yes</asp:ListItem>
																		<asp:ListItem Value="0">No</asp:ListItem>
																	</asp:radiobuttonlist>
																</ItemTemplate>
															</asp:TemplateColumn>
														</Columns>
														<PagerStyle Mode="NumericPages"></PagerStyle>
													</asp:datagrid>
												</td>
											</tr>
											<tr>
												<td class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2"><asp:button id="BTN_SAVERAC" runat="server" Text="Save RAC" CssClass="Button1"></asp:button></td>
											</tr>
										</table>
									</TD>
								</TR>
							</table>
						</TD>
					</TR>
				</TABLE>
			</CENTER>
		</form>
	</body>
</HTML>
