<%@ Page language="c#" Codebehind="BCG_Facility_Detail.aspx.cs" AutoEventWireup="True" Inherits="SME.Scoring.Version01.BCG_Facility_Detail" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Scoring</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../../include/cek_all.html" -->
		<!-- #include file="../../include/onepost.html" -->
		<!-- #include file="../../include/ConfirmBox.html" -->
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table2" style="HEIGHT: 368px" cellSpacing="1" cellPadding="1" width="90%" border="0">
					<TR>
						<TD>
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD class="tdHeader1" style="HEIGHT: 1px; TEXT-ALIGN: center" colSpan="3"><asp:label id="LABEL" runat="server" Height="16px" Width="143px">Application Type</asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 345px; HEIGHT: 24px" vAlign="middle">Application 
										Type
									</TD>
									<TD style="WIDTH: 14px; HEIGHT: 24px" width="14"></TD>
									<TD style="HEIGHT: 24px" vAlign="middle"><asp:dropdownlist id="DDL_APPTYPE" runat="server" Height="32px" Width="144px" AutoPostBack="True" onselectedindexchanged="DDL_APPTYPE_SelectedIndexChanged"></asp:dropdownlist><asp:button id="BTN_LIHAT" runat="server" Width="72px" Visible="False" CssClass="Button1" Text="Show"></asp:button></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 345px; HEIGHT: 17px">Financial and Qualitative 
										Rating</TD>
									<TD style="WIDTH: 14px; HEIGHT: 17px" width="14"></TD>
									<TD style="HEIGHT: 17px"><asp:dropdownlist id="DDL_BCGFINRATING" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_BCGFINRATING_SelectedIndexChanged"></asp:dropdownlist><asp:textbox id="TXT_CUSTRISKTYPE" runat="server" Height="19px" Width="125px" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 345px">Probability of Default (P(d))</TD>
									<TD style="WIDTH: 14px"></TD>
									<TD><asp:textbox id="TXT_SR_BCGPROBDEF" runat="server" Height="19px" Width="136px" CssClass="angka"
											onkeypress="return numbersonly();"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 345px; HEIGHT: 5px">1 Year Average P(d)</TD>
									<TD style="WIDTH: 14px; HEIGHT: 5px"></TD>
									<TD style="HEIGHT: 5px"><asp:textbox id="TXT_SR_BCGYRAVG" runat="server" Height="19px" Width="136px" CssClass="angka"
											onkeypress="return numbersonly();"></asp:textbox></TD>
								</TR>
								<TR>
									<TD colspan="3" style="HEIGHT: 3px"></TD>
								</TR>
								<TR>
									<TD class="tdHeader1" colSpan="3">Struktur Kredit
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 346px; HEIGHT: 18px">No. Rekening</TD>
									<TD style="HEIGHT: 18px" width="15"></TD>
									<TD style="HEIGHT: 18px"><asp:textbox id="TXT_ACC_NO" runat="server" Height="19px" Width="152px" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 346px; HEIGHT: 18px">Jenis Pengajuan</TD>
									<TD style="HEIGHT: 18px" width="15"></TD>
									<TD style="HEIGHT: 18px"><asp:textbox id="TXT_APPTYPE" runat="server" Height="19px" Width="152px" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 346px; HEIGHT: 18px">Jenis Kredit</TD>
									<TD style="HEIGHT: 18px" width="15"></TD>
									<TD style="HEIGHT: 18px"><asp:textbox id="TXT_PRODUCTDESC" runat="server" Height="19px" Width="152px" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 346px; HEIGHT: 18px">Sifat Kredit</TD>
									<TD style="HEIGHT: 18px" width="15"></TD>
									<TD style="HEIGHT: 18px"><asp:textbox id="TXT_REVOLVING" runat="server" Height="19px" Width="152px" CssClass="angka" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 346px; HEIGHT: 18px" vAlign="top">Tujuan 
										Penggunaan</TD>
									<TD style="HEIGHT: 18px" width="15"></TD>
									<TD style="HEIGHT: 18px"><asp:textbox id="TXT_LOANPURPOSEDESC" runat="server" Height="56px" Width="288px" ReadOnly="True"
											TextMode="MultiLine"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 346px; HEIGHT: 18px">Limit (Rp.)</TD>
									<TD style="HEIGHT: 18px" width="15"></TD>
									<TD style="HEIGHT: 18px"><asp:textbox id="TXT_CP_LIMIT" runat="server" Height="19px" Width="152px" CssClass="angka" ReadOnly="True"></asp:textbox><asp:textbox id="Textbox5" runat="server" Height="19px" Width="136px" Visible="False" CssClass="angka"
											ReadOnly="True"></asp:textbox></TD>
								</TR>
								<!--
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 346px; HEIGHT: 18px">Installment (Rp.)</TD>
									<TD style="HEIGHT: 18px" width="15"></TD>
									<TD style="HEIGHT: 18px"></TD>
								</TR>
								--></TABLE>
							<asp:label id="LBL_CU_REF" runat="server" Visible="False"></asp:label><BR>
							<TABLE id="Table1" style="HEIGHT: 131px" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD class="tdHeader1" colSpan="3">Original Facility Rating
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 346px; HEIGHT: 18px">Average Collateral 
										Coverage (%)</TD>
									<TD style="HEIGHT: 18px" width="15"></TD>
									<TD style="HEIGHT: 18px"><asp:textbox id="TXT_SB_AVGCOLL" runat="server" Height="19px" Width="136px" CssClass="angka"
											onkeypress="return numbersonly();"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 346px">LGD (%)</TD>
									<TD></TD>
									<TD><asp:textbox id="TXT_SB_AVGLGD" runat="server" Height="19px" Width="136px" CssClass="angka" onkeypress="return numbersonly();"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 346px">Exposure at Default (%)</TD>
									<TD></TD>
									<TD><asp:textbox id="TXT_SB_EXPOSURE" runat="server" Height="19px" Width="136px" CssClass="angka"
											onkeypress="return numbersonly();"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 346px">Expected Loss (%)</TD>
									<TD></TD>
									<TD><asp:textbox id="TXT_SB_EXPLOSS" runat="server" Height="19px" Width="136px" CssClass="angka"
											onkeypress="return numbersonly();"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 346px">Facility Rating</TD>
									<TD></TD>
									<TD><asp:dropdownlist id="DDL_SB_FACRATING" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_SB_FACRATING_SelectedIndexChanged"></asp:dropdownlist><asp:textbox id="TXT_FACRISKTYPE" runat="server" Height="19px" Width="125px" ReadOnly="True"></asp:textbox></TD>
								</TR>
							</TABLE>
							<asp:label id="LBL_AP_REGNO" runat="server" Visible="False"></asp:label><asp:label id="LBL_PRODUCTID" runat="server" Visible="False"></asp:label>
							<asp:label id="LBL_SR_BCGRISKGRADE" runat="server" Visible="False"></asp:label></TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" align="center"><asp:button id="btnSave" runat="server" Width="140px" CssClass="Button1" Text="Save" onclick="btnSave_Click"></asp:button>&nbsp;
						<%if (Request.QueryString["scr"] != "0") {%>
							<asp:button id="btnUpdateStatus" runat="server" Width="140" CssClass="Button1" Text="Update Status" onclick="btnUpdateStatus_Click"></asp:button>
							<%}%>
							</TD>
					</TR>
					<tr>
						<td style="VISIBILITY: hidden"><asp:comparevalidator id="PROBDEF_VALID" runat="server" Display="Dynamic" ControlToValidate="TXT_SR_BCGPROBDEF"
								Type="Double" Operator="DataTypeCheck" ErrorMessage="<li> Probability of Default harus angka"> *</asp:comparevalidator>&nbsp;
							<asp:comparevalidator id="YRAVG_VALID" runat="server" Display="Dynamic" ControlToValidate="TXT_SR_BCGYRAVG"
								Type="Double" Operator="DataTypeCheck" ErrorMessage="1 Year Average harus angka">*</asp:comparevalidator>&nbsp;
							<asp:comparevalidator id="AVGCOLL_VALID" runat="server" Display="Dynamic" ControlToValidate="TXT_SB_AVGCOLL"
								Type="Double" Operator="DataTypeCheck" ErrorMessage="Average Collateral Coverage harus angka">*</asp:comparevalidator>&nbsp;
							<asp:comparevalidator id="LGD_VALID" runat="server" ControlToValidate="TXT_SB_AVGLGD" Type="Double" Operator="DataTypeCheck"
								ErrorMessage="LGD harus angka">*</asp:comparevalidator>&nbsp;
							<asp:comparevalidator id="EXP_VALID" runat="server" ControlToValidate="TXT_SB_EXPOSURE" Type="Double"
								Operator="DataTypeCheck" ErrorMessage="Exposure at Default harus angka">*</asp:comparevalidator>&nbsp;
							<asp:comparevalidator id="EXPLOSS_VALID" runat="server" ControlToValidate="TXT_SB_EXPLOSS" Type="Double"
								Operator="DataTypeCheck" ErrorMessage="Expected Loss harus angka">*</asp:comparevalidator>&nbsp;
							<asp:requiredfieldvalidator id="APPTYPE_VALID" runat="server" ControlToValidate="DDL_APPTYPE" ErrorMessage="Pilih salah satu Application Type">*</asp:requiredfieldvalidator><asp:validationsummary id="VALID_SUMMARY" runat="server" Height="24px" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary></td>
					</tr>
				</TABLE>
			</center>
		</form>
	</body>
	<script language=javascript>
	/**
	function update() {
		ans = confirm("Are you sure you want to update?");
		
		if (ans) {
			return true;
		}
		else {
			return false;
		}
	}**/
	</script>
</HTML>
