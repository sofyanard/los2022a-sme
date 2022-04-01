<%@ Page language="c#" Codebehind="InfoPerusahaanCEA.aspx.cs" AutoEventWireup="True" Inherits="SME.CEA.DataEntry.InfoPerusahaanCEA" %>
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
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Initial Data Entry - Data 
											Kepemilikan Perusahaan</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg"></asp:imagebutton><A href="../Body.aspx"><IMG src="../../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:hyperlink id="HL_ACCOUNT" runat="server" Visible="False" NavigateUrl="CustomerInfo.aspx">Informasi Rekanan</asp:hyperlink><asp:hyperlink id="Hyperlink1" runat="server" Visible="False" NavigateUrl="DTBO\ListDTBO.aspx">Dokumen Legal & Perijinan</asp:hyperlink><asp:hyperlink id="Hyperlink2" runat="server" Visible="False" NavigateUrl="InfoPerusahaan.aspx">Data Kepemilikan Perusahaan</asp:hyperlink><asp:hyperlink id="Hyperlink4" runat="server" Visible="False" NavigateUrl="TenagaAhli.aspx">Tenaga Ahli</asp:hyperlink><asp:hyperlink id="HL_COLLATERAL" runat="server" Visible="False" NavigateUrl="KantorCabang.aspx">Kantor Cabang/Perwakilan</asp:hyperlink><asp:hyperlink id="HL_HISTORY" runat="server" Visible="False" NavigateUrl="CustHistory.aspx"> Notaris</asp:hyperlink></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">Data Kepemilikan Perusahaan</TD>
					</TR>
				</TABLE>
				<asp:Label id="LBL_CUREF" style="Z-INDEX: 101; LEFT: 248px; POSITION: absolute; TOP: 120px"
					runat="server" Width="88px" Height="8px"></asp:Label>
				<asp:label id="lbl_CU_CUSTTYPEID" runat="server" Visible="False"></asp:label><TR>
					<TD class="tdNoBorder" style="HEIGHT: 41px" colSpan="2" align="center"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
				</TR>
				<TR>
					<TD class="tdHeader1" colSpan="2" width="45%" vAlign="top">Data Kepemilikan dan 
						Pengurus&nbsp;Perusahaan</TD>
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
								<asp:BoundColumn DataField="NAME" HeaderText="Name">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CS_DOB" HeaderText="Tgl Lahir/Pendirian/Kadaluwarsa KITAS">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CS_IDCARDNUM" HeaderText="No. KTP/AKTA">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="CS_NPWP" HeaderText="NPWP">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="JOBTITLEDESC" HeaderText="Jabatan">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CS_STOCKPERC" HeaderText="Saham (%)">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="EDUCATIONDESC" HeaderText="Pendidikan">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="AGE" HeaderText="Umur">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="EXPDESC" HeaderText="Pengalaman">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CS_KEYPERSON1" HeaderText="Key Person">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="STATUS_DESC" HeaderText="Status">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CS_AKTIF" HeaderText="Aktif">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CS_REMARK" HeaderText="Remark">
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
								<TD style="HEIGHT: 43px" vAlign="top" width="50%" colSpan="2"><asp:radiobuttonlist id="RDO_RFCUSTOMERTYPE" onclick="setMandatory2()" runat="server" AutoPostBack="True"
										RepeatDirection="Horizontal"></asp:radiobuttonlist></TD>
							</TR>
							<TR>
								<TD class="td" vAlign="top" width="50%">
									<TABLE id="Table10" cellSpacing="0" cellPadding="0" width="100%">
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 276px" width="276">Nama</TD>
											<TD style="WIDTH: 17px"></TD>
											<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CS_FIRSTNAME" runat="server" Width="300px"
													MaxLength="50"></asp:textbox><BR>
												<asp:textbox onkeypress="return kutip_satu()" id="TXT_CS_MIDDLENAME" runat="server" Width="300px"
													MaxLength="50"></asp:textbox><BR>
												<asp:textbox onkeypress="return kutip_satu()" id="TXT_CS_LASTNAME" runat="server" Width="300px"
													MaxLength="50"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 276px">Nomor KTP/Nomor Akta Pendirian/KITAS</TD>
											<TD></TD>
											<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CS_IDCARDNUM" runat="server" Width="300px"
													MaxLength="50"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 276px">Alamat KTP/ AlamatPerusahaan</TD>
											<TD></TD>
											<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CS_ADDR1" runat="server" Width="300px"
													MaxLength="50"></asp:textbox><BR>
												<asp:textbox onkeypress="return kutip_satu()" id="TXT_CS_ADDR2" runat="server" Width="300px"
													MaxLength="50"></asp:textbox><BR>
												<asp:textbox onkeypress="return kutip_satu()" id="TXT_CS_ADDR3" runat="server" Width="300px"
													MaxLength="50"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 276px">Kota</TD>
											<TD></TD>
											<TD class="TDBGColorValue" align="left"><asp:textbox id="TXT_CS_CITY" runat="server" Width="175px" ReadOnly="True"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 276px">Kode Pos</TD>
											<TD></TD>
											<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CS_ZIPCODE" runat="server" AutoPostBack="True"
													MaxLength="6" Columns="6"></asp:textbox><asp:button id="BTN_SEARCHCOMP" runat="server" Text="Search"></asp:button></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 276px">Remark</TD>
											<TD></TD>
											<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CS_REMARK" runat="server" Width="300px"
													MaxLength="200" TextMode="MultiLine"></asp:textbox></TD>
										</TR>
									</TABLE>
									<asp:label id="SEQ" runat="server" Visible="False"></asp:label></TD>
								<TD class="td" vAlign="top" align="center">
									<TABLE id="Table11" cellSpacing="0" cellPadding="0" width="100%">
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 262px; HEIGHT: 23px" width="262">Tgl Lahir/<BR>
												Tgl&nbsp;Pendirian/Tgl Kadaluwarsa KITAS</TD>
											<TD style="WIDTH: 20px; HEIGHT: 23px"></TD>
											<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left"><asp:textbox onkeypress="return numbersonly()" id="TXT_CS_DOB_DAY" runat="server" Width="24px"
													MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_CS_DOB_MONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CS_DOB_YEAR" runat="server" Width="36px"
													MaxLength="4" Columns="4"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 262px" width="262">NPWP</TD>
											<TD style="WIDTH: 20px"></TD>
											<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CS_NPWP" runat="server" Width="300px" MaxLength="50"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 262px; HEIGHT: 21px">Job Title</TD>
											<TD style="WIDTH: 20px; HEIGHT: 21px"></TD>
											<TD class="TDBGColorValue" align="left"><asp:dropdownlist id="DDL_CS_JOBTITLE" runat="server"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 262px">Jumlah Saham
											</TD>
											<TD style="WIDTH: 20px"></TD>
											<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return digitsonly()" id="TXT_CS_STOCKPERC" runat="server" Width="48px"
													MaxLength="5" CssClass=""></asp:textbox>&nbsp;%
												<asp:label id="LBL_TOTPERC" runat="server" Visible="False">100</asp:label></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 262px; HEIGHT: 20px">Status</TD>
											<TD style="WIDTH: 20px; HEIGHT: 20px"></TD>
											<TD class="TDBGColorValue" style="HEIGHT: 20px" align="left"><asp:radiobutton id="RDO_CS_NATSTAT0" runat="server" Text="WNI" Checked="True" GroupName="RDG_CS_NATSTAT"></asp:radiobutton>&nbsp;&nbsp;&nbsp;
												<asp:radiobutton id="RDO_CS_NATSTAT1" runat="server" Text="WNA" GroupName="RDG_CS_NATSTAT"></asp:radiobutton>
												<asp:Label id="TXT_STATUS" runat="server" Height="8px" Width="88px" DESIGNTIMEDRAGDROP="800"></asp:Label></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 262px">Jenis Kelamin</TD>
											<TD style="WIDTH: 20px"></TD>
											<TD class="TDBGColorValue" align="left"><asp:dropdownlist id="DDL_CS_SEX" runat="server"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 262px; HEIGHT: 39px">Key Person</TD>
											<TD style="WIDTH: 20px; HEIGHT: 39px"></TD>
											<TD class="TDBGColorValue" style="HEIGHT: 39px" align="left"><asp:radiobuttonlist id="RDO_KEY_PERSON" runat="server" Width="150px" AutoPostBack="True" RepeatDirection="Horizontal">
													<asp:ListItem Value="1">Ya</asp:ListItem>
													<asp:ListItem Value="0" Selected="True">Tidak</asp:ListItem>
												</asp:radiobuttonlist></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 262px; HEIGHT: 30px">Pengurus Aktif</TD>
											<TD style="WIDTH: 20px; HEIGHT: 30px"></TD>
											<TD class="TDBGColorValue" style="HEIGHT: 30px" align="left"><asp:radiobuttonlist id="RDO_AKTIF" runat="server" Width="150px" AutoPostBack="True" RepeatDirection="Horizontal">
													<asp:ListItem Value="1">Ya</asp:ListItem>
													<asp:ListItem Value="0" Selected="True">Tidak</asp:ListItem>
												</asp:radiobuttonlist></TD>
										</TR>
									</TABLE>
									<BR>
								</TD>
							</TR>
							<TR>
								<TD vAlign="top" align="center" width="50%" colSpan="2"><asp:button id="BTN_STOCKHOLDER" runat="server" Text="Add Pengurus/StockHolder/Pemegang Saham"
										CssClass="button1"></asp:button><asp:button id="BTN_UPDATE_NEW" runat="server" Visible="False" Text="Update" CssClass="button1"></asp:button><asp:button id="BTN_CANCEL" runat="server" Visible="False" Text="Cancel" CssClass="button1"></asp:button></TD>
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
