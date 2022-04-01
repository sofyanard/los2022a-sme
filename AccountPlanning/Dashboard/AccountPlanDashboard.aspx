<%@ Page language="c#" Codebehind="AccountPlanDashboard.aspx.cs" AutoEventWireup="True" Inherits="SME.AccountPlanning.Dashboard.AccountPlanDashboard" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<TITLE>AccountPlanDashboard</TITLE>
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
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>PERFORMANCE DASHBOARD</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/image/Back.jpg"></asp:imagebutton><A href="../../Body.aspx"><IMG height="25" src="../../Image/MainMenu.jpg" width="106"></A>
							<A href="../../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A>
						</TD>
					</TR>
					<TR>
						<TD vAlign="top" align="center" width="100%" colSpan="2"></TD>
					</TR>
					<TR>
						<TD align="center" colSpan="2">
							<TABLE class="td" id="Table3" style="WIDTH: 590px; HEIGHT: 140px" height="140" cellSpacing="1"
								cellPadding="1" width="590" border="1">
								<TR>
									<TD class="tdHeader1">Search Criteria</TD>
								</TR>
								<TR>
									<TD vAlign="top" align="center">
										<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD class="TDBGColor1" width="40%">Customer Group Name</TD>
												<TD width="5">:</TD>
												<TD class="TDBGColorValue" width="60%"><asp:dropdownlist id="DDL_CUST_GROUP" runat="server" Width="85%"></asp:dropdownlist>
												</TD>
											</TR>
											<TR>
												<TD></TD>
											</TR>
											<TR>
												<TD vAlign="top" align="center" colSpan="3" height="10">
													<asp:button id="BTN_FIND" runat="server" Width="180px" Text="Find" CssClass="button1"></asp:button>
												</TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" colSpan="2">
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
								<TBODY>
									<TR>
										<TD class="tdSmallHeader" align="center" width="15%" rowSpan="2"></TD>
										<TD class="tdSmallHeader" align="center" width="5%" rowSpan="2">Unit of Measurement</TD>
										<TD class="tdSmallHeader" align="center" colSpan="2">Target</TD>
										<TD class="tdSmallHeader" align="center" width="5%" rowSpan="2">Target Growth</TD>
										<TD class="tdSmallHeader" align="center" colSpan="12">Accumulative Realization</TD>
										<TD class="tdSmallHeader" align="center" width="5%" rowSpan="2">% YTD Realization</TD>
										<TD class="tdSmallHeader" align="center" width="5%" rowSpan="2">% YTD Annualized 
											Realization</TD>
										<TD class="tdSmallHeader" align="center" width="5%" rowSpan="2">Growth</TD>
									</TR>
									<TR>
										<TD class="tdSmallHeader" align="center" width="5%">Last Year</TD>
										<TD class="tdSmallHeader" align="center" width="5%">This Year</TD>
										<TD class="tdSmallHeader" align="center">Jan</TD>
										<TD class="tdSmallHeader" align="center">Feb</TD>
										<TD class="tdSmallHeader" align="center">Mar</TD>
										<TD class="tdSmallHeader" align="center">Apr</TD>
										<TD class="tdSmallHeader" align="center">Mei</TD>
										<TD class="tdSmallHeader" align="center">Jun</TD>
										<TD class="tdSmallHeader" align="center">Jul</TD>
										<TD class="tdSmallHeader" align="center">Ags</TD>
										<TD class="tdSmallHeader" align="center">Sep</TD>
										<TD class="tdSmallHeader" align="center">Okt</TD>
										<TD class="tdSmallHeader" align="center">Nov</TD>
										<TD class="tdSmallHeader" align="center">Des</TD>
									</TR>
									<TR>
										<TD vAlign="middle" align="left" width="100%" colSpan="20"><b>WHOLESALE VOLUME</b></TD>
									</TR>
									<!--Line 1-->
									<TR>
										<TD class="TDBGColor" style="PADDING-RIGHT: 40px" align="left" width="100%" colSpan="20"><STRONG>&nbsp;&nbsp;&nbsp;Focus 
												Companies</STRONG></TD>
									</TR>
									<TR>
										<TD style="PADDING-LEFT: 40px" align="left" width="15%">CASA</TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_F1_1" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_F1_2" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_F1_3" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_F1_4" runat="server" Width="5%"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F1_5" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F1_6" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F1_7" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F1_8" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F1_9" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F1_10" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F1_11" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F1_12" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F1_13" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F1_14" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F1_15" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F1_16" runat="server"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_F1_17" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_F1_18" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_F1_19" runat="server" Width="5%"></asp:label></TD>
									</TR>
									<TR>
										<TD style="PADDING-LEFT: 40px" align="left" width="15%">Time Deposit</TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_F2_1" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_F2_2" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_F2_3" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_F2_4" runat="server" Width="5%"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F2_5" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F2_6" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F2_7" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F2_8" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F2_9" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F2_10" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F2_11" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F2_12" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F2_13" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F2_14" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F2_15" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F2_16" runat="server"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_F2_17" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_F2_18" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_F2_19" runat="server" Width="5%"></asp:label></TD>
									</TR>
									<TR>
										<TD style="PADDING-LEFT: 40px" align="left" width="15%">Working Capital Loan</TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_F3_1" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_F3_2" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_F3_3" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_F3_4" runat="server" Width="5%"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F3_5" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F3_6" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F3_7" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F3_8" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F3_9" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F3_10" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F3_11" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F3_12" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F3_13" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F3_14" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F3_15" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F3_16" runat="server"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_F3_17" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_F3_18" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_F3_19" runat="server" Width="5%"></asp:label></TD>
									</TR>
									<TR>
										<TD style="PADDING-LEFT: 40px" align="left" width="15%">Investment Loan</TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_F4_1" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_F4_2" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_F4_3" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_F4_4" runat="server" Width="5%"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F4_5" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F4_6" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F4_7" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F4_8" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F4_9" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F4_10" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F4_11" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F4_12" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F4_13" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F4_14" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F4_15" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F4_16" runat="server"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_F4_17" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_F4_18" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_F4_19" runat="server" Width="5%"></asp:label></TD>
									</TR>
									<TR>
										<TD style="PADDING-LEFT: 40px" align="left" width="15%">Supply Chain Financing</TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_F5_1" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_F5_2" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_F5_3" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_F5_4" runat="server" Width="5%"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F5_5" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F5_6" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F5_7" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F5_8" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F5_9" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F5_10" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F5_11" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F5_12" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F5_13" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F5_14" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F5_15" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F5_16" runat="server"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_F5_17" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_F5_18" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_F5_19" runat="server" Width="5%"></asp:label></TD>
									</TR>
									<TR>
										<TD style="PADDING-LEFT: 40px" align="left" width="15%">FX &amp; Derivatives</TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_F6_1" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_F6_2" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_F6_3" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_F6_4" runat="server" Width="5%"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F6_5" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F6_6" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F6_7" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F6_8" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F6_9" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F6_10" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F6_11" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F6_12" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F6_13" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F6_14" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F6_15" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F6_16" runat="server"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_F6_17" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_F6_18" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_F6_19" runat="server" Width="5%"></asp:label></TD>
									</TR>
									<TR>
										<TD style="PADDING-LEFT: 40px" align="left" width="15%">LC &amp; SKBDN</TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_F7_1" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_F7_2" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_F7_3" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_F7_4" runat="server" Width="5%"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F7_5" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F7_6" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F7_7" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F7_8" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F7_9" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F7_10" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F7_11" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F7_12" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F7_13" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F7_14" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F7_15" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F7_16" runat="server"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_F7_17" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_F7_18" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_F7_19" runat="server" Width="5%"></asp:label></TD>
									</TR>
									<TR>
										<TD style="PADDING-LEFT: 40px" align="left" width="15%">Bank Guarantee</TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_F8_1" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_F8_2" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_F8_3" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_F8_4" runat="server" Width="5%"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F8_5" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F8_6" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F8_7" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F8_8" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F8_9" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F8_10" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F8_11" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F8_12" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F8_13" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F8_14" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F8_15" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F8_16" runat="server"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_F8_17" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_F8_18" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_F8_19" runat="server" Width="5%"></asp:label></TD>
									</TR>
									<TR>
										<TD style="PADDING-LEFT: 40px" align="left" width="15%">Remittance</TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_F9_1" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_F9_2" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_F9_3" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_F9_4" runat="server" Width="5%"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F9_5" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F9_6" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F9_7" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F9_8" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F9_9" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F9_10" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F9_11" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F9_12" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F9_13" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F9_14" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F9_15" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_F9_16" runat="server"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_F9_17" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_F9_18" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_F9_19" runat="server" Width="5%"></asp:label></TD>
									</TR>
									<!--Line 2-->
									<TR>
										<TD class="TDBGColor" style="PADDING-RIGHT: 40px" align="left" width="100%" colSpan="20"><STRONG>&nbsp;&nbsp;&nbsp;Non 
												Focus Companies</STRONG></TD>
									</TR>
									<TR>
										<TD style="PADDING-LEFT: 40px" align="left" width="15%">CASA</TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_NF1_1" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_NF1_2" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_NF1_3" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_NF1_4" runat="server" Width="5%"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF1_5" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF1_6" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF1_7" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF1_8" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF1_9" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF1_10" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF1_11" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF1_12" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF1_13" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF1_14" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF1_15" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF1_16" runat="server"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_NF1_17" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_NF1_18" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_NF1_19" runat="server" Width="5%"></asp:label></TD>
									</TR>
									<TR>
										<TD style="PADDING-LEFT: 40px" align="left" width="15%">Time Deposit</TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_NF2_1" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_NF2_2" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_NF2_3" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_NF2_4" runat="server" Width="5%"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF2_5" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF2_6" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF2_7" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF2_8" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF2_9" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF2_10" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF2_11" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF2_12" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF2_13" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF2_14" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF2_15" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF2_16" runat="server"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_NF2_17" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_NF2_18" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_NF2_19" runat="server" Width="5%"></asp:label></TD>
									</TR>
									<TR>
										<TD style="PADDING-LEFT: 40px" align="left" width="15%">Working Capital Loan</TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_NF3_1" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_NF3_2" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_NF3_3" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_NF3_4" runat="server" Width="5%"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF3_5" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF3_6" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF3_7" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF3_8" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF3_9" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF3_10" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF3_11" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF3_12" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF3_13" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF3_14" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF3_15" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF3_16" runat="server"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_NF3_17" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_NF3_18" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_NF3_19" runat="server" Width="5%"></asp:label></TD>
									</TR>
									<TR>
										<TD style="PADDING-LEFT: 40px" align="left" width="15%">Investment Loan</TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_NF4_1" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_NF4_2" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_NF4_3" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_NF4_4" runat="server" Width="5%"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF4_5" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF4_6" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF4_7" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF4_8" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF4_9" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF4_10" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF4_11" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF4_12" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF4_13" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF4_14" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF4_15" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF4_16" runat="server"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_NF4_17" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_NF4_18" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_NF4_19" runat="server" Width="5%"></asp:label></TD>
									</TR>
									<TR>
										<TD style="PADDING-LEFT: 40px" align="left" width="15%">Supply Chain Financing</TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_NF5_1" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_NF5_2" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_NF5_3" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_NF5_4" runat="server" Width="5%"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF5_5" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF5_6" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF5_7" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF5_8" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF5_9" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF5_10" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF5_11" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF5_12" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF5_13" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF5_14" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF5_15" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF5_16" runat="server"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_NF5_17" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_NF5_18" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_NF5_19" runat="server" Width="5%"></asp:label></TD>
									</TR>
									<TR>
										<TD style="PADDING-LEFT: 40px" align="left" width="15%">FX &amp; Derivatives</TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_NF6_1" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_NF6_2" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_NF6_3" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_NF6_4" runat="server" Width="5%"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF6_5" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF6_6" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF6_7" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF6_8" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF6_9" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF6_10" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF6_11" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF6_12" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF6_13" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF6_14" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF6_15" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF6_16" runat="server"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_NF6_17" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_NF6_18" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_NF6_19" runat="server" Width="5%"></asp:label></TD>
									</TR>
									<TR>
										<TD style="PADDING-LEFT: 40px" align="left" width="15%">LC &amp; SKBDN</TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_NF7_1" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_NF7_2" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_NF7_3" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_NF7_4" runat="server" Width="5%"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF7_5" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF7_6" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF7_7" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF7_8" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF7_9" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF7_10" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF7_11" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF7_12" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF7_13" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF7_14" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF7_15" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF7_16" runat="server"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_NF7_17" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_NF7_18" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_NF7_19" runat="server" Width="5%"></asp:label></TD>
									</TR>
									<TR>
										<TD style="PADDING-LEFT: 40px" align="left" width="15%">Bank Guarantee</TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_NF8_1" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_NF8_2" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_NF8_3" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_NF8_4" runat="server" Width="5%"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF8_5" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF8_6" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF8_7" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF8_8" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF8_9" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF8_10" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF8_11" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF8_12" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF8_13" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF8_14" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF8_15" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF8_16" runat="server"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_NF8_17" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_NF8_18" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_NF8_19" runat="server" Width="5%"></asp:label></TD>
									</TR>
									<TR>
										<TD style="PADDING-LEFT: 40px" align="left" width="15%">Remittance</TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_NF9_1" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_NF9_2" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_NF9_3" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_NF9_4" runat="server" Width="5%"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF9_5" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF9_6" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF9_7" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF9_8" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF9_9" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF9_10" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF9_11" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF9_12" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF9_13" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF9_14" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF9_15" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_NF9_16" runat="server"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_NF9_17" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_NF9_18" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_NF9_19" runat="server" Width="5%"></asp:label></TD>
									</TR>
									<!--Line 3-->
									<TR>
										<TD class="TDBGColor" style="PADDING-RIGHT: 40px" align="left" width="100%" colSpan="20"><STRONG>&nbsp;&nbsp;&nbsp;Total</STRONG></TD>
									</TR>
									<TR>
										<TD style="PADDING-LEFT: 40px" align="left" width="15%">CASA</TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_T1_1" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_T1_2" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_T1_3" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_T1_4" runat="server" Width="5%"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T1_5" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T1_6" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T1_7" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T1_8" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T1_9" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T1_10" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T1_11" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T1_12" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T1_13" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T1_14" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T1_15" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T1_16" runat="server"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_T1_17" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_T1_18" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_T1_19" runat="server" Width="5%"></asp:label></TD>
									</TR>
									<TR>
										<TD style="PADDING-LEFT: 40px" align="left" width="15%">Time Deposit</TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_T2_1" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_T2_2" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_T2_3" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_T2_4" runat="server" Width="5%"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T2_5" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T2_6" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T2_7" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T2_8" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T2_9" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T2_10" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T2_11" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T2_12" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T2_13" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T2_14" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T2_15" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T2_16" runat="server"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_T2_17" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_T2_18" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_T2_19" runat="server" Width="5%"></asp:label></TD>
									</TR>
									<TR>
										<TD style="PADDING-LEFT: 40px" align="left" width="15%">Working Capital Loan</TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_T3_1" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_T3_2" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_T3_3" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_T3_4" runat="server" Width="5%"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T3_5" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T3_6" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T3_7" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T3_8" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T3_9" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T3_10" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T3_11" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T3_12" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T3_13" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T3_14" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T3_15" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T3_16" runat="server"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_T3_17" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_T3_18" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_T3_19" runat="server" Width="5%"></asp:label></TD>
									</TR>
									<TR>
										<TD style="PADDING-LEFT: 40px" align="left" width="15%">Investment Loan</TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_T4_1" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_T4_2" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_T4_3" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_T4_4" runat="server" Width="5%"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T4_5" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T4_6" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T4_7" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T4_8" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T4_9" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T4_10" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T4_11" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T4_12" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T4_13" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T4_14" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T4_15" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T4_16" runat="server"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_T4_17" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_T4_18" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_T4_19" runat="server" Width="5%"></asp:label></TD>
									</TR>
									<TR>
										<TD style="PADDING-LEFT: 40px" align="left" width="15%">Supply Chain Financing</TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_T5_1" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_T5_2" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_T5_3" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_T5_4" runat="server" Width="5%"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T5_5" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T5_6" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T5_7" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T5_8" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T5_9" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T5_10" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T5_11" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T5_12" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T5_13" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T5_14" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T5_15" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T5_16" runat="server"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_T5_17" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_T5_18" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_T5_19" runat="server" Width="5%"></asp:label></TD>
									</TR>
									<TR>
										<TD style="PADDING-LEFT: 40px" align="left" width="15%">FX &amp; Derivatives</TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_T6_1" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_T6_2" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_T6_3" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_T6_4" runat="server" Width="5%"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T6_5" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T6_6" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T6_7" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T6_8" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T6_9" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T6_10" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T6_11" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T6_12" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T6_13" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T6_14" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T6_15" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T6_16" runat="server"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_T6_17" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_T6_18" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_T6_19" runat="server" Width="5%"></asp:label></TD>
									</TR>
									<TR>
										<TD style="PADDING-LEFT: 40px" align="left" width="15%">LC &amp; SKBDN</TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_T7_1" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_T7_2" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_T7_3" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_T7_4" runat="server" Width="5%"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T7_5" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T7_6" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T7_7" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T7_8" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T7_9" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T7_10" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T7_11" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T7_12" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T7_13" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T7_14" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T7_15" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T7_16" runat="server"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_T7_17" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_T7_18" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_T7_19" runat="server" Width="5%"></asp:label></TD>
									</TR>
									<TR>
										<TD style="PADDING-LEFT: 40px" align="left" width="15%">Bank Guarantee</TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_T8_1" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_T8_2" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_T8_3" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_T8_4" runat="server" Width="5%"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T8_5" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T8_6" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T8_7" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T8_8" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T8_9" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T8_10" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T8_11" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T8_12" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T8_13" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T8_14" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T8_15" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T8_16" runat="server"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_T8_17" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_T8_18" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_T8_19" runat="server" Width="5%"></asp:label></TD>
									</TR>
									<TR>
										<TD style="PADDING-LEFT: 40px" align="left" width="15%">Remittance</TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_T9_1" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_T9_2" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_T9_3" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_T9_4" runat="server" Width="5%"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T9_5" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T9_6" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T9_7" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T9_8" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T9_9" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T9_10" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T9_11" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T9_12" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T9_13" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T9_14" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T9_15" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WV_T9_16" runat="server"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_T9_17" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_T9_18" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WV_T9_19" runat="server" Width="5%"></asp:label></TD>
									</TR>
									<!--New Line-->
									<TR>
										<TD width="100%" colSpan="20"></TD>
									</TR>
									<TR>
										<TD vAlign="middle" align="left" width="100%" colSpan="20"><b>ALLIANCES VOLUME</b></TD>
									</TR>
									<TR>
										<TD style="PADDING-LEFT: 40px" align="left" width="15%">Investments</TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_1_1" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_1_2" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_1_3" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_1_4" runat="server" Width="5%"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_1_5" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_1_6" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_1_7" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_1_8" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_1_9" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_1_10" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_1_11" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_1_12" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_1_13" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_1_14" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_1_15" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_1_16" runat="server"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_1_17" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_1_18" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_1_19" runat="server" Width="5%"></asp:label></TD>
									</TR>
									<TR>
										<TD style="PADDING-LEFT: 40px" align="left" width="15%">DPLK</TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_2_1" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_2_2" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_2_3" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_2_4" runat="server" Width="5%"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_2_5" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_2_6" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_2_7" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_2_8" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_2_9" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_2_10" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_2_11" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_2_12" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_2_13" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_2_14" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_2_15" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_2_16" runat="server"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_2_17" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_2_18" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_2_19" runat="server" Width="5%"></asp:label></TD>
									</TR>
									<TR>
										<TD style="PADDING-LEFT: 40px" align="left" width="15%">Payroll CASA Deposit</TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_3_1" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_3_2" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_3_3" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_3_4" runat="server" Width="5%"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_3_5" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_3_6" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_3_7" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_3_8" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_3_9" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_3_10" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_3_11" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_3_12" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_3_13" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_3_14" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_3_15" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_3_16" runat="server"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_3_17" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_3_18" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_3_19" runat="server" Width="5%"></asp:label></TD>
									</TR>
									<TR>
										<TD style="PADDING-LEFT: 40px" align="left" width="15%">Value Chain CASA Deposit</TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_4_1" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_4_2" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_4_3" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_4_4" runat="server" Width="5%"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_4_5" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_4_6" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_4_7" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_4_8" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_4_9" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_4_10" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_4_11" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_4_12" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_4_13" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_4_14" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_4_15" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_4_16" runat="server"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_4_17" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_4_18" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_4_19" runat="server" Width="5%"></asp:label></TD>
									</TR>
									<TR>
										<TD style="PADDING-LEFT: 40px" align="left" width="15%">Value Chain Lending</TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_5_1" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_5_2" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_5_3" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_5_4" runat="server" Width="5%"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_5_5" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_5_6" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_5_7" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_5_8" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_5_9" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_5_10" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_5_11" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_5_12" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_5_13" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_5_14" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_5_15" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_5_16" runat="server"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_5_17" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_5_18" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_5_19" runat="server" Width="5%"></asp:label></TD>
									</TR>
									<TR>
										<TD style="PADDING-LEFT: 40px" align="left" width="15%">Micro Loan</TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_6_1" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_6_2" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_6_3" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_6_4" runat="server" Width="5%"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_6_5" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_6_6" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_6_7" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_6_8" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_6_9" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_6_10" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_6_11" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_6_12" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_6_13" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_6_14" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_6_15" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_6_16" runat="server"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_6_17" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_6_18" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_6_19" runat="server" Width="5%"></asp:label></TD>
									</TR>
									<TR>
										<TD style="PADDING-LEFT: 40px" align="left" width="15%">MKM &amp; KTA</TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_7_1" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_7_2" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_7_3" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_7_4" runat="server" Width="5%"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_7_5" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_7_6" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_7_7" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_7_8" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_7_9" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_7_10" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_7_11" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_7_12" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_7_13" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_7_14" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_7_15" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_7_16" runat="server"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_7_17" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_7_18" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_7_19" runat="server" Width="5%"></asp:label></TD>
									</TR>
									<TR>
										<TD style="PADDING-LEFT: 40px" align="left" width="15%">KPR &amp; MGM</TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_8_1" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_8_2" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_8_3" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_8_4" runat="server" Width="5%"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_8_5" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_8_6" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_8_7" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_8_8" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_8_9" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_8_10" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_8_11" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_8_12" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_8_13" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_8_14" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_8_15" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_8_16" runat="server"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_8_17" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_8_18" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_8_19" runat="server" Width="5%"></asp:label></TD>
									</TR>
									<TR>
										<TD style="PADDING-LEFT: 40px" align="left" width="15%">Auto &amp; 2W Loan</TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_9_1" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_9_2" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_9_3" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_9_4" runat="server" Width="5%"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_9_5" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_9_6" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_9_7" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_9_8" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_9_9" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_9_10" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_9_11" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_9_12" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_9_13" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_9_14" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_9_15" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_9_16" runat="server"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_9_17" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_9_18" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_9_19" runat="server" Width="5%"></asp:label></TD>
									</TR>
									<TR>
										<TD style="PADDING-LEFT: 40px" align="left" width="15%">Credit Cards</TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_10_1" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_10_2" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_10_3" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_10_4" runat="server" Width="5%"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_10_5" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_10_6" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_10_7" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_10_8" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_10_9" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_10_10" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_10_11" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_10_12" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_10_13" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_10_14" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_10_15" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_10_16" runat="server"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_10_17" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_10_18" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_10_19" runat="server" Width="5%"></asp:label></TD>
									</TR>
									<TR>
										<TD style="PADDING-LEFT: 40px" align="left" width="15%">Insurance</TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_11_1" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_11_2" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_11_3" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_11_4" runat="server" Width="5%"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_11_5" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_11_6" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_11_7" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_11_8" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_11_9" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_11_10" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_11_11" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_11_12" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_11_13" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_11_14" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_11_15" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AV_11_16" runat="server"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_11_17" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_11_18" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AV_11_19" runat="server" Width="5%"></asp:label></TD>
									</TR>
									<!--Other-->
									<TR>
										<TD width="100%" colSpan="20"></TD>
									</TR>
									<TR>
										<TD class="tdSmallHeader" align="center" width="15%" rowSpan="2"></TD>
										<TD class="tdSmallHeader" align="center" width="5%" rowSpan="2">Unit of Measurement</TD>
										<TD class="tdSmallHeader" align="center" colSpan="2">Target</TD>
										<TD class="tdSmallHeader" align="center" width="5%" rowSpan="2">Target Growth</TD>
										<TD class="tdSmallHeader" align="center" colSpan="12">Accumulative Realization</TD>
										<TD class="tdSmallHeader" align="center" width="5%" rowSpan="2">% YTD Realization</TD>
										<TD class="tdSmallHeader" align="center" width="5%" rowSpan="2">% YTD Annualized 
											Realization</TD>
										<TD class="tdSmallHeader" align="center" width="5%" rowSpan="2">Growth</TD>
									</TR>
									<TR>
										<TD class="tdSmallHeader" align="center" width="5%">Last Year</TD>
										<TD class="tdSmallHeader" align="center" width="5%">This Year</TD>
										<TD class="tdSmallHeader" align="center">Jan</TD>
										<TD class="tdSmallHeader" align="center">Feb</TD>
										<TD class="tdSmallHeader" align="center">Mar</TD>
										<TD class="tdSmallHeader" align="center">Apr</TD>
										<TD class="tdSmallHeader" align="center">Mei</TD>
										<TD class="tdSmallHeader" align="center">Jun</TD>
										<TD class="tdSmallHeader" align="center">Jul</TD>
										<TD class="tdSmallHeader" align="center">Ags</TD>
										<TD class="tdSmallHeader" align="center">Sep</TD>
										<TD class="tdSmallHeader" align="center">Okt</TD>
										<TD class="tdSmallHeader" align="center">Nov</TD>
										<TD class="tdSmallHeader" align="center">Des</TD>
									</TR>
									<TR>
										<TD vAlign="middle" align="left" width="100%" colSpan="20"><b>WHOLESALE INCOME</b></TD>
									</TR>
									<!--Line 1-->
									<TR>
										<TD class="TDBGColor" style="PADDING-RIGHT: 40px" align="left" width="100%" colSpan="20"><STRONG>&nbsp;&nbsp;&nbsp;Focus 
												Companies</STRONG></TD>
									</TR>
									<TR>
										<TD style="PADDING-LEFT: 20px" align="left" width="15%"><b>Net Interest Income</b></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F1_1" runat="server" Width="5%" Font-Bold="True"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F1_2" runat="server" Width="5%" Font-Bold="True"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F1_3" runat="server" Width="5%" Font-Bold="True"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F1_4" runat="server" Width="5%" Font-Bold="True"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F1_5" runat="server" Font-Bold="True"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F1_6" runat="server" Font-Bold="True"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F1_7" runat="server" Font-Bold="True"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F1_8" runat="server" Font-Bold="True"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F1_9" runat="server" Font-Bold="True"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F1_10" runat="server" Font-Bold="True"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F1_11" runat="server" Font-Bold="True"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F1_12" runat="server" Font-Bold="True"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F1_13" runat="server" Font-Bold="True"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F1_14" runat="server" Font-Bold="True"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F1_15" runat="server" Font-Bold="True"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F1_16" runat="server" Font-Bold="True"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F1_17" runat="server" Width="5%" Font-Bold="True"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F1_18" runat="server" Width="5%" Font-Bold="True"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F1_19" runat="server" Width="5%" Font-Bold="True"></asp:label></TD>
									</TR>
									<TR>
										<TD style="PADDING-LEFT: 40px" align="left" width="15%">CASA</TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F2_1" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F2_2" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F2_3" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F2_4" runat="server" Width="5%"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F2_5" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F2_6" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F2_7" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F2_8" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F2_9" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F2_10" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F2_11" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F2_12" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F2_13" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F2_14" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F2_15" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F2_16" runat="server"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F2_17" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F2_18" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F2_19" runat="server" Width="5%"></asp:label></TD>
									</TR>
									<TR>
										<TD style="PADDING-LEFT: 40px" align="left" width="15%">Time Deposit</TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F3_1" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F3_2" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F3_3" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F3_4" runat="server" Width="5%"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F3_5" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F3_6" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F3_7" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F3_8" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F3_9" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F3_10" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F3_11" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F3_12" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F3_13" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F3_14" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F3_15" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F3_16" runat="server"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F3_17" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F3_18" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F3_19" runat="server" Width="5%"></asp:label></TD>
									</TR>
									<TR>
										<TD style="PADDING-LEFT: 40px" align="left" width="15%">Working Capital Loan</TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F4_1" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F4_2" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F4_3" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F4_4" runat="server" Width="5%"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F4_5" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F4_6" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F4_7" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F4_8" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F4_9" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F4_10" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F4_11" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F4_12" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F4_13" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F4_14" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F4_15" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F4_16" runat="server"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F4_17" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F4_18" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F4_19" runat="server" Width="5%"></asp:label></TD>
									</TR>
									<TR>
										<TD style="PADDING-LEFT: 40px" align="left" width="15%">Investment Loan</TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F5_1" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F5_2" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F5_3" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F5_4" runat="server" Width="5%"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F5_5" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F5_6" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F5_7" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F5_8" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F5_9" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F5_10" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F5_11" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F5_12" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F5_13" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F5_14" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F5_15" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F5_16" runat="server"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F5_17" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F5_18" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F5_19" runat="server" Width="5%"></asp:label></TD>
									</TR>
									<TR>
										<TD style="PADDING-LEFT: 40px" align="left" width="15%">Syndication Loan</TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F6_1" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F6_2" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F6_3" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F6_4" runat="server" Width="5%"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F6_5" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F6_6" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F6_7" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F6_8" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F6_9" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F6_10" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F6_11" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F6_12" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F6_13" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F6_14" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F6_15" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F6_16" runat="server"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F6_17" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F6_18" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F6_19" runat="server" Width="5%"></asp:label></TD>
									</TR>
									<TR>
										<TD style="PADDING-LEFT: 40px" align="left" width="15%">Others</TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F7_1" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F7_2" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F7_3" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F7_4" runat="server" Width="5%"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F7_5" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F7_6" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F7_7" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F7_8" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F7_9" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F7_10" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F7_11" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F7_12" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F7_13" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F7_14" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F7_15" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F7_16" runat="server"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F7_17" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F7_18" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F7_19" runat="server" Width="5%"></asp:label></TD>
									</TR>
									<!--Other Line-->
									<TR>
										<TD style="PADDING-LEFT: 20px" align="left" width="15%"><b>Fee Based Income</b></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F8_1" runat="server" Width="5%" Font-Bold="True"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F8_2" runat="server" Width="5%" Font-Bold="True"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F8_3" runat="server" Width="5%" Font-Bold="True"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F8_4" runat="server" Width="5%" Font-Bold="True"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F8_5" runat="server" Font-Bold="True"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F8_6" runat="server" Font-Bold="True"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F8_7" runat="server" Font-Bold="True"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F8_8" runat="server" Font-Bold="True"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F8_9" runat="server" Font-Bold="True"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F8_10" runat="server" Font-Bold="True"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F8_11" runat="server" Font-Bold="True"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F8_12" runat="server" Font-Bold="True"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F8_13" runat="server" Font-Bold="True"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F8_14" runat="server" Font-Bold="True"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F8_15" runat="server" Font-Bold="True"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F8_16" runat="server" Font-Bold="True"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F8_17" runat="server" Width="5%" Font-Bold="True"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F8_18" runat="server" Width="5%" Font-Bold="True"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F8_19" runat="server" Width="5%" Font-Bold="True"></asp:label></TD>
									</TR>
									<TR>
										<TD style="PADDING-LEFT: 40px" align="left" width="15%">CASA</TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F9_1" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F9_2" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F9_3" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F9_4" runat="server" Width="5%"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F9_5" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F9_6" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F9_7" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F9_8" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F9_9" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F9_10" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F9_11" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F9_12" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F9_13" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F9_14" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F9_15" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F9_16" runat="server"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F9_17" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F9_18" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F9_19" runat="server" Width="5%"></asp:label></TD>
									</TR>
									<TR>
										<TD style="PADDING-LEFT: 40px" align="left" width="15%">Loan Maintenance Fee</TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F10_1" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F10_2" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F10_3" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F10_4" runat="server" Width="5%"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F10_5" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F10_6" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F10_7" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F10_8" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F10_9" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F10_10" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F10_11" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F10_12" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F10_13" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F10_14" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F10_15" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F10_16" runat="server"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F10_17" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F10_18" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F10_19" runat="server" Width="5%"></asp:label></TD>
									</TR>
									<TR>
										<TD style="PADDING-LEFT: 40px" align="left" width="15%">Syndication Fee</TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F11_1" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F11_2" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F11_3" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F11_4" runat="server" Width="5%"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F11_5" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F11_6" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F11_7" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F11_8" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F11_9" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F11_10" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F11_11" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F11_12" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F11_13" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F11_14" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F11_15" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F11_16" runat="server"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F11_17" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F11_18" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F11_19" runat="server" Width="5%"></asp:label></TD>
									</TR>
									<TR>
										<TD style="PADDING-LEFT: 40px" align="left" width="15%">Supply Chain Financing</TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F12_1" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F12_2" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F12_3" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F12_4" runat="server" Width="5%"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F12_5" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F12_6" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F12_7" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F12_8" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F12_9" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F12_10" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F12_11" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F12_12" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F12_13" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F12_14" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F12_15" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F12_16" runat="server"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F12_17" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F12_18" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F12_19" runat="server" Width="5%"></asp:label></TD>
									</TR>
									<TR>
										<TD style="PADDING-LEFT: 40px" align="left" width="15%">FX &amp; Derivatives</TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F13_1" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F13_2" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F13_3" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F13_4" runat="server" Width="5%"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F13_5" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F13_6" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F13_7" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F13_8" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F13_9" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F13_10" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F13_11" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F13_12" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F13_13" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F13_14" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F13_15" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F13_16" runat="server"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F13_17" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F13_18" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F13_19" runat="server" Width="5%"></asp:label></TD>
									</TR>
									<TR>
										<TD style="PADDING-LEFT: 40px" align="left" width="15%">LC &amp; SKBDN</TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F14_1" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F14_2" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F14_3" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F14_4" runat="server" Width="5%"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F14_5" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F14_6" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F14_7" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F14_8" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F14_9" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F14_10" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F14_11" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F14_12" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F14_13" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F14_14" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F14_15" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F14_16" runat="server"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F14_17" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F14_18" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F14_19" runat="server" Width="5%"></asp:label></TD>
									</TR>
									<TR>
										<TD style="PADDING-LEFT: 40px" align="left" width="15%">Bank Guarantee</TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F15_1" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F15_2" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F15_3" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F15_4" runat="server" Width="5%"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F15_5" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F15_6" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F15_7" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F15_8" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F15_9" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F15_10" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F15_11" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F15_12" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F15_13" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F15_14" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F15_15" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F15_16" runat="server"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F15_17" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F15_18" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F15_19" runat="server" Width="5%"></asp:label></TD>
									</TR>
									<TR>
										<TD style="PADDING-LEFT: 40px" align="left" width="15%">Remittance</TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F16_1" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F16_2" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F16_3" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F16_4" runat="server" Width="5%"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F16_5" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F16_6" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F16_7" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F16_8" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F16_9" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F16_10" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F16_11" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F16_12" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F16_13" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F16_14" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F16_15" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F16_16" runat="server"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F16_17" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F16_18" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F16_19" runat="server" Width="5%"></asp:label></TD>
									</TR>
									<TR>
										<TD style="PADDING-LEFT: 40px" align="left" width="15%">Others</TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F17_1" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F17_2" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F17_3" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F17_4" runat="server" Width="5%"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F17_5" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F17_6" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F17_7" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F17_8" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F17_9" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F17_10" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F17_11" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F17_12" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F17_13" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F17_14" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F17_15" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_F17_16" runat="server"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F17_17" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F17_18" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_F17_19" runat="server" Width="5%"></asp:label></TD>
									</TR>
									<!--Line 2-->
									<TR>
										<TD class="TDBGColor" style="PADDING-RIGHT: 40px" align="left" width="100%" colSpan="20"><STRONG>&nbsp;&nbsp;&nbsp;Non 
												Focus Companies</STRONG></TD>
									</TR>
									<TR>
										<TD style="PADDING-LEFT: 40px" align="left" width="15%">Net Interest Income</TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_NF1_1" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_NF1_2" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_NF1_3" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_NF1_4" runat="server" Width="5%"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_NF1_5" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_NF1_6" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_NF1_7" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_NF1_8" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_NF1_9" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_NF1_10" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_NF1_11" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_NF1_12" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_NF1_13" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_NF1_14" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_NF1_15" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_NF1_16" runat="server"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_NF1_17" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_NF1_18" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_NF1_19" runat="server" Width="5%"></asp:label></TD>
									</TR>
									<TR>
										<TD style="PADDING-LEFT: 40px" align="left" width="15%">Fee Based Income</TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_NF2_1" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_NF2_2" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_NF2_3" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_NF2_4" runat="server" Width="5%"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_NF2_5" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_NF2_6" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_NF2_7" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_NF2_8" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_NF2_9" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_NF2_10" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_NF2_11" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_NF2_12" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_NF2_13" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_NF2_14" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_NF2_15" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_NF2_16" runat="server"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_NF2_17" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_NF2_18" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_NF2_19" runat="server" Width="5%"></asp:label></TD>
									</TR>
									<!--Line 3-->
									<TR>
										<TD class="TDBGColor" style="PADDING-RIGHT: 40px" align="left" width="100%" colSpan="20"><STRONG>&nbsp;&nbsp;&nbsp;Total</STRONG></TD>
									</TR>
									<TR>
										<TD style="PADDING-LEFT: 40px" align="left" width="15%">Net Interest Income</TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_T1_1" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_T1_2" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_T1_3" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_T1_4" runat="server" Width="5%"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_T1_5" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_T1_6" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_T1_7" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_T1_8" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_T1_9" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_T1_10" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_T1_11" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_T1_12" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_T1_13" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_T1_14" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_T1_15" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_T1_16" runat="server"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_T1_17" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_T1_18" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_T1_19" runat="server" Width="5%"></asp:label></TD>
									</TR>
									<TR>
										<TD style="PADDING-LEFT: 40px" align="left" width="15%">Fee Based Income</TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_T2_1" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_T2_2" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_T2_3" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_T2_4" runat="server" Width="5%"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_T2_5" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_T2_6" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_T2_7" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_T2_8" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_T2_9" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_T2_10" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_T2_11" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_T2_12" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_T2_13" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_T2_14" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_T2_15" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_T2_16" runat="server"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_T2_17" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_T2_18" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_T2_19" runat="server" Width="5%"></asp:label></TD>
									</TR>
									<TR>
										<TD align="center" width="15%"><b>Total</b></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_T3_1" runat="server" Width="5%" Font-Bold="True"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_T3_2" runat="server" Width="5%" Font-Bold="True"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_T3_3" runat="server" Width="5%" Font-Bold="True"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_T3_4" runat="server" Width="5%" Font-Bold="True"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_T3_5" runat="server" Font-Bold="True"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_T3_6" runat="server" Font-Bold="True"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_T3_7" runat="server" Font-Bold="True"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_T3_8" runat="server" Font-Bold="True"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_T3_9" runat="server" Font-Bold="True"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_T3_10" runat="server" Font-Bold="True"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_T3_11" runat="server" Font-Bold="True"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_T3_12" runat="server" Font-Bold="True"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_T3_13" runat="server" Font-Bold="True"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_T3_14" runat="server" Font-Bold="True"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_T3_15" runat="server" Font-Bold="True"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_WI_T3_16" runat="server" Font-Bold="True"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_T3_17" runat="server" Width="5%" Font-Bold="True"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_T3_18" runat="server" Width="5%" Font-Bold="True"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_WI_T3_19" runat="server" Width="5%" Font-Bold="True"></asp:label></TD>
									</TR>
									<TR>
										<TD width="100%" colSpan="20"></TD>
									</TR>
									<TR>
										<TD class="TDBGColor" align="center" width="15%"><b>INVESTMENT<br>
												BANKING INCOME</b></TD>
										<TD class="TDBGColor" align="center" width="5%"><asp:label id="LBL_WI_IBI_1" runat="server" Width="5%" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center" width="5%"><asp:label id="LBL_WI_IBI_2" runat="server" Width="5%" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center" width="5%"><asp:label id="LBL_WI_IBI_3" runat="server" Width="5%" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center" width="5%"><asp:label id="LBL_WI_IBI_4" runat="server" Width="5%" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center"><asp:label id="LBL_WI_IBI_5" runat="server" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center"><asp:label id="LBL_WI_IBI_6" runat="server" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center"><asp:label id="LBL_WI_IBI_7" runat="server" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center"><asp:label id="LBL_WI_IBI_8" runat="server" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center"><asp:label id="LBL_WI_IBI_9" runat="server" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center"><asp:label id="LBL_WI_IBI_10" runat="server" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center"><asp:label id="LBL_WI_IBI_11" runat="server" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center"><asp:label id="LBL_WI_IBI_12" runat="server" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center"><asp:label id="LBL_WI_IBI_13" runat="server" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center"><asp:label id="LBL_WI_IBI_14" runat="server" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center"><asp:label id="LBL_WI_IBI_15" runat="server" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center"><asp:label id="LBL_WI_IBI_16" runat="server" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center" width="5%"><asp:label id="LBL_WI_IBI_17" runat="server" Width="5%" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center" width="5%"><asp:label id="LBL_WI_IBI_18" runat="server" Width="5%" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center" width="5%"><asp:label id="LBL_WI_IBI_19" runat="server" Width="5%" Font-Bold="True"></asp:label></TD>
									</TR>
									<!--New Line-->
									<TR>
										<TD width="100%" colSpan="20"></TD>
									</TR>
									<TR>
										<TD vAlign="middle" align="left" width="100%" colSpan="20"><b>ALLIANCES INCOME</b></TD>
									</TR>
									<TR>
										<TD style="PADDING-LEFT: 40px" align="left" width="15%">Investments</TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_1_1" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_1_2" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_1_3" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_1_4" runat="server" Width="5%"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_1_5" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_1_6" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_1_7" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_1_8" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_1_9" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_1_10" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_1_11" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_1_12" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_1_13" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_1_14" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_1_15" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_1_16" runat="server"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_1_17" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_1_18" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_1_19" runat="server" Width="5%"></asp:label></TD>
									</TR>
									<TR>
										<TD style="PADDING-LEFT: 40px" align="left" width="15%">DPLK</TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_2_1" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_2_2" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_2_3" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_2_4" runat="server" Width="5%"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_2_5" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_2_6" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_2_7" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_2_8" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_2_9" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_2_10" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_2_11" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_2_12" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_2_13" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_2_14" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_2_15" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_2_16" runat="server"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_2_17" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_2_18" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_2_19" runat="server" Width="5%"></asp:label></TD>
									</TR>
									<TR>
										<TD style="PADDING-LEFT: 40px" align="left" width="15%">Payroll CASA Deposit</TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_3_1" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_3_2" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_3_3" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_3_4" runat="server" Width="5%"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_3_5" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_3_6" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_3_7" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_3_8" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_3_9" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_3_10" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_3_11" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_3_12" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_3_13" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_3_14" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_3_15" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_3_16" runat="server"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_3_17" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_3_18" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_3_19" runat="server" Width="5%"></asp:label></TD>
									</TR>
									<TR>
										<TD style="PADDING-LEFT: 40px" align="left" width="15%">Value Chain CASA Deposit</TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_4_1" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_4_2" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_4_3" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_4_4" runat="server" Width="5%"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_4_5" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_4_6" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_4_7" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_4_8" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_4_9" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_4_10" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_4_11" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_4_12" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_4_13" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_4_14" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_4_15" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_4_16" runat="server"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_4_17" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_4_18" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_4_19" runat="server" Width="5%"></asp:label></TD>
									</TR>
									<TR>
										<TD style="PADDING-LEFT: 40px" align="left" width="15%">Value Chain Lending</TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_5_1" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_5_2" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_5_3" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_5_4" runat="server" Width="5%"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_5_5" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_5_6" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_5_7" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_5_8" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_5_9" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_5_10" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_5_11" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_5_12" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_5_13" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_5_14" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_5_15" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_5_16" runat="server"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_5_17" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_5_18" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_5_19" runat="server" Width="5%"></asp:label></TD>
									</TR>
									<TR>
										<TD style="PADDING-LEFT: 40px" align="left" width="15%">Micro Loan</TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_6_1" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_6_2" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_6_3" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_6_4" runat="server" Width="5%"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_6_5" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_6_6" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_6_7" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_6_8" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_6_9" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_6_10" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_6_11" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_6_12" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_6_13" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_6_14" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_6_15" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_6_16" runat="server"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_6_17" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_6_18" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_6_19" runat="server" Width="5%"></asp:label></TD>
									</TR>
									<TR>
										<TD style="PADDING-LEFT: 40px" align="left" width="15%">MKM &amp; KTA</TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_7_1" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_7_2" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_7_3" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_7_4" runat="server" Width="5%"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_7_5" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_7_6" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_7_7" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_7_8" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_7_9" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_7_10" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_7_11" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_7_12" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_7_13" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_7_14" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_7_15" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_7_16" runat="server"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_7_17" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_7_18" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_7_19" runat="server" Width="5%"></asp:label></TD>
									</TR>
									<TR>
										<TD style="PADDING-LEFT: 40px" align="left" width="15%">KPR &amp; MGM</TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_8_1" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_8_2" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_8_3" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_8_4" runat="server" Width="5%"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_8_5" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_8_6" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_8_7" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_8_8" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_8_9" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_8_10" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_8_11" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_8_12" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_8_13" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_8_14" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_8_15" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_8_16" runat="server"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_8_17" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_8_18" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_8_19" runat="server" Width="5%"></asp:label></TD>
									</TR>
									<TR>
										<TD style="PADDING-LEFT: 40px" align="left" width="15%">Auto &amp; 2W Loan</TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_9_1" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_9_2" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_9_3" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_9_4" runat="server" Width="5%"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_9_5" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_9_6" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_9_7" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_9_8" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_9_9" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_9_10" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_9_11" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_9_12" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_9_13" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_9_14" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_9_15" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_9_16" runat="server"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_9_17" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_9_18" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_9_19" runat="server" Width="5%"></asp:label></TD>
									</TR>
									<TR>
										<TD style="PADDING-LEFT: 40px" align="left" width="15%">Credit Cards</TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_10_1" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_10_2" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_10_3" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_10_4" runat="server" Width="5%"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_10_5" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_10_6" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_10_7" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_10_8" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_10_9" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_10_10" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_10_11" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_10_12" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_10_13" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_10_14" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_10_15" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_10_16" runat="server"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_10_17" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_10_18" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_10_19" runat="server" Width="5%"></asp:label></TD>
									</TR>
									<TR>
										<TD style="PADDING-LEFT: 40px" align="left" width="15%">Insurance</TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_11_1" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_11_2" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_11_3" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_11_4" runat="server" Width="5%"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_11_5" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_11_6" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_11_7" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_11_8" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_11_9" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_11_10" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_11_11" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_11_12" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_11_13" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_11_14" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_11_15" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_11_16" runat="server"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_11_17" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_11_18" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_11_19" runat="server" Width="5%"></asp:label></TD>
									</TR>
									<TR>
										<TD style="PADDING-LEFT: 40px" align="left" width="15%">Others</TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_12_1" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_12_2" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_12_3" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_12_4" runat="server" Width="5%"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_12_5" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_12_6" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_12_7" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_12_8" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_12_9" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_12_10" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_12_11" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_12_12" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_12_13" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_12_14" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_12_15" runat="server"></asp:label></TD>
										<TD align="center"><asp:label id="LBL_AI_12_16" runat="server"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_12_17" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_12_18" runat="server" Width="5%"></asp:label></TD>
										<TD align="center" width="5%"><asp:label id="LBL_AI_12_19" runat="server" Width="5%"></asp:label></TD>
									</TR>
									<TR>
										<TD class="TDBGColor" align="center" width="15%"><b>Total</b></TD>
										<TD class="TDBGColor" align="center" width="5%"><asp:label id="LBL_AI_13_1" runat="server" Width="5%" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center" width="5%"><asp:label id="LBL_AI_13_2" runat="server" Width="5%" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center" width="5%"><asp:label id="LBL_AI_13_3" runat="server" Width="5%" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center" width="5%"><asp:label id="LBL_AI_13_4" runat="server" Width="5%" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center"><asp:label id="LBL_AI_13_5" runat="server" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center"><asp:label id="LBL_AI_13_6" runat="server" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center"><asp:label id="LBL_AI_13_7" runat="server" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center"><asp:label id="LBL_AI_13_8" runat="server" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center"><asp:label id="LBL_AI_13_9" runat="server" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center"><asp:label id="LBL_AI_13_10" runat="server" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center"><asp:label id="LBL_AI_13_11" runat="server" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center"><asp:label id="LBL_AI_13_12" runat="server" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center"><asp:label id="LBL_AI_13_13" runat="server" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center"><asp:label id="LBL_AI_13_14" runat="server" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center"><asp:label id="LBL_AI_13_15" runat="server" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center"><asp:label id="LBL_AI_13_16" runat="server" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center" width="5%"><asp:label id="LBL_AI_13_17" runat="server" Width="5%" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center" width="5%"><asp:label id="LBL_AI_13_18" runat="server" Width="5%" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center" width="5%"><asp:label id="LBL_AI_13_19" runat="server" Width="5%" Font-Bold="True"></asp:label></TD>
									</TR>
									<TR>
										<TD width="100%" colSpan="20"></TD>
									</TR>
									<TR>
										<TD class="TDBGColor" align="left" width="15%"><b>TOTAL RELATIONSHIP INCOME</b></TD>
										<TD class="TDBGColor" align="center" width="5%"><asp:label id="LBL_TRI_1" runat="server" Width="5%" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center" width="5%"><asp:label id="LBL_TRI_2" runat="server" Width="5%" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center" width="5%"><asp:label id="LBL_TRI_3" runat="server" Width="5%" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center" width="5%"><asp:label id="LBL_TRI_4" runat="server" Width="5%" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center"><asp:label id="LBL_TRI_5" runat="server" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center"><asp:label id="LBL_TRI_6" runat="server" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center"><asp:label id="LBL_TRI_7" runat="server" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center"><asp:label id="LBL_TRI_8" runat="server" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center"><asp:label id="LBL_TRI_9" runat="server" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center"><asp:label id="LBL_TRI_10" runat="server" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center"><asp:label id="LBL_TRI_11" runat="server" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center"><asp:label id="LBL_TRI_12" runat="server" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center"><asp:label id="LBL_TRI_13" runat="server" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center"><asp:label id="LBL_TRI_14" runat="server" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center"><asp:label id="LBL_TRI_15" runat="server" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center"><asp:label id="LBL_TRI_16" runat="server" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center" width="5%"><asp:label id="LBL_TRI_17" runat="server" Width="5%" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center" width="5%"><asp:label id="LBL_TRI_18" runat="server" Width="5%" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center" width="5%"><asp:label id="LBL_TRI_19" runat="server" Width="5%" Font-Bold="True"></asp:label></TD>
									</TR>
									<TR>
										<TD class="TDBGColor" align="left" width="15%"><b>RORA</b></TD>
										<TD class="TDBGColor" align="center" width="5%"><asp:label id="LBL_RORA_1" runat="server" Width="5%" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center" width="5%"><asp:label id="LBL_RORA_2" runat="server" Width="5%" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center" width="5%"><asp:label id="LBL_RORA_3" runat="server" Width="5%" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center" width="5%"><asp:label id="LBL_RORA_4" runat="server" Width="5%" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center"><asp:label id="LBL_RORA_5" runat="server" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center"><asp:label id="LBL_RORA_6" runat="server" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center"><asp:label id="LBL_RORA_7" runat="server" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center"><asp:label id="LBL_RORA_8" runat="server" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center"><asp:label id="LBL_RORA_9" runat="server" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center"><asp:label id="LBL_RORA_10" runat="server" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center"><asp:label id="LBL_RORA_11" runat="server" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center"><asp:label id="LBL_RORA_12" runat="server" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center"><asp:label id="LBL_RORA_13" runat="server" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center"><asp:label id="LBL_RORA_14" runat="server" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center"><asp:label id="LBL_RORA_15" runat="server" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center"><asp:label id="LBL_RORA_16" runat="server" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center" width="5%"><asp:label id="LBL_RORA_17" runat="server" Width="5%" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center" width="5%"><asp:label id="LBL_RORA_18" runat="server" Width="5%" Font-Bold="True"></asp:label></TD>
										<TD class="TDBGColor" align="center" width="5%"><asp:label id="LBL_RORA_19" runat="server" Width="5%" Font-Bold="True"></asp:label></TD>
									</TR>
								</TBODY>
							</TABLE>
						</TD>
					</TR>
				</TABLE>
			</CENTER>
		</FORM>
	</BODY>
</HTML>
