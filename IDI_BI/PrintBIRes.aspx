<%@ Page language="c#" Codebehind="PrintBIRes.aspx.cs" AutoEventWireup="True" Inherits="SME.IDI_BI.PrintBIRes" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PrintBIRes</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../Style.css" type="text/css" rel="stylesheet">
		<script language="javascript">
function print_frame() {
	//window.parent.framelkkn.focus();
	tr_print.style.display = "none";
	window.print();
	tr_print.style.display = "";
}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table4" width="100%" border="0">
					<tr>
						<td>
							<table width="100%">
								<tr id="tr_print" align="center">
									<td width="3%" colSpan="2"><INPUT class="button1" id="BTN_PRINT" onclick="print_frame();" type="button" value="Print"
											name="BTN_PRINT"><INPUT class="button1" id="BTN_BACK" onclick="javascript:history.back();" type="button"
											value="Back" name="BTN_BACK">
									</td>
								</tr>
								<tr>
									<td></td>
								</tr>
								<tr align="center">
									<td class="td" colSpan="2"><STRONG>IDI BI RESULT</STRONG></td>
								</tr>
								<tr>
									<td class="td">
										<table width="100%">
											<tr>
												<td width="30%">IDI REQUEST #</td>
												<td width="2%">:</td>
												<td style="WIDTH: 208px" width="208"><asp:label id="LBL_IDI_REQ" Runat="server"></asp:label></td>
											</tr>
											<tr>
												<td width="30%">DATE</td>
												<td width="2%">:</td>
												<td style="WIDTH: 208px" width="208"><asp:label id="LBL_DATE" Runat="server"></asp:label></td>
											</tr>
										</table>
									</td>
								</tr>
							</table>
						</td>
					</tr>
				</TABLE>
				<table width="100%">
					<TR>
						<TD class="td" style="WIDTH: 675px; HEIGHT: 21px" vAlign="top" width="675"><FONT size="2"><STRONG>A. 
									DATA KREDIT</STRONG></FONT>
						</TD>
					</TR>
					<TR>
						<TD colSpan="2"><ASP:DATAGRID id="DGR_DATAKREDIT" runat="server" AutoGenerateColumns="False" CellPadding="1" Width="100%">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="idi_custname" HeaderText="Nama">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="IDI_ADDRESS" HeaderText="Alamat">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="IDI_BANK" HeaderText="Bank">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="IDI_JENISKREDIT" HeaderText="Jenis Kredit">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="IDI_ACC" HeaderText="Rekening">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="IDI_ACC_CURR" HeaderText="Mata Uang">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="IDI_ACC_LIMIT" HeaderText="Limit">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="IDI_OS" HeaderText="Baki Debet">
										<HeaderStyle Width="13%" CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="IDI_TUNGGAKAN" HeaderText="Tunggakan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="IDI_SIFAT" HeaderText="Sifat Kredit">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="IDI_PENGGUNAAN" HeaderText="Jenis Penggunaan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="IDI_PKDATE" HeaderText="Tgl.PK">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="IDI_KOLEK" HeaderText="Kolek">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="IDI_COLLATERAL" HeaderText="Jaminan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
					<tr>
						<td></td>
					</tr>
				</table>
				<table width="100%">
					<TR>
						<TD class="td" style="WIDTH: 675px" vAlign="top" width="675"><STRONG><FONT size="2">B. DATA 
									AGUNAN</FONT></STRONG>
						</TD>
					</TR>
					<TR>
						<TD colSpan="2"><ASP:DATAGRID id="DGR_DATAAGUNAN" runat="server" AutoGenerateColumns="False" CellPadding="1" Width="100%">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="idi_custname" HeaderText="Nama">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="IDI_ADDRESS" HeaderText="Alamat">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="idi_coll_TYPE" HeaderText="Jenis Agunan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="IDI_COLL_SIZE" HeaderText="Ukuran">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="IDI_COLL_LOC" HeaderText="Lokasi">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="IDI_COLL_OWNER" HeaderText="No.Bukti Kepemilikan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="IDI_COLL_OWNDATE" HeaderText="Tgl.Bukti">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="IDI_COLL_PLEDGE" HeaderText="Pengikatan">
										<HeaderStyle Width="13%" CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="IDI_COLL_CURR" HeaderText="Mata Uang">
										<HeaderStyle Width="13%" CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="IDI_APP_VALUE" HeaderText="Nilai Transaksi">
										<HeaderStyle Width="13%" CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="IDI_APP_DATE" HeaderText="Tgl. Penilaian">
										<HeaderStyle Width="13%" CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="IDI_COLL#" HeaderText="No. Referensi">
										<HeaderStyle Width="13%" CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
					<tr>
						<td></td>
					</tr>
					<TR>
						<TD class="td" style="WIDTH: 675px" vAlign="top" width="675"><STRONG><FONT size="2">C. DATA 
									IRREVOCABLE L/C</FONT></STRONG>
						</TD>
					</TR>
					<TR>
						<TD colSpan="2"><ASP:DATAGRID id="DGR_IRR" runat="server" AutoGenerateColumns="False" CellPadding="1" Width="100%">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn HeaderText="Nama" DataField="idi_custname">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="Alamat" DataField="IDI_ADDRESS">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="Bank" DataField="IDI_BANK">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="Jenis LC" DataField="IDI_JENISLC">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="No.LC" DataField="IDI_LC_NO">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="Valuta" DataField="IDI_LC_CURR">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="Set Jaminan" DataField="IDI_SETJAM">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="Plafond" DataField="IDI_LC_LIMIT">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="Nominal" DataField="IDI_LC_NOM">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="Bank Penerbit LC" DataField="IDI_LC_BANK">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="Tgl. Terbit" DataField="IDI_LC_START_DATE">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="Jatuh Tempo" DataField="IDI_LC_DUE_DATE">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="Tgl Wan Prestasi" DataField="IDI_LC_WAN_DATE">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="Kolek" DataField="IDI_LC_KOLEK">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
					<tr>
						<td></td>
					</tr>
					<TR>
						<TD class="td" style="WIDTH: 675px" vAlign="top" width="675"><STRONG><FONT size="2">D. DATA 
									BANK GARANSI</FONT></STRONG>
						</TD>
					</TR>
					<TR>
						<TD colSpan="2"><ASP:DATAGRID id="DGR_BG" runat="server" AutoGenerateColumns="False" CellPadding="1" Width="100%">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn HeaderText="Nama" DataField="idi_custname">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="Alamat" DataField="IDI_ADDRESS">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="Bank" DataField="IDI_BANK">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="Jenis BG" DataField="IDI_BG_JENIS">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="No.BG" DataField="IDI_BG_NO">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="Valuta" DataField="IDI_BG_CURR">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="Set Jaminan" DataField="IDI_SETJAM">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="Plafond" DataField="IDI_BG_LIMIT">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="Nominal" DataField="IDI_BG_NOM">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="Yg Dijamin" DataField="IDI_BG_JAMIN">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="Tgl. Terbit" DataField="IDI_BG_START_DATE">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="Jatuh Tempo" DataField="IDI_BG_DUE_DATE">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="Tgl Wan Prestasi" DataField="IDI_BG_WAN_DATE">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="Kolek" DataField="IDI_BG_KOLEK">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
					<TR>
						<TD class="td" style="WIDTH: 675px" vAlign="top" width="675"><STRONG><FONT size="2"> BANK 
									INDONESIA</FONT></STRONG>
						</TD>
					</TR>
					<tr>
						<td class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						</td>
					</tr>
					<TR>
					</TR>
				</table>
			</center>
		</form>
		</TD></TR></TABLE></FORM>
	</body>
</HTML>
