<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SiteVisitAssignment.aspx.cs" Inherits="SME.VerificationAssignment.SiteVisitAssignment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../style.css" type="text/css" rel="stylesheet">
    <link type="text/css" rel="stylesheet" href="../include/bootstrap.min.css" />
	<link type="text/css" rel="stylesheet" href="../include/bootstrap-select.min.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table cellspacing="2" cellpadding="2" width="100%">
                <tr>
                    <td class="tdHeader1" colspan="2">Penugasan</td>
                </tr>
            </table>
            <table cellspacing="2" cellpadding="2" width="100%">
                <tr>
                    <td vAlign="top" width="45%">
                        <table cellSpacing="2" cellPadding="2" width="80%">
                            <tr>
                                <td>Status</td>
                                <td>
                                    <asp:Label ID="Lbl_Status" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>City</td>
                                <td>
                                    <asp:DropDownList ID="Ddl_City" runat="server" CssClass="selectpicker form-control" data-live-search="true" OnSelectedIndexChanged="Ddl_City_SelectedIndexChanged" AutoPostBack="True">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>Agency</td>
                                <td>
                                    <asp:DropDownList ID="Ddl_Agency" runat="server" CssClass="selectpicker form-control" data-live-search="true" AutoPostBack="True" OnSelectedIndexChanged="Ddl_Agency_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>Officer</td>
                                <td>
                                    <asp:DropDownList ID="Ddl_Officer" runat="server" CssClass="selectpicker form-control" data-live-search="true">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:Button ID="Btn_Assign" runat="server" Text="Assign to Surveyor" OnClick="Btn_Assign_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>

    <script type="text/javascript" src="../include/jquery.min.js"></script>
	<script type="text/javascript" src="../include/popper.min.js"></script>
	<script type="text/javascript" src="../include/bootstrap.min.js"></script>
	<script type="text/javascript" src="../include/bootstrap-select.min.js"></script>

</body>
</html>
