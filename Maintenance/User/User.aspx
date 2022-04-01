<%@ Page language="c#" Codebehind="User.aspx.cs" AutoEventWireup="True" Inherits="SME.Maintenance.User.User" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>User</title>
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
						<TD class="tdNoBorder"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
							<TABLE id="Table2">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>User Maintenance</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="/SME/Body.aspx"><IMG src="/SME/Image/MainMenu.jpg"></A><A href="/SME/Logout.aspx" target="_top"><IMG src="/SME/Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD align="center" colSpan="2" height="41"><asp:hyperlink id="HyperLink1" runat="server" NavigateUrl="User.aspx" Font-Bold="True">User Maintenance</asp:hyperlink>&nbsp;|
							<asp:hyperlink id="HyperLink2" runat="server" Font-Bold="True">Group Maintenance</asp:hyperlink></TD>
					</TR>
					<TR>
						<TD align="center" colSpan="2">
							<TABLE class="td" id="Table4" cellSpacing="1" cellPadding="1" width="50%" border="0">
								<TR>
									<TD class="tdheader1" colSpan="2">Search Criteria</TD>
								</TR>
								<TR>
									<TD><STRONG>Area</STRONG></TD>
									<TD><asp:dropdownlist id="DDL_FIND_AREAID" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD><STRONG>Group</STRONG></TD>
									<TD><asp:dropdownlist id="DDL_GROUPID" runat="server" onselectedindexchanged="DDL_GROUPID_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 20px"><STRONG>Cabang/CBC/Group</STRONG></TD>
									<TD style="HEIGHT: 20px"><asp:dropdownlist id="DDL_BRANCH" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD><STRONG>User ID</STRONG></TD>
									<TD><asp:textbox onkeypress="return kutip_satu()" id="TXT_FIND_USERID" runat="server" Width="200px"
											MaxLength="20"></asp:textbox></TD>
								</TR>
								<TR>
									<TD><STRONG>User Name</STRONG></TD>
									<TD><asp:textbox onkeypress="return kutip_satu()" id="TXT_FIND_SU_FULLNAME" runat="server" Width="200px"
											MaxLength="30"></asp:textbox></TD>
								</TR>
								<TR>
									<TD><STRONG>Officer Code</STRONG></TD>
									<TD><asp:textbox onkeypress="return kutip_satu()" id="TXT_FIND_OFFICER_CODE" runat="server" MaxLength="10"></asp:textbox>
										<asp:Label id="LBL_ISSHOWALL" runat="server" Visible="False">0</asp:Label></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="2"><asp:button id="BTN_SEARCH" runat="server" Width="75px" CssClass="button1" Text="Search" onclick="BTN_SEARCH_Click"></asp:button>
										<asp:button id="BTN_CLEAR" runat="server" Width="75px" Text="Clear" CssClass="button1" onclick="BTN_CLEAR_Click"></asp:button>&nbsp;
										<asp:button id="BTN_SHOWALL" runat="server" Width="75px" Text="Show All" CssClass="button1" onclick="BTN_SHOWALL_Click"></asp:button></TD>
								</TR>
							</TABLE>
							<BR>
						</TD>
					</TR>
					<TR>
						<TD colSpan="2"><ASP:DATAGRID id="DatGrd" runat="server" AllowPaging="True" Width="100%" CellPadding="1" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="USERID" HeaderText="User ID">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="120px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="SU_FULLNAME" HeaderText="Full Name">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="GROUPID" HeaderText="Group ID">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="SG_GRPNAME" HeaderText="Group">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="SU_LOGON" HeaderText="Logon">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="SU_REVOKE" HeaderText="Revoke">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Logon">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
										<ItemTemplate>
											<asp:CheckBox id="CheckBox1" runat="server" Enabled="False"></asp:CheckBox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Revoke">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
										<ItemTemplate>
											<asp:CheckBox id="CheckBox2" runat="server" Enabled="False"></asp:CheckBox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="SU_ACTIVE" HeaderText="Active">
										<HeaderStyle Width="5%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Function">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="150px"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="LNK_VIEW" runat="server" CommandName="view">View</asp:LinkButton>&nbsp;
											<asp:LinkButton id="LinkButton1" runat="server" CommandName="edit">Edit</asp:LinkButton>&nbsp;
											<asp:LinkButton id="Linkbutton2" runat="server" CommandName="delete">Delete</asp:LinkButton>&nbsp;
											<asp:LinkButton id="LinkButton3" runat="server" CommandName="active">Active</asp:LinkButton>
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
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px; HEIGHT: 17px">UserID</TD>
									<TD style="WIDTH: 15px; HEIGHT: 17px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox onkeypress="return kutip_satu()" id="TXT_USERID" runat="server" CssClass="mandatory"
											MaxLength="20" Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Nama Lengkap</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_SU_FULLNAME" runat="server" Width="300px"
											CssClass="mandatory" MaxLength="300"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">NIP</TD>
									<TD></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox onkeypress="return kutip_satu()" id="TXT_SU_NIP" runat="server" MaxLength="20" Width="200px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">HP No.</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_SU_HPNUM" runat="server" MaxLength="30"
											Width="200px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Email</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_SU_EMAIL" runat="server" Width="300px"
											MaxLength="300"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Officer Code</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="txt_ofcrcode" runat="server" MaxLength="10"
											Width="200px"></asp:textbox></TD>
								</TR>
								<tr>
									<td class="TDBGColor1">Jabatan Code</td>
									<td></td>
									<td class="TDBGColorValue"><asp:dropdownlist id="ddl_jbcode" runat="server"></asp:dropdownlist></td>
								</tr>
								<TR>
									<TD class="TDBGColor1">Password</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_SU_PWD" runat="server" MaxLength="40" Width="300px" Visible="False" TextMode="Password"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Verify</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_VERIFYPWD" runat="server" MaxLength="40" Width="300px" Visible="False" TextMode="Password"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"></TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:LinkButton id="LNK_CHG_PWD" runat="server" Visible="False" Enabled="False" onclick="LNK_CHG_PWD_Click">Change Password</asp:LinkButton>
										<asp:Label id="LBL_STATUS_PWD" runat="server" Visible="False">0</asp:Label></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px; HEIGHT: 7px">Group</TD>
									<TD style="WIDTH: 15px; HEIGHT: 7px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 7px"><asp:dropdownlist id="DDL_USRGRPID" runat="server" AutoPostBack="True" CssClass="mandatory" onselectedindexchanged="DDL_USRGRPID_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Kantor Pusat/Kanwil</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_AREAID" runat="server" onselectedindexchanged="DDL_AREAID_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Cabang/CBC/Group</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_SU_BRANCH" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_SU_BRANCH_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Kota</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CITYNAME" runat="server" Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Teamleader</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="ddl_teamleader" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Upliner Small</TD>
									<TD></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:dropdownlist id="DDL_SU_UPLINER" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Upliner Middle</TD>
									<TD></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:dropdownlist id="DDL_SU_MIDUPLINER" runat="server"></asp:dropdownlist></TD>
								</TR>
								<tr>
									<td class="TDBGColor1">User Pair</td>
									<td></td>
									<td class="TDBGColorValue" style="HEIGHT: 17px"><asp:dropdownlist id="ddl_scmitra" runat="server"></asp:dropdownlist></td>
								</tr>
								<tr>
									<td class="TDBGColor1">Approval Limit</td>
									<td></td>
									<td class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox onkeypress="return numbersonly()" id="txt_scaprvlimit" runat="server" MaxLength="20"
											Width="200px"></asp:textbox></td>
								</tr>
								<tr>
									<td class="TDBGColor1">eMas Limit</td>
									<td></td>
									<td class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox onkeypress="return numbersonly()" id="txt_scemaslimit" runat="server" MaxLength="20"
											Width="200px"></asp:textbox></td>
								</tr>
								<tr>
									<td class="TDBGColor1">Revoke</td>
									<td></td>
									<td class="TDBGColorValue" style="HEIGHT: 17px"><asp:checkbox id="cb_revoke" runat="server"></asp:checkbox></td>
								</tr>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2"><asp:button id="BTN_NEW" runat="server" Width="70px" CssClass="Button1" Text="New" onclick="BTN_NEW_Click"></asp:button>&nbsp;<asp:button id="BTN_SAVE" runat="server" Width="70px" CssClass="Button1" Text="Save" Visible="False" onclick="BTN_SAVE_Click"></asp:button>&nbsp;
							<asp:button id="BTN_CANCEL" runat="server" Width="70px" CssClass="Button1" Text="Cancel" Visible="False" onclick="BTN_CANCEL_Click"></asp:button><asp:checkbox id="CHK_ISNEW" runat="server" Visible="False"></asp:checkbox></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
