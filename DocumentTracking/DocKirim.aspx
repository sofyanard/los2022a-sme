<%@ Page CodeBehind="DocKirim.aspx.cs" Language="c#" AutoEventWireup="True" Inherits="DocumentTracing.DocKirim" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>dtbo</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_all.html" -->
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 536px; HEIGHT: 50px"
					borderColor="gray" cellSpacing="1" cellPadding="1" width="100%" border="0">
				</TABLE>
				<table cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD class="tdBGColor2" align="center"><B>List Pengiriman Dokumen</B></TD>
						<TD class="tdNoBorder" align="right"><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" align="center" colSpan="2"></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 24px" align="center" colSpan="2"></TD>
					</TR>
					<tr>
						<td colSpan="2">&nbsp;
							<P align="center">
								<TABLE id="Table2" cellSpacing="2" cellPadding="2" width="90%">
									<TR>
										<TD class="td" vAlign="top" width="50%"><asp:datagrid id="DGR_LIST" Width="100%" AllowPaging="True" CellPadding="1" AutoGenerateColumns="False"
												Runat="server" onselectedindexchanged="DGR_LIST_SelectedIndexChanged">
												<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
												<Columns>
													<asp:BoundColumn DataField="DOCID" HeaderText="Dokumen ID" Visible="False">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="SEQ" HeaderText="SEQ" Visible="False">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="DOCDESC" HeaderText="Nama Dokumen">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="SEND_DATE" HeaderText="Tanggal Dikirm">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
													</asp:BoundColumn>
													<asp:TemplateColumn HeaderText="Function">
														<HeaderStyle Width="8%" CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
														<ItemTemplate>
															<asp:LinkButton id="Kirim" runat="server" CommandName="Kirim">Kirim</asp:LinkButton>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:TemplateColumn HeaderText="Function">
														<HeaderStyle Width="8%" CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
														<ItemTemplate>
															<asp:LinkButton id="Linkbutton1" runat="server" CommandName="Delete">Delete</asp:LinkButton>
														</ItemTemplate>
													</asp:TemplateColumn>
												</Columns>
												<PagerStyle Mode="NumericPages"></PagerStyle>
											</asp:datagrid></TD>
									</TR>
									<TR>
										<TD align="center" colSpan="2">Item
											<asp:dropdownlist id="DDL_NEWITEM" runat="server" Width="489px"></asp:dropdownlist><asp:button id="Button1" runat="server" Text="Insert" onclick="Button1_Click"></asp:button></TD>
									</TR>
								</TABLE>
							</P>
						</td>
					</tr>
					<TR>
						<TD align="center" colSpan="2"><asp:label id="LBL_CUREF" runat="server" Visible="False">LBL_CUREF</asp:label><asp:label id="LBL_REGNO" runat="server" Visible="False">LBL_REGNO</asp:label>
							<asp:label id="LBL_MC" runat="server" Visible="False">LBL_MC</asp:label></TD>
					</TR>
					<TR>
						<TD colSpan="2"></TD>
					</TR>
				</table>
			</center>
		</form>
	</body>
</HTML>
