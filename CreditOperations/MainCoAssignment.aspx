<%@ Page language="c#" Codebehind="MainCoAssignment.aspx.cs" AutoEventWireup="True" Inherits="SME.CreditOperation.MainCoAssignment" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Appraisal Assignment</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_mandatoryOnly.html" -->
		<script language="javascript">
			function isSave()
			{
				conf = confirm("Are you sure you want to save?");
				if (conf)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		</script>
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TBODY>
						<TR>
							<TD class="tdNoBorder"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
								<TABLE id="Table2">
									<TR>
										<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Assignment : Main</B></TD>
									</TR>
								</TABLE>
							</TD>
							<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A>
								<asp:ImageButton id="BTN_BACK" runat="server" ImageUrl="../Image/back.jpg" onclick="BTN_BACK_Click"></asp:ImageButton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
						</TR>
						<TR>
							<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
						</TR>
						<TR>
							<TD class="tdHeader1" colSpan="2">Informasi Umum</TD>
						</TR>
						<TR>
							<TD class="td" vAlign="top" width="50%">
								<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 129px">No. Aplikasi</TD>
										<TD style="WIDTH: 15px">:</TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_AP_REGNO" runat="server" Width="150px" ReadOnly="True"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">No. Referensi</TD>
										<TD style="WIDTH: 15px">:</TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_REF" runat="server" Width="150px" ReadOnly="True"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Tanggal Aplikasi</TD>
										<TD style="WIDTH: 15px">:</TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_AP_SIGNDATE" runat="server" Width="150px" ReadOnly="True"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Sub-Segment/Program</TD>
										<TD style="WIDTH: 15px">:</TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_PROGRAMDESC" runat="server" Width="175px" ReadOnly="True"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Unit</TD>
										<TD style="WIDTH: 15px">:</TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_BRANCH_NAME" runat="server" Width="175px" ReadOnly="True"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Supervisi</TD>
										<TD>:</TD>
										<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_AP_TEAMLEADER" runat="server" ReadOnly="True"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Analis</TD>
										<TD>:</TD>
										<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_AP_RELMNGR" runat="server" ReadOnly="True"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Petugas</TD>
										<TD>:</TD>
										<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_AP_BUSINESUNIT" runat="server" Width="175px" ReadOnly="True"></asp:textbox></TD>
									</TR> <!-- Additional Field : Right --></TABLE>
								<asp:label id="LBL_CU_CUSTTYPEID" runat="server" Visible="False"></asp:label></TD>
							<TD class="td" vAlign="top" width="50%">
								<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="TDBGColor1" width="150">Nama</TD>
										<TD style="WIDTH: 15px">:</TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_NAME" runat="server" Width="175px" ReadOnly="True"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Alamat</TD>
										<TD style="WIDTH: 15px">:</TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_ADDRESS1" runat="server" Width="175px" ReadOnly="True"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="HEIGHT: 11px">&nbsp;</TD>
										<TD style="HEIGHT: 11px"></TD>
										<TD class="TDBGColorValue" style="HEIGHT: 11px"><asp:textbox id="TXT_ADDRESS2" runat="server" Width="175px" ReadOnly="True"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">&nbsp;</TD>
										<TD></TD>
										<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_ADDRESS3" runat="server" Width="175px" ReadOnly="True"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Kota</TD>
										<TD>:</TD>
										<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_CITY" runat="server" Width="175px" ReadOnly="True"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">No. Telepon</TD>
										<TD>:</TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_PHONENUM" runat="server" Width="175px" ReadOnly="True"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Bidang Usaha</TD>
										<TD>:</TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_BUSINESSTYPE" runat="server" Width="175px" ReadOnly="True"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Segmen</TD>
										<TD>:</TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_AP_CA" runat="server" Width="175px" ReadOnly="True"></asp:textbox></TD>
									</TR> <!-- 14 --> <!-- 21 --> <!-- Additional Field : Right --></TABLE>
							</TD>
						</TR>
						<TR>
							<TD class="tdHeader1" colSpan="2">Penugasan Penilaian</TD>
						</TR>
						<TR>
							<TD class="td" vAlign="top" width="100%" colSpan="2">
								<table cellSpacing="0" cellPadding="0" width="100%" border="0">
									<TBODY>
										<TR>
											<td vAlign="top" width="45%">
												<table cellSpacing="2" cellPadding="2" width="100%">
													<tr>
														<td class="td">
															<asp:Table id="Table_List" runat="server" Width="100%" CellPadding="0" CellSpacing="0" CssClass="TDBGColor21">
																<asp:TableRow>
																	<asp:TableCell CssClass="tdSmallHeader" Width="40%">Agunan</asp:TableCell>
																	<asp:TableCell CssClass="tdSmallHeader" Width="60%" ColumnSpan="2">Penugasan Penilaian</asp:TableCell>
																</asp:TableRow>
															</asp:Table>
														</td>
													</tr>
													<tr>
														<td align="center">&nbsp;
															<asp:TextBox id="TXT_JML_JAMINAN" runat="server" Visible="False"></asp:TextBox>
															<asp:TextBox id="TXT_AUDITDESC_OFFICER" runat="server" Visible="False">Appraisal Officer for </asp:TextBox>
															<asp:TextBox id="TXT_AUDITDESC_AGENCY" runat="server" Visible="False">Appraisal Agency for </asp:TextBox></td>
													</tr>
												</table>
											</td>
											<td width="55%"><iframe id="coldetail" name="coldetail" scrolling="auto" width="100%" height="500" frameborder="0"></iframe>
											</td>
										</TR>
									</TBODY>
								</table>
							</TD>
						</TR>
					</TBODY>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
