<%@ Page language="c#" Codebehind="CollateralLegalSigning_Data.aspx.cs" AutoEventWireup="True" Inherits="SME.CreditOperations.NotaryAssignment.CollateralLegalSigning_Data" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CollateralLegalSigning_Data</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../../include/cek_entries.html" -->
		<!-- #include file="../../include/cek_mandatoryOnly.html" -->
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE cellSpacing="2" cellPadding="2" width="100%">
					<tr>
						<td class="tdHeader1" colSpan="2"><B>Daftar Agunan</B></td>
					</tr>
					<tr>
						<td>
							<TABLE cellSpacing="2" cellPadding="2" width="100%">
								<tr>
									<td class="td" vAlign="top" width="50%">
										<TABLE cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD class="TDBGColor1" width="150">Deskripsi</TD>
												<TD width="15"></TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_CL_DESC" ReadOnly="True" Columns="25" MaxLength="21" Runat="server"></asp:textbox></TD>
											</TR>
											<tr>
												<td class="TDBGColor1" width="150">Hasil Penilaian</td>
												<td width="15"></td>
												<td class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CL_APPRVALUE" ReadOnly="True" Columns="25"
														MaxLength="21" Runat="server" CssClass="angka"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Nilai Awal</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CL_OFFERVALUE" ReadOnly="True" Columns="25"
														MaxLength="21" Runat="server" CssClass="angka"></asp:textbox></td>
											</tr>
										</TABLE>
										<asp:label id="LBL_REGNO" Runat="server" Visible="False"></asp:label><asp:label id="LBL_CUREF" Runat="server" Visible="False"></asp:label><asp:label id="LBL_TC" Runat="server" Visible="False"></asp:label><asp:label id="LBL_CL_SEQ" Runat="server" Visible="False"></asp:label><asp:label id="LBL_CL_TYPE" Runat="server" Visible="False"></asp:label><asp:label id="LBL_APPTYPE" Runat="server" Visible="False"></asp:label></td>
									<td class="td" vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<td class="TDBGColor1" vAlign="top" width="150">Alamat</td>
												<td width="15"></td>
												<td class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CL_SERTADDR1" ReadOnly="True" Columns="25"
														MaxLength="30" Runat="server"></asp:textbox><BR>
													<asp:textbox onkeypress="return kutip_satu()" id="TXT_CL_SERTADDR2" ReadOnly="True" Columns="25"
														MaxLength="30" Runat="server"></asp:textbox><BR>
													<asp:textbox onkeypress="return kutip_satu()" id="TXT_CL_SERTADDR3" ReadOnly="True" Columns="25"
														MaxLength="30" Runat="server"></asp:textbox></td>
											</tr>
										</TABLE>
										<asp:checkbox id="CHB_CL_SERTADDRSM" Runat="server" Visible="False" Text="Sesuai Sertifikat"></asp:checkbox>&nbsp;&nbsp;&nbsp;
										<asp:label id="LBL_PRODUCTID" Runat="server" Visible="False"></asp:label></td>
								</tr>
							</TABLE>
						</td>
					<tr>
						<td class="tdHeader1"><B>Asuransi Jaminan</B></td>
					</tr>
					<tr>
						<td><asp:datagrid id="DataGrid1" runat="server" PageSize="3" AutoGenerateColumns="False" Width="100%"
								CellPadding="1" AllowPaging="True">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="SEQ">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="ICT_DESC" HeaderText="Type">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="INSRCOMPDESC" HeaderText="Nama Perusahaan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="INSRTYPEDESC" HeaderText="Tipe Asuransi">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AN_POLICYNO" HeaderText="No Polis">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AN_CUR" HeaderText="Mata Uang">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="ACA_VALUE" HeaderText="Nilai Pertanggungan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AN_DATESTART" HeaderText="Tanggal Mulai">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AN_DATEEND" HeaderText="Tanggal Akhir">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="ACA_PERCENTAGE" HeaderText="% Pertanggungan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="ACA_CLASS" HeaderText="Klasifikasi">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="ACA_PREMI" HeaderText="Premi">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="IC_ID"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="IT_ID"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="RATE"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="ICT_ID"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="CUR_ID"></asp:BoundColumn>
									<asp:BoundColumn DataField="ICT_LEADDESC" HeaderText="Status">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="BROKER_ID"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="ACA_AMOUNT_BANG"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="ACA_AMOUNT_MESIN"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="ACA_AMOUNT_LAIN"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="ACA_PREMI_DIBAYAR"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="ACA_PREMIDATE"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="ACA_ORDERNO"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="ACA_ORDERDATE"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="ACA_COVERNO"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="ACA_COVERDATE"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="ACA_COVERDUEDATE"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="ACA_POLICYDATE"></asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Fungsi">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="BTNEDIT" runat="server" CommandName="edit">Ubah</asp:LinkButton>&nbsp;
											<asp:LinkButton id="BTNDEL" runat="server" CommandName="delete">Hapus</asp:LinkButton>&nbsp;&nbsp;
											<asp:LinkButton id="BTNLNK_PRINT" runat="server" CommandName="print">Cetak</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</asp:datagrid><BR>
							<%if (Request.QueryString["na"] != "0") {%>
							<TABLE cellSpacing="2" cellPadding="2" width="100%">
								<tr>
									<td class="td" vAlign="top" width="50%">
										<TABLE cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<td class="TDBGColor1" style="HEIGHT: 23px" width="150">Jenis Asuransi</td>
												<td style="HEIGHT: 23px" width="15"></td>
												<td class="TDBGColorValue" style="HEIGHT: 23px"><asp:dropdownlist id="DDL_CI_TYPE" Runat="server" AutoPostBack="True" onselectedindexchanged="DDL_CI_TYPE_SelectedIndexChanged"></asp:dropdownlist>&nbsp;&nbsp;</td>
											</tr>
											<TR>
												<td class="TDBGColor1">Nama Perusahaan</td>
												<td></td>
												<td class="TDBGColorValue"><asp:dropdownlist id="DDL_CI_COMP" Runat="server"></asp:dropdownlist></td>
											</TR>
											<TR>
												<TD class="TDBGColor1">Rating</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_ICRATE" Runat="server"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Klasifikasi</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CI_CLASS" Columns="2" MaxLength="2" Runat="server"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Tipe</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_INSURANCECOMPANYTYPE" Runat="server"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">No. Polis</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CP_POLICYNO" Columns="25" MaxLength="20"
														Runat="server"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="150">Tanggal Polis</TD>
												<TD width="15"></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_POLICYDATE_DAY" Columns="2" MaxLength="2"
														Runat="server"></asp:textbox><asp:dropdownlist id="DDL_POLICYDATE_MONTH" Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_POLICYDATE_YEAR" Columns="4" MaxLength="4"
														Runat="server"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Asuransi Utama</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:radiobuttonlist id="RDO_LEAD" runat="server" Width="150px" Height="16px" RepeatDirection="Horizontal">
														<asp:ListItem Value="1" Selected="True">Ya</asp:ListItem>
														<asp:ListItem Value="0">Tidak</asp:ListItem>
													</asp:radiobuttonlist></TD>
											</TR>
											<tr>
												<td class="TDBGColor1" style="HEIGHT: 23px" width="150">Broker</td>
												<td style="HEIGHT: 23px" width="15"></td>
												<td class="TDBGColorValue" style="HEIGHT: 23px"><asp:dropdownlist id="DDL_CI_BROKER" Runat="server" AutoPostBack="True" onselectedindexchanged="DDL_CI_TYPE_SelectedIndexChanged"></asp:dropdownlist>&nbsp;&nbsp;</td>
											</tr>
											<TR>
												<td class="TDBGColor1" width="150">Nilai Pertanggungan Bangunan</td>
												<td width="15"></td>
												<td class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CI_AMNT_BANG" Columns="25" MaxLength="20"
														Runat="server" CssClass="angka"></asp:textbox></td>
											</TR>
											<TR>
												<td class="TDBGColor1" width="150">Nilai Pertanggungan Mesin</td>
												<td width="15"></td>
												<td class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CI_AMNT_MESIN" Columns="25" MaxLength="20"
														Runat="server" CssClass="angka"></asp:textbox></td>
											</TR>
											<TR>
												<td class="TDBGColor1" width="150">Nilai Pertanggungan Lain</td>
												<td width="15"></td>
												<td class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CI_AMNT_LAIN" Columns="25" MaxLength="20"
														Runat="server" CssClass="angka"></asp:textbox></td>
											</TR>
										</TABLE>
									</td>
									<TD class="td" vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD class="TDBGColor1" width="150">Mata Uang</TD>
												<TD width="15"></TD>
												<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CP_CUR" runat="server"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<td class="TDBGColor1" width="150">Nilai Pertanggungan</td>
												<td width="15"></td>
												<td class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CI_AMNT" Columns="25" MaxLength="20" Runat="server"
														CssClass="angka"></asp:textbox></td>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="150">Tanggal mulai</TD>
												<TD width="15"></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_DATESTART_DAY" Columns="2" MaxLength="2"
														Runat="server"></asp:textbox><asp:dropdownlist id="DDL_DATESTART_MONTH" Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_DATESTART_YEAR" Columns="4" MaxLength="4"
														Runat="server"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="150">Tanggal akhir</TD>
												<TD width="15"></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_DATEEND_DAY" Columns="2" MaxLength="2"
														Runat="server"></asp:textbox><asp:dropdownlist id="DDL_DATEEND_MONTH" Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_DATEEND_YEAR" Columns="4" MaxLength="4"
														Runat="server"></asp:textbox></TD>
											</TR>
											<tr>
												<td class="TDBGColor1">% Pertanggungan</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CI_INSRPCT" Columns="4" MaxLength="4" Runat="server"
														CssClass="angkamandatory"></asp:textbox>%</td>
											</tr>
											<TR>
												<TD class="TDBGColor1">Premi</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CI_PREMI" Columns="25" MaxLength="20" Runat="server"
														CssClass="angka"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Premi yang Telah Dibayar</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CI_PREMI_DIBAYAR" Columns="25" MaxLength="20"
														Runat="server" CssClass="angka"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="150">Tanggal Premi</TD>
												<TD width="15"></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_PREMIDATE_DAY" Columns="2" MaxLength="2"
														Runat="server"></asp:textbox><asp:dropdownlist id="DDL_PREMIDATE_MONTH" Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_PREMIDATE_YEAR" Columns="4" MaxLength="4"
														Runat="server"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">No. Surat Order Asuransi</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CI_ORDERNO" Columns="25" MaxLength="20"
														Runat="server"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="150">Tanggal Surat Order Asuransi</TD>
												<TD width="15"></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_ORDERDATE_DAY" Columns="2" MaxLength="2"
														Runat="server"></asp:textbox><asp:dropdownlist id="DDL_ORDERDATE_MONTH" Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_ORDERDATE_YEAR" Columns="4" MaxLength="4"
														Runat="server"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">No. Cover Note</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CI_COVERNO" Columns="25" MaxLength="20"
														Runat="server"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="150">Tanggal Cover Note</TD>
												<TD width="15"></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_COVERDATE_DAY" Columns="2" MaxLength="2"
														Runat="server"></asp:textbox><asp:dropdownlist id="DDL_COVERDATE_MONTH" Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_COVERDATE_YEAR" Columns="4" MaxLength="4"
														Runat="server"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="150">Jatuh Tempo Cover Note</TD>
												<TD width="15"></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_COVERDUEDATE_DAY" Columns="2" MaxLength="2"
														Runat="server"></asp:textbox><asp:dropdownlist id="DDL_COVERDUEDATE_MONTH" Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_COVERDUEDATE_YEAR" Columns="4" MaxLength="4"
														Runat="server"></asp:textbox></TD>
											</TR>
										</TABLE>
									</TD>
								</tr>
								<TR>
									<TD class="td" vAlign="top" align="center" width="50%" colSpan="2"><asp:button id="BTN_TAMBAH" runat="server" Text="Tambah" cssclass="button1" width="75px" onclick="BTN_TAMBAH_Click"></asp:button><asp:label id="LBL_H_SEQ" Runat="server" Visible="False">0</asp:label><asp:button id="BTN_CANCEL" runat="server" Visible="False" Text="Cancel" cssclass="button1"
											width="75px" onclick="BTN_CANCEL_Click"></asp:button></TD>
								</TR>
							</TABLE>
							<%}%>
						</td>
					</tr>
					<tr>
						<td class="tdHeader1"><B>Jenis Pengikatan</B></td>
					</tr>
					<tr>
						<td class="td" colSpan="2">
							<TABLE cellSpacing="0" cellPadding="0" width="100%">
								<tr>
									<td class="TDBGColor1" width="150">Dilakukan Oleh</td>
									<td width="15"></td>
									<td class="TDBGColorValue"><asp:radiobuttonlist id="RBL_LEGALSTA" runat="server" RepeatDirection="Horizontal"></asp:radiobuttonlist></td>
								</tr>
								<TR>
									<TD class="TDBGColor1" width="150">JENIS PENGIKATAN</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CL_IKATTYPE" Runat="server"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</td>
					</tr>
					<tr>
						<td class="TDBGColor2" align="center"><asp:button id="BTN_SAVE" Runat="server" 
                                CssClass="button1" Text="Simpan" onclick="BTN_SAVE_Click"></asp:button>&nbsp;
							<asp:button id="BTN_PRINT" Runat="server" CssClass="button1" 
                                Text="Cetak SP Pengikatan" onclick="BTN_PRINT_Click"></asp:button></td>
					</tr>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
