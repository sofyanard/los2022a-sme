<%@ Register TagPrefix="uc1" TagName="DocExport" Src="../CommonForm/DocumentExport.ascx" %>
<%@ Register TagPrefix="uc1" TagName="GenInfo" Src="CommonGeneralInfo.ascx" %>
<%@ Page language="c#" Codebehind="GeneralInfo.aspx.cs" AutoEventWireup="True" Inherits="SME.LMS.GeneralInfo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>GeneralInfo</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/onepost.html" -->
		<!-- #include file="../include/ConfirmBox.html" -->
		<!-- #include file="../include/cek_all.html" -->
		<!-- #include file="../include/popup.html" -->
        <%= popUp%>
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TBODY>
						<TR>
							<TD class="tdNoBorder"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
								<TABLE id="Table4">
									<TR>
										<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>GENERAL INFO</B></TD>
									</TR>
								</TABLE>
							</TD>
							<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="../Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
						</TR>
						<TR>
							<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
						</TR>
						<TR>
							<TD colSpan="2"><uc1:geninfo id="GenInfo1" runat="server"></uc1:geninfo></TD>
						</TR>
						<tr>
							<TD align="center" colSpan="2">
								<TABLE id="Table2" cellSpacing="2" cellPadding="2" width="100%" border="0">
									<TR>
										<TD class="TDBGColor1">Segmen</TD>
										<TD style="WIDTH: 15px">:</TD>
										<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_BUSSUNIT" Runat="server" AutoPostBack="True" onselectedindexchanged="DDL_BUSSUNIT_SelectedIndexChanged"></asp:dropdownlist></TD>
									</TR>
								</TABLE>
							</TD>
						</tr>
						<tr>
							<td class="tdHeader1" width="100%" colSpan="2">Watchlist Item</td>
						</tr>
						<TR width="100%">
							<TD colSpan="2"><ASP:DATAGRID id="DGR_WATCH" runat="server" AllowPaging="True" CellPadding="1" AutoGenerateColumns="False"
									Width="100%">
									<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
									<Columns>
										<asp:BoundColumn Visible="False" DataField="BUSSUNITID"></asp:BoundColumn>
										<asp:BoundColumn Visible="False" DataField="WATCHID"></asp:BoundColumn>
										<asp:BoundColumn Visible="False" DataField="SUBWATCHID"></asp:BoundColumn>
										<asp:BoundColumn DataField="WATCHDESC" HeaderText="Watchlist Item">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="DISPNODESC" HeaderText="No">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="SUBWATCHDESC" HeaderText="Watchlist Sub Item">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										</asp:BoundColumn>
										<asp:TemplateColumn HeaderText="Watchlist Sub Sub Item">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemTemplate>
												<asp:radiobuttonlist id="RBL_SUBSUBWATCH" runat="server" RepeatDirection="Horizontal"></asp:radiobuttonlist>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:BoundColumn Visible="False" DataField="WEIGHT" HeaderText="Weight">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="ISMANDATORY" HeaderText="Watchlist">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="RVWKOLBI" HeaderText="Review Kol BI">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="PILARBI" HeaderText="Pilar BI">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
									</Columns>
									<PagerStyle Mode="NumericPages"></PagerStyle>
								</ASP:DATAGRID></TD>
						</TR>
						<tr>
							<td class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2"><asp:button id="BTN_SAVE" runat="server" CssClass="Button1" Text="Save" onclick="BTN_SAVE_Click"></asp:button></td>
						</tr>
						<tr>
							<td class="td" align="center" colSpan="2"><asp:datagrid id="DGR_SUMMARY" Runat="server" CellPadding="1" AutoGenerateColumns="False" Width="500"
									PageSize="1">
									<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
									<Columns>
										<asp:BoundColumn Visible="False" DataField="WATCHID"></asp:BoundColumn>
										<asp:BoundColumn DataField="WATCHDESC" HeaderText="Watchlist Item">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="AVERAGE" HeaderText="Average" Visible="False">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="CLASSIFICATION" HeaderText="Classification">
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										</asp:BoundColumn>
									</Columns>
								</asp:datagrid></td>
						</tr>
						<TR>
							<TD class="tdHeader1" colSpan="2">Watchlist Summary</TD>
						</TR>
						<TR>
							<TD align="center" colSpan="2">
								<TABLE id="Table2" cellSpacing="2" cellPadding="2" width="100%" border="0">
									<TR>
										<TD class="TDBGColor1">Kategori</TD>
										<TD style="WIDTH: 15px">:</TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_KATEGORI" runat="server" Width="300px" BorderStyle="None" ReadOnly="True"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Faktor Penyebab</TD>
										<TD>:</TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_FAKTOR" runat="server" Width="300px" BorderStyle="None" ReadOnly="True"></asp:textbox></TD>
									</TR>
									<TR id="TR_FOLLOW" runat="server" Visible="False">
										<TD class="TDBGColor1">Follow Up</TD>
										<TD>:</TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_FOLLOW" runat="server" Width="300px" BorderStyle="None" ReadOnly="True"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Rekomendasi Status Kolektibilitas</TD>
										<TD>:</TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_REKOMENDASI" runat="server" Width="300px" BorderStyle="None" ReadOnly="True"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Review 3 Pilar BI yang Tidak Terpenuhi</TD>
										<TD>:</TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_REVW3PILAR" runat="server" Width="300px" BorderStyle="None" ReadOnly="True"></asp:textbox></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR id="TR_ACQINFO" runat="server">
							<TD class="tdheader1" colSpan="2">Information acquired</TD>
						</TR>
						<TR id="TR_ACQINFO1" runat="server">
							<TD colSpan="2"><asp:textbox id="TXT_ACQINFO" Runat="server" Width="100%" ReadOnly="True" TextMode="MultiLine"
									Height="150"></asp:textbox></TD>
						</TR>
						<TR>
							<TD class="tdHeader1" width="100%" colSpan="2">Remark</TD>
						</TR>
						<TR>
							<TD width="100%" colSpan="2">
								<P><asp:textbox onkeypress="return kutip_satu()" id="TXT_REMARK" Runat="server" Width="100%" TextMode="MultiLine"
										Height="100px"></asp:textbox></P>
							</TD>
						</TR>
						<TR>
							<TD colSpan="2"><uc1:docexport id="DocExport1" runat="server"></uc1:docexport></TD>
						</TR>
						<TR id="TR_DOCEXPORT_OLD" runat="server">
							<TD class="tdHeader1" vAlign="top" width="50%" colSpan="2">Document Export</TD>
						</TR>
						<TR id="TR_DOCEXPORT_OLD2" runat="server">
							<TD style="WIDTH: 540px" vAlign="top" width="540">
								<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="TDBGColor1" style="HEIGHT: 19px" width="75">Format</TD>
										<TD style="WIDTH: 15px; HEIGHT: 19px">:</TD>
										<TD class="TDBGColorValue" style="HEIGHT: 19px"><asp:button id="BTN_EXPORT" runat="server" Width="64px" Text="Export" onclick="BTN_EXPORT_Click"></asp:button></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Status</TD>
										<TD>:</TD>
										<TD class="TDBGColorValue"><asp:label id="LBL_STATUS_EXPORT" runat="server" ForeColor="Red"></asp:label></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1"></TD>
										<TD></TD>
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
							<TD style="HEIGHT: 42px" vAlign="top" width="50%">
								<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD><ASP:DATAGRID id="DATA_EXPORT" runat="server" CellPadding="1" AutoGenerateColumns="False" Width="100%"
												PageSize="1">
												<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
												<Columns>
													<asp:BoundColumn Visible="False" DataField="LMS_REGNO" HeaderText="User ID"></asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="DOC_ID" HeaderText="User ID"></asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="FE_USERID" HeaderText="User ID"></asp:BoundColumn>
													<asp:BoundColumn DataField="FE_FILENAME" HeaderText="File Name">
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
							<TD class="tdHeader1" width="100%" colSpan="2">Document Upload</TD>
						</TR>
						<TR>
							<TD vAlign="top" width="50%">
								<table cellSpacing="0" cellPadding="0" width="100%">
									<tr>
										<td><asp:datagrid id="DG_XLS" runat="server" CellPadding="1" AutoGenerateColumns="False" Width="100%"
												PageSize="1">
												<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
												<Columns>
													<asp:BoundColumn DataField="cnt" HeaderText="No">
														<HeaderStyle HorizontalAlign="Center" Width="10%" CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="XLS_VIEW" HeaderText="Source File">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="Location" HeaderText="Location"></asp:BoundColumn>
													<asp:TemplateColumn>
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
														<ItemTemplate>
															<asp:HyperLink id="HP_DOWNLOAD" runat="server" Target="_blank">Download</asp:HyperLink>
														</ItemTemplate>
													</asp:TemplateColumn>
												</Columns>
											</asp:datagrid></td>
									</tr>
								</table>
							</TD>
							<TD vAlign="top" width="50%" rowSpan="2">
								<table cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD><ASP:DATAGRID id="DatGrid" runat="server" CellPadding="1" AutoGenerateColumns="False" Width="100%"
												PageSize="1">
												<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
												<Columns>
													<asp:BoundColumn Visible="False" DataField="LMS_REGNO" HeaderText="LMS App No"></asp:BoundColumn>
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
								</table>
							</TD>
						</TR>
						<TR>
							<TD vAlign="top" width="50%">
								<table cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="TDBGColor1" width="75">File</TD>
										<TD style="WIDTH: 15px">:</TD>
										<TD class="TDBGColorValue"><INPUT id="TXT_FILE_UPLOAD" type="file" size="30" name="TXT_FILE_UPLOAD" runat="Server"></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Status</TD>
										<TD>:</TD>
										<TD class="TDBGColorValue"><asp:label id="LBL_STATUS" runat="server" ForeColor="Red"></asp:label><asp:regularexpressionvalidator id="Regularexpressionvalidator2" runat="server" ErrorMessage="Only xls, doc, txt or zip files are allowed!"
												ControlToValidate="TXT_FILE_UPLOAD" ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.xls|.XLS|.doc|.DOC|.txt|.TXT|.zip|.ZIP)$"></asp:regularexpressionvalidator></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1"></TD>
										<TD></TD>
										<TD class="TDBGColorValue"><asp:label id="LBL_STATUSREPORT" runat="server" ForeColor="Red"></asp:label></TD>
									</TR>
									<TR>
										<TD style="HEIGHT: 21px" align="center" colSpan="3"><asp:label id="LBL_SUMBERDATA" runat="server"></asp:label></TD>
									</TR>
									<TR>
										<TD align="center" colSpan="3"><asp:button id="BTN_UPLOAD" runat="server" Text="Upload" onclick="BTN_UPLOAD_Click"></asp:button></TD>
									</TR>
									<TR>
										<TD align="center" colSpan="3"></TD>
									</TR>
									<TR>
										<TD align="left" colSpan="3"><FONT color="#0000ff">Note : disarankan utk mempercepat 
												proses tidak meng-klik tulisan download, tp di klik kanan saja dari tulisan 
												download tersebut, kemudian pilih "save target as"...simpan di lokal komputer</FONT></TD>
									</TR>
								</table>
							</TD>
						</TR>
						<TR id="TR_REV" runat="server">
							<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2"><asp:button id="BTN_FWDTOACC" runat="server" CssClass="Button1" Text="Forward For Acceptance" onclick="BTN_FWDTOACC_Click"></asp:button>&nbsp;
								<asp:button id="BTN_UPDTOWATCH" runat="server" CssClass="Button1" Text="Update to Nota Watchlist" onclick="BTN_UPDTOWATCH_Click"></asp:button>&nbsp;
								<asp:button id="BTN_FINISH" runat="server" CssClass="Button1" Text="Finish" onclick="BTN_FINISH_Click"></asp:button>&nbsp;
								<asp:button id="BTN_NOREVIEW" runat="server" CssClass="Button1" Text="No Review" onclick="BTN_NOREVIEW_Click"></asp:button></TD>
						</TR>
						<TR id="TR_ACC" runat="server">
							<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2"><asp:button id="BTN_ACQUIRE" runat="server" CssClass="Button1" Text="Acquire Information" onclick="BTN_ACQUIRE_Click"></asp:button>&nbsp;
								<asp:button id="BTN_ACCEPT" runat="server" CssClass="Button1" Text="Accept" onclick="BTN_ACCEPT_Click"></asp:button>&nbsp;
								<asp:textbox id="TXT_TEMP" runat="server" Width="1px" BorderStyle="None"></asp:textbox></TD>
						</TR>
						<TR id="TR_ADVIS" runat="server">
							<TD class="TDBGColor2" vAlign="middle" colSpan="2">Advis Assign to&nbsp;&nbsp;
								<asp:dropdownlist id="DDL_ADVIS" Runat="server"></asp:dropdownlist><asp:button id="BTN_ADVIS" Runat="server" Width="200px" CssClass="Button1" Text="Assign to Advis" onclick="BTN_ADVIS_Click"></asp:button></TD>
						</TR>
						<TR id="TR_ADVISREPLY" runat="server">
							<TD class="tdBGColor2" align="center" colSpan="2"><asp:button id="BTN_ADVISREPLY" Runat="server" Width="200px" CssClass="button1" Text="Forward to Acceptance" onclick="BTN_ADVISREPLY_Click"></asp:button></TD>
						</TR>
					</TBODY>
				</TABLE>
			</center>
		</form>
		</TR></TBODY></TABLE></TR></TBODY></TABLE>
		<CENTER></CENTER>
		</FORM>
	</body>
</HTML>
