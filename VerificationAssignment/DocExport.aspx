<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DocExport.aspx.cs" Inherits="SME.VerificationAssignment.DocExport" %>

<%@ Register TagPrefix="uc1" TagName="DocExport" Src="../CommonForm/DocumentExport.ascx" %>
<%@ Register TagPrefix="uc1" TagName="DocUpload" Src="../CommonForm/DocumentUpload.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Document Export</title>
    <link href="../style.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <table style="width: 100%">
        <tr>
            <td colspan="2">
                <uc1:DocExport ID="DocExport1" runat="server"></uc1:DocExport>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <uc1:DocUpload ID="DocUpload1" runat="server"></uc1:DocUpload>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
