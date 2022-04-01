<%@ Page language="c#" Codebehind="QA.aspx.cs" AutoEventWireup="True" Inherits="SME.HDRS.QA" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>QA</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
				<TR>
					<TD class="tdNoBorder">
						<TABLE id="Table8">
							<TR>
								<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>QUESTION &amp; ANSWER 
										LIST</B></TD>
							</TR>
						</TABLE>
					</TD>
					<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
				</TR>
				<TR id="TR_FIND" runat="server">
					<TD class="tdNoBorder" vAlign="top" width="50%">
						<table id="Table20" cellSpacing="0" cellPadding="0" width="100%">
							<TBODY>
								<TR>
									<TD class="TDBGColor1" width="129">Problem Type:</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class='A"TDBGColorValue"' style="HEIGHT: 10px"><asp:dropdownlist id="DDL_PROBLEM" runat="server" AutoPostBack="True"></asp:dropdownlist>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:button id="BTN_FIND" CssClass="button1" Text="Find" Runat="server" onclick="BTN_FIND_Click"></asp:button></TD>
									<td></td>
					</TD>
				</TR>
			</TABLE>
			</TD>
			<TD class="tdNoBorder" vAlign="top" width="50%"></TD>
			</TR>
			<TR>
				<TD colSpan="2"><ASP:DATAGRID id="DATA_EXPORT" runat="server" Width="100%" CellPadding="1" AutoGenerateColumns="False"
						AllowPaging="True">
						<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
						<Columns>
							<asp:BoundColumn HeaderText="QUESTION" DataField="H_PROBLEM">
								<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								<ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
							</asp:BoundColumn>
							<asp:BoundColumn HeaderText="DOCUMENT EXPORT" DataField="H_PROBLEM_FILE_EXPORT">
								<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
							</asp:BoundColumn>
							<asp:TemplateColumn HeaderText="Download">
								<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								<ItemStyle HorizontalAlign="Center"></ItemStyle>
								<ItemTemplate>
									<asp:HyperLink id="UPL_DOWNLOAD_QUESTION" runat="server" Target="_blank">Download</asp:HyperLink>
								</ItemTemplate>
							</asp:TemplateColumn>
							<asp:BoundColumn HeaderText="ANSWER" DataField="H_RESPON">
								<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
							</asp:BoundColumn>
							<asp:BoundColumn HeaderText="DOCUMENT EXPORT" DataField="H_RESPON_FILE_EXPORT">
								<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
							</asp:BoundColumn>
							<asp:TemplateColumn HeaderText="Download">
								<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								<ItemStyle HorizontalAlign="Center"></ItemStyle>
								<ItemTemplate>
									<asp:HyperLink id="UPL_DOWNLOAD_ANSWER" runat="server" Target="_blank">Download</asp:HyperLink>
								</ItemTemplate>
							</asp:TemplateColumn>
							<asp:BoundColumn HeaderText="H_HRS#" Visible="False" DataField="H_HRS#">
								<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								<ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
							</asp:BoundColumn>
						</Columns>
						<PagerStyle Mode="NumericPages"></PagerStyle>
					</ASP:DATAGRID></TD>
			</TR>
			<tr>
				<td class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:button id="BTN_PRINT" runat="server" CssClass="Button1" Text="PRINT" onclick="BTN_PRINT_Click"></asp:button></td>
			</tr>
			</TBODY></TABLE></form>
	</body>
</HTML>
