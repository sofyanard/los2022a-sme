<%@ Page language="c#" Codebehind="Pledging.aspx.cs" AutoEventWireup="True" Inherits="SME.ComplyReview.Channeling.Condition.Pledging" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ListInitiation</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="fSppkMonitor" method="post" runat="server">
			<center>
				<table id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder" style="WIDTH: 1022px"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
							<TABLE id="Table6">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Biaya &amp; PK</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="../../../Image/back.jpg"></asp:imagebutton><A href="../../../Body.aspx"><IMG src="../../../Image/MainMenu.jpg"></A>
							<A href="../../../Logout.aspx" target="_top"><IMG src="../../../Image/Logout.jpg"></A>
						</TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="SubMenu" runat="server"></asp:placeholder></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">
							Customer&nbsp;Data</TD>
					</TR>
					<tr>
						<td style="HEIGHT: 28px" colSpan="2">
							<table>
								<tr>
									<td class="TDBGColor1" style="WIDTH: 154px"><STRONG> No PK #</STRONG></td>
									<td style="WIDTH: 5px"><STRONG>:</STRONG></td>
									<td><asp:textbox onkeypress="return kutip_satu()" id="txt_regno" runat="server" MaxLength="20" Columns="30"
											Width="176px"></asp:textbox></td>
									<td style="WIDTH: 5px"></td>
									<td><asp:button id="btn_cari" runat="server" Width="56px" Text="Find"></asp:button></td>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 50%" colSpan="2"><asp:datagrid id="dgListChan" runat="server" Width="100%" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="CU_NAME" HeaderText="Application #" ItemStyle-Width="15%">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CU_LIMIT" HeaderText="End User Name">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="No PK" ItemStyle-Width="15%">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemTemplate>
											<asp:TextBox Width="100%" Runat="server" ID="Textbox2" CssClass="mandatory"></asp:TextBox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Tanggal PK" ItemStyle-Width="20%">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemTemplate>
											<asp:TextBox Width="15%" Runat="server" ID="TXT_A" CssClass="mandatory"></asp:TextBox>
											<asp:DropDownList id="DDL_CANCEL" Runat="server" Width="50%" CssClass="mandatory"></asp:DropDownList>
											<asp:TextBox Width="30%" Runat="server" ID="Textbox1" CssClass="mandatory"></asp:TextBox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Provisi" ItemStyle-Width="20%">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemTemplate>
											<asp:TextBox Width="15%" Runat="server" ID="Textbox4" CssClass="mandatory"></asp:TextBox>%
											<asp:TextBox Width="70%" Runat="server" ID="Textbox5" CssClass="mandatory"></asp:TextBox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="PRODUCTID" HeaderText="Jenis Pengikatan" ItemStyle-Width="5%">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Administration" ItemStyle-Width="10%">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemTemplate>
											<asp:TextBox Width="100%" Runat="server" ID="Textbox3" CssClass="mandatory"></asp:TextBox>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</asp:datagrid>
						</td>
					</tr>
					<tr>
						<td width="1022" style="WIDTH: 1022px" colspan="2" align="center" class="TDBGColor2">
							<asp:button id="BTN_SAVE" runat="server" Width="141px" Text="HITUNG" CssClass="BUTTON1"></asp:button>
							<asp:button id="BTN_UPDATE_STATUS" runat="server" Width="146px" Text="SAVE" CssClass="Button1"
								Enabled="False"></asp:button>
						</td>
					</tr>
				</table>
			</center>
		</form>
	</body>
</HTML>
