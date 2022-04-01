<%@ Page language="c#" Codebehind="WalletSetupTarget.aspx.cs" AutoEventWireup="True" Inherits="SME.AccountPlanning.WalletShareTarget.WalletSetupTarget" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>WalletSetupTarget</TITLE>
		<META content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY MS_POSITIONING="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<CENTER>
				<TABLE id="MAIN_TABLE" width="100%" border="0" runat="server">
					<TR>
						<TD align="left" width="50%">
							<TABLE id="Table1">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>&nbsp;INQUIRY WALLET SIZE</B></TD>
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
					<tr>
						<td colSpan="2">
							<table width="100%">
								<TR>
									<TD vAlign="top" align="center" colSpan="2">
										<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="60%" border="0">
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 15px" width="40%">Group Unit Name :</TD>
												<TD class="TDBGColorValue" style="HEIGHT: 15px" width="60%"><asp:dropdownlist id="DDL_GROUP_UNIT" Runat="server" AutoPostBack="True" Width="100%" CssClass="Mandatory" onselectedindexchanged="DDL_GROUP_UNIT_SelectedIndexChanged"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 14px" width="40%">Unit Name :</TD>
												<TD class="TDBGColorValue" style="HEIGHT: 14px" width="60%"><asp:dropdownlist id="DDL_UNIT" Runat="server" AutoPostBack="True" Width="100%" CssClass="Mandatory" onselectedindexchanged="DDL_UNIT_SelectedIndexChanged"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 18px" width="40%">Industry Name :</TD>
												<TD class="TDBGColorValue" style="HEIGHT: 18px" width="60%"><asp:dropdownlist id="DDL_INDUSTRY" Runat="server" AutoPostBack="True" Width="100%" CssClass="Mandatory" onselectedindexchanged="DDL_INDUSTRY_SelectedIndexChanged"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 11px" width="40%">Company Name :</TD>
												<TD class="TDBGColorValue" style="HEIGHT: 11px" width="60%"><asp:dropdownlist id="DDL_COMPANY" runat="server" Width="100%" CssClass="Mandatory"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD vAlign="top" align="center" colSpan="2"></TD>
											</TR>
											<TR>
												<TD class="TDBGColor2" vAlign="top" align="center" colSpan="3" height="10"><asp:button id="BTN_Find" runat="server" Width="80px" Text="Retrieve" CssClass="button1" onclick="BTN_Find_Click"></asp:button>&nbsp;<asp:button id="BTN_Cancel" runat="server" Width="80px" Text="Clear" CssClass="button1"></asp:button></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</table>
							<center>
								<table class="td" height="35" cellSpacing="1" cellPadding="1" width="100%" border="1">
									<TR>
										<TD class="tdHeader1" colSpan="7" height="35">RETRIEVE&nbsp;RESULT</TD>
									</TR>
									<TR>
										<TD colSpan="2">
											<ASP:DATAGRID id="DatagridWalletMain" runat="server" Width="100%" AutoGenerateColumns="False"
												CellPadding="1" PageSize="1">
												<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
												<Columns>
													<asp:BoundColumn DataField="CIF_GROUP" HeaderText="CIF Group">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="CU_CIF" HeaderText="CIF Company">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="WHOLESALECATEGORY" HeaderText="Product Group">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="WALLETSIZECATEGORY" HeaderText="Product Category">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="WALLETSIZEPRODUCT" HeaderText="Sub Product">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="CURRENT_INCOME" HeaderText="Current Income">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="POTENTIAL_INCOME" HeaderText="Potential Income">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="CURRENT_VOLUME" HeaderText="Current Volume">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="POTENTIAL_VOLUME" HeaderText="Potential Volume">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="COMPANY_ANNUAL_REVENUE" HeaderText="Company Annual Revenue">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
													</asp:BoundColumn>
												</Columns>
											</ASP:DATAGRID></TD>
									</TR>
								</table>
							</center>
						</td>
					</tr>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" colSpan="3" height="10">
							<asp:button id="Button1" runat="server" Width="80px" Text="Print" CssClass="button1" onclick="Button1_Click"></asp:button>
						</TD>
					</TR>
				</TABLE>
			</CENTER>
		</FORM>
	</BODY>
</HTML>
