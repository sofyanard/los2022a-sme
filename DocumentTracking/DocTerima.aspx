<%@ Page CodeBehind="DocTerima.aspx.cs" Language="c#" AutoEventWireup="True" Inherits="DocumentTracing.DocTerima" %>
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
						<TD class="tdBGColor2" align="center"><B>List Penerimaan Dokumen</B></TD>
						<TD class="tdNoBorder" align="right"><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" align="center" colSpan="2"></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 20px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 20px" align="center" colSpan="2"></TD>
					</TR>
					<tr>
						<td colSpan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<TABLE id="Table2" cellSpacing="2" cellPadding="2" width="90%">
							</TABLE>
						</td>
					</tr>
					<TR>
						<TD style="HEIGHT: 21px" align="center" colSpan="2">
							<TABLE id="Table3" cellSpacing="2" cellPadding="2" width="90%">
								<TR>
									<TD align="center" colSpan="2"><asp:label id="LBL_SENDTO" runat="server" Visible="False">Send To   </asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:dropdownlist id="DDL_SCGROUP" runat="server" Visible="False" onselectedindexchanged="DDL_SCGROUP_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="2"><asp:button id="BTN_SEND" runat="server" Width="78px" Text="Send" onclick="BTN_SEND_Click"></asp:button></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="2"><asp:label id="LBL_STAGETO" runat="server"> Stage</asp:label><asp:dropdownlist id="DDL_StageTo" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_StageTo_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="2"><asp:datagrid id="DGR_LIST" Width="100%" PageSize="15" AllowPaging="True" CellPadding="1" AutoGenerateColumns="False"
											Runat="server">
											<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
											<Columns>
												<asp:BoundColumn DataField="DOCID" HeaderText="Doc ID">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Description" HeaderText="Description">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="RECDATE" HeaderText="Recv Date">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Notes" HeaderText="Catatan">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:TemplateColumn HeaderText="Catatan Add">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
													<ItemTemplate>
														<asp:TextBox id="TXT_NOTES1" runat="server"></asp:TextBox>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:BoundColumn DataField="SentTo" HeaderText="SentTo">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Original" HeaderText="Original">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
											</Columns>
											<PagerStyle Mode="NumericPages"></PagerStyle>
										</asp:datagrid></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="2"><asp:label id="LBL_REGNO" runat="server" Visible="False">LBL_REGNO</asp:label><asp:label id="LBL_CUREF" runat="server" Visible="False">LBL_CUREF</asp:label><asp:label id="LBL_MC" runat="server" Visible="False">LBL_MC</asp:label></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="2"><asp:button id="BTN_RCV" runat="server" Text="Receive" onclick="BTN_RCV_Click"></asp:button></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="2"><asp:label id="LBL_STAGEFROM" runat="server"> Stage </asp:label><asp:dropdownlist id="DDL_StageFrom" runat="server" onselectedindexchanged="DDL_StageFrom_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="2"><asp:datagrid id="DGR_KIRIM" Width="100%" PageSize="20" AllowPaging="True" CellPadding="1" AutoGenerateColumns="False"
											Runat="server">
											<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
											<Columns>
												<asp:BoundColumn DataField="DocID" HeaderText="Doc ID">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Description" HeaderText="Description">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="SentDate" HeaderText="Sent Date">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Notes" HeaderText="Catatan">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:TemplateColumn HeaderText="Catatan Add">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
													<ItemTemplate>
														<asp:TextBox id="TXT_NOTES" runat="server"></asp:TextBox>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:BoundColumn DataField="SentTo" HeaderText="Sent To">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Original" HeaderText="Original" Visible="true">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:TemplateColumn HeaderText="Original" Visible="true">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
													<ItemTemplate>
														<asp:CheckBox id="CHK_ORIGINAL" runat="server"></asp:CheckBox>
													</ItemTemplate>
												</asp:TemplateColumn>
											</Columns>
											<PagerStyle Mode="NumericPages"></PagerStyle>
										</asp:datagrid></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="2">&nbsp;
									</TD>
								</TR>
								<TR>
									<TD align="center" colSpan="2"></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 21px" align="center" colSpan="2"></TD>
					</TR>
					<TR>
						<TD colSpan="2"></TD>
					</TR>
				</table>
			</center>
		</form>
	</body>
</HTML>
