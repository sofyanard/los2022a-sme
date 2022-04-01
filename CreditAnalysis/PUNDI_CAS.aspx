<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PUNDI_CAS.aspx.cs" Inherits="SME.CreditAnalysis.PUNDI_CAS" %>

<%@ Register src="../CommonForm/DocumentUpload.ascx" tagname="DocumentUpload" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CAS</title>
    <LINK href="../style.css" type="text/css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <table id="Table1" width="100%">
			<tr>
				<td class="tdHeader1" colspan="3">CAS Per USAHA</td>
			</tr>
            <tr>
				<td colSpan="2">
                    <ASP:DATAGRID id="DatGrd" runat="server" CellPadding="1" Width="100%" 
                        AutoGenerateColumns="False" onitemcommand="DatGrd_ItemCommand" 
                        AllowPaging="True" SelectedIndex="0">
						<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
						<Columns>
                            <asp:BoundColumn DataField="USAHA" HeaderText="USAHA">
								<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								<ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
							</asp:BoundColumn>
							<asp:BoundColumn DataField="IDIR" HeaderText="IDIR" Visible=false DataFormatString="{0:p}">
								<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								<ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
							</asp:BoundColumn>
							<asp:BoundColumn DataField="DISP_INCOME" HeaderText="Disposable Income" DataFormatString="Rp.{0:###,###,###.00}" Visible=false>
								<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
							</asp:BoundColumn>
							<asp:BoundColumn DataField="GPM" HeaderText="GPM" DataFormatString="{0:p}">
								<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								<ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
							</asp:BoundColumn>
                            <asp:BoundColumn DataField="WI_NORMAL" HeaderText="WI NORMAL" DataFormatString="Rp.{0:###,###,###.00}">
								<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								<ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
							</asp:BoundColumn>
                            <asp:BoundColumn DataField="WI_NERACA" HeaderText="WI NERACA" DataFormatString="Rp.{0:###,###,###.00}">
								<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								<ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
							</asp:BoundColumn>
                            <asp:BoundColumn DataField="FAC_PER_WI_NORMAL" HeaderText="O/S ALL FASILITAS / WI NORMAL" DataFormatString="{0:p}">
								<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								<ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
							</asp:BoundColumn>
                            <asp:BoundColumn DataField="FAC_PER_WI_NERACA" HeaderText="O/S ALL FASILITAS / WI NERACA" DataFormatString="{0:p}">
								<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								<ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
							</asp:BoundColumn>
                            <asp:ButtonColumn Text="Delete" HeaderText="Function" CommandName="Delete" Visible=false>
								<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								<ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
							</asp:ButtonColumn>
							<asp:BoundColumn Visible="False" DataField="SEQ" HeaderText="SEQ"></asp:BoundColumn>
                            <asp:BoundColumn Visible="False" DataField="AP_REGNO" HeaderText="AP_REGNO"></asp:BoundColumn>
                            <asp:BoundColumn Visible="False" DataField="CU_REF" HeaderText="CU_REF"></asp:BoundColumn>
						</Columns>
					</ASP:DATAGRID>
                </td>
	        </tr>
            <tr>
				<td class="tdHeader1" colspan="3">CAS Summary</td>
			</tr>
            <tr>
                <td>
                    <uc1:DocumentUpload ID="DocumentUpload1" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="vertical-align:middle; text-align:center">
                    <asp:Button ID="Retrieve" runat="server" Text="Ambil Hasil CAS" 
                        CssClass="Button1" Width="160px"/>
                </td>
            </tr>
            <tr>
				<td colSpan="2">
                    <ASP:DATAGRID id="DGSummary" runat="server" CellPadding="1" Width="100%" 
                        AutoGenerateColumns="False" onitemcommand="DatGrd_ItemCommand" 
                        AllowPaging="True" SelectedIndex="0">
						<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
						<Columns>
                            <asp:BoundColumn DataField="USAHA" HeaderText="USAHA">
								<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								<ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
							</asp:BoundColumn>
							<asp:BoundColumn DataField="IDIR" HeaderText="IDIR" DataFormatString="{0:p}">
								<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								<ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
							</asp:BoundColumn>
							<asp:BoundColumn DataField="DISP_INCOME" HeaderText="Disposable Income" DataFormatString="Rp.{0:###,###,###.00}">
								<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
							</asp:BoundColumn>
							<asp:BoundColumn DataField="GPM" HeaderText="GPM" DataFormatString="{0:p}">
								<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								<ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
							</asp:BoundColumn>
                            <asp:BoundColumn DataField="WI_NORMAL" HeaderText="WI NORMAL" DataFormatString="Rp.{0:###,###,###.00}">
								<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								<ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
							</asp:BoundColumn>
                            <asp:BoundColumn DataField="WI_NERACA" HeaderText="WI NERACA" DataFormatString="Rp.{0:###,###,###.00}">
								<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								<ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
							</asp:BoundColumn>
                            <asp:BoundColumn DataField="FAC_PER_WI_NORMAL" HeaderText="O/S ALL FASILITAS / WI NORMAL" DataFormatString="{0:p}">
								<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								<ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
							</asp:BoundColumn>
                            <asp:BoundColumn DataField="FAC_PER_WI_NERACA" HeaderText="O/S ALL FASILITAS / WI NERACA" DataFormatString="{0:p}">
								<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								<ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
							</asp:BoundColumn>
                            <asp:ButtonColumn Text="Delete" HeaderText="Function" CommandName="Delete" Visible=false>
								<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								<ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
							</asp:ButtonColumn>
							<asp:BoundColumn Visible="False" DataField="SEQ" HeaderText="SEQ"></asp:BoundColumn>
                            <asp:BoundColumn Visible="False" DataField="AP_REGNO" HeaderText="AP_REGNO"></asp:BoundColumn>
                            <asp:BoundColumn Visible="False" DataField="CU_REF" HeaderText="CU_REF"></asp:BoundColumn>
						</Columns>
					</ASP:DATAGRID>
                </td>
	        </tr>
        </table>
    </form>
</body>
</html>
