<%@ Page language="c#" Codebehind="ActionPlan.aspx.cs" AutoEventWireup="True" Inherits="SME.AccountPlanning.AccountPlanSetup.ActionPlan" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>ActionPlan</TITLE>
		<META content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
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
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Action Plan</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/image/Back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../../Body.aspx"><IMG height="25" src="../../Image/MainMenu.jpg" width="106"></A>
							<A href="../../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A>
						</TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">ANCHOR INFO</TD>
					</TR>
					<TR>
						<TD class="td" style="HEIGHT: 7px" vAlign="top" width="50%">
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_CIF" runat="server">CIF No. :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CIF" runat="server" Enabled="False" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_CUST_NAME" runat="server">Customer Name :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CUST_NAME" runat="server" Enabled="False" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_ADDRESS" runat="server">Address :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_ADDRESS" runat="server" Enabled="False" Width="100%" Height="40px" TextMode="MultiLine"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_KOTA" runat="server">Kota :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_KOTA" runat="server" Enabled="False" Width="100%"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" style="HEIGHT: 7px" vAlign="top" width="50%">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_CUST_DATE" runat="server">Customer Date :</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2"><asp:textbox id="TXT_CUST_DATE" runat="server" Enabled="False" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_RM" runat="server">Relationship Manager :</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2"><asp:textbox id="TXT_RM" runat="server" Enabled="False" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_GROUP_NAME" runat="server">Group Name :</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2"><asp:textbox id="TXT_GROUP_NAME" runat="server" Enabled="False" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_UNIT_NAME" runat="server">Unit Name :</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2"><asp:textbox id="TXT_UNIT_NAME" runat="server" Enabled="False" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_RELATIONSHIP" runat="server">Length of relationship :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_RELATIONSHIP" runat="server" Enabled="False" Width="100%"></asp:textbox></TD>
									<TD><asp:label id="LBL_TXT_DAYS" runat="server">Years</asp:label></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD align="left" colSpan="2"></TD>
					</TR>
					<TR>
						<TD class="td" style="HEIGHT: 7px" vAlign="top" width="50%">
							<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label1" runat="server" Font-Bold="True" Font-Size="150%">Company Name :</asp:label></TD>
									<TD class="TDBGColorValue" width="50%"><asp:dropdownlist id="DDL_COMPANY" runat="server" Width="100%" AutoPostBack="True" onselectedindexchanged="DDL_COMPANY_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR id="TR_COMPANY_HEADER" runat="server">
						<TD class="tdHeader1" colSpan="2"><asp:label id="LBL_COMPANY_HEADER" runat="server"></asp:label></TD>
					</TR>
					<TR id="TR_COMPANY_GRID" runat="server">
						<TD class="td" vAlign="top" align="center" width="50%" colSpan="2"><asp:datagrid id="DGR_COMPANY" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="SEQ" Visible="False">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PRODUCTID" Visible="False">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PRODUCTDESC" HeaderText="Product Name">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="OPPORTUNITYDESC" HeaderText="Opportunity Description">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PIC_TEAM" HeaderText="Overall PIC (Anchor Team Members)">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="ACTION_STEP" HeaderText="Action Step">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="START_DATE" HeaderText="Start Date">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="DUE_DATE" HeaderText="Due Date">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PIC_NAME" HeaderText="PIC (Group/Dept)">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="SUPPORT_DESC" HeaderText="Support Required">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
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
					<TR id="TR_COMPANY_FIELD" runat="server">
						<TD class="td" style="HEIGHT: 7px" vAlign="top" width="50%">
							<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label3" runat="server">Product :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_PRODUCT" runat="server" Width="100%" AutoPostBack="True" onselectedindexchanged="DDL_PRODUCT_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label4" runat="server">Overall PIC Name (Anchor Team Members) :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_OVERALL_PIC" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label5" runat="server">Action Step :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_ACTION_STEP" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label12" runat="server">Opportunity Description :</asp:label></TD>
									<!--<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_OPP_DESC" runat="server" Width="100%"></asp:dropdownlist></TD>-->
									<TD class="TDBGColorValue"><asp:textbox id="TXT_OPP_DESC" runat="server" Width="100%" Height="40px" TextMode="MultiLine"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" style="HEIGHT: 7px" vAlign="top" width="50%">
							<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label6" runat="server">PIC Unit :</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2"><asp:textbox id="TXT_PIC" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label2" runat="server">Start Date :</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2">
										<asp:textbox onkeypress="return numbersonly()" id="TXT_START_DAY" runat="server" Width="24px"
											MaxLength="2" Columns="4"></asp:textbox>
										<asp:dropdownlist id="DDL_START_MONTH" runat="server"></asp:dropdownlist>
										<asp:textbox onkeypress="return numbersonly()" id="TXT_START_YEAR" runat="server" Width="36px"
											MaxLength="4" Columns="4"></asp:textbox>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label7" runat="server">Due Date :</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2">
										<asp:textbox onkeypress="return numbersonly()" id="TXT_DUE_DAY" runat="server" Width="24px" MaxLength="2"
											Columns="4"></asp:textbox>
										<asp:dropdownlist id="DDL_DUE_MONTH" runat="server"></asp:dropdownlist>
										<asp:textbox onkeypress="return numbersonly()" id="TXT_DUE_YEAR" runat="server" Width="36px"
											MaxLength="4" Columns="4"></asp:textbox>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label8" runat="server">Support Required  :</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2"><asp:textbox id="TXT_SUPPORT_REQUIRED" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR id="TR_COMPANY_BTN" runat="server">
						<TD class="TDBGColor2" vAlign="top" align="center" colSpan="3" height="10">
							<asp:label id="LBL_SEQ" runat="server" Visible="False"></asp:label>
							<asp:button id="BTN_SAVE" runat="server" Width="100px" CssClass="button1" Text="INSERT" onclick="BTN_SAVE_Click"></asp:button></TD>
					</TR>
				</TABLE>
				<TABLE id="TBL_COMPANY" width="100%" border="1" runat="server">
				</TABLE>
			</CENTER>
		</FORM>
	</BODY>
</HTML>
