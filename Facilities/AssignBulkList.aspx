<%@ Page language="c#" Codebehind="AssignBulkList.aspx.cs" AutoEventWireup="True" Inherits="SME.Facilities.AssignBulkList" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AssignBulkList</title>
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
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Assignment</B></TD>
								</TR>
							</TABLE>
						</TD>
						<td align="right"><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></td>
					</TR>
					<TR>
						<TD align="center" colSpan="2">
							<TABLE class="td" id="Table1" style="WIDTH: 590px; HEIGHT: 125px" cellSpacing="1" cellPadding="1"
								width="590" border="1">
								<TR>
									<TD class="tdHeader1">Search Criteria</TD>
								</TR>
								<TR>
									<TD vAlign="top">
										<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD class="TDBGColor1" width="160">UserID</TD>
												<TD width="17"></TD>
												<TD class="TDBGColorValue" width="340"><asp:textbox onkeypress="return kutip_satu()" id="TXT_USERID" runat="server" MaxLength="20" Width="300px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="160">Name</TD>
												<TD width="17"></TD>
												<TD class="TDBGColorValue" width="340"><asp:textbox onkeypress="return kutip_satu()" id="TXT_USERNAME" runat="server" MaxLength="100"
														Width="300px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="160">Group</TD>
												<TD width="17"></TD>
												<TD class="TDBGColorValue" width="340"><asp:textbox onkeypress="return kutip_satu()" id="TXT_GROUP" runat="server" MaxLength="100" Width="300px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="160">Branch</TD>
												<TD width="17"></TD>
												<TD class="TDBGColorValue" width="340"><asp:textbox onkeypress="return kutip_satu()" id="TXT_BRANCH" runat="server" Width="300px" MaxLength="100"></asp:textbox></TD>
											</TR>
											<TR>
												<TD vAlign="top" align="center" colSpan="3"><asp:button id="BTN_FIND" runat="server" Width="100px" CssClass="button1" Text="Find" onclick="BTN_FIND_Click"></asp:button></TD>
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
						<TD colSpan="2"><ASP:DATAGRID id="DatGrd" runat="server" Width="100%" CellPadding="1" AllowPaging="True" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="USERID" HeaderText="User ID">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="USERNAME" HeaderText="User Name">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="GROUPNAME" HeaderText="Group">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="BRANCHNAME" HeaderText="Branch">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:ButtonColumn Text="View" HeaderText="Function" CommandName="View">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
									</asp:ButtonColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
