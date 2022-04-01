<%@ Page language="c#" Codebehind="CreditFacility.aspx.cs" AutoEventWireup="True" Inherits="SME.Syndication.CustomerBasicInformation.CreditFacility" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>CreditFacility</TITLE>
		<META content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
		<!-- #include file = "../../include/cek_entries.html" -->
	</HEAD>
	<BODY MS_POSITIONING="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<CENTER>
				<TABLE width="100%" border="0">
					<TR>
						<TD align="left" width="50%">
							<TABLE id="Table1">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>CREDIT FACILITY</B></TD>
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
						<TD class="tdHeader1" colSpan="2">FACILITIES INFO</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" align="center" width="50%" colSpan="2">
							<asp:datagrid id="DGR_FACILITY" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="BANKNAME" HeaderText="Nama Bank">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CURR" HeaderText="Currency">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="SUM_VALUTA" HeaderText="Nilai Valuta Asal">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="SUM_IDR" HeaderText="Nilai Dalam Rupiah">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="SHARE" HeaderText="%Share">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</asp:datagrid>
						</TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">KREDIT INVESTASI</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" align="center" width="50%" colSpan="2">
							<asp:datagrid id="DGR_KREDIT_INVESTASI" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="SEQ" Visible="False">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="BANK_NM" HeaderText="Nama Bank">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CURR" HeaderText="Currency">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="LIMIT_POKOK" HeaderText="Limit Pokok">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="LIMIT_IDC" HeaderText="Limit IDC">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="LIMIT_POKOK_RP" HeaderText="Limit Pokok(rp.)">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="LIMIT_IDC_RP" HeaderText="Limit IDC(rp.)">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="RATE_PERCENT" HeaderText="Bunga Pokok">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="RATE_IDC_PERCENT" HeaderText="Bunga IDC">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="START_DATE" HeaderText="Tgl.Mulai">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="MATURITY_DATE" HeaderText="Tgl.Akhir">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Function">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="LNK_EDIT_INVEST" runat="server" CommandName="edit">Edit</asp:LinkButton>
											<asp:LinkButton id="LNK_DELETE_INVEST" runat="server" CommandName="delete">Delete</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</asp:datagrid>
						</TD>
					</TR>
					<TR>
						<TD class="td" style="HEIGHT: 7px" vAlign="top" width="50%">
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_BANK_NM_INVEST" runat="server">Nama Bank :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_BANK_NM_INVEST" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_CURRENCY_INVEST" runat="server">Currency :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CURRENCY_INVEST" runat="server" Width="100%" AutoPostBack="True" onselectedindexchanged="DDL_CURRENCY_INVEST_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_EXCHANGE_INVEST" runat="server">Exchange Rate :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_EXCHANGE_INVEST" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_LIMIT_POKOK_INVEST" runat="server">Limit Pokok :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_LIMIT_POKOK_INVEST" runat="server"
											Width="100%" AutoPostBack="True" ontextchanged="TXT_LIMIT_POKOK_INVEST_TextChanged"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_LIMIT_IDC_INVEST" runat="server">Limit IDC :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_LIMIT_IDC_INVEST" runat="server"
											Width="100%" AutoPostBack="True" ontextchanged="TXT_LIMIT_IDC_INVEST_TextChanged"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_LIMIT_POKOK_RP_INVEST" runat="server">Limit Pokok (rp.) :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_LIMIT_POKOK_RP_INVEST" runat="server"
											Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_LIMIT_IDC_RP_INVEST" runat="server">Limit IDC (rp.) :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_LIMIT_IDC_RP_INVEST" runat="server"
											Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_BUNGA_POKOK_INVEST" runat="server">Suku Bunga Pokok :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_BUNGA_POKOK_INVEST" runat="server"
											Width="100%"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" style="HEIGHT: 7px" vAlign="top" width="50%">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_BUNGA_IDC_INVEST" runat="server">Suku Bunga IDC :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_BUNGA_IDC_INVEST" runat="server"
											Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_IDC_PERCENT_INVEST" runat="server">%IDC :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_IDC_PERCENT_INVEST" runat="server"
											Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_START_DATE_INVEST" runat="server">Tanggal Mulai :</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_START_DAY_INVEST" runat="server" Width="24px"
											Columns="4" MaxLength="2"></asp:textbox><asp:dropdownlist id="DDL_START_MONTH_INVEST" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_START_YEAR_INVEST" runat="server" Width="36px"
											Columns="4" MaxLength="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_MATURITY_DATE_INVEST" runat="server">Tanggal Akhir :</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_MATURITY_DAY_INVEST" runat="server" Width="24px"
											Columns="4" MaxLength="2"></asp:textbox><asp:dropdownlist id="DDL_MATURITY_MONTH_INVEST" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_MATURITY_YEAR_INVEST" runat="server" Width="36px"
											Columns="4" MaxLength="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_BUNGA_DENDA_PERCENT_INVEST" runat="server">Suku Bunga Denda(%) :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_BUNGA_DENDA_PERCENT_INVEST" runat="server"
											Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_COMMITMENT_FEE_PERCENT_INVEST" runat="server">Commitment fee(%) :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_COMMITMENT_FEE_PERCENT_INVEST" runat="server"
											Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_OTHERS_FEE_PERCENT_INVEST" runat="server">Others fee(%) :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_OTHERS_FEE_PERCENT_INVEST" runat="server"
											Width="100%"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" colSpan="3" height="10">
							<asp:label id="LBL_SEQ_INVEST" runat="server" Visible="False"></asp:label>
							<asp:button id="BTN_SAVE_INVEST" runat="server" Width="100px" CssClass="button1" Text="INSERT" onclick="BTN_SAVE_INVEST_Click"></asp:button>&nbsp;&nbsp;
							<asp:button id="BTN_CLEAR_INVEST" runat="server" Width="100px" CssClass="button1" Text="CLEAR" onclick="BTN_CLEAR_INVEST_Click"></asp:button>
						</TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">KREDIT MODAL KERJA</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" align="center" width="50%" colSpan="2">
							<asp:datagrid id="DGR_KREDIT_MODAL_KERJA" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="SEQ" Visible="False">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="BANK_NM" HeaderText="Nama Bank">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CURR" HeaderText="Currency">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="LIMIT_POKOK" HeaderText="Limit">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="LIMIT_POKOK_RP" HeaderText="Limit(rp.)">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="RATE_PERCENT" HeaderText="Suku Bunga">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="START_DATE" HeaderText="Tgl.Mulai">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="MATURITY_DATE" HeaderText="Tgl.Akhir">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Function">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="LNK_EDIT_MODAL_KERJA" runat="server" CommandName="edit">Edit</asp:LinkButton>
											<asp:LinkButton id="LNK_DELETE_MODAL_KERJA" runat="server" CommandName="delete">Delete</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</asp:datagrid>
						</TD>
					</TR>
					<TR>
						<TD class="td" style="HEIGHT: 7px" vAlign="top" width="50%">
							<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_BANK_NM_MODAL" runat="server">Nama Bank :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_BANK_NM_MODAL" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_CURRENCY_MODAL" runat="server">Currency :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CURRENCY_MODAL" runat="server" Width="100%" AutoPostBack="True" onselectedindexchanged="DDL_CURRENCY_MODAL_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_EXCHANGE_MODAL" runat="server">Exchange Rate :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_EXCHANGE_MODAL" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_LIMIT_POKOK_MODAL" runat="server">Limit :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_LIMIT_POKOK_MODAL" runat="server"
											Width="100%" AutoPostBack="True" ontextchanged="TXT_LIMIT_POKOK_MODAL_TextChanged"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_LIMIT_POKOK_RP_MODAL" runat="server">Limit (rp.) :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_LIMIT_POKOK_RP_MODAL" runat="server"
											Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_SUKU_BUNGA_MODAL" runat="server">Suku Bunga :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_SUKU_BUNGA_MODAL" runat="server"
											Width="100%"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" style="HEIGHT: 7px" vAlign="top" width="50%">
							<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_BUNGA_DENDA_PERCENT_MODAL" runat="server">Bunga Denda(%) :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_BUNGA_DENDA_PERCENT_MODAL" runat="server"
											Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_COMMITMENT_FEE_PERCENT_MODAL" runat="server">Commitment fee(%) :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_COMMITMENT_FEE_PERCENT_MODAL" runat="server"
											Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_OTHERS_FEE_PERCENT_MODAL" runat="server">Others fee(%) :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_OTHERS_FEE_PERCENT_MODAL" runat="server"
											Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_START_DATE_MODAL" runat="server">Tanggal Mulai :</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_START_DAY_MODAL" runat="server" Width="24px"
											Columns="4" MaxLength="2"></asp:textbox><asp:dropdownlist id="DDL_START_MONTH_MODAL" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_START_YEAR_MODAL" runat="server" Width="36px"
											Columns="4" MaxLength="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_MATURITY_DATE_MODAL" runat="server">Tanggal Akhir :</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_MATURITY_DAY_MODAL" runat="server" Width="24px"
											Columns="4" MaxLength="2"></asp:textbox><asp:dropdownlist id="DDL_MATURITY_MONTH_MODAL" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_MATURITY_YEAR_MODAL" runat="server" Width="36px"
											Columns="4" MaxLength="4"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" colSpan="3" height="10">
							<asp:label id="LBL_SEQ_MODAL" runat="server" Visible="False"></asp:label>
							<asp:button id="BTN_SAVE_MODAL" runat="server" Width="100px" CssClass="button1" Text="INSERT" onclick="BTN_SAVE_MODAL_Click"></asp:button>&nbsp;&nbsp;
							<asp:button id="BTN_CLEAR_MODAL" runat="server" Width="100px" CssClass="button1" Text="CLEAR" onclick="BTN_CLEAR_MODAL_Click"></asp:button>
						</TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">NON CASH LOAN</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" align="center" width="50%" colSpan="2">
							<asp:datagrid id="DGR_NONCASH_LOAN" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="SEQ" Visible="False">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="BANK_NM" HeaderText="Bank Pembuka">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="NCL_PRODUCT_TYPE" HeaderText="Product Type">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CURR" HeaderText="Currency">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="LIMIT_POKOK" HeaderText="Nominal">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="LIMIT_POKOK_RP" HeaderText="Nominal(rp.)">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="START_DATE" HeaderText="Tgl.Mulai">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="MATURITY_DATE" HeaderText="Tgl.Akhir">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Function">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="LNK_EDIT_NONCASH" runat="server" CommandName="edit">Edit</asp:LinkButton>
											<asp:LinkButton id="LNK_DELETE_NONCASH" runat="server" CommandName="delete">Delete</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</asp:datagrid>
						</TD>
					</TR>
					<TR>
						<TD class="td" style="HEIGHT: 7px" vAlign="top" width="50%">
							<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_BANK_NM_NONCASH" runat="server">Bank Pembuka :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_BANK_NM_NONCASH" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_PRODUCT_TYPE_NONCASH" runat="server">Product Type :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_PRODUCT_TYPE_NONCASH" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%" style="HEIGHT: 20px"><asp:label id="LBL_TXT_CURRENCY_NONCASH" runat="server">Currency :</asp:label></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:dropdownlist id="DDL_CURRENCY_NONCASH" runat="server" Width="100%" AutoPostBack="True" onselectedindexchanged="DDL_CURRENCY_NONCASH_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_EXCHANGE_NONCASH" runat="server">Exchange Rate :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_EXCHANGE_NONCASH" runat="server"
											Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_NOMINAL_NONCASH" runat="server">Nominal :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_NOMINAL_NONCASH" runat="server" Width="100%"
											AutoPostBack="True" ontextchanged="TXT_NOMINAL_NONCASH_TextChanged"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_NOMINAL_RP_NONCASH" runat="server">Nominal(rp.) :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_NOMINAL_RP_NONCASH" runat="server"
											Width="100%"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" style="HEIGHT: 7px" vAlign="top" width="50%">
							<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_PROVISI_KOMISI_PERCENT_NONCASH" runat="server">Provisi/Komisi(%) :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_PROVISI_KOMISI_PERCENT_NONCASH" runat="server"
											Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_OTHERS_FEE_PERCENT_NONCASH" runat="server">Others Fee(%) :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_OTHERS_FEE_PERCENT_NONCASH" runat="server"
											Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_START_DATE_NONCASH" runat="server">Tanggal Mulai :</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_START_DAY_NONCASH" runat="server" Width="24px"
											Columns="4" MaxLength="2"></asp:textbox><asp:dropdownlist id="DDL_START_MONTH_NONCASH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_START_YEAR_NONCASH" runat="server" Width="36px"
											Columns="4" MaxLength="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_MATURITY_DATE_NONCASH" runat="server">Tanggal Akhir :</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_MATURITY_DAY_NONCASH" runat="server" Width="24px"
											Columns="4" MaxLength="2"></asp:textbox><asp:dropdownlist id="DDL_MATURITY_MONTH_NONCASH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_MATURITY_YEAR_NONCASH" runat="server"
											Width="36px" Columns="4" MaxLength="4"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" colSpan="3" height="10">
							<asp:label id="LBL_SEQ_NONCASH" runat="server" Visible="False"></asp:label>
							<asp:button id="BTN_SAVE_NONCASH" runat="server" Width="100px" CssClass="button1" Text="INSERT" onclick="BTN_SAVE_NONCASH_Click"></asp:button>&nbsp;&nbsp;
							<asp:button id="BTN_CLEAR_NONCASH" runat="server" Width="100px" CssClass="button1" Text="CLEAR" onclick="BTN_CLEAR_NONCASH_Click"></asp:button>
						</TD>
					</TR>
				</TABLE>
			</CENTER>
		</FORM>
	</BODY>
</HTML>
