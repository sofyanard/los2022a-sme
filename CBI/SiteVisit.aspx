<%@ Page language="c#" Codebehind="SiteVisit.aspx.cs" AutoEventWireup="True" Inherits="SME.CBI.SiteVisit" %>
<%@ Register TagPrefix="uc1" TagName="DocExport" Src="../CommonForm/DocumentExport.ascx" %>
<%@ Register TagPrefix="uc1" TagName="DocUpload" Src="../CommonForm/DocumentUpload.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Site Visit</title> <!--onkeypress="return numbersonly()" -->
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include  file="../include/cek_all.html" -->
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TBODY>
						<TR>
							<TD class="tdNoBorder"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
								<TABLE id="Table6">
									<TR>
										<TD class="tdBGColor2" style="WIDTH: 400px" align="left"><B>Verification Assignment : 
												Site Visit</B></TD>
									</TR>
								</TABLE>
							</TD>
							<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A>
								<asp:ImageButton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg" onclick="BTN_BACK_Click"></asp:ImageButton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
						</TR>
						<TR>
							<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
						</TR>
						<TR>
							<TD class="tdHeader1" colSpan="2">General Information</TD>
						</TR>
						<TR>
							<TD class="td" vAlign="top" width="50%">
								<TABLE cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="TDBGColor1" width="125">
											Name</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue">
											<asp:TextBox id="TXT_CU_NAME" runat="server" ReadOnly="True" Width="240px"></asp:TextBox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Address</TD>
										<TD vAlign="top"></TD>
										<TD class="TDBGColorValue">
											<asp:TextBox id="TXT_CU_ADDR1" runat="server" ReadOnly="True" Width="150px"></asp:TextBox>
											<asp:TextBox id="TXT_CU_ADDR2" runat="server" ReadOnly="True" Width="150px"></asp:TextBox>
											<asp:TextBox id="TXT_CU_ADDR3" runat="server" ReadOnly="True" Width="176px"></asp:TextBox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Contact Person</TD>
										<TD vAlign="top"></TD>
										<TD class="TDBGColorValue">
											<asp:TextBox id="TXT_CU_CONTACTPERSON" runat="server" ReadOnly="True" Width="175px"></asp:TextBox></TD>
									</TR>
								</TABLE>
							</TD>
							<TD class="td" vAlign="top" width="50%">
								<TABLE cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="TDBGColor1" width="150">Relationship Manager</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue">
											<asp:TextBox id="TXT_AP_RELMNGR" runat="server" ReadOnly="True" Width="175px"></asp:TextBox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Credit Analyst</TD>
										<TD></TD>
										<TD class="TDBGColorValue">
											<asp:TextBox id="TXT_CREDIT_ANALIS" runat="server" ReadOnly="True" Width="175px"></asp:TextBox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Unit</TD>
										<TD></TD>
										<TD class="TDBGColorValue">
											<asp:TextBox id="TXT_BRANCH_CODE" runat="server" ReadOnly="True" Width="175px"></asp:TextBox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Group</TD>
										<TD></TD>
										<TD class="TDBGColorValue">
											<asp:TextBox id="TXT_GROUP" runat="server" ReadOnly="True" Width="175px"></asp:TextBox></TD>
									</TR>
								</TABLE>
								<asp:label id="LBL_REGNO" Visible="False" Runat="server"></asp:label>
								<asp:label id="LBL_TC" Visible="False" Runat="server"></asp:label>
								<asp:label id="LBL_CUREF" Visible="False" Runat="server"></asp:label>
							</TD>
						</TR>
						<TR>
							<TD class="tdHeader1" colSpan="2">Laporan Kontak Dan Kunjungan Nasabah</TD>
						</TR>
						<TR>
							<TD class="td" vAlign="top" width="100%" colspan="2">
								<TABLE cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="TDBGColor1">Tanggal Kunjungan</TD>
										<TD width="17"></TD>
										<TD class="TDBGColorValue" width="74%">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_SV_DATE_DAY" runat="server" Width="24px"
												Columns="4" MaxLength="2"></asp:textbox>
											<asp:dropdownlist id="DDL_SV_DATE_MONTH" runat="server"></asp:dropdownlist>
											<asp:textbox onkeypress="return numbersonly()" id="TXT_SV_DATE_YEAR" runat="server" Width="36px"
												Columns="4" MaxLength="4"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Nama Yang Ditemui</TD>
										<TD></TD>
										<TD class="TDBGColorValue">
											<asp:TextBox onkeypress="return kutip_satu()" id="TXT_SV_NAME" runat="server" Width="793px" TextMode="MultiLine"></asp:TextBox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Tujuan kunjungan dan hal-hal yang dibicarakan</TD>
										<TD></TD>
										<TD class="TDBGColorValue">
											<asp:TextBox onkeypress="return kutip_satu()" id="TXT_SV_TUJUAN" runat="server" Width="793px"
												TextMode="MultiLine" Height="50px"></asp:TextBox>
										</TD>
									</TR>
									<TR>
										<TD colSpan="3"><b>&nbsp;Hasil Kunjungan Yang Lalu Yang Belum Ditindaklanjuti</b></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Nasabah</TD>
										<TD width="17"></TD>
										<TD class="TDBGColorValue">
											<asp:TextBox onkeypress="return kutip_satu()" id="TXT_SV_NASABAH" runat="server" Width="793px"
												TextMode="MultiLine" Height="50px"></asp:TextBox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Bank</TD>
										<TD></TD>
										<TD class="TDBGColorValue">
											<asp:TextBox onkeypress="return kutip_satu()" id="TXT_SV_BANK" runat="server" Width="793px" TextMode="MultiLine"
												Height="50px"></asp:TextBox></TD>
									</TR>
									<TR>
										<TD colSpan="3"><b>&nbsp;Hasil-hasil Kunjungan / Pembicaraan</b></TD>
									</TR>
									<TR>
										<TD colSpan="3"><b>&nbsp;1. Lokasi Usaha</b></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Kantor</TD>
										<TD width="17"></TD>
										<TD class="TDBGColorValue">
											<asp:TextBox onkeypress="return kutip_satu()" id="TXT_SV_OFFICE" runat="server" Width="793px"
												TextMode="MultiLine" Height="50px"></asp:TextBox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Pabrik</TD>
										<TD></TD>
										<TD class="TDBGColorValue">
											<asp:TextBox onkeypress="return kutip_satu()" id="TXT_SV_FACTORY" runat="server" Width="793px"
												TextMode="MultiLine" Height="50px"></asp:TextBox></TD>
									</TR>
									<TR>
										<TD colSpan="3"><b>&nbsp;2. Kondisi Usaha</b></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Manajemen</TD>
										<TD width="17"></TD>
										<TD class="TDBGColorValue">
											<asp:TextBox onkeypress="return kutip_satu()" id="TXT_SV_MANAGEMENT" runat="server" Width="794"
												TextMode="MultiLine" Height="50px"></asp:TextBox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Produksi</TD>
										<TD></TD>
										<TD class="TDBGColorValue">
											<asp:TextBox onkeypress="return kutip_satu()" id="TXT_SV_PRODUKSI" runat="server" Width="794"
												TextMode="MultiLine" Height="50px" DESIGNTIMEDRAGDROP="139"></asp:TextBox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Pemasaran</TD>
										<TD></TD>
										<TD class="TDBGColorValue">
											<asp:TextBox onkeypress="return kutip_satu()" id="TXT_SV_PEMASARAN" runat="server" Width="794"
												TextMode="MultiLine" Height="50px"></asp:TextBox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Keuangan</TD>
										<TD></TD>
										<TD class="TDBGColorValue">
											<asp:TextBox onkeypress="return kutip_satu()" id="TXT_SV_KEUANGAN" runat="server" Width="794"
												TextMode="MultiLine" Height="50px"></asp:TextBox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Agunan</TD>
										<TD></TD>
										<TD class="TDBGColorValue">
											<asp:TextBox onkeypress="return kutip_satu()" id="TXT_SV_AGUNAN" runat="server" Width="794" TextMode="MultiLine"
												Height="50px"></asp:TextBox></TD>
									</TR>
									<TR>
										<TD colSpan="3"><b>&nbsp;Persoalan Yang Harus Diselesaikan</b></TD>
									</TR>
									<TR>
										<TD colSpan="3">
											<asp:TextBox onkeypress="return kutip_satu()" id="TXT_SV_PERSOALAN" runat="server" Width="100%"
												TextMode="MultiLine" Height="50px"></asp:TextBox></TD>
									</TR>
									<TR>
										<TD colSpan="3"><b>&nbsp;Tanggal Target</b></TD>
									</TR>
									<TR>
										<TD colSpan="3">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_TG_DATE_DAY" runat="server" Width="24px"
												MaxLength="2" Columns="4"></asp:textbox>
											<asp:dropdownlist id="DDL_TG_DATE_MONTH" runat="server"></asp:dropdownlist>
											<asp:textbox onkeypress="return numbersonly()" id="TXT_TG_DATE_YEAR" runat="server" Width="36px"
												MaxLength="4" Columns="4"></asp:textbox></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2">
								<asp:button id="BTN_UPDATE" runat="server" CssClass="Button1" Text="Update" Enabled="False" onclick="BTN_UPDATE_Click"></asp:button><asp:button id="BTN_SAVE" runat="server" Text="Save" CssClass="Button1" onclick="BTN_SAVE_Click"></asp:button>&nbsp;<asp:button id="BTN_PRINT" runat="server" Text="View" CssClass="Button1" Enabled="False" onclick="BTN_PRINT_Click"></asp:button>&nbsp;</TD>
						</TR>
						<tr>
							<td width="100%"></td>
						</tr>
						<TR>
							<TD colSpan="2"><uc1:docexport id="DocExport1" runat="server"></uc1:docexport></TD>
						</TR>
						<TR>
							<TD colSpan="2"><uc1:docupload id="DocUpload1" runat="server"></uc1:docupload></TD>
						</TR>
					</TBODY>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
