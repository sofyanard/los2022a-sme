<%@ Page language="c#" Codebehind="GenInfoWatchlist1.aspx.cs" AutoEventWireup="false" Inherits="SME.LMS.PortfolioWatchlistChecking.GenInfoWatchlist1" %>
<%@ Register TagPrefix="uc1" TagName="DocExport" Src="CommonForm/DocExport.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>GenInfoWatchlist1</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table4" width="100%" border="0">
				<TR>
					<TD align="left" colSpan="1">
						<TABLE id="Table3">
							<TR>
								<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>GENERAL INFO</B></TD>
							</TR>
						</TABLE>
					</TD>
					<td align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg"></asp:imagebutton><A href="../../Body.aspx"><IMG src="../../Image/MainMenu.jpg"></A><A href="../../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A></td>
				</TR>
				<tr>
					<td align="center"><asp:placeholder id="Placeholder1" runat="server"></asp:placeholder><asp:label id="HTH_PICTRACK" runat="server" Visible="False"></asp:label><asp:label id="TXT_SEND_TO" runat="server" Visible="False"></asp:label><asp:label id="TXT_SEND_BY" runat="server" Visible="False"></asp:label></td>
				</tr>
				<tr>
					<!--../dataentry/custproduct.aspx?regno=<%=Request.QueryString["regno"]%>&curef=<%=Request.QueryString["curef"]%>&sta=view-->
					<td align="center" colSpan="2"><iframe id="if2" name="if2" src="" width="100%" scrolling="auto" height="100"></iframe>
					</td>
				</tr>
				<TR>
					<TD align="center" colSpan="2">&nbsp;</TD>
				</TR>
				<tr>
					<td class="tdHeader1" id="Td2" vAlign="middle" colSpan="2" runat="server">PORTOFOLIO 
						WATCHLIST CHECKING</td>
				</tr>
				<TR>
					<TD class="td" vAlign="top" width="50%">
						<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 129px">No. Nota</TD>
								<TD style="WIDTH: 15px">:</TD>
								<TD class="TDBGColorValue"><asp:textbox id="TXT_NO_NOTA" runat="server" BorderStyle="None" Width="300px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Periode</TD>
								<TD style="WIDTH: 15px">:</TD>
								<TD class="TDBGColorValue"><asp:textbox id="TXT_PERIODE" runat="server" BorderStyle="None" Width="300px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">No. LMS</TD>
								<TD style="WIDTH: 15px">:</TD>
								<TD class="TDBGColorValue"><asp:textbox id="TXT_NO_LMS" runat="server" BorderStyle="None" Width="300px" ReadOnly="True"></asp:textbox></TD>
							</TR>
						</TABLE>
						<asp:label id="LBL_LOAN_TYPE_ID" runat="server" Visible="False"></asp:label><asp:label id="LBL_AP_PROG_CODE" runat="server" Visible="False"></asp:label></TD>
					<TD class="td" vAlign="top" width="50%">
						<TABLE id="Table10" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD class="TDBGColor1" width="129">Tanggal Nota</TD>
								<TD style="WIDTH: 15px">:</TD>
								<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_NOTA" runat="server" Width="24px"
										Columns="4" MaxLength="2"></asp:textbox><asp:dropdownlist id="DDL_BLN_NOTA" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_NOTA" runat="server" Width="36px"
										Columns="4" MaxLength="4"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Analyst</TD>
								<TD>:</TD>
								<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_ANALYST" runat="server" BorderStyle="None" Width="300px" ReadOnly="True"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">LMS Date</TD>
								<TD>:</TD>
								<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_LMS_DATE" runat="server" Width="300px" ReadOnly="True"></asp:textbox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<tr>
					<td></td>
				</tr>
				<tr>
					<td colSpan="3">
						<table id="Table33" cellSpacing="0" cellPadding="0" width="100%">
							<tr>
								<td width="30%"><ASP:DATAGRID id="DATGRD_PERIODE" runat="server" Width="100%" AllowPaging="True" CellPadding="1"
										AutoGenerateColumns="False">
										<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
										<Columns>
											<asp:BoundColumn HeaderText="loan id" DataField="loan_type_id" Visible="False">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="Jenis Kredit" DataField="loan_type">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:ButtonColumn Text="Retrieve" HeaderText="Function" CommandName="Retrieve">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
											</asp:ButtonColumn>
										</Columns>
										<PagerStyle Mode="NumericPages"></PagerStyle>
									</ASP:DATAGRID></td>
								<td width="70%"></td>
							</tr>
							<tr>
								<td></td>
							</tr>
							<tr>
								<td width="100%" colSpan="2"><ASP:DATAGRID id="DATGRD_PORTFOLIO" runat="server" Width="100%" AllowPaging="True" CellPadding="1"
										AutoGenerateColumns="False" PageSize="20">
										<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
										<Columns>
											<asp:BoundColumn DataField="Unit_name" HeaderText="Unit Name">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="jenis" HeaderText="Jenis">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="trashold" HeaderText="Threshold (%)">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="bulan_ke_n_2" HeaderText="Bln ke n-2 (%)">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="bulan_ke_n_1" HeaderText="Bln ke n-1 (%)">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="bulan_ke_n" HeaderText="Bulan ke n (%)">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="status" HeaderText="Status">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="Portfolio Strategy">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
												<ItemTemplate>
													<asp:TextBox Runat="server" Width="200px" TextMode="MultiLine" ID="TXT_STRATEGY"></asp:TextBox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn Visible="False" DataField="buc_cd">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="loan_type_id">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle Mode="NumericPages"></PagerStyle>
									</ASP:DATAGRID></td>
								<td width="80%"></td>
							</tr>
							<tr>
								<td class="TDBGColor2" colSpan="2"><asp:button id="Button1" Text="SAVE" Runat="server" CssClass="button1"></asp:button>&nbsp;<asp:button id="BTN_CLEAR_PERIODE" Text="CLEAR" Runat="server" CssClass="button1"></asp:button>
								</td>
							</tr>
							<tr>
								<td></td>
							</tr>
							<!--<tr>
								<td class="tdHeader1" id="Td1" vAlign="middle" colSpan="2" runat="server">NOTA 
									ANALISA</td>
							</tr>
							<tr>
								<td vAlign="top" width="50%">
									<table cellSpacing="0" cellPadding="0" width="100%">
										<TR>
											<TD class="TDBGColor1" width="75">Format</TD>
											<TD style="WIDTH: 15px">:</TD>
											<TD class="TDBGColorValue"><INPUT id="TXT_FILE_UPLOAD" style="WIDTH: 344px; HEIGHT: 19px" type="file" size="38" name="File1"
													runat="Server"></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1">Status</TD>
											<TD>:</TD>
											<TD class="TDBGColorValue"><asp:label id="LBL_STATUS" runat="server" ForeColor="Red"></asp:label><asp:regularexpressionvalidator id="Regularexpressionvalidator1" runat="server" ControlToValidate="TXT_FILE_UPLOAD"
													ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.xls|.XLS|.doc|.DOC|.txt|.TXT|.zip|.ZIP|.pdf|.PDF|.docx|DOCX)$" ErrorMessage="Only xls, doc, txt, pdf, docx or zip files are allowed!"></asp:regularexpressionvalidator></TD>
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
								</td>
								<td vAlign="top" width="50%"><asp:datagrid id="DATA_EXPORT" runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="1"
										AllowPaging="True" PageSize="5">
										<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
										<Columns>
											<asp:BoundColumn Visible="False" DataField="ID_UPLOAD_PORTFOLIO" HeaderText="ID_UPLOAD_PORTFOLIO">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="FILE_UPLOAD_PORTFOLIO_NAME" HeaderText="File Name">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn>
												<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
												<ItemTemplate>
													<asp:HyperLink id="UPL_PORTFOLIO_DOWNLOAD" runat="server" Target="_blank">Download</asp:HyperLink>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
												<ItemTemplate>
													<asp:LinkButton id="UPL_PORTFOLIO_DELETE" runat="server" CommandName="delete">Delete</asp:LinkButton>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle Mode="NumericPages"></PagerStyle>
									</asp:datagrid></td>
							</tr> -->
							<tr>
								<td></td>
							</tr>
							<TR>
								<TD colSpan="2"><uc1:docexport id="DocExport1" runat="server"></uc1:docexport></TD>
							</TR>
							<tr>
								<td class="TDBGColor2" colSpan="2"><asp:button id="BTN_UPDATE" Text="UPDATE STATUS" Runat="server" CssClass="button1"></asp:button></td>
							</tr>
						</table>
					</td>
				</tr>
			</TABLE>
		</form>
	</body>
</HTML>
