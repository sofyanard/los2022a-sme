<%@ Page language="c#" Codebehind="PrintWorksheet.aspx.cs" AutoEventWireup="True" Inherits="SME.CEA.PrintWorksheet" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PrintWorksheet</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_entries.html" -->
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
			<table id="Table1" width="30%" cellSpacing="0" cellPadding="1">
				<tr align="center">
					<td class="td">NOTA</td>
				</tr>
				<tr>
					<td>
						<table cellSpacing="0" cellPadding="0" width="100%">
							<tr>
								<td width="20%">Nomor</td>
								<td width="5%">:</td>
								<td>FST.PSP/GH.<asp:textbox id="Textbox2" Width="40px" Runat="server"></asp:textbox>&nbsp;/&nbsp;<asp:textbox id="Textbox4" Width="40px" Runat="server"></asp:textbox></td>
							</tr>
							<tr>
								<td width="20%">Tanggal</td>
								<td width="5%">:</td>
								<td><asp:textbox id="TXT_TGL" Width="40px" Runat="server" MaxLength="2"></asp:textbox>&nbsp;<asp:textbox id="TXT_BLN" Width="80px" Runat="server" MaxLength="10"></asp:textbox>&nbsp;<asp:textbox id="Textbox1" Width="40px" Runat="server" MaxLength="4"></asp:textbox></td>
							</tr>
							<tr>
								<td width="20%">Lampiran</td>
								<td width="5%">:</td>
								<td><asp:textbox id="Textbox3" Width="144px" Runat="server"></asp:textbox></td>
							</tr>
							<tr>
								<td width="20%"></td>
								<td width="5%"></td>
								<td></td>
							</tr>
							<tr>
								<td width="20%">Kepada</td>
								<td width="5%">:</td>
								<td>IT Planning, Architecture &amp; BCP Group</td>
							</tr>
							<tr>
								<td width="20%">Dari</td>
								<td width="5%">:</td>
								<td>Policy, System &amp; Procedure Group</td>
							</tr>
							<tr>
								<td width="20%"></td>
								<td width="5%"></td>
								<td></td>
							</tr>
							<tr>
								<td width="20%">Perihal</td>
								<td width="5%">:</td>
								<td>
									Penambahan Parameter
									<asp:label id="LBL_PERIHAL" Runat="server" Text="Notaris"></asp:label>&nbsp;pada 
									eMAS</td>
							</tr>
							<tr>
								<td width="20%"></td>
								<td width="5%"></td>
								<td></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td>
						<table width="100%">
							<tr>
								<td>
									<p>Kami mohon bantuan Saudara untuk menambahkan parameter tersebut di atas dengan 
										rincian sebagai berikut:</p>
								</td>
							</tr>
							<tr>
								<td class="td">
									<table style="WIDTH: 568px; HEIGHT: 25px" align="center">
										<tr>
											<td style="WIDTH: 40px" align="center" width="40" class="td">No
											</td>
											<td style="WIDTH: 208px" width="208" class="td">Nama &nbsp;<asp:label id="LBL_PERIHAL2" Runat="server" text="Notaris"></asp:label></td>
											<td width="50%" class="td">Alamat</td>
										</tr>
										<tr>
											<td style="WIDTH: 40px" align="center" width="40" class="td">1.
											</td>
											<td class="td" style="WIDTH: 208px" width="208"><asp:label id="LBL_NAMA" Runat="server" text="Rosaline"></asp:label></td>
											<td class="td" width="50%"><asp:label id="LBL_ALAMAT" Runat="server" text="Jl. Kemang Utara I No. 2A Jakarta Selatan"></asp:label></td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td>
									<p>Demikian kami sampaikan, terima kasih atas kerja samanya.</p>
									<p>Policy, System &amp; Procedure Group</p>
									<p style="TEXT-DECORATION: underline">Setyowati</p>
								</td>
							</tr>
							<tr id="tr_GH">
								<td>Group Head</td>
							</tr>
							<tr id="tr_print" align="center">
								<td width="3%" colSpan="2"><INPUT class="button1" id="BTN_PRINT" onclick="print_frame();" type="button" value="Print"
										name="BTN_PRINT"><INPUT class="button1" id="BTN_BACK" onclick="javascript:history.back();" type="button"
										value="Back" name="BTN_BACK">
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
