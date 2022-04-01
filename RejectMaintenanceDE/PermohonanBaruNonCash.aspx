<%@ Page language="c#" Codebehind="PermohonanBaruNonCash.aspx.cs" AutoEventWireup="True" Inherits="SME.RejectMaintenanceDE.PermohonanBaruNonCash" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PermohonanBaruNonCash</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_mandatoryOnly.html" -->
		<!-- #include  file="../include/cek_entries.html" -->
		<!-- #include  file="../include/popup.html" -->
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
					<td class="tdHeader1" align="center" width="100%" colSpan="2">
						<asp:label id="LBL_REGNO" runat="server" Visible="False"></asp:label>
						<asp:label id="LBL_PRODID" runat="server" Visible="False"></asp:label>
						<asp:label id="LBL_APPTYPE" runat="server" Visible="False"></asp:label>
						<asp:label id="LBL_PRODUCT" runat="server" Font-Bold="True"></asp:label>
						<asp:label id="LBL_RATENO" runat="server" Visible="False"></asp:label>
						<asp:label id="LBL_CU_REF" runat="server" Visible="False"></asp:label>
						<asp:label id="LBL_PROD_SEQ" runat="server" Visible="False"></asp:label>
						<asp:label id="LBL_KET_CODE" runat="server" Visible="False"></asp:label>
					</td>
				</tr>
				<TR>
					<TD vAlign="top" width="50%">
						<FIELDSET>
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1">Jenis Pengajuan</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_APPTYPE" runat="server" ReadOnly="True"
											Width="168px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jenis Kredit</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_PRODUCT" runat="server" ReadOnly="True"
											Width="300px" AutoPostBack="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Sifat Kredit</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_REVOLVING" runat="server" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tujuan Penggunaan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CP_LOANPURPOSE" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="170">Limit Awal yang diminta (dlm Currency)</TD>
									<TD style="WIDTH: 3px"></TD>
									<TD class="TDBGColorValue"><asp:label id="LBL_CP_LIMITAWAL" runat="server"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="170">Limit dlm Currency&nbsp;yang diminta</TD>
									<TD style="WIDTH: 3px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CP_EXLIMITVAL" onblur="FormatCurrency(this), FormatCurrency(document.getElementById('TXT_CP_LIMIT'))"
											onkeyup="HitungLimit()" runat="server" AutoPostBack="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="170">Exchange Rate Rp. to 1 Unit Foreign Currency 
										(Limit)</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CP_EXRPLIMIT" onblur="FormatCurrency(this), FormatCurrency(document.getElementById('TXT_CP_LIMIT'))"
											onkeyup="HitungLimit()" runat="server"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Limit (Rp)</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CP_LIMIT" runat="server" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Installment</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CP_INSTALLMENT" runat="server" Width="136px"
											AutoPostBack="True" CssClass="angkamandatory" Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Loan Term</TD>
									<TD></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 12px"><asp:textbox onkeypress="return numbersonly()" id="TXT_CP_JANGKAWKT" runat="server" AutoPostBack="True"
											CssClass="angkamandatory" Columns="3" MaxLength="3">0</asp:textbox><asp:dropdownlist id="DDL_CP_TENORCODE" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"><asp:label id="LBL_INTERESTTYPE" runat="server"></asp:label></TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue"><asp:label id="LBL_INTEREST" runat="server"></asp:label>%
										<asp:label id="LBL_VARCODE" runat="server"></asp:label>&nbsp;
										<asp:label id="LBL_VARIANCE" runat="server"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="170">Keterangan</TD>
									<TD style="WIDTH: 3px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CP_KETERANGAN" runat="server" Width="100%"
											Height="48px" TextMode="MultiLine"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="170">Total Limit Exposure</TD>
									<TD style="WIDTH: 3px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_LIMITEXPOSURE" runat="server" ReadOnly="True"
											CssClass="angka"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="170">Total Application Value</TD>
									<TD style="WIDTH: 3px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_SUMLIMIT" runat="server" ReadOnly="True"
											CssClass="angka"></asp:textbox></TD>
								</TR>
							</TABLE>
						</FIELDSET>
						<asp:checkbox id="CHECK_IDC" runat="server" Visible="False" Font-Bold="True" AutoPostBack="True"
							Text="IDC" oncheckedchanged="CHECK_IDC_CheckedChanged"></asp:checkbox>
						<asp:DropDownList id="DDL_PROJECT_CODE" runat="server" Visible="False"></asp:DropDownList>
						<asp:Label id="LBL_PROJECT_CODE" runat="server" Visible="False"></asp:Label>
					</TD>
					<TD vAlign="top" width="50%">
						<FIELDSET>
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="180">Tanggal Penerbitan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CP_ISSUEDATE_DD" runat="server" Width="24px"
											Columns="4" MaxLength="2"></asp:textbox><asp:dropdownlist id="DDL_CP_ISSUEDATE_MM" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CP_ISSUEDATE_YY" runat="server" Width="36px"
											Columns="4" MaxLength="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tanggal Jatuh Tempo</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CP_DUEDATE_DD" runat="server" Width="24px"
											Columns="4" MaxLength="2"></asp:textbox><asp:dropdownlist id="DDL_CP_DUEDATE_MM" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CP_DUEDATE_YY" runat="server" Width="36px"
											Columns="4" MaxLength="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Dasar Permohonan Penerbitan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CP_REQUEST" runat="server" Columns="40"
											MaxLength="350"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Ditujukan Kepada</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CP_ISSUETO" runat="server" Columns="40"
											MaxLength="350"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Alamat</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CP_ISSUEADDR1" runat="server" Width="175px"></asp:textbox><BR>
										<asp:textbox onkeypress="return kutip_satu()" id="TXT_CP_ISSUEADDR2" runat="server" Width="175px"></asp:textbox><BR>
										<asp:textbox onkeypress="return kutip_satu()" id="TXT_CP_ISSUEADDR3" runat="server" Width="175px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nama Barang / Komoditi</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CP_COMMODITYNAME" runat="server" Columns="40"
											MaxLength="350"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jumlah</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CP_COMMODITYAMNT" runat="server" Width="50px"
											CssClass="angka"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nilai FOB/CIF/CNF</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CP_VALUE" runat="server" CssClass="angka"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Bank Koresponden</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CP_BANKCORR" runat="server"></asp:dropdownlist><asp:dropdownlist id="DDL_CP_BANKCORRCITY" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"><asp:label id="LBL_DECSTA" runat="server" Visible="False"></asp:label>Alamat</TD>
									<TD width="17"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CP_BANKADDR1" runat="server" Width="175px"></asp:textbox><BR>
										<asp:textbox onkeypress="return kutip_satu()" id="TXT_CP_BANKADDR2" runat="server" Width="175px"></asp:textbox><BR>
										<asp:textbox onkeypress="return kutip_satu()" id="TXT_CP_BANKADDR3" runat="server" Width="175px"></asp:textbox></TD>
								</TR>
							</TABLE>
						</FIELDSET>
					</TD>
				</TR>
				<TR id="TR_IDC" runat="server">
					<TD vAlign="top" align="center" colSpan="2">
						<fieldset>
							<TABLE id="Table8" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1">Main a/c&nbsp;- IDC Ratio</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_IDC_RATIO" runat="server" CssClass="angka"
											Columns="4" MaxLength="3"></asp:textbox>%</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">IDC Loan Term</TD>
									<TD style="WIDTH: 1px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_IDC_JWAKTU" runat="server" CssClass="angka"
											Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">IDC a/c - % Kapitalis</TD>
									<TD style="WIDTH: 1px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_IDC_CAPRATIO" runat="server" Columns="4"
											MaxLength="3"></asp:textbox>%</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">IDC variance code and percentage</TD>
									<TD style="WIDTH: 1px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_IDC_PRIMEVARCODE" runat="server" ReadOnly="True"
											Width="40px" MaxLength="10"></asp:textbox>%
										<asp:dropdownlist id="DDL_IDC_VARCODE" runat="server" Width="40px">
											<asp:ListItem Value="+" Selected="True">+</asp:ListItem>
											<asp:ListItem Value="-">-</asp:ListItem>
										</asp:dropdownlist><asp:textbox onkeypress="return kutip_satu()" id="TXT_IDC_VARIANCE" runat="server" Width="40px"
											MaxLength="10"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="170">IDC a/c - Plafond</TD>
									<TD style="WIDTH: 1px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_IDC_CAPAMNT" runat="server" CssClass="angka"></asp:textbox></TD>
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
										<tr>
											<td><ASP:DATAGRID id="DatGrd" runat="server" Width="100%" HorizontalAlign="Center" PageSize="3" AllowPaging="True"
													AutoGenerateColumns="False" CellPadding="1">
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
															<HeaderStyle Width="10%" CssClass="tdSmallHeader"></HeaderStyle>
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
															<HeaderStyle Width="15%" CssClass="tdSmallHeader"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:ButtonColumn>
													</Columns>
													<PagerStyle Mode="NumericPages"></PagerStyle>
												</ASP:DATAGRID>
											</td>
										</tr>
									</table>
								</td>
							</TR>
							<TR>
								<TD align="left">
									<%if (Request.QueryString["de"] == "1") {%>
									<table id="Table6" cellSpacing="0" cellPadding="0" width="100%">
										<tr align="center">
											<TD width="20%"><asp:dropdownlist id="DDL_CL_ID" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_CL_ID_SelectedIndexChanged"></asp:dropdownlist></TD>
											<TD><asp:textbox id="TXT_CL_DESC" runat="server" ReadOnly="True" Width="179px"></asp:textbox></TD>
											<TD width="10%"><asp:textbox onkeypress="return digitsonly()" id="TXT_LC_PERCENTAGE" runat="server" Width="48px"
													CssClass="angka"></asp:textbox></TD>
											<TD width="15%"><asp:textbox id="TXT_LC_VALUE" runat="server" ReadOnly="True" CssClass="angka"></asp:textbox></TD>
											<TD width="15%"><asp:textbox id="TXT_ENDVALUE" runat="server" ReadOnly="True" CssClass="angka"></asp:textbox></TD>
											<TD width="15%"><asp:button id="calc" runat="server" Text="hitung"></asp:button>&nbsp;<asp:button id="insert" runat="server" Text="insert" onclick="insert_Click"></asp:button></TD>
										</tr>
									</table>
									<%}%>
								</TD>
							</TR>
						</table>
					</td>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
