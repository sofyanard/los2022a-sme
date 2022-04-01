<%@ Page language="c#" Codebehind="PenugasanAgunan_Main.aspx.cs" AutoEventWireup="True" Inherits="SME.CreditProposal.PenugasaAgunan_Main" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Surat Penugasan Agunan</title>
		<script language="javascript">
function print_frame() {
	window.parent.if1.focus();
	window.print();
}
		</script>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="TDBGColor2" style="WIDTH: 115px" align="center"></TD>
						<TD align="center" style="WIDTH: 529px"><INPUT id="BTN_PRINT" style="WIDTH: 101px; HEIGHT: 24px" onclick="javascript:window.print();"
								type="button" value="Print" name="BTNCANCEL">&nbsp;<INPUT id="BTNCANCEL" style="WIDTH: 101px; HEIGHT: 24px" type="button" value="Cancel" onclick="javascript:history.back(-1)">&nbsp;<INPUT id="BTN_CLOSE" style="WIDTH: 101px; HEIGHT: 24px" onclick="javascript:window.close();"
								type="button" value="Close" name="Button1"></TD>
						<TD class="TDBGColor2" align="center"></TD>
					</TR>
					<tr>
						<TD style="WIDTH: 111px"></TD>
						<td style="WIDTH: 529px" align="center">
							<asp:PlaceHolder id="PH1" runat="server"></asp:PlaceHolder></td>
						<TD></TD>
					</tr>
					<TR>
						<TD class="TDBGColor2" style="WIDTH: 111px" align="center"></TD>
						<TD align="center" style="VISIBILITY: hidden; WIDTH: 529px">
							<asp:TextBox id="TXT_NO_SURAT" runat="server" Height="21px" Font-Names="Tahoma" Font-Size="X-Small"
								ForeColor="Blue" Width="20px">DNW.JCK.JCO/            /2003</asp:TextBox>
							<asp:TextBox id="TXT_TANGGAL" runat="server" Height="21px" Font-Names="Tahoma" Font-Size="X-Small"
								ForeColor="Blue" Width="20px" ReadOnly="True" BorderColor="Black"></asp:TextBox>
							<asp:TextBox id="TXT_LAMPIRAN" runat="server" Height="22px" Font-Names="Tahoma" Font-Size="X-Small"
								ForeColor="Blue" Width="20px">-</asp:TextBox>
							<asp:TextBox id="TXT_NAMA_APPRAISER" runat="server" Height="21px" Font-Names="Tahoma" Font-Size="X-Small"
								ForeColor="Blue" Width="20px" ReadOnly="True" BorderColor="Black"></asp:TextBox>
							<asp:TextBox id="TXT_ALAMAT1_APPRAISER" runat="server" Height="20px" Font-Names="Tahoma" Font-Size="X-Small"
								ForeColor="Blue" Width="20px" ReadOnly="True" BorderColor="Black"></asp:TextBox>
							<asp:TextBox id="TXT_ALAMAT2_APPRAISER" runat="server" Height="20px" Font-Names="Tahoma" Font-Size="X-Small"
								ForeColor="Blue" Width="20px" ReadOnly="True" BorderColor="Black"></asp:TextBox>
							<asp:TextBox id="TXT_ALAMAT3_APPRAISER" runat="server" Height="20px" Font-Names="Tahoma" Font-Size="X-Small"
								ForeColor="Blue" Width="20px" ReadOnly="True" BorderColor="Black"></asp:TextBox>
							<asp:TextBox id="TXT_TELP_APPRAISER" runat="server" Height="20px" Font-Names="Tahoma" Font-Size="X-Small"
								ForeColor="Blue" Width="20px" ReadOnly="True" BorderColor="Black"> Telp/Fax.</asp:TextBox>
							<asp:TextBox id="TXT_UP" runat="server" Height="21px" Font-Names="Tahoma" Font-Size="X-Small"
								ForeColor="Blue" Width="20px" ReadOnly="True" BorderColor="Black">Bpk. Ir. Okky Danuza M.Sc/Direktur</asp:TextBox>
							<asp:TextBox id="TXT_PERIHAL" runat="server" Height="21px" Font-Names="Tahoma" Font-Size="X-Small"
								ForeColor="Blue" Width="20px">Pelaksanaan Kerja Penilaian Agunan Kredit (calon) Debitur Bank Mandiri</asp:TextBox>
							<asp:TextBox id="TXT_NO_SURAT_REF" runat="server" Height="21px" Font-Names="Tahoma" Font-Size="X-Small"
								ForeColor="Blue" Width="20px">198/SP/PP-PFF/VI/2003</asp:TextBox>
							<asp:TextBox id="TXT_TGL_SURAT_REF" runat="server" Height="21px" Font-Names="Tahoma" Font-Size="X-Small"
								ForeColor="Blue" Width="20px">4 Juni 2003</asp:TextBox>
							<asp:TextBox id="TXT_WAKTU_BAYAR_BILANG" runat="server" Height="21px" Font-Names="Tahoma" Font-Size="X-Small"
								ForeColor="Blue" Width="20px">dua</asp:TextBox>
							<asp:TextBox id="TXT_WAKTU_BAYAR" runat="server" Height="21px" Font-Names="Tahoma" Font-Size="X-Small"
								ForeColor="Blue" Width="20px">2</asp:TextBox>
							<asp:TextBox id="TXT_JUMLAH_COLL" runat="server" Height="21px" Font-Names="Tahoma" Font-Size="X-Small"
								ForeColor="Blue" Width="20px">1</asp:TextBox><FONT size="2">
								<asp:TextBox id="TXT_NAMA_COLLATERAL" runat="server" Height="21px" Font-Names="Tahoma" Font-Size="X-Small"
									ForeColor="Blue" Width="20px" ReadOnly="True" BorderColor="Black">Tanah/Bangunan/Rumah</asp:TextBox></FONT>
							<asp:TextBox id="TXT_WAKTU_LAPORAN_BILANG" runat="server" Height="21px" Font-Names="Tahoma" Font-Size="X-Small"
								ForeColor="Blue" Width="20px">enam</asp:TextBox>
							<asp:TextBox id="TXT_WAKTU_LAPORAN" runat="server" Height="21px" Font-Names="Tahoma" Font-Size="X-Small"
								ForeColor="Blue" Width="20px">6</asp:TextBox><FONT size="2">
								<asp:TextBox id="TXT_NAMA_COLL_FEE" runat="server" Height="21px" Font-Names="Tahoma" Font-Size="X-Small"
									ForeColor="Blue" Width="20px" ReadOnly="True" BorderColor="Black">Tanah/Bangunan/Rumah</asp:TextBox></FONT>
							<asp:TextBox id="TXT_COLL_FEE" runat="server" Height="21px" Font-Names="Tahoma" Font-Size="X-Small"
								ForeColor="Blue" Width="20px"></asp:TextBox><STRONG><FONT face="Georgia" size="2"><EM>
										<asp:TextBox id="TXT_JCCO_TTD" runat="server" Height="21px" Font-Names="Tahoma" Font-Size="X-Small"
											ForeColor="Blue" Width="20px">Jakarta City Operations</asp:TextBox></EM></FONT></STRONG><STRONG><FONT face="Georgia" size="2"><EM>
										<asp:TextBox id="TXT_ALAMAT_JCCO_TTD" runat="server" Height="21px" Font-Names="Tahoma" Font-Size="X-Small"
											ForeColor="Blue" Width="20px">Jakarta Sudirman</asp:TextBox></EM></FONT></STRONG><STRONG><U><FONT face="Georgia" size="2"><EM>
											<asp:TextBox id="TXT_NAMA_TTD" runat="server" Height="21px" Font-Names="Tahoma" Font-Size="X-Small"
												ForeColor="Blue" Width="20px" Font-Underline="True">Basu Fitri Manugrahani</asp:TextBox></EM></FONT></U></STRONG><STRONG><FONT face="Georgia" size="2"><EM>
										<asp:TextBox id="TXT_DEPT_TTD" runat="server" Height="21px" Font-Names="Tahoma" Font-Size="X-Small"
											ForeColor="Blue" Width="20px">JCO Manager</asp:TextBox></EM></FONT></STRONG></TD>
						<TD class="TDBGColor2" align="center"></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
