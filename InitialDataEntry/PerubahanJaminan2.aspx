<%@ Page language="c#" Codebehind="PerubahanJaminan2.aspx.cs" AutoEventWireup="True" Inherits="SME.InitialDataEntry.PerubahanJaminan2" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PerubahanJaminan2</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_entries.html" -->
		<!-- #include file="../include/cek_mandatoryColl.html" -->
		<script language="javascript">
		    function IsNumeric(n) {
		        return !isNaN(parseFloat(n)) && isFinite(n);
		    }

		    function HitungColValue() {
		        var CL_FOREIGNVAL = window.document.getElementById('TXT_CL_FOREIGNVAL').value;
		        var CL_EXCHANGERATE = window.document.getElementById('TXT_CL_EXCHANGERATE').value;
		        var CL_VALUE;
		        var FOREIGNVAL;
		        var EXCHANGERATE;

		        if (IsNumeric(parseFloat(CL_FOREIGNVAL)))
		            FOREIGNVAL = parseFloat(CL_FOREIGNVAL.replace(/\./g, ''));
		        else
		            FOREIGNVAL = 0;

		        if (IsNumeric(parseFloat(CL_EXCHANGERATE)))
		            EXCHANGERATE = parseFloat(CL_EXCHANGERATE.replace(/\./g, ''));
		        else
		            EXCHANGERATE = 0;
		        CL_VALUE = FOREIGNVAL * EXCHANGERATE;
		        /*CL_VALUE = CL_VALUE.replace('.', ',');*/
		        window.document.getElementById('TXT_CL_VALUE').value = CL_VALUE;
		    }

		    function HitungColValue2() {
		        var CL_FOREIGNVAL = window.document.getElementById('TXT_CL_FOREIGNVAL2').value;
		        var CL_EXCHANGERATE = window.document.getElementById('TXT_CL_EXCHANGERATE').value;
		        var CL_VALUE;
		        var FOREIGNVAL;
		        var EXCHANGERATE;

		        if (IsNumeric(parseFloat(CL_FOREIGNVAL)))
		            FOREIGNVAL = parseFloat(CL_FOREIGNVAL.replace(/\./g, ''));
		        else
		            FOREIGNVAL = 0;

		        if (IsNumeric(parseFloat(CL_EXCHANGERATE)))
		            EXCHANGERATE = parseFloat(CL_EXCHANGERATE.replace(/\./g, ''));
		        else
		            EXCHANGERATE = 0;
		        CL_VALUE = FOREIGNVAL * EXCHANGERATE;
		        /*CL_VALUE = CL_VALUE.replace('.', ',');*/
		        window.document.getElementById('TXT_CL_VALUE2').value = CL_VALUE;
		    }

		    function HitungColValue3() {
		        var CL_FOREIGNVAL = window.document.getElementById('TXT_CL_FOREIGNVALINS').value;
		        var CL_EXCHANGERATE = window.document.getElementById('TXT_CL_EXCHANGERATE').value;
		        var CL_VALUE;
		        var FOREIGNVAL;
		        var EXCHANGERATE;

		        if (IsNumeric(parseFloat(CL_FOREIGNVAL)))
		            FOREIGNVAL = parseFloat(CL_FOREIGNVAL.replace(/\./g, ''));
		        else
		            FOREIGNVAL = 0;

		        if (IsNumeric(parseFloat(CL_EXCHANGERATE)))
		            EXCHANGERATE = parseFloat(CL_EXCHANGERATE.replace(/\./g, ''));
		        else
		            EXCHANGERATE = 0;
		        CL_VALUE = FOREIGNVAL * EXCHANGERATE;
		        /*CL_VALUE = CL_VALUE.replace('.', ',');*/
		        window.document.getElementById('TXT_CL_VALUEINS').value = CL_VALUE;
		    }

		    function HitungColValue4() {
		        var CL_FOREIGNVAL = window.document.getElementById('TXT_CL_FOREIGNVALIKAT').value;
		        var CL_EXCHANGERATE = window.document.getElementById('TXT_CL_EXCHANGERATE').value;
		        var CL_VALUE;
		        var FOREIGNVAL;
		        var EXCHANGERATE;

		        if (IsNumeric(parseFloat(CL_FOREIGNVAL)))
		            FOREIGNVAL = parseFloat(CL_FOREIGNVAL.replace(/\./g, ''));
		        else
		            FOREIGNVAL = 0;

		        if (IsNumeric(parseFloat(CL_EXCHANGERATE)))
		            EXCHANGERATE = parseFloat(CL_EXCHANGERATE.replace(/\./g, ''));
		        else
		            EXCHANGERATE = 0;
		        CL_VALUE = FOREIGNVAL * EXCHANGERATE;
		        /*CL_VALUE = CL_VALUE.replace('.', ',');*/
		        window.document.getElementById('TXT_CL_VALUEIKAT').value = CL_VALUE;
		    }

		    function HitungColValue5() {
		        var CL_FOREIGNVAL = window.document.getElementById('TXT_CL_FOREIGNVALPPA').value;
		        var CL_EXCHANGERATE = window.document.getElementById('TXT_CL_EXCHANGERATE').value;
		        var CL_VALUE;
		        var FOREIGNVAL;
		        var EXCHANGERATE;

		        if (IsNumeric(parseFloat(CL_FOREIGNVAL)))
		            FOREIGNVAL = parseFloat(CL_FOREIGNVAL.replace(/\./g, ''));
		        else
		            FOREIGNVAL = 0;

		        if (IsNumeric(parseFloat(CL_EXCHANGERATE)))
		            EXCHANGERATE = parseFloat(CL_EXCHANGERATE.replace(/\./g, ''));
		        else
		            EXCHANGERATE = 0;
		        CL_VALUE = FOREIGNVAL * EXCHANGERATE;
		        /*CL_VALUE = CL_VALUE.replace('.', ',');*/
		        window.document.getElementById('TXT_CL_VALUEPPA').value = CL_VALUE;
		    }

		    function HitungColValue6() {
		        var CL_FOREIGNVAL = window.document.getElementById('TXT_CL_FOREIGNVALLIQ').value;
		        var CL_EXCHANGERATE = window.document.getElementById('TXT_CL_EXCHANGERATE').value;
		        var CL_VALUE;
		        var FOREIGNVAL;
		        var EXCHANGERATE;

		        if (IsNumeric(parseFloat(CL_FOREIGNVAL)))
		            FOREIGNVAL = parseFloat(CL_FOREIGNVAL.replace(/\./g, ''));
		        else
		            FOREIGNVAL = 0;

		        if (IsNumeric(parseFloat(CL_EXCHANGERATE)))
		            EXCHANGERATE = parseFloat(CL_EXCHANGERATE.replace(/\./g, ''));
		        else
		            EXCHANGERATE = 0;
		        CL_VALUE = FOREIGNVAL * EXCHANGERATE;
		        /*CL_VALUE = CL_VALUE.replace('.', ',');*/
		        window.document.getElementById('TXT_CL_VALUELIQ').value = CL_VALUE;
		    }
		</script>
		<script language="javascript">
			function SaveMsg()
			{			
				msg = "1. Agar dicheck apakah tujuan proposal sudah sesuai dengan surat permohonan calon debitur.";
				
				conf = confirm(msg);
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
											Perubahan Jaminan</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><A href="../Body.aspx"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" colSpan="2" style="HEIGHT: 41px" align="center">
							<asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					-->
					<TR>
						<TD class="tdHeader1" colSpan="2">Informasi Loan</TD>
					</TR>
					<TR id="TR_JENISPENGAJUAN" runat="server">
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Jenis Pengajuan</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_APPTYPE" runat="server" CssClass="mandatory" AutoPostBack="True" onselectedindexchanged="DDL_APPTYPE_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">AA No.</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_AA_NO" runat="server" CssClass="mandatory" AutoPostBack="True" onselectedindexchanged="DDL_AA_NO_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">No. Fasilitas</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_PRODUCTID" runat="server" CssClass="mandatory" AutoPostBack="True" onselectedindexchanged="DDL_PRODUCTID_SelectedIndexChanged"></asp:dropdownlist><asp:dropdownlist id="DDL_FACILITYNO" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_FACILITYNO_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jenis Kredit</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PRODUCTDESC" runat="server" BorderStyle="None" MaxLength="80" ReadOnly="True"
											Width="300"></asp:textbox></TD>
								</TR>
								<TR>
									<TD>&nbsp;</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD><asp:label id="LBL_PRODUCTID" runat="server" Visible="False"></asp:label><asp:label id="LBL_USERID" runat="server" Visible="False"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Limit</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_LIMIT" runat="server" BorderStyle="None"
											MaxLength="15" ReadOnly="True" Width="250px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jangka Waktu</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_TENORDESC" runat="server" BorderStyle="None"
											MaxLength="3" ReadOnly="True"></asp:textbox><asp:label id="LBL_SEQ" runat="server" Visible="False"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tujuan Penggunaan</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CP_LOANPURPOSE" runat="server"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Keterangan</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CP_NOTES" runat="server" MaxLength="200"
											Width="100%" TextMode="MultiLine" Height="100px"></asp:textbox></TD>
								</TR>
							</TABLE>
							<asp:label id="LBL_MAINREGNO" runat="server" Visible="False"></asp:label><asp:label id="LBL_MAINPROD_SEQ" runat="server" Visible="False"></asp:label><asp:label id="LBL_MAINPRODUCTID" runat="server" Visible="False"></asp:label></TD>
					</TR>
					<TR id="TR_COLL" runat="server">
						<TD class="td" vAlign="top" align="center" width="50%" colSpan="2">
							<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="100%" border="0">
								<TR>
									<TD class="tdHeader1">Existing Collateral</TD>
								</TR>
								<TR>
									<TD align="center"><ASP:DATAGRID id="DatGrdOld" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False"
											PageSize="5" CellPadding="1">
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
												<asp:BoundColumn Visible="False" DataField="CL_FOREIGNVAL2" HeaderText="ForeignValuePasar"></asp:BoundColumn>
												<asp:BoundColumn DataField="CL_VALUE2" HeaderText="Nilai Pasar">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Right"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="CL_FOREIGNVAL" HeaderText="ForeignValueBank"></asp:BoundColumn>
												<asp:BoundColumn DataField="CL_VALUE" HeaderText="Nilai Bank">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Right"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="CL_FOREIGNVALINS" HeaderText="ForeignValueAsuransi"></asp:BoundColumn>
												<asp:BoundColumn DataField="CL_VALUEINS" HeaderText="Nilai Asuransi">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Right"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="CL_FOREIGNVALIKAT" HeaderText="ForeignValuePegikatan"></asp:BoundColumn>
												<asp:BoundColumn DataField="CL_VALUEIKAT" HeaderText="Nilai Pengikatan">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Right"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="CL_FOREIGNVALPPA" HeaderText="ForeignValuePenurunanPPA"></asp:BoundColumn>
												<asp:BoundColumn DataField="CL_VALUEPPA" HeaderText="Nilai Penurunan PPA">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Right"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="CL_FOREIGNVALLIQ" HeaderText="ForeignValueLikuidasi"></asp:BoundColumn>
												<asp:BoundColumn DataField="CL_VALUELIQ" HeaderText="Nilai Likuidasi">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Right"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="CL_PERCENT" HeaderText="% Use">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn HeaderText="Nilai Akhir">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Right"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn Visible="False" HeaderText="ISNEW"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="CL_CURRENCY" HeaderText="Currency"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="CL_COLCLASSIFY" HeaderText="ColClassify"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="CL_EXCHANGERATE" HeaderText="ExchangeRate"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="CL_PENILAIANDATE" HeaderText="ExchangeRate"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="CL_PENILAIANBY" HeaderText="ExchangeRate"></asp:BoundColumn>
											</Columns>
											<PagerStyle Mode="NumericPages"></PagerStyle>
										</ASP:DATAGRID></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR id="TR_COLL2" runat="server">
						<TD class="td" vAlign="top" align="center" width="50%" colSpan="2">
							<TABLE id="Table7" cellSpacing="1" cellPadding="1" width="100%" border="0">
								<TR>
									<TD class="tdHeader1">Requested Collateral</TD>
								</TR>
								<TR>
									<TD align="center"><ASP:DATAGRID id="DatGrd" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False"
											PageSize="5" CellPadding="1">
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
												<asp:BoundColumn Visible="False" DataField="CL_FOREIGNVAL2" HeaderText="ForeignValuePasar"></asp:BoundColumn>
												<asp:BoundColumn DataField="CL_VALUE2" HeaderText="Nilai Pasar">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Right"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="CL_FOREIGNVAL" HeaderText="ForeignValueBank"></asp:BoundColumn>
												<asp:BoundColumn DataField="CL_VALUE" HeaderText="Nilai Bank">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Right"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="CL_FOREIGNVALINS" HeaderText="ForeignValueAsuransi"></asp:BoundColumn>
												<asp:BoundColumn DataField="CL_VALUEINS" HeaderText="Nilai Asuransi">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Right"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="CL_FOREIGNVALIKAT" HeaderText="ForeignValuePengikatan"></asp:BoundColumn>
												<asp:BoundColumn DataField="CL_VALUEIKAT" HeaderText="Nilai Pengikatan">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Right"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="CL_FOREIGNVALPPA" HeaderText="ForeignValuePenurunanPPA"></asp:BoundColumn>
												<asp:BoundColumn DataField="CL_VALUEPPA" HeaderText="Nilai Penurunan PPA">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Right"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="CL_FOREIGNVALLIQ" HeaderText="ForeignValueLikuidasi"></asp:BoundColumn>
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
												<asp:BoundColumn Visible="False" DataField="ISNEW" HeaderText="ISNEW"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="CL_CURRENCY" HeaderText="Currency"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="CL_COLCLASSIFY" HeaderText="ColClassify"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="CL_EXCHANGERATE" HeaderText="ExchangeRate"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="CL_PENILAIANDATE" HeaderText="ExchangeRate"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="CL_PENILAIANBY" HeaderText="ExchangeRate"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="LC_ACTION" HeaderText="Col Type"></asp:BoundColumn>
												<asp:BoundColumn DataField="LC_ACTIONDESC" HeaderText="Action">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:TemplateColumn>
													<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
													<ItemTemplate>
														<asp:LinkButton id="LinkButton1" runat="server" CommandName="delete">Delete</asp:LinkButton>
													</ItemTemplate>
												</asp:TemplateColumn>
											</Columns>
											<PagerStyle Mode="NumericPages"></PagerStyle>
										</ASP:DATAGRID></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR id="TR_COLLENTRY" runat="server">
						<TD class="td" vAlign="top" align="center" colSpan="2">
							<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD width="129" colSpan="3"><asp:radiobuttonlist id="RDO_COLLATERAL" runat="server" AutoPostBack="True" Width="150px" RepeatDirection="Horizontal" onselectedindexchanged="RDO_COLLATERAL_SelectedIndexChanged">
											<asp:ListItem Value="1" Selected="True">New</asp:ListItem>
											<asp:ListItem Value="2">Existing</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jenis Jaminan</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CL_TYPE" runat="server" CssClass="mandatoryColl"></asp:dropdownlist><asp:textbox onkeypress="return kutip_satu()" id="TXT_CL_COLTYPEDESC" runat="server" CssClass="mandatoryColl"
											MaxLength="60" ReadOnly="True" Visible="False"></asp:textbox>
										<asp:textbox onkeypress="return digitsonly()" id="TXT_LC_PERCENTAGE" runat="server" MaxLength="3"
											Width="50px" Visible="False">100</asp:textbox>
										<asp:label id="LBL_SISAUTILIZATION" runat="server" Visible="False">100</asp:label>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Keterangan</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CL_DESC" runat="server" CssClass="mandatoryColl"
											MaxLength="100"></asp:textbox><asp:dropdownlist id="DDL_CL_TYPE_EXISTING" runat="server" CssClass="mandatoryColl" AutoPostBack="True"
											Visible="False" onselectedindexchanged="DDL_CL_TYPE_EXISTING_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">eMAS Colateral ID</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_COL_ID" runat="server" BorderStyle="None" ReadOnly="True" Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Bukti Kepemilikan</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_BUKTI_KEPEMILIKAN" runat="server" CssClass="mandatoryColl"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Bentuk Pengikatan</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 11px"><asp:dropdownlist id="DDL_BENTUK_PENGIKATAN" runat="server" CssClass="mandatoryColl"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 11px">Klasifikasi Jaminan</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CL_COLCLASSIFY" runat="server" CssClass="mandatoryColl"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Currency</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CL_CURRENCY" runat="server" CssClass="mandatoryColl" AutoPostBack="True" onselectedindexchanged="DDL_CL_CURRENCY_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Exchange Rate to Rp</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CL_EXCHANGERATE" onblur="FormatCurrency(this), FormatCurrency(document.Form1.TXT_CL_VALUE), FormatCurrency(document.Form1.TXT_CL_VALUE2), FormatCurrency(document.Form1.TXT_CL_VALUEINS), FormatCurrency(document.Form1.TXT_CL_VALUEIKAT), FormatCurrency(document.Form1.TXT_CL_VALUEPPA)"
											onkeyup="HitungColValue();HitungColValue2();HitungColValue3();HitungColValue4();HitungColValue5();HitungColValue6();"
											runat="server" CssClass="mandatoryColl" MaxLength="10" Width="100px">1</asp:textbox></TD>
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
											onkeyup="HitungColValue2()" runat="server" MaxLength="15" Width="200px" CssClass="mandatoryColl"></asp:textbox>&nbsp;&nbsp;in 
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
									<TD class="TDBGColor1" width="129">Nilai Penurunan PPA</TD>
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
									<TD class="TDBGColorValue">
									</TD>
								</TR>-->
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
								<TR>
									<TD class="TDBGColor1">Action</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:radiobuttonlist id="rdoAction" runat="server" Width="224px" RepeatDirection="Horizontal"></asp:radiobuttonlist></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR id="TR_BUTTONCOLL" runat="server">
						<TD vAlign="top" align="center" width="50%" colSpan="2"><asp:button id="BTN_INSCOLL" runat="server" CssClass="button1" Text="Tambah Collateral" onclick="BTN_INSCOLL_Click"></asp:button></TD>
					</TR>
					<TR id="TR_BUTTONS" runat="server">
						<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2"><asp:button id="BTN_SAVE" runat="server" CssClass="Button1" Width="70px" Text="Save" onclick="BTN_SAVE_Click"></asp:button>&nbsp;
							<asp:button id="Button2" runat="server" CssClass="Button1" Width="70px" Visible="False" Text="Next"
								Enabled="False" onclick="Button2_Click"></asp:button><asp:button id="Button1" runat="server" CssClass="Button1" Visible="False" Text="Update Status"
								Enabled="False" onclick="Button1_Click"></asp:button></TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" align="center" width="50%" colSpan="2"><ASP:DATAGRID id="DATAGRID1" runat="server" Width="100%" AutoGenerateColumns="False" PageSize="1"
								CellPadding="1">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="CP_FACILITYNO" HeaderText="Fasilitas No">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="120px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="APPTYPE" HeaderText="APPTYPE">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="APPTYPEDESC" HeaderText="Jenis Pengajuan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="PRODUCTID" HeaderText="PRODUCTID">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PRODUCTDESC" HeaderText="Jenis Kredit">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CP_EXLIMITVAL" HeaderText="Limit">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CP_LIMITCHGTO" HeaderText="Limit Lama">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="TENORDESC" HeaderText="Tenor">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="TENORLAMA" HeaderText="Tenor Lama">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="PROD_SEQ" HeaderText="PROD_SEQ"></asp:BoundColumn>
									<asp:TemplateColumn>
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="LinkButton2" runat="server" CommandName="delete">Delete</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</ASP:DATAGRID></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
