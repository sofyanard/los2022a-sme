<%@ Page language="c#" Codebehind="DetailBiayaKredit.aspx.cs" AutoEventWireup="True" Inherits="SME.CreditOperations.Booking.DetailBiayaKredit" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DetailBiayaKredit</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE cellSpacing="0" cellPadding="0" width="100%">
					<tr>
						<td class="tdHeader1"><B>Biaya-biaya</B></td>
					</tr>
					<tr>
						<td>
							<TABLE cellSpacing="2" cellPadding="2" width="100%">
								<tr>
									<td class="td" vAlign="top" width="50%">
										<TABLE cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<td class="TDBGColor1" width="150">Biaya Administrasi</td>
												<td width="15"></td>
												<td class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CP_BEAADM" Columns="25" Runat="server"
														CssClass="angkamandatory" MaxLength="21" ReadOnly="True"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Biaya Provisi</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CP_BEAPROVISI" Columns="25" Runat="server"
														CssClass="angkamandatory" MaxLength="21" ReadOnly="True"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Biaya Notaris</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CP_BEANOTARIS" Columns="25" Runat="server"
														CssClass="angkamandatory" MaxLength="21" ReadOnly="True"></asp:textbox></td>
											</tr>
										</TABLE>
									</td>
									<td class="td" vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<td class="TDBGColor1" width="150">Biaya Pengikatan</td>
												<td width="15"></td>
												<td class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CP_BEAIKAT" Columns="25" Runat="server"
														CssClass="angkamandatory" MaxLength="21" ReadOnly="True"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Biaya Meterai</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CP_BEAMATERAI" Columns="25" Runat="server"
														CssClass="angkamandatory" MaxLength="21" ReadOnly="True"></asp:textbox></td>
											</tr>
										</TABLE>
										<asp:label id="LBL_REGNO" Runat="server" Visible="False"></asp:label>
										<asp:label id="LBL_CUREF" Runat="server" Visible="False"></asp:label>
										<asp:label id="LBL_TC" Runat="server" Visible="False"></asp:label>
										<asp:label id="LBL_PRODUCTID" Runat="server" Visible="False"></asp:label>
										<asp:label id="LBL_APPTYPE" Runat="server" Visible="False"></asp:label>
									</td>
								</tr>
							</TABLE>
						</td>
					</tr>
					<tr>
						<td class="tdHeader1"><B>Asuransi Kredit</B></td>
					</tr>
					<tr>
						<td><asp:datagrid id="DataGrid1" runat="server" CellPadding="1" Width="100%" AutoGenerateColumns="False"
								PageSize="3" AllowPaging="True">
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
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
