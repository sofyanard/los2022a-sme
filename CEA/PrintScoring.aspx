<%@ Page language="c#" Codebehind="PrintScoring.aspx.cs" AutoEventWireup="True" Inherits="SME.CEA.PrintScoring" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PrintScoring</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
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
									<td class="td" colSpan="2"><STRONG>LAPORAN HASIL SCORING</STRONG></td>
								</tr>
								<tr>
									<td class="td">
										<table width="100%">
											<tr>
												<td width="30%">No. Registrasi</td>
												<td width="2%">:</td>
												<td style="WIDTH: 208px" width="208"><asp:label id="LBL_REKANAN_REF" Runat="server"></asp:label></td>
											</tr>
											<tr>
												<td width="30%">No. Aplikasi</td>
												<td width="2%">:</td>
												<td style="WIDTH: 208px" width="208"><asp:label id="LBL_REGNUM" Runat="server"></asp:label></td>
											</tr>
											<tr>
												<td width="30%">Nama Rekanan</td>
												<td width="2%">:</td>
												<td style="WIDTH: 208px" width="208"><asp:label id="LBL_NAMA" Runat="server"></asp:label></td>
											</tr>
											<tr>
												<td width="30%">Jenis Rekanan</td>
												<td width="2%">:</td>
												<td style="WIDTH: 208px" width="208"><asp:label id="LBL_JENIS_REKANAN" Runat="server"></asp:label></td>
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
						<TD class="td" style="WIDTH: 675px" vAlign="top" width="675"><FONT size="2"><STRONG>1. 
									Aspek Penilaian Kuantitatif</STRONG></FONT>
						</TD>
					</TR>
					<TR width="100%">
						<TD colSpan="2"><ASP:DATAGRID id="DGR_QUAN" runat="server" AutoGenerateColumns="False" CellPadding="1" Width="100%">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="QUANTITATIVEID"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="SUBQUANTITATIVEID"></asp:BoundColumn>
									<asp:BoundColumn DataField="QUANTITATIVEDESC" HeaderText="Quantitative">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="SUBQUANTITATIVEDESC" HeaderText="Sub Quantitative">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="subsubquantitativedesc" HeaderText="Sub Sub Quantitative">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID><asp:label id="LBL_RFREKANANTYPE" runat="server" Visible="False"></asp:label></TD>
					</TR>
					<TR>
						<TD class="TDBGColor1">TOTAL PENILAIAN KUANTITAITF&nbsp;:<asp:textbox id="TXT_TOTAL_QUAN" runat="server" Width="320px" ReadOnly="True"></asp:textbox></TD>
					</TR>
					<tr>
						<td></td>
					</tr>
				</table>
				<table width="100%">
					<TR>
						<TD class="td" style="WIDTH: 675px" vAlign="top" width="675"><STRONG><FONT size="2">2. 
									Aspek Penilaian Kualitatif</FONT></STRONG>
						</TD>
					</TR>
					<TR width="100%">
						<TD colSpan="2"><ASP:DATAGRID id="DGR_QUAL" runat="server" AutoGenerateColumns="False" CellPadding="1" Width="100%"
								PageSize="12" DESIGNTIMEDRAGDROP="466">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="QUALITATIVEID"></asp:BoundColumn>
									<asp:BoundColumn Visible="False"></asp:BoundColumn>
									<asp:BoundColumn DataField="QUALITATIVEDESC" HeaderText="Qualitative">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="SUBQUALITATIVEDESC" HeaderText="Sub Qualitative">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
					<TR>
						<TD class="TDBGColor1">TOTAL PENILAIAN KUALITATIF&nbsp;:<asp:textbox id="TXT_TOTAL_QUAL" runat="server" Width="320px" ReadOnly="True"></asp:textbox></TD>
					</TR>
					<tr>
						<td></td>
					</tr>
					<TR>
						<TD class="td" style="WIDTH: 675px" vAlign="top" width="675"><STRONG><FONT size="2">3. 
									Kriteria Tambahan</FONT></STRONG>
						</TD>
					</TR>
					<tr width="100%">
						<td colSpan="2"><ASP:DATAGRID id="DGR_CLA" runat="server" AutoGenerateColumns="False" CellPadding="1" Width="100%"
								PageSize="12">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="CRITEID"></asp:BoundColumn>
									<asp:BoundColumn Visible="False"></asp:BoundColumn>
									<asp:BoundColumn DataField="CRITEDESC" HeaderText="Kriteria Tambahan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="subcritedesc" HeaderText="Klasifikasi A">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></td>
						</TD></tr>
					<TR>
						<TD class="TDBGColor1">TOTAL&nbsp;:<asp:textbox id="TOTAL_SCORING" runat="server" Width="320px" ReadOnly="True"></asp:textbox></TD>
					</TR>
					<TR>
						<TD class="TDBGColor1">Penetapan Klasifikasi&nbsp;:<asp:textbox id="KLASIFIKASI" runat="server" Width="320px" ReadOnly="True"></asp:textbox></TD>
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
		</TD></TR></TBODY></TABLE>
		<CENTER></CENTER>
		</FORM>
	</body>
</HTML>
