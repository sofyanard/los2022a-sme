<%@ Page language="c#" Codebehind="Watchlist.aspx.cs" AutoEventWireup="True" Inherits="SME.LMS.Watchlist" %>
<%@ Register TagPrefix="uc1" TagName="GenInfo" Src="CommonGeneralInfo.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Watchlist</title>
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
										<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>WATCHLIST</B></TD>
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
						<TR id="TR_ACQINFO" runat="server">
							<TD class="tdheader1" colSpan="2">Information acquired</TD>
						</TR>
						<TR id="TR_ACQINFO1" runat="server">
							<TD colSpan="2"><asp:textbox id="TXT_ACQINFO" Runat="server" ReadOnly="True" TextMode="MultiLine" Width="100%"
									Height="150"></asp:textbox></TD>
						</TR>
						<TR id="Tr1" runat="server">
							<TD class="tdheader1" colSpan="2">Checklist Summary</TD>
						</TR>
						<TR>
							<TD colSpan="2"><ASP:DATAGRID id="DatGrd" runat="server" Width="100%" CellPadding="1" AutoGenerateColumns="False"
									AllowPaging="True">
									<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
									<Columns>
										<asp:BoundColumn DataField="ITEM_CODE" HeaderText="No.">
											<HeaderStyle CssClass="tdSmallHeader" Width="10%"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="ITEM_DESC" HeaderText="Parameter">
											<HeaderStyle CssClass="tdSmallHeader" Width="65%"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="ITEM_VALUE" HeaderText="Klasifikasi">
											<HeaderStyle CssClass="tdSmallHeader" Width="25%"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
									</Columns>
									<PagerStyle Mode="NumericPages"></PagerStyle>
								</ASP:DATAGRID></TD>
						</TR>
						<TR>
							<TD class="tdHeader1" colSpan="2">Hasil Watchlist Checking</TD>
						</TR>
						<TR>
							<TD align="center" colSpan="2">
								<TABLE id="Table2" cellSpacing="2" cellPadding="2" width="100%" border="0">
									<TR>
										<TD class="TDBGColor1">Kategori</TD>
										<TD style="WIDTH: 15px">:</TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_KATEGORI" runat="server" ReadOnly="True" Width="200px" BorderStyle="None"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Faktor Penyebab</TD>
										<TD>:</TD>
										<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_FAKTOR" runat="server" ReadOnly="True" Width="200px" BorderStyle="None"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Follow Up</TD>
										<TD>:</TD>
										<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_FOLLOW" runat="server" ReadOnly="True" Width="200px" BorderStyle="None"></asp:textbox></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD class="tdHeader1" width="100%" colSpan="2">Remark</TD>
						</TR>
						<TR>
							<TD width="100%" colSpan="2">
								<P><asp:textbox onkeypress="return kutip_satu()" id="TXT_REMARK" Width="100%" Runat="server" Height="100px"
										TextMode="MultiLine"></asp:textbox></P>
							</TD>
						</TR>
						<TR>
							<TD class="tdHeader1" width="100%" colSpan="2">Document Upload</TD>
						</TR>
						<TR>
							<TD vAlign="top" width="50%">
								<table cellSpacing="0" cellPadding="0" width="100%">
									<tr>
										<td><asp:datagrid id="DG_XLS" runat="server" Width="100%" CellPadding="1" AutoGenerateColumns="False"
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
										<TD><ASP:DATAGRID id="DatGrid" runat="server" Width="100%" CellPadding="1" AutoGenerateColumns="False"
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
						<TR>
							<TD class="tdHeader1" width="100%" colSpan="2">Decision</TD>
						</TR>
					</TBODY>
				</TABLE>
				<TABLE>
					<TR>
						<TD width="50%">
							<TABLE>
								<TR id="TR_EXPOSURE" runat="server">
									<TD class="TDBGColor1" style="WIDTH: 200px; HEIGHT: 15px" vAlign="middle">Total 
										Exposure</TD>
									<TD style="WIDTH: 300px; HEIGHT: 15px" vAlign="top"><asp:textbox id="TXT_EXPOSURE" runat="server" ReadOnly="True" Width="200px" DataFormatString="{0:00.00,00}"></asp:textbox></TD>
								</TR>
								<TR id="TR_WEWENANG" runat="server">
									<TD class="TDBGColor1" style="WIDTH: 200px; HEIGHT: 15px" vAlign="middle">Wewenang 
										Memutus</TD>
									<TD style="WIDTH: 300px; HEIGHT: 15px" vAlign="top"><asp:dropdownlist id="DDL_WEWENANG" Runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
								</TR>
								<TR id="TR_RKK" runat="server">
									<TD class="TDBGColor1" style="WIDTH: 200px; HEIGHT: 15px" vAlign="middle"><asp:checkbox id="CHK_RKK" runat="server" Text="Submit to RKK" AutoPostBack="True" oncheckedchanged="CHK_RKK_CheckedChanged"></asp:checkbox></TD>
									<TD style="WIDTH: 300px; HEIGHT: 15px" vAlign="top"><asp:dropdownlist id="DDL_RKK" Runat="server"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</TD>
						<TD width="50%" vAlign="middle" align="center">
							<asp:button id="BTN_SAVE" Runat="server" Text="Save" CssClass="button1" Width="200px" onclick="BTN_SAVE_Click"></asp:button>
						</TD>
					</TR>
				</TABLE>
				<TR>
					<TD><p></p>
					</TD>
				</TR>
				<TABLE>
					<TR id="TR_UPDATE" runat="server">
						<TD vAlign="top" class="tdBGColor2" align="center" colspan="3">
							<asp:button id="BTN_UPDATE" Runat="server" Width="200px" Text="Forward to Acceptance" CssClass="button1" onclick="BTN_UPDATE_Click"></asp:button>
						</TD>
					</TR>
					<TR id="TR_ADVIS" runat="server">
						<TD class="TDBGColor1" style="WIDTH: 200px; HEIGHT: 15px" vAlign="middle">Advis 
							Assign to</TD>
						<TD style="WIDTH: 300px; HEIGHT: 15px" vAlign="top"><asp:dropdownlist id="DDL_ADVIS" Runat="server"></asp:dropdownlist></TD>
						<TD style="WIDTH: 500px; HEIGHT: 15px" vAlign="top" class="tdBGColor2" align="center">
							<asp:button id="BTN_ADVIS" Runat="server" Width="200px" Text="Assign to Advis" CssClass="Button1" onclick="BTN_ADVIS_Click"></asp:button>
						</TD>
					</TR>
					<TR id="TR_ADVISREPLY" runat="server">
						<TD class="tdBGColor2" align="center" colspan="3">
							<asp:button id="BTN_ADVISREPLY" Runat="server" Width="200px" Text="Forward to Acceptance" CssClass="button1" onclick="BTN_ADVISREPLY_Click"></asp:button>
						</TD>
					</TR>
					<TR id="TR_FORWARD" runat="server">
						<TD class="TDBGColor1" style="WIDTH: 200px; HEIGHT: 15px" vAlign="middle"><asp:label id="LBL_FORWARD" Runat="server">Next Acceptance Forward to</asp:label></TD>
						<TD style="WIDTH: 300px; HEIGHT: 15px" vAlign="top"><asp:dropdownlist id="DDL_FORWARD" Runat="server"></asp:dropdownlist></TD>
						<TD style="WIDTH: 500px; HEIGHT: 15px" vAlign="top" class="tdBGColor2" align="center">
							<asp:button id="BTN_FORWARD" Runat="server" Width="200px" Text="Forward" CssClass="Button1" onclick="BTN_FORWARD_Click"></asp:button>
						</TD>
					</TR>
					<TR id="TR_ACCEPT" runat="server">
						<TD class="tdBGColor2" align="center" colspan="3">
							<asp:button id="BTN_ACCEPT" Runat="server" Width="200px" Text="Accept" CssClass="button1" onclick="BTN_ACCEPT_Click"></asp:button>
						</TD>
					</TR>
					<TR id="TR_ACQINFO2" runat="server">
						<TD class="tdBGColor2" align="center" colspan="3">
							<asp:button id="BTN_ACQINFO" Runat="server" Text="Acquire Information" CssClass="button1" Width="200px" onclick="BTN_ACQINFO_Click"></asp:button>
							<asp:textbox id="TXT_TEMP" runat="server" Width="1px" BorderStyle="None"></asp:textbox>
						</TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
