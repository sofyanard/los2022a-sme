<%@ Page language="c#" Codebehind="InputJatuhTempo.aspx.cs" AutoEventWireup="True" Inherits="SME.CEA.InputJatuhTempo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>InputJatuhTempo</title>
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
								<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Jatuh Tempo Rekanan</B></TD>
							</TR>
						</TABLE>
					</TD>
					<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
				</TR>
				<tr>
					<td></td>
				</tr>
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
					<TD class="tdHeader1" vAlign="top" width="50%" colSpan="2">Input Jatuh Tempo 
						Rekanan</TD>
				</TR>
				<TR>
					<TD colSpan="2"><ASP:DATAGRID id="DatGrd" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False"
							CellPadding="1">
							<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
							<Columns>
								<asp:BoundColumn DataField="REKANAN_REF" HeaderText="Rekanan Ref" Visible="True">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="REGNUM" HeaderText="No. Aplikasi">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NAMEREKANAN" HeaderText="Nama Rekanan">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="ID_NUMBER" HeaderText="ID Number">
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
										<asp:LinkButton id="LinkButton1" runat="server" Text="Continue" CausesValidation="false" CommandName="Continue"></asp:LinkButton>&nbsp;&nbsp;
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</ASP:DATAGRID></TD>
				</TR>
				<tr id="TR_CATATAN" runat="server">
					<td class="td" vAlign="top" width="60%">
						<TABLE id="Table61" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD class="TDBGColor1">No. Aplikasi</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue" style="WIDTH: 43px"><asp:textbox id="TXT_REGNUM" runat="server" Width="352px" BorderStyle="None" ReadOnly="True"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Nama Rekanan</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue" style="WIDTH: 43px"><asp:textbox id="TXT_NAME" runat="server" Width="352px" BorderStyle="None" ReadOnly="True"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Jenis Rekanan</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue" style="WIDTH: 43px"><asp:textbox id="TXT_JNS" runat="server" Width="352px" BorderStyle="None" ReadOnly="True"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Tgl. Jatuh Tempo</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_TEMPO" runat="server" MaxLength="2"
										Width="24px" CssClass="mandatory" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_BLN_TEMPO" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_TEMPO" runat="server" MaxLength="4"
										Width="36px" CssClass="mandatory" Columns="4"></asp:textbox></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<TR id="TR_BTN" runat="server">
					<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2"><asp:button id="BTN_SAVE" runat="server" Width="75px" Text="Save" CssClass="button1" onclick="BTN_SAVE_Click"></asp:button>&nbsp;
					</TD>
				</TR>
				<tr>
					<td></td>
				</tr>
				<tr>
					<td></td>
				</tr>
				<tr>
					<td></td>
				</tr>
				<TR id="Tr1" runat="server">
					<TD class="tdNoBorder" vAlign="top" width="50%">
						<TABLE id="Table20" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD class="TDBGColor1">Nama Rekanan</TD>
								<TD style="WIDTH: 15px" align="center">:</TD>
								<TD class="TDBGColorValue" style="WIDTH: 43px">
									<asp:textbox id="TXT_REK_NAME2" runat="server" Width="352px" MaxLength="15"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Bulan Jatuh Tempo Rekanan</TD>
								<TD style="WIDTH: 15px" align="center">:</TD>
								<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_BLN_JT" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
							</TR>
						</TABLE>
					</TD>
					<TD class="tdNoBorder" vAlign="top" width="50%"></TD>
				</TR>
				<TR id="Tr3" runat="server">
					<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2"><asp:button id="BTN_FIND2" runat="server" Width="84px" Text="Find" CssClass="button1" onclick="BTN_FIND2_Click"></asp:button>&nbsp;
					</TD>
				</TR>
				<TR>
					<TD class="tdHeader1" vAlign="top" width="50%" colSpan="2">Edit&nbsp;Jatuh Tempo 
						Rekanan</TD>
				</TR>
				<TR>
					<TD colSpan="2"><ASP:DATAGRID id="DatGrd2" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False"
							CellPadding="1">
							<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
							<Columns>
								<asp:BoundColumn Visible="True" DataField="REKANAN_REF" HeaderText="Rekanan Ref">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="REGNUM" HeaderText="No. Aplikasi">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NAMEREKANAN" HeaderText="Nama Rekanan">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="ID_NUMBER" HeaderText="ID Number">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="REKANANDESC" HeaderText="Jenis Rekanan">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="tgl_jatuh_tempo" HeaderText="Tgl. Jatuh Tempo">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Function">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:LinkButton id="BTN_UDATE" runat="server" Text="Edit" CausesValidation="false" CommandName="Edit"></asp:LinkButton>&nbsp;&nbsp;
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</ASP:DATAGRID></TD>
				</TR>
				<tr id="TR_CATATAN2" runat="server">
					<td class="td" vAlign="top" width="60%">
						<TABLE id="Table61" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD class="TDBGColor1">No. Aplikasi</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue" style="WIDTH: 43px"><asp:textbox id="TXT_REGNUM2" runat="server" Width="352px" BorderStyle="None" ReadOnly="True"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Nama Rekanan</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue" style="WIDTH: 43px"><asp:textbox id="TXT_NAME2" runat="server" Width="352px" BorderStyle="None" ReadOnly="True"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Jenis Rekanan</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue" style="WIDTH: 43px"><asp:textbox id="TXT_JNS2" runat="server" Width="352px" BorderStyle="None" ReadOnly="True"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Tgl. Jatuh Tempo</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue">
									<asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_TEMPO2" runat="server" MaxLength="2"
										Width="24px" CssClass="mandatory" Columns="4"></asp:textbox>
									<asp:dropdownlist id="DDL_BLN_TEMPO2" runat="server" CssClass="mandatory"></asp:dropdownlist>
									<asp:textbox onkeypress="return numbersonly()" id="TXT_THN_TEMPO2" runat="server" MaxLength="4"
										Width="36px" CssClass="mandatory" Columns="4"></asp:textbox></TD>
								<TD><asp:label id="LBL_TGL_TEMPO2" runat="server" Visible="False"></asp:label>
									<asp:label id="LBL_BLN_TEMPO2" runat="server" Visible="False"></asp:label>
									<asp:label id="LBL_THN_TEMPO2" runat="server" Visible="False"></asp:label></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<TR id="TR_BTN2" runat="server">
					<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2"><asp:button id="BTN_UPDATE" runat="server" Width="75px" Text="Update" CssClass="button1" onclick="BTN_UDATE_Click"></asp:button>&nbsp;
					</TD>
				</TR>
				<TR>
					<asp:label id="LBL_REKREF" runat="server" Visible="False"></asp:label></TR>
			</TABLE>
			<table id="Tabel3" style="WIDTH: 993px; HEIGHT: 136px" cellSpacing="0" cellPadding="0"
				width="993" border="0">
			</table>
			<!-- </center> --></form>
	</body>
</HTML>
