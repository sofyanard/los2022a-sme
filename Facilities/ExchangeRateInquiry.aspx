<%@ Page language="c#" Codebehind="ExchangeRateInquiry.aspx.cs" AutoEventWireup="True" Inherits="SME.Facilities.ExchangeRateInquiry" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>FindCustomer</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_entries.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table4" width="100%" border="0">
					<TR>
						<TD align="left" colSpan="1">
							<TABLE id="Table3">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Exchange Rate Inquiry</B></TD>
								</TR>
							</TABLE>
						</TD>
						<td align="right"><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></td>
					</TR>
					<TR>
						<TD align="center" colSpan="2">
							<TABLE class="td" id="Table1" style="WIDTH: 590px; HEIGHT: 152px" cellSpacing="1" cellPadding="1"
								width="590" border="1">
								<TR>
									<TD class="tdHeader1">Search Criteria</TD>
								</TR>
								<TR>
									<TD vAlign="top">
										<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD class="TDBGColor1">Currency Code</TD>
												<TD width="17"></TD>
												<TD class="TDBGColorValue" style="WIDTH: 342px" width="342"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CURRENCYID" runat="server" Width="200px"
														MaxLength="50"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Currency Description</TD>
												<TD></TD>
												<TD class="TDBGColorValue" style="WIDTH: 342px"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CURRENCYDESC" runat="server" Width="200px"
														MaxLength="20"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 18px">Currency Rate</TD>
												<TD style="HEIGHT: 18px"></TD>
												<TD style="WIDTH: 342px; HEIGHT: 18px"><asp:textbox onkeypress="return digitsonly()" id="TXT_BOTTOMRATE" runat="server" Width="112px"
														MaxLength="25"></asp:textbox>&nbsp;&nbsp;&nbsp; s/d&nbsp; &nbsp;&nbsp;
													<asp:textbox onkeypress="return digitsonly()" id="TXT_TOPRATE" runat="server" Width="112px" MaxLength="25"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 27px" vAlign="middle">Condition</TD>
												<TD style="HEIGHT: 27px" vAlign="middle"></TD>
												<TD class="TDBGColorValue" style="WIDTH: 342px; HEIGHT: 27px" vAlign="top"><asp:radiobuttonlist id="RDB_COND" runat="server" Width="256px" CellPadding="0" Height="11px" CellSpacing="0"
														RepeatDirection="Horizontal">
														<asp:ListItem Value="and">And</asp:ListItem>
														<asp:ListItem Value="or" Selected="True">Or</asp:ListItem>
													</asp:radiobuttonlist></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 521px" vAlign="top" align="center" colSpan="3"><BR>
													<asp:button id="BTN_FIND" runat="server" Width="75px" CssClass="button1" Text="Find" onclick="BTN_FIND_Click"></asp:button></TD>
											</TR>
										</TABLE>
										<BR>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD align="center" colSpan="2">&nbsp;</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 86px" colSpan="2"><ASP:DATAGRID id="DTG_EXCHRATEINQ" runat="server" Width="100%" CellPadding="1" AutoGenerateColumns="False"
								AllowPaging="True" AllowSorting="True">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="CURRENCYID" SortExpression="CURRENCYID" HeaderText="Currency Code">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="90px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CURRENCYDESC" SortExpression="CURRENCYDESC" HeaderText="Currency Description">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CURRENCYRATE" SortExpression="CURRENCYRATE" HeaderText="Currency Rate">
										<HeaderStyle Width="160px" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
					<tr>
					</tr>
					<TR>
						<TD class="tdH" colSpan="2"><asp:label id="LBL_SORTEXP" runat="server" Visible="False">CURRENCYDESC</asp:label>
							<asp:Label id="LBL_SORTTYPE" runat="server" Visible="False">ASC</asp:Label></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
