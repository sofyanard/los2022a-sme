<%@ Page language="c#" Codebehind="ListReqPreData.aspx.cs" AutoEventWireup="True" Inherits="SME.IDI_BI.ListReqPreData" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ListReqPreData</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<CENTER>
				<table width="100%" border="0">
					<tr>
						<td align="left">
							<TABLE id="Table31">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>LIST REQUEST</B></TD>
								</TR>
							</TABLE>
						</td>
						<TD class="tdNoBorder" align="right"><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</tr>
					<TR>
						<TD colSpan="2"><ASP:DATAGRID id="DGR_LIST_REQUEST" runat="server" Width="100%" AllowPaging="True" CellPadding="1"
								AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn HeaderText="No. Surat" DataField="IDI_SURAT#">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="Request Date" DataField="IDI_REQDATE">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="IDI BI Request #" DataField="IDI_REQ#">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="Nama Debitur" DataField="IDI_CUSTNAME">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="NPWP" DataField="IDI_NPWP#">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="No.KTP/APP" DataField="IDI_KTP#">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="Tgl.Lahir/Pendirian" DataField="IDI_BOD_DATE">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="Unit" DataField="IDI_UNIT">
										<HeaderStyle Width="10%" CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="RM" DataField="IDI_OFFICER">
										<HeaderStyle Width="10%" CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Block Data">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:Button Text="Block" Runat="server" ID="BTN_BLOCK" CssClass="button1" CommandName="block"></asp:Button>
											<asp:Button Text="Unblock" Runat="server" ID="BTN_UNBLOCK" CssClass="button1" CommandName="unblock"></asp:Button>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" id="TR_B" vAlign="top" align="center" width="50%" colSpan="2"></TD>
					</TR>
				</table>
			</CENTER>
		</form>
	</body>
</HTML>
