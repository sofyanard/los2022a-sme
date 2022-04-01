<%@ Page language="c#" Codebehind="RptBUApprRegPrint.aspx.cs" AutoEventWireup="True" Inherits="SME.SourceSMEReport.RptBUApprRegPrint" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RptBUApprRegPrint</title>
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
						<TD class="HeaderReport" align="center"><B></B></TD>
					</TR>
					<TR>
						<TD class="TitleHeaderReport" align="center">BUSSINESS UNIT APPRAISAL REQUEST 
							REPORT</TD>
					</TR>
					<TR>
						<TD class="TitleReport" align="center"><asp:label id="lbl_periode" runat="server"></asp:label></TD>
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
						<TD class="TitleReport" align="center"><asp:label id="LBL_RM" runat="server"></asp:label></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder"><asp:table id="TBL_CONTENT" runat="server" ForeColor="Black" CellSpacing="0" CellPadding="0"
								BorderWidth="1px" BorderStyle="Solid" BorderColor="Black">
								<asp:TableRow>
									<asp:TableCell Width="30px" Text="No." CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="120px" Text="BRANCH" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="80px" Text="APPL#" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Text="COLLATERALS TYPE" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="80px" Text="COLLATERALS DETAIL 1" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="80px" Text="REQUEST DATE" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="70px" Text="END DATE" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="70px" Text="#OF DAYS" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Text="RM" CssClass="HeaderPrint"></asp:TableCell>
								</asp:TableRow>
							</asp:table></TD>
					</TR>
					<TR>
						<TD class="LblPrint"><asp:label id="lbl_completed" runat="server" ForeColor="Black">Total Completed Application  :</asp:label></TD>
					</TR>
					<TR>
						<TD class="LblPrint"><asp:label id="lbl_pending" runat="server" ForeColor="Black">Total Pending Application  :</asp:label></TD>
					</TR>
					<TR>
						<TD class="LblPrint"><asp:label id="lbl_ket1" runat="server" ForeColor="Black">Request Date : At Assign Verification, Select Collaterals Appraisal </asp:label></TD>
					</TR>
					<TR>
						<TD class="LblPrint"><asp:label id="lbl_ket2" runat="server" ForeColor="Black">End Datea : After Collaterals Result have been verified</asp:label></TD>
					</TR>
					<TR id="TRPRINT">
						<TD align="center"><INPUT onclick="cetak()" type="button" value="Print" CssClass="Button1" Width="125px"></ASP:BUTTON>
						</TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
