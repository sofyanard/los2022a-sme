<%@ Page language="c#" Codebehind="InfoPerusahaanCEA.aspx.cs" AutoEventWireup="false" Inherits="SME.CEA.DataEntry.InfoPerusahaanCEA" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>InfoPerusahaanCEA</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_mandatoryOnly.html" -->
		<!-- #include file="../include/cek_mandatoryColl.html" -->
		<!-- #include file="../include/cek_entries.html" -->
		<script language="javascript">
		function setMandatory() {
			nilai_1 = document.Form1.RDO_KEY_PERSON[0].checked;	// key person : YES
			nilai_2 = document.Form1.RDO_KEY_PERSON[1].checked;	// key person : NO

			if (nilai_1) {
				document.Form1.DDL_CS_EDUCATION.className = "mandatoryColl";
				document.Form1.TXT_CS_CHILDREN.className  = "mandatoryColl";
				document.Form1.TXT_CS_MULAIMENETAPMM.className  = "mandatoryColl";
				document.Form1.TXT_CS_MULAIMENETAPYY.className  = "mandatoryColl";
				document.Form1.DDL_CS_HOMESTA.className  = "mandatoryColl";
				document.Form1.DDL_CS_MARITAL.className  = "mandatoryColl";
			}			
			else {
				document.Form1.DDL_CS_EDUCATION.className = "";
				document.Form1.TXT_CS_CHILDREN.className  = "";
				document.Form1.TXT_CS_MULAIMENETAPMM.className  = "";
				document.Form1.TXT_CS_MULAIMENETAPYY.className  = "";
				document.Form1.DDL_CS_HOMESTA.className  = "";
				document.Form1.DDL_CS_MARITAL.className  = "";
			}
		}

		function setMandatory2() {
			nilai_1 = document.Form1.RDO_RFCUSTOMERTYPE[1].checked;		// Perorangan
			if (nilai_1) {
				document.Form1.DDL_CS_SEX.className = "mandatoryColl";
				document.Form1.DDL_CS_MARITAL.className = "mandatoryColl";
			}
			else {
				document.Form1.DDL_CS_SEX.className = "";
				document.Form1.DDL_CS_MARITAL.className = "";
			}
		}
		
		function checkChannFac() {
			// If user decide this facility as a Channeling-Facility, 
			// then follow this policy :
			// - Nomor rekening must be empty
			// - Bank Percentage must be empty
			// - Remaining eMAS limit must be empty
			// - Maturity Date is mandatory
			
			if (Form1.CHK_ISCHANNFACILITY.checked) 
			{
				Form1.TXT_AI_NOREK.value = "";				
				Form1.TXT_AI_NOREK.disabled = true;
			}
			else 
			{
				Form1.TXT_AI_NOREK.disabled = false;
			}
		}
		</script>
	</HEAD>
	<body leftMargin="0" topMargin="0" onload="setMandatory2()" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<CENTER>
				<TABLE cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder">
							<TABLE id="Table8">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Data Perusahaan</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg"></asp:imagebutton><A href="../Body.aspx"><IMG src="../../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:hyperlink id="HL_ACCOUNT" runat="server" Visible="False" NavigateUrl="CustomerInfo.aspx">Info Rekanan</asp:hyperlink><asp:hyperlink id="Hyperlink1" runat="server" Visible="False" NavigateUrl="DTBO\ListDTBO.aspx"> Perijinan</asp:hyperlink><asp:hyperlink id="Hyperlink2" runat="server" Visible="False" NavigateUrl="InfoPerusahaan.aspx">Data Perusahaan</asp:hyperlink><asp:hyperlink id="HL_COLLATERAL" runat="server" Visible="False" NavigateUrl="KantorCabang.aspx">Struktur Organisasi</asp:hyperlink><asp:hyperlink id="HL_HISTORY" runat="server" Visible="False" NavigateUrl="CustHistory.aspx"> Notaris</asp:hyperlink></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">Data Kepemilikan/Pengurus Perusahaan</TD>
					</TR>
				</TABLE>
				<TR>
					<TD class="tdNoBorder" style="HEIGHT: 41px" colSpan="2" align="center"></TD>
				</TR>
				<TR>
					<TD class="td" colSpan="2" width="45%" vAlign="top"><ASP:DATAGRID id="DatGridPengurus" runat="server" DESIGNTIMEDRAGDROP="33" CellPadding="1" PageSize="1"
							AutoGenerateColumns="False" Width="100%">
							<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="no_registrasi" HeaderText="noreg"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="SEQ" HeaderText="Seq">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NAME" HeaderText="Nama">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CS_IDCARDNUM" HeaderText="No. KTP">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="CS_NPWP" HeaderText="Tgl. Lahir">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="JOBTITLEDESC" HeaderText="Porsentase Sham">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CS_STOCKPERC" HeaderText="Nilai Saham">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CS_KEYPERSON1" HeaderText="Key Person">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Function">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:LinkButton id="LNK_EDIT" runat="server" CommandName="edit">Edit</asp:LinkButton>&nbsp;
										<asp:LinkButton id="LinkButton1" runat="server" CommandName="delete">Delete</asp:LinkButton>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
						</ASP:DATAGRID><BR>
						<TABLE id="Table9" cellSpacing="2" cellPadding="2" width="100%" border="0">
							<TR>
								<TD style="HEIGHT: 43px" vAlign="top" width="50%" colSpan="2"></TD>
							</TR>
							<TR>
								<TD class="td" vAlign="top" width="50%">
									<TABLE id="Table10" cellSpacing="0" cellPadding="0" width="100%">
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 276px">Nama</TD>
											<TD></TD>
											<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return kutip_satu()" id="nama_company" runat="server" Width="300px"
													MaxLength="50"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 262px; HEIGHT: 23px" width="262">Tgl 
												Lahir/Berdiri Perusahaan</TD>
											<TD style="WIDTH: 20px; HEIGHT: 23px"></TD>
											<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left"><asp:textbox onkeypress="return numbersonly()" id="tglhr_berdiri_company" runat="server" Width="24px"
													MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="tglbln_berdiri_company" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="tglth_berdiri_perusahaan" runat="server" Width="36px"
													MaxLength="4" Columns="4"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 276px">No. KTP</TD>
											<TD></TD>
											<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return kutip_satu()" id="KTP_perusahaan" runat="server" Width="300px"
													MaxLength="50"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 262px; HEIGHT: 23px" width="262">Tgl. Berakhir 
												KTP</TD>
											<TD style="WIDTH: 20px; HEIGHT: 23px"></TD>
											<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left"><asp:textbox onkeypress="return numbersonly()" id="tglakhirday_KTP_perusahaan" runat="server"
													Width="24px" MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="tglakhirbln_KTP_perusahaan" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="tglakhirth_KTP_perusahaan" runat="server"
													Width="36px" MaxLength="4" Columns="4"></asp:textbox></TD>
										</TR>
									</TABLE>
								</TD>
								<TD class="td" vAlign="top" align="center">
									<TABLE id="Table11" cellSpacing="0" cellPadding="0" width="100%">
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 262px">
												Prosentase&nbsp;Saham
											</TD>
											<TD style="WIDTH: 20px"></TD>
											<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return digitsonly()" id="persen_perusahaan" runat="server" Width="48px"
													MaxLength="5" CssClass=""></asp:textbox>&nbsp;%</TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 262px" width="262">Nilai Saham</TD>
											<TD style="WIDTH: 20px"></TD>
											<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return kutip_satu()" id="nilaisaham_company" runat="server" Width="300px"
													MaxLength="50"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 262px; HEIGHT: 39px">Key Person</TD>
											<TD style="WIDTH: 20px; HEIGHT: 39px"></TD>
											<TD class="TDBGColorValue" style="HEIGHT: 39px" align="left"><asp:radiobuttonlist id="RDO_KEY_PERSON_perusahaan" runat="server" Width="150px" AutoPostBack="True"
													RepeatDirection="Horizontal">
													<asp:ListItem Value="1">Ya</asp:ListItem>
													<asp:ListItem Value="0" Selected="True">Tidak</asp:ListItem>
												</asp:radiobuttonlist></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 262px" width="262">NPWP</TD>
											<TD style="WIDTH: 20px"></TD>
											<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CS_NPWP_perusahaan" runat="server" Width="300px"
													MaxLength="50"></asp:textbox></TD>
										</TR>
									</TABLE>
									<BR>
								</TD>
							</TR>
							<TR>
								<TD vAlign="top" align="center" width="50%" colSpan="2"><asp:button id="add_dataperusahaan" runat="server" Text="Add Pemilik/Pengurus/Pemegang Saham"
										CssClass="button1"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<%if (Request.QueryString["bi"] == "" || Request.QueryString["bi"] == null) {%>
				<!--
					<TR>
						<TD class="tdHeader1" align="center" colSpan="2">Hubungan Dengan Bank Lain</TD>
					</TR>
					<TR>
						<TD class="td" align="center" colSpan="3">
							<TABLE id="Table_OB1" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD class="TDBGColorValue" align="center"><ASP:DATAGRID id="DGR_OB" runat="server" Width="100%" AutoGenerateColumns="False" PageSize="1"
											CellPadding="1">
											<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
											<Columns>
												<asp:BoundColumn Visible="False" DataField="CU_REF" HeaderText="CUST REF">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="CO_SEQ" HeaderText="SEQ">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="CO_CREDTYPE" HeaderText="Jenis Kredit">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="CO_BANKNAME" HeaderText="Nama Bank">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="CO_LIMIT" HeaderText="Limit">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="CO_BAKIDEBET" HeaderText="Baki Debet">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="CO_TGKPOKOK" HeaderText="Tgk. Pokok">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="CO_TGKBUNGA" HeaderText="Tgk. Bunga">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="CO_DUEDATE" HeaderText="J.W/Tgl. Jth. Tempo">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="COLLECTDESC" HeaderText="Kolektibilitas">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:TemplateColumn>
													<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
													<ItemTemplate>
														<asp:LinkButton id="Linkbutton2" runat="server" CommandName="delete">Delete</asp:LinkButton>
													</ItemTemplate>
												</asp:TemplateColumn>
											</Columns>
										</ASP:DATAGRID></TD>
								</TR>
								<tr>
									<td>&nbsp;</td>
								</tr>
							</TABLE>
							<TABLE id="Table_OB2" cellSpacing="2" cellPadding="2" align="center" border="0">
								<tr>
									<td class="td" vAlign="top" width="50%">
										<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD class="TDBGColor1" width="100">Jenis Kredit</TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CO_CREDTYPE" runat="server" MaxLength="30"
														Columns="30"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Nama Bank</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CO_BANKNAME" runat="server" MaxLength="30"
														Columns="30"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Limit</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CO_LIMIT" runat="server" MaxLength="21"
														Columns="25" CssClass="angka"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Baki Debet</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CO_BAKIDEBET" runat="server" MaxLength="21"
														Columns="25" CssClass="angka"></asp:textbox></TD>
											</TR>
										</TABLE>
									</td>
									<td class="td" vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD class="TDBGColor1">Tgk. Pokok</TD>
												<TD width="15"></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CO_TGKPOKOK" runat="server" MaxLength="21"
														Columns="25" CssClass="angka"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Tgk. Bunga</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CO_TGKBUNGA" runat="server" MaxLength="21"
														Columns="25" CssClass="angka"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">J.W/Tgl. Jth. Tempo</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CO_DUEDATEDAY" runat="server" MaxLength="2"
														Columns="2"></asp:textbox><asp:dropdownlist id="DDL_CO_DUEDATEMONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CO_DUEDATEYEAR" runat="server" MaxLength="4"
														Columns="4"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Kolektibilitas</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CO_COLLECTABILITY" runat="server"></asp:dropdownlist></TD>
											</TR>
										</TABLE>
									</td>
								</tr>
								<TR>
									<TD align="center" colSpan="2"><asp:button id="BTN_OBINSERT" runat="server" Text="Insert"></asp:button></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					-->
				<% } %>
				</TABLE></CENTER>
		</form>
	</body>
</HTML>
