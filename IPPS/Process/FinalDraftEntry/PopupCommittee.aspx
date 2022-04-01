<%@ Page language="c#" Codebehind="PopupCommittee.aspx.cs" AutoEventWireup="True" Inherits="SME.IPPS.Process.FinalDraftEntry.PopupCommittee" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PopupCommittee</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD class="tdHeader1">Approval Committee</TD>
				</TR>
				<TR>
					<TD><ASP:DATAGRID id="DG_List_Unit" runat="server" CssClass="TDBGGrid" AutoGenerateColumns="False"
							AllowPaging="True" Width="100%">
							<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
							<Columns>
								<asp:TemplateColumn>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:CheckBox id="ckbx_cek" runat="server"></asp:CheckBox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn Visible="False" DataField="anggota_code"></asp:BoundColumn>
								<asp:BoundColumn DataField="anggota_name">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</ASP:DATAGRID></TD>
				</TR>
				<TR align="center">
					<TD class="TDBGColor2" vAlign="top" align="center">
						<asp:button id="BTN_INSERT" runat="server" Width="75px" Text="INSERT" CssClass="Button1" onclick="BTN_INSERT_Click"></asp:button>&nbsp;&nbsp;
						<asp:button id="BTN_CLEAR" runat="server" Width="75px" Text="CLEAR" CssClass="Button1" onclick="BTN_CLEAR_Click"></asp:button></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
