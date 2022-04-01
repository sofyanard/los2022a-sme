<%@ Page language="c#" Codebehind="CollateralLegalSigning_Data.aspx.cs" AutoEventWireup="True" Inherits="SME.Legal.CollateralLegalSigning_Data" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CollateralLegalSigning_Data</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_all.html" -->
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE cellSpacing="2" cellPadding="2" width="100%">
					<tr>
						<td width="50%" valign="top" class="td">
							<TABLE cellSpacing="0" cellPadding="0" width="100%">
								<tr>
									<td class="TDBGColor1" width="150">Appraisal Value</td>
									<td width="15"></td>
									<td class="TDBGColorValue"><asp:TextBox ID="TXT_CL_APPRVALUE" Runat="server" MaxLength="21" Columns="25" onKeypress="return numbersonly()"
											CssClass="angka"></asp:TextBox></td>
								</tr>
								<tr>
									<td class="TDBGColor1">Offered Value</td>
									<td></td>
									<td class="TDBGColorValue"><asp:TextBox ID="TXT_CL_OFFERVALUE" Runat="server" MaxLength="21" Columns="25" onKeypress="return numbersonly()"
											CssClass="angka"></asp:TextBox></td>
								</tr>
								<tr>
									<td class="TDBGColor1">jenis Pengikatan</td>
									<td></td>
									<td class="TDBGColorValue"><asp:DropDownList ID="DDL_CL_IKATTYPE" Runat="server" CssClass="mandatory"></asp:DropDownList></td>
								</tr>
							</TABLE>
						</td>
						<td valign="top" class="td">
							<TABLE cellSpacing="0" cellPadding="0" width="100%">
							<tr>
								<td class="TDBGColor1" valign="top" width="150">Alamat</td>
								<td width="15"></td>
								<td class="TDBGColorValue"><asp:CheckBox ID="CHB_CL_SERTADDRSM" Runat="server" Text="Sesuai Sertifikat"></asp:CheckBox><br>
									<asp:TextBox ID="TXT_CL_SERTADDR1" Runat="server" MaxLength="30" Columns="25" onKeypress="return kutip_satu()"></asp:TextBox><br>
									<asp:TextBox ID="TXT_CL_SERTADDR2" Runat="server" MaxLength="30" Columns="25" onKeypress="return kutip_satu()"></asp:TextBox><br>
									<asp:TextBox ID="TXT_CL_SERTADDR3" Runat="server" MaxLength="30" Columns="25" onKeypress="return kutip_satu()"></asp:TextBox>
								</td>
							</tr>
							</TABLE>
						</td>
					</tr>
					<tr>
						<td><b>Choose Legal Signing</b></td>
						<td></td>
					</tr>
				</TABLE>
				<TABLE cellSpacing="2" cellPadding="2" width="100%">
					<tr>
						<td class="td" valign="top" width="100%">
							<table cellpadding="0" cellspacing="0">
								<tr>
									<td class="TDBGColor1" width="150">COLLATERAL MORTGAGE</td>
									<td width="15"></td>
									<td class="TDBGColorValue">
										<asp:RadioButton ID="RDB_CM1" GroupName="RDB_CM" Runat="server" Text="Notary"></asp:RadioButton>
										<asp:RadioButton ID="RDB_CM2" GroupName="RDB_CM" Runat="server" Text="Di bawah tangan"></asp:RadioButton>
									</td>
								</tr>
							</table>
						</td>
					</tr>
				</TABLE>
				<TABLE cellSpacing="0" cellPadding="0" width="100%">
					<tr>
						<td align="center" class="tdHeader1">Asuransi</td>
					</tr>
					<tr>
						<td>
							<asp:DataGrid ID="DGR_INSR" Runat="server" Width="100%" CellPadding="1" PageSize="1" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="CU_REF" HeaderText="Reference #" Visible="False">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CI_TYPE" HeaderText="Jenis Asuransi">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CI_COMP" HeaderText="Perusahaan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CI_AMNT" HeaderText="Nilai Pertanggungan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CI_MASA" HeaderText="Masa Pertanggungan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CI_CLASS" HeaderText="Klass">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CI_PREMI" HeaderText="Premi">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn>
										<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="Linkbutton1" runat="server" CommandName="delete">Delete</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</asp:DataGrid>
						</td>
					</tr>
					<tr>
						<td valign="top">
							<table cellpadding="2" cellspacing="1" align="center">
								<tr>
									<td valign="top" width="50%" class="td">
										<table cellpadding="0" cellspacing="0">
											<tr>
												<td class="TDBGColor1" width="150">Jenis Asuransi</td>
												<td width="15"></td>
												<td class="TDBGColorValue"><asp:DropDownList Runat="server" ID="DDL_CI_TYPE"></asp:DropDownList></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Perusahaan</td>
												<td></td>
												<td class="TDBGColorValue"><asp:DropDownList Runat="server" ID="DDL_CI_COMP"></asp:DropDownList></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Nilai Pertanggungan</td>
												<td></td>
												<td class="TDBGColorValue"><asp:TextBox ID="TXT_CI_AMNT" Runat="server" Columns="25" MaxLength="21" CssClass="angka"
														onKeypress="return numbersonly()"></asp:TextBox></td>
											</tr>
										</table>
									</td>
									<td valign="top" class="td">
										<table cellpadding="0" cellspacing="0">
											<tr>
												<td class="TDBGColor1" width="150">Masa Pertanggungan</td>
												<td width="15"></td>
												<td class="TDBGColorValue"><asp:TextBox ID="TXT_CI_MASA" Runat="server" Columns="4" MaxLength="4" CssClass="angka" onKeypress="return numbersonly()"></asp:TextBox>Tahun</td>
											</tr>
											<tr>
												<td class="TDBGColor1">Klass</td>
												<td></td>
												<td class="TDBGColorValue"><asp:TextBox ID="TXT_CI_CLASS" Runat="server" Columns="2" MaxLength="2" CssClass="angka"
														onKeypress="return numbersonly()"></asp:TextBox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Premi</td>
												<td></td>
												<td class="TDBGColorValue"><asp:TextBox ID="TXT_CI_PREMI" Runat="server" Columns="25" CssClass="angka" ReadOnly></asp:TextBox></td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td colspan="2" align="center">
									<asp:Button ID="BTN_INSERT" Text="Masukkan" Runat="server" onclick="BTN_INSERT_Click"></asp:Button>
									<asp:Label ID="LBL_REGNO" Runat="server" Visible="False"></asp:Label>
									<asp:Label ID="LBL_CUREF" Runat="server" Visible="False"></asp:Label>
									<asp:Label ID="LBL_TC" Runat="server" Visible="False"></asp:Label>
									<asp:Label ID="LBL_CL_SEQ" Runat="server" Visible="False"></asp:Label>
									<asp:Label ID="LBL_CL_TYPE" Runat="server" Visible="False"></asp:Label>
									</td>
								</tr>
							</table>
						</td>
					</tr>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
