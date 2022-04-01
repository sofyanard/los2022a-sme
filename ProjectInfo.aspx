<%@ Page language="c#" Codebehind="ProjectInfo.aspx.cs" AutoEventWireup="True" Inherits="SME.ProjectInfo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ProjectInfo</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="style.css" type="text/css" rel="stylesheet">
		<!-- #include file="include/child.html" -->
		<!-- #include file="include/cek_entries.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 0px" cellSpacing="0"
				cellPadding="0" width="100%" border="0">
				<TR>
					<TD class="tdH" align="center" bgColor="#f0f0f0" colSpan="2"><IMG height="71" src="image/log01.jpg" width="328"></TD>
				</TR>
				<TR>
					<TD class="tdheader1" vAlign="top" width="50%">Project Information</TD>
				</TR>
				<TR align="center" valign="middle">
					<TD vAlign="top" width="50%">
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="50%" border="0">
							<TR>
								<TD width="30%" class="TDBGColor1">Nama Proyek</TD>
								<TD width="2%"></TD>
								<TD width="68%" class="TDBGColorValue">
									<asp:textbox id="txt_NAMAPROYEK" runat="server" Width="100%"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">
									<P>Remaining Limit</P>
								</TD>
								<TD></TD>
								<TD>
									<asp:textbox onkeypress="return numbersonly()" id="txt_REMAININGLIMIT_AWAL" runat="server" Width="100px"></asp:textbox>&nbsp;to
									<asp:textbox onkeypress="return numbersonly()" id="txt_REMAININGLIMIT_AKHIR" runat="server" Width="100px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD align="center" valign="middle" colSpan="3" style="HEIGHT: 33px">
									<asp:button id="btn_SEARCH" runat="server" Width="100px" Text="Search" onclick="btn_SEARCH_Click"></asp:button>&nbsp;
									<asp:button id="btn_CLEAR" runat="server" Width="100px" Text="Clear" onclick="btn_CLEAR_Click"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD class="td" vAlign="top" width="50%">
						<asp:datagrid id="DGR_PROJECT" runat="server" Width="100%" AutoGenerateColumns="False" AllowSorting="True">
							<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="PRJ_CODE" HeaderText="PRJ_CODE">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="PRJ_NAME" SortExpression="PRJ_NAME" HeaderText="Project Name">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="PRJ_DESC" HeaderText="Description">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="PRJ_LIMIT" SortExpression="PRJ_LIMIT" HeaderText="Limit Provided" DataFormatString="{0:00,00.00}">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="PRJ_LIMIT_REMAINING" SortExpression="PRJ_LIMIT_REMAINING" HeaderText="Remaining Limit"
									DataFormatString="{0:00,00.00}">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="PRJ_LIMIT_PENDING_APPRV" HeaderText="Pending Customer Acceptance" DataFormatString="{0:00,00.00}">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="PRJ_EXPIRY_DATE" SortExpression="PRJ_EXPIRY_DATE" HeaderText="Expiry Date"
									DataFormatString="{0:dd-MMM-yyyy}">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
				</TR>
				<TR>
					<TD class="tdH" colSpan="2">
						<asp:label id="lbl_SQL" runat="server" Visible="False"></asp:label>
						<asp:TextBox id="TXT_SORTTYPE" runat="server" Visible="False">ASC</asp:TextBox>
						<asp:TextBox id="TXT_SORTEXP" runat="server" Visible="False">PRJ_NAME</asp:TextBox></TD>
				</TR>
				<TR>
					<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2"><INPUT class="button1" style="WIDTH: 100px; HEIGHT: 26px" onclick="javascript:window.close()"
							type="button" size="20" value="Close"></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
