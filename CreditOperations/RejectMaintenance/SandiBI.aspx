<%@ Page language="c#" Codebehind="SandiBI.aspx.cs" AutoEventWireup="True" Inherits="SME.CreditOperations.RejectMaintenance.SandiBI" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SandiBI</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE cellSpacing="2" cellPadding="2" width="100%">
					<tr>
						<td colspan="2" class="tdHeader1" width="100%" align="center"><B>Sandi BI</B></td>
					</tr>
                    <tr>
                        <td colspan="2" class="tdHeader1" width="100%" align="center">
                            <ASP:DATAGRID id="DataGrid1" runat="server" AutoGenerateColumns="False" 
                            Width="100%" CellPadding="1"
								AllowPaging="True" Visible="true" onitemcommand="DataGrid1_ItemCommand">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="AP_REGNO" HeaderText="Application No.">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="CU_REF" HeaderText="CU_REF"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="APPTYPE"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="PRODUCTID"></asp:BoundColumn>
                                    <asp:BoundColumn Visible="False" DataField="KET_CODE"></asp:BoundColumn>
									<asp:BoundColumn DataField="UF_CPSEQ" HeaderText="Product Sequence">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="APPTYPEDESC" HeaderText="Jenis Permohonan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PRODUCTDESC" HeaderText="Jenis Kredit">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="NAME" HeaderText="Nama Pemohon">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AP_SIGNDATE" HeaderText="Tanggal Aplikasi" DataFormatString="{0:dd-MMM-yyyy}">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AP_RELMNGR" HeaderText="Nama RM">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="STATUS" HeaderText="STATUS">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Function">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											&nbsp;
											<asp:LinkButton id="BTN_GRID_VIEW" runat="server" CommandName="view">View</asp:LinkButton>&nbsp;
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn Visible="False" DataField="PROD_SEQ" HeaderText="PROD_SEQ"></asp:BoundColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID>
                        </td>
                    </tr>
					<tr>
						<TD width="20%" valign="top">
							<asp:Table ID="TBL_FASILITAS" Runat="server" Width="100%" CssClass="BackGroundList"></asp:Table>
						</TD>
						<td><iframe id="frm_sandibi" name="frm_sandibi" scrolling="auto" width="100%" height="400" frameborder="0"></iframe>
						</td>
					</tr>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
