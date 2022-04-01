<%@ Page language="c#" Codebehind="CancelApprove.aspx.cs" AutoEventWireup="True" Inherits="SME.Approval.CancelApprove" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CancelApprove</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_all.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="fCanAprv" method="post" runat="server">
			<center>
				<table id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<tr>
						<td class="tdNoBorder"><!--<img src="../Image/HeaderDetailDataEntry.jpg">--></td>
						<td class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></td>
					</tr>
					<tr>
						<td style="HEIGHT: 28px" colSpan="2">
							<asp:label id="lbl_groupid" runat="server" Visible="False"></asp:label>
							<asp:label id="lbl_userid" runat="server" Visible="False"></asp:label>
							<asp:label id="lbl_track" runat="server" Visible="False"></asp:label>
							<asp:label id="lbl_dari" runat="server" Visible="False"></asp:label>
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 50%" colSpan="2">
							<asp:datagrid id="dgCancelAss" runat="server" AutoGenerateColumns="False" Width="100%">
								<Columns>
									<asp:BoundColumn DataField="AP_REGNO" HeaderText="Application No.">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="CU_REF" HeaderText="Ref #">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CU_NAME" HeaderText="Nama Pemohon">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AP_SIGNDATE" HeaderText="Tgl. Aplikasi">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Status">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:CheckBox id="CheckBox1" runat="server"></asp:CheckBox>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</asp:datagrid>
						</td>
					</tr>
				</table>
				<table id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
					<tr>
						<td></td>
						<td></td>
						<td align="right" colSpan="1">
							<asp:Button id="btn_cancel" runat="server" Text="Cancel" Width="115" onclick="btn_cancel_Click"></asp:Button>
						</td>
					</tr>
				</table>
			</center>
		</form>
	</body>
</HTML>
