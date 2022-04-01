<%@ Page language="c#" Codebehind="LOWExportCBI.aspx.cs" AutoEventWireup="True" Inherits="SME.LOW.LOWExportCBI" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>LOWExportCBI</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function Batal()
		{
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
						<TD style="WIDTH: 361px" width="361" height="35">
							<TABLE id="Table8">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Customer Info Export</B></TD>
								</TR>
							</TABLE>
						</TD>
						<td align="right"><asp:imagebutton id="btn_back" runat="server" ImageUrl="../image/back.jpg"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></td>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2" height="160">
							<asp:PlaceHolder id="Menu" runat="server"></asp:PlaceHolder></TD>
					</TR>
					<TR>
						<TD vAlign="top" align="center" colSpan="2" height="160">
							<TABLE id="Table6" style="WIDTH: 500px; HEIGHT: 64px" height="64" cellSpacing="2" cellPadding="2"
								width="500">
								<TR>
									<TD class="tdHeader1">Customer Information Export</TD>
								</TR>
								<TR>
									<TD class="td" style="HEIGHT: 17px" vAlign="top">
										<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD class="TDBGColor1">Application Number</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_AP_REGNO" runat="server" Width="200px"></asp:textbox></TD>
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
												<TD class="TDBGColor1" width="84">Format File</TD>
												<TD style="WIDTH: 1px; HEIGHT: 11px">:</TD>
												<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_FORMATFILE" runat="server" Width="248px" CssClass="mandatory" AutoPostBack="True"></asp:dropdownlist><asp:button id="BTN_EXPORT" runat="server" Width="64px" Text="Export"></asp:button></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Status</TD>
												<TD style="WIDTH: 1px; HEIGHT: 11px">:</TD>
												<TD class="TDBGColorValue"><asp:label id="LBL_STATUS_EXPORT" runat="server" ForeColor="Red"></asp:label></TD>
											</TR>
											<TR>
												<TD width="84"></TD>
												<TD style="WIDTH: 1px; HEIGHT: 11px"></TD>
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
															<asp:BoundColumn Visible="False" DataField="EXPORT_ID">
																<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="FU_FILENAME" HeaderText="File Name">
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
															<asp:BoundColumn Visible="False" DataField="FU_USERID" HeaderText="User ID"></asp:BoundColumn>
														</Columns>
													</ASP:DATAGRID></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
							<asp:label id="LBL_USER_ID" runat="server" Width="72px" Visible="False"></asp:label><asp:label id="LBL_GROUP_ID" runat="server" Width="56px" Visible="False"></asp:label><asp:label id="LBL_BRANCH_ID" runat="server" Visible="False"></asp:label>
							<asp:label id="LBL_CUREF" runat="server" Width="72px" Visible="False"></asp:label></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" style="HEIGHT: 10px" colSpan="2">Document Upload
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 540px" vAlign="top" width="540">
							<table cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="75">File</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><INPUT id="TXT_FILE_UPLOAD" style="WIDTH: 344px; HEIGHT: 19px" type="file" size="38" name="File1"
											runat="Server"></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Status</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:label id="LBL_STATUS" runat="server" ForeColor="Red"></asp:label><asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" ErrorMessage="Only xls, doc, txt or zip files are allowed!"
											ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.xls|.XLS|.doc|.DOC|.txt|.TXT|.zip|.ZIP)$" ControlToValidate="TXT_FILE_UPLOAD"></asp:regularexpressionvalidator></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"></TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:label id="LBL_STATUSREPORT" runat="server" ForeColor="Red"></asp:label></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 21px" align="center" colSpan="3"><asp:button id="BTN_UPLOAD" runat="server" Text="Upload"></asp:button></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="3"></TD>
								</TR>
							</table>
						</TD>
						<TD style="HEIGHT: 42px" vAlign="top">
							<TABLE cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD><ASP:DATAGRID id="DatGrid" runat="server" Width="100%" AutoGenerateColumns="False" PageSize="1"
											CellPadding="1">
											<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
											<Columns>
												<asp:BoundColumn Visible="False" DataField="CU_REF" HeaderText="Cust Ref"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="SEQ" HeaderText="Seq"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="FU_USERID" HeaderText="User ID"></asp:BoundColumn>
												<asp:BoundColumn DataField="FU_FILENAME" HeaderText="File Name">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												</asp:BoundColumn>
												<asp:TemplateColumn>
													<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
													<ItemTemplate>
														<asp:HyperLink id="FU_DOWNLOAD" runat="server" Target="_blank">Download</asp:HyperLink>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn>
													<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
													<ItemTemplate>
														<asp:LinkButton id="FU_DELETE" runat="server" CommandName="delete">Delete</asp:LinkButton>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:BoundColumn Visible="False" DataField="FU_URL" HeaderText="Download URL"></asp:BoundColumn>
											</Columns>
										</ASP:DATAGRID></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
