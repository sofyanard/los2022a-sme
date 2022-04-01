<%@ Page language="c#" Codebehind="RptCOApprReqPrint.aspx.cs" AutoEventWireup="True" Inherits="SME.SourceSMEReport.RptCOApprReqPrint" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RptCOApprReqPrint</title>
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
						<TD><P align="center"><B>CREDIT OPERATION APPRAISAL REQUEST REPORT</B></P>
						</TD>
					</TR>
					<TR>
						<TD class="TitleReport" align="center">
							<asp:Label id="lbl_periode" runat="server"></asp:Label></TD>
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
							<asp:Label id="lbl_team" runat="server">lbl_team</asp:Label></TD>
					</TR>
					<TR>
						<TD class="TitleReport" align="center">
							<asp:Label id="LBL_RM" runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD class="TitleReport" align="center">
							<asp:Label id="lbl_agency" runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder">
							<asp:Table id="TBL_CONTENT" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"
								CellPadding="0" CellSpacing="0" ForeColor="Black">
								<asp:TableRow>
									<asp:TableCell Width="20px" Text="No." CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="120px" Text="BRANCH" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="80px" Text="APPL#" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Text="COLLATERALS TYPE" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="80px" Text="COLLATERALS DETAIL 1" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="80px" Text="REQUEST DATE" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="80px" Text="END DATE" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="50px" Text="#OF DAYS" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="70px" Text="APPRAISAL AGENCY" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="70px" Text="VALUE" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="70px" Text="CO COMMENT" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Text="RM" CssClass="HeaderPrint"></asp:TableCell>
								</asp:TableRow>
							</asp:Table>
						</TD>
					</TR>
					<TR>
						<TD class="LblPrint">
							<asp:Label id="lbl_completed" runat="server" ForeColor="Black">Total Completed Application  :</asp:Label></TD>
					</TR>
					<TR>
						<TD class="LblPrint">
							<asp:Label id="lbl_pending" runat="server" ForeColor="Black">Total Pending Application  :</asp:Label></TD>
					</TR>
					<TR>
						<TD class="LblPrint">
							<asp:Label id="lbl_ket1" runat="server" ForeColor="Black">Request Date : At Assign Verification, Select Collaterals Appraisal </asp:Label></TD>
					</TR>
					<TR>
						<TD class="LblPrint">
							<asp:Label id="lbl_ket2" runat="server" ForeColor="Black">End Datea : After Collaterals Result have been verified</asp:Label></TD>
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
