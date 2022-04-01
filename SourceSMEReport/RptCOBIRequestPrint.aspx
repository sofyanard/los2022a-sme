<%@ Page language="c#" Codebehind="RptCOBIRequestPrint.aspx.cs" AutoEventWireup="True" Inherits="SME.SourceSMEReport.RptCOBIRequestPrint" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RptCOBIRequestPrint</title>
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
						<TD class="TitleHeaderReport" align="center">
							CO BI REQUEST REPORT</TD>
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
							<asp:Label id="LBL_RM" runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD align="center">
							<asp:Table id="TBL_CONTENT" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"
								CellPadding="0" CellSpacing="0" Width="100%">
								<asp:TableRow>
									<asp:TableCell Width="30px" Text="No." CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="300px" Text="BRANCH" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="80px" Text="APPL#" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell width="300px" Text="APPLICANTS" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="150px" Text="REQUEST DATE" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="150px" Text="RETURN DATE" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="50px" Text="#OF DAYS" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="200px" Text="RM" CssClass="HeaderPrint"></asp:TableCell>
								</asp:TableRow>
							</asp:Table>
						</TD>
					</TR>
				</TABLE>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" Width="100%">
					<TR>
						<TD class="LblPrint">
							<asp:Label id="lbl_total_completed" runat="server" ForeColor="Black">Total Completed Application  :</asp:Label></TD>
					</TR>
					<TR>
						<TD class="LblPrint">
							<asp:Label id="lbl_total_peding" runat="server" ForeColor="Black">Total Pending Application  :</asp:Label></TD>
					</TR>
					<TR>
						<TD class="LblPrint">
							<asp:Label id="lbl_ket1" runat="server" ForeColor="Black">Request Date - Upon printing of BI checking</asp:Label></TD>
					</TR>
					<TR>
						<TD class="LblPrint">
							<asp:Label id="lbl_ket2" runat="server" ForeColor="Black">Return Date - Upon completion of entering BI Results by CO into the system</asp:Label></TD>
					</TR>
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
