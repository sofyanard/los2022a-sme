<%@ Page language="c#" Codebehind="DetailJaminanData.aspx.cs" AutoEventWireup="True" Inherits="SME.CreditOperations.Booking.DetailJaminanData" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DetailJaminanData</title>
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
						<td colspan="2" class="tdHeader1"><B>Data Jaminan</B></td>
					</tr>
					<tr>
						<td width="50%" valign="top" class="td">
							<TABLE cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="150">Deskripsi</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue">
										<asp:TextBox onkeypress="return numbersonly()" id="TXT_CL_DESC" ReadOnly="True" CssClass="angka"
											Columns="25" MaxLength="21" Runat="server"></asp:TextBox></TD>
								</TR>
								<tr>
									<td class="TDBGColor1" width="150">Appraisal Value</td>
									<td width="15"></td>
									<td class="TDBGColorValue"><asp:TextBox ID="TXT_CL_APPRVALUE" Runat="server" MaxLength="21" Columns="25" onKeypress="return numbersonly()"
											CssClass="angka" ReadOnly="True"></asp:TextBox></td>
								</tr>
								<tr>
									<td class="TDBGColor1">Offered Value</td>
									<td></td>
									<td class="TDBGColorValue"><asp:TextBox ID="TXT_CL_OFFERVALUE" Runat="server" MaxLength="21" Columns="25" onKeypress="return numbersonly()"
											CssClass="angka" ReadOnly="True"></asp:TextBox></td>
								</tr>
							</TABLE>
							<asp:Label ID="LBL_REGNO" Runat="server" Visible="False"></asp:Label>
							<asp:Label ID="LBL_CUREF" Runat="server" Visible="False"></asp:Label>
							<asp:Label ID="LBL_TC" Runat="server" Visible="False"></asp:Label>
							<asp:Label ID="LBL_CL_SEQ" Runat="server" Visible="False"></asp:Label>
							<asp:Label ID="LBL_PRODUCTID" Runat="server" Visible="False"></asp:Label>
							<asp:Label id="LBL_CL_TYPE" Runat="server" Visible="False"></asp:Label>
						</td>
						<td valign="top" class="td">
							<TABLE cellSpacing="0" cellPadding="0" width="100%">
								<tr>
									<td class="TDBGColor1" width="150" valign="top">Alamat</td>
									<td width="15"></td>
									<td class="TDBGColorValue">
										<asp:TextBox ID="TXT_CL_SERTADDR1" Runat="server" MaxLength="30" Columns="25" onKeypress="return kutip_satu()"
											ReadOnly="True"></asp:TextBox>
										<asp:TextBox ID="TXT_CL_SERTADDR2" Runat="server" MaxLength="30" Columns="25" onKeypress="return kutip_satu()"
											ReadOnly="True"></asp:TextBox>
										<asp:TextBox ID="TXT_CL_SERTADDR3" Runat="server" MaxLength="30" Columns="25" onKeypress="return kutip_satu()"
											ReadOnly="True"></asp:TextBox>
									</td>
								</tr>
							</TABLE>
							<asp:CheckBox ID="CHB_CL_SERTADDRSM" Runat="server" Text="Sesuai Sertifikat" Visible="False"></asp:CheckBox>
						</td>
					</tr>
				</TABLE>
				<TABLE cellSpacing="2" cellPadding="2" width="100%">
					<tr>
						<td class="tdHeader1"><B> Asuransi</B></td>
					</tr>
					<tr>
						<td><asp:datagrid id="DataGrid1" runat="server" PageSize="3" AutoGenerateColumns="False" Width="100%"
								CellPadding="1">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="SEQ">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="ICT_DESC" HeaderText="Type">
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
									<asp:BoundColumn DataField="ACA_VALUE" HeaderText="Nilai Pertanggungan">
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
									<asp:BoundColumn DataField="ACA_PERCENTAGE" HeaderText="% Pertanggungan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="ACA_CLASS" HeaderText="Class">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="ACA_PREMI" HeaderText="Premi">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
							</asp:datagrid>
						</td>
					</tr>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
