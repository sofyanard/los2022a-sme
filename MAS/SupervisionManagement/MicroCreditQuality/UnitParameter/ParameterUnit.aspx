<%@ Page language="c#" Codebehind="ParameterUnit.aspx.cs" AutoEventWireup="True" Inherits="SME.MAS.SupervisionManagement.MicroCreditQuality.UnitParameter.ParameterUnit" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ParameterUnit</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../../Style.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function keluar()
		{
			if (confirm("Are you sure want to finish ?"))
				document.Fmain.submit();
		}
		</script>
		<script type="text/javascript">
            function confirmDelete(){
                return window.confirm('Are you sure you want to delete this?');
            }
		</script>
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder">
							<TABLE id="Table8">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>PARAMETER UNIT</B></TD>
								</TR>
							</TABLE>
						</TD>
						<td align="right"><A href="ListCustomer.aspx?si="></A><A href="../../../../Body.aspx"><IMG src="../../../../Image/MainMenu.jpg"></A><A href="../../../../Logout.aspx" target="_top"><IMG src="../../../../Image/Logout.jpg"></A></td>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2"></TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table4" cellSpacing="1" cellPadding="2" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 141px">Distrik</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="ddl_distrik" runat="server" AutoPostBack="True" onselectedindexchanged="ddl_distrik_SelectedIndexChanged"></asp:dropdownlist><asp:textbox onkeypress="return kutip_satu()" id="TXT_DISTRIK" runat="server" ReadOnly="True"
											MaxLength="100" Width="300px" Visible="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 141px; HEIGHT: 16px">Cluster</TD>
									<TD style="HEIGHT: 16px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 16px"><asp:dropdownlist id="DDL_CLUSTER" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_CLUSTER_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 141px">Unit / Cabang</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:dropdownlist id="DDL_UNIT_CABANG" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_UNIT_CABANG_SelectedIndexChanged"></asp:dropdownlist><asp:textbox id="txt_unit_code" runat="server" AutoPostBack="True" Width="80px" ontextchanged="txt_unit_code_TextChanged"></asp:textbox><asp:button id="btn_search_unit" runat="server" Text="Search" onclick="btn_search_unit_Click"></asp:button></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table65" cellSpacing="1" cellPadding="2" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 141px">Tahun Pembukaan</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_BUKA" runat="server" MaxLength="2"
											Width="24px" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_BLN_BUKA" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_BUKA" runat="server" MaxLength="4"
											Width="36px" Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 141px">Jumlah Sales Outlet</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_JUM_SALES" runat="server" MaxLength="100"
											Width="300px" TextMode="SingleLine"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<tr>
						<td></td>
					</tr>
					<tr align="center">
						<td class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2"><asp:button id="BTN_INSERT" runat="server" Width="75px" Text="INSERT" CssClass="Button1" onclick="BTN_INSERT_Click"></asp:button>&nbsp;&nbsp;
							<asp:button id="BTN_CLEAR" runat="server" Width="75px" Text="CLEAR" CssClass="Button1" onclick="BTN_CLEAR_Click"></asp:button></td>
					</tr>
					<tr>
						<td><asp:label id="TXT_SEQ" Visible="False" Runat="server"></asp:label></td>
					</tr>
					<TR>
						<TD colSpan="2"><ASP:DATAGRID id="DatGrd" runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="1"
								AllowPaging="True">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="unit_seq#" HeaderText="seq" Visible="False">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="distrik_code" HeaderText="Distrik">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="cluster_code" HeaderText="Cluster">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="unit_code" HeaderText="Unit / Cabang">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="tahun_pembukaan" HeaderText="Tahun Pembukaan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="jumlah_so" HeaderText="Jumlah Sales Outlet">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Function">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="edit_data" runat="server" CommandName="edit_data">Edit</asp:LinkButton>&nbsp;
											<asp:LinkButton id="delete_data" runat="server" CommandName="delete_data">Delete</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
