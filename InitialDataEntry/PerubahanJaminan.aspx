<%@ Page language="c#" Codebehind="PerubahanJaminan.aspx.cs" AutoEventWireup="True" Inherits="SME.InitialDataEntry.PerubahanJaminan" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PerubahanJaminan</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_entries.html" -->
		<!-- #include file="../include/cek_mandatoryColl.html" -->
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<!--
					<TR>
						<TD class="tdNoBorder">
							<TABLE id="Table4">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Initial Data Entry: 
											Perubahan Jaminan</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><A href="../Body.aspx"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" colSpan="2" style="HEIGHT: 41px" align="center">
							<asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					-->
					<TR>
						<TD class="tdHeader1" colSpan="2">Informasi Loan</TD>
					</TR>
					<TR id="TR_JENISPENGAJUAN" runat="server">
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Jenis Pengajuan</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_APPTYPE" runat="server" CssClass="mandatory" AutoPostBack="True" onselectedindexchanged="DDL_APPTYPE_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">No. Akomodasi Rekening</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_AA_NO" runat="server" CssClass="mandatory" AutoPostBack="True" onselectedindexchanged="DDL_AA_NO_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">No. Fasilitas</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_PRODUCTID" runat="server" CssClass="mandatory" AutoPostBack="True" onselectedindexchanged="DDL_PRODUCTID_SelectedIndexChanged"></asp:dropdownlist><asp:dropdownlist id="DDL_FACILITYNO" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_FACILITYNO_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jenis Kredit</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PRODUCTDESC" runat="server" BorderStyle="None" MaxLength="80" ReadOnly="True"
											Width="300"></asp:textbox></TD>
								</TR>
								<TR>
									<TD>&nbsp;</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD><asp:label id="LBL_PRODUCTID" runat="server" Visible="False"></asp:label><asp:label id="LBL_USERID" runat="server" Visible="False"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Limit</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_LIMIT" runat="server" BorderStyle="None"
											MaxLength="15" ReadOnly="True" Width="250px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jangka Waktu</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_TENORDESC" runat="server" BorderStyle="None"
											MaxLength="3" ReadOnly="True"></asp:textbox><asp:label id="LBL_SEQ" runat="server" Visible="False"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tujuan Penggunaan</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CP_LOANPURPOSE" runat="server"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Keterangan</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CP_NOTES" runat="server" MaxLength="200"
											Width="100%" TextMode="MultiLine" Height="100px"></asp:textbox></TD>
								</TR>
							</TABLE>
							<asp:label id="LBL_MAINREGNO" runat="server" Visible="False"></asp:label>
							<asp:label id="LBL_MAINPROD_SEQ" runat="server" Visible="False"></asp:label>
							<asp:label id="LBL_MAINPRODUCTID" runat="server" Visible="False"></asp:label>
						</TD>
					</TR>
					<TR id="TR_COLL" runat="server">
						<TD class="td" vAlign="top" align="center" width="50%" colSpan="2">
							<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="100%" border="0">
								<TR>
									<TD class="tdHeader1">Eksisting Agunan</TD>
								</TR>
								<TR>
									<TD align="center"><ASP:DATAGRID id="DatGrdOld" runat="server" Width="75%" AllowPaging="True" AutoGenerateColumns="False"
											PageSize="5" CellPadding="1">
											<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
											<Columns>
												<asp:BoundColumn Visible="False" DataField="CL_SEQ" HeaderText="Sequence"></asp:BoundColumn>
												<asp:BoundColumn DataField="MYDESC" HeaderText="Keterangan">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="COLTYPEID" HeaderText="Col Type"></asp:BoundColumn>
												<asp:BoundColumn DataField="COLTYPEDESC" HeaderText="Jenis Jaminan">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="CL_VALUE" HeaderText="Nilai">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Right"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="CL_PERCENT" HeaderText="% Use">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn HeaderText="Nilai Akhir">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Right"></ItemStyle>
												</asp:BoundColumn>
											</Columns>
											<PagerStyle Mode="NumericPages"></PagerStyle>
										</ASP:DATAGRID></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR id="TR_COLL2" runat="server">
						<TD class="td" vAlign="top" align="center" width="50%" colSpan="2">
							<TABLE id="Table7" cellSpacing="1" cellPadding="1" width="100%" border="0">
								<TR>
									<TD class="tdHeader1">Perubahan</TD>
								</TR>
								<TR>
									<TD align="center"><ASP:DATAGRID id="DatGrd" runat="server" Width="75%" AllowPaging="True" AutoGenerateColumns="False"
											PageSize="5" CellPadding="1">
											<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
											<Columns>
												<asp:BoundColumn Visible="False" DataField="CL_SEQ" HeaderText="Sequence"></asp:BoundColumn>
												<asp:BoundColumn DataField="CL_DESC" HeaderText="Keterangan">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="COLTYPEID" HeaderText="Col Type"></asp:BoundColumn>
												<asp:BoundColumn DataField="COLTYPEDESC" HeaderText="Jenis Jaminan">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="CL_VALUE" HeaderText="Nilai">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Right"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="LC_PERCENTAGE" HeaderText="% Use">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn HeaderText="Nilai Akhir">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Right"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="ISNEW" HeaderText="Col Type"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="CL_CURRENCY" HeaderText="Col Type"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="CL_COLCLASSIFY" HeaderText="Col Type"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="CL_FOREIGNVAL" HeaderText="Col Type"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="CL_EXCHANGERATE" HeaderText="Col Type"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="LC_ACTION" HeaderText="Col Type"></asp:BoundColumn>
												<asp:BoundColumn DataField="LC_ACTIONDESC" HeaderText="Action">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:TemplateColumn>
													<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
													<ItemTemplate>
														<asp:LinkButton id="LinkButton1" runat="server" CommandName="delete">Delete</asp:LinkButton>
													</ItemTemplate>
												</asp:TemplateColumn>
											</Columns>
											<PagerStyle Mode="NumericPages"></PagerStyle>
										</ASP:DATAGRID></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR id="TR_COLLENTRY" runat="server">
						<TD class="td" vAlign="top" align="center" width="50%">
							<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD width="129" colSpan="3"><asp:radiobuttonlist id="RDO_COLLATERAL" runat="server" AutoPostBack="True" Width="150px" RepeatDirection="Horizontal" onselectedindexchanged="RDO_COLLATERAL_SelectedIndexChanged">
											<asp:ListItem Value="1" Selected="True">Baru</asp:ListItem>
											<asp:ListItem Value="2">Eksisting</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jenis Agunan</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CL_TYPE" runat="server" CssClass="mandatoryColl"></asp:dropdownlist><asp:textbox onkeypress="return kutip_satu()" id="TXT_CL_COLTYPEDESC" runat="server" MaxLength="60"
											ReadOnly="True" Visible="False" CssClass="mandatoryColl"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Keterangan</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CL_DESC" runat="server" MaxLength="100"
											CssClass="mandatoryColl"></asp:textbox><asp:dropdownlist id="DDL_CL_TYPE_EXISTING" runat="server" AutoPostBack="True" Visible="False" CssClass="mandatoryColl" onselectedindexchanged="DDL_CL_TYPE_EXISTING_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 12px">Klasifikasi Jaminan</TD>
									<TD style="WIDTH: 15px; HEIGHT: 12px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 12px"><asp:dropdownlist id="DDL_CL_COLCLASSIFY" runat="server" CssClass="mandatoryColl"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Valuta</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CL_CURRENCY" runat="server" AutoPostBack="True" CssClass="mandatoryColl" onselectedindexchanged="DDL_CL_CURRENCY_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" align="center">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="129">Nilai</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CL_FOREIGNVAL" runat="server" AutoPostBack="True"
											MaxLength="15" CssClass="mandatoryColl" ontextchanged="TXT_CL_FOREIGNVAL_TextChanged"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="129">Kurs Valuta ke Rp</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CL_EXCHANGERATE" runat="server" AutoPostBack="True"
											MaxLength="6" ontextchanged="TXT_CL_EXCHANGERATE_TextChanged">1</asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="129">Nilai in Rp</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CL_VALUE" runat="server" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">% digunakan</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_LC_PERCENTAGE" runat="server" MaxLength="3"
											CssClass="mandatoryColl"></asp:textbox><asp:label id="LBL_SISAUTILIZATION" runat="server" Visible="False">100</asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tindakan</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:radiobuttonlist id="rdoAction" runat="server" Width="224px" RepeatDirection="Horizontal"></asp:radiobuttonlist></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR id="TR_BUTTONCOLL" runat="server">
						<TD vAlign="top" align="center" width="50%" colSpan="2">
                            <asp:button id="BTN_INSCOLL" runat="server" CssClass="button1" 
                                Text="Tambah Agunan" onclick="BTN_INSCOLL_Click"></asp:button></TD>
					</TR>
					<TR id="TR_BUTTONS" runat="server">
						<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2">
                            <asp:button id="BTN_SAVE" runat="server" CssClass="Button1" Width="70px" 
                                Text="Simpan" onclick="BTN_SAVE_Click"></asp:button>&nbsp;
							<asp:button id="Button2" runat="server" CssClass="Button1" Width="70px" 
                                Visible="False" Text="Lanjut"
								Enabled="False" onclick="Button2_Click"></asp:button><asp:button id="Button1" runat="server" CssClass="Button1" Visible="False" Text="Update Status"
								Enabled="False" onclick="Button1_Click"></asp:button></TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" align="center" width="50%" colSpan="2"><ASP:DATAGRID id="DATAGRID1" runat="server" Width="100%" AutoGenerateColumns="False" PageSize="1"
								CellPadding="1">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="CP_FACILITYNO" HeaderText="Fasilitas No">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="120px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="APPTYPE" HeaderText="APPTYPE">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="APPTYPEDESC" HeaderText="Jenis Pengajuan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="PRODUCTID" HeaderText="PRODUCTID">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PRODUCTDESC" HeaderText="Jenis Kredit">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CP_EXLIMITVAL" HeaderText="Limit">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CP_LIMITCHGTO" HeaderText="Limit Lama">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="TENORDESC" HeaderText="Tenor">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="TENORLAMA" HeaderText="Tenor Lama">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="PROD_SEQ" HeaderText="PROD_SEQ"></asp:BoundColumn>
									<asp:TemplateColumn>
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="LinkButton2" runat="server" CommandName="delete">Delete</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</ASP:DATAGRID></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
