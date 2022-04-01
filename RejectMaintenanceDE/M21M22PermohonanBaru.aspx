<%@ Page language="c#" Codebehind="M21M22PermohonanBaru.aspx.cs" AutoEventWireup="True" Inherits="SME.RejectMaintenanceDE.StrucCreditDetail" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>StrucCreditDetail</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include  file="../include/cek_mandatoryOnly.html" -->
		<!-- #include  file="../include/cek_entries.html" -->
		<script language="javascript">
		    function IsNumeric(n) {
		        return !isNaN(parseFloat(n)) && isFinite(n);
		    }

		    function HitungLimit() {
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
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
				<tr>
					<td class="tdHeader1" align="center" width="100%" colSpan="2"><asp:label id="LBL_REGNO" runat="server" Visible="False"></asp:label><asp:label id="LBL_PRODID" runat="server" Visible="False"></asp:label><asp:label id="LBL_APPTYPE" runat="server" Visible="False"></asp:label><asp:label id="LBL_PRODUCT" runat="server" Font-Bold="True"></asp:label><asp:label id="LBL_RATENO" runat="server" Visible="False"></asp:label><asp:label id="LBL_CU_REF" runat="server" Visible="False"></asp:label>
						<asp:label id="LBL_PROD_SEQ" runat="server" Visible="False"></asp:label></td>
				</tr>
				<TR>
					<TD vAlign="top" width="50%">
						<FIELDSET>
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1">Jenis Pengajuan</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_APPTYPE" runat="server" Width="175px" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jenis Kredit</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_PRODUCT" runat="server" ReadOnly="True"
											AutoPostBack="True" Width="175px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">
										Pembentukan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_REVOLVING" runat="server" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tujuan Penggunaan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CP_LOANPURPOSE" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="170">Limit Awal</TD>
									<TD style="WIDTH: 3px"></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return digitsonly()" id="TXT_CP_EXLIMIT_AWAL" onblur="FormatCurrency(this), FormatCurrency(document.getElementById('TXT_CP_LIMIT'))"
											onkeyup="HitungLimit()" runat="server" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="170">Limit dlm Currency&nbsp;yang diminta</TD>
									<TD style="WIDTH: 3px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CP_EXLIMITVAL" onkeyup="HitungLimit()"
											runat="server" onblur="FormatCurrency(this), FormatCurrency(document.getElementById('TXT_CP_LIMIT'))" Enabled="False"></asp:textbox>&nbsp;(Jumlah 
										yg dimohon)</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="170">
										Exchange Rate</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CP_EXRPLIMIT" onkeyup="HitungLimit()" runat="server"
											onblur="FormatCurrency(this), FormatCurrency(document.getElementById('TXT_CP_LIMIT'))"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Limit (Rp)</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CP_LIMIT" runat="server" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"><asp:label id="LBL_INSTALLMENT" runat="server"></asp:label></TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CP_INSTALLMENT" runat="server" Width="136px"
											CssClass="angkamandatory" Columns="4" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Loan Term</TD>
									<TD></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 12px"><asp:textbox onkeypress="return numbersonly()" id="TXT_CP_JANGKAWKT" runat="server" AutoPostBack="True"
											Columns="3" Enabled="False">0</asp:textbox><asp:dropdownlist id="DDL_CP_TENORCODE" runat="server" Enabled="False"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Grace Period</TD>
									<TD></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 12px">
										<asp:textbox onkeypress="return numbersonly()" id="TXT_CP_GRACEPERIOD" runat="server" Columns="3"></asp:textbox>&nbsp;Bulan</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Repayment Frequency</TD>
									<TD></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 12px">
										<asp:dropdownlist id="DDL_CP_PAYMENTID" runat="server"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</FIELDSET>
					</TD>
					<TD vAlign="top" width="50%">
						<FIELDSET>
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1"><asp:label id="LBL_INTERESTTYPE" runat="server"></asp:label></TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return digitsonly()" id="TXT_INTEREST" onblur="FormatCurrency(this), FormatCurrency(document.Form1.TXT_CP_LIMIT)"
											onkeyup="HitungLimit()" runat="server" Columns="4" Enabled="False"></asp:textbox>%
										<asp:textbox onkeypress="return digitsonly()" id="TXT_VARCODE" onblur="FormatCurrency(this), FormatCurrency(document.Form1.TXT_CP_LIMIT)"
											onkeyup="HitungLimit()" runat="server" Columns="4" Enabled="False"></asp:textbox>&nbsp;
										<asp:textbox onkeypress="return digitsonly()" id="TXT_VARIANCE" onblur="FormatCurrency(this), FormatCurrency(document.Form1.TXT_CP_LIMIT)"
											onkeyup="HitungLimit()" runat="server" Columns="4" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="170">Keterangan</TD>
									<TD style="WIDTH: 3px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CP_KETERANGAN" runat="server" Width="100%"
											TextMode="MultiLine" Height="100px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD>
										<asp:Label id="LBL_DECSTA" runat="server" Visible="False"></asp:Label></TD>
									<TD style="WIDTH: 3px"></TD>
									<TD></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="170">Total Limit Exposure</TD>
									<TD style="WIDTH: 3px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_LIMITEXPOSURE" runat="server" ReadOnly="True"
											CssClass="angka"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="170">Total Application Value</TD>
									<TD style="WIDTH: 3px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_SUMLIMIT" runat="server" ReadOnly="True"
											CssClass="angka"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"></TD>
									<TD></TD>
									<TD class="TDBGColorValue"></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Alih Debitur</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:CheckBox id="CHK_ALIHDEB" runat="server" AutoPostBack="True" Text="Yes" oncheckedchanged="CHK_ALIHDEB_CheckedChanged"></asp:CheckBox></TD>
								</TR>
								<TR id="TR_OLDCIFNO" runat="server">
									<TD class="TDBGColor1">Old CIF No.</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_OLDCIFNO" runat="server" MaxLength="19"></asp:textbox></TD>
								</TR>
								<TR id="TR_OLDACCNO" runat="server">
									<TD class="TDBGColor1">Old ACC No.</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_OLDACCNO" runat="server" MaxLength="19"></asp:textbox></TD>
								</TR>
							</TABLE>
							<asp:DropDownList id="DDL_PROJECT_CODE" runat="server" Visible="False"></asp:DropDownList>
							<asp:Label id="LBL_PROJECT_CODE" runat="server" Visible="False"></asp:Label>
						</FIELDSET>
						<asp:checkbox id="CHECK_IDC" runat="server" Font-Bold="True" AutoPostBack="True" Text="IDC" Enabled="False" oncheckedchanged="CHECK_IDC_CheckedChanged"></asp:checkbox><BR>
						<asp:CheckBox id="CHK_CP_REVATACCT" runat="server" Font-Bold="True" Text="Rekening Koran"></asp:CheckBox></TD>
				</TR>
				<TR id="TR_IDC" runat="server">
					<TD vAlign="top" align="center" colSpan="2">
						<fieldset>
							<TABLE id="Table8" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1">IDC a/c - Plafond</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_IDC_CAPAMNT" runat="server">0</asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">IDC Loan Term</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return numbersonly()" id="TXT_IDC_JWAKTU" runat="server" Columns="4">0</asp:textbox>&nbsp;
										<asp:Label id="LBL_IDC_TENOR" runat="server"></asp:Label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Main a/c&nbsp;- IDC Ratio</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_IDC_RATIO" runat="server" Columns="4">0</asp:textbox>%</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">IDC a/c - % Kapitalis</TD>
									<TD style="WIDTH: 1px"></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return digitsonly()" id="TXT_IDC_CAPRATIO" runat="server" Columns="4"
											MaxLength="3">0</asp:textbox>%</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="170">
										IDC Interest</TD>
									<TD style="WIDTH: 1px"></TD>
									<TD class="TDBGColorValue">
										<asp:DropDownList id="DDL_IDC_INTERESTTYPE" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_IDC_INTERESTTYPE_SelectedIndexChanged"></asp:DropDownList>
										<asp:textbox onkeypress="return digitsonly()" id="TXT_IDC_PRIMEVARCODE" runat="server" ReadOnly="True"
											Width="40px" MaxLength="10"></asp:textbox>%
										<asp:dropdownlist id="DDL_IDC_VARCODE" runat="server" Width="40px">
											<asp:ListItem Value="+" Selected="True">+</asp:ListItem>
											<asp:ListItem Value="-">-</asp:ListItem>
										</asp:dropdownlist>
										<asp:textbox onkeypress="return digitsonly()" id="TXT_IDC_VARIANCE" runat="server" Width="40px"
											MaxLength="10"></asp:textbox></TD>
								</TR>
							</TABLE>
						</fieldset>
					</TD>
				</TR>
				<TR id="tr" runat="server">
					<TD class="TDBGColor2" align="center" colSpan="2"><asp:button id="update" runat="server" CssClass="Button1" Text="Save" onclick="update_Click"></asp:button></TD>
				</TR>
				<!--<TR>
					<TD colspan="2"><iframe src="ListCollateral.aspx?regno=<%=Request.QueryString["regno"]%>&prodid=<%=Request.QueryString["prodid"]%>" width="100%" height="200" frameborder="0"></iframe>
					</TD>
				</TR>-->
				<TR>
					<td align="center" colSpan="2">
						<table id="Table4" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<td align="center" colSpan="5">
									<table id="Table5" cellSpacing="0" cellPadding="0" width="100%">
										<TBODY>
											<tr>
												<td><ASP:DATAGRID id="DatGrd" runat="server" Width="100%" CellPadding="1" AutoGenerateColumns="False"
														AllowPaging="True" PageSize="3" HorizontalAlign="Center">
														<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
														<Columns>
															<asp:BoundColumn Visible="False" DataField="CL_SEQ"></asp:BoundColumn>
															<asp:BoundColumn DataField="cl_desc" HeaderText="Collateral Description">
																<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="coltypedesc" HeaderText="Collateral Type">
																<HeaderStyle Width="20%" CssClass="tdSmallHeader"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="lc_percentage" HeaderText="% of Use">
																<HeaderStyle Width="15%" CssClass="tdSmallHeader"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="cl_value" HeaderText="Start Nomial">
																<HeaderStyle Width="15%" CssClass="tdSmallHeader"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="lc_value" HeaderText="End Nominal">
																<HeaderStyle Width="15%" CssClass="tdSmallHeader"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:BoundColumn>
															<asp:ButtonColumn Text="Delete" HeaderText="Function" CommandName="Delete">
																<HeaderStyle Width="10%" CssClass="tdSmallHeader"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:ButtonColumn>
														</Columns>
														<PagerStyle Mode="NumericPages"></PagerStyle>
													</ASP:DATAGRID></td>
								</td>
							</TR>
						</table>
					</td>
				</TR>
				<TR>
					<TD align="left">
						<table id="Table6" cellSpacing="0" cellPadding="0" width="100%">
							<tr align="center">
								<TD width="20%"><asp:dropdownlist id="DDL_CL_ID" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_CL_ID_SelectedIndexChanged"></asp:dropdownlist></TD>
								<TD><asp:textbox id="TXT_CL_DESC" runat="server" Width="179px" ReadOnly="True"></asp:textbox></TD>
								<TD width="15%"><asp:textbox onkeypress="return numbersonly()" id="TXT_LC_PERCENTAGE" runat="server" Width="48px"
										ReadOnly="True" AutoPostBack="True" CssClass="angka" ontextchanged="TXT_LC_PERCENTAGE_TextChanged"></asp:textbox></TD>
								<TD width="15%"><asp:textbox id="TXT_LC_VALUE" runat="server" ReadOnly="True" CssClass="angka"></asp:textbox></TD>
								<TD width="15%"><asp:textbox id="TXT_ENDVALUE" runat="server" ReadOnly="True" CssClass="angka"></asp:textbox></TD>
								<TD width="10%"><asp:button id="insert" runat="server" Text="insert" onclick="insert_Click"></asp:button></TD>
							</tr>
						</table>
					</TD>
				</TR>
			</TABLE>
			</TD></TR></TBODY></TABLE></form>
	</body>
</HTML>
