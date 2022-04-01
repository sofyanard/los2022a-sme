<%@ Page language="c#" Codebehind="AssignmentDetail.aspx.cs" AutoEventWireup="True" Inherits="SME.Assignment.AssignmentDetail" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>BICheckingEntry</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file = "../include/cek_entries.html" -->
		<!-- #include file = "../include/cek_mandatory.html" -->
		<script language="javascript">
			function update()
			{
				conf = confirm("Are you sure you want to update?");
				if (conf)
				{
					return true;
				}
				else
				{
					return false;
				}
			}

			function konfirAssign(ddl)
			{				
				var indeks = ddl.selectedIndex
				conf = confirm("Anda yakin ingin meng-assign " + ddl.options(indeks).text + " ?");
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
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TBODY>
						<TR>
							<TD class="tdNoBorder"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
								<TABLE id="Table3">
									<TR>
										<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>
												<asp:Label id="LBL_TITLE" runat="server"></asp:Label>
												&nbsp;Assignment</B></TD>
									</TR>
								</TABLE>
							</TD>
							<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A>
								<A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
						</TR>
						<TR>
							<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
						</TR>
						<TR>
							<TD class="tdHeader1" colSpan="2">
								PENUGASAN</TD>
						</TR>
						<tr>
							<td class="tdHeader1" colSpan="2">Info Pemohon</td>
						</tr>
						<tr>
							<td colSpan="2">
								<TABLE cellSpacing="2" cellPadding="2" width="100%">
									<tr>
										<td class="td" vAlign="top" width="50%">
											<TABLE cellSpacing="0" cellPadding="0" width="100%">
												<tr>
													<td class="TDBGColor1" width="150">No. Aplikasi</td>
													<td width="15"></td>
													<td class="TDBGColorValue">
														<asp:textbox id="TXT_AP_REGNO" Runat="server" Width="300px" BorderStyle="None" ReadOnly="True"></asp:textbox></td>
												</tr>
												<TR>
													<TD class="TDBGColor1">No. Referensi</TD>
													<TD></TD>
													<td class="TDBGColorValue"><asp:textbox id="TXT_CU_REF" Runat="server" ReadOnly="True" Width="300px" BorderStyle="None"></asp:textbox></td>
												</TR>
												<tr>
													<td class="TDBGColor1">Tanggal Aplikasi</td>
													<td></td>
													<td class="TDBGColorValue"><asp:textbox id="TXT_AP_SIGNDATE" Runat="server" ReadOnly="True" Width="300px" BorderStyle="None"></asp:textbox></td>
												</tr>
												<tr>
													<td class="TDBGColor1">Sub-Segment/Program</td>
													<td></td>
													<td class="TDBGColorValue"><asp:textbox id="TXT_PROGRAMDESC" Runat="server" ReadOnly="True" Width="300px" BorderStyle="None"></asp:textbox></td>
												</tr>
												<tr>
													<td class="TDBGColor1">KC/KCP</td>
													<td></td>
													<td class="TDBGColorValue"><asp:textbox id="TXT_BRANCH_NAME" Runat="server" ReadOnly="True" Width="300px" BorderStyle="None"></asp:textbox></td>
												</tr>
												<tr>
													<td class="TDBGColor1">Supervisi</td>
													<td></td>
													<td class="TDBGColorValue"><asp:textbox id="TXT_AP_TMLDRNM" Runat="server" ReadOnly="True" Width="300px" BorderStyle="None"></asp:textbox></td>
												</tr>
												<tr>
													<td class="TDBGColor1">Analis</td>
													<td></td>
													<td class="TDBGColorValue"><asp:textbox id="TXT_AP_RMNM" Runat="server" ReadOnly="True" Width="300px" BorderStyle="None"></asp:textbox></td>
												</tr>
												<tr>
													<td class="TDBGColor1">Segmen</td>
													<td></td>
													<td class="TDBGColorValue"><asp:textbox id="TXT_BU_DESC" Runat="server" ReadOnly="True" Width="300px" BorderStyle="None"></asp:textbox></td>
												</tr>
											</TABLE>
										</td>
										<td class="td" vAlign="top">
											<TABLE cellSpacing="0" cellPadding="0" width="100%">
												<tr>
													<td class="TDBGColor1" width="150">Nama Pemohon</td>
													<td width="15"></td>
													<td class="TDBGColorValue"><asp:textbox id="TXT_CU_NAME" Runat="server" ReadOnly="True" Width="300px" BorderStyle="None"></asp:textbox></td>
												</tr>
												<tr>
													<td class="TDBGColor1" vAlign="top">Alamat</td>
													<td></td>
													<td class="TDBGColorValue"><asp:textbox id="TXT_CU_ADDR1" Runat="server" ReadOnly="True" Width="300px" BorderStyle="None"></asp:textbox><br>
														<asp:textbox id="TXT_CU_ADDR2" Runat="server" ReadOnly="True" Width="300px" BorderStyle="None"></asp:textbox><br>
														<asp:textbox id="TXT_CU_ADDR3" Runat="server" ReadOnly="True" Width="300px" BorderStyle="None"></asp:textbox></td>
												</tr>
												<tr>
													<td class="TDBGColor1">Kota</td>
													<td></td>
													<td class="TDBGColorValue"><asp:textbox id="TXT_CU_CITYNM" Runat="server" ReadOnly="True" Width="300px" BorderStyle="None"></asp:textbox></td>
												</tr>
												<tr>
													<td class="TDBGColor1">No. Telp</td>
													<td></td>
													<td class="TDBGColorValue"><asp:textbox id="TXT_CU_PHN" Runat="server" ReadOnly="True" Width="300px" BorderStyle="None"></asp:textbox></td>
												</tr>
												<tr>
													<td class="TDBGColor1">Bidang Usaha</td>
													<td></td>
													<td class="TDBGColorValue"><asp:textbox id="TXT_BUSSTYPEDESC" Runat="server" ReadOnly="True" Width="300px" BorderStyle="None"></asp:textbox></td>
												</tr> <!-- Additional Field : Right --></TABLE>
											<asp:label id="LBL_TC" Runat="server" Visible="False"></asp:label>
											<asp:label id="LBL_AP_REGNO" Runat="server" Visible="False"></asp:label>
											<asp:label id="LBL_CU_REF" Runat="server" Visible="False"></asp:label>
											<asp:label id="LBL_BS_COMPLETE" Runat="server" Visible="False"></asp:label>
											<asp:label id="LBL_BS_BIASSIGN" Runat="server" Visible="False"></asp:label>
										</td>
									</tr>
								</TABLE>
							</td>
						</tr>
						<%if (Request.QueryString["bi"] != "0") { %>
						<% } %>
						<TR>
							<TD colSpan="2" class="tdheader1">Penugasan</TD>
						</TR>
						<%if (Request.QueryString["bi"] != "0") { %>
						<% } %>
						<TR>
							<TD colspan="2">
								<TABLE id="Table2" style="WIDTH: 569px; HEIGHT: 8px" cellSpacing="1" cellPadding="1" width="569">
									<TR>
										<TD class="tdbgcolor1" style="HEIGHT: 17px">
											Petugas</TD>
										<TD style="HEIGHT: 17px"></TD>
										<TD style="HEIGHT: 17px">
											<asp:DropDownList id="DDL_PETUGAS" runat="server"></asp:DropDownList>
											<asp:button id="BTN_ASSIGN" runat="server" Text="Kirim" CssClass="Button1" 
                                                Width="80px" onclick="BTN_ASSIGN_Click"></asp:button>
											<asp:button id="BTN_CANCEL" runat="server" CssClass="Button1" Text="Batal" 
                                                Width="80px" Visible="False" onclick="BTN_CANCEL_Click"></asp:button></TD>
									</TR>
									<TR>
										<TD class="tdbgcolor1">Supervisi</TD>
										<TD></TD>
										<TD>
											<asp:DropDownList id="DDL_TEAM" runat="server"></asp:DropDownList>
											<asp:button id="BTN_ASSIGN_TEAM" runat="server" Width="80px" CssClass="Button1" 
                                                Text="Kirim" onclick="BTN_ASSIGN_TEAM_Click"></asp:button></TD>
									</TR>
								</TABLE>
								<asp:Label id="LBL_USERID" runat="server" Visible="False"></asp:Label>
							</TD>
						</TR>
						<TR>
							<TD vAlign="top" align="center" width="50%" colSpan="2">
								<asp:Label id="LBL_DEBUG" runat="server" ForeColor="Red" Visible="False"></asp:Label>
								<asp:TextBox id="TXT_AUDITDESC" runat="server" Visible="False"> Assignment to </asp:TextBox></TD>
						</TR>
						<TR>
							<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2">
								<asp:button id="BTN_RECHECK" runat="server" Width="140px" Visible="False" CssClass="Button1"
									Text="Cek Ulang" onclick="BTN_RECHECK_Click"></asp:button>
								<asp:button id="BTN_UPDATESTATUS" runat="server" CssClass="Button1" Text="Update Status" Visible="False"
									Width="140" onclick="BTN_UPDATESTATUS_Click"></asp:button>
							</TD>
						</TR>
					</TBODY>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
