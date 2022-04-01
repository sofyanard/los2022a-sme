<%@ Page language="c#" Codebehind="InquiryRequestData.aspx.cs" AutoEventWireup="True" Inherits="SME.DCM.DataDictionary.Facilities.InquiryRequestData.InquiryRequestData" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>InquiryRequestData</TITLE>
		<META name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<META name="CODE_LANGUAGE" Content="C#">
		<META name="vs_defaultClientScript" content="JavaScript">
		<META name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../../../Style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY MS_POSITIONING="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<CENTER>
				<TABLE width="100%" border="0">
					<TR>
						<TD align="left" width="50%">
							<TABLE id="Table1">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>INQUIRY REQUEST DATA</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="../../../../Body.aspx"><IMG height="25" src="../../../../Image/MainMenu.jpg" width="106"></A>
							<A href="../../../../Logout.aspx" target="_top"><IMG src="../../../../Image/Logout.jpg"></A>
						</TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" colSpan="2"></TD>
					</TR>
				</TABLE>
				<TABLE class="td" width="40%" align="center" cellSpacing="1" cellPadding="1" border="1">
					<TR>
						<TD class="tdHeader1" colSpan="6">INQUIRY REQUEST DATA</TD>
					</TR>
					<TR>
						<TD class="TDBGColor1" width="30%">Request Date :</TD>
						<TD class="TDBGColorValue" colSpan="2">
							<asp:textbox onkeypress="return numbersonly()" id="TXT_REQ_DAY1" runat="server" Width="24px"
								Columns="4" MaxLength="2"></asp:textbox>
							<asp:dropdownlist id="DDL_REQ_MONTH1" runat="server"></asp:dropdownlist>
							<asp:textbox onkeypress="return numbersonly()" id="TXT_REQ_YEAR1" runat="server" Width="36px"
								Columns="4" MaxLength="4"></asp:textbox>
							to
							<asp:textbox onkeypress="return numbersonly()" id="TXT_REQ_DAY2" runat="server" Width="24px"
								Columns="4" MaxLength="2"></asp:textbox>
							<asp:dropdownlist id="DDL_REQ_MONTH2" runat="server"></asp:dropdownlist>
							<asp:textbox onkeypress="return numbersonly()" id="TXT_REQ_YEAR2" runat="server" Width="36px"
								Columns="4" MaxLength="4"></asp:textbox>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor1" width="30%">Request Result :</TD>
						<TD class="TDBGColorValue" colSpan="2">
							<asp:textbox onkeypress="return numbersonly()" id="TXT_RESULT_DAY1" runat="server" Width="24px"
								Columns="4" MaxLength="2"></asp:textbox>
							<asp:dropdownlist id="DDL_RESULT_MONTH1" runat="server"></asp:dropdownlist>
							<asp:textbox onkeypress="return numbersonly()" id="TXT_RESULT_YEAR1" runat="server" Width="36px"
								Columns="4" MaxLength="4"></asp:textbox>
							to
							<asp:textbox onkeypress="return numbersonly()" id="TXT_RESULT_DAY2" runat="server" Width="24px"
								Columns="4" MaxLength="2"></asp:textbox>
							<asp:dropdownlist id="DDL_RESULT_MONTH2" runat="server"></asp:dropdownlist>
							<asp:textbox onkeypress="return numbersonly()" id="TXT_RESULT_YEAR2" runat="server" Width="36px"
								Columns="4" MaxLength="4"></asp:textbox>
						</TD>
					</TR>
					<TR>
						<TD colSpan="3"></TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" colSpan="3" height="5">
							<asp:button id="BTN_FIND" runat="server" Width="80px" CssClass="button1" Text="Search" onclick="BTN_FIND_Click"></asp:button></TD>
					</TR>
				</TABLE>
				<TABLE width="100%" border="0">
					<TR>
						<TD colSpan="2"></TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" align="center" width="50%" colSpan="2"><asp:datagrid id="DATA_GRID" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="True">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="SEQ" Visible="False">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="REQ_NUMBER" HeaderText="Request#">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="REQ_DATE" HeaderText="Request Date">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="REQ_UNIT" HeaderText="Requester Unit">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="REQ_BY" HeaderText="Request Prepare by">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="REQ_RESULT" HeaderText="Request Result">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Function">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="LNK_VIEW" runat="server" CommandName="view">View Detail</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</asp:datagrid></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2"><asp:label id="LBL_EXPORT" runat="server">REQUEST DATA DOCUMENT EXPORT</asp:label></TD>
					</TR>
					<TR>
						<TD vAlign="top" width="50%">
							<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="30%"><asp:label id="LBL_TEMPLATE" runat="server">Format :</asp:label></TD>
									<TD class="TDBGColorValue" width="50%"><asp:dropdownlist id="DDL_FORMAT_TYPE" runat="server" Width="100%"></asp:dropdownlist></TD>
									<TD class="TDBGColorValue" width="20%"><asp:button id="BTN_EXPORT" runat="server" Width="100%" Text="Export" onclick="BTN_EXPORT_Click"></asp:button></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="30%"><asp:label id="LBL_STATUS" runat="server">Status :</asp:label></TD>
									<TD class="TDBGColorValue" width="70%" colSpan="2"><asp:label id="LBL_STATUS_EXPORT" runat="server" ForeColor="Red"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="30%"></TD>
									<TD class="TDBGColorValue" width="70%" colSpan="2"><asp:label id="LBL_STATUSEXPORT" runat="server" ForeColor="Red"></asp:label></TD>
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
												<asp:BoundColumn Visible="False" DataField="AP_REGNO"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="TEMPLATE_ID"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="FE_USERID"></asp:BoundColumn>
												<asp:BoundColumn DataField="FE_FILENAME" HeaderText="DESTINATION FILE">
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
						<TD style="COLOR: dodgerblue">Note : disarankan untuk mempercepat proses tidak 
							meng-klik tulisan download, tapi di klik kanan saja dari tulisan download 
							tersebut, kemudian pilih "save" target as"...simpan di lokal komputer
						</TD>
					</TR>
				</TABLE>
			</CENTER>
		</FORM>
	</BODY>
</HTML>
