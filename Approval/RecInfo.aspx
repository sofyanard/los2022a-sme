<%@ Page language="c#" Codebehind="RecInfo.aspx.cs" AutoEventWireup="True" Inherits="SME.Approval.MemoDE" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Memo</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0" ms_2d_layout="TRUE">
			<TR vAlign="top">
				<TD>
					<form id="Form1" method="post" runat="server">
						<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
						<TR>
							<TD class="tdBGColor2" align="center" width="400"><B>Request&nbsp;Information</B></TD>
							<TD class="tdNoBorder" align="right" height="29"><A href="ListCustomer.aspx?si="></A>
								<asp:ImageButton id="BTN_BACK" runat="server" ImageUrl="../Image/back.jpg" onclick="BTN_BACK_Click"></asp:ImageButton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
						</TR>
						<TR>
							<TD class="tdNoBorder" align="center" colSpan="2" height="41"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
						</TR>
						<TR>
							<TD vAlign="top" colSpan="2">
								<table id="Table5" cellSpacing="0" cellPadding="0" width="100%">
								<tr>
									<td><ASP:DATAGRID id="DatGrd" runat="server" Width="100%" HorizontalAlign="Center" AllowPaging="True"
											AutoGenerateColumns="False" CellPadding="1">
										<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
										<Columns>
											<asp:BoundColumn DataField="ap_acqinfodate" HeaderText="Date">
												<HeaderStyle Width="10%" CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" Width="120px"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ap_acqinfo" HeaderText="Description">
												<HeaderStyle Width="50%" CssClass="tdSmallHeader"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="SU_FUllname" HeaderText="From">
												<HeaderStyle Width="10%" CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" Width="120px"></ItemStyle>
											</asp:BoundColumn>
											</Columns>
											<PagerStyle Mode="NumericPages"></PagerStyle>
										</ASP:DATAGRID></td>
								</tr>
								</table>
							</TD>
						</TR>
					</TABLE>
					</form>
				</TD>
			</TR>
		</TABLE>
	</body>
</HTML>
