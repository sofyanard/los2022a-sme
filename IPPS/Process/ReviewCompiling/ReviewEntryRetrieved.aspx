<%@ Page language="c#" Codebehind="ReviewEntryRetrieved.aspx.cs" AutoEventWireup="True" Inherits="SME.IPPS.Process.ReviewCompiling.ReviewEntryRetrieved" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ReviewEntry</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../Style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table id="Table1" cellSpacing="2" cellPadding="2" width="100%">
				<tbody>
					<TR>
						<TD class="tdNoBorder" style="WIDTH: 626px">
							<TABLE id="Table8">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Review Entry</B></TD>
								</TR>
							</TABLE>
						</TD>
						<td align="right"><A href="/SME/Body.aspx"><IMG src="/SME/Image/MainMenu.jpg"></A><A href="/SME/Logout.aspx" target="_top"><IMG src="/SME/Image/Logout.jpg"></A></td>
					</TR>
					<tr>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</tr>
					<TR>
						<TD class="tdHeader1" colSpan="2">DRAFTING INFO</TD>
					</TR>
					<tr>
						<td colSpan="2"><ASP:DATAGRID id="DGR_DRAFTINFO" runat="server" Width="70%" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="req_seq" Visible="False" />
									<asp:BoundColumn DataField="request_type" Visible="False" />
									<asp:BoundColumn DataField="policy_type" Visible="False" />
									<asp:TemplateColumn HeaderText="Request">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
										<ItemTemplate>
											<asp:Label id="lbl" runat="server" />
										</ItemTemplate>
										<ItemTemplate>
											<asp:LinkButton id="link" runat="server" CommandName="view"></asp:LinkButton>&nbsp;
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="FILENAME" HeaderText="File Name">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Function">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="LNK_DOWNLOAD" runat="server" CommandName="download">Download</asp:LinkButton>&nbsp;
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</ASP:DATAGRID></td>
					</tr>
					<TR>
						<TD class="tdHeader1" colSpan="2">FORMAT</TD>
					</TR>
					<TR>
						<TD class="td" style="WIDTH: 627px" vAlign="top" width="627"><TABLE id="Table9" cellSpacing="1" cellPadding="2" width="100%">
								<TR>
									<TD class="TDBGColor1" width="180">Name:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NAME" runat="server" Width="300px" BorderStyle="None" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Edisi:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_EDISI" runat="server" Width="300px" BorderStyle="None" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Revisi:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_REVISI" runat="server" Width="300px" BorderStyle="None" ReadOnly="True"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table65" cellSpacing="1" cellPadding="2" width="100%">
								<TR>
									<TD class="TDBGColor1" width="180">Berlaku Sejak Tanggal:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_TGL_BERLAKU" runat="server" Width="300px" BorderStyle="None" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tanggal yang digantikan:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_TGL_DIGANTI" runat="server" Width="300px" BorderStyle="None" ReadOnly="True"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<tr>
						<TD class="tdHeader1" colSpan="2">OUTLINE</TD>
					</tr>
					<!--OUTLINE UNTUK NEW-->
					<tr id="TR_OUTLINE_NEW" runat="server">
						<TD class="TDBGColorValue" colSpan="2"><asp:textbox id="TXT_OUTLINENEW" runat="server" Width="100%" ReadOnly="True" Enabled="False"
								TextMode="MultiLine" Height="128px"></asp:textbox></TD>
					</tr>
					<!--OUTLINE UNTUK UPDATE-->
					<tr id="TR_OUTLINE_UPDATE" runat="server">
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="TableEXISTING" cellSpacing="1" cellPadding="2" width="100%">
								<tr>
									<TD class="tdHeader1">Existing Outline</TD>
								</tr>
								<tr>
									<TD class="TDBGColorValue" colSpan="2"><asp:textbox id="TXT_EXISTING" runat="server" Width="100%" ReadOnly="True" Enabled="False" TextMode="MultiLine"
											Height="128px"></asp:textbox></TD>
								</tr>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="TableREVISE" cellSpacing="1" cellPadding="2" width="100%">
								<tr>
									<TD class="tdHeader1">Revise Outline Outline</TD>
								</tr>
								<tr>
									<TD class="TDBGColorValue" colSpan="2"><asp:textbox id="TXT_REVISE" runat="server" Width="100%" ReadOnly="True" Enabled="False" TextMode="MultiLine"
											Height="128px"></asp:textbox></TD>
								</tr>
							</TABLE>
						</TD>
					</tr>
					<tr>
						<TD class="tdHeader1" colSpan="2">CONTAIN
							<asp:label id="lbl_reqseq" runat="server"></asp:label></TD>
					</tr>
					<tr id="TR_COINTAIN_NEW" runat="server">
						<td colSpan="2"><ASP:DATAGRID id="DGR_COINTAINNEW" runat="server" Width="100%" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="cnt_seq" Visible="False" />
									<asp:BoundColumn DataField="chapter" HeaderText="Bab">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="new_contain" HeaderText="Draft">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left" Width="40%"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="REV_CONTAIN" HeaderText="Review">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left" Width="40%"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
							</ASP:DATAGRID></td>
					</tr>
					<tr id="TR_CONTAIN_UPDATE" runat="server">
						<td colSpan="2"><ASP:DATAGRID id="DGR_CONTAINUPD" runat="server" Width="100%" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="cnt_seq" Visible="False" />
									<asp:BoundColumn DataField="chapter" HeaderText="Bab">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="old_contain" HeaderText="Existing to Revise">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="new_contain" HeaderText="Draft Revise">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="REV_CONTAIN" HeaderText="Review">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left" Width="40%"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
							</ASP:DATAGRID></td>
					</tr>
					<TR>
						<TD class="tdHeader1" colSpan="2"><asp:label id="LBL_EXPORT" runat="server">Document Export</asp:label></TD>
					</TR>
					<TR>
						<TD vAlign="top" width="50%">
							<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="30%"><asp:label id="LBL_FORMAT" runat="server">Format File :</asp:label></TD>
									<TD class="TDBGColorValue" width="50%"><asp:dropdownlist id="DDL_FORMAT" runat="server" Width="100%"></asp:dropdownlist></TD>
									<TD class="TDBGColorValue" width="20%"><asp:button id="BTN_EXPORT" runat="server" Width="100%" Text="Export"></asp:button></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="30%"><asp:label id="LBL_REQTYPE" runat="server">Request Type :</asp:label></TD>
									<TD class="TDBGColorValue" width="50%"><asp:dropdownlist id="DDL_REQTYPE" runat="server" Width="100%"></asp:dropdownlist></TD>
									<TD class="TDBGColorValue" width="20%"></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="30%">Status :</TD>
									<TD class="TDBGColorValue" width="50%"><asp:label id="Label4" runat="server" ForeColor="Red"></asp:label><asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" ErrorMessage="Hanya file xls yang diperbolehkan!"
											ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.xls|.XLS)$" ControlToValidate="TXT_FILE_UPLOAD"></asp:regularexpressionvalidator></TD>
								</TR>
								<TR>
									<TD></TD>
									<TD class="TDBGColorValue" width="50%"><asp:label id="LBL_STATUSREPORT" runat="server" ForeColor="Red"></asp:label></TD>
								</TR>
								<TR>
									<TD></TD>
									<TD style="HEIGHT: 21px" align="center" colSpan="2"><asp:button id="BTN_UPLOAD" runat="server" Width="80px" Enabled="False" Text="Upload" Font-Bold="True"></asp:button></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="3"></TD>
								</TR>
							</TABLE>
						</TD>
						<TD style="HEIGHT: 42px" vAlign="top" width="50%">
							<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD><ASP:DATAGRID id="DATA_EXPORT" runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="1"
											PageSize="1">
											<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
											<Columns>
												<asp:BoundColumn Visible="False" DataField="AP_REGNO"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="TEMPLATE_ID"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="FE_USERID"></asp:BoundColumn>
												<asp:BoundColumn DataField="FE_FILENAME" HeaderText="FILE NAME">
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
				</tbody>
			</table>
		</form>
	</body>
</HTML>
