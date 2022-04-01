<%@ Page language="c#" Codebehind="SkalaAngsuranAnuitet.aspx.cs" AutoEventWireup="True" Inherits="SME.CreditProposal.SkalaAngsuranAnuitet" %>
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
				<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="1"
					cellPadding="1" width="70%" border="0">
					<TR>
						<TD style="FONT-SIZE: x-small; FONT-FAMILY: Tahoma; TEXT-ALIGN: center"><STRONG>SKALA 
								ANGSURAN ANUITET</STRONG><BR>
						</TD>
					</TR>
					<TR>
						<TD>
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD width="110"><STRONG><FONT face="Tahoma" size="2">Limit Kredit (Rp)</FONT></STRONG></TD>
									<TD style="WIDTH: 4px"><STRONG><FONT face="Tahoma" size="2">:</FONT></STRONG></TD>
									<TD style="WIDTH: 195px"><FONT face="Tahoma" size="2">
											<asp:TextBox id="TXT_LIMIT" runat="server" Height="21" Width="137" CssClass="angka" onkeypress="return numbersonly();" Font-Names="Tahoma"></asp:TextBox></FONT></TD>
									<TD><FONT face="Tahoma" size="2"><STRONG></STRONG></FONT></TD>
								</TR>
								<TR>
									<TD width="110"><STRONG><FONT face="Tahoma" size="2">Jangka Waktu</FONT></STRONG></TD>
									<TD style="WIDTH: 4px"><STRONG><FONT face="Tahoma" size="2">:</FONT></STRONG></TD>
									<TD style="WIDTH: 195px">
										<asp:TextBox id="TXT_JANGKAWAKTU" runat="server" Width="73" Height="21" CssClass="angka" onkeypress="return numbersonly();" Font-Names="Tahoma"></asp:TextBox><FONT face="Tahoma" size="2">&nbsp;Bulan</FONT></TD>
									<TD><FONT face="Tahoma" size="2">&nbsp;</FONT></TD>
								</TR>
								<TR>
									<TD width="110"><STRONG><FONT face="Tahoma" size="2">Grace Period</FONT></STRONG></TD>
									<TD style="WIDTH: 4px"><STRONG><FONT face="Tahoma" size="2">:</FONT></STRONG></TD>
									<TD style="WIDTH: 195px">
										<asp:TextBox id="TXT_GPERIODE" runat="server" Width="73px" Height="21px" CssClass="angka" onkeypress="return numbersonly();" Font-Names="Tahoma"></asp:TextBox><FONT face="Tahoma" size="2">&nbsp;Bulan</FONT></TD>
									<TD><STRONG><FONT size="2"><FONT face="Tahoma"></FONT></FONT></STRONG></TD>
								</TR>
								<TR>
									<TD width="110"><STRONG><FONT face="Tahoma" size="2">Bunga</FONT></STRONG></TD>
									<TD style="WIDTH: 4px"><STRONG><FONT face="Tahoma" size="2">:</FONT></STRONG></TD>
									<TD style="WIDTH: 195px">
										<asp:TextBox id="TXT_BUNGA" runat="server" Width="73px" Height="21px" CssClass="angka" Font-Names="Tahoma"></asp:TextBox><FONT face="Tahoma" size="2">
											&nbsp;%</FONT></TD>
									<TD><FONT face="Tahoma" size="2"><STRONG>
												<asp:Button id="BTN_HITUNG" runat="server" Text=" Hitung " CssClass="button1" onclick="BTN_HITUNG_Click"></asp:Button></STRONG></FONT></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD></TD>
					</TR>
					<TR>
						<TD><FONT face="Tahoma" size="2"> <STRONG>
									<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="100%" border="0">
										<TR>
											<TD style="WIDTH: 250px"><FONT face="Tahoma" size="2">Besar Angsuran per&nbsp;bulan</FONT></TD>
											<TD style="WIDTH: 35px"><FONT face="Tahoma" size="2"><STRONG>: Rp.</STRONG></FONT></TD>
											<TD>
												<asp:TextBox id="TXT_ANGSPOKOK" runat="server" Height="21px" Width="137px" ReadOnly="True" CssClass="angka" onkeypress="return numbersonly();"></asp:TextBox>
												<asp:button id="BTN_UPDATE" runat="server" CssClass="button1" Text="Update" Visible="False" onclick="BTN_UPDATE_Click"></asp:button></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 250px"><FONT face="Tahoma" size="2">Total Bunga selama periode kredit</FONT></TD>
											<TD style="WIDTH: 35px"><FONT face="Tahoma" size="2"><STRONG>: Rp.</STRONG></FONT></TD>
											<TD>
												<asp:label id="LBL_TOTAL_BUNGA" runat="server"></asp:label>
												<asp:TextBox id="TXT_TOTBUNGA" runat="server" Height="21px" Width="137px" ReadOnly="True" BorderColor="Black"
													CssClass="angka" Visible="False"></asp:TextBox></TD>
										</TR>
									</TABLE>
								</STRONG></FONT>
						</TD>
					</TR>
					<TR>
						<TD>
							<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="704" border="0" style="WIDTH: 704px; BORDER-BOTTOM: black solid; HEIGHT: 27px">
								<TR>
									<TD style="WIDTH: 74px" align="right"><FONT face="Tahoma" size="2"><STRONG>Angsuran</STRONG></FONT></TD>
									<TD style="WIDTH: 139px" align="right"><FONT face="Tahoma" size="2"><STRONG>Saldo Awal</STRONG></FONT></TD>
									<TD style="WIDTH: 140px" align="right"><FONT face="Tahoma" size="2"><STRONG>Angsuran Pokok</STRONG></FONT></TD>
									<TD style="WIDTH: 88px" align="right"><FONT face="Tahoma" size="2"><STRONG>Bunga</STRONG></FONT></TD>
									<TD style="WIDTH: 121px" align="right"><FONT face="Tahoma" size="2"><STRONG>Total</STRONG></FONT></TD>
									<TD align="right"><FONT face="Tahoma" size="2"><STRONG>Saldo AKhir</STRONG></FONT></TD>
								</TR>
							</TABLE>
							<asp:PlaceHolder id="PH_TABEL" runat="server"></asp:PlaceHolder>
						</TD>
					</TR>
					<TR>
						<TD style="VISIBILITY: hidden">&nbsp;&nbsp;
							<asp:RequiredFieldValidator id="REQ_LIMIT" runat="server" ControlToValidate="TXT_LIMIT" ErrorMessage="Limit Kredit harus diisi">REQ_LIMIT</asp:RequiredFieldValidator>&nbsp;
							<asp:RequiredFieldValidator id="REQ_TENOR" runat="server" ControlToValidate="TXT_JANGKAWAKTU" ErrorMessage="Jangka Waktu harus diisi">REQ_TENOR</asp:RequiredFieldValidator>&nbsp;
							<asp:RequiredFieldValidator id="REQ_GPERIOD" runat="server" ControlToValidate="TXT_GPERIODE" ErrorMessage="Grace Periode harus diisi">REQ_GPERIOD</asp:RequiredFieldValidator>&nbsp;&nbsp;
							<asp:RequiredFieldValidator id="REQ_BUNGA" runat="server" ControlToValidate="TXT_BUNGA" ErrorMessage="Bunga harus diisi">REQ_BUNGA</asp:RequiredFieldValidator>&nbsp;&nbsp;
							<asp:CompareValidator id="COMP_TENOR_GPERIOD" runat="server" ErrorMessage="Tenor harus lebih besar dari Grace Periode"
								ControlToValidate="TXT_JANGKAWAKTU" ControlToCompare="TXT_GPERIODE" Operator="GreaterThan" Type="Double">COMP_TENOR_GPERIOD</asp:CompareValidator>&nbsp;
							<asp:TextBox id="TXT_NOL" runat="server" Font-Names="Tahoma" CssClass="angka" Width="73px" Height="21px">0</asp:TextBox>&nbsp;&nbsp;
							<asp:CompareValidator id="COMP_BUNGA_NOL" runat="server" ErrorMessage="Bunga harus lebih besar dari 0 (nol)"
								ControlToValidate="TXT_BUNGA" Type="Double" Operator="GreaterThan" ControlToCompare="TXT_NOL">COMP_BUNGA_NOL</asp:CompareValidator>
							<asp:ValidationSummary id="VSUMM" runat="server" ShowMessageBox="True"></asp:ValidationSummary>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
