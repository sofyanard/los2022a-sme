<%@ Page language="c#" Codebehind="VariableParam.aspx.cs" AutoEventWireup="True" Inherits="SME.AccountPlanning.Parameter.Maker.VariableParam" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<TITLE>VariableParam</TITLE>
		<META name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<META name="CODE_LANGUAGE" Content="C#">
		<META name="vs_defaultClientScript" content="JavaScript">
		<META name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../../../include/popup.html" -->
  </HEAD>
	<BODY MS_POSITIONING="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<CENTER>
				<TABLE width="100%" border="0">
					<TR>
						<TD align="left">
							<TABLE id="Table1">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>VARIABLE PARAMETER - 
											MAKER</B></TD>
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
						<TD class="td" vAlign="top" width="50%" style="HEIGHT: 7px">
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_VARIABLE_ID" runat="server">Variable ID :</asp:label></TD>
									<TD class="TDBGColorValue" colspan="2"><asp:textbox id="TXT_VARIABLE_ID" runat="server" Width="100%" CssClass="Mandatory"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_VARIABLE_NAME" runat="server">Variable Name :</asp:label></TD>
									<TD class="TDBGColorValue" colspan="2"><asp:textbox id="TXT_VARIABLE_NAME" runat="server" Width="100%" CssClass="Mandatory"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_DATA_UPLOAD" runat="server">Link to Data Upload :</asp:label></TD>
									<TD class='A"TDBGColorValue"' colspan="2"><asp:dropdownlist id="DDL_DATA_UPLOAD" runat="server" Width="100%" AutoPostBack="True" onselectedindexchanged="DDL_DATA_UPLOAD_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD width="50%"></TD>
									<TD class="TDBGColorValue" width="50%"><asp:textbox id="TXT_LINKID" runat="server" Width="100%"></asp:textbox></TD>
									<TD class="TDBGColorValue"><asp:button id="BTN_LINK" runat="server" Text="........" onclick="BTN_LINK_Click"></asp:button></TD>
								</TR>
								<TR>
									<TD>
										<asp:label id="LBL_ID" runat="server" Visible="False"></asp:label>
										<asp:label id="TXT_ID" runat="server" Visible="False"></asp:label>
									</TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%" style="HEIGHT: 7px">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_VALUE_NON_RANGE" runat="server">Value Non Range :</asp:label></TD>
									<TD class="TDBGColorValue" colspan="3"><asp:textbox id="TXT_VALUE_NON_RANGE" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_VALUE_RANGE" runat="server">Value Range :</asp:label></TD>
									<TD class='A"TDBGColorValue"' width="20%"><asp:textbox id="TXT_VALUE_RANGE" runat="server" Width="100%"></asp:textbox></TD>
									<TD class="TDBGColor1" width="10%"><asp:label id="LBL_TXT_VALUE_RANGE_SCORE" runat="server">Score :</asp:label></TD>
									<TD class='A"TDBGColorValue"' width="20%"><asp:textbox id="TXT_VALUE_RANGE_SCORE" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2">
							<asp:button id="BTN_SAVE" runat="server" Width="76px" CssClass="button1" Text="SAVE" onclick="BTN_SAVE_Click"></asp:button>&nbsp;&nbsp;
							<asp:button id="BTN_CLEAR" runat="server" Width="76px" CssClass="button1" Text="CLEAR" onclick="BTN_CLEAR_Click"></asp:button></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">EXISTING PARAMETER</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" align="center" width="50%" colSpan="2"><asp:datagrid id="DGR_VARIABLE_EXIST" runat="server" AllowPaging="True" AutoGenerateColumns="False"
								Width="100%">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="SEQ" Visible="False">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="VARIABLE_ID" HeaderText="Variable ID">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="VARIABLE_NM" HeaderText="Variable Name">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="VARIABLE_LINKID" Visible="False">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="VARIABLE_LINK" HeaderText="Data Link">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="VALUE_RANGE" HeaderText="Value Non Range">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="VALUE" HeaderText="Value Range">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="SCORE" HeaderText="Value Range Score">
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
					<TR>
						<TD class="tdHeader1" colSpan="2">REQUEST PARAMETER</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" align="center" width="50%" colSpan="2"><asp:datagrid id="DGR_VARIABLE_REQ" runat="server" AllowPaging="True" AutoGenerateColumns="False"
								Width="100%">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="SEQ" Visible="False">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="VARIABLE_ID" HeaderText="Variable ID">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="VARIABLE_NM" HeaderText="Variable Name">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="VARIABLE_LINKID" Visible="False">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="VARIABLE_LINK" HeaderText="Data Link">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="VALUE_RANGE" HeaderText="Value Non Range">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="VALUE" HeaderText="Value Range">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="SCORE" HeaderText="Value Range Score">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="REQUEST" HeaderText="Status">
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
				</TABLE>
			</CENTER>
		</FORM>
	</BODY>
</HTML>
