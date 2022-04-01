<%@ Page language="c#" Codebehind="RptCRMApprovalPrint.aspx.cs" AutoEventWireup="True" Inherits="SME.SourceSMEReport.RptCRMApprovalPrint" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RptCRMApprovalPrint</title>
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
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="TitleHeaderReport" align="center">CRM&nbsp;APPROVAL REPORT</TD>
					</TR>
					<TR>
						<TD class="TitleReport" align="center"><asp:label id="LBL_PERIODE" runat="server"></asp:label></TD>
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
						<TD class="TitleReport" align="center"><asp:label id="LBL_PROGRAM" runat="server"></asp:label></TD>
					</TR>
					<TR>
						<TD align="center"><asp:table id="TBL_CONTENT" runat="server" Width="100%" CellSpacing="0" CellPadding="0" BorderWidth="1px"
								BorderStyle="Solid" BorderColor="Black">
								<asp:TableRow>
									<asp:TableCell Width="20px" Text="No." CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="150px" Text="BRANCH" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell width="150px" Text="#APPL" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="150px" Text="APPLICANTS" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="100px" Text="DOC SENT DATE" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="100px" Text="DOC RECEIVE DATE" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="100px" Text="REGUEST DATE" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell width="100px" Text="RETURN DATE" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="100px" Text="#OF DAYS" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="100px" Text="RESULT" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="150px" Text="CRM APPROVAL " CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="150px" Text="BU APPROVAL" CssClass="HeaderPrint"></asp:TableCell>
								</asp:TableRow>
							</asp:table></TD>
					</TR>
					<TR>
						<TD align="left">
							<P>
								<asp:Label id="Label4" runat="server" Width="176px">Total Accepted Application </asp:Label>
								<asp:Label id="Label8" runat="server">Label</asp:Label><BR>
								<asp:Label id="Label5" runat="server" Width="176px">Total Rejected Application </asp:Label>
								<asp:Label id="Label9" runat="server">Label</asp:Label><BR>
								<asp:Label id="Label6" runat="server" Width="176px">Total Completed Application </asp:Label>
								<asp:Label id="Label10" runat="server">Label</asp:Label><BR>
								<asp:Label id="Label7" runat="server" Width="176px">Total Pending Application </asp:Label>
								<asp:Label id="Label11" runat="server">Label</asp:Label><BR>
								<BR>
								<asp:Label id="Label1" runat="server" Width="272px">Request Date - Upon Nota Analisa Completed</asp:Label><BR>
								<asp:Label id="Label3" runat="server" Width="272px"> Return Date - Upon BU approval Completed </asp:Label><BR>
								<asp:Label id="Label2" runat="server" Width="272px">Result - Approved or Reject by BU</asp:Label></P>
						</TD>
					</TR>
				</TABLE>
				<TABLE id="Table2" cellSpacing="2" cellPadding="2" width="100%">
				</TABLE>
				<TR id="TRPRINT">
					<TD align="center"><INPUT onclick="cetak()" type="button" value="Print" Width="125px" CssClass="Button1"></ASP:BUTTON>
					</TD>
				</TR>
				</TABLE></center>
		</form>
	</body>
</HTML>
