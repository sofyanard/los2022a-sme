<%@ Page language="c#" Codebehind="AsuransiJaminan_Main.aspx.cs" AutoEventWireup="True" Inherits="SME.CreditOperations.CoverNote.AsuransiJaminan_Main" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AsuransiJaminan</title>
		<script language="javascript">
function print_frame() {
	window.parent.if1.focus();
	window.print();
}
		</script>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="1"
				cellPadding="1" width="100%" border="0">
				<TR>
					<TD width="115"></TD>
					<TD align="center">
						<INPUT id="BTN_PRINT" style="WIDTH: 101px; HEIGHT: 24px" onclick="print_frame();" type="button"
							value="Print" name="BTNCANCEL">&nbsp; <INPUT id="BTN_CANCEL" style="WIDTH: 101px; HEIGHT: 24px" onclick="javascript:history.back(-1);"
							type="button" value="Cancel" name="BTNCANCEL">&nbsp; <INPUT id="BTN_CLOSE" style="WIDTH: 101px; HEIGHT: 24px" onclick="javascript:window.close();"
							type="button" value="Close" name="BTNCANCEL"></TD>
					<TD width="115"></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 59px"></TD>
					<TD align="center"></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 59px"></TD>
					<TD align="center">
						<asp:PlaceHolder id="PH" runat="server"></asp:PlaceHolder></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 59px"></TD>
					<TD align="center" style="VISIBILITY: hidden">
						<asp:TextBox id="TXT_NO_SURAT" runat="server" Height="22px" Font-Names="Tahoma" Font-Size="X-Small"
							ForeColor="Blue" Width="10px" Visible="False">JNK.JCO/JCCO V. 4868 /2003</asp:TextBox>
						<asp:TextBox id="TXT_TANGGAL" runat="server" Height="22px" Font-Names="Tahoma" Font-Size="X-Small"
							ForeColor="Blue" Width="10px" ReadOnly="True" BorderStyle="Solid" BorderColor="Black" Visible="False">01 Agustus 2003</asp:TextBox>
						<asp:TextBox id="TXT_LAMPIRAN" runat="server" Height="22px" Font-Names="Tahoma" Font-Size="X-Small"
							ForeColor="Blue" Width="10px" Visible="False">-</asp:TextBox>
						<asp:TextBox id="TXT_NAMA_PT" runat="server" Height="21px" Font-Names="Tahoma" Font-Size="X-Small"
							ForeColor="Blue" Width="10px" ReadOnly="True" BorderStyle="Solid" BorderColor="Black" Visible="False"></asp:TextBox>
						<asp:TextBox id="TXT_ALAMAT1_PT" runat="server" Height="21px" Font-Names="Tahoma" Font-Size="X-Small"
							ForeColor="Blue" Width="10px" ReadOnly="True" BorderStyle="Solid" BorderColor="Black" Visible="False"></asp:TextBox>
						<asp:TextBox id="TXT_ALAMAT2_PT" runat="server" Height="21px" Font-Names="Tahoma" Font-Size="X-Small"
							ForeColor="Blue" Width="10px" ReadOnly="True" BorderStyle="Solid" BorderColor="Black"></asp:TextBox>
						<asp:TextBox id="TXT_ALAMAT3_PT" runat="server" Height="21px" Font-Names="Tahoma" Font-Size="X-Small"
							ForeColor="Blue" Width="10px" ReadOnly="True" BorderStyle="Solid" BorderColor="Black" Visible="False"></asp:TextBox>
						<asp:TextBox id="TXT_TELP_PT" runat="server" Height="21px" Font-Names="Tahoma" Font-Size="X-Small"
							ForeColor="Blue" Width="10px" ReadOnly="True" BorderStyle="Solid" BorderColor="Black" Visible="False"></asp:TextBox>
						<asp:TextBox id="TXT_UP" runat="server" Height="21px" Font-Names="Tahoma" Font-Size="X-Small"
							ForeColor="Blue" Width="10px" ReadOnly="True" BorderStyle="Solid" BorderColor="Black" Visible="False"></asp:TextBox>
						<asp:TextBox id="TXT_DEBITUR" runat="server" Height="21px" Font-Names="Tahoma" Font-Size="X-Small"
							ForeColor="Blue" Width="10px" ReadOnly="True" BorderStyle="Solid" BorderColor="Black" Visible="False"></asp:TextBox><FONT size="2"><FONT size="2">
								<asp:TextBox id="TXT_DEBITUR_NAME" runat="server" Height="21px" Font-Names="Tahoma" Font-Size="X-Small"
									ForeColor="Blue" Width="10px" ReadOnly="True" BorderColor="Black" Visible="False"></asp:TextBox></FONT></FONT><FONT size="2">
							<asp:TextBox id="TXT_DEBITUR_ADDR" runat="server" Height="21px" Font-Names="Tahoma" Font-Size="X-Small"
								ForeColor="Blue" Width="10px" ReadOnly="True" BorderColor="Black" Visible="False"></asp:TextBox></FONT><FONT size="2">
							<asp:TextBox id="TXT_OBYEK_TANGGUNG" runat="server" Height="21px" Font-Names="Tahoma" Font-Size="X-Small"
								ForeColor="Blue" Width="10px" ReadOnly="True" BorderColor="Black" Visible="False"></asp:TextBox></FONT>
						<asp:TextBox id="TXT_ACA_AMOUNT" runat="server" Height="21px" Font-Names="Tahoma" Font-Size="X-Small"
							ForeColor="Blue" Width="10px" ReadOnly="True" BorderColor="Black"></asp:TextBox><FONT size="2">
							<asp:TextBox id="TXT_LOKASI_TANGGUNG" runat="server" Height="21px" Font-Names="Tahoma" Font-Size="X-Small"
								ForeColor="Blue" Width="10px" ReadOnly="True" BorderColor="Black" Visible="False"></asp:TextBox></FONT><FONT size="2">
							<asp:TextBox id="TXT_ACA_DURATION" runat="server" Height="21px" Font-Names="Tahoma" Font-Size="X-Small"
								ForeColor="Blue" Width="10px" ReadOnly="True" BorderColor="Black" Visible="False"></asp:TextBox></FONT><FONT size="2">
							<asp:TextBox id="TXT_LAIN_LAIN" runat="server" Height="30px" Font-Names="Tahoma" Font-Size="X-Small"
								ForeColor="Blue" Width="30px" TextMode="MultiLine" Visible="False"></asp:TextBox></FONT>
						<asp:TextBox id="TXT_CP_BM" runat="server" Height="21px" Font-Names="Tahoma" Font-Size="X-Small"
							ForeColor="Blue" Width="10px" Visible="False">Sdr. Daryanto</asp:TextBox>
						<asp:TextBox id="TXT_CP_BM_PHN" runat="server" Height="21px" Font-Names="Tahoma" Font-Size="X-Small"
							ForeColor="Blue" Width="10px" Visible="False">5266566 ext. 1299</asp:TextBox><STRONG><FONT face="Georgia" size="2"><EM>
									<asp:TextBox id="TXT_JCCO_TTD" runat="server" Height="21px" Font-Names="Tahoma" Font-Size="X-Small"
										ForeColor="Blue" Width="10px" Visible="False"> Jakarta City Operation</asp:TextBox></EM></FONT></STRONG><STRONG><FONT face="Georgia" size="2"><EM>
									<asp:TextBox id="TXT_ALAMAT_JCCO_TTD" runat="server" Height="21px" Font-Names="Tahoma" Font-Size="X-Small"
										ForeColor="Blue" Width="232px" Visible="False">Jakarta Sudirman</asp:TextBox></EM></FONT></STRONG><STRONG><U><FONT face="Georgia" size="2"><EM>
										<asp:TextBox id="TXT_NAMA_TTD" runat="server" Height="21px" Font-Names="Tahoma" Font-Size="X-Small"
											ForeColor="Blue" Width="10px" Font-Underline="True" Visible="False">Basu Fitri Manugrahani</asp:TextBox></EM></FONT></U></STRONG><STRONG><FONT face="Georgia" size="2"><EM>
									<asp:TextBox id="TXT_DEPT_TTD" runat="server" Height="21px" Font-Names="Tahoma" Font-Size="X-Small"
										ForeColor="Blue" Width="10px">JCO Manager</asp:TextBox></EM></FONT></STRONG></TD>
					<TD></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
