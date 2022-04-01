<%@ Page language="c#" Codebehind="AsuransiJiwa_Main.aspx.cs" AutoEventWireup="True" Inherits="SME.CreditProposal.AsuransiJiwa_Main" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Asuransi Jiwa</title>
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
						<TD style="WIDTH: 115px" align="center"></TD>
						<TD align="center" style="WIDTH: 529px"><INPUT id="BTN_PRINT1" style="WIDTH: 101px; HEIGHT: 24px" onclick="print_frame();"
								type="button" value="Print" name="BTNCANCEL">&nbsp;<INPUT id="BTN_CANCEL_2" style="WIDTH: 101px; HEIGHT: 24px" onclick="javascript:history.back(-1)"
								type="button" value="Cancel" name="BTNCANCEL">&nbsp;<INPUT id="BTN_CLOSE" style="WIDTH: 101px; HEIGHT: 24px" onclick="javascript:window.close();"
								type="button" value="Close" name="BTNCANCEL"></TD>
						<TD align="center"></TD>
					</TR>
					<tr>
						<TD style="WIDTH: 111px; HEIGHT: 6px"></TD>
						<td style="WIDTH: 529px; HEIGHT: 6px">
						</td>
						<TD style="HEIGHT: 6px"></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px"></TD>
						<td style="WIDTH: 529px" align="center">
							<asp:PlaceHolder id="PH1" runat="server"></asp:PlaceHolder></td>
						<TD></TD>
					</tr>
					<TR>
						<TD style="WIDTH: 111px"></TD>
						<TD style="VISIBILITY: hidden; WIDTH: 529px" align="center">
							<asp:TextBox id="TXT_NO_SURAT" runat="server" Width="20px" ForeColor="Blue" Font-Size="X-Small"
								Font-Names="Tahoma" Height="22px"></asp:TextBox>
							<asp:TextBox id="TXT_TANGGAL" runat="server" Width="20px" ForeColor="Blue" Font-Size="X-Small"
								Font-Names="Tahoma" Height="22px" BorderColor="Black" ReadOnly="True"></asp:TextBox>
							<asp:TextBox id="TXT_LAMPIRAN" runat="server" Width="20px" ForeColor="Blue" Font-Size="X-Small"
								Font-Names="Tahoma" Height="22px">-</asp:TextBox>
							<asp:TextBox id="TXT_NAMA_PT" runat="server" Width="20px" ForeColor="Blue" Font-Size="X-Small"
								Font-Names="Tahoma" Height="21px" BorderColor="Black" ReadOnly="True"></asp:TextBox>
							<asp:TextBox id="TXT_ALAMAT1_PT" runat="server" Width="20px" ForeColor="Blue" Font-Size="X-Small"
								Font-Names="Tahoma" Height="21px" BorderColor="Black" ReadOnly="True"></asp:TextBox>
							<asp:TextBox id="TXT_ALAMAT2_PT" runat="server" Width="20px" ForeColor="Blue" Font-Size="X-Small"
								Font-Names="Tahoma" Height="21px" BorderColor="Black" ReadOnly="True"></asp:TextBox>
							<asp:TextBox id="TXT_ALAMAT3_PT" runat="server" Width="20px" ForeColor="Blue" Font-Size="X-Small"
								Font-Names="Tahoma" Height="21px" BorderColor="Black" ReadOnly="True"></asp:TextBox>
							<asp:TextBox id="TXT_TELP_PT" runat="server" Width="20px" ForeColor="Blue" Font-Size="X-Small"
								Font-Names="Tahoma" Height="21px" BorderColor="Black" ReadOnly="True"></asp:TextBox>
							<asp:TextBox id="TXT_UP" runat="server" Width="20px" ForeColor="Blue" Font-Size="X-Small" Font-Names="Tahoma"
								Height="21px" BorderColor="Black" ReadOnly="True"></asp:TextBox>
							<asp:TextBox id="TXT_DEBITUR" runat="server" Width="20px" ForeColor="Blue" Font-Size="X-Small"
								Font-Names="Tahoma" Height="21px" BorderColor="Black" ReadOnly="True"></asp:TextBox><FONT size="2"><FONT size="2">
									<asp:TextBox id="TXT_CU_NAME" runat="server" Width="20px" ForeColor="Blue" Font-Size="X-Small"
										Font-Names="Tahoma" Height="21px" BorderColor="Black" ReadOnly="True"></asp:TextBox></FONT></FONT><FONT size="2">
								<asp:TextBox id="TXT_CU_DOB" runat="server" Width="20px" ForeColor="Blue" Font-Size="X-Small"
									Font-Names="Tahoma" Height="21px" BorderColor="Black" ReadOnly="True"></asp:TextBox></FONT><FONT size="2">
								<asp:TextBox id="TXT_CU_AGE" runat="server" Width="20px" ForeColor="Blue" Font-Size="X-Small"
									Font-Names="Tahoma" Height="21px" BorderColor="Black" ReadOnly="True"></asp:TextBox></FONT>
							<asp:TextBox id="TXT_ALI_AMOUNT" runat="server" Width="20px" ForeColor="Blue" Font-Size="X-Small"
								Font-Names="Tahoma" Height="21px" BorderColor="Black" ReadOnly="True"></asp:TextBox><FONT size="2">
								<asp:TextBox id="TXT_ALI_DURATION" runat="server" Width="20px" ForeColor="Blue" Font-Size="X-Small"
									Font-Names="Tahoma" Height="21px" BorderColor="Black" ReadOnly="True"></asp:TextBox></FONT>
							<asp:TextBox id="TXT_ALI_PREMI" runat="server" Width="20px" ForeColor="Blue" Font-Size="X-Small"
								Font-Names="Tahoma" Height="21px" BorderColor="Black" ReadOnly="True"></asp:TextBox><FONT size="2">
								<asp:TextBox id="TXT_CU_ADDR" runat="server" Width="20px" ForeColor="Blue" Font-Size="X-Small"
									Font-Names="Tahoma" Height="21px" BorderColor="Black" ReadOnly="True"></asp:TextBox></FONT><FONT size="2">
								<asp:TextBox id="TXT_CU_PHN" runat="server" Width="20px" ForeColor="Blue" Font-Size="X-Small"
									Font-Names="Tahoma" Height="21px" BorderColor="Black" ReadOnly="True"></asp:TextBox></FONT><STRONG><FONT face="Georgia" size="2"><EM>
										<asp:TextBox id="TXT_JCCO_TTD" runat="server" Width="20px" ForeColor="Blue" Font-Size="X-Small"
											Font-Names="Tahoma" Height="21px">Jakarta City Operation</asp:TextBox></EM></FONT></STRONG><STRONG><FONT face="Georgia" size="2"><EM>
										<asp:TextBox id="TXT_ALAMAT_JCCO_TTD" runat="server" Width="20px" ForeColor="Blue" Font-Size="X-Small"
											Font-Names="Tahoma" Height="21px">Jakarta Sudirman</asp:TextBox></EM></FONT></STRONG><STRONG><U><FONT face="Georgia" size="2"><EM>
											<asp:TextBox id="TXT_NAMA_TTD" runat="server" Width="20px" ForeColor="Blue" Font-Size="X-Small"
												Font-Names="Tahoma" Height="21px" Font-Underline="True">Basu Fitri Manugrahani</asp:TextBox></EM></FONT></U></STRONG><STRONG><FONT face="Georgia" size="2"><EM>
										<asp:TextBox id="TXT_DEPT_TTD" runat="server" Width="20px" ForeColor="Blue" Font-Size="X-Small"
											Font-Names="Tahoma" Height="21px">JCO Manager</asp:TextBox></EM></FONT></STRONG></TD>
						<TD></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
