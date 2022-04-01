<%@ Page language="c#" Codebehind="SPPKPrint.aspx.cs" AutoEventWireup="True" Inherits="SME.SPPK.SPPKPrint" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML xmlns:o>
	<HEAD>
		<title>SPPK Letter</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_mandatory.html" -->
		<!-- #include file="../include/cek_entries.html" -->
		<script language="javascript">
		  function cetak()
		  {
		    TRPRINT.style.display = "none";
		    window.print();
		    TRPRINT.style.display = "";
		  }
		</script>
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE cellSpacing="0" cellPadding="0" width="100%">
				</TABLE>
				<TABLE cellSpacing="1" cellPadding="1" width="100%" align="center" border="0">
					<TR id="TRPRINT">
						<TD class="tdHeader1" align="left" width="6%" colSpan="3" style="HEIGHT: 21px"><asp:label id="LBL_REGNO" runat="server" Visible="False"></asp:label>
							<INPUT type="button" value="Print" onclick="cetak()" class="button1" style="WIDTH: 49px; HEIGHT: 26px"
								id="TRPrint"> <INPUT class="button1" onclick="javascript:history.back()" style="WIDTH: 49px; HEIGHT: 26px"
								type="button" value="Back">
							<asp:label id="LBL_CUREF" runat="server" Visible="False"></asp:label></TD>
					</TR>
					<TR>
						<TD align="left" width="6%"></TD>
						<TD align="left" width="100%"></TD>
						<TD align="left" width="9%"></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 20px" align="left" width="6%"></TD>
						<TD style="HEIGHT: 20px" align="left" width="100%"></TD>
						<TD style="HEIGHT: 20px" align="left" width="9%"></TD>
					</TR>
					<TR>
						<TD align="left" width="6%"></TD>
						<TD align="left" width="100%">
							<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
								<TR>
									<TD style="WIDTH: 128px"><asp:label id="Label7" runat="server" Font-Size="X-Small"> Nomor </asp:label></TD>
									<TD style="WIDTH: 10px"><FONT face="Tahoma" size="2"><FONT face="Tahoma" size="2"><asp:label id="Label2" runat="server" Font-Size="X-Small">:</asp:label></FONT></FONT></TD>
									<TD>
										<asp:label id="LBL_NO" runat="server" Font-Size="X-Small"></asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 128px"><asp:label id="Label9" runat="server" Font-Size="X-Small">Tanggal</asp:label></TD>
									<TD style="WIDTH: 10px"><FONT face="Tahoma" size="2"><FONT face="Tahoma" size="2"><asp:label id="Label3" runat="server" Font-Size="X-Small">:</asp:label></FONT></FONT></TD>
									<TD>
										<asp:label id="LBL_CURTIME" runat="server" Font-Size="X-Small"></asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 128px"><asp:label id="Label10" runat="server" Font-Size="X-Small">Lampiran</asp:label></TD>
									<TD style="WIDTH: 10px"><FONT face="Tahoma" size="2"><FONT face="Tahoma" size="2"><asp:label id="Label14" runat="server" Font-Size="X-Small">:</asp:label></FONT></FONT></TD>
									<TD>
										<asp:label id="LBL_LAMP" runat="server" Font-Size="X-Small"></asp:label></TD>
								</TR>
							</TABLE>
						</TD>
						<TD align="left" width="9%"></TD>
					</TR>
					<TR>
						<TD align="left" width="6%"></TD>
						<TD align="left" width="100%"></TD>
						<TD align="left" width="9%"></TD>
					</TR>
					<TR>
						<TD align="left" width="6%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						</TD>
						<TD align="left" width="100%">
							<P><STRONG><FONT face="Tahoma" size="2"><asp:label id="Label6" runat="server" Font-Size="X-Small" Font-Bold="True">Kepada:</asp:label></FONT></STRONG></P>
						</TD>
						<TD align="left" width="9%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
							&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 3px" align="left" width="6%"></TD>
						<TD style="HEIGHT: 3px" align="left" width="100%">
							<asp:label id="LBL_CUST_NAME" runat="server" Font-Size="X-Small"></asp:label><FONT face="Tahoma" size="2"></FONT></TD>
						<TD style="HEIGHT: 3px" align="left" width="9%"></TD>
					</TR>
					<TR>
						<TD align="left" width="6%"></TD>
						<TD align="left" width="100%">
							<asp:label id="LBL_ADDR" runat="server" Font-Size="X-Small"></asp:label><FONT face="Tahoma" size="2"></FONT></TD>
						<TD align="left" width="9%"></TD>
					</TR>
					<TR>
						<TD align="left" width="6%"></TD>
						<TD align="left" width="100%">
							<asp:label id="LBL_ADDR2" runat="server" Font-Size="X-Small"></asp:label></TD>
						<TD align="left" width="9%"></TD>
					</TR>
					<TR>
						<TD align="left" width="6%"></TD>
						<TD align="left" width="100%">
							<asp:label id="LBL_ADDR3" runat="server" Font-Size="X-Small"></asp:label></TD>
						<TD align="left" width="9%"></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 22px" align="left" width="6%"></TD>
						<TD style="HEIGHT: 22px" align="left" width="100%">
							<asp:label id="LBL_CITY" runat="server" Font-Size="X-Small"></asp:label><FONT face="Tahoma" size="2"></FONT></TD>
						<TD style="HEIGHT: 22px" align="left" width="9%"></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 25px" align="left" width="6%"></TD>
						<TD style="HEIGHT: 25px" align="left" width="100%">
							<asp:label id="LBL_POSTCODE" runat="server" Font-Size="X-Small"></asp:label><FONT face="Tahoma" size="2"></FONT></TD>
						<TD style="HEIGHT: 25px" align="left" width="9%"></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 21px" noWrap align="left" width="6%"></TD>
						<TD style="HEIGHT: 21px" noWrap align="left" width="100%" rowSpan="1"><FONT face="Tahoma" size="2"></FONT></TD>
						<TD style="HEIGHT: 21px" noWrap align="left" width="9%"></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 50px" align="left" width="9"></TD>
						<TD style="HEIGHT: 50px" align="left">
							<P><FONT face="Tahoma"><FONT size="2"><asp:label id="Label4" runat="server" Font-Size="X-Small" Font-Bold="True">Perihal: </asp:label>&nbsp;
										<asp:label id="Label5" runat="server" Font-Size="X-Small">Surat Pemberitahuan Persetujuan Kredit</asp:label></FONT></FONT></P>
							<P><FONT face="Tahoma" size="2"></FONT>&nbsp;</P>
						</TD>
						<TD style="HEIGHT: 50px" align="left" width="9%"></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 41px" align="left" width="6%"></TD>
						<TD style="HEIGHT: 41px" align="left" width="100%"><FONT face="X-Small" size="2"> Menunjuk 
								Aplikasi Saudara tanggal
								<asp:label id="LBL_AP_DATE" runat="server" Font-Size="X-Small"></asp:label>&nbsp;perihal 
								permohonan kredit Saudara, dengan ini memberitahukan bahwa kami dapat 
								menyetujui permohonan kredit dimaksud dengan ketentuan dan persyaratan sebagai 
								berikut:&nbsp;&nbsp;</FONT></TD>
						<TD style="HEIGHT: 41px" align="left" width="9%"></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 23px" align="left" width="6%"></TD>
						<TD style="HEIGHT: 23px" align="left" width="100%"><FONT face="Tahoma" size="2"></FONT></TD>
						<TD style="HEIGHT: 23px" align="left" width="9%"></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 23px" align="left" width="6%"></TD>
						<TD style="HEIGHT: 23px" align="left" width="100%"><FONT face="Tahoma"><FONT size="2"><STRONG>A.&nbsp;Ketentuan</STRONG>
								</FONT></FONT>
						</TD>
						<TD style="HEIGHT: 23px" align="left" width="9%"></TD>
					</TR>
					</TR>
					<TR>
						<TD align="center" width="6%"></TD>
						<TD align="left" width="9%"><asp:placeholder id="PH1" runat="server"></asp:placeholder></TD>
						<TD align="center" width="9%"></TD>
					</TR>
					<TR>
						<TD align="center" width="6%"></TD>
						<TD align="center" width="9%">
							<TABLE id="Table2" style="HEIGHT: 125px" cellSpacing="1" cellPadding="1" width="100%" border="0">
								<TR>
									<TD><FONT face="Tahoma"><FONT size="2"><FONT face="Tahoma"><FONT size="2"><STRONG>B.&nbsp;Syarat 
															Penandatangan Kredit</STRONG> </FONT></FONT></FONT></FONT>
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 521px"><asp:table id="TBL_SYARAT_PK" runat="server" Font-Size="X-Small"></asp:table></TD>
								</TR>
								<TR>
									<TD><FONT face="Tahoma" size="2"><STRONG>&nbsp;<FONT face="Tahoma" size="2"><STRONG>C. Syarat 
														Penarikan Kredit</STRONG></FONT></STRONG></FONT></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 521px"><asp:table id="TBL_SYARAT_PKR" runat="server" Font-Size="X-Small"></asp:table></TD>
								</TR>
								<TR>
									<TD><STRONG><FONT face="Tahoma" size="2">D. Syarat-syarat lainnya</FONT></STRONG></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 521px"><asp:table id="TBL_SYARAT_LAIN" runat="server" Font-Size="X-Small"></asp:table></TD>
								</TR>
								<TR style="TEXT-ALIGN: justify">
									<TD style="WIDTH: 521px; TEXT-ALIGN: justify"></TD>
								</TR>
								<TR style="TEXT-ALIGN: justify">
									<TD justify>
										<P><FONT face="X-Small" size="2">Demikian agar &nbsp;maklum, dan sebagai tanda 
												persetujuan Saudara duplikat surat ini agar dikembalikan kepada kami setelah 
												ditandatangani diatas materai Rp.
												<asp:label id="LBL_MATERAI" runat="server" Font-Size="X-Small"></asp:label></FONT>&nbsp;<FONT face="X-Small" size="2">dan 
												segera ke kantor kami untuk menandatangani Perjanjian Kredit.</FONT></P>
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 521px"><b><FONT face="Tahoma" size="2"><asp:table id="Tabel" runat="server" Width="100%" CellPadding="0" CellSpacing="0"></asp:table></FONT></b></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 521px"><B><asp:label id="LBL_MANDIRI" runat="server" Font-Size="X-Small">PT. Bank Mandiri (Persero) Tbk</asp:label></B></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 521px; HEIGHT: 26px">
										<asp:label id="LBL_BRANCH" runat="server"></asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 521px; HEIGHT: 78px"></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 521px"><b>(</b>&nbsp;
										<asp:label id="LBL_MANAGER" runat="server"></asp:label>&nbsp;<b>)</b></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 521px"><b>
											<asp:label id="LBL_BRANCHMANAGER" runat="server"></asp:label></b></TD>
								</TR>
							</TABLE>
						</TD>
						<TD align="center" width="9%"></TD>
					</TR>
					<TR>
						<TD align="center" width="6%"></TD>
						<TD align="center" width="9%">
							<TABLE id="Table5" style="WIDTH: 860px; HEIGHT: 26px" cellSpacing="1" cellPadding="1" width="860"
								border="0">
								<TR>
									<TD><asp:label id="Label100" runat="server" Font-Size="X-Small">Tembusan :</asp:label></TD>
								</TR>
								<TR>
									<TD>
										<P>
											<asp:label id="LBL_TEMBUSAN" runat="server"></asp:label></P>
										<P>
											<asp:label id="LBL_CURRENCY" runat="server"></asp:label></P>
									</TD>
								</TR>
							</TABLE>
						</TD>
						<TD align="center" width="9%"></TD>
					</TR>
					<tr>
						<TD align="center" width="6%"></TD>
						<td align="center" width="100%">&nbsp;&nbsp;&nbsp;</td>
						<TD align="center" width="9%"></TD>
					</tr>
				</TABLE>
				<asp:label id="Label1" style="Z-INDEX: 101; LEFT: 264px; POSITION: absolute; TOP: 1120px" runat="server"
					ForeColor="White" Height="14px" Visible="False"></asp:label>
		</form>
		</CENTER>
	</body>
</HTML>
