<%@ Page language="c#" Codebehind="RptBPRChannelingPrint.aspx.cs" AutoEventWireup="True" Inherits="SME.SourceSMEReport.RptBPRChannelingPrint" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RptBPRChannelingPrint</title>
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
						<TD><P align="center"><B>BPR CHANNELING - BATCH APPLICATION REPORT</B></P>
						</TD>
					</TR>
					<TR>
						<TD class="TitleReport" align="center">
							<asp:Label id="LBL_PERIODE" runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD class="TitleReport" align="center">
							<asp:Label id="LBL_BPRNAME" runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD class="TitleReport" align="center">
							<asp:Label id="LBL_FACILITY" runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder">
							<asp:Table id="TBL_CONTENT" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"
								CellPadding="0" CellSpacing="0" ForeColor="Black">
								<asp:TableRow>
									<asp:TableCell Width="200px" Text="NAME OF BORROWER" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="200px" Text="KTP / COMPANY REGISTRATION" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="100px" Text="CREDIT LIMIT" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="200px" Text="PUSPOSE OF LOAN" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="200px" Text="STATUS" CssClass="HeaderPrint_d"></asp:TableCell>
								</asp:TableRow>
							</asp:Table>
						</TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:Label id="Label1" runat="server">Total Application Submited</asp:Label>&nbsp;
							<asp:Label id="LBL_SUBMIT" runat="server" Width="192px">LBL_SUBMIT</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:Label id="Label7" runat="server">Total Amount from Bank</asp:Label>&nbsp;&nbsp;
							<asp:Label id="LBL_BANK" runat="server" Width="192px">LBL_BANK</asp:Label></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:Label id="Label2" runat="server">Total Amount for the Batch</asp:Label>&nbsp;
							<asp:Label id="LBL_AMTSUBMITED" runat="server" Width="240px">LBL_AMTSUBMITED</asp:Label></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:Label id="Label3" runat="server">Total Application Accepted</asp:Label>&nbsp;
							<asp:Label id="LBL_ACCEPTED" runat="server" Width="208px">LBL_ACCEPTED</asp:Label></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:Label id="Label4" runat="server">Total Amount Accepted</asp:Label>&nbsp;
							<asp:Label id="LBL_AMTACCEPTED" runat="server" Width="216px">LBL_AMTACCEPTED</asp:Label></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:Label id="Label5" runat="server">Total Application Rejected</asp:Label>&nbsp;
							<asp:Label id="LBL_REJECTED" runat="server" Width="200px">LBL_REJECTED</asp:Label></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:Label id="Label6" runat="server">Total Amount Rejected</asp:Label>&nbsp;
							<asp:Label id="LBL_AMTREJECTED" runat="server" Width="232px">LBL_AMTREJECTED</asp:Label></TD>
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
