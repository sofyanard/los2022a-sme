<%@ Page language="c#" Codebehind="SearchUnitCode.aspx.cs" AutoEventWireup="True" Inherits="SME.MAS.SupervisionManagement.MicroCreditQuality.UnitParameter.SearchUnitCode" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SearchUnitCode</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../../../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../../../../include/cek_entries.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD class="tdH" colSpan="2"></TD>
				</TR>
				<TR>
					<TD class="td" vAlign="top" width="50%">
						<TABLE id="Table2" cellSpacing="2" cellPadding="1" width="100%" border="0">
							<TR>
								<TD class="TDBGColor1" align="right" width="180">Nama Unit/Cabang</TD>
								<TD>:</TD>
								<TD class="TDBGColorValue">&nbsp;
									<asp:textbox id="txt_unit" runat="server"></asp:textbox>&nbsp;
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD class="tdH" align="center" colSpan="2"><asp:button id="BTN_SEARCH" runat="server" Text="Search" onclick="BTN_SEARCH_Click"></asp:button>&nbsp;
						<asp:button id="BTN_cancel" runat="server" Text="Cancel" onclick="BTN_cancel_Click"></asp:button></TD>
				</TR>
				<TR>
					<TD colSpan="2"><ASP:DATAGRID id="DG_List_Unit" runat="server" PageSize="10" CssClass="TDBGGrid" AutoGenerateColumns="False"
							AllowPaging="True" Width="100%">
							<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
							<Columns>
								<asp:BoundColumn DataField="branch_code" HeaderText="Kode Unit/Cabang">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="branch_name" HeaderText="Nama Unit/Cabang">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn>
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:LinkButton id="Linkbutton1" runat="server" CommandName="select">Select</asp:LinkButton>&nbsp;
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</ASP:DATAGRID></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
