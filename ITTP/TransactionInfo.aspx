<%@ Page language="c#" Codebehind="TransactionInfo.aspx.cs" AutoEventWireup="True" Inherits="SME.ITTP.TransactionInfo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>TransactionInfo</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_mandatory.html" -->
		<!-- #include file="../include/cek_entries.html" -->
		<!-- #include file="../include/popup.html" -->
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TBODY>
						<TR>
							<TD colSpan="2"></TD>
						</TR>
						<TR>
							<TD class="tdNoBorder">
								<TABLE id="Table4">
									<TR>
										<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Main - General Info</B></TD>
									</TR>
								</TABLE>
							</TD>
							<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
						</TR>
						<TR>
							<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
						</TR>
						<TR>
							<TD class="tdheader1" colSpan="2">General Information</TD>
						</TR>
						<TR>
							<TD colSpan="2">
								<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="100%" border="0">
									<TR>
										<TD id="temp_txt_business_unit">
											<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 0px">Region</TD>
													<TD style="WIDTH: 8px">:</TD>
													<TD class="TDBGColorValue" style="WIDTH: 152px"><asp:textbox id="TXT_REGION" runat="server" Width="100%"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 0px; HEIGHT: 23px">Business Unit / Cabang</TD>
													<TD style="WIDTH: 8px; HEIGHT: 23px">:</TD>
													<TD class="TDBGColorValue" style="WIDTH: 152px; HEIGHT: 23px"><asp:textbox id="TXT_BUSINESS_UNIT" runat="server" Width="100%"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 0px; HEIGHT: 18px">Program</TD>
													<TD style="WIDTH: 8px; HEIGHT: 18px">:</TD>
													<TD class="TDBGColorValue" style="WIDTH: 152px; HEIGHT: 18px"><asp:dropdownlist id="DDL_PROGRAM" runat="server" CssClass="mandatory" AutoPostBack="True"></asp:dropdownlist></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 0px">Processing&nbsp;Unit</TD>
													<TD style="WIDTH: 8px">:</TD>
													<TD class="TDBGColorValue" style="WIDTH: 152px"><asp:dropdownlist id="DDL_OPERATION_UNIT" runat="server" CssClass="mandatory" AutoPostBack="True"></asp:dropdownlist></TD>
												</TR> <!-- Additional Field : Right --></TABLE>
											<asp:label id="temp_txt_business_unit" runat="server">temp_txt_business_unit</asp:label></TD>
										<TD>
											<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%">
												<TR>
													<TD class="TDBGColor1" style="HEIGHT: 21px" width="150">Application Date</TD>
													<TD style="WIDTH: 15px; HEIGHT: 21px">:</TD>
													<TD class="TDBGColorValue" style="HEIGHT: 21px"><asp:textbox onkeypress="return numbersonly()" id="TXT_AP_SIGNDATE_DAY" runat="server" Width="32px"
															CssClass="mandatory" MaxLength="2" Columns="4" Height="19px"></asp:textbox><asp:dropdownlist id="DDL_AP_SIGNDATE_MONTH" runat="server" Width="88px" CssClass="mandatory" Height="17px"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_AP_SIGNDATE_YEAR" runat="server" Width="51px"
															CssClass="mandatory" MaxLength="4" Columns="4" Height="18px"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Application Number</TD>
													<TD>:</TD>
													<TD class="TDBGColorValue"><asp:textbox id="TXT_AP_REGNO" runat="server" Width="168px" Height="25px" BorderStyle="None"
															ReadOnly="True"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1"></TD>
													<TD></TD>
													<TD class="TDBGColorValue" style="HEIGHT: 17px"></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1"></TD>
													<TD></TD>
													<TD class="TDBGColorValue" style="HEIGHT: 17px"></TD>
												</TR> <!-- 14 --> <!-- 21 --> <!-- Additional Field : Right --></TABLE>
										</TD>
									</TR>
									<TR>
										<TD class="TDBGColor2" style="HEIGHT: 18px" vAlign="top" align="center" colSpan="2"><asp:button id="BTN_SAVE" runat="server" Width="100px" CssClass="Button1" Text="Save"></asp:button><asp:button id="BTN_UPDATE_STATUS" runat="server" Width="100px" CssClass="Button1" Text="Update Status"></asp:button></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<tr>
							<td style="HEIGHT: 35px" colSpan="2">
								<CENTER><asp:textbox id="txt_acqinfo" Width="100%" Height="47px" ReadOnly="True" TextMode="MultiLine"
										Runat="server"></asp:textbox></CENTER>
							</td>
						</tr>
						<TR>
							<TD align="center" colSpan="2">
								<TABLE class="td" id="Table7" cellSpacing="1" cellPadding="1" width="100%" border="0">
									<TR>
										<TD class="tdheader1">REQUEST TYPE</TD>
									</TR>
									<TR>
										<TD>
											<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="100%" border="0">
												<TR>
													<TD class="TDBGColor1">Earmark Facility</TD>
													<TD>:</TD>
													<TD><asp:radiobuttonlist id="RDO_EARMARK" runat="server" AutoPostBack="True" RepeatLayout="Flow">
															<asp:ListItem Value="1" Selected="True">Yes</asp:ListItem>
															<asp:ListItem Value="0">No</asp:ListItem>
														</asp:radiobuttonlist></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Facility</TD>
													<TD>:</TD>
													<TD><asp:dropdownlist id="DDL_FACILITY" runat="server" AutoPostBack="True"></asp:dropdownlist>&nbsp;| 
														Remaining Limit :
														<asp:label id="LBL_REMAINING_EMAS_LIMIT" runat="server"></asp:label></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Transaction Type</TD>
													<TD>:</TD>
													<TD><asp:dropdownlist id="DDL_TRANSACTION_TYPE" runat="server" AutoPostBack="True"></asp:dropdownlist>&nbsp;| 
														Trade Code :
														<asp:dropdownlist id="DDL_TRADE_CODE" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Transaction Limit</TD>
													<TD>:</TD>
													<TD><asp:textbox id="TXT_TRANSACTION_LIMIT" runat="server" Width="72px"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Exchange Rate to Rp</TD>
													<TD>:</TD>
													<TD><asp:textbox id="TXT_EXCHANGE_RATE" runat="server" Width="72px"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Limit in Rp</TD>
													<TD>:</TD>
													<TD><asp:textbox id="TXT_LIMIT_IN_RP" runat="server" Width="72px"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Tenor</TD>
													<TD>:</TD>
													<TD><asp:textbox id="TXT_TENOR" runat="server" Width="72px"></asp:textbox><asp:dropdownlist id="DDL_TENOR" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Jaminan</TD>
													<TD>:</TD>
													<TD>Tipe :<asp:dropdownlist id="DDL_JAMINAN" runat="server"></asp:dropdownlist>
														&nbsp;&nbsp;Nomor Rekening :
														<asp:textbox id="DDL_REKENING" runat="server" Width="72px"></asp:textbox></TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
									<TR>
										<TD class="tdbgcolor2"><asp:button id="BTN_ADD" runat="server" Width="125px" CssClass="button1" Text="Add Request"></asp:button></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR id="TR_COLL3" runat="server">
							<TD colSpan="2">
								<TABLE class="td" id="Table8" cellSpacing="1" cellPadding="1" width="100%" border="0">
									<TR>
										<TD class="tdheader1">List Request</TD>
									</TR>
									<TR>
										<TD><ASP:DATAGRID id="DATAGRID1" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False"
												PageSize="5">
												<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
												<Columns>
													<asp:BoundColumn Visible="False" DataField="AP_REGNO" HeaderText="AP_REGNO"></asp:BoundColumn>
													<asp:BoundColumn DataField="APPTYPEDESC" HeaderText="Transaction Type">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="APPTYPE"></asp:BoundColumn>
													<asp:BoundColumn DataField="PRODUCTDESC" HeaderText="Facility">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="productid"></asp:BoundColumn>
													<asp:BoundColumn DataField="CP_EXLIMITVAL" HeaderText="Amount" DataFormatString="{0:00,00.00}">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="CP_EXRPLIMIT" HeaderText="Exchange Rate">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="CP_LIMIT" HeaderText="Amount in IDR">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="PRODUCTID" HeaderText="PRODUCTID"></asp:BoundColumn>
													<asp:BoundColumn DataField="TENORDESC" HeaderText="Tenor">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="PROD_SEQ" HeaderText="PROD_SEQ"></asp:BoundColumn>
													<asp:TemplateColumn HeaderText="Collateral">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
														<ItemTemplate>
															<asp:LinkButton id="LNK_VIEW" runat="server" CommandName="view">view</asp:LinkButton>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:TemplateColumn HeaderText="Function">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
														<ItemTemplate>
															&nbsp;&nbsp;&nbsp;
															<asp:LinkButton id="LNK_DELETE" runat="server" CommandName="delete">Delete</asp:LinkButton>
														</ItemTemplate>
													</asp:TemplateColumn>
												</Columns>
												<PagerStyle Mode="NumericPages"></PagerStyle>
											</ASP:DATAGRID></TD>
									</TR>
									<TR id="TR_BUTTONS1" runat="server">
										<TD class="tdbgcolor2"><asp:button id="Button1" runat="server" Width="180px" CssClass="button1" Text="Save Request"
												Enabled="False" Visible="False"></asp:button><asp:listbox id="ListBox2" runat="server" Width="10px" Height="25px" Visible="False"></asp:listbox></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
					</TBODY>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
