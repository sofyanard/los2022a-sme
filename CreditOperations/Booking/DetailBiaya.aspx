<%@ Page language="c#" Codebehind="DetailBiaya.aspx.cs" AutoEventWireup="True" Inherits="SME.CreditOperations.Booking.DetailBiaya" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DetailBiaya</title>
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
						<td colspan="2" class="tdHeader1" width="100%" align="center"><B>Data Detail</B></td>
					</tr>
					<tr>
						<TD rowspan="3" width="20%" valign="top">
							<asp:Table ID="TBL_FASILITAS" Runat="server" Width="100%" CssClass="BackGroundList"></asp:Table>
							<asp:Label id="LBL_REGNO" Runat="server" Visible="False"></asp:Label>
							<asp:Label id="LBL_CUREF" Runat="server" Visible="False"></asp:Label>
							<asp:Label id="LBL_TC" Runat="server" Visible="False"></asp:Label>
						</TD>
						<td class="tdHeader1">Asuransi Jiwa</td>
					</tr>
					<tr>
						<td><asp:datagrid id="DataGrid1" runat="server" CellPadding="1" Width="100%" AutoGenerateColumns="False"
								PageSize="3" AllowPaging="True">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
										<asp:BoundColumn Visible="False" DataField="SEQ">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="INSRCOMPDESC" HeaderText="Nama Perusahaan">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="INSRTYPEDESC" HeaderText="Insurance Type">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="AN_POLICYNO" HeaderText="No Polis">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="AN_CUR" HeaderText="Mata Uang">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="AN_VALUE" HeaderText="Nilai Pertanggungan">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Right"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="AN_DATESTART" HeaderText="Tanggal Mulai">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="AN_DATEEND" HeaderText="Tanggal Akhir">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="AN_PERCENTAGE" HeaderText="% Pertanggungan">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="AN_PREMI" HeaderText="Premi">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Right"></ItemStyle>
										</asp:BoundColumn>
								</Columns>
							</asp:datagrid>
						</td>
					</tr>
					<tr>
						<td><iframe id="frm_fasilitas" name="frm_fasilitas" scrolling="no" width="100%" height="500"
								frameborder="0"></iframe>
						</td>
					</tr>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
