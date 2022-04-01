<%@ Page language="c#" Codebehind="Memo.aspx.cs" AutoEventWireup="True" Inherits="SME.DisbursementWorksheet.MemoDE" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Memo</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
					<FORM id="Form1" method="post" runat="server">
									<center>
										<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
											<TR>
												<TD class="tdBGColor2" align="center" width="400"><B> Memo</B></TD>
												<TD class="tdNoBorder" align="right" height="29"><A href="ListCustomer.aspx?si="></A>
													<asp:ImageButton id="BTN_BACK" runat="server" ImageUrl="../../Image/back.jpg" onclick="BTN_BACK_Click"></asp:ImageButton><A href="../../Body.aspx"><IMG src="../../Image/MainMenu.jpg"></A><A href="../../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A></TD>
											</TR>
											<TR>
												<TD class="tdNoBorder" align="center" colSpan="2" height="41"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
											</TR>
											<TR>
												<TD class="tdHeader1" colSpan="2">Memo</TD>
											</TR>
											<TR>
												<td colSpan="2"></td>
											</TR>
											<TR>
												<TD vAlign="top" colSpan="2"><asp:textbox id="TXT_TM_CONTENT" runat="server" Height="72px" Width="100%" TextMode="MultiLine"></asp:textbox></TD>
											</TR>
											<TR>
												<TD vAlign="top" align="center" colSpan="2"><asp:button id="BTN_SAVE" runat="server" Text="Save" Visible="False" onclick="BTN_SAVE_Click"></asp:button>
													<asp:TextBox id="TXT_REGNO" runat="server" Visible="False"></asp:TextBox>
													<asp:TextBox id="TXT_TMSEQ" runat="server" Visible="False"></asp:TextBox></TD>
											</TR>
											<TR>
												<TD vAlign="top" colSpan="2">
													<table id="Table5" cellSpacing="0" cellPadding="0" width="100%">
														<tr>
															<td><ASP:DATAGRID id="DatGrd" runat="server" Height="80px" Width="100%" HorizontalAlign="Center" AllowPaging="True"
																	CssClass="TDBGColorValue" AutoGenerateColumns="False" CellPadding="1" BorderColor="Silver"
																	BorderWidth="1px">
																	<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
																	<Columns>
																		<asp:BoundColumn Visible="False" DataField="AP_REGNO"></asp:BoundColumn>
																		<asp:BoundColumn DataField="TM_SEQ" HeaderText="No.">
																			<HeaderStyle Width="5%" CssClass="tdSmallHeader"></HeaderStyle>
																			<ItemStyle HorizontalAlign="Center" Width="120px"></ItemStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="TM_DATE" HeaderText="Date">
																			<HeaderStyle Width="10%" CssClass="tdSmallHeader"></HeaderStyle>
																			<ItemStyle HorizontalAlign="Center"></ItemStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="TM_COntent" HeaderText="Description">
																			<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="SU_FUllname" HeaderText="By">
																			<HeaderStyle Width="15%" CssClass="tdSmallHeader"></HeaderStyle>
																			<ItemStyle HorizontalAlign="Center" Width="120px"></ItemStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="sg_grpname" HeaderText="Group">
																			<HeaderStyle Width="15%" CssClass="tdSmallHeader"></HeaderStyle>
																			<ItemStyle HorizontalAlign="Center" Width="120px"></ItemStyle>
																		</asp:BoundColumn>
																		<asp:TemplateColumn Visible="False" HeaderText="Function">
																			<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
																			<ItemTemplate>
																				<asp:LinkButton id="LINK_EDIT" runat="server" CommandName="Edit">Edit</asp:LinkButton>&nbsp;
																				<asp:LinkButton id="LINK_DELETE" runat="server" CommandName="Delete">Delete</asp:LinkButton>
																			</ItemTemplate>
																		</asp:TemplateColumn>
																		<asp:BoundColumn Visible="False" DataField="TM_USERID" HeaderText="TM_USERID">
																			<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
																			<ItemStyle HorizontalAlign="Center" Width="120px"></ItemStyle>
																		</asp:BoundColumn>
																	</Columns>
																	<PagerStyle Mode="NumericPages"></PagerStyle>
																</ASP:DATAGRID></td>
														</tr>
													</table>
												</TD>
											</TR>
										</TABLE>
									</center>
					</FORM>
	</body>
</HTML>
