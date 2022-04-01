<%@ Page language="c#" Codebehind="BUCDanaAppr.aspx.cs" AutoEventWireup="True" Inherits="SME.DCM.BUCDanaAppr" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>BUCDanaAppr</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0">
				<tr>
					<td style="WIDTH: 686px" align="left">
						<table>
							<tr>
								<td class="tdBGColor2" style="WIDTH: 400px" align="center"><b>APPROVAL LIST</b></td>
							</tr>
						</table>
					</td>
					<td class="tdNoBorder" align="right"><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></td>
				</tr>
				<tr>
					<td colspan="2"></td>
				</tr>
				<tr>
					<td class="tdHeader1" align="center" colSpan="2">INVALID DATA</td>
				</tr>
				<tr>
					<td colSpan="2"><asp:datagrid id="DGR_INVALID_DATA" ShowFooter="True" Runat="server" AllowPaging="True" CellPadding="1"
							Width="100%" AutoGenerateColumns="False">
							<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
							<Columns>
								<asp:BoundColumn HeaderText="Posisi" DataField="TGL_DATA">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn HeaderText="ACC#" DataField="ACCTNO">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn HeaderText="CIF#" DataField="CIFNO">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn HeaderText="Customer Name" DataField="SNAME">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn HeaderText="Product" DataField="JNS_PRODUK">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn HeaderText="Type" DataField="ACTYPE">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn HeaderText="BUC" DataField="BUC">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Update Data">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:DropDownList Runat="server" ID="DDL_UPDATE_DATA_INVALID"></asp:DropDownList>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="ACCEPT">
									<HeaderStyle Width="50px" CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:RadioButton id="RDO_ACCEPT_INVALID_DATA" runat="server" GroupName="approval_status"></asp:RadioButton>
									</ItemTemplate>
									<FooterTemplate>
										<asp:LinkButton id="LNK_ACCEPT_INVALID_DATA" runat="server" CommandName="allAccept">Select All</asp:LinkButton>
									</FooterTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="PENDING">
									<HeaderStyle Width="50px" CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:RadioButton id="RDO_PENDING_INVALID_DATA" runat="server" GroupName="approval_status" Checked="True"></asp:RadioButton>
									</ItemTemplate>
									<FooterTemplate>
										<asp:LinkButton id="LNK_PENDING_INVALID_DATA" runat="server" CommandName="allPend">Select All</asp:LinkButton>
									</FooterTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="REJECT">
									<HeaderStyle Width="50px" CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:RadioButton id="RDO_REJECT_INVALID_DATA" runat="server" GroupName="approval_status"></asp:RadioButton>
									</ItemTemplate>
									<FooterTemplate>
										<asp:LinkButton id="LNK_REJECT_INVALID_DATA" runat="server" CommandName="allReject">Select All</asp:LinkButton>
									</FooterTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid></td>
				</tr>
				<tr align="center">
					<td class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2"><asp:button id="BTN_SUBMIT_INVALID_DATA" runat="server" Width="76px" Text="SUBMIT" CssClass="Button1" onclick="BTN_SUBMIT_INVALID_DATA_Click"></asp:button><asp:button id="BTN_UPDATE_INVALID_DATA" runat="server" Width="121px" Text="UPDATE STATUS" CssClass="Button1" onclick="BTN_UPDATE_INVALID_DATA_Click"></asp:button></td>
				</tr>
				<tr>
					<td class="tdHeader1" align="center" colSpan="2">CHECKING DATA</td>
				</tr>
				<tr>
					<td colSpan="2"><asp:datagrid id="DGR_CHECKING_DATA" ShowFooter="True" Runat="server" AllowPaging="True" CellPadding="1"
							Width="100%" AutoGenerateColumns="False">
							<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
							<Columns>
								<asp:BoundColumn HeaderText="Posisi" DataField="TGL_DATA">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn HeaderText="ACC#" DataField="ACCTNO">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn HeaderText="CIF#" DataField="CIFNO">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn HeaderText="Customer Name" DataField="SNAME">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn HeaderText="Product" DataField="JNS_PRODUK">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn HeaderText="Type" DataField="ACTYPE">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn HeaderText="BUC" DataField="BUC">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Update Data">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:DropDownList Runat="server" ID="DDL_UPDATE_DATA_CHECK"></asp:DropDownList>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="ACCEPT">
									<HeaderStyle Width="50px" CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:RadioButton id="RDO_ACCEPT_CHECK_DATA" runat="server" GroupName="approval_status"></asp:RadioButton>
									</ItemTemplate>
									<FooterTemplate>
										<asp:LinkButton id="LNK_ACCEPT_CHECK_DATA" runat="server" CommandName="allAccept">Select All</asp:LinkButton>
									</FooterTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="PENDING">
									<HeaderStyle Width="50px" CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:RadioButton id="RDO_PENDING_CHECK_DATA" runat="server" GroupName="approval_status" Checked="True"></asp:RadioButton>
									</ItemTemplate>
									<FooterTemplate>
										<asp:LinkButton id="LNK_PENDING_CHECK_DATA" runat="server" CommandName="allPend">Select All</asp:LinkButton>
									</FooterTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="REJECT">
									<HeaderStyle Width="50px" CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:RadioButton id="RDO_REJECT_CHECK_DATA" runat="server" GroupName="approval_status"></asp:RadioButton>
									</ItemTemplate>
									<FooterTemplate>
										<asp:LinkButton id="LNK_REJECT_CHECK_DATA" runat="server" CommandName="allReject">Select All</asp:LinkButton>
									</FooterTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid></td>
				</tr>
				<tr align="center">
					<td class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2"><asp:button id="BTN_SUBMIT_CHECK_DATA" runat="server" Width="76px" Text="SUBMIT" CssClass="Button1" onclick="BTN_SUBMIT_CHECK_DATA_Click"></asp:button><asp:button id="BTN_UPDATE_CHECK_DATA" runat="server" Width="121px" Text="UPDATE STATUS" CssClass="Button1" onclick="BTN_UPDATE_CHECK_DATA_Click"></asp:button></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
