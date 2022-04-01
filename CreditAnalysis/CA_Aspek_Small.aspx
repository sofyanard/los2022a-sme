<%@ Page language="c#" Codebehind="CA_Aspek_Small.aspx.cs" AutoEventWireup="True" Inherits="SME.CreditAnalysis.CA_Aspek" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CA_Aspek</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include  file="../include/cek_all.html" -->
		<script language="javascript">
		  function fillText(sTXT)
		  {
		    objTXT = eval('document.Form1.TXT_' + sTXT)
		    objDDL = eval('document.Form1.DDL_' + sTXT)
		    objTXT.value = objDDL.options[objDDL.selectedIndex].text;
		  }
		</script>
		</SCRIPT>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE cellSpacing="2" cellPadding="2" width="100%">
				<TR>
					<TD class="tdNoBorder"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
						<TABLE width="100%">
							<TR>
								<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Credit Analysis&nbsp;: 
										Aspek - Aspek</B></TD>
							</TR>
						</TABLE>
					</TD>
					<TD class="tdNoBorder" align="right"><A href="MainCreditAnalysis.aspx?"></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="../Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
				</TR>
				<TR>
					<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
				</TR>
				<TR>
					<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="SubMenu" runat="server"></asp:placeholder></TD>
				</TR>
				<TR>
					<TD colSpan="2">&nbsp;<STRONG>Select Aspek :</STRONG>
						<asp:dropdownlist id="DDL_ASPEK" runat="server"></asp:dropdownlist><asp:button id="BTN_INSERT" runat="server" Text="<< INSERT" onclick="BTN_INSERT_Click"></asp:button></TD>
				</TR>
				<!-- FORMAT A -------------------------------------------------------------------------------------------------->
				<TR>
					<TD class="td" width="100%" colSpan="2">
						<table id="FORMAT_A" width="100%" runat="server">
							<TR>
								<TD>
									<TABLE width="100%">
										<TBODY>
											<TR>
												<TD class="tdHeader1" width="100%" colSpan="3">ASPEK LEGALITAS</TD>
											</TR>
											<tr>
												<td class="tdHeader1" width="60%" colSpan="2">Legalitas</td>
												<td class="tdHeader1" width="40%">Catatan</td>
											</tr>
											<tr>
												<td class="tdBGColor1" width="40%">Legalitas Mandiri Perusahaan</td>
												<td class="tdBGColorValue" width="20%"><asp:radiobutton id="OPT_LMP1_FORMAT_A" runat="server" Text="Sah" GroupName="OPT_LMP" Checked="True"></asp:radiobutton>&nbsp;&nbsp;&nbsp;<asp:radiobutton id="OPT_LMP2_FORMAT_A" runat="server" Text="Tidak Sah" GroupName="OPT_LMP"></asp:radiobutton></td>
												<td class="tdBGColorValue" width="40%"><asp:textbox onkeypress="return kutip_satu()" id="TXT_LMP_FORMAT_A" runat="server" Width="100%"></asp:textbox></td>
											</tr>
											<!-- -->
											<tr>
												<td class="tdBGColor1" width="40%">Legalitas Usaha (Ijin-ijin)</td>
												<td class="tdBGColorValue" width="20%"><asp:radiobutton id="OPT_LUI1_FORMAT_A" runat="server" Text="Sah" GroupName="OPT_LUI" Checked="True"></asp:radiobutton>&nbsp;&nbsp;&nbsp;<asp:radiobutton id="OPT_LUI2_FORMAT_A" runat="server" Text="Tidak Sah" GroupName="OPT_LUI"></asp:radiobutton></td>
												<td class="tdBGColorValue" width="40%"><asp:textbox onkeypress="return kutip_satu()" id="TXT_LUI_FORMAT_A" runat="server" Width="100%"></asp:textbox></td>
											</tr>
											<!-- -->
											<tr>
												<td class="tdBGColor1" width="40%">Legalitas Pemohon</td>
												<td class="tdBGColorValue" width="20%"><asp:radiobutton id="OPT_LP1_FORMAT_A" runat="server" Text="Sah" GroupName="OPT_LP" Checked="True"></asp:radiobutton>&nbsp;&nbsp;&nbsp;<asp:radiobutton id="OPT_LP2_FORMAT_A" runat="server" Text="Tidak Sah" GroupName="OPT_LP"></asp:radiobutton></td>
												<td class="tdBGColorValue" width="40%"><asp:textbox onkeypress="return kutip_satu()" id="TXT_LP_FORMAT_A" runat="server" Width="100%"></asp:textbox></td>
											</tr>
											<!-- -->
											<tr>
												<td class="tdBGColor1" width="40%">Legalitas Kontrak Kerja</td>
												<td class="tdBGColorValue" width="20%"><asp:radiobutton id="OPT_LKK1_FORMAT_A" runat="server" Text="Sah" GroupName="OPT_LKK" Checked="True"></asp:radiobutton>&nbsp;&nbsp;&nbsp;<asp:radiobutton id="OPT_LKK2_FORMAT_A" runat="server" Text="Tidak Sah" GroupName="OPT_LKK" AutoPostBack="True"></asp:radiobutton></td>
												<td class="tdBGColorValue" width="40%"><asp:textbox onkeypress="return kutip_satu()" id="TXT_LKK_FORMAT_A" runat="server" Width="100%"></asp:textbox></td>
											</tr>
										</TBODY>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD class="td">
									<table id="Table1" width="100%" runat="server">
										<TR>
											<TD class="tdHeader1" width="100%">Aspek Pemasaran, Manajemen, Teknis &amp; Past 
												Performance</TD>
										</TR>
										<TR>
											<TD vAlign="top" align="center" width="50%" colSpan="2"><asp:textbox onkeypress="return kutip_satu()" id="TXT_APMT_FORMAT_A" runat="server" MaxLength="8000"
													TextMode="MultiLine" Rows="15" Columns="125"></asp:textbox></TD>
										</TR>
									</table>
								</TD>
							</TR>
						</table>
					</TD>
				</TR>
				<!-- FORMAT B -------------------------------------------------------------------------------------------------->
				<TR>
					<TD class="td" width="100%" colSpan="2">
						<table id="FORMAT_B" width="100%" runat="server">
							<TR>
								<TD>
									<TABLE width="100%">
										<TBODY>
											<TR>
												<TD class="tdHeader1" width="100%" colSpan="3">ASPEK LEGALITAS</TD>
											</TR>
											<tr>
												<td class="tdHeader1" width="60%" colSpan="2">Legalitas</td>
												<td class="tdHeader1" width="40%">Catatan</td>
											</tr>
											<tr>
												<td class="tdBGColor1" width="40%">Legalitas Mandiri Perusahaan</td>
												<td class="tdBGColorValue" width="20%"><asp:radiobutton id="OPT_LMP1_FORMAT_B" runat="server" Text="Sah" GroupName="OPT_LMP_B" Checked="True"></asp:radiobutton>&nbsp;&nbsp;&nbsp;<asp:radiobutton id="OPT_LMP2_FORMAT_B" runat="server" Text="Tidak Sah" GroupName="OPT_LMP_B"></asp:radiobutton></td>
												<td class="tdBGColorValue" width="40%"><asp:textbox onkeypress="return kutip_satu()" id="TXT_LMP_FORMAT_B" runat="server" Width="100%"></asp:textbox></td>
											</tr>
											<!-- -->
											<tr>
												<td class="tdBGColor1" width="40%">Legalitas Usaha (Ijin-ijin)</td>
												<td class="tdBGColorValue" width="20%"><asp:radiobutton id="OPT_LUI1_FORMAT_B" runat="server" Text="Sah" GroupName="OPT_LUI_B" Checked="True"></asp:radiobutton>&nbsp;&nbsp;&nbsp;<asp:radiobutton id="OPT_LUI2_FORMAT_B" runat="server" Text="Tidak Sah" GroupName="OPT_LUI_B"></asp:radiobutton></td>
												<td class="tdBGColorValue" width="40%"><asp:textbox onkeypress="return kutip_satu()" id="TXT_LUI_FORMAT_B" runat="server" Width="100%"></asp:textbox></td>
											</tr>
											<!-- -->
											<tr>
												<td class="tdBGColor1" width="40%">Legalitas Pemohon</td>
												<td class="tdBGColorValue" width="20%"><asp:radiobutton id="OPT_LP1_FORMAT_B" runat="server" Text="Sah" GroupName="OPT_LP_B" Checked="True"></asp:radiobutton>&nbsp;&nbsp;&nbsp;<asp:radiobutton id="OPT_LP2_FORMAT_B" runat="server" Text="Tidak Sah" GroupName="OPT_LP_B"></asp:radiobutton></td>
												<td class="tdBGColorValue" width="40%"><asp:textbox onkeypress="return kutip_satu()" id="TXT_LP_FORMAT_B" runat="server" Width="100%"></asp:textbox></td>
											</tr>
											<!-- -->
											<tr>
												<td class="tdBGColor1" width="40%">Legalitas Kontrak Kerja</td>
												<td class="tdBGColorValue" width="20%"><asp:radiobutton id="OPT_LKK1_FORMAT_B" runat="server" Text="Sah" GroupName="OPT_LKK_B" Checked="True"></asp:radiobutton>&nbsp;&nbsp;&nbsp;<asp:radiobutton id="OPT_LKK2_FORMAT_B" runat="server" Text="Tidak Sah" GroupName="OPT_LKK_B"></asp:radiobutton></td>
												<td class="tdBGColorValue" width="40%"><asp:textbox onkeypress="return kutip_satu()" id="TXT_LKK_FORMAT_B" runat="server" Width="100%"></asp:textbox></td>
											</tr>
										</TBODY>
									</TABLE>
								</TD>
							</TR>
							<!-- ----- ------------->
							<TR>
								<TD class="td">
									<table id="Table2" width="100%" border="1" runat="server">
										<TR>
											<TD class="tdHeader1" width="100%">PENJELASAN ASPEK LEGAL</TD>
										</TR>
										<TR>
											<TD class="td" vAlign="top" align="center" width="50%" colSpan="2"><asp:textbox onkeypress="return kutip_satu()" id="TXT_PAL_FORMAT_B" runat="server" MaxLength="8000"
													TextMode="MultiLine" Rows="15" Columns="125"></asp:textbox></TD>
										</TR>
									</table>
								</TD>
							</TR>
							<TR>
								<TD class="td">
									<table id="Table3" width="100%" border="1" runat="server">
										<TR>
											<TD class="tdHeader1" colSpan="2">ASPEK PEMASARAN</TD>
										</TR>
										<TR>
											<TD class="td" vAlign="top" align="center" width="50%" colSpan="2"><asp:textbox onkeypress="return kutip_satu()" id="TXT_PEMASARAN_FORMAT_B" runat="server" MaxLength="8000"
													TextMode="MultiLine" Rows="15" Columns="125"></asp:textbox></TD>
										</TR>
									</table>
								</TD>
							</TR>
							<TR>
								<TD class="td">
									<table id="Table4" width="100%" border="1" runat="server">
										<TR>
											<TD class="tdHeader1" colSpan="2">ASPEK MANAJEMEN</TD>
										</TR>
										<TR>
											<TD class="td" vAlign="top" align="center" width="50%" colSpan="2"><asp:textbox onkeypress="return kutip_satu()" id="TXT_MANAJEMEN_FORMAT_B" runat="server" MaxLength="8000"
													TextMode="MultiLine" Rows="15" Columns="125"></asp:textbox></TD>
										</TR>
									</table>
								</TD>
							</TR>
							<TR>
								<TD class="td">
									<table id="Table5" width="100%" border="1" runat="server">
										<TR>
											<TD class="tdHeader1" colSpan="2">ASPEK TEKNIS</TD>
										</TR>
										<TR>
											<TD class="td" vAlign="top" align="center" width="50%" colSpan="2"><asp:textbox onkeypress="return kutip_satu()" id="TXT_TEKNIS_FORMAT_B" runat="server" MaxLength="8000"
													TextMode="MultiLine" Rows="15" Columns="125"></asp:textbox></TD>
										</TR>
									</table>
								</TD>
							</TR>
							<TR>
								<TD class="td">
									<table id="Table6" width="100%" border="1" runat="server">
										<TR>
											<TD class="tdHeader1" colSpan="2">ASPEK PAST PERFORMANCE</TD>
										</TR>
										<TR>
											<TD class="td" vAlign="top" align="center" width="50%" colSpan="2"><asp:textbox onkeypress="return kutip_satu()" id="TXT_PP_FORMAT_B" runat="server" MaxLength="8000"
													TextMode="MultiLine" Rows="15" Columns="125"></asp:textbox></TD>
										</TR>
									</table>
								</TD>
							</TR>
						</table>
					</TD>
				</TR>
				<!-- FORMAT C -------------------------------------------------------------------------------------------------->
				<TR>
					<TD class="td" width="100%" colSpan="2">
						<table id="FORMAT_C" width="100%" runat="server">
							<TR>
								<TD>
									<TABLE width="100%">
										<TBODY>
											<TR>
												<TD class="tdHeader1" width="100%" colSpan="3">ASPEK LEGALITAS</TD>
											</TR>
											<tr>
												<td class="tdHeader1" width="60%" colSpan="2">Legalitas</td>
												<td class="tdHeader1" width="40%">Catatan</td>
											</tr>
											<tr>
												<td class="tdBGColor1" width="40%">Legalitas Mandiri Perusahaan</td>
												<td class="tdBGColorValue" width="20%"><asp:radiobutton id="OPT_LMP1_FORMAT_C" runat="server" Text="Sah" GroupName="OPT_LMP_C" Checked="True"></asp:radiobutton>&nbsp;&nbsp;&nbsp;<asp:radiobutton id="OPT_LMP2_FORMAT_C" runat="server" Text="Tidak Sah" GroupName="OPT_LMP_C"></asp:radiobutton></td>
												<td class="tdBGColorValue" width="40%"><asp:textbox onkeypress="return kutip_satu()" id="TXT_LMP_FORMAT_C" runat="server" Width="100%"></asp:textbox></td>
											</tr>
											<!-- -->
											<tr>
												<td class="tdBGColor1" width="40%">Legalitas Usaha (Ijin-ijin)</td>
												<td class="tdBGColorValue" width="20%"><asp:radiobutton id="OPT_LUI1_FORMAT_C" runat="server" Text="Sah" GroupName="OPT_LUI_C" Checked="True"></asp:radiobutton>&nbsp;&nbsp;&nbsp;<asp:radiobutton id="OPT_LUI2_FORMAT_C" runat="server" Text="Tidak Sah" GroupName="OPT_LUI_C"></asp:radiobutton></td>
												<td class="tdBGColorValue" width="40%"><asp:textbox onkeypress="return kutip_satu()" id="TXT_LUI_FORMAT_C" runat="server" Width="100%"></asp:textbox></td>
											</tr>
											<!-- -->
											<tr>
												<td class="tdBGColor1" width="40%">Legalitas Pemohon</td>
												<td class="tdBGColorValue" width="20%"><asp:radiobutton id="OPT_LP1_FORMAT_C" runat="server" Text="Sah" GroupName="OPT_LP_C" Checked="True"></asp:radiobutton>&nbsp;&nbsp;&nbsp;<asp:radiobutton id="OPT_LP2_FORMAT_C" runat="server" Text="Tidak Sah" GroupName="OPT_LP_C"></asp:radiobutton></td>
												<td class="tdBGColorValue" width="40%"><asp:textbox onkeypress="return kutip_satu()" id="TXT_LP_FORMAT_C" runat="server" Width="100%"></asp:textbox></td>
											</tr>
											<!-- -->
											<tr>
												<td class="tdBGColor1" width="40%">Legalitas Kontrak Kerja</td>
												<td class="tdBGColorValue" width="20%"><asp:radiobutton id="OPT_LKK1_FORMAT_C" runat="server" Text="Sah" GroupName="OPT_LKK_C" Checked="True"></asp:radiobutton>&nbsp;&nbsp;&nbsp;<asp:radiobutton id="OPT_LKK2_FORMAT_C" runat="server" Text="Tidak Sah" GroupName="OPT_LKK_C"></asp:radiobutton></td>
												<td class="tdBGColorValue" width="40%"><asp:textbox onkeypress="return kutip_satu()" id="TXT_LKK_FORMAT_C" runat="server" Width="100%"></asp:textbox></td>
											</tr>
										</TBODY>
									</TABLE>
								</TD>
							</TR>
							<!-- ----- ------------->
							<TR>
								<TD class="td">
									<table id="Table7" width="100%" border="1" runat="server">
										<TR>
											<TD class="tdHeader1" width="100%">PENJELASAN ASPEK LEGAL</TD>
										</TR>
										<TR>
											<TD class="td" vAlign="top" align="center" width="50%" colSpan="2"><asp:textbox onkeypress="return kutip_satu()" id="TXT_PAL_FORMAT_C" runat="server" MaxLength="8000"
													TextMode="MultiLine" Rows="15" Columns="125"></asp:textbox></TD>
										</TR>
									</table>
								</TD>
							</TR>
							<TR>
								<TD class="td">
									<table id="Table8" width="100%" border="1" runat="server">
										<TR>
											<TD class="tdHeader1" colSpan="2">ASPEK PEMASARAN</TD>
										</TR>
										<TR>
											<TD class="td" vAlign="top" align="center" width="50%" colSpan="2"><asp:textbox onkeypress="return kutip_satu()" id="TXT_PEMASARAN_FORMAT_C" runat="server" MaxLength="8000"
													TextMode="MultiLine" Rows="15" Columns="125"></asp:textbox></TD>
										</TR>
									</table>
								</TD>
							</TR>
							<TR>
								<TD class="td">
									<table id="Table9" width="100%" border="1" runat="server">
										<TR>
											<TD class="tdHeader1" colSpan="2">ASPEK MANAJEMEN</TD>
										</TR>
										<TR>
											<TD class="td" vAlign="top" align="center" width="50%" colSpan="2"><asp:textbox onkeypress="return kutip_satu()" id="TXT_MANAJEMEN_FORMAT_C" runat="server" MaxLength="8000"
													TextMode="MultiLine" Rows="15" Columns="125"></asp:textbox></TD>
										</TR>
									</table>
								</TD>
							</TR>
							<TR>
								<TD class="td">
									<table id="Table10" width="100%" border="1" runat="server">
										<TR>
											<TD class="tdHeader1" colSpan="2">ASPEK TEKNIS</TD>
										</TR>
										<TR>
											<TD class="td" vAlign="top" align="center" width="50%" colSpan="2"><asp:textbox onkeypress="return kutip_satu()" id="TXT_TEKNIS_FORMAT_C" runat="server" MaxLength="8000"
													TextMode="MultiLine" Rows="15" Columns="125"></asp:textbox></TD>
										</TR>
									</table>
								</TD>
							</TR>
						</table>
					</TD>
				</TR>
				<!-- FORMAT D ----------------------------------------->
				<TR>
					<TD class="td" width="100%" colSpan="2">
						<table id="FORMAT_D" width="100%" runat="server">
							<TR>
								<TD>
									<TABLE width="100%">
										<TBODY>
											<TR>
												<TD class="tdHeader1" width="100%" colSpan="3">ASPEK LEGALITAS</TD>
											</TR>
											<tr>
												<td class="tdHeader1" width="60%" colSpan="2">Legalitas</td>
												<td class="tdHeader1" width="40%">Catatan</td>
											</tr>
											<tr>
												<td class="tdBGColor1" width="40%">Legalitas Mandiri Perusahaan</td>
												<td class="tdBGColorValue" width="20%"><asp:radiobutton id="OPT_LMP1_FORMAT_D" runat="server" Text="Sah" GroupName="OPT_LMP_D" Checked="True"></asp:radiobutton>&nbsp;&nbsp;&nbsp;<asp:radiobutton id="OPT_LMP2_FORMAT_D" runat="server" Text="Tidak Sah" GroupName="OPT_LMP_D"></asp:radiobutton></td>
												<td class="tdBGColorValue" width="40%"><asp:textbox onkeypress="return kutip_satu()" id="TXT_LMP_FORMAT_D" runat="server" Width="100%"></asp:textbox></td>
											</tr>
											<!-- -->
											<tr>
												<td class="tdBGColor1" width="40%">Legalitas Usaha (Ijin-ijin)</td>
												<td class="tdBGColorValue" width="20%"><asp:radiobutton id="OPT_LUI1_FORMAT_D" runat="server" Text="Sah" GroupName="OPT_LUI_D" Checked="True"></asp:radiobutton>&nbsp;&nbsp;&nbsp;<asp:radiobutton id="OPT_LUI2_FORMAT_D" runat="server" Text="Tidak Sah" GroupName="OPT_LUI_D"></asp:radiobutton></td>
												<td class="tdBGColorValue" width="40%"><asp:textbox onkeypress="return kutip_satu()" id="TXT_LUI_FORMAT_D" runat="server" Width="100%"></asp:textbox></td>
											</tr>
											<!-- -->
											<tr>
												<td class="tdBGColor1" width="40%">Legalitas Pemohon</td>
												<td class="tdBGColorValue" width="20%"><asp:radiobutton id="OPT_LP1_FORMAT_D" runat="server" Text="Sah" GroupName="OPT_LP_D" Checked="True"></asp:radiobutton>&nbsp;&nbsp;&nbsp;<asp:radiobutton id="OPT_LP2_FORMAT_D" runat="server" Text="Tidak Sah" GroupName="OPT_LP_D"></asp:radiobutton></td>
												<td class="tdBGColorValue" width="40%"><asp:textbox onkeypress="return kutip_satu()" id="TXT_LP_FORMAT_D" runat="server" Width="100%"></asp:textbox></td>
											</tr>
											<!-- -->
											<tr>
												<td class="tdBGColor1" width="40%">Legalitas Kontrak Kerja</td>
												<td class="tdBGColorValue" width="20%"><asp:radiobutton id="OPT_LKK1_FORMAT_D" runat="server" Text="Sah" GroupName="OPT_LKK_D" Checked="True"></asp:radiobutton>&nbsp;&nbsp;&nbsp;<asp:radiobutton id="OPT_LKK2_FORMAT_D" runat="server" Text="Tidak Sah" GroupName="OPT_LKK_D"></asp:radiobutton></td>
												<td class="tdBGColorValue" width="40%"><asp:textbox onkeypress="return kutip_satu()" id="TXT_LKK_FORMAT_D" runat="server" Width="100%"></asp:textbox></td>
											</tr>
											<TR>
												<TD class="tdBGColor1" width="40%">Legalitas&nbsp;Agunan Kredit</TD>
												<TD class="tdBGColorValue" width="20%"><asp:radiobutton id="OPT_LAK1_FORMAT_D" runat="server" Text="Sah" GroupName="OPT_LAK_D" Checked="True"></asp:radiobutton>&nbsp;&nbsp;&nbsp;<asp:radiobutton id="OPT_LAK2_FORMAT_D" runat="server" Text="Tidak Sah" GroupName="OPT_LAK_D"></asp:radiobutton></TD>
												<TD class="tdBGColorValue" width="40%"><asp:textbox onkeypress="return kutip_satu()" id="TXT_LAK_FORMAT_D" runat="server" Width="100%"></asp:textbox></TD>
											</TR>
										</TBODY>
									</TABLE>
								</TD>
							</TR>
							<!-- ----- ------------->
							<TR>
								<TD class="td">
									<table id="Table11" width="100%" border="1" runat="server">
										<TR>
											<TD class="tdHeader1" width="100%">PENJELASAN ASPEK LEGAL</TD>
										</TR>
										<TR>
											<TD class="td" vAlign="top" align="center" width="50%" colSpan="2"><asp:textbox onkeypress="return kutip_satu()" id="TXT_PAL_FORMAT_D" runat="server" MaxLength="8000"
													TextMode="MultiLine" Rows="15" Columns="125"></asp:textbox></TD>
										</TR>
									</table>
								</TD>
							</TR>
						</table>
					</TD>
				</TR>
				<!-- FORMAT E ----------------------------------------->
				<TR>
					<TD class="td" width="100%" colSpan="2">
						<table id="FORMAT_E" width="100%" runat="server">
							<TR>
								<TD>
									<TABLE width="100%">
										<TBODY>
											<TR>
												<TD class="tdHeader1" width="100%" colSpan="3">ASPEK LEGALITAS</TD>
											</TR>
											<tr>
												<td class="tdHeader1" width="60%" colSpan="2">Legalitas</td>
												<td class="tdHeader1" width="40%">Catatan</td>
											</tr>
											<tr>
												<td class="tdBGColor1" width="40%">Legalitas Mandiri Perusahaan</td>
												<td class="tdBGColorValue" width="20%"><asp:radiobutton id="OPT_LMP1_FORMAT_E" runat="server" Text="Sah" GroupName="OPT_LMP_E" Checked="True"></asp:radiobutton>&nbsp;&nbsp;&nbsp;<asp:radiobutton id="OPT_LMP2_FORMAT_E" runat="server" Text="Tidak Sah" GroupName="OPT_LMP_E"></asp:radiobutton></td>
												<td class="tdBGColorValue" width="40%"><asp:textbox onkeypress="return kutip_satu()" id="TXT_LMP_FORMAT_E" runat="server" Width="100%"></asp:textbox></td>
											</tr>
											<!-- -->
											<tr>
												<td class="tdBGColor1" width="40%">Legalitas Usaha (Ijin-ijin)</td>
												<td class="tdBGColorValue" width="20%"><asp:radiobutton id="OPT_LUI1_FORMAT_E" runat="server" Text="Sah" GroupName="OPT_LUI_E" Checked="True"></asp:radiobutton>&nbsp;&nbsp;&nbsp;<asp:radiobutton id="OPT_LUI2_FORMAT_E" runat="server" Text="Tidak Sah" GroupName="OPT_LUI_E"></asp:radiobutton></td>
												<td class="tdBGColorValue" width="40%"><asp:textbox onkeypress="return kutip_satu()" id="TXT_LUI_FORMAT_E" runat="server" Width="100%"></asp:textbox></td>
											</tr>
											<!-- -->
											<tr>
												<td class="tdBGColor1" width="40%">Legalitas Pemohon</td>
												<td class="tdBGColorValue" width="20%"><asp:radiobutton id="OPT_LP1_FORMAT_E" runat="server" Text="Sah" GroupName="OPT_LP_E" Checked="True"></asp:radiobutton>&nbsp;&nbsp;&nbsp;<asp:radiobutton id="OPT_LP2_FORMAT_E" runat="server" Text="Tidak Sah" GroupName="OPT_LP_E"></asp:radiobutton></td>
												<td class="tdBGColorValue" width="40%"><asp:textbox onkeypress="return kutip_satu()" id="TXT_LP_FORMAT_E" runat="server" Width="100%"></asp:textbox></td>
											</tr>
											<!-- -->
											<tr>
												<td class="tdBGColor1" width="40%">Legalitas Kontrak Kerja</td>
												<td class="tdBGColorValue" width="20%"><asp:radiobutton id="OPT_LKK1_FORMAT_E" runat="server" Text="Sah" GroupName="OPT_LKK_E" Checked="True"></asp:radiobutton>&nbsp;&nbsp;&nbsp;<asp:radiobutton id="OPT_LKK2_FORMAT_E" runat="server" Text="Tidak Sah" GroupName="OPT_LKK_E"></asp:radiobutton></td>
												<td class="tdBGColorValue" width="40%"><asp:textbox onkeypress="return kutip_satu()" id="TXT_LKK_FORMAT_E" runat="server" Width="100%"></asp:textbox></td>
											</tr>
											<TR>
												<TD class="tdBGColor1" width="40%">Legalitas&nbsp;Agunan Kredit</TD>
												<TD class="tdBGColorValue" width="20%"><asp:radiobutton id="OPT_LAK1_FORMAT_E" runat="server" Text="Sah" GroupName="OPT_LAK_E" Checked="True"></asp:radiobutton>&nbsp;&nbsp;&nbsp;<asp:radiobutton id="OPT_LAK2_FORMAT_E" runat="server" Text="Tidak Sah" GroupName="OPT_LAK_E"></asp:radiobutton></TD>
												<TD class="tdBGColorValue" width="40%"><asp:textbox onkeypress="return kutip_satu()" id="TXT_LAK_FORMAT_E" runat="server" Width="100%"></asp:textbox></TD>
											</TR>
										</TBODY>
									</TABLE>
								</TD>
							</TR>
							<!-- ----- ------------->
							<TR>
								<TD class="td">
									<table id="Table12" width="100%" border="1" runat="server">
										<TR>
											<TD class="tdHeader1" width="100%">PENJELASAN ASPEK LEGAL</TD>
										</TR>
										<TR>
											<TD class="td" vAlign="top" align="center" width="50%" colSpan="2"><asp:textbox onkeypress="return kutip_satu()" id="TXT_PAL_FORMAT_E" runat="server" MaxLength="8000"
													TextMode="MultiLine" Rows="15" Columns="125"></asp:textbox></TD>
										</TR>
									</table>
								</TD>
							</TR>
						</table>
					</TD>
				</TR>
				<!-- FORMAT H (Qualitative Rating) ---------------------------------------------------------------------->
				<TR>
					<TD class="td" width="100%" colSpan="2">
						<table id="FORMAT_H" width="100%" runat="server">
							<!-- -------- rating qualitative new ----------------->
							<TR>
								<TD class="td" colSpan="2">
									<table width="100%">
										<tr>
											<td class="tdHeader1" width="100%" colSpan="2">Qualitative Rating</td>
										</tr>
										<TR width="100%">
											<TD colSpan="2"><ASP:DATAGRID id="DGR_QUAL" runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="1"
													AllowPaging="True">
													<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
													<Columns>
														<asp:BoundColumn Visible="False" DataField="QUALITATIVEID"></asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="SUBQUALITATIVEID"></asp:BoundColumn>
														<asp:BoundColumn DataField="QUALITATIVEDESC" HeaderText="Qualitative">
															<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="SUBQUALITATIVEDESC" HeaderText="Sub Qualitative">
															<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn HeaderText="Sub Sub Qualitative">
															<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
															<ItemTemplate>
																<asp:radiobuttonlist id="RBL_SUBSUBQUAL" runat="server" RepeatDirection="Vertical"></asp:radiobuttonlist>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:BoundColumn DataField="SCORE" HeaderText="Score" Visible="False">
															<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="FLAG" HeaderText="Flag">
															<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														</asp:BoundColumn>
													</Columns>
													<PagerStyle Mode="NumericPages"></PagerStyle>
												</ASP:DATAGRID></TD>
										</TR>
										<tr>
											<td class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2">
												<asp:button id="BTN_RETRVCBI" runat="server" Text="Retrieve from CBI" onclick="BTN_RETRVCBI_Click"></asp:button>&nbsp;&nbsp;
												<asp:button id="BTN_SAVEQUAL" runat="server" Text="Save Qualitative" CssClass="Button1" onclick="BTN_SAVEQUAL_Click"></asp:button>
											</td>
										</tr>
										<tr>
											<td class="td" align="center" colSpan="2"><asp:datagrid id="DGR_CLASSIFY" Width="500" AutoGenerateColumns="False" CellPadding="1" Runat="server"
													PageSize="1">
													<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
													<Columns>
														<asp:BoundColumn Visible="False" DataField="QUALITATIVEID"></asp:BoundColumn>
														<asp:BoundColumn DataField="QUALITATIVEDESC" HeaderText="Qualitative">
															<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="AVERAGE" HeaderText="Average">
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
															<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="CLASSIFICATION" HeaderText="Classification">
															<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="CHILDSCORE" HeaderText="Child Score">
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
															<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="SCORE" HeaderText="Score">
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
															<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="FLAG" HeaderText="Flag">
															<HeaderStyle Width="5%" CssClass="tdSmallHeader"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
													</Columns>
												</asp:datagrid></td>
										</tr>
										<tr>
											<td class="td" colSpan="2">
												<table width="100%">
													<tr>
														<TD class="TDBGColor1" width="20%">Qualitative Total Score</TD>
														<TD>:</TD>
														<TD class="TDBGColorValue" width="30%"><asp:label id="LBL_QSCORE" runat="server"></asp:label></TD>
														<TD class="TDBGColor1" width="20%">Qualitative Recommendation</TD>
														<TD>:</TD>
														<TD class="TDBGColorValue" width="30%"><asp:label id="LBL_QREC" runat="server"></asp:label></TD>
													</tr>
												</table>
											</td>
										</tr>
									</table>
								</TD>
							</TR>
						</table>
					</TD>
				</TR>
				<!-- FORMAT G (Small Business Enhancement) ---------------------------------------------------------------------->
				<TR>
					<TD class="td" width="100%" colSpan="2">
						<table id="FORMAT_G" width="100%" runat="server">
							<TR>
								<TD class="td" colSpan="2">
									<table width="100%">
										<tr>
											<td class="tdHeader1" width="100%" colSpan="2">R A C</td>
										</tr>
										<tr>
											<td class="td" colSpan="2"><asp:datagrid id="DGR_RAC" Width="100%" AutoGenerateColumns="False" CellPadding="1" Runat="server"
													AllowPaging="True" DESIGNTIMEDRAGDROP="2507">
													<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
													<Columns>
														<asp:BoundColumn Visible="False" DataField="RACID"></asp:BoundColumn>
														<asp:BoundColumn DataField="RACDESC" HeaderText="Item">
															<HeaderStyle Width="90%" CssClass="tdSmallHeader"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="ISCOMPLY"></asp:BoundColumn>
														<asp:TemplateColumn HeaderText="Compliance">
															<HeaderStyle Width="10%" CssClass="tdSmallHeader"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
															<ItemTemplate>
																<asp:radiobuttonlist id="RBL_RAC" runat="server" RepeatDirection="Horizontal">
																	<asp:ListItem Value="1">Yes</asp:ListItem>
																	<asp:ListItem Value="0">No</asp:ListItem>
																</asp:radiobuttonlist>
															</ItemTemplate>
														</asp:TemplateColumn>
													</Columns>
													<PagerStyle Mode="NumericPages"></PagerStyle>
												</asp:datagrid></td>
										</tr>
										<tr>
											<td class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2"><asp:button id="BTN_SAVERAC" runat="server" Text="Save RAC" CssClass="Button1" onclick="BTN_SAVERAC_Click"></asp:button></td>
										</tr>
									</table>
								</TD>
							</TR>
						</table>
					</TD>
				</TR>
				<!-- FORMAT F -------------------------------------->
				<TR>
					<TD class="td" width="100%" colSpan="2">
						<table id="FORMAT_F" width="100%" runat="server">
							<TR>
								<TD>
									<TABLE width="100%">
										<TR>
											<TD align="right" width="10%">&nbsp;</TD>
											<TD class="tdHeader1" align="center" width="90%" colSpan="2">Data Legalitas</TD>
										</TR>
										<TR>
											<TD class="tdBGColor1" align="right" width="10%">1.</TD>
											<TD class="tdBGColorValue" align="left" width="50%">Status Kemilikan Lahan</TD>
											<TD class="tdBGColorValue" align="left" width="40%"><asp:radiobutton id="OPT_LAHAN1_FORMAT_F" runat="server" Text="Sah" GroupName="OPT_LAHAN_F" Checked="True"></asp:radiobutton>&nbsp;&nbsp;&nbsp;<asp:radiobutton id="OPT_LAHAN2_FORMAT_F" runat="server" Text="Tidak Sah" GroupName="OPT_LAHAN_F"></asp:radiobutton></TD>
										</TR>
										<TR>
											<TD class="tdBGColor1" align="right" width="10%">2.</TD>
											<TD class="tdBGColorValue" align="left" width="50%">Luas</TD>
											<TD class="tdBGColorValue" align="left" width="40%"><asp:textbox onkeypress="return numbersonly()" id="TXT_LUAS_FORMAT_F" runat="server" Width="90%"></asp:textbox>&nbsp;</TD>
										</TR>
										<TR>
											<TD class="tdBGColor1" align="right" width="10%">3.</TD>
											<TD class="tdBGColorValue" align="left" width="50%">Lokasi Lahan</TD>
											<TD class="tdBGColorValue" align="left" width="40%"><asp:textbox onkeypress="return kutip_satu()" id="TXT_LOKASI_FORMAT_F" runat="server" Width="90%"></asp:textbox>&nbsp;</TD>
										</TR>
										<TR>
											<TD align="right" width="10%">&nbsp;</TD>
											<TD class="tdHeader1" align="center" width="90%" colSpan="2">Hubungan dengan Bank</TD>
										</TR>
										<TR>
											<TD class="tdBGColor1" align="right" width="10%">1.</TD>
											<TD class="tdBGColorValue" align="left" width="50%">Masih memperoleh fasilitas KUT</TD>
											<TD class="tdBGColorValue" align="left" width="40%"><asp:radiobutton id="OPT_KUT1_FORMAT_F" runat="server" Text="Sah" GroupName="OPT_KUT_F" Checked="True"></asp:radiobutton>&nbsp;&nbsp;&nbsp;<asp:radiobutton id="OPT_KUT2_FORMAT_F" runat="server" Text="Tidak Sah" GroupName="OPT_KUT_F"></asp:radiobutton></TD>
										</TR>
										<TR>
											<TD class="tdBGColor1" align="right" width="10%">2.</TD>
											<TD class="tdBGColorValue" align="left" width="50%">
											Fasilitas KUT tersebut dari Bank
											<TD class="tdBGColorValue" align="left" width="40%"><asp:textbox onkeypress="return kutip_satu()" id="TXT_FASILITASBANK_FORMAT_F" runat="server"
													Width="90%"></asp:textbox>&nbsp;</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</table>
					</TD>
				</TR>
			</TABLE>
			<!-- SEPARATOR -->
			<table id="TBL_SAVE" width="100%" runat="server">
				<TR>
					<TD class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2"><asp:button id="BTN_SIMPANLAH" runat="server" Text="S A V E" Width="150px" CssClass="Button1" onclick="BTN_SIMPANLAH_Click"></asp:button><asp:label id="LBL_H_JNSNASABAH" runat="server" Visible="False"></asp:label><asp:label id="LBL_H_PROGRAMID" runat="server" Visible="False"></asp:label></TD>
				</TR>
			</table>
		</form>
	</body>
</HTML>
