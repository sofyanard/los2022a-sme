<%@ Page language="c#" Codebehind="RptPipeLine1SummPrint.aspx.cs" AutoEventWireup="True" Inherits="SME.SourceSMEReport.RptPipeLine1SummPrint" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RptPipeLine1SummPrint</title>
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
							<P align="left"><B> PIPELINE&nbsp;REPORT PER WILAYAH/CBC (SUMMARY)</B></P>
						</TD>
					</TR>
					<TR>
						<TD class="TitleReport" align="left">
							<asp:Label id="LBL_BUSINESSUNIT" runat="server"></asp:Label>&nbsp;PER WILAYAH</TD>
					</TR>
					<TR>
						<TD class="TitleReport" align="left">
							PERIODE
							<asp:Label id="LBL_PERIODE" runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder"><asp:table id="TBL_CONTENT" runat="server" CellSpacing="0" CellPadding="0" BorderWidth="1px"
								BorderStyle="Solid" BorderColor="Black" ForeColor="Black">
								<asp:TableRow>
									<asp:TableCell HorizontalAlign="Center" Width="30px" Text="No." RowSpan="3" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell HorizontalAlign="Center" Width="200px" ColumnSpan="2" RowSpan="3" Text="WILAYAH"
										CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell HorizontalAlign="Center" Width="300px" Text="PIPELINE DALAM PROSES" ColumnSpan="6"
										CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell HorizontalAlign="Center" Width="200px" Text="JUMLAH DALAM PROSES" RowSpan="2" ColumnSpan="2"
										CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell HorizontalAlign="Center" Width="200px" Text="SELESAI ON BOOKING" RowSpan="2" ColumnSpan="2"
										CssClass="HeaderPrint"></asp:TableCell>
								</asp:TableRow>
								<asp:TableRow>
									<asp:TableCell Width="70px" Text="BU" ColumnSpan="2" CssClass="HeaderPrint" HorizontalAlign="Center"></asp:TableCell>
									<asp:TableCell HorizontalAlign="Center" Width="70px" ColumnSpan="2" Text="RRM" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell HorizontalAlign="Center" Width="70px" Text="CO" ColumnSpan="2" CssClass="HeaderPrint"></asp:TableCell>
								</asp:TableRow>
								<asp:TableRow>
									<asp:TableCell HorizontalAlign="Center" Width="80px" Text="LIMIT (RP. JUTA)" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell HorizontalAlign="Center" Width="30px" Text="DEBITUR" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell HorizontalAlign="Center" Width="80px" Text="LIMIT (RP. JUTA)" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell HorizontalAlign="Center" Width="30px" Text="DEBITUR" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell HorizontalAlign="Center" Width="80px" Text="LIMIT (RP. JUTA)" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell HorizontalAlign="Center" Width="30px" Text="DEBITUR" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell HorizontalAlign="Center" Width="80px" Text="LIMIT (RP. JUTA)" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell HorizontalAlign="Center" Width="30px" Text="DEBITUR" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell HorizontalAlign="Center" Width="80px" Text="LIMIT (RP. JUTA)" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell HorizontalAlign="Center" Width="30px" Text="DEBITUR" CssClass="HeaderPrint"></asp:TableCell>
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
