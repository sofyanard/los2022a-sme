<%@ Page language="c#" Codebehind="RptOrdDocTrackPrint.aspx.cs" AutoEventWireup="True" Inherits="SME.SourceSMEReport.RptOrdDocTrackPrint" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RptOrdDocTrackPrint</title>
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
							<P align="center"><B>DOCUMENTS TRACKING REPORT</B></P>
						</TD>
					</TR>
					<TR>
						<TD class="TitleReport" align="center">
							<asp:Label id="LBL_PERIODE" runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD class="TitleReport" align="center">
							<asp:Label id="LBL_FROM" runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD class="TitleReport" align="center">
							<asp:Label id="LBL_TO" runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD class="TitleReport" align="center">
							<asp:Label id="LBL_BRANCH" runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD class="TitleReport" align="center">
							<asp:Label id="LBL_TEAM" runat="server" ForeColor="Black">TEAM 1</asp:Label></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder"><asp:table id="TBL_CONTENT" runat="server" CellSpacing="0" CellPadding="0" BorderWidth="1px"
								BorderStyle="Solid" BorderColor="Black" ForeColor="Black">
								<asp:TableRow>
									<asp:TableCell Width="30px" Text="No." CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="120px" Text="BRANCH" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="80px" Text="APP#" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Text="APPLICANTS" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="80px" Text="SEND DATE" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="80px" Text="RECEIVE DATE" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="70px" Text="FROM" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="70px" Text="TO" CssClass="HeaderPrint"></asp:TableCell>
								</asp:TableRow>
							</asp:table></TD>
					</TR>
					<TR align="left">
						<TD class="tdNoBorder">
							<asp:Label id="lbl_total" runat="server" ForeColor="Black">Total Application  :</asp:Label>
						</TD>
					</TR>
					<TR align="left">
						<TD class="tdNoBorder">
							<asp:Label id="lbl_send" runat="server" ForeColor="Black">Total Send  :</asp:Label>
						</TD>
					</TR>
					<TR align="left">
						<TD class="tdNoBorder">
							<asp:Label id="lbl_receive" runat="server" ForeColor="Black">Total Receive  :</asp:Label>
						</TD>
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
