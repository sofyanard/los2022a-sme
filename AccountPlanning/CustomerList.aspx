<%@ Page language="c#" Codebehind="CustomerList.aspx.cs" AutoEventWireup="True" Inherits="SME.AccountPlanning.CustomerList" %>
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
												<TD class="TDBGColor1" style="HEIGHT: 10px" width="30%"><asp:label id="LBL_TXT_SEGMENT" runat="server">Segment :</asp:label></TD>
												<TD class='A"TDBGColorValue"' style="HEIGHT: 10px"><asp:dropdownlist id="DDL_SEGMENT" Width="80%" AutoPostBack="True" Runat="server" onselectedindexchanged="DDL_SEGMENT_SelectedIndexChanged"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 7px" width="30%"><asp:label id="LBL_TXT_UNIT" runat="server">Unit :</asp:label></TD>
												<TD class='A"TDBGColorValue"' style="HEIGHT: 7px"><asp:dropdownlist id="DDL_UNIT" Width="80%" AutoPostBack="True" Runat="server" onselectedindexchanged="DDL_UNIT_SelectedIndexChanged"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 3px" width="30%"><asp:label id="LBL_TXT_CST" runat="server">Anchor Team Lead / RM :</asp:label></TD>
												<TD class='A"TDBGColorValue"' style="HEIGHT: 3px"><asp:TextBox id="TXT_RM_NAME" Width="80%" Runat="server"></asp:TextBox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 9px" width="30%"><asp:label id="LBL_TXT_ANCHOR" runat="server">Anchor Name :</asp:label></TD>
												<TD class='A"TDBGColorValue"' style="HEIGHT: 9px"><asp:TextBox id="TXT_ANCHOR" Width="80%" Runat="server"></asp:TextBox></TD>
											</TR>
											<TR>
												<TD vAlign="top" align="center" colSpan="2"></TD>
											</TR>
											<TR>
												<TD class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2"><asp:button id="BTN_Find" runat="server" Width="200px" CssClass="button1" Text="FIND EXISTING CLIENT" onclick="BTN_Find_Click"></asp:button>&nbsp;&nbsp;
													<asp:button id="BTN_New" runat="server" Width="200px" CssClass="button1" Text="NEW ACTION" Visible="False" onclick="BTN_New_Click"></asp:button></TD>
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
									<asp:BoundColumn DataField="CIF#" Visible="False">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="BUSSUNITID" Visible="False">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="BUSSUNITDESC" HeaderText="Segment">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="BUC" Visible="False">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="BRANCH_NAME" HeaderText="Unit">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CUSTOMER_NAME" HeaderText="Subsidiary Name">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="RM_NAME" HeaderText="Anchor Team Lead / RM">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CUSTOMER_GROUP" HeaderText="Anchor Name">
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
