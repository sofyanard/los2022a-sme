<%@ Page language="c#" Codebehind="AsuransiJaminan.aspx.cs" AutoEventWireup="True" Inherits="SME.CreditOperations.AsuransiJaminan" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Asuransi Jaminan</title>
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
						<TD align="center" style="WIDTH: 618px">
							<asp:button id="BTN_VIEW" Runat="server" Text="View" Width="100px" onclick="BTN_VIEW_Click"></asp:button>&nbsp;<INPUT id="BTN_CLOSE" style="WIDTH: 101px; HEIGHT: 24px" onclick="javascript:window.close();"
								type="button" value="Close" name="BTNCANCEL"></TD>
						<TD align="center"></TD>
					</TR>
					<tr>
						<TD style="WIDTH: 111px; HEIGHT: 81px"></TD>
						<td style="WIDTH: 618px; HEIGHT: 81px">
							<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="496" border="0" style="WIDTH: 496px; HEIGHT: 67px">
								<TR>
									<TD style="WIDTH: 87px"><FONT face="Tahoma" size="2">Nomor</FONT></TD>
									<TD style="WIDTH: 8px"><FONT face="Tahoma" size="2">:</FONT></TD>
									<TD>
										<asp:TextBox id="TXT_NO_SURAT" runat="server" Width="384px" Height="22px" Font-Names="Tahoma"
											Font-Size="X-Small" ForeColor="Blue">JNK.JCO/JCCO V. 4868 /2003</asp:TextBox><FONT face="Tahoma"></FONT></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 87px"><FONT face="Tahoma" size="2">Tanggal</FONT></TD>
									<TD style="WIDTH: 8px"><FONT face="Tahoma" size="2">:</FONT></TD>
									<TD>
										<asp:TextBox id="TXT_TANGGAL" runat="server" Width="112px" Height="22px" Font-Names="Tahoma"
											Font-Size="X-Small" ForeColor="Blue" ReadOnly="True" BorderStyle="Solid" BorderColor="Black">01 Agustus 2003</asp:TextBox><FONT face="Tahoma"></FONT></TD>
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
						<td style="WIDTH: 618px"><FONT face="Tahoma"><FONT size="2"><STRONG>Kepada Yth :</STRONG></FONT>
								<BR>
							</FONT>
							<asp:TextBox id="TXT_NAMA_PT" runat="server" Width="289" ForeColor="Blue" Font-Size="X-Small"
								Font-Names="Tahoma" Height="21px" ReadOnly="True" BorderStyle="Solid" BorderColor="Black"></asp:TextBox><BR>
							<asp:TextBox id="TXT_ALAMAT1_PT" runat="server" Width="289px" ForeColor="Blue" Font-Size="X-Small"
								Font-Names="Tahoma" Height="21px" ReadOnly="True" BorderStyle="Solid" BorderColor="Black"></asp:TextBox><BR>
							<asp:TextBox id="TXT_ALAMAT2_PT" runat="server" Width="289px" ForeColor="Blue" Font-Size="X-Small"
								Font-Names="Tahoma" Height="21px" ReadOnly="True" BorderStyle="Solid" BorderColor="Black"></asp:TextBox><BR>
							<asp:TextBox id="TXT_ALAMAT3_PT" runat="server" Width="289px" ForeColor="Blue" Font-Size="X-Small"
								Font-Names="Tahoma" Height="21px" ReadOnly="True" BorderStyle="Solid" BorderColor="Black"></asp:TextBox><BR>
							<asp:TextBox id="TXT_TELP_PT" runat="server" Width="289px" ForeColor="Blue" Font-Size="X-Small"
								Font-Names="Tahoma" Height="21px" ReadOnly="True" BorderStyle="Solid" BorderColor="Black"></asp:TextBox><BR>
							<BR>
							<BR>
						</td>
						<TD></TD>
					</tr>
					<TR>
						<TD style="WIDTH: 111px"></TD>
						<TD style="WIDTH: 618px"><FONT face="Tahoma" size="2">u.p. </FONT>
							<asp:TextBox id="TXT_UP" runat="server" Width="384px" ForeColor="Blue" Font-Size="X-Small" Font-Names="Tahoma"
								Height="21px" ReadOnly="True" BorderStyle="Solid" BorderColor="Black"></asp:TextBox><BR>
							<BR>
						</TD>
						<TD></TD>
					</TR>
					<tr>
						<TD style="WIDTH: 111px"></TD>
						<td style="WIDTH: 618px"><FONT face="Georgia" size="2"><FONT face="Tahoma">Perihal :&nbsp;<STRONG>Penutupan 
										asuransi agunan atas nama &nbsp;
										<asp:TextBox id="TXT_DEBITUR" runat="server" Width="213px" ForeColor="Blue" Font-Size="X-Small"
											Font-Names="Tahoma" Height="21px" ReadOnly="True" BorderStyle="Solid" BorderColor="Black"></asp:TextBox></STRONG></FONT></FONT>
							<BR>
							<BR>
						</td>
						<TD></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px; HEIGHT: 19px"></TD>
						<td style="WIDTH: 618px; HEIGHT: 19px"><FONT face="Tahoma" size="2">Dengan hormat,<BR>
								<BR>
							</FONT>
						</td>
						<TD style="HEIGHT: 19px"></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px; HEIGHT: 100px"></TD>
						<td style="VERTICAL-ALIGN: baseline; WIDTH: 619px; HEIGHT: 100px; TEXT-ALIGN: justify">
							<P><FONT size="2"><FONT face="Tahoma">Sehubungan dengan telah disetujuinya pemberian 
										penambahan fasilitas kredit kepada Debitur tersebut diatas, dengan ini kami 
										minta bantuan Saudara untuk melaksanakan penutupan asuransi dengan rincian 
										sebagai berikut :<BR>
										<BR>
										<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TBODY>
												<TR>
													<TD style="WIDTH: 13px; HEIGHT: 15px" vAlign="top"><FONT size="2">1.</FONT></TD>
													<TD style="WIDTH: 160px; HEIGHT: 15px" vAlign="top"><FONT size="2"><STRONG>Nama Tertanggung</STRONG></FONT></TD>
													<TD style="WIDTH: 8px; HEIGHT: 15px; TEXT-ALIGN: justify" vAlign="top"><FONT size="2">:</FONT></TD>
													<TD style="HEIGHT: 15px; TEXT-ALIGN: justify"><FONT size="2"><FONT size="2">
																<asp:TextBox id="TXT_DEBITUR_NAME" runat="server" Width="312px" ForeColor="Blue" Font-Size="X-Small"
																	Font-Names="Tahoma" Height="21px" ReadOnly="True" BorderColor="Black"></asp:TextBox>
															</FONT></FONT>
													</TD>
												</TR>
												<TR>
													<TD style="WIDTH: 13px" vAlign="top"><FONT size="2">2.</FONT></TD>
													<TD style="WIDTH: 160px" vAlign="top"><FONT size="2">Alamat Tertanggung</FONT></TD>
													<TD style="WIDTH: 8px; TEXT-ALIGN: justify" vAlign="top"><FONT size="2">:</FONT></TD>
													<TD style="TEXT-ALIGN: justify"><FONT size="2">
															<asp:TextBox id="TXT_DEBITUR_ADDR" runat="server" Width="432px" ForeColor="Blue" Font-Size="X-Small"
																Font-Names="Tahoma" Height="21px" ReadOnly="True" BorderColor="Black"></asp:TextBox></FONT>
													</TD>
												</TR>
												<TR>
													<TD style="WIDTH: 13px; HEIGHT: 14px" vAlign="top"><FONT size="2">3.</FONT></TD>
													<TD style="WIDTH: 160px; HEIGHT: 14px" vAlign="top"><FONT size="2"><STRONG>Obyek 
																Pertanggungan</STRONG></FONT></TD>
													<TD style="WIDTH: 8px; HEIGHT: 14px" vAlign="top"><FONT size="2">:</FONT></TD>
													<TD style="HEIGHT: 14px"><FONT size="2">
															<asp:TextBox id="TXT_OBYEK_TANGGUNG" runat="server" Width="264px" ForeColor="Blue" Font-Size="X-Small"
																Font-Names="Tahoma" Height="21px" ReadOnly="True" BorderColor="Black"></asp:TextBox></FONT>
													</TD>
												</TR>
												<TR>
													<TD style="WIDTH: 13px" vAlign="top"><FONT size="2">4.</FONT></TD>
													<TD style="WIDTH: 160px" vAlign="top"><FONT size="2">Nilai Pertanggungan</FONT></TD>
													<TD style="WIDTH: 8px; TEXT-ALIGN: justify" vAlign="top"><FONT size="2">:</FONT></TD>
													<TD style="TEXT-ALIGN: justify"><FONT size="2">Rp.
															<asp:TextBox id="TXT_ACA_AMOUNT" runat="server" Width="152px" ForeColor="Blue" Font-Size="X-Small"
																Font-Names="Tahoma" Height="21px" ReadOnly="True" BorderColor="Black"></asp:TextBox>&nbsp;,-</FONT>
													</TD>
												</TR>
												<TR>
													<TD style="WIDTH: 13px" vAlign="top"><FONT size="2">5.</FONT></TD>
													<TD style="WIDTH: 160px" vAlign="top"><FONT size="2">Lokasi Pertanggungan</FONT></TD>
													<TD style="WIDTH: 8px" vAlign="top"><FONT size="2">:</FONT></TD>
													<TD><FONT size="2">
															<asp:TextBox id="TXT_LOKASI_TANGGUNG" runat="server" Width="432px" ForeColor="Blue" Font-Size="X-Small"
																Font-Names="Tahoma" Height="21px" ReadOnly="True" BorderColor="Black"></asp:TextBox></FONT>
													</TD>
												</TR>
												<TR>
													<TD style="WIDTH: 13px" vAlign="top"><FONT size="2">6.</FONT></TD>
													<TD style="WIDTH: 160px" vAlign="top"><FONT size="2">Jangka Waktu Pertanggungan</FONT></TD>
													<TD style="WIDTH: 8px" vAlign="top"><FONT size="2">:</FONT></TD>
													<TD><FONT size="2">
															<asp:TextBox id="TXT_ACA_DURATION" runat="server" Width="112px" ForeColor="Blue" Font-Size="X-Small"
																Font-Names="Tahoma" Height="21px" ReadOnly="True" BorderColor="Black"></asp:TextBox>&nbsp;bulan 
															tmt.penutupan asuransi sejak diterimanya surat ini.</FONT>
													</TD>
												</TR>
												<TR>
													<TD style="WIDTH: 13px" vAlign="top"><FONT size="2">7.</FONT></TD>
													<TD style="WIDTH: 160px" vAlign="top"><FONT size="2"><STRONG>Banker's Clause</STRONG></FONT></TD>
													<TD style="WIDTH: 8px" vAlign="top"><FONT size="2">:</FONT></TD>
													<TD><FONT size="2"><STRONG>PT. BANK MANDIRI (Persero)</STRONG></FONT></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 13px" vAlign="top"><FONT size="2">8.</FONT></TD>
													<TD style="WIDTH: 160px" vAlign="top"><FONT size="2">Lain-lain</FONT></TD>
													<TD style="WIDTH: 8px" vAlign="top"><FONT size="2">:</FONT></TD>
													<TD><FONT size="2">
															<asp:TextBox id="TXT_LAIN_LAIN" runat="server" Width="432px" ForeColor="Blue" Font-Size="X-Small"
																Font-Names="Tahoma" Height="120px" TextMode="MultiLine"></asp:TextBox></FONT></TD>
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
						<td style="WIDTH: 618px"><FONT face="Tahoma" size="2">Apabila ada data lainnya yang 
								Saudara perlukan dalam rangka hal tersebut diatas, mohon diinformasikan kepada 
								kami dalam kesempatan pertama dengan
								<asp:TextBox id="TXT_CP_BM" runat="server" Width="232px" ForeColor="Blue" Font-Size="X-Small"
									Font-Names="Tahoma" Height="21px">Sdr. Daryanto</asp:TextBox>&nbsp;<STRONG>telp.</STRONG>
								<asp:TextBox id="TXT_CP_BM_PHN" runat="server" Width="192px" ForeColor="Blue" Font-Size="X-Small"
									Font-Names="Tahoma" Height="21px">5266566 ext. 1299</asp:TextBox>
								<BR>
								<BR>
								<BR>
							</FONT>
						</td>
						<TD></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px"></TD>
						<td style="WIDTH: 618px"><FONT face="Tahoma" size="2">Hormat kami,<BR>
								<STRONG>PT. BANK MANDIRI (PERSERO)</STRONG></FONT></td>
						<TD><STRONG></STRONG></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px"><STRONG></STRONG></TD>
						<td style="WIDTH: 618px"><STRONG><FONT face="Georgia" size="2"><EM>
										<asp:TextBox id="TXT_JCCO_TTD" runat="server" Width="232px" ForeColor="Blue" Font-Size="X-Small"
											Font-Names="Tahoma" Height="21px"></asp:TextBox></EM></FONT></STRONG></td>
						<TD><STRONG></STRONG></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px"><STRONG></STRONG></TD>
						<td style="WIDTH: 618px"><STRONG><FONT face="Georgia" size="2"><EM>
										<asp:TextBox id="TXT_ALAMAT_JCCO_TTD" runat="server" Width="232px" ForeColor="Blue" Font-Size="X-Small"
											Font-Names="Tahoma" Height="21px"></asp:TextBox></EM></FONT></STRONG></td>
						<TD></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px"></TD>
						<td style="WIDTH: 618px">
							<P><BR>
								<BR>
								&nbsp;</P>
						</td>
						<TD></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px"></TD>
						<td style="WIDTH: 618px"><STRONG><U><FONT face="Georgia" size="2"><EM>
											<asp:TextBox id="TXT_NAMA_TTD" runat="server" Width="232px" ForeColor="Blue" Font-Size="X-Small"
												Font-Names="Tahoma" Height="21px" Font-Underline="True"></asp:TextBox></EM></FONT></U></STRONG></td>
						<TD></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px"></TD>
						<td style="WIDTH: 618px"><STRONG><FONT face="Georgia" size="2"><EM>
										<asp:TextBox id="TXT_DEPT_TTD" runat="server" Width="232px" ForeColor="Blue" Font-Size="X-Small"
											Font-Names="Tahoma" Height="21px"></asp:TextBox></EM></FONT></STRONG></td>
						<TD></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px"></TD>
						<td style="WIDTH: 618px"></td>
						<TD></TD>
					</tr>
					<TR>
						<TD style="WIDTH: 111px" align="center"></TD>
						<TD align="center" style="WIDTH: 618px">
							<asp:button id="BTN_VIEW_2" Width="100px" Text="View" Runat="server" onclick="BTN_VIEW_2_Click"></asp:button></TD>
						<TD align="center"></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
