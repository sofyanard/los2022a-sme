<%@ Page language="c#" Codebehind="RptRMApprovalAppealPrint.aspx.cs" AutoEventWireup="True" Inherits="SME.SourceSMEReport.RptRMApprovalAppealPrint" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RptRMApprovalAppealPrint</title>
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
						<TD class="TitleHeaderReport" align="center">
							REGIONAL MANAGER APPROVAL&nbsp;REPORT (APPEAL)</TD>
					</TR>
					<TR>
						<TD class="TitleReport" align="center">
							<asp:Label id="LBL_PERIODE" runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD class="TitleReport" align="center">
							<asp:Label id="LBL_REGION" runat="server"></asp:Label></TD>
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
						<TD class="TitleReport" align="center">
							<asp:Label id="LBL_APPROVAL" runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD align="center">
							<asp:Table id="TBL_CONTENT" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"
								CellPadding="0" CellSpacing="0" Width="100%">
								<asp:TableRow>
									<asp:TableCell Width="30px" Text="No." CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="200px" Text="BRANCH" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="150px" Text="APPL#" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell width="300px" Text="APPLICANTS" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="120px" Text="REQUEST DATE" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="120px" Text="RETURN DATE" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="50px" Text="#OF DAYS" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="80px" Text="TOTAL AMOUNT REQUEST" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="80px" Text="TOTAL AMOUNT APPROVED" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="80px" Text="APPEAL BY (CUSTOMER/RM)" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="80px" Text="APPROVAL STATUS" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="200px" Text="REGIONAL MANAGER" CssClass="HeaderPrint"></asp:TableCell>
								</asp:TableRow>
							</asp:Table>
						</TD>
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
