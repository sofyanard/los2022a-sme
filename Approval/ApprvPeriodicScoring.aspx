<%@ Page language="c#" Codebehind="ApprvPeriodicScoring.aspx.cs" AutoEventWireup="false" Inherits="SME.Approval.ApprvPeriodicScoring" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ApprvPeriodicScoring</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include  file="../include/cek_all.html" -->
		<!-- #include  file="../include/cek_mandatoryOnly.html" -->
		<!-- #include file="../include/popup.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
				<TR>
					<TD align="center" width="100%" colSpan="2">
						<TABLE id="kreditAwal" cellSpacing="2" cellPadding="2" width="100%" runat="server">
							<TR>
								<TD class="td" vAlign="top" width="50%">
									<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="100%">
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 140px">Limit</TD>
											<TD style="WIDTH: 15px"></TD>
											<TD class="TDBGColorValue">Rp.
												<asp:textbox id="txt_limit" runat="server" Width="150px" MaxLength="15" Columns="50" ReadOnly></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 140px">Tenor</TD>
											<TD style="WIDTH: 15px"></TD>
											<TD class="TDBGColorValue"><asp:textbox id="txt_tenor" runat="server" Width="40px" MaxLength="3" Columns="5" ReadOnly></asp:textbox>&nbsp;
												<asp:textbox id="txt_tenorcode" runat="server" Width="40px" MaxLength="5" Columns="5" Visible="False"
													ReadOnly></asp:textbox>
												<asp:textbox id="txt_tenorcodedesc" runat="server" Width="40px" MaxLength="5" Columns="5" ReadOnly></asp:textbox>
												<asp:textbox onkeypress="return numbersonly()" id="txt_tenor_year" runat="server" Width="36px"
													Visible="False" MaxLength="4" Columns="4"></asp:textbox><asp:textbox id="txt_tenor_day" onkeyup="return numbersonly()" runat="server" CssClass="angkamandatory"
													MaxLength="3" Columns="3">0</asp:textbox><asp:dropdownlist id="ddl_tenor_month" runat="server"></asp:dropdownlist></TD>
										</TR>
										<TR id="tr_fix" runat="server">
											<TD class="TDBGColor1" style="WIDTH: 140px">Interest/p.a Fix</TD>
											<TD style="WIDTH: 15px"></TD>
											<TD class="TDBGColorValue"><asp:textbox id="txt_fix" runat="server" Width="40px" MaxLength="6" Columns="10" ReadOnly></asp:textbox>%</TD>
										</TR>
										<TR id="tr_float" runat="server">
											<TD class="TDBGColor1" style="WIDTH: 140px; HEIGHT: 22px">Interest Floating</TD>
											<TD style="WIDTH: 15px; HEIGHT: 22px"></TD>
											<TD class="TDBGColorValue" style="HEIGHT: 22px"><asp:dropdownlist id="ddl_rate" runat="server" Enabled="False" Visible="False"></asp:dropdownlist><asp:textbox id="txt_rate" runat="server" Width="40px" MaxLength="10" Columns="10" ReadOnly></asp:textbox>%
												<asp:dropdownlist id="ddl_varcode" runat="server" Enabled="False"></asp:dropdownlist><asp:textbox id="txt_variance" runat="server" Width="40px" MaxLength="10" Columns="10" ReadOnly></asp:textbox>%
											</TD>
										</TR>
										<TR id="tr_install" runat="server">
											<TD class="TDBGColor1" style="WIDTH: 140px">Installment</TD>
											<TD style="WIDTH: 15px"></TD>
											<TD class="TDBGColorValue"><asp:textbox id="txt_installment" runat="server" Width="152px" MaxLength="15" Columns="10" ReadOnly></asp:textbox></TD>
										</TR>
									</TABLE>
								</TD>
								<TD class="td" vAlign="top">
									<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 164px">Tujuan Penggunaan</TD>
											<TD style="WIDTH: 15px"></TD>
											<TD class="TDBGColorValue"><asp:textbox id="txt_purpose" runat="server" Width="280px" MaxLength="200" Columns="200" ReadOnly></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 164px">Sifat Kredit</TD>
											<TD style="WIDTH: 15px"></TD>
											<TD class="TDBGColorValue"><asp:textbox id="txt_sifat" runat="server" Width="176px" MaxLength="100" Columns="100" ReadOnly></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 164px; HEIGHT: 18px">Total Collaterals In Rp.</TD>
											<TD style="WIDTH: 15px; HEIGHT: 18px"></TD>
											<TD class="TDBGColorValue" style="HEIGHT: 18px"><asp:textbox id="txt_totcoll" runat="server" Width="100px" MaxLength="100" Columns="100" ReadOnly></asp:textbox><asp:textbox id="txt_exrplimit" runat="server" Width="24px" Visible="False" MaxLength="50" Height="16px"
													Columns="50"></asp:textbox><asp:textbox id="txt_exlimitval" runat="server" Width="24px" Visible="False" MaxLength="50" Height="16px"
													Columns="50"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 164px" vAlign="top"><asp:label id="lbl_exlimitval" runat="server" Visible="False"></asp:label>Remark</TD>
											<TD style="WIDTH: 15px"></TD>
											<TD class="TDBGColorValue"><asp:textbox id="txt_remark" runat="server" Width="280px" MaxLength="50" Height="40px" TextMode="MultiLine"
													Columns="50"></asp:textbox></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
						<TABLE id="tbl_idc" cellSpacing="0" cellPadding="0" width="100%" runat="server">
							<TR>
								<TD class="TDBGColor1" width="170">Main a/c-IDC Ratio</TD>
								<TD style="WIDTH: 1px"></TD>
								<TD class="TDBGColorValue"><asp:label id="LBL_IDC_RATIO" runat="server" Visible="False"></asp:label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" width="170">IDC Loan Term</TD>
								<TD style="WIDTH: 1px; HEIGHT: 24px"></TD>
								<TD class="TDBGColorValue"><asp:label id="LBL_IDC_JWAKTU" runat="server" Visible="False"></asp:label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" width="170">IDC a/c - % Kapitalis&nbsp;</TD>
								<TD style="WIDTH: 3px"></TD>
								<TD class="TDBGColorValue"><asp:label id="LBL_IDC_CAPRATIO" runat="server" Visible="False"></asp:label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" width="170">IDC variance code and percentage</TD>
								<TD style="WIDTH: 3px"></TD>
								<TD class="TDBGColorValue"><asp:dropdownlist id="ddl_idcprimevar" runat="server" Enabled="False" AutoPostBack="True"></asp:dropdownlist>%
									<asp:dropdownlist id="ddl_idcvarcode" runat="server" Enabled="False" Width="40px">
										<asp:ListItem Value="+" Selected="True">+</asp:ListItem>
										<asp:ListItem Value="-">-</asp:ListItem>
									</asp:dropdownlist><asp:label id="LBL_IDC_VARIANCE" runat="server" Visible="False"></asp:label><asp:dropdownlist id="ddl_idcinttype" runat="server" Enabled="False" AutoPostBack="True"></asp:dropdownlist><asp:label id="LBL_IDC_PRIMEVAR" runat="server" Visible="False"></asp:label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" width="170">IDC a/c - Plafond</TD>
								<TD style="WIDTH: 3px"></TD>
								<TD class="TDBGColorValue"><asp:label id="LBL_IDC_CAPAMNT" runat="server" Visible="False"></asp:label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<tr>
					<td class="tdHeader1" align="center" width="100%" colSpan="2"><asp:textbox id="TXT_CP_CUREF" runat="server" Width="61px" Visible="False"></asp:textbox><asp:label id="LBL_PRODUCT" runat="server" Font-Bold="True"></asp:label><asp:label id="LBL_RATENO" runat="server" Visible="False"></asp:label></td>
				</tr>
				<TR>
					<TD vAlign="top" width="50%">
						<FIELDSET>
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="170">Jenis Pengajuan</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:label id="LBL_APPTYPE" runat="server"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="170">Jenis Kredit</TD>
									<TD style="WIDTH: 1px"></TD>
									<TD class="TDBGColorValue"><asp:label id="LBL_PRODUCT_DESC" runat="server"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="170">Pembentukan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:label id="LBL_REVOLVING" runat="server"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="170">Limit
									</TD>
									<TD style="WIDTH: 1px"></TD>
									<TD class="TDBGColorValue"><asp:label id="LBL_CURRENCY" runat="server"></asp:label>&nbsp;<asp:label id="LBL_CP_LIMIT" runat="server"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="170">Tenor</TD>
									<TD style="WIDTH: 1px; HEIGHT: 12px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_OLDTENOR" runat="server" CssClass="angka" MaxLength="3" Columns="3" ReadOnly="True"
											BorderStyle="None">0</asp:textbox>&nbsp;
										<asp:label id="LBL_OLDTENOR" runat="server"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tujuan Penggunaan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CP_LOANPURPOSE" runat="server" Enabled="False" Width="250px"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</FIELDSET>
					</TD>
					<TD vAlign="top" width="50%">
						<FIELDSET>
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="170">Keterangan</TD>
									<TD style="WIDTH: 3px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CP_KETERANGAN" runat="server" Width="250px"
											Height="65px" TextMode="MultiLine" ReadOnly="True"></asp:textbox><asp:dropdownlist id="DDL_CP_NOREK" runat="server" Enabled="False" Visible="False"></asp:dropdownlist><asp:label id="LBL_ACC_NO" runat="server" Visible="False"></asp:label></TD>
								</TR>
							</TABLE>
						</FIELDSET>
						<asp:label id="lbl_decsta" runat="server" Visible="False"></asp:label></TD>
				</TR>
				<TR>
					<TD class="tdheader1" vAlign="top" colSpan="2">Decision
						<asp:label id="lbl_usergroup" Runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" colSpan="2">
						<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%">
							<TBODY>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 161px; HEIGHT: 15px">Decision Status</TD>
									<TD style="WIDTH: 14px; HEIGHT: 14px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 14px"><asp:textbox id="txt_decsta" runat="server" Width="288px" MaxLength="10" Columns="10" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 161px; HEIGHT: 15px">Override Status</TD>
									<TD style="WIDTH: 14px; HEIGHT: 14px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 14px"><asp:textbox id="txt_decovrsta" runat="server" Width="40px" MaxLength="100" Columns="100" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 161px; HEIGHT: 15px">Override Reason</TD>
									<TD style="WIDTH: 14px; HEIGHT: 15px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 15px"><asp:dropdownlist id="ddl_decovrreason" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 161px"></TD>
									<TD style="WIDTH: 14px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="txt_decovrreason" runat="server" Width="223px"
											CssClass="mandatory" MaxLength="100" TextMode="MultiLine" Columns="100"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 161px; HEIGHT: 15px" vAlign="top">Remark</TD>
									<TD style="WIDTH: 14px; HEIGHT: 15px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 15px"><asp:textbox onkeypress="return kutip_satu()" id="txt_decremark" runat="server" Width="288px"
											MaxLength="50" TextMode="MultiLine" Columns="50" Rows="5"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 161px"><asp:textbox id="TXT_NEGATIVE" runat="server" Visible="False">NO</asp:textbox></TD>
					</TD>
					<TD style="WIDTH: 14px"></TD>
					<TD class="TDBGColorValue" align="left">
						<%if (Request.QueryString["sta"] != "view") {%>
						<asp:button id="btn_override" Runat="server" Text="Override" CssClass="button1"></asp:button>
						<%}%>
					</TD>
				</TR>
			</TABLE>
			</TD></TR></TBODY></TABLE></form>
	</body>
</HTML>
