<%@ Page language="c#" Codebehind="BUCCreditInput2.aspx.cs" AutoEventWireup="True" Inherits="SME.DCM.BUCCreditInput2" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>BUCCreditInput2</title>
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
								<td class="tdBGColor2" style="WIDTH: 400px" align="center"><b>BUC CREDIT DATA</b></td>
							</tr>
						</table>
					</td>
					<td class="tdNoBorder" align="right"><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></td>
				</tr>
				<tr>
					<td class="tdHeader1" align="center" colSpan="2">INVALID DATA</td>
				</tr>
				<tr>
					<td style="WIDTH: 686px" align="left">
						<table style="WIDTH: 63.97%">
							<tr>
								<td class="TDBGColor1" style="WIDTH: 160px">BUC</td>
								<td width="10">:</td>
								<td class="TDBGColorValue" style="HEIGHT: 10px"><asp:dropdownlist id="DDL_BUC_INVALID_DATA" Runat="server"></asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="TDBGColor1" style="WIDTH: 160px">Customer Name</td>
								<td width="10">:</td>
								<td class="TDBGColorValue" style="HEIGHT: 10px"><asp:textbox id="TXT_CUST_NAME_INVALID_DATA" Runat="server" Width="320px"></asp:textbox></td>
							</tr>
							<tr>
								<td vAlign="top" align="center" width="100%" colSpan="3"><asp:button id="BTN_FIND_INVALID_DATA" runat="server" Width="76px" Text="FIND" CssClass="Button1" onclick="BTN_FIND_INVALID_DATA_Click"></asp:button></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td style="WIDTH: 686px" align="left">
						<table style="WIDTH: 63.97%">
							<tr>
								<td class="TDBGColor1" style="WIDTH: 160px">Tanggal Data</td>
								<td width="10">:</td>
								<td class="TDBGColorValue" style="HEIGHT: 10px"><asp:textbox id="TXT_TGL_DATA_INVALID" Runat="server" Width="320px" ReadOnly="True"></asp:textbox></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td colSpan="2"><asp:datagrid id="DGR_INVALID_DATA" Runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="1"
							AllowPaging="True" ShowFooter="True">
							<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
							<Columns>
								<asp:BoundColumn Visible="False" HeaderText="Posisi">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CIFNO" HeaderText="CIF">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="SNAME" HeaderText="Customer Name">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="ACCTNO" HeaderText="ACC#">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="TYPE" HeaderText="Loan Type">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="BUC_EMAS" HeaderText="BUC">
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
								<asp:TemplateColumn HeaderText="Function">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:Button Runat="server" ID="BTN_SAVE_DATA_INVALID" Text="Save" CssClass="Button1" CommandName="btn_save_invalid"></asp:Button>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Status">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:LinkButton id="LNK_UPDATE_INVALID_DATA" runat="server" Text="Update Status" CausesValidation="false"
											CommandName="Update_Invalid"></asp:LinkButton>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid></td>
				</tr>
				<tr>
					<td class="tdHeader1" align="center" colSpan="2">CHECKING DATA</td>
				</tr>
				<tr>
					<td style="WIDTH: 686px" align="left">
						<table style="WIDTH: 63.97%">
							<tr>
								<td class="TDBGColor1" style="WIDTH: 160px; HEIGHT: 21px">BUC</td>
								<td style="HEIGHT: 21px" width="10">:</td>
								<td class="TDBGColorValue" style="HEIGHT: 21px"><asp:dropdownlist id="DDL_BUC_CHECKING_DATA" Runat="server"></asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="TDBGColor1" style="WIDTH: 160px">Customer Name</td>
								<td width="10">:</td>
								<td class="TDBGColorValue" style="HEIGHT: 10px"><asp:textbox id="TXT_CUST_NAME_CHECKING_DATA" Runat="server" Width="320px"></asp:textbox></td>
							</tr>
							<tr>
								<td vAlign="top" align="center" width="100%" colSpan="3"><asp:button id="BTN_FIND_CHECKING_DATA" runat="server" Width="76px" Text="FIND" CssClass="Button1" onclick="BTN_FIND_CHECKING_DATA_Click"></asp:button></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td style="WIDTH: 686px" align="left">
						<table style="WIDTH: 63.97%">
							<tr>
								<td class="TDBGColor1" style="WIDTH: 160px">Tanggal Data</td>
								<td width="10">:</td>
								<td class="TDBGColorValue" style="HEIGHT: 10px"><asp:textbox id="TXT_TGL_DATA_CHECKING" Runat="server" Width="320px" ReadOnly="True"></asp:textbox></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td colSpan="2"><asp:datagrid id="DGR_CHECKING_DATA" Runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="1"
							AllowPaging="True" ShowFooter="True">
							<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
							<Columns>
								<asp:BoundColumn Visible="False" HeaderText="Posisi">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CIFNO" HeaderText="CIF">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="SNAME" HeaderText="Customer Name">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="ACCTNO" HeaderText="ACC#">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="TYPE" HeaderText="Loan Type">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="BUC_EMAS" HeaderText="BUC">
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
								<asp:TemplateColumn HeaderText="Function">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:Button Runat="server" ID="BTN_SAVE_DATA_CHECKING" Text="Save" CssClass="Button1" CommandName="btn_save_checking"></asp:Button>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Status">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:LinkButton id="LNK_UPDATE_CHECKING_DATA" runat="server" Text="Update Status" CausesValidation="false"
											CommandName="Update_Checking"></asp:LinkButton>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
