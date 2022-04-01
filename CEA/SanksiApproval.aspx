<%@ Page language="c#" Codebehind="SanksiApproval.aspx.cs" AutoEventWireup="True" Inherits="SME.CEA.SanksiApproval" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SanksiApproval</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table4" width="100%" border="0">
					<TR>
						<TD align="left" colSpan="1">
							<TABLE id="Table3">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Sanksi - Approval</B></TD>
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
												<TD class="TDBGColor1">No. Registrasi</TD>
												<TD></TD>
												<TD class="TDBGColorValue" style="WIDTH: 342px"><asp:textbox onkeypress="return kutip_satu()" id="TXT_NoReg" runat="server" MaxLength="25" Width="168px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 521px" vAlign="top" align="center" colSpan="3"></TD>
											</TR>
										</TABLE>
										<asp:button id="btn_Find" runat="server" Width="200px" CssClass="button1" Text="Find Rekanan" onclick="btn_Find_Click"></asp:button></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD align="center" colSpan="2">&nbsp;</TD>
					</TR>
					<TR>
						<TD class="tdHeader1" vAlign="top" width="50%" colSpan="2">Existing Data</TD>
					</TR>
					<TR>
						<TD colSpan="2"><ASP:DATAGRID id="DatGrd" runat="server" Width="100%" AllowPaging="True" CellPadding="1" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<ASP:BoundColumn DataField="SEQ" Visible="False"></ASP:BoundColumn>
									<asp:BoundColumn HeaderText="No. Registrasi" DataField="REKANAN_REF">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="Nama" DataField="Namerekanan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PROBLEMDESC" HeaderText="Pelanggaran Internal">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="300px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PERMASALAHAN" HeaderText="Pelanggaran Eksternal">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:ButtonColumn Text="Sanksi Detail" HeaderText="Function" CommandName="Detail">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
									</asp:ButtonColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
					<tr id="TR_INFO" runat="server">
						<td vAlign="top" width="100%" colSpan="2">
							<table id="tabel23" cellSpacing="2" cellPadding="2" width="100%" border="0">
								<TR>
									<TD class="tdHeader1" colSpan="2">Info Rekanan</TD>
								</TR>
								<TR id="Tr1" runat="server">
									<TD class="td" vAlign="top" width="50%">
										<TABLE id="Table6" cellSpacing="2" cellPadding="2" width="100%">
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 129px">No. Registrasi</TD>
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
												<TD class="TDBGColor1">Contact Person</TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_CP" runat="server" Width="300px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
											</TR>
										</TABLE>
										<asp:label id="LBL_CU_CUSTTYPEID" runat="server" Visible="False"></asp:label><asp:label id="LBL_AP_PROG_CODE" runat="server" Visible="False"></asp:label></TD>
									<TD class="td" vAlign="top" width="50%">
										<TABLE id="Table10" cellSpacing="2" cellPadding="2" width="100%">
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
							</table>
						</td>
					</tr>
					<TR>
						<TD class="tdHeader1" vAlign="top" width="50%" colSpan="2">Sanksi Internal</TD>
					</TR>
					<TR id="TR_SANKSI" runat="server">
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table20" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 10px" width="129">Jenis Sanksi</TD>
									<TD style="WIDTH: 15px; HEIGHT: 10px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 10px"><asp:textbox id="TXT_JNS_SANKSI" runat="server" Width="300px" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="129">No. Surat</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NO_SURAT" runat="server" MaxLength="15" Width="300px" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="129">Tgl. Surat</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_TGL_SURAT" runat="server" Width="300px" ReadOnly="True" Columns="4"></asp:textbox></TD>
								</TR>
								<!-- Additional Field : Right --></TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" runat="server">
								<TR>
									<TD class="TDBGColor1" width="129">Jangka Waktu Sanksi</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_JANGKA_WKT_SANKSI" runat="server" MaxLength="40" Width="300px" ReadOnly="True"
											Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 15px" width="129">Permasalahan</TD>
									<TD style="WIDTH: 15px; HEIGHT: 15px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 15px"><asp:textbox id="TXT_PROBLEM" runat="server" Width="300px" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Status Sanksi</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_STATUS_SANKSI" runat="server" Width="300px" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<!-- Additional Field : Right --></TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="tdHeader1" vAlign="top" width="50%" colSpan="2">Sanksi Eksternal</TD>
					</TR>
					<TR id="TR_SANKSI_EXT" runat="server">
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table200" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 10px" width="129">Sanksi</TD>
									<TD style="WIDTH: 15px; HEIGHT: 10px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="SANKSI_EXT" runat="server" Width="300px" ReadOnly="True" TextMode="MultiLine"
											Height="40px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="129">No. Surat</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="NO_SURAT_EXT" runat="server" Width="300px" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="129">Tgl. Surat</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_DAY_EXT" runat="server" Width="300px" ReadOnly="True" Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 10px" width="129">Dikeluarkan Oleh</TD>
									<TD style="WIDTH: 15px; HEIGHT: 10px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="DIKELUARKAN_EXT" runat="server" Width="300px" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<!-- Additional Field : Right --></TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="100%" runat="server">
								<TR>
									<TD class="TDBGColor1" width="129">Jangka Waktu Sanksi</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="JANGKA_WKT_EXT" runat="server" Width="300px" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 15px" width="129">Permasalahan</TD>
									<TD style="WIDTH: 15px; HEIGHT: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="MASALAH_EXT" runat="server" Width="300px" ReadOnly="True" TextMode="MultiLine"
											Height="40px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Status Sanksi</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="STATUS_EXT" runat="server" Width="300px" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 10px" width="129">Keterangan</TD>
									<TD style="WIDTH: 15px; HEIGHT: 10px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="KET_EXT" runat="server" Width="300px" ReadOnly="True" TextMode="MultiLine" Height="40px"></asp:textbox></TD>
								</TR>
								<!-- Additional Field : Right --></TABLE>
						</TD>
					</TR>
					<TR id="TR_BUTTON" runat="server">
						<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2"><asp:button id="BTN_APPROVE" runat="server" Width="75px" CssClass="button1" Text="Disetujui" onclick="BTN_APPROVE_Click"></asp:button>&nbsp;
							<asp:button id="BTN_REJECT" runat="server" Width="83px" CssClass="button1" Text="Tolak" onclick="BTN_REJECT_Click"></asp:button></TD>
					</TR>
					<TR>
						<TD class="tdH" colSpan="2"><asp:label id="LBL_REKANANREF" runat="server" Visible="False"></asp:label><asp:label id="TXT_SEQ" runat="server" Visible="False"></asp:label></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
