<%@ Page language="c#" Codebehind="CIFDataKeuanganBU.aspx.cs" AutoEventWireup="True" Inherits="SME.DCM.DataCorrectionRequir.CIFDataKeuanganBU" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CIFDataKeuanganBU</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<CENTER>
				<table width="100%" border="0">
					<tr>
						<td align="left">
							<TABLE id="Table31">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>CIF DATA KEUANGAN</B></TD>
								</TR>
							</TABLE>
						</td>
						<TD class="tdNoBorder" align="right"><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../../Body.aspx"><IMG src="../../Image/MainMenu.jpg"></A><A href="../../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A></TD>
					</tr>
					<tr>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="left" colSpan="2"><asp:placeholder id="MenuCIF" runat="server"></asp:placeholder></TD>
					</tr>
					<TR>
						<TD class="tdHeader1" colSpan="2">Laporan Keuangan</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="100%" colSpan="2"><ASP:DATAGRID id="DatGridDataPerusahaan" runat="server" AllowPaging="True" CellPadding="1" PageSize="5"
								AutoGenerateColumns="False" Width="100%">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="" HeaderText="Th. Lap Keuangan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="" HeaderText="Currency">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="" HeaderText="Total Month">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="" HeaderText="Denominasi">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Function">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="edit_data" runat="server" CommandName="edit_data">Edit</asp:LinkButton>&nbsp;
											<asp:LinkButton id="LB_DELETE" runat="server" CommandName="delete_data">Delete</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1">
										<asp:Label id="LBL_DDL_BLN_LAP" runat="server">Posisi Laporan Keuangan</asp:Label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_LAP" runat="server" Width="24px" Columns="4"
											MaxLength="2"></asp:textbox><asp:dropdownlist id="DDL_BLN_LAP" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_LAP" runat="server" Width="36px" Columns="4"
											MaxLength="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">
										<asp:Label id="LBL_RDO_PINJAMAN_LN" runat="server">Pinjaman Luar Negeri</asp:Label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 39px" align="left"><asp:radiobuttonlist id="RDO_PINJAMAN_LN" runat="server" Width="150px" RepeatDirection="Horizontal">
											<asp:ListItem Value="Y">Ya</asp:ListItem>
											<asp:ListItem Value="N" Selected="True">Tidak</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 149px">
										<asp:Label id="LBL_DDL_DENO" runat="server">Denominasi</asp:Label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class='A"TDBGColorValue"' style="HEIGHT: 10px"><asp:dropdownlist id="DDL_DENO" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1">
										<asp:Label id="LBL_DDL_AUDITED" runat="server">Audited/Unaudited</asp:Label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class='A"TDBGColorValue"' style="HEIGHT: 10px"><asp:dropdownlist id="DDL_AUDITED" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">
										<asp:Label id="LBL_DDL_CURR" runat="server">Currency</asp:Label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class='A"TDBGColorValue"' style="HEIGHT: 10px"><asp:dropdownlist id="DDL_CURR" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 149px" width="149">
										<asp:Label id="LBL_TXT_JML_BLN" runat="server">Jumlah Bulan</asp:Label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_JML_BLN" runat="server" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="tdHeader1" colSpan="3">AKTIVA</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">
										<asp:Label id="LBL_TXT_ACTIVA" runat="server">Aktiva Lancar</asp:Label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_ACTIVA" runat="server" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">
										<asp:Label id="LBL_TXT_TOT_ACTIVA" runat="server">Total Aktiva</asp:Label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_TOT_ACTIVA" runat="server" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="tdHeader1" colSpan="3">PASIVA</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">
										<asp:Label id="LBL_TXT_WJB_BANK" runat="server">Kewajiban kepada Bank</asp:Label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_WJB_BANK" runat="server" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">
										<asp:Label id="LBL_TXT_WJB_LANCAR" runat="server">Kewajiban Lancar</asp:Label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_WJB_LANCAR" runat="server" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">
										<asp:Label id="LBL_TXT_TOT_WJB" runat="server">Total Kewajiban</asp:Label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_TOT_WJB" runat="server" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">
										<asp:Label id="LBL_TXT_MODAL" runat="server">Modal</asp:Label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_MODAL" runat="server" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="tdHeader1" colSpan="3">LABA/RUGI</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">
										<asp:Label id="LBL_TXT_PENJUALAN" runat="server">Penjualan</asp:Label>&nbsp;</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PENJUALAN" runat="server" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">
										<asp:Label id="LBL_TXT_POP" runat="server">Pendapatan Operasional</asp:Label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_POP" runat="server" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">
										<asp:Label id="LBL_TXT_BOP" runat="server">Biaya Operasioanl</asp:Label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_BOP" runat="server" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">
										<asp:Label id="LBL_TXT_NON_POP" runat="server">Pendapatan Non Operasional</asp:Label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NON_POP" runat="server" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">
										<asp:Label id="LBL_TXT_NON_BOP" runat="server">Biaya Non Operasioanl</asp:Label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NON_BOP" runat="server" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">
										<asp:Label id="LBL_LR_AFTER" runat="server">Laba Rugi Thn Lalu (Stlh Pajak)</asp:Label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="LR_AFTER" runat="server" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">
										<asp:Label id="LBL_LR_BEFORE" runat="server">Laba Rugi Thn Lalu (Sblm Pajak)</asp:Label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="LR_BEFORE" runat="server" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<tr>
						<td></td>
					</tr>
					<tr align="center">
						<td class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2"><asp:button id="BTN_SAVE" runat="server" Width="76px" Text="ADD" CssClass="Button1" onclick="BTN_SAVE_Click"></asp:button>&nbsp;&nbsp;
							<asp:button id="BTN_CLEAR" runat="server" Width="76px" CssClass="Button1" Text="CLEAR" onclick="BTN_CLEAR_Click"></asp:button></td>
					</tr>
				</table>
			</CENTER>
		</form>
	</body>
</HTML>
