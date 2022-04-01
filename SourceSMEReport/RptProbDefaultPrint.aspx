<%@ Page language="c#" Codebehind="RptProbDefaultPrint.aspx.cs" AutoEventWireup="True" Inherits="SME.SourceSMEReport.RptProbDefaultPrint" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RptProbDefaultPrint</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
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
							<P align="left"><B>PROBABILITY OF DEFAULT REPORT</B></P>
						</TD>
					</TR>
					<TR>
						<TD class="TitleReport" align="left"><asp:label id="LBL_PERIODE" runat="server"></asp:label></TD>
					</TR>
					<TR>
						<TD>
							<P align="left">Actual Default Event</P>
						</TD>
					</TR>					
					<TR>
						<TD class="tdNoBorder"><asp:table id="TBL_CONTENT" runat="server" ForeColor="Black" CellSpacing="0" CellPadding="0"
								BorderWidth="1px" BorderStyle="Solid" BorderColor="Black">
								<asp:TableRow>
									<asp:TableCell Width="100px" Text="SCORE RANGE" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="100px" Text="RISK CLASS" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="120px" Text="RATING DEFAULT PROBABILITY" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="120px" Text="NUMBER OF COMPANY FALL INTO THE RANGE" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="120px" Text="DISTRIBUTION OF COMPANY IN RANGE" CssClass="HeaderPrint_d"></asp:TableCell>
								</asp:TableRow>
							</asp:table></TD>
					</TR>
					<TR id="TRPRINT">
						<TD align="center">
							<INPUT type="button" onclick="cetak()" Width="125px" Value="Print" CssClass="Button1"></ASP:BUTTON>
						</TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
