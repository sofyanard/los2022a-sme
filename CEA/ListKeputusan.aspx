<%@ Page language="c#" Codebehind="ListKeputusan.aspx.cs" AutoEventWireup="True" Inherits="SME.CEA.ListKeputusan" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ListKeputusan</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="form1" method="post" runat="server">
			<!-- <center> -->
			<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
				<TR>
					<TD class="tdNoBorder">
						<TABLE id="Table8">
							<TR>
								<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>List Keputusan</B></TD>
							</TR>
						</TABLE>
					</TD>
					<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
				</TR>
				<TR id="TR_FIND" runat="server">
					<TD class="tdNoBorder" vAlign="top" width="50%">
						<TABLE id="Table20" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD class="TDBGColor1" width="129">Nama Rekanan</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue" style="WIDTH: 208px"><asp:textbox id="TXT_REK_NAME" runat="server" Width="200px" MaxLength="15"></asp:textbox></TD>
								<td><asp:button id="BTN_FIND" CssClass="button1" Text="Find" Runat="server" onclick="BTN_FIND_Click"></asp:button></td>
							</TR>
						</TABLE>
					</TD>
					<TD class="tdNoBorder" vAlign="top" width="50%"></TD>
				</TR>
				<TR>
					<TD colSpan="2"><ASP:DATAGRID id="DatGrd" runat="server" Width="100%" CellPadding="1" AutoGenerateColumns="False"
							AllowPaging="True">
							<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="REKANAN_REF"></asp:BoundColumn>
								<asp:BoundColumn DataField="REGNUM" HeaderText="No. Aplikasi">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NAMEREKANAN" HeaderText="Nama Rekanan">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NPWP" HeaderText="NPWP">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="REKANANDESC" HeaderText="Jenis Rekanan">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Function">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:LinkButton id="LinkButton1" runat="server" Text="View" CausesValidation="false" CommandName="View"></asp:LinkButton>&nbsp;&nbsp;
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</ASP:DATAGRID></TD>
				</TR>
			</TABLE>
			<table id="Tabel3" style="WIDTH: 993px; HEIGHT: 136px" cellSpacing="0" cellPadding="0"
				width="993" border="0">
			</table>
			<!-- </center> --></form>
	</body>
</HTML>
