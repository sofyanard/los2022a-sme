<%@ Page language="c#" Codebehind="ListApproval.aspx.cs" AutoEventWireup="True" Inherits="SME.Approval.ListApproval" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ListApproval</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_all.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="fListApp" method="post" runat="server">
			<center>
				<table id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder"><!--<img src="../Image/HeaderDetailDataEntry.jpg">--></TD>
						<TD class="tdNoBorder" align="right"><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</TR>
					<!--<tr>
					asdfasdfs
						<td align="center" colSpan="2"><asp:placeholder id="placeholder1" runat="server"></asp:placeholder></td>
					</tr>-->
					<tr>
						<td style="HEIGHT: 28px" colSpan="2">
							<table>
								<tr>
									<td class="TDBGColor1" style="WIDTH: 110px">Application #</td>
									<td style="WIDTH: 5px"></td>
									<td><asp:textbox id="txt_regno" runat="server" Width="176px" Columns="30" MaxLength="20" onkeypress="return kutip_satu()"></asp:textbox></td>
									<td style="WIDTH: 5px"></td>
									<td>
										<asp:button id="btn_cari" runat="server" Text="Cari" onclick="btn_cari_Click"></asp:button>
										<asp:label id="lbl_prod" runat="server" Width="176px" Columns="30" MaxLength="20" Visible="False"></asp:label>
										<asp:label id="lbl_apptype" runat="server" Width="176px" Columns="30" MaxLength="20" Visible="False"></asp:label>
										<asp:label id="lbl_track" runat="server" Width="176px" Columns="30" MaxLength="20" Visible="False"></asp:label>
										<asp:label id="lbl_userid" runat="server" Visible="False"></asp:label>
									</td>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 50%" colSpan="2"><asp:datagrid id="dgListApproval" runat="server" AutoGenerateColumns="False" Width="100%">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
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
									<asp:BoundColumn DataField="AP_SIGNDATE" HeaderText="Tgl. Aplikasi" DataFormatString="{0:dd-MMM-yyyy}">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CP_LIMIT" HeaderText="Limit" DataFormatString="{0:00.00,00}" Visible="False">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AP_ISAPPEAL" HeaderText="Banding">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AP_ISAPPEALDATE" HeaderText="Tanggal Banding" DataFormatString="{0:dd-MMM-yyyy}">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AP_ISAPPEALBY" HeaderText="Banding Oleh">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn>
										<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="LinkButton1" runat="server" CommandName="view">Lihat</asp:LinkButton>
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
