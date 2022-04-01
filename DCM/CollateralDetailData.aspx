<%@ Page language="c#" Codebehind="CollateralDetailData.aspx.cs" AutoEventWireup="True" Inherits="SME.DCM.CollateralDetailData" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CollateralDetailData</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include  file="../include/cek_entries.html" -->
		<script language="javascript">
			function update()
			{
				conf = confirm("Are you sure you want to update?");
				if (conf)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE cellSpacing="2" cellPadding="2" width="100%">
					<tr>
						<td class="tdHeader1" align="center" width="100%" colSpan="2"><B>General Data</B></td>
					</tr>
					<tr>
						<td colSpan="2" width="100%">
							<table width="100%">
								<tr>
									<TD class="td" vAlign="top" width="50%">
										<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD class="TDBGColor1">ID Agunan</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue">
													<asp:textbox id="TXT_ID_AGUNAN" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:textbox>
												</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Jenis Agunan</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue">
													<asp:textbox id="TXT_JENIS_AGUNAN" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:textbox>
												</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Keterangan Agunan</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue">
													<asp:textbox id="TXT_KETERANGAN_AGUNAN" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:textbox>
												</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Error Message</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue">
													<asp:textbox id="TXT_ERRORMSG" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:textbox>
												</TD>
											</TR>
											<tr>
												<td colspan="3"></td>
											</tr>
											<TR>
												<TD class="TDBGColor1">Sifat Agunan</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue">
													<asp:dropdownlist id="DDL_SIFAT_AGUNAN" runat="server"></asp:dropdownlist>
												</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Nama Pemilik Agunan</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue">
													<asp:textbox id="TXT_NAMA_PEMILIK" runat="server" Width="300px"></asp:textbox>
												</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Bukti Kepemilikan</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue">
													<asp:dropdownlist id="DDL_BUKTI_KEPEMILIKAN" runat="server"></asp:dropdownlist>
												</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Status Kepemilikan</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue">
													<asp:dropdownlist id="DDL_STATUS_KEPEMILIKAN" runat="server"></asp:dropdownlist>
												</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Tgl. Terbit Sertifikat</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue">
													<asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_TERBIT_SERTIFIKAT_DD" runat="server"
														Columns="4" MaxLength="2"></asp:textbox>
													<asp:dropdownlist id="DDL_TGL_TERBIT_SERTIFIKAT_MM" runat="server"></asp:dropdownlist>
													<asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_TERBIT_SERTIFIKAT_YY" runat="server"
														Columns="4" MaxLength="4"></asp:textbox>
												</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">&nbsp;Tgl. Expired Sertifikat</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue">
													<asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_EXPIRED_SERTIFIKAT_DD" runat="server"
														Columns="4" MaxLength="2"></asp:textbox>
													<asp:dropdownlist id="DDL_TGL_EXPIRED_SERTIFIKAT_MM" runat="server"></asp:dropdownlist>
													<asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_EXPIRED_SERTIFIKAT_YY" runat="server"
														Columns="4" MaxLength="4"></asp:textbox>
												</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Alamat Agunan</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_ALAMAT_AGUNAN" runat="server" Width="300px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Lokasi Dati II</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue">
													<asp:dropdownlist id="DDL_LOKASI_DATI2" runat="server"></asp:dropdownlist>
												</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Kode Mata Uang</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CURRENCY" runat="server"></asp:dropdownlist></TD>
											</TR>
										</TABLE>
									</TD>
									<TD class="td" vAlign="top" width="50%">
										<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD class="TDBGColor1">Nilai Pasar</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_NILAI_PASAR" runat="server" Width="300px" onblur="FormatCurrency(this)"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Nilai Appraisal</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_NILAI_APPRAISAL" runat="server" Width="300px" onblur="FormatCurrency(this)"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Nilai Likuidasi</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_NILAI_LIKUIDASI" runat="server" Width="300px" onblur="FormatCurrency(this)"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Nilai NJOP</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_NILAI_NJOP" runat="server" Width="300px" onblur="FormatCurrency(this)"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Nilai Pengikatan</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_NILAI_PENGIKATAN" runat="server" Width="300px" onblur="FormatCurrency(this)"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">&nbsp;Tanggl Penilaian ke-1</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue">
													<asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_PENILAIAN_PERTAMA_DD" runat="server"
														Columns="4" MaxLength="2"></asp:textbox>
													<asp:dropdownlist id="DDL_TGL_PENILAIAN_PERTAMA_MM" runat="server"></asp:dropdownlist>
													<asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_PENILAIAN_PERTAMA_YY" runat="server"
														Columns="4" MaxLength="4"></asp:textbox>
												</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">&nbsp;Tanggl Penilaian Terakhir</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue">
													<asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_PENILAIAN_TERAKHIR_DD" runat="server"
														Columns="4" MaxLength="2"></asp:textbox>
													<asp:dropdownlist id="DDL_TGL_PENILAIAN_TERAKHIR_MM" runat="server"></asp:dropdownlist>
													<asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_PENILAIAN_TERAKHIR_YY" runat="server"
														Columns="4" MaxLength="4"></asp:textbox>
												</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Penilaian Oleh</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue">
													<asp:dropdownlist id="DDL_PENILAIAN_OLEH" runat="server"></asp:dropdownlist>
												</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Jenis Pengikatan</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_JENIS_PENGIKATAN" runat="server"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">&nbsp;Tanggal Pengikatan</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue">
													<asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_PENGIKATAN_DD" runat="server" Columns="4"
														MaxLength="2"></asp:textbox>
													<asp:dropdownlist id="DDL_TGL_PENGIKATAN_MM" runat="server"></asp:dropdownlist>
													<asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_PENGIKATAN_YY" runat="server" Columns="4"
														MaxLength="4"></asp:textbox>
												</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Asuransi</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue">
													<asp:dropdownlist id="DDL_ASURANSI" runat="server"></asp:dropdownlist>
												</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Peringkat Surat Berharga</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue">
													<asp:textbox id="TXT_PERINGKAT_SURAT" runat="server" Width="300px"></asp:textbox>
												</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">&nbsp;Tanggal Peringkat</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue">
													<asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_PERINGKAT_DD" runat="server" MaxLength="2"
														Columns="4"></asp:textbox>
													<asp:dropdownlist id="DDL_TGL_PERINGKAT_MM" runat="server"></asp:dropdownlist>
													<asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_PERINGKAT_YY" runat="server" Width="36px"
														MaxLength="4" Columns="4"></asp:textbox>
												</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Penerbit Surat Berharga</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue">
													<asp:textbox id="TXT_PENERBIT_SURAT" runat="server" Width="300px"></asp:textbox>
												</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">&nbsp;Tanggl Penerbitan</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue">
													<asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_PENERBITAN_SURAT_DD" runat="server"
														MaxLength="2" Columns="4"></asp:textbox>
													<asp:dropdownlist id="DDL_TGL_PENERBITAN_SURAT_MM" runat="server"></asp:dropdownlist>
													<asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_PENERBITAN_SURAT_YY" runat="server"
														MaxLength="4" Columns="4"></asp:textbox>
												</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">&nbsp;Tanggal Jatuh Tempo</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue">
													<asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_EXPIRED_SURAT_DD" runat="server" MaxLength="2"
														Columns="4"></asp:textbox>
													<asp:dropdownlist id="DDL_TGL_EXPIRED_SURAT_MM" runat="server"></asp:dropdownlist>
													<asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_EXPIRED_SURAT_YY" runat="server" MaxLength="4"
														Columns="4"></asp:textbox>
												</TD>
											</TR>
										</TABLE>
									</TD>
								</tr>
							</table>
						</td>
					</tr>
					<TR>
						<TD class="TDBGColor2" align="center" colSpan="2">
							<asp:button id="BTN_SAVE" Text="SAVE" Runat="server" CssClass="button1" onclick="BTN_SAVE_Click"></asp:button>&nbsp;&nbsp;
							<asp:button id="BTN_UPDATE" Width="132px" Text="UPDATE STATUS" Runat="server" CssClass="button1" onclick="BTN_UPDATE_Click"></asp:button>
						</TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
