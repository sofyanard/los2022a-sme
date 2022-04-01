<%@ Page language="c#" Codebehind="CifGeneralData.aspx.cs" AutoEventWireup="True" Inherits="SME.DCM.CifGeneralData" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>CifGeneralData</title>
<meta content="Microsoft Visual Studio .NET 7.1" name=GENERATOR>
<meta content=C# name=CODE_LANGUAGE>
<meta content=JavaScript name=vs_defaultClientScript>
<meta content=http://schemas.microsoft.com/intellisense/ie5 name=vs_targetSchema><LINK href="../Style.css" type=text/css rel=stylesheet >
  </HEAD>
<body MS_POSITIONING="GridLayout">
<form id=Form1 method=post runat="server">
<CENTER>
<table width="100%" border=0>
  <tr>
    <td align=left>
      <TABLE id=Table31>
        <TR>
          <TD class=tdBGColor2 style="WIDTH: 400px" align=center 
          ><B>CIF GENERAL 
        DATA</B></TD></TR></TABLE></TD>
    <TD class=tdNoBorder align=right><A href="CifListData.aspx" ></A><asp:imagebutton id=BTN_BACK runat="server" ImageUrl="/SME/Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../Body.aspx" ><IMG src="../Image/MainMenu.jpg" ></A><A href="../Logout.aspx" target=_top ><IMG src="../Image/Logout.jpg" ></A></TD></TR>
  <tr>
    <TD class=tdNoBorder style="HEIGHT: 41px" align=left colSpan=2 
    ><asp:placeholder id=MenuCIF 
      runat="server"></asp:placeholder></TD></TR>
  <TR>
    <TD class=tdHeader1 colSpan=2>General&nbsp;Data</TD></TR>
  <TR>
    <TD class=td vAlign=top width="50%">
      <TABLE id=Table6 cellSpacing=0 cellPadding=0 width="100%" 
      >
        <TR>
          <TD class=TDBGColor1>CIF No</TD>
          <TD style="WIDTH: 15px">:</TD>
          <TD class=TDBGColorValue><asp:textbox id=TXT_CIFNO runat="server" Width="300px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD></TR>
        <TR>
          <TD class=TDBGColor1>Customer&nbsp;Name</TD>
          <TD style="WIDTH: 15px">:</TD>
          <TD class=TDBGColorValue><asp:textbox id=TXT_CUSTNAME runat="server" Width="300px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD></TR>
        <TR>
          <TD class=TDBGColor1 style="WIDTH: 262px; HEIGHT: 31px" 
          >Jenis Nasabah</TD>
          <TD style="WIDTH: 15px">:</TD>
          <TD class=TDBGColorValue><asp:radiobuttonlist id=RDO_JENIS_NASABAH runat="server" Width="250px" AutoPostBack="False" RepeatDirection="Horizontal"></asp:radiobuttonlist></TD></TR>
        <TR>
          <TD class=TDBGColor1>BUC</TD>
          <TD style="WIDTH: 15px">:</TD>
          <TD class=TDBGColorValue style="HEIGHT: 10px"><asp:dropdownlist id=DDL_BUC runat="server"></asp:dropdownlist></TD></TR>
        <TR>
          <TD class=TDBGColor1>PIC Data Owner</TD>
          <TD style="WIDTH: 15px">:</TD>
          <TD class=TDBGColorValue style="HEIGHT: 10px"><asp:dropdownlist id=DDL_PIC_DATA_OWNER runat="server"></asp:dropdownlist></TD></TR>
        <TR>
          <TD class=TDBGColor1>Nama Nasabah Pelaporan</TD>
          <TD style="WIDTH: 15px">:</TD>
          <TD class=TDBGColorValue><asp:textbox id=TXT_NAMA_NASABAH_PELAPORAN runat="server" Width="300px" BorderStyle="None"></asp:textbox></TD></TR>
        <TR>
          <TD class=TDBGColor1>&nbsp;Tgl. Lahir/Tgl. 
            Berdiri Perusahaan</TD>
          <TD style="WIDTH: 15px">:</TD>
          <TD class=TDBGColorValue style="HEIGHT: 23px" align=left 
          ><asp:textbox id=TXT_TGL_PERUSAHAAN runat="server" Width="24px" Columns="4" MaxLength="2"></asp:textbox><asp:dropdownlist id=DDL_BLN_PERUSAHAAN runat="server"></asp:dropdownlist><asp:textbox id=TXT_THN_PERUSAHAAN runat="server" Width="36px" Columns="4" MaxLength="4"></asp:textbox></TD></TR>
        <TR>
          <TD class=TDBGColor1>Tempat Lahir/Akta 
            Dikeluarkan</TD>
          <TD style="WIDTH: 15px">:</TD>
          <TD class=TDBGColorValue><asp:textbox id=TXT_TEMPAT_LAHIR runat="server" Width="300px" BorderStyle="None"></asp:textbox></TD></TR>
        <TR>
          <TD class=TDBGColor1>Jenis ID Utama</TD>
          <TD style="WIDTH: 15px">:</TD>
          <TD class=TDBGColorValue style="HEIGHT: 10px"><asp:dropdownlist id=DDL_ID_UTAMA runat="server"></asp:dropdownlist></TD></TR>
        <TR>
          <TD class=TDBGColor1>No. ID Utama</TD>
          <TD style="WIDTH: 15px">:</TD>
          <TD class=TDBGColorValue><asp:textbox id=TXT_ID_UTAMA runat="server" Width="300px" BorderStyle="None"></asp:textbox></TD></TR>
        <TR>
          <TD class=TDBGColor1>Golongan Nasabah</TD>
          <TD style="WIDTH: 15px">:</TD>
          <TD class=TDBGColorValue style="HEIGHT: 10px"><asp:dropdownlist id=DDL_GOL_NASABAH runat="server"></asp:dropdownlist></TD></TR>
        <TR>
          <TD class=TDBGColor1>Jenis Debitur</TD>
          <TD style="WIDTH: 15px">:</TD>
          <TD class=TDBGColorValue style="HEIGHT: 10px"><asp:dropdownlist id=DDL_JENIS_DEBITUR runat="server"></asp:dropdownlist></TD></TR>
        <TR>
          <TD class=TDBGColor1>Group Nasabah</TD>
          <TD style="WIDTH: 15px">:</TD>
          <TD class=TDBGColorValue><asp:textbox id=TXT_GROUP_NASABAH runat="server" Width="300px" BorderStyle="None"></asp:textbox></TD></TR>
        <TR>
          <TD class=TDBGColor1>Hubungan dengan Bank</TD>
          <TD style="WIDTH: 15px">:</TD>
          <TD class='A"TDBGColorValue"' style="HEIGHT: 10px" 
          ><asp:dropdownlist id=DDL_HUB_DGN_BANK runat="server"></asp:dropdownlist></TD></TR>
        <TR>
          <TD class=TDBGColor1>Alamat Nasabah</TD>
          <TD style="WIDTH: 15px">:</TD>
          <TD class=TDBGColorValue><asp:textbox id=TXT_ADD_NASABAH runat="server" Width="300px" BorderStyle="None"></asp:textbox></TD></TR>
        <TR>
          <TD class=TDBGColor1>Kecamatan</TD>
          <TD style="WIDTH: 15px">:</TD>
          <TD class=TDBGColorValue><asp:textbox id=TXT_KECAMATAN runat="server" Width="300px" BorderStyle="None"></asp:textbox></TD></TR>
        <TR>
          <TD class=TDBGColor1>Kode Pos</TD>
          <TD style="WIDTH: 15px">:</TD>
          <TD class=TDBGColorValue><asp:textbox id=TXT_CU_COMPZIPCODE runat="server" ReadOnly="True" Columns="6" MaxLength="6"></asp:textbox><asp:button id=BTN_SEARCHCOMP runat="server" Text="Search" onclick="BTN_SEARCHCOMP_Click"></asp:button></TD></TR>
        <TR>
          <TD class=TDBGColor1>Lokasi Dati II</TD>
          <TD style="WIDTH: 15px">:</TD>
          <TD class=TDBGColorValue style="HEIGHT: 10px"><asp:dropdownlist id=DDL_LOKASI_DATI runat="server"></asp:dropdownlist></TD></TR>
        <TR>
          <TD class=TDBGColor1 style="WIDTH: 262px; HEIGHT: 31px" 
          >Nomor Telp Rumah/Kantor/HP</TD>
          <TD style="WIDTH: 15px">:</TD>
          <TD class=TDBGColorValue><asp:radiobuttonlist id=RDO_NO_TLP runat="server" RepeatDirection="Horizontal">
											<asp:ListItem Value="HP" Selected="True">HP</asp:ListItem>
											<asp:ListItem Value="TR">TR</asp:ListItem>
											<asp:ListItem Value="TK">TK</asp:ListItem>
										</asp:radiobuttonlist><asp:textbox id=TXT_NO_TLP BorderStyle="None" Runat="server"></asp:textbox></TD></TR>
        <TR>
          <TD class=TDBGColor1>Valuta</TD>
          <TD style="WIDTH: 15px">:</TD>
          <TD class=TDBGColorValue style="HEIGHT: 10px"><asp:dropdownlist id=DDL_VALUTA runat="server"></asp:dropdownlist></TD></TR></TABLE></TD>
    <TD class=td vAlign=top width="50%">
      <TABLE id=Table3 cellSpacing=0 cellPadding=0 width="100%" 
      >
        <TR>
          <TD class=tdHeader1 colSpan=3>Badan Usaha</TD></TR>
        <TR>
          <TD class=TDBGColor1>No. APP</TD>
          <TD style="WIDTH: 15px">:</TD>
          <TD class=TDBGColorValue><asp:textbox id=TXT_NO_APP runat="server" Width="300px" BorderStyle="None"></asp:textbox></TD></TR>
        <TR>
          <TD class=TDBGColor1>Tanggal Akte APP</TD>
          <TD style="WIDTH: 15px">:</TD>
          <TD class=TDBGColorValue style="HEIGHT: 23px" align=left 
          ><asp:textbox id=TXT_TGL_APP runat="server" Width="24px" Columns="4" MaxLength="2"></asp:textbox><asp:dropdownlist id=DDL_BLN_APP runat="server"></asp:dropdownlist><asp:textbox id=TXT_THN_APP runat="server" Width="36px" Columns="4" MaxLength="4"></asp:textbox></TD></TR>
        <TR>
          <TD class=TDBGColor1>No. APT</TD>
          <TD style="WIDTH: 15px">:</TD>
          <TD class=TDBGColorValue><asp:textbox id=TXT_NO_APT runat="server" Width="300px" BorderStyle="None"></asp:textbox></TD></TR>
        <TR>
          <TD class=TDBGColor1>Tanggal APT</TD>
          <TD style="WIDTH: 15px">:</TD>
          <TD class=TDBGColorValue style="HEIGHT: 23px" align=left 
          ><asp:textbox id=TXT_TGL_APT runat="server" Width="24px" Columns="4" MaxLength="2"></asp:textbox><asp:dropdownlist id=DDL_BLN_APT runat="server"></asp:dropdownlist><asp:textbox id=TXT_THN_APT runat="server" Width="36px" Columns="4" MaxLength="4"></asp:textbox></TD></TR>
        <TR>
          <TD class=TDBGColor1>Pendapatan Operasional</TD>
          <TD style="WIDTH: 15px">:</TD>
          <TD class=TDBGColorValue><asp:textbox id=TXT_PENDAPATAN_OPERASIONAL runat="server" Width="300px" BorderStyle="None"></asp:textbox></TD></TR>
        <TR>
          <TD class=TDBGColor1>Pendapatan Non 
          Operasional</TD>
          <TD style="WIDTH: 15px">:</TD>
          <TD class=TDBGColorValue><asp:textbox id=TXT_PENDAPATAN_NON_OPERASIONAL runat="server" Width="300px" BorderStyle="None"></asp:textbox></TD></TR>
        <TR>
          <TD class=TDBGColor1>Lembaga Pemeringkatan</TD>
          <TD style="WIDTH: 15px">:</TD>
          <TD class='A"TDBGColorValue"' style="HEIGHT: 10px" 
          ><asp:dropdownlist id=DDL_LEMBAGA_PEMERINGKAT runat="server"></asp:dropdownlist></TD></TR>
        <TR>
          <TD class=TDBGColor1>Peringkat Perusahaan</TD>
          <TD style="WIDTH: 15px">:</TD>
          <TD class='A"TDBGColorValue"' style="HEIGHT: 10px" 
          ><asp:dropdownlist id=DDL_PERINGKAT_PERUSAHAAN runat="server"></asp:dropdownlist></TD></TR>
        <TR>
          <TD class=TDBGColor1>&nbsp;Tanggal 
          Pemeringkatan</TD>
          <TD style="WIDTH: 15px">:</TD>
          <TD class=TDBGColorValue style="HEIGHT: 23px" align=left 
          ><asp:textbox id=TXT_TGL_PEMERINGKAT runat="server" Width="24px" Columns="4" MaxLength="2"></asp:textbox><asp:dropdownlist id=DDL_BLN_PEMERINGKAT runat="server"></asp:dropdownlist><asp:textbox id=TXT_THN_PEMERINGKAT runat="server" Width="36px" Columns="4" MaxLength="4"></asp:textbox></TD></TR>
        <TR>
          <TD class=TDBGColor1>Bentuk Badan Usaha</TD>
          <TD style="WIDTH: 15px">:</TD>
          <TD class='A"TDBGColorValue"' style="HEIGHT: 10px" 
          ><asp:dropdownlist id=DDL_BU runat="server"></asp:dropdownlist></TD></TR>
        <TR>
          <TD class=tdHeader1 colSpan=3>Perorangan</TD></TR>
        <TR>
          <TD class=TDBGColor1>Jenis Kelamin</TD>
          <TD style="WIDTH: 15px">:</TD>
          <TD class='A"TDBGColorValue"' style="HEIGHT: 10px" 
          ><asp:dropdownlist id=DDL_JENIS_KELAMIN runat="server"></asp:dropdownlist></TD></TR>
        <TR>
          <TD class=TDBGColor1>Nama Gadis/Ibu Kandung</TD>
          <TD style="WIDTH: 15px">:</TD>
          <TD class=TDBGColorValue><asp:textbox id=TXT_NAMA_IBU runat="server" Width="300px" BorderStyle="None"></asp:textbox></TD></TR>
        <TR>
          <TD class=TDBGColor1>Nama Prefik</TD>
          <TD style="WIDTH: 15px">:</TD>
          <TD class='A"TDBGColorValue"' style="HEIGHT: 10px" 
          ><asp:dropdownlist id=DDL_NAMA_PREFIK runat="server"></asp:dropdownlist></TD></TR>
        <TR>
          <TD class=TDBGColor1>Nama Perusahaan Nasabah 
            Bekerja</TD>
          <TD style="WIDTH: 15px">:</TD>
          <TD class=TDBGColorValue><asp:textbox id=TXT_NAMA_PERUSAHAAN runat="server" Width="300px" BorderStyle="None"></asp:textbox></TD></TR>
        <TR>
          <TD class=TDBGColor1>Bidang Usaha Nasabah</TD>
          <TD style="WIDTH: 15px">:</TD>
          <TD class=TDBGColorValue><asp:dropdownlist id=DDL_BU_NASABAH runat="server"></asp:dropdownlist></TD></TR>
        <TR>
          <TD class=TDBGColor1>Jabatan Nasabah</TD>
          <TD style="WIDTH: 15px">:</TD>
          <TD class='A"TDBGColorValue"' style="HEIGHT: 10px" 
          ><asp:dropdownlist id=DDL_JABATAN_NASABAH runat="server"></asp:dropdownlist></TD></TR>
        <TR>
          <TD class=TDBGColor1>Pekerjaan Nasabah</TD>
          <TD style="WIDTH: 15px">:</TD>
          <TD class='A"TDBGColorValue"' style="HEIGHT: 10px" 
          ><asp:dropdownlist id=DDL_PEKERJAAN_NASABAH runat="server"></asp:dropdownlist></TD></TR>
        <TR>
          <TD class=TDBGColor1>Gaji</TD>
          <TD style="WIDTH: 15px">:</TD>
          <TD class=TDBGColorValue><asp:textbox id=TXT_GAJI runat="server" Width="300px" BorderStyle="None"></asp:textbox></TD></TR>
        <TR>
          <TD class=TDBGColor1>Pendapatan Utama</TD>
          <TD style="WIDTH: 15px">:</TD>
          <TD class=TDBGColorValue><asp:textbox id=TXT_PENDAPATAN_UTAMA runat="server" Width="300px" BorderStyle="None"></asp:textbox></TD></TR>
        <TR>
          <TD class=TDBGColor1>Pendapatan Lainnya</TD>
          <TD style="WIDTH: 15px">:</TD>
          <TD class=TDBGColorValue><asp:textbox id=TXT_PENDAPATAN_LAINNYA runat="server" Width="300px" BorderStyle="None"></asp:textbox></TD></TR>
        <TR>
          <TD class=TDBGColor1>Kewarganegaraan</TD>
          <TD style="WIDTH: 15px">:</TD>
          <TD class='A"TDBGColorValue"' style="HEIGHT: 10px" 
          ><asp:dropdownlist id=DDL_KEWARGANEGARAAN runat="server"></asp:dropdownlist></TD></TR>
        <TR>
          <TD class=TDBGColor1>Status Perkawinan</TD>
          <TD style="WIDTH: 15px">:</TD>
          <TD class='A"TDBGColorValue"' style="HEIGHT: 10px" 
          ><asp:dropdownlist id=DDL_STATUS_PERKAWINAN runat="server"></asp:dropdownlist></TD></TR></TABLE></TD></TR>
  <tr>
    <td></TD></TR>
  <tr align=center>
    <td class=TDBGColor2 vAlign=top align=center width="100%" colSpan=2 
    ><asp:button id=BTN_SAVE runat="server" Width="76px" Text="SAVE" CssClass="Button1" onclick="BTN_SAVE_Click"></asp:button><asp:button id=BTN_CLEAR runat="server" Width="76px" Text="CLEAR" CssClass="Button1" onclick="BTN_CLEAR_Click"></asp:button></TD></TR></TABLE></CENTER></FORM>
	</body>
</HTML>
