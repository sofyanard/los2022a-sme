<%@ Page language="c#" Codebehind="RpteBizCardPrint.aspx.cs" AutoEventWireup="True" Inherits="SME.SourceSMEReport.RpteBizCardPrint" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RpteBizCardPrint</title>
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
						<TD><P align="left"><B>EBIZ POLA CARDHOLDER NAME REPORT</B></P>
						</TD>
					</TR>
					<TR>
						<TD class="TitleReport" align="left">
							<asp:Label id="LBL_PERIODE" runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD class="TitleReport" align="left">
							<asp:Label id="LBL_REGION" runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD class="TitleReport" align="left">
							<asp:Label id="LBL_CBC" runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD class="TitleReport" align="left">
							<asp:Label id="LBL_BRANCH" runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder">
							<asp:Table id="TBL_CONTENT" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"
								CellPadding="0" CellSpacing="0" ForeColor="Black">
								<asp:TableRow>
									<asp:TableCell Width="200px" RowSpan="2" Text="NAMA NASABAH" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="120px" RowSpan="2" Text="APPL #" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="200px" RowSpan="2" Text="PRODUCT" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="80px" RowSpan="2" Text="TANGGAL APPROVED" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="200px" RowSpan="2" Text="CARDHOLDER NAME" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="200px" Text="NEW CARD" CssClass="HeaderPrint_d"></asp:TableCell>
								</asp:TableRow>
								<asp:TableRow>
									<asp:TableCell Width="200px" Text="ENDORSENAME 2" CssClass="HeaderPrint_d"></asp:TableCell>
								</asp:TableRow>
							</asp:Table>
						</TD>
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
