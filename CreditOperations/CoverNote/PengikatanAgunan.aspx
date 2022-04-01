<%@ Page language="c#" Codebehind="PengikatanAgunan.aspx.cs" AutoEventWireup="True" Inherits="SME.CreditProposal.PengikatanAgunan" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Surat Perintah ke Notaris untuk Pengikatan</title>
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
						<TD class="TDBGColor2" style="WIDTH: 115px" align="center"></TD>
						<TD align="center" style="WIDTH: 529px">
							<asp:button id="BTN_VIEW" Runat="server" Text="View" Width="100px" onclick="BTN_VIEW_Click"></asp:button>&nbsp;<INPUT id="BTN_CLOSE" style="WIDTH: 101px; HEIGHT: 24px" onclick="javascript:window.close();"
								type="button" value="Close" name="BTNCANCEL"></TD>
						<TD class="TDBGColor2" align="center"></TD>
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
										<asp:TextBox id="TXT_LAMPIRAN1" runat="server" Width="112px" ForeColor="Blue" Font-Size="X-Small"
											Font-Names="Tahoma" Height="22px">-</asp:TextBox></TD>
								</TR>
							</TABLE>
							<BR>
						</td>
						<TD style="HEIGHT: 81px"></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px"></TD>
						<td style="WIDTH: 529px"><FONT face="Tahoma"><FONT size="2">Kepada Yth :</FONT>
								<BR>
							</FONT>
							<asp:TextBox id="TXT_NAMA_NOTARIS" runat="server" Width="384px" Height="22px" Font-Names="Tahoma"
								Font-Size="X-Small" ForeColor="Blue" ReadOnly="True" BorderColor="Black"></asp:TextBox><BR>
							<asp:TextBox id="TXT_ALAMAT1_NOTARIS" runat="server" Width="384px" Height="22px" Font-Names="Tahoma"
								Font-Size="X-Small" ForeColor="Blue" ReadOnly="True" BorderColor="Black"></asp:TextBox><BR>
							<asp:TextBox id="TXT_ALAMAT2_NOTARIS" runat="server" Width="384px" Height="22px" Font-Names="Tahoma"
								Font-Size="X-Small" ForeColor="Blue" ReadOnly="True" BorderColor="Black"></asp:TextBox><BR>
							<asp:TextBox id="TXT_ALAMAT3_NOTARIS" runat="server" Width="384px" Height="22px" Font-Names="Tahoma"
								Font-Size="X-Small" ForeColor="Blue" ReadOnly="True" BorderColor="Black"></asp:TextBox><BR>
							<asp:TextBox id="TXT_TELP_NOTARIS" runat="server" Width="384px" Height="22px" Font-Names="Tahoma"
								Font-Size="X-Small" ForeColor="Blue" ReadOnly="True" BorderColor="Black"></asp:TextBox><BR>
							<BR>
						</td>
						<TD></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px"></TD>
						<td style="WIDTH: 529px"><FONT face="Georgia" size="2"><FONT face="Tahoma">Perihal : <STRONG>Pengikatan 
										agunan atas nama Debitur</STRONG></FONT>&nbsp;</FONT>
							<asp:TextBox id="TXT_NAMA_DEBITUR" runat="server" Width="200px" Height="22px" Font-Names="Tahoma"
								Font-Size="X-Small" ForeColor="Blue" ReadOnly="True" BorderColor="Black"></asp:TextBox><BR>
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
						<td style="VERTICAL-ALIGN: baseline; WIDTH: 529px; HEIGHT: 100px; TEXT-ALIGN: justify"><FONT size="2" style="VERTICAL-ALIGN: baseline; TEXT-ALIGN: justify"><FONT face="Tahoma">Berkenaan 
									dengan telah disetujuinya pemberian penambahan fasilitas kredit kepada Debitur 
									tersebut diatas, dengan ini kami harapkan bantuan Saudara untuk mengadakan 
									pengikatan atas </FONT>
								<asp:TextBox id="TXT_DIIKAT" runat="server" Width="489px" Height="20px" Font-Names="Tahoma" Font-Size="X-Small"
									ForeColor="Blue"></asp:TextBox><FONT face="Tahoma">&nbsp;</FONT></FONT><FONT size="2"><FONT face="Tahoma">a/n.&nbsp;
								</FONT>
								<asp:TextBox id="TXT_AN" runat="server" Width="298px" Height="22px" Font-Names="Tahoma" Font-Size="X-Small"
									ForeColor="Blue"></asp:TextBox></FONT><FONT face="Tahoma" size="2">&nbsp;dengan
							</FONT><FONT size="2">
								<asp:TextBox id="TXT_HAK_TANGGUNG" runat="server" Width="258px" Height="22px" Font-Names="Tahoma"
									Font-Size="X-Small" ForeColor="Blue">Hak Tanggungan Peringkat I (Pertama)</asp:TextBox><FONT face="Tahoma">&nbsp;untuk 
									kepentingan PT. Bank Mandiri (Persero) </FONT>
								<asp:TextBox id="TXT_JCCO" runat="server" Width="232px" ForeColor="Blue" Font-Size="X-Small"
									Font-Names="Tahoma" Height="22px"></asp:TextBox><FONT face="Tahoma">&nbsp;sebesar 
									Rp.&nbsp; </FONT>
								<asp:TextBox id="TXT_JUMLAH_IKAT" runat="server" Width="211px" Height="22px" Font-Names="Tahoma"
									Font-Size="X-Small" ForeColor="Blue"></asp:TextBox><FONT face="Tahoma">&nbsp;( </FONT>
								<asp:TextBox id="TXT_JUMLAH_IKAT_TERBILANG" runat="server" Width="368px" Height="22px" Font-Names="Tahoma"
									Font-Size="X-Small" ForeColor="Blue"></asp:TextBox><FONT face="Tahoma">).<BR>
									<BR>
								</FONT></FONT>
						</td>
						<TD style="HEIGHT: 100px"></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px"></TD>
						<td style="WIDTH: 529px"><FONT face="Tahoma" size="2">Berkenaan dengan hal tersebut 
								diatas, kami lampirkan :</FONT></td>
						<TD></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px"></TD>
						<td style="WIDTH: 530px">
							<asp:TextBox id="TXT_LAMPIRAN" runat="server" Width="456px" ForeColor="Blue" Font-Size="X-Small"
								Font-Names="Tahoma" Height="120px" TextMode="MultiLine"></asp:TextBox>
							<BR>
						</td>
						<TD><FONT face="Tahoma" size="2"></FONT></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px"><FONT face="Tahoma" size="2"></FONT></TD>
						<td style="VERTICAL-ALIGN: baseline; WIDTH: 529px; TEXT-ALIGN: justify"><FONT style="VERTICAL-ALIGN: baseline; TEXT-ALIGN: justify"><FONT face="Tahoma" size="2">Seluruh 
									biaya yang timbul sehubungan dengan pengikatan tersebut diatas merupakan beban 
									yang bersangkutan dan penagihannya agar Saudara ajukan kepada kami dan pada 
									saat pengambilan berkas tersebut mohon Saudara buatkan tanda terima sebagai 
									mestinya.<BR>
									<BR>
								</FONT></FONT>
						</td>
						<TD></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px"></TD>
						<td style="VERTICAL-ALIGN: baseline; WIDTH: 529px; TEXT-ALIGN: justify"><FONT face="Tahoma" size="2">Apabila 
								masih ada data lainnya yang masih diperlukan, mohon segera diinformasikan 
								kepada kami pada kesempatan pertama dengan &nbsp; </FONT>
							<asp:TextBox id="TXT_CP_BM" runat="server" Width="176px" Height="22px" Font-Names="Tahoma" Font-Size="X-Small"
								ForeColor="Blue"></asp:TextBox><FONT size="2"><FONT face="Tahoma">&nbsp; <STRONG>telp </STRONG>
								</FONT></FONT>
							<asp:TextBox id="TXT_TLP_CP_BM" runat="server" Width="152px" Height="22px" Font-Names="Tahoma"
								Font-Size="X-Small" ForeColor="Blue"></asp:TextBox><FONT face="Tahoma" size="2">.<BR>
								<BR>
							</FONT>
						</td>
						<TD></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px"></TD>
						<td style="WIDTH: 529px"><FONT face="Tahoma" size="2">Demikian kami sampaikan, atas 
								kerjasama Saudara kami ucapkan terima kasih.<BR>
								<BR>
								<BR>
							</FONT>
						</td>
						<TD></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px"></TD>
						<td style="WIDTH: 529px"><STRONG><FONT face="Tahoma" size="2">PT. BANK MANDIRI (PERSERO)</FONT></STRONG></td>
						<TD><STRONG></STRONG></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px"><STRONG></STRONG></TD>
						<td style="WIDTH: 529px"><STRONG><FONT face="Georgia" size="2"><EM>
										<asp:TextBox id="TXT_JCCO_TTD" runat="server" Width="232px" ForeColor="Blue" Font-Size="X-Small"
											Font-Names="Tahoma" Height="22px"></asp:TextBox></EM></FONT></STRONG></td>
						<TD><STRONG></STRONG></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px"><STRONG></STRONG></TD>
						<td style="WIDTH: 529px"><STRONG><FONT face="Georgia" size="2"><EM>
										<asp:TextBox id="TXT_ALAMAT_JCCO_TTD" runat="server" Width="232px" ForeColor="Blue" Font-Size="X-Small"
											Font-Names="Tahoma" Height="22px"></asp:TextBox></EM></FONT></STRONG></td>
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
												Font-Names="Tahoma" Height="22px" Font-Underline="True"></asp:TextBox></EM></FONT></U></STRONG></td>
						<TD></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px"></TD>
						<td style="WIDTH: 529px"><STRONG><FONT face="Georgia" size="2"><EM>
										<asp:TextBox id="TXT_DEPT_TTD" runat="server" Width="232px" ForeColor="Blue" Font-Size="X-Small"
											Font-Names="Tahoma" Height="22px"></asp:TextBox></EM></FONT></STRONG></td>
						<TD></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px"></TD>
						<td style="WIDTH: 529px"></td>
						<TD></TD>
					</tr>
					<TR>
						<TD class="TDBGColor2" style="WIDTH: 111px" align="center"></TD>
						<TD align="center" style="WIDTH: 529px">
							<asp:button id="BTN_VIEW_2" Runat="server" Text="View" Width="100px" onclick="BTN_VIEW_2_Click"></asp:button></TD>
						<TD class="TDBGColor2" align="center"></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
