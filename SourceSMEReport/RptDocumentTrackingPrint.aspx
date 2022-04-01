<%@ Page language="c#" Codebehind="RptDocumentTrackingPrint.aspx.cs" AutoEventWireup="True" Inherits="SME.SourceSMEReport.RptDocumentTrackingPrint" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RptDocumentTrackingPrint</title>
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
			<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
				<TR>
					<TD class="TitleHeaderReport" align="center">
						DOCUMENT TRACKING&nbsp;REPORT</TD>
				</TR>
				<TR>
					<TD class="TitleReport" align="center">
						<asp:Label id="LBL_PERIODE" runat="server"></asp:Label></TD>
				</TR>
				<TR>
					<TD class="TitleReport" align="center">
						<asp:Label id="LBL_CBC" runat="server">LBL_CBC</asp:Label></TD>
				</TR>
				<TR>
					<TD class="TitleReport" align="center">
						<asp:Label id="LBL_BRANCH" runat="server"></asp:Label></TD>
				</TR>
				<TR>
					<TD class="TitleReport" align="center">
						<asp:Label id="LBL_TEAM" runat="server"></asp:Label></TD>
				</TR>
				<TR>
					<TD align="center">
						<asp:Table id="TBL_CONTENT" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"
							CellPadding="0" CellSpacing="0" Width="100%">
							<asp:TableRow>
								<asp:TableCell Width="50px" Text="No." CssClass="HeaderPrint"></asp:TableCell>
								<asp:TableCell Width="200px" Text="BRANCH" CssClass="HeaderPrint"></asp:TableCell>
								<asp:TableCell Width="120px" Text="APPL#" CssClass="HeaderPrint"></asp:TableCell>
								<asp:TableCell width="300px" Text="APPLICANTS" CssClass="HeaderPrint"></asp:TableCell>
								<asp:TableCell Width="150px" Text="SENT DATE" CssClass="HeaderPrint"></asp:TableCell>
								<asp:TableCell Width="150px" Text="RECEIVE DATE" CssClass="HeaderPrint"></asp:TableCell>
								<asp:TableCell Width="100px" Text="FROM" CssClass="HeaderPrint"></asp:TableCell>
								<asp:TableCell Width="100px" Text="TO" CssClass="HeaderPrint"></asp:TableCell>
							</asp:TableRow>
						</asp:Table>
					</TD>
				</TR>
				<TR>
					<TD align="left">
						<asp:Label id="LBL_APP" runat="server">Total Application</asp:Label>&nbsp;
						<asp:Label id="LBL_APPL" runat="server">LBL_APPL</asp:Label></TD>
				</TR>
				<TR>
					<TD align="left">
						<asp:Label id="Label2" runat="server">Total Sent</asp:Label>&nbsp;
						<asp:Label id="LBL_SENT" runat="server">LBL_SENT</asp:Label></TD>
				</TR>
				<TR>
					<TD align="left">
						<asp:Label id="Label3" runat="server">Total Receive</asp:Label>&nbsp;
						<asp:Label id="LBL_RECV" runat="server">LBL_RECV</asp:Label></TD>
				</TR>
			</TABLE>
			<TABLE id="Table2" cellSpacing="2" cellPadding="2" Width="100%">
				<TR id="TRPRINT">
					<TD align="center">
						<INPUT type="button" onclick="cetak()" Width="125px" Value="Print" CssClass="Button1"></ASP:BUTTON>
					</TD>
				</TR>
			</TABLE>
			<CENTER></CENTER>
		</form>
	</body>
</HTML>
