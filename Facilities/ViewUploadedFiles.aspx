<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewUploadedFiles.aspx.cs" Inherits="SME.Facilities.ViewUploadedFiles" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <LINK href="../style.css" type="text/css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <center>
            <table id="Table4" width="100%" border="0">
                <tr>
                    <td class="tdNoBorder" width="421">
                        <!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
                        <table id="Table6">
                            <tr>
                                <td class="tdBGColor2" style="width: 400px" align="center"><b>Document Tracking Search</b></td>
                            </tr>
                        </table>
                    </td>
                    <td class="tdNoBorder" align="right"><a href="ListCustomer.aspx?si="></a><a href="../Body.aspx">
                        <img src="../Image/MainMenu.jpg"></a><a href="../Logout.aspx" target="_top"><img src="../Image/Logout.jpg"></a></td>
                </tr>
                <tr>
                    <table class="td" id="Table1" style="width: 590px; height: 200px" cellspacing="1" cellpadding="1" border="1">
                        <tr>
                            <td class="tdHeader1">Search Criteria</td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <table id="Table2" cellspacing="0" cellpadding="0" width="100%" border="0">
                                    <tr>
                                        <td class="TDBGColor1" width="160">Application Number</td>
                                        <td></td>
                                        <td class="TDBGColorValue">
                                            <asp:TextBox onkeypress="return kutip_satu()" ID="TXT_APPNO" runat="server" Width="200px" MaxLength="20"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="TDBGColor1" width="160">CIF No</td>
                                        <td></td>
                                        <td class="TDBGColorValue">
                                            <asp:TextBox onkeypress="return kutip_satu()" ID="TXT_CIFNO" runat="server" Width="200px" MaxLength="20"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="TDBGColor1" width="160">ID Card Number</td>
                                        <td></td>
                                        <td class="TDBGColorValue">
                                            <asp:TextBox onkeypress="return kutip_satu()" ID="TXT_IDNO" runat="server" Width="200px"
                                                MaxLength="30"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td class="TDBGColor1" width="160">Customer Name</td>
                                        <td></td>
                                        <td class="TDBGColorValue">
                                            <asp:TextBox onkeypress="return kutip_satu()" ID="TXT_CU_NAME" runat="server" Width="200px" MaxLength="50"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td valign="top" align="center" width="100%" colspan="3">
                                            <asp:Button ID="BTN_SEARCH" runat="server" Width="75px" CssClass="button1" Text="Search" OnClick="BTN_SEARCH_Click"></asp:Button>&nbsp;
											<asp:Button ID="BTN_CLEAR" runat="server" Width="75px" CssClass="button1" Text="Clear" OnClick="BTN_CLEAR_Click"></asp:Button></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </tr>
                <tr>
					<td class="tdHeader1" colSpan="2">Uploaded File List</td>
				</tr>
                <tr>
                    <td colspan="2">
                        <asp:DataGrid ID="DG_UPFILES" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False"
                            CellPadding="1" PageSize="25" OnPageIndexChanged="DG_UPFILES_PageIndexChanged">
                            <AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
                            <Columns>
                                <asp:BoundColumn DataField="CU_REF" HeaderText="Customer Ref No">
                                    <HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="AP_REGNO" HeaderText="Applicaiton No">
                                    <HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="CU_NAME" HeaderText="Customer Name">
                                    <HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="TEMPLATE" HeaderText="File Template">
                                    <HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="UPLOADFILENAME" HeaderText="File Name">
                                    <HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="DOWNLOAD_URL" Visible="false"></asp:BoundColumn>
                                <asp:TemplateColumn>
									<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:HyperLink id="FU_DOWNLOAD" runat="server" Target="_blank">Download</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
                            </Columns>
                            <PagerStyle Mode="NumericPages"></PagerStyle>
                        </asp:DataGrid></td>
                </tr>
            </table>
        </center>
    </form>
</body>
</html>
