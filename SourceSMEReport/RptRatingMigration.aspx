<%@ Page language="c#" Codebehind="RptRatingMigration.aspx.cs" AutoEventWireup="True" Inherits="SME.SourceSMEReport.RptRatingMigration" %>
<%@ Register TagPrefix="cc1" Namespace="Microsoft.Samples.ReportingServices" Assembly="ReportViewer" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RptRatingMigration</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
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
			document.Form1.DDL_RM.value		= "";
			document.Form1.DDL_CBC.value	= "";
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
						<td align="right"><asp:imagebutton id="btn_Back" runat="server" ImageUrl="../image/back.jpg" onclick="btn_Back_Click"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></td>
					</TR>
					<tr>
						<td vAlign="top" align="center" colSpan="2">
							<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="500">
								<TR>
									<TD class="tdHeader1">
										RATING MIGRATION DEBITUR 3 TAHUN TERAKHIR</TD>
								</TR>
								<TR>
									<TD class="td" vAlign="top">
										<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD class="TDBGColor1" width="100">Periode</TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_TGL1" runat="server" CssClass="mandatory" Width="30px"></asp:textbox><asp:dropdownlist id="DDL_BLN1" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox id="TXT_THN1" runat="server" CssClass="mandatory" Width="40px"></asp:textbox>&nbsp;To
													<asp:textbox id="TXT_TGL2" runat="server" CssClass="mandatory" Width="30px"></asp:textbox><asp:dropdownlist id="DDL_BLN2" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox id="TXT_THN2" runat="server" CssClass="mandatory" Width="40px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Sub-Segment/Program</TD>
												<TD></TD>
												<TD class="TDBGColorValue">
													<asp:dropdownlist id="DDL_Program" runat="server" Width="344px" CssClass="mandatory"></asp:dropdownlist></TD>
											</TR> <!-- Additional Field : Right --></TABLE>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor2" vAlign="top" align="center">&nbsp;&nbsp;&nbsp;</TD>
								</TR>
							</TABLE>
						</td>
					</tr>
					<TR>
						<TD align="center" colSpan="2"><asp:button id="BTN_LIHAT" runat="server" CssClass="Button1" Width="60px" Text="Find" Visible="False" onclick="BTN_LIHAT_Click"></asp:button>
							<asp:button id="Btn_Print" runat="server" Visible="False" Text="Print" Width="60px" CssClass="Button1" onclick="Btn_Print_Click"></asp:button><asp:dropdownlist id="DDL_year" runat="server" Visible="False"></asp:dropdownlist>
							<asp:label id="Label1" runat="server" Visible="False"></asp:label>
							<asp:Label id="LBL_BU" runat="server" Visible="False"></asp:Label></TD>
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
												<TD class="TDBGColorValue">
													<asp:dropdownlist id="DDL_PROGRAMRPT" runat="server" Width="248px" CssClass="mandatory"></asp:dropdownlist>
													<asp:button id="BTN_EXPORT" runat="server" Text="Export" Width="64px"></asp:button></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Status</TD>
												<TD style="HEIGHT: 11px">:</TD>
												<TD class="TDBGColorValue">
													<asp:label id="LBL_STATUS_EXPORT" runat="server" ForeColor="Red"></asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1"></TD>
												<TD style="HEIGHT: 11px"></TD>
												<TD class="TDBGColorValue">
													<asp:label id="LBL_STATUSEXPORT" runat="server" ForeColor="Red"></asp:label></TD>
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
												<TD>
													<ASP:DATAGRID id="DATA_EXPORT" runat="server" Width="473" CellPadding="1" PageSize="1" AutoGenerateColumns="False">
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
					<TR align="center">
						<TD colSpan="2">&nbsp;
							<cc1:ReportViewer id="ReportViewer1" runat="server" Visible="False" Width="100%" Parameters="False"
								Height="400px"></cc1:ReportViewer></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
