<%@ Page language="c#" Codebehind="RptCaracterAnalysis.aspx.cs" AutoEventWireup="True" Inherits="SME.SourceSMEReport.RptCaracterAnalysis" %>
<%@ Register TagPrefix="cc1" Namespace="Microsoft.Samples.ReportingServices" Assembly="ReportViewer" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RptCaracterAnalysis</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="style.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function Batal()
		{
			document.Form1.TXT_DAY1.value	= "";
			document.Form1.DDL_MONTH1.value	= "";
			document.Form1.TXT_YEAR1.value	= "";
			
			document.Form1.TXT_DAY2.value	= "";
			document.Form1.DDL_MONTH2.value	= "";
			document.Form1.TXT_YEAR2.value	= "";
			
			document.Form1.DDL_PROGRAM.value = "";
			document.Form1.DDL_PROGRAMRPT.value = "";			
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
							<TABLE id="Table2" height="160" cellSpacing="2" cellPadding="2" width="600">
								<TR>
									<TD class="tdHeader1" colSpan="3">
										CHARACTERISTIC ANALYSIS&nbsp;REPORT
									</TD>
								</TR>
								<TR>
									<TD class="td" style="HEIGHT: 63px" vAlign="top" align="center" width="100%">
										<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 17px">Past Start Date</TD>
												<TD style="HEIGHT: 17px"></TD>
												<TD class="TDBGColorValue" style="HEIGHT: 17px">
													<asp:textbox onkeypress="return numbersonly()" id="TXT_Day1" runat="server" Width="38px" CssClass="mandatory"></asp:textbox>
													<asp:dropdownlist id="DDL_Month1" runat="server" CssClass="mandatory"></asp:dropdownlist>
													<asp:textbox onkeypress="return numbersonly()" id="TXT_Year1" runat="server" Width="60px" CssClass="mandatory"></asp:textbox></TD>
											</TR> <!-- Additional Field : Right -->
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 17px">Past End Date/Recent Start Date</TD>
												<TD style="HEIGHT: 17px"></TD>
												<TD class="TDBGColorValue" style="HEIGHT: 17px">
													<asp:textbox onkeypress="return numbersonly()" id="TXT_Day2" runat="server" Width="38px" CssClass="mandatory"></asp:textbox>
													<asp:dropdownlist id="DDL_Month2" runat="server" CssClass="mandatory"></asp:dropdownlist>
													<asp:textbox onkeypress="return numbersonly()" id="TXT_Year2" runat="server" Width="60px" CssClass="mandatory"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 17px">Recent End Date</TD>
												<TD style="HEIGHT: 17px"></TD>
												<TD class="TDBGColorValue" style="HEIGHT: 17px">
													<asp:textbox onkeypress="return numbersonly()" id="TXT_DAY3" runat="server" CssClass="mandatory"
														Width="38px"></asp:textbox>
													<asp:dropdownlist id="DDL_MONTH3" runat="server" CssClass="mandatory"></asp:dropdownlist>
													<asp:textbox onkeypress="return numbersonly()" id="TXT_YEAR3" runat="server" CssClass="mandatory"
														Width="60px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 22px">Sub-Segment/Program</TD>
												<TD style="WIDTH: 15px; HEIGHT: 22px"></TD>
												<TD class="TDBGColorValue" style="HEIGHT: 22px">
													<asp:dropdownlist id="DDL_Program" runat="server" Width="344px" CssClass="mandatory" AutoPostBack="True" onselectedindexchanged="DDL_Program_SelectedIndexChanged"></asp:dropdownlist></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2"><asp:button id="BTN_LIHAT" runat="server" CssClass="Button1" Width="60px" Text="Find" Visible="False" onclick="BTN_LIHAT_Click"></asp:button>
										<asp:button id="Btn_Print" runat="server" CssClass="Button1" Width="60px" Text="Print" Visible="False" onclick="Btn_Print_Click"></asp:button></TD>
								</TR>
							</TABLE>
						</td>
					</tr>
					<TR>
						<TD vAlign="top" align="center" colSpan="2"><asp:dropdownlist id="DDL_year" runat="server" Visible="False"></asp:dropdownlist>
							<asp:label id="Label2" runat="server" Visible="False"></asp:label>
							<asp:label id="LBL_BRANCH" runat="server" Visible="False" Width="89px"></asp:label>
							<asp:label id="LBL_Score" runat="server" Visible="False"></asp:label>
							<asp:label id="Label1" runat="server" Visible="False"></asp:label>
							<asp:Label id="LBL_BU" runat="server" Visible="False"></asp:Label>
							<asp:label id="LBL_REGION" runat="server" Visible="False"></asp:label></TD>
					</TR>
					<TR align="center">
						<TD colSpan="2">
							<TABLE id="Table6" cellSpacing="2" cellPadding="2" width="100%">
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
													<asp:button id="BTN_EXPORT" runat="server" Width="64px" Text="Export" onclick="BTN_EXPORT_Click"></asp:button></TD>
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
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
