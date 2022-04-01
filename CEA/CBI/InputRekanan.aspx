<%@ Page language="c#" Codebehind="InputRekanan.aspx.cs" AutoEventWireup="True" Inherits="SME.CEA.CBI.InputRekanan" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>InputRekanan</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
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
			<TABLE cellSpacing="2" cellPadding="2" width="100%">
				<TR>
					<TD class="tdNoBorder">
						<TABLE id="Table8">
							<TR>
								<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Data Perusahaan</B></TD>
							</TR>
						</TABLE>
					</TD>
					<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../../Body.aspx"><IMG src="../../Image/MainMenu.jpg"></A><A href="../../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A></TD>
				</TR>
				<tr>
					<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
				</tr>
				<TR>
					<TD class="tdHeader1" colSpan="2">Data Kepemilikan/Pengurus Perusahaan/Partner</TD>
				</TR>
				<TR>
					<TD class="td" vAlign="top" width="100%" colSpan="2"><ASP:DATAGRID id="DatGridDataPerusahaan" runat="server" AllowPaging="True" CellPadding="1" PageSize="5"
							AutoGenerateColumns="False" Width="100%">
							<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="SEQ"></asp:BoundColumn>
								<asp:BoundColumn DataField="NAMA" HeaderText="Nama">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="KTP#" HeaderText="No. KTP">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="BOD_ISTABLISH" HeaderText="Tgl. Lahir">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="SHARE" HeaderText="Persentase Saham">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="SHARE_VAL" HeaderText="Nilai Saham">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="KEY_PERSON" HeaderText="Key Person">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Function">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:LinkButton id="edit_data" runat="server" CommandName="edit_data">Edit</asp:LinkButton>&nbsp;
										<asp:LinkButton id="delete_data" runat="server" CommandName="delete_data">Delete</asp:LinkButton>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</ASP:DATAGRID></TD>
				</TR>
				<TR>
					<TD class="td" vAlign="top" width="50%">
						<TABLE id="Table10" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 276px">Nama</TD>
								<TD></TD>
								<TD class="TDBGColorValue" align="left"><asp:textbox id="TXT_NAMA" runat="server" Width="300px" MaxLength="50"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 276px">Jabatan</TD>
								<TD></TD>
								<TD class="TDBGColorValue" align="left"><asp:textbox id="TXT_JABATAN" runat="server" Width="300px" MaxLength="50"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 276px">Tgl Lahir/Berdiri Perusahaan</TD>
								<TD style="WIDTH: 15px; HEIGHT: 23px"></TD>
								<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_COMP" runat="server" Width="24px"
										MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_BLN_COMP" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_COMP" runat="server" Width="36px"
										MaxLength="4" Columns="4"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 276px">No. KTP</TD>
								<TD></TD>
								<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return kutip_satu()" id="TXT_NO_KTP" runat="server" Width="300px" MaxLength="50"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 276px">Tgl. Berakhir KTP</TD>
								<TD style="WIDTH: 15px; HEIGHT: 23px"></TD>
								<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGLEXP_KTP" runat="server" Width="24px"
										MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_BLNEXP_KTP" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THNEXP_KTP" runat="server" Width="36px"
										MaxLength="4" Columns="4"></asp:textbox></TD>
							</TR>
						</TABLE>
					</TD>
					<TD class="td" vAlign="top" align="center" width="50%">
						<TABLE id="Table11" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 276px">Sertifikasi</TD>
								<TD></TD>
								<TD class="TDBGColorValue" align="left"><asp:textbox id="TXT_SERTIFIKASI" runat="server" Width="300px" MaxLength="50"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 262px">Prosentase Saham
								</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return digitsonly()" id="TXT_PERSEN_SAHAM" runat="server" Width="48px"
										MaxLength="5" AutoPostBack="True" CssClass="" ontextchanged="TXT_PERSEN_SAHAM_TextChanged"></asp:textbox>&nbsp;%</TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 262px" width="262">Nilai Saham</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return kutip_satu()" id="TXT_NILAI_SAHAM" runat="server" Width="300px"
										MaxLength="50" AutoPostBack="True" ontextchanged="TXT_NILAI_SAHAM_TextChanged"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 262px; HEIGHT: 39px">Key Person</TD>
								<TD style="WIDTH: 15px; HEIGHT: 39px"></TD>
								<TD class="TDBGColorValue" style="HEIGHT: 39px" align="left"><asp:radiobuttonlist id="RDO_KEY_PERSON_COMP" runat="server" Width="150px" RepeatDirection="Horizontal">
										<asp:ListItem Value="Y" Selected="True">Ya</asp:ListItem>
										<asp:ListItem Value="N">Tidak</asp:ListItem>
									</asp:radiobuttonlist></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 262px" width="262">NPWP</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return kutip_satu()" id="TXT_NPWP_COMP" runat="server" Width="300px"
										MaxLength="50"></asp:textbox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="50%" colSpan="2"><asp:label id="TXT_SEQ" Visible="False" Runat="server"></asp:label><asp:label id="TXT_XLSNAME" Visible="False" Runat="server"></asp:label><asp:button id="BTN_ADD" runat="server" CssClass="button1" Text="Add Pemilik/Pengurus/Pemegang Saham" onclick="BTN_ADD_Click"></asp:button><asp:button id="BTN_UPDATE" runat="server" CssClass="button1" Text="Update Pemilik/Pengurus/Pemegang Saham" onclick="BTN_UPDATE_Click"></asp:button></TD>
				</TR>
				<tr>
					<td colSpan="2"></td>
				</tr>
				<TR>
					<TD class="tdHeader1" colSpan="2">Pengalaman Perusahaan</TD>
				</TR>
				<tr>
					<TD vAlign="top" width="50%">
						<table cellSpacing="0" cellPadding="0" width="100%">
							<tr>
								<td><asp:datagrid id="DATA_TEMPLATE" runat="server" CellPadding="1" PageSize="1" AutoGenerateColumns="False"
										Width="100%">
										<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
										<Columns>
											<asp:BoundColumn DataField="ID_TEMPLATE_REKANAN" HeaderText="Id">
												<HeaderStyle HorizontalAlign="Center" Width="10%" CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="NAMA_TEMPLATE_REKANAN" HeaderText="Daftar Template">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn>
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
												<ItemTemplate>
													<asp:HyperLink id="HP_DOWNLOAD" runat="server" Target="_blank">Download</asp:HyperLink>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
									</asp:datagrid></td>
							</tr>
						</table>
					</TD>
					<td vAlign="top" width="50%">
						<table cellSpacing="0" cellPadding="0" width="100%">
							<tr>
								<TD><ASP:DATAGRID id="DATA_EXPORT" runat="server" AllowPaging="True" CellPadding="1" PageSize="5"
										AutoGenerateColumns="False" Width="100%">
										<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
										<Columns>
											<asp:BoundColumn DataField="ID_UPLOAD_EXP" HeaderText="No" Visible="False">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle Width="10px"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="FILE_UPLOAD_EXP_NAME" HeaderText="Destination File">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn>
												<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
												<ItemTemplate>
													<asp:HyperLink id="EXPERIENCE_DOWNLOAD" runat="server" Target="_blank">Download</asp:HyperLink>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
												<ItemTemplate>
													<asp:LinkButton id="EXPERIENCE_DELETE" runat="server" CommandName="delete">Delete</asp:LinkButton>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle Mode="NumericPages"></PagerStyle>
									</ASP:DATAGRID></TD>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td vAlign="top" width="50%">
						<table cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD class="TDBGColor1" width="75">File</TD>
								<TD style="WIDTH: 15px">:</TD>
								<TD class="TDBGColorValue"><INPUT id="TXT_FILE_UPLOAD" style="WIDTH: 344px; HEIGHT: 19px" type="file" size="38" name="File1"
										runat="Server"></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Status</TD>
								<TD>:</TD>
								<TD class="TDBGColorValue"><asp:label id="LBL_STATUS" runat="server" ForeColor="Red"></asp:label><asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" ErrorMessage="Hanya file xls yang diperbolehkan!"
										ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.xls|.XLS)$" ControlToValidate="TXT_FILE_UPLOAD"></asp:regularexpressionvalidator></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1"></TD>
								<TD></TD>
								<TD class="TDBGColorValue"><asp:label id="LBL_STATUSREPORT" runat="server" ForeColor="Red"></asp:label></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 21px" align="center" colSpan="3"><asp:button id="BTN_UPLOAD" runat="server" Text="Upload" onclick="BTN_UPLOAD_Click"></asp:button></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="3"></TD>
							</TR>
						</table>
					</td>
				</tr>
				<TR>
					<TD class="tdHeader1" colSpan="7" height="35">Uploaded Data</TD>
				</TR>
				<TR>
					<TD colSpan="2"><ASP:DATAGRID id="DatGrd" runat="server" AllowPaging="True" CellPadding="1" AutoGenerateColumns="False"
							Width="100%">
							<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
							<Columns>
								<asp:BoundColumn DataField="comp_name" HeaderText="Nama perusahaan">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="jns_bu" HeaderText="Jenis Badan Usaha">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Pemberi_proyek" HeaderText="Pemberi Proyek">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="nilai_aset" HeaderText="Nilai Aset">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Fee" HeaderText="Fee">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Tahun" HeaderText="Tahun">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</ASP:DATAGRID></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
