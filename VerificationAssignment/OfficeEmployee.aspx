<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OfficeEmployee.aspx.cs" Inherits="SME.VerificationAssignment.OfficeEmployee" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee Office</title>
    <link href="../style.css" type="text/css" rel="stylesheet" />
    <!-- #include file="../include/cek_all.html" -->
    <!-- #include file="../include/cek_mandatory.html" -->
    <!-- #include file="../include/cek_entries.html" -->
</head>
<body>
    <form id="Form1" method="post" runat="server">
    <table width="100%">
        <tr>
            <td class="tdheader1" style="vertical-align: middle" colspan="2">
                Data Kantor
            </td>
        </tr>
        <tr>
            <td class="td" style="width: 50%; vertical-align: top">
                <table width="100%">
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Tanggal Investigasi :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:TextBox onkeypress="return numbersonly()" ID="TXT_INVESTIGASI_DAY" runat="server"
                                Width="24px" Columns="4" MaxLength="2" CssClass="TDBGColorValue"></asp:TextBox>
                            <asp:DropDownList ID="DDL_INVESTIGASI_MONTH" runat="server" CssClass="TDBGColorValue">
                            </asp:DropDownList>
                            <asp:TextBox onkeypress="return numbersonly()" ID="TXT_INVESTIGASI_YEAR" runat="server"
                                Width="36px" Columns="4" MaxLength="4" CssClass="TDBGColorValue"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Pemberi Keterangan 1 :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:TextBox ID="TXT_PEMBERI_KET1" runat="server" Width="98%" MaxLength="50"
                                CssClass="TDBGColorValue"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Jabatan Pemberi Keterangan 1 :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:DropDownList ID="DDL_POSISI_PEMBERI_KET1" runat="server" Width="99%" CssClass="TDBGColorValue">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Pemberi Keterangan 2 :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:TextBox ID="TXT_PEMBERI_KET2" runat="server" Width="98%" MaxLength="50"
                                CssClass="TDBGColorValue"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Jabatan Pemberi Keterangan 2 :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:DropDownList ID="DDL_POSISI_PEMBERI_KET2" runat="server" Width="99%" CssClass="TDBGColorValue">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Nama Perusahaan :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:DropDownList ID="DDL_OFFICE" runat="server" Width="30%" CssClass="TDBGColorValue">
                            </asp:DropDownList>
                            <asp:TextBox ID="TXT_NM_OFFICE" runat="server" Width="67%" MaxLength="50"
                                CssClass="TDBGColorValue"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Alamat Perusahaan :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:TextBox ID="TXT_ADDR_OFFICE1" runat="server" Width="98%" MaxLength="50"
                                CssClass="TDBGColorValue"></asp:TextBox>&nbsp;
                            <asp:TextBox ID="TXT_ADDR_OFFICE2" runat="server" Width="98%" MaxLength="50"
                                CssClass="TDBGColorValue"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Kelurahan / Kecamatan :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:TextBox ID="TXT_ADDR_OFFICE3" runat="server" Width="98%" MaxLength="50"
                                CssClass="TDBGColorValue"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Kode Pos :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:TextBox onkeypress="return kutip_satu()" ID="TXT_ZIPCODE_OFFICE" runat="server"
                                CssClass="TDBGColorValue" AutoPostBack="True" MaxLength="6" Columns="6" 
                                ontextchanged="TXT_ZIPCODE_OFFICE_TextChanged">
                            </asp:TextBox>&nbsp;
                            <asp:Button ID="BTN_SEARCHZIP_OFFICE" runat="server" Text="Search" 
                                onclick="BTN_SEARCHZIP_OFFICE_Click">
                            </asp:Button>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            <asp:Label ID="LBL_CITY_OFFICE" runat="server" Visible="False"></asp:Label>Kota :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:TextBox ID="TXT_CITY_OFFICE" runat="server" Width="98%" MaxLength="50" CssClass="TDBGColorValue"
                                Enabled="False"></asp:TextBox>
                        </td>
                    </tr>                    
                </table>
            </td>
            <td class="td" style="width: 50%; vertical-align: top">
                <table width="100%">
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            No. Telepon :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:TextBox ID="TXT_N0_TLP_AREA_OFFICE" runat="server" Width="15%" CssClass="TDBGColorValue"
                                MaxLength="5" onkeypress="return numbersonly()">
                            </asp:TextBox>&nbsp;-&nbsp;
                            <asp:TextBox ID="TXT_N0_TLP_OFFICE" runat="server" Width="50%" CssClass="TDBGColorValue"
                                MaxLength="20" onkeypress="return numbersonly()"></asp:TextBox>&nbsp;Ext
                            :
                            <asp:TextBox ID="TXT_EXT_OFFICE" runat="server" Width="15%" CssClass="TDBGColorValue"
                                MaxLength="5" onkeypress="return numbersonly()"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            No. Fax :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:TextBox ID="TXT_N0_FAX_AREA_OFFICE" runat="server" Width="15%" CssClass="TDBGColorValue"
                                MaxLength="5" onkeypress="return numbersonly()">
                            </asp:TextBox>&nbsp;-&nbsp;
                            <asp:TextBox ID="TXT_N0_FAX_OFFICE" runat="server" Width="50%" CssClass="TDBGColorValue"
                                MaxLength="20" onkeypress="return numbersonly()"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Lama Berdiri Perusahaan :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:TextBox onkeypress="return numbersonly()" ID="TXT_YEAR_OFFICE" runat="server"
                                Width="24px" Columns="4" MaxLength="2" CssClass="TDBGColorValue"></asp:TextBox>&nbsp;Tahun
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Bidang Usaha :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:DropDownList ID="DDL_USAHA_OFFICE" runat="server" Width="99%" CssClass="TDBGColorValue">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Jumlah Karyawan :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:TextBox ID="TXT_STAF_OFFICE" runat="server" Width="98%" MaxLength="50" CssClass="TDBGColorValue" onkeypress="return numbersonly()"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Skala Perusahaan :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:TextBox ID="TXT_SCALE_OFFICE" runat="server" Width="98%" MaxLength="50"
                                CssClass="TDBGColorValue"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Jenis Bangunan :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:DropDownList ID="DDL_BANGUNAN_OFFICE" runat="server" Width="99%" CssClass="TDBGColorValue">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Lokasi Bangunan :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:DropDownList ID="DDL_LOKASI_OFFICE" runat="server" Width="99%" CssClass="TDBGColorValue">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Kondisi Bangunan :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:DropDownList ID="DDL_KONDISI_OFFICE" runat="server" Width="99%" CssClass="TDBGColorValue">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Status Kepemilikan :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:DropDownList ID="DDL_OWNER_OFFICE" runat="server" Width="99%" CssClass="TDBGColorValue">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: middle; text-align: center; width: 50%" colspan="2">
                <asp:Label ID="LBL_STS_OFFICE" Font-Bold="True" ForeColor="red" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="TDBGColor2" style="vertical-align: middle; text-align: center; width: 50%" colspan="2">
                <asp:Button ID="BTN_SV_OFFICE" runat="server" Text="Simpan" CssClass="Button1" 
                    Width="8%" onclick="BTN_SV_OFFICE_Click"></asp:Button>&nbsp;&nbsp;
                <asp:Button ID="BTN_CLR_OFFICE" runat="server" Text="Hapus" CssClass="Button1" 
                    Width="8%" onclick="BTN_CLR_OFFICE_Click"></asp:Button>
            </td>
        </tr>
        <tr>
            <td class="tdheader1" style="vertical-align: middle" colspan="2">
                Data Kantor Tambahan
            </td>
        </tr>
        <tr>
            <td class="td" style="width: 50%; vertical-align: top">
                <table width="100%">
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Nama Perusahaan :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:DropDownList ID="DDL_NM_OFFICE_PLUS" runat="server" Width="30%" CssClass="TDBGColorValue">
                            </asp:DropDownList>
                            <asp:TextBox ID="TXT_NM_OFFICE_PLUS" runat="server" Width="67%" MaxLength="50"
                                CssClass="TDBGColorValue"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Jabatan Pemohon :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:DropDownList ID="DDL_POSISI_PEMOHON_PLUS" runat="server" Width="99%" CssClass="TDBGColorValue">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            No. Telepon :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:TextBox ID="TXT_NO_TLP_AREA_PLUS" runat="server" Width="15%" CssClass="TDBGColorValue"
                                MaxLength="5" onkeypress="return numbersonly()">
                            </asp:TextBox>&nbsp;-&nbsp;
                            <asp:TextBox ID="TXT_NO_TLP_PLUS" runat="server" Width="50%" CssClass="TDBGColorValue"
                                MaxLength="20" onkeypress="return numbersonly()"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            No. Fax :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:TextBox ID="TXT_NO_FAX_AREA_PLUS" runat="server" Width="15%" CssClass="TDBGColorValue"
                                MaxLength="5" onkeypress="return numbersonly()">
                            </asp:TextBox>&nbsp;-&nbsp;
                            <asp:TextBox ID="TXT_NO_FAX_PLUS" runat="server" Width="50%" CssClass="TDBGColorValue"
                                MaxLength="20" onkeypress="return numbersonly()"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
            <td class="td" style="width: 50%; vertical-align: top">
                <table width="100%">
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Alamat Rumah Tambahan :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:TextBox ID="TXT_ADDR_PLUS1" runat="server" Width="98%" MaxLength="50"
                                CssClass="TDBGColorValue"></asp:TextBox>&nbsp;
                            <asp:TextBox ID="TXT_ADDR_PLUS2" runat="server" Width="98%" MaxLength="50"
                                CssClass="TDBGColorValue"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Kelurahan / Kecamatan :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:TextBox ID="TXT_ADDR_PLUS3" runat="server" Width="98%" MaxLength="50"
                                CssClass="TDBGColorValue"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Kode Pos :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:TextBox onkeypress="return kutip_satu()" ID="TXT_ZIPCODE_PLUS" runat="server"
                                CssClass="TDBGColorValue" AutoPostBack="True" MaxLength="6" Columns="6" 
                                ontextchanged="TXT_ZIPCODE_PLUS_TextChanged">
                            </asp:TextBox>&nbsp;
                            <asp:Button ID="BTN_SEARCHZIP_PLUS" runat="server" Text="Search" 
                                onclick="BTN_SEARCHZIP_PLUS_Click"></asp:Button>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            <asp:Label ID="LBL_CITY_PLUS" runat="server" Visible="False"></asp:Label>Kota :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:TextBox ID="TXT_CITY_PLUS" runat="server" Width="98%" MaxLength="50" CssClass="TDBGColorValue"
                                Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: middle; text-align: center; width: 50%" colspan="2">
                <asp:Label ID="LBL_STS_OFFICE_PLUS" Font-Bold="True" ForeColor="red" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="TDBGColor2" style="vertical-align: middle; text-align: center; width: 50%" colspan="2">
                <asp:Button ID="BTN_SV_OFFICE_PLUS" runat="server" Text="Simpan" CssClass="Button1" 
                    Width="8%" onclick="BTN_SV_OFFICE_PLUS_Click"></asp:Button>&nbsp;&nbsp;
                <asp:Button ID="BTN_CLR_OFFICE_PLUS" runat="server" Text="Hapus" CssClass="Button1" 
                    Width="8%" onclick="BTN_CLR_OFFICE_PLUS_Click"></asp:Button>
            </td>
        </tr>
        <tr>
            <td class="td" style="width: 50%; vertical-align: top">
                <table width="100%">
                    <tr>
                        <td class="tdheader1" style="vertical-align: middle" colspan="3">
                            Data Pekerjaan
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Pekerjaan :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:DropDownList ID="DDL_NAME_WORK" runat="server" Width="99%" CssClass="TDBGColorValue">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Jabatan Pemohon :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:DropDownList ID="DDL_POSISI_WORK" runat="server" Width="99%" CssClass="TDBGColorValue">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Lama Bekerja :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:TextBox onkeypress="return numbersonly()" ID="TXT_YEAR_WORK" runat="server"
                                Width="24px" Columns="4" MaxLength="2" CssClass="TDBGColorValue"></asp:TextBox>&nbsp;Tahun&nbsp;
                            <asp:TextBox onkeypress="return numbersonly()" ID="TXT_MONTH_WORK" runat="server"
                                Width="24px" Columns="4" MaxLength="2" CssClass="TDBGColorValue"></asp:TextBox>&nbsp;Bulan&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Status Karyawan :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:DropDownList ID="DDL_STATUS_WORK" runat="server" Width="99%" CssClass="TDBGColorValue">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Bagian / Unit :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:TextBox ID="TXT_UNIT_WORK" runat="server" Width="98%" MaxLength="50"
                                CssClass="TDBGColorValue"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Kinerja :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:DropDownList ID="DDL_KINERJA_WORK" runat="server" Width="99%" CssClass="TDBGColorValue">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </td>
            <td class="td" style="width: 50%; vertical-align: top">
                <table width="100%">
                    <tr>
                        <td class="tdheader1" style="vertical-align: middle" colspan="3">
                            Perusahaan Sebelumnya
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Nama Perusahaan :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:TextBox ID="TXT_OFFICE_NM_HISTORY" runat="server" Width="98%" MaxLength="50"
                                CssClass="TDBGColorValue"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            No. Telepon :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:TextBox ID="TXT_NO_TLP_AREA_HISTORY" runat="server" Width="15%" CssClass="TDBGColorValue"
                                MaxLength="5" onkeypress="return numbersonly()">
                            </asp:TextBox>&nbsp;-&nbsp;
                            <asp:TextBox ID="TXT_NO_TLP_HISTORY" runat="server" Width="50%" CssClass="TDBGColorValue"
                                MaxLength="20" onkeypress="return numbersonly()"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Lama Bekerja :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:TextBox onkeypress="return numbersonly()" ID="TXT_OFFICE_YEAR_HISTORY" runat="server"
                                Width="24px" Columns="4" MaxLength="2" CssClass="TDBGColorValue"></asp:TextBox>&nbsp;Tahun&nbsp;
                            <asp:TextBox onkeypress="return numbersonly()" ID="TXT_OFFICE_MONTH_HISTORY" runat="server"
                                Width="24px" Columns="4" MaxLength="2" CssClass="TDBGColorValue"></asp:TextBox>&nbsp;Bulan&nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: middle; text-align: center; width: 50%" colspan="2">
                <asp:Label ID="LBL_STS_OFFICE_WORK" Font-Bold="True" ForeColor="red" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="TDBGColor2" style="vertical-align: middle; text-align: center; width: 50%" colspan="2">
                <asp:Button ID="BTN_SV_OFFICE_WORK" runat="server" Text="Simpan" CssClass="Button1" 
                    Width="8%" onclick="BTN_SV_OFFICE_WORK_Click"></asp:Button>&nbsp;&nbsp;
                <asp:Button ID="BTN_CLR_OFFICE_WORK" runat="server" Text="Hapus" CssClass="Button1" 
                    Width="8%" onclick="BTN_CLR_OFFICE_WORK_Click"></asp:Button>
            </td>
        </tr>
        <tr>
            <td class="tdheader1" style="vertical-align: middle" colspan="2">
                Data Keuangan Customer
            </td>
        </tr>   
        <tr>
            <td class="td" style="width: 50%; vertical-align: top">
                <table width="100%">
                    <tr>
                        <td class="tdheader1" style="vertical-align: middle" colspan="3">
                            Pemohon
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            <b>- Pendapatan</b>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Kotor :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:TextBox ID="TXT_INCOME_BRUTO_PEMOHON" runat="server" Width="98%" MaxLength="50" CssClass="TDBGColorValue" onkeypress="return numbersonly()"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Bersih :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:TextBox ID="TXT_INCOME_NETTO_PEMOHON" runat="server" Width="98%" MaxLength="50" CssClass="TDBGColorValue" onkeypress="return numbersonly()"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Pendapatan Lain :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:TextBox ID="TXT_OTHER_INCOME_PEMOHON" runat="server" Width="98%" MaxLength="50" CssClass="TDBGColorValue" onkeypress="return numbersonly()"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            <b>- Total Pendapatan :</b>
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:TextBox ID="TXT_TOTAL_INCOME_PEMOHON" runat="server" Width="98%" MaxLength="50" CssClass="TDBGColorValue" onkeypress="return numbersonly()"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            <b>- Pengeluaran</b>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Kewajiban Pihak Ketiga :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:TextBox ID="TXT_PAY_PEMOHON" runat="server" Width="98%" MaxLength="50" CssClass="TDBGColorValue" onkeypress="return numbersonly()"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
            <td class="td" style="width: 50%; vertical-align: top">
                <table width="100%">
                    <tr>
                        <td class="tdheader1" style="vertical-align: middle" colspan="3">
                            Spouse
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            <b>- Pendapatan</b>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Kotor :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:TextBox ID="TXT_INCOME_BRUTO_SPOUSE" runat="server" Width="98%" MaxLength="50" CssClass="TDBGColorValue" onkeypress="return numbersonly()"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Bersih :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:TextBox ID="TXT_INCOME_NETTO_SPOUSE" runat="server" Width="98%" MaxLength="50" CssClass="TDBGColorValue" onkeypress="return numbersonly()"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Pendapatan Lain :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:TextBox ID="TXT_OTHER_INCOME_SPOUSE" runat="server" Width="98%" MaxLength="50" CssClass="TDBGColorValue" onkeypress="return numbersonly()"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            <b>- Total Pendapatan :</b>
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:TextBox ID="TXT_TOTAL_INCOME_SPOUSE" runat="server" Width="98%" MaxLength="50" CssClass="TDBGColorValue" onkeypress="return numbersonly()"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            <b>- Pengeluaran</b>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Kewajiban Pihak Ketiga :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:TextBox ID="TXT_PAY_SPOUSE" runat="server" Width="98%" MaxLength="50" CssClass="TDBGColorValue" onkeypress="return numbersonly()"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            <b>- Sisa Pendapatan :</b>
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:TextBox ID="TXT_INCOME_MARGIN" runat="server" Width="98%" MaxLength="50" 
                                onkeypress="return numbersonly()" BackColor="#FFDFBF"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: middle; text-align: center; width: 50%" colspan="2">
                <asp:Label ID="LBL_STS_OFFICE_FINANCE" Font-Bold="True" ForeColor="red" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="TDBGColor2" style="vertical-align: middle; text-align: center; width: 50%" colspan="2">
                <asp:Button ID="BTN_SV_OFFICE_FINANCE" runat="server" Text="Simpan" CssClass="Button1" 
                    Width="8%" onclick="BTN_SV_OFFICE_FINANCE_Click"></asp:Button>&nbsp;&nbsp;
                <asp:Button ID="BTN_CLR_OFFICE_FINANCE" runat="server" Text="Hapus" CssClass="Button1" 
                    Width="8%" onclick="BTN_CLR_OFFICE_FINANCE_Click"></asp:Button>
            </td>
        </tr>
        <tr>
            <td class="tdheader1" style="vertical-align: middle" colspan="2">
                Kesimpulan
            </td>
        </tr>
        <tr>
            <td class="td" style="width: 50%; vertical-align: top">
                <table width="100%">
                    <tr>
                        <td class="tdheader1" style="vertical-align: middle" colspan="3">
                            Informasi Pemohon
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="TXT_PEMOHON_SUMMARY" runat="server" Width="99%" Height="100" MaxLength="1000" style="resize:none"
                                TextMode="MultiLine" CssClass="TDBGColorValue"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
            <td class="td" style="width: 50%; vertical-align: top">
                <table width="100%">
                    <tr>
                        <td class="tdheader1" style="vertical-align: middle" colspan="3">
                            Informasi Pasangan / Lainnya
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="TXT_OTHER_SUMMARY" runat="server" Width="99%" Height="100" MaxLength="1000" style="resize:none"
                                TextMode="MultiLine" CssClass="TDBGColorValue"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: middle; text-align: center; width: 50%" colspan="2">
                <asp:Label ID="LBL_STS_SUMMARY" Font-Bold="True" ForeColor="red" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="TDBGColor2" style="vertical-align: middle; text-align: center; width: 50%" colspan="2">
                <asp:Button ID="BTN_SV_OFFICE_SUMMARY" runat="server" Text="Simpan" CssClass="Button1" 
                    Width="8%" onclick="BTN_SV_OFFICE_SUMMARY_Click"></asp:Button>&nbsp;&nbsp;
                <asp:Button ID="BTN_CLR_OFFICE_SUMMARY" runat="server" Text="Hapus" CssClass="Button1" 
                    Width="8%" onclick="BTN_CLR_OFFICE_SUMMARY_Click"></asp:Button>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
