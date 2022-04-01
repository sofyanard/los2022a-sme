<%@ Page language="c#" Codebehind="RptPenolakanKreditPrint.aspx.cs" AutoEventWireup="True" Inherits="SME.SourceSMEReport.RptPenolakanKreditPrint" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RptPenolakanKreditPrint</title>
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
							LAPORAN PENOLAKAN KREDIT</TD>
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
						<TD class="TitleReport" align="center">
							<asp:Label id="LBL_TEAM" runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD class="TitleReport" align="center">
							<asp:Label id="LBL_PROGRAM" runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD class="TitleReport" align="center">
							<asp:Label id="LBL_PRODUCT" runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD align="center">
							<asp:Table id="TBL_CONTENT" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"
								CellPadding="0" CellSpacing="0" Width="100%">
								<asp:TableRow>
									<asp:TableCell Width="30px" Text="No." CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="200px" Text="BRANCH" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="200px" Text="PRODUCT" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell width="150px" Text="REJECT REASON" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="120px" Text="TOTAL AMOUNT" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="100px" Text="PERCENTAGE" CssClass="HeaderPrint"></asp:TableCell>
								</asp:TableRow>
							</asp:Table>
						</TD>
					</TR>
				</TABLE>
				<TABLE id="Table2" cellSpacing="2" cellPadding="2" Width="100%">
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
