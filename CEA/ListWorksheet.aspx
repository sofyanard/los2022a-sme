<%@ Page language="c#" Codebehind="ListWorksheet.aspx.cs" AutoEventWireup="True" Inherits="SME.CEA.ListWorksheet" %>
<%@ Register TagPrefix="uc1" TagName="DocExport" Src="CommonForm/NotaExport.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ListWorksheet</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="form1" method="post" runat="server">
			<!-- <center> -->
			<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
				<TR>
					<TD class="tdNoBorder">
						<TABLE id="Table8">
							<TR>
								<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>List Worksheet</B></TD>
							</TR>
						</TABLE>
					</TD>
					<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
				</TR>
				<TR id="TR_FIND" runat="server">
					<TD class="tdNoBorder" vAlign="top" width="50%">
						<TABLE id="Table20" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD class="TDBGColor1" width="129">Nama Rekanan</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue" style="WIDTH: 208px"><asp:textbox id="TXT_REK_NAME" runat="server" MaxLength="15" Width="200px"></asp:textbox></TD>
								<td><asp:button id="BTN_FIND" Runat="server" Text="Find" CssClass="button1" onclick="BTN_FIND_Click"></asp:button></td>
							</TR>
						</TABLE>
					</TD>
					<TD class="tdNoBorder" vAlign="top" width="50%"></TD>
				</TR>
				<TR>
					<TD colSpan="2"><ASP:DATAGRID id="DatGrd" runat="server" Width="100%" PageSize="20" AllowPaging="True" AutoGenerateColumns="False"
							CellPadding="1">
							<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="REKANAN_REF"></asp:BoundColumn>
								<asp:BoundColumn DataField="REGNUM" HeaderText="No. Aplikasi">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NAMEREKANAN" HeaderText="Nama Rekanan">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NPWP" HeaderText="NPWP">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="REKANANDESC" HeaderText="Jenis Rekanan">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Function">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:LinkButton id="LinkButton1" runat="server" Text="View" CausesValidation="false" CommandName="View"></asp:LinkButton>&nbsp;&nbsp;
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</ASP:DATAGRID></TD>
				</TR>
				<tr id="TR_INFO" runat="server">
					<td colSpan="2">
						<table width="100%">
							<TR>
								<TD class="tdHeader1" colSpan="2">Info Rekanan</TD>
							</TR>
							<TR>
								<TD class="td" vAlign="top" width="50%">
									<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 129px">No. Aplikasi</TD>
											<TD style="WIDTH: 15px"></TD>
											<TD class="TDBGColorValue"><asp:textbox id="TXT_REGNUM" runat="server" Width="300px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1">Jenis Rekanan</TD>
											<TD style="WIDTH: 15px"></TD>
											<TD class="TDBGColorValue"><asp:textbox id="TXT_JNS_REK" runat="server" Width="300px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1">Nama Rekanan</TD>
											<TD style="WIDTH: 15px"></TD>
											<TD class="TDBGColorValue"><asp:textbox id="TXT_NAMA_REK" runat="server" Width="300px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1">NPWP</TD>
											<TD style="WIDTH: 15px"></TD>
											<TD class="TDBGColorValue"><asp:textbox id="TXT_NPWP" runat="server" Width="300px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
										</TR>
									</TABLE>
									<asp:label id="LBL_CU_CUSTTYPEID" runat="server" Visible="False"></asp:label><asp:label id="LBL_AP_PROG_CODE" runat="server" Visible="False"></asp:label></TD>
								<TD class="td" vAlign="top" width="50%">
									<TABLE id="Table10" cellSpacing="0" cellPadding="0" width="100%">
										<TR>
											<TD class="TDBGColor1">Alamat Rekanan</TD>
											<TD style="WIDTH: 15px">:</TD>
											<TD class="TDBGColorValue"><asp:textbox id="TXT_ADDRESS1" runat="server" Width="300px" ReadOnly="True"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="HEIGHT: 11px">&nbsp;</TD>
											<TD style="HEIGHT: 11px"></TD>
											<TD class="TDBGColorValue" style="HEIGHT: 11px"><asp:textbox id="TXT_ADDRESS2" runat="server" Width="300px" ReadOnly="True"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1">Kota</TD>
											<TD>:</TD>
											<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_CITY" runat="server" Width="300px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1">No. Telepon Kantor</TD>
											<TD></TD>
											<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_NOTLP" runat="server" Width="300px" ReadOnly="True"></asp:textbox></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD colSpan="2"><uc1:docexport id="DocExport1" runat="server"></uc1:docexport></TD>
							</TR>
						</table>
					</td>
				</tr>
			</TABLE>
			<table id="Tabel3" style="WIDTH: 993px; HEIGHT: 136px" cellSpacing="0" cellPadding="0"
				width="993" border="0">
			</table>
			<!-- </center> --></form>
	</body>
</HTML>
