<%@ Page language="c#" Codebehind="LegalInvestRqstForm.aspx.cs" AutoEventWireup="True" Inherits="SME.Booking.Channeling.LegalInvestRqstForm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>:: Checklist Pemenuhan Persyaratan Penandatanganan Kredit ::</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../style.css" type="text/css" rel="stylesheet">
		<!-- #include  file="../../../include/child.html" -->
		<script language="javascript">
		  function cetak()
		  {
		    TRPRINT.style.display = "none";
		    window.print();
		    TRPRINT.style.display = "";
		  }
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR id="TRPRINT">
					<TD class="tdHeader1" style="HEIGHT: 21px" align="left" width="6%" colSpan="3"><asp:label id="LBL_REGNO" runat="server" Visible="False"></asp:label><INPUT class="button1" id="TRPrint" style="WIDTH: 49px; HEIGHT: 26px" onclick="cetak()"
							type="button" value="Print"> <INPUT class="button1" style="WIDTH: 49px; HEIGHT: 26px" onclick="javascript:window.close()"
							type="button" value="Close">
						<asp:label id="LBL_CUREF" runat="server" Visible="False"></asp:label></TD>
				</TR>
				<TR>
					<TD width="18%"><IMG src="../../../image/mandiri.gif" border="0"></TD>
					<TD align="center" width="64%"><FONT face="Verdana"><br>
							<FONT face="Verdana" size="2"><STRONG>CHECKLIST PEMENUHAN PERSYARATAN PENANDATANGANAN 
									KREDIT</STRONG></FONT><BR>
						</FONT>
					</TD>
					<TD width="18%">&nbsp;</TD>
				</TR>
				<TR>
					<TD align="center" width="100%" colSpan="3"></TD>
				</TR>
				<TR>
					<TD align="center" width="100%" colSpan="3">
						<!--<table width="100%">
							<TR>
								<td width="18%">&nbsp;][</td>
								<TD align="center" width="64%"><FONT face="Verdana" size="2">Perjanjian Kredit 
										Investasi No.xxxxxxx</FONT></TD>
								<td width="18%">&nbsp;</td>
							</TR>
							<TR>
								<TD width="18%"></TD>
								<TD align="center" width="64%"><FONT face="Verdana" size="2">Akta No. xxxx&nbsp; 
										Tanggal dd-mm-yyyy, nm_notaris......,SH Notaris di Jakarta</FONT></TD>
								<TD width="18%">][</TD>
							</TR>
						</table>--><BR>
					</TD>
				</TR>
				<TR>
					<TD width="100%" colSpan="3">
						<TABLE style="BORDER-RIGHT: #000000 1px solid; BORDER-TOP: #000000 1px solid; BORDER-LEFT: #000000 1px solid; BORDER-BOTTOM: #000000 1px solid; BACKGROUND-COLOR: #eeeeee"
							width="100%">
							<TR>
								<TD>
									<table width="100%">
										<tr>
											<td style="HEIGHT: 20px" width="25%"><FONT face="Verdana" size="2">Tanggal Penilaian</FONT></td>
											<td style="HEIGHT: 20px" width="25%"><FONT face="Verdana"><FONT size="2"><STRONG>:</STRONG>
														<asp:label id="LBL_TGLNILAI" runat="server">Label</asp:label></FONT></FONT></td>
											<td align="left" width="15%"><FONT face="Verdana" size="2">Nomor Aplikasi</FONT></td>
											<td width="35%"><FONT face="Verdana"><FONT size="2"><STRONG>:</STRONG>
														<asp:label id="LBL_APREGNO" runat="server">Label</asp:label></FONT></FONT></td>
										</tr>
										<TR>
											<TD width="25%"><FONT face="Verdana" size="2">Nama Debitur</FONT></TD>
											<TD width="25%"><FONT face="Verdana"><FONT size="2"><STRONG>:</STRONG>
														<asp:label id="LBL_DEBITUR" runat="server">Label</asp:label></FONT></FONT></TD>
											<TD align="left" width="15%"><FONT face="Verdana" size="2">Tanggal Aplikasi</FONT></TD>
											<TD width="35%"><FONT face="Verdana"><FONT size="2"><STRONG>:</STRONG>
														<asp:label id="LBL_APSIGNDATE" runat="server">Label</asp:label></FONT></FONT></TD>
										</TR>
										<TR>
											<TD vAlign="top" align="left" width="25%"><FONT face="Verdana" size="2"></FONT></TD>
											<TD vAlign="top" align="left" width="25%"><FONT face="Verdana"><FONT size="2"></FONT></FONT></TD>
											<TD align="left" width="15%"><FONT face="Verdana" size="2">Nama Notaris</FONT></TD>
											<TD vAlign="top" align="left" width="35%"><FONT size="2"><STRONG>:</STRONG>
													<asp:label id="LBL_NAMANOTARIS" runat="server">Label</asp:label></FONT></FONT></TD>
										</TR>
										<TR>
											<TD vAlign="top" align="left" width="25%"><FONT face="Verdana" size="2">Jenis Kredit</FONT></TD>
											<TD vAlign="top" align="left" width="25%"><asp:PlaceHolder id="LBL_KetKredit" runat="server"></asp:PlaceHolder></TD>
											<TD vAlign="top" align="left" width="15%"><FONT face="Verdana" size="2">Limit disetujui</FONT></TD>
											<TD vAlign="top" align="left" width="35%"><FONT size="2"><asp:placeholder id="PLHLD_LIMIT" runat="server"></asp:placeholder></FONT></TD>
										</TR>
									</table>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD colSpan="3"><asp:table id="TBL_CONTENT" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"
							CellPadding="0" CellSpacing="0" ForeColor="Black" Width="100%">
							<asp:TableRow>
								<asp:TableCell Width="5%" Text="No." CssClass="HeaderPrint"></asp:TableCell>
								<asp:TableCell Width="40%" Text="SYARAT PENANDATANGANAN KREDIT" CssClass="HeaderPrint"></asp:TableCell>
								<asp:TableCell Width="15%" Text="DIPENUHI" CssClass="HeaderPrint"></asp:TableCell>
								<asp:TableCell Width="40%" Text="KETERANGAN" CssClass="HeaderPrint"></asp:TableCell>
							</asp:TableRow>
						</asp:table></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 30px" width="100%" colSpan="3">&nbsp;</TD>
				</TR>
				<TR>
					<TD width="100%" colSpan="3"><FONT size="2">Dengan ini saya tegaskan bahwa saya telah 
							meneliti tersedianya dokumen tersebut di atas dengan sebenarnya.</FONT>
						<hr align="center" width="100%">
					</TD>
				</TR>
				<TR>
					<TD width="100%" colSpan="3">
						<table width="100%">
							<tr>
								<td style="HEIGHT: 30px" width="40%">Pemeriksa, Credit Officer COD</td>
								<td style="HEIGHT: 30px" width="20%">:&nbsp;</td>
								<td style="HEIGHT: 30px; BACKGROUND-COLOR: #eeeeee" width="40%">&nbsp;</td>
							</tr>
						</table>
					</TD>
				</TR>
				<TR>
					<TD width="100%" colSpan="3">
						<table width="100%">
							<tr>
								<td style="HEIGHT: 30px" width="40%">Mengetahui, Section Head/Team Leader/Officer 
									CO Community Branch</td>
								<td style="HEIGHT: 30px" width="20%">:&nbsp;</td>
								<td style="HEIGHT: 30px; BACKGROUND-COLOR: #eeeeee" width="40%">&nbsp;</td>
							</tr>
						</table>
					</TD>
				</TR>
				<TR>
					<TD width="100%" colSpan="3">
						<table width="100%">
							<tr>
								<td style="HEIGHT: 30px" width="40%">Rekomendasi, Department Head/Hub Manager/Spoke 
									Manager Community Branch</td>
								<td style="HEIGHT: 30px" width="20%">:&nbsp;</td>
								<td style="HEIGHT: 30px; BACKGROUND-COLOR: #eeeeee" width="40%">&nbsp;</td>
							</tr>
						</table>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
