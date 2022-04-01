<%@ Page language="c#" Codebehind="CIFDataPengurusBU.aspx.cs" AutoEventWireup="True" Inherits="SME.DCM.DataCorrectionRequir.CIFDataPengurusBU" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CIFDataPengurusBU</title>
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
								<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>CIF DATA PENGURUS</B></TD>
							</TR>
						</TABLE>
					</TD>
					<TD class="tdNoBorder" align="right"><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../../Body.aspx"><IMG src="../../Image/MainMenu.jpg"></A><A href="../../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A></TD>
				</TR>
				<tr>
					<TD class="tdNoBorder" style="HEIGHT: 41px" align="left" colSpan="2"><asp:placeholder id="MenuCIF" runat="server"></asp:placeholder></TD>
				</tr>
				<TR>
					<TD class="tdHeader1" colSpan="2">Data Pengurus</TD>
				</TR>
				<TR>
					<TD class="td" vAlign="top" width="100%" colSpan="2"><ASP:DATAGRID id="DatGridDataPerusahaan" runat="server" AllowPaging="True" CellPadding="1" PageSize="5"
							AutoGenerateColumns="False" Width="100%">
							<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
							<Columns>
								<asp:BoundColumn DataField="EMAS_CIF" HeaderText="CIF#">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NAME" HeaderText="Nama">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CS_DOB" HeaderText="BOD/Tgl. Berdiri">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CS_SEX" HeaderText="Sex">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CS_NPWP" HeaderText="NPWP#">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CS_ALAMAT" HeaderText="Alamat">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CS_STOCKPERC" HeaderText="Share Saham(%)">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CS_ZIPCODE" HeaderText="Kode Pos">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Function">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:LinkButton id="edit_data" runat="server" CommandName="edit_data">Edit</asp:LinkButton>&nbsp;
										<asp:LinkButton id="LB_DELETE" runat="server" CommandName="delete_data">Delete</asp:LinkButton>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</ASP:DATAGRID></TD>
				</TR>
				<tr>
					<td class="td" vAlign="top" width="50%">
						<table id="Table30" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 276px">
									<asp:Label id="DDL_TXT_TOT_SAHAM" runat="server">TOTAL SAHAM (%) :</asp:Label></TD>
								<TD style="WIDTH: 15px; HEIGHT: 23px"></TD>
								<TD class="TDBGColorValue" align="left"><asp:textbox id="TXT_TOT_SAHAM" runat="server" Width="300px" ReadOnly="True" MaxLength="50"></asp:textbox></TD>
							</TR>
						</table>
					</td>
				</tr>
				<TR>
					<TD class="td" vAlign="top" width="50%">
						<TABLE id="Table10" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 276px">
									<asp:Label id="LBL_TXT_CIF" runat="server">CIF No :</asp:Label></TD>
								<TD style="WIDTH: 15px; HEIGHT: 23px"></TD>
								<TD class="TDBGColorValue" align="left"><asp:textbox id="TXT_CIF" runat="server" Width="300px" MaxLength="50"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 276px">
									<asp:Label id="LBL_TXT_NAMA" runat="server">Nama :</asp:Label></TD>
								<TD style="WIDTH: 15px; HEIGHT: 23px"></TD>
								<TD class="TDBGColorValue" align="left"><asp:textbox id="TXT_NAMA" runat="server" Width="300px" MaxLength="50"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 276px">
									<asp:Label id="LBL_DDL_JNS_NASABAH" runat="server">Jenis Nasabah  :</asp:Label>
									&nbsp;
								</TD>
								<TD style="WIDTH: 15px; HEIGHT: 23px"></TD>
								<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left"><asp:dropdownlist id="DDL_JNS_NASABAH" runat="server" Width="96px"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 276px">
									<asp:Label id="LBL_DDL_BLN_COMP" runat="server">BOD/Berdiri Sejak :</asp:Label></TD>
								<TD style="WIDTH: 15px; HEIGHT: 23px"></TD>
								<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_COMP" runat="server" Width="24px"
										MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_BLN_COMP" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_COMP" runat="server" Width="36px"
										MaxLength="4" Columns="4"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 276px">
									<asp:Label id="LBL_DDL_JNS_KELAMIN" runat="server">Jenis Kelamin :</asp:Label></TD>
								<TD style="WIDTH: 15px; HEIGHT: 10px"></TD>
								<TD class='A"TDBGColorValue"' style="HEIGHT: 10px"><asp:dropdownlist id="DDL_JNS_KELAMIN" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 276px">
									<asp:Label id="LBL_TXT_SAHAM" runat="server">Share Saham (%) :</asp:Label></TD>
								<TD style="WIDTH: 15px; HEIGHT: 23px"></TD>
								<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left"><asp:textbox onkeypress="return numbersonly()" id="TXT_SAHAM" runat="server" Width="48px" MaxLength="20"
										Columns="4"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 276px">
									<asp:Label id="LBL_TXT_NPWP" runat="server">NPWP :</asp:Label></TD>
								<TD style="WIDTH: 15px; HEIGHT: 23px"></TD>
								<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left"><asp:textbox onkeypress="return numbersonly()" id="TXT_NPWP" runat="server" Width="300px" MaxLength="50"
										Columns="4"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 276px">
									<asp:Label id="LBL_DDL_JNS_ID" runat="server">Jenis ID Utama :</asp:Label></TD>
								<TD style="WIDTH: 15px; HEIGHT: 23px"></TD>
								<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left"><asp:dropdownlist id="DDL_JNS_ID" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
							</TR>
						</TABLE>
					</TD>
					<TD class="td" vAlign="top" align="center" width="50%">
						<TABLE id="Table11" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 276px">
									<asp:Label id="LBL_TXT_ID_UTAMA" runat="server">No. ID Utama :</asp:Label></TD>
								<TD style="WIDTH: 15px; HEIGHT: 23px"></TD>
								<TD class="TDBGColorValue" align="left"><asp:textbox id="TXT_ID_UTAMA" runat="server" Width="300px" MaxLength="50"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 276px">
									<asp:Label id="LBL_DDL_BLN_EXP" runat="server">Expired Date ID Utama :</asp:Label></TD>
								<TD></TD>
								<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left"><asp:textbox onkeypress="return numbersonly()" id="TXT_EXP_DAY" runat="server" Width="24px" MaxLength="2"
										Columns="4"></asp:textbox><asp:dropdownlist id="DDL_BLN_EXP" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_EXP_YEAR" runat="server" Width="36px"
										MaxLength="4" Columns="4"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 276px">
									<asp:Label id="LBL_DDL_DATI" runat="server">Lokasi Dati II :</asp:Label>
									&nbsp;</TD>
								<TD></TD>
								<TD class="TDBGColorValue" align="left"><asp:dropdownlist id="DDL_DATI" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 276px">
									<asp:Label id="LBL_TXT_ALAMAT" runat="server">Alamat :</asp:Label></TD>
								<TD></TD>
								<TD class="TDBGColorValue" align="left"><asp:textbox id="TXT_ALAMAT" runat="server" Width="300px" MaxLength="50"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 276px">
									<asp:Label id="LBL_TXT_KECAMATAN" runat="server">Kecamatan :</asp:Label></TD>
								<TD></TD>
								<TD class="TDBGColorValue" align="left"><asp:textbox id="TXT_KECAMATAN" runat="server" Width="300px" MaxLength="50"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 276px">
									<asp:Label id="LBL_TXT_CU_ZIPCODE" runat="server">Kode Pos :</asp:Label></TD>
								<TD></TD>
								<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_ZIPCODE" runat="server" MaxLength="6"
										Columns="6" AutoPostBack="True"></asp:textbox><asp:button id="BTN_SEARCHCOMP" runat="server" Text="Search" onclick="BTN_SEARCHCOMP_Click"></asp:button></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 276px">
									<asp:Label id="LBL_DDL_BUC" runat="server">BUC :</asp:Label>
									&nbsp;</TD>
								<TD></TD>
								<TD class="TDBGColorValue" align="left"><asp:dropdownlist id="DDL_BUC" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 276px">
									<asp:Label id="LBL_DDL_KODE_HUB" runat="server">Kode Hubungan :</asp:Label></TD>
								<TD></TD>
								<TD class="TDBGColorValue" align="left"><asp:dropdownlist id="DDL_KODE_HUB" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 276px">
									<asp:Label id="LBL_CHK_REMOVED" runat="server">Remove: Link</asp:Label></TD>
								<TD></TD>
								<TD class="TDBGColorValue" align="left"><asp:checkbox id="CHK_REMOVED" Runat="server" Checked="false"></asp:checkbox><asp:Label id="Label1" runat="server">(check for Yes)</asp:Label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="50%" colSpan="2"><asp:label id="TXT_SEQ" Runat="server" Visible="False"></asp:label><asp:label id="TXT_XLSNAME" Runat="server" Visible="False"></asp:label><asp:button id="BTN_ADD" runat="server" Text="ADD" CssClass="button1"></asp:button><asp:button id="BTN_UPDATE" runat="server" Text="UPDATE" CssClass="button1"></asp:button><asp:button id="BTN_CLEAR" runat="server" Text="CLEAR" CssClass="button1" onclick="BTN_CLEAR_Click"></asp:button></TD>
				</TR>
				<tr>
					<td colSpan="2"></td>
				</tr>
			</TABLE>
			</TD></TR></TABLE></form>
	</body>
</HTML>
