<%@ Page language="c#" Codebehind="PengikatanAgunan_Final.aspx.cs" AutoEventWireup="True" Inherits="SME.CreditProposal.PengikatanAgunan_Final" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Surat Perintah ke Notaris untuk Pengikatan</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD style="WIDTH: 115px" align="center"></TD>
						<TD align="center" style="WIDTH: 550px"><INPUT id="BTN_PRINT1" style="WIDTH: 75px; HEIGHT: 24px" onclick="javascript:window.print();"
								type="button" value="Print" name="BTNCANCEL" class="button1">&nbsp;<INPUT id="BTN_CANCEL" style="WIDTH: 75px; HEIGHT: 24px" onclick="javascript:history.back(-1)"
								type="button" value="Cancel" name="Button1" class="button1">&nbsp;<INPUT id="BTN_CLOSE" style="WIDTH: 75px; HEIGHT: 24px" onclick="javascript:window.close();"
								type="button" value="Close" name="Button1" class="button1"><FONT face="Tahoma"></FONT></TD>
						<TD align="center"></TD>
					</TR>
					<tr>
						<TD style="WIDTH: 111px; HEIGHT: 81px"></TD>
						<td style="WIDTH: 550px; HEIGHT: 81px">
							<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="496" border="0" style="WIDTH: 496px; HEIGHT: 67px">
								<TR>
									<TD style="WIDTH: 87px"><FONT face="Tahoma" size="2">Nomor</FONT></TD>
									<TD style="WIDTH: 8px"><FONT face="Tahoma">:</FONT></TD>
									<TD>
										<asp:Label id="LBL_NO_SURAT" runat="server" Width="296px" Height="8px" Font-Names="Tahoma"
											ForeColor="Blue" Font-Size="X-Small">[no_surat]</asp:Label><FONT face="Tahoma"></FONT></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 87px"><FONT face="Tahoma" size="2">Tanggal</FONT></TD>
									<TD style="WIDTH: 8px"><FONT face="Tahoma">:</FONT></TD>
									<TD>
										<asp:Label id="LBL_TANGGAL" runat="server" Width="152px" Height="8px" Font-Names="Tahoma" ForeColor="Blue"
											Font-Size="X-Small">[tanggal]</asp:Label><FONT face="Tahoma"></FONT></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 87px"><FONT face="Tahoma" size="2">Lampiran</FONT></TD>
									<TD style="WIDTH: 8px"><FONT face="Tahoma">:</FONT></TD>
									<TD><FONT face="Tahoma">
											<asp:Label id="LBL_LAMPIRAN1" runat="server" Font-Size="X-Small" ForeColor="Blue" Font-Names="Tahoma"
												Height="8px" Font-Bold="True"></asp:Label></FONT></TD>
								</TR>
							</TABLE>
							<BR>
						</td>
						<TD style="HEIGHT: 81px"></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px"></TD>
						<td style="WIDTH: 550px"><FONT face="Tahoma"><FONT size="2">Kepada Yth :</FONT>
								<BR>
							</FONT>
							<asp:Label id="LBL_NAMA_NOTARIS" runat="server" Width="449" Height="8px" Font-Bold="True" Font-Names="Tahoma"
								ForeColor="Blue" Font-Size="X-Small">[nama_notaris]</asp:Label><BR>
							<asp:Label id="LBL_ALAMAT1_NOTARIS" runat="server" Width="449px" Height="8px" Font-Names="Tahoma"
								ForeColor="Blue" Font-Size="X-Small">[alamat1_notaris]</asp:Label><BR>
							<asp:Label id="LBL_ALAMAT2_NOTARIS" runat="server" Width="449px" Height="8px" Font-Names="Tahoma"
								ForeColor="Blue" Font-Size="X-Small">[alamat2_notaris]</asp:Label><BR>
							<asp:Label id="LBL_ALAMAT3_NOTARIS" runat="server" Width="449px" Height="8px" Font-Names="Tahoma"
								ForeColor="Blue" Font-Size="X-Small">[alamat3_notaris]</asp:Label><BR>
							<asp:Label id="LBL_TELP_NOTARIS" runat="server" Width="449px" Height="8px" Font-Names="Tahoma"
								ForeColor="Blue" Font-Size="X-Small">[telp_notaris]</asp:Label><BR>
							<BR>
						</td>
						<TD></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px"></TD>
						<td style="WIDTH: 550px"><FONT face="Tahoma"><FONT size="2">Perihal : <STRONG>Pengikatan agunan 
										atas nama Debitur</STRONG>&nbsp;</FONT> </FONT>
							<asp:Label id="LBL_NAMA_DEBITUR" runat="server" Height="8px" Font-Bold="True" Font-Names="Tahoma"
								ForeColor="Blue" Font-Size="X-Small"></asp:Label><BR>
							<BR>
						</td>
						<TD></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px; HEIGHT: 19px"></TD>
						<td style="WIDTH: 550px; HEIGHT: 19px"><FONT face="Tahoma" size="2">Dengan hormat,<BR>
								<BR>
							</FONT>
						</td>
						<TD style="HEIGHT: 19px"></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px; HEIGHT: 100px"></TD>
						<td style="VERTICAL-ALIGN: baseline; WIDTH: 550px; HEIGHT: 100px; TEXT-ALIGN: justify"><FONT size="2" style="VERTICAL-ALIGN: baseline; TEXT-ALIGN: justify"><FONT face="Tahoma">Berkenaan 
									dengan telah disetujuinya pemberian penambahan fasilitas kredit kepada Debitu 
									tersebut diatas, dengan ini kami harapkan bantuan Saudara untuk mengadakan 
									pengikatan atas </FONT>
								<asp:Label id="LBL_DIIKAT" runat="server" Height="8px" Font-Bold="True" Font-Names="Tahoma"
									ForeColor="Blue" Font-Size="X-Small"></asp:Label><FONT face="Tahoma">&nbsp;</FONT></FONT><FONT size="2"><FONT face="Tahoma">a/n.&nbsp;
								</FONT>
								<asp:Label id="LBL_AN" runat="server" Height="8px" Font-Names="Tahoma" ForeColor="Blue" Font-Size="X-Small"></asp:Label></FONT><FONT face="Tahoma" size="2">&nbsp;dengan
							</FONT><FONT size="2">
								<asp:Label id="LBL_HAK_TANGGUNG" runat="server" Height="8px" Font-Bold="True" Font-Names="Tahoma"
									ForeColor="Blue" Font-Size="X-Small"></asp:Label><FONT face="Tahoma">&nbsp;untuk 
									kepentingan PT. Bank Mandiri (Persero) </FONT>
								<asp:Label id="LBL_JCCO" runat="server" Height="8px" Font-Names="Tahoma" ForeColor="Blue" Font-Size="X-Small"></asp:Label><FONT face="Tahoma">&nbsp;sebesar 
									Rp.&nbsp; </FONT>
								<asp:Label id="LBL_JUMLAH_IKAT" runat="server" Height="8px" Font-Bold="True" Font-Names="Tahoma"
									ForeColor="Blue" Font-Size="X-Small"></asp:Label><FONT face="Tahoma">&nbsp;(&nbsp;
								</FONT>
								<asp:Label id="LBL_JUMLAH_IKAT_TERBILANG" runat="server" Height="8px" Font-Names="Tahoma" ForeColor="Blue"
									Font-Size="X-Small"></asp:Label><FONT face="Tahoma">&nbsp;rupiah).<BR>
									<BR>
								</FONT></FONT>
						</td>
						<TD style="HEIGHT: 100px"></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px"></TD>
						<td style="WIDTH: 550px"><FONT face="Tahoma" size="2">Berkenaan dengan hal tersebut 
								diatas, kami lampirkan :</FONT></td>
						<TD></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px"></TD>
						<td style="WIDTH: 550px" id="PH_LAMPIRAN"><FONT size="2"><FONT face="Tahoma">
									<asp:PlaceHolder id="PH_LAMPIRAN" runat="server"></asp:PlaceHolder></FONT><BR>
								<BR>
							</FONT>
						</td>
						<TD></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px"></TD>
						<td style="VERTICAL-ALIGN: baseline; WIDTH: 550px; TEXT-ALIGN: justify"><FONT face="Tahoma" size="2" style="VERTICAL-ALIGN: baseline; TEXT-ALIGN: justify">Seluruh 
								biaya yang timbul sehubungan dengan pengikatan tersebut diatas merupakan beban 
								yang bersangkutan dan penagihannya agar Saudara ajukan kepada kami dan pada 
								saat pengambilan berkas tersebut mohon Saudara buatkan tanda terima sebagai 
								mestinya.<BR>
								<BR>
							</FONT>
						</td>
						<TD></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px"></TD>
						<td style="VERTICAL-ALIGN: baseline; WIDTH: 550px; TEXT-ALIGN: justify"><FONT size="2"><FONT face="Tahoma">Apabila 
									masih ada data lainnya yang masih diperlukan, mohon segera diinformasikan 
									kepada kami pada kesempatan pertama dengan </FONT>
								<asp:Label id="LBL_CP_BM" runat="server" Height="8px" Font-Bold="True" Font-Names="Tahoma"
									ForeColor="Blue" Font-Size="X-Small"></asp:Label>
							</FONT><FONT size="2"><FONT face="Tahoma">&nbsp; <STRONG>telp </STRONG></FONT></FONT>
							<asp:Label id="LBL_TLP_CP_BM" runat="server" Height="8px" Font-Bold="True" Font-Names="Tahoma"
								ForeColor="Blue" Font-Size="X-Small"></asp:Label><FONT face="Tahoma" size="2">.<BR>
								<BR>
							</FONT>
						</td>
						<TD></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px"></TD>
						<td style="WIDTH: 550px"><FONT face="Tahoma" size="2">Demikian kami sampaikan, atas 
								kerjasama Saudara kami ucapkan terima kasih.<BR>
								<BR>
								<BR>
							</FONT>
						</td>
						<TD></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px"></TD>
						<td style="WIDTH: 550px"><STRONG><FONT face="Tahoma" size="2">PT. BANK MANDIRI (PERSERO)</FONT></STRONG></td>
						<TD><STRONG></STRONG></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px"><STRONG></STRONG></TD>
						<td style="WIDTH: 550px"><FONT face="Tahoma" size="2">
								<asp:Label id="LBL_JCCO_TTD" runat="server" Width="456px" Height="8px" Font-Bold="True" Font-Names="Tahoma"
									ForeColor="Blue" Font-Size="X-Small">[jcco_ttd]</asp:Label></FONT></td>
						<TD><STRONG></STRONG></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px"><STRONG></STRONG></TD>
						<td style="WIDTH: 550px"><FONT face="Tahoma" size="2">
								<asp:Label id="LBL_ALAMAT_JCCO_TTD" runat="server" Width="456px" Height="8px" Font-Bold="True"
									Font-Names="Tahoma" ForeColor="Blue" Font-Size="X-Small">[alamat_jcco_ttd]</asp:Label></FONT></td>
						<TD></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px"></TD>
						<td style="WIDTH: 550px">
							<P><BR>
								<BR>
								<FONT face="Tahoma">&nbsp;</FONT></P>
						</td>
						<TD></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px"></TD>
						<td style="WIDTH: 550px"><U><FONT face="Tahoma" size="2">
									<asp:Label id="LBL_NAMA_TTD" runat="server" Width="456px" Height="8px" Font-Bold="True" Font-Names="Tahoma"
										ForeColor="Blue" Font-Size="X-Small">[nama_ttd]</asp:Label></FONT></U></td>
						<TD></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px"></TD>
						<td style="WIDTH: 550px"><FONT face="Tahoma" size="2">
								<asp:Label id="LBL_DEPT_TTD" runat="server" Width="456px" Height="8px" Font-Bold="True" Font-Names="Tahoma"
									ForeColor="Blue" Font-Size="X-Small">[dept_ttd]</asp:Label></FONT></td>
						<TD></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px"></TD>
						<td style="WIDTH: 550px"><FONT face="Tahoma"></FONT></td>
						<TD></TD>
					</tr>
					<TR>
						<TD style="WIDTH: 111px" align="center"></TD>
						<TD align="center" style="WIDTH: 550px">&nbsp;<FONT face="Tahoma"></FONT></TD>
						<TD align="center"></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
