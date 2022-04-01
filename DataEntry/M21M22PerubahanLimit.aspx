<%@ Page language="c#" Codebehind="M21M22PerubahanLimit.aspx.cs" AutoEventWireup="True" Inherits="SME.DataEntry.M21M22PerubahanLimit" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Struktur Kredit Perubahan Limit</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_mandatoryOnly.html" -->
		<!-- #include file="../include/cek_entries.html" -->
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
						<asp:label id="LBL_AA_NO" runat="server" Visible="False"></asp:label>
						<asp:label id="LBL_ACC_SEQ" runat="server" Visible="False"></asp:label><asp:textbox id="TXT_CP_CUREF" runat="server" Visible="False" Width="56px"></asp:textbox><asp:label id="LBL_PRODID" runat="server" Visible="False"></asp:label><asp:label id="LBL_REGNO" runat="server" Visible="False"></asp:label><asp:label id="LBL_APPTYPE" runat="server" Visible="False"></asp:label><asp:label id="LBL_PRODUCT" runat="server" Font-Bold="True"></asp:label>
						<asp:Label id="LBL_RATENO" runat="server" Visible="False"></asp:Label>
						<asp:Label id="LBL_PROD_SEQ" runat="server" Visible="False"></asp:Label>
						<asp:Label id="LBL_KET_CODE" runat="server" Visible="False"></asp:Label></td>
				</tr>
				<TR>
					<TD vAlign="top" width="50%">
						<FIELDSET>
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="180">Jenis Pengajuan</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_APPTYPE" runat="server" ReadOnly="True"
											Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">No. Akomodasi Rekening</TD>
									<TD style="WIDTH: 1px"></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return kutip_satu()" id="TXT_AA_NO" runat="server" Width="300px" ReadOnly="True"
											BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Kode Fasilitas</TD>
									<TD style="WIDTH: 1px"></TD>
									<TD class="TDBGColorValue">
										<asp:TextBox id="TXT_PRODUCTID" runat="server" Columns="5" onkeypress="return kutip_satu()" MaxLength="10"></asp:TextBox>
										<asp:dropdownlist id="DDL_CP_NOREK" runat="server" CssClass="mandatory" AutoPostBack="True" Enabled="False" onselectedindexchanged="DDL_CP_NOREK_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">
										Pembentukan</TD>
									<TD style="WIDTH: 1px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_PRODUCT" runat="server" ReadOnly="True"
											Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Limit Lama -&nbsp;</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CP_LIMITCHGTO" runat="server" ReadOnly="True"
											CssClass="angka" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="180">
										Perubahan Limit -&nbsp;</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:dropdownlist id="DDL_CP_LIMITCHG" runat="server" CssClass="mandatory">
											<asp:ListItem Value="+" Selected="True">+</asp:ListItem>
											<asp:ListItem Value="-">-</asp:ListItem>
										</asp:dropdownlist><asp:textbox onkeypress="return digitsonly()" onkeyup="HitungLimit()" id="TXT_CP_EXLIMITVAL"
											onblur="FormatCurrency(document.getElementById(TXT_CP_LIMIT'))" runat="server" Width="250px" MaxLength="15"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="180">
										Kurs Valuta ke Rp.</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" onkeyup="HitungLimit()"
											id="TXT_CP_EXRPLIMIT" runat="server" Width="300px" MaxLength="15"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Perubahan Limit&nbsp;in Rp.</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CP_LIMIT" runat="server" ReadOnly="True"
											CssClass="angkamandatory" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tujuan Penggunaan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CP_LOANPURPOSE" runat="server" Width="280px"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</FIELDSET>
					</TD>
					<TD vAlign="top" width="50%">
						<FIELDSET>
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="100">Keterangan</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CP_KETERANGAN" runat="server" CssClass="mandatory"
											Width="300px" Height="120px" TextMode="MultiLine"></asp:textbox></TD>
								</TR>
								<TR>
									<TD colSpan="3"></TD>
								</TR>
							</TABLE>
						</FIELDSET>
						<asp:textbox onkeypress="return numbersonly()" id="TXT_NEWTENOR" runat="server" Visible="False"
							Width="136px" CssClass="angkamandatory" Columns="4"></asp:textbox>
						<asp:Label id="LBL_NEWTENORCODE" runat="server" Visible="False"></asp:Label>
						<asp:Label id="LBL_VARIANCE" runat="server" Visible="False"></asp:Label>
						<asp:Label id="LBL_INSTALLMENT" runat="server" Visible="False"></asp:Label>
						<asp:Label id="LBL_VARCODE" runat="server" Visible="False"></asp:Label>
						<asp:Label id="LBL_CURR3" runat="server" Visible="False"></asp:Label>
						<asp:Label id="LBL_INTEREST" runat="server" Visible="False"></asp:Label>
						<asp:Label id="LBL_FLOATING" runat="server" Visible="False"></asp:Label>
						<asp:Label id="LBL_INTERESTTYPE" runat="server" Visible="False"></asp:Label><asp:textbox onkeypress="return numbersonly()" id="TXT_CP_INSTALLMENT" runat="server" CssClass="angkamandatory"
							Width="136px" Columns="4" Visible="False"></asp:textbox>
					</TD>
				</TR>
				<TR id="TR_STATUS" runat="server">
					<TD class="TDBGColor2" align="center" colSpan="2">
						<asp:Label ID="labelStatus" Runat="Server" Font-Bold="True" Font-Names="Arial" Font-Size="Medium"
							ForeColor="Red"></asp:Label>
					</TD>
				</TR>
				<TR id="tr" runat="server">
					<TD class="TDBGColor2" align="center" colSpan="2">
						<asp:Label id="LBL_CURR2" runat="server" visible="false">LBL_CURR1</asp:Label>
						<asp:Label id="LBL_CURR1" runat="server" visible="false"></asp:Label><asp:button id="update" runat="server" CssClass="Button1" Text="Update" onclick="update_Click"></asp:button></TD>
				</TR>
				<!--<TR>
					<TD colspan="2"><iframe src="ListCollateral.aspx?regno=<%=Request.QueryString["regno"]%>&prodid=<%=Request.QueryString["prodid"]%>" width="100%" height="200" frameborder="0"></iframe>
					</TD>
				</TR>-->
			</TABLE>
		</form>
	</body>
</HTML>
