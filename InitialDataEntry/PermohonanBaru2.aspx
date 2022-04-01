<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PermohonanBaru2.aspx.cs" Inherits="SME.InitialDataEntry.PermohonanBaru2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
	<LINK href="../style.css" type="text/css" rel="stylesheet">
	<!-- #include file="../include/cek_mandatoryColl.html" -->
	<!-- #include file="../include/cek_entries.html" -->
	<!-- #include file="../include/ConfirmBox.html" -->

    <script language="javascript">
            function IsNumeric(n)
            {
                return !isNaN(parseFloat(n)) && isFinite(n);
            }

            function HitungLimit()
            {
                var CP_EXLIMITVAL = window.document.getElementById('TXT_CP_EXLIMITVAL').value;
                var CP_EXRPLIMIT = window.document.getElementById('TXT_CP_EXRPLIMIT').value;
                var CP_LIMIT;
                var EXLIMIT;
                var EXRPLIMIT;

                if (IsNumeric(parseFloat(CP_EXLIMITVAL)))
                    EXLIMIT = parseFloat(CP_EXLIMITVAL.replace(/\./g, ''));
                else
                    EXLIMIT = 0;

                if (IsNumeric(parseFloat(CP_EXRPLIMIT)))
                    EXRPLIMIT = parseFloat(CP_EXRPLIMIT.replace(/\./g, ''));
                else
                    EXRPLIMIT = 0;
                CP_LIMIT = EXLIMIT * EXRPLIMIT;
                /*CP_LIMIT = CP_LIMIT.replace('.', ',');*/
                window.document.getElementById('TXT_CP_LIMIT').value = CP_LIMIT;
            }

            function HitungColValue()
            {
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

            function HitungColValue2()
            {
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

            function HitungColValue3()
            {
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

            function HitungColValue4()
            {
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

            function HitungColValue5()
            {
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

            function HitungColValue6()
            {
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
		    function update() {
		        conf = confirm("Are you sure you want to update?");
		        if (conf) {
		            return true;
		        }
		        else {
		            return false;
		        }
		    }

		    function SaveMsg() {
		        msg = "1. Agar dicheck apakah tujuan proposal sudah sesuai dengan surat permohonan calon debitur.";

		        conf = confirm(msg);
		        if (conf) {
		            return true;
		        }
		        else {
		            return false;
		        }
		    }
		</script>

        <script language="javascript">
            function buka() {
                window.open("../DataEntry/SkalaAngsuran_Main.aspx", "", "width=640,height=400, scrollbars=yes");
			}

            function PopupPage(href, width, height) {
                // if (popupWindow != null) return;
                var X = (screen.width - width) / 2;
                var Y = (screen.height - height) / 2;

                var popupWindow = window.open(href, "",
                    "height=" + height + "px,width=" + width + "px,left=" + X + ",top=" + Y +
                    ",status=no,toolbar=no,titlebar=no,menubar=no,location=no,dependent=yes,scrollbars=yes");
            }
        </script>
</head>
<body>
    <form id="Form1" runat="server">
        <div>
            <table id="Table1" cellSpacing="2" cellPadding="2" width="100%">
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
				<tr>
					<td class="tdHeader1" colSpan="2">Informasi Loan</td>
				<tr id="TR_JENISPENGAJUAN" runat="server">
						<td class="td" vAlign="top" width="50%">
							<table id="Table6" cellSpacing="0" cellPadding="0" width="100%">
								<tr>
									<td class="TDBGColor1" style="WIDTH: 129px">Jenis Pengajuan</td>
									<td style="WIDTH: 15px"></td>
									<td class="TDBGColorValue"><asp:dropdownlist id="DDL_APPTYPE" runat="server" 
                                            AutoPostBack="True" CssClass="mandatory" 
                                            onselectedindexchanged="DDL_APPTYPE_SelectedIndexChanged"></asp:dropdownlist></td>
								</tr>
                                <tr>
									<td class="TDBGColor1">Jenis Kredit</td>
									<td style="WIDTH: 15px"></td>
									<td class="TDBGColorValue"><asp:dropdownlist id="DDL_PRODUCTID" runat="server" 
                                            AutoPostBack="True" CssClass="mandatory" 
                                            onselectedindexchanged="DDL_PRODUCTID_SelectedIndexChanged"></asp:dropdownlist></td>
								</tr>
								<tr>
									<td class="TDBGColor1">Limit</td>
									<td style="WIDTH: 15px"></td>
									<td class="TDBGColorValue">
                                        <asp:textbox onkeypress="return digitsonly()" 
                                            id="TXT_CP_EXLIMITVAL" onblur="FormatCurrency(this), FormatCurrency(document.getElementById('TXT_CP_LIMIT'))"
											onkeyup="HitungLimit()" runat="server" CssClass="mandatory" MaxLength="15" 
                                            ontextchanged="TXT_CP_EXLIMITVAL_TextChanged"></asp:textbox></td>
								</tr>
								<tr>
									<td class="TDBGColor1">Kurs Valuta ke Rp</td>
									<td style="WIDTH: 15px"></td>
									<td class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CP_EXRPLIMIT" onblur="FormatCurrency(this), FormatCurrency(document.getElementById('TXT_CP_LIMIT'))"
											onkeyup="HitungLimit()" runat="server" CssClass="mandatory" MaxLength="15">1</asp:textbox></td>
								</tr>
								<tr>
									<td class="TDBGColor1">Limit dalam Rp</td>
									<td style="WIDTH: 15px"></td>
									<td class="TDBGColorValue"><asp:textbox id="TXT_CP_LIMIT" runat="server" 
                                            BorderStyle="None"></asp:textbox></td>
								</tr>
								<tr>
									<td class="TDBGColor1" style="HEIGHT: 20px">Jangka Waktu</td>
									<td style="WIDTH: 15px; HEIGHT: 20px"></td>
									<td class="TDBGColorValue" style="HEIGHT: 20px"><asp:textbox onkeypress="return numbersonly()" id="TXT_CP_JANGKAWKT" runat="server" CssClass="mandatory"
											MaxLength="3" Columns="3"></asp:textbox><asp:dropdownlist id="DDL_CP_TENORCODE" runat="server" CssClass="mandatory"></asp:dropdownlist></td>
								</tr>
								<tr>
									<td class="TDBGColor1">Tujuan Penggunaan</td>
									<td></td>
									<td class="TDBGColorValue"><asp:dropdownlist id="DDL_CP_LOANPURPOSE" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:label id="LBL_SEQ" runat="server" Visible="False"></asp:label><asp:label id="LBL_USERID" runat="server" Visible="False"></asp:label></td>
								</tr>
							</table>
							<asp:dropdownlist id="DDL_PROJECT_CODE" runat="server" Visible="False"></asp:dropdownlist>
                        </td>
                        <td class="td" vAlign="top" width="50%">
							<table id="Table5" cellSpacing="0" cellPadding="0" width="100%">
								<tr>
									<td class="TDBGColor1" style="WIDTH: 129px">Keterangan</td>
									<td style="WIDTH: 15px"></td>
									<td class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CP_NOTES" runat="server" MaxLength="200"
											TextMode="MultiLine" Height="100px" Width="100%"></asp:textbox></td>
								</tr>
								<tr>
									<td class="TDBGColor1" style="WIDTH: 129px; HEIGHT: 21px">Agunan</td>
									<td style="WIDTH: 15px; HEIGHT: 21px"></td>
									<td class="TDBGColorValue" style="HEIGHT: 21px">
                                        <asp:checkbox id="CHK_COLLATERAL" 
                                            runat="server" AutoPostBack="True" Text="(check jika iya)" 
                                            oncheckedchanged="CHK_COLLATERAL_CheckedChanged" Checked="True"></asp:checkbox></td>
								</tr>
								<tr>
									<td class="TDBGColor1" style="WIDTH: 129px">Alih Debitur</td>
									<td style="WIDTH: 15px"></td>
									<td class="TDBGColorValue">
                                        <asp:checkbox id="CHK_ALIHDEB" runat="server" 
                                            AutoPostBack="True" Text="(check jika iya)" 
                                            oncheckedchanged="CHK_ALIHDEB_CheckedChanged"></asp:checkbox></td>
								</tr>
								<tr id="TR_OLDCIFNO" runat="server">
									<td class="TDBGColor1">Old CIF No.</td>
									<td style="WIDTH: 15px"></td>
									<td class="TDBGColorValue"><asp:textbox id="TXT_OLDCIFNO" runat="server" CssClass="mandatory" MaxLength="19"></asp:textbox></td>
								</tr>
								<tr id="TR_OLDACCNO" runat="server">
									<td class="TDBGColor1">Old Account No.</td>
									<td style="WIDTH: 15px"></td>
									<td class="TDBGColorValue"><asp:textbox id="TXT_OLDACCNO" runat="server" CssClass="mandatory" MaxLength="19"></asp:textbox></td>
								</tr>
								<tr id="TR_MOBILEAPPINFO" runat="server">
									<td colspan="3">
										<input onclick="javascript: PopupPage('MobileApplicationInfo.aspx?regno=<%=Request.QueryString["regno"]%>', '800', '600');"
                                            type="button" value="View Info from Mobile Apps">
									</td>
								</tr>
							</table>
							<asp:label id="LBL_MAINREGNO" runat="server" Visible="False"></asp:label><asp:label id="LBL_MAINPROD_SEQ" runat="server" Visible="False"></asp:label><asp:label id="LBL_MAINPRODUCTID" runat="server" Visible="False"></asp:label>
                        </td>
					</tr>
                    <tr id="TR_COLL" runat="server">
						<td class="td" colSpan="2">
							<P>
								<table id="Table2" cellSpacing="2" cellPadding="2" width="100%" border="0">
									<tr>
										<td align="center" colSpan="2"><ASP:DATAGRID id="DatGrd" runat="server" 
                                                Width="100%" AutoGenerateColumns="False" PageSize="7"
												CellPadding="1" onitemcommand="DatGrd_ItemCommand" onpageindexchanged="DatGrd_PageIndexChanged">
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
											</ASP:DATAGRID></td>
									</tr>
									<tr>
										<td class="td" vAlign="top" align="left" colSpan="2">
											<table id="Table4" cellSpacing="0" cellPadding="0" width="100%">
												<tr>
													<td width="129" colSpan="3"><asp:radiobuttonlist id="RDO_COLLATERAL" runat="server" AutoPostBack="True" Width="150px" RepeatDirection="Horizontal">
															<asp:ListItem Value="1" Selected="True">New</asp:ListItem>
															<asp:ListItem Value="2">Existing</asp:ListItem>
														</asp:radiobuttonlist></td>
												</tr>
												<tr>
													<td class="TDBGColor1"><asp:label id="Label1" runat="server"></asp:label></td>
													<td style="WIDTH: 15px"></td>
													<td class="TDBGColorValue">
														<asp:dropdownlist id="DDL_CL_TYPE" runat="server"></asp:dropdownlist>
														<asp:dropdownlist id="DDL_CL_TYPE_EXISTING" runat="server" AutoPostBack="True" 
                                                            Visible="False" 
                                                            onselectedindexchanged="DDL_CL_TYPE_EXISTING_SelectedIndexChanged"></asp:dropdownlist>
														<asp:label id="LBL_SISAUTILIZATION" runat="server" Visible="False">100</asp:label>
														<asp:textbox onkeypress="return digitsonly()" id="TXT_LC_PERCENTAGE" runat="server" MaxLength="3"
															Width="50px" Visible="False">100</asp:textbox>
													</td>
												</tr>
												<tr>
													<td class="TDBGColor1"><asp:label id="Label2" runat="server"></asp:label></td>
													<td style="WIDTH: 15px"></td>
													<td class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CL_DESC" runat="server" CssClass="mandatoryColl"
															MaxLength="150" Width="300px"></asp:textbox></td>
												</tr>
												<tr>
													<td class="TDBGColor1">Core Colateral ID</td>
													<td style="WIDTH: 15px"></td>
													<td class="TDBGColorValue"><asp:textbox id="TXT_COL_ID" runat="server" Width="300px"></asp:textbox></td>
												</tr>
												<tr>
													<td class="TDBGColor1">Bukti Kepemilikan</td>
													<td style="WIDTH: 15px; HEIGHT: 11px"></td>
													<td class="TDBGColorValue"><asp:dropdownlist id="DDL_BUKTI_KEPEMILIKAN" runat="server" CssClass="mandatoryColl"></asp:dropdownlist></td>
												</tr>
												<tr>
													<td class="TDBGColor1">Bentuk Pengikatan</td>
													<td style="WIDTH: 15px; HEIGHT: 11px"></td>
													<td class="TDBGColorValue" style="HEIGHT: 11px"><asp:dropdownlist id="DDL_BENTUK_PENGIKATAN" runat="server" CssClass="mandatoryColl"></asp:dropdownlist></td>
												</tr>
												<tr>
													<td class="TDBGColor1" style="HEIGHT: 11px">Klasifikasi Jaminan</td>
													<td style="WIDTH: 15px; HEIGHT: 11px"></td>
													<td class="TDBGColorValue"><asp:dropdownlist id="DDL_CL_COLCLASSIFY" runat="server" CssClass="mandatoryColl"></asp:dropdownlist></td>
												</tr>
												<tr>
													<td class="TDBGColor1">Currency</td>
													<td style="WIDTH: 15px"></td>
													<td class="TDBGColorValue"><asp:dropdownlist id="DDL_CL_CURRENCY" runat="server" 
                                                            AutoPostBack="True" 
                                                            onselectedindexchanged="DDL_CL_CURRENCY_SelectedIndexChanged"></asp:dropdownlist></td>
												</tr>
												<tr>
													<td class="TDBGColor1">Exchange Rate to Rp</td>
													<td style="WIDTH: 15px"></td>
													<td class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CL_EXCHANGERATE" onblur="FormatCurrency(this), FormatCurrency(document.getElementById('TXT_CL_VALUE')), FormatCurrency(document.getElementById('TXT_CL_VALUE2')), FormatCurrency(document.getElementById('TXT_CL_VALUEINS')), FormatCurrency(document.getElementById('TXT_CL_VALUEIKAT')), FormatCurrency(document.getElementById('TXT_CL_VALUEPPA')), FormatCurrency(document.getElementById('TXT_CL_VALUELIQ'))"
															onkeyup="HitungColValue();HitungColValue2();HitungColValue3();HitungColValue4();HitungColValue5();HitungColValue6();"
															runat="server" MaxLength="10" Width="100px">1</asp:textbox></td>
												</tr>
												<tr>
													<td class="TDBGColor1" width="129">Nilai Bank</td>
													<td style="WIDTH: 15px"></td>
													<td class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CL_FOREIGNVAL" onblur="FormatCurrency(this), FormatCurrency(document.getElementById('TXT_CL_VALUE'))"
															onkeyup="HitungColValue()" runat="server" MaxLength="15" Width="200px"></asp:textbox>&nbsp;&nbsp;in 
														Rp&nbsp;
														<asp:textbox id="TXT_CL_VALUE" runat="server" BorderStyle="None" Width="200px"></asp:textbox></td>
												</tr>
												<tr>
													<td class="TDBGColor1">Nilai Pasar</td>
													<td style="WIDTH: 15px"></td>
													<td class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CL_FOREIGNVAL2" onblur="FormatCurrency(this), FormatCurrency(document.getElementById('TXT_CL_VALUE2'))"
															onkeyup="HitungColValue2()" runat="server" MaxLength="15" Width="200px"></asp:textbox>&nbsp;&nbsp;in 
														Rp&nbsp;
														<asp:textbox id="TXT_CL_VALUE2" runat="server" BorderStyle="None" Width="200px"></asp:textbox></td>
												</tr>
												<tr>
													<td class="TDBGColor1" width="129">Nilai Asuransi</td>
													<td style="WIDTH: 15px"></td>
													<td class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CL_FOREIGNVALINS" onblur="FormatCurrency(this), FormatCurrency(document.getElementById('TXT_CL_VALUEINS'))"
															onkeyup="HitungColValue3()" runat="server" MaxLength="15" Width="200px"></asp:textbox>&nbsp;&nbsp;in 
														Rp&nbsp;
														<asp:textbox id="TXT_CL_VALUEINS" runat="server" BorderStyle="None" 
                                                            Width="200px"></asp:textbox></td>
												</tr>
												<tr>
													<td class="TDBGColor1" width="129">Nilai Pengikatan</td>
													<td style="WIDTH: 15px"></td>
													<td class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CL_FOREIGNVALIKAT" onblur="FormatCurrency(this), FormatCurrency(document.getElementById('TXT_CL_VALUEIKAT'))"
															onkeyup="HitungColValue4()" runat="server" MaxLength="15" Width="200px"></asp:textbox>&nbsp;&nbsp;in 
														Rp&nbsp;
														<asp:textbox id="TXT_CL_VALUEIKAT" runat="server" BorderStyle="None" 
                                                            Width="200px"></asp:textbox></td>
												</tr>
												<tr>
													<td class="TDBGColor1" width="129">Nilai Pengurang PPA</td>
													<td style="WIDTH: 15px"></td>
													<td class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CL_FOREIGNVALPPA" onblur="FormatCurrency(this), FormatCurrency(document.getElementById('TXT_CL_VALUEPPA'))"
															onkeyup="HitungColValue5()" runat="server" MaxLength="15" Width="200px"></asp:textbox>&nbsp;&nbsp;in 
														Rp&nbsp;
														<asp:textbox id="TXT_CL_VALUEPPA" runat="server" BorderStyle="None" 
                                                            Width="200px"></asp:textbox></td>
												</tr>
												<tr>
													<td class="TDBGColor1" width="129">Nilai Likuidasi</td>
													<td style="WIDTH: 15px"></td>
													<td class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CL_FOREIGNVALLIQ" onblur="FormatCurrency(this), FormatCurrency(document.getElementById('TXT_CL_VALUELIQ'))"
															onkeyup="HitungColValue6()" runat="server" MaxLength="15" Width="200px"></asp:textbox>&nbsp;&nbsp;in 
														Rp&nbsp;
														<asp:textbox id="TXT_CL_VALUELIQ" runat="server" BorderStyle="None" 
                                                            Width="200px"></asp:textbox></td>
												</tr>
												<!--<tr>
													<td class="TDBGColor1">% Use</td>
													<td style="WIDTH: 15px"></td>
													<td class="TDBGColorValue"></td>
												</tr>-->
												<tr>
													<td class="TDBGColor1">Tanggal Penilaian</td>
													<td style="WIDTH: 15px"></td>
													<td class="TDBGColorValue"><asp:textbox id="TXT_TGLPENILAIAN_DAY" runat="server" MaxLength="2" Columns="4" CssClass="mandatoryColl"></asp:textbox><asp:dropdownlist id="DDL_TGLPENILAIAN_MONTH" runat="server" CssClass="mandatoryColl"></asp:dropdownlist><asp:textbox id="TXT_TGLPENILAIAN_YEAR" runat="server" MaxLength="4" Columns="4" CssClass="mandatoryColl"></asp:textbox></td>
												</tr>
												<tr>
													<td class="TDBGColor1">Penilaian Oleh</td>
													<td style="WIDTH: 15px"></td>
													<td class="TDBGColorValue"><asp:dropdownlist id="DDL_PENILAI_OLEH" runat="server" CssClass="mandatoryColl"></asp:dropdownlist></td>
												</tr>
											</table>
										</td>
									</tr>
									<tr>
										<td align="center" width="50%" colSpan="2"><asp:button id="BTN_INSCOLL" 
                                                runat="server" CssClass="button1" Text="Tambah Collateral" 
                                                onclick="BTN_INSCOLL_Click"></asp:button></td>
									</tr>
								</table>
							</P>
						</td>
					</tr>
					<tr id="TR_BUTTONS" runat="server">
						<td class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2">
                            <asp:button id="BTN_SAVE" runat="server" CssClass="Button1" Width="125px" 
                                Text="Simpan" onclick="BTN_SAVE_Click"></asp:button>&nbsp;
							<asp:button id="Button2" runat="server" CssClass="Button1" Visible="False" 
                                Width="125px" Text="Lanjut"
								Enabled="False" onclick="Button2_Click"></asp:button>
                            <asp:button id="Button1" runat="server" CssClass="Button1" Visible="False" 
                                Width="150px" Text="Update Status"
								Enabled="False" onclick="Button1_Click"></asp:button></td>
					</tr>
					<tr>
						<td class="td" vAlign="top" align="center" width="50%" colSpan="2">
                            <ASP:DATAGRID id="DATAGRID1" runat="server" Width="100%" 
                                AutoGenerateColumns="False" PageSize="1"
								CellPadding="1" onitemcommand="DATAGRID1_ItemCommand">
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
									<asp:TemplateColumn Visible="false">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="LNK_EDIT" runat="server" CommandName="edit">Edit</asp:LinkButton>&nbsp;
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</ASP:DATAGRID>
                        </td>
					</tr>
			</table>
        </div>
    </form>
</body>
</html>
