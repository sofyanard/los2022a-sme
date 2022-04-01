<%@ Page language="c#" Codebehind="RptDataAnalysisPrint.aspx.cs" AutoEventWireup="True" Inherits="SME.SourceSMEReport.RptDataAnalysisPrint" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RptDataAnalysisPrint</title>
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
						<TD><P align="center"><B>DATA ANALYSIS REPORT</B></P>
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
							<asp:Label id="LBL_SCORE" runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder">
							<asp:Table id="TBL_CONTENT" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"
								CellPadding="0" CellSpacing="0" ForeColor="Black">
								<asp:TableRow>
									<asp:TableCell Width="30px" Text="No." CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="120px" Text="APPLICATION NUMBER" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="80px" Text="PRODUCT TYPE" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Text="COLLATERAL TYPE" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="80px" Text="REGION" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="80px" Text="COMPANY NAME" CssClass="HeaderPrint_d"></asp:TableCell>
                                    <asp:TableCell Width="70px" Text="CBC/BRANCH" CssClass="HeaderPrint_d"></asp:TableCell>
                                    <asp:TableCell Width="70px" Text="COMPANY LEGAL TYPE" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="70px" Text="COMPANY GROUP" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="70px" Text="APPLICATION TYPE" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="70px" Text="CREDIT LIMIT" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="70px" Text="TOTAL EXPOSURE" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="70px" Text="KEY PERSON DOB" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="70px" Text="KEY PERSON SEX" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="70px" Text="KEY PERSON EDUCATION LEVEL" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="70px" Text="KEY PERSON MARITAL STATUS" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="70px" Text="KEY PERSON #OF CHILDREN" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="70px" Text="KEY PERSON HOUSE" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="70px" Text="ECONOMY SECTOR" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="70px" Text="TIME AT BUSINESS" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="70px" Text="#OF EMPLOYEE" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="70px" Text="YEAR RELATIONSHIP WITH BANK MANDIRI" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="70px" Text="OTHER BANK NAME" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="70px" Text="COLLATERAL VALUE" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="70px" Text="COLLATERAL OWNERSHIP" CssClass="HeaderPrint_d"></asp:TableCell>
                                    <asp:TableCell Width="70px" Text="BI KOLEKBILITAS" CssClass="HeaderPrint_d"></asp:TableCell>
                                    <asp:TableCell Width="70px" Text="INTERNAL KOLEKBILITAS" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="70px" Text="FINANCIAL YEAR" CssClass="HeaderPrint_d"></asp:TableCell>
									<asp:TableCell Width="70px" Text="FINANCIAL YEAR POS 1" CssClass="HeaderPrint_d"></asp:TableCell>
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
