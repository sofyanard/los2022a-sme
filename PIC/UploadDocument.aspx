<%@ Page language="c#" Codebehind="UploadDocument.aspx.cs" AutoEventWireup="True" Inherits="SME.PIC.UploadDocument" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>UploadDocument</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_entries.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table4" width="100%" border="0">
					<TR>
						<TD align="left" colSpan="1">
							<TABLE id="Table3">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Upload Document</B></TD>
								</TR>
							</TABLE>
						</TD>
						<td align="right"><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></td>
					</TR>
					<TR>
						<TD align="center" colSpan="2">
							<TABLE class="td" id="Table1" cellSpacing="1" cellPadding="1" border="1">
								<TR id="TR_EX_JUDUL" runat="server">
									<TD class="tdHeader1" colSpan="2">DOCUMENT INFORMASI UMUM</TD>
								</TR>
								<tr id="TR_EX_CONTENT" runat="server">
									<TD vAlign="top" width="50%">
										<table cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD class="TDBGColor1" width="75">KSEBM</TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_KSEBM_IU" AutoPostBack="True" CssClass="Mandatory" Runat="server" Width="100%" onselectedindexchanged="DDL_KSEBM_IU_SelectedIndexChanged"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="75">File</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><INPUT id="TXT_FILE_UPLOAD_IU" type="file" size="30" name="File1" runat="Server"></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Status</TD>
												<TD>:</TD>
												<TD class="TDBGColorValue"><asp:label id="LBL_STATUS1" runat="server" ForeColor="Red"></asp:label><asp:regularexpressionvalidator id="Regularexpressionvalidator1" runat="server" ErrorMessage="Only xls, doc, txt, pdf, docx, xlsx or zip files are allowed!"
														ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.xls|.XLS|.doc|.DOC|.txt|.TXT|.zip|.ZIP|.pdf|.PDF|.docx|.DOCX|.xlsx|.XLSX|)$" ControlToValidate="TXT_FILE_UPLOAD_IU"></asp:regularexpressionvalidator></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1"></TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:label id="LBL_STATUSREPORT1" runat="server" ForeColor="Red"></asp:label></TD>
											</TR>
											<TR>
												<TD style="HEIGHT: 21px" align="center" colSpan="3"><asp:label id="LBL_SUMBERDATA_IU" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD align="center" colSpan="3"><asp:button id="UPLOAD_IU" runat="server" Text="Upload" onclick="UPLOAD_IU_Click"></asp:button></TD>
											</TR>
											<TR>
												<TD align="center" colSpan="3"></TD>
											</TR>
										</table>
									</TD>
									<TD vAlign="top" width="50%" rowSpan="2">
										<table cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD>
													<table>
														<tr>
															<td><ASP:DATAGRID id="DATA_EXPORT1" runat="server" Width="100%" CellPadding="1" AutoGenerateColumns="False"
																	ShowFooter="True">
																	<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
																	<Columns>
																		<asp:BoundColumn DataField="ID_UPLOAD" HeaderText="No">
																			<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
																			<ItemStyle Width="10px"></ItemStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="FILE_UPLOAD_NAME" HeaderText="Destination File">
																			<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
																		</asp:BoundColumn>
																		<asp:TemplateColumn>
																			<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
																			<ItemStyle HorizontalAlign="Center"></ItemStyle>
																			<ItemTemplate>
																				<asp:checkbox id="chk_1" runat="server"></asp:checkbox>
																			</ItemTemplate>
																			<FooterStyle HorizontalAlign="Center"></FooterStyle>
																			<FooterTemplate>
																				<asp:LinkButton id="lnk_allfac" runat="server" CommandName="allfac1">Select All</asp:LinkButton>
																			</FooterTemplate>
																		</asp:TemplateColumn>
																		<asp:TemplateColumn HeaderText="Function">
																			<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
																			<ItemStyle HorizontalAlign="Center"></ItemStyle>
																			<ItemTemplate>
																				<asp:LinkButton id="UPL1_DELETE" runat="server" CommandName="delete">Delete</asp:LinkButton>
																			</ItemTemplate>
																		</asp:TemplateColumn>
																	</Columns>
																	<PagerStyle Mode="NumericPages"></PagerStyle>
																</ASP:DATAGRID></td>
														</tr>
														<tr>
															<td align="right"><asp:button id="DELETE_IU" runat="server" Text="DELETE" onclick="DELETE_IU_Click"></asp:button></td>
														</tr>
													</table>
												</TD>
											</TR>
										</table>
									</TD>
								</tr>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD align="center" colSpan="2">
							<TABLE class="td" id="Table1" cellSpacing="1" cellPadding="1" border="1">
								<TR id="Tr9" runat="server">
									<TD class="tdHeader1" colSpan="2">DOCUMENT PERKEMBANGAN PORTFOLIO SEKTOR</TD>
								</TR>
								<tr id="Tr10" runat="server">
									<TD vAlign="top" width="50%">
										<table cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD class="TDBGColor1" width="75">KSEBM</TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_KSEBM_PPS" AutoPostBack="True" CssClass="Mandatory" Runat="server" Width="100%" onselectedindexchanged="DDL_KSEBM_PPS_SelectedIndexChanged"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="75">File</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><INPUT id="TXT_FILE_UPLOAD_PPS" type="file" size="30" name="File1" runat="Server"></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Status</TD>
												<TD>:</TD>
												<TD class="TDBGColorValue"><asp:label id="LBL_STATUS2" runat="server" ForeColor="Red"></asp:label><asp:regularexpressionvalidator id="Regularexpressionvalidator6" runat="server" ErrorMessage="Only xls, doc, txt, pdf, docx, xlsx or zip files are allowed!"
														ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.xls|.XLS|.doc|.DOC|.txt|.TXT|.zip|.ZIP|.pdf|.PDF|.docx|.DOCX|.xlsx|.XLSX|)$" ControlToValidate="TXT_FILE_UPLOAD_PPS"></asp:regularexpressionvalidator></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1"></TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:label id="LBL_STATUSREPORT2" runat="server" ForeColor="Red"></asp:label></TD>
											</TR>
											<TR>
												<TD style="HEIGHT: 21px" align="center" colSpan="3"><asp:label id="LBL_SUMBERDATA_PPS" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD align="center" colSpan="3"><asp:button id="UPLOAD_PPS" runat="server" Text="Upload" onclick="UPLOAD_PPS_Click"></asp:button></TD>
											</TR>
											<TR>
												<TD align="center" colSpan="3"></TD>
											</TR>
										</table>
									</TD>
									<TD vAlign="top" width="50%" rowSpan="2">
										<table cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD>
													<table>
														<tr>
															<td><ASP:DATAGRID id="DATA_EXPORT2" runat="server" Width="100%" CellPadding="1" AutoGenerateColumns="False"
																	ShowFooter="True" PageSize="5">
																	<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
																	<Columns>
																		<asp:BoundColumn DataField="ID_UPLOAD" HeaderText="No">
																			<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
																			<ItemStyle Width="10px"></ItemStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="FILE_UPLOAD_NAME" HeaderText="Destination File">
																			<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
																		</asp:BoundColumn>
																		<asp:TemplateColumn>
																			<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
																			<ItemStyle HorizontalAlign="Center"></ItemStyle>
																			<ItemTemplate>
																				<asp:checkbox id="chk_2" runat="server"></asp:checkbox>
																			</ItemTemplate>
																			<FooterStyle HorizontalAlign="Center"></FooterStyle>
																			<FooterTemplate>
																				<asp:LinkButton id="Linkbutton9" runat="server" CommandName="allfac2">Select All</asp:LinkButton>
																			</FooterTemplate>
																		</asp:TemplateColumn>
																		<asp:TemplateColumn HeaderText="Function">
																			<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
																			<ItemStyle HorizontalAlign="Center"></ItemStyle>
																			<ItemTemplate>
																				<asp:LinkButton id="UPL2_DELETE" runat="server" CommandName="delete">Delete</asp:LinkButton>
																			</ItemTemplate>
																		</asp:TemplateColumn>
																	</Columns>
																	<PagerStyle Mode="NumericPages"></PagerStyle>
																</ASP:DATAGRID></td>
														</tr>
														<tr>
															<td align="right"><asp:button id="DELETE_PPS" runat="server" Text="DELETE" onclick="DELETE_PPS_Click"></asp:button></td>
														</tr>
													</table>
												</TD>
											</TR>
										</table>
									</TD>
								</tr>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD align="center" colSpan="2">
							<TABLE class="td" id="Table1" cellSpacing="1" cellPadding="1" border="1">
								<TR id="Tr11" runat="server">
									<TD class="tdHeader1" colSpan="2">DOCUMENT KAJIAN SEKTOR</TD>
								</TR>
								<tr id="Tr12" runat="server">
									<TD vAlign="top" width="50%">
										<table cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD class="TDBGColor1" width="75">KSEBM</TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_KSEBM_KS" AutoPostBack="True" CssClass="Mandatory" Runat="server" Width="100%" onselectedindexchanged="DDL_KSEBM_KS_SelectedIndexChanged"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="75">File</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><INPUT id="TXT_FILE_UPLOAD_KS" type="file" size="30" name="File1" runat="Server"></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Status</TD>
												<TD>:</TD>
												<TD class="TDBGColorValue"><asp:label id="LBL_STATUS3" runat="server" ForeColor="Red"></asp:label><asp:regularexpressionvalidator id="Regularexpressionvalidator7" runat="server" ErrorMessage="Only xls, doc, txt, pdf, docx, xlsx or zip files are allowed!"
														ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.xls|.XLS|.doc|.DOC|.txt|.TXT|.zip|.ZIP|.pdf|.PDF|.docx|.DOCX|.xlsx|.XLSX|)$" ControlToValidate="TXT_FILE_UPLOAD_KS"></asp:regularexpressionvalidator></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1"></TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:label id="LBL_STATUSREPORT3" runat="server" ForeColor="Red"></asp:label></TD>
											</TR>
											<TR>
												<TD style="HEIGHT: 21px" align="center" colSpan="3"><asp:label id="LBL_SUMBERDATA_KS" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD align="center" colSpan="3"><asp:button id="UPLOAD_KS" runat="server" Text="Upload" onclick="UPLOAD_KS_Click"></asp:button></TD>
											</TR>
											<TR>
												<TD align="center" colSpan="3"></TD>
											</TR>
										</table>
									</TD>
									<TD vAlign="top" width="50%" rowSpan="2">
										<table cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD>
													<table>
														<tr>
															<td><ASP:DATAGRID id="DATA_EXPORT3" runat="server" Width="100%" CellPadding="1" AutoGenerateColumns="False"
																	ShowFooter="True" PageSize="5">
																	<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
																	<Columns>
																		<asp:BoundColumn DataField="ID_UPLOAD" HeaderText="No">
																			<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
																			<ItemStyle Width="10px"></ItemStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="FILE_UPLOAD_NAME" HeaderText="Destination File">
																			<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
																		</asp:BoundColumn>
																		<asp:TemplateColumn>
																			<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
																			<ItemStyle HorizontalAlign="Center"></ItemStyle>
																			<ItemTemplate>
																				<asp:checkbox id="chk_3" runat="server"></asp:checkbox>
																			</ItemTemplate>
																			<FooterStyle HorizontalAlign="Center"></FooterStyle>
																			<FooterTemplate>
																				<asp:LinkButton id="Linkbutton11" runat="server" CommandName="allfac3">Select All</asp:LinkButton>
																			</FooterTemplate>
																		</asp:TemplateColumn>
																		<asp:TemplateColumn HeaderText="Function">
																			<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
																			<ItemStyle HorizontalAlign="Center"></ItemStyle>
																			<ItemTemplate>
																				<asp:LinkButton id="UPL3_DELETE" runat="server" CommandName="delete">Delete</asp:LinkButton>
																			</ItemTemplate>
																		</asp:TemplateColumn>
																	</Columns>
																	<PagerStyle Mode="NumericPages"></PagerStyle>
																</ASP:DATAGRID></td>
														</tr>
														<tr>
															<td align="right"><asp:button id="DELETE_KS" runat="server" Text="DELETE" onclick="DELETE_KS_Click"></asp:button></td>
														</tr>
													</table>
												</TD>
											</TR>
										</table>
									</TD>
								</tr>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD align="center" colSpan="2">
							<TABLE class="td" id="Table1" cellSpacing="1" cellPadding="1" border="1">
								<TR id="Tr13" runat="server">
									<TD class="tdHeader1" colSpan="2">DOCUMENT IAC SEKTOR TERKAIT</TD>
								</TR>
								<tr id="Tr14" runat="server">
									<TD vAlign="top" width="50%">
										<table cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD class="TDBGColor1" width="75">KSEBM</TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_KSEBM_IST" AutoPostBack="True" CssClass="Mandatory" Runat="server" Width="100%" onselectedindexchanged="DDL_KSEBM_IST_SelectedIndexChanged"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="75">File</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><INPUT id="TXT_FILE_UPLOAD_IST" type="file" size="30" name="File1" runat="Server"></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Status</TD>
												<TD>:</TD>
												<TD class="TDBGColorValue"><asp:label id="LBL_STATUS4" runat="server" ForeColor="Red"></asp:label><asp:regularexpressionvalidator id="Regularexpressionvalidator8" runat="server" ErrorMessage="Only xls, doc, txt, pdf, docx, xlsx or zip files are allowed!"
														ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.xls|.XLS|.doc|.DOC|.txt|.TXT|.zip|.ZIP|.pdf|.PDF|.docx|.DOCX|.xlsx|.XLSX|)$" ControlToValidate="TXT_FILE_UPLOAD_IST"></asp:regularexpressionvalidator></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1"></TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:label id="LBL_STATUSREPORT4" runat="server" ForeColor="Red"></asp:label></TD>
											</TR>
											<TR>
												<TD style="HEIGHT: 21px" align="center" colSpan="3"><asp:label id="LBL_SUMBERDATA_IST" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD align="center" colSpan="3"><asp:button id="UPLOAD_IST" runat="server" Text="Upload" onclick="UPLOAD_IST_Click"></asp:button></TD>
											</TR>
											<TR>
												<TD align="center" colSpan="3"></TD>
											</TR>
										</table>
									</TD>
									<TD vAlign="top" width="50%" rowSpan="2">
										<table cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD>
													<table>
														<tr>
															<td><ASP:DATAGRID id="DATA_EXPORT4" runat="server" Width="100%" CellPadding="1" AutoGenerateColumns="False"
																	ShowFooter="True" PageSize="5">
																	<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
																	<Columns>
																		<asp:BoundColumn DataField="ID_UPLOAD" HeaderText="No">
																			<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
																			<ItemStyle Width="10px"></ItemStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="FILE_UPLOAD_NAME" HeaderText="Destination File">
																			<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
																		</asp:BoundColumn>
																		<asp:TemplateColumn>
																			<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
																			<ItemStyle HorizontalAlign="Center"></ItemStyle>
																			<ItemTemplate>
																				<asp:checkbox id="chk_4" runat="server"></asp:checkbox>
																			</ItemTemplate>
																			<FooterStyle HorizontalAlign="Center"></FooterStyle>
																			<FooterTemplate>
																				<asp:LinkButton id="Linkbutton13" runat="server" CommandName="allfac4">Select All</asp:LinkButton>
																			</FooterTemplate>
																		</asp:TemplateColumn>
																		<asp:TemplateColumn HeaderText="Function">
																			<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
																			<ItemStyle HorizontalAlign="Center"></ItemStyle>
																			<ItemTemplate>
																				<asp:LinkButton id="UPL4_DELETE" runat="server" CommandName="delete">Delete</asp:LinkButton>
																			</ItemTemplate>
																		</asp:TemplateColumn>
																	</Columns>
																	<PagerStyle Mode="NumericPages"></PagerStyle>
																</ASP:DATAGRID></td>
														</tr>
														<tr>
															<td align="right"><asp:button id="DELETE_IST" runat="server" Text="DELETE" onclick="DELETE_IST_Click"></asp:button></td>
														</tr>
													</table>
												</TD>
											</TR>
										</table>
									</TD>
								</tr>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD align="center" colSpan="2">
							<TABLE class="td" id="Table1" cellSpacing="1" cellPadding="1" border="1">
								<TR id="Tr15" runat="server">
									<TD class="tdHeader1" colSpan="2">DOCUMENT HASIL STRESS TEST SEKTOR TERKAIT</TD>
								</TR>
								<tr id="Tr16" runat="server">
									<TD vAlign="top" width="50%">
										<table cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD class="TDBGColor1" width="75" style="HEIGHT: 15px">KSEBM</TD>
												<TD style="WIDTH: 15px; HEIGHT: 15px"></TD>
												<TD class="TDBGColorValue" style="HEIGHT: 15px"><asp:dropdownlist id="DDL_KSEBM_HST" AutoPostBack="True" CssClass="Mandatory" Runat="server" Width="100%" onselectedindexchanged="DDL_KSEBM_HST_SelectedIndexChanged"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="75">File</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><INPUT id="TXT_FILE_UPLOAD_HST" type="file" size="30" name="File1" runat="Server"></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Status</TD>
												<TD>:</TD>
												<TD class="TDBGColorValue"><asp:label id="LBL_STATUS5" runat="server" ForeColor="Red"></asp:label><asp:regularexpressionvalidator id="Regularexpressionvalidator9" runat="server" ErrorMessage="Only xls, doc, txt, pdf, docx, xlsx or zip files are allowed!"
														ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.xls|.XLS|.doc|.DOC|.txt|.TXT|.zip|.ZIP|.pdf|.PDF|.docx|.DOCX|.xlsx|.XLSX|)$" ControlToValidate="TXT_FILE_UPLOAD_HST"></asp:regularexpressionvalidator></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1"></TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:label id="LBL_STATUSREPORT5" runat="server" ForeColor="Red"></asp:label></TD>
											</TR>
											<TR>
												<TD style="HEIGHT: 21px" align="center" colSpan="3"><asp:label id="LBL_SUMBERDATA_HST" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD align="center" colSpan="3"><asp:button id="UPLOAD_HST" runat="server" Text="Upload" onclick="UPLOAD_HST_Click"></asp:button></TD>
											</TR>
											<TR>
												<TD align="center" colSpan="3"></TD>
											</TR>
										</table>
									</TD>
									<TD vAlign="top" width="50%" rowSpan="2">
										<table cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD>
													<table>
														<tr>
															<td><ASP:DATAGRID id="DATA_EXPORT5" runat="server" Width="100%" CellPadding="1" AutoGenerateColumns="False"
																	ShowFooter="True" PageSize="5">
																	<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
																	<Columns>
																		<asp:BoundColumn DataField="ID_UPLOAD" HeaderText="No">
																			<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
																			<ItemStyle Width="10px"></ItemStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="FILE_UPLOAD_NAME" HeaderText="Destination File">
																			<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
																		</asp:BoundColumn>
																		<asp:TemplateColumn>
																			<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
																			<ItemStyle HorizontalAlign="Center"></ItemStyle>
																			<ItemTemplate>
																				<asp:checkbox id="chk_5" runat="server"></asp:checkbox>
																			</ItemTemplate>
																			<FooterStyle HorizontalAlign="Center"></FooterStyle>
																			<FooterTemplate>
																				<asp:LinkButton id="Linkbutton15" runat="server" CommandName="allfac5">Select All</asp:LinkButton>
																			</FooterTemplate>
																		</asp:TemplateColumn>
																		<asp:TemplateColumn HeaderText="Function">
																			<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
																			<ItemStyle HorizontalAlign="Center"></ItemStyle>
																			<ItemTemplate>
																				<asp:LinkButton id="UPL5_DELETE" runat="server" CommandName="delete">Delete</asp:LinkButton>
																			</ItemTemplate>
																		</asp:TemplateColumn>
																	</Columns>
																	<PagerStyle Mode="NumericPages"></PagerStyle>
																</ASP:DATAGRID></td>
														</tr>
														<tr>
															<td align="right"><asp:button id="DELETE_HST" runat="server" Text="DELETE" onclick="DELETE_HST_Click"></asp:button></td>
														</tr>
													</table>
												</TD>
											</TR>
										</table>
									</TD>
								</tr>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD align="center" colSpan="2">
							<TABLE class="td" id="Table1" cellSpacing="1" cellPadding="1" border="1">
								<TR id="Tr1" runat="server">
									<TD class="tdHeader1" colSpan="2">BERITA SEKTORAL</TD>
								</TR>
								<tr id="Tr2" runat="server">
									<TD vAlign="top" width="50%">
										<table cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD class="TDBGColor1" width="75">KSEBM</TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_KSEBM_BS" AutoPostBack="True" CssClass="Mandatory" Runat="server" Width="100%" onselectedindexchanged="DDL_KSEBM_BS_SelectedIndexChanged"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="75">File</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><INPUT id="TXT_FILE_UPLOAD_BS" type="file" size="30" name="File1" runat="Server"></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Status</TD>
												<TD>:</TD>
												<TD class="TDBGColorValue"><asp:label id="LBL_STATUS6" runat="server" ForeColor="Red"></asp:label><asp:regularexpressionvalidator id="Regularexpressionvalidator2" runat="server" ErrorMessage="Only xls, doc, txt, pdf, docx, xlsx or zip files are allowed!"
														ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.xls|.XLS|.doc|.DOC|.txt|.TXT|.zip|.ZIP|.pdf|.PDF|.docx|.DOCX|.xlsx|.XLSX|)$" ControlToValidate="TXT_FILE_UPLOAD_HST"></asp:regularexpressionvalidator></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1"></TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:label id="LBL_STATUSREPORT6" runat="server" ForeColor="Red"></asp:label></TD>
											</TR>
											<TR>
												<TD style="HEIGHT: 21px" align="center" colSpan="3"><asp:label id="LBL_SUMBERDATA_BS" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD align="center" colSpan="3"><asp:button id="UPLOAD_BS" runat="server" Text="Upload" onclick="UPLOAD_BS_Click"></asp:button></TD>
											</TR>
											<TR>
												<TD align="center" colSpan="3"></TD>
											</TR>
										</table>
									</TD>
									<TD vAlign="top" width="50%" rowSpan="2">
										<table cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD>
													<table>
														<tr>
															<td><ASP:DATAGRID id="DATA_EXPORT6" runat="server" Width="100%" CellPadding="1" AutoGenerateColumns="False"
																	ShowFooter="True" PageSize="5">
																	<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
																	<Columns>
																		<asp:BoundColumn DataField="ID_UPLOAD" HeaderText="No">
																			<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
																			<ItemStyle Width="10px"></ItemStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="FILE_UPLOAD_NAME" HeaderText="Destination File">
																			<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
																		</asp:BoundColumn>
																		<asp:TemplateColumn>
																			<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
																			<ItemStyle HorizontalAlign="Center"></ItemStyle>
																			<ItemTemplate>
																				<asp:checkbox id="chk_6" runat="server"></asp:checkbox>
																			</ItemTemplate>
																			<FooterStyle HorizontalAlign="Center"></FooterStyle>
																			<FooterTemplate>
																				<asp:LinkButton id="Linkbutton1" runat="server" CommandName="allfac6">Select All</asp:LinkButton>
																			</FooterTemplate>
																		</asp:TemplateColumn>
																		<asp:TemplateColumn HeaderText="Function">
																			<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
																			<ItemStyle HorizontalAlign="Center"></ItemStyle>
																			<ItemTemplate>
																				<asp:LinkButton id="UPL6_DELETE" runat="server" CommandName="delete">Delete</asp:LinkButton>
																			</ItemTemplate>
																		</asp:TemplateColumn>
																	</Columns>
																	<PagerStyle Mode="NumericPages"></PagerStyle>
																</ASP:DATAGRID></td>
														</tr>
														<tr>
															<td align="right"><asp:button id="DELETE_BS" runat="server" Text="DELETE" onclick="DELETE_BS_Click"></asp:button></td>
														</tr>
													</table>
												</TD>
											</TR>
										</table>
									</TD>
								</tr>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="tdH" colSpan="2"><asp:label id="Label1" runat="server"></asp:label></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
