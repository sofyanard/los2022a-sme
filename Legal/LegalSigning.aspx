<%@ Page language="c#" Codebehind="LegalSigning.aspx.cs" AutoEventWireup="True" Inherits="SME.Legal.LegalSigning2" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>LegalSigning</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include  file="../include/cek_entries.html" -->
		<!-- #include  file="../include/onepost.html" -->
		<!-- #include  file="../include/ConfirmBox.html" -->
		<!-- #include  file="../include/cek_mandatoryOnly.html" -->
		<!-- #include  file="../include/popup.html" -->
        <%= popUp%>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<table cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
							<TABLE id="Table6">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Legal Signing Condition</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<TR>
						<td class="tdHeader1" colSpan="2">Informasi Pemohon</td>
					</TR>
					<tr>
						<td colSpan="2">
							<TABLE cellSpacing="2" cellPadding="2" width="100%">
								<tr>
									<td class="td" vAlign="top" width="50%">
										<TABLE cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<td class="TDBGColor1" width="150">Nomor Aplikasi</td>
												<td width="15"></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_AP_REGNO" Columns="35" ReadOnly Runat="server" Width="300px" BorderStyle="None"></asp:textbox><asp:label id="LBL_REGNO" Runat="server" Visible="False"></asp:label><asp:label id="LBL_TC" Runat="server" Visible="False"></asp:label></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Nomor Referensi</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_CU_REF" Columns="35" ReadOnly Runat="server" Width="300px" BorderStyle="None"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Tanggal Aplikasi</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_AP_SIGNDATEDAY" Columns="2" ReadOnly Runat="server"></asp:textbox><asp:dropdownlist id="DDL_AP_SIGNDATEMONTH" ReadOnly Runat="server" Enabled="False"></asp:dropdownlist><asp:textbox id="TXT_AP_SIGNDATEYEAR" Columns="4" ReadOnly Runat="server"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Unit</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_BRANCH_NAME" Columns="35" ReadOnly Runat="server" Width="300px" BorderStyle="None"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Supervisi</td>
												<td style="HEIGHT: 22px"></td>
												<td class="TDBGColorValue" style="HEIGHT: 22px"><asp:textbox id="TXT_AP_TMLDRNM" Columns="35" ReadOnly Runat="server" Width="300px" BorderStyle="None"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Analis</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_ANALIS" Columns="35" ReadOnly Runat="server" Width="300px" BorderStyle="None"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Petugas</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_AP_RMNM" Columns="35" ReadOnly Runat="server" Width="300px" BorderStyle="None"></asp:textbox></td>
											</tr>
										</TABLE>
									</td>
									<td class="td" vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<td class="TDBGColor1" width="150">Nama Pemohon</td>
												<td width="15"></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_CU_NAME" Columns="35" ReadOnly Runat="server" Width="300px"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Alamat</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_CU_ADDR1" Columns="35" ReadOnly Runat="server" Width="300px"></asp:textbox><br>
													<asp:textbox id="TXT_CU_ADDR2" Columns="35" ReadOnly Runat="server" Width="300px"></asp:textbox><br>
													<asp:textbox id="TXT_CU_ADDR3" Columns="35" ReadOnly Runat="server" Width="300px"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Kota</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_CU_CITYNM" Columns="35" ReadOnly Runat="server" Width="300px" BorderStyle="None"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">No. Telp</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_CU_PHN" Columns="35" ReadOnly Runat="server" Width="300px" BorderStyle="None"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Bidang Usaha</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_BUSSTYPEDESC" Columns="35" ReadOnly Runat="server" Width="300px" BorderStyle="None"></asp:textbox></td>
											</tr>
										</TABLE>
									</td>
								</tr>
							</TABLE>
						</td>
					</tr>
					<tr>
						<td class="tdHeader1" colSpan="2">Syarat Penandatanganan Kredit</td>
					</tr>
					<tr id="TR_LEGALSIGNING2" runat="server">
						<td style="HEIGHT: 63px" vAlign="top" colSpan="2">
							<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="150">Syarat</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_PROSES" ReadOnly Runat="server" Width="750px" CssClass="mandatory"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tanggal Dipenuhi</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL" Columns="2" Runat="server" CssClass="mandatory"
											MaxLength="2"></asp:textbox><asp:dropdownlist id="DDL_BLN" ReadOnly Runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN" Columns="4" Runat="server" CssClass="mandatory"
											MaxLength="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Keterangan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_KET" Columns="35" Runat="server" Width="512px"
											TextMode="MultiLine" Height="60px"></asp:textbox>&nbsp;</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tanggal Pemenuhan Berikutnya</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_COV_NEXTDATE_DAY2" Columns="2" Runat="server"
											MaxLength="2"></asp:textbox><asp:dropdownlist id="DDL_COV_NEXTDATE_MONTH2" ReadOnly Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_COV_NEXTDATE_YEAR2" Columns="4" Runat="server"
											MaxLength="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Status</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:checkbox id="CHK_COV_ISFINISH2" runat="server"></asp:checkbox>
                                        &nbsp;Cek jika Terpenuhi
									</TD>
								</TR>
							</TABLE>
							<asp:textbox id="TXT_AU_TEXT" runat="server" Visible="False">Return from Legal to BU</asp:textbox></td>
					</tr>
					<tr id="TR_LEGALSIGNING" runat="server">
						<td class="TDBGColor2" colSpan="2"><asp:button id="BTN_DF_INPUT" Runat="server" 
                                Width="101px" CssClass="button1" Text="Simpan" onclick="BTN_DF_INPUT_Click"></asp:button>&nbsp;
							<asp:button id="BTN_PRINT" Runat="server" Width="101px" Enabled="False" 
                                CssClass="button1" Text="Cetak" onclick="BTN_PRINT_Click"></asp:button>&nbsp;
							<asp:button id="BTN_UPDATE" Runat="server" Enabled="False" CssClass="button1" Text="Update Status" onclick="BTN_UPDATE_Click"></asp:button>&nbsp;
							<asp:button id="BTN_RETURNTOBU" Runat="server" CssClass="button1" 
                                Text="Kembali ke Konfirmasi" onclick="BTN_RETURNTOBU_Click"></asp:button><asp:textbox id="TXT_TEMP" runat="server" Width="1px" BorderStyle="None" ontextchanged="TXT_TEMP_TextChanged"></asp:textbox></td>
					</tr>
					<TR>
						<TD class="td" colSpan="2"><asp:datagrid id="DGR_LIST" runat="server" Width="100%" CellPadding="1" AutoGenerateColumns="False"
								PageSize="1">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="seq" HeaderText="seq"></asp:BoundColumn>
									<asp:BoundColumn DataField="des" HeaderText="Syarat">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="sy_accdate" HeaderText="Tanggal Dipenuhi">
										<HeaderStyle HorizontalAlign="Center" CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="sy_ket" HeaderText="Keterangan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Dokumen">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
										<ItemTemplate>
											<asp:datagrid id="DG_PKDOC" runat="server" AutoGenerateColumns="False" CellPadding="1" Width="100%"
												AllowPaging="True" PageSize="5" ShowHeader="False">
												<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
												<Columns>
													<asp:BoundColumn Visible="False" DataField="COVSEQ"></asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="FILESEQ"></asp:BoundColumn>
													<asp:BoundColumn HeaderText="No.">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center" Width="35px"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="COVFILENAME" HeaderText="File Name">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Left"></ItemStyle>
													</asp:BoundColumn>
													<asp:TemplateColumn>
														<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
														<ItemTemplate>
															<asp:HyperLink id="HL_DOWNLOAD1" runat="server" Target="_blank">Download</asp:HyperLink>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:TemplateColumn>
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
														<ItemTemplate>
															<asp:LinkButton id="LB_DELETE1" runat="server" CommandName="delete">Delete</asp:LinkButton>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:BoundColumn Visible="False" DataField="USERID" HeaderText="User ID"></asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="COVURL" HeaderText="User ID"></asp:BoundColumn>
												</Columns>
												<PagerStyle Mode="NumericPages"></PagerStyle>
											</asp:datagrid>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:ButtonColumn Text="Upload File" HeaderText="Fungsi" CommandName="Upload">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:ButtonColumn>
									<asp:TemplateColumn HeaderText="Tanggal Pemenuhan Berikutnya">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
										<ItemTemplate>
											<asp:textbox onkeypress="return numbersonly()" id="TXT_COV_NEXTDATE_DAY" Columns="2" runat="server"
												MaxLength="2"></asp:textbox>
											<asp:dropdownlist id="DDL_COV_NEXTDATE_MONTH" runat="server"></asp:dropdownlist>
											<asp:textbox onkeypress="return numbersonly()" id="TXT_COV_NEXTDATE_YEAR" Columns="4" runat="server"
												MaxLength="4"></asp:textbox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Status">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
										<ItemTemplate>
											<asp:checkbox id="CHK_COV_ISFINISH" runat="server" Text="Finish"></asp:checkbox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn>
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="Linkbutton1" runat="server" CommandName="delete">hapus</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn Visible="False" DataField="COV_NEXTDATE"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="COV_ISFINISH"></asp:BoundColumn>
								</Columns>
							</asp:datagrid><asp:textbox id="TXT_TEMP_PK" runat="server" ReadOnly="True" Width="1px" BorderStyle="None" ontextchanged="TXT_TEMP_PK_TextChanged"></asp:textbox></TD>
					</TR>
					<tr id="TR_REVIEWCOVENANT" runat="server">
						<td class="TDBGColor2" colSpan="2"><asp:button id="BTN_SAVEREV" Width="100px" 
                                Runat="server" CssClass="button1" Text="Simpan" onclick="BTN_SAVEREV_Click"></asp:button></td>
					</tr>
					<TR>
						<TD align="center" colSpan="2"></TD>
					</TR>
				</table>
				<table id="TBL_FILEUPLOAD" cellSpacing="0" cellPadding="0" width="100%" runat="server">
					<tr>
						<td align="center">
							<iframe id="if2" width="100%" height="510" name="if2" src="..\CreditOperations\COUploadFile.aspx?regno=<%=Request.QueryString["regno"]%>">
							</iframe>
						</td>
					</tr>
				</table>
			</center>
		</form>
	</body>
</HTML>
