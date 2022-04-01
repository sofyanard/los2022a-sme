<%@ Page language="c#" Codebehind="PrintMonthlyReview.aspx.cs" AutoEventWireup="True" Inherits="SME.MAS.SupervisionManagement.MicroCreditQuality.MonthlyReview.PrintMonthlyReview" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PrintMonthlyReview</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../../Style.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function keluar()
		{
			if (confirm("Are you sure want to finish ?"))
				document.Fmain.submit();
		}
		
		function print_frame() 
		{
			//window.parent.framelkkn.focus();
			tr_print.style.display = "none";
			window.print();
			tr_print.style.display = "";
		}		
			
		</script>
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<tr id="tr_print" align="center">
						<td width="3%" colSpan="3"><INPUT class="button1" id="BTN_PRINT" onclick="print_frame();" type="button" value="Print"
								name="BTN_PRINT"><INPUT class="button1" id="BTN_BACK" onclick="javascript:history.back();" type="button"
								value="Back" name="BTN_BACK">
						</td>
					</tr>
					<tr>
						<TD class="td" vAlign="top" width="100%" colSpan="3">
							<TABLE id="Table4" cellSpacing="1" cellPadding="2" width="100%">
								<TR>
									<TD align="center" width="100%"><STRONG>LAPORAN AKTIVITAS BULANAN</STRONG></TD>
								</TR>
							</TABLE>
						</TD>
					</tr>
					<tr>
						<TD class="td" vAlign="top" width="100%" colSpan="3">
							<TABLE id="Table4" cellSpacing="1" cellPadding="2" width="100%">
								<TR>
									<TD width="100%"><STRONG>PERIODE :<asp:label id="TXT_PERIODE" Runat="server"></asp:label></STRONG></TD>
								</TR>
								<TR>
									<TD width="100%"><STRONG>CLUSTER :<asp:label id="TXT_CLUSTER" Runat="server"></asp:label></STRONG></TD>
								</TR>
							</TABLE>
						</TD>
					</tr>
					<TR>
						<TD colSpan="3"><ASP:DATAGRID id="DatGrd" runat="server" AutoGenerateColumns="False" CellPadding="1" Width="100%">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="seq#" HeaderText="seq">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="branch_name" HeaderText="Unit/Cabang Name">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="doc_kredit_desc" HeaderText="Dokumen Kredit">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="mmm_ots_desc" HeaderText="MMM OTS">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="monitoring_mmm" HeaderText="Kualitas Monitoring MMM">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="indikasi_calo_desc" HeaderText="Indikasi Calo">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="risk_level_desc" HeaderText="Risk Level">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
				</TABLE>
				<table id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<tr>
						<TD class="td" vAlign="top" width="33%" colSpan="1">
							<TABLE id="Table4" cellSpacing="1" cellPadding="2" width="100%">
								<TR>
									<TD align="left" width="100%"><STRONG>Dibuat Oleh :</STRONG></TD>
								</TR>
								<TR>
									<TD align="left" width="100%"><asp:Label Runat="server" ID="TXT_DIBUAT_OLEH"></asp:Label></TD>
								</TR>
							</TABLE>
						</TD>
					</tr>
				</table>
			</center>
		</form>
	</body>
</HTML>
