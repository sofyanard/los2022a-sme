<%@ Page language="c#" Codebehind="VerifikasiMain.aspx.cs" AutoEventWireup="True" Inherits="SME.CEA.VerifikasiMain" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>VerifikasiMain</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_mandatory.html" -->
		<!-- #include file="../include/cek_entries.html" -->
		<!-- #include file="../include/popup.html" -->
		<!-- #include file="../include/cek_all.html" -->
		<!-- #include file="../include/onepost.html" -->
		<!-- #include file="../include/ConfirmBox.html" -->
		<script language="javascript">
		function keluar()
		{
			if (confirm("Are you sure want to finish ?"))
				document.Fmain.submit();
		}
		
			
		</script>
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder">
							<TABLE id="Table8">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Verification - Main</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">Info Rekanan</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">No. Aplikasi</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NO_Reg" runat="server" BorderStyle="None" ReadOnly="True" Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jenis Rekanan</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_JNS_REK" runat="server" BorderStyle="None" ReadOnly="True" Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nama Rekanan</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NAMA_REK" runat="server" BorderStyle="None" ReadOnly="True" Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Contact Person</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CP" runat="server" BorderStyle="None" ReadOnly="True" Width="300px"></asp:textbox></TD>
								</TR>
							</TABLE>
							<asp:label id="LBL_r" runat="server" Visible="False"></asp:label>
							<asp:label id="LBL_REKANANTYPEID" runat="server" Visible="False"></asp:label>
							<asp:label id="LBL_AP_PROG_CODE" runat="server" Visible="False"></asp:label></TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1">Alamat Rekanan</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_ADDRESS1" runat="server" ReadOnly="True" Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 11px">&nbsp;</TD>
									<TD style="HEIGHT: 11px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 11px"><asp:textbox id="TXT_ADDRESS2" runat="server" ReadOnly="True" Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Kota</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_CITY" runat="server" BorderStyle="None" ReadOnly="True" Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">No. Telepon Kantor</TD>
									<TD></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_NoTelp" runat="server" ReadOnly="True" Width="300px"></asp:textbox></TD>
								</TR>
								<!--<TR>
										<TD class="TDBGColor1">Nama Analis</TD>
										<TD>:</TD>
										<TD class="TDBGColorValue"><asp:textbox id="Textbox2" runat="server" Width="175px" ReadOnly="True"></asp:textbox></TD>
									</TR>--></TABLE>
						</TD>
					</TR>
				</TABLE>
				<table id="Table5" cellSpacing="0" cellPadding="0" width="100%">
					<tr>
						<td align="center"><asp:button id="BTN_UPDATE" Text="Update Status" Runat="server" CssClass="button1" onclick="BTN_UPDATE_Click"></asp:button></td>
					</tr>
					<tr>
						<td align="center"><asp:placeholder id="PlaceHolder1" runat="server"></asp:placeholder><asp:label id="lbl_regno" runat="server" Visible="False"></asp:label><asp:label id="lbl_curef" runat="server" Visible="False"></asp:label></td>
					</tr>
				</table>
				<table id="Table41" cellSpacing="0" cellPadding="0" width="100%">
					<tr>
						<td align="center"><asp:placeholder id="Placeholder2" runat="server"></asp:placeholder>
							<asp:label id="lbl_regnum" runat="server" Visible="False"></asp:label>
							<asp:label id="lbl_regnum2" runat="server" Visible="False"></asp:label>
							<asp:label id="lbl_rekananref" runat="server" Visible="False"></asp:label>
							<asp:label id="lbl_rekananref2" runat="server" Visible="False"></asp:label>
							<asp:label id="txt_score" runat="server" Visible="False"></asp:label>
						</td>
					</tr>
				</table>
				<table id="Table4" cellSpacing="0" cellPadding="0" width="100%">
					<tr>
						<!--../dataentry/custproduct.aspx?regno=<%=Request.QueryString["regno"]%>&curef=<%=Request.QueryString["curef"]%>&sta=view-->
						<td align="center"><iframe id="if2" name="if2" src="" width="100%" scrolling="auto" height="650"></iframe>
						</td>
					</tr>
				</table>
			</center>
		</form>
	</body>
</HTML>
