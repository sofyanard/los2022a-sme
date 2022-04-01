<%@ Page language="c#" Codebehind="ListChoosen.aspx.cs" AutoEventWireup="True" Inherits="SME.IDI_BI.ListChoosen" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ListChoosen</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<LINK href="../Style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<TABLE height="1214" cellSpacing="0" cellPadding="0" width="476" border="0" ms_2d_layout="TRUE">
			<TR vAlign="top">
				<TD width="476" height="1214">
					<form id="Form1" method="post" runat="server">
						<TABLE height="474" cellSpacing="0" cellPadding="0" width="1212" border="0" ms_2d_layout="TRUE">
							<TR vAlign="top">
								<TD width="1212" height="474">
									<CENTER>
										<table width="100%" border="0">
											<tr>
												<td align="left">
													<TABLE id="Table31">
														<TR>
															<TD class="tdBGColor2" align="center" width="400"><B>LIST REQUEST</B></TD>
														</TR>
													</TABLE>
												</td>
												<TD class="tdNoBorder" align="right"><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
											</tr>
											<tr>
												<td></td>
											</tr>
											<TR>
												<TD class="tdHeader1" colSpan="2">RESULT</TD>
											</TR>
											<TR>
												<TD colSpan="2"><ASP:DATAGRID id="DGR_RESULT" runat="server" Width="100%" AllowPaging="True" CellPadding="1" AutoGenerateColumns="False">
														<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
														<Columns>
															<asp:BoundColumn DataField="IDI_CUSTNAME" HeaderText="Nama">
																<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="IDI_NPWP#" HeaderText="NPWP">
																<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="IDI_KTP#" HeaderText="No.KTP/APP">
																<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="IDI_ADDRESS" HeaderText="Alamat">
																<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
															</asp:BoundColumn>
															<asp:TemplateColumn HeaderText="Approve">
																<HeaderStyle CssClass="tdSmallHeader" Width="7%"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
																<ItemTemplate>
																	<asp:CheckBox Runat="server" ID="check" Enabled="False"></asp:CheckBox>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="Block Data">
																<HeaderStyle CssClass="tdSmallHeader" Width="15%"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
																<ItemTemplate>
																	<asp:Button Text="Block" Runat="server" ID="BTN_BLOCK" CssClass="button1" CommandName="block"
																		Visible="False"></asp:Button>
																	<asp:Button Text="Unblock" Runat="server" ID="BTN_UNBLOCK" CssClass="button1" CommandName="unblock"></asp:Button>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:BoundColumn DataField="idi_req#" HeaderText="idi_req#" Visible="False">
																<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="idi_surat_seq#" HeaderText="idi_surat_seq#" Visible="False">
																<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
															</asp:BoundColumn>
														</Columns>
														<PagerStyle Mode="NumericPages"></PagerStyle>
													</ASP:DATAGRID></TD>
											</TR>
											<TR>
												<TD class="TDBGColor2" id="TR_B" vAlign="top" align="center" width="50%" colSpan="2"></TD>
											</TR>
										</table>
									</CENTER>
								</TD>
							</TR>
						</TABLE>
					</form>
				</TD>
			</TR>
		</TABLE>
	</body>
</HTML>
