<%@ Page language="c#" Codebehind="ProcessBaru.aspx.cs" AutoEventWireup="True" Inherits="SME.ITTP.ProcessBaru" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ProcessBaru</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_mandatoryColl.html" -->
		<!-- #include file="../include/cek_entries.html" -->
		<script language="vbscript">
		function HitungLimit()
			SetLocale("in")
			set obj = document.Form1
			if isnumeric(obj.TXT_CP_EXLIMITVAL.value) then
				EXLIMIT = cdbl(obj.TXT_CP_EXLIMITVAL.value)
			else
				EXLIMIT = 0
			end if
			
			if isnumeric(obj.TXT_CP_EXRPLIMIT.value) then
				EXRPLIMIT = cdbl(obj.TXT_CP_EXRPLIMIT.value)
			else
				EXRPLIMIT = 0
			end if
			obj.TXT_CP_LIMIT.value = EXLIMIT * EXRPLIMIT	
			obj.TXT_CP_LIMIT.value = replace(obj.TXT_CP_LIMIT.value, ".", ",")
		end function
		
		function HitungColValue()
			SetLocale("in")
			set obj = document.Form1
			if isnumeric(obj.TXT_CL_FOREIGNVAL.value) then
				FOREIGNVAL = cdbl(obj.TXT_CL_FOREIGNVAL.value)
			else
				FOREIGNVAL = 0
			end if
			
			if isnumeric(obj.TXT_CL_EXCHANGERATE.value) then
				EXCHANGE = cdbl(obj.TXT_CL_EXCHANGERATE.value)
			else
				EXCHANGE = 0
			end if
			obj.TXT_CL_VALUE.value = FOREIGNVAL * EXCHANGE
			obj.TXT_CL_VALUE.value = replace(obj.TXT_CL_VALUE.value, ".", ",")
		end function
		
		function HitungColValue2()
			SetLocale("in")
			set obj = document.Form1
			if isnumeric(obj.TXT_CL_FOREIGNVAL2.value) then
				FOREIGNVAL2 = cdbl(obj.TXT_CL_FOREIGNVAL2.value)
			else
				FOREIGNVAL2 = 0
			end if
			
			if isnumeric(obj.TXT_CL_EXCHANGERATE.value) then
				EXCHANGE = cdbl(obj.TXT_CL_EXCHANGERATE.value)
			else
				EXCHANGE = 0
			end if
			obj.TXT_CL_VALUE2.value = FOREIGNVAL2 * EXCHANGE
			obj.TXT_CL_VALUE2.value = replace(obj.TXT_CL_VALUE2.value, ".", ",")
		end function
		
		function HitungColValue3()
			SetLocale("in")
			set obj = document.Form1
			if isnumeric(obj.TXT_CL_FOREIGNVALINS.value) then
				FOREIGNVAL3 = cdbl(obj.TXT_CL_FOREIGNVALINS.value)
			else
				FOREIGNVAL3 = 0
			end if
			
			if isnumeric(obj.TXT_CL_EXCHANGERATE.value) then
				EXCHANGE = cdbl(obj.TXT_CL_EXCHANGERATE.value)
			else
				EXCHANGE = 0
			end if
			obj.TXT_CL_VALUEINS.value = FOREIGNVAL3 * EXCHANGE
			obj.TXT_CL_VALUEINS.value = replace(obj.TXT_CL_VALUEINS.value, ".", ",")
		end function
		
		function HitungColValue4()
			SetLocale("in")
			set obj = document.Form1
			if isnumeric(obj.TXT_CL_FOREIGNVALIKAT.value) then
				FOREIGNVAL4 = cdbl(obj.TXT_CL_FOREIGNVALIKAT.value)
			else
				FOREIGNVAL4 = 0
			end if
			
			if isnumeric(obj.TXT_CL_EXCHANGERATE.value) then
				EXCHANGE = cdbl(obj.TXT_CL_EXCHANGERATE.value)
			else
				EXCHANGE = 0
			end if
			obj.TXT_CL_VALUEIKAT.value = FOREIGNVAL4 * EXCHANGE
			obj.TXT_CL_VALUEIKAT.value = replace(obj.TXT_CL_VALUEIKAT.value, ".", ",")
		end function
		
		function HitungColValue5()
			SetLocale("in")
			set obj = document.Form1
			if isnumeric(obj.TXT_CL_FOREIGNVALPPA.value) then
				FOREIGNVAL5 = cdbl(obj.TXT_CL_FOREIGNVALPPA.value)
			else
				FOREIGNVAL5 = 0
			end if
			
			if isnumeric(obj.TXT_CL_EXCHANGERATE.value) then
				EXCHANGE = cdbl(obj.TXT_CL_EXCHANGERATE.value)
			else
				EXCHANGE = 0
			end if
			obj.TXT_CL_VALUEPPA.value = FOREIGNVAL5 * EXCHANGE
			obj.TXT_CL_VALUEPPA.value = replace(obj.TXT_CL_VALUEPPA.value, ".", ",")
		end function
		
		function HitungColValue6()
			SetLocale("in")
			set obj = document.Form1
			if isnumeric(obj.TXT_CL_FOREIGNVALLIQ.value) then
				FOREIGNVAL6 = cdbl(obj.TXT_CL_FOREIGNVALLIQ.value)
			else
				FOREIGNVAL6 = 0
			end if
			
			if isnumeric(obj.TXT_CL_EXCHANGERATE.value) then
				EXCHANGE = cdbl(obj.TXT_CL_EXCHANGERATE.value)
			else
				EXCHANGE = 0
			end if
			obj.TXT_CL_VALUELIQ.value = FOREIGNVAL6 * EXCHANGE
			obj.TXT_CL_VALUELIQ.value = replace(obj.TXT_CL_VALUELIQ.value, ".", ",")
		end function
		</script>
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
		</script>
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<!--
					<TR>
						<TD class="tdNoBorder">
							<TABLE id="Table4">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Initial Data Entry: 
											Permohonan Baru</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><A href="../Body.aspx"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</TR>
					
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2">
							<asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					-->
					<TR>
						<TD class="tdHeader1" colSpan="2">Informasi Permohonan</TD>
					</TR>
					<TR id="TR_JENISPENGAJUAN" runat="server">
						<TD class="td" vAlign="top" width="50%" colSpan="2">
							<TABLE id="Table3" style="WIDTH: 1196px; HEIGHT: 132px" cellSpacing="1" cellPadding="1"
								width="1196" border="0">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 406px; HEIGHT: 22px"><FONT size="2">Amount</FONT></TD>
									<TD style="HEIGHT: 22px"><FONT size="2">:</FONT></TD>
									<TD style="HEIGHT: 22px">
										<asp:textbox id="TXT_CP_EXLIMITVAL" runat="server" CssClass="mandatory2" MaxLength="50" Width="300px"></asp:textbox><FONT size="2"></FONT></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 406px; HEIGHT: 22px"><FONT size="2">Exchange Rate 
											to Rp</FONT></TD>
									<TD style="HEIGHT: 22px">:</TD>
									<TD style="HEIGHT: 22px">
										<asp:textbox onkeypress="return digitsonly()" id="TXT_CP_EXRPLIMIT" onblur="FormatCurrency(this), FormatCurrency(document.Form1.TXT_CP_LIMIT)"
											onkeyup="HitungLimit()" runat="server" CssClass="mandatory" MaxLength="15">1</asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 406px; HEIGHT: 22px"><FONT size="2">Limit in Rp</FONT></TD>
									<TD style="HEIGHT: 22px">:</TD>
									<TD style="HEIGHT: 22px">
										<asp:textbox id="TXT_CP_LIMIT" runat="server" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 406px; HEIGHT: 22px"><FONT size="2">Tenor</FONT></TD>
									<TD style="HEIGHT: 22px"><FONT size="2">:</FONT></TD>
									<TD style="HEIGHT: 22px">
										<asp:textbox id="TXT_CP_JANGKAWKT" runat="server" CssClass="mandatory2" MaxLength="50" Width="24px"></asp:textbox>
										<asp:dropdownlist id="DDL_CP_TENORCODE" runat="server" CssClass="mandatory2"></asp:dropdownlist><FONT size="2"></FONT></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 406px; HEIGHT: 20px"><FONT size="2">Product</FONT></TD>
									<TD style="HEIGHT: 20px"><FONT size="2">:</FONT></TD>
									<TD style="HEIGHT: 20px">
										<asp:dropdownlist id="DDL_PRODUCTID" runat="server" CssClass="mandatory2" Width="296px"></asp:dropdownlist><FONT size="2"></FONT></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 406px; HEIGHT: 19px"><FONT size="2">Purpose Code</FONT></TD>
									<TD style="HEIGHT: 19px"><FONT size="2">:</FONT></TD>
									<TD style="HEIGHT: 19px"><FONT size="2">
											<asp:dropdownlist id="DDL_CP_LOANPURPOSE" runat="server" CssClass="mandatory" Width="296px"></asp:dropdownlist></FONT></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 406px; HEIGHT: 19px"><FONT size="2">Collateral</FONT></TD>
									<TD style="HEIGHT: 19px">:</TD>
									<TD style="HEIGHT: 19px"><FONT size="2">
											<asp:checkbox id="CHK_COLLATERAL" runat="server" AutoPostBack="True" Text="(Check for Yes)"></asp:checkbox><FONT size="2">&nbsp;</FONT></FONT></TD>
								</TR>
							</TABLE>
							<asp:label id="Label8" runat="server" Visible="False"></asp:label>
							<asp:label id="Label9" runat="server" Visible="False"></asp:label>
							<asp:label id="Label10" runat="server" Visible="False"></asp:label></TD>
					</TR>
					<TR id="TR_COLL" runat="server">
						<TD class="td" colSpan="2">
							<P>
								<TABLE id="Table2" cellSpacing="2" cellPadding="2" width="100%" border="0">
									<TR>
										<TD align="center" colSpan="2"><ASP:DATAGRID id="DatGrd" runat="server" Width="100%" AutoGenerateColumns="False" PageSize="7"
												CellPadding="1">
												<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
												<Columns>
													<asp:BoundColumn Visible="False" DataField="CL_SEQ" HeaderText="Sequence"></asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="COLTYPEID" HeaderText="ColType"></asp:BoundColumn>
													<asp:BoundColumn DataField="COLTYPEDESC" HeaderText="Jenis Jaminan">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="CL_DESC" HeaderText="Keterangan">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="CL_CERTTYPE1" HeaderText="BuktiKepemilikan"></asp:BoundColumn>
													<asp:BoundColumn DataField="CL_CERTTYPE1DESC" HeaderText="Bukti Kepemilikan">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="CL_IKATID" HeaderText="BentukPengikatan"></asp:BoundColumn>
													<asp:BoundColumn DataField="CL_IKATIDDESC" HeaderText="Bentuk Pengikatan">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="CL_VALUE2" HeaderText="Nilai Pasar">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Right"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="CL_VALUE" HeaderText="Nilai Bank">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Right"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="CL_VALUEINS" HeaderText="Nilai Asuransi">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Right"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="CL_VALUEIKAT" HeaderText="Nilai Pengikatan">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Right"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="CL_VALUEPPA" HeaderText="Nilai Pengurang PPA">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Right"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="CL_VALUELIQ" HeaderText="Nilai Likuidasi">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Right"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="LC_PERCENTAGE" HeaderText="% Use">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn HeaderText="Nilai Akhir">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Right"></ItemStyle>
													</asp:BoundColumn>
													<asp:TemplateColumn>
														<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
														<ItemTemplate>
															<asp:LinkButton id="Linkbutton2" runat="server" CommandName="delete">Delete</asp:LinkButton>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:BoundColumn Visible="False" DataField="ISNEW" HeaderText="ISNEW"></asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="CL_CURRENCY" HeaderText="Currency"></asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="CL_COLCLASSIFY" HeaderText="ColClassify"></asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="CL_FOREIGNVAL2" HeaderText="ForeignValuePasar"></asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="CL_FOREIGNVAL" HeaderText="ForeignValueBank"></asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="CL_FOREIGNVALINS" HeaderText="ForeignValueAsuransi"></asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="CL_FOREIGNVALIKAT" HeaderText="ForeignValuePengikatan"></asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="CL_FOREIGNVALPPA" HeaderText="ForeignValuePengurangPPA"></asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="CL_FOREIGNVALLIQ" HeaderText="ForeignValueLikuidasi"></asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="CL_EXCHANGERATE" HeaderText="ExchangeRate"></asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="CL_PENILAIANDATE" HeaderText="PenilaianDate"></asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="CL_PENILAIANBY" HeaderText="PenilaianBy"></asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="SIBS_COLID" HeaderText="SIBSColID"></asp:BoundColumn>
												</Columns>
												<PagerStyle Mode="NumericPages"></PagerStyle>
											</ASP:DATAGRID></TD>
									</TR>
									<TR>
										<TD class="td" vAlign="top" align="center" colSpan="2">
											<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%">
												<TR>
													<TD width="129" colSpan="3"><asp:radiobuttonlist id="RDO_COLLATERAL" runat="server" AutoPostBack="True" Width="150px" RepeatDirection="Horizontal">
															<asp:ListItem Value="1" Selected="True">New</asp:ListItem>
															<asp:ListItem Value="2">Existing</asp:ListItem>
														</asp:radiobuttonlist></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1"><asp:label id="Label1" runat="server"></asp:label></TD>
													<TD style="WIDTH: 15px"></TD>
													<TD class="TDBGColorValue">
														<asp:dropdownlist id="DDL_CL_TYPE" runat="server"></asp:dropdownlist>
														<asp:dropdownlist id="DDL_CL_TYPE_EXISTING" runat="server" AutoPostBack="True" Visible="False"></asp:dropdownlist>
														<asp:label id="LBL_SISAUTILIZATION" runat="server" Visible="False">100</asp:label>
														<asp:textbox onkeypress="return digitsonly()" id="TXT_LC_PERCENTAGE" runat="server" MaxLength="3"
															Width="50px" Visible="False">100</asp:textbox>
													</TD>
												</TR>
												<TR>
													<TD class="TDBGColor1"><asp:label id="Label2" runat="server"></asp:label></TD>
													<TD style="WIDTH: 15px"></TD>
													<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CL_DESC" runat="server" CssClass="mandatoryColl"
															MaxLength="150" Width="300px"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">eMAS Colateral ID</TD>
													<TD style="WIDTH: 15px"></TD>
													<TD class="TDBGColorValue"><asp:textbox id="TXT_COL_ID" runat="server" BorderStyle="None" ReadOnly="True" Width="300px"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Bukti Kepemilikan</TD>
													<TD style="WIDTH: 15px; HEIGHT: 11px"></TD>
													<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_BUKTI_KEPEMILIKAN" runat="server" CssClass="mandatoryColl"></asp:dropdownlist></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Bentuk Pengikatan</TD>
													<TD style="WIDTH: 15px; HEIGHT: 11px"></TD>
													<TD class="TDBGColorValue" style="HEIGHT: 11px"><asp:dropdownlist id="DDL_BENTUK_PENGIKATAN" runat="server" CssClass="mandatoryColl"></asp:dropdownlist></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="HEIGHT: 11px">Klasifikasi Jaminan</TD>
													<TD style="WIDTH: 15px; HEIGHT: 11px"></TD>
													<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CL_COLCLASSIFY" runat="server" CssClass="mandatoryColl"></asp:dropdownlist></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Currency</TD>
													<TD style="WIDTH: 15px"></TD>
													<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CL_CURRENCY" runat="server" AutoPostBack="True" CssClass="mandatoryColl"></asp:dropdownlist></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Exchange Rate to Rp</TD>
													<TD style="WIDTH: 15px"></TD>
													<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CL_EXCHANGERATE" onblur="FormatCurrency(this), FormatCurrency(document.Form1.TXT_CL_VALUE), FormatCurrency(document.Form1.TXT_CL_VALUE2), FormatCurrency(document.Form1.TXT_CL_VALUEINS), FormatCurrency(document.Form1.TXT_CL_VALUEIKAT), FormatCurrency(document.Form1.TXT_CL_VALUEPPA)"
															onkeyup="HitungColValue();HitungColValue2();HitungColValue3();HitungColValue4();HitungColValue5();HitungColValue6();"
															runat="server" MaxLength="10" Width="100px" CssClass="mandatoryColl">1</asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" width="129">Nilai Bank</TD>
													<TD style="WIDTH: 15px"></TD>
													<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CL_FOREIGNVAL" onblur="FormatCurrency(this), FormatCurrency(document.Form1.TXT_CL_VALUE)"
															onkeyup="HitungColValue()" runat="server" MaxLength="15" Width="200px" CssClass="mandatoryColl"></asp:textbox>&nbsp;&nbsp;in 
														Rp&nbsp;
														<asp:textbox id="TXT_CL_VALUE" runat="server" BorderStyle="None" ReadOnly="True" Width="200px"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Nilai Pasar</TD>
													<TD style="WIDTH: 15px"></TD>
													<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CL_FOREIGNVAL2" onblur="FormatCurrency(this), FormatCurrency(document.Form1.TXT_CL_VALUE2)"
															onkeyup="HitungColValue2()" runat="server" MaxLength="15" Width="200px"></asp:textbox>&nbsp;&nbsp;in 
														Rp&nbsp;
														<asp:textbox id="TXT_CL_VALUE2" runat="server" BorderStyle="None" ReadOnly="True" Width="200px"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" width="129">Nilai Asuransi</TD>
													<TD style="WIDTH: 15px"></TD>
													<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CL_FOREIGNVALINS" onblur="FormatCurrency(this), FormatCurrency(document.Form1.TXT_CL_VALUEINS)"
															onkeyup="HitungColValue3()" runat="server" MaxLength="15" Width="200px"></asp:textbox>&nbsp;&nbsp;in 
														Rp&nbsp;
														<asp:textbox id="TXT_CL_VALUEINS" runat="server" BorderStyle="None" ReadOnly="True" Width="200px"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" width="129">Nilai Pengikatan</TD>
													<TD style="WIDTH: 15px"></TD>
													<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CL_FOREIGNVALIKAT" onblur="FormatCurrency(this), FormatCurrency(document.Form1.TXT_CL_VALUEIKAT)"
															onkeyup="HitungColValue4()" runat="server" MaxLength="15" Width="200px"></asp:textbox>&nbsp;&nbsp;in 
														Rp&nbsp;
														<asp:textbox id="TXT_CL_VALUEIKAT" runat="server" BorderStyle="None" ReadOnly="True" Width="200px"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" width="129">Nilai Pengurang PPA</TD>
													<TD style="WIDTH: 15px"></TD>
													<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CL_FOREIGNVALPPA" onblur="FormatCurrency(this), FormatCurrency(document.Form1.TXT_CL_VALUEPPA)"
															onkeyup="HitungColValue5()" runat="server" MaxLength="15" Width="200px"></asp:textbox>&nbsp;&nbsp;in 
														Rp&nbsp;
														<asp:textbox id="TXT_CL_VALUEPPA" runat="server" BorderStyle="None" ReadOnly="True" Width="200px"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" width="129">Nilai Likuidasi</TD>
													<TD style="WIDTH: 15px"></TD>
													<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CL_FOREIGNVALLIQ" onblur="FormatCurrency(this), FormatCurrency(document.Form1.TXT_CL_VALUELIQ)"
															onkeyup="HitungColValue6()" runat="server" MaxLength="15" Width="200px"></asp:textbox>&nbsp;&nbsp;in 
														Rp&nbsp;
														<asp:textbox id="TXT_CL_VALUELIQ" runat="server" BorderStyle="None" ReadOnly="True" Width="200px"></asp:textbox></TD>
												</TR>
												<!--<TR>
													<TD class="TDBGColor1">% Use</TD>
													<TD style="WIDTH: 15px"></TD>
													<TD class="TDBGColorValue"></TD>
												</TR>-->
												<TR>
													<TD class="TDBGColor1">Tanggal Penilaian</TD>
													<TD style="WIDTH: 15px"></TD>
													<TD class="TDBGColorValue"><asp:textbox id="TXT_TGLPENILAIAN_DAY" runat="server" MaxLength="2" Columns="4" CssClass="mandatoryColl"></asp:textbox><asp:dropdownlist id="DDL_TGLPENILAIAN_MONTH" runat="server" CssClass="mandatoryColl"></asp:dropdownlist><asp:textbox id="TXT_TGLPENILAIAN_YEAR" runat="server" MaxLength="4" Columns="4" CssClass="mandatoryColl"></asp:textbox></TD>
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
								</TABLE>
							</P>
						</TD>
					</TR>
					<TR id="TR_BUTTONS" runat="server">
						<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2"><asp:button id="BTN_SAVE" runat="server" CssClass="Button1" Width="125px" Text="Save"></asp:button>&nbsp;</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" align="center" width="50%" colSpan="2">
							<ASP:DATAGRID id="DATAGRID1" runat="server" Width="100%" PageSize="5" AutoGenerateColumns="False"
								AllowPaging="True">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="TRAN_TYPE" HeaderText="Transaction Type">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="APPTYPE"></asp:BoundColumn>
									<asp:BoundColumn DataField="FACILITY" HeaderText="Facility">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AMOUNT" HeaderText="Amount" DataFormatString="{0:00,00.00}">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="PRODUCTID" HeaderText="PRODUCTID"></asp:BoundColumn>
									<asp:BoundColumn DataField="TENOR" HeaderText="Tenor">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="PROD_SEQ" HeaderText="PROD_SEQ"></asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Function">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											&nbsp;&nbsp;&nbsp;
											<asp:LinkButton id="LNK_DELETE" runat="server" CommandName="delete">Delete</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
					<TR id="Tr1" runat="server">
						<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2">
							<asp:button id="Button1" runat="server" CssClass="Button1" Visible="False" Width="150px" Text="Update Status"
								Enabled="False"></asp:button>&nbsp;</TD>
					</TR>
				</TABLE>
			</center>
		</form>
		<script language="javascript">
		function buka()
		{
			window.open("../DataEntry/SkalaAngsuran_Main.aspx", "", "width=640,height=400, scrollbars=yes");
		}
		</script>
	</body>
</HTML>
