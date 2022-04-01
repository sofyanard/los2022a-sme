<%@ Page language="c#" Codebehind="RptCONotaryMntrPrint.aspx.cs" AutoEventWireup="True" Inherits="SME.SourceSMEReport.RptCONotaryMntrPrint" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RptCONotaryMntrPrint</title>
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
						<TD><P align="center"><B>CO NOTARY MONITORING REPORT</B></P>
						</TD>
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
							<asp:Label id="LBL_CBC" runat="server"></asp:Label></TD>
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
						<TD class="TitleReport" align="center">
							<asp:Label id="LBL_RM" runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD class="TitleReport" align="center">
							<asp:Label id="lbl_notary" runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder">
							<asp:Table id="TBL_CONTENT" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"
								CellPadding="0" CellSpacing="0" ForeColor="Black" Width="100%">
								<asp:TableRow>
									<asp:TableCell Width="20px" Text="NO" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="150px" Text="BRANCH" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="120px" Text="APPL#" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="200px" Text="APPLICANTS" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="120px" Text="START DATE" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="120px" Text="END DATE" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="50px" Text="#OF DAYS" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="70px" Text="CO COMMENT" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="100px" Text="NOTARY" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="150px" Text="RM" CssClass="HeaderPrint"></asp:TableCell>
								</asp:TableRow>
							</asp:Table>
						</TD>
					</TR>
					<TR>
						<TD class="LblPrint"><asp:label id="lbl_complete" runat="server" ForeColor="Black">Total Complete Application  :</asp:label></TD>
					</TR>
					<TR>
						<TD class="LblPrint"><asp:label id="lbl_pending" runat="server" ForeColor="Black">Total Pending Application  :</asp:label></TD>
					</TR>
					<TR>
						<TD class="LblPrint"><asp:label id="lbl_start_Date" runat="server" ForeColor="Black">Start Date  :  The data completion of notary assignment</asp:label></TD>
					</TR>
					<TR>
						<TD class="LblPrint"><asp:label id="lbl_end_date" runat="server" ForeColor="Black">End Date  :  The data return of legal signing process</asp:label></TD>
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
