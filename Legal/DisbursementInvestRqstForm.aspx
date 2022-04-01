<%@ Page language="c#" Codebehind="DisbursementInvestRqstForm.aspx.cs" AutoEventWireup="True" Inherits="SME.Legal.DisbursementInvestRqstForm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DisbursementInvestRqstForm</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
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
					<TD class="tdHeader1" align="left" width="6%" colSpan="3" style="HEIGHT: 21px"><asp:label id="LBL_REGNO" runat="server" Visible="False"></asp:label>
						<INPUT type="button" value="Print" onclick="cetak()" class="button1" style="WIDTH: 49px; HEIGHT: 26px"
							id="TRPrint"> <INPUT class="button1" onclick="javascript:history.back()" style="WIDTH: 49px; HEIGHT: 26px"
							type="button" value="Back">
						<asp:label id="LBL_CUREF" runat="server" Visible="False"></asp:label></TD>
				</TR>
				<TR>
					<TD width="18%"><IMG src="../image/mandiri.gif" border="0"></TD>
					<TD align="center" width="64%"><FONT face="Verdana"><FONT face="Verdana" size="2"><STRONG>CHECKLIST 
									PEMENUHAN PERSYARATAN PENCAIRAN KREDIT</STRONG></FONT><br>
						</FONT>
					</TD>
					<TD width="18%">&nbsp;</TD>
				</TR>
				<TR>
					<TD align="center" width="100%" colSpan="3"><br>
					</TD>
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
						</table>-->
						<BR>
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
														<asp:Label id="LBL_TGLNILAI" runat="server">Label</asp:Label></FONT></FONT></td>
											<td style="HEIGHT: 20px" width="25%" align="right"><FONT face="Verdana" size="2">&nbsp;<FONT face="Verdana" size="2">&nbsp;Nomor 
														Aplikasi</FONT></FONT></td>
											<td style="HEIGHT: 19px" width="25%"><FONT face="Verdana" size="2"><FONT face="Verdana"><FONT size="2"><STRONG>:</STRONG>
															<asp:Label id="LBL_APREGNO" runat="server">Label</asp:Label></FONT></FONT></FONT></td>
										</tr>
										<TR>
											<TD width="25%"><FONT face="Verdana" size="2">Nama Debitur</FONT></TD>
											<TD width="25%"><FONT face="Verdana"><FONT size="2"><STRONG>:</STRONG>
														<asp:Label id="LBL_DEBITUR" runat="server">Label</asp:Label>
													</FONT></FONT>
											</TD>
											<TD width="25%" align="right"><FONT face="Verdana" size="2">Tanggal Aplikasi</FONT></TD>
											<TD width="25%"><FONT face="Verdana" size="2"><FONT face="Verdana"><FONT size="2"><STRONG>:</STRONG>
															<asp:Label id="LBL_APSIGNDATE" runat="server">Label</asp:Label></FONT></FONT></FONT></TD>
										</TR>
										<TR>
											<TD vAlign="top" align="left" width="25%"><FONT face="Verdana" size="2"></FONT></TD>
											<TD vAlign="top" align="left" width="25%"><FONT face="Verdana"><FONT size="2"><STRONG></STRONG></FONT></FONT></TD>
											<TD align="right" width="25%" style="HEIGHT: 20px"><FONT face="Verdana" size="2"><FONT face="Verdana" size="2">Nama 
														Notaris</FONT></FONT></TD>
											<TD width="25%" style="HEIGHT: 20px"><FONT size="2"><FONT face="Verdana"><FONT size="2"><STRONG>:</STRONG>
															<asp:Label id="LBL_NAMANOTARIS" runat="server">Label</asp:Label></FONT></FONT></FONT></FONT></TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 20px" width="25%"><FONT face="Verdana" size="2">Jenis Kredit</FONT></TD>
											<TD style="HEIGHT: 20px" width="25%">
												<asp:PlaceHolder id="LBL_KetKredit" runat="server"></asp:PlaceHolder></TD>
											<TD style="HEIGHT: 20px" align="right" width="25%"><FONT face="Verdana" size="2">Limit 
													disetujui</FONT></TD>
											<TD style="HEIGHT: 20px" width="25%"><FONT size="2">
													<asp:PlaceHolder id="PLHLD_LIMIT" runat="server"></asp:PlaceHolder></FONT></TD>
										</TR>
									</table>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD colSpan="3">
						<asp:Table id="TBL_CONTENT" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"
							CellPadding="0" CellSpacing="0" ForeColor="Black" Width="100%">
							<asp:TableRow>
								<asp:TableCell Width="5%" Text="No." CssClass="HeaderPrint"></asp:TableCell>
								<asp:TableCell Width="40%" Text="SYARAT EFEKTIF/PENCAIRAN KREDIT" CssClass="HeaderPrint"></asp:TableCell>
								<asp:TableCell Width="15%" Text="DIPENUHI" CssClass="HeaderPrint"></asp:TableCell>
								<asp:TableCell Width="40%" Text="KETERANGAN" CssClass="HeaderPrint"></asp:TableCell>
							</asp:TableRow>
						</asp:Table></TD>
				</TR>
				<TR>
					<TD colspan="3" style="HEIGHT:30px" width="100%">&nbsp;</TD>
				</TR>
				<TR>
					<TD colspan="3" width="100%"><FONT size="2">Dengan ini saya tegaskan bahwa saya telah 
							meneliti tersedianya dokumen tersebut di atas dengan sebenarnya.</FONT>
						<hr align="center" width="100%">
					</TD>
				</TR>
				<TR>
					<TD colspan="3" width="100%">
						<table width="100%">
							<tr>
								<td width="40%" style="HEIGHT:30px">Pemeriksa, Credit Officer COD</td>
								<td width="20%" style="HEIGHT:30px">:&nbsp;</td>
								<td width="40%" style="HEIGHT:30px; BACKGROUND-COLOR:#eeeeee">&nbsp;</td>
							</tr>
						</table>
					</TD>
				</TR>
				<TR>
					<TD colspan="3" width="100%">
						<table width="100%">
							<tr>
								<td width="40%" style="HEIGHT:30px">Mengetahui, Section Head/Team Leader/Officer CO 
									Community Branch</td>
								<td width="20%" style="HEIGHT:30px">:&nbsp;</td>
								<td width="40%" style="HEIGHT:30px; BACKGROUND-COLOR:#eeeeee">&nbsp;</td>
							</tr>
						</table>
					</TD>
				</TR>
				<TR>
					<TD colspan="3" width="100%">
						<table width="100%">
							<tr>
								<td width="40%" style="HEIGHT:30px">Rekomendasi, Department Head/Hub Manager/Spoke 
									Manager Community Branch</td>
								<td width="20%" style="HEIGHT:30px">:&nbsp;</td>
								<td width="40%" style="HEIGHT:30px; BACKGROUND-COLOR:#eeeeee">&nbsp;</td>
							</tr>
						</table>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
