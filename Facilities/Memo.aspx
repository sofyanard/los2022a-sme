<%@ Page language="c#" Codebehind="Memo.aspx.cs" AutoEventWireup="True" Inherits="SME.DataEntry.Memo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Memo</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_entries.html" -->
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder" width="421" height="29"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
							<TABLE id="Table6">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Memo</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right" height="29"><A href="ListCustomer.aspx?si="></A><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" align="center" colSpan="2" height="41"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">Memo</TD>
					</TR>
					<TR>
						<td vAlign="top" width="25%" colSpan="2"></td>
					</TR>
					<TR>
						<TD vAlign="top" width="25%" colSpan="2" height="78"><asp:textbox onkeypress="return kutip_satu()" id="TXT_TM_CONTENT" runat="server" Height="72px"
								Width="100%" TextMode="MultiLine" MaxLength="500"></asp:textbox></TD>
					</TR>
					<TR>
						<TD vAlign="top" align="center" width="25%" colSpan="2"><asp:button id="BTN_SAVE" runat="server" Text="Save" Width="75px" CssClass="button1" onclick="BTN_SAVE_Click"></asp:button></TD>
					</TR>
					<TR>
						<TD vAlign="top" width="25%" colSpan="2">
							<asp:TextBox id="TXT_REGNO" runat="server" Visible="False"></asp:TextBox>
							<asp:TextBox id="TXT_TMSEQ" runat="server" Visible="False"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD vAlign="top" width="25%" colSpan="2">
							<table id="Table5" cellSpacing="0" cellPadding="0" width="100%">
								<TBODY>
									<tr>
										<td><ASP:DATAGRID id="DatGrd" runat="server" Height="80px" Width="100%" HorizontalAlign="Center" PageSize="2"
												AllowPaging="True" AutoGenerateColumns="False" CellPadding="1">
												<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
												<Columns>
													<asp:BoundColumn Visible="False" DataField="AP_REGNO"></asp:BoundColumn>
													<asp:BoundColumn DataField="TM_SEQ" HeaderText="No.">
														<HeaderStyle Width="5%" CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center" Width="120px"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="TM_DATE" HeaderText="Date">
														<HeaderStyle Width="15%" CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="TM_COntent" HeaderText="Description">
														<HeaderStyle Width="50%" CssClass="tdSmallHeader"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="SU_FUllname" HeaderText="By">
														<HeaderStyle Width="10%" CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center" Width="120px"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="sg_grpname" HeaderText="Group">
														<HeaderStyle Width="10%" CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center" Width="120px"></ItemStyle>
													</asp:BoundColumn>
													<asp:TemplateColumn HeaderText="Function">
														<HeaderStyle Width="10%" CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
														<ItemTemplate>
															<asp:LinkButton id="LINK_EDIT" runat="server" CommandName="Edit">Edit</asp:LinkButton>&nbsp;
															<asp:LinkButton id="LINK_DELETE" runat="server" CommandName="Delete">Delete</asp:LinkButton>
														</ItemTemplate>
													</asp:TemplateColumn>
												</Columns>
												<PagerStyle Mode="NumericPages"></PagerStyle>
											</ASP:DATAGRID></td>
						</TD>
					</TR>
				</TABLE>
				</TD></TR></TBODY></TABLE></center>
		</form>
	</body>
</HTML>
