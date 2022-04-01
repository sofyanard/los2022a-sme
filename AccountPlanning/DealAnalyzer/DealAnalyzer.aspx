<%@ Page language="c#" Codebehind="DealAnalyzer.aspx.cs" AutoEventWireup="True" Inherits="SME.AccountPlanning.DealAnalyzer.DealAnalyzer" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<TITLE>DealAnalyzer</TITLE>
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
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Deal Analyzer Scenario</B></TD>
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
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_CIF" runat="server">CIF No. :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CIF" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_CUST_NAME" runat="server">Customer Name :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CUST_NAME" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_ADDRESS" runat="server">Address :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_ADDRESS" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_KOTA" runat="server">Kota :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_KOTA" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_GROUP_NAME" runat="server">Customer Group Name :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_GROUP_NAME" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" style="HEIGHT: 7px" vAlign="top" width="50%">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_CUST_DATE" runat="server">Customer Date :</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2"><asp:textbox id="TXT_CUST_DATE" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_RM" runat="server">Relationship Manager :</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2"><asp:textbox id="TXT_RM" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_RM_GROUP_NAME" runat="server">RM Group Name :</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2"><asp:textbox id="TXT_RM_GROUP_NAME" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_RM_UNIT_NAME" runat="server">RM Unit Name :</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2"><asp:textbox id="TXT_RM_UNIT_NAME" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_RELATIONSHIP" runat="server">Length of relationship :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_RELATIONSHIP" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
									<TD><asp:label id="LBL_TXT_DAYS" runat="server">Years</asp:label></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">RUNNING SCENARIO</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" align="center" width="50%" colSpan="2"><asp:datagrid id="DGR_SCENARIO" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="True">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="CIF" HeaderText="CIF"></asp:BoundColumn>
									<asp:BoundColumn DataField="SCENARIO#" HeaderText="No">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="SCENARIO_DESC" HeaderText="Scenario Description">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Function">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="LNK_VIEW" runat="server" CommandName="view">View</asp:LinkButton>&nbsp;
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
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_SCENARIO" runat="server">Scenario Description :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_SCENARIO" runat="server" Width="100%" CssClass="Mandatory"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" style="HEIGHT: 7px" vAlign="top" width="50%">
							<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD vAlign="top" align="left"><asp:button id="BTN_ADD_SCENARIO" runat="server" Text="Add Scenario" onclick="BTN_ADD_SCENARIO_Click"></asp:button><asp:label id="LBL_NOSCENARIO" runat="server" Visible="False"></asp:label><asp:label id="LBL_SCENARIO_SEQ_ID" runat="server" Visible="False"></asp:label></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2"></TD>
					</TR>
					<TR>
						<TD class="td" style="HEIGHT: 7px" vAlign="top" width="50%">
							<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_PRODUCT" runat="server">Product :</asp:label></TD>
									<TD class='A"TDBGColorValue"' width="50%"><asp:dropdownlist id="DDL_PRODUCT" runat="server" Width="100%" CssClass="Mandatory" AutoPostBack="True" onselectedindexchanged="DDL_PRODUCT_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" style="HEIGHT: 7px" vAlign="top" width="50%">
							<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_CURRENCY" runat="server">Currency :</asp:label></TD>
									<TD class='A"TDBGColorValue"' width="50%"><asp:dropdownlist id="DDL_CURRENCY" runat="server" Width="100%" AutoPostBack="True" onselectedindexchanged="DDL_CURRENCY_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2"></TD>
					</TR>
				</TABLE>
				<TABLE id="TBL_PAGE" width="100%" border="0" runat="server">
					<TR id="TR_CASA" runat="server">
						<TD class="td" style="HEIGHT: 7px" vAlign="top" width="50%">
							<TABLE id="Table10" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label1" runat="server">Product :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PRODUCT_CASA" runat="server" Width="100%" Enabled="False" CssClass="Mandatory"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label2" runat="server">Average volume / year :</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2"><asp:textbox id="TXT_VOLUME_CASA" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label3" runat="server">Exchange rate :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_EXCHANGE_CASA" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label5" runat="server">Number of Supplier :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_SUPPLIER_CASA" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label6" runat="server">Administration fee(%) :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_ADMINISTRATION_CASA" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" style="HEIGHT: 7px" vAlign="top" width="50%">
							<TABLE id="Table11" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label9" runat="server">FTP GWM(%) :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_FTP_GWM_CASA" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label10" runat="server">FTP Income(%) :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_FTP_INCOME_CASA" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label11" runat="server">GWM(%) :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_GWM_CASA" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label12" runat="server">Interest rate(%) :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_INTEREST_RATE_CASA" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label13" runat="server">Premium for LPS(%) :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_LPS_CASA" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR id="TR_LOAN" runat="server">
						<TD class="td" style="HEIGHT: 7px" vAlign="top" width="50%">
							<TABLE id="Table8" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_PRODUCTID" runat="server">Product :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PRODUCT_LOAN" runat="server" Width="100%" Enabled="False" CssClass="Mandatory"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_AVERAGE_VOLUME" runat="server">Average Volume per :</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2"><asp:radiobuttonlist id="RDO_AVERAGE_VOLUME" runat="server" Width="150px" RepeatDirection="Horizontal">
											<asp:ListItem Value="Y">Year</asp:ListItem>
											<asp:ListItem Value="L">Loan</asp:ListItem>
											<asp:ListItem Value="M">Mortgage</asp:ListItem>
										</asp:radiobuttonlist><asp:textbox id="TXT_VOLUME_LOAN" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_EXCHANGE" runat="server">Exchange rate :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_EXCHANGE_LOAN" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_AVERAGE_AR_SUBS" runat="server">Average AR / Subsidiaries :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_AVERAGE_AR_SUBS" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_AVERAGE_TRANSACTION" runat="server">Average transaction / card :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_AVERAGE_TRANSACTION_LOAN" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_NO_MORTGAGE" runat="server">Number of mortgage :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NO_MORTGAGE_LOAN" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_NO_CARD" runat="server">Number of card :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NO_CARD_LOAN" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_NO_LOAN" runat="server">Number of loan :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NO_LOAN" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_NO_EMPLOYEE" runat="server">Number of Employee :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NO_EMPLOYEE_LOAN" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" style="HEIGHT: 7px" vAlign="top" width="50%">
							<TABLE id="Table9" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_CKPN" runat="server">CKPN(%) :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CKPN_LOAN" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_FTP_COST" runat="server">FTP Cost(%) :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_FTP_COST_LOAN" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_INTEREST_RATE" runat="server">Interest rate(%) :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_INTEREST_RATE_LOAN" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_PENALTY_FEE" runat="server">Penalty fee(%) :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PENALTY_FEE_LOAN" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_PROVISI_KOMISI" runat="server">Provisi komisi(%) :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PROVISI_KOMISI_LOAN" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_SYNDICATION_FEE" runat="server">Syndication fee(%) :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_SYNDICATION_FEE_LOAN" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_COMMISSION_FEE" runat="server">Commitment fee(%) :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_COMMISSION_FEE_LOAN" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_FTP_CKPN" runat="server">FTP CKPN(%) :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_FTP_CKPN_LOAN" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label14" runat="server">Referral fee income(%) :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_REFERRAL_FEE_LOAN" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_ANNUAL_FEE" runat="server">Annual fee :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_ANNUAL_FEE_LOAN" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR id="TR_BILLPAYMENT" runat="server">
						<TD class="td" style="HEIGHT: 7px" vAlign="top" width="50%">
							<TABLE id="Table12" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label18" runat="server">Product :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PRODUCT_BP" runat="server" Width="100%" Enabled="False" CssClass="Mandatory"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label19" runat="server">Number transaction / month :</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2"><asp:textbox id="TXT_TRANSACTION_BP" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label20" runat="server">Exchange rate :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_EXCHANGE_BP" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label21" runat="server">Type :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_TYPE_BP" runat="server" Width="100%" Enabled="False"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label22" runat="server">Monthly Min Transaction :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_MONTHLY_TXN_BP" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" style="HEIGHT: 7px" vAlign="top" width="50%">
							<TABLE id="Table13" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label26" runat="server">H2H Dev. Fee :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_H2HDEV_BP" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label27" runat="server">IT Cost / transaction :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_ITCOST_BP" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label28" runat="server">Joining Fee :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_JOINING_BP" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label29" runat="server">Non H2H Dev. Fee :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NONH2HDEV_BP" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label30" runat="server">Transaction Fee :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_TRANSACTION_FEE_BP" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR id="TR_TRADE" runat="server">
						<TD class="td" style="HEIGHT: 7px" vAlign="top" width="50%">
							<TABLE id="Table14" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label35" runat="server">Product :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PRODUCT_TRADE" runat="server" Width="100%" Enabled="False" CssClass="Mandatory"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label36" runat="server">Average volume / year :</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2"><asp:textbox id="TXT_VOLUME_TRADE" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label37" runat="server">Average AR / subsidiaries :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_AVERAGE_AR_TRADE" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label38" runat="server">Exchange Rate :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_EXCHANGE_TRADE" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 17px" width="50%"><asp:label id="Label39" runat="server">Cover / Type :</asp:label></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:dropdownlist id="DDL_TYPE_TRADE" runat="server" Width="100%" Enabled="False"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label40" runat="server">Time Period(days) :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PERIOD_TRADE" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label41" runat="server">Total volume / year :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_TOTAL_VOLUME_TRADE" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label42" runat="server">Number of supplier :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_SUPPLIER_TRADE" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label4" runat="server">CKPN(%) :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CKPN_TRADE" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label7" runat="server">FTP CKPN(%) :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_FTP_CKPN_TRADE" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" style="HEIGHT: 7px" vAlign="top" width="50%">
							<TABLE id="Table15" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label43" runat="server">Interest rate(%) :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_INTEREST_TRADE" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label44" runat="server">Provisi Blokir / quartal(%) :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PROVISI_BLOKIR_TRADE" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label45" runat="server">Provisi Fasilitas / quartal(%) :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PROVISI_FASILITAS_TRADE" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label46" runat="server">Provisi Giro Jaminan (USD) :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PROVISI_GIRO_TRADE" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label47" runat="server">Provision(%) :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PROVISION_TRADE" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label48" runat="server">Swift fee(%) :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_SWIFT_TRADE" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label49" runat="server">Unit Cost :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_UNIT_COST_TRADE" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label50" runat="server">Direct IT Cost :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_DIRECT_IT_TRADE" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label51" runat="server">FTP Cost(%) :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_FTP_COST_TRADE" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR id="TR_IBAM" runat="server">
						<TD class="td" style="HEIGHT: 7px" vAlign="top" width="50%">
							<TABLE id="Table16" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label52" runat="server">Product :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PRODUCT_IBAM" runat="server" Width="100%" Enabled="False" CssClass="Mandatory"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label53" runat="server">Average volume / referral :</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2"><asp:textbox id="TXT_AVE_VOLUME_IBAM" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label54" runat="server">Total volume / year :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_TOTAL_VOLUME_IBAM" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label55" runat="server">Exchange rate :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_EXCHANGE_IBAM" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label56" runat="server">Number of referral :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_REFERRAL_IBAM" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" style="HEIGHT: 7px" vAlign="top" width="50%">
							<TABLE id="Table17" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label60" runat="server">Other Cost(%) :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_OTHER_COST_IBAM" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label61" runat="server">Service fee(%) :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_SERVICE_FEE_IBAM" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label62" runat="server">Spread(%) :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_SPREAD_IBAM" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label63" runat="server">Referral fee income(%) :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_REFERRAL_FEE_IBAM" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR id="TR_PAYMENT" runat="server">
						<TD class="td" style="HEIGHT: 7px" vAlign="top" width="50%">
							<TABLE id="Table18" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label69" runat="server">Product :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PRODUCT_PAYMENT" runat="server" Width="100%" Enabled="False" CssClass="Mandatory"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label70" runat="server">Average vol. / transaction :</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2"><asp:textbox id="TXT_AVERAGE_PAYMENT" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label71" runat="server">Exchange rate :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_EXCHANGE_PAYMENT" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label72" runat="server">Number of transaction / year :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_TRANSACTION_PAYMENT" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label73" runat="server">Interest rate(%) :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_INTEREST_PAYMENT" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label74" runat="server">Provision(%) :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PROVISION_PAYMENT" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label75" runat="server">Correspondent Cost :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CORRESPONDENT_COST_PAYMENT" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label76" runat="server">Correspondent fee :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CORRESPONDENT_FEE_PAYMENT" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" style="HEIGHT: 7px" vAlign="top" width="50%">
							<TABLE id="Table19" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label77" runat="server">BI Cost :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_BI_PAYMENT" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label78" runat="server">Cable Cost :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CABLE_COST_PAYMENT" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label79" runat="server">Cable Fee :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CABLE_FEE_PAYMENT" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label80" runat="server">Fixed Fee :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_FIXED_FEE_PAYMENT" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label81" runat="server">Indirect Cost / transaction :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_INDIRECT_PAYMENT" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label82" runat="server">IT Cost / transaction :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_IT_COST_PAYMENT" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label8" runat="server">Minimum provision :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_MINIMUM_PROVISION_PAYMENT" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label83" runat="server">Maximum provision :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_MAXIMUM_PROVISION_PAYMENT" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR id="TR_FUNDING" runat="server">
						<TD class="td" style="HEIGHT: 7px" vAlign="top" width="50%">
							<TABLE id="Table20" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label86" runat="server">Product :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PRODUCT_FUNDING" runat="server" Width="100%" Enabled="False" CssClass="Mandatory"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label87" runat="server">Number of payroll :</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2"><asp:textbox id="TXT_PAYROLL_FUNDING" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label88" runat="server">Number pickup / year :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PICKUP_FUNDING" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label89" runat="server">Number transaction / year :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_TRANSACTION_FUNDING" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label90" runat="server">Rate / employee :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_RATE_FUNDING" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label91" runat="server">Cash Processing fee / day :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PROCESSING_FEE_FUNDING" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label92" runat="server">Service Cost :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_SERVICE_COST_FUNDING" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" style="HEIGHT: 7px" vAlign="top" width="50%">
							<TABLE id="Table21" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label94" runat="server">Cash-in-Shift / day :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CASHIN_SHIFT_FUNDING" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label95" runat="server">Cash-in-Transit Cost / day :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CASHIN_TRANSIT_FUNDING" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label96" runat="server">Collection Cost / day :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_COLLECTION_FUNDING" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label97" runat="server">Fee / transaction :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_FEE_FUNDING" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label98" runat="server">IT Cost / transaction :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_IT_COST_FUNDING" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label99" runat="server">Minimum fee / Process :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_MINIMUM_FEE_FUNDING" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2"><asp:button id="BTN_CALCULATE" runat="server" Width="100px" CssClass="button1" Text="Calculate"
								Visible="False"></asp:button>&nbsp;&nbsp;
							<asp:button id="BTN_INSERT" runat="server" Width="100px" CssClass="button1" Text="Insert" onclick="BTN_INSERT_Click"></asp:button></TD>
					</TR>
				</TABLE>
				<TABLE width="100%" border="0">
					<TR>
						<TD class="td" vAlign="top" align="center" width="50%" colSpan="2"><asp:datagrid id="DGR_SAVE_SCENARIO" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="True">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="SEQ_SCENARIO" HeaderText="Seq#">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="SCENARIO#" Visible="False">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CIF#" Visible="False">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PRODUCTID" Visible="False">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PRODUCT_NM" HeaderText="Product Name">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="NII" HeaderText="Net Interest Income" DataFormatString="{0:00.00,00}">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="FBI" HeaderText="Fee Based Income" DataFormatString="{0:00.00,00}">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="NET_INCOME" HeaderText="Net Income" DataFormatString="{0:00.00,00}">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="INCOME_COST_CUST" HeaderText="Income / Cost for Customer" DataFormatString="{0:00.00,00}">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Function">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="LNK_EDIT" runat="server" CommandName="edit">Edit</asp:LinkButton>
											<asp:LinkButton id="LNK_DELETE2" runat="server" CommandName="delete">Delete</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</asp:datagrid></TD>
					</TR>
					<!--<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2"><asp:button id="BTN_SAVE" runat="server" CssClass="button1" Text="SAVE SCENARIO" Visible="False"></asp:button></TD>
					</TR>--></TABLE>
			</CENTER>
		</FORM>
	</BODY>
</HTML>
