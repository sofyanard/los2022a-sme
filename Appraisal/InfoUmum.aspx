<%@ Page language="c#" Codebehind="InfoUmum.aspx.cs" AutoEventWireup="True" Inherits="SME.Appraisal.InfoUmum" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>InfoUmum</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_all.html" -->
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder">
							<TABLE id="Table2">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Appraisal : Informasi 
											Umum</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><asp:imagebutton id="ImageButton1" runat="server" ImageUrl="../Image/back.jpg" onclick="ImageButton1_Click"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
				</TABLE>
				<TABLE cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdHeader1" vAlign="top" align="center" colSpan="2"><B>INFORMASI UMUM NASABAH</B></TD>
					</TR>
					<tr>
						<td class="td" vAlign="top" width="50%">
							<TABLE cellSpacing="0" cellPadding="0" width="100%">
								<tr>
									<td class="TDBGColor1" width="150">Application #</td>
									<td width="15"></td>
									<td class="TDBGColorValue"><asp:textbox id="TXT_AP_REGNO" Columns="35" ReadOnly Runat="server" Width="264px"></asp:textbox></td>
								</tr>
								<tr>
									<td class="TDBGColor1">Tanggal Aplikasi</td>
									<td></td>
									<td class="TDBGColorValue"><asp:textbox id="TXT_AP_SIGNDATEDAY" Columns="2" ReadOnly Runat="server"></asp:textbox><asp:dropdownlist id="DDL_AP_SIGNDATEMONTH" ReadOnly Runat="server" Enabled="False"></asp:dropdownlist><asp:textbox id="TXT_AP_SIGNDATEYEAR" Columns="4" ReadOnly Runat="server"></asp:textbox></td>
								</tr>
								<tr>
									<td class="TDBGColor1">Sub-Segment/Program</td>
									<td></td>
									<td class="TDBGColorValue"><asp:textbox id="TXT_PROGRAMDESC" Columns="35" ReadOnly Runat="server" Width="264px"></asp:textbox></td>
								</tr>
								<tr>
									<td class="TDBGColor1">KC/KCP</td>
									<td></td>
									<td class="TDBGColorValue"><asp:textbox id="TXT_BRANCH_NAME" Columns="35" ReadOnly Runat="server" Width="264px"></asp:textbox></td>
								</tr>
								<tr>
									<td class="TDBGColor1">Supervisi</td>
									<td></td>
									<td class="TDBGColorValue"><asp:textbox id="TXT_AP_TMLDRNM" Columns="35" ReadOnly Runat="server" Width="264px"></asp:textbox></td>
								</tr>
								<tr>
									<td class="TDBGColor1">Analis</td>
									<td></td>
									<td class="TDBGColorValue"><asp:textbox id="TXT_AP_RMNM" Columns="35" ReadOnly Runat="server" Width="264px"></asp:textbox></td>
								</tr>
								<tr>
									<td class="TDBGColor1">Segmen</td>
									<td></td>
									<td class="TDBGColorValue"><asp:textbox id="TXT_BU_DESC" Columns="35" ReadOnly Runat="server" Width="264px"></asp:textbox></td>
								</tr>
							</TABLE>
							<asp:label id="LBL_REGNO" Runat="server" Visible="False"></asp:label><asp:label id="LBL_CUREF" Runat="server" Visible="False"></asp:label><asp:label id="LBL_TC" Runat="server" Visible="False"></asp:label></td>
						<td class="td" vAlign="top">
							<TABLE cellSpacing="0" cellPadding="0" width="100%">
								<tr>
									<td class="TDBGColor1" width="150">Nama Pemohon</td>
									<td width="15"></td>
									<td class="TDBGColorValue"><asp:textbox id="TXT_CU_NAME" Columns="35" ReadOnly Runat="server" Width="264px"></asp:textbox></td>
								</tr>
								<tr>
									<td class="TDBGColor1" vAlign="top">Alamat</td>
									<td></td>
									<td class="TDBGColorValue"><asp:textbox id="TXT_CU_ADDR1" Columns="35" ReadOnly Runat="server" Width="264px"></asp:textbox><br>
										<asp:textbox id="TXT_CU_ADDR2" Columns="35" ReadOnly Runat="server" Width="264px"></asp:textbox><br>
										<asp:textbox id="TXT_CU_ADDR3" Columns="35" ReadOnly Runat="server" Width="264px"></asp:textbox></td>
								</tr>
								<tr>
									<td class="TDBGColor1">Kota</td>
									<td></td>
									<td class="TDBGColorValue"><asp:textbox id="TXT_CU_CITYNM" Columns="35" ReadOnly Runat="server" Width="264px"></asp:textbox></td>
								</tr>
								<tr>
									<td class="TDBGColor1">No. Telp</td>
									<td></td>
									<td class="TDBGColorValue"><asp:textbox id="TXT_CU_PHN" Columns="35" ReadOnly Runat="server" Width="264px"></asp:textbox></td>
								</tr>
								<tr>
									<td class="TDBGColor1">Bidang Usaha</td>
									<td></td>
									<td class="TDBGColorValue"><asp:textbox id="TXT_BUSSTYPEDESC" Columns="35" ReadOnly Runat="server" Width="264px"></asp:textbox></td>
								</tr>
							</TABLE>
						</td>
					</tr>
					<TR>
						<TD class="tdHeader1" align="center" width="100%" colSpan="2">HASIL PENILAIAN</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="100%" colSpan="2">
							<table cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TBODY>
									<TR>
										<td vAlign="top" width="20%">
											<table cellSpacing="2" cellPadding="2" width="100%">
												<tr>
													<td class="td"><asp:table id="Table_List" runat="server" CssClass="TDBGColor21" CellSpacing="0" CellPadding="0"
															Width="100%">
															<asp:TableRow>
																<asp:TableCell CssClass="tdSmallHeader" Width="100%" ColumnSpan="2">Daftar Agunan</asp:TableCell>
															</asp:TableRow>
														</asp:table></td>
												</tr>
											</table>
										</td>
										<td width="80%"><iframe id="coldetail" name="ApprResult" frameBorder="0" width="100%" scrolling="auto" height="425"
												runat="server"> </iframe>
										</td>
									</TR>
								</TBODY>
							</table>
						</TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
