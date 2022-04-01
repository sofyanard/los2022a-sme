<%@ Page language="c#" Codebehind="RptOverallSLAPrint.aspx.cs" AutoEventWireup="True" Inherits="SME.SourceSMEReport.RptOverallSLAPrint" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RptOverallSLAPrint</title>
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
						<TD class="TitleHeaderReport" align="left">
							OVERRALL SLA REPORT</TD>
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
						<TD class="TitleReport" align="left">
							<asp:Label id="LBL_PROGRAM" runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD class="TitleReport" align="left">
							<asp:Label id="LBL_TEAM" runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD class="TitleReport" align="left">
							<asp:Label id="LBL_RM" runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD align="center">
							<asp:Table id="TBL_CONTENT" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"
								CellPadding="0" CellSpacing="0" Width="100%">
								<asp:TableRow>
									<asp:TableCell RowSpan="3" Width="30px" Text="No." CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell RowSpan="3" Width="120px" Text="NO APPLIKASI" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell RowSpan="3" Width="200px" Text="NAMA" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell RowSpan="3" width="150px" Text="PROGRAM" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell RowSpan="3" Width="100px" Text="CREDIT TYPE" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell RowSpan="3" Width="100px" Text="APPLICATION AMOUNT" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell RowSpan="3" Width="100px" Text="APPLICATION RECEIVE DATE" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell ColumnSpan="11" HorizontalAlign=Center  Width="1000px" Text="BUSINESS UNIT" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell ColumnSpan="3" HorizontalAlign=Center Width="300px" Text="CRM" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell ColumnSpan="9" HorizontalAlign=Center Width="900px" Text="CREDIT OPERATION(CO)" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="100px" Text="JUMLAH DALAM PROSES" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="100px" Text="SELESAI ON BOOKING" CssClass="HeaderPrint"></asp:TableCell>
								</asp:TableRow>
								<asp:TableRow>
									<asp:TableCell RowSpan="2" Width="100px" Text="INITIAL DATA ENTRY" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell RowSpan="2" Width="100px" Text="DTBO" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell RowSpan="2" Width="100px" Text="DETAIL DATA ENTRY" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell RowSpan="2" Width="100px" Text="VERIFICATION ASSIGNMENT" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell RowSpan="2" Width="100px" Text="CREDIT ANALIST" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell RowSpan="2" Width="100px" Text="SCORING / RATING" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell RowSpan="2" Width="100px" Text="CREDIT PROPOSAL" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell ColumnSpan="3" Width="100px" Text="BU APPROVAL" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell RowSpan="2" Width="100px" Text="TOTAL HARI" CssClass="HeaderPrint"></asp:TableCell>

									<asp:TableCell RowSpan="2" Width="100px" Text="CRM APPROVAL" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell RowSpan="2" Width="100px" Text="PRRK" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell RowSpan="2" Width="100px" Text="TOTAL HARI" CssClass="HeaderPrint"></asp:TableCell>
									
									<asp:TableCell RowSpan="2" Width="100px" Text="BI CHECKING" CssClass="HeaderPrint"></asp:TableCell>
                                    <asp:TableCell RowSpan="2" Width="100px" Text="APPRAISAL ENTRY" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell RowSpan="2" Width="100px" Text="LEGAL SIGNING CONDITION" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell RowSpan="2" Width="100px" Text="ASSIGN NOTARY & INSURANCE" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell RowSpan="2" Width="100px" Text="DISBURSEMENT CHECKLIST" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell RowSpan="2" Width="100px" Text="BOOKING" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell RowSpan="2" Width="100px" Text="SPPK LETTER" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell RowSpan="2" Width="100px" Text="SPPK CONFIRMATION" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell RowSpan="2" Width="100px" Text="TOTAL HARI" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="100px" Text="LIMIT" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="100px" Text="LIMIT" CssClass="HeaderPrint"></asp:TableCell>
								</asp:TableRow>
								
                                <asp:TableRow>
									<asp:TableCell Width="100px" Text="TEAM LEADER" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="100px" Text="CBC MANAGER" CssClass="HeaderPrint"></asp:TableCell>
                                    <asp:TableCell Width="100px" Text="GH" CssClass="HeaderPrint"></asp:TableCell>
                                    <asp:TableCell Width="100px" Text="RP. JUTA" CssClass="HeaderPrint"></asp:TableCell>
                                    <asp:TableCell Width="100px" Text="RP. JUTA" CssClass="HeaderPrint"></asp:TableCell>                                    
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
