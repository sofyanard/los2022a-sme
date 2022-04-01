<%@ Page language="c#" Codebehind="DocPendingTaskListTrack.aspx.cs" AutoEventWireup="True" Inherits="SME.Syndication.EarlyWarning.DocPendingTaskListTrack" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>DocPendingTaskListTrack</TITLE>
		<META content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY MS_POSITIONING="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<CENTER>
				<TABLE id="Table1" width="100%" border="0">
					<TR>
						<TD class="tdNoBorder" align="right" colSpan="2"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/image/Back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../../Body.aspx"><IMG height="25" src="../../Image/MainMenu.jpg" width="106"></A>
							<A href="../../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A>
						</TD>
					</TR>
					<TR>
						<TD align="center" colSpan="2">
							<TABLE class="td" id="Table2" height="195" cellSpacing="1" cellPadding="1" width="550"
								border="1">
								<TR>
									<TD class="tdHeader1">DOCUMENT &amp; PENDING TASK LIST TRACKING</TD>
								</TR>
								<TR>
									<TD vAlign="top" align="center">
										<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD class="TDBGColor1" width="30%"><asp:label id="LBL_TXT_TGL_JATUH_TEMPO" runat="server">Periode :</asp:label></TD>
												<TD class="TDBGColorValue" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL1" runat="server" Columns="4" MaxLength="2"
														Width="24px"></asp:textbox><asp:dropdownlist id="DDL_BLN1" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN1" runat="server" Columns="4" MaxLength="4"
														Width="36px"></asp:textbox>to
													<asp:textbox onkeypress="return numbersonly()" id="TXT_TGL2" runat="server" Columns="4" MaxLength="2"
														Width="24px"></asp:textbox><asp:dropdownlist id="DDL_BLN2" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN2" runat="server" Columns="4" MaxLength="4"
														Width="36px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 15px" width="30%">Customer Name :</TD>
												<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CUSTOMER_NM" Width="100%" Runat="server"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="30%">Bank Name :</TD>
												<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_BANK_NM" Width="100%" Runat="server"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD vAlign="top" align="center" colSpan="2"></TD>
											</TR>
											<TR>
												<TD class="TDBGColor2" vAlign="top" align="center" colSpan="3" height="10"><asp:button id="BTN_CLEAR" runat="server" Width="80px" Text="CLEAR" CssClass="button1" onclick="BTN_CLEAR_Click"></asp:button></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2"><asp:label id="LBL_EXPORT" runat="server">GENERATE REPORT</asp:label></TD>
					</TR>
					<TR>
						<TD vAlign="top" width="50%">
							<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="30%"><asp:label id="LBL_TEMPLATE" runat="server">Format File :</asp:label></TD>
									<TD class="TDBGColorValue" width="50%"><asp:dropdownlist id="DDL_FORMAT_TYPE" runat="server" Width="100%"></asp:dropdownlist></TD>
									<TD class="TDBGColorValue" width="20%"><asp:button id="BTN_EXPORT" runat="server" Width="100%" Text="Export" onclick="BTN_EXPORT_Click"></asp:button></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="30%"><asp:label id="LBL_STATUS" runat="server">Status :</asp:label></TD>
									<TD class="TDBGColorValue" width="70%" colSpan="2"><asp:label id="LBL_STATUS_EXPORT" runat="server" ForeColor="Red"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="30%"></TD>
									<TD class="TDBGColorValue" width="70%" colSpan="2"><asp:label id="LBL_STATUSEXPORT" runat="server" ForeColor="Red"></asp:label></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 21px" align="center" colSpan="3"></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="3"></TD>
								</TR>
							</TABLE>
						</TD>
						<TD style="HEIGHT: 42px" vAlign="top" width="50%">
							<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD><ASP:DATAGRID id="DATA_EXPORT" runat="server" Width="100%" CellPadding="1" PageSize="1" AutoGenerateColumns="False">
											<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
											<Columns>
												<asp:BoundColumn Visible="False" DataField="AP_REGNO"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="TEMPLATE_ID"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="FE_USERID"></asp:BoundColumn>
												<asp:BoundColumn DataField="FE_FILENAME" HeaderText="DESTINATION FILE">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												</asp:BoundColumn>
												<asp:TemplateColumn>
													<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
													<ItemTemplate>
														<asp:HyperLink id="FE_DOWNLOAD" runat="server" Target="_blank">Download</asp:HyperLink>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn>
													<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
													<ItemTemplate>
														<asp:LinkButton id="FE_DELETE" runat="server" CommandName="delete">Delete</asp:LinkButton>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:BoundColumn Visible="False" DataField="FE_URL" HeaderText="Download URL"></asp:BoundColumn>
											</Columns>
										</ASP:DATAGRID></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD style="COLOR: dodgerblue">Note : disarankan untuk mempercepat proses tidak 
							meng-klik tulisan download, tapi di klik kanan saja dari tulisan download 
							tersebut, kemudian pilih "save" target as"...simpan di lokal komputer
						</TD>
					</TR>
				</TABLE>
			</CENTER>
		</FORM>
	</BODY>
</HTML>
