<%@ Page language="c#" Codebehind="BounceCheque.aspx.cs" AutoEventWireup="True" Inherits="Websysca.BounceCheque" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>List Customer</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_all.html" -->
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
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Kolektibilitas Account 
											History</B></TD>
								</TR>
							</TABLE>
						</TD>
						<td align="right">
							<asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="../Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></td>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder>&nbsp;&nbsp;&nbsp;&nbsp;</TD>
					</TR>
					<TR>
						<TD colSpan="2"><BR>
							<ASP:DATAGRID id="DGR_LIST" runat="server" PageSize="1" AutoGenerateColumns="False" CellPadding="1"
								Width="100%" onselectedindexchanged="DGR_LIST_SelectedIndexChanged">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="CU_REF" HeaderText="curef"></asp:BoundColumn>
									<asp:BoundColumn DataField="ACC_GIRO" HeaderText="Nomor Rekening">
										<HeaderStyle Width="25%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Justify"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="NOTE" HeaderText="Catatan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Justify" VerticalAlign="Middle"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn>
										<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="LinkButton1" runat="server" CommandName="delete">Delete</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</ASP:DATAGRID></TD>
					</TR>
					<TR>
						<TD colSpan="2"></TD>
					</TR>
					<TR>
						<TD colSpan="2">
							<P align="center">
								<TABLE id="Table2" cellSpacing="1" cellPadding="1" border="0">
									<TR>
										<TD>Nomor Rekening :
											<asp:textbox onkeypress="return digitsonly()" id="txtNoRekGiro" runat="server" MaxLength="19"
												Width="179px"></asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp; Catatan :
											<asp:textbox id="TXT_NOTE" runat="server" Width="505px"></asp:textbox>
										</TD>
										<TD>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
											<asp:button id="BTN_ADD" runat="server" CssClass="BUTTON1" Text="Tambah" onclick="BTN_ADD_Click"></asp:button></TD>
									</TR>
								</TABLE>
							</P>
						</TD>
					</TR>
					<TR>
						<TD align="center" colSpan="2">
							<TABLE id="Table1" cellSpacing="1" cellPadding="1" border="0">
								<TR>
									<TD>Jumlah Cek yang Ditolak :
										<asp:textbox id="TXT_JMLBC" runat="server" Width="39px"></asp:textbox></TD>
									<TD><asp:button id="BTN_SAVE" runat="server" Width="75px" CssClass="Button1" Text="Save" onclick="BTN_SAVE_Click"></asp:button></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
					</TR>
					<TR>
						<TD align="center" colSpan="2"></TD>
					</TR>
					<TR>
						<TD class="tdH" align="center" colSpan="2"><ASP:DATAGRID id="DGR_LIST2" runat="server" PageSize="1" AutoGenerateColumns="False" CellPadding="1"
								Width="100%" onselectedindexchanged="DGR_LIST2_SelectedIndexChanged">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="acc_no" HeaderText="Nomor Rekening" DataFormatString="{0:N2}">
										<HeaderStyle Width="25%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="cheque_no" HeaderText="Nomor Cek">
										<HeaderStyle Width="15%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="cheque_amount" HeaderText="Nilai Cek" DataFormatString="{0:0,00.00}">
										<HeaderStyle Width="20%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="cheque_return_date" HeaderText="Tanggal" DataFormatString="{0:dd MMMM yyyy}">
										<HeaderStyle Width="15%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="bad_cheque_reason" HeaderText="Alasan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Justify"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
							</ASP:DATAGRID><BR>
							<BR>
						</TD>
					</TR>
					<TR>
						<TD class="tdH" align="center" colSpan="2">
							<asp:label id="LBL_TOTAL_BC" runat="server" Font-Bold="True"></asp:label><BR>
							<BR>
						</TD>
					</TR>
					<TR>
						<TD class="tdH" align="center" colSpan="2">
							<asp:DropDownList id="DDL_TIMERANGE" runat="server">
								<asp:ListItem Value="12">12 bulan terakhir</asp:ListItem>
								<asp:ListItem Value="24">24 bulan terakhir</asp:ListItem>
							</asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:button id="BTN_SEARCH" runat="server" Text="Search" CssClass="BUTTON1" onclick="BTN_SEARCH_Click"></asp:button></TD>
					</TR>
				</TABLE>
			</center>
			<asp:label id="LBL_CUREF" style="Z-INDEX: 101; LEFT: 288px; POSITION: absolute; TOP: 568px"
				runat="server" Visible="False">LBL_CUREF</asp:label><asp:label id="Label2" style="Z-INDEX: 102; LEFT: 384px; POSITION: absolute; TOP: 568px" runat="server"
				Visible="False">Label</asp:label></form>
	</body>
</HTML>
