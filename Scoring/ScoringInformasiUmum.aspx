<%@ Page language="c#" Codebehind="ScoringInformasiUmum.aspx.cs" AutoEventWireup="True" Inherits="SME.Scoring.ScoringInformasiUmum" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Neraca</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_entries.html" -->
		<!-- #include file="../include/popup.html" -->
		<script language="javascript">
		function cek_mandatory(frm, alamat)
		{
			max_elm = (frm.elements.length) - 2;
			lanjut = true;
			for (var i=1; i<=max_elm; i++)
			{
				elm = frm.elements[i];
				nm_kolom = "kotak";
				if (elm.className == "mandatory" && (elm.value == "") && (elm.type == "text" || elm.type == "select-one"))
				{
					r = elm.parentElement.parentElement;
					d = r.cells(0).innerText;
					alert(d + " tidak boleh kosong...");
					lanjut = false;
					elm.focus();
					return false;
				}
			}
			if (lanjut)
			{

				if (alamat != undefined && alamat != "" )
					frm.action = alamat;

				return true;
			}
		}
		function updateParent(regno, curef, tc, mc, cekdata) {
			parent.document.Form1.action = "ScoringMain.aspx?regno=" + regno + "&curef=" + curef + "&tc=" + tc + "&mc=" + mc + "&cekdata=" + cekdata + "&stw=1";
			parent.document.Form1.submit();
			return true;
		}
		</script>
		<script language="vbscript">


		function samakanDeficit(sumber,tujuan1,tujuan2)
			SetLocale("in")		
			set obj_sumber = eval("document.form1." & sumber)			
			set obj_tujuan1 = eval("document.form1." & tujuan1)			
			set obj_tujuan2 = eval("document.form1." & tujuan2)			
			if isnumeric(obj_sumber.value) then
				SATUAN_VAL1 = obj_sumber.value
				SATUAN_VAL2 = obj_sumber.value
			end if						
			obj_tujuan1.value = SATUAN_VAL1 
			obj_tujuan2.value = SATUAN_VAL2 
		end function			


		'''''''''''' Menghitung Satuan dari Million ''''''''''''''''''''
		function konversiKeSatuan(sumber, tujuan)
			SetLocale("in")		
			set obj_sumber = eval("document." & sumber)				
			set obj_tujuan = eval("document." & tujuan)				
			if isnumeric(obj_sumber.value) then
				MILLION_VAL = cdbl(obj_sumber.value)
			else
				MILLION_VAL = 0
			end if						
			obj_tujuan.value = Round(MILLION_VAL / 1000)
			obj_tujuan.value = replace(obj_tujuan.value, ".", ",")
		end function			
		
		''''''''''' Menghitung Million dari Satuan ''''''''''''''''''''
		function konversiKeMillion(sumber, tujuan)
			SetLocale("in")		
			set obj_sumber = eval("document." & sumber)				
			set obj_tujuan = eval("document." & tujuan)				
			if isnumeric(obj_sumber.value) then
				SATUAN_VAL = cdbl(obj_sumber.value)
			else
				SATUAN_VAL = 0
			end if						
			obj_tujuan.value = SATUAN_VAL * 1000
			obj_tujuan.value = replace(obj_tujuan.value, ".", ",")
		end function
		function samaKan(sumber, tujuan)
			SetLocale("in")		
			set obj_sumber = eval("document." & sumber)				
			set obj_tujuan = eval("document." & tujuan)				
			if isnumeric(obj_sumber.value) then
				NILAI = cdbl(obj_sumber.value)
			else
				NILAI = 0
			end if						
			obj_tujuan.value = NILAI
			obj_tujuan.value = replace(obj_tujuan.value, ".", ",")
		end function				
		</script>
		<script language="javascript">		
		function valid_infoumum()
		{
			if(
				(document.Form1.TXT_TGLLAHIR.value == "")||
				(document.Form1.TXT_NAMAPEMOHON.value == "")||
				(document.Form1.TXT_JML_ANAK.value == "")||
				(document.Form1.TXT_THN_MENETAP.value == "")||
				(document.Form1.TXT_NAMA_PERUSHAAN.value == "")||
				(document.Form1.TXT_JML_KREDIT.value == "")||
				(document.Form1.TXT_THN_LAHIR.value == "")||
				(document.Form1.TXT_JML_PEGAWAI.value == "")||
				(document.Form1.TXT_THN_USAHA.value == "")||
				(document.Form1.TXT_THN_MILIKUSAHA.value == "")||
				(document.Form1.TXT_BLN_MILIKUSAHA.value == "")||
				(document.Form1.TXT_KODESEKTOREKONOMIBI.value == "")||
				(document.Form1.TXT_TGL_MENETAP.value == "")||
				(document.Form1.TXT_TGL_USAHA.value == "")||
				(document.Form1.DDL_JNSPERMOHONAN.value == "")||
				(document.Form1.DDL_JNSKREDIT.value == "")||
				(document.Form1.DDL_JNSKELAMIN.value == "")||
				(document.Form1.DDL_PENDAKHIR.value == "")||
				(document.Form1.DDL_STATUSKAWIN.value == "")||
				(document.Form1.DDL_STATMILIKRMH.value == "")||
				(document.Form1.DDL_JNSPERUSH.value == "")||
				(document.Form1.DDL_KODEPOSLOKASIUSAHA.value == "")||
				(document.Form1.DDL_BLN_USAHA.value == "")||
				(document.Form1.DDL_BLN_MENETAP.value == "")||
				(document.Form1.DDL_BULANLAHIR.value == "")
				(document.Form1.DDL_CONTRACTORREQLINETYPE=="")
				(document.Form1.DDL_SKEMAKREDIT=="")
				(document.Form1.DDL_JAMINANTAMBAHAN=="")
				(document.Form1.TXT_LIMITOTHERBANK=="")
				(document.Form1.TXT_UMURKEYPERSON=="")
				(document.Form1.TXT_PROSENSAHAM=="")
				(document.Form1.DDL_PASTPUKKFAC=="")
				(document.Form1.DDL_CURRPUKKFAC=="")
				(document.Form1.DDL_PRODUCTEXIST=="")
				(document.Form1.TXT_EXPOSUREEXISTING=="")
				(document.Form1.TXT_LAMAJADINASABAH=="")
				(document.Form1.DDL_PUKKCURR=="")
				(document.Form1.DDL_LGLLAWSUIT=="")				
			  )
			{
				alert("Kolom Tidak boleh mengandung nilai null\nSilakan anda melengkapi data nya.");
				return false;
			}	
			return true;	
		}
		
		
		</script>
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TBODY>
						<!-- ************************* separator *************------------------------------------------------------------------------------------------------------------------------------------------->
						<!-- ************************* separator *************------------------------------------------------------------------------------------------------------------------------------------------->
						<!-- ************************* separator *************------------------------------------------------------------------------------------------------------------------------------------------->
						<!-- ************************* separator *************------------------------------------------------------------------------------------------------------------------------------------------->
						<!--  separator ------------------------------------------------------------------------------------------------------------------------------------------>
						<TR>
							<td class="tdNoBorder" align="center" colSpan="2">x
								<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="tdHeader1" align="center" width="100%" colSpan="2">Input Data Informasi 
											Umum</TD>
									</TR>
								</TABLE>
								<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="100%" border="0">
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 294px">
											<P>Nama Nasabah</P>
										</TD>
										<TD width="12"></TD>
										<TD><asp:textbox id="TXT_NAMA_PERUSHAAN" runat="server" Width="301px" ReadOnly="True" BackColor="Gainsboro"></asp:textbox><asp:label id="LBL_TIPENASABAH" runat="server" Visible="False">Label</asp:label></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 293px; HEIGHT: 5px">Jenis Permohonan</TD>
										<TD style="HEIGHT: 5px"></TD>
										<TD style="HEIGHT: 5px"><asp:dropdownlist id="DDL_JNSPERMOHONAN" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 293px; HEIGHT: 1px">Jenis Kredit yang Dimohon</TD>
										<TD style="HEIGHT: 1px"></TD>
										<TD style="HEIGHT: 1px"><asp:dropdownlist id="DDL_JNSKREDIT" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 293px; HEIGHT: 1px">Model</TD>
										<TD style="HEIGHT: 1px"></TD>
										<TD style="HEIGHT: 1px"><asp:textbox id="TXT_MODEL" runat="server" ReadOnly="True" MaxLength="12" onkeypress="return digitsonly()"
												Enabled="False" BackColor="#FFE0C0"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 293px; HEIGHT: 21px">Total Exposure (ribuan)</TD>
										<TD style="HEIGHT: 21px"></TD>
										<TD style="HEIGHT: 21px"><asp:textbox id="TXT_JML_KREDIT" runat="server" ReadOnly="True" MaxLength="12" onkeypress="return digitsonly()"
												CssClass="mandatory"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 293px; HEIGHT: 19px">Legal Lawsuit</TD>
										<TD style="HEIGHT: 19px"></TD>
										<TD style="HEIGHT: 19px"><asp:dropdownlist id="DDL_LGLLAWSUIT" runat="server" Enabled="False">
												<asp:ListItem Value="N">TIDAK</asp:ListItem>
												<asp:ListItem Value="Y">YA</asp:ListItem>
											</asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 293px; HEIGHT: 18px">Limit W/C di Bank Lain 
											(ribuan)</TD>
										<TD style="HEIGHT: 18px"></TD>
										<TD style="HEIGHT: 18px"><asp:textbox id="TXT_LIMITOTHERBANK" runat="server" MaxLength="12" ReadOnly="True" BackColor="Gainsboro"
												onkeypress="return digitsonly()">0</asp:textbox><asp:label id="Label2" runat="server" Visible="False">[Existing w/c limit in other bank]</asp:label></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 293px; HEIGHT: 18px">Produk Existing</TD>
										<TD style="HEIGHT: 18px"></TD>
										<TD style="HEIGHT: 18px"><asp:dropdownlist id="DDL_PRODUCTEXIST" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 293px; HEIGHT: 18px">Exposure Existing 
											(ribuan)</TD>
										<TD style="HEIGHT: 18px"></TD>
										<TD style="HEIGHT: 18px"><asp:textbox id="TXT_EXPOSUREEXISTING" runat="server" Width="152px" ReadOnly="True" MaxLength="8"
												onkeypress="return digitsonly()" CssClass="mandatory"></asp:textbox><asp:label id="Label3" runat="server" Visible="False">[Existing Exposure]</asp:label></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 293px; HEIGHT: 18px">Skema Kredit</TD>
										<TD style="HEIGHT: 18px"></TD>
										<TD style="HEIGHT: 18px"><asp:dropdownlist id="DDL_SKEMAKREDIT" runat="server"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 293px; HEIGHT: 18px">Contractor Requested w.c 
											line type</TD>
										<TD style="HEIGHT: 18px"></TD>
										<TD style="HEIGHT: 18px">
											<asp:dropdownlist id="DDL_CONTRACTORREQLINETYPE" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_CONTRACTORREQLINETYPE_SelectedIndexChanged"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 293px; HEIGHT: 18px">Lama Menjadi Nasabah Bank 
											Mandiri (YY/MM)</TD>
										<TD style="HEIGHT: 18px"></TD>
										<TD style="HEIGHT: 18px"><asp:textbox id="TXT_LAMAJADINASABAH" runat="server" Width="64px" MaxLength="4" ReadOnly="True"
												onkeypress="return digitsonly()" CssClass="mandatory"></asp:textbox></TD>
									</TR>
								</TABLE>
							</td>
						</TR> <!-- ************************* separator *************------------------------------------------------------------------------------------------------------------------------------------------->
						<TR>
							<TD class="tdheader1" align="center" colSpan="2">Informasi Key Person</TD>
						</TR>
						<TR>
							<TD class="tdNoBorder" align="center" colSpan="2">
								<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="100%" border="0">
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 296px">Nama Pemohon</TD>
										<TD width="12"></TD>
										<TD><asp:textbox id="TXT_NAMAPEMOHON" runat="server" Width="302px" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 296px; HEIGHT: 16px">Tanggal Lahir</TD>
										<TD style="HEIGHT: 16px"></TD>
										<TD style="HEIGHT: 16px"><asp:textbox id="TXT_TGLLAHIR" runat="server" ReadOnly="True" MaxLength="2" Columns="2" onkeypress="return digitsonly()"></asp:textbox><asp:dropdownlist id="DDL_BULANLAHIR" runat="server" Width="96px" Enabled="False"></asp:dropdownlist><asp:textbox id="TXT_THN_LAHIR" runat="server" ReadOnly="True" MaxLength="4" Columns="4" onkeypress="return digitsonly()"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 296px; HEIGHT: 13px">Jenis Kelamin</TD>
										<TD style="HEIGHT: 13px"></TD>
										<TD style="HEIGHT: 13px"><asp:dropdownlist id="DDL_JNSKELAMIN" runat="server" Width="76px" Enabled="False">
												<asp:ListItem Value="L">L</asp:ListItem>
												<asp:ListItem Value="P">P</asp:ListItem>
											</asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 296px; HEIGHT: 21px">Pendidikan Terakhir</TD>
										<TD style="HEIGHT: 21px"></TD>
										<TD style="HEIGHT: 21px"><asp:dropdownlist id="DDL_PENDAKHIR" runat="server" Enabled="False"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 296px; HEIGHT: 21px">Status Perkawinan</TD>
										<TD style="HEIGHT: 21px"></TD>
										<TD style="HEIGHT: 21px"><asp:dropdownlist id="DDL_STATUSKAWIN" runat="server" Enabled="False"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 296px">Jumlah Anak</TD>
										<TD></TD>
										<TD><asp:textbox id="TXT_JML_ANAK" runat="server" Width="50px" ReadOnly="True" MaxLength="2" Columns="2"
												onkeypress="return digitsonly()"></asp:textbox><asp:label id="Label1" runat="server">Orang</asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
											<asp:label id="Label7" runat="server" Visible="False">Number of children of main owner</asp:label></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 296px">Mulai Menetap di Alamat Saat Ini 
											(MM/YYYY)</TD>
										<TD></TD>
										<TD><asp:dropdownlist id="DDL_BLN_MENETAP" runat="server" Width="104px" Enabled="False"></asp:dropdownlist><asp:textbox id="TXT_THN_MENETAP" runat="server" ReadOnly="True" MaxLength="4" Columns="4" onkeypress="return digitsonly()"></asp:textbox><asp:textbox id="TXT_TGL_MENETAP" runat="server" Width="8px" ReadOnly="True" Visible="False"
												Height="19px">01</asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 296px">Apakah Nasabah Miliki Rumah Tinggal 
											Sendiri ?</TD>
										<TD></TD>
										<TD>
											<asp:dropdownlist id="DDL_IUM_HOMEOWNEDCUST" runat="server" Enabled="False">
												<asp:ListItem Value="N">TIDAK</asp:ListItem>
												<asp:ListItem Value="Y">YA</asp:ListItem>
											</asp:dropdownlist><asp:dropdownlist id="DDL_STATMILIKRMH" runat="server" Width="125px" Enabled="False" Visible="False"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 296px">Umur (YYMM)</TD>
										<TD></TD>
										<TD><asp:textbox id="TXT_UMURKEYPERSON" runat="server" ReadOnly="True" MaxLength="4" Columns="4"
												onkeypress="return digitsonly()" BackColor="Gainsboro"></asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
											<asp:label id="Label6" runat="server" Visible="False">Age of Primary Owner (yymm)</asp:label>&nbsp;&nbsp;</TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 296px">Prosentasi Saham (Main Owners)</TD>
										<TD></TD>
										<TD><asp:textbox id="TXT_PROSENSAHAM" runat="server" Width="50px" ReadOnly="True" MaxLength="3" Columns="3"
												onkeypress="return digitsonly()" CssClass="mandatory"></asp:textbox>%&nbsp;&nbsp;&nbsp;&nbsp;
											<asp:label id="Label5" runat="server" Visible="False">% share - main owner</asp:label></TD>
									</TR>
								</TABLE>
							</TD>
						</TR> <!-- ************************* separator *************------------------------------------------------------------------------------------------------------------------------------------------->  <!-- ************************* separator *************------------------------------------------------------------------------------------------------------------------------------------------->
						<TR>
							<TD class="tdheader1" align="center" colSpan="2">Informasi Usaha</TD>
						</TR>
						<TR>
							<TD class="tdNoBorder" align="center" colSpan="2">
								<TABLE id="Table6" cellSpacing="1" cellPadding="1" width="100%" border="0">
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 297px; HEIGHT: 15px">Jenis Perusahaan</TD>
										<TD width="12" style="HEIGHT: 15px"></TD>
										<TD style="HEIGHT: 15px"><asp:dropdownlist id="DDL_JNSPERUSH" runat="server" Enabled="False"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 297px; HEIGHT: 16px">Jumlah Pegawai</TD>
										<TD></TD>
										<TD><asp:textbox id="TXT_JML_PEGAWAI" runat="server" ReadOnly="True" MaxLength="3" Columns="3" onkeypress="return digitsonly()"
												BackColor="Gainsboro"></asp:textbox>Orang<asp:label id="Label8" runat="server" Visible="False">[Existing w/c limit in other bank]</asp:label>
											<asp:Label id="Label10" runat="server" Visible="False">Existing W/C Limit in Other Bank (ribuan)</asp:Label><asp:textbox id="TXT_EXIST_WC_LIMIT_OTHERBANK_INMILLION" onkeyup='konversiKeSatuan("Form1.TXT_EXIST_WC_LIMIT_OTHERBANK_INMILLION","Form1.TXT_EXIST_WC_LIMIT_OTHERBANK_INSATUAN")'
												runat="server" Width="152px" ReadOnly="True" BackColor="Gainsboro" onkeypress="return digitsonly()" Visible="False"></asp:textbox>
											<asp:textbox id="TXT_EXIST_WC_LIMIT_OTHERBANK_INSATUAN" onkeyup='konversiKeMillion("Form1.TXT_EXIST_WC_LIMIT_OTHERBANK_INSATUAN","Form1.TXT_EXIST_WC_LIMIT_OTHERBANK_INMILLION")'
												runat="server" MaxLength="8" Visible="False"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 297px; HEIGHT: 16px">Mulai Usaha (MM/YYYY)</TD>
										<TD></TD>
										<TD><asp:textbox id="TXT_TGL_USAHA" runat="server" ReadOnly="True" Visible="False" MaxLength="2"
												Columns="2" onkeypress="return digitsonly()">01</asp:textbox><asp:dropdownlist id="DDL_BLN_USAHA" runat="server" Enabled="False"></asp:dropdownlist><asp:textbox id="TXT_THN_USAHA" runat="server" ReadOnly="True" MaxLength="4" Columns="4" onkeypress="return digitsonly()"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 297px; HEIGHT: 16px">Kota Lokasi Usaha</TD>
										<TD></TD>
										<TD><asp:textbox id="TXT_KOTAUSAHA" runat="server" Width="200px" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 297px; HEIGHT: 16px">Kode Pos Lokasi Usaha</TD>
										<TD style="HEIGHT: 22px"></TD>
										<TD style="HEIGHT: 22px"><asp:textbox id="TXT_KODEPOS" runat="server" ReadOnly="True" MaxLength="6" Columns="6" DESIGNTIMEDRAGDROP="1466"
												BackColor="Gainsboro"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 297px; HEIGHT: 16px">Lama Kepemilikan Usaha 
											(YY/MM)</TD>
										<TD></TD>
										<TD><asp:textbox id="TXT_THN_MILIKUSAHA" runat="server" ReadOnly="True" MaxLength="4" Columns="4"
												onkeypress="return digitsonly()" CssClass="mandatory"></asp:textbox>Tahun
											<asp:textbox id="TXT_BLN_MILIKUSAHA" runat="server" Width="50px" ReadOnly="True" MaxLength="2"
												Columns="2" onkeypress="return digitsonly()" CssClass="mandatory"></asp:textbox>&nbsp;Bulan<asp:textbox id="TXT_KODESEKTOREKONOMIBI" runat="server" Width="68px" Visible="False"></asp:textbox><asp:dropdownlist id="DDL_SEKTOREKONOMIBI" runat="server" Width="272px" Visible="False"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 297px; HEIGHT: 16px">Penjualan Tahunan 
											(ribuan)</TD>
										<TD></TD>
										<TD><asp:textbox id="TXT_PSRL_PENJUALANTAHUNAN" runat="server" Width="152px" ReadOnly="True" MaxLength="12"
												BackColor="Gainsboro" onkeypress="return digitsonly()"></asp:textbox>
											&nbsp;&nbsp;
											<asp:textbox id="TXT_PSRL_PENJUALANTAHUNAN_INSATUAN" runat="server" MaxLength="8" Visible="False"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 297px; HEIGHT: 16px">
											%&nbsp;Peningkatan Penjualan</TD>
										<TD></TD>
										<TD>
											<asp:TextBox id="TXT_PROSEN_SALES_INCREASE" runat="server" Width="104px" ReadOnly="True" BackColor="Gainsboro"
												onkeypress="return digitsonly()"></asp:TextBox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 297px; HEIGHT: 16px">Harga Pokok Penjualan 
											(ribuan)</TD>
										<TD></TD>
										<TD><asp:textbox id="TXT_PSRL_HPP" runat="server" Width="152px" ReadOnly="True" MaxLength="12" BackColor="Gainsboro"
												onkeypress="return digitsonly()"></asp:textbox>
											&nbsp;&nbsp;
											<asp:textbox id="TXT_PSRL_HPP_INSATUAN" runat="server" MaxLength="8" Visible="False"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 297px; HEIGHT: 16px">Biaya Umum &amp; 
											Administrasi (ribuan)</TD>
										<TD></TD>
										<TD><asp:textbox id="TXT_PSRL_BIAYAUMUMADM" runat="server" Width="152px" ReadOnly="True" MaxLength="12"
												BackColor="Gainsboro" onkeypress="return digitsonly()"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 297px; HEIGHT: 16px">Total Hutang (ribuan)</TD>
										<TD></TD>
										<TD><asp:textbox id="TXT_HUTANG" runat="server" Width="152px" ReadOnly="True" MaxLength="12" BackColor="Gainsboro"
												onkeypress="return digitsonly()"></asp:textbox>
											&nbsp;&nbsp;
											<asp:textbox id="TXT_HUTANG_INSATUAN" runat="server" MaxLength="8" Visible="False" onkeypress="return digitsonly()"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 297px; HEIGHT: 16px">Kas (ribuan)</TD>
										<TD></TD>
										<TD><asp:textbox id="TXT_PSN_KASBANK" runat="server" Width="152px" ReadOnly="True" MaxLength="12"
												BackColor="Gainsboro" onkeypress="return digitsonly()" CssClass="mandatory"></asp:textbox>
											&nbsp;&nbsp;
											<asp:textbox id="TXT_PSN_KASBANK_INSATUAN" runat="server" MaxLength="8" Visible="False"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 297px; HEIGHT: 16px">Current Asset (ribuan)
										</TD>
										<TD></TD>
										<TD><asp:textbox id="TXT_PSN_TTLAKTIVALCR" runat="server" Width="152px" ReadOnly="True" MaxLength="12"
												BackColor="Gainsboro" onkeypress="return digitsonly()"></asp:textbox>
											&nbsp;&nbsp;&nbsp;
											<asp:textbox id="TXT_PSN_TTLAKTIVALCR_INSATUAN" runat="server" MaxLength="8" Visible="False"></asp:textbox><asp:label id="LBL_TOTAL_AKTIVA_LANCAR" runat="server" Visible="False"></asp:label></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 297px; HEIGHT: 16px">Aktiva Tetap (Tanah &amp; 
											Bangunan)&nbsp;(ribuan)</TD>
										<TD></TD>
										<TD><asp:textbox id="TXT_PSN_TNHBGN" runat="server" Width="152px" ReadOnly="True" MaxLength="12"
												BackColor="Gainsboro" onkeypress="return digitsonly()"></asp:textbox>&nbsp;&nbsp;</TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 297px; HEIGHT: 16px">Total Asset (ribuan)</TD>
										<TD></TD>
										<TD><asp:textbox id="TXT_PSN_TTLAKTIVA" runat="server" Width="152px" ReadOnly="True" MaxLength="12"
												BackColor="Gainsboro" onkeypress="return digitsonly()"></asp:textbox><asp:label id="LBL_TOTAL_AKTIVA" runat="server" Visible="False"></asp:label></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 297px; HEIGHT: 16px">Net Worth (ribuan)</TD>
										<TD></TD>
										<TD><asp:textbox id="TXT_TOTMODAL" runat="server" Width="152px" ReadOnly="True" MaxLength="12" BackColor="Gainsboro"
												onkeypress="return digitsonly()"></asp:textbox>
											&nbsp;&nbsp;
											<asp:textbox id="TXT_TOTMODAL_INSATUAN" runat="server" MaxLength="8" Visible="False"></asp:textbox><asp:label id="LBL_REGNO" runat="server" Visible="False">LBL_REGNO</asp:label><asp:dropdownlist id="DDL_AL_MINTANAS" runat="server" Width="125px" Visible="False"></asp:dropdownlist></TD>
									</TR>
									<!--
									<TR>
										<TD class="tdHeader1" colSpan="3">Applied Loan Information</TD>
									</TR>									
									<TR>
										<TD class="TDBGColor1">Permintaan Nasabah</TD>
										<TD></TD>
										<TD></TD>
									</TR>
									--></TABLE>
								<CENTER>&nbsp;</CENTER>
							</TD>
						</TR>
						<TR id="TR_MICRO" runat="server">
							<TD class="tdNoBorder" align="center" colSpan="2">
								<TABLE id="Table11" cellSpacing="1" cellPadding="1" width="100%" border="0">
									<TR>
										<TD class="tdheader1">Micro/Low Line</TD>
									</TR>
									<TR>
										<TD>
											<TABLE id="Table7" cellSpacing="1" cellPadding="1" width="100%" border="0">
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 294px">Purchasing Plan Amount (ribuan)</TD>
													<TD width="12"></TD>
													<TD>
														<asp:textbox onkeypress="return numbersonly()" id="TXT_PURCHASING_PLANT_AMOUNT_M" onkeyup='samaKan("Form1.TXT_PURCHASING_PLANT_AMOUNT_M", "Form1.TXT_PURCHASING_PLANT_AMOUNT_PUKK")'
															runat="server" Width="128px" MaxLength="8"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 294px; HEIGHT: 21px">
														<P>% Interest pa (x100)</P>
													</TD>
													<TD style="HEIGHT: 21px"></TD>
													<TD style="HEIGHT: 21px">
														<asp:textbox id="TXT_PRSN_INTEREST_PA" runat="server" Width="50px" MaxLength="5" Columns="4"
															onkeypress="return digitsonly()" DESIGNTIMEDRAGDROP="2040"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 293px; HEIGHT: 22px">Termin (dalam bulan)</TD>
													<TD style="HEIGHT: 22px"></TD>
													<TD style="HEIGHT: 22px">
														<asp:textbox id="TXT_TERMYN_MONTH" runat="server" Width="50px" MaxLength="2" Columns="2" onkeypress="return digitsonly()"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 293px; HEIGHT: 16px">Average Net Profit 
														(ribuan)</TD>
													<TD style="HEIGHT: 16px"></TD>
													<TD style="HEIGHT: 16px">
														<asp:textbox id="TXT_AVG_NET_PROFIT" runat="server" Width="128px" MaxLength="7" onkeypress="return digitsonly()"></asp:textbox>
														<asp:label id="Label9" runat="server" Visible="False">Avg net Profit</asp:label></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 293px; HEIGHT: 5px">Existing Facilities</TD>
													<TD style="HEIGHT: 5px"></TD>
													<TD style="HEIGHT: 5px">
														<asp:dropdownlist id="DDL_EXISTING_FAC" runat="server" DESIGNTIMEDRAGDROP="158"></asp:dropdownlist></TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR id="TR_PUKK" runat="server">
							<td class="tdNoBorder" align="center" colSpan="2">
								<TABLE id="Table12" cellSpacing="1" cellPadding="1" width="100%" border="0">
									<TR>
										<TD class="tdheader1">PUKK</TD>
									</TR>
									<TR>
										<TD>
											<TABLE id="Table8" cellSpacing="1" cellPadding="1" width="100%" border="0">
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 294px">Purchasing Plan Amount (ribuan)</TD>
													<TD width="12"></TD>
													<TD>
														<asp:textbox onkeypress="return numbersonly()" id="TXT_PURCHASING_PLANT_AMOUNT_PUKK" onkeyup='samaKan("Form1.TXT_PURCHASING_PLANT_AMOUNT_PUKK", "Form1.TXT_PURCHASING_PLANT_AMOUNT_M")'
															runat="server" Width="128px" MaxLength="8"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 294px; HEIGHT: 6px">
														<P>Memiliki Agunan Tambahan ?
														</P>
													</TD>
													<TD style="HEIGHT: 6px"></TD>
													<TD style="HEIGHT: 6px">
														<asp:dropdownlist id="DDL_JAMINANTAMBAHAN" runat="server" DESIGNTIMEDRAGDROP="158">
															<asp:ListItem Value="N">TIDAK</asp:ListItem>
															<asp:ListItem Value="Y">YA</asp:ListItem>
														</asp:dropdownlist></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 294px; HEIGHT: 20px">
														Sedang Menikmati PUKK dari BUMN lain&nbsp;?</TD>
													<TD style="HEIGHT: 20px"></TD>
													<TD style="HEIGHT: 20px">
														<asp:dropdownlist id="DDL_PUKKCURR" runat="server" DESIGNTIMEDRAGDROP="192">
															<asp:ListItem Value="N">TIDAK</asp:ListItem>
															<asp:ListItem Value="Y">YA</asp:ListItem>
														</asp:dropdownlist></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 294px; HEIGHT: 20px">Pernah memperoleh PUKK 
														dari BUMN lain ?</TD>
													<TD style="HEIGHT: 20px"></TD>
													<TD style="HEIGHT: 20px">
														<asp:dropdownlist id="DDL_PUKKPAST" runat="server" DESIGNTIMEDRAGDROP="193">
															<asp:ListItem Value="N">TIDAK</asp:ListItem>
															<asp:ListItem Value="Y">YA</asp:ListItem>
														</asp:dropdownlist></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 294px; HEIGHT: 22px">Mempunyai Izin Usaha ?</TD>
													<TD style="HEIGHT: 22px"></TD>
													<TD style="HEIGHT: 22px">
														<asp:dropdownlist id="DDL_LISENSI" runat="server">
															<asp:ListItem Value="N">TIDAK</asp:ListItem>
															<asp:ListItem Value="Y">YA</asp:ListItem>
														</asp:dropdownlist></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 293px; HEIGHT: 5px">Pernah Memperoleh PUKK 
														dari Bank Mandiri ?</TD>
													<TD style="HEIGHT: 5px"></TD>
													<TD style="HEIGHT: 5px">
														<asp:dropdownlist id="DDL_PUKK_PAST_BM" runat="server">
															<asp:ListItem Value="N">TIDAK</asp:ListItem>
															<asp:ListItem Value="Y">YA</asp:ListItem>
														</asp:dropdownlist></TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
								</TABLE>
							</td>
						</TR> <!-- ************************* separator *************------------------------------------------------------------------------------------------------------------------------------------------->  <!-- ************************* separator *************------------------------------------------------------------------------------------------------------------------------------------------->
						<TR id="TR_KI" runat="server">
							<td class="tdNoBorder" align="center" colSpan="2">
								<TABLE id="Table12" cellSpacing="1" cellPadding="1" width="100%" border="0">
									<TR>
										<TD class="tdheader1" align="center" colSpan="2">Kredit Investasi</TD>
									</TR>
									<TR>
										<td class="tdNoBorder" align="center" colSpan="2">
											<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 301px">Acceptable Project Cost (ribuan)</TD>
													<TD width="12"></TD>
													<TD><asp:textbox onkeypress="return numbersonly()" id="TXT_ACCEPT_PROJ_COST_KI" runat="server" Width="128px"
															MaxLength="8" DESIGNTIMEDRAGDROP="803"></asp:textbox></TD>
												</TR>
											</TABLE>
										</td>
									</TR>
								</TABLE>
							</td>
						</TR> <!-- ************************* separator *************------------------------------------------------------------------------------------------------------------------------------------------->  <!-- ************************* separator *************------------------------------------------------------------------------------------------------------------------------------------------->
						<TR id="TR_CONTRACTOR" runat="server">
							<td class="tdNoBorder" align="center" colSpan="2">
								<TABLE id="Table12" cellSpacing="1" cellPadding="1" width="100%" border="0">
									<TR>
										<TD class="tdheader1" align="center" colSpan="2">Contractor Loan</TD>
									</TR>
									<TR>
										<td class="tdNoBorder" align="center" colSpan="2">
											<TABLE id="Table9" cellSpacing="1" cellPadding="1" width="100%" border="0">
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 299px">
														Downpayment Amount (ribuan)</TD>
													<TD width="12"></TD>
													<TD>
														<asp:textbox onkeypress="return digitsonly()" id="TXT_PLAFOND_DP" runat="server" Width="128px"
															MaxLength="8"></asp:textbox><asp:textbox id="TXT_ACCEPT_PROJ_COST" runat="server" Width="128px" MaxLength="8" onkeypress="return digitsonly()"
															Visible="False"></asp:textbox>
														<asp:Label id="Label4" runat="server" Visible="False">A914</asp:Label></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 299px">&nbsp; Turnkey : Project Cost (ribuan)
													</TD>
													<TD></TD>
													<TD>
														<asp:textbox onkeypress="return digitsonly()" id="TXT_CONTR_TURNKEY_PROJ_COST" runat="server"
															Width="128px" MaxLength="8"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 299px">&nbsp;Progress Payment : MC Contractor 
														Peak Deficit Cash Flow (ribuan)</TD>
													<TD></TD>
													<TD>
														<asp:textbox onkeypress="return digitsonly()" onkeyup="return samakanDeficit('TXTMC_CONT_PEAK_DEFICIT_CF','TXTMC_CONT_PEAK_DEFICIT_CF2','TXTMC_CONT_PEAK_DEFICIT_CF3')"
															id="TXTMC_CONT_PEAK_DEFICIT_CF" runat="server" Width="128px" MaxLength="8" DESIGNTIMEDRAGDROP="513">0</asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 299px">Termyn : Project Cost (1 Project) 
														(ribuan)</TD>
													<TD></TD>
													<TD>
														<asp:textbox onkeypress="return digitsonly()" id="TXT_PROJ_COST" runat="server" Width="128px"
															MaxLength="8" Columns="8"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 299px">Termyn : Number of Termyns</TD>
													<TD></TD>
													<TD>
														<asp:textbox onkeypress="return digitsonly()" id="TXT_NUM_TERMYN" runat="server" Width="50px"
															MaxLength="2" Columns="2"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 299px">Plafond : MC Contractor Peak Deficit 
														Cash Flow (ribuan)</TD>
													<TD></TD>
													<TD>
														<asp:textbox onkeypress="return digitsonly()" onkeyup="return samakanDeficit('TXTMC_CONT_PEAK_DEFICIT_CF2','TXTMC_CONT_PEAK_DEFICIT_CF','TXTMC_CONT_PEAK_DEFICIT_CF3')"
															id="TXTMC_CONT_PEAK_DEFICIT_CF2" runat="server" Width="128px" MaxLength="8">0</asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 299px">Plafond : Total Value of Projects 
														(ribuan)</TD>
													<TD></TD>
													<TD>
														<asp:textbox onkeypress="return digitsonly()" id="TXT_PLAFOND_TOT_VAL_PROJECTS" runat="server"
															Width="128px" MaxLength="8" DESIGNTIMEDRAGDROP="2148"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 299px">Plafond : % Project Cost</TD>
													<TD></TD>
													<TD>
														<asp:textbox onkeypress="return digitsonly()" id="TXT_PLAFOND_PRSN_PROJ_COST" runat="server"
															Width="88px" MaxLength="3" DESIGNTIMEDRAGDROP="2158"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 299px">Plafond : Term of Payment (months)</TD>
													<TD></TD>
													<TD>
														<asp:textbox onkeypress="return digitsonly()" id="TXT_PLAFOND_TOP" runat="server" Width="50px"
															MaxLength="2" Columns="2" DESIGNTIMEDRAGDROP="2162"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 299px">Plafond : Existing W/C 
														Plafond&nbsp;Limit in BM (ribuan)</TD>
													<TD></TD>
													<TD>
														<asp:textbox onkeypress="return digitsonly()" id="TXT_CL_EXIST_WC_BM" runat="server" Width="128px"
															MaxLength="8" DESIGNTIMEDRAGDROP="2218"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 299px">Plafond : Existing W/C Plafond Limit in 
														Other Bank (ribuan)</TD>
													<TD></TD>
													<TD>
														<asp:textbox onkeypress="return digitsonly()" id="TXT_CL_EXIST_WC_OBANK" runat="server" Width="128px"
															MaxLength="8" DESIGNTIMEDRAGDROP="2218"></asp:textbox></TD>
												</TR>
											</TABLE>
										</td>
									</TR>
								</TABLE>
							</td>
						</TR> <!-- ************************* separator *************------------------------------------------------------------------------------------------------------------------------------------------->
						<TR id="TR_NCL" runat="server">
							<td class="tdNoBorder" align="center" colSpan="2">
								<TABLE id="Table15" cellSpacing="1" cellPadding="1" width="100%" border="0">
									<TR>
										<TD class="tdheader1" align="center" colSpan="2">NCL</TD>
									</TR>
									<TR>
										<TD class="tdNoBorder" align="center" colSpan="2">
											<TABLE id="Table10" cellSpacing="1" cellPadding="1" width="100%" border="0">
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 294px">
														<P>Non Cash Value of Project pa-General (ribuan)</P>
													</TD>
													<TD width="12"></TD>
													<TD>
														<asp:textbox onkeypress="return digitsonly()" id="TXT_SB_NC_PROJ_PA_GENERAL" runat="server" Width="128px"
															MaxLength="8" DESIGNTIMEDRAGDROP="2085"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 294px">Non CashValue of Project pa-Purchase 
														Bond(ribuan)</TD>
													<TD></TD>
													<TD>
														<asp:textbox onkeypress="return digitsonly()" id="TXT_NC_PROJ_PA_PURCHASE_BOND" runat="server"
															Width="128px" MaxLength="8" DESIGNTIMEDRAGDROP="2193"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 294px; HEIGHT: 1px">% Bid Bond</TD>
													<TD style="HEIGHT: 1px"></TD>
													<TD style="HEIGHT: 1px">
														<asp:textbox onkeypress="return digitsonly()" id="TXT_BID_BOND" runat="server" Width="50px" MaxLength="3"
															Columns="3"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 294px; HEIGHT: 1px">% Probability of Success 
														Bid Bond</TD>
													<TD style="HEIGHT: 1px"></TD>
													<TD style="HEIGHT: 1px">
														<asp:textbox onkeypress="return digitsonly()" id="TXT_PRSN_PROB_SUCCESS_BID_BOND" runat="server"
															Width="50px" MaxLength="3" Columns="3" DESIGNTIMEDRAGDROP="2194"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 294px; HEIGHT: 21px">% Advance Bond</TD>
													<TD style="HEIGHT: 21px"></TD>
													<TD style="HEIGHT: 21px">
														<asp:textbox onkeypress="return digitsonly()" id="TXT_ADV_BOND" runat="server" Width="50px" MaxLength="3"
															Columns="3" DESIGNTIMEDRAGDROP="2196"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 294px">% Performace Bond</TD>
													<TD></TD>
													<TD>
														<asp:textbox onkeypress="return digitsonly()" id="TXT_PRFRMN_BOND" runat="server" Width="50px"
															MaxLength="3" Columns="3"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 294px">% Retention Bond</TD>
													<TD></TD>
													<TD>
														<asp:textbox onkeypress="return digitsonly()" id="TXT_PRSN_RET_BOND" runat="server" Width="50px"
															MaxLength="3" Columns="3" DESIGNTIMEDRAGDROP="2198"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 294px; HEIGHT: 21px">Non Cash Total Amount of 
														Contract (ribuan)</TD>
													<TD style="HEIGHT: 21px"></TD>
													<TD style="HEIGHT: 21px">
														<asp:textbox onkeypress="return digitsonly()" id="TXT_MC_NC_TOTAMOUNT" runat="server" Width="128px"
															MaxLength="11"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 294px; HEIGHT: 21px">
														%
														<asp:Label id="lblPurchaseBondSml" runat="server">Purchase Bond </asp:Label>
														<asp:Label id="lblBondOtherMdl" runat="server" Visible="False">Bond Other Than Contractor</asp:Label></TD>
													<TD style="HEIGHT: 21px"></TD>
													<TD style="HEIGHT: 21px">
														<asp:textbox onkeypress="return digitsonly()" id="TXT_PRSN_PURCHASE_BOND" runat="server" Width="50px"
															MaxLength="3" Columns="3" DESIGNTIMEDRAGDROP="2209"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 294px; HEIGHT: 22px">MC Contractor Peak 
														Deficit Cash Flow (ribuan)</TD>
													<TD style="HEIGHT: 22px"></TD>
													<TD style="HEIGHT: 22px">
														<asp:textbox onkeypress="return digitsonly()" onkeyup="return samakanDeficit('TXTMC_CONT_PEAK_DEFICIT_CF3','TXTMC_CONT_PEAK_DEFICIT_CF','TXTMC_CONT_PEAK_DEFICIT_CF2')"
															id="TXTMC_CONT_PEAK_DEFICIT_CF3" runat="server" Width="128px" MaxLength="8">0</asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 294px; HEIGHT: 22px">L/C Limit : Avg Value L/C 
														in a Year (ribuan)</TD>
													<TD style="HEIGHT: 22px"></TD>
													<TD style="HEIGHT: 22px">
														<asp:textbox onkeypress="return digitsonly()" id="SB_AVG_VALUELC_YEAR" runat="server" Width="128px"
															MaxLength="8" DESIGNTIMEDRAGDROP="2210"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 294px">&nbsp;L/C Limit :&nbsp;Avg Term of L/C 
														in a Year (Turnover in Months)</TD>
													<TD></TD>
													<TD>
														<asp:textbox onkeypress="return digitsonly()" id="TXT_SB_AVG_TERMLC" runat="server" Width="50px"
															MaxLength="3" Columns="3" DESIGNTIMEDRAGDROP="2211"></asp:textbox></TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
								</TABLE>
							</td>
						</TR> <!-- ************************* separator *************------------------------------------------------------------------------------------------------------------------------------------------->
						<TR>
							<TD class="TDBGColor2" vAlign="top" align="center" colSpan="2">
								<asp:label id="SQL" runat="server"></asp:label>
								<asp:button id="BTN_SAVE" runat="server" Width="100px" CssClass="BUTTON1" Text="Save" onclick="BTN_SAVE_Click"></asp:button>
								<asp:button id="BTN_SND_FAIRISAAC" runat="server" Width="167px" CssClass="Button1" Enabled="False"
									Text="Calculate Score" onclick="BTN_SND_FAIRISAAC_Click"></asp:button></TD>
						</TR>
					</TBODY>
				</TABLE>
			</center>
		</form>
		</TR></TBODY></TABLE></TR></TBODY></TABLE>
		<CENTER>&nbsp;</CENTER>
		</FORM>
	</body>
</HTML>
