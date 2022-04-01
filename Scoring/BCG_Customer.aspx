<%@ Page language="c#" Codebehind="BCG_Customer.aspx.cs" AutoEventWireup="True" Inherits="SME.Scoring.BCG_Customer" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Scoring</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_all.html" -->
		<!-- #include file="../include/onepost.html" -->
		<!-- #include file="../include/ConfirmBox.html" -->
  </HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="90%" border="0">
					<TR>
						<TD style="HEIGHT: 83px">
							<TABLE id="Table2" style="HEIGHT: 170px" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD colSpan="3">
										<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="100%" border="0">
										</TABLE>
										<TABLE id="Table4" style="WIDTH: 856px" borderColor="black" cellSpacing="1" cellPadding="1"
											width="856" align="center" border="1">
											<TR>
												<TD class="tdHeader1" colSpan="6"><STRONG>Financial Rating </STRONG>
												</TD>
											</TR>
											<TR vAlign="top">
												<TD colSpan="6">
													<TABLE width="100%">
														<!--<TR>
															<TD align="center" bgColor="#e5ebf4" colSpan="6"><STRONG>Financial Rating</STRONG></TD>
														</TR>-->
														<TR>
															<TD>
																<TABLE width="100%">
																	<TR vAlign="top">
																		<TD>
																			<TABLE borderColor="black" width="100%" border="1">
																				<TR>
																					<TD align="center"><STRONG>Ratio</STRONG></TD>
																					<TD align="center"><STRONG>Value</STRONG></TD>
																				</TR>
																				<TR id="CURRENT_RATIO" runat="server">
																					<TD class="TDBGColor1">Current Ratio</TD>
																					<TD><asp:textbox id="TXT_CURRENT_RATIO" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="DEBT_TO_EQUITY" runat="server">
																					<TD class="TDBGColor1">Debt to Equity</TD>
																					<TD><asp:textbox id="TXT_DEBT_TO_EQUITY" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="DEBT_TO_ASSETS" runat="server">
																					<TD class="TDBGColor1">Debt to Assets</TD>
																					<TD><asp:textbox id="TXT_DEBT_TO_ASSETS" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="EBITDA_TO_INTEREST_EXPENSE" runat="server">
																					<TD class="TDBGColor1">EBITDA to Interest Expense</TD>
																					<TD><asp:textbox id="TXT_EBITDA_TO_INTEREST_EXPENSE" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="RETURN_ON_AVERAGE_EQUITY" runat="server">
																					<TD class="TDBGColor1">Return&nbsp;On Average Equity</TD>
																					<TD><asp:textbox id="TXT_RETURN_ON_AVERAGE_EQUITY" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="NET_PROFIT_MARGIN" runat="server">
																					<TD class="TDBGColor1">Net Profit&nbsp;Margin</TD>
																					<TD><asp:textbox id="TXT_NET_PROFIT_MARGIN" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="ASSETS_TURN_OVER" runat="server">
																					<TD class="TDBGColor1">Assets Turnover</TD>
																					<TD><asp:textbox id="TXT_ASSETS_TURN_OVER" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="INVENTORY_TURN_OVER" runat="server">
																					<TD class="TDBGColor1">Inventory Turnover</TD>
																					<TD><asp:textbox id="TXT_INVENTORY_TURN_OVER" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="NET_TRADE_CYCLE" runat="server">
																					<TD class="TDBGColor1">Net Trade Cycle</TD>
																					<TD><asp:textbox id="TXT_NET_TRADE_CYCLE" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="GEARING_RATIO" runat="server">
																					<TD class="TDBGColor1">Gearing Ratio</TD>
																					<TD><asp:textbox id="TXT_GEARING_RATIO" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="NET_REVENUE_PER_MONTH" runat="server">
																					<TD class="TDBGColor1">Net Revenue PerMonth</TD>
																					<TD><asp:textbox id="TXT_NET_REVENUE_PER_MONTH" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="ROA" runat="server">
																					<TD class="TDBGColor1">Return On Assets</TD>
																					<TD><asp:textbox id="TXT_ROA" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="BUSINESS_DEBT_SERVICE_RATIO" runat="server">
																					<TD class="TDBGColor1">Business Debt Service</TD>
																					<TD><asp:textbox id="TXT_BUSINESS_DEBT_SERVICE_RATIO" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="SALES_TO_WORKING_CAPITAL" runat="server">
																					<TD class="TDBGColor1">Sales To Working Capital</TD>
																					<TD><asp:textbox id="TXT_SALES_TO_WORKING_CAPITAL" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="QUICK_RATIO_CORPORATE" runat="server">
																					<TD class="TDBGColor1">Quick Ratio</TD>
																					<TD><asp:textbox id="TXT_QUICK_RATIO_CORPORATE" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="NET_INCOME_GROWTH_CORPORATE" runat="server">
																					<TD class="TDBGColor1">Net Income Growth</TD>
																					<TD><asp:textbox id="TXT_NET_INCOME_GROWTH_CORPORATE" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="INVENTORY_TURN_OVER_CORPORATE" runat="server">
																					<TD class="TDBGColor1">Inventory Turnover</TD>
																					<TD><asp:textbox id="TXT_INVENTORY_TURN_OVER_CORPORATE" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="CURRENT_RATIO_CORPORATE" runat="server">
																					<TD class="TDBGColor1">Current Ratio</TD>
																					<TD><asp:textbox id="TXT_CURRENT_RATIO_CORPORATE" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="DEBT_TO_EQUITY_CORPORATE" runat="server">
																					<TD class="TDBGColor1">Debt To Equity</TD>
																					<TD><asp:textbox id="TXT_DEBT_TO_EQUITY_CORPORATE" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="SALES_ON_CREDIT" runat="server">
																					<TD class="TDBGColor1">Sales On Credit</TD>
																					<TD><asp:textbox id="TXT_SALES_ON_CREDIT" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="SALES_GROWTH_RATE" runat="server">
																					<TD class="TDBGColor1">Sales Growth Rate</TD>
																					<TD><asp:textbox id="TXT_SALES_GROWTH_RATE" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="RETURN_ON_EQUITY" runat="server">
																					<TD class="TDBGColor1">Return On Equity</TD>
																					<TD><asp:textbox id="TXT_RETURN_ON_EQUITY" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="INTEREST_AVERAGE_BANK_DEBT" runat="server">
																					<TD class="TDBGColor1">Interest Avrg Bank Debt</TD>
																					<TD><asp:textbox id="TXT_INTEREST_AVERAGE_BANK_DEBT" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="SALES_AVERAGE_ASSET" runat="server">
																					<TD class="TDBGColor1">Sales Average Asset</TD>
																					<TD><asp:textbox id="TXT_SALES_AVERAGE_ASSET" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="DAYS_RECEIVABLE" runat="server">
																					<TD class="TDBGColor1">Days Receivable</TD>
																					<TD><asp:textbox id="TXT_DAYS_RECEIVABLE" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="DAYS_INVENTORY" runat="server">
																					<TD class="TDBGColor1">Days Inventory</TD>
																					<TD><asp:textbox id="TXT_DAYS_INVENTORY" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="DAYS_PAYABLE" runat="server">
																					<TD class="TDBGColor1">Days Payable</TD>
																					<TD><asp:textbox id="TXT_DAYS_PAYABLE" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="LONG_TERM_LEVERAGE" runat="server">
																					<TD class="TDBGColor1">Long Term Leverage</TD>
																					<TD><asp:textbox id="TXT_LONG_TERM_LEVERAGE" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="DAYS_TRADE_CYCLE" runat="server">
																					<TD class="TDBGColor1">Days Trade Cycle</TD>
																					<TD><asp:textbox id="TXT_DAYS_TRADE_CYCLE" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="TIME_INTEREST_EARN" runat="server">
																					<TD class="TDBGColor1">Time Interest Earn</TD>
																					<TD><asp:textbox id="TXT_TIME_INTEREST_EARN" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																			</TABLE>
																		</TD>
																		<TD>
																			<TABLE borderColor="black" width="100%" border="1">
																				<TR>
																					<TD align="center"><STRONG>Ratio</STRONG></TD>
																					<TD align="center"><STRONG>Value</STRONG></TD>
																				</TR>
																				<TR id="EBITDA_GROWTH" runat="server">
																					<TD class="TDBGColor1">EBITDA Growth</TD>
																					<TD><asp:textbox id="TXT_EBITDA_GROWTH" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="NET_INCOME_GROWTH" runat="server">
																					<TD class="TDBGColor1">Net Income Growth</TD>
																					<TD><asp:textbox id="TXT_NET_INCOME_GROWTH" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="QUICK_RATIO" runat="server">
																					<TD class="TDBGColor1">Quick Ratio</TD>
																					<TD><asp:textbox id="TXT_QUICK_RATIO" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="DEBT_TO_CAPITAL" runat="server">
																					<TD class="TDBGColor1">Debt to Capital</TD>
																					<TD><asp:textbox id="TXT_DEBT_TO_CAPITAL" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="LONG_TERM_DEBT_TO_EQUITY_LTD" runat="server">
																					<TD class="TDBGColor1">Long Term Debt to Equity</TD>
																					<TD><asp:textbox id="TXT_LONG_TERM_DEBT_TO_EQUITY_LTD" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="EBITDA_TO_DEBT" runat="server">
																					<TD class="TDBGColor1">EBITDA to Debt</TD>
																					<TD><asp:textbox id="TXT_EBITDA_TO_DEBT" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="EBITDA_TO_LIABILITIES" runat="server">
																					<TD class="TDBGColor1">EBITDA to Lialibilities</TD>
																					<TD><asp:textbox id="TXT_EBITDA_TO_LIABILITIES" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="RECEIVABLE_TURN_OVER" runat="server">
																					<TD class="TDBGColor1">Receivable Turnover</TD>
																					<TD><asp:textbox id="TXT_RECEIVABLE_TURN_OVER" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="ACCOUNT_RECEIVABLE_TO_LIABILITIES" runat="server">
																					<TD class="TDBGColor1">Acc Receivable To Liabilities</TD>
																					<TD><asp:textbox id="TXT_ACCOUNT_RECEIVABLE_TO_LIABILITIES" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="EQUITY_TO_ASSET" runat="server">
																					<TD class="TDBGColor1">Equity To Asset</TD>
																					<TD><asp:textbox id="TXT_EQUITY_TO_ASSET" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="ASSET_GROWTH" runat="server">
																					<TD class="TDBGColor1">Asset Growth</TD>
																					<TD><asp:textbox id="TXT_ASSET_GROWTH" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="EBITDA_TO_INTEREST_EXPENSE_CORPORATE" runat="server">
																					<TD class="TDBGColor1">Ebitda To Interest Expense</TD>
																					<TD><asp:textbox id="TXT_EBITDA_TO_INTEREST_EXPENSE_CORPORATE" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="ASSETS_TURN_OVER_CORPORATE" runat="server">
																					<TD class="TDBGColor1">Assets Turnover</TD>
																					<TD><asp:textbox id="TXT_ASSETS_TURN_OVER_CORPORATE" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="EBITDA_GROWTH_CORPORATE" runat="server">
																					<TD class="TDBGColor1">Ebitda Growth</TD>
																					<TD><asp:textbox id="TXT_EBITDA_GROWTH_CORPORATE" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="DEBT_TO_ASSETS_CORPORATE" runat="server">
																					<TD class="TDBGColor1">Debt To Assets</TD>
																					<TD><asp:textbox id="TXT_DEBT_TO_ASSETS_CORPORATE" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="RETURN_ON_AVERAGE_EQUITY_CORPORATE" runat="server">
																					<TD class="TDBGColor1">Return On Average Equity</TD>
																					<TD><asp:textbox id="TXT_RETURN_ON_AVERAGE_EQUITY_CORPORATE" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="NET_PROFIT_MARGIN_CORPORATE" runat="server">
																					<TD class="TDBGColor1">Net Profit Margin</TD>
																					<TD><asp:textbox id="TXT_NET_PROFIT_MARGIN_CORPORATE" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="DEBT_TO_CAPITAL_CORPORATE" runat="server">
																					<TD class="TDBGColor1">Debt To Capital</TD>
																					<TD><asp:textbox id="TXT_DEBT_TO_CAPITAL_CORPORATE" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="LONG_TERM_DEBT_TO_EQUITY_LTD_CORPORATE" runat="server">
																					<TD class="TDBGColor1">Long Term&nbsp;Debt To Equity</TD>
																					<TD><asp:textbox id="TXT_LONG_TERM_DEBT_TO_EQUITY_LTD_CORPORATE" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="OPERATING_CASHFLOW_TO_INTERESTEXPENSE" runat="server">
																					<TD class="TDBGColor1">Ebitda&nbsp;To Interest Expense</TD>
																					<TD><asp:textbox id="TXT_OPERATING_CASHFLOW_TO_INTERESTEXPENSE" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="COLLATERAL_COVERAGE" runat="server">
																					<TD class="TDBGColor1">Collateral Coverage</TD>
																					<TD><asp:textbox id="TXT_COLLATERAL_COVERAGE" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="NET_WORTH" runat="server">
																					<TD class="TDBGColor1">Net Worth</TD>
																					<TD><asp:textbox id="TXT_NET_WORTH" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="RETURN_ON_INVESTMENT" runat="server">
																					<TD class="TDBGColor1">Return On Investment</TD>
																					<TD><asp:textbox id="TXT_RETURN_ON_INVESTMENT" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="NET_PRESENT_VALUE" runat="server">
																					<TD class="TDBGColor1">Net Present Value</TD>
																					<TD><asp:textbox id="TXT_NET_PRESENT_VALUE" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="INTEREST_RATE_OF_RETURN" runat="server">
																					<TD class="TDBGColor1">Interest Rate of Return</TD>
																					<TD><asp:textbox id="TXT_INTEREST_RATE_OF_RETURN" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="PAYBACK" runat="server">
																					<TD class="TDBGColor1">Payback</TD>
																					<TD><asp:textbox id="TXT_PAYBACK" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="EBITDA" runat="server">
																					<TD class="TDBGColor1">EBITDA</TD>
																					<TD><asp:textbox id="TXT_EBITDA" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="DEBT_TO_NETWORTH" runat="server">
																					<TD class="TDBGColor1">Debt To Networth</TD>
																					<TD><asp:textbox id="TXT_DEBT_TO_NETWORTH" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="SALES_INCREASE" runat="server">
																					<TD class="TDBGColor1">Sales Growth</TD>
																					<TD><asp:textbox id="TXT_SALES_INCREASE" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="NET_INCOME_INCREASE" runat="server">
																					<TD class="TDBGColor1">Net Income Growth</TD>
																					<TD><asp:textbox id="TXT_NET_INCOME_INCREASE" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="AVERAGE_NET_PROFIT" runat="server">
																					<TD class="TDBGColor1">Average Net Profit</TD>
																					<TD><asp:textbox id="TXT_AVERAGE_NET_PROFIT" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																			</TABLE>
																		</TD>
																		<TD>
																			<TABLE borderColor="black" width="100%" border="1">
																				<TR>
																					<TD align="center"><STRONG>Ratio</STRONG></TD>
																					<TD align="center"><STRONG>Value</STRONG></TD>
																				</TR>
																				<TR id="FIXED_ASSETS_TURN_OVER" runat="server">
																					<TD class="TDBGColor1">Fixed Assets Turnover</TD>
																					<TD><asp:textbox id="TXT_FIXED_ASSETS_TURN_OVER" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="RETURN_ON_AVERAGE_ASSETS" runat="server">
																					<TD class="TDBGColor1">Return on Average Assets</TD>
																					<TD><asp:textbox id="TXT_RETURN_ON_AVERAGE_ASSETS" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="OPERATING_MARGIN" runat="server">
																					<TD class="TDBGColor1">Operating Margin</TD>
																					<TD><asp:textbox id="TXT_OPERATING_MARGIN" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="SALES_GROWTH" runat="server">
																					<TD class="TDBGColor1">Sales Growth</TD>
																					<TD><asp:textbox id="TXT_SALES_GROWTH" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="OPERATING_CASHFLOW_TO_DEBT" runat="server">
																					<TD class="TDBGColor1">Ebitda to Debt</TD>
																					<TD><asp:textbox id="TXT_OPERATING_CASHFLOW_TO_DEBT" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="EFICIENCY_RATIO" runat="server">
																					<TD class="TDBGColor1">Efficiency Ratio</TD>
																					<TD><asp:textbox id="TXT_EFICIENCY_RATIO" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="TOTAL_ASSET" runat="server">
																					<TD class="TDBGColor1">Total Asset</TD>
																					<TD><asp:textbox id="TXT_TOTAL_ASSET" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="ACCOUNT_RECEIVABLE_TO_ASSET" runat="server">
																					<TD class="TDBGColor1">Acc Receivable To Asset</TD>
																					<TD><asp:textbox id="TXT_ACCOUNT_RECEIVABLE_TO_ASSET" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="RECEIVABLES_GROWTH" runat="server">
																					<TD class="TDBGColor1">Acc Receivables Growth</TD>
																					<TD><asp:textbox id="TXT_RECEIVABLES_GROWTH" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="EQUITY_GROWTH" runat="server">
																					<TD class="TDBGColor1">Equity Growth</TD>
																					<TD><asp:textbox id="TXT_EQUITY_GROWTH" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="EBITDA_TO_DEBT_COPRPRATE" runat="server">
																					<TD class="TDBGColor1">Ebitda To Debt</TD>
																					<TD><asp:textbox id="TXT_EBITDA_TO_DEBT_COPRPRATE" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="EBITDA_TO_LIABILITIES_CORPORATE" runat="server">
																					<TD class="TDBGColor1">Ebitda To Liabilities</TD>
																					<TD><asp:textbox id="TXT_EBITDA_TO_LIABILITIES_CORPORATE" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="RECEIVABLE_TURN_OVER_CORPORATE" runat="server">
																					<TD class="TDBGColor1">Receivable Turn Over</TD>
																					<TD><asp:textbox id="TXT_RECEIVABLE_TURN_OVER_CORPORATE" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="FIXED_ASSETS_TURN_OVER_CORPORATE" runat="server">
																					<TD class="TDBGColor1">Fixed Assets Turn Over</TD>
																					<TD><asp:textbox id="TXT_FIXED_ASSETS_TURN_OVER_CORPORATE" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="OPERATING_MARGIN_CORPORATE" runat="server">
																					<TD class="TDBGColor1">Operating Profit&nbsp;Margin</TD>
																					<TD><asp:textbox id="TXT_OPERATING_MARGIN_CORPORATE" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="SALES_GROWTH_CORPORATE" runat="server">
																					<TD class="TDBGColor1">Sales Growth</TD>
																					<TD><asp:textbox id="TXT_SALES_GROWTH_CORPORATE" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="RETURN_ON_AVERAGE_ASSETS_CORPORATE" runat="server">
																					<TD class="TDBGColor1">Return On Average Assets</TD>
																					<TD><asp:textbox id="TXT_RETURN_ON_AVERAGE_ASSETS_CORPORATE" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="NET_WORKING_CAPITAL" runat="server">
																					<TD class="TDBGColor1">Net Working Capital</TD>
																					<TD><asp:textbox id="TXT_NET_WORKING_CAPITAL" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="GROSS_PROFIT_MARGIN" runat="server">
																					<TD class="TDBGColor1">Gross Profit Margin</TD>
																					<TD><asp:textbox id="TXT_GROSS_PROFIT_MARGIN" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="OPERATIONAL_PROFIT_MARGIN" runat="server">
																					<TD class="TDBGColor1">Operating Profit Margin</TD>
																					<TD><asp:textbox id="TXT_OPERATIONAL_PROFIT_MARGIN" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="TOTAL_EQUITY" runat="server">
																					<TD class="TDBGColor1">Total Equity</TD>
																					<TD><asp:textbox id="TXT_TOTAL_EQUITY" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="LEVERAGE" runat="server">
																					<TD class="TDBGColor1">Leverage</TD>
																					<TD><asp:textbox id="TXT_LEVERAGE" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="LONGTERM_DEBT_TO_EQUITY" runat="server">
																					<TD class="TDBGColor1">Long Term Debt To Equity</TD>
																					<TD><asp:textbox id="TXT_LONGTERM_DEBT_TO_EQUITY" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="INTEREST_COVERAGE_RATIO" runat="server">
																					<TD class="TDBGColor1">Interest Coverage Ratio</TD>
																					<TD><asp:textbox id="TXT_INTEREST_COVERAGE_RATIO" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="INTEREST_TO_SALES_RATIO" runat="server">
																					<TD class="TDBGColor1">Interest To Sales Ratio</TD>
																					<TD><asp:textbox id="TXT_INTEREST_TO_SALES_RATIO" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="DEBT_TO_EBITDA" runat="server">
																					<TD class="TDBGColor1">Debt To EBITDA</TD>
																					<TD><asp:textbox id="TXT_DEBT_TO_EBITDA" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="DEBT_SERVICE_COVERAGE" runat="server">
																					<TD class="TDBGColor1">Debt Service Coverage</TD>
																					<TD><asp:textbox id="TXT_DEBT_SERVICE_COVERAGE" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																				<TR id="ACCOUNT_PAYABLE_TURN_OVER" runat="server">
																					<TD class="TDBGColor1">Acc Payable Turn Over</TD>
																					<TD><asp:textbox id="TXT_ACCOUNT_PAYABLE_TURN_OVER" runat="server" Columns="10" ReadOnly="True"></asp:textbox></TD>
																				</TR>
																			</TABLE>
																		</TD>
																	</TR>
																</TABLE>
															</TD>
														</TR>
														<TR>
															<TD>
																<TABLE width="100%">
																	<TR vAlign="top">
																		<TD id="TD_Historical_Financial_Rating" width="33%" runat="server">
																			<TABLE borderColor="black" width="100%" border="1">
																				<TR>
																					<TD align="center" colSpan="2"><STRONG>Historical Financial Rating</STRONG></TD>
																				</TR>
																				<TR>
																					<TD class="TDBGColor1">Historical Financial Score</TD>
																					<TD><asp:label id="LBL_0G024H" runat="server" Font-Bold="True"></asp:label></TD>
																				</TR>
																				<TR>
																					<TD class="TDBGColor1">Historical Financial Score Range</TD>
																					<TD><asp:label id="LBL_0A601H" runat="server" Font-Bold="True"></asp:label></TD>
																				</TR>
																				<TR>
																					<TD class="TDBGColor1">Historical Financial Risk Class</TD>
																					<TD><asp:label id="LBL_0A602H" runat="server" Font-Bold="True"></asp:label></TD>
																				</TR>
																				<TR>
																					<TD class="TDBGColor1">Historical Financial PD Range</TD>
																					<TD><asp:label id="LBL_0A603H" runat="server" Font-Bold="True"></asp:label></TD>
																				</TR>
																			</TABLE>
																		</TD>
																		<TD id="TD_Pre_Financial_Rating" width="33%" runat="server">
																			<TABLE borderColor="black" width="100%" border="1">
																				<TR>
																					<TD align="center" colSpan="2"><STRONG>Pre Financial Rating</STRONG></TD>
																				</TR>
																				<TR>
																					<TD class="TDBGColor1">Pre Financial Score</TD>
																					<TD><asp:label id="LBL_0G024" runat="server" Font-Bold="True"></asp:label></TD>
																				</TR>
																				<TR>
																					<TD class="TDBGColor1">Pre Financial Score Range</TD>
																					<TD><asp:label id="LBL_0A601" runat="server" Font-Bold="True"></asp:label></TD>
																				</TR>
																				<TR>
																					<TD class="TDBGColor1">Pre Financial Risk Class</TD>
																					<TD><asp:label id="LBL_0A602" runat="server" Font-Bold="True"></asp:label></TD>
																				</TR>
																				<TR>
																					<TD class="TDBGColor1">Pre Financial PD Range</TD>
																					<TD><asp:label id="LBL_0A603" runat="server" Font-Bold="True"></asp:label></TD>
																				</TR>
																			</TABLE>
																		</TD>
																		<TD width="34%">
																			<TABLE borderColor="black" width="100%" border="1">
																				<TR>
																					<TD align="center" colSpan="2"><STRONG>Final Financial Rating</STRONG></TD>
																				</TR>
																				<TR>
																					<TD></TD>
																					<TD></TD>
																				</TR>
																				<TR>
																					<TD class="TDBGColor1">Final Financial Score Range</TD>
																					<TD><asp:label id="LBL_0A601F" runat="server" Font-Bold="True"></asp:label></TD>
																				</TR>
																				<TR>
																					<TD class="TDBGColor1">Final Financial Risk Class</TD>
																					<TD><asp:label id="LBL_0A602F" runat="server" Font-Bold="True"></asp:label></TD>
																				</TR>
																				<TR>
																					<TD class="TDBGColor1">Final Financial PD Range</TD>
																					<TD><asp:label id="LBL_0A603F" runat="server" Font-Bold="True"></asp:label></TD>
																				</TR>
																			</TABLE>
																		</TD>
																	</TR>
																</TABLE>
															</TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD class="tdHeader1" colSpan="6"><STRONG>Customer Rating </STRONG>
												</TD>
											</TR>
											<TR vAlign="top">
												<TD colSpan="6">
													<TABLE width="100%">
														<TR id="TR_PAYMENT_CATEGORY_TITLE" runat="server" Visible="False">
															<TD align="center" bgColor="#e5ebf4" colSpan="6"><STRONG>Payment Category</STRONG></TD>
														</TR>
														<TR id="TR_PAYMENT_CATEGORY_DETAIL" runat="server" Visible="False">
															<TD>
																<TABLE width="100%">
																	<TR vAlign="top">
																		<TD>
																			<TABLE borderColor="black" width="100%" border="1">
																				<TR>
																					<TD align="center"><STRONG>Category</STRONG></TD>
																					<TD align="center"><STRONG>Yes Or No</STRONG></TD>
																				</TR>
																				<TR>
																					<TD class="TDBGColor1">Bank Mandiri Customer</TD>
																					<TD><asp:radiobuttonlist id="RDO_CU_PERNAHJDNASABAHBM" runat="server" RepeatDirection="Horizontal">
																							<asp:ListItem Value="1" Selected="True">Yes</asp:ListItem>
																							<asp:ListItem Value="0">No</asp:ListItem>
																						</asp:radiobuttonlist></TD>
																				</TR>
																				<TR>
																					<TD class="TDBGColor1">Present In BI/IBRA Blacklist</TD>
																					<TD><asp:radiobuttonlist id="RDO_AP_BLBIPERNAH" runat="server" RepeatDirection="Horizontal">
																							<asp:ListItem Value="1" Selected="True">Yes</asp:ListItem>
																							<asp:ListItem Value="0">No</asp:ListItem>
																						</asp:radiobuttonlist></TD>
																				</TR>
																				<TR>
																					<TD class="TDBGColor1">Lancar for Over 24 Month</TD>
																					<TD><asp:radiobuttonlist id="RDO_LANCAR_LAST_12BLN" runat="server" RepeatDirection="Horizontal">
																							<asp:ListItem Value="1" Selected="True">Yes</asp:ListItem>
																							<asp:ListItem Value="0">No</asp:ListItem>
																						</asp:radiobuttonlist></TD>
																				</TR>
																			</TABLE>
																		</TD>
																		<TD>
																			<TABLE borderColor="black" width="100%" border="1">
																				<TR>
																					<TD align="center"><STRONG>Category</STRONG></TD>
																					<TD align="center"><STRONG>Yes Or No</STRONG></TD>
																				</TR>
																				<TR>
																					<TD class="TDBGColor1">Prior Default with Losses</TD>
																					<TD><asp:radiobuttonlist id="RDO_PRIORRESULT_LOSS" runat="server" RepeatDirection="Horizontal">
																							<asp:ListItem Value="1" Selected="True">Yes</asp:ListItem>
																							<asp:ListItem Value="0">No</asp:ListItem>
																						</asp:radiobuttonlist></TD>
																				</TR>
																				<TR>
																					<TD class="TDBGColor1">Defaulting Now</TD>
																					<TD><asp:radiobuttonlist id="RDO_REVOLVING_NOW" runat="server" RepeatDirection="Horizontal">
																							<asp:ListItem Value="1" Selected="True">Yes</asp:ListItem>
																							<asp:ListItem Value="0">No</asp:ListItem>
																						</asp:radiobuttonlist></TD>
																				</TR>
																				<TR>
																					<TD class="TDBGColor1">Full Recovery on Previous Default</TD>
																					<TD><asp:radiobuttonlist id="RDO_FULL_RECOVERY" runat="server" RepeatDirection="Horizontal">
																							<asp:ListItem Value="1" Selected="True">Yes</asp:ListItem>
																							<asp:ListItem Value="0">No</asp:ListItem>
																						</asp:radiobuttonlist></TD>
																				</TR>
																			</TABLE>
																		</TD>
																		<TD>
																			<TABLE borderColor="black" width="100%" border="1">
																				<TR>
																					<TD align="center"><STRONG>Category</STRONG></TD>
																					<TD align="center"><STRONG>Yes Or No</STRONG></TD>
																				</TR>
																				<TR>
																					<TD class="TDBGColor1">Default with Losses</TD>
																					<TD><asp:radiobuttonlist id="RDO_DEFAULT_LOSS" runat="server" RepeatDirection="Horizontal">
																							<asp:ListItem Value="1" Selected="True">Yes</asp:ListItem>
																							<asp:ListItem Value="0">No</asp:ListItem>
																						</asp:radiobuttonlist></TD>
																				</TR>
																				<TR>
																					<TD class="TDBGColor1">PH Recommendation</TD>
																					<TD><asp:label id="LBL_A0701" runat="server" Font-Bold="True"></asp:label></TD>
																				</TR>
																			</TABLE>
																		</TD>
																	</TR>
																</TABLE>
															</TD>
														</TR>
														<TR id="TR_QUALITATIVE_ASSIGNMENT_TITLE" runat="server" Visible="False">
															<TD align="center" bgColor="#e5ebf4" colSpan="6"><STRONG>Qualitative Assesment</STRONG></TD>
														</TR>
														<TR id="TR_QUALITATIVE_ASSIGNMENT_DETAIL" runat="server" Visible="False">
															<TD>
																<TABLE width="100%">
																	<TR vAlign="top">
																		<TD>
																			<TABLE borderColor="black" width="100%" border="1">
																				<TR>
																					<TD align="center" colSpan="2"><STRONG>Industrial Review</STRONG></TD>
																				</TR>
																				<TR>
																					<TD class="TDBGColor1">Industrial Code</TD>
																					<TD><asp:dropdownlist id="DDL_INDCODE" runat="server"></asp:dropdownlist></TD>
																				</TR>
																				<TR>
																					<TD class="TDBGColor1">Industrial Score</TD>
																					<TD><asp:label id="LBL_A0801" runat="server" Font-Bold="True"></asp:label></TD>
																				</TR>
																				<TR>
																					<TD class="TDBGColor1">Industrial Recommendation</TD>
																					<TD><asp:label id="LBL_A0802" runat="server" Font-Bold="True"></asp:label></TD>
																				</TR>
																			</TABLE>
																		</TD>
																		<TD>
																			<TABLE borderColor="black" width="100%" border="1">
																				<TR>
																					<TD align="center" colSpan="2"><STRONG>Management Quality</STRONG></TD>
																				</TR>
																				<TR>
																					<TD class="TDBGColor1">Experience/Expertise</TD>
																					<TD><asp:textbox id="TXT_EXPERIENCE" runat="server" ReadOnly="True" Visible="False" TextMode="MultiLine"
																							Width="100%"></asp:textbox></TD>
																				</TR>
																				<TR>
																					<TD class="TDBGColor1">Information Disclosure</TD>
																					<TD><asp:textbox id="TXT_INFODISCLOSURE" runat="server" ReadOnly="True" Visible="False" TextMode="MultiLine"
																							Width="100%"></asp:textbox></TD>
																				</TR>
																				<TR>
																					<TD class="TDBGColor1">Company/Group Reputation</TD>
																					<TD><asp:textbox id="TXT_COMPANYGROUP" runat="server" ReadOnly="True" Visible="False" TextMode="MultiLine"
																							Width="100%"></asp:textbox></TD>
																				</TR>
																				<TR>
																					<TD class="TDBGColor1">Capital Support</TD>
																					<TD><asp:textbox id="TXT_CAPITALSUPPORT" runat="server" ReadOnly="True" Visible="False" TextMode="MultiLine"
																							Width="100%"></asp:textbox></TD>
																				</TR>
																				<TR>
																					<TD class="TDBGColor1">Score</TD>
																					<TD><asp:label id="LBL_G0025" runat="server" Font-Bold="True" Visible="False"></asp:label></TD>
																				</TR>
																			</TABLE>
																		</TD>
																		<TD>
																			<TABLE borderColor="black" width="100%" border="1">
																				<TR>
																					<TD align="center" colSpan="2"><STRONG>Business Outlook</STRONG></TD>
																				</TR>
																				<TR>
																					<TD class="TDBGColor1">Market Share</TD>
																					<TD><asp:textbox id="TXT_MARKETSHARE" runat="server" ReadOnly="True" Visible="False" TextMode="MultiLine"
																							Width="100%"></asp:textbox></TD>
																				</TR>
																				<TR>
																					<TD class="TDBGColor1">Product Comptetitivenes</TD>
																					<TD><asp:textbox id="TXT_PRODUCT_COMPETITIVENESS" runat="server" ReadOnly="True" Visible="False"
																							TextMode="MultiLine" Width="100%"></asp:textbox></TD>
																				</TR>
																				<TR>
																					<TD class="TDBGColor1">Cost Efficiency</TD>
																					<TD><asp:textbox id="TXT_COSTEFICIENCY" runat="server" ReadOnly="True" Visible="False" TextMode="MultiLine"
																							Width="100%"></asp:textbox></TD>
																				</TR>
																				<TR>
																					<TD class="TDBGColor1">3nd Party Dependency</TD>
																					<TD><asp:textbox id="TXT_PARTYDEPENDENCY" runat="server" ReadOnly="True" Visible="False" TextMode="MultiLine"
																							Width="100%"></asp:textbox></TD>
																				</TR>
																				<TR>
																					<TD class="TDBGColor1">Score</TD>
																					<TD><asp:label id="LBL_G0026" runat="server" Font-Bold="True" Visible="False"></asp:label></TD>
																				</TR>
																			</TABLE>
																		</TD>
																	</TR>
																</TABLE>
															</TD>
														</TR>
														<TR>
															<TD>
																<TABLE width="100%">
																	<TR vAlign="top">
																		<TD id="TD_Historical_Qualitative" width="33%" runat="server">
																			<TABLE borderColor="black" width="100%" border="1">
																				<TR>
																					<TD align="center" colSpan="2"><STRONG>Historical Qualitative</STRONG></TD>
																				</TR>
																				<TR>
																					<TD class="TDBGColor1">Qualitative Score</TD>
																					<TD><asp:label id="LBL_G0027H" runat="server" Font-Bold="True"></asp:label></TD>
																				</TR>
																				<TR>
																					<TD class="TDBGColor1">Qualitative Recommendation</TD>
																					<TD><asp:label id="LBL_A0901H" runat="server" Font-Bold="True"></asp:label></TD>
																				</TR>
																			</TABLE>
																		</TD>
																		<TD width="33%">
																			<TABLE borderColor="black" width="100%" border="1">
																				<TR>
																					<TD align="center" colSpan="2"><STRONG>Current Qualitative</STRONG></TD>
																				</TR>
																				<TR>
																					<TD class="TDBGColor1">Qualitative Score</TD>
																					<TD><asp:label id="LBL_G0027" runat="server" Font-Bold="True"></asp:label></TD>
																				</TR>
																				<TR>
																					<TD class="TDBGColor1">Qualitative Recommendation</TD>
																					<TD><asp:label id="LBL_A0901" runat="server" Font-Bold="True"></asp:label></TD>
																				</TR>
																			</TABLE>
																		</TD>
																		<TD width="34%"></TD>
																	</TR>
																</TABLE>
															</TD>
														</TR>
														<TR>
															<TD>
																<TABLE width="100%">
																	<TR id="TR_CUSTOMER_RATING" vAlign="top" runat="server">
																		<TD width="10%"><asp:label id="LBL_A1001" runat="server" Font-Bold="True" Visible="False"></asp:label><asp:label id="LBL_A1002" runat="server" Font-Bold="True" Visible="False"></asp:label><asp:radiobuttonlist id="RDO_A0303ACCEPTCUSTRISKCLASS" runat="server" Visible="False" RepeatDirection="Horizontal"
																				Width="79px" AutoPostBack="True">
																				<asp:ListItem Value="1" Selected="True">Yes</asp:ListItem>
																				<asp:ListItem Value="0">No</asp:ListItem>
																			</asp:radiobuttonlist></TD>
																		<TD width="45%">
																			<TABLE borderColor="black" width="100%" border="1">
																				<TR>
																					<TD class="TDBGColor1">Mandatory Down Grade Applied?</TD>
																					<TD><asp:label id="LBL_CHKSYS1" runat="server" Font-Bold="True"></asp:label></TD>
																				</TR>
																				<TR>
																					<TD class="TDBGColor1">Current Qualitative Score &gt;= Historical Qualitative Score 
																						- 5?</TD>
																					<TD><asp:label id="LBL_CHKSYS2" runat="server" Font-Bold="True"></asp:label></TD>
																				</TR>
																				<TR>
																					<TD class="TDBGColor1">Historical Customer Rating &gt; BB?</TD>
																					<TD><asp:label id="LBL_CHKSYS3" runat="server" Font-Bold="True"></asp:label></TD>
																				</TR>
																			</TABLE>
																		</TD>
																		<TD width="45%">
																			<TABLE borderColor="black" width="100%" border="1">
																				<TR>
																					<TD class="TDBGColor1"><b>Accept Pre Customer Rating?</b></TD>
																					<TD><asp:radiobuttonlist id="RBL_ACCEPT1" runat="server" RepeatDirection="Horizontal" Width="79px" AutoPostBack="True" onselectedindexchanged="RBL_ACCEPT1_SelectedIndexChanged">
																							<asp:ListItem Value="1" Selected="True">Yes</asp:ListItem>
																							<asp:ListItem Value="0">No</asp:ListItem>
																						</asp:radiobuttonlist></TD>
																				</TR>
																				<TR>
																					<TD class="TDBGColor1"><b>Apakah secara umum ratio keuangan debitur masih berada dalam 
																							rata-rata industri?</b></TD>
																					<TD><asp:radiobuttonlist id="RBL_ACCEPT2" runat="server" RepeatDirection="Horizontal" Width="79px" AutoPostBack="True" onselectedindexchanged="RBL_ACCEPT2_SelectedIndexChanged">
																							<asp:ListItem Value="1">Yes</asp:ListItem>
																							<asp:ListItem Value="0" Selected="True">No</asp:ListItem>
																						</asp:radiobuttonlist></TD>
																				</TR>
																				<TR>
																					<TD class="TDBGColor1"><b>Accept Last Customer Rating?</b></TD>
																					<TD><asp:radiobuttonlist id="RBL_ACCEPT3" runat="server" RepeatDirection="Horizontal" Width="79px" AutoPostBack="True" onselectedindexchanged="RBL_ACCEPT3_SelectedIndexChanged">
																							<asp:ListItem Value="1">Yes</asp:ListItem>
																							<asp:ListItem Value="0" Selected="True">No</asp:ListItem>
																						</asp:radiobuttonlist></TD>
																				</TR>
																			</TABLE>
																		</TD>
																	</TR>
																</TABLE>
															</TD>
														</TR>
														<TR>
															<TD>
																<TABLE width="100%">
																	<TR vAlign="top">
																		<TD id="TD_Historical_Customer_Rating" width="33%" runat="server">
																			<TABLE borderColor="black" width="100%" border="1">
																				<TR>
																					<TD align="center" colSpan="2"><STRONG>Historical Customer Rating</STRONG></TD>
																				</TR>
																				<TR>
																					<TD class="TDBGColor1">Historical Customer Risk Class</TD>
																					<TD><asp:label id="LBL_A1003H" runat="server" Font-Bold="True"></asp:label></TD>
																				</TR>
																				<TR>
																					<TD class="TDBGColor1">Historical Probability of Default (PD) Range Customer</TD>
																					<TD width="60"><asp:label id="LBL_A1004H" runat="server" Font-Bold="True"></asp:label></TD>
																				</TR>
																			</TABLE>
																		</TD>
																		<TD id="TD_Pre_Customer_Rating" width="33%" runat="server">
																			<TABLE borderColor="black" width="100%" border="1">
																				<TR>
																					<TD align="center" colSpan="2"><STRONG>Pre Customer Rating</STRONG></TD>
																				</TR>
																				<TR>
																					<TD class="TDBGColor1">Pre Customer Risk Class</TD>
																					<TD><asp:label id="LBL_A1003" runat="server" Font-Bold="True"></asp:label></TD>
																				</TR>
																				<TR>
																					<TD class="TDBGColor1">Pre Probability of Default (PD) Range Customer</TD>
																					<TD width="60"><asp:label id="LBL_A1004" runat="server" Font-Bold="True"></asp:label></TD>
																				</TR>
																			</TABLE>
																		</TD>
																		<TD width="34%">
																			<TABLE borderColor="black" width="100%" border="1">
																				<TR>
																					<TD align="center" colSpan="2"><STRONG>Final Customer Rating</STRONG></TD>
																				</TR>
																				<TR>
																					<TD class="TDBGColor1">Final Customer Risk Class</TD>
																					<TD><asp:label id="LBL_A1003F" runat="server" Font-Bold="True"></asp:label></TD>
																				</TR>
																				<TR>
																					<TD class="TDBGColor1">Final Probability of Default (PD) Range Customer</TD>
																					<TD width="60"><asp:label id="LBL_A1004F" runat="server" Font-Bold="True"></asp:label></TD>
																				</TR>
																			</TABLE>
																		</TD>
																	</TR>
																</TABLE>
															</TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
							<asp:label id="LBL_CU_REF" runat="server" Visible="False"></asp:label><asp:label id="LBL_INDUSTRIALCODE" runat="server" Visible="False"></asp:label><asp:label id="LBL_KET_CODE" runat="server" Visible="False"></asp:label><asp:label id="LBL_NETCOLLATERAL" runat="server" Visible="False"></asp:label><asp:label id="LBL_FACILITY" runat="server" Visible="False"></asp:label><asp:label id="LBL_A0111" runat="server" Visible="False"></asp:label><asp:label id="LBL_A0112" runat="server" Visible="False"></asp:label><asp:label id="LBL_A0113" runat="server" Visible="False"></asp:label><asp:label id="LBL_A0114" runat="server" Visible="False"></asp:label><asp:label id="LBL_A0115" runat="server" Visible="False"></asp:label><asp:label id="LBL_A0116" runat="server" Visible="False"></asp:label><asp:label id="LBL_A0110" runat="server" Visible="False"></asp:label><asp:label id="LBL_A0109" runat="server" Visible="False"></asp:label><asp:label id="LBL_TRY" runat="server" Visible="False">0</asp:label><asp:label id="LBL_CA0001" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0002" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0003" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0004" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0005" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0006" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0007" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0008" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0009" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0010" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0011" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0012" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0013" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0014" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0015" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0016" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0017" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0018" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0019" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0020" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0021" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0022" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0023" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0024" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0025" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0026" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0027" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0028" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0029" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0030" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0031" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0032" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0033" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0034" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0035" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0036" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0037" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0038" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0039" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0040" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0041" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0042" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0043" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0044" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0045" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0046" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0047" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0048" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0049" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0050" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0051" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0052" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0053" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0054" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0055" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0056" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0057" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0058" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0059" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0060" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0061" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0062" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0063" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0064" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0065" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0066" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0067" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0068" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0069" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0070" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0071" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0072" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0073" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0074" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0075" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0076" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0077" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0078" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0079" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0080" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0081" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0082" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0083" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0084" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0085" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0086" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0087" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0088" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0089" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0090" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0091" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0092" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0093" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0101" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0102" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0103" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0104" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0105" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0106" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0107" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0108" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0109" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0110" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0111" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0112" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0113" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0114" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0115" runat="server" Visible="False"></asp:label><asp:label id="LBL_CA0116" runat="server" Visible="False"></asp:label><asp:label id="LBL_CurentDataSta" runat="server" Visible="False"></asp:label><asp:label id="LBL_STA1" runat="server" Visible="False"></asp:label><asp:label id="LBL_STA2" runat="server" Visible="False"></asp:label><asp:label id="LBL_STA3" runat="server" Visible="False"></asp:label><asp:label id="LBL_STA4" runat="server" Visible="False"></asp:label><asp:label id="LBL_STA5" runat="server" Visible="False"></asp:label><asp:label id="LBL_SCOREBCG_SEQ" runat="server" Visible="False"></asp:label><asp:label id="LBL_RATIO_PERIOD" runat="server" Visible="False"></asp:label><asp:label id="LBL_RATIO_TYPE" runat="server" Visible="False"></asp:label><asp:label id="LBL_G0027_TEMP" runat="server" Visible="False"></asp:label><asp:label id="LBL_A0901_TEMP" runat="server" Visible="False"></asp:label></TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" align="center"><asp:button id="btnRate" runat="server" 
                                Width="140px" Text="Rate" CssClass="Button1"></asp:button>&nbsp;
							<%if (Request.QueryString["scr"] != "0") {%>
							<asp:button id="btnUpdateStatus" runat="server" Width="140" Text="Update Status" CssClass="Button1" onclick="btnUpdateStatus_Click"></asp:button>
							<%}%>
						</TD>
					</TR>
				</TABLE>
				<CENTER></CENTER>
		</form>
		<script language="javascript">
		/**
	function update() {
		ans = confirm("Are you sure you want to update?");
		
		if (ans) {
			return true;
		}
		else {
			return false;
		}
	}**/
		</script>
</TR></TBODY></TABLE></CENTER>
	</body>
</HTML>
