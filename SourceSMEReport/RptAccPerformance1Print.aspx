<%@ Page language="c#" Codebehind="RptAccPerformance1Print.aspx.cs" AutoEventWireup="True" Inherits="SME.SourceSMEReport.RptAccPerformance1Print" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RptAccPerformance1Print</title>
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
						<TD align="center" class="HeaderReport"><B></B></TD>
					</TR>
					<TR>
						<TD class="TitleHeaderReport" align="center">
							ANALYST/PUBLIC ACCOUNTANT PERFORMANCE REPORT</TD>
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
							<asp:Label id="lbl_team" runat="server" ForeColor="Black">[lbl_team]</asp:Label></TD>
					</TR>
					<!--					
					<TR>
						<TD class="TitleReport" align="center">
							<asp:Label id="lbl_ps" runat="server" ForeColor="Black">PS</asp:Label></TD>
					</TR>
-->
					<TR>
						<TD class="TDBGColorValue">
							<asp:Table id="TBL_CONTENT" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"
								Width="100%" CellPadding="0" CellSpacing="0">
								<asp:TableRow>
									<asp:TableCell Width="30px" Text="No." CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="120px" Text="BRANCH" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="80px" Text="APPL#" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Text="APPLICANTS" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="80px" Text="START DATE" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="80px" Text="END DATE" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="80px" Text="#OF DAYS" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="80px" Text="ANALYST" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="80px" Text="ACCOUNTANT" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="80px" Text="ACCOUNTANT OPINION" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Text="RM" CssClass="HeaderPrint"></asp:TableCell>
								</asp:TableRow>
							</asp:Table>
						</TD>
					</TR>
					<TR>
						<TD class="lblprint">
							<asp:Label id="lbl_complete" runat="server" ForeColor="Black">Total Pending Application : </asp:Label></TD>
					</TR>
					<TR>
						<TD class="lblprint">
							<asp:Label id="lbl_pending" runat="server" ForeColor="Black">Total Complete Application : </asp:Label></TD>
					</TR>
					<TR>
						<TD class="lblprint">
							<asp:Label id="lbl_ket1" runat="server" ForeColor="Black">Start Date : Fianancial Analysis Start Date</asp:Label></TD>
					</TR>
					<TR>
						<TD class="lblprint">
							<asp:Label id="lbl_ket2" runat="server" ForeColor="Black">End Date : After Nota Analisa is prepared</asp:Label></TD>
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
