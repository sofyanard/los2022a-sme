<%@ Page language="c#" Codebehind="TargetCustomerAssign.aspx.cs" AutoEventWireup="True" Inherits="SME.TargetCustomer.TargetCustomerAssign" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>TargetCustomerAssign</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_entries.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table4" width="100%" border="0">
					<TR>
						<TD class="tdNoBorder" width="421"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
							<TABLE id="Table6">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Inquiry Target Customer</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD align="center" colSpan="2">
							<TABLE class="td" id="Table1" height="195" cellSpacing="1" cellPadding="1" width="590"
								border="1">
								<TR>
									<TD class="tdHeader1">Search Criteria</TD>
								</TR>
								<TR>
									<TD vAlign="top" align="center">
										<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD class="TDBGColor1">Target Customer Ref. No.</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_TRG_CU_REF" runat="server" Width="200px"
														MaxLength="20"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Name</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_NAME" runat="server" Width="300px" MaxLength="50"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Address</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_ADDR" runat="server" Width="300px" MaxLength="100"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">KTP/NPWP&nbsp;No.</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_IDNO" runat="server" Width="300px" MaxLength="30"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Process Date</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_TARGETDATE_START_DD" runat="server" MaxLength="2"
														Columns="2"></asp:textbox><asp:dropdownlist id="DDL_TARGETDATE_START_MM" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_TARGETDATE_START_YY" runat="server" MaxLength="4"
														Columns="4"></asp:textbox>&nbsp;s/d&nbsp;
													<asp:textbox onkeypress="return numbersonly()" id="TXT_TARGETDATE_END_DD" runat="server" MaxLength="2"
														Columns="2"></asp:textbox><asp:dropdownlist id="DDL_TARGETDATE_END_MM" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_TARGETDATE_END_YY" runat="server" MaxLength="4"
														Columns="4"></asp:textbox></TD>
											</TR>
											<TR>
												<TD vAlign="top" align="center" colSpan="3" height="5"></TD>
											</TR>
											<TR>
												<TD vAlign="top" align="center" colSpan="3" height="10"><asp:button id="BTN_FIND" runat="server" Width="100px" CssClass="button1" Text="Find" onclick="BTN_FIND_Click"></asp:button>&nbsp;
													<asp:button id="BTN_CLEAR" runat="server" Width="100px" CssClass="button1" Text="Clear" onclick="BTN_CLEAR_Click"></asp:button></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD align="center" colSpan="2">&nbsp;</TD>
					</TR>
					<TR id="TR_APP" runat="server">
						<TD colSpan="2"><ASP:DATAGRID id="DG_APP" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False"
								CellPadding="1">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="TRG_CU_REF" HeaderText="Target Cust Ref No">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CU_NAME" HeaderText="Name">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CU_ADDR" HeaderText="Address">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CU_IDNO" HeaderText="ID No.">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="120px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="TARGETDATE" HeaderText="Target Date">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="120px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="TARGETUNIT" HeaderText="Unit">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="120px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="TARGETUSER" HeaderText="RM">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="120px"></ItemStyle>
									</asp:BoundColumn>
									<asp:ButtonColumn Text="View" HeaderText="Function" CommandName="View">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
									</asp:ButtonColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
					<TR id="TR_TRACK" runat="server">
						<TD colSpan="3">
							<TABLE width="100%">
								<TR>
									<TD colSpan="5"><asp:label id="LBL_TRG_CU_REF" runat="server" Font-Bold="True"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Current Unit</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_TARGETUNIT" runat="server" Width="100%" ReadOnly="True"></asp:textbox></TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_TARGETUNIT" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_TARGETUNIT_SelectedIndexChanged"></asp:dropdownlist></TD>
									<TD><asp:button id="BTN_TARGETUNIT" runat="server" CssClass="Button1" Text="Assign" onclick="BTN_TARGETUNIT_Click"></asp:button></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Current RM/AM</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_TARGETUSER" runat="server" Width="100%" ReadOnly="True"></asp:textbox></TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_TARGETUSER" runat="server"></asp:dropdownlist></TD>
									<TD><asp:button id="BTN_TARGETUSER" runat="server" CssClass="Button1" Text="Assign" onclick="BTN_TARGETUSER_Click"></asp:button></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Current Track</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CURRTRACK" runat="server" Width="100%" ReadOnly="True"></asp:textbox></TD>
									<TD></TD>
									<TD></TD>
									<TD></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Current User</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CURRUSER" runat="server" Width="100%" ReadOnly="True"></asp:textbox></TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CURRUSER" runat="server"></asp:dropdownlist></TD>
									<TD><asp:button id="BTN_CURRUSER" runat="server" CssClass="Button1" Text="Assign" onclick="BTN_CURRUSER_Click"></asp:button></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
