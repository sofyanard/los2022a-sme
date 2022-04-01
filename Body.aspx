<%@ Page Language="c#" CodeBehind="Body.aspx.cs" AutoEventWireup="True" Inherits="SME.Body" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="head" runat="server">
    <title>Body</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="C#">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link href="Maintenance/MenuAccess/menuStyle.css" type="text/css" rel="stylesheet">
    <!-- #include file="include/popup.html" -->
    <link rel="import" href="include/popup.html">
    <link href="Components/General/CSS/Reset.css" rel="stylesheet" type="text/css" />
    <script src="Components/General/JavaScript/jQuery-1.10.2.js" type="text/javascript"></script>
    <link href="Components/Menus/CSS/Menus.css" rel="stylesheet" type="text/css" />
    <script src="Components/Menus/JavaScript/Menus.js" type="text/javascript"></script>
    <script type="text/javascript">

        jQuery(document).ready(function () {
            jQuery('ul.sf-menu').superfish();

            var pend = '<%= getPendingCount() %>';
            $('#MenuDIV .Menus').append('<div id="PopupAppPendingLink" ><img src="Image/mails.png" /><span>' + pend + '</span></div>');
            $('#MenuDIV').on('click', '#PopupAppPendingLink', function () {
                window.open('PendingApplicationInfo.aspx?targetFormID=Form1&targetObjectID=TXT_CON', "Pending Application", "width=450, height=480");
            });
        });

    </script>
    <%= showPendingApplicationsMessage()%>

    <style type="text/css">
        #PopupAppPendingLink {
            cursor: pointer;
            display: inline-block;
        }

            #PopupAppPendingLink img {
                margin: 4px;
            }

            #PopupAppPendingLink span {
                display: block;
                position: relative;
                font-family: Tahoma;
                font-size: 8pt;
                color: #fff;
                font-weight: bold;
                margin-top: -17px;
                margin-left: 25px;
            }
    </style>

</head>
<body ms_positioning="GridLayout" topmargin="0" leftmargin="0" rightmargin="0" bottommargin="0">
    <form id="Form1" method="post" runat="server">
        <div id="MenuDIV" runat="server">
        </div>
        <table height="85%" width="100%">
            <tr>
                <td align="center" valign="top">
                    <table id="Table1" height="100%" cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tr>
                            <td align="right" colspan="3">
                                <asp:Label ID="Label1" runat="server" Visible="False"></asp:Label>
                                <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td align="center">
                                <img src="image/losnet.gif"></td>
                            <td></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <p></p>
    </form>
</body>
</html>
