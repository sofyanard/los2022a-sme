<%@ Page language="c#" Codebehind="ValueChainInfo.aspx.cs" AutoEventWireup="True" Inherits="SME.AccountPlanning.InfoSetup.ValueChainInfo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ValueChainInfo</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY MS_POSITIONING="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<CENTER>
				<TABLE width="100%" border="0">
					<TR>
						<TD align="left" width="50%">
							<TABLE id="Table1">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Customer Value Chain Info </B>
									</TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/image/Back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../../Body.aspx"><IMG height="25" src="../../Image/MainMenu.jpg" width="106"></A>
							<A href="../../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A>
						</TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">CUSTOMER INFO</TD>
					</TR>
					<TR>
						<TD class="td" style="HEIGHT: 7px" vAlign="top" width="50%">
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_CIF" runat="server">CIF No. / ID:</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_ANCHOR_CIF" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_CUST_NAME" runat="server">Customer Name :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_ANCHOR_NAME" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_ADDRESS" runat="server">Address :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_ANCHOR_ADDRESS" runat="server" Width="100%" TextMode="MultiLine" Height="40px"
											Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_KOTA" runat="server">City :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_ANCHOR_CITY" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_ANCHOR_INDUSTRY" runat="server">Industry :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_ANCHOR_INDUSTRY" runat="server" Width="100%" Enabled="False"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" style="HEIGHT: 7px" vAlign="top" width="50%">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_CUST_DATE" runat="server">Customer Date :</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_ANCHOR_DAY" runat="server" Width="24px"
											MaxLength="2" Columns="4" Enabled="False"></asp:textbox><asp:dropdownlist id="DDL_ANCHOR_MONTH" runat="server" Enabled="False"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_ANCHOR_YEAR" runat="server" Width="36px"
											MaxLength="4" Columns="4" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_RM" runat="server">Customer Team Lead / RM :</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2"><asp:textbox id="TXT_ANCHOR_RM" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_GROUP_NAME" runat="server">Group Name :</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2"><asp:dropdownlist id="DDL_ANCHOR_GROUP_NAME" runat="server" Width="100%" AutoPostBack="True" Enabled="False" onselectedindexchanged="DDL_ANCHOR_GROUP_NAME_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_UNIT_NAME" runat="server">Unit Name :</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2"><asp:dropdownlist id="DDL_ANCHOR_UNIT_NAME" runat="server" Width="100%" Enabled="False"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_RELATIONSHIP" runat="server">Length of relationship :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_ANCHOR_RELATIONSHIP" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
									<TD><asp:label id="LBL_TXT_DAYS" runat="server">Years</asp:label></TD>
								</TR>
							</TABLE>
							<asp:label id="LBL_TEMP" runat="server" Visible="False"></asp:label>
						</TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">VALUE CHAIN INFO</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" align="center" width="50%" colSpan="2"><asp:datagrid id="DGR_VALUE_CHAIN" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="True">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="SEQ" Visible="False">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CUSTOMER_NAME" HeaderText="Company Name">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="INDUSTRY_NAME" HeaderText="Industry">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="RELATION_STATUS" HeaderText="Relationship Status">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CATEGORY" HeaderText="Category">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PRIORITY" HeaderText="Priority For Pundi">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="KEY_CONTACT" HeaderText="Key Contact">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="MEET" HeaderText="Meet In Last 3 Month">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Function">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="Linkbutton1" runat="server" CommandName="edit">Edit</asp:LinkButton>
											<asp:LinkButton id="Linkbutton2" runat="server" CommandName="delete">Delete</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</asp:datagrid></TD>
					</TR>
					<TR>
						<TD class="td" style="HEIGHT: 7px" vAlign="top" width="50%">
							<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_VC_CIF" runat="server">CIF No. / ID:</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_VC_CIF" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_VC_NAME" runat="server">Company Name :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_VC_NAME" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_VC_ADDRESS" runat="server">Address :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_VC_ADDRESS" runat="server" Width="100%" TextMode="MultiLine" Height="40px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_VC_CITY" runat="server">City :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_VC_CITY" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_VC_INDUSTRY" runat="server">Industry :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_VC_INDUSTRY" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_VC_RELATION" runat="server">Relationship Status :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_VC_RELATION" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label1" runat="server">Category :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_VC_CATEGORY" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" style="HEIGHT: 7px" vAlign="top" width="50%">
							<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_VC_GROUP_NAME" runat="server">Group Name :</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2"><asp:dropdownlist id="DDL_VC_GROUP_NAME" runat="server" Width="100%" AutoPostBack="True" onselectedindexchanged="DDL_VC_GROUP_NAME_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_VC_UNIT_NAME" runat="server">Unit Name :</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2"><asp:dropdownlist id="DDL_VC_UNIT_NAME" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_VC_LEN_RELATION" runat="server">Length of relationship :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_VC_LEN_RELATION" runat="server" Width="100%"></asp:textbox></TD>
									<TD><asp:label id="LBL_TXT_VC_DAY" runat="server">Years</asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_VC_PRIORITY" runat="server">Priority for Pundi:</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2"><asp:radiobuttonlist id="RDO_PRIORITY_VC" runat="server" Width="150px" RepeatDirection="Horizontal">
											<asp:ListItem Value="1">Yes</asp:ListItem>
											<asp:ListItem Value="0">No</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_VC_MEET" runat="server">Meet in Last Three Month :</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2"><asp:radiobuttonlist id="RDO_MEET_VC" runat="server" Width="150px" RepeatDirection="Horizontal">
											<asp:ListItem Value="1">Yes</asp:ListItem>
											<asp:ListItem Value="0">No</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_VC_CONTACT" runat="server">Key Contact:</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2"><asp:textbox id="TXT_VC_CONTACT" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label3" runat="server">Average turn-over (IDR) :</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2"><asp:textbox id="TXT_VC_AVG_TURN" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" colSpan="3" height="10"><asp:label id="LBL_SEQ_VC" runat="server" Visible="False"></asp:label><asp:button id="BTN_SAVE_VC" runat="server" Width="100px" CssClass="button1" Text="INSERT" onclick="BTN_SAVE_VC_Click"></asp:button></TD>
					</TR>
				</TABLE>
				<TABLE id="TBL_COMPANY" width="100%" border="1" runat="server">
				</TABLE>
			</CENTER>
		</FORM>
	</BODY>
</HTML>
