<%@ Page language="c#" Codebehind="KantorCabang.aspx.cs" AutoEventWireup="True" Inherits="dbrbm.Data_Entry.KantorCabang" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>KantorCabang</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Fmain" name="Fmain" action="SearchCustomer.aspx?mc=030" method="post" target="main">
		</form>
		<form id="Form2" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder">
							<TABLE id="Table8">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Initial Data Entry - 
											Kantor Cabang/Perwakilan</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg"></asp:imagebutton><A href="../Body.aspx"><IMG src="../../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:hyperlink id="HL_ACCOUNT" runat="server" NavigateUrl="CustomerInfo.aspx" Visible="False">Informasi Rekanan</asp:hyperlink><asp:hyperlink id="Hyperlink1" runat="server" NavigateUrl="DTBO\ListDTBO.aspx" Visible="False">Dokumen Legal & Perijinan</asp:hyperlink><asp:hyperlink id="Hyperlink2" runat="server" NavigateUrl="InfoPerusahaan.aspx" Visible="False">Data Kepemilikan Perusahaan</asp:hyperlink><asp:hyperlink id="Hyperlink4" runat="server" NavigateUrl="TenagaAhli.aspx" Visible="False">Tenaga Ahli</asp:hyperlink><asp:hyperlink id="HL_COLLATERAL" runat="server" NavigateUrl="KantorCabang.aspx" Visible="False">Kantor Cabang/Perwakilan</asp:hyperlink><asp:hyperlink id="HL_HISTORY" runat="server" NavigateUrl="CustHistory.aspx" Visible="False"> Notaris</asp:hyperlink></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">Kantor Cabang/Perwakilan</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="50%" colSpan="2">
							<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 8px">Kota</TD>
									<TD style="HEIGHT: 8px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 8px"><asp:textbox onkeypress="return kutip_satu()" id="Textbox13" runat="server" MaxLength="50" Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Alamat</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="Textbox14" runat="server" MaxLength="50" Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Contact Person</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="Textbox15" runat="server" MaxLength="50" Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">No. Telp</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return kutip_satu()" id="Textbox1" runat="server" Width="300px" MaxLength="50"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">No. Fax</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return kutip_satu()" id="Textbox2" runat="server" Width="300px" MaxLength="50"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Status</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
										<asp:dropdownlist id="cu_jeniskelamin" runat="server" Width="208px"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" id="TR_A" vAlign="top" align="center" width="50%" colSpan="2"><asp:button id="BTN_NEW" runat="server" CssClass="button1" Width="75px" Text="Save"></asp:button>&nbsp;
							<asp:button id="Button1" runat="server" CssClass="button1" Width="75px" Text="Cancel"></asp:button></TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" align="center" width="50%" colSpan="2"><ASP:DATAGRID id="DatGrd" runat="server" Width="100%" CellPadding="1" AutoGenerateColumns="False"
								AllowPaging="True" PageSize="5" HorizontalAlign="Center">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="kota" HeaderText="Kota">
										<HeaderStyle Width="15%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="alamat" HeaderText="Alamat">
										<HeaderStyle Width="10%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="cp" HeaderText="Contact Person">
										<HeaderStyle HorizontalAlign="Right" Width="20%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="notelp" HeaderText="No. Telp">
										<HeaderStyle Width="15%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="nofax" HeaderText="No. Fax">
										<HeaderStyle Width="15%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="status" HeaderText="Status">
										<HeaderStyle Width="15%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:ButtonColumn Text="Edit" CommandName="Edit">
										<HeaderStyle Width="5%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:ButtonColumn>
									<asp:ButtonColumn Text="Delete" CommandName="Delete">
										<HeaderStyle Width="5%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:ButtonColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID>
						</TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
