<%@ Page language="c#" Codebehind="BUCDanaInput.aspx.cs" AutoEventWireup="True" Inherits="SME.DCM.BUCDanaInput" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>BUCDanaInput</title>
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
								<td class="tdBGColor2" style="WIDTH: 400px" align="center"><b>BUC&nbsp;DANA DATA</b></td>
							</tr>
						</table>
					</td>
					<td class="tdNoBorder" align="right"><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></td>
				</tr>
				<tr>
					<td colSpan="2"></td>
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
								<td class="TDBGColorValue" style="HEIGHT: 10px"><asp:dropdownlist id="DDL_BUC_INVALID_DATA" CssClass="mandatory" Runat="server"></asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="TDBGColor1" style="WIDTH: 160px">Customer Name</td>
								<td width="10"></td>
								<td class="TDBGColorValue" style="HEIGHT: 10px"><asp:textbox id="TXT_CUST_NAME_INVALID_DATA" Runat="server" Width="320px"></asp:textbox></td>
							</tr>
							<tr>
								<td vAlign="top" align="center" width="100%" colSpan="3"><asp:button id="BTN_FIND_INVALID_DATA" runat="server" CssClass="Button1" Width="76px" Text="FIND" onclick="BTN_FIND_INVALID_DATA_Click"></asp:button></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr id="tgl" runat="server">
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
					<td colSpan="2"><asp:datagrid id="DGR_INVALID_DATA" Runat="server" Width="100%" AllowPaging="True" CellPadding="1"
							AutoGenerateColumns="False">
							<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
							<Columns>
								<asp:BoundColumn HeaderText="Position Date" DataField="TGL_DATA">
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
								<asp:TemplateColumn HeaderText="Update">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:Button Runat="server" ID="BTN_UPDATE" Text="Save" CssClass="Button1" CommandName="btn_save"></asp:Button>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Status">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:LinkButton Runat="server" ID="LNK_UPDATE_STATUS_DATA_INVALID" Text="Update Status" CausesValidation="False"
											CommandName="update"></asp:LinkButton>
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
								<td class="TDBGColor1" style="WIDTH: 160px">BUC</td>
								<td width="10">:</td>
								<td class="TDBGColorValue" style="HEIGHT: 10px"><asp:dropdownlist id="DDL_BUC_CHECK_DATA" CssClass="mandatory" Runat="server"></asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="TDBGColor1" style="WIDTH: 160px">Customer Name</td>
								<td width="10"></td>
								<td class="TDBGColorValue" style="HEIGHT: 10px"><asp:textbox id="DDL_CUST_NAME_CHECK_DATA" Runat="server" Width="320px"></asp:textbox></td>
							</tr>
							<tr>
								<td vAlign="top" align="center" width="100%" colSpan="3"><asp:button id="BTN_FIND_CHECK_DATA" runat="server" CssClass="Button1" Width="76px" Text="FIND" onclick="BTN_FIND_CHECK_DATA_Click"></asp:button></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr id="tgl2" runat="server">
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
					<td colSpan="2"><asp:datagrid id="DGR_CHECKING_DATA" Runat="server" Width="100%" AllowPaging="True" CellPadding="1"
							AutoGenerateColumns="False">
							<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
							<Columns>
								<asp:BoundColumn HeaderText="Position Date" DataField="TGL_DATA">
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
										<asp:DropDownList Runat="server" ID="DDL_UPDATE_DATA_CHECKING"></asp:DropDownList>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Update">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:Button Runat="server" ID="BTN_SAVE_DATA_CHECK" Text="Save" CssClass="Button1" CommandName="btn_save"></asp:Button>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Status">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:LinkButton Runat="server" ID="LNK_UPDATE_STATUS_DATA_CHECK" Text="Update Status" CausesValidation="False"
											CommandName="update"></asp:LinkButton>
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
