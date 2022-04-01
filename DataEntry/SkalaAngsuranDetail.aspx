<%@ Page language="c#" Codebehind="SkalaAngsuranDetail.aspx.cs" AutoEventWireup="True" Inherits="SME.CreditProposal.SkalaAngsuranDetail" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Nota Analisa</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include  file="../include/cek_all.html" -->
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 680px; POSITION: absolute; TOP: 8px; HEIGHT: 104px"
					cellSpacing="1" cellPadding="1" width="680" border="0">
					<TR>
						<TD style="FONT-SIZE: x-small; FONT-FAMILY: Tahoma; TEXT-ALIGN: center"><STRONG>SIMPLE 
								INTEREST</STRONG><BR>
						</TD>
					</TR>
					<TR>
						<TD><FONT face="Tahoma" size="2">
								<TABLE id="Table2" style="WIDTH: 672px; HEIGHT: 48px" cellSpacing="0" cellPadding="0" width="672"
									border="0">
									<TR>
										<TD width="110"><STRONG><FONT face="Tahoma" size="2">Limit Kredit (Rp)</FONT></STRONG></TD>
										<TD style="WIDTH: 4px"><STRONG><FONT face="Tahoma" size="2">:</FONT></STRONG></TD>
										<TD style="WIDTH: 211px"><FONT face="Tahoma" size="2"><asp:textbox id="TXT_LIMIT_KREDIT" runat="server" CssClass="angka" Font-Names="Tahoma" onkeypress="return numbersonly();"></asp:textbox></FONT></TD>
										<TD><FONT face="Tahoma" size="2"><STRONG>SISTEM PEMBAYARAN</STRONG></FONT></TD>
									</TR>
									<TR>
										<TD width="110"><STRONG><FONT face="Tahoma" size="2">Tenor</FONT></STRONG></TD>
										<TD style="WIDTH: 4px"><STRONG><FONT face="Tahoma" size="2">:</FONT></STRONG></TD>
										<TD style="WIDTH: 211px"><asp:textbox id="TXT_TENOR" runat="server" CssClass="angka" onkeypress="return numbersonly();" Font-Names="Tahoma" Width="73" Height="21"></asp:textbox><FONT face="Tahoma" size="2">&nbsp;Bulan</FONT></TD>
										<TD><FONT face="Tahoma" size="2"><asp:textbox id="TXT_BULANAN" runat="server" CssClass="angka" onkeypress="return numbersonly();" Width="73px" Height="21px"></asp:textbox>&nbsp;Bulanan&nbsp;&nbsp;
												<asp:label id="LBL_JUML_ANGSURAN" runat="server"></asp:label>&nbsp;Kali</FONT></TD>
									</TR>
									<TR>
										<TD width="110"><STRONG><FONT face="Tahoma" size="2">Grace Period</FONT></STRONG></TD>
										<TD style="WIDTH: 4px"><STRONG><FONT face="Tahoma" size="2">:</FONT></STRONG></TD>
										<TD style="WIDTH: 211px"><asp:textbox id="TXT_GRACE_PERIOD" runat="server" CssClass="angka" onkeypress="return numbersonly();" Font-Names="Tahoma" Width="73px"
												Height="21px"></asp:textbox><FONT face="Tahoma" size="2">&nbsp;Bulan</FONT></TD>
										<TD><STRONG><FONT size="2"><FONT face="Tahoma"></FONT></FONT></STRONG></TD>
									</TR>
									<TR>
										<TD width="110"><STRONG><FONT face="Tahoma" size="2">Bunga</FONT></STRONG></TD>
										<TD style="WIDTH: 4px"><STRONG><FONT face="Tahoma" size="2">:</FONT></STRONG></TD>
										<TD style="WIDTH: 211px"><asp:textbox id="TXT_BUNGA" runat="server" CssClass="angka" Font-Names="Tahoma" Width="73px"
												Height="21px"></asp:textbox><FONT face="Tahoma" size="2">&nbsp;% p.a.</FONT></TD>
										<TD><FONT face="Tahoma" size="2"><STRONG><asp:button id="BTN_HITUNG" runat="server" CssClass="button1" Text=" Hitung " onclick="BTN_HITUNG_Click"></asp:button><asp:label id="LBL_ROW" runat="server" Font-Names="Tahoma" Visible="False"></asp:label><asp:label id="LBL_ROWGPERIODE" runat="server" Visible="False"></asp:label></STRONG></FONT></TD>
									</TR>
								</TABLE>
							</FONT>
						</TD>
					</TR>
					<TR>
						<TD></TD>
					</TR>
					<TR>
						<TD><FONT face="Tahoma" size="2">
								<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
									<TR>
										<TD style="WIDTH: 303px"><FONT face="Tahoma" size="2">Besar Angsuran Pokok per </FONT>
											<asp:label id="LBL_BULAN_PER" runat="server"></asp:label><FONT face="Tahoma" size="2">&nbsp;bulan
											</FONT>
										</TD>
										<TD style="WIDTH: 31px"><FONT face="Tahoma"><FONT size="2">: <STRONG>Rp</STRONG></FONT></FONT></TD>
										<TD><asp:textbox id="TXT_ANGSPOKOK" runat="server" CssClass="angka" onkeypress="return numbersonly();" Font-Names="Tahoma" Width="109px"
												ReadOnly="True"></asp:textbox><asp:button id="BTN_UPDATE" runat="server" CssClass="button1" Text="Update" Visible="False" onclick="BTN_UPDATE_Click"></asp:button></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 303px"><FONT face="Tahoma" size="2">Total Bunga selama periode 
												kredit&nbsp;</FONT></TD>
										<TD style="WIDTH: 31px"><FONT face="Tahoma"><FONT size="2">: <STRONG>Rp</STRONG></FONT></FONT></TD>
										<TD><asp:label id="LBL_TOTAL_BUNGA" runat="server"></asp:label></TD>
									</TR>
								</TABLE>
								<STRONG>
									<asp:label id="LBL_ANGSURAN_PER_PERIODE" runat="server" Visible="False"></asp:label></STRONG></FONT></TD>
					</TR>
					<TR>
						<TD>
							<TABLE id="Table3" style="BORDER-BOTTOM: black solid" cellSpacing="1" cellPadding="1" width="100%"
								border="0">
								<TR>
									<TD><FONT face="Tahoma" size="2"><STRONG>Angsuran</STRONG></FONT></TD>
									<TD><FONT face="Tahoma" size="2"><STRONG>Saldo Awal</STRONG></FONT></TD>
									<TD style="WIDTH: 171px"><FONT face="Tahoma" size="2"><STRONG>Angsuran Pokok</STRONG></FONT></TD>
									<TD><FONT face="Tahoma" size="2"><STRONG>Bunga</STRONG></FONT></TD>
									<TD><FONT face="Tahoma" size="2"><STRONG>Saldo AKhir</STRONG></FONT></TD>
								</TR>
							</TABLE>
							<asp:PlaceHolder id="PH_TABEL_ANGSURAN" runat="server"></asp:PlaceHolder></TD>
					</TR>
					<TR>
						<TD style="VISIBILITY: hidden">
							<asp:ValidationSummary id="VSUMM" runat="server" ShowMessageBox="True"></asp:ValidationSummary>&nbsp;&nbsp;
							<asp:RequiredFieldValidator id="REQ_LIMIT" runat="server" ErrorMessage="Limit Kredit harus diisi" ControlToValidate="TXT_LIMIT_KREDIT">REQ_LIMIT</asp:RequiredFieldValidator>&nbsp;
							<asp:RequiredFieldValidator id="REQ_TENOR" runat="server" ErrorMessage="Tenor harus diisi" ControlToValidate="TXT_TENOR">REQ_TENOR</asp:RequiredFieldValidator>&nbsp;&nbsp;
							<asp:RequiredFieldValidator id="REQ_GPERIOD" runat="server" ErrorMessage="Grace Periode harus diisi" ControlToValidate="TXT_GRACE_PERIOD">REQ_GPERIOD</asp:RequiredFieldValidator>&nbsp;&nbsp;
							<asp:RequiredFieldValidator id="REQ_BUNGA" runat="server" ErrorMessage="Bunga harus diisi" ControlToValidate="TXT_BUNGA">REQ_BUNGA</asp:RequiredFieldValidator>&nbsp;
							<asp:RequiredFieldValidator id="REQ_BLNAN" runat="server" ErrorMessage="Sistem Pembayaran minimal 1 bulan atau lebih"
								ControlToValidate="TXT_BULANAN">REQ_BLNAN</asp:RequiredFieldValidator>&nbsp;&nbsp;
							<asp:CompareValidator id="COMP_TENOR_GPERIOD" runat="server" ErrorMessage="Tenor harus lebih besar dari Grace Period"
								ControlToValidate="TXT_TENOR" Operator="GreaterThan" Type="Double" ControlToCompare="TXT_GRACE_PERIOD">COMP_TENOR_GPERIOD</asp:CompareValidator>&nbsp;
							<asp:TextBox id="TXT_NOL" runat="server" Font-Names="Tahoma" CssClass="angka" Height="21px" Width="73px">0</asp:TextBox>
							<asp:TextBox id="TXT_SATU" runat="server" Font-Names="Tahoma" CssClass="angka" Height="21px"
								Width="73px">1</asp:TextBox>
							<asp:CompareValidator id="COMP_BUNGA_NOL" runat="server" ControlToValidate="TXT_BUNGA" ErrorMessage="Bunga harus lebih besar dari 0 (nol)"
								ControlToCompare="TXT_NOL" Type="Double" Operator="GreaterThan">COMP_BUNGA_NOL</asp:CompareValidator>&nbsp;
							<asp:CompareValidator id="COMP_BLNAN_SATU" runat="server" ControlToValidate="TXT_BULANAN" ErrorMessage="Sistem Pembayaran minimal 1 bulan atau lebih"
								ControlToCompare="TXT_SATU" Type="Double" Operator="GreaterThanEqual">COMP_BULANAN_SATU</asp:CompareValidator>&nbsp;</TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
