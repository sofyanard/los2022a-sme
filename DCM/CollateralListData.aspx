<%@ Page language="c#" Codebehind="CollateralListData.aspx.cs" AutoEventWireup="True" Inherits="SME.DCM.CollateralListData" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CollateralListData</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0">
				<tr>
					<td align="left">
						<TABLE id="Table31">
							<TR>
								<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>COLLATERAL DATA 
										CORRECTION</B></TD>
							</TR>
						</TABLE>
					</td>
					<TD class="tdNoBorder" align="right"><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
				</tr>
				<TR>
					<TD style="HEIGHT: 124px" vAlign="top" align="center" colSpan="2" height="124">
						<TABLE id="Table11" cellSpacing="2" cellPadding="2" width="100%">
							<TBODY>
								<TR>
									<TD class="tdHeader1" colSpan="2"></TD>
								</TR>
								<TR>
									<TD class="td" style="HEIGHT: 36px" vAlign="top" width="90%">
										<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 119px; HEIGHT: 16px">Kelompok Unit Kerja</TD>
												<TD style="WIDTH: 8px; HEIGHT: 16px"></TD>
												<TD class="TDBGColorValue" style="HEIGHT: 16px"><asp:dropdownlist id="DDL_KELOMPOK" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_KELOMPOK_SelectedIndexChanged"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 119px; HEIGHT: 12px">Wilayah</TD>
												<TD style="WIDTH: 8px; HEIGHT: 12px"></TD>
												<TD class="TDBGColorValue" style="HEIGHT: 12px"><asp:dropdownlist id="DDL_WILAYAH" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
											</TR>
											<TR id="TR_UNIT" runat="server">
												<TD class="TDBGColor1" style="WIDTH: 119px; HEIGHT: 17px">Unit Kerja</TD>
												<TD style="WIDTH: 8px; HEIGHT: 17px"></TD>
												<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:dropdownlist id="DDL_UNIT" runat="server" AutoPostBack="True"></asp:dropdownlist>&nbsp;
													<asp:label id="LBL_RCO" runat="server">/ RCO</asp:label><asp:dropdownlist id="DDL_RCO" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
											</TR>
											<!-- Additional Field : Right --></TABLE>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2"><asp:button id="BTN_FIND" runat="server" Text="Find" Width="150px" CssClass="Button1" onclick="BTN_FIND_Click"></asp:button>&nbsp;
										<asp:button id="BTN_CLEAR" runat="server" Text="Clear" Width="150px" CssClass="Button1"></asp:button></TD>
								</TR>
					</TD>
				</TR>
				<TR>
					<TD class="tdHeader1" colSpan="2"></TD>
				</TR>
				<TR>
					<TD colSpan="2"><ASP:DATAGRID id="DatGrd" runat="server" Width="100%" PageSize="20" AutoGenerateColumns="False"
							CellPadding="1" AllowPaging="True">
							<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
							<Columns>
								<asp:BoundColumn DataField="COLL_ID" HeaderText="Coll ID">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="COLL_DESC" HeaderText="Coll Desc">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="COLL_TYPE" HeaderText="Coll Type">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="ACC_NO" HeaderText="Acc No">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CUST_NAME" HeaderText="Acc Name">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="ERROR_MSG" HeaderText="Error Message">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="STATUS_FLAG"></asp:BoundColumn>
								<asp:BoundColumn DataField="STATUS_DESC" HeaderText="Status">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="LINK"></asp:BoundColumn>
								<asp:TemplateColumn>
									<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:LinkButton id="LB_VIEW" runat="server" CommandName="view">View</asp:LinkButton>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn>
									<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:LinkButton id="LB_UPDATE" runat="server" CommandName="update">Update Status</asp:LinkButton>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</ASP:DATAGRID></TD>
				</TR>
				<tr>
					<td colspan="2"></td>
				</tr>
				<TR>
					<TD class="tdHeader1" colSpan="2">Pending Data</TD>
				</TR>
				<TR>
					<TD colSpan="2"><ASP:DATAGRID id="DatGrd2" runat="server" Width="100%" PageSize="7" AutoGenerateColumns="False"
							CellPadding="1" AllowPaging="True">
							<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
							<Columns>
								<asp:BoundColumn DataField="COLL_ID" HeaderText="Coll ID">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="COLL_DESC" HeaderText="Coll Desc">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="COLL_TYPE" HeaderText="Coll Type">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="ACC_NO" HeaderText="Acc No">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CUST_NAME" HeaderText="Acc Name">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="ERROR_MSG" HeaderText="Error Message">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="STATUS_FLAG"></asp:BoundColumn>
								<asp:BoundColumn DataField="STATUS_DESC" HeaderText="Status">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="LINK"></asp:BoundColumn>
								<asp:TemplateColumn>
									<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:LinkButton id="LB_VIEW2" runat="server" CommandName="view">View</asp:LinkButton>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn>
									<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:LinkButton id="LB_UPDATE2" runat="server" CommandName="update">Update Status</asp:LinkButton>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</ASP:DATAGRID></TD>
				</TR>
			</table>
		</form>
		</TD></TR></TBODY></TABLE>
	</body>
</HTML>
