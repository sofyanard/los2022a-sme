<%@ Page language="c#" Codebehind="DataJaminan.aspx.cs" AutoEventWireup="True" Inherits="SME.MAS.CollateralAdministration.DetailCollateral.DataJaminan" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DataJaminan</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
				<TR>
					<TD align="left" colSpan="1">
						<TABLE id="Table3">
							<TR>
								<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Collateral Document 
										Report</B></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR id="TR_SUBMENU" runat="server">
					<TD class="tdNoBorder" align="center" colSpan="2"><asp:placeholder id="PH_SUBMENU" runat="server"></asp:placeholder></TD>
				</TR>
				<TR>
					<TD class="tdHeader1" colSpan="2">Document Report</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 540px" vAlign="top" width="540">
						<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD class="TDBGColor1" style="HEIGHT: 19px" width="75">Account Number</TD>
								<TD style="WIDTH: 15px; HEIGHT: 19px">:</TD>
								<TD class="TDBGColorValue" style="HEIGHT: 19px"><asp:dropdownlist id="DDL_FORMAT_TYPE" runat="server" Width="280px" Visible="False"></asp:dropdownlist>
									<asp:TextBox id="txt_acc_number" runat="server"></asp:TextBox>
									<asp:button id="BTN_EXPORTc" runat="server" Width="64px" Text="Export" onclick="btn_export_Click"></asp:button>
								</TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Status</TD>
								<TD>:</TD>
								<TD class="TDBGColorValue"><asp:label id="LBL_STATUS_EXPORT" runat="server" ForeColor="Red"></asp:label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1"></TD>
								<TD></TD>
								<TD class="TDBGColorValue"><asp:label id="LBL_STATUSEXPORT" runat="server" ForeColor="Red"></asp:label></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 21px" align="center" colSpan="3"></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="3"></TD>
							</TR>
						</TABLE>
					</TD>
					<TD style="HEIGHT: 42px" vAlign="top" width="50%">
						<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD><ASP:DATAGRID id="DATA_EXPORT" runat="server" Width="100%" CellPadding="1" PageSize="1" AutoGenerateColumns="False">
										<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
										<Columns>
											<asp:BoundColumn Visible="False" HeaderText="regnum"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="TEMPLATE_ID"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="FE_USERID"></asp:BoundColumn>
											<asp:BoundColumn DataField="FE_FILENAME" HeaderText="File Name">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn>
												<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
												<ItemTemplate>
													<asp:HyperLink id="FE_DOWNLOAD" runat="server" Target="_blank">Download</asp:HyperLink>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
												<ItemTemplate>
													<asp:LinkButton id="FE_DELETE" runat="server" CommandName="delete">Delete</asp:LinkButton>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn Visible="False" DataField="FE_URL" HeaderText="Download URL"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="SEQ"></asp:BoundColumn>
										</Columns>
									</ASP:DATAGRID></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<tr id="tr0" runat="server" Visible="false">
					<td colSpan="2"><ASP:DATAGRID id="DGR_list_col" runat="server" Width="100%" CellPadding="1" AutoGenerateColumns="False"
							Visible="False" AllowPaging="True">
							<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
							<Columns>
								<asp:BoundColumn HeaderText="Collateral ID" DataField="COLLATERAL_ID">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn HeaderText="Collateral Type" DataField="COLLATERAL_TYPE" Visible="False"></asp:BoundColumn>
								<asp:BoundColumn HeaderText="Collateral Type" DataField="COLLATERAL_TYPE2">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn HeaderText="Collateral Name" DataField="COLLATERAL_NAME">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Function">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:LinkButton id="LNK_CONTINUE" runat="server" CommandName="view" Visible="False">View</asp:LinkButton>
										<asp:HyperLink ID="hyper" runat="server">View</asp:HyperLink>
										<asp:LinkButton id="delete" runat="server" CommandName="delete">Delete</asp:LinkButton>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</ASP:DATAGRID></td>
				</tr>
				<TR id="tr1" runat="server" visible="False">
					<TD colSpan="2"><asp:label id="lbt_type" runat="server">Collateral Type :</asp:label><asp:dropdownlist id="ddl_type_col" runat="server"></asp:dropdownlist><asp:button id="BTN_new" runat="server" Text="Add New Collateral" onclick="BTN_new_Click"></asp:button></TD>
				</TR>
				<TR id="tr2" runat="server" visible="False">
					<TD colSpan="2" height="50%"><iframe id="coldetail" style="WIDTH: 100%; HEIGHT: 500px" name="coldetail" frameBorder="0"
							width="100%" scrolling="auto" runat="server"></iframe>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
