<%@ Page language="c#" Codebehind="RptOPDetalPrint.aspx.cs" AutoEventWireup="True" Inherits="SME.SourceSMEReport.RptOPDetalPrint" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RptOPDetalPrint</title>
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
						<TD><P align="center"><B>DAILY POSITION REPORT (DETAIL)</B></P>
						</TD>
					</TR>
					<TR>
						<TD class="TitleReport" align="center">
							<asp:Label id="LBL_PERIODE" runat="server"></asp:Label></TD>
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
						<TD class="tdNoBorder">
							<asp:Table id="TBL_CONTENT" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"
								CellPadding="0" CellSpacing="0" ForeColor="Black">
								<asp:TableRow>
									<asp:TableCell Width="30px" Text="No." CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="80px" Text="TANGGAL APPLIKASI" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="120px" Text="BRANCH" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="80px" Text="APPLICANT" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="80px" Text="APPL#" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="80px" Text="PERMASALAHAN" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="50px" Text="EKONOMI" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="50px" Text="PRODUCT" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="50px" Text="CURRENCY" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="50px" Text="APPLIED EXCHANGE RATE" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="50px" Text="LIMIT APPLIED" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="50px" Text="APPROVED EXCHANGE RATE" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="50px" Text="APPROVED AMMOUNT" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="50px" Text="EQUI IDR" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="50px" Text="DISBURSED AMMOUNT" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="50px" Text="STATUS" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="50px" Text="RM" CssClass="HeaderPrint_d"></asp:TableCell>
								</asp:TableRow>
							</asp:Table>
						</TD>
					</TR>
					<TR>
						<TD class="LblPrint">
							<asp:Label id="lbl_applied" runat="server" ForeColor="Black">Total Applied Application</asp:Label></TD>
					</TR>
					<TR>
						<TD class="LblPrint">
							<asp:Label id="lbl_approved" runat="server" ForeColor="Black">Total Approved Application</asp:Label></TD>
					</TR>
					<TR>
						<TD class="LblPrint">
							<asp:Label id="lbl_disbursed" runat="server" ForeColor="Black">Total Disbursed Application </asp:Label></TD>
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
