<%@ Page language="c#" Codebehind="LinkTemplate.aspx.cs" AutoEventWireup="True" Inherits="SME.AccountPlanning.Parameter.Maker.LinkTemplate" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>LinkTemplate</TITLE>
		<META content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY MS_POSITIONING="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<CENTER>
				<TABLE width="100%" border="0">
					<TR>
						<TD align="left" width="50%">
							<TABLE id="Table1">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>LINK TEMPLATE - MAKER</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/image/Back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../../../Body.aspx"><IMG height="25" src="/SME/Image/MainMenu.jpg" width="106"></A>
							<A href="../../../Logout.aspx" target="_top"><IMG src="/SME/Image/Logout.jpg"></A>
						</TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">MAKER</TD>
					</TR>
					<TR>
						<TD class="td" style="HEIGHT: 7px" vAlign="top" width="50%">
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_PRODUCT_ID" runat="server">Product Name :</asp:label></TD>
									<TD class='A"TDBGColorValue"' width="50%"><asp:dropdownlist id="DDL_PRODUCT_ID" runat="server" CssClass="Mandatory" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_TEMPLATE_ID" runat="server">Template :</asp:label></TD>
									<TD class='A"TDBGColorValue"' width="50%"><asp:dropdownlist id="DDL_TEMPLATE_ID" runat="server" Width="100%" AutoPostBack="True" onselectedindexchanged="DDL_TEMPLATE_ID_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_FIELD_ID" runat="server">Field :</asp:label></TD>
									<TD class='A"TDBGColorValue"' width="50%"><asp:dropdownlist id="DDL_FIELD_ID" Width="100%" Runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label1" runat="server">Query Procedure :</asp:label></TD>
									<TD class="TDBGColorValue" width="50%"><asp:textbox id="TXT_QUERY" runat="server" Width="100%" TextMode="MultiLine" Height="40px"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" colSpan="3" height="10"><asp:label id="LBL_SEQ" runat="server" Visible="False"></asp:label><asp:button id="BTN_SAVE" runat="server" CssClass="button1" Width="76px" Text="SAVE" onclick="BTN_SAVE_Click"></asp:button>&nbsp;&nbsp;
							<asp:button id="BTN_CLEAR" runat="server" CssClass="button1" Width="76px" Text="CLEAR" onclick="BTN_CLEAR_Click"></asp:button></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">EXISTING PARAMETER</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" align="center" width="50%" colSpan="2"><asp:datagrid id="DGR_LINK_TEMPLATE_EXIST" runat="server" Width="100%" AutoGenerateColumns="False"
								AllowPaging="True">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="SEQ" Visible="False">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PRODUCT_ID" HeaderText="Product ID">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PRODUCT_NAME" HeaderText="Product Name">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="TEMPLATE_NAME" HeaderText="Template Name">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="FIELD_NAME" HeaderText="Field Name">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="QUERY" HeaderText="Query Procedure">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Function">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="LNK_EDIT_EXIST" runat="server" CommandName="edit_exist">Edit</asp:LinkButton>
											<asp:LinkButton id="LNK_DELETE_EXIST" runat="server" CommandName="delete_exist">Delete</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</asp:datagrid></TD>
					</TR>
				</TABLE>
			</CENTER>
		</FORM>
	</BODY>
</HTML>
