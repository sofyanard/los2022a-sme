<%@ Page language="c#" Codebehind="RptSLABussinessUnitPrint.aspx.cs" AutoEventWireup="True" Inherits="SME.SourceSMEReport.RptSLABussinessUnitPrint" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RptSLABussinessUnitPrint</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
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
						<TD>
							<P align="center"><B>SLA BUSSINESS UNIT REPORT</B></P>
						</TD>
					</TR>
					<TR>
						<TD class="TitleReport" align="center"><asp:label id="LBL_PERIODE" runat="server"></asp:label></TD>
					</TR>
					<TR>
						<TD class="TitleReport" align="center"><asp:label id="LBL_REGION" runat="server"></asp:label></TD>
					</TR>
					<TR>
						<TD class="TitleReport" align="center"><asp:label id="LBL_CBC" runat="server"></asp:label></TD>
					</TR>
					<TR>
						<TD class="TitleReport" align="center"><asp:label id="LBL_BRANCH" runat="server"></asp:label></TD>
					</TR>
					<TR>
						<TD class="TitleReport" align="center"><asp:label id="lbl_team" runat="server" ForeColor="Black">TEAM 1</asp:label></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder"><asp:table id="TBL_CONTENT" runat="server" ForeColor="Black" BorderColor="Black" BorderStyle="Solid"
								BorderWidth="1px" CellPadding="0" CellSpacing="0">
								<asp:TableRow>
									<asp:TableCell Width="30px" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="120px" Text="#OF APPLICATION" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="200px" Text="TOTAL AMOUNT" CssClass="HeaderPrint"></asp:TableCell>
								</asp:TableRow>
							</asp:table></TD>
					</TR>
					<TR id="TRPRINT">
						<TD align="center"><INPUT onclick="cetak()" type="button" value="Print" Width="125px" CssClass="Button1"></ASP:BUTTON>
						</TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
