<%@ Page language="c#" Codebehind="NasabahDetail.aspx.cs" AutoEventWireup="True" Inherits="SME.CreditChanneling.NasabahDetail" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>NasabahDetail</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_mandatory.html" -->
		<!-- #include file="../include/cek_entries.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 0px" cellSpacing="1"
				cellPadding="1" width="100%" border="0">
				<TR>
					<TD style="WIDTH: 475px">
						<TABLE id="Table4">
							<TR>
								<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Nasabah&nbsp;Detail</B></TD>
							</TR>
						</TABLE>
					</TD>
					<TD align="right"><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
				</TR>
				<TR>
					<TD colSpan="2"><asp:label id="LBL_ACCEPT" runat="server" Visible="False"></asp:label><asp:label id="LBL_BATCHNO" runat="server" Visible="False"></asp:label><asp:label id="LBL_PARENT" runat="server" Visible="False"></asp:label><asp:label id="LBL_TC" runat="server" Visible="False"></asp:label><asp:label id="LBL_MC" runat="server" Visible="False"></asp:label></TD>
				</TR>
				<TR>
					<TD class="tdheader1" colSpan="2">Informasi Pribadi Nasabah</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 476px">
						<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD class="TDBGColor1">No.&nbsp; Nasabah</TD>
								<TD style="WIDTH: 15px">:</TD>
								<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_NONAS" runat="server" CssClass="mandatory"
										Width="250px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Nama Nasabah</TD>
								<TD style="WIDTH: 15px">:</TD>
								<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CH_NAMA" runat="server" Width="250px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Alamat</TD>
								<TD style="WIDTH: 15px">:</TD>
								<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CH_ALAMAT" runat="server" Width="250px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Identitas</TD>
								<TD>:</TD>
								<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CH_IDENTITAS" runat="server" Width="250px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Tgl Lahir</TD>
								<TD>:</TD>
								<TD class="TDBGColorValue"><asp:textbox id="TXT_CH_TGLAHIR_DAY" runat="server" Width="30px" MaxLength="2"></asp:textbox><asp:dropdownlist id="DDL_CH_TGLAHIR" runat="server"></asp:dropdownlist><asp:textbox id="TXT_CH_TGLAHIR_YEAR" runat="server" Width="40px" MaxLength="4"></asp:textbox></TD>
							</TR> <!-- 1 : Left --></TABLE>
					</TD>
					<TD>
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD class="TDBGColor1">Pendapatan (per bulan)</TD>
								<TD>:</TD>
								<TD></TD>
								<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CH_PENDAPATAN" onblur="FormatCurrency(this)"
										runat="server" Width="250px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="HEIGHT: 19px">Masa Kerja (tahun)</TD>
								<TD style="HEIGHT: 19px">:</TD>
								<TD style="HEIGHT: 19px"></TD>
								<TD class="TDBGColorValue" style="HEIGHT: 19px"><asp:textbox onkeypress="return numbersonly()" id="TXT_CH_MKERJA" runat="server" Width="250px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColorValue"></TD>
								<TD></TD>
								<TD class="TDBGColorValue"></TD>
								<TD class="TDBGColorValue"></TD>
							</TR>
							<TR>
								<TD class="TDBGColorValue"></TD>
								<TD></TD>
								<TD class="TDBGColorValue"></TD>
								<TD class="TDBGColorValue"></TD>
							</TR>
							<TR>
								<TD class="TDBGColorValue"></TD>
								<TD></TD>
								<TD class="TDBGColorValue"></TD>
								<TD class="TDBGColorValue"></TD>
							</TR> <!-- 2 : Right --></TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 476px"></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD class="tdheader1" colSpan="2">Loan Info</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 476px">
						<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR>
								<TD class="TDBGColor1">Limit (Rp)</TD>
								<TD>:</TD>
								<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CH_LIMIT" onblur="FormatCurrency(this)"
										runat="server" Width="250px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Suku Bunga (%)</TD>
								<TD>:</TD>
								<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CH_SBUN" onblur="FormatCurrency(this)"
										runat="server" Width="50px" MaxLength="3"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Tenor&nbsp;(bulan)</TD>
								<TD>:</TD>
								<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CH_JW" runat="server" Width="250px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">No Kontrak</TD>
								<TD>:</TD>
								<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CH_NOPK" runat="server" Width="250px"></asp:textbox></TD>
							</TR>
						</TABLE>
					</TD>
					<TD>
						<TABLE id="Table5" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR>
								<TD class="TDBGColor1">Tanggal Kontrak</TD>
								<TD>:</TD>
								<TD class="TDBGColorValue"><asp:textbox id="TXT_CH_TGPK_DAY" runat="server" Width="30px" MaxLength="2"></asp:textbox><asp:dropdownlist id="DDL_CH_TGPK" runat="server"></asp:dropdownlist><asp:textbox id="TXT_CH_TGPK_YEAR" runat="server" Width="40px" MaxLength="4"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Tujuan Penggunaan</TD>
								<TD>:</TD>
								<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CH_TUJ_CODE" runat="server"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Current Installment (Rp)</TD>
								<TD>:</TD>
								<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_INSTALLMENT" onblur="FormatCurrency(this)"
										runat="server" Width="250px" MaxLength="15"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColorValue"></TD>
								<TD class="TDBGColorValue"></TD>
								<TD class="TDBGColorValue"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 476px"></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD class="tdheader1" colSpan="2">Deskripsi Agunan</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 476px">
						<TABLE id="Table7" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR>
								<TD class="tdbgcolor1">Harga Beli (Rp)</TD>
								<TD>:</TD>
								<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CH_HARGABELI" onblur="FormatCurrency(this)"
										runat="server" Width="250px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="tdbgcolor1">Jenis Barang</TD>
								<TD>:</TD>
								<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CH_JB" runat="server" Width="250px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="tdbgcolor1">Merk Barang</TD>
								<TD>:</TD>
								<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CH_MERKB" runat="server" Width="250px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="tdbgcolor1">Type</TD>
								<TD>:</TD>
								<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CH_TYPE" runat="server" Width="250px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="tdbgcolor1">Tahun Pembuatan</TD>
								<TD>:</TD>
								<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CH_TAHUN" runat="server" Width="250px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="tdbgcolor1">No. Rangka</TD>
								<TD>:</TD>
								<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CH_NORANGKA" runat="server" Width="250px"></asp:textbox></TD>
							</TR>
						</TABLE>
					</TD>
					<TD>
						<TABLE id="Table8" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR>
								<TD class="tdbgcolor1">No. Mesin</TD>
								<TD>:</TD>
								<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CH_NOMESIN" runat="server" Width="250px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="tdbgcolor1">Jenis Dokumen Agunan</TD>
								<TD>:</TD>
								<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CH_JDOK" runat="server" Width="250px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="tdbgcolor1">Jenis Pertanggungan Asuransi</TD>
								<TD>:</TD>
								<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CH_JPTG" runat="server" Width="250px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="tdbgcolor1">Nilai Pertanggungan (Rp)</TD>
								<TD>:</TD>
								<TD><asp:textbox onkeypress="return numbersonly()" id="TXT_CH_NPTG" onblur="FormatCurrency(this)"
										runat="server" Width="250px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="tdbgcolor1">Kondisi Kendaraan</TD>
								<TD>:</TD>
								<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CH_KOND_CODE" runat="server"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD class="TDBGColorValue"></TD>
								<TD class="TDBGColorValue"></TD>
								<TD class="TDBGColorValue"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD class="tdbgcolor2" colSpan="2"><asp:button id="BTN_SAVE" runat="server" CssClass="BUTTON1" Text="Save" onclick="BTN_SAVE_Click"></asp:button></TD>
				</TR>
				<TR>
					<TD colSpan="2"><asp:dropdownlist id="ddl_RejectMan" runat="server" Visible="False"></asp:dropdownlist>&nbsp;
						<asp:button id="btn_RejectMan" runat="server" Visible="False" Text="Reject Manually" onclick="btn_RejectMan_Click"></asp:button></TD>
				</TR>
				<TR>
					<TD colSpan="2"><ASP:DATAGRID id="grd_RejectMan" runat="server" Visible="False" Width="100%" CellPadding="1" AutoGenerateColumns="False"
							PageSize="1">
							<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="NONAS" HeaderText="NONAS"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="BATCHNO" HeaderText="BATCHNO"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="CH_BPR_CUREF" HeaderText="CH_BPR_CUREF"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="REASONID" HeaderText="REASONID"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="REASONTYPE" HeaderText="REASONTYPE"></asp:BoundColumn>
								<asp:BoundColumn DataField="REASONDESC" HeaderText="Manual Reject Description">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn>
									<HeaderStyle Width="5%" CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:LinkButton id="lnk_Delete" runat="server" CommandName="delete">Delete</asp:LinkButton>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
						</ASP:DATAGRID></TD>
				</TR>
				<TR>
					<TD colSpan="2"><ASP:DATAGRID id="DatGrd" runat="server" Visible="False" Width="100%" CellPadding="1" AutoGenerateColumns="False"
							PageSize="1">
							<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
							<Columns>
								<asp:BoundColumn DataField="CH_PRM_REJECTDESC" HeaderText="Reject Description">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								</asp:BoundColumn>
							</Columns>
						</ASP:DATAGRID></TD>
				</TR>
				<TR>
					<TD colSpan="2"><ASP:DATAGRID id="DatGrdCompRvw" runat="server" Width="100%" CellPadding="1" AutoGenerateColumns="False"
							PageSize="1">
							<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
							<Columns>
								<asp:BoundColumn DataField="CH_PRM_NAME" HeaderText="Parameter">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CH_VALUE1" HeaderText="Min Value">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CH_VALUE2" HeaderText="Max Value">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CH_VALUE3" HeaderText="Fixed Value">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CH_SCORE" HeaderText="Score">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								</asp:BoundColumn>
							</Columns>
						</ASP:DATAGRID></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
