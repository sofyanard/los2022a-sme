<%@ Page language="c#" Codebehind="AsuransiJiwa.aspx.cs" AutoEventWireup="True" Inherits="SME.CreditOperations.AsuransiJiwa" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Asuransi Jiwa</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../../include/cek_all.html" -->
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD style="WIDTH: 115px" align="center"></TD>
						<TD align="center" style="WIDTH: 529px">
							<asp:button id="BTN_VIEW" Runat="server" Text="View" Width="100px" onclick="BTN_VIEW_Click"></asp:button>&nbsp;<INPUT id="BTN_CLOSE" style="WIDTH: 101px; HEIGHT: 24px" onclick="javascript:window.close();"
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
									<TD>
										<asp:TextBox id="TXT_NO_SURAT" runat="server" Width="384px" Height="22px" Font-Names="Tahoma"
											Font-Size="X-Small" ForeColor="Blue"></asp:TextBox><FONT face="Tahoma"></FONT></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 87px"><FONT face="Tahoma" size="2">Tanggal</FONT></TD>
									<TD style="WIDTH: 8px"><FONT face="Tahoma" size="2">:</FONT></TD>
									<TD>
										<asp:TextBox id="TXT_TANGGAL" runat="server" Width="112px" Height="22px" Font-Names="Tahoma"
											Font-Size="X-Small" ForeColor="Blue" ReadOnly="True" BorderColor="Black"></asp:TextBox><FONT face="Tahoma"></FONT></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 87px"><FONT face="Tahoma" size="2">Lampiran</FONT></TD>
									<TD style="WIDTH: 8px"><FONT face="Tahoma" size="2">:</FONT></TD>
									<TD>
										<asp:TextBox id="TXT_LAMPIRAN" runat="server" Width="112px" ForeColor="Blue" Font-Size="X-Small"
											Font-Names="Tahoma" Height="22px">-</asp:TextBox></TD>
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
							<asp:TextBox id="TXT_NAMA_PT" runat="server" Width="289" ForeColor="Blue" Font-Size="X-Small"
								Font-Names="Tahoma" Height="21px" ReadOnly="True" BorderColor="Black"></asp:TextBox><BR>
							<asp:TextBox id="TXT_ALAMAT1_PT" runat="server" Width="289px" ForeColor="Blue" Font-Size="X-Small"
								Font-Names="Tahoma" Height="21px" ReadOnly="True" BorderColor="Black"></asp:TextBox><BR>
							<asp:TextBox id="TXT_ALAMAT2_PT" runat="server" Width="289px" ForeColor="Blue" Font-Size="X-Small"
								Font-Names="Tahoma" Height="21px" ReadOnly="True" BorderColor="Black"></asp:TextBox><BR>
							<asp:TextBox id="TXT_ALAMAT3_PT" runat="server" Width="289px" ForeColor="Blue" Font-Size="X-Small"
								Font-Names="Tahoma" Height="21px" ReadOnly="True" BorderColor="Black"></asp:TextBox><BR>
							<asp:TextBox id="TXT_TELP_PT" runat="server" Width="289px" ForeColor="Blue" Font-Size="X-Small"
								Font-Names="Tahoma" Height="21px" ReadOnly="True" BorderColor="Black"></asp:TextBox><BR>
							<BR>
							<BR>
						</td>
						<TD></TD>
					</tr>
					<TR>
						<TD style="WIDTH: 111px"></TD>
						<TD style="WIDTH: 529px"><FONT face="Tahoma" size="2">u.p. </FONT>
							<asp:TextBox id="TXT_UP" runat="server" Width="384px" ForeColor="Blue" Font-Size="X-Small" Font-Names="Tahoma"
								Height="21px" ReadOnly="True" BorderColor="Black"></asp:TextBox><BR>
							<BR>
						</TD>
						<TD></TD>
					</TR>
					<tr>
						<TD style="WIDTH: 111px"></TD>
						<td style="WIDTH: 529px"><FONT face="Georgia" size="2"><FONT face="Tahoma">Perihal :&nbsp;<STRONG>Penutupan 
										asuransi atas nama
										<asp:TextBox id="TXT_DEBITUR" runat="server" Width="248px" ForeColor="Blue" Font-Size="X-Small"
											Font-Names="Tahoma" Height="21px" ReadOnly="True" BorderColor="Black"></asp:TextBox></STRONG></FONT></FONT>
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
							<P><FONT size="2"><FONT face="Tahoma">Sehubungan dengan fasilitas kredit yang akan 
										diberikan kepada debitur tersebut di atas, dengan ini kami mengharapkan bantuan 
										Saudara untuk melakukan penutupan asuransi jiwa kredit dengan data-data sebagai 
										berikut :<BR>
										<BR>
										<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TBODY>
												<TR>
													<TD style="WIDTH: 131px; HEIGHT: 15px" vAlign="top"><FONT size="2">Nama</FONT></TD>
													<TD style="WIDTH: 10px; HEIGHT: 15px; TEXT-ALIGN: justify" vAlign="top"><FONT size="2">:</FONT></TD>
													<TD style="HEIGHT: 15px; TEXT-ALIGN: justify"><FONT size="2"><FONT size="2">
																<asp:TextBox id="TXT_CU_NAME" runat="server" Width="312px" ForeColor="Blue" Font-Size="X-Small"
																	Font-Names="Tahoma" Height="21px" ReadOnly="True" BorderColor="Black"></asp:TextBox>
															</FONT></FONT>
													</TD>
												</TR>
												<TR>
													<TD style="WIDTH: 131px" vAlign="top"><FONT size="2">Tanggal Lahir</FONT></TD>
													<TD style="WIDTH: 10px; TEXT-ALIGN: justify" vAlign="top"><FONT size="2">:</FONT></TD>
													<TD style="TEXT-ALIGN: justify"><FONT size="2">
															<asp:TextBox id="TXT_CU_DOB" runat="server" Width="208px" ForeColor="Blue" Font-Size="X-Small"
																Font-Names="Tahoma" Height="21px" ReadOnly="True" BorderColor="Black"></asp:TextBox></FONT>
													</TD>
												</TR>
												<TR>
													<TD style="WIDTH: 131px; HEIGHT: 14px" vAlign="top"><FONT size="2">Usia</FONT></TD>
													<TD style="WIDTH: 10px; HEIGHT: 14px" vAlign="top"><FONT size="2">:</FONT></TD>
													<TD style="HEIGHT: 14px"><FONT size="2">
															<asp:TextBox id="TXT_CU_AGE" runat="server" Width="112px" ForeColor="Blue" Font-Size="X-Small"
																Font-Names="Tahoma" Height="21px" ReadOnly="True" BorderColor="Black"></asp:TextBox>&nbsp;tahun</FONT>
													</TD>
												</TR>
												<TR>
													<TD style="WIDTH: 131px" vAlign="top"><FONT size="2">Uang pertanggungan</FONT></TD>
													<TD style="WIDTH: 10px; TEXT-ALIGN: justify" vAlign="top"><FONT size="2">:</FONT></TD>
													<TD style="TEXT-ALIGN: justify"><FONT size="2">Rp.
															<asp:TextBox id="TXT_ALI_AMOUNT" runat="server" Width="112px" ForeColor="Blue" Font-Size="X-Small"
																Font-Names="Tahoma" Height="21px" ReadOnly="True" BorderColor="Black"></asp:TextBox>&nbsp;,-</FONT>
													</TD>
												</TR>
												<TR>
													<TD style="WIDTH: 131px" vAlign="top"><FONT size="2">Masa pertanggungan</FONT></TD>
													<TD style="WIDTH: 10px" vAlign="top"><FONT size="2">:</FONT></TD>
													<TD><FONT size="2">
															<asp:TextBox id="TXT_ALI_DURATION" runat="server" Width="112px" ForeColor="Blue" Font-Size="X-Small"
																Font-Names="Tahoma" Height="21px" ReadOnly="True" BorderColor="Black"></asp:TextBox>&nbsp;tahun</FONT>
													</TD>
												</TR>
												<TR>
													<TD style="WIDTH: 131px" vAlign="top"><FONT size="2">Perkiraan Premi</FONT></TD>
													<TD style="WIDTH: 10px" vAlign="top"><FONT size="2">:</FONT></TD>
													<TD><FONT size="2">Rp.
															<asp:TextBox id="TXT_ALI_PREMI" runat="server" Width="112px" ForeColor="Blue" Font-Size="X-Small"
																Font-Names="Tahoma" Height="21px" ReadOnly="True" BorderColor="Black"></asp:TextBox>&nbsp;,-</FONT>
													</TD>
												</TR>
												<TR>
													<TD style="WIDTH: 131px" vAlign="top"><FONT size="2">Alamat</FONT></TD>
													<TD style="WIDTH: 10px" vAlign="top"><FONT size="2">:</FONT></TD>
													<TD><FONT size="2">
															<asp:TextBox id="TXT_CU_ADDR" runat="server" Width="384px" ForeColor="Blue" Font-Size="X-Small"
																Font-Names="Tahoma" Height="21px" ReadOnly="True" BorderColor="Black"></asp:TextBox></FONT></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 131px" vAlign="top"><FONT size="2">Telp</FONT></TD>
													<TD style="WIDTH: 10px" vAlign="top"><FONT size="2">:</FONT></TD>
													<TD><FONT size="2">
															<asp:TextBox id="TXT_CU_PHN" runat="server" Width="232px" ForeColor="Blue" Font-Size="X-Small"
																Font-Names="Tahoma" Height="21px" ReadOnly="True" BorderColor="Black"></asp:TextBox></FONT></TD>
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
						<td style="WIDTH: 529px"><STRONG><FONT face="Georgia" size="2"><EM>
										<asp:TextBox id="TXT_JCCO_TTD" runat="server" Width="232px" ForeColor="Blue" Font-Size="X-Small"
											Font-Names="Tahoma" Height="21px"></asp:TextBox></EM></FONT></STRONG></td>
						<TD><STRONG></STRONG></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px"><STRONG></STRONG></TD>
						<td style="WIDTH: 529px"><STRONG><FONT face="Georgia" size="2"><EM>
										<asp:TextBox id="TXT_ALAMAT_JCCO_TTD" runat="server" Width="232px" ForeColor="Blue" Font-Size="X-Small"
											Font-Names="Tahoma" Height="21px"></asp:TextBox></EM></FONT></STRONG></td>
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
						<td style="WIDTH: 529px"><STRONG><U><FONT face="Georgia" size="2"><EM>
											<asp:TextBox id="TXT_NAMA_TTD" runat="server" Width="232px" ForeColor="Blue" Font-Size="X-Small"
												Font-Names="Tahoma" Height="21px" Font-Underline="True"></asp:TextBox></EM></FONT></U></STRONG></td>
						<TD></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px"></TD>
						<td style="WIDTH: 529px"><STRONG><FONT face="Georgia" size="2"><EM>
										<asp:TextBox id="TXT_DEPT_TTD" runat="server" Width="232px" ForeColor="Blue" Font-Size="X-Small"
											Font-Names="Tahoma" Height="21px"></asp:TextBox></EM></FONT></STRONG></td>
						<TD></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px"></TD>
						<td style="WIDTH: 529px"></td>
						<TD></TD>
					</tr>
					<TR>
						<TD style="WIDTH: 111px" align="center"></TD>
						<TD align="center" style="WIDTH: 529px">
							<asp:button id="BTN_VIEW_2" Width="100px" Text="View" Runat="server" onclick="BTN_VIEW_2_Click"></asp:button></TD>
						<TD align="center"></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
