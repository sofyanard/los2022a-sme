<%@ Page language="c#" Codebehind="ListInputReqBI.aspx.cs" AutoEventWireup="True" Inherits="SME.IDI_BI.ListInputReqBI" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ListInputReqBI</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table4" width="100%" border="0">
					<TR>
						<TD align="left" colSpan="1">
							<TABLE id="Table3">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>BI CHECKING REQUEST</B></TD>
								</TR>
							</TABLE>
						</TD>
						<td align="right"><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></td>
					</TR>
					<TR>
						<TD align="center" colSpan="2">
							<TABLE class="td" id="Table1" style="WIDTH: 590px; HEIGHT: 100px" cellSpacing="1" cellPadding="1"
								width="590" border="1">
								<TR>
									<TD class="tdHeader1" style="HEIGHT: 26px">Search Criteria</TD>
								</TR>
								<TR>
									<TD vAlign="bottom" align="center">
										<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD class="TDBGColor1">Customer Name</TD>
												<TD width="17"></TD>
												<TD class="TDBGColorValue" style="WIDTH: 342px" width="342"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CUST_NAME" runat="server" MaxLength="20"
														Width="280px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">KTP Number</TD>
												<TD width="17"></TD>
												<TD class="TDBGColorValue" style="WIDTH: 342px" width="342"><asp:textbox onkeypress="return kutip_satu()" id="TXT_KTP_NUM" runat="server" MaxLength="20"
														Width="280px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 1px">NPWP Number</TD>
												<TD style="HEIGHT: 1px" width="17"></TD>
												<TD class="TDBGColorValue" style="WIDTH: 342px; HEIGHT: 1px" width="342"><asp:textbox onkeypress="return kutip_satu()" id="NPWP_NUM" runat="server" MaxLength="20" Width="280px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 521px" vAlign="top" align="center" colSpan="3"></TD>
											</TR>
										</TABLE>
										<%if (Request.QueryString["tc"] != "" && Request.QueryString["tc"] != null&& Request.QueryString["tc"] != "1.0") {%>
										<asp:button id="BTN_FIND" runat="server" Width="200px" CssClass="button1" Text="Find Existing" onclick="BTN_FIND_Click"></asp:button>
										<% } else { %>
										<% } %>
										&nbsp;
										<asp:button id="BTN_NEW_CUST" runat="server" Width="200px" CssClass="button1" Text="New Customer" onclick="BTN_NEW_CUST_Click"></asp:button></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD align="center" colSpan="2">&nbsp;</TD>
					</TR>
					<TR>
						<TD colSpan="2"><ASP:DATAGRID id="DatGrd" runat="server" Width="100%" AllowPaging="True" CellPadding="1" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn HeaderText="IDI REQ #" DataField="IDI_REQ#">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="Customer Name" DataField="IDI_CUSTNAME">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="IDI_KTP#" HeaderText="KTP Number">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="IDI_NPWP#" HeaderText="NPWP number">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:ButtonColumn Text="Continue" HeaderText="Function" CommandName="Continue">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
									</asp:ButtonColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
					<TR>
					</TR>
					<TR>
						<TD class="tdH" colSpan="2"></TD>
					</TR>
					<TR>
						<TD class="tdH" colSpan="2"><asp:label id="Label1" runat="server"></asp:label></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
