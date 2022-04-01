<%@ Page language="c#" Codebehind="RptCustRepornsePrint.aspx.cs" AutoEventWireup="True" Inherits="SME.SourceSMEReport.RptCustRepornsePrint" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RptCustRepornsePrint</title>
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
							<P align="center"><B>SPPK RESPONSE REPORT</B></P>
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
						<TD class="TitleReport" align="center"><asp:label id="lbl_team" runat="server">TEAM 1</asp:label></TD>
					</TR>
					<TR>
						<TD class="TitleReport" align="center"><asp:label id="LBL_RM" runat="server"></asp:label></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder"><asp:table id="TBL_CONTENT" runat="server" ForeColor="Black" CellSpacing="0" CellPadding="0"
								BorderWidth="1px" BorderStyle="Solid" BorderColor="Black">
								<asp:TableRow>
									<asp:TableCell Width="30px" Text="No." CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="120px" Text="BRANCH" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="80px" Text="APPL#" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="120px" Text="APPLICANT" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="80px" Text="SPPK SENT" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="80px" Text="SPPK ACK" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="50px" Text="#OF DAYS" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="50px" Text="RESULT" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="50px" Text="RM" CssClass="HeaderPrint"></asp:TableCell>
								</asp:TableRow>
							</asp:table></TD>
					</TR>
					<TR>
						<TD class="LblPrint"><asp:label id="lbl_accepted" runat="server" ForeColor="Black">Total Accepted Application  :</asp:label></TD>
					</TR>
					<TR>
						<TD class="LblPrint"><asp:label id="lbl_rejected" runat="server" ForeColor="Black">Total Rejected Application  :</asp:label></TD>
					</TR>
					<TR>
						<TD class="LblPrint"><asp:label id="LBL_completed" runat="server" ForeColor="Black">Total Completed Application  :</asp:label></TD>
					</TR>
					<TR>
						<TD class="LblPrint"><asp:label id="lbl_pending" runat="server" ForeColor="Black">Total Pending Application  :</asp:label></TD>
					</TR>
					<TR>
						<TD class="LblPrint"><asp:label id="Label1" runat="server" ForeColor="Black">SPPK Sent - Send date of SPPK by BU</asp:label></TD>
					</TR>
					<TR>
						<TD class="LblPrint"><asp:label id="Label2" runat="server" ForeColor="Black">SPPK Ack - Acknowledgement of SPPK by Applicant</asp:label></TD>
					</TR>
					<TR>
						<TD class="LblPrint"><asp:label id="Label3" runat="server" ForeColor="Black">Result - Accept/Rejeck by Customer</asp:label></TD>
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
