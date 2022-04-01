<%@ Page language="c#" Codebehind="P2EMAnalysis.aspx.cs" AutoEventWireup="True" Inherits="SME.IPPS.Facilities.P2EMAnalysis.P2EMAnalysis" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>P2EMAnalysis</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY MS_POSITIONING="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<CENTER>
				<TABLE width="100%" border="0">
					<TR>
						<TD align="left" width="50%">
							<TABLE id="Table1">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 150px" align="center"><B>P2EM Analysis</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="/sme/Body.aspx"><IMG src="/sme/Image/MainMenu.jpg"></A>
							<A href="/sme/Logout.aspx" target="_top"><IMG src="/sme/Image/Logout.jpg"></A>
						</TD>
					</TR>
					<tr>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colspan="2">
							<asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</tr>
				</TABLE>
				<table width="100%">
					<TR>
						<TD class="tdHeader1">General Info</TD>
					</TR>
					<TR>
						<td>
							<table>
								<tr>
									<td>
										Select Existing P2 :
									</td>
									<td>
										<asp:dropdownlist id="ddl_exist_p2" runat="server"></asp:dropdownlist>
									</td>
									<td>
										<asp:button id="BTN_view_related_p2" runat="server" Text="View Related P2"></asp:button>
									</td>
								</tr>
							</table>
						</td>
					</TR>
					<TR>
						<td align="left">
							<asp:datagrid id="Datagrid1" runat="server" AllowPaging="True" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="SEQ" Visible="False">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="No">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="p2em"></asp:BoundColumn>
									<asp:TemplateColumn>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="link_download" runat="server" CommandName="download">Download</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</asp:datagrid></td>
					</TR>
				</table>
				<table width="100%">
					<TR>
						<TD class="tdHeader1">Synchronizations Analysis</TD>
					</TR>
					<tr>
						<td>
							<asp:datagrid id="dg_Synchronizations_Analysis" runat="server" Width="100%" AllowPaging="True"
								AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="SEQ" Visible="False">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="No" HeaderText="No.">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="policyname" HeaderText="Policy Name">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="SynType" HeaderText="Synchronizations Type">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Remark" HeaderText="Remark">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Function">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="link_edit" runat="server" CommandName="edit">Edit</asp:LinkButton>
											<asp:LinkButton id="link_delete" runat="server" CommandName="delete">Delete</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</asp:datagrid></td>
					</tr>
					<tr>
						<td>
							<table width="100%">
								<tr>
									<td width="50%">
										<TABLE id="Table4" cellSpacing="1" cellPadding="2" width="100%">
											<TR>
												<TD class="TDBGColor1">
													Policy Name</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue" style="HEIGHT: 20px">
													<asp:dropdownlist CssClass="mandatory" id="ddl_request" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Synchronizations Type</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue" style="HEIGHT: 20px">
													<asp:dropdownlist id="ddl_approval_method" CssClass="mandatory" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
											</TR>
										</TABLE>
									</td>
									<TD class="td" vAlign="top" width="50%">
										<TABLE id="Table65" cellSpacing="1" cellPadding="2" width="100%">
											<TR>
												<TD class="TDBGColor1">Remark</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue" rowspan="2"><asp:textbox id="txt_remark" runat="server" BorderStyle="None" ReadOnly="True" Width="300px"
														TextMode="MultiLine"></asp:textbox></TD>
											</TR>
											<tr>
												<td></td>
											</tr>
										</TABLE>
									</TD>
								</tr>
							</table>
						</td>
					</tr>
					<tr align="center">
						<td>
							<table>
								<TR>
									<td vAlign="top" align="right" width="50%"><asp:button id="BTN_Insert" runat="server" Width="65px" Text="Insert" CssClass="Button1"></asp:button></td>
									<td vAlign="top" align="left" width="50%"><asp:button id="BTN_clear" runat="server" Width="106px" Text="Clear" CssClass="Button1"></asp:button></td>
								</TR>
							</table>
						</td>
					</tr>
				</table>
				<table width="100%">
					<TR>
						<TD class="tdHeader1">Business Infrastructure Analysis</TD>
					</TR>
					<tr>
						<td>
							<asp:datagrid id="Datagrid2" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="SEQ">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="No" HeaderText="No.">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Aspect" HeaderText="Aspect">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Remark">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:radiobuttonlist id="rdo_req_remark" runat="server" RepeatDirection="Horizontal"></asp:radiobuttonlist>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</asp:datagrid></td>
					</tr>
					<tr align="center">
						<td>
							<table>
								<TR>
									<td vAlign="top" align="right" width="50%"><asp:button id="btn_save_busines" runat="server" Width="65px" Text="Save" CssClass="Button1"></asp:button></td>
									<td vAlign="top" align="left" width="50%"><asp:button id="btn_clear_busines" runat="server" Width="106px" Text="Clear" CssClass="Button1"></asp:button></td>
								</TR>
							</table>
						</td>
					</tr>
				</table>
				<table>
					<TR>
						<TD class="tdHeader1" vAlign="top" width="50%" colSpan="2">Document Export</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 540px" vAlign="top" width="540">
							<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 19px" width="75">Format</TD>
									<TD style="WIDTH: 15px; HEIGHT: 19px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 19px"><asp:dropdownlist id="DDL_FORMAT_TYPE" runat="server" Width="280px"></asp:dropdownlist><asp:button id="BTN_EXPORT" runat="server" Text="Export" Width="64px"></asp:button></TD>
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
									<TD><ASP:DATAGRID id="DATA_EXPORT" runat="server" Width="100%" CellPadding="1" PageSize="1" AutoGenerateColumns="False">
											<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
											<Columns>
												<asp:BoundColumn Visible="False" HeaderText="regnum"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="TEMPLATE_ID"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="FE_USERID"></asp:BoundColumn>
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
												<asp:BoundColumn Visible="False" DataField="SEQ"></asp:BoundColumn>
											</Columns>
										</ASP:DATAGRID></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<tr align="center">
						<td colspan="2" class="TDBGColor2">
							<table>
								<TR>
									<td vAlign="top" align="right" width="50%"><asp:button id="btn_analysis_finish" runat="server" Text="Analysis Finish" CssClass="Button1"></asp:button></td>
									<td vAlign="top" align="left" width="50%"><asp:button id="btn_update_status" runat="server" Text="Update Status" CssClass="Button1"></asp:button></td>
								</TR>
							</table>
						</td>
					</tr>
				</table>
			</CENTER>
		</FORM>
	</BODY>
</HTML>
