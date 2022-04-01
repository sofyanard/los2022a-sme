<%@ Page language="c#" Codebehind="ListComplyReview.aspx.cs" AutoEventWireup="True" Inherits="SME.Assignment.Channeling.ListComplyReview" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ListInitiation</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_all.html" -->
		<!-- aaa -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="fSppkMonitor" method="post" runat="server">
			<center>
				<table id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder" style="WIDTH: 805px"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
							<TABLE id="Table6">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Approval List</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="../../Image/back.jpg"></asp:imagebutton><A href="../Body.aspx"><IMG src="../../Image/MainMenu.jpg"></A>
							<A href="../../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A>
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
									<td class="TDBGColor1" style="WIDTH: 154px"><STRONG>Application #</STRONG></td>
									<td style="WIDTH: 5px"><STRONG>:</STRONG></td>
									<td><asp:textbox onkeypress="return kutip_satu()" id="txt_regno" runat="server" MaxLength="20" Columns="30"
											Width="176px"></asp:textbox></td>
									<td style="WIDTH: 5px"></td>
									<td><asp:button id="btn_cari" runat="server" Width="56px" Text="Find" onclick="btn_cari_Click"></asp:button></td>
								</tr>
							</table>
							<asp:label id="LBL_COUNT_APP" runat="server" Font-Bold="True"></asp:label></td>
					</tr>
					<tr>
						<td style="WIDTH: 50%" colSpan="2"><asp:datagrid id="dgListChan" runat="server" Width="100%" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="CU_REF" HeaderText="Ref #">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CU_NAME" HeaderText="Application #">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CU_LIMIT" HeaderText="Plafond Owner">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PENDING_LIMIT" HeaderText="Limit Permohonan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AA_NO" HeaderText="Application Date">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PRODUCTID" HeaderText="RM">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn>
										<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="LinkButton1" runat="server" CommandName="Continue">Continue</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</asp:datagrid>
						</td>
					</tr>
				</table>
			</center>
		</form>
	</body>
</HTML>
