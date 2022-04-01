<%@ Page language="c#" Codebehind="ListVerificator.aspx.cs" AutoEventWireup="True" Inherits="SME.Verificator.ListVer" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Verification List</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_all.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table4" width="100%" border="0">
					<TR>
						<TD class="tdNoBorder">
							<TABLE id="Table6">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>RAC &amp; Scoring 
											Verificator List</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD align="center" colSpan="2">
							<TABLE class="td" id="Table1" style="WIDTH: 590px; HEIGHT: 200px" cellSpacing="1" cellPadding="1"
								width="590" border="1">
								<TR>
									<TD class="tdHeader1">Search Criteria</TD>
								</TR>
								<TR>
									<TD vAlign="top">
										<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD class="TDBGColor1" width="160">Nama Pemohon</TD>
												<TD width="17"></TD>
												<TD class="TDBGColorValue" style="WIDTH: 342px" width="342"><asp:textbox onkeypress="return kutip_satu()" id="txt_Name" runat="server"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Application No.</TD>
												<TD></TD>
												<TD class="TDBGColorValue" style="WIDTH: 342px"><asp:textbox onkeypress="return kutip_satu()" id="txt_ProsID" runat="server"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">KTP&nbsp;No. / TDP No.</TD>
												<TD></TD>
												<TD class="TDBGColorValue" style="WIDTH: 342px"><asp:textbox onkeypress="return kutip_satu()" id="txt_IdCard" runat="server"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">NPWP</TD>
												<TD></TD>
												<TD style="WIDTH: 342px"><asp:textbox onkeypress="return kutip_satu()" id="txt_NPWP" runat="server"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 18px">Dari Tanggal s/d Tanggal</TD>
												<TD style="HEIGHT: 18px"></TD>
												<TD style="WIDTH: 400px; HEIGHT: 18px">
													<P class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly();" id="txt_Date" runat="server" MaxLength="2" Columns="3"></asp:textbox><asp:dropdownlist id="ddl_Month" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly();" id="txt_Year" runat="server" MaxLength="4" Columns="3"></asp:textbox>&nbsp;s/d
														<asp:textbox onkeypress="return numbersonly();" id="txt_Date1" runat="server" MaxLength="2" Columns="3"></asp:textbox><asp:dropdownlist id="ddl_Month1" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly();" id="txt_Year1" runat="server" MaxLength="4" Columns="3"></asp:textbox></P>
												</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" vAlign="middle">Condition</TD>
												<TD vAlign="middle"></TD>
												<TD class="TDBGColorValue" style="WIDTH: 342px" vAlign="top"><asp:radiobuttonlist id="RDB_COND" runat="server" Height="24px" CellSpacing="0" RepeatDirection="Horizontal"
														CellPadding="0" Width="208px">
														<asp:ListItem Value="And">And</asp:ListItem>
														<asp:ListItem Value="Or" Selected="True">Or</asp:ListItem>
													</asp:radiobuttonlist></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 521px" vAlign="top" align="center" colSpan="3"><asp:button id="btn_Find" CssClass="button1" runat="server" Text="Find" onclick="btn_Find_Click"></asp:button></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD colSpan="2"><asp:label id="LBL_COUNT_APP" runat="server" Font-Bold="True"></asp:label>
							<asp:label id="LBL_SORT" runat="server" Visible="False"> ORDER BY REQUESTDATE</asp:label></TD>
					</TR>
					<TR>
						<TD colSpan="2"><ASP:DATAGRID id="DatGrd" runat="server" CellPadding="1" Width="100%" AutoGenerateColumns="False"
								AllowSorting="True" AllowPaging="True" PageSize="10">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="AP_REGNO" SortExpression="AP_REGNO" HeaderText="Application No.">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="120px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CU_NAME" SortExpression="CU_NAME" HeaderText="Nama Pemohon">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="BRANCH_NAME" SortExpression="BRANCH_NAME" HeaderText="Source Aplikasi">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="REQUESTDATE" SortExpression="REQUESTDATE" HeaderText="Tanggal Request"
										DataFormatString="{0:dd-MMM-yyyy hh:mm}">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="VERCOUNTER" SortExpression="VERCOUNTER" HeaderText="Verificator Count">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AP_RELMNGR" HeaderText="Nama RM">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="CU_REF"></asp:BoundColumn>
									<asp:ButtonColumn Text="View" HeaderText="Function" CommandName="View">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
									</asp:ButtonColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
					<tr>
					</tr>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
