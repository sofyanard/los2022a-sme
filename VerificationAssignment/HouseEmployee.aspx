<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HouseEmployee.aspx.cs"
    Inherits="SME.VerificationAssignment.HouseEmployee" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Employee House</title>
    <link href="../style.css" type="text/css" rel="stylesheet" />
    <!-- #include file="../include/cek_all.html" -->
    <!-- #include file="../include/cek_mandatory.html" -->
    <!-- #include file="../include/cek_entries.html" -->
    <script language="javascript" type="text/javascript">
        function RefreshParent(link) {
            window.parent.location.href = link;
    }
	</script>
</head>
<body>
    <form id="Form1" method="post" runat="server">
    <table width="100%">
        <tr>
            <td class="tdheader1" style="vertical-align: middle" colspan="2">
                Data Rumah
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
                            <asp:TextBox ID="TXT_PEMBERI_KET_1" runat="server" Width="98%" MaxLength="50"
                                CssClass="TDBGColorValue"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Hubungan dengan Pemberi Keterangan 1 :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:DropDownList ID="DDL_HUB_PEMBERI_KET_1" runat="server" Width="99%" CssClass="TDBGColorValue">
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
                            <asp:TextBox ID="TXT_PEMBERI_KET_2" runat="server" Width="98%" MaxLength="50"
                                CssClass="TDBGColorValue"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Hubungan dengan Pemberi Keterangan 2 :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:DropDownList ID="DDL_HUB_PEMBERI_KET_2" runat="server" Width="99%" CssClass="TDBGColorValue">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Nama Pemohon (sesuai KTP) :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:TextBox ID="TXT_NAMA_PEMOHON1" runat="server" Width="30%" MaxLength="50"
                                CssClass="TDBGColorValue"></asp:TextBox>&nbsp;
                            <asp:TextBox ID="TXT_NAMA_PEMOHON2" runat="server" Width="30%" MaxLength="50"
                                CssClass="TDBGColorValue"></asp:TextBox>&nbsp;
                            <asp:TextBox ID="TXT_NAMA_PEMOHON3" runat="server" Width="30%" MaxLength="50"
                                CssClass="TDBGColorValue"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Tanggal Lahir :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:TextBox onkeypress="return numbersonly()" ID="TXT_BIRTHDATE_DAY" runat="server"
                                Width="24px" Columns="4" MaxLength="2" CssClass="TDBGColorValue"></asp:TextBox>
                            <asp:DropDownList ID="DDL_BIRTHDATE_MONTH" runat="server" CssClass="TDBGColorValue">
                            </asp:DropDownList>
                            <asp:TextBox onkeypress="return numbersonly()" ID="TXT_BIRTHDATE_YEAR" runat="server"
                                Width="36px" Columns="4" MaxLength="4" CssClass="TDBGColorValue"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Jenis Kelamin :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:RadioButtonList ID="RDO_SEX_TYPE" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="1" Selected="True">Laki-laki</asp:ListItem>
                                <asp:ListItem Value="0">Perempuan</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Alamat Email :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:TextBox ID="TXT_EMAIL" runat="server" Width="98%" MaxLength="50" AutoCompleteType="Email"
                                CssClass="TDBGColorValue"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Alamat Sesuai KTP :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:TextBox ID="TXT_ADDR_KTP1" runat="server" Width="98%" MaxLength="50"
                                CssClass="TDBGColorValue"></asp:TextBox>&nbsp;
                            <asp:TextBox ID="TXT_ADDR_KTP2" runat="server" Width="98%" MaxLength="50"
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
                            <asp:TextBox ID="TXT_ADDR_KTP3" runat="server" Width="98%" MaxLength="50"
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
                            <asp:TextBox onkeypress="return kutip_satu()" ID="TXT_ZIPCODE_KTP" runat="server"
                                CssClass="TDBGColorValue" AutoPostBack="True" MaxLength="6" Columns="6" 
                                ontextchanged="TXT_ZIPCODE_KTP_TextChanged">
                            </asp:TextBox>&nbsp;
                            <asp:Button ID="BTN_SEARCHZIP_KTP" runat="server" Text="Search" 
                                onclick="BTN_SEARCHZIP_KTP_Click">
                            </asp:Button>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            <asp:Label ID="LBL_CITY_KTP" runat="server" Visible="False"></asp:Label>Kota :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:TextBox ID="TXT_CITY_KTP" runat="server" Width="98%" MaxLength="50" CssClass="TDBGColorValue"
                                Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
            <td class="td" style="width: 50%; vertical-align: top">
                <table width="100%">
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Alamat Tinggal Sekarang :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:TextBox ID="TXT_ADDR1" runat="server" Width="98%" MaxLength="50"
                                CssClass="TDBGColorValue"></asp:TextBox>&nbsp;
                            <asp:TextBox ID="TXT_ADDR2" runat="server" Width="98%" MaxLength="50"
                                CssClass="TDBGColorValue"></asp:TextBox>
                            <asp:CheckBox ID="CHB_ADDR" AutoPostBack="True" Text="Sama dengan Alamat KTP"
                                runat="server" oncheckedchanged="CHB_ADDR_CheckedChanged"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Kelurahan / Kecamatan :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:TextBox ID="TXT_ADDR3" runat="server" Width="98%" MaxLength="50"
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
                            <asp:TextBox onkeypress="return kutip_satu()" ID="TXT_ZIPCODE" runat="server"
                                CssClass="TDBGColorValue" AutoPostBack="True" MaxLength="6" Columns="6" 
                                ontextchanged="TXT_ZIPCODE_TextChanged">
                            </asp:TextBox>&nbsp;
                            <asp:Button ID="BTN_SEARCHZIP" runat="server" Text="Search" 
                                onclick="BTN_SEARCHZIP_Click">
                            </asp:Button>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            <asp:Label ID="LBL_CITY" runat="server" Visible="False"></asp:Label>Kota :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:TextBox ID="TXT_CITY" runat="server" Width="98%" MaxLength="50" CssClass="TDBGColorValue"
                                Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            No. Telepon :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:TextBox ID="TXT_NO_TLP_AREA" runat="server" Width="15%" CssClass="TDBGColorValue"
                                MaxLength="5" onkeypress="return numbersonly()">
                            </asp:TextBox>&nbsp;-&nbsp;
                            <asp:TextBox ID="TXT_NO_TLP" runat="server" Width="50%" CssClass="TDBGColorValue"
                                MaxLength="20" onkeypress="return numbersonly()"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            No. Handphone :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:TextBox ID="TXT_NO_HP_AREA" runat="server" Width="15%" CssClass="TDBGColorValue"
                                Text="+62" MaxLength="5" onkeypress="return numbersonly()">
                            </asp:TextBox>&nbsp;-&nbsp;
                            <asp:TextBox ID="TXT_NO_HP" runat="server" Width="50%" CssClass="TDBGColorValue"
                                MaxLength="20" onkeypress="return numbersonly()"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Status :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:DropDownList ID="DDL_MARRIAGE" runat="server" Width="99%" CssClass="TDBGColorValue">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Nama Suami / Istri :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:TextBox ID="TXT_COUPLE_NM1" runat="server" Width="30%" MaxLength="50"
                                CssClass="TDBGColorValue"></asp:TextBox>&nbsp;
                            <asp:TextBox ID="TXT_COUPLE_NM2" runat="server" Width="30%" MaxLength="50"
                                CssClass="TDBGColorValue"></asp:TextBox>&nbsp;
                            <asp:TextBox ID="TXT_COUPLE_NM3" runat="server" Width="30%" MaxLength="50"
                                CssClass="TDBGColorValue"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Pekerjaan Suami / Istri :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:DropDownList ID="DDL_COUPLE_JOB" runat="server" Width="99%" CssClass="TDBGColorValue">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Nama Ibu Kandung :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:TextBox ID="TXT_MOTHER_NM1" runat="server" Width="30%" MaxLength="50"
                                CssClass="TDBGColorValue"></asp:TextBox>&nbsp;
                            <asp:TextBox ID="TXT_MOTHER_NM2" runat="server" Width="30%" MaxLength="50"
                                CssClass="TDBGColorValue"></asp:TextBox>&nbsp;
                            <asp:TextBox ID="TXT_MOTHER_NM3" runat="server" Width="30%" MaxLength="50"
                                CssClass="TDBGColorValue"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Jumlah Tertanggung :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:TextBox ID="TXT_TERTANGGUNG" runat="server" Width="98%" MaxLength="50" CssClass="TDBGColorValue" onkeypress="return numbersonly()"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Karakter Debitur :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:DropDownList ID="DDL_DEBITUR_TYPE" runat="server" Width="99%" CssClass="TDBGColorValue">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: middle; text-align: center; width: 50%" colspan="2">
                <asp:Label ID="LBL_STS_DATA_HM" Font-Bold="True" ForeColor="red" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="TDBGColor2" style="vertical-align: middle; text-align: center; width: 50%" colspan="2">
                <asp:Button ID="BTN_SV_DATA_HM" runat="server" Text="Simpan" CssClass="Button1" 
                    Width="8%" onclick="BTN_SV_DATA_HM_Click"></asp:Button>&nbsp;&nbsp;
                <asp:Button ID="BTN_CLR_DATA_HM" runat="server" Text="Hapus" CssClass="Button1" 
                    Width="8%" onclick="BTN_CLR_DATA_HM_Click"></asp:Button>
            </td>
        </tr>
        <tr>
            <td class="tdheader1" style="vertical-align: middle" colspan="2">
                Data Rumah Tambahan
            </td>
        </tr>
        <tr>
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
            <td class="td" style="width: 50%; vertical-align: top">
                <table width="100%">
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
                            No. Handphone :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:TextBox ID="TXT_NO_HP_AREA_PLUS" runat="server" Width="15%" CssClass="TDBGColorValue"
                                Text="+62" MaxLength="5" onkeypress="return numbersonly()">
                            </asp:TextBox>&nbsp;-&nbsp;
                            <asp:TextBox ID="TXT_NO_HP_PLUS" runat="server" Width="50%" CssClass="TDBGColorValue"
                                MaxLength="20" onkeypress="return numbersonly()"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: middle; text-align: center; width: 50%" colspan="2">
                <asp:Label ID="LBL_STS_HM_PLUS" Font-Bold="True" ForeColor="red" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="TDBGColor2" style="vertical-align: middle; text-align: center; width: 50%" colspan="2">
                <asp:Button ID="BTN_SV_HM_PLUS" runat="server" Text="Simpan" CssClass="Button1" 
                    Width="8%" onclick="BTN_SV_HM_PLUS_Click"></asp:Button>&nbsp;&nbsp;
                <asp:Button ID="BTN_CLR_HM_PLUS" runat="server" Text="Hapus" CssClass="Button1" 
                    Width="8%" onclick="BTN_CLR_HM_PLUS_Click"></asp:Button>
            </td>
        </tr>
        <tr>
            <td class="tdheader1" style="vertical-align: middle" colspan="2">
                Keluarga Dekat Tidak Serumah
            </td>
        </tr>
        <tr>
            <td class="td" style="width: 50%; vertical-align: top">
                <table width="100%">
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Nama :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:TextBox ID="TXT_NAMA_FAMS1" runat="server" Width="30%" MaxLength="50"
                                CssClass="TDBGColorValue"></asp:TextBox>&nbsp;
                            <asp:TextBox ID="TXT_NAMA_FAMS2" runat="server" Width="30%" MaxLength="50"
                                CssClass="TDBGColorValue"></asp:TextBox>&nbsp;
                            <asp:TextBox ID="TXT_NAMA_FAMS3" runat="server" Width="30%" MaxLength="50"
                                CssClass="TDBGColorValue"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Alamat Tinggal Sekarang :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:TextBox ID="TXT_ADDR_FAMS1" runat="server" Width="98%" MaxLength="50"
                                CssClass="TDBGColorValue"></asp:TextBox>&nbsp;
                            <asp:TextBox ID="TXT_ADDR_FAMS2" runat="server" Width="98%" MaxLength="50"
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
                            <asp:TextBox ID="TXT_ADDR_FAMS3" runat="server" Width="98%" MaxLength="50"
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
                            <asp:TextBox onkeypress="return kutip_satu()" ID="TXT_ZIPCODE_FAMS" runat="server"
                                CssClass="TDBGColorValue" AutoPostBack="True" MaxLength="6" Columns="6" 
                                ontextchanged="TXT_ZIPCODE_FAMS_TextChanged">
                            </asp:TextBox>&nbsp;
                            <asp:Button ID="BTN_SEARCHZIP_FAMS" runat="server" Text="Search" 
                                onclick="BTN_SEARCHZIP_FAMS_Click"></asp:Button>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            <asp:Label ID="LBL_CITY_FAMS" runat="server" Visible="False"></asp:Label>Kota :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:TextBox ID="TXT_CITY_FAMS" runat="server" Width="98%" MaxLength="50" CssClass="TDBGColorValue" Enabled="False"></asp:TextBox>
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
                            <asp:TextBox ID="TXT_NO_TLP_AREA_FAMS" runat="server" Width="15%" CssClass="TDBGColorValue" MaxLength="5"
                                onkeypress="return numbersonly()">
                            </asp:TextBox>&nbsp;-&nbsp;
                            <asp:TextBox ID="TXT_NO_TLP_FAMS" runat="server" Width="50%" CssClass="TDBGColorValue"
                                MaxLength="20" onkeypress="return numbersonly()"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            No. Telepon Kantor :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:TextBox ID="TXT_N0_OFFICE_AREA_FAMS" runat="server" Width="15%" CssClass="TDBGColorValue"
                                MaxLength="5" onkeypress="return numbersonly()">
                            </asp:TextBox>&nbsp;-&nbsp;
                            <asp:TextBox ID="TXT_N0_OFFICE_FAMS" runat="server" Width="50%" CssClass="TDBGColorValue"
                                MaxLength="20" onkeypress="return numbersonly()"></asp:TextBox>&nbsp;Ext
                            :
                            <asp:TextBox ID="TXT_EXT_OFFICE_FAMS" runat="server" Width="15%" CssClass="TDBGColorValue"
                                MaxLength="5" onkeypress="return numbersonly()"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            No. Handphone :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:TextBox ID="TXT_NO_HP_AREA_FAMS" runat="server" Width="15%" CssClass="TDBGColorValue"
                                Text="+62" MaxLength="5" onkeypress="return numbersonly()">
                            </asp:TextBox>&nbsp;-&nbsp;
                            <asp:TextBox ID="TXT_NO_HP_FAMS" runat="server" Width="50%" CssClass="TDBGColorValue"
                                MaxLength="20" onkeypress="return numbersonly()"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Relationship :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:DropDownList ID="DDL_HUB_FAMS" runat="server" Width="99%" CssClass="TDBGColorValue">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: middle; text-align: center; width: 50%" colspan="2">
                <asp:Label ID="LBL_STS_HM_FAMS" Font-Bold="True" ForeColor="red" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="TDBGColor2" style="vertical-align: middle; text-align: center; width: 50%" colspan="2">
                <asp:Button ID="BTN_SV_HM_FAMS" runat="server" Text="Simpan" CssClass="Button1" 
                    Width="8%" onclick="BTN_SV_HM_FAMS_Click"></asp:Button>&nbsp;&nbsp;
                <asp:Button ID="BTN_CLR_HM_FAMS" runat="server" Text="Hapus" CssClass="Button1" 
                    Width="8%" onclick="BTN_CLR_HM_FAMS_Click"></asp:Button>
            </td>
        </tr>
        <tr>
            <td class="tdheader1" style="vertical-align: middle" colspan="2">
                Data Rumah Yang Dihuni Pemohon
            </td>
        </tr>
        <tr>
            <td class="td" style="width: 50%; vertical-align: top">
                <table width="100%">
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Status Rumah :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:DropDownList ID="DDL_STS_HS" runat="server" Width="99%" CssClass="TDBGColorValue">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Cek ke :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:CheckBoxList ID="CHB_CEK_HS" runat="server">
                                <asp:ListItem Value="1">Sertifikat</asp:ListItem>
                                <asp:ListItem Value="2">Akta Jual Beli</asp:ListItem>
                                <asp:ListItem Value="3">PBB</asp:ListItem>
                                <asp:ListItem Value="4">Rekening Listrik</asp:ListItem>
                                <asp:ListItem Value="5">Rekening Telepon</asp:ListItem>
                            </asp:CheckBoxList>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Agunan Dihuni :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:RadioButtonList ID="RDO_AGUNAN_HS" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="1">Ya</asp:ListItem>
                                <asp:ListItem Value="0" Selected="True">Tidak</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Lama Menetap :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:TextBox onkeypress="return numbersonly()" ID="TXT_STAY_DAY_HS" runat="server"
                                Width="24px" Columns="4" MaxLength="2" CssClass="TDBGColorValue"></asp:TextBox>&nbsp;Tahun&nbsp;
                            <asp:TextBox onkeypress="return numbersonly()" ID="TXT_STAY_MONTH_HS" runat="server"
                                Width="24px" Columns="4" MaxLength="2" CssClass="TDBGColorValue"></asp:TextBox>&nbsp;Bulan&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Jenis Bangunan :
                        </td>
                        <td width="15px">
                        </td>
                        <td>
                            <asp:DropDownList ID="DDL_JNSBANGUNAN_HS" runat="server" Width="99%" CssClass="TDBGColorValue">
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
                            <asp:DropDownList ID="DDL_LKSBANGUNAN_HS" runat="server" Width="99%" CssClass="TDBGColorValue">
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
                            <asp:DropDownList ID="DDL_CONDBANGUNAN_HS" runat="server" Width="99%" CssClass="TDBGColorValue">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Fasilitas :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:DropDownList ID="DDL_FACILITY_HS" runat="server" Width="99%" CssClass="TDBGColorValue">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Akses Jalan ke Rumah Tinggal :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:DropDownList ID="DDL_AKSES_HS" runat="server" Width="99%" CssClass="TDBGColorValue">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Kondisi Lingkungan :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:DropDownList ID="DDL_COND_HS" runat="server" Width="99%" CssClass="TDBGColorValue">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </td>
            <td class="td" style="width: 50%; vertical-align: top">
                <table width="100%">
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Isi Rumah :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:CheckBoxList ID="CHB_BARANG_HS" runat="server">
                                <asp:ListItem Value="1">Mobil</asp:ListItem>
                                <asp:ListItem Value="2">Sepeda Motor</asp:ListItem>
                                <asp:ListItem Value="3">TV</asp:ListItem>
                                <asp:ListItem Value="4">Sofa</asp:ListItem>
                                <asp:ListItem Value="5">Perabot Lainnya</asp:ListItem>
                            </asp:CheckBoxList>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Luas Tanah :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:TextBox ID="TXT_LUASTANAH_HS" runat="server" Width="50%" CssClass="TDBGColorValue"
                                MaxLength="50" onkeypress="return numbersonly()"></asp:TextBox>&nbsp;m2
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Luas Bangunan :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:TextBox ID="TXT_LUASBANGUNAN_HS" runat="server" Width="50%" CssClass="TDBGColorValue"
                                MaxLength="50" onkeypress="return numbersonly()"></asp:TextBox>&nbsp;m2
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Garasi :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:RadioButtonList ID="RDO_GARASI_HS" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="1">Ada</asp:ListItem>
                                <asp:ListItem Value="0" Selected="True">Tidak Ada</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            CarPort :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:RadioButtonList ID="RDO_CARPORT_HS" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="1">Ada</asp:ListItem>
                                <asp:ListItem Value="0" Selected="True">Tidak Ada</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Kendaraan :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:RadioButtonList ID="RDO_KENDARAAN_HS" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="1">Ada</asp:ListItem>
                                <asp:ListItem Value="0" Selected="True">Tidak Ada</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Jenis Kendaraan :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:DropDownList ID="DDL_VHCTYP_HS" runat="server" Width="99%" CssClass="TDBGColorValue">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Jumlah Kendaraan :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:TextBox ID="TXT_JUMVHC_HS" runat="server" Width="98%" MaxLength="50" CssClass="TDBGColorValue" onkeypress="return numbersonly()"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Kondisi Kendaraan :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:RadioButtonList ID="RDO_CONDVHC_HS" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="1">Baik</asp:ListItem>
                                <asp:ListItem Value="0" Selected="True">Tidak Baik</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Keterangan Lainnya :
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <asp:TextBox ID="TXT_OTHERKET_HS" runat="server" Width="98%" MaxLength="1000" style="resize:none"
                                TextMode="MultiLine" CssClass="TDBGColorValue"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: middle; text-align: center; width: 50%" colspan="2">
                <asp:Label ID="LBL_STS_HS" Font-Bold="True" ForeColor="red" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="TDBGColor2" style="vertical-align: middle; text-align: center; width: 50%" colspan="2">
                <asp:Button ID="BTN_SV_HS" runat="server" Text="Simpan" CssClass="Button1" 
                    Width="8%" onclick="BTN_SV_HS_Click"></asp:Button>&nbsp;&nbsp;
                <asp:Button ID="BTN_CLR_HS" runat="server" Text="Hapus" CssClass="Button1" 
                    Width="8%" onclick="BTN_CLR_HS_Click"></asp:Button>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
