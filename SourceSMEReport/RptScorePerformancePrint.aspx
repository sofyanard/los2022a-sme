<%@ Page language="c#" Codebehind="RptScorePerformancePrint.aspx.cs" AutoEventWireup="True" Inherits="SME.SourceSMEReport.RptScorePerformancePrint" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RptScorePerformancePrint</title>
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
						<TD><P align="center"><B> SCORING PERFROMANCE&nbsp;REPORT</B></P>
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
							<asp:Label id="LBL_TEAM" runat="server">LBL_TEAM</asp:Label></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder">
							<asp:Table id="TBL_CONTENT" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"
								CellPadding="0" CellSpacing="0" ForeColor="Black">
								<asp:TableRow>
									<asp:TableCell Width="20px" RowSpan="2" Text="NO" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="120px" RowSpan="2" Text="BRANCH" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="120px" RowSpan="2" Text="APPL #" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="200px" RowSpan="2" Text="APPLICANT" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="120px" RowSpan="2" Text="INITIAL SCORING DATE" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="80px" RowSpan="2" Text="INITIAL SCORING DECISION (FAIR ISAAC)" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="80px" RowSpan="2" Text="INITIAL COLOUR" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="120px" RowSpan="2" Text="FINAL SCORING DATE" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="200px" ColumnSpan="4" Text="FINAL SCORING DECISION" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="100px" RowSpan="2" Text="RESULT" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="100px" RowSpan="2" Text="AMOUNT ACCEPTED" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="150px" RowSpan="2" Text="PIC" CssClass="HeaderPrint_d"></asp:TableCell>
								</asp:TableRow>
								<asp:TableRow>
									<asp:TableCell Width="120px" Text="FAIS ISAAC" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="120px" Text="CRSS" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="120px" Text="BCG" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="120px" Text="BPR" CssClass="HeaderPrint_d"></asp:TableCell>
								</asp:TableRow>
							</asp:Table>
						</TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:Label id="Label1" runat="server">Total Accepted Application in Initial Scoring</asp:Label>&nbsp;
							<asp:Label id="LBL_AcceptedI" runat="server">LBL_Accepted</asp:Label></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:Label id="Label2" runat="server">Total Rejected Application in Intial Scoring (Rejected and Grey Zone)</asp:Label>&nbsp;
							<asp:Label id="LBL_RejectedI" runat="server">LBL_Rejected</asp:Label></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:Label id="Label3" runat="server">Total Accepted Application in Final Scoring</asp:Label>&nbsp;
							<asp:Label id="LBL_AcceptedF" runat="server">LBL_Accepted</asp:Label></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:Label id="Label4" runat="server">Total Grey Zone Application in Final Scoring</asp:Label>&nbsp;
							<asp:Label id="LBL_GreyZoneF" runat="server">LBL_GreyZone</asp:Label></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:Label id="Label5" runat="server">Total Rejected Application in Final Scoring</asp:Label>&nbsp;
							<asp:Label id="LBL_RejectedF" runat="server">LBL_Rejected</asp:Label></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:Label id="Label6" runat="server">Initial Scoring - (Accepted/Grey Zone/Rejected)</asp:Label></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:Label id="Label7" runat="server">Final Scoring - (Accepted/Grey Zone/Rejected)</asp:Label></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:Label id="Label8" runat="server">Total Approved by Authority Holder</asp:Label></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:Label id="Label9" runat="server">Total Amount Accepted</asp:Label>&nbsp;
							<asp:Label id="LBL_Amount" runat="server">LBL_Amount</asp:Label></TD>
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
