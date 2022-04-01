<%@ Page language="c#" Codebehind="CollateralAssignData.aspx.cs" AutoEventWireup="True" Inherits="SME.DCM.CollateralAssignData" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CollateralAssignData</title>
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
					<td align="left">
						<TABLE id="Table31">
							<TR>
								<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>COLLATERAL DATA 
										CORRECTION</B></TD>
							</TR>
						</TABLE>
					</td>
					<TD class="tdNoBorder" align="right"><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
				</tr>
				<TR>
					<TD class="tdHeader1" colSpan="2">Collateral Assignment</TD>
				</TR>
				<TR>
					<TD class="td" vAlign="top" width="100%" colSpan="2">
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TBODY>
								<TR>
									<td vAlign="top" width="25%">
										<table cellSpacing="2" cellPadding="2" width="100%">
											<tr>
												<td><ASP:DATAGRID id="DatGrd" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False"
														CellPadding="1">
														<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
														<Columns>
															<asp:BoundColumn DataField="ACC_NO" Visible="False"></asp:BoundColumn>
															<asp:BoundColumn DataField="COLL_ID" Visible="False"></asp:BoundColumn>
															<asp:BoundColumn DataField="COLL_DESC" Visible="False"></asp:BoundColumn>
															<asp:BoundColumn DataField="STATUS_FLAG" Visible="False"></asp:BoundColumn>
															<asp:BoundColumn DataField="STATUS_DESC" Visible="False"></asp:BoundColumn>
															<asp:BoundColumn DataField="STATUS_IMG" Visible="False"></asp:BoundColumn>
															<asp:BoundColumn DataField="LINK" Visible="False"></asp:BoundColumn>
															<asp:BoundColumn DataField="BTN_TEXT" Visible="False"></asp:BoundColumn>
															<asp:BoundColumn DataField="BTN_ENABLE" Visible="False"></asp:BoundColumn>
															<asp:BoundColumn DataField="CURR_OFCR" Visible="False"></asp:BoundColumn>
															<asp:BoundColumn DataField="DDL_ENABLE" Visible="False"></asp:BoundColumn>
															<asp:TemplateColumn HeaderText="Collateral">
																<HeaderStyle Width="50%" CssClass="tdSmallHeader"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
																<ItemTemplate>
																	<asp:HyperLink id="HL_COLID" runat="server"></asp:HyperLink>
																	<br>
																	<asp:Image id="IMG_STA" runat="server"></asp:Image>
																	<asp:Label id="LBL_STA" runat="server"></asp:Label>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="Assignment">
																<HeaderStyle Width="50%" CssClass="tdSmallHeader"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
																<ItemTemplate>
																	<asp:DropDownList id="DDL_OFCR" runat="server"></asp:DropDownList>
																	<br>
																	<asp:Button id="BTN_PROC" runat="server" Width="100px"></asp:Button>
																</ItemTemplate>
															</asp:TemplateColumn>
														</Columns>
														<PagerStyle Mode="NumericPages"></PagerStyle>
													</ASP:DATAGRID></td>
											</tr>
										</table>
									</td>
									<td width="75%"><iframe id="coldetail" name="coldetail" frameBorder="0" width="100%" scrolling="auto" height="700"></iframe>
									</td>
								</TR>
							</TBODY>
						</table>
					</TD>
				</TR>
			</table>
		</form>
	</body>
</HTML>
