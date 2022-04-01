<%@ Page language="c#" Codebehind="LinkDataIDParam.aspx.cs" AutoEventWireup="True" Inherits="SME.DCM.EnhancementErrorChecking.DataErrorCheckModel.Maker.LinkDataIDParam" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<TITLE>LinkDataIDParam</TITLE>
		<META content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../../Style.css" type="text/css" rel="stylesheet">
  </HEAD>
	<BODY MS_POSITIONING="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<CENTER>
				<TABLE width="100%" border="0">
					<TBODY>
						<TR>
							<TD align="left">
								<TABLE id="Table1">
									<TR>
										<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>LINK DATA - ID PARAMETER</B></TD>
									</TR>
								</TABLE>
							</TD>
							<TD class="tdNoBorder" align="right"><A href="../../../../Body.aspx"><IMG height="25" src="/SME/Image/MainMenu.jpg" width="106"></A>
								<A href="../../../../Logout.aspx" target="_top"><IMG src="/SME/Image/Logout.jpg"></A>
							</TD>
						</TR>
						<TR>
							<TD class="tdHeader1" colSpan="2">PARAMETER SETUP</TD>
						</TR>
						<TR>
							<TD class="td" vAlign="top" width="50%">
								<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
									<TBODY>
										<TR>
											<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_RULE_ID" runat="server">Rule ID :</asp:label></TD>
											<TD class="TDBGColorValue"><asp:textbox id="TXT_RULE_ID" runat="server" Width="100%" ReadOnly="True"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_DATA_TYPE" runat="server">Data Type :</asp:label></TD>
											<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_DATA_TYPE" runat="server" Width="100%" AutoPostBack="True" CssClass="Mandatory" onselectedindexchanged="DDL_DATA_TYPE_SelectedIndexChanged"></asp:dropdownlist></TD>
										</TR>
									</TBODY>
								</TABLE>
							</TD>
							<TD class="td" vAlign="top" width="50%">
								<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_FIELD" runat="server">Fields :</asp:label></TD>
										<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_FIELD" runat="server" Width="100%" CssClass="Mandatory"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_DESC" runat="server">Description :</asp:label></TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_DESC" runat="server" Width="100%" AutoPostBack="True" CssClass="Mandatory" ontextchanged="TXT_DESC_TextIndexChanged"></asp:textbox></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2"><asp:label id="LBL_SEQ" runat="server" Visible="False"></asp:label>
								<asp:button id="BTN_SAVE" runat="server" Width="76px" CssClass="button1" Text="SAVE" onclick="BTN_SAVE_Click"></asp:button>&nbsp;&nbsp;
								<asp:button id="BTN_CLEAR" runat="server" Width="76px" CssClass="button1" Text="CLEAR" onclick="BTN_CLEAR_Click"></asp:button></TD>
						</TR>
						<TR>
							<TD class="tdHeader1" colSpan="2">EXISTING PARAMETER</TD>
						</TR>
						<TR>
							<TD class="td" vAlign="top" align="center" width="50%" colSpan="2"><asp:datagrid id="DGR_DATA_EXIST" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="True">
									<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
									<Columns>
										<asp:BoundColumn DataField="SEQ" Visible="False">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="RULE_ID" Visible="False">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="RULE_NAME" HeaderText="Rule ID">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Left"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="DATA_TYPE" Visible="False">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="DATA_TYPE_NAME" HeaderText="Data Type">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Left"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="DATA_FIELD" Visible="False">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="DATA_FIELD_NAME" HeaderText="Field">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Left"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="DESC" Visible="False">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
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
								</asp:datagrid></TD>
						</TR>
						<TR>
							<TD class="tdHeader1" colSpan="2">REQUESTED PARAMETER</TD>
						</TR>
						<TR>
							<TD class="td" vAlign="top" align="center" width="50%" colSpan="2"><asp:datagrid id="DGR_DATA_REQUEST" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="True">
									<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
									<Columns>
										<asp:BoundColumn DataField="SEQ" Visible="False">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="RULE_ID" Visible="False">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="RULE_NAME" HeaderText="Rule ID">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Left"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="DATA_TYPE" Visible="False">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="DATA_TYPE_NAME" HeaderText="Data Type">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Left"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="DATA_FIELD" Visible="False">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="DATA_FIELD_NAME" HeaderText="Field">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Left"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="DESC" Visible="False">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
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
								</asp:datagrid></TD>
						</TR>
					</TBODY>
				</TABLE>
			</CENTER>
		</FORM>
	</BODY>
</HTML>
