<%@ Page language="c#" Codebehind="ApprovalSPPK.aspx.cs" AutoEventWireup="True" Inherits="SME.SPPK.Channeling.ApprovalSPPK" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ListInitiation</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
		<!-- aaa -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="fSppkMonitor" method="post" runat="server">
			<center>
				<table id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder" style="WIDTH: 1022px"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
							<TABLE id="Table6">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>SPPK&nbsp;Letter</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="../../Image/back.jpg"></asp:imagebutton><A href="../../Body.aspx"><IMG src="../../Image/MainMenu.jpg"></A>
							<A href="../../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A>
						</TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">Customer&nbsp;Data</TD>
					</TR>
					<tr>
						<td colSpan="2"><asp:datagrid id="dgListChan" runat="server" ShowFooter="True" Width="100%" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="AP_REGNO" HeaderText="Application #">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="12%"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CUST_NAME" HeaderText="End User Name">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="12%"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="ALAMAT" HeaderText="Address">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="12%"></ItemStyle>
									</asp:BoundColumn>
									<asp:ButtonColumn Text="Export SPPK" HeaderText="Function" CommandName="Export">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="8%"></ItemStyle>
									</asp:ButtonColumn>
									<asp:BoundColumn DataField="FILENAMES" HeaderText="File Name">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AGING" HeaderText="Aging">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="4%"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Status">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="4%"></ItemStyle>
										<ItemTemplate>
											<asp:CheckBox ID="CB_STATUS" Runat="server"></asp:CheckBox>
										</ItemTemplate>
										<FooterStyle HorizontalAlign="Center"></FooterStyle>
										<FooterTemplate>
											<asp:LinkButton id="Linkbutton4" runat="server" CommandName="checkall">Check All</asp:LinkButton>
										</FooterTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Cancel">
										<HeaderStyle Width="25%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemTemplate>
											<asp:DropDownList id="DDL_CANCEL" Runat="server" Width="100%"></asp:DropDownList>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</asp:datagrid></td>
					</tr>
					<tr>
						<center>
							<td align="center" width="100%" colSpan="2"><asp:button id="BTN_SAVE" runat="server" Width="189px" Text="ACQUIRE INFORMATION" CssClass="BUTTON1" onclick="BTN_SAVE_Click"></asp:button><asp:button id="BTN_UPDATE_STATUS" runat="server" Width="167px" Text="UPDATE STATUS" CssClass="Button1" onclick="BTN_UPDATE_STATUS_Click"></asp:button></td>
						</center>
					</tr>
				</table>
			</center>
		</form>
	</body>
</HTML>
