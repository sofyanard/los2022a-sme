<%@ Page language="c#" Codebehind="SearchUser.aspx.cs" AutoEventWireup="True" Inherits="SME.Facilities.SearchUser" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SearchUser</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function UserSelect(theForm, theObj, theObjVal)
		{
			theObj.value = theObjVal;
			theForm.submit();
			window.close();
		}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD class="tdH" colSpan="2"></TD>
				</TR>
				<TR>
					<TD class="td" vAlign="top" width="50%">
						<TABLE id="Table2" cellSpacing="2" cellPadding="1" width="100%" border="0">
							<TR>
								<TD class="TDBGColor1" align="right" width="180">Group</TD>
								<TD>:</TD>
								<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_GROUP" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_GROUP_SelectedIndexChanged"></asp:dropdownlist>&nbsp;
									<asp:textbox id="TXT_GROUP" runat="server"></asp:textbox>&nbsp;
								</TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" align="right" width="180">Unit</TD>
								<TD>:</TD>
								<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_UNIT" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_UNIT_SelectedIndexChanged"></asp:dropdownlist>&nbsp;
									<asp:textbox id="TXT_UNIT" runat="server"></asp:textbox>&nbsp;
								</TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" align="right" width="180">Name</TD>
								<TD>:</TD>
								<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_USER" runat="server"></asp:dropdownlist>&nbsp;
									<asp:textbox id="TXT_USER" runat="server"></asp:textbox>&nbsp;
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD class="tdH" align="center" colSpan="2"><asp:button id="BTN_SEARCH" runat="server" Text="Search" onclick="BTN_SEARCH_Click"></asp:button>&nbsp;
						<asp:button id="BTN_CLEAR" runat="server" Text="Clear" onclick="BTN_CLEAR_Click"></asp:button></TD>
				</TR>
				<TR>
					<TD colSpan="2"><ASP:DATAGRID id="DG_RESULT" runat="server" PageSize="10" CssClass="TDBGGrid" AutoGenerateColumns="False"
							AllowPaging="True" Width="100%">
							<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
							<Columns>
								<asp:BoundColumn DataField="USERID" HeaderText="UserID">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="USERNAME" HeaderText="Name">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" Width="200px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="GROUPNAME" HeaderText="Group">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="UNITNAME" HeaderText="Unit">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn>
									<HeaderStyle Width="50px" CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:HyperLink id="HL_SELECT" runat="server">Select</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</ASP:DATAGRID></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
