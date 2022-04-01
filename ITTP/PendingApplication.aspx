<%@ Page language="c#" Codebehind="PendingApplication.aspx.cs" AutoEventWireup="True" Inherits="SME.ITTP.PendingApplication" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PendingApplication</title>
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
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Pending List</B></TD>
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
										<HeaderStyle CssClass="tdSmallHeader" Width="20%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="NAME" SortExpression="NAME" HeaderText="Customer Name">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="40%"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AP_SIGNDATE" SortExpression="AP_SIGNDATE" HeaderText="Appl. Date" DataFormatString="{0:dd-MMM-yyyy}">
										<HeaderStyle CssClass="tdSmallHeader" Width="20%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="SU_FULLNAME" SortExpression="SU_FULLNAME" HeaderText="PIC Unit Business">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:ButtonColumn Text="Continue" HeaderText="Function" CommandName="Continue">
										<HeaderStyle HorizontalAlign="Center" CssClass="tdSmallHeader" Width="20%"></HeaderStyle>
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
