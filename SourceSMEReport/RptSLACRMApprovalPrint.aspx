<%@ Page language="c#" Codebehind="RptSLACRMApprovalPrint.aspx.cs" AutoEventWireup="True" Inherits="SME.SourceSMEReport.RptSLACRMApprovalPrint" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RptSLACRMApprovalPrint</title>
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
							<P align="center"><B> SLA CRM APPROVAL REPORT</B></P>
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
						<TD class="TitleReport" align="center">
							<asp:label id="lbl_team" runat="server">TEAM 1</asp:label></TD>
					</TR>
					<TR>
						<TD class="TitleReport" align="center"><asp:label id="LBL_APPROVAL" runat="server"></asp:label></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder"><asp:table id="TBL_CONTENT" runat="server" CellSpacing="0" CellPadding="0" BorderWidth="1px"
								BorderStyle="Solid" BorderColor="Black" ForeColor="Black">
								<asp:TableRow>
									<asp:TableCell Width="30px" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="150px" Text="#OF APPLICATION" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="200px" Text="TOTAL AMOUNT" CssClass="HeaderPrint"></asp:TableCell>
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
