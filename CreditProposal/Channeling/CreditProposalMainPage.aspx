<%@ Page language="c#" Codebehind="CreditProposalMainPage.aspx.cs" AutoEventWireup="True" Inherits="SME.CreditProposal.Channeling.CreditProposalMainPage" %>
<%@ Register TagPrefix="uc1" TagName="DocumentExport" Src="../../CommonForm/DocumentExport.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Verification Assignment</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- #include file="../../include/cek_all.html" -->
		<!-- #include file="../../include/popup.html" -->
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
  </HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TBODY>
						<TR>
							<TD class="tdNoBorder"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
								<TABLE id="Table2">
									<TR>
										<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Credit Proposal</B></TD>
									</TR>
								</TABLE>
							</TD>
							<TD class="tdNoBorder" align="right"><A href="FindCustomer.aspx?mc=CHAN002"><IMG src="/SME/Image/back.jpg"></A><A href="../../Body.aspx"><IMG src="/SME/Image/MainMenu.jpg"></A><A href="../../Logout.aspx" target="_top"><IMG src="/SME/Image/Logout.jpg"></A></TD>
						</TR>
						<TR>
							<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
						</TR>
						<TR>
							<TD class="tdHeader1" colSpan="2">
								General Info</TD>
						</TR>
						<TR>
							<TD class="td" vAlign="top" width="50%">
								<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 886px; HEIGHT: 8px">Business Unit
										</TD>
										<TD style="WIDTH: 1px; HEIGHT: 8px">:</TD>
										<TD class="TDBGColorValue" style="HEIGHT: 8px">
											<asp:DropDownList id="DDL_AP_BOOKINGBRANCH" runat="server" Width="300px" CssClass="mandatory" Enabled="False"></asp:DropDownList></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 886px">CO Unit
										</TD>
										<TD style="WIDTH: 1px">:</TD>
										<TD class="TDBGColorValue">
											<asp:DropDownList id="DDL_AP_CCOBRANCH" runat="server" Width="300px"></asp:DropDownList></TD>
									</TR>
								</TABLE>
							</TD>
							<TD class="td" vAlign="top" width="50%">
								<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="TDBGColor1" width="182" style="WIDTH: 182px">Application Date
										</TD>
										<TD style="WIDTH: 6px">:</TD>
										<TD class="TDBGColorValue">
											<asp:TextBox id="txt_DD_B" runat="server" Width="40px" CssClass="mandatory" Enabled="False"></asp:TextBox>
											<asp:DropDownList id="ddl_MM_B" runat="server" Width="176px" CssClass="mandatory" Enabled="False"></asp:DropDownList>
											<asp:TextBox id="txt_YY_B" runat="server" Width="66px" CssClass="mandatory" Enabled="False"></asp:TextBox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 182px">Application Number
										</TD>
										<TD style="WIDTH: 6px">:</TD>
										<TD class="TDBGColorValue">
											<asp:TextBox id="TXT_APPLICATION" runat="server" Width="288px" CssClass="mandatory" Enabled="False"></asp:TextBox></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD class="tdNoBorder" align="center" colspan="2"></TD>
						</TR>
					</TBODY>
				</TABLE>
				<table cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdHeader1" colSpan="3">Plafond Info</TD>
					</TR>
					<TR>
						<TD class="TDBGColor1" width="484" style="WIDTH: 49%">Plafond Owner</TD>
						<TD style="WIDTH: 1%">:</TD>
						<TD class="TDBGColorValue">
							<asp:Label id="LBL_PLAFOND_OWNER" runat="server" Width="320px">Label</asp:Label>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor1" style="WIDTH: 49%">Remaining eMas Limit</TD>
						<TD style="WIDTH: 1%">:</TD>
						<TD class="TDBGColorValue">
							<asp:Label id="LBL_REMAINING_EMAS" runat="server" Width="320px">Label</asp:Label>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor1" style="WIDTH: 49%">Pending Limit</TD>
						<TD style="WIDTH: 1%">:</TD>
						<TD class="TDBGColorValue">
							<asp:Label id="LBL_PENDING_LIMIT" runat="server" Width="320px">Label</asp:Label>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor1" style="WIDTH: 49%">Available Limit</TD>
						<TD style="WIDTH: 1%">:</TD>
						<TD class="TDBGColorValue">
							<asp:Label id="LBL_AVAILBALE_LIMIT" runat="server" Width="320px">Label</asp:Label>
						</TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" align="center" colspan="3"></TD>
					</TR>
				</table>
				<table cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder" align="left" width="100%">
							<uc1:DocumentExport id="DocumentExport1" runat="server"></uc1:DocumentExport>
						</TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" align="left"></TD>
					</TR>
				</table>
				<table cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdHeader1" colSpan="2">File Document</TD>
					</TR>
					<tr>
						<td style="HEIGHT: 28px" colSpan="2">
							<TABLE id="Table1" class="td" border="1" cellSpacing="1" cellPadding="1" width="100%" height="35">
								<TR>
									<TD class="tdHeader1" colSpan="7">Documents</TD>
								</TR>
								<tr>
									<TD align="center" width="48%">
										<ASP:DATAGRID id="DATA_EXPORT" runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="1"
											PageSize="1">
											<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
											<Columns>
												<asp:BoundColumn Visible="True" DataField="ID_UPLOAD_CHANNELING" HeaderText="No">
													<HeaderStyle CssClass="tdSmallHeader" Width="5%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="FILE_UPLOAD_CHANNELING_NAME" HeaderText="Destination File">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:TemplateColumn>
													<HeaderStyle CssClass="tdSmallHeader" Width="15%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
													<ItemTemplate>
														<asp:HyperLink id="UPL_CHANNELING_DOWNLOAD" runat="server" Target="_blank">Download</asp:HyperLink>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn>
													<HeaderStyle CssClass="tdSmallHeader" Width="15%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
													<ItemTemplate>
														<asp:LinkButton id="UPL_CHANNELING_DELETE" runat="server" CommandName="Delete">Delete</asp:LinkButton>
													</ItemTemplate>
												</asp:TemplateColumn>
											</Columns>
										</ASP:DATAGRID>
									</TD>
								</tr>
							</TABLE>
							<br>
							<table cellSpacing="0" cellPadding="0" width="50%">
								<TR>
									<TD class="TDBGColor1" width="75">File</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><INPUT style="WIDTH: 344px; HEIGHT: 19px" id="TXT_FILE_UPLOAD" size="38" type="file" name="File1"
											runat="Server"></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Status</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:label id="LBL_STATUS" runat="server" ForeColor="Red"></asp:label><asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" ControlToValidate="TXT_FILE_UPLOAD"
											ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.xls|.XLS|.doc|.DOC|.txt|.TXT|.zip|.ZIP)$" ErrorMessage="Only xls, doc, txt or zip files are allowed!"></asp:regularexpressionvalidator></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"></TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:label id="LBL_STATUSREPORT" runat="server" ForeColor="Red"></asp:label></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 21px" colSpan="3" align="center"><asp:button id="BTN_UPLOAD" runat="server" Text="Upload" onclick="BTN_UPLOAD_Click"></asp:button></TD>
								</TR>
								<TR>
									<TD colSpan="3" align="center"></TD>
								</TR>
							</table>
						</td>
					</tr>
					<TR>
						<TD class="tdNoBorder" align="left"></TD>
					</TR>
				</table>
				<table style="WIDTH: 100%; HEIGHT: 36px">
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" colSpan="2">
							<asp:button id="BTN_SAVE" runat="server" Width="187px" CssClass="BUTTON1" Text="Forward For Approval" onclick="BTN_SAVE_Click"></asp:button>
						</TD>
					</TR>
				</table>
			</center>
		</form>
	</body>
</HTML>
