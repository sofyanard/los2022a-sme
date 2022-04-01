<%@ Page language="c#" Codebehind="CustomerList.aspx.cs" AutoEventWireup="True" Inherits="SME.Syndication.CustomerList" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>CustomerList</TITLE>
		<META content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY MS_POSITIONING="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<CENTER>
				<TABLE width="100%" border="0">
					<TR>
						<TD align="left" width="50%">
							<TABLE id="Table1">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>CUSTOMER LIST</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A>
							<A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A>
						</TD>
					</TR>
				</TABLE>
				<TABLE width="100%" align="center" border="0">
					<TR>
						<TD align="center" colSpan="2">
							<TABLE class="td" id="Table2" cellSpacing="1" cellPadding="1" width="50%" border="0">
								<TR>
									<TD class="tdHeader1">SEARCH CRITERIA</TD>
								</TR>
								<TR>
									<TD vAlign="top" align="center">
										<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 10px" width="40%"><asp:label id="LBL_TXT_CIF" runat="server">CIF Number :</asp:label></TD>
												<TD class="TDBGColorValue" style="HEIGHT: 10px" width="60%"><asp:textbox id="TXT_CIF" Width="100%" Runat="server"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 7px" width="40%"><asp:label id="LBL_TXT_CUST" runat="server">Customer Name :</asp:label></TD>
												<TD class="TDBGColorValue" style="HEIGHT: 7px" width="60%"><asp:textbox id="TXT_CUST" Width="100%" Runat="server"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 3px" width="40%"><asp:label id="LBL_TXT_NO_SIUP" runat="server">No. SIUP/TDP :</asp:label></TD>
												<TD class="TDBGColorValue" style="HEIGHT: 3px" width="60%"><asp:textbox id="TXT_NO_SIUP" Width="100%" Runat="server"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 9px" width="40%"><asp:label id="LBL_TXT_NO_NPWP" runat="server">NPWP Number :</asp:label></TD>
												<TD class="TDBGColorValue" style="HEIGHT: 9px" width="60%"><asp:textbox id="TXT_NO_NPWP" Width="100%" Runat="server"></asp:textbox></TD>
											</TR>
											<TR>
												<TD vAlign="top" align="center" colSpan="2"></TD>
											</TR>
											<TR>
												<TD class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2"><asp:button id="BTN_FIND" runat="server" Width="150px" CssClass="button1" Text="FIND EXISTING" onclick="BTN_FIND_Click"></asp:button>&nbsp;&nbsp;
													<asp:button id="BTN_NEW" runat="server" Width="150px" CssClass="button1" Text="NEW CUSTOMER"
														Visible="False" onclick="BTN_NEW_Click"></asp:button>&nbsp;&nbsp;
													<asp:button id="BTN_CLEAR" runat="server" Width="150px" CssClass="button1" Text="CLEAR" Visible="False" onclick="BTN_CLEAR_Click"></asp:button></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" align="center" width="50%" colSpan="2"><asp:datagrid id="DATA_GRID" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="True">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="SEQ" Visible="False">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CU_REF" Visible="False">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CIF" HeaderText="CIF#">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CUST_NAME" HeaderText="Customer Name">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="SIUP_TDP_NUMBER" HeaderText="ID Number">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="NPWP" HeaderText="NPWP Number">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Function">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="LNK_CONTINUE" runat="server" CommandName="continue">Continue</asp:LinkButton>
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
