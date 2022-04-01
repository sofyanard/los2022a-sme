<%@ Page language="c#" Codebehind="Booking.aspx.cs" AutoEventWireup="True" Inherits="SME.Booking.Channeling.Booking" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ListInitiation</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../../include/cek_all.html" -->
		<!-- aaa -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="fSppkMonitor" method="post" runat="server">
			<center>
				<table id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder" style="WIDTH: 805px">
							<TABLE id="Table6">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Booking</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="../../Image/back.jpg"></asp:imagebutton><A href="../../Body.aspx"><IMG src="../../Image/MainMenu.jpg"></A>
							<A href="../../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A>
						</TD>
					</TR>
					<tr>
						<td style="HEIGHT: 28px" colSpan="2">
							<table>
								<tr>
									<td class="TDBGColor1" style="WIDTH: 154px"><STRONG>Application #</STRONG></td>
									<td style="WIDTH: 5px"><STRONG>:</STRONG></td>
									<td><asp:textbox onkeypress="return kutip_satu()" id="txt_regno" runat="server" MaxLength="20" Columns="30"
											Width="176px"></asp:textbox></td>
									<td style="WIDTH: 5px"></td>
									<td><asp:button id="btn_cari" runat="server" Width="56px" Text="Find" onclick="btn_cari_Click"></asp:button></td>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 50%" colSpan="2"><asp:datagrid id="dgListChan" runat="server" Width="100%" AutoGenerateColumns="False" ShowFooter="True">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="AP_REGNO" HeaderText="Application #">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CUST_NAME" HeaderText="End User Name">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AP_RECVDATE" HeaderText="App.Date">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="SU_FULLNAME" HeaderText="RM">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Function">
										<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="LinkView" runat="server" CommandName="View">View</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Confirm">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:RadioButton id="rdo_confirm" runat="server" GroupName="rdg_Decision"></asp:RadioButton>
										</ItemTemplate>
										<FooterStyle HorizontalAlign="Center"></FooterStyle>
										<FooterTemplate>
											<asp:LinkButton id="lnk_allcol" runat="server" CommandName="allconfirm">Select All</asp:LinkButton>
										</FooterTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="UnConfirm">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:RadioButton id="rdo_unconfirm" runat="server" GroupName="rdg_Decision"></asp:RadioButton>
										</ItemTemplate>
										<FooterStyle HorizontalAlign="Center"></FooterStyle>
										<FooterTemplate>
											<asp:LinkButton id="Linkbutton1" runat="server" CommandName="allunconfirm">Select All</asp:LinkButton>
										</FooterTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn Visible="False" DataField="CU_REF" HeaderText="RM">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
							</asp:datagrid>
						</td>
					</tr>
					<tr>
						<td width="100%" colspan="2" align="center" class="TDBGColor2">
							<asp:button id="BTN_SAVE" runat="server" Width="141px" Text="UPDATE STATUS" CssClass="BUTTON1" onclick="BTN_SAVE_Click"></asp:button>
						</td>
					</tr>
				</table>
			</center>
		</form>
	</body>
</HTML>
