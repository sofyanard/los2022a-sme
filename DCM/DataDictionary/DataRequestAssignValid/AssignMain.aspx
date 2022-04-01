<%@ Page language="c#" Codebehind="AssignMain.aspx.cs" AutoEventWireup="True" Inherits="SME.DCM.DataDictionary.DataRequestAssignValid.AssignMain" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>AssignMain</TITLE>
		<META name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<META name="CODE_LANGUAGE" Content="C#">
		<META name="vs_defaultClientScript" content="JavaScript">
		<META name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../../Style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY MS_POSITIONING="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<CENTER>
				<TABLE width="100%" border="0">
					<TR>
						<TD align="left">
							<TABLE id="Table1">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B><B>REQUEST DATA APPROVAL</B></B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/image/Back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../../../Body.aspx"><IMG height="25" src="../../../Image/MainMenu.jpg" width="106"></A>
							<A href="../../../Logout.aspx" target="_top"><IMG src="../../../Image/Logout.jpg"></A>
						</TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">REQUEST DATA</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%">Request # :</TD>
									<TD class="TDBGColorValue" width="50%"><asp:textbox id="TXT_REQ" runat="server" Enabled="False" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%">Request Purpose :</TD>
									<TD class='A"TDBGColorValue"' width="50%"><asp:dropdownlist CssClass="Mandatory" id="DDL_PURPOSE" runat="server" Enabled="False" Width="100%"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%">Request Date :</TD>
									<TD class="TDBGColorValue" width="50%"><asp:textbox id="TXT_TGL" runat="server" Enabled="False" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%">Remark* :</TD>
									<TD class="TDBGColorValue" width="50%"><asp:textbox id="TXT_REMARK" runat="server" Enabled="False" Width="100%"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">REQUEST CRITERIA<asp:label id="TXT_XLSNAME" Visible="False" Runat="server"></asp:label></TD>
					</TR>
					<TR>
						<TD class="td" style="HEIGHT: 7px" vAlign="top" width="50%">
							<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="td" vAlign="top" align="center" width="50%" colSpan="3"><asp:datagrid id="DATA_GRID" runat="server" Width="100%" PageSize="5" CellPadding="1" AutoGenerateColumns="False"
											AllowPaging="True">
											<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
											<Columns>
												<asp:BoundColumn DataField="SEQ" HeaderText="NO">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="DESCRIPTION" HeaderText="DESCRIPTION">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Left"></ItemStyle>
												</asp:BoundColumn>
												<asp:TemplateColumn HeaderText="FUNCTION">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
												</asp:TemplateColumn>
											</Columns>
											<PagerStyle Mode="NumericPages"></PagerStyle>
										</asp:datagrid></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" style="HEIGHT: 7px" vAlign="top" width="50%">
							<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD><ASP:DATAGRID id="DATA_EXPORT" runat="server" Width="100%" PageSize="5" CellPadding="1" AutoGenerateColumns="False"
											AllowPaging="True">
											<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
											<Columns>
												<asp:BoundColumn DataField="ID_UPLOAD_EXP" HeaderText="No">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle Width="10px" HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="FILE_UPLOAD_EXP_NAME" HeaderText="FILE DESTINATION">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												</asp:BoundColumn>
												<asp:TemplateColumn>
													<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
													<ItemTemplate>
														<asp:HyperLink id="SCORING_DOWNLOAD" runat="server" Target="_blank">Download</asp:HyperLink>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn>
													<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
													<ItemTemplate>
														<asp:LinkButton id="SCORING_DELETE" runat="server" CommandName="delete" Visible="False">Delete</asp:LinkButton>
													</ItemTemplate>
												</asp:TemplateColumn>
											</Columns>
											<PagerStyle Mode="NumericPages"></PagerStyle>
										</ASP:DATAGRID></TD>
								</TR>
								<TR>
									<TD vAlign="top" width="50%">
										<TABLE cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD class="TDBGColor1" width="30%">File :</TD>
												<TD class="TDBGColorValue" width="50%"><INPUT id="TXT_FILE_UPLOAD" style="WIDTH: 100%; HEIGHT: 19px" type="file" size="38" name="File1"
														runat="Server"></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="30%">Status :</TD>
												<TD class="TDBGColorValue" width="50%"><asp:label id="LBL_STATUS" runat="server" ForeColor="Red"></asp:label><asp:regularexpressionvalidator id="Regularexpressionvalidator2" runat="server" ErrorMessage="Only xls, doc, txt, pdf, docx, xlsx or zip files are allowed!"
														ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.xls|.XLS|.doc|.DOC|.txt|.TXT|.zip|.ZIP|.pdf|.PDF|.docx|.DOCX|.xlsx|.XLSX|)$" ControlToValidate="TXT_FILE_UPLOAD"></asp:regularexpressionvalidator></TD>
											</TR>
											<TR>
												<TD></TD>
												<TD class="TDBGColorValue" width="50%"><asp:label id="LBL_STATUSREPORT" runat="server" ForeColor="Red"></asp:label></TD>
											</TR>
											<TR>
												<TD style="HEIGHT: 21px" align="center" colSpan="2"><asp:button id="BTN_UPLOAD" runat="server" Width="80px" Font-Bold="True" Text="Upload" onclick="BTN_UPLOAD_Click"></asp:button></TD>
											</TR>
											<TR>
												<TD align="center" colSpan="3"></TD>
											</TR>
											<TR>
												<TD align="left" colSpan="3"><FONT color="#0000ff">Note : disarankan utk mempercepat 
														proses tidak meng-klik tulisan download, tp di klik kanan saja dari tulisan 
														download tersebut, kemudian pilih "save target as"...simpan di lokal komputer</FONT></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2"><B>DATA REQUEST RESULT</B></TD>
					</TR>
					<TR>
						<TD align="center" width="50%" valign="top" colspan="2">
							<asp:textbox id="DESC_TXT" Width="100%" Runat="server" TextMode="MultiLine" Height="75px" MaxLength="8000"
								CssClass="Mandatory" ReadOnly="True"></asp:textbox></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">GENERATE DATA<asp:label id="TXT_XLSNAME1" Visible="False" Runat="server"></asp:label></TD>
					</TR>
					<TR>
						<TD vAlign="top" width="50%">
							<TABLE cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="30%">File :</TD>
									<TD class="TDBGColorValue" width="50%"><INPUT id="TXT_FILE_UPLOAD1" style="WIDTH: 100%; HEIGHT: 19px" type="file" size="38" name="File1"
											runat="Server"></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="30%">Status :</TD>
									<TD class="TDBGColorValue" width="50%"><asp:label id="LBL_STATUS1" runat="server" ForeColor="Red"></asp:label><asp:regularexpressionvalidator id="Regularexpressionvalidator1" runat="server" ErrorMessage="Only xls, doc, txt, pdf, docx, xlsx or zip files are allowed!"
											ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.xls|.XLS|.doc|.DOC|.txt|.TXT|.zip|.ZIP|.pdf|.PDF|.docx|.DOCX|.xlsx|.XLSX|)$" ControlToValidate="TXT_FILE_UPLOAD"></asp:regularexpressionvalidator></TD>
								</TR>
								<TR>
									<TD></TD>
									<TD class="TDBGColorValue" width="50%"><asp:label id="LBL_STATUSREPORT1" runat="server" ForeColor="Red"></asp:label></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 21px" align="center" colSpan="2"><asp:button id="BTN_UPLOAD1" runat="server" Width="80px" Font-Bold="True" Text="Upload" onclick="BTN_UPLOAD1_Click"></asp:button></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="3"></TD>
								</TR>
								<TR>
									<TD align="left" colSpan="3"><FONT color="#0000ff">Note : disarankan utk mempercepat 
											proses tidak meng-klik tulisan download, tp di klik kanan saja dari tulisan 
											download tersebut, kemudian pilih "save target as"...simpan di lokal komputer</FONT></TD>
								</TR>
							</TABLE>
						</TD>
						<TD vAlign="top" width="50%" rowSpan="2">
							<TABLE cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD><ASP:DATAGRID id="DGR_EXPORT" runat="server" Width="100%" PageSize="5" CellPadding="1" AutoGenerateColumns="False"
											AllowPaging="True">
											<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
											<Columns>
												<asp:BoundColumn DataField="ID_UPLOAD_EXP" HeaderText="No">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle Width="10px" HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="FILE_UPLOAD_EXP_NAME" HeaderText="FILE DESTINATION">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												</asp:BoundColumn>
												<asp:TemplateColumn>
													<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
													<ItemTemplate>
														<asp:HyperLink id="SCORING_DOWNLOAD1" runat="server" Target="_blank">Download</asp:HyperLink>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn>
													<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
													<ItemTemplate>
														<asp:LinkButton id="SCORING_DELETE1" runat="server" CommandName="delete">Delete</asp:LinkButton>
													</ItemTemplate>
												</asp:TemplateColumn>
											</Columns>
											<PagerStyle Mode="NumericPages"></PagerStyle>
										</ASP:DATAGRID>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">DATA REQUEST ASSIGNMENT</TD>
					</TR>
					<TR>
						<TD vAlign="top" width="50%" rowspan="2">
							<TABLE cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%">PIC Data Service Owner :</TD>
									<TD class='A"TDBGColorValue"' width="50%"><asp:dropdownlist CssClass="Mandatory" id="DDL_PICSERVICE" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD></TD>
								</TR>
								<TR>
									<TD>
										<asp:Image id="IMG_ASSIGN_STATUS" runat="server"></asp:Image>
										<asp:Label id="LBL_ASSIGN_STATUS" runat="server"></asp:Label>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD vAlign="top" align="left" width="50%" colSpan="2">
							<asp:button id="BTN_ASSIGN" runat="server" Text="ASSIGN" CssClass="button1" Width="100px" onclick="BTN_ASSIGN_Click"></asp:button>&nbsp;
							<asp:button id="BTN_REASSIGN" runat="server" Text="RE-ASSIGN" CssClass="button1" Enabled="False"
								Width="100px" onclick="BTN_REASSIGN_Click"></asp:button>
						</TD>
					</TR>
				</TABLE>
			</CENTER>
		</FORM>
	</BODY>
</HTML>
