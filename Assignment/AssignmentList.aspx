<%@ Page language="c#" Codebehind="AssignmentList.aspx.cs" AutoEventWireup="True" Inherits="SME.Assignment.AssignmentList" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>BICheckingList</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder">
							<TABLE id="Table2">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>
											<asp:Label id="LBL_TITLE" runat="server"></asp:Label>
											&nbsp;List</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder"></TD>
						<TD class="tdNoBorder" align="right"></TD>
					</TR>
					<TR>
						<TD vAlign="top" colSpan="2">
							<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="100%" border="0">
								<TR>
									<TD class="tdbgcolor1">Find</TD>
									<TD>:</TD>
									<TD>
										<asp:DropDownList id="DDL_FIND_KRITERIA" runat="server"></asp:DropDownList>
										<asp:TextBox id="TXT_FIND_KRITERIA" runat="server"></asp:TextBox>
										<asp:Button id="BTN_FIND" runat="server" Width="100px" CssClass="button1" 
                                            Text="Cari" onclick="BTN_FIND_Click"></asp:Button></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD vAlign="top" align="center" colSpan="2">
							<asp:DataGrid id="DataGrid1" runat="server" AutoGenerateColumns="False" AllowPaging="True" Width="100%"
								AllowSorting="True">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="AP_REGNO" SortExpression="AP_REGNO" HeaderText="Application No.">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="CU_REF" HeaderText="Ref #">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="NAME" SortExpression="NAME" HeaderText="Nama Pemohon">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AP_SIGNDATE" SortExpression="AP_SIGNDATE" HeaderText="Tanggal Aplikasi">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AP_RELMNGR" SortExpression="SU_FULLNAME" HeaderText="Nama Analis">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="BS_BIASSIGN" HeaderText="BS_BIASSIGN"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="BS_COMPLETE" HeaderText="BS_COMPLETE"></asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Penugasan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:Image id="IMG_BS_ASSIGN" runat="server"></asp:Image>
											<asp:Label id="LBL_BS_ASSIGN" runat="server"></asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn Visible="False" HeaderText="Status">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:Image id="IMG_BS_COMPLETE" runat="server"></asp:Image>
											<asp:Label id="LBL_BS_COMPLETE" runat="server"></asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:ButtonColumn Text="View" HeaderText="Fungsi" CommandName="View">
										<HeaderStyle HorizontalAlign="Center" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<FooterStyle HorizontalAlign="Center"></FooterStyle>
									</asp:ButtonColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</asp:DataGrid>
							<asp:Label id="LBL_CBC_CODE" runat="server" Visible="False"></asp:Label>
							<asp:Label id="LBL_BR_CCOBRANCH" runat="server" Visible="False"></asp:Label>
							<asp:Label id="LBL_TC" runat="server" Visible="False"></asp:Label>
							<asp:Label id="LBL_SORTEXP" runat="server" Visible="False">AP_REGNO</asp:Label>
							<asp:Label id="LBL_SORTTYPE" runat="server" Visible="False">ASC</asp:Label>
						</TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
