<%@ Page language="c#" Codebehind="DaftarPensiun.aspx.cs" AutoEventWireup="True" Inherits="SME.CEA.DaftarPensiun" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DaftarPensiun</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<table id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<tr>
						<td>
							<TABLE id="Table8">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Daftar Pensiun</B></TD>
								</TR>
							</TABLE>
						</td>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A>
						</TD>
					</tr>
					<tr>
						<td>
							<table width="100%">
							</table>
						</td>
					</tr>
					<tr>
						<td class="tdHeader1" width="100%" colSpan="2">Daftar Pensiun Notaris</td>
					</tr>
					<TR id="TR_BLN_PENSIUN" runat="server">
						<TD vAlign="top">
							<TABLE id="Table18" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 130px">Bulan Pensiun</TD>
									<TD style="WIDTH: 15px" align="center">:</TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_BLN_PENSIUN" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_BLN_PENSIUN_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</table>
				<table width="100%">
					<TR width="100%">
						<TD colSpan="2"><ASP:DATAGRID id="DGR_DAFTAR" runat="server" AutoGenerateColumns="False" CellPadding="1" Width="100%"
								AllowPaging="True">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="rekanan_ref" HeaderText="No. Registrasi" ItemStyle-HorizontalAlign="Center">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="namerekanan" HeaderText="Nama Rekanan" ItemStyle-HorizontalAlign="Center">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="address1" HeaderText="Alamat" ItemStyle-HorizontalAlign="Center">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="ktp#" HeaderText="No.KTP" ItemStyle-HorizontalAlign="Center">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="telpoffice" HeaderText="No.Telp Kantor" ItemStyle-HorizontalAlign="Center">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="mobile" HeaderText="Mobile Phone" ItemStyle-HorizontalAlign="Center">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="pensiun_date" HeaderText="Tanggal Pensiun" ItemStyle-HorizontalAlign="Center">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
				</table>
			</center>
		</form>
	</body>
</HTML>
