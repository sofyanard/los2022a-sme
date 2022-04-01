<%@ Page language="c#" Codebehind="ProductMasterParam.aspx.cs" AutoEventWireup="false" Inherits="SME.AccountPlanning.Parameter.Maker.ProductMasterParam" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>ProductMasterParam</TITLE>
		<META content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../../../include/popup.html" -->
	</HEAD>
	<BODY MS_POSITIONING="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<CENTER>
				<TABLE width="100%" border="0">
					<TR>
						<TD align="left" width="50%">
							<TABLE id="Table1">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>PRODUCT LINK - MAKER</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/image/Back.jpg"></asp:imagebutton><A href="../../../Body.aspx"><IMG height="25" src="/SME/Image/MainMenu.jpg" width="106"></A>
							<A href="../../../Logout.aspx" target="_top"><IMG src="/SME/Image/Logout.jpg"></A>
						</TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">MAKER</TD>
					</TR>
					<TR>
						<TD class="td" style="HEIGHT: 7px" vAlign="top" width="100%" colSpan="2">
							<TABLE cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="16.5%"><asp:label id="LBL_PRODUCT_LINK_NAME" runat="server">Product Link Name :</asp:label></TD>
									<TD class="TDBGColorValue" width="83.5%"><asp:dropdownlist id="DDL_PRODUCT_ID" Runat="server" Width="100%" CssClass="Mandatory"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="16.5%"><asp:label id="Label49" runat="server"> Category :</asp:label></TD>
									<TD class="TDBGColorValue" width="83.5%"><asp:dropdownlist id="DDL_CATEGORY" Runat="server" Width="100%" CssClass="Mandatory"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="16.5%"><asp:label id="Label50" runat="server"> Benchmark :</asp:label></TD>
									<TD class="TDBGColorValue" width="83.5%"><asp:dropdownlist id="DDL_BENCHMARK" Runat="server" Width="100%" CssClass="Mandatory"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="16.5%"><asp:label id="Label51" runat="server"> Uploaded Data :</asp:label></TD>
									<TD class="TDBGColorValue" width="83.5%"><asp:dropdownlist id="DDL_UPLOADED" Runat="server" Width="100%" CssClass="Mandatory"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="16.5%" colSpan="1"><asp:label id="LBL_PRODUCT_IPS_LINK" runat="server">Product IPS Link :</asp:label></TD>
									<td>
										<table width="100%" align="center">
											<tr>
												<TD class="TDBGColorValue" width="100%"><asp:textbox id="TXT_LINKID" runat="server" Width="100%" CssClass="Mandatory" ReadOnly="True"></asp:textbox></TD>
												<TD class="TDBGColorValue"><asp:button id="BTN_LINK" runat="server" Text="........"></asp:button></TD>
											</tr>
										</table>
									</td>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="td" style="HEIGHT: 7px" vAlign="top" width="100%" colSpan="2">
							<TABLE  cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="16.5%"><asp:label id="Label1" runat="server">Admin fee(%) :</asp:label></TD>
									<TD class="TDBGColorValue" width="16.5%"><asp:textbox id="TXT_ADMIN_FEE" runat="server" Width="100%"></asp:textbox></TD>
									<TD class="TDBGColor1" width="17.5%"><asp:label id="Label2" runat="server">Cash Processing Fee/day :</asp:label></TD>
									<TD class="TDBGColorValue" width="16.5%"><asp:textbox id="TXT_CASH_PROCESS" runat="server" Width="100%"></asp:textbox></TD>
									<TD class="TDBGColor1" width="16.5%"><asp:label id="Label3" runat="server">Provisi Blokir/quartal (%) :</asp:label></TD>
									<TD class="TDBGColorValue" width="16.5%"><asp:textbox id="TXT_PROVISI_BLOKIR" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="16.5%"><asp:label id="Label4" runat="server">Annual Fee :</asp:label></TD>
									<TD class="TDBGColorValue" width="16.5%"><asp:textbox id="TXT_ANNUAL_FEE" runat="server" Width="100%"></asp:textbox></TD>
									<TD class="TDBGColor1" width="17.5%"><asp:label id="Label5" runat="server">Cash-in-Shift/day :</asp:label></TD>
									<TD class="TDBGColorValue" width="16.5%"><asp:textbox id="TXT_CASH_IN_SHIFT" runat="server" Width="100%"></asp:textbox></TD>
									<TD class="TDBGColor1" width="16.5%"><asp:label id="Label6" runat="server">Interest rate (%) :</asp:label></TD>
									<TD class="TDBGColorValue" width="16.5%"><asp:textbox id="TXT_INTEREST_RATE" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="16.5%"><asp:label id="Label7" runat="server">BI Cost :</asp:label></TD>
									<TD class="TDBGColorValue" width="16.5%"><asp:textbox id="TXT_BI_COST" runat="server" Width="100%"></asp:textbox></TD>
									<TD class="TDBGColor1" width="17.5%"><asp:label id="Label8" runat="server">Cash-in-Transit Cost/day :</asp:label></TD>
									<TD class="TDBGColorValue" width="16.5%"><asp:textbox id="TXT_CASH_IN_TRANSIT" runat="server" Width="100%"></asp:textbox></TD>
									<TD class="TDBGColor1" width="16.5%"><asp:label id="Label9" runat="server">IT Cost/transaction :</asp:label></TD>
									<TD class="TDBGColorValue" width="16.5%"><asp:textbox id="TXT_IT_C0ST" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="16.5%"><asp:label id="Label10" runat="server">Cable Cost (USD) :</asp:label></TD>
									<TD class="TDBGColorValue" width="16.5%"><asp:textbox id="TXT_CABLE_COST" runat="server" Width="100%"></asp:textbox></TD>
									<TD class="TDBGColor1" width="17.5%"><asp:label id="Label11" runat="server">H2HDevelopment Fee (USD) :</asp:label></TD>
									<TD class="TDBGColorValue" width="16.5%"><asp:textbox id="TXT_H2HDEV_FEE" runat="server" Width="100%"></asp:textbox></TD>
									<TD class="TDBGColor1" width="16.5%"><asp:label id="Label12" runat="server">Joining Fee :</asp:label></TD>
									<TD class="TDBGColorValue" width="16.5%"><asp:textbox id="TXT_JOINING_FEE" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="16.5%"><asp:label id="Label13" runat="server">Cable Fee (USD) :</asp:label></TD>
									<TD class="TDBGColorValue" width="16.5%"><asp:textbox id="TXT_CABLE_FEE" runat="server" Width="100%"></asp:textbox></TD>
									<TD class="TDBGColor1" width="17.5%"><asp:label id="Label14" runat="server">Collection Fee/day :</asp:label></TD>
									<TD class="TDBGColorValue" width="16.5%"><asp:textbox id="TXT_COLLECTION_FEE" runat="server" Width="100%"></asp:textbox></TD>
									<TD class="TDBGColor1" width="16.5%"><asp:label id="Label15" runat="server">Maximum Provision (USD) :</asp:label></TD>
									<TD class="TDBGColorValue" width="16.5%"><asp:textbox id="TXT_MAX_PROVOSION" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="16.5%"><asp:label id="Label16" runat="server">FTP CKPN (%) - IDR :</asp:label></TD>
									<TD class="TDBGColorValue" width="16.5%"><asp:textbox id="TXT_FTP_CKPN_IDR" runat="server" Width="100%"></asp:textbox></TD>
									<TD class="TDBGColor1" width="17.5%"><asp:label id="Label17" runat="server">Commitment Fee(%) :</asp:label></TD>
									<TD class="TDBGColorValue" width="16.5%"><asp:textbox id="TXT_COMMITMENT_FEE" runat="server" Width="100%"></asp:textbox></TD>
									<TD class="TDBGColor1" width="16.5%"><asp:label id="Label18" runat="server">Minimum Fee / Process :</asp:label></TD>
									<TD class="TDBGColorValue" width="16.5%"><asp:textbox id="TXT_MINIMUM_FEE" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="16.5%"><asp:label id="Label19" runat="server">FTP CKPN(%) - Valas :</asp:label></TD>
									<TD class="TDBGColorValue" width="16.5%"><asp:textbox id="TXT_FTP_CKPN_VALAS" runat="server" Width="100%"></asp:textbox></TD>
									<TD class="TDBGColor1" width="17.5%"><asp:label id="Label20" runat="server">Correspondent Cost (USD) :</asp:label></TD>
									<TD class="TDBGColorValue" width="16.5%"><asp:textbox id="TXT_CORRESPONDENT_COST" runat="server" Width="100%"></asp:textbox></TD>
									<TD class="TDBGColor1" width="16.5%"><asp:label id="Label21" runat="server">Minimum Provision (USD) :</asp:label></TD>
									<TD class="TDBGColorValue" width="16.5%"><asp:textbox id="TXT_MINIMUM_PROVISION" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="16.5%"><asp:label id="Label22" runat="server">FTP Cost(%) - IDR :</asp:label></TD>
									<TD class="TDBGColorValue" width="16.5%"><asp:textbox id="TXT_FTP_COST_IDR" runat="server" Width="100%"></asp:textbox></TD>
									<TD class="TDBGColor1" width="17.5%"><asp:label id="Label23" runat="server">Correspondent Fee (USD) :</asp:label></TD>
									<TD class="TDBGColorValue" width="16.5%"><asp:textbox id="TXT_CORRESPONDENT_FEE" runat="server" Width="100%"></asp:textbox></TD>
									<TD class="TDBGColor1" width="16.5%"><asp:label id="Label24" runat="server">Provision(%) - IDR :</asp:label></TD>
									<TD class="TDBGColorValue" width="16.5%"><asp:textbox id="TXT_PROVISION_IDR" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="16.5%"><asp:label id="Label25" runat="server">FTP COST(%)-Valas :</asp:label></TD>
									<TD class="TDBGColorValue" width="16.5%"><asp:textbox id="TXT_FTP_COST_VALAS" runat="server" Width="100%"></asp:textbox></TD>
									<TD class="TDBGColor1" width="17.5%"><asp:label id="Label26" runat="server">Direct IT Cost(Per Million Unit) :</asp:label></TD>
									<TD class="TDBGColorValue" width="16.5%"><asp:textbox id="TXT_DIRECT_IT_COST" runat="server" Width="100%"></asp:textbox></TD>
									<TD class="TDBGColor1" width="16.5%"><asp:label id="Label27" runat="server">Provision(%) - Valas :</asp:label></TD>
									<TD class="TDBGColorValue" width="16.5%"><asp:textbox id="TXT_PROVISION_VALAS" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="16.5%"><asp:label id="Label28" runat="server">FTP Income(%) -IDR :</asp:label></TD>
									<TD class="TDBGColorValue" width="16.5%"><asp:textbox id="TXT_FTP_INCOME_IDR" runat="server" Width="100%"></asp:textbox></TD>
									<TD class="TDBGColor1" width="17.5%"><asp:label id="Label29" runat="server">Fee/transaction :</asp:label></TD>
									<TD class="TDBGColorValue" width="16.5%"><asp:textbox id="TXT_FEE_TRANSACTION" runat="server" Width="100%"></asp:textbox></TD>
									<TD class="TDBGColor1" width="16.5%"><asp:label id="Label30" runat="server">Referral fee income(%) :</asp:label></TD>
									<TD class="TDBGColorValue" width="16.5%"><asp:textbox id="TXT_REFERRAL_FEE_INCOME" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="16.5%"><asp:label id="Label31" runat="server">FTP Income (%)-Valas :</asp:label></TD>
									<TD class="TDBGColorValue" width="16.5%"><asp:textbox id="TXT_FTP_INCOME_VALAS" runat="server" Width="100%"></asp:textbox></TD>
									<TD class="TDBGColor1" width="17.5%"><asp:label id="Label32" runat="server">Non H2H Dev Fee :</asp:label></TD>
									<TD class="TDBGColorValue" width="16.5%"><asp:textbox id="TXT_NON_H2H_DEV_FEE" runat="server" Width="100%"></asp:textbox></TD>
									<TD class="TDBGColor1" width="16.5%"><asp:label id="Label33" runat="server">Service Cost :</asp:label></TD>
									<TD class="TDBGColorValue" width="16.5%"><asp:textbox id="TXT_SERVICE_COST" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="16.5%"><asp:label id="Label34" runat="server">Penalty  fee(%) :</asp:label></TD>
									<TD class="TDBGColorValue" width="16.5%"><asp:textbox id="TXT_PENALTY_FEE" runat="server" Width="100%"></asp:textbox></TD>
									<TD class="TDBGColor1" width="17.5%"><asp:label id="Label35" runat="server">Indirect Cost/transaction :</asp:label></TD>
									<TD class="TDBGColorValue" width="16.5%"><asp:textbox id="TXT_INDIRECT_COST" runat="server" Width="100%"></asp:textbox></TD>
									<TD class="TDBGColor1" width="16.5%"><asp:label id="Label36" runat="server">Service fee(%) :</asp:label></TD>
									<TD class="TDBGColorValue" width="16.5%"><asp:textbox id="TXT_SERVICE_FEE" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="16.5%"><asp:label id="Label37" runat="server">Premium for LPS(%) :</asp:label></TD>
									<TD class="TDBGColorValue" width="16.5%"><asp:textbox id="TXT_PREMIUM_LPS" runat="server" Width="100%"></asp:textbox></TD>
									<TD class="TDBGColor1" width="17.5%"><asp:label id="Label38" runat="server">Monthly Minimum Transaction :</asp:label></TD>
									<TD class="TDBGColorValue" width="16.5%"><asp:textbox id="TXT_MONTHLY_MIN_TRANSACTION" runat="server" Width="100%"></asp:textbox></TD>
									<TD class="TDBGColor1" width="16.5%"><asp:label id="Label39" runat="server">Transaction fee :</asp:label></TD>
									<TD class="TDBGColorValue" width="16.5%"><asp:textbox id="TXT_TRANSACTION_FEE" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="16.5%"><asp:label id="Label40" runat="server">CKPN(%) :</asp:label></TD>
									<TD class="TDBGColorValue" width="16.5%"><asp:textbox id="TXT_CKPN" runat="server" Width="100%"></asp:textbox></TD>
									<TD class="TDBGColor1" width="17.5%"><asp:label id="Label41" runat="server">Provisi Fasilitas/quartal(%) :</asp:label></TD>
									<TD class="TDBGColorValue" width="16.5%"><asp:textbox id="TXT_PROVISI_FASILITAS" runat="server" Width="100%"></asp:textbox></TD>
									<TD class="TDBGColor1" width="16.5%"><asp:label id="Label42" runat="server">Swift Fee(%) :</asp:label></TD>
									<TD class="TDBGColorValue" width="16.5%"><asp:textbox id="TXT_SWIFT_FEE" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="16.5%"><asp:label id="Label43" runat="server">GWM(%) :</asp:label></TD>
									<TD class="TDBGColorValue" width="16.5%"><asp:textbox id="TXT_GWM" runat="server" Width="100%"></asp:textbox></TD>
									<TD class="TDBGColor1" width="17.5%"><asp:label id="Label44" runat="server">Provisi Giro Jaminan(USD) :</asp:label></TD>
									<TD class="TDBGColorValue" width="16.5%"><asp:textbox id="TXT_PROVISI_GIRO_JAMINAN" runat="server" Width="100%"></asp:textbox></TD>
									<TD class="TDBGColor1" width="16.5%"><asp:label id="Label45" runat="server">Syndication Fee(%) :</asp:label></TD>
									<TD class="TDBGColorValue" width="16.5%"><asp:textbox id="TXT_SYNDICATION_FEE" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="16.5%"><asp:label id="Label46" runat="server">Spread(%) :</asp:label></TD>
									<TD class="TDBGColorValue" width="16.5%"><asp:textbox id="TXT_SPREAD" runat="server" Width="100%"></asp:textbox></TD>
									<TD class="TDBGColor1" width="17.5%"><asp:label id="Label47" runat="server">Unit Cost (Per Million Unit) :</asp:label></TD>
									<TD class="TDBGColorValue" width="16.5%"><asp:textbox id="TXT_UNIT_COST" runat="server" Width="100%"></asp:textbox></TD>
									<TD class="TDBGColor1" width="16.5%"><asp:label id="Label48" runat="server">Usage Comission Fee(%) :</asp:label></TD>
									<TD class="TDBGColorValue" width="16.5%"><asp:textbox id="TXT_USAGE_COMISSIOM_FEE" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="16.5%"><asp:label id="Label52" runat="server">Other Cost(%) :</asp:label></TD>
									<TD class="TDBGColorValue" width="16.5%"><asp:textbox id="TXT_OTHER_COST2" runat="server" Width="100%"></asp:textbox></TD>
									<TD class="TDBGColor1" width="17.5%"><asp:label id="Label53" runat="server">Fixed Fee :</asp:label></TD>
									<TD class="TDBGColorValue" width="16.5%"><asp:textbox id="TXT_FIXED_FEE2" runat="server" Width="100%"></asp:textbox></TD>
									<TD class="TDBGColor1" width="16.5%"><asp:label id="Label54" runat="server">FTP GWM (%) :</asp:label></TD>
									<TD class="TDBGColorValue" width="16.5%"><asp:textbox id="TXT_FTP_GWM2" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="16.5%"><asp:label id="Label55" runat="server">Rate/Employee :</asp:label></TD>
									<TD class="TDBGColorValue" width="16.5%"><asp:textbox id="TXT_RATE_EMPLOYEE2" runat="server" Width="100%"></asp:textbox></TD>
									<TD class="TDBGColor1" width="17.5%"><asp:label id="SEQ" runat="server" Visible="False"></asp:label></TD>
									<TD class="TDBGColor1" width="16.5%"></TD>
									<TD class="TDBGColor1" width="16.5%"><asp:label id="Label57" runat="server"></asp:label></TD>
									<TD class="TDBGColor1" width="16.5%"></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD><asp:label id="LBL_ID" runat="server" Visible="False"></asp:label><asp:label id="TXT_ID" runat="server" Visible="False"></asp:label></TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" style="HEIGHT: 32px" vAlign="top" align="center" width="100%"
							colSpan="2"><asp:button id="BTN_SAVE" runat="server" Width="76px" CssClass="button1" Text="SAVE"></asp:button>&nbsp;&nbsp;
							<asp:button id="BTN_CLEAR" runat="server" Width="76px" CssClass="button1" Text="CLEAR"></asp:button></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">EXISTING PARAMETER</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" align="center" width="50%" colSpan="2"><asp:datagrid id="DGR_PRODUCT_LINK_EXIST" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="seq" Visible="False" HeaderText="SEQ">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="ID_AP_VARIABLE" HeaderText="Product Link ID">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="DESCRIPTION" HeaderText="Product Link Name">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="" Visible="False">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PRODUCT_LINK_ID" HeaderText="Product IPS Link">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="" HeaderText="Category" Visible="False">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
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
						<TD class="td" vAlign="top" align="center" width="50%" colSpan="2"><asp:datagrid id="DGR_PRODUCT_LINK_REQ" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="seq" Visible="False" HeaderText="SEQ">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="ID_AP_VARIABLE" HeaderText="Product Link ID">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="DESCRIPTION" HeaderText="Product Link Name">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="" Visible="False">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PRODUCT_LINK_ID" HeaderText="Product IPS Link">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="REQUEST" HeaderText="Status">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="" HeaderText="Category" Visible="False">
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
