<%@ Page language="c#" Codebehind="AP_VARIABLE.aspx.cs" AutoEventWireup="True" Inherits="SME.AccountPlanning.Parameter.Maker.AP_VARIABLE" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AP_VARIABLE</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../../../include/popup.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table4" width="100%" border="0">
					<TR>
						<TD class="tdNoBorder" align="left" width="50%">
							<TABLE id="Table3">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Product &nbsp;Parameter</B>
									</TD>
								</TR>
							</TABLE>
						</TD>
						<td align="right"><A href="../../../Body.aspx"><IMG src="../../../Image/MainMenu.jpg"></A><A href="../../../Logout.aspx" target="_top"><IMG src="../../../Image/Logout.jpg"></A>
						</td>
					</TR>
					<TR>
						<TD align="center" colSpan="2">
							<TABLE class="td" id="Table1" style="WIDTH: 590px; HEIGHT: 140px" height="140" cellSpacing="1"
								cellPadding="1" width="590" border="1">
								<TR>
									<TD class="tdHeader1">Search Product</TD>
								</TR>
								<TR>
									<TD vAlign="top" align="center">
										<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD class="TDBGColor1" width="170">ID</TD>
												<TD width="5"></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="_txtIDQualitative" runat="server" MaxLength="200"
														Width="200px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Description</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="_txtParamName" runat="server" MaxLength="500"
														Width="200px"></asp:textbox></TD>
											</TR>
											<tr>
												<TD></TD>
											</tr>
											<TR>
												<TD vAlign="top" align="center" colSpan="3" height="10"><asp:button id="_btnFind" runat="server" Width="180px" Text="Find Parameter" CssClass="button1"></asp:button>&nbsp;
													<asp:button id="_btnNew" runat="server" Width="180px" Text="New Parameter" CssClass="button1"></asp:button>&nbsp;
												</TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR id="TR_EDIT_PARAMETER" runat="server">
						<TD align="center" colSpan="2">
							<TABLE class="td" id="TableEdit1" cellSpacing="1" cellPadding="1" width="900" border="1">
								<TR>
									<TD class="tdHeader1" colSpan="2">Parameter</TD>
								</TR>
								<TR>
									<TD vAlign="top" align="center">
										<TABLE id="TableEdit2" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD class="TDBGColor1">ID</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox id="_txt_ID" runat="server" MaxLength="500" Width="200px" BackColor="Silver" Enabled="False"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Description</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox id="_txt_DESC" runat="server" MaxLength="500" Width="200px" TextMode="MultiLine"
														Height="42px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Benchmark</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:dropdownlist id="_ddl_benchmark" runat="server" Width="200px"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Uploaded Data</TD>
												<TD></TD>
												<TD class="TDBGColorValue">
													<asp:DropDownList id="_ddl_uploaded_data" runat="server" Width="200px"></asp:DropDownList></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Cash Processing Fee Day</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox id="_txt_CPFD" runat="server" MaxLength="500" Width="200px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Cash In Shift Day</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox id="_txt_CASH_IN_SHIFT_DAY" runat="server" MaxLength="500" Width="200px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Cash In Transit Cost Day</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox id="_txt_CASH_IN_TRANSIT_COST_DAY" runat="server" MaxLength="500" Width="200px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">H2H Development Fee</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox id="_txt_H2HDEVELOPMENT_FEE_USD" runat="server" MaxLength="500" Width="200px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Collection Fee Day</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox id="_txt_COLLECTION_FEE_DAY" runat="server" MaxLength="500" Width="200px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Commitment Fee</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox id="_txt_COMMITMENT_FEE" runat="server" MaxLength="500" Width="200px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Correspondent Cost USD</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox id="_txt_CORRESPONDENT_COST_USD" runat="server" MaxLength="500" Width="200px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Correspondent Fee USD</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox id="_txt_CORRESPONDENT_FEE_USD" runat="server" MaxLength="500" Width="200px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Direct IT Cost Per-Million Unit</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox id="_txt_DIRECT_IT_COST_PER_MILLION_UNIT" runat="server" MaxLength="500" Width="200px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Fee Transcation</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox id="_txt_FEE_TRANSACTION" runat="server" MaxLength="500" Width="200px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Non H2H Development Fee</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox id="_txt_NON_H2H_DEV_FEE" runat="server" MaxLength="500" Width="200px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Indirect Cost Transaction</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox id="_txt_INDIRECT_COST_TRANSACTION" runat="server" MaxLength="500" Width="200px"></asp:textbox></TD>
											</TR>
											<!-- <TR>
												<TD class="TDBGColor1">Request</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox id="_txt_REQUEST" runat="server" MaxLength="500" Width="200px"></asp:textbox></TD>
											</TR> -->
											<TR>
												<TD class="TDBGColor1">GWM Percent</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox id="_txt_GWM_PERCENT" runat="server" MaxLength="500" Width="200px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Spread Percent</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox id="_txt_SPREAD_PERCENT" runat="server" MaxLength="500" Width="200px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">CKPN Percent</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox id="_txt_CKPN_PERCENT" runat="server" MaxLength="500" Width="200px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Monthly Minimum Transaction</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox id="_txt_MONTHLY_MINIMUM_TRANSACTION" runat="server" MaxLength="500" Width="200px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Provisi Fasilitas Quartal Percent</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox id="_txt_PROVISI_FASILITAS_QUARTAL_PERCENT" runat="server" MaxLength="500" Width="200px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Provisi Giro Jaminan USD</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox id="_txt_PROVISI_GIRO_JAMINAN_USD" runat="server" MaxLength="500" Width="200px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Unit Cost Per Million Unit</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox id="_txt_UNIT_COST_PER_MILLION_UNIT" runat="server" MaxLength="500" Width="200px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Provisi Blokir Perquartal Percent</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox id="_txt_PROVISI_BLOKIR_PERQUARTAL_PERCENT" runat="server" MaxLength="500" Width="200px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Interest Rate Percent</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox id="_txt_INTEREST_RATE_PERCENT" runat="server" MaxLength="500" Width="200px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">IT Cost Transaction</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox id="_txt_IT_COST_TRANSACTION" runat="server" MaxLength="500" Width="200px"></asp:textbox></TD>
											</TR>
										</TABLE>
									</TD>
									<TD vAlign="top">
										<TABLE id="TableEdit2" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD class="TDBGColor1" vAlign="middle">Joining Fee</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox id="_txt_JOINING_FEE" runat="server" MaxLength="500" Width="200px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Maximum Provision USD</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox id="_txt_MAXIMUM_PROVISION_USD" runat="server" MaxLength="500" Width="200px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Minimum Fee PerProcess</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox id="_txt_MINIMUM_FEE_PER_PROCESS" runat="server" MaxLength="500" Width="200px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Minimum Provision USD</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox id="_txt_MINIMUM_PROVISION_USD" runat="server" MaxLength="500" Width="200px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Provision Percent</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox id="_txt_PROVISION_PERCENT" runat="server" MaxLength="500" Width="200px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Rate Per-Employee</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox id="_txt_RATE_PER_EMPLOYEE" runat="server" MaxLength="500" Width="200px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Premium For LPS Percent</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox id="_txt_PREMIUM_FOR_LPS_PERCENT" runat="server" MaxLength="500" Width="200px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Referral Fee Income Percent</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox id="_txt_REFERRAL_FEE_INCOME_PERCENT" runat="server" MaxLength="500" Width="200px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Service Cost</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox id="_txt_SERVICE_COST" runat="server" MaxLength="500" Width="200px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Service Fee Percent</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox id="_txt_SERVICE_FEE_PERCENT" runat="server" MaxLength="500" Width="200px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Transaction Fee</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox id="_txt_TRANSACT_FEE" runat="server" MaxLength="500" Width="200px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Swift Fee Percent</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox id="_txt_SWIFT_FEE_PERCENT" runat="server" MaxLength="500" Width="200px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Syndication Fee Percent</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox id="_txt_SYNDICATION_FEE_PERCENT" runat="server" MaxLength="500" Width="200px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Usage Commision Fee Percent</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox id="_txt_USAGE_COMMISION_FEE_PERCENT" runat="server" MaxLength="500" Width="200px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Admin Fee Percent</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox id="_txt_ADMIN_FEE_PERCENT" runat="server" MaxLength="500" Width="200px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Annual Fee</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox id="_txt_ANNUAL_FEE" runat="server" MaxLength="500" Width="200px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">BI Cost</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox id="_txt_BI_COST" runat="server" MaxLength="500" Width="200px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Cable Cost USD</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox id="_txt_CABLE_COST_USD" runat="server" MaxLength="500" Width="200px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Cable Fee USD</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox id="_txt_CABLE_FEE_USD" runat="server" MaxLength="500" Width="200px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Fixed Fee</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox id="_txt_FIXED_FEE" runat="server" MaxLength="500" Width="200px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">FTP CKPN Percent</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox id="_txt_FTP_CKPN_PERCENT" runat="server" MaxLength="500" Width="200px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">FTP COST Percent</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox id="_txt_FTP_COST_PERCENT" runat="server" MaxLength="500" Width="200px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">FTP GWM Percent</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox id="_txt_FTP_GWM_PERCENT" runat="server" MaxLength="500" Width="200px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">FTP Income Percent</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox id="_txt_FTP_INCOME_PERCENT" runat="server" MaxLength="500" Width="200px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Other Cost Percent</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox id="_txt_OTHER_COST_PERCENT" runat="server" MaxLength="500" Width="200px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Penalty Fee Percent</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox id="_txt_PENALTY_FEE_PERCENT" runat="server" MaxLength="500" Width="200px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Active</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:checkbox id="CB_ACTIVE" Text="Check to activate the parameter" Runat="Server" Font-Bold="True"></asp:checkbox></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD vAlign="top" align="center" colSpan="3" height="10"><asp:button id="_btnEditedUpdate" runat="server" Width="180px" Text="Insert Parameter" CssClass="button1" onclick="_btnEditedUpdate_Click"></asp:button>&nbsp;
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD align="center" colSpan="2">&nbsp;</TD>
					</TR>
					<TR>
						<TD colSpan="2"><ASP:DATAGRID id="DatGrd" runat="server" Width="100%" PageSize="10" AllowPaging="True" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="ID_AP_VARIABLE"></asp:BoundColumn>
									<asp:BoundColumn DataField="ID_AP_VARIABLE" HeaderText="ID">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="DESCRIPTION" HeaderText="Description">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="DSTATUS" HeaderText="Status">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
									</asp:BoundColumn>
									<asp:ButtonColumn Text="Edit" HeaderText="Function" CommandName="Edit">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="8%"></ItemStyle>
									</asp:ButtonColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
				</TABLE>
				<table id="TBL_MAKER_REQUEST" width="100%" runat="server">
					<TR>
						<TD class="tdHeader1" colSpan="3">Maker Request</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" align="center" colSpan="3"><asp:datagrid id="DatGridRuleReason" runat="server" Width="100%" PageSize="5" AllowPaging="True"
								AutoGenerateColumns="False">
								<Columns>
									<asp:BoundColumn Visible="False" DataField="ID"></asp:BoundColumn>
									<asp:BoundColumn DataField="ID" HeaderText="ID">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="DESCRIPTION" HeaderText="Deskripsi" HeaderStyle-Width="30%">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="DSTATUS" HeaderText="Status" HeaderStyle-Width="15%">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:ButtonColumn Text="Edit" HeaderText="Function" CommandName="Edit">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
									</asp:ButtonColumn>
									<asp:ButtonColumn Text="Delete" HeaderText="Function" CommandName="Delete">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
									</asp:ButtonColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</asp:datagrid></TD>
					</TR>
				</table>
				<asp:textbox id="_txtRRID" Runat="server" Visible="False"></asp:textbox></center>
		</form>
	</body>
</HTML>
