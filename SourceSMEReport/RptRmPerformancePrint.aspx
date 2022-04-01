<%@ Page language="c#" Codebehind="RptRmPerformancePrint.aspx.cs" AutoEventWireup="True" Inherits="SME.SourceSMEReport.RptRmPerformancePrint" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RptRmPerformancePrint</title>
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
							<P align="center"><B>RM PERFORMANCE REPORT</B></P>
						</TD>
					</TR>
					<TR>
						<TD class="TitleReport" align="center">
							<asp:Label id="LBL_PERIODE" runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD class="TitleReport" align="center">
							<asp:Label id="LBL_CBC" runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD class="TitleReport" align="center">
							<asp:Label id="LBL_BRANCH" runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD class="TitleReport" align="center">
							<asp:Label id="LBL_TEAM" runat="server">TEAM 1</asp:Label></TD>
					</TR>
					<TR>
						<TD class="TitleReport" align="center">
							<asp:Label id="LBL_PROGRAM" runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD class="TitleReport" align="center">
							<asp:Label id="LBL_PRODUCT" runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD class="TitleReport" align="center">
							<asp:Label id="LBL_INDUSTRI" runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder"><asp:table id="TBL_CONTENT" runat="server" CellSpacing="0" CellPadding="0" BorderWidth="1px"
								BorderStyle="Solid" BorderColor="Black" ForeColor="Black">
								<asp:TableRow>
									<asp:TableCell Width="30px" Text="No." CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="120px" Text="BRANCH" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="80px" Text="PRODUCT" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Text="INDUSTRI" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="80px" Text="TOTAL APPLICATION APPROVED" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="70px" Text="TOTAL AMOUNT APPROVED" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="70px" Text="TOTAL AMOUNT DISBURSED" CssClass="HeaderPrint"></asp:TableCell>
                                    <asp:TableCell Width="80px" Text="TEAM" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="80px" Text="RM" CssClass="HeaderPrint"></asp:TableCell>
								</asp:TableRow>
							</asp:table></TD>
					</TR>
					<TR>
						<TD class="LblPrint">
							<asp:Label id="lbl_total1" runat="server" ForeColor="Black">Total Application - Reffering to Application Form (Could be multiple service)</asp:Label></TD>
					</TR>
					<TR>
						<TD class="LblPrint">
							<asp:Label id="lbl_total2" runat="server" ForeColor="Black">Total Accepted</asp:Label></TD>
					</TR>
					<TR>
						<TD class="LblPrint">
							<asp:Label id="lbl_total3" runat="server" ForeColor="Black">Total Amount - New Application Amount + Renewal + (Limit Changes)</asp:Label></TD>
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
