<%@ Page language="c#" Codebehind="SearchCustomerHistoryTransaction.aspx.cs" AutoEventWireup="True" Inherits="SME.ITTP.SearchCustomerHistoryTransaction" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SearchCustomerHistoryTransaction</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../Style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_entries.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table4" width="100%" border="0">
					<TR>
						<TD align="left" colSpan="1">
							<TABLE id="Table3">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Customer List</B></TD>
								</TR>
							</TABLE>
						</TD>
						<td align="right"><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></td>
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
												<TD class="TDBGColor1" width="170">CIF No.</TD>
												<TD width="5"></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_CIF" runat="server" Width="200px" MaxLength="20"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Nama Pemohon</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="txt_Name" runat="server" Width="200px" MaxLength="50"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">KTP&nbsp;No.</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="txt_IdCard" runat="server" Width="200px" MaxLength="30"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Tanggal Lahir</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="Textbox2" runat="server" MaxLength="2" Columns="2"></asp:textbox><asp:dropdownlist id="DDL_CU_DOB_MM" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="Textbox1" runat="server" MaxLength="4" Columns="4"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">NPWP</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="txt_NPWP" runat="server" Width="200px" MaxLength="25"></asp:textbox></TD>
											</TR>
											<TR>
												<TD vAlign="top" align="center" colSpan="3" height="5"></TD>
											</TR>
											<TR>
												<TD vAlign="top" align="center" colSpan="3" height="10"><asp:button id="btn_Find" runat="server" Width="180px" CssClass="button1" Text="Find" onclick="btn_Find_Click"></asp:button>&nbsp;</TD>
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
					<TR>
						<TD colSpan="2"><ASP:DATAGRID id="DatGrd" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False"
								CellPadding="1">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="CU_REF"></asp:BoundColumn>
									<asp:BoundColumn DataField="CU_CIF" HeaderText="CIF No.">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CUST_NAME" HeaderText="Nama Pemohon">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CU_NPWP" HeaderText="NPWP">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="120px"></ItemStyle>
									</asp:BoundColumn>
									<asp:ButtonColumn Text="Continue" HeaderText="Function" CommandName="View">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
									</asp:ButtonColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
					<TR>
					</TR>
					<TR>
						<TD class="tdH" colSpan="2"><asp:label id="Label1" runat="server"></asp:label></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
