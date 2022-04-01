<%@ Page language="c#" Codebehind="BPRPermohonanBaru.aspx.cs" AutoEventWireup="True" Inherits="SME.DataEntry.BPRPermohonanBaru" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>BPRPermohonanBaru</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="LEFT: 0px; POSITION: absolute; TOP: 0px" cellSpacing="2" cellPadding="2"
				width="100%">
				<tr>
					<td class="tdHeader1" align="center" width="100%" colSpan="2"><asp:label id="LBL_PRODUCT" runat="server" Font-Bold="True"></asp:label></td>
				</tr>
				<TR>
					<TD vAlign="top" width="50%">
						<FIELDSET>
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="150">Jenis Pengajuan</TD>
									<TD width="1"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_APPTYPE" runat="server" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="150">Jenis Kredit</TD>
									<TD width="1"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PRODUCT" runat="server" ReadOnly="True" AutoPostBack="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="150">Sifat Kredit</TD>
									<TD width="1"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CP_SKREDIT" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="150">Tujuan Penggunaan</TD>
									<TD width="1"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CP_LOANPURPOSE" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="150">Limit (Rp)</TD>
									<TD width="1"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CP_LIMIT" runat="server" CssClass="mandatory"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="150">Installment (Rp)</TD>
									<TD width="1"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CP_INSTALLMENT" runat="server" AutoPostBack="True" CssClass="mandatory"
											Columns="4"></asp:textbox></TD>
								</TR>
							</TABLE>
						</FIELDSET>
					</TD>
					<TD vAlign="top" width="50%">
						<FIELDSET>
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="189">Tenor</TD>
									<TD width="3"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CP_TENOR" runat="server" CssClass="mandatory"></asp:dropdownlist>&nbsp;month</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="189">Bunga&nbsp; / p.a</TD>
									<TD width="3"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CP_INTEREST" runat="server" CssClass="mandatory" Columns="4" MaxLength="2"></asp:textbox>&nbsp;%</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" vAlign="top" width="189">Keterangan</TD>
									<TD width="3"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CP_KETERANGAN" runat="server" TextMode="MultiLine" Height="48px" Width="168px"></asp:textbox></TD>
								</TR>
							</TABLE>
						</FIELDSET>
						<asp:checkbox id="CHECK_IDC" runat="server" AutoPostBack="True" Text="IDC" Font-Bold="True" oncheckedchanged="CHECK_IDC_CheckedChanged"></asp:checkbox></TD>
				</TR>
				<!-- IDC -->
				<TR id="TR_IDC" runat="server">
					<TD vAlign="top" width="50%">
						<fieldset>
							<TABLE id="Table8" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="150">Main a/c-IDC Ratio</TD>
									<TD width="1"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_IDC_RATIO" runat="server"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="150">IDC a/c-J.Waktu IDC (Loan Term)</TD>
									<TD width="1"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_IDC_JWAKTU" runat="server"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="150">IDC a/c-Tgl Kadaluarsa(IDC Expiry Date)</TD>
									<TD width="1"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_DAYIDC" runat="server" MaxLength="2" Width="32px"></asp:textbox>&nbsp;
										<asp:dropdownlist id="DDL_MONTHIDC" runat="server"></asp:dropdownlist><asp:textbox id="TXT_YEARIDC" runat="server" MaxLength="4" Width="40px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="150">IDC a/c-Bunga % (Loan interest rate)</TD>
									<TD width="1"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_IDC_INTEREST" runat="server"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="150">IDC a/c-Prime Variance</TD>
									<TD width="1"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_IDC_PVARIANCE" runat="server"></asp:textbox></TD>
								</TR>
							</TABLE>
						</fieldset>
					</TD>
					<TD vAlign="top" width="50%">
						<fieldset>
							<TABLE id="Table9" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="189">IDC a/c-Limit Penarikan(IDC Capitalise Amount)</TD>
									<TD width="3"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_IDC_CAPAMNT" runat="server"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="189">IDC a/c-% utk dikapitalisasi (IDC Ratio)</TD>
									<TD width="3"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_IDC_CAPRATIO" runat="server"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="189">IDC a/c-No.Prime Rate (Prime Rate Number)</TD>
									<TD width="3"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_IDC_PRIMERATE" runat="server"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="189">IDC a/c-Prime Variance Kode (Prime Variance 
										Code)</TD>
									<TD width="3"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_IDC_PRIMEVARCODE" runat="server"></asp:textbox></TD>
								</TR>
							</TABLE>
						</fieldset>
					</TD>
				</TR>
				<TR id="tr" runat="server">
					<TD class="TDBGColor2" align="center" colSpan="2"><asp:button id="update" runat="server" CssClass="Button1" Text="Update" onclick="update_Click"></asp:button></TD>
				</TR>
				<!--<TR>
					<TD colspan="2"><iframe src="ListCollateral.aspx?regno=<%=Request.QueryString["regno"]%>&prodid=<%=Request.QueryString["prodid"]%>" width="100%" height="200" frameborder="0"></iframe>
					</TD>
				</TR>-->
				<TR>
					<td align="center" colSpan="2">
						<table id="Table4" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<td align="center" colSpan="5">
									<table id="Table5" cellSpacing="0" cellPadding="0" width="100%">
										<TBODY>
											<tr>
												<td><ASP:DATAGRID id="DatGrd" runat="server" Height="80px" Width="100%" CellPadding="1" AutoGenerateColumns="False"
														AllowPaging="True" PageSize="3" HorizontalAlign="Center">
														<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
														<Columns>
															<asp:BoundColumn Visible="False" DataField="CL_SEQ"></asp:BoundColumn>
															<asp:BoundColumn DataField="coltypedesc" HeaderText="Collateral Type">
																<HeaderStyle Width="30%" CssClass="tdSmallHeader"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="lc_percentage" HeaderText="% of Use">
																<HeaderStyle Width="20%" CssClass="tdSmallHeader"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="cl_value" HeaderText="Start Nomial">
																<HeaderStyle Width="20%" CssClass="tdSmallHeader"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="lc_value" HeaderText="End Nominal">
																<HeaderStyle Width="20%" CssClass="tdSmallHeader"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:BoundColumn>
															<asp:ButtonColumn Text="Delete" HeaderText="Function" CommandName="Delete">
																<HeaderStyle Width="10%" CssClass="tdSmallHeader"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:ButtonColumn>
														</Columns>
														<PagerStyle Mode="NumericPages"></PagerStyle>
													</ASP:DATAGRID></td>
								</td>
							</TR>
						</table>
					</td>
				</TR>
				<TR>
					<TD align="left">
						<table id="Table6" cellSpacing="0" cellPadding="0" width="100%">
							<tr>
								<TD align="center" width="30%"><asp:dropdownlist id="DDL_CL_ID" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_CL_ID_SelectedIndexChanged"></asp:dropdownlist></TD>
								<TD align="center" width="20%"><asp:textbox id="TXT_LC_PERCENTAGE" runat="server" ReadOnly="True" AutoPostBack="True" Width="48px" ontextchanged="TXT_LC_PERCENTAGE_TextChanged"></asp:textbox></TD>
								<TD align="center" width="20%"><asp:textbox id="TXT_LC_VALUE" runat="server" ReadOnly="True"></asp:textbox></TD>
								<TD align="center" width="20%"><asp:textbox id="TXT_ENDVALUE" runat="server" ReadOnly="True"></asp:textbox></TD>
								<TD align="center" width="10%"><asp:button id="insert" runat="server" Text="insert" onclick="insert_Click"></asp:button></TD>
							</tr>
						</table>
					</TD>
				</TR>
			</TABLE>
			</TD></TR></TBODY></TABLE></form>
	</body>
</HTML>
