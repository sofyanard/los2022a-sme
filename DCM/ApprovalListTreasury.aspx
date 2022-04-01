<%@ Page language="c#" Codebehind="ApprovalListTreasury.aspx.cs" AutoEventWireup="True" Inherits="SME.DCM.ApprovalListTreasury" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ApprovalListTreasury</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
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
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Approval List</B></TD>
								</TR>
							</TABLE>
						</td>
						<TD class="tdNoBorder" align="right"><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</tr>
					<TR>
						<TD colSpan="2"><ASP:DATAGRID id="DGR_CIF_LIST" runat="server" AutoGenerateColumns="False" CellPadding="1" AllowPaging="True"
								Width="100%">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="" HeaderText="Unit Kerja">
										<HeaderStyle CssClass="tdSmallHeader" Width="15%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="" HeaderText="CIF #">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="" HeaderText="Customer Name">
										<HeaderStyle CssClass="tdSmallHeader" Width="15%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="" HeaderText="Produk Type">
										<HeaderStyle CssClass="tdSmallHeader" Width="10%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="" HeaderText="PIC">
										<HeaderStyle CssClass="tdSmallHeader" Width="15%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Decision">
										<HeaderStyle CssClass="tdSmallHeader" Width="20%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:radiobuttonlist id="RBL_VISIT" runat="server" RepeatDirection="Horizontal" DataValueField="iscomply">
												<asp:ListItem Value="1">Approve</asp:ListItem>
												<asp:ListItem Value="2">Pending</asp:ListItem>
												<asp:ListItem Value="3">Reject</asp:ListItem>
											</asp:radiobuttonlist>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Function">
										<HeaderStyle CssClass="tdSmallHeader" Width="5%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="edit_data" runat="server" CommandName="edit_data">View</asp:LinkButton>&nbsp;
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
					<tr>
						<td></td>
					</tr>
					<tr align="center">
						<td class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2"><asp:button id="BTN_SAVE" runat="server" Width="76px" CssClass="Button1" Text="SUBMMIT"></asp:button>&nbsp;&nbsp;
						</td>
					</tr>
				</table>
			</CENTER>
		</form>
	</body>
</HTML>
