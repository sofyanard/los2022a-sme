<%@ Page language="c#" Codebehind="UploadList.aspx.cs" AutoEventWireup="True" Inherits="SME.ITTP.UploadList" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>UploadList</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_entries.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table4" width="100%" border="0">
					<TR>
						<TD align="left" colSpan="1">
							<TABLE id="Table3">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Upload List</B></TD>
								</TR>
							</TABLE>
						</TD>
						<td align="right"><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></td>
					</TR>
					<tr>
						<td style="HEIGHT: 28px" colSpan="2">
							<table>
								<tr>
									<td class="TDBGColor1" style="WIDTH: 110px">Find Application :</td>
									<td style="WIDTH: 5px"></td>
									<td><asp:dropdownlist id="DDL_FIND_KRITERIA" runat="server"></asp:dropdownlist><asp:textbox id="TXT_FIND_KRITERIA" runat="server"></asp:textbox></td>
									<td style="WIDTH: 5px"></td>
									<td><asp:button id="BTN_FIND" runat="server" Text="F i n d"></asp:button><asp:label id="lbl_prod" runat="server" Visible="False" MaxLength="20" Columns="30" Width="176px"></asp:label><asp:label id="lbl_apptype" runat="server" Visible="False" MaxLength="20" Columns="30" Width="176px"></asp:label><asp:label id="lbl_track" runat="server" Visible="False" MaxLength="20" Columns="30" Width="176px"></asp:label><asp:label id="lbl_userid" runat="server" Visible="False"></asp:label></td>
								</tr>
							</table>
						</td>
					</tr>
					<TR>
						<TD align="center" colSpan="2">&nbsp;</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 34px" align="center" bgColor="#ff0000" colSpan="2"><FONT face="Arial Unicode MS" color="white" size="3"><STRONG>Note 
									: Untuk deposito sebagai collateral, diminta melaksanakan blokir di BDS/eMAS</STRONG></FONT></TD>
					</TR>
					<TR>
						<TD colSpan="2"><ASP:DATAGRID id="DataGrid1" runat="server" Width="100%" CellPadding="1" AutoGenerateColumns="False"
								AllowPaging="True">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="CU_REF"></asp:BoundColumn>
									<asp:BoundColumn DataField="AP_REGNO" SortExpression="AP_REGNO" HeaderText="Application #">
										<HeaderStyle Width="15%" CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="NAME" SortExpression="NAME" HeaderText="Customer Name">
										<HeaderStyle Width="15%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="120px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AP_SIGNDATE" SortExpression="AP_SIGNDATE" HeaderText="Appl. Date">
										<HeaderStyle Width="10%" CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AD_LIMIT" HeaderText="Limit" DataFormatString="{0:00.00,00}">
										<HeaderStyle Width="15%" CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="txntype" HeaderText="Transaction Type">
										<HeaderStyle Width="15%" CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AP_RELMNGR" SortExpression="SU_FULLNAME" HeaderText="PIC Unit Business">
										<HeaderStyle Width="15%" CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Confirm">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											&nbsp;
											<asp:Image id="IMG_CONFIRM" runat="server"></asp:Image>
											<asp:Label id="LBL_CONFIRM" runat="server"></asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Function">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											&nbsp;
											<asp:LinkButton id="BTN_GRID_VIEW" runat="server" CommandName="view">View</asp:LinkButton>&nbsp;
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn Visible="False" DataField="AP_CO" HeaderText="AP_CO"></asp:BoundColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
					<TR>
					</TR>
					<TR>
						<TD class="tdH" colSpan="2"><asp:label id="Label1" runat="server"></asp:label><asp:label id="LBL_CBC_CODE" runat="server" Visible="False"></asp:label><asp:label id="LBL_BR_CCOBRANCH" runat="server" Visible="False"></asp:label><asp:label id="LBL_TC" runat="server" Visible="False"></asp:label><asp:label id="LBL_SORTEXP" runat="server" Visible="False">AP_REGNO</asp:label><asp:label id="LBL_SORTTYPE" runat="server" Visible="False">ASC</asp:label></TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" align="center" colSpan="2">&nbsp;
							<asp:button id="BTN_UPDATE" Text="Update Status" CssClass="button1" Runat="server" onclick="BTN_UPDATE_Click"></asp:button></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
