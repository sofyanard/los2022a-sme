<%@ Page language="c#" Codebehind="RateInquiry.aspx.cs" AutoEventWireup="True" Inherits="SME.Facilities.RateInquiry" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>FindCustomer</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
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
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Product Rate Inquiry</B></TD>
								</TR>
							</TABLE>
						</TD>
						<td align="right"><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></td>
					</TR>
					<TR>
						<TD align="center" colSpan="2">
							<TABLE class="td" id="Table1" cellSpacing="1" cellPadding="1" width="590" border="1" style="WIDTH: 590px; HEIGHT: 212px">
								<TR>
									<TD class="tdHeader1">Search Criteria</TD>
								</TR>
								<TR>
									<TD vAlign="top">
										<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD class="TDBGColor1" width="160">ID Produk</TD>
												<TD width="17"></TD>
												<TD width="342" class="TDBGColorValue" style="WIDTH: 342px">
													<asp:textbox onkeypress="return kutip_satu()" id="TXT_PRODUCTID" runat="server" MaxLength="50"
														Width="200px"></asp:textbox>
												</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Deskripsi Produk</TD>
												<TD></TD>
												<TD class="TDBGColorValue" style="WIDTH: 342px">
													<asp:textbox onkeypress="return kutip_satu()" id="TXT_PRODUCTDESC" runat="server" MaxLength="20"
														Width="200px"></asp:textbox>
												</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 22px">
													Jenis Produk</TD>
												<TD style="HEIGHT: 22px"></TD>
												<TD class="TDBGColorValue" style="WIDTH: 342px; HEIGHT: 22px">
													<asp:textbox onkeypress="return kutip_satu()" id="TXT_JNSPRODUCT" runat="server" MaxLength="30"
														Width="200px"></asp:textbox>
												</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 11px">Rate Produk</TD>
												<TD style="HEIGHT: 11px"></TD>
												<TD style="WIDTH: 342px; HEIGHT: 11px">
													<asp:textbox onkeypress="return digitsonly()" id="TXT_BOTTOMRATE" runat="server" Width="112px"
														MaxLength="25"></asp:textbox>&nbsp;&nbsp;&nbsp; s/d&nbsp; &nbsp;&nbsp;
													<asp:textbox onkeypress="return digitsonly()" id="TXT_TOPRATE" runat="server" Width="112px" MaxLength="25"></asp:textbox>
												</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" vAlign="middle" style="HEIGHT: 11px">Condition</TD>
												<TD vAlign="middle" style="HEIGHT: 11px"></TD>
												<TD vAlign="top" class="TDBGColorValue" style="WIDTH: 342px; HEIGHT: 25px">
													<asp:radiobuttonlist id="RDB_COND" runat="server" RepeatDirection="Horizontal" CellSpacing="0" Height="11px"
														CellPadding="0" Width="256px">
														<asp:ListItem Value="And">And</asp:ListItem>
														<asp:ListItem Value="Or" Selected="True">Or</asp:ListItem>
													</asp:radiobuttonlist></TD>
											</TR>
											<TR>
												<TD vAlign="top" align="center" colSpan="3" style="WIDTH: 521px"><BR>
													<asp:button id="BTN_FIND" runat="server" Text="Find" Width="75px" CssClass="button1" onclick="BTN_FIND_Click"></asp:button></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD align="center" colSpan="2">&nbsp;</TD>
					</TR>
					<TR>
						<TD colSpan="2" style="HEIGHT: 86px">
							<ASP:DATAGRID id="DTG_RATEINQ" runat="server" CellPadding="1" Width="100%" AllowPaging="True"
								AutoGenerateColumns="False" AllowSorting="True">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="PRODUCTID" SortExpression="PRODUCTID" HeaderText="ID Produk">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="90px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PRODUCTDESC" SortExpression="PRODUCTDESC" HeaderText="Deskripsi Produk">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="JNSPRODUCT" SortExpression="JNSPRODUCT" HeaderText="Jenis Produk">
										<HeaderStyle Width="110px" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="RATE" SortExpression="RATE" HeaderText="Rate Produk"  DataFormatString="{0:N2}%">
										<HeaderStyle Width="130px" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn>
										<HeaderStyle Width="75px" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="LNK_PRODUCTDETAIL" runat="server" CommandName="View">View</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID>
						</TD>
					</TR>
					<tr>
					</tr>
					<TR>
						<TD class="tdH" colSpan="2"><asp:label id="LBL_SORTEXP" runat="server" Visible="False">PRODUCTID</asp:label>
							<asp:label id="LBL_SORTTYPE" runat="server" Visible="False">ASC</asp:label></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
