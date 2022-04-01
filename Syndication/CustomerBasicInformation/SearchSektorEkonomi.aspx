<%@ Page language="c#" Codebehind="SearchSektorEkonomi.aspx.cs" AutoEventWireup="True" Inherits="SME.Syndication.CustomerBasicInformation.SearchSektorEkonomi" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SearchSektorEkonomi</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
		<script language="javascript">
			function SektorEkonomiSelect(theForm, frmSE1, frmSE1Value)
			{
				frmSE1.value = frmSE1Value;
				theForm.submit();
				window.close();
			}
		</script>
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
								<TD class="TDBGColor1" align="right" width="180">Sektor Ekonomi BI 1</TD>
								<TD>:</TD>
								<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_BI1" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_BI1_SelectedIndexChanged"></asp:dropdownlist>&nbsp;
									<asp:textbox id="TXT_BI1" runat="server"></asp:textbox>&nbsp;
								</TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" align="right" width="180">Sektor Ekonomi BI 2</TD>
								<TD>:</TD>
								<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_BI2" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_BI2_SelectedIndexChanged"></asp:dropdownlist>&nbsp;
									<asp:textbox id="TXT_BI2" runat="server"></asp:textbox>&nbsp;
								</TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" align="right" width="180">Sektor Ekonomi BI 3</TD>
								<TD>:</TD>
								<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_BI3" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_BI3_SelectedIndexChanged"></asp:dropdownlist>&nbsp;
									<asp:textbox id="TXT_BI3" runat="server"></asp:textbox>&nbsp;
								</TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" align="right" width="180">Sektor Ekonomi BI 4</TD>
								<TD>:</TD>
								<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_BI4" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_BI4_SelectedIndexChanged"></asp:dropdownlist>&nbsp;
									<asp:textbox id="TXT_BI4" runat="server"></asp:textbox>&nbsp;
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD class="tdH" align="center" colSpan="2"><asp:button id="BTN_SEARCH" runat="server" Text="Search" onclick="BTN_SEARCH_Click"></asp:button>&nbsp;
						<asp:button id="BTN_CLEAR" runat="server" Text="Clear" onclick="BTN_CLEAR_Click"></asp:button></TD>
				</TR>
				<TR>
					<TD colSpan="2"><ASP:DATAGRID id="DG_RESULT" runat="server" PageSize="10" CssClass="TDBGGrid" AutoGenerateColumns="False"
							AllowPaging="True" Width="100%">
							<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="BI1_CODE"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="BI2_CODE"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="BI3_CODE"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="BI4_CODE"></asp:BoundColumn>
								<asp:BoundColumn DataField="BI1_DESC" HeaderText="Sektor Ekonomi BI 1">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="BI2_DESC" HeaderText="Sektor Ekonomi BI 2">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="BI3_DESC" HeaderText="Sektor Ekonomi BI 3">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="BI4_DESC" HeaderText="Sektor Ekonomi BI 4">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn>
									<HeaderStyle Width="50px" CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:HyperLink id="HL_SELECT" runat="server">Select</asp:HyperLink>
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
