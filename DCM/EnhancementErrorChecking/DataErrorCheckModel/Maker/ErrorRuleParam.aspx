<%@ Page language="c#" Codebehind="ErrorRuleParam.aspx.cs" AutoEventWireup="True" Inherits="SME.DCM.EnhancementErrorChecking.DataErrorCheckModel.Maker.ErrorRuleParam" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>ErrorRuleParam</TITLE>
		<META content="Microsoft Visual Studio .NET 7.1" name=GENERATOR>
		<META content=C# name=CODE_LANGUAGE>
		<META content=JavaScript name=vs_defaultClientScript>
		<META content=http://schemas.microsoft.com/intellisense/ie5 name=vs_targetSchema><LINK href="../../../../Style.css" type=text/css rel=stylesheet >
	</HEAD>
	<BODY MS_POSITIONING="GridLayout">
		<FORM id=Form1 method=post runat="server">
			<CENTER>
				<TABLE width="100%" border=0>
					<TR>
						<TD align=left>
							<TABLE id=Table1>
								<TR>
									<TD class=tdBGColor2 style="WIDTH: 400px" align=center><B>ERROR RULE PARAMETER</B>
									</TD>
								</TR>
							</TABLE>
						</TD>
						<TD class=tdNoBorder align=right><A href="../../../../Body.aspx" ><IMG height=25 src="/SME/Image/MainMenu.jpg" width=106 ></A> <A href="../../../../Logout.aspx" target=_top ><IMG src="/SME/Image/Logout.jpg" ></A>
						</TD>
					</TR>
					<TR>
						<TD class=tdHeader1 colSpan=2>PARAMETER SETUP</TD></TR>
					<TR>
						<TD class=td vAlign=top width="50%">
							<TABLE id=Table2 cellSpacing=0 cellPadding=0 width="100%">
								<TR>
									<TD class=TDBGColor1 width="50%"><asp:label id=LBL_DDL_DATA_TYPE runat="server">Data Type :</asp:label></TD>
									<TD class='A"TDBGColorValue"' width="50%"><asp:dropdownlist id=DDL_DATA_TYPE runat="server" Width="100%" AutoPostBack="True" onselectedindexchanged="DDL_DATA_TYPE_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class=TDBGColor1 width="50%"><asp:label id=LBL_TXT_FIELD runat="server">Fields :</asp:label></TD>
									<TD class='A"TDBGColorValue"' width="50%"><asp:dropdownlist id=DDL_FIELD runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class=td vAlign=top width="50%">
							<TABLE id=Table3 cellSpacing=0 cellPadding=0 width="100%">
								<TR>
									<TD class=TDBGColor1 width="50%"><asp:label id=LBL_TXT_PAGE runat="server">Page :</asp:label></TD>
									<TD class='A"TDBGColorValue"' width="50%"><asp:dropdownlist id=DDL_PAGE runat="server" Width="100%" AutoPostBack="True" onselectedindexchanged="DDL_PAGE_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class=TDBGColor1 width="50%"><asp:label id=LBL_TXT_CONTROL runat="server">ID Control :</asp:label></TD>
									<TD class='A"TDBGColorValue"' width="50%"><asp:dropdownlist id=DDL_CONTROL runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class=TDBGColor1 width="50%"><asp:label id=LBL_TXT_MESSAGE runat="server">Error Message :</asp:label></TD>
									<TD class=TDBGColorValue width="50%"><asp:textbox id=TXT_MESSAGE runat="server" Width="100%" TextMode="MultiLine"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class=TDBGColor2 vAlign=top align=center width="100%" colSpan=2>
							<asp:label id=LBL_SEQ runat="server" Visible="False"></asp:label>
							<asp:button id=BTN_SAVE runat="server" Width="76px" CssClass="button1" Text="SAVE" onclick="BTN_SAVE_Click"></asp:button>&nbsp;&nbsp; 
							<asp:button id=BTN_CLEAR runat="server" Width="76px" CssClass="button1" Text="CLEAR" onclick="BTN_CLEAR_Click"></asp:button>
						</TD>
					</TR>
					<TR>
						<TD class=tdHeader1 colSpan=2>EXISTING PARAMETER</TD>
					</TR>
					<TR>
						<TD class=td vAlign=top align=center width="50%" colSpan=2>
							<asp:datagrid id=DGR_DATA_EXIST runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="SEQ" Visible="False">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="DATA_TYPE" Visible="False">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="DATA_TYPE_NM" HeaderText="Field">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="DATA_FIELD" Visible="False">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="DATA_FIELD_NM" HeaderText="Field">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PAGE_ID" Visible="False">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PAGE_NM" HeaderText="Page Name">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CONTROL_ID" Visible="False">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CONTROL_NM" HeaderText="Control Name">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="ERR_MESSAGE" HeaderText="Error Message">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="IS_ACTIVE" Visible="False">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Function">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="LNK_EDIT" runat="server" CommandName="edit">Edit</asp:LinkButton>
											<asp:LinkButton id="LNK_DELETE" runat="server" CommandName="delete">Delete</asp:LinkButton>
											<asp:LinkButton id="LNK_UNDELETE" runat="server" CommandName="undelete">Undelete</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</asp:datagrid>
						</TD>
					</TR>
					<TR>
						<TD class=tdHeader1 colSpan=2>REQUESTED PARAMETER</TD>
					</TR>
					<TR>
						<TD class=td vAlign=top align=center width="50%" colSpan=2>
							<asp:datagrid id=DGR_DATA_REQUEST runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="SEQ" Visible="False">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="DATA_TYPE" Visible="False">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="DATA_TYPE_NM" HeaderText="Field">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="DATA_FIELD" Visible="False">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="DATA_FIELD_NM" HeaderText="Field">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PAGE_ID" Visible="False">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PAGE_NM" HeaderText="Page Name">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CONTROL_ID" Visible="False">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CONTROL_NM" HeaderText="Control Name">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="ERR_MESSAGE" HeaderText="Error Message">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="STATUS" HeaderText="Pending Status">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Function">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="LNK_EDIT_REQ" runat="server" CommandName="edit_req">Edit</asp:LinkButton>
											<asp:LinkButton id="LNK_DELETE_REQ" runat="server" CommandName="delete_req">Delete</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</asp:datagrid>
						</TD>
					</TR>
				</TABLE>
			</CENTER>
		</FORM>
	</BODY>
</HTML>
