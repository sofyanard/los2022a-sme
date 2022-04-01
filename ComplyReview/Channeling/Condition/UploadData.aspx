<%@ Page language="c#" Codebehind="UploadData.aspx.cs" AutoEventWireup="True" Inherits="SME.ComplyReview.Channeling.Condition.UploadData" %>
<%@ Register TagPrefix="uc1" TagName="DocumentExport" Src="../../../CommonForm/DocumentExport.ascx" %>
<%@ Register TagPrefix="uc1" TagName="DocumentUpload" Src="../../../CommonForm/DocumentUpload.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>ListInitiation</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../../../include/cek_all.html" -->
		<!-- aaa -->
  </HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="fSppkMonitor" method="post" runat="server">
			<center>
				<table id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder" style="WIDTH: 805px"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
							<TABLE id="Table6">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Batch Info</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListComplyCOndition.aspx?mc=CHAN006"><IMG src="/SME/Image/back.jpg"></A><A href="../../../Body.aspx"><IMG src="../../../Image/MainMenu.jpg"></A><A href="../../../Logout.aspx" target="_top"><IMG src="../../../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
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
									<TD align="center" width="48%"><ASP:DATAGRID id="DATA_TEMPLATE" runat="server" PageSize="1" CellPadding="1" AutoGenerateColumns="False"
											Width="100%">
											<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
											<Columns>
												<asp:BoundColumn Visible="False" DataField="ID_TEMPLATE_CHANNELING">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="NAMA_TEMPLATE_CHANNELING" HeaderText="Source File" ItemStyle-HorizontalAlign="Center">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												</asp:BoundColumn>
												<asp:TemplateColumn>
													<HeaderStyle Width="35%" CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
													<ItemTemplate>
														<asp:HyperLink id="HL_DOWNLOAD" runat="server" Target="_blank">Download</asp:HyperLink>
													</ItemTemplate>
												</asp:TemplateColumn>
											</Columns>
										</ASP:DATAGRID></TD>
									<TD align="center" width="48%"><ASP:DATAGRID id="DATA_EXPORT" runat="server" PageSize="1" CellPadding="1" AutoGenerateColumns="False"
											Width="100%">
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
														<asp:LinkButton id="UPL_CHANNELING_DELETE" runat="server" CommandName="delete">Delete</asp:LinkButton>
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
									<TD style="HEIGHT: 21px" align="center" colSpan="3"><asp:button id="BTN_UPLOAD" runat="server" Text="Upload" onclick="BTN_UPLOAD_Click"></asp:button></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="3"></TD>
								</TR>
							</table>
						</td>
					</tr>
					<TR>
						<TD class="tdHeader1" colSpan="2">Data Uploaded</TD>
					</TR>
					<tr>
						<td style="WIDTH: 50%" colSpan="2"><asp:datagrid id="dgListChan" runat="server" PageSize="10" AutoGenerateColumns="False" Width="100%"
								AllowPaging="True" Height="30%" ShowFooter="True">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="CUST_NAME" HeaderText="End User Name">
										<HeaderStyle Width="15%" CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AP_REGNO" HeaderText="Application Number">
										<HeaderStyle Width="15%" CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CP_LIMIT" HeaderText="Limit">
										<HeaderStyle Width="20%" CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Kol.BI Checking">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle Width="15%"></ItemStyle>
										<ItemTemplate>
											<asp:DropDownList Width="100%" Runat="server" ID="DDL_KOLEKTIBILITAS" CssClass="mandatory"></asp:DropDownList>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Black List BI">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:RadioButton id="rdo_yes" runat="server" GroupName="rdg_Decision" Text="Yes"></asp:RadioButton>
											<asp:RadioButton id="rdo_no" runat="server" GroupName="rdg_Decision" Text="No" Checked="True"></asp:RadioButton>
										</ItemTemplate>
										<FooterStyle HorizontalAlign="Center"></FooterStyle>
										<FooterTemplate>
											<asp:LinkButton id="Linkbutton4" runat="server" CommandName="yesall">Yes All</asp:LinkButton>
											<asp:LinkButton id="Linkbutton3" runat="server" CommandName="noall">No All</asp:LinkButton>
										</FooterTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn>
										<HeaderStyle Width="25%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="LinkButton1" runat="server" CommandName="Edit">Edit</asp:LinkButton>
											<asp:LinkButton id="Linkbutton2" runat="server" CommandName="Delete" Visible="False">Delete</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn Visible="False" DataField="CU_REF" HeaderText="Limit">
										<HeaderStyle Width="20%" CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</asp:datagrid>
						</td>
					</tr>
					<TR id="tobehidden" runat="server">
						<TD class="td" vAlign="top" width="50%" colSpan="2">
							<TABLE id="Table8" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD style="WIDTH: 129px">Request BI Checking
									</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue" style="WIDTH: 117px" width="117"><asp:radiobuttonlist id="RDO_BI_CHECKING" runat="server" Width="150px" AutoPostBack="True" RepeatDirection="Horizontal">
											<asp:ListItem Value="1" Selected="True">Ya</asp:ListItem>
											<asp:ListItem Value="0">Tidak</asp:ListItem>
										</asp:radiobuttonlist></TD>
									<TD class="TDBGColorValue" style="WIDTH: 304px">
										<TABLE id="Table9" cellSpacing="1" cellPadding="1" width="100%" border="0">
											<TR>
												<TD style="WIDTH: 138px"><asp:label id="LBL_CO" runat="server">Group Pelaksana :</asp:label></TD>
												<TD><asp:dropdownlist id="DDL_GRPUNIT" runat="server"></asp:dropdownlist></TD>
											</TR>
										</TABLE>
									</TD>
									<TD class="TDBGColorValue">Tanggal Terakhir Checking:
										<asp:textbox id="TXT_BS_RECVDATE" runat="server" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" colSpan="2"><asp:button id="BTN_SAVE" runat="server" Width="100px" Text="Save" CssClass="Button1" onclick="BTN_SAVE_Click"></asp:button></TD>
					</TR>
				</table>
			</center>
		</form>
	</body>
</HTML>
