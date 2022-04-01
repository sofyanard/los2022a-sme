<%@ Page language="c#" Codebehind="PengikatanAgunan_Main.aspx.cs" AutoEventWireup="True" Inherits="SME.CreditProposal.PengikatanAgunan_Main" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Surat Perintah ke Notaris untuk Pengikatan</title>
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
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD style="WIDTH: 115px" align="center"></TD>
						<TD align="center" style="WIDTH: 550px"><INPUT id="BTN_PRINT1" style="WIDTH: 75px; HEIGHT: 24px" onclick="print_frame();" type="button"
								value="Print" name="BTNCANCEL" class="button1">&nbsp;<INPUT id="BTN_CANCEL" style="WIDTH: 75px; HEIGHT: 24px" onclick="javascript:history.back(-1)"
								type="button" value="Cancel" name="Button1" class="button1">&nbsp;<INPUT id="BTN_CLOSE" style="WIDTH: 75px; HEIGHT: 24px" onclick="javascript:window.close();"
								type="button" value="Close" name="Button1" class="button1"><FONT face="Tahoma"></FONT></TD>
						<TD align="center"></TD>
					</TR>
					<tr>
						<TD style="WIDTH: 111px"></TD>
						<td style="WIDTH: 550px" align="center"><FONT face="Tahoma">
								<asp:PlaceHolder id="PH1" runat="server"></asp:PlaceHolder></FONT></td>
						<TD></TD>
					</tr>
					<TR>
						<TD style="WIDTH: 111px" align="center"></TD>
						<TD align="center" style="VISIBILITY: hidden; WIDTH: 550px">&nbsp;
							<asp:TextBox id="TXT_NO_SURAT" runat="server" Font-Size="X-Small" ForeColor="Blue" Font-Names="Tahoma"
								Height="22px" Width="20px">JNK.JCO/JCCO.V</asp:TextBox>
							<asp:TextBox id="TXT_TANGGAL" runat="server" Font-Size="X-Small" ForeColor="Blue" Font-Names="Tahoma"
								Height="22px" Width="20px" ReadOnly="True" BorderColor="Black">17 June 2003</asp:TextBox>
							<asp:TextBox id="TXT_LAMPIRAN1" runat="server" Font-Size="X-Small" ForeColor="Blue" Font-Names="Tahoma"
								Height="22px" Width="20px">-</asp:TextBox>
							<asp:TextBox id="TXT_NAMA_NOTARIS" runat="server" Font-Size="X-Small" ForeColor="Blue" Font-Names="Tahoma"
								Height="22px" Width="20px" ReadOnly="True" BorderColor="Black">Notaris Lenny Janis Isbak, SH</asp:TextBox>
							<asp:TextBox id="TXT_ALAMAT1_NOTARIS" runat="server" Font-Size="X-Small" ForeColor="Blue" Font-Names="Tahoma"
								Height="22px" Width="20px" ReadOnly="True" BorderColor="Black">Ratu Plaza Office Tower Lt. 20</asp:TextBox>
							<asp:TextBox id="TXT_ALAMAT2_NOTARIS" runat="server" Font-Size="X-Small" ForeColor="Blue" Font-Names="Tahoma"
								Height="22px" Width="20px" ReadOnly="True" BorderColor="Black">Jl. Jend. Sudirman 9</asp:TextBox>
							<asp:TextBox id="TXT_ALAMAT3_NOTARIS" runat="server" Font-Size="X-Small" ForeColor="Blue" Font-Names="Tahoma"
								Height="22px" Width="20px" ReadOnly="True" BorderColor="Black">Jakarta 10270</asp:TextBox>
							<asp:TextBox id="TXT_TELP_NOTARIS" runat="server" Font-Size="X-Small" ForeColor="Blue" Font-Names="Tahoma"
								Height="22px" Width="20px" ReadOnly="True" BorderColor="Black">Telp/Fax. 101010101</asp:TextBox>
							<asp:TextBox id="TXT_NAMA_DEBITUR" runat="server" Font-Size="X-Small" ForeColor="Blue" Font-Names="Tahoma"
								Height="22px" Width="20px" ReadOnly="True" BorderColor="Black"></asp:TextBox>
							<asp:TextBox id="TXT_AN" runat="server" Font-Size="X-Small" ForeColor="Blue" Font-Names="Tahoma"
								Height="22px" Width="20px">Haji Taufik Noer, SE</asp:TextBox>
							<asp:TextBox id="TXT_DIIKAT" runat="server" Font-Size="X-Small" ForeColor="Blue" Font-Names="Tahoma"
								Height="20px" Width="20px">SHM No. 1348</asp:TextBox><FONT size="2">
								<asp:TextBox id="TXT_HAK_TANGGUNG" runat="server" Font-Size="X-Small" ForeColor="Blue" Font-Names="Tahoma"
									Height="22px" Width="20px">Hak Tanggungan Peringkat I (Pertama)</asp:TextBox></FONT>
							<asp:TextBox id="TXT_JUMLAH_IKAT" runat="server" Font-Size="X-Small" ForeColor="Blue" Font-Names="Tahoma"
								Height="22px" Width="20px">175.000.000</asp:TextBox>
							<asp:TextBox id="TXT_JCCO" runat="server" Font-Size="X-Small" ForeColor="Blue" Font-Names="Tahoma"
								Height="22px" Width="20px">JCCO.V Jakarta Sudirman</asp:TextBox>
							<asp:TextBox id="TXT_JUMLAH_IKAT_TERBILANG" runat="server" Font-Size="X-Small" ForeColor="Blue"
								Font-Names="Tahoma" Height="22px" Width="20px">Seratus tujuh puluh lima ribu</asp:TextBox>
							<asp:TextBox id="TXT_LAMPIRAN" runat="server" Font-Size="X-Small" ForeColor="Blue" Font-Names="Tahoma"
								Height="20px" Width="20px" TextMode="MultiLine"></asp:TextBox>
							<asp:TextBox id="TXT_CP_BM" runat="server" Font-Size="X-Small" ForeColor="Blue" Font-Names="Tahoma"
								Height="22px" Width="20px">Sdr. Daryanto</asp:TextBox>
							<asp:TextBox id="TXT_TLP_CP_BM" runat="server" Font-Size="X-Small" ForeColor="Blue" Font-Names="Tahoma"
								Height="22px" Width="20px">5266566 ext. 1229</asp:TextBox><STRONG><FONT face="Georgia" size="2"><EM>
										<asp:TextBox id="TXT_JCCO_TTD" runat="server" Font-Size="X-Small" ForeColor="Blue" Font-Names="Tahoma"
											Height="22px" Width="20px">Jakarta City Credit Operation</asp:TextBox></EM></FONT></STRONG><STRONG><FONT face="Georgia" size="2"><EM>
										<asp:TextBox id="TXT_ALAMAT_JCCO_TTD" runat="server" Font-Size="X-Small" ForeColor="Blue" Font-Names="Tahoma"
											Height="22px" Width="20px">Jakarta Sudirman</asp:TextBox></EM></FONT></STRONG><STRONG><U><FONT face="Georgia" size="2"><EM>
											<asp:TextBox id="TXT_NAMA_TTD" runat="server" Font-Size="X-Small" ForeColor="Blue" Font-Names="Tahoma"
												Height="22px" Width="20px" Font-Underline="True">Suparta</asp:TextBox></EM></FONT></U></STRONG><STRONG><FONT face="Georgia" size="2"><EM>
										<asp:TextBox id="TXT_DEPT_TTD" runat="server" Font-Size="X-Small" ForeColor="Blue" Font-Names="Tahoma"
											Height="22px" Width="20px">Department Head</asp:TextBox></EM></FONT></STRONG><FONT face="Tahoma"></FONT></TD>
						<TD align="center"></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
