<%@ Page language="c#" Codebehind="Group.aspx.cs" AutoEventWireup="True" Inherits="SME.Maintenance.User.Group" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Group</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../../include/cek_mandatoryOnly.html" -->
		<!-- #include file="../../include/cek_entries.html" -->
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder" style="WIDTH: 473px"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
							<TABLE id="Table4">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Group Maintenance</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><A href="/SME/Body.aspx"><IMG src="/SME/Image/MainMenu.jpg"></A><A href="/SME/Logout.aspx" target="_top"><IMG src="/SME/Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD align="center" colSpan="2" height="41">
							<asp:HyperLink id="HyperLink1" runat="server" Font-Bold="True" NavigateUrl="User.aspx">User Maintenance</asp:HyperLink>
							|
							<asp:HyperLink id="HyperLink2" runat="server" Font-Bold="True">Group Maintenance</asp:HyperLink></TD>
					</TR>
					<TR>
						<TD align="center" colSpan="2" height="41">
							<TABLE class="td" id="Table2" cellSpacing="1" cellPadding="1" width="50%" border="0">
								<TR>
									<TD class="tdheader1" colSpan="2">Search Criteria</TD>
								</TR>
								<TR>
									<TD><STRONG>Group ID</STRONG></TD>
									<TD>
										<asp:textbox onkeypress="return kutip_satu()" id="TXT_FIND_GROUPID" runat="server" Width="200px"
											MaxLength="20"></asp:textbox></TD>
								</TR>
								<TR>
									<TD><STRONG>Group Name</STRONG></TD>
									<TD>
										<asp:textbox onkeypress="return kutip_satu()" id="TXT_FIND_SG_GRPNAME" runat="server" Width="200px"
											MaxLength="50"></asp:textbox>
										<asp:Label id="LBL_ISSHOWALL" runat="server" Visible="False">1</asp:Label></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="2">
										<asp:button id="BTN_SEARCH" runat="server" Width="75px" CssClass="button1" Text="Search" onclick="BTN_SEARCH_Click"></asp:button>&nbsp;
										<asp:button id="BTN_CLEAR" runat="server" Width="75px" CssClass="button1" Text="Clear" onclick="BTN_CLEAR_Click"></asp:button>&nbsp;
										<asp:button id="BTN_SHOWALL" runat="server" Width="75px" Text="Show All" CssClass="button1" onclick="BTN_SHOWALL_Click"></asp:button></TD>
								</TR>
							</TABLE>
							<BR>
						</TD>
					</TR>
					<TR>
						<TD colSpan="2"><ASP:DATAGRID id="DatGrd" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="1"
								Width="100%">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="GROUPID" HeaderText="Group ID">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="150px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="SG_GRPNAME" HeaderText="Group Name">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Function">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="175px"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="LinkButton3" runat="server" CommandName="menuAccess">Menu Access</asp:LinkButton>&nbsp;
											<asp:LinkButton id="LinkButton1" runat="server" CommandName="edit">Edit</asp:LinkButton>&nbsp;
											<asp:LinkButton id="Linkbutton2" runat="server" CommandName="delete">Delete</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
					<TR>
						<TD colSpan="2">&nbsp;</TD>
					</TR>
					<TR>
						<TD class="tdHeader1" vAlign="top" width="50%" colSpan="2">Detail Information</TD>
					</TR>
					<TR>
						<TD class="td" style="WIDTH: 474px" vAlign="top" width="474"><TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px; HEIGHT: 17px">Group ID</TD>
									<TD style="WIDTH: 15px; HEIGHT: 17px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_GROUPID" runat="server" onkeypress="return kutip_satu()" CssClass="mandatory"
											MaxLength="20" Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Group Desc</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_SG_GRPNAME" runat="server" Width="300px" onkeypress="return kutip_satu()"
											CssClass="mandatory" MaxLength="150"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Group Upliner Small</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_SG_GRPUPLINER" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Group Upliner Middle</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_SG_MDLUPLINER" runat="server"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px; HEIGHT: 17px">Approval Group</TD>
									<TD style="WIDTH: 15px; HEIGHT: 17px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:checkbox id="CHK_SG_APPRSTA" runat="server" AutoPostBack="True" Text="(check if yes)" oncheckedchanged="CHK_SG_APPRSTA_CheckedChanged"></asp:checkbox></TD>
								</TR>
								<TR id="tr_aprvtrack" runat="server">
									<TD class="TDBGColor1" style="WIDTH: 129px; HEIGHT: 17px">Approval Track</TD>
									<TD style="WIDTH: 15px; HEIGHT: 17px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:dropdownlist id="DDL_SG_APRVTRACK" runat="server" Width="350"></asp:dropdownlist></TD>
								</TR>
								<tr id="tr_mitra" runat="server">
									<td class="TDBGColor1" style="WIDTH: 129px; HEIGHT: 17px">Group Pair</td>
									<td style="WIDTH: 15px; HEIGHT: 17px"></td>
									<td class="TDBGColorValue" style="HEIGHT: 17px"><asp:dropdownlist id="ddl_sgmitra" runat="server" Width="350"></asp:dropdownlist></td>
								</tr>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2">
							<asp:button id="BTN_NEW" runat="server" Width="70px" CssClass="Button1" Text="New" onclick="BTN_NEW_Click"></asp:button>&nbsp;<asp:button id="BTN_SAVE" runat="server" Text="Save" CssClass="Button1" Width="70px" Visible="False" onclick="BTN_SAVE_Click"></asp:button>&nbsp;
							<asp:button id="BTN_CANCEL" runat="server" CssClass="Button1" Width="70px" Text="Cancel" Visible="False" onclick="BTN_CANCEL_Click"></asp:button>
							<asp:CheckBox id="CHK_ISNEW" runat="server" Visible="False"></asp:CheckBox></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
