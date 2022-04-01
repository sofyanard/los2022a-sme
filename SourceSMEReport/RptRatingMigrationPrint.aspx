<%@ Page language="c#" Codebehind="RptRatingMigrationPrint.aspx.cs" AutoEventWireup="True" Inherits="SME.SourceSMEReport.RptRatingMigrationPrint" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RptRatingMigrationPrint</title>
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
							<P align="left"><B>RATING MIGRATION DEBITUR 3 TAHUN REAKHIR</B></P>
						</TD>
					</TR>
					<TR>
						<TD class="TitleReport" align="left"><asp:label id="LBL_PERIODE" runat="server"></asp:label></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder"><asp:table id="TBL_CONTENT" runat="server" ForeColor="Black" CellSpacing="0" CellPadding="0"
								BorderWidth="1px" BorderStyle="Solid" BorderColor="Black">
								<asp:TableRow>
									<asp:TableCell Width="80px" Text="NO" CssClass="HeaderPrint_d"></asp:TableCell>
                                    <asp:TableCell Width="100px" Text="INDUSTRI" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="200px" Text="NAMA NASABAH" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="100px" Text="TOTAL SCORE" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="80px" Text="P(D)" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="80px" Text="FINANCIAL RATING" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="80px" Text="CUSTOMER RATING" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="80px" Text="FACILITY RATING" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="80px" Text="LOSS" CssClass="HeaderPrint_d"></asp:TableCell>
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
