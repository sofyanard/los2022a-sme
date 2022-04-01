<%@ Page language="c#" Codebehind="MainReportDQA.aspx.cs" AutoEventWireup="True" Inherits="SME.SourceSMEReport.DQA.MainReportDQA" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>MainReportDQA</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Style.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function view_report(mc, bu)
		{
			for ( i=0 ; i<13; i++)
			{
				if (eval("document.Form1.RB_1("+i+").checked"))
					window.location	= eval("document.Form1.RB_1("+i+").value") + "?mc="+mc + "&BU=" + bu;
			}
		}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout" onload="click_rb()">
		<form id="Form1" method="post" runat="server">
			<input type="hidden" name="cs1" value="#fffff0"> <input type="hidden" name="cs2" value="white">
			<input type="hidden" name="cs3" value="#e5ebf4"> <input type="hidden" name="cs4" value="whitesmoke">
			<TABLE id="Table4" width="96%" border="0">
				<TR>
					<TD width="146" height="35" style="WIDTH: 146px"></TD>
					<td align="right"><A href="../../Body.aspx"><IMG src="../../Image/MainMenu.jpg"></A><A href="../../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A></td>
				</TR>
				<tr>
					<td colspan="2">
						<table cellpadding="2" cellspacing="2" border="1" width="100%" align="center">
							<TR>
								<TD class="tdHeader1" colspan="2" align="center">
									CONTROL &amp; MONITORING</TD>
							</TR>
							<TR runat="server" id="TR_BUC_DANA">
								<TD id="id01" class="TDBGColor1" align="center"><INPUT type="radio" value="BUCDana.aspx" name="RB_1"></TD>
								<td id="id02" class="TDBGColorValue">&nbsp;
									<asp:Label id="Label0" runat="server"> Data Rekening Pihak Ketiga</asp:Label></td>
							</TR>
							<!--
							<TR runat="server" id="TR_BUC_KREDIT">
								<TD id="id11" class="TDBGColor1" align="center"><INPUT type="radio" value="BUCKredit.aspx" name="RB_1"></TD>
								<TD id="id12" class="TDBGColorValue">&nbsp;
									<asp:Label id="Label1" runat="server"> BUC Kredit</asp:Label>
								</TD>
							</TR>
							-->
							<TR runat="server" id="TR_CIF_DANA">
								<TD id="id21" class="TDBGColor1" align="center"><INPUT type="radio" value="CIFDana.aspx" name="RB_1"></TD>
								<TD id="id22" class="TDBGColorValue">&nbsp;
									<asp:Label id="Label2" runat="server"> CIF Dana</asp:Label>
								</TD>
							</TR>
							<TR runat="server" id="TR_CIF_KREDIT">
								<TD id="id31" class="TDBGColor1" align="center"><INPUT type="radio" value="CIFKredit.aspx" name="RB_1"></TD>
								<TD id="id32" class="TDBGColorValue">&nbsp;
									<asp:Label id="Label3" runat="server"> CIF Kredit</asp:Label>
								</TD>
							</TR>
							<TR runat="server" id="TR_PERKREDITAN">
								<TD class="TDBGColor1" id="id41" align="center"><INPUT type="radio" value="Perkreditan.aspx" name="RB_1"></TD>
								<TD id="id42" class="TDBGColorValue">&nbsp;&nbsp;
									<asp:Label id="Label4" runat="server"> Perkreditan</asp:Label>
								</TD>
							</TR>
							<TR runat="server" id="TR_AGUNAN">
								<TD class="TDBGColor1" id="id51" align="center"><INPUT type="radio" value="Agunan.aspx" name="RB_1"></TD>
								<TD id="id52" class="TDBGColorValue">&nbsp;&nbsp;
									<asp:Label id="Label5" runat="server"> Agunan</asp:Label>
								</TD>
							</TR>
							<TR runat="server" id="TR_ILP_ERROR">
								<TD class="TDBGColor1" id="id61" align="center"><INPUT type="radio" value="ILPErrorChecking.aspx" name="RB_1"></TD>
								<TD id="id62" class="TDBGColorValue">&nbsp;&nbsp;
									<asp:Label id="Label6" runat="server"> ILP Error Checking</asp:Label>
								</TD>
							</TR>
							<TR runat="server" id="TR_UNCLEAN_CIF">
								<TD class="TDBGColor1" id="id71" align="center"><INPUT type="radio" value="CIFUnclean.aspx" name="RB_1"></TD>
								<TD id="id72" class="TDBGColorValue">&nbsp;&nbsp;
									<asp:Label id="Label7" runat="server"> Unclean CIF </asp:Label>
								</TD>
							</TR>
							<TR runat="server" id="TR_NORMALISASI">
								<TD class="TDBGColor1" id="id81" align="center"><INPUT type="radio" value="NormalisasiCIF.aspx" name="RB_1"></TD>
								<TD id="id82" class="TDBGColorValue">&nbsp;&nbsp;
									<asp:Label id="Label8" runat="server"> Normalisasi CIF </asp:Label>
								</TD>
							</TR>
							<TR>
								<TD class="TDBGColor2" colSpan="2" height="90%" align="center">&nbsp;<INPUT class="BUTTON1" type="button" value="VIEW REPORT" onclick="view_report('<%=Request.QueryString["mc"] %>','<%=Request.QueryString["bu"] %>')"></TD>
							</TR>
						</table>
					</td>
				</tr>
			</TABLE>
			<CENTER></CENTER>
		</form>
	</body>
</HTML>
