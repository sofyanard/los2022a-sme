<%@ Page language="c#" Codebehind="M21M22Withdrawl.aspx.cs" AutoEventWireup="True" Inherits="SME.RejectMaintenanceDE.M21M22Withdrawl" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>M21M22Withdrawl</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
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
						<asp:label id="LBL_PROD_SEQ" runat="server" Visible="False"></asp:label>
						<asp:label id="LBL_AA_NO" runat="server" Visible="False"></asp:label>
						<asp:label id="LBL_ACC_SEQ" runat="server" Visible="False"></asp:label><asp:textbox id="TXT_CP_CUREF" runat="server" Visible="False" Width="56px"></asp:textbox><asp:label id="LBL_PRODID" runat="server" Visible="False"></asp:label><asp:label id="LBL_REGNO" runat="server" Visible="False"></asp:label><asp:label id="LBL_APPTYPE" runat="server" Visible="False"></asp:label><asp:label id="LBL_PRODUCT" runat="server" Font-Bold="True"></asp:label>
						<asp:Label id="LBL_RATENO" runat="server" Visible="False"></asp:Label>
						<asp:label id="LBL_CU_REF" runat="server" Visible="False"></asp:label></td>
				</tr>
				<TR>
					<TD vAlign="top" width="50%">
						<FIELDSET>
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="180">Jenis Pengajuan</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_APPTYPE" runat="server" ReadOnly="True"
											Width="170px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="180">Jenis Withdrawl</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue">
										<asp:dropdownlist id="DDL_WITHDRAWLID" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">AA No.</TD>
									<TD style="WIDTH: 1px"></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return kutip_satu()" id="TXT_AA_NO" runat="server" Width="170px" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Kode Fasilitas</TD>
									<TD style="WIDTH: 1px"></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return kutip_satu()" id="TXT_PRODUCTID" runat="server" ReadOnly="True"
											Columns="5"></asp:textbox><asp:dropdownlist id="DDL_CP_NOREK" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jenis Kredit</TD>
									<TD style="WIDTH: 1px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_PRODUCT" runat="server" ReadOnly="True"
											Width="168px"></asp:textbox>
										<asp:Label id="LBL_PRODUCTID" runat="server" Visible="False"></asp:Label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="180">Limit Awal yang diminta (Rp)</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:Label id="LBL_LIMIT_AWAL" runat="server"></asp:Label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="180">
										Limit&nbsp;-&nbsp;
										<asp:Label id="LBL_CURR2" runat="server"></asp:Label></TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" onkeyup="HitungLimit()" id="TXT_CP_EXLIMITVAL"
											onblur="FormatCurrency(this), FormatCurrency(document.getElementById('TXT_CP_LIMIT'))" runat="server" CssClass="angkamandatory"
											AutoPostBack="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="180">
										Exchange Rate to&nbsp;Rp.</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" onkeyup="HitungLimit()" onblur="FormatCurrency(this), FormatCurrency(document.getElementById('TXT_CP_LIMIT'))"
											id="TXT_CP_EXRPLIMIT" runat="server" CssClass="angkamandatory"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Request Limit&nbsp;in Rp.</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CP_LIMIT" runat="server" ReadOnly="True"
											CssClass="angkamandatory"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tenor</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_CP_JANGKAWKT" runat="server" Columns="3" AutoPostBack="True"></asp:textbox>
										<asp:dropdownlist id="DDL_CP_TENORCODE" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</FIELDSET>
						<asp:Label id="LBL_EARMARK_AMOUNT" runat="server" Visible="False"></asp:Label>
						<asp:Label id="LBL_PRJ_CODE" runat="server" Visible="False"></asp:Label>
					</TD>
					<TD vAlign="top" width="50%">
						<FIELDSET>
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="170">&nbsp;
										<asp:Label id="LBL_CURR3" runat="server"></asp:Label>Installment</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CP_INSTALLMENT" runat="server" CssClass="angkamandatory"
											Width="136px" Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">
										<asp:Label id="LBL_INTERESTTYPE" runat="server"></asp:Label></TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:Label id="LBL_INTEREST" runat="server">0</asp:Label>%
										<asp:Label id="LBL_VARCODE" runat="server"></asp:Label>&nbsp;
										<asp:Label id="LBL_VARIANCE" runat="server"></asp:Label></TD>
								</TR>
								<TR>
									<TD>
										<asp:textbox onkeypress="return numbersonly()" id="TXT_NEWTENOR" runat="server" Visible="False"
											Width="136px" CssClass="angkamandatory" Columns="4"></asp:textbox></TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:Label id="LBL_DECSTA" runat="server" Visible="False"></asp:Label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Keterangan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CP_KETERANGAN" runat="server" Width="100%"
											Height="80px" TextMode="MultiLine"></asp:textbox></TD>
								</TR>
							</TABLE>
						</FIELDSET>
					</TD>
				</TR>
				<TR id="tr" runat="server">
					<TD class="TDBGColor2" align="center" colSpan="2"><asp:button id="update" runat="server" CssClass="Button1" Text="Update" onclick="update_Click"></asp:button></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
