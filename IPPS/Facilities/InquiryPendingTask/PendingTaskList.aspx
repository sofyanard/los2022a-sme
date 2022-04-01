<%@ Page language="c#" Codebehind="PendingTaskList.aspx.cs" AutoEventWireup="True" Inherits="SME.IPPS.Facilities.InquiryPendingTask.PendingTaskList" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PendingTaskList</title>
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
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Pending Task List</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="/sme/Body.aspx"><IMG src="/sme/Image/MainMenu.jpg"></A>
							<A href="/sme/Logout.aspx" target="_top"><IMG src="/sme/Image/Logout.jpg"></A>
						</TD>
					</TR>
				</TABLE>
				<TABLE width="100%" align="center" border="0">
					<TR>
						<TD align="center" colSpan="2">
							<TABLE class="td" id="Table2" cellSpacing="1" cellPadding="1" width="50%" border="0">
								<TR>
									<TD class="tdHeader1">SEARCH CRITERIA</TD>
								</TR>
								<TR>
									<TD vAlign="top" align="center">
										<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TBODY>
												<TR>
													<TD class="TDBGColor1" style="HEIGHT: 10px" width="40%"><asp:label id="LBL_TXT_Reference" runat="server">Periode :</asp:label></TD>
													<TD class="TDBGColorValue" style="HEIGHT: 10px" width="60%">
														<asp:textbox onkeypress="return numbersonly()" id="TXT_from_DAY" runat="server" Width="24px"
															Columns="4" MaxLength="2"></asp:textbox>
														<asp:dropdownlist id="DDL_from_MONTH" runat="server"></asp:dropdownlist>
														<asp:textbox onkeypress="return numbersonly()" id="TXT_from_YEAR" runat="server" Width="36px"
															Columns="4" MaxLength="4"></asp:textbox>
														to
														<asp:textbox onkeypress="return numbersonly()" id="TXT_to_DAY" runat="server" Width="24px" Columns="4"
															MaxLength="2"></asp:textbox><asp:dropdownlist id="DDL_to_MONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_to_YEAR" runat="server" Width="36px" Columns="4"
															MaxLength="4"></asp:textbox>
													</TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="HEIGHT: 7px" width="40%"><asp:label id="LBL_TXT_Requester_Unit" runat="server">Requester Unit :</asp:label></TD>
													<TD class="TDBGColorValue" style="HEIGHT: 7px" width="60%">
														<asp:dropdownlist id="ddl_req_unit" runat="server"></asp:dropdownlist></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="HEIGHT: 3px" width="40%"><asp:label id="LBL_TXT_track_process" runat="server">Track Process :</asp:label></TD>
													<TD class="TDBGColorValue" style="HEIGHT: 3px" width="60%">
														<asp:dropdownlist id="ddl_track_process" runat="server"></asp:dropdownlist></TD>
												</TR>
												<TR>
													<TD class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2"><asp:button id="BTN_FIND" runat="server" Text="Find" CssClass="button1"></asp:button>&nbsp;&nbsp;
														<asp:button id="BTN_clear" runat="server" Text="Clear" CssClass="button1"></asp:button>&nbsp;&nbsp;</TD>
												</TR>
											</TBODY>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" align="center" width="50%" colSpan="2">
						<asp:datagrid id="DG_pending_task_list" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="SEQ" Visible="False">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Reference" HeaderText="Reference#">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Request_date" HeaderText="Request Date">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Requester_unit" HeaderText="Requester Unit">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Track_Process" HeaderText="Track Process">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Track_Date" HeaderText="Track Date">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Track_User" HeaderText="Track User">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Pending_Days" HeaderText="Pending Days">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</asp:datagrid></TD>
					</TR>


				</TABLE>
			</CENTER>
		</FORM>
	</BODY>
</HTML>
