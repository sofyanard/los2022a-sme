<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QueryEditor.aspx.cs" Inherits="SME.QTools.QueryEditor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <div>
            <asp:TextBox ID="TXT_QUERY" runat="server" Height="600px" TextMode="MultiLine" Width="900px"></asp:TextBox>
        </div>
        <br />
        <div>
            <asp:Button ID="BTN_SELECT" runat="server" Text="Select" OnClick="BTN_SELECT_Click" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="BTN_UPDATE" runat="server" Text="Update" ForeColor="Red" OnClick="BTN_UPDATE_Click" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="BTN_CLEAR" runat="server" Text="Clear" OnClick="BTN_CLEAR_Click" />
        </div>
        <br />
        <div>
            <asp:GridView ID="GV_RESULT" runat="server" AllowPaging="True" OnPageIndexChanging="GV_RESULT_PageIndexChanging"></asp:GridView>
        </div>
        <br />
        <div>
            <asp:Button ID="BTN_EXPORT" runat="server" Text="Export to Excel" OnClick="BTN_EXPORT_Click" />
        </div>
        <br />
        <div>
            <asp:Label ID="LBL_MESSAGE" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
