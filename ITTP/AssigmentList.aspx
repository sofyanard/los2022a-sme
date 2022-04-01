<%@ Page language="c#" Codebehind="AssigmentList.aspx.cs" AutoEventWireup="True" Inherits="SME.ITTP.AssigmentList" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AssigmentList</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_entries.html" -->
		<!-- #include file="../include/cek_all.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table4" width="100%" border="0">
					<TR>
						<TD align="left" colSpan="1">
							<TABLE id="Table3">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Assigment List</B></TD>
								</TR>
							</TABLE>
						</TD>
						<td align="right"><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></td>
					</TR>
					<tr>
						<td style="HEIGHT: 28px" colSpan="2">
							<table>
								<tr>
									<td class="TDBGColor1" style="WIDTH: 110px">Find Application :</td>
									<td style="WIDTH: 5px"></td>
									<td>
										<asp:DropDownList id="DDL_FIND_KRITERIA" runat="server"></asp:DropDownList>
										<asp:TextBox id="TXT_FIND_KRITERIA" runat="server"></asp:TextBox></td>
									<td style="WIDTH: 5px"></td>
									<td><asp:button id="BTN_FIND" runat="server" Text="F i n d" onclick="BTN_FIND_Click"></asp:button><asp:label id="lbl_prod" runat="server" Width="176px" Columns="30" MaxLength="20" Visible="False"></asp:label><asp:label id="lbl_apptype" runat="server" Width="176px" Columns="30" MaxLength="20" Visible="False"></asp:label><asp:label id="lbl_track" runat="server" Width="176px" Columns="30" MaxLength="20" Visible="False"></asp:label><asp:label id="lbl_userid" runat="server" Visible="False"></asp:label></td>
								</tr>
							</table>
						</td>
					</tr>
					<TR>
						<TD align="center" colSpan="2">&nbsp;</TD>
					</TR>
					<TR>
						<TD colSpan="2"><ASP:DATAGRID id="DataGrid1" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False"
								CellPadding="1">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="CU_REF"></asp:BoundColumn>
									<asp:BoundColumn DataField="AP_REGNO" SortExpression="AP_REGNO" HeaderText="Application #">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="NAME" SortExpression="NAME" HeaderText="Customer Name">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="120px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AP_SIGNDATE" SortExpression="AP_SIGNDATE" HeaderText="Appl. Date">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CP_LIMIT" HeaderText="Limit" DataFormatString="{0:00.00,00}">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="txntype" HeaderText="Transaction Type">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AP_RELMNGR" SortExpression="SU_FULLNAME" HeaderText="PIC Unit Business">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="BS_BIASSIGN" HeaderText="BS_BIASSIGN"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="BS_COMPLETE" HeaderText="BS_COMPLETE">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Assignment">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:Image id="IMG_BS_ASSIGN" runat="server"></asp:Image>
											<asp:Label id="LBL_BS_ASSIGN" runat="server"></asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn Visible="False" HeaderText="Complete">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:Image id="IMG_BS_COMPLETE" runat="server"></asp:Image>
											<asp:Label id="LBL_BS_COMPLETE" runat="server"></asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:ButtonColumn Text="Continue" HeaderText="Function" CommandName="Continue">
										<HeaderStyle HorizontalAlign="Center" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<FooterStyle HorizontalAlign="Center"></FooterStyle>
									</asp:ButtonColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
					<TR>
					</TR>
					<TR>
						<TD class="tdH" colSpan="2"><asp:label id="Label1" runat="server"></asp:label><asp:label id="LBL_CBC_CODE" runat="server" Visible="False"></asp:label><asp:label id="LBL_BR_CCOBRANCH" runat="server" Visible="False"></asp:label><asp:label id="LBL_TC" runat="server" Visible="False"></asp:label><asp:label id="LBL_SORTEXP" runat="server" Visible="False">AP_REGNO</asp:label><asp:label id="LBL_SORTTYPE" runat="server" Visible="False">ASC</asp:label></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
