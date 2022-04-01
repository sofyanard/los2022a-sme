<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MobileApplicationInfo.aspx.cs" Inherits="SME.InitialDataEntry.MobileApplicationInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Informasi Pengajuan</title>
    <link type="text/css" rel="stylesheet" href="../include/bootstrap.min.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h4>Informasi Pengajuan</h4>
            <div class="row">
                <div class="col-md-6">
                    <table class="table table-striped">
                        <tbody>
                            <tr>
                                <td>Id</td>
                                <td>
                                    <asp:Label ID="LblId" runat="server" Text=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td>Product</td>
                                <td>
                                    <asp:Label ID="LblProduct" runat="server" Text=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td>Limit</td>
                                <td>
                                    <asp:Label ID="LblLimit" runat="server" Text=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td>Tenor</td>
                                <td>
                                    <asp:Label ID="LblTenor" runat="server" Text=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td>Purpose</td>
                                <td>
                                    <asp:Label ID="LblPurpose" runat="server" Text=""></asp:Label></td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div class="col-md-6">
                    <table class="table table-striped">
                        <tbody>
                            <tr>
                                <td>Collateral</td>
                                <td><asp:Label ID="LblCollateralFlag" runat="server" Text=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td>Collateral Type</td>
                                <td><asp:Label ID="LblCollateralType" runat="server" Text=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td>Collateral Value</td>
                                <td><asp:Label ID="LblCollateralValue" runat="server" Text=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td>Certificate Type</td>
                                <td><asp:Label ID="LblCertificateType" runat="server" Text=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td>Certificate No</td>
                                <td><asp:Label ID="LblCertificateNo" runat="server" Text=""></asp:Label></td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
            
        </div>
    </form>
    <script type="text/javascript" src="../include/jquery.min.js"></script>
	<script type="text/javascript" src="../include/popper.min.js"></script>
	<script type="text/javascript" src="../include/bootstrap.min.js"></script>
</body>
</html>
