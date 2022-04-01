<%@ Page language="c#" Codebehind="ApprovalMainPage.aspx.cs" AutoEventWireup="True" Inherits="SME.Approval.Channeling.ApprovalMainPage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Verification Assignment</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../../include/cek_all.html" -->
		<!-- #include file="../../include/popup.html" -->
		<script language="javascript">
		function continueApproval(action)
		{			
			/*pesan = "Penentuan kategori pemutus kredit agar memperhatikan limit kredit one obligor, security coverage agunan,";
			pesan = pesan + "\n jenis permohonan kredit (baru, perpanjangan, tambahan), dan hasil rating/scoring.";*/
			pesan = "Are you sure you want to " + action + " ? ";
			
			//pesan = "Are you sure you want to " + action + " ? ";			
			conf = confirm(pesan);
			if (conf)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		</script>
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
										<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Batch Info</B></TD>
									</TR>
								</TABLE>
							</TD>
							<TD class="tdNoBorder" align="right"><A href="ListApproval.aspx?mc=CHAN003"><IMG src="/SME/Image/back.jpg"></A><A href="../../Body.aspx"><IMG src="/SME/Image/MainMenu.jpg"></A><A href="../../Logout.aspx" target="_top"><IMG src="/SME/Image/Logout.jpg"></A></TD>
						</TR>
						<TR>
							<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
						</TR>
						<TR>
							<TD class="tdHeader1" colSpan="2">General Info</TD>
						</TR>
						<TR>
							<TD class="td" vAlign="top" width="50%">
								<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 886px; HEIGHT: 8px">Business Unit
										</TD>
										<TD style="WIDTH: 1px; HEIGHT: 8px">:</TD>
										<TD class="TDBGColorValue" style="HEIGHT: 8px"><asp:dropdownlist id="DDL_AP_BOOKINGBRANCH" runat="server" Width="300px" CssClass="mandatory" Enabled="False"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 886px">CO Unit
										</TD>
										<TD style="WIDTH: 1px">:</TD>
										<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_AP_CCOBRANCH" runat="server" Width="300px" Enabled="False"></asp:dropdownlist></TD>
									</TR>
								</TABLE>
							</TD>
							<TD class="td" vAlign="top" width="50%">
								<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 182px" width="182">Application Date
										</TD>
										<TD style="WIDTH: 6px">:</TD>
										<TD class="TDBGColorValue"><asp:textbox id="txt_DD_B" runat="server" Width="40px" CssClass="mandatory" Enabled="False"></asp:textbox><asp:dropdownlist id="ddl_MM_B" runat="server" Width="176px" CssClass="mandatory" Enabled="False"></asp:dropdownlist><asp:textbox id="txt_YY_B" runat="server" Width="72px" CssClass="mandatory" Enabled="False"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 182px">Application Number
										</TD>
										<TD style="WIDTH: 6px">:</TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_APPLICATION" runat="server" Width="288px" CssClass="mandatory" Enabled="False"></asp:textbox></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD class="tdNoBorder" align="center" colSpan="2"></TD>
						</TR>
					</TBODY>
				</TABLE>
				<table cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdHeader1" colSpan="3">Plafond Info</TD>
					</TR>
					<TR>
						<TD class="TDBGColor1" style="WIDTH: 49%" width="484">Plafond Owner</TD>
						<TD style="WIDTH: 1%">:</TD>
						<TD class="TDBGColorValue"><asp:label id="LBL_PLAFOND_OWNER" runat="server" Width="320px">Label</asp:label></TD>
					</TR>
					<TR>
						<TD class="TDBGColor1" style="WIDTH: 49%">Remaining eMas Limit</TD>
						<TD style="WIDTH: 1%">:</TD>
						<TD class="TDBGColorValue"><asp:label id="LBL_REMAINING_EMAS" runat="server" Width="320px">Label</asp:label></TD>
					</TR>
					<TR>
						<TD class="TDBGColor1" style="WIDTH: 49%">Pending Limit</TD>
						<TD style="WIDTH: 1%">:</TD>
						<TD class="TDBGColorValue"><asp:label id="LBL_PENDING_LIMIT" runat="server" Width="320px">Label</asp:label></TD>
					</TR>
					<TR>
						<TD class="TDBGColor1" style="WIDTH: 49%">Available Limit</TD>
						<TD style="WIDTH: 1%">:</TD>
						<TD class="TDBGColorValue"><asp:label id="LBL_AVAILBALE_LIMIT" runat="server" Width="320px">Label</asp:label></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" align="center" colSpan="3"></TD>
					</TR>
				</table>
				<table cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdHeader1" colSpan="3">Remark</TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" align="center" width="100%"><asp:textbox id="REMARK_APPROVAL" runat="server" Width="100%" TextMode="MultiLine" Height="128px"></asp:textbox></TD>
					</TR>
				</table>
				<table cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD vAlign="top" width="50%" colSpan="2">
							<TABLE class="td" id="Table8" cellSpacing="1" cellPadding="1" width="100%" border="0">
								<TR>
									<TD class="tdHeader1">User Approval</TD>
								</TR>
								<TR>
									<TD>
										<TABLE id="Table9" cellSpacing="1" cellPadding="1" width="50%" border="0">
											<TR>
												<TD style="WIDTH: 208px"><asp:radiobutton id="rb_manual" Text="Manual" GroupName="fwdtype" Runat="server" Checked="True"></asp:radiobutton></TD>
												<TD><asp:dropdownlist id="ddl_manual" Runat="server" onselectedindexchanged="ddl_manual_SelectedIndexChanged"></asp:dropdownlist></TD>
											</TR>
											<TR id="tobehidden" runat="server">
												<TD style="WIDTH: 208px"><asp:checkbox id="chk_more2person" runat="server" Width="184px" Text="Submit To BOD Approval"
														AutoPostBack="True"></asp:checkbox></TD>
												<TD><asp:dropdownlist id="ddl_nextendorse" Enabled="False" Runat="server"></asp:dropdownlist></TD>
											</TR>
										</TABLE>
										<asp:label id="Label1" runat="server" Visible="False">Next Endorse/Approval</asp:label><asp:radiobutton id="rb_auto" Text="Automatic" GroupName="fwdtype" Runat="server" Visible="False"></asp:radiobutton><asp:textbox id="TXT_ERRMSG" runat="server" Visible="False">Exception occured.\\nPlease contact system administrator for further informations.</asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</table>
				<table cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdHeader1" colSpan="2">File Document</TD>
					</TR>
					<tr>
						<td style="HEIGHT: 28px" colSpan="2">
							<TABLE class="td" id="Table1" height="35" cellSpacing="1" cellPadding="1" width="100%"
								border="1">
								<TR>
									<TD class="tdHeader1" colSpan="7">Documents</TD>
								</TR>
								<tr>
									<TD align="center" width="48%"><ASP:DATAGRID id="DATA_EXPORT" runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="1"
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
										</ASP:DATAGRID></TD>
								</tr>
							</TABLE>
							<br>
							<table cellSpacing="0" cellPadding="0" width="50%">
								<TR>
									<TD class="TDBGColor1" width="75">File</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><INPUT id="TXT_FILE_UPLOAD" style="WIDTH: 344px; HEIGHT: 19px" type="file" size="38" name="File1"
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
									<TD style="HEIGHT: 21px" align="center" colSpan="3"><asp:button id="BTN_UPLOAD" runat="server" Text="Upload" onclick="BTN_UPLOAD_Click"></asp:button></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="3"></TD>
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
						<TD class="TDBGColor2" vAlign="top" align="center" colSpan="2"><asp:button id="BTN_SAVE" runat="server" Width="126px" CssClass="BUTTON1" Text="Save" onclick="BTN_SAVE_Click"></asp:button><asp:button id="AcquireInfo" runat="server" Width="187px" CssClass="BUTTON1" Text="Acquire Information" onclick="AcquireInfo_Click"></asp:button><asp:button id="Approval" runat="server" Width="147px" CssClass="BUTTON1" Text="Approval" Visible="False" onclick="Approval_Click"></asp:button><asp:button id="BTN_FORWARD_APPROVAL" runat="server" Width="192px" CssClass="BUTTON1" Text="Forward to Approval" onclick="BTN_FORWARD_APPROVAL_Click"></asp:button></TD>
					</TR>
				</table>
			</center>
		</form>
	</body>
</HTML>
