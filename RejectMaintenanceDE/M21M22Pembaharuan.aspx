<%@ Page language="c#" Codebehind="M21M22Pembaharuan.aspx.cs" AutoEventWireup="True" Inherits="SME.RejectMaintenanceDE.M21M22Pembaharuan" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>M21M22Pembaharuan</TITLE>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include  file="../include/cek_all.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
				<tr>
					<td class="tdHeader1" align="center" width="100%" colSpan="2">
						<asp:textbox id="TXT_CP_CUREF" runat="server" Visible="False" Width="61px"></asp:textbox><asp:label id="LBL_APPTYPE" runat="server" Visible="False"></asp:label><asp:label id="LBL_REGNO" runat="server" Visible="False"></asp:label><asp:label id="LBL_PRODID" runat="server" Visible="False"></asp:label><asp:label id="LBL_PRODUCT" runat="server" Font-Bold="True"></asp:label>
						<asp:Label id="LBL_RATENO" runat="server" Visible="False"></asp:Label>
						<asp:label id="LBL_PROD_SEQ" runat="server" Visible="False"></asp:label></td>
				</tr>
				<TR>
					<TD vAlign="top" width="50%">
						<FIELDSET>
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="170">Jenis Pengajuan</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_APPTYPE" runat="server" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="170">Jenis Kredit</TD>
									<TD style="WIDTH: 1px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PRODUCT" runat="server" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="170">
										Pembentukan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_REVOLVING" runat="server" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="170">Tujuan Penggunaan</TD>
									<TD style="WIDTH: 1px"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CP_LOANPURPOSE" runat="server" Enabled="False"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="170">Limit
										<asp:label id="LBL_CURRENCY" runat="server"></asp:label></TD>
									<TD style="WIDTH: 1px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CP_LIMIT" runat="server" ReadOnly="True"
											CssClass="angka"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="170">Tenor</TD>
									<TD style="WIDTH: 1px; HEIGHT: 12px"></TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_OLDTENOR" runat="server" ReadOnly="True" CssClass="angka" Columns="3">0</asp:textbox>&nbsp;
										<asp:label id="LBL_OLDTENOR" runat="server"></asp:label></TD>
								</TR>
							</TABLE>
						</FIELDSET>
					</TD>
					<TD vAlign="top" width="50%">
						<FIELDSET>
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="170">No. Rekening</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CP_NOREK" runat="server" Visible="False"></asp:dropdownlist><asp:textbox id="TXT_CP_NOREK" runat="server" ReadOnly="True" Columns="4" Width="176px" MaxLength="2"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="170">Request Tenor</TD>
									<TD style="WIDTH: 1px; HEIGHT: 10px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 10px">
										<asp:textbox id="TXT_NEWTENOR" onkeyup="return numbersonly()" runat="server" CssClass="angkamandatory"
											Columns="3">0</asp:textbox>
										<asp:dropdownlist id="DDL_NEWTENOR" runat="server"></asp:dropdownlist><asp:textbox id="TXT_CP_INTEREST" runat="server" ReadOnly="True" CssClass="angka" Columns="4"
											MaxLength="2" Visible="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="170">
										<asp:Label id="LBL_INTERESTTYPE" runat="server" Visible="False"></asp:Label>Keterangan
										<asp:Label id="LBL_INTEREST" runat="server" Visible="False"></asp:Label>
										<asp:Label id="LBL_VARIANCE" runat="server" Visible="False"></asp:Label>
										<asp:Label id="LBL_VARCODE" runat="server" Visible="False"></asp:Label></TD>
									<TD style="WIDTH: 3px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CP_KETERANGAN" runat="server" Width="192px"
											TextMode="MultiLine" Height="65px"></asp:textbox></TD>
								</TR>
							</TABLE>
						</FIELDSET>
						<asp:checkbox id="CHECK_IDC" runat="server" Font-Bold="True" AutoPostBack="True" Text="IDC" Visible="False" oncheckedchanged="CHECK_IDC_CheckedChanged"></asp:checkbox></TD>
				</TR>
				<TR id="TR_IDC" runat="server">
					<TD vAlign="top" colSpan="2">
						<fieldset>
							<TABLE id="Table8" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="170">Main a/c-IDC Ratio</TD>
									<TD style="WIDTH: 1px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_IDC_RATIO" runat="server" CssClass="angka"></asp:textbox><asp:textbox onkeypress="return numbersonly()" id="TXT_CP_INSTALLMENT" runat="server" AutoPostBack="True"
											CssClass="angkamandatory" Columns="4" Width="136px" Visible="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="170">IDC Loan Term</TD>
									<TD style="WIDTH: 1px; HEIGHT: 24px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_IDC_JWAKTU" runat="server" CssClass="angka"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="170">IDC a/c - % Kapitalis&nbsp;</TD>
									<TD style="WIDTH: 3px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_IDC_CAPRATIO" runat="server" CssClass="angka"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="170">IDC variance code and percentage</TD>
									<TD style="WIDTH: 3px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_IDC_PRIMEVARCODE" runat="server" MaxLength="10"
											Width="40px"></asp:textbox>%
										<asp:DropDownList id="DDL_IDC_VARCODE" runat="server" Width="40px">
											<asp:ListItem Value="+" Selected="True">+</asp:ListItem>
											<asp:ListItem Value="-">-</asp:ListItem>
										</asp:DropDownList>
										<asp:textbox onkeypress="return kutip_satu()" id="TXT_IDC_VARIANCE" runat="server" Width="40px"
											MaxLength="10"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="170">IDC a/c - Plafond</TD>
									<TD style="WIDTH: 3px"></TD>
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
			</TABLE>
		</form>
		</SCRIPT>
	</body>
</HTML>
