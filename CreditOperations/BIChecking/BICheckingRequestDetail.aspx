<%@ Page language="c#" Codebehind="BICheckingRequestDetail.aspx.cs" AutoEventWireup="True" Inherits="SME.CreditOperations.BIChecking.BICheckingRequestDetail" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>BICheckingRequestDetail</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../../include/cek_mandatoryOnly.html" -->
		<!-- #include file="../../include/cek_entries.html" -->
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
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder">
							<TABLE id="Table3">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>BI Checking Request 
											Detail</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="../../Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../../Body.aspx"><IMG src="../../Image/MainMenu.jpg"></A><A href="../../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">Detail Permintaan IDI BI</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="200">Nomor Surat</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NOSURAT" runat="server" onkeypress="return kutip_satu()" CssClass="mandatory"
											MaxLength="30" Columns="35"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">
									Unit<TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CABANG" runat="server" ReadOnly="True" Columns="35" Width="300px" BorderStyle="None"></asp:textbox></TD>
									<TD class="TDBGColorValue"></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Supervisi</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_TEAMLEADER" runat="server" ReadOnly="True" Columns="35" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Analis</TD>
									<TD></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_RM" runat="server" ReadOnly="True" Columns="35" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nama Petuas</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CO" runat="server" ReadOnly="True" Columns="35" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tanggal Aplikasi</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_AP_SIGNDATE" runat="server" ReadOnly="True" Columns="35" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">No. Aplikasi</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_AP_REGNO" runat="server" ReadOnly="True" Columns="35" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nama Pemohon</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NAME" runat="server" ReadOnly="True" Columns="35" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1">Jenis Badan Hukum</TD>
									<TD width="17"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_BADANHUKUM" runat="server" ReadOnly="True" Columns="35" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Alamat</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_ALAMAT" runat="server" ReadOnly="True" Columns="35" Width="300px" BorderStyle="None"
											TextMode="MultiLine"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Area</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_DATI1" runat="server" ReadOnly="True" Columns="35" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">No. NPWP</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_NPWP" runat="server" ReadOnly="True" Columns="35" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">ID No</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_IDNO" runat="server" ReadOnly="True" Columns="35" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Segmen</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_BUSINESSUNIT" runat="server" ReadOnly="True" Columns="35" Width="300px"
											BorderStyle="None"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="tdHeader1" vAlign="top" align="left" width="50%" colSpan="2">Daftar 
							Pengurus dan Pemegang Saham</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" align="center" width="50%" colSpan="2"><asp:datagrid id="DataGrid1" runat="server" Width="100%" AutoGenerateColumns="False">
								<Columns>
									<asp:BoundColumn DataField="NAME" HeaderText="Nama">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="ADDR" HeaderText="Alamat KTP/Perusahaan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="DOB" HeaderText="Tgl Lahir/Pendirian">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="ID" HeaderText="No. KTP/AKTA">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="JOBTITLE" HeaderText="Jabatan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
								</Columns>
							</asp:datagrid></TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2">
                            <asp:button id="BTN_PRINT" runat="server" Width="125px" CssClass="Button1" 
                                Text="Cetak" onclick="BTN_PRINT_Click"></asp:button>&nbsp;
							<asp:button id="BTN_UPDATE" runat="server" Width="125px" CssClass="Button1" Text="Update Status" onclick="BTN_UPDATE_Click"></asp:button></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
