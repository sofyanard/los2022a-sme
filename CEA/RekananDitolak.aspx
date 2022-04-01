<%@ Page language="c#" Codebehind="RekananDitolak.aspx.cs" AutoEventWireup="True" Inherits="SME.CEA.RekananDitolak" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>RekananDitolak</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../Style.css" type="text/css" rel="stylesheet">
  </HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table4" width="100%" border="0">
  <TBODY>
					<TR>
						<TD align="left" colSpan="1">
							<TABLE id="Table3">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Daftar Rekanan Ditolak</B></TD>
								</TR>
							</TABLE>
						</TD>
						<td align="right"><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></td>
					</TR>
					<TR>
						<TD align="center" colSpan="2">
							<TABLE class="td" id="Table1" style="WIDTH: 590px" cellSpacing="1" cellPadding="1" width="590"
								border="1">
								<TR>
									<TD class="tdHeader1">Search Criteria</TD>
								</TR>
								<TR>
									<TD vAlign="bottom" align="center">
										<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD class="TDBGColor1">Nama Rekanan</TD>
												<TD width="17"></TD>
												<TD class="TDBGColorValue" style="WIDTH: 342px" width="342"><asp:textbox onkeypress="return kutip_satu()" id="TXT_REK_NAME" runat="server" MaxLength="20"
														Width="280px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">No. Aplikasi</TD>
												<TD></TD>
												<TD class="TDBGColorValue" style="WIDTH: 342px"><asp:textbox onkeypress="return kutip_satu()" id="TXT_NoReg" runat="server" MaxLength="25" Width="168px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 521px" vAlign="top" align="center" colSpan="3"></TD>
											</TR>
										</TABLE>
										<asp:button id="btn_Find" runat="server" Width="200px" CssClass="button1" Text="Cari Rekanan" onclick="btn_Find_Click"></asp:button></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD align="center" colSpan="2">&nbsp;</TD>
					</TR>
					<TR>
						<TD class="tdHeader1" vAlign="top" width="50%" colSpan="2">Daftar Rekanan Ditolak</TD>
					</TR>
					<TR>
						<TD colSpan="2"><ASP:DATAGRID id="DatGrd" runat="server" Width="100%" AllowPaging="True" CellPadding="1" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn HeaderText="No. Aplikasi" DataField="Regnum">
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
									<asp:BoundColumn DataField="apcurrtrackdate" HeaderText="Tanggal Penolakan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:ButtonColumn Text="View" HeaderText="Function" CommandName="View">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
									</asp:ButtonColumn>
									<asp:BoundColumn HeaderText="Registrasi#" Visible="False" DataField="Rekanan_ref">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">Info Rekanan</TD>
					</TR>
					<TR id="TR_INFO" runat="server">
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">No. Aplikasi</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_REGNUM" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jenis Rekanan</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_JNS_REK" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nama Rekanan</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NAMA_REK" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Contact Person</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CP" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:textbox></TD>
								</TR>
							</TABLE>
							<asp:label id="LBL_CU_CUSTTYPEID" runat="server" Visible="False"></asp:label><asp:label id="LBL_AP_PROG_CODE" runat="server" Visible="False"></asp:label></TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table10" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="150">Alamat Rekanan</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_ADDRESS1" runat="server" ReadOnly="True" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 11px">&nbsp;</TD>
									<TD style="HEIGHT: 11px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 11px"><asp:textbox id="TXT_ADDRESS2" runat="server" ReadOnly="True" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Kota</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_CITY" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">No. Telepon Kantor</TD>
									<TD></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_NOTLP" runat="server" ReadOnly="True" Width="100%"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<tr id="TR_ALASAN" runat="server">
						<td>
							<table>
        <TBODY>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 250px">Alasan Ditolak</TD>
									<TD style="WIDTH: 26px"></TD>
									<TD class="TDBGColorValue" align="left"><asp:textbox id="TXT_CAT" runat="server" Width="450px" Height="100px" MaxLength="100" ReadOnly="True" TextMode="MultiLine"></asp:textbox></TD></TR></TBODY></table></td></tr><TR><TD class="tdH colSpan=" 2??><asp:label id="LBL_REKANANREF" runat="server" Visible="False"></asp:label></TD>
					</TR>
					<TR>
						<TD class="tdH" colSpan="2"><asp:label id="LBL_REGNUM" runat="server" Visible="False"></asp:label></TD>
					</TR></TBODY>
				</TABLE>
			</center>
		</form></TR></TBODY></TABLE></TR></TBODY></TABLE>
<CENTER></CENTER></FORM>
	</body>
</HTML>
