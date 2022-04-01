<%@ Page language="c#" Codebehind="arAspekTeknisCBI.aspx.cs" AutoEventWireup="True" Inherits="SME.CBI.arAspekTeknisCBI" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Aspek Teknis</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_entries.html" -->
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="1">
				<tr>
					<td class="tdHeader1" width="100%" colSpan="2">
						<P>ASPEK TEKNIS</P>
					</td>
				</tr>
				<TR>
					<TD style="HEIGHT: 6px" align="center" width="100%" colSpan="2"><nobr>Ketentuan Kredit:
							<asp:dropdownlist id="ddl_AT_KETKREDIT" runat="server" Enabled="False">
								<asp:ListItem Value="0">--Pilih--</asp:ListItem>
							</asp:dropdownlist></nobr></TD>
				</TR>
				<tr>
					<td class="tdSmallHeader" width="100%" colSpan="2">1. Objek Pembiayaan</td>
				</tr>
				<tr>
					<td style="HEIGHT: 58px" width="100%" colSpan="2"><asp:textbox onkeypress="return kutip_satu()" id="txt_AT_OBJEKPEMBIAYAAN" runat="server" Height="48px"
							TextMode="MultiLine" Width="496px"></asp:textbox></td>
				</tr>
				<tr>
					<td width="100%" colSpan="2"></td>
				</tr>
				<tr>
					<td class="tdSmallHeader" width="100%" colSpan="2">2. Aspek teknis</td>
				</tr>
				<tr>
					<td width="100%" colSpan="2">- Bangunan: sarana/prasarana, lokasi, lama proyek, 
						jadwal pembangunan proyek, luas, pemborong/kontraktor, SPK, dsb</td>
				</tr>
				<tr>
					<td style="HEIGHT: 21px" width="100%" colSpan="2">- Mesin: nama pemasok, merk, 
						type, spesifikasi teknis, kapasitas, rencana produksi/peningkatan, dsb</td>
				</tr>
				<tr>
					<td width="100%" colSpan="2">- Kendaraan: Nama Dealer/Distributor &amp; alamatnya, 
						jenis, merk, spesifikasi teknis, dsb</td>
				</tr>
				<tr>
					<td style="HEIGHT: 80px" width="100%" colSpan="2"><asp:textbox onkeypress="return kutip_satu()" id="txt_AT_ASPEKTEKNIS" runat="server" Height="70px"
							TextMode="MultiLine" Width="496px"></asp:textbox></td>
				</tr>
				<tr>
					<td width="100%" colSpan="2"></td>
				</tr>
				<tr>
					<td class="tdSmallHeader" width="100%" colSpan="2">3. Perizinan</td>
				</tr>
				<tr>
					<td width="100%" colSpan="2">- Bangunan<span style="mso-spacerun: yes">: Iz</span>in 
						lokasi, IMB, Izin Perluasan dari BKPM/BKPMD, dsb</td>
				</tr>
				<tr>
					<td width="100%" colSpan="2">- Mesin: Izin Perluasan Produksi, Penambahan kapasitas 
						dari BKPM/BKPMD, dsb</td>
				</tr>
				<tr>
					<td style="HEIGHT: 22px" width="100%" colSpan="2">- Lainnya: Sebutkan izin-izin 
						yang relevan</td>
				</tr>
				<tr>
					<td style="HEIGHT: 94px" width="100%" colSpan="2">
						<table width="100%" border="1">
							<tr>
								<td class="tdSmallHeader" width="10%">No.</td>
								<td class="tdSmallHeader" width="30%">Surat izin dari</td>
								<td class="tdSmallHeader" width="27%">No. Surat</td>
								<td class="tdSmallHeader" width="33%">Keterangan</td>
							</tr>
							<tr>
								<td style="HEIGHT: 26px" width="10%"><asp:textbox id="txt_IZIN_NO" runat="server" Width="100%" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
								<td style="HEIGHT: 26px" width="30%"><asp:textbox onkeypress="return kutip_satu()" id="txt_IZIN_SURATIZINDARI" runat="server" Width="100%"
										MaxLength="50"></asp:textbox></td>
								<td style="HEIGHT: 26px" width="27%"><asp:textbox onkeypress="return kutip_satu()" id="txt_IZIN_NOSURAT" runat="server" Width="100%"
										MaxLength="20"></asp:textbox></td>
								<td style="HEIGHT: 26px" width="33%"><asp:textbox onkeypress="return kutip_satu()" id="txt_IZIN_KETERANGAN" runat="server" Width="100%"
										MaxLength="50"></asp:textbox></td>
							</tr>
							<tr>
								<td class="TDBGColor2" style="HEIGHT: 2px" align="center" width="10%" colSpan="4"><asp:button id="btn_AddIzin" runat="server" Text="Save Perizinan" CssClass="Button1" onclick="btn_AddIzin_Click"></asp:button>&nbsp;
									<asp:button id="btn_IzinCancel" runat="server" Text="Cancel" CssClass="Button1" onclick="btn_IzinCancel_Click"></asp:button></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td width="100%" colSpan="2"><asp:datagrid id="dg_Izin" runat="server" Width="100%" PageSize="5" AutoGenerateColumns="False">
							<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
							<Columns>
								<asp:BoundColumn DataField="IZIN_NO" HeaderText="No.">
									<HeaderStyle HorizontalAlign="Center" Width="8%" CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="IZIN_SURATIZINDARI" HeaderText="Surat Izin dari">
									<HeaderStyle HorizontalAlign="Center" Width="30%" CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="IZIN_NOSURAT" HeaderText="No. Surat">
									<HeaderStyle HorizontalAlign="Center" Width="27%" CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="IZIN_KETERANGAN" HeaderText="Keterangan">
									<HeaderStyle HorizontalAlign="Center" Width="37%" CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:ButtonColumn Text="Edit" CommandName="edit">
									<HeaderStyle Width="1%"></HeaderStyle>
								</asp:ButtonColumn>
								<asp:ButtonColumn Text="Delete" CommandName="delete">
									<HeaderStyle Width="1%"></HeaderStyle>
								</asp:ButtonColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid></td>
				</tr>
				<TR>
					<TD width="100%" colSpan="2"></TD>
				</TR>
				<tr>
					<td class="tdSmallHeader" width="100%" colSpan="2">4. Daftar Pembiayaan Investasi</td>
				</tr>
				<tr>
					<td style="HEIGHT: 22px" width="106%">Nasabah menyerahkan rencana anggaran/daftar 
						pembiayaan</td>
					<td style="HEIGHT: 22px" width="1%"><asp:dropdownlist id="ddl_AT_PEMBIAYAANINVESTASI" runat="server" Width="100%">
							<asp:ListItem Value="0">Ya</asp:ListItem>
							<asp:ListItem Value="1">Tidak</asp:ListItem>
						</asp:dropdownlist></td>
				</tr>
				<tr>
					<td width="100%" colSpan="2"></td>
				</tr>
				<tr>
					<td width="100%" colSpan="2">
						<table width="100%" border="1">
							<tr>
								<td class="tdSmallHeader" width="9%">No.</td>
								<td class="tdSmallHeader" width="51%">Jenis Biaya</td>
								<td class="tdSmallHeader" style="WIDTH: 185px" width="185">Nilai Investasi</td>
								<td class="tdSmallHeader" width="20%">
									<P>Nilai yg Diterima</P>
								</td>
							</tr>
							<tr>
								<td width="9%"><asp:textbox id="txt_INVES_NO" runat="server" Enabled="False" Width="100%" BackColor="Gainsboro"></asp:textbox></td>
								<td width="51%"><asp:textbox onkeypress="return kutip_satu()" id="txt_INVES_JNSBIAYA" runat="server" Width="100%"
										MaxLength="50"></asp:textbox></td>
								<td width="20%"><asp:textbox onkeypress="return digitsonly()" id="txt_INVES_NILAIBIAYA" onblur="FormatCurrency(this)"
										runat="server" Width="100%" MaxLength="12"></asp:textbox></td>
								<td width="20%"><asp:textbox onkeypress="return digitsonly()" id="txt_INVES_NILADITERIMA" onblur="FormatCurrency(this)"
										runat="server" Width="100%" MaxLength="12"></asp:textbox></td>
							</tr>
							<tr class="TblAlternating">
								<td class="TDBGColor2" style="HEIGHT: 16px" width="9%" colSpan="4"><asp:button id="btn_AddInves" runat="server" Text="Save Investasi" CssClass="Button1" onclick="btn_AddInves_Click"></asp:button>&nbsp;
									<asp:button id="btn_InvesCancel" runat="server" Text="Cancel" CssClass="Button1" onclick="btn_InvesCancel_Click"></asp:button></td>
							</tr>
							<TR>
								<TD style="HEIGHT: 10px" width="9%" colSpan="4"></TD>
							</TR>
							<TR>
								<TD class="tdSmallHeader" style="HEIGHT: 38px" width="9%" colSpan="4">Rincian 
									Investasi (Rp. 000)</TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 153px" width="9%" colSpan="4"><asp:datagrid id="dg_Inves" runat="server" Width="100%" PageSize="5" AutoGenerateColumns="False">
										<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
										<Columns>
											<asp:BoundColumn DataField="INVES_NO" HeaderText="No.">
												<HeaderStyle HorizontalAlign="Center" Width="7px" CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="INVES_JNSBIAYA" HeaderText="Jenis Biaya">
												<HeaderStyle HorizontalAlign="Center" Width="51%" CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="INVES_NILAIBIAYA" HeaderText="Nilai Investasi" DataFormatString="{0:00,00.00}">
												<HeaderStyle HorizontalAlign="Center" Width="20%" CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="INVES_NILADITERIMA" HeaderText="Nilai yg Diterima" DataFormatString="{0:00,00.00}">
												<HeaderStyle HorizontalAlign="Center" Width="20%" CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:ButtonColumn Text="Edit" CommandName="edit">
												<HeaderStyle Width="1%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:ButtonColumn>
											<asp:ButtonColumn Text="Delete" CommandName="delete">
												<HeaderStyle Width="1%"></HeaderStyle>
											</asp:ButtonColumn>
										</Columns>
										<PagerStyle Mode="NumericPages"></PagerStyle>
									</asp:datagrid>
									<TABLE id="Table1" width="100%" border="1">
										<TR>
											<TD width="7%"></TD>
											<TD class="TDBGColor" width="48%"><STRONG>Total Investasi menurut nasabah</STRONG></TD>
											<TD width="18%"><asp:textbox id="txt_TotInves" style="TEXT-ALIGN: right" runat="server" Width="100%" BackColor="Gainsboro"
													ReadOnly="True"></asp:textbox></TD>
											<TD width="18%"></TD>
											<TD width="7%"></TD>
										</TR>
										<TR>
											<TD></TD>
											<TD class="TDBGColor"><STRONG>Total Investasi yang diterima Bank</STRONG></TD>
											<TD></TD>
											<TD><asp:textbox id="txt_TotDiterima" style="TEXT-ALIGN: right" runat="server" Width="100%" BackColor="Gainsboro"
													ReadOnly="True"></asp:textbox></TD>
											<TD></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</table>
					</td>
				</tr>
				<tr>
					<td class="tdSmallHeader" width="100%" colSpan="2">5. Rencana</td>
				</tr>
				<tr>
					<td width="79%">Rencana Penarikan kredit, penerimaan, pembelanjaan termijn, 
						angsuran bunga dan pelunasan kredit, dll. diproyeksikan dalam cash flow 
						terlampir</td>
					<td width="21%"><asp:dropdownlist id="ddl_AT_RENCANA" runat="server" Width="100%">
							<asp:ListItem Value="0">Ya</asp:ListItem>
							<asp:ListItem Value="1">Tidak</asp:ListItem>
						</asp:dropdownlist></td>
				</tr>
				<TR>
					<TD class="tdSmallHeader" width="79%" colSpan="2">Catatan</TD>
				</TR>
				<TR>
					<TD width="79%" colSpan="2"><asp:textbox onkeypress="return kutip_satu()" id="txt_AT_NOTE" runat="server" Height="50px" TextMode="MultiLine"
							Width="100%" MaxLength="500"></asp:textbox></TD>
				</TR>
				<TR>
					<TD class="TDBGColor2" width="79%" colSpan="2"><asp:button id="btn_Save" runat="server" Text="Save" CssClass="Button1" onclick="btn_Save_Click"></asp:button>&nbsp;
						<asp:button id="btn_Delete" runat="server" Text="Delete" CssClass="Button1" onclick="btn_Delete_Click"></asp:button></TD>
				</TR>
			</table>
		</form>
	</body>
</HTML>
