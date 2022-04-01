<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PerhitunganDSR.aspx.cs" Inherits="SME.CreditAnalysis.PerhitunganDSR" %>

<%@ Register src="../CommonForm/DocumentUpload.ascx" tagname="DocumentUpload" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Perhitungan DSR</title>
    <LINK href="../style.css" type="text/css" rel="stylesheet">
    <!-- #include file="../include/cek_entries.html" -->
</head>
<body>
    <form id="form1" runat="server">
        <table id="Table1" width="100%">
			<tr>
				<td class="tdHeader1" colspan="3">Perhitungan DSR</td>
			</tr>
            <TR id="TR_COMPANY" runat="Server">
				<TD class="td" vAlign="top" width="50%">
					<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%">
						<TR>
							<TD class="TDBGColor1" style="WIDTH: 129px">Plafond</TD>
							<TD style="WIDTH: 15px"></TD>
							<TD class="TDBGColorValue"><asp:textbox id="TXT_PLAFOND" runat="server" 
                                    ReadOnly="True"></asp:textbox></TD>
						</TR>
                        <TR>
							<TD class="TDBGColor1" style="WIDTH: 129px">Jangka Waktu</TD>
							<TD style="WIDTH: 15px"></TD>
							<TD class="TDBGColorValue"><asp:textbox id="TXT_JANGKAWAKTU" runat="server" 
                                    ReadOnly="True"></asp:textbox></TD>
						</TR>
                        <TR>
							<TD class="TDBGColor1" style="WIDTH: 129px">Suku Bunga</TD>
							<TD style="WIDTH: 15px"></TD>
							<TD class="TDBGColorValue">
                                <asp:textbox id="TXT_SUKUBUNGA" runat="server" ReadOnly="True"></asp:textbox>
                                <asp:dropdownlist id="DDL_SIFATBUNGA" runat="server"></asp:dropdownlist>
                            </TD>
						</TR>
                        <TR>
							<TD class="TDBGColor1" style="WIDTH: 129px">Sisa Pendapatan</TD>
							<TD style="WIDTH: 15px"></TD>
							<TD class="TDBGColorValue"><asp:textbox id="TXT_SISAPENDAPATAN" runat="server" 
                                    ReadOnly="True"></asp:textbox>
                                <asp:textbox id="TXT_SISAPENDAPATAN_X" runat="server" BorderStyle="None" 
                                    Width="1px"></asp:textbox></TD>
						</TR>
				    </TABLE>
				</TD>
				<TD class="td" vAlign="top" width="50%">
					<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%">
						<TR>
							<TD class="TDBGColor1" style="WIDTH: 129px">Angsuran</TD>
							<TD style="WIDTH: 15px"></TD>
							<TD class="TDBGColorValue"><asp:textbox id="TXT_ANGSURAN" runat="server" onblur="FormatCurrency(this)"></asp:textbox><asp:label id="LBL_ANGSURAN" runat="server" Width="200px"></asp:label></TD>
						</TR>
                        <TR>
							<TD class="TDBGColor1">DSCR</TD>
							<TD></TD>
							<TD class="TDBGColorValue">
								<asp:textbox id="TXT_DSCR" runat="server" Width="50px" MaxLength="5" onkeypress="return digitsonly()"></asp:textbox>&nbsp;%</TD>
						</TR>
                        <TR>
							<TD class="TDBGColor1" style="WIDTH: 129px">Maksimal Angsuran</TD>
							<TD style="WIDTH: 15px"></TD>
							<TD class="TDBGColorValue"><asp:textbox id="TXT_MAXANGSURAN" runat="server" 
                                    ReadOnly="True"></asp:textbox></TD>
						</TR>
                        <TR>
							<TD class="TDBGColor1" style="WIDTH: 129px">Rekomendasi Limit</TD>
							<TD style="WIDTH: 15px"></TD>
							<TD class="TDBGColorValue"><asp:textbox id="TXT_REKOMENDASILIMIT" runat="server" onblur="FormatCurrency(this)"></asp:textbox><asp:label id="LBL_REKOMENDASILIMIT" runat="server"></asp:label></TD>
						</TR>
                        <TR>
							<TD colspan="3">
                                <asp:textbox id="TXT_AP_REGNO_X" runat="server" BorderStyle="None" Width="1px"></asp:textbox>
                                <asp:textbox id="TXT_APPTYPE_X" runat="server" BorderStyle="None" Width="1px"></asp:textbox>
                                <asp:textbox id="TXT_PRODUCTID_X" runat="server" BorderStyle="None" Width="1px"></asp:textbox>
                                <asp:textbox id="TXT_PROD_SEQ_X" runat="server" BorderStyle="None" Width="1px"></asp:textbox>
                            </TD>
						</TR>
					</TABLE>
				</TD>
			</TR>
            <TR>
				<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2">
                    <asp:button id="BTN_PROCESS" runat="server" Text="Hitung" CssClass="Button1" 
                        Width="100px" onclick="BTN_CALCULATE_Click"></asp:button>&nbsp;&nbsp;
                    <asp:button id="BTN_SAVE" runat="server" Text="Simpan" CssClass="Button1" 
                        Width="100px" onclick="BTN_SAVE_Click"></asp:button>
                </TD>
			</TR>
        </table>
        <table>
            <tr>
                <td>
                    <uc1:DocumentUpload id="DocumentUpload1" runat="server"></uc1:DocumentUpload>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
