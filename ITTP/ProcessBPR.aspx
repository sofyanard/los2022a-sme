<%@ Page language="c#" Codebehind="ProcessBPR.aspx.cs" AutoEventWireup="True" Inherits="SME.ITTP.ProcessBPR" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ProcessBPR</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_mandatoryOnly.html" -->
		<!-- #include file="../include/cek_mandatory.html" -->
		<!-- #include file="../include/cek_entries.html" -->
		<!-- #include file="../include/popup.html" -->
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
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 0px" cellSpacing="1"
				cellPadding="1" width="100%" border="0">
				<TBODY>
					<TR>
						<TD>
							<TABLE id="Table2">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B><a name="Top">Process</a></B></TD>
								</TR>
							</TABLE>
						</TD>
						<td align="right"><asp:imagebutton id="BTN_BACK" runat="server" Visible="False" ImageUrl="../Image/back.jpg"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A>
						</td>
					</TR>
					<TR>
						<TD class="tdnoborder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<TR id="TR_JUDUL" runat="server">
						<TD class="tdheader1" style="HEIGHT: 27px" colSpan="2">Request</TD>
					</TR>
					<TR>
					</TR>
					<TR>
						<TD colSpan="2"></TD>
					</TR>
					<TR id="TR_BODY" runat="server">
						<TD align="center" colSpan="2">
							<TABLE class="td" id="Table7" cellSpacing="1" cellPadding="1" width="100%" border="0">
								<TBODY>
									<TR>
										<td>
											<TABLE class="TD" id="TBL_DETAIL" cellSpacing="1" cellPadding="1" width="100%" border="0"
												runat="server">
												<TBODY>
													<TR id="TR_COLL1" runat="server">
														<TD align="center" colSpan="2">
															<TABLE class="td" id="Table7" cellSpacing="1" cellPadding="1" width="100%" border="0">
																<TR>
																	<TD>
																		<TABLE id="Table3" style="WIDTH: 1196px; HEIGHT: 132px" cellSpacing="1" cellPadding="1"
																			width="1196" border="0">
																			<TR>
																				<TD class="TDBGColor1" style="WIDTH: 406px; HEIGHT: 26px"><FONT size="2">Product</FONT></TD>
																				<TD style="HEIGHT: 26px">:</TD>
																				<TD style="HEIGHT: 26px"><asp:dropdownlist id="DDL_PRODUCTID" runat="server" Width="296px" AutoPostBack="True" CssClass="mandatory" onselectedindexchanged="DDL_PRODUCTID_SelectedIndexChanged"></asp:dropdownlist></TD>
																			</TR>
																			<TR>
																				<TD class="TDBGColor1" style="WIDTH: 406px; HEIGHT: 17px"><FONT size="2">Purpose Code</FONT></TD>
																				<TD style="HEIGHT: 17px">:</TD>
																				<TD style="HEIGHT: 17px"><FONT size="2"><asp:dropdownlist id="DDL_CP_LOANPURPOSE" runat="server" Width="296px" CssClass="mandatory"></asp:dropdownlist></FONT></TD>
																			</TR>
																			<TR>
																				<TD class="TDBGColor1" style="WIDTH: 406px; HEIGHT: 22px"><FONT size="2">Amount</FONT></TD>
																				<TD style="HEIGHT: 22px"><FONT size="2">:</FONT></TD>
																				<TD style="HEIGHT: 22px"><asp:textbox id="TXT_CP_EXLIMITVAL" runat="server" Width="300px" CssClass="mandatory2" MaxLength="50"></asp:textbox><FONT size="2"></FONT></TD>
																			</TR>
																			<TR>
																				<TD class="TDBGColor1" style="WIDTH: 406px; HEIGHT: 22px"><FONT size="2">Exchange Rate 
																						to Rp</FONT></TD>
																				<TD style="HEIGHT: 22px">:</TD>
																				<TD style="HEIGHT: 22px"><asp:textbox onkeypress="return digitsonly()" id="TXT_CP_EXRPLIMIT" onblur="FormatCurrency(this), FormatCurrency(document.Form1.TXT_CP_LIMIT)"
																						onkeyup="HitungLimit()" runat="server" CssClass="mandatory2" MaxLength="15">1</asp:textbox></TD>
																			</TR>
																			<TR>
																				<TD class="TDBGColor1" style="WIDTH: 406px; HEIGHT: 22px"><FONT size="2">Limit in Rp</FONT></TD>
																				<TD style="HEIGHT: 22px">:</TD>
																				<TD style="HEIGHT: 22px"><asp:textbox id="TXT_CP_LIMIT" runat="server" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
																			</TR>
																			<!--
																			<TR>
																				<TD class="TDBGColor1" style="WIDTH: 406px; HEIGHT: 22px"><FONT size="2">Tenor</FONT></TD>
																				<TD style="HEIGHT: 22px"><FONT size="2">:</FONT></TD>
																				<TD style="HEIGHT: 22px"><asp:textbox id="TXT_CP_JANGKAWKT" runat="server" Width="24px" CssClass="mandatory2" MaxLength="50"></asp:textbox><asp:dropdownlist id="DDL_CP_TENORCODE" runat="server" CssClass="mandatory2"></asp:dropdownlist><FONT size="2"></FONT></TD>
																			</TR>
																			<TR>
																				<TD class="TDBGColor1" style="WIDTH: 406px; HEIGHT: 19px"><FONT size="2"><FONT size="2"><FONT size="2">Collateral</FONT></FONT></FONT></TD>
																				<TD style="HEIGHT: 19px">:</TD>
																				<TD style="HEIGHT: 19px"><FONT size="2"><asp:checkbox id="CHK_COLLATERAL" runat="server" AutoPostBack="True" Text="(Check for Yes)"></asp:checkbox><FONT size="2">&nbsp;</FONT></FONT></TD>
																			</TR>
																			--></TABLE>
																		<asp:label id="Label8" runat="server" Visible="False"></asp:label><asp:label id="Label9" runat="server" Visible="False"></asp:label><asp:label id="Label10" runat="server" Visible="False"></asp:label></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
												</TBODY>
											</TABLE>
										</td>
									</TR>
									<TR>
										<TD>
											<TABLE id="table10" style="WIDTH: 1216px; HEIGHT: 575px">
												<TR id="TR_COLL2" runat="server">
													<TD>
														<TABLE id="table11">
															<TR>
																<TD align="center" colSpan="2"><ASP:DATAGRID id="DatGrd" runat="server" Width="1206px" AutoGenerateColumns="False" PageSize="7"
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
														</TABLE>
														<!--
														<TABLE id="table12">
															<TR>
																<TD class="td" vAlign="top" align="center" colSpan="2">
																	<TABLE id="Table4" style="WIDTH: 1206px; HEIGHT: 385px" cellSpacing="0" cellPadding="0"
																		width="1206">
																		<TR>
																			<TD colSpan="3"><asp:radiobuttonlist id="RDO_COLLATERAL" runat="server" Width="150px" AutoPostBack="True" RepeatDirection="Horizontal">
																					<asp:ListItem Value="1" Selected="True">New</asp:ListItem>
																					<asp:ListItem Value="2">Existing</asp:ListItem>
																				</asp:radiobuttonlist></TD>
																		</TR>
																		<TR>
																			<TD class="TDBGColor1" style="HEIGHT: 16px"><asp:label id="Label1" runat="server"></asp:label></TD>
																			<TD style="WIDTH: 15px; HEIGHT: 16px"></TD>
																			<TD class="TDBGColorValue" style="HEIGHT: 16px"><asp:dropdownlist id="DDL_CL_TYPE" runat="server"></asp:dropdownlist><asp:dropdownlist id="DDL_CL_TYPE_EXISTING" runat="server" Visible="False" AutoPostBack="True"></asp:dropdownlist><asp:label id="LBL_SISAUTILIZATION" runat="server" Visible="False">100</asp:label><asp:textbox onkeypress="return digitsonly()" id="TXT_LC_PERCENTAGE" runat="server" Visible="False"
																					Width="50px" MaxLength="3">100</asp:textbox></TD>
																		</TR>
																		<TR>
																			<TD class="TDBGColor1">No. Deposito/<asp:label id="Label2" runat="server"></asp:label></TD>
																			<TD style="WIDTH: 15px"></TD>
																			<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CL_DESC" runat="server" Width="300px" CssClass="mandatoryColl"
																					MaxLength="150"></asp:textbox></TD>
																		</TR>
																		<TR>
																			<TD class="TDBGColor1">eMAS Colateral ID</TD>
																			<TD style="WIDTH: 15px"></TD>
																			<TD class="TDBGColorValue"><asp:textbox id="TXT_COL_ID" runat="server" Width="300px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
																		</TR>
																		<TR>
																			<TD class="TDBGColor1">Bukti Kepemilikan</TD>
																			<TD style="WIDTH: 15px; HEIGHT: 11px"></TD>
																			<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_BUKTI_KEPEMILIKAN" runat="server" CssClass="mandatoryColl"></asp:dropdownlist></TD>
																		</TR>
																		<TR>
																			<TD class="TDBGColor1" style="HEIGHT: 21px">Bentuk Pengikatan</TD>
																			<TD style="WIDTH: 15px; HEIGHT: 21px"></TD>
																			<TD class="TDBGColorValue" style="HEIGHT: 21px"><asp:dropdownlist id="DDL_BENTUK_PENGIKATAN" runat="server" CssClass="mandatoryColl"></asp:dropdownlist></TD>
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
																					runat="server" Width="100px" CssClass="mandatoryColl" MaxLength="10">1</asp:textbox></TD>
																		</TR>
																		<TR>
																			<TD class="TDBGColor1" width="129">Nilai Bank</TD>
																			<TD style="WIDTH: 15px"></TD>
																			<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CL_FOREIGNVAL" onblur="FormatCurrency(this), FormatCurrency(document.Form1.TXT_CL_VALUE)"
																					onkeyup="HitungColValue()" runat="server" Width="200px" CssClass="mandatoryColl" MaxLength="15"></asp:textbox>&nbsp;&nbsp;in 
																				Rp&nbsp;
																				<asp:textbox id="TXT_CL_VALUE" runat="server" Width="200px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
																		</TR>
																		<TR>
																			<TD class="TDBGColor1">Nilai Pasar</TD>
																			<TD style="WIDTH: 15px"></TD>
																			<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CL_FOREIGNVAL2" onblur="FormatCurrency(this), FormatCurrency(document.Form1.TXT_CL_VALUE2)"
																					onkeyup="HitungColValue2()" runat="server" Width="200px" MaxLength="15"></asp:textbox>&nbsp;&nbsp;in 
																				Rp&nbsp;
																				<asp:textbox id="TXT_CL_VALUE2" runat="server" Width="200px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
																		</TR>
																		<TR>
																			<TD class="TDBGColor1" width="129">Nilai Asuransi</TD>
																			<TD style="WIDTH: 15px"></TD>
																			<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CL_FOREIGNVALINS" onblur="FormatCurrency(this), FormatCurrency(document.Form1.TXT_CL_VALUEINS)"
																					onkeyup="HitungColValue3()" runat="server" Width="200px" MaxLength="15"></asp:textbox>&nbsp;&nbsp;in 
																				Rp&nbsp;
																				<asp:textbox id="TXT_CL_VALUEINS" runat="server" Width="200px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
																		</TR>
																		<TR>
																			<TD class="TDBGColor1" width="129">Nilai Pengikatan</TD>
																			<TD style="WIDTH: 15px"></TD>
																			<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CL_FOREIGNVALIKAT" onblur="FormatCurrency(this), FormatCurrency(document.Form1.TXT_CL_VALUEIKAT)"
																					onkeyup="HitungColValue4()" runat="server" Width="200px" MaxLength="15"></asp:textbox>&nbsp;&nbsp;in 
																				Rp&nbsp;
																				<asp:textbox id="TXT_CL_VALUEIKAT" runat="server" Width="200px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
																		</TR>
																		<TR>
																			<TD class="TDBGColor1" width="129">Nilai Pengurang PPA</TD>
																			<TD style="WIDTH: 15px"></TD>
																			<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CL_FOREIGNVALPPA" onblur="FormatCurrency(this), FormatCurrency(document.Form1.TXT_CL_VALUEPPA)"
																					onkeyup="HitungColValue5()" runat="server" Width="200px" MaxLength="15"></asp:textbox>&nbsp;&nbsp;in 
																				Rp&nbsp;
																				<asp:textbox id="TXT_CL_VALUEPPA" runat="server" Width="200px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
																		</TR>
																		<TR>
																			<TD class="TDBGColor1" width="129">Nilai Likuidasi</TD>
																			<TD style="WIDTH: 15px"></TD>
																			<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CL_FOREIGNVALLIQ" onblur="FormatCurrency(this), FormatCurrency(document.Form1.TXT_CL_VALUELIQ)"
																					onkeyup="HitungColValue6()" runat="server" Width="200px" MaxLength="15"></asp:textbox>&nbsp;&nbsp;in 
																				Rp&nbsp;
																				<asp:textbox id="TXT_CL_VALUELIQ" runat="server" Width="200px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
																		</TR>
																		<TR>
																			<TD class="TDBGColor1">Tanggal Penilaian</TD>
																			<TD style="WIDTH: 15px"></TD>
																			<TD class="TDBGColorValue"><asp:textbox id="TXT_TGLPENILAIAN_DAY" runat="server" CssClass="mandatoryColl" MaxLength="2"
																					Columns="4"></asp:textbox><asp:dropdownlist id="DDL_TGLPENILAIAN_MONTH" runat="server" CssClass="mandatoryColl"></asp:dropdownlist><asp:textbox id="TXT_TGLPENILAIAN_YEAR" runat="server" CssClass="mandatoryColl" MaxLength="4"
																					Columns="4"></asp:textbox></TD>
																		</TR>
																		<TR>
																			<TD class="TDBGColor1">Penilaian Oleh</TD>
																			<TD style="WIDTH: 15px"></TD>
																			<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_PENILAI_OLEH" runat="server" CssClass="mandatoryColl"></asp:dropdownlist></TD>
																		</TR>
																	</TABLE>
																</TD>
															</TR>
														</TD>
												</TR>
											</TABLE>
											--></TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
									<TBODY>
									</TBODY>
					</TR>
				</TBODY>
			</TABLE>
			<TABLE>
				<TR id="TR_BUTTONS2" runat="server">
					<TD>
						<TABLE>
							<TR>
								<TD align="center" width="50%" colSpan="2"><asp:button id="BTN_INSCOLL" runat="server" CssClass="button1" Text="Tambah Collateral" onclick="BTN_INSCOLL_Click"></asp:button></TD>
							</TR>
						</TABLE>
						<TABLE>
							<TR>
								<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2">&nbsp;
									<asp:button id="BTN_SAVECOLL" runat="server" Width="125px" CssClass="Button1" Text="Save Collateral" onclick="BTN_SAVECOLL_Click"></asp:button></TD>
							</TR>
						</TABLE>
						<table style="VISIBILITY: hidden">
							<tr>
								<td><asp:label id="LBL_REGNO" runat="server" Visible="False"></asp:label><asp:label id="LBL_CUREF" runat="server" Visible="False"></asp:label><asp:label id="LBL_USERID" runat="server" Visible="False"></asp:label><asp:label id="LBL_KET_CODE" runat="server" Visible="False"></asp:label></td>
							</tr>
						</table>
					</TD>
				</TR>
			</TABLE>
			</TD></TR></TBODY>
			<TR id="TR_COLL4" runat="server">
				<TD class="tdbgcolor2" colSpan="2"><asp:button id="BTN_ADD" runat="server" Width="125px" CssClass="button1" Text="Add Request" onclick="BTN_ADD_Click"></asp:button><asp:button id="BTN_CANCEL" runat="server" Visible="False" Width="125px" CssClass="button1"
						Text="Cancel" onclick="BTN_CANCEL_Click"></asp:button></TD>
			</TR>
			<TR id="TR_COLL3" runat="server">
				<TD colSpan="2">
					<TABLE class="td" id="Table8" cellSpacing="1" cellPadding="1" width="100%" border="0">
						<TR>
							<TD class="tdheader1">List Request</TD>
						</TR>
						<TR>
							<TD><ASP:DATAGRID id="DATAGRID1" runat="server" Width="100%" AutoGenerateColumns="False" PageSize="5"
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
												<asp:LinkButton id="LNK_DELETE" runat="server" CommandName="delete">Delete</asp:LinkButton>
											</ItemTemplate>
										</asp:TemplateColumn>
									</Columns>
									<PagerStyle Mode="NumericPages"></PagerStyle>
								</ASP:DATAGRID></TD>
						</TR>
						<TR id="TR_BUTTONS1" runat="server">
							<TD class="tdbgcolor2"><asp:button id="BTN_SAVE" runat="server" Visible="False" Width="180px" Enabled="False" CssClass="button1"
									Text="Save Request"></asp:button><asp:listbox id="ListBox2" runat="server" Visible="False" Width="10px" Height="25px"></asp:listbox></TD>
						</TR>
					</TABLE>
				</TD>
			</TR>
			</TABLE></TD></TR></TBODY></TABLE></TBODY></TABLE></TD></TR></TBODY></TABLE></form>
	</body>
</HTML>
