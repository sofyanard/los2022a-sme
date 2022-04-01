<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerificationInvestigation.aspx.cs" Inherits="SME.VerificationAssignment.VerificationInvestigation" %>

<%@ Register TagPrefix="uc1" TagName="DocExport" Src="../CommonForm/DocumentExport.ascx" %>
<%@ Register TagPrefix="uc1" TagName="DocUpload" Src="../CommonForm/DocumentUpload.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Verification Investigation</title>
    <link href="../style.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <table style="width: 100%">
        <tr>
            <td class="tdNoBorder" style="width: 325px">
                <table style="width: 400px">
                    <tr>
                        <td class="TDBGColor2" style="text-align: center">
                            <b>Verification and Investigation</b>
                        </td>
                    </tr>
                </table>
            </td>
            <td class="tdNoBorder" style="text-align: right">
                <asp:ImageButton ID="BTN_BACK" runat="server" ImageUrl="../Image/back.jpg" 
                    onclick="BTN_BACK_Click"></asp:ImageButton>
                <a href="../Body.aspx">
                    <img src="../Image/MainMenu.jpg" /></a> <a href="../Logout.aspx" target="_top">
                        <img src="../Image/Logout.jpg" /></a>
            </td>
        </tr>
        <tr>
            <td class="tdNoBorder" style="height: 41px; text-align: center" colspan="2">
                <asp:PlaceHolder ID="Menu" runat="server"></asp:PlaceHolder>
            </td>
        </tr>
        <tr>
            <td class="tdheader1" style="vertical-align: middle; width: 50%" colspan="2">
                General Information
            </td>
        </tr>
        <tr>
            <td class="td" style="width: 50%; vertical-align: top">
                <table style="width: 100%">
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Nama :
                        </td>
                        <td style="width: 5px">
                        </td>
                        <td>
                            <asp:TextBox ID="TXT_CU_NAME" runat="server" Enabled="False" Width="98%" CssClass="TDBGColorValue"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Alamat :
                        </td>
                        <td style="width: 5px">
                        </td>
                        <td>
                            <asp:TextBox ID="TXT_CU_ADDR1" runat="server" Enabled="False" Width="98%" CssClass="TDBGColorValue"></asp:TextBox>
                            <asp:TextBox ID="TXT_CU_ADDR2" runat="server" Enabled="False" Width="98%" CssClass="TDBGColorValue"></asp:TextBox>
                            <asp:TextBox ID="TXT_CU_ADDR3" runat="server" Enabled="False" Width="98%" CssClass="TDBGColorValue"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Contact Person :
                        </td>
                        <td style="width: 5px">
                        </td>
                        <td>
                            <asp:TextBox ID="TXT_CU_CONTACTPERSON" runat="server" Enabled="False" Width="98%"
                                CssClass="TDBGColorValue"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
            <td class="td" style="width: 50%; vertical-align: top">
                <table width="100%">
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Analis :
                        </td>
                        <td style="width: 5px">
                        </td>
                        <td>
                            <asp:TextBox ID="TXT_AP_RELMNGR" runat="server" Enabled="False" Width="98%" CssClass="TDBGColorValue"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Petugas :
                        </td>
                        <td style="width: 5px">
                        </td>
                        <td>
                            <asp:TextBox ID="TXT_CREDIT_ANALIS" runat="server" Enabled="False" Width="98%"
                                CssClass="TDBGColorValue"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Unit :
                        </td>
                        <td style="width: 5px">
                        </td>
                        <td>
                            <asp:TextBox ID="TXT_BRANCH_CODE" runat="server" Enabled="False" Width="98%" CssClass="TDBGColorValue"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDBGColor1" width="40%">
                            Segmen :
                        </td>
                        <td style="width: 5px">
                        </td>
                        <td>
                            <asp:TextBox ID="TXT_GROUP" runat="server" Enabled="False" Width="98%" CssClass="TDBGColorValue"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <asp:Label ID="LBL_REGNO" Visible="False" runat="server"></asp:Label>
                <asp:Label ID="LBL_TC" Visible="False" runat="server"></asp:Label>
                <asp:Label ID="LBL_CUREF" Visible="False" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="tdheader1" style="vertical-align: top" colspan="2">
            </td>
        </tr>
        <tr>
            <td class="td" style="vertical-align: top" colspan="2">
                <table style="width: 100%">
                    <tr>
                        <td style="text-align: center" colspan="3">
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center" colspan="3">
                            <asp:HyperLink ID="HPL_HOUSE" runat="server" Font-Bold="True" Target="frame">Investigasi Tempat Tinggal</asp:HyperLink>&nbsp;|
                            <asp:HyperLink ID="HPL_OFFICE" runat="server" Font-Bold="True" Target="frame">Investigasi Kantor</asp:HyperLink>&nbsp;|
                            <%--<asp:HyperLink ID="HPL_SELF" runat="server" Font-Bold="True" Target="frame">Self Employee Office</asp:HyperLink>&nbsp;|
                            <asp:HyperLink ID="HPL_PRO" runat="server" Font-Bold="True" Target="frame">Proffessional Office</asp:HyperLink>&nbsp;|--%>
                            <asp:HyperLink ID="HPL_DOC" runat="server" Font-Bold="True" Target="frame">Eksport Dokumen</asp:HyperLink>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table style="width: 100%">
        <tr>
            <td width="100%" colspan="2">
                <iframe id="frame" name="frame" frameborder="0" width="100%" scrolling="auto" height="800"
                    style="border-right: black thin solid; border-top: black thin solid; border-left: black thin solid;
                    border-bottom: black thin solid"></iframe>
            </td>
        </tr>
        <tr>
            <td class="TDBGColor2" style="text-align: center; vertical-align: middle" width="50%" colspan="2">
                <asp:Button ID="BTN_UPDATE" runat="server" CssClass="Button1" 
                    Text="Update Status" Enabled="True" onclick="BTN_UPDATE_Click"></asp:Button>
            </td>
        </tr>
    </table>
    <%--<table style="width: 100%">
        <tr>
            <td colspan="2">
                <uc1:DocExport ID="DocExport" runat="server"></uc1:DocExport>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <uc1:DocUpload ID="DocUpload" runat="server"></uc1:DocUpload>
            </td>
        </tr>
        <tr>
            <td class="TDBGColor2" style="text-align: center; vertical-align: middle" width="50%" colspan="2">
                <asp:Button ID="BTN_UPDATE" runat="server" CssClass="Button1" Text="Update Status" Enabled="False"></asp:Button>
            </td>
        </tr>
    </table>--%>
    </form>
</body>
</html>
