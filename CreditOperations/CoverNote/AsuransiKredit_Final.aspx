<%@ Page language="c#" Codebehind="AsuransiKredit_Final.aspx.cs" AutoEventWireup="True" Inherits="SME.CreditProposal.AsuransiKredit_Final" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Asuransi Kredit</title>
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
						<TD align="center" style="WIDTH: 529px"><INPUT id="BTN_PRINT1" style="WIDTH: 101px; HEIGHT: 24px" onclick="javascript:window.print();"
								type="button" value="Print" name="BTNCANCEL">&nbsp;<INPUT id="BTN_CANCEL_2" style="WIDTH: 101px; HEIGHT: 24px" onclick="javascript:history.back(-1)"
								type="button" value="Cancel" name="BTNCANCEL">&nbsp;<INPUT id="BTN_CLOSE" style="WIDTH: 101px; HEIGHT: 24px" onclick="javascript:window.close();"
								type="button" value="Close" name="BTNCANCEL"></TD>
						<TD align="center"></TD>
					</TR>
					<tr>
						<TD style="WIDTH: 111px; HEIGHT: 81px"></TD>
						<td style="WIDTH: 529px; HEIGHT: 81px">
							<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="496" border="0" style="WIDTH: 496px; HEIGHT: 67px">
								<TR>
									<TD style="WIDTH: 87px"><FONT face="Tahoma" size="2">Nomor</FONT></TD>
									<TD style="WIDTH: 8px"><FONT face="Tahoma" size="2">:</FONT></TD>
									<TD><FONT face="Tahoma">
											<asp:Label id="LBL_NO_SURAT" runat="server" ForeColor="Blue" Font-Size="X-Small" Font-Names="Tahoma"
												Height="8px" Font-Bold="True"></asp:Label></FONT></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 87px"><FONT face="Tahoma" size="2">Tanggal</FONT></TD>
									<TD style="WIDTH: 8px"><FONT face="Tahoma" size="2">:</FONT></TD>
									<TD><FONT face="Tahoma">
											<asp:Label id="LBL_TANGGAL" runat="server" ForeColor="Blue" Font-Size="X-Small" Font-Names="Tahoma"
												Height="8px" Font-Bold="True"></asp:Label></FONT></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 87px"><FONT face="Tahoma" size="2">Lampiran</FONT></TD>
									<TD style="WIDTH: 8px"><FONT face="Tahoma" size="2">:</FONT></TD>
									<TD>
										<asp:Label id="LBL_LAMPIRAN" runat="server" Font-Bold="True" Height="8px" Font-Names="Tahoma"
											Font-Size="X-Small" ForeColor="Blue"></asp:Label></TD>
								</TR>
							</TABLE>
							<BR>
						</td>
						<TD style="HEIGHT: 81px"></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px"></TD>
						<td style="WIDTH: 529px"><FONT face="Tahoma"><FONT size="2"><STRONG>Kepada Yth :</STRONG></FONT>
								<BR>
							</FONT>
							<asp:Label id="LBL_NAMA_PT" runat="server" ForeColor="Blue" Font-Size="X-Small" Font-Names="Tahoma"
								Height="8px" Font-Bold="True"></asp:Label><BR>
							<asp:Label id="LBL_ALAMAT1_PT" runat="server" ForeColor="Blue" Font-Size="X-Small" Font-Names="Tahoma"
								Height="8px" Font-Bold="True"></asp:Label><BR>
							<asp:Label id="LBL_ALAMAT2_PT" runat="server" ForeColor="Blue" Font-Size="X-Small" Font-Names="Tahoma"
								Height="8px" Font-Bold="True"></asp:Label><BR>
							<asp:Label id="LBL_ALAMAT3_PT" runat="server" ForeColor="Blue" Font-Size="X-Small" Font-Names="Tahoma"
								Height="8px" Font-Bold="True"></asp:Label><BR>
							<asp:Label id="LBL_TELP_PT" runat="server" ForeColor="Blue" Font-Size="X-Small" Font-Names="Tahoma"
								Height="8px" Font-Bold="True"></asp:Label><BR>
							<BR>
							<BR>
						</td>
						<TD></TD>
					</tr>
					<TR>
						<TD style="WIDTH: 111px"></TD>
						<TD style="WIDTH: 529px"><FONT face="Tahoma" size="2">u.p.
								<asp:Label id="LBL_UP" runat="server" ForeColor="Blue" Font-Size="X-Small" Font-Names="Tahoma"
									Height="8px" Font-Bold="True"></asp:Label>
							</FONT>
							<BR>
							<BR>
						</TD>
						<TD></TD>
					</TR>
					<tr>
						<TD style="WIDTH: 111px"></TD>
						<td style="WIDTH: 529px"><FONT face="Georgia" size="2"><FONT face="Tahoma">Perihal :&nbsp;<STRONG>Penutupan 
										asuransi atas nama
										<asp:Label id="LBL_DEBITUR" runat="server" ForeColor="Blue" Font-Size="X-Small" Font-Names="Tahoma"
											Height="8px" Font-Bold="True"></asp:Label></STRONG></FONT></FONT>
							<BR>
							<BR>
						</td>
						<TD></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px; HEIGHT: 19px"></TD>
						<td style="WIDTH: 529px; HEIGHT: 19px"><FONT face="Tahoma" size="2">Dengan hormat,<BR>
								<BR>
							</FONT>
						</td>
						<TD style="HEIGHT: 19px"></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px; HEIGHT: 100px"></TD>
						<td style="VERTICAL-ALIGN: baseline; WIDTH: 529px; HEIGHT: 100px; TEXT-ALIGN: justify">
							<P><FONT size="2"><FONT face="Tahoma"> Sehubungan dengan fasilitas kredit yang akan 
										diberikan kepada debitur tersebut di atas, dengan ini kami mengharapkan bantuan 
										Saudara untuk melakukan penutupan asuransi kredit dengan data-data sebagai 
										berikut :<BR>
										<BR>
										<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TBODY>
												<TR>
													<TD style="WIDTH: 131px" vAlign="top"><FONT size="2">Nama</FONT></TD>
													<TD style="WIDTH: 10px; TEXT-ALIGN: justify" vAlign="top"><FONT size="2">:</FONT></TD>
													<TD style="TEXT-ALIGN: justify"><FONT size="2"><FONT size="2">
																<asp:Label id="LBL_DEBITUR_NAME" runat="server" ForeColor="Blue" Font-Size="X-Small" Font-Names="Tahoma"
																	Height="8px" Font-Bold="True"></asp:Label>
															</FONT></FONT>
													</TD>
												</TR>
												<TR>
													<TD style="WIDTH: 131px" vAlign="top"><FONT size="2">Tanggal Lahir</FONT></TD>
													<TD style="WIDTH: 10px; TEXT-ALIGN: justify" vAlign="top"><FONT size="2">:</FONT></TD>
													<TD style="TEXT-ALIGN: justify"><FONT size="2">
															<asp:Label id="LBL_DEBITUR_DOB" runat="server" ForeColor="Blue" Font-Size="X-Small" Font-Names="Tahoma"
																Height="8px" Font-Bold="True"></asp:Label></FONT>
													</TD>
												</TR>
												<TR>
													<TD style="WIDTH: 131px; HEIGHT: 14px" vAlign="top"><FONT size="2">Usia</FONT></TD>
													<TD style="WIDTH: 10px; HEIGHT: 14px" vAlign="top"><FONT size="2">:</FONT></TD>
													<TD style="HEIGHT: 14px"><FONT size="2">
															<asp:Label id="LBL_DEBITUR_AGE" runat="server" ForeColor="Blue" Font-Size="X-Small" Font-Names="Tahoma"
																Height="8px" Font-Bold="True"></asp:Label>&nbsp;tahun</FONT>
													</TD>
												</TR>
												<TR>
													<TD style="WIDTH: 131px" vAlign="top"><FONT size="2">Uang pertanggungan</FONT></TD>
													<TD style="WIDTH: 10px; TEXT-ALIGN: justify" vAlign="top"><FONT size="2">:</FONT></TD>
													<TD style="TEXT-ALIGN: justify"><FONT size="2">Rp.
															<asp:Label id="LBL_UANG_TANGGUNG" runat="server" ForeColor="Blue" Font-Size="X-Small" Font-Names="Tahoma"
																Height="8px" Font-Bold="True"></asp:Label></FONT>
													</TD>
												</TR>
												<TR>
													<TD style="WIDTH: 131px" vAlign="top"><FONT size="2">Masa pertanggungan</FONT></TD>
													<TD style="WIDTH: 10px" vAlign="top"><FONT size="2">:</FONT></TD>
													<TD><FONT size="2">
															<asp:Label id="LBL_MASA_TANGGUNG" runat="server" ForeColor="Blue" Font-Size="X-Small" Font-Names="Tahoma"
																Height="8px" Font-Bold="True"></asp:Label>&nbsp;tahun</FONT>
													</TD>
												</TR>
												<TR>
													<TD style="WIDTH: 131px" vAlign="top"><FONT size="2">Perkiraan Premi</FONT></TD>
													<TD style="WIDTH: 10px" vAlign="top"><FONT size="2">:</FONT></TD>
													<TD><FONT size="2">Rp.
															<asp:Label id="LBL_PREMI" runat="server" ForeColor="Blue" Font-Size="X-Small" Font-Names="Tahoma"
																Height="8px" Font-Bold="True"></asp:Label></FONT>
													</TD>
												</TR>
												<TR>
													<TD style="WIDTH: 131px" vAlign="top"><FONT size="2">Alamat</FONT></TD>
													<TD style="WIDTH: 10px" vAlign="top"><FONT size="2">:</FONT></TD>
													<TD><FONT size="2">
															<asp:Label id="LBL_DEBITUR_ADDR" runat="server" ForeColor="Blue" Font-Size="X-Small" Font-Names="Tahoma"
																Height="8px" Font-Bold="True"></asp:Label></FONT></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 131px" vAlign="top"><FONT size="2">Telp</FONT></TD>
													<TD style="WIDTH: 10px" vAlign="top"><FONT size="2">:</FONT></TD>
													<TD><FONT size="2">
															<asp:Label id="LBL_DEBITUR_PHN" runat="server" ForeColor="Blue" Font-Size="X-Small" Font-Names="Tahoma"
																Height="8px" Font-Bold="True"></asp:Label></FONT></TD>
												</TR>
											</TBODY>
										</TABLE>
									</FONT></FONT>
							</P>
						</td>
						<TD style="HEIGHT: 100px"></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px"></TD>
						<td style="WIDTH: 529px"><FONT face="Tahoma" size="2">Demikian kami sampaikan, atas 
								kerjasama Saudara, kami ucapkan terima kasih.
								<BR>
								<BR>
								<BR>
							</FONT>
						</td>
						<TD></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px"></TD>
						<td style="WIDTH: 529px"><FONT face="Tahoma" size="2">Hormat kami,<BR>
								<STRONG>PT. BANK MANDIRI (PERSERO)</STRONG></FONT></td>
						<TD><STRONG></STRONG></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px"><STRONG></STRONG></TD>
						<td style="WIDTH: 529px"><STRONG><FONT face="Georgia" size="2">
									<asp:Label id="LBL_JCCO_TTD" runat="server" ForeColor="Blue" Font-Size="X-Small" Font-Names="Tahoma"
										Height="8px" Font-Bold="True"></asp:Label></FONT></STRONG></td>
						<TD><STRONG></STRONG></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px"><STRONG></STRONG></TD>
						<td style="WIDTH: 529px"><STRONG><FONT face="Georgia" size="2">
									<asp:Label id="LBL_ALAMAT_JCCO_TTD" runat="server" ForeColor="Blue" Font-Size="X-Small" Font-Names="Tahoma"
										Height="8px" Font-Bold="True"></asp:Label></FONT></STRONG></td>
						<TD></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px"></TD>
						<td style="WIDTH: 529px">
							<P><BR>
								<BR>
								&nbsp;</P>
						</td>
						<TD></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px"></TD>
						<td style="WIDTH: 529px"><STRONG><U><FONT face="Georgia" size="2">
										<asp:Label id="LBL_NAMA_TTD" runat="server" ForeColor="Blue" Font-Size="X-Small" Font-Names="Tahoma"
											Height="8px" Font-Bold="True"></asp:Label></FONT></U></STRONG></td>
						<TD></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px"></TD>
						<td style="WIDTH: 529px"><STRONG><FONT face="Georgia" size="2">
									<asp:Label id="LBL_DEPT_TTD" runat="server" ForeColor="Blue" Font-Size="X-Small" Font-Names="Tahoma"
										Height="8px" Font-Bold="True"></asp:Label></FONT></STRONG></td>
						<TD></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px"></TD>
						<td style="WIDTH: 529px"></td>
						<TD></TD>
					</tr>
					<TR>
						<TD style="WIDTH: 111px" align="center"></TD>
						<TD align="center" style="WIDTH: 529px">&nbsp;</TD>
						<TD align="center"></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
