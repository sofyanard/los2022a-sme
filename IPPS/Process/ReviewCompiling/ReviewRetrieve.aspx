<%@ Page language="c#" Codebehind="ReviewRetrieve.aspx.cs" AutoEventWireup="false" Inherits="SME.IPPS.Process.ReviewCompiling.ReviewRetrieve" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ReviewRetrieve</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../Style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TBODY>
						<TR>
							<TD class="tdNoBorder" style="WIDTH: 482px">
								<TABLE id="Table8">
									<TR>
										<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Review Retrieve</B></TD>
									</TR>
								</TABLE>
							</TD>
							<td align="right"><A href="/SME/Body.aspx"><IMG src="/SME/Image/MainMenu.jpg"></A><A href="/SME/Logout.aspx" target="_top"><IMG src="/SME/Image/Logout.jpg"></A></td>
						</TR>
						<tr>
							<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
						</tr>
						<TR>
							<TD class="tdHeader1" colSpan="2">GENERAL INFO</TD>
						</TR>
						<TR>
							<TD class="td" style="WIDTH: 483px" vAlign="top" width="483"><TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 129px">Unit:</TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_unit" runat="server" BorderStyle="None" ReadOnly="True" Width="300px"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Reference#:</TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_reference" runat="server" BorderStyle="None" ReadOnly="True" Width="300px"></asp:textbox></TD>
									</TR>
								</TABLE>
							</TD>
							<TD class="td" vAlign="top" width="50%">
								<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 129px">Request Date:</TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_request_date" runat="server" ReadOnly="True" Width="320px"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 129px"></TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD class="tdHeader1" colSpan="2">Retrieved</TD>
						</TR>
						<TR>
							<TD class="TDBGColor1">Pilih Request:
							</TD>
							<TD class="TDBGColorValue"><asp:dropdownlist id="ddl_request" runat="server"></asp:dropdownlist></TD>
						</TR>
						<tr>
							<td colSpan="2">
								<table style="WIDTH: 888px; HEIGHT: 152px">
									<tr>
										<td class="td" id="GRIDRETRIEVED" style="WIDTH: 759px" vAlign="top" width="759"><ASP:DATAGRID id="dg_list_retrieved" runat="server" Width="760px" AutoGenerateColumns="False">
												<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
												<Columns>
													<asp:BoundColumn Visible="False" DataField="req_seq" HeaderText="reqseq"></asp:BoundColumn>
													<asp:BoundColumn DataField="rev_seq" HeaderText="No.">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="unit" HeaderText="Unit Name">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="assign_tounit_date" HeaderText="Submit Date">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="approve_date" HeaderText="Received Date">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
													</asp:BoundColumn>
													<asp:TemplateColumn HeaderText="Function">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
														<ItemTemplate>
															<asp:LinkButton id="view" runat="server" CommandName="view">View Detail</asp:LinkButton>&nbsp;
														</ItemTemplate>
													</asp:TemplateColumn>
												</Columns>
											</ASP:DATAGRID></td>
										<td align="center"><asp:button id="BTN_RETRIEVE" runat="server" CssClass="Button1" Text="Retrieve"></asp:button></td>
									</tr>
								</table>
							</td>
						</tr>
						<tr class="tdBGColor2" align="center">
							<td vAlign="top" align="center" colSpan="2"><asp:button id="BTN_SUBMIT" runat="server" CssClass="Button1" Text="Submit to WG" Visible="False"></asp:button></td>
						</tr>
					</TBODY>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
