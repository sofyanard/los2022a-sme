<%@ Page language="c#" Codebehind="RptCaracterAnalysisPrint.aspx.cs" AutoEventWireup="True" Inherits="SME.SourceSMEReport.RptCaracterAnalysisPrint" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RptCaracterAnalysisPrint</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="style.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		  function cetak()
		  {
		    TRPRINT.style.display = "none";
		    window.print();
		    TRPRINT.style.display = "";
		  }
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2">
					<TR>
						<TD>
							<P align="left"><B>CHARACTERISTIC ANALYSIS&nbsp;REPORT</B></P>
						</TD>
					</TR>
					<TR>
						<TD class="TitleReport" align="left"><asp:label id="LBL_PERIODE" runat="server"></asp:label></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder"><asp:table id="TBL_CONTENT" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"
								CellPadding="0" CellSpacing="0" ForeColor="Black">
								<asp:TableRow>
									<asp:TableCell Width="120px" Text="ATTRIBUT" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="100px" Text="Recent" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="100px" Text="Past" CssClass="HeaderPrint_d"></asp:TableCell>
								</asp:TableRow>
							</asp:table></TD>
					</TR>
					<TR id="TRPRINT">
						<TD align="center"><INPUT onclick="cetak()" type="button" value="Print" CssClass="Button1" Width="125px"></ASP:BUTTON>
						</TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
