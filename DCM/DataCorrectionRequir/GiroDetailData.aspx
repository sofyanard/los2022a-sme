<%@ Page language="c#" Codebehind="GiroDetailData.aspx.cs" AutoEventWireup="True" Inherits="SME.DCM.DataCorrectionRequir.GiroDetailData" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>GiroDetailData</title>
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
								<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>GIRO DETAIL DATA</B></TD>
							</TR>
						</TABLE>
					</TD>
					<TD class="tdNoBorder" align="right"><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../../Body.aspx"><IMG src="../../Image/MainMenu.jpg"></A><A href="../../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A></TD>
				</TR>
				<tr>
					<td></td>
				</tr>
				<TR>
					<TD class="tdHeader1" colSpan="2">Giro Data</TD>
				</TR>
				<TR>
					<TD class="td" vAlign="top" width="50%">
						<TABLE id="Table10" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 276px">
									<asp:Label id="LBL_TXT_NO_REK" runat="server">No Rekening</asp:Label></TD>
								<TD style="WIDTH: 15px; HEIGHT: 23px">:</TD>
								<TD class="TDBGColorValue" align="left"><asp:textbox id="TXT_NO_REK" runat="server" Width="300px" MaxLength="50"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 276px">
									<asp:Label id="LBL_TXT_NM_NASABAH" runat="server">Nama Nasabah</asp:Label></TD>
								<TD style="WIDTH: 15px; HEIGHT: 23px">:</TD>
								<TD class="TDBGColorValue" align="left"><asp:textbox id="TXT_NM_NASABAH" runat="server" Width="300px" MaxLength="50"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 276px">
									<asp:Label id="LBL_TXT_BUC" runat="server">BUC</asp:Label></TD>
								<TD style="WIDTH: 15px; HEIGHT: 23px">:</TD>
								<TD class="TDBGColorValue" align="left"><asp:textbox id="TXT_BUC" runat="server" Width="300px" MaxLength="50"></asp:textbox></TD>
							</TR>
						</TABLE>
					</TD>
					<TD class="td" vAlign="top" align="center" width="50%">
						<TABLE id="Table11" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 276px"><FONT color="#000000">
										<asp:Label id="LBL_DDL_TUJ_PENG_DN" runat="server">Tujuan Penggunaan Dana</asp:Label></FONT></TD>
								<TD style="WIDTH: 15px; HEIGHT: 23px">:</TD>
								<TD class="TDBGColorValue" align="left"><asp:dropdownlist id="DDL_TUJ_PENG_DN" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 276px"><FONT color="#000000">
										<asp:Label id="LBL_DDL_TUJ_PEM_REK" runat="server">Tujuan Pembukaan Rekening</asp:Label></FONT></TD>
								<TD style="WIDTH: 15px; HEIGHT: 23px">:</TD>
								<TD class="TDBGColorValue" align="left"><asp:dropdownlist id="DDL_TUJ_PEM_REK" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 276px"><FONT color="#000000">
										<asp:Label id="LBL_DDL_RANGE" runat="server">Range Pendapatan</asp:Label></FONT></TD>
								<TD style="WIDTH: 15px; HEIGHT: 23px">:</TD>
								<TD class="TDBGColorValue" align="left"><asp:dropdownlist id="DDL_RANGE" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<tr align="center">
					<td class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2"><asp:button id="BTN_SAVE" runat="server" Width="76px" Text="SAVE" CssClass="Button1" onclick="BTN_SAVE_Click"></asp:button>&nbsp;
						<asp:button id="BTN_CLEAR" runat="server" Width="76px" Text="CLEAR" CssClass="Button1" onclick="BTN_CLEAR_Click"></asp:button></td>
				</tr>
				<tr>
					<td colSpan="2"></td>
				</tr>
			</TABLE>
			</TD></TR></TABLE></form>
	</body>
</HTML>
