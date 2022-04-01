<%@ Page language="c#" Codebehind="Nota.aspx.cs" AutoEventWireup="True" Inherits="SME.LMS.Nota" %>
<%@ Register TagPrefix="uc1" TagName="DocExport" Src="../CommonForm/DocumentExport.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Nota</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_mandatory.html" -->
		<!-- #include file="../include/cek_entries.html" -->
		<!-- #include file="../include/onepost.html" -->
		<!-- #include file="../include/ConfirmBox.html" -->
		<!-- #include file="../include/cek_all.html" -->
		<!-- #include file="../include/popup.html" -->
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TBODY>
						<TR>
							<TD class="tdNoBorder"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
								<TABLE id="Table4">
									<TR>
										<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Nota Watchlist</B></TD>
									</TR>
								</TABLE>
							</TD>
							<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="../Image/back.jpg"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
						</TR>
						<TR>
							<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
						</TR>
						<TR>
							<TD class="tdheader1" colSpan="2">NOTA REVIEW ACCOUNT WATCHLIST</TD>
						</TR>
						<TR>
							<TD class="td" vAlign="top" width="50%">
								<TABLE cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="tdBGColor1" style="HEIGHT: 10px">No</TD>
										<TD style="WIDTH: 15px; HEIGHT: 10px"></TD>
										<TD class="tdBGColorValue" style="HEIGHT: 10px"><asp:textbox id="TXT_NOTANO" runat="server" Columns="50" MaxLength="50" CssClass="mandatory"></asp:textbox></TD>
									</TR>
								</TABLE>
							</TD>
							<TD class="td" vAlign="top" width="50%">
								<TABLE cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="tdBGColor1" style="HEIGHT: 10px">Tanggal</TD>
										<TD style="WIDTH: 15px; HEIGHT: 10px"></TD>
										<TD class="tdBGColorValue" style="HEIGHT: 10px"><asp:textbox onkeypress="return numbersonly()" id="TXT_NOTADATE_DAY" runat="server" Columns="2"
												MaxLength="2" CssClass="mandatory"></asp:textbox><asp:dropdownlist id="DDL_NOTADATE_MONTH" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_NOTADATE_YEAR" runat="server" Columns="4"
												MaxLength="4" CssClass="mandatory"></asp:textbox></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD class="td" vAlign="top" width="50%">
								<TABLE cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="tdBGColor1" style="HEIGHT: 10px">Group</TD>
										<TD style="WIDTH: 15px; HEIGHT: 10px"></TD>
										<TD class="tdBGColorValue" style="HEIGHT: 10px"><asp:textbox id="TXT_GROUP" runat="server" Columns="50" MaxLength="50"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="tdBGColor1" style="HEIGHT: 10px">Nasabah</TD>
										<TD style="WIDTH: 15px; HEIGHT: 10px"></TD>
										<TD class="tdBGColorValue" style="HEIGHT: 10px"><asp:textbox id="TXT_NAMANASABAH" runat="server" Columns="50" MaxLength="50" ReadOnly="True"
												BorderWidth="0px"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="tdBGColor1" style="HEIGHT: 10px">Kode Sektor Ekonomi BI</TD>
										<TD style="WIDTH: 15px; HEIGHT: 10px"></TD>
										<TD class="tdBGColorValue" style="HEIGHT: 10px"><asp:textbox id="TXT_KODESEBI" runat="server" Columns="50" MaxLength="50" ReadOnly="True" BorderWidth="0px"></asp:textbox></TD>
									</TR>
								</TABLE>
							</TD>
							<TD class="td" vAlign="top" width="50%">
								<TABLE cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="tdBGColor1" style="HEIGHT: 10px">Unit Bisnis</TD>
										<TD style="WIDTH: 15px; HEIGHT: 10px"></TD>
										<TD class="tdBGColorValue" style="HEIGHT: 10px"><asp:textbox id="TXT_UNITBISNIS" runat="server" Columns="50" MaxLength="50"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="tdBGColor1" style="HEIGHT: 10px">Account Manager</TD>
										<TD style="WIDTH: 15px; HEIGHT: 10px"></TD>
										<TD class="tdBGColorValue" style="HEIGHT: 10px"><asp:textbox id="TXT_ACCMGR" runat="server" Columns="50" MaxLength="50" ReadOnly="True" BorderWidth="0px"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="tdBGColor1" style="HEIGHT: 10px">Kode Sektor Ekonomi BM</TD>
										<TD style="WIDTH: 15px; HEIGHT: 10px"></TD>
										<TD class="tdBGColorValue" style="HEIGHT: 10px"><asp:textbox id="TXT_KODESEBM" runat="server" Columns="50" MaxLength="50" ReadOnly="True" BorderWidth="0px"></asp:textbox></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD class="tdheader1" colSpan="2">Informasi Fasilitas Nasabah</TD>
						</TR>
						<TR>
							<TD colSpan="2"><ASP:DATAGRID id="DatGrd" runat="server" CellPadding="1" AutoGenerateColumns="False" AllowPaging="True"
									Width="100%">
									<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
									<Columns>
										<asp:BoundColumn DataField="ACC_NO" HeaderText="No. Rekening">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="FAC_CODE" HeaderText="Jenis Kredit">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="ORGAMT" HeaderText="Limit">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="CBALRP" HeaderText="Baki Debet">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center" Width="120px"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="BILPRNRP" HeaderText="Tunggakan Pokok/thn">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="BILINTRP" HeaderText="Tunggakan Bunga/thn">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="BIKOLE" HeaderText="Kolektibilitas">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="KTARIK" HeaderText="Jumlah Pencairan">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="NIL_AGUNAN" HeaderText="Nilai Agunan">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="NILAI_PPAP" HeaderText="Nilai Pengikatan">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="TGL_PENILAIAN" HeaderText="Tanggal Penilaian">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="ISREADONLY" Visible="False">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
										</asp:BoundColumn>
									</Columns>
									<PagerStyle Mode="NumericPages"></PagerStyle>
								</ASP:DATAGRID></TD>
						</TR>
						<TR>
							<TD class="td" vAlign="top" width="50%">
								<TABLE cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="tdBGColor1" style="HEIGHT: 10px">Tunggakan Bunga</TD>
										<TD style="WIDTH: 15px; HEIGHT: 10px"></TD>
										<TD class="tdBGColorValue" style="HEIGHT: 10px"><asp:textbox id="TXT_TUNGGBUNGA" runat="server" Columns="50" MaxLength="50" ReadOnly="True" BorderWidth="0px"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="tdBGColor1" style="HEIGHT: 10px">Tunggakan Pokok</TD>
										<TD style="WIDTH: 15px; HEIGHT: 10px"></TD>
										<TD class="tdBGColorValue" style="HEIGHT: 10px"><asp:textbox id="TXT_TUNGGPOKOK" runat="server" Columns="50" MaxLength="50" ReadOnly="True" BorderWidth="0px"></asp:textbox></TD>
									</TR>
								</TABLE>
							</TD>
							<TD class="td" vAlign="top" width="50%">
								<TABLE cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="tdBGColor1" style="HEIGHT: 10px">Outstanding Triwulan Sebelumnya</TD>
										<TD style="WIDTH: 15px; HEIGHT: 10px"></TD>
										<TD class="tdBGColorValue" style="HEIGHT: 10px"><asp:textbox id="TXT_OUTSTANDINGPAST3" runat="server" Columns="50" MaxLength="50"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="tdBGColor1" style="HEIGHT: 10px">Posisi Fasilitas Pada Saat Persetujuan 
											Awal</TD>
										<TD style="WIDTH: 15px; HEIGHT: 10px"></TD>
										<TD class="tdBGColorValue" style="HEIGHT: 10px"><asp:textbox id="TXT_FACAWAL" runat="server" Columns="50" MaxLength="50"></asp:textbox></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD class="tdheader1" colSpan="2">Kewenangan Memutus</TD>
						</TR>
						<TR>
							<TD class="td" vAlign="top" width="50%">
								<TABLE cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="tdBGColor1" style="HEIGHT: 10px">Wewenang Memutus</TD>
										<TD style="WIDTH: 15px; HEIGHT: 10px"></TD>
										<TD class="tdBGColorValue" style="HEIGHT: 10px"><asp:textbox id="TXT_WEWENANG" runat="server" Columns="50" MaxLength="50" ReadOnly="True" BorderWidth="0px"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="tdBGColor1" style="HEIGHT: 10px"></TD>
										<TD style="WIDTH: 15px; HEIGHT: 10px"></TD>
										<TD class="tdBGColorValue" style="HEIGHT: 10px"><asp:textbox id="TXT_WEWENANG2" runat="server" Columns="50" MaxLength="50" ReadOnly="True" BorderWidth="0px"></asp:textbox></TD>
									</TR>
								</TABLE>
							</TD>
							<TD class="td" vAlign="top" width="50%">
								<TABLE cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD class="tdheader1" colSpan="2">Rating Summary</TD>
						</TR>
						<TR>
							<TD colSpan="2"><b>Customer Rating</b>
								<ASP:DATAGRID id="DG_CUSTRATING" runat="server" CellPadding="1" AutoGenerateColumns="False" AllowPaging="True"
									Width="100%">
									<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
									<Columns>
										<asp:BoundColumn DataField="RATING_DATE" HeaderText="Year of Financial Statement">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="FINANCIAL_RATING" HeaderText="Financial Rating">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="FINANCIAL_PD" HeaderText="P(d) Average">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="ADJUSTMENT_RATING" HeaderText="Adjusted Customer Rating">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="ADJUSTMENT_PD" HeaderText="P(d) Average">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
									</Columns>
									<PagerStyle Mode="NumericPages"></PagerStyle>
								</ASP:DATAGRID></TD>
						</TR>
						<TR>
							<TD colSpan="2"><b>Facility Rating</b>
								<ASP:DATAGRID id="DG_FACRATING" runat="server" CellPadding="1" AutoGenerateColumns="False" AllowPaging="True"
									Width="100%">
									<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
									<Columns>
										<asp:BoundColumn DataField="FACILITY" HeaderText="Facility">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="RATING_DATE" HeaderText="Year of Financial Statement">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="RISK_CLASS" HeaderText="Risk Class">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="LGD" HeaderText="LGD">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="EL" HeaderText="EL">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
										</asp:BoundColumn>
									</Columns>
									<PagerStyle Mode="NumericPages"></PagerStyle>
								</ASP:DATAGRID></TD>
						</TR>
						<TR>
							<TD class="td" vAlign="top" width="100%" colSpan="2">
								<TABLE cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="tdBGColor1" style="HEIGHT: 10px">Keterangan</TD>
										<TD style="WIDTH: 15px; HEIGHT: 10px"></TD>
										<TD class="tdBGColorValue" style="HEIGHT: 10px"><asp:textbox id="TXT_RATINGKESIMPULAN" runat="server" Columns="100" MaxLength="100" Rows="5"
												TextMode="MultiLine"></asp:textbox></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD class="tdheader1" colSpan="2">Informasi Nasabah</TD>
						</TR>
						<TR>
							<TD class="td" vAlign="top" width="50%">
								<TABLE cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="tdBGColor1" style="HEIGHT: 10px">Nama Debitur</TD>
										<TD style="WIDTH: 15px; HEIGHT: 10px"></TD>
										<TD class="tdBGColorValue" style="HEIGHT: 10px"><asp:textbox id="TXT_NAMANASABAH2" runat="server" Columns="50" MaxLength="50" ReadOnly="True"
												BorderWidth="0px"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="tdBGColor1" style="HEIGHT: 10px">Tanggal Pendirian Perusahaan</TD>
										<TD style="WIDTH: 15px; HEIGHT: 10px"></TD>
										<TD class="tdBGColorValue" style="HEIGHT: 10px"><asp:textbox onkeypress="return numbersonly()" id="TXT_PENDIRIAN_DAY" runat="server" Columns="2"
												MaxLength="2" Enabled="False"></asp:textbox><asp:dropdownlist id="DDL_PENDIRIAN_MONTH" runat="server" Enabled="False"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_PENDIRIAN_YEAR" runat="server" Columns="4"
												MaxLength="4" Enabled="False"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="tdBGColor1" style="HEIGHT: 10px">Group Usaha</TD>
										<TD style="WIDTH: 15px; HEIGHT: 10px"></TD>
										<TD class="tdBGColorValue" style="HEIGHT: 10px"><asp:textbox id="TXT_GRPUSAHA" runat="server" Columns="50" MaxLength="50" ReadOnly="True" BorderWidth="0px"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="tdBGColor1" style="HEIGHT: 10px">Alamat Kantor</TD>
										<TD style="WIDTH: 15px; HEIGHT: 10px"></TD>
										<TD class="tdBGColorValue" style="HEIGHT: 10px"><asp:textbox id="TXT_ALAMAT1" runat="server" Columns="50" MaxLength="50" ReadOnly="True" BorderWidth="0px"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="tdBGColor1" style="HEIGHT: 10px"></TD>
										<TD style="WIDTH: 15px; HEIGHT: 10px"></TD>
										<TD class="tdBGColorValue" style="HEIGHT: 10px"><asp:textbox id="TXT_ALAMAT2" runat="server" Columns="50" MaxLength="50" ReadOnly="True" BorderWidth="0px"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="tdBGColor1" style="HEIGHT: 10px"></TD>
										<TD style="WIDTH: 15px; HEIGHT: 10px"></TD>
										<TD class="tdBGColorValue" style="HEIGHT: 10px"><asp:textbox id="TXT_ALAMAT3" runat="server" Columns="50" MaxLength="50" ReadOnly="True" BorderWidth="0px"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="tdBGColor1" style="HEIGHT: 10px"></TD>
										<TD style="WIDTH: 15px; HEIGHT: 10px"></TD>
										<TD class="tdBGColorValue" style="HEIGHT: 10px"><asp:textbox id="TXT_ALAMAT4" runat="server" Columns="50" MaxLength="50" ReadOnly="True" BorderWidth="0px"></asp:textbox></TD>
									</TR>
								</TABLE>
							</TD>
							<TD class="td" vAlign="top" width="50%">
								<TABLE cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="tdBGColor1" style="HEIGHT: 10px">Lokasi Pabrik/Kebun/Proyek</TD>
										<TD style="WIDTH: 15px; HEIGHT: 10px"></TD>
										<TD class="tdBGColorValue" style="HEIGHT: 10px"><asp:textbox id="TXT_LOKASIPROYEK" runat="server" Columns="50" MaxLength="50" ReadOnly="True"
												BorderWidth="0px"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="tdBGColor1" style="HEIGHT: 10px">Bidang Usaha</TD>
										<TD style="WIDTH: 15px; HEIGHT: 10px"></TD>
										<TD class="tdBGColorValue" style="HEIGHT: 10px"><asp:textbox id="TXT_BIDUSAHA" runat="server" Columns="50" MaxLength="50" ReadOnly="True" BorderWidth="0px"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="tdBGColor1" style="HEIGHT: 10px">Key Person</TD>
										<TD style="WIDTH: 15px; HEIGHT: 10px"></TD>
										<TD class="tdBGColorValue" style="HEIGHT: 10px"><asp:textbox id="TXT_KEYPERSON" runat="server" Columns="50" MaxLength="50"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="tdBGColor1" style="HEIGHT: 10px">Tahun Hubungan dengan Bank</TD>
										<TD style="WIDTH: 15px; HEIGHT: 10px"></TD>
										<TD class="tdBGColorValue" style="HEIGHT: 10px"><asp:textbox id="TXT_TAHUNHUBBANK" runat="server" Columns="50" MaxLength="50"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="tdBGColor1" style="HEIGHT: 10px">Tanggal Pembukaan Rekening</TD>
										<TD style="WIDTH: 15px; HEIGHT: 10px"></TD>
										<TD class="tdBGColorValue" style="HEIGHT: 10px"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGLPEMBUKAANREK_DAY" runat="server" Columns="2"
												MaxLength="2"></asp:textbox><asp:dropdownlist id="DDL_TGLPEMBUKAANREK_MONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_TGLPEMBUKAANREK_YEAR" runat="server" Columns="4"
												MaxLength="4"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="tdBGColor1" style="HEIGHT: 10px">Tanggal Masuk Watchlist</TD>
										<TD style="WIDTH: 15px; HEIGHT: 10px"></TD>
										<TD class="tdBGColorValue" style="HEIGHT: 10px"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGLMASUKWATCHLIST_DAY" runat="server"
												Columns="2" MaxLength="2"></asp:textbox><asp:dropdownlist id="DDL_TGLMASUKWATCHLIST_MONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_TGLMASUKWATCHLIST_YEAR" runat="server"
												Columns="4" MaxLength="4"></asp:textbox></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD class="tdheader1" colSpan="2">Riwayat Kolektibilitas</TD>
						</TR>
						<TR>
							<TD class="td" vAlign="top" width="50%">
								<TABLE cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD><b>Saat ini (n)</b></TD>
									</TR>
									<TR>
										<TD class="tdBGColor1" style="HEIGHT: 10px">Kolektibilitas</TD>
										<TD style="WIDTH: 15px; HEIGHT: 10px"></TD>
										<TD class="tdBGColorValue" style="HEIGHT: 10px"><asp:textbox id="TXT_KOLEKTIBILITAS_N" runat="server" Columns="50" MaxLength="50"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="tdBGColor1" style="HEIGHT: 10px">Tanggal</TD>
										<TD style="WIDTH: 15px; HEIGHT: 10px"></TD>
										<TD class="tdBGColorValue" style="HEIGHT: 10px"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGLKOLEKTIBILITAS_N_DAY" runat="server"
												Columns="2" MaxLength="2"></asp:textbox><asp:dropdownlist id="DDL_TGLKOLEKTIBILITAS_N_MONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_TGLKOLEKTIBILITAS_N_YEAR" runat="server"
												Columns="4" MaxLength="4"></asp:textbox></TD>
									</TR>
								</TABLE>
							</TD>
							<TD class="td" vAlign="top" width="50%">
								<TABLE cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD><b>Sebelum (n-1)</b></TD>
									</TR>
									<TR>
										<TD class="tdBGColor1" style="HEIGHT: 10px">Kolektibilitas</TD>
										<TD style="WIDTH: 15px; HEIGHT: 10px"></TD>
										<TD class="tdBGColorValue" style="HEIGHT: 10px"><asp:textbox id="TXT_KOLEKTIBILITAS_N1" runat="server" Columns="50" MaxLength="50"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="tdBGColor1" style="HEIGHT: 10px">Tanggal</TD>
										<TD style="WIDTH: 15px; HEIGHT: 10px"></TD>
										<TD class="tdBGColorValue" style="HEIGHT: 10px"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGLKOLEKTIBILITAS_N1_DAY" runat="server"
												Columns="2" MaxLength="2"></asp:textbox><asp:dropdownlist id="DDL_TGLKOLEKTIBILITAS_N1_MONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_TGLKOLEKTIBILITAS_N1_YEAR" runat="server"
												Columns="4" MaxLength="4"></asp:textbox></TD>
									</TR>
									<TR>
										<TD><b>Sebelum (n-2)</b></TD>
									</TR>
									<TR>
										<TD class="tdBGColor1" style="HEIGHT: 10px">Kolektibilitas</TD>
										<TD style="WIDTH: 15px; HEIGHT: 10px"></TD>
										<TD class="tdBGColorValue" style="HEIGHT: 10px"><asp:textbox id="TXT_KOLEKTIBILITAS_N2" runat="server" Columns="50" MaxLength="50"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="tdBGColor1" style="HEIGHT: 10px">Tanggal</TD>
										<TD style="WIDTH: 15px; HEIGHT: 10px"></TD>
										<TD class="tdBGColorValue" style="HEIGHT: 10px"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGLKOLEKTIBILITAS_N2_DAY" runat="server"
												Columns="2" MaxLength="2"></asp:textbox><asp:dropdownlist id="DDL_TGLKOLEKTIBILITAS_N2_MONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_TGLKOLEKTIBILITAS_N2_YEAR" runat="server"
												Columns="4" MaxLength="4"></asp:textbox></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD class="td" vAlign="top" width="100%" colSpan="2">
								<TABLE cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="tdBGColor1" style="HEIGHT: 10px">Kesimpulan</TD>
										<TD style="WIDTH: 15px; HEIGHT: 10px"></TD>
										<TD class="tdBGColorValue" style="HEIGHT: 10px"><asp:textbox id="TXT_KOLEKTIBILITAS_KESIMPULAN" runat="server" Columns="100" MaxLength="100"
												Rows="5" TextMode="MultiLine"></asp:textbox></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD class="tdheader1" colSpan="2">Agunan</TD>
						</TR>
						<TR>
							<TD>Terlampir</TD>
						</TR>
						<TR>
							<TD class="tdheader1" colSpan="2">Aspek Keuangan</TD>
						</TR>
						<TR>
							<TD class="td" vAlign="top" width="100%" colSpan="2">
								<TABLE cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="tdBGColor1" style="HEIGHT: 10px">Kondisi Keuangan (Dupont Analysis &amp; 
											Liquidity Analysis)</TD>
										<TD style="WIDTH: 15px; HEIGHT: 10px"></TD>
										<TD class="tdBGColorValue" style="HEIGHT: 10px"><asp:textbox id="TXT_KONDISIKEUANGAN" runat="server" Columns="100" MaxLength="100" Rows="5" TextMode="MultiLine"></asp:textbox></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD class="tdheader1" colSpan="2">Watchlist</TD>
						</TR>
						<TR>
							<TD class="td" vAlign="top" width="100%" colSpan="2">
								<TABLE cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="tdBGColor1" style="HEIGHT: 10px">Alasan Masuk Dalam Watchlist</TD>
										<TD style="WIDTH: 15px; HEIGHT: 10px"></TD>
										<TD class="tdBGColorValue" style="HEIGHT: 10px"><asp:textbox id="TXT_ALASANWATCHLIST" runat="server" Columns="100" MaxLength="100" Rows="5" TextMode="MultiLine"></asp:textbox></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD class="tdheader1" colSpan="2">Perkembangan Triwulan Terakhir</TD>
						</TR>
						<TR>
							<TD class="td" vAlign="top" width="100%" colSpan="2">
								<TABLE cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="tdBGColor1" style="HEIGHT: 10px">Perkembangan Nasabah pada Triwulan 
											Terakhir</TD>
										<TD style="WIDTH: 15px; HEIGHT: 10px"></TD>
										<TD class="tdBGColorValue" style="HEIGHT: 10px"><asp:textbox id="TXT_PERKEMBANGAN3BLN" runat="server" Columns="100" MaxLength="100" Rows="5"
												TextMode="MultiLine"></asp:textbox></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD class="tdheader1" colSpan="2">Info Kunjungan / Pembicaraan Dengan Debitur</TD>
						</TR>
						<TR>
							<TD class="td" vAlign="top" width="100%" colSpan="2">
								<TABLE cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="tdBGColor1" style="HEIGHT: 10px">Info OTS / Call Report</TD>
										<TD style="WIDTH: 15px; HEIGHT: 10px"></TD>
										<TD class="tdBGColorValue" style="HEIGHT: 10px"><asp:textbox id="TXT_CALLREPORT" runat="server" Columns="100" MaxLength="100" Rows="5" TextMode="MultiLine"></asp:textbox></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD class="tdheader1" colSpan="2">Strategy</TD>
						</TR>
						<TR>
							<TD class="td" vAlign="top" width="100%" colSpan="2">
								<TABLE cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="tdBGColor1" style="HEIGHT: 10px">Account Strategy</TD>
										<TD style="WIDTH: 15px; HEIGHT: 10px"></TD>
										<TD class="tdBGColorValue" style="HEIGHT: 10px">
											<asp:DropDownList ID="DDL_STRATEGY" Runat="server"></asp:DropDownList>
										</TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD class="tdheader1" colSpan="2">Usulan</TD>
						</TR>
						<TR>
							<TD class="td" vAlign="top" width="100%" colSpan="2">
								<TABLE cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="tdBGColor1" style="HEIGHT: 10px">Usulan</TD>
										<TD style="WIDTH: 15px; HEIGHT: 10px"></TD>
										<TD class="tdBGColorValue" style="HEIGHT: 10px"><asp:textbox id="TXT_USULAN" runat="server" Columns="100" MaxLength="100" Rows="5" TextMode="MultiLine"></asp:textbox></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2"><asp:button id="BTN_SAVE" runat="server" Text="Save" CssClass="Button1" onclick="BTN_SAVE_Click"></asp:button>&nbsp;
								<asp:button id="BTN_CLEAR" runat="server" Text="Clear" CssClass="Button1" onclick="BTN_CLEAR_Click"></asp:button></TD>
						</TR>
						<TR id="TRE1" runat="server">
							<TD class="tdHeader1" vAlign="top" width="50%" colSpan="2">Document Export</TD>
						</TR>
						<TR id="TRE2" runat="server">
							<TD style="WIDTH: 540px" vAlign="top" width="540">
								<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="TDBGColor1" style="HEIGHT: 19px" width="75">Format</TD>
										<TD style="WIDTH: 15px; HEIGHT: 19px">:</TD>
										<TD class="TDBGColorValue" style="HEIGHT: 19px"><asp:button id="BTN_EXPORT" runat="server" Width="64px" Text="Export" onclick="BTN_EXPORT_Click"></asp:button></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Status</TD>
										<TD>:</TD>
										<TD class="TDBGColorValue"><asp:label id="LBL_STATUS_EXPORT" runat="server" ForeColor="Red"></asp:label></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1"></TD>
										<TD></TD>
										<TD class="TDBGColorValue"><asp:label id="LBL_STATUSEXPORT" runat="server" ForeColor="Red"></asp:label></TD>
									</TR>
									<TR>
										<TD style="HEIGHT: 21px" align="center" colSpan="3"></TD>
									</TR>
									<TR>
										<TD align="center" colSpan="3"></TD>
									</TR>
								</TABLE>
							</TD>
							<TD style="HEIGHT: 42px" vAlign="top" width="50%">
								<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD><ASP:DATAGRID id="DATA_EXPORT" runat="server" Width="100%" AutoGenerateColumns="False" PageSize="1"
												CellPadding="1">
												<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
												<Columns>
													<asp:BoundColumn Visible="False" DataField="LMS_REGNO" HeaderText="User ID"></asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="DOC_ID" HeaderText="User ID"></asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="FE_USERID" HeaderText="User ID"></asp:BoundColumn>
													<asp:BoundColumn DataField="FE_FILENAME" HeaderText="File Name">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													</asp:BoundColumn>
													<asp:TemplateColumn>
														<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
														<ItemTemplate>
															<asp:HyperLink id="FE_DOWNLOAD" runat="server" Target="_blank">Download</asp:HyperLink>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:TemplateColumn>
														<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
														<ItemTemplate>
															<asp:LinkButton id="FE_DELETE" runat="server" CommandName="delete">Delete</asp:LinkButton>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:BoundColumn Visible="False" DataField="FE_URL" HeaderText="Download URL"></asp:BoundColumn>
												</Columns>
											</ASP:DATAGRID></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
                        <TR>
							<TD colSpan="2"><uc1:docexport id="DocExport1" runat="server"></uc1:docexport></TD>
						</TR>
					</TBODY>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
