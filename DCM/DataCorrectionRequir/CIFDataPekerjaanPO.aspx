<%@ Page language="c#" Codebehind="CIFDataPekerjaanPO.aspx.cs" AutoEventWireup="True" Inherits="SME.DCM.DataCorrectionRequir.CIFDataPekerjaanPO" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CIFDataPekerjaanPO</title>
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
								<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>CIF DATA PEKERJAAN</B></TD>
							</TR>
						</TABLE>
					</TD>
					<TD class="tdNoBorder" align="right"><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../../Body.aspx"><IMG src="../../Image/MainMenu.jpg"></A><A href="../../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A></TD>
				</TR>
				<tr>
					<TD class="tdNoBorder" style="HEIGHT: 41px" align="left" colSpan="2"><asp:placeholder id="MenuCIF" runat="server"></asp:placeholder></TD>
				</tr>
				<TR>
					<TD class="tdHeader1" colSpan="2">Data Pekerjaan</TD>
				</TR>
				<TR>
					<TD class="td" vAlign="top" width="100%" colSpan="2"><ASP:DATAGRID id="DatGridDataPerusahaan" runat="server" AllowPaging="True" CellPadding="1" PageSize="5"
							AutoGenerateColumns="False" Width="100%">
							<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
							<Columns>
								<asp:BoundColumn DataField="" HeaderText="SEQ#">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="" HeaderText="Company Name">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="" HeaderText="Jabatan">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="" HeaderText="Tgl. Mula Bekerja">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="" HeaderText="Current Salary">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="" HeaderText="Currency">
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
				<TR>
					<TD class="td" vAlign="top" width="50%">
						<TABLE id="Table10" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 276px">
									<asp:Label id="LBL_TXT_COMP_NAME" runat="server">Nama Perusahaan :</asp:Label></TD>
								<TD style="WIDTH: 15px; HEIGHT: 23px"></TD>
								<TD class="TDBGColorValue" align="left"><asp:textbox id="TXT_COMP_NAME" runat="server" Width="300px" MaxLength="50"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 276px">
									<asp:Label id="LBL_DDL_BLN_START" runat="server">Tgl. Mulai Bekerja :</asp:Label></TD>
								<TD style="WIDTH: 15px; HEIGHT: 23px"></TD>
								<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_START" runat="server" Width="24px"
										MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_BLN_START" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_START" runat="server" Width="36px"
										MaxLength="4" Columns="4"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 276px">
									<asp:Label id="Label1" runat="server">Tgl. Berhenti Bekerja :</asp:Label></TD>
								<TD style="WIDTH: 15px; HEIGHT: 23px"></TD>
								<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_STOP" runat="server" Width="24px"
										MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_BLN_STOP" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_STOP" runat="server" Width="36px"
										MaxLength="4" Columns="4"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 276px">
									<asp:Label id="LBL_DDL_INDUSTRY_CD" runat="server">Kode Industri :</asp:Label></TD>
								<TD style="WIDTH: 15px; HEIGHT: 23px"></TD>
								<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left"><asp:dropdownlist id="DDL_INDUSTRY_CD" runat="server" Width="96px"></asp:dropdownlist></TD>
							</TR>
						</TABLE>
					</TD>
					<TD class="td" vAlign="top" align="center" width="50%">
						<TABLE id="Table11" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 276px">
									<asp:Label id="LBL_DDL_JABATAN" runat="server">Jabatan :</asp:Label></TD>
								<TD></TD>
								<TD class="TDBGColorValue" align="left"><asp:dropdownlist id="DDL_JABATAN" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 276px">
									<asp:Label id="LBL_DDL_KODE_JOB" runat="server">Kode Pekerjaan :</asp:Label></TD>
								<TD></TD>
								<TD class="TDBGColorValue" align="left"><asp:dropdownlist id="DDL_KODE_JOB" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 276px">
									<asp:Label id="LBL_TXT_SALARY" runat="server">Current Salary :</asp:Label></TD>
								<TD></TD>
								<TD class="TDBGColorValue" align="left"><asp:textbox id="TXT_SALARY" runat="server" Width="300px" MaxLength="50"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 276px">
									<asp:Label id="LBL_DDL_CURR" runat="server">Currency :</asp:Label></TD>
								<TD></TD>
								<TD class="TDBGColorValue" align="left"><asp:dropdownlist id="DDL_CURR" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<tr align="center">
					<td class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2"><asp:button id="BTN_SAVE" runat="server" Width="76px" Text="INSERT" CssClass="Button1" onclick="BTN_SAVE_Click"></asp:button>&nbsp;
						<asp:button id="BTN_CLEAR" runat="server" Width="76px" Text="CLEAR" CssClass="Button1" onclick="BTN_CLEAR_Click"></asp:button></td>
				</tr>
			</TABLE>
			</TD></TR></TABLE></form>
	</body>
</HTML>
