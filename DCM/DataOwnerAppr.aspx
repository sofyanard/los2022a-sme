<%@ Page language="c#" Codebehind="DataOwnerAppr.aspx.cs" AutoEventWireup="True" Inherits="SME.DCM.DataOwnerAppr" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DataOwnerAppr</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../Style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0">
				<tr>
					<td align="left" style="WIDTH: 686px">
						<table>
							<tr>
								<td class="tdBGColor2" style="WIDTH: 400px" align="center"><b>APPROVAL&nbsp;LIST</b></td>
							</tr>
						</table>
					</td>
					<td class="tdNoBorder" align="right"><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></td>
				</tr>
				<tr>
					<td align="center" colspan="2" class="tdHeader1">INVALID DATA</td>
				</tr>
				<tr>
					<td align="left" style="WIDTH: 686px">
						<table style="WIDTH: 72.25%; HEIGHT: 56px">
							<tr>
								<td class="TDBGColor1" style="WIDTH: 160px; HEIGHT: 11px">Unit</td>
								<td width="10" style="HEIGHT: 11px">:</td>
								<td class="TDBGColorValue" style="WIDTH: 160px; HEIGHT: 11px"><asp:DropDownList Runat="server" ID="DDL_UNIT"></asp:DropDownList></td>
								<td vAlign="top" align="left" width="100%" colSpan="3" style="HEIGHT: 11px"><asp:button id="BTN_FIND" runat="server" Text="FIND" CssClass="Button1"></asp:button></td>
							</tr>
							<tr>
								<td class="TDBGColor1" style="WIDTH: 160px">Officer</td>
								<td width="10">:</td>
								<td class="TDBGColorValue" style="WIDTH: 349px"><asp:DropDownList Runat="server" ID="DDL_OFFICER"></asp:DropDownList></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td colspan="2">
						<asp:DataGrid Runat="server" AllowPaging="True" ID="DGR_INVALID_DATA" CellPadding="1" Width="100%"
							AutoGenerateColumns="False" ShowFooter="True">
							<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
							<Columns>
								<asp:BoundColumn HeaderText="Position Date" DataField="">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn HeaderText="CIF#" DataField="">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn HeaderText="Customer Name" DataField="">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn HeaderText="Unit Code" DataField="">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn HeaderText="Officer" DataField="">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="ACCEPT">
									<HeaderStyle Width="50px" CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:RadioButton id="RDO_ACCEPT" runat="server" GroupName="approval_status"></asp:RadioButton>
									</ItemTemplate>
									<FooterTemplate>
										<asp:LinkButton id="LNK_ACCEPT" runat="server" CommandName="allAccept">Select All</asp:LinkButton>
									</FooterTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="PENDING">
									<HeaderStyle Width="50px" CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:RadioButton id="RDO_PENDING" runat="server" GroupName="approval_status" Checked="True"></asp:RadioButton>
									</ItemTemplate>
									<FooterTemplate>
										<asp:LinkButton id="LNK_PENDING" runat="server" CommandName="allPend">Select All</asp:LinkButton>
									</FooterTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="REJECT">
									<HeaderStyle Width="50px" CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:RadioButton id="RDO_REJECT" runat="server" GroupName="approval_status"></asp:RadioButton>
									</ItemTemplate>
									<FooterTemplate>
										<asp:LinkButton id="LNK_REJECT" runat="server" CommandName="allReject">Select All</asp:LinkButton>
									</FooterTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:DataGrid>
					</td>
				</tr>
				<tr align="center">
					<td class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2"><asp:button id="BTN_SUBMIT" runat="server" Width="76px" CssClass="Button1" Text="SUBMIT"></asp:button><asp:button id="BTN_UPDATE" runat="server" Width="121px" CssClass="Button1" Text="UPDATE STATUS"></asp:button></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
