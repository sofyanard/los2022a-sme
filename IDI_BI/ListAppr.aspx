<%@ Page language="c#" Codebehind="ListAppr.aspx.cs" AutoEventWireup="True" Inherits="SME.IDI_BI.ListAppr" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ListAppr</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<LINK href="../Style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<TABLE height="1214" cellSpacing="0" cellPadding="0" width="298" border="0" ms_2d_layout="TRUE">
			<TR vAlign="top">
				<TD width="298" height="1214">
					<form id="Form1" method="post" runat="server">
						<TABLE height="296" cellSpacing="0" cellPadding="0" width="1212" border="0" ms_2d_layout="TRUE">
							<TR vAlign="top">
								<TD width="1212" height="296">
									<CENTER>
										<table width="100%" border="0">
											<tr>
												<td align="left">
													<TABLE id="Table31">
														<TR>
															<TD class="tdBGColor2" align="center" width="400"><B>LIST APPROVAL</B></TD>
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
												<TD colSpan="2"><ASP:DATAGRID id="DGR_RESULT" runat="server" Width="100%" CellPadding="1" AutoGenerateColumns="False">
														<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
														<Columns>
															<asp:BoundColumn Visible="False" DataField="idi_surat_seq#">
																<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="IDI_SURAT#" HeaderText="No. Surat">
																<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="IDI_REQDATE" HeaderText="Request Date">
																<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="IDI_REQ#" HeaderText="IDI BI Request #">
																<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="IDI_CUSTNAME" HeaderText="Nama Debitur">
																<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="IDI_NPWP#" HeaderText="NPWP">
																<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="IDI_KTP#" HeaderText="No.KTP/APP">
																<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="IDI_BOD_DATE" HeaderText="Tgl.Lahir/Pendirian">
																<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="IDI_ADDRESS" HeaderText="Alamat">
																<HeaderStyle Width="10%" CssClass="tdSmallHeader"></HeaderStyle>
															</asp:BoundColumn>
															<asp:TemplateColumn HeaderText="Check for Choose">
																<HeaderStyle Width="7%" CssClass="tdSmallHeader"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
																<ItemTemplate>
																	<asp:CheckBox Runat="server" ID="check"></asp:CheckBox>
																</ItemTemplate>
															</asp:TemplateColumn>
														</Columns>
														<PagerStyle Mode="NumericPages"></PagerStyle>
													</ASP:DATAGRID></TD>
											</TR>
											<TR>
												<TD class="TDBGColor2" id="TR_B" vAlign="top" align="center" width="50%" colSpan="2"><asp:button id="BTN_SAVE" runat="server" Width="75px" Text="SAVE" CssClass="button1" onclick="BTN_SAVE_Click"></asp:button>&nbsp;
													<asp:button id="BTN_CLEAR" runat="server" Width="85px" Text="CLEAR" CssClass="button1" onclick="BTN_CLEAR_Click"></asp:button>&nbsp;<asp:button id="BTN_APPROVE" runat="server" Width="114px" Text="APPROVE" CssClass="button1" onclick="BTN_APPROVE_Click"></asp:button></TD>
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
