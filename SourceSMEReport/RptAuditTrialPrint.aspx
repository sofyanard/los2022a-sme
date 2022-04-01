<%@ Page language="c#" Codebehind="RptAuditTrialPrint.aspx.cs" AutoEventWireup="True" Inherits="SME.SourceSMEReport.RptAuditTrialPrint" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RptAuditTrialPrint</title>
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
							AUDIT TRAIL REPORT</TD>
					</TR>
					<TR>
						<TD class="TitleReport" align="center">
							<asp:Label id="LBL_PERIODE" runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD class="TitleReport" align="center">
							<asp:Label id="LBL_REGNO" runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD class="TitleReport" align="center">
							<asp:Label id="LBL_RM" runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD class="TitleReport" align="center"></TD>
					</TR>
					<TR>
						<TD align="center">
							<asp:Table id="TBL_CONTENT" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"
								CellPadding="0" CellSpacing="0" Width="100%">
								<asp:TableRow>
									<asp:TableCell Text="No." CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Text="APPL#" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Text="APP TYPE" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Text="PRODUCT" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Text="CUSTOMER NAME" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Text="TRACK NAME" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Text="TRACK DATE" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Text="AUDIT DESC" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Text="AUDIT LIMIT" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Text="PERSONAL" CssClass="HeaderPrint"></asp:TableCell>
								</asp:TableRow>
							</asp:Table>
							<asp:Label id="LBL_BRANCH" runat="server" Visible="False"></asp:Label>
						</TD>
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
