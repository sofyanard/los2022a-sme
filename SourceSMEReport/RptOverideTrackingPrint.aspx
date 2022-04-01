<%@ Page language="c#" Codebehind="RptOverideTrackingPrint.aspx.cs" AutoEventWireup="True" Inherits="SME.SourceSMEReport.RptOverideTrackingPrint" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RptOverideTrackingPrint</title>
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
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="TitleHeaderReport" align="center">
							OVERRIDE TRACKING REPORT</TD>
					</TR>
					<TR>
						<TD class="TitleReport" align="center">
							<asp:Label id="LBL_PERIODE" runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD class="TitleReport" align="center">
							<asp:Label id="LBL_PRODUCT" runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD class="TitleReport" align="center">
							<asp:Label id="LBL_REGION" runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD class="TitleReport" align="center"></TD>
					</TR>
					<TR>
						<TD align="center">
							<asp:Table id="TBL_CONTENT" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"
								CellPadding="0" CellSpacing="0" Width="70%">
								<asp:TableRow>
									<asp:TableCell Width="300" Text="OVERRIDE REASON" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="100px" Text="ACCEPTED" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="100px" Text="REJECTED" CssClass="HeaderPrint"></asp:TableCell>
								</asp:TableRow>
								<asp:TableRow HorizontalAlign="Left">
									<asp:TableCell ColumnSpan="3" HorizontalAlign="Left" Font-Bold="True" Text="&nbsp;Accepted Scorecard / Final Decision Reject"></asp:TableCell>
								</asp:TableRow>
							</asp:Table></TD>
					</TR>
				</TABLE>
				<TABLE id="Table2" cellSpacing="2" cellPadding="2" Width="100%">
				</TABLE>
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
