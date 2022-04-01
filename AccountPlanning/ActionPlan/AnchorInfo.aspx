<%@ Page language="c#" Codebehind="AnchorInfo.aspx.cs" AutoEventWireup="True" Inherits="SME.AccountPlanning.ActionPlan.AnchorInfo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AnchorInfo</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
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
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Anchor Info &amp; 
											Team&nbsp;Setup </B>
									</TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/image/Back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../../Body.aspx"><IMG height="25" src="../../Image/MainMenu.jpg" width="106"></A>
							<A href="../../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A>
						</TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">ANCHOR INFO</TD>
					</TR>
					<TR>
						<TD class="td" style="HEIGHT: 7px" vAlign="top" width="50%">
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_CIF" runat="server">CIF No. / ID:</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_ANCHOR_CIF" runat="server" CssClass="Mandatory" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_CUST_NAME" runat="server">Anchor Name :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_ANCHOR_NAME" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_ADDRESS" runat="server">Address :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_ANCHOR_ADDRESS" runat="server" Width="100%" Height="40px" TextMode="MultiLine"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_KOTA" runat="server">City :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_ANCHOR_CITY" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_ANCHOR_INDUSTRY" runat="server">Industry :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_ANCHOR_INDUSTRY" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" style="HEIGHT: 7px" vAlign="top" width="50%">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_CUST_DATE" runat="server">Customer Date :</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_ANCHOR_DAY" runat="server" Width="24px"
											Columns="4" MaxLength="2"></asp:textbox><asp:dropdownlist id="DDL_ANCHOR_MONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_ANCHOR_YEAR" runat="server" Width="36px"
											Columns="4" MaxLength="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_RM" runat="server">Anchor Team Lead / RM :</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2"><asp:textbox id="TXT_ANCHOR_RM" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_GROUP_NAME" runat="server">Group Name :</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2"><asp:dropdownlist id="DDL_ANCHOR_GROUP_NAME" runat="server" Width="100%" AutoPostBack="True" onselectedindexchanged="DDL_ANCHOR_GROUP_NAME_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_UNIT_NAME" runat="server">Unit Name :</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2"><asp:dropdownlist id="DDL_ANCHOR_UNIT_NAME" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_RELATIONSHIP" runat="server">Length of relationship :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_ANCHOR_RELATIONSHIP" runat="server" Width="100%"></asp:textbox></TD>
									<TD><asp:label id="LBL_TXT_DAYS" runat="server">Years</asp:label></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" colSpan="3" height="10"><asp:label id="LBL_SEQ" runat="server" Visible="False"></asp:label><asp:button id="BTN_SAVE_ANCHOR" runat="server" CssClass="button1" Width="100px" Visible="False"
								Text="SAVE" onclick="BTN_SAVE_ANCHOR_Click"></asp:button><asp:button id="BTN_UPDATE_ANCHOR" runat="server" CssClass="button1" Width="100px" Visible="False"
								Text="UPDATE" onclick="BTN_UPDATE_ANCHOR_Click"></asp:button><asp:label id="LBL_TEMP" runat="server" Visible="False"></asp:label></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">SUBSIDIARY INFO</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" align="center" width="50%" colSpan="2"><asp:datagrid id="DGR_SUBSIDIARY" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False">
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
									<asp:BoundColumn DataField="PRIORITY" HeaderText="Priority For Bank Pundi">
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
											<asp:LinkButton id="LNK_EDIT" runat="server" CommandName="edit">Edit</asp:LinkButton>
											<asp:LinkButton id="LNK_DELETE" runat="server" CommandName="delete">Delete</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</asp:datagrid></TD>
					</TR>
					<TR>
						<TD class="td" style="HEIGHT: 7px" vAlign="top" width="50%">
							<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_SUB_CIF" runat="server">CIF No. / ID:</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_SUB_CIF" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_SUB_NAME" runat="server">Company Name :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_SUB_NAME" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_SUB_ADDR" runat="server">Address :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_SUB_ADDRESS" runat="server" Width="100%" Height="40px" TextMode="MultiLine"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_SUB_CITY" runat="server">City :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_SUB_CITY" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_SUB_INDUSTRY" runat="server">Industry :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_SUB_INDUSTRY" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_SUB_RELATION" runat="server">Relationship Status :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_SUB_RELATION" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_NUMBER_EMPLOYEE" runat="server">Number of Employee :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NUMBER_EMPLOYEE" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" style="HEIGHT: 7px" vAlign="top" width="50%">
							<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 6px" width="50%"><asp:label id="LBL_TXT_SUB_GROUP_NAME" runat="server">Group Name :</asp:label></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 6px" colSpan="2"><asp:dropdownlist id="DDL_SUB_GROUP_NAME" runat="server" Width="100%" AutoPostBack="True" onselectedindexchanged="DDL_SUB_GROUP_NAME_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_SUB_UNIT_NAME" runat="server">Unit Name :</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2"><asp:dropdownlist id="DDL_SUB_UNIT_NAME" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_SUB_LEN_RELATION" runat="server">Length of relationship :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_SUB_LEN_RELATION" runat="server" Width="100%"></asp:textbox></TD>
									<TD><asp:label id="LBL_TXT_SUB_DAY" runat="server">Years</asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_SUB_PRIORITY" runat="server">Priority for Bank Pundi:</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2"><asp:radiobuttonlist id="RDO_SUB_PRIORITY" runat="server" Width="150px" RepeatDirection="Horizontal">
											<asp:ListItem Value="1">Yes</asp:ListItem>
											<asp:ListItem Value="0">No</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_SUB_MEET" runat="server">Meet in Last Three Month :</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2"><asp:radiobuttonlist id="RDO_SUB_MEET" runat="server" Width="150px" RepeatDirection="Horizontal">
											<asp:ListItem Value="1">Yes</asp:ListItem>
											<asp:ListItem Value="0">No</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_SUB_CONTACT" runat="server">Key Contact:</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2"><asp:textbox id="TXT_SUB_CONTACT" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" colSpan="3" height="10"><asp:label id="LBL_SEQ_SUB" runat="server" Visible="False"></asp:label><asp:button id="BTN_SAVE_SUB" runat="server" CssClass="button1" Width="100px" Text="INSERT" onclick="BTN_SAVE_SUB_Click"></asp:button></TD>
					</TR>
					<!--
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
									<asp:BoundColumn DataField="PRIORITY" HeaderText="Priority For Mandiri">
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
									<TD class="TDBGColorValue" colSpan="2"><asp:dropdownlist id="DDL_VC_GROUP_NAME" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
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
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_VC_PRIORITY" runat="server">Priority for Mandiri:</asp:label></TD>
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
						<TD class="TDBGColor2" vAlign="top" align="center" colSpan="3" height="10"><asp:label id="LBL_SEQ_VC" runat="server" Visible="False"></asp:label><asp:button id="BTN_SAVE_VC" runat="server" Width="100px" CssClass="button1" Text="INSERT"></asp:button></TD>
					</TR>
					-->
					<TR>
						<TD class="tdHeader1" colSpan="2">ANCHOR CLIENT TEAM</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" align="center" width="50%" colSpan="2"><asp:datagrid id="DGR_ANCHOR_TEAM" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="SEQ" Visible="False">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="ROLE" HeaderText="Role">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="TEAM_NAME" HeaderText="Name">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="SIGNED_OFF" HeaderText="Signed-Off Account Plan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="GROUP_NAME" HeaderText="Group Name">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PHONE" HeaderText="Phone">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PRODUCT" HeaderText="Product">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="REMARK" HeaderText="Remark">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Function">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="Linkbutton3" runat="server" CommandName="edit">Edit</asp:LinkButton>
											<asp:LinkButton id="Linkbutton4" runat="server" CommandName="delete">Delete</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</asp:datagrid></TD>
					</TR>
					<TR>
						<TD class="td" style="HEIGHT: 7px" vAlign="top" width="50%">
							<TABLE id="Table8" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_CST_NAME" runat="server"> Role :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_TEAM_ROLE" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_NAME" runat="server">Name :</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2"><asp:textbox id="TXT_TEAM_NAME" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_RDO_TEAM_SIGNED" runat="server">Has Signed-off Account Plan :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:radiobuttonlist id="RDO_TEAM_SIGNED" runat="server" Width="150px" RepeatDirection="Horizontal">
											<asp:ListItem Value="1">Yes</asp:ListItem>
											<asp:ListItem Value="0">No</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD><asp:label id="LBL_TEAMID" runat="server" Visible="False"></asp:label></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" style="HEIGHT: 7px" vAlign="top" width="50%">
							<TABLE id="Table9" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_WORKING_UNIT" runat="server">Group Name :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_TEAM_WORKING_UNIT" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_PHONE" runat="server">Phone Number :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_TEAM_PHONE" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_PRODUCT" runat="server">Product Speciality :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_TEAM_PRODUCT" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_REMARK" runat="server">Remark :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_TEAM_REMARK" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" colSpan="3" height="10"><asp:button id="BTN_SAVE_ANCHOR_TEAM" runat="server" CssClass="button1" Width="100px" Text="INSERT" onclick="BTN_SAVE_ANCHOR_TEAM_Click"></asp:button></TD>
					</TR>
				</TABLE>
				<TABLE id="TBL_COMPANY" width="100%" border="1" runat="server">
				</TABLE>
			</CENTER>
		</FORM>
	</BODY>
</HTML>
