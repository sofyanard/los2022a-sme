<%@ Page language="c#" Codebehind="RptPRRKPreparationPrint.aspx.cs" AutoEventWireup="True" Inherits="SME.Scoring.RptPRRKPreparationPrint" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RptPRRKPreparationPrint</title>
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
							<P align="center"><B>PRRK PREPARATION&nbsp;REPORT</B></P>
						</TD>
					</TR>
					<TR>
						<TD class="TitleReport" align="center"><asp:label id="LBL_PERIODE" runat="server"></asp:label></TD>
					</TR>
					<TR>
						<TD class="TitleReport" align="center"><asp:label id="LBL_REGION" runat="server"></asp:label></TD>
					</TR>
					<TR>
						<TD class="TitleReport" align="center"><asp:label id="LBL_CBC" runat="server"></asp:label></TD>
					</TR>
					<TR>
						<TD class="TitleReport" align="center"><asp:label id="LBL_BRANCH" runat="server"></asp:label></TD>
					</TR>
					<TR>
						<TD class="TitleReport" align="center"><asp:label id="LBL_TEAM" runat="server"></asp:label></TD>
					</TR>
					<TR>
						<TD class="TitleReport" align="center"><asp:label id="LBL_PS" runat="server"></asp:label></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder"><asp:table id="TBL_CONTENT" runat="server" ForeColor="Black" CellSpacing="0" CellPadding="0"
								BorderWidth="1px" BorderStyle="Solid" BorderColor="Black">
								<asp:TableRow>
									<asp:TableCell Width="80px" Text="NO" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="200px" Text="BRANCH" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="120px" Text="APPL #" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="200px" Text="APPLICANT" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="80px" Text="DOC SENT DATE" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="80px" Text="DOC RECEIVE DATE" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="80px" Text="REQUEST DATE" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="80px" Text="RETURN DATE" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="100px" Text="JUMLAH HARI" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="200px" Text="PS" CssClass="HeaderPrint_d"></asp:TableCell>
								</asp:TableRow>
							</asp:table></TD>
					</TR>
					<TR>
						<TD align="left"><asp:label id="Label1" runat="server">Total Completed Application</asp:label>&nbsp;
							<asp:Label id="LBL_COMPLETED" runat="server">LBL_COMPLETED</asp:Label></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:Label id="Label2" runat="server">Total Pending Application</asp:Label>&nbsp;
							<asp:Label id="LBL_PENDING" runat="server">LBL_PENDING</asp:Label></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:Label id="Label3" runat="server">Request Date - Upon BU Approval</asp:Label></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:Label id="Label4" runat="server">Return Date - Upon completion of PRRK preparation</asp:Label></TD>
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
