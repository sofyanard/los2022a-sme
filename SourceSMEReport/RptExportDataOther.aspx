<%@ Page language="c#" Codebehind="RptExportDataOther.aspx.cs" AutoEventWireup="True" Inherits="SME.SourceSMEReport.RptExportDataOther" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RptExportDataOther</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="style.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function Batal()
		{
			document.Form1.TXT_TGL1.value	= "";
			document.Form1.DDL_BLN1.value	= "";
			document.Form1.TXT_THN1.value	= "";
			document.Form1.TXT_TGL2.value	= "";
			document.Form1.DDL_BLN2.value	= "";
			document.Form1.TXT_THN2.value	= "";
			document.Form1.DDL_BRANCH.value	= "";
			document.Form1.DDL_CBC.value	= "";
			document.Form1.DDL_RM.value		= "";
			document.Form1.DDL_PROGRAM.value	= "";
		}
		</script>
		
		<!-- #include  file="../include/cek_entries.html" -->
		<!-- #include  file="../include/cek_mandatoryOnly.html" -->
		<!-- #include  file="../include/onepost.html" -->
		<!-- #include  file="../include/exportpost.html" -->
		
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD width="20%" height="35"></TD>
						<td align="right"><asp:imagebutton id="btn_back" runat="server" ImageUrl="../image/back.jpg" onclick="btn_back_Click"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></td>
					</TR>
					<TR>
						<TD vAlign="top" align="center" colSpan="2" height="160">
							<TABLE id="Table6" height="160" cellSpacing="2" cellPadding="2" width="500">
								<TR>
									<TD class="tdHeader1">OTHER BU REPORT</TD>
								</TR>
								<TR>
									<TD class="td" vAlign="top">
										<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD class="TDBGColor1" width="100">Periode</TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL1" runat="server" MaxLength="2" CssClass="mandatory"
														Width="30px"></asp:textbox><asp:dropdownlist id="DDL_BLN1" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN1" runat="server" MaxLength="4" CssClass="mandatory"
														Width="40px"></asp:textbox>&nbsp;To
													<asp:textbox onkeypress="return numbersonly()" id="TXT_TGL2" runat="server" MaxLength="2" CssClass="mandatory"
														Width="30px"></asp:textbox><asp:dropdownlist id="DDL_BLN2" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox id="TXT_THN2" runat="server" MaxLength="4" CssClass="mandatory" Width="40px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 14px">Region</TD>
												<TD style="HEIGHT: 14px"></TD>
												<TD class="TDBGColorValue" style="HEIGHT: 14px"><asp:dropdownlist id="DDL_REGION" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_REGION_SelectedIndexChanged"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">CBC</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CBC" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_CBC_SelectedIndexChanged"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Branch</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_BRANCH" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_BRANCH_SelectedIndexChanged"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Team</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_TEAM" runat="server"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 18px">RM</TD>
												<TD style="HEIGHT: 18px"></TD>
												<TD class="TDBGColorValue" style="HEIGHT: 18px"><asp:dropdownlist id="DDL_RM" runat="server"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Sub-Segment/Program</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_PROGRAM" runat="server" AutoPostBack="True" DESIGNTIMEDRAGDROP="68" onselectedindexchanged="DDL_PROGRAM_SelectedIndexChanged"></asp:dropdownlist></TD>
											</TR> <!-- Additional Field : Right --></TABLE>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor2" vAlign="top" align="center">&nbsp;&nbsp;&nbsp;
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<tr align="centerc">
						<td align="center" colSpan="2"><asp:label id="LBL_BRANCH" runat="server" Width="93px" Height="10px" Visible="False"></asp:label><asp:label id="LBL_CBC" runat="server" Width="72px" Visible="False"></asp:label><asp:label id="LBL_REGION" runat="server" Visible="False"></asp:label><asp:label id="Label1" runat="server" Visible="False"></asp:label><asp:label id="LBL_BU" runat="server"></asp:label><asp:label id="LBL_AGENCY" runat="server" Visible="False"></asp:label><asp:label id="LBL_RM" runat="server" Visible="False"></asp:label><asp:label id="LBL_SCORE" runat="server" Visible="False"></asp:label></td>
					</tr>
					<TR>
						<TD style="HEIGHT: 20px" align="center" colSpan="2"></TD>
					</TR>
					<TR align="center">
						<TD colSpan="2"></TD>
					</TR>
					<TR>
						<TD colSpan="2">
							<TABLE id="Table2" cellSpacing="2" cellPadding="2" width="100%">
								<TR>
									<TD class="tdHeader1" vAlign="top" width="50%" colSpan="2">Document Export</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 366px" vAlign="top" width="366">
										<TABLE id="Table4" style="WIDTH: 456px; HEIGHT: 124px" cellSpacing="0" cellPadding="0"
											width="456">
											<TR>
												<TD class="TDBGColor1" width="75">Pilihan Informasi</TD>
												<TD style="HEIGHT: 11px">:</TD>
												<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_PROGRAMRPT" runat="server" CssClass="mandatory" Width="248px"></asp:dropdownlist><asp:button id="BTN_EXPORT" runat="server" Width="64px" Text="Export" onclick="BTN_EXPORT_Click"></asp:button></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Status</TD>
												<TD style="HEIGHT: 11px">:</TD>
												<TD class="TDBGColorValue"><asp:label id="LBL_STATUS_EXPORT" runat="server" ForeColor="Red"></asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1"></TD>
												<TD style="HEIGHT: 11px"></TD>
												<TD class="TDBGColorValue"><asp:label id="LBL_STATUSEXPORT" runat="server" ForeColor="Red"></asp:label></TD>
											</TR>
											<TR>
												<TD style="HEIGHT: 21px" align="center" colSpan="3"></TD>
											</TR>
											<TR>
												<TD align="center" colSpan="3"></TD>
											</TR>
										</TABLE>
									</TD>
									<TD style="HEIGHT: 42px" vAlign="top" width="50%"><TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD><ASP:DATAGRID id="DATA_EXPORT" runat="server" Width="473px" CellPadding="1" PageSize="1" AutoGenerateColumns="False">
														<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
														<Columns>
															<asp:BoundColumn Visible="False" DataField="DATA_ID">
																<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="DATA_FILENAME" HeaderText="File Name">
																<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
															</asp:BoundColumn>
															<asp:TemplateColumn>
																<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
																<ItemTemplate>
																	<asp:HyperLink id="HL_DOWNLOAD" runat="server" Target="_blank">Download</asp:HyperLink>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn>
																<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
																<ItemTemplate>
																	<asp:LinkButton id="LB_DELETE" runat="server" CommandName="delete">Delete</asp:LinkButton>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:BoundColumn Visible="False" DataField="USERID" HeaderText="User ID"></asp:BoundColumn>
														</Columns>
													</ASP:DATAGRID></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
