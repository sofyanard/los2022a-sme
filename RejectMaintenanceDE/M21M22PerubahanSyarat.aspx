<%@ Page language="c#" Codebehind="M21M22PerubahanSyarat.aspx.cs" AutoEventWireup="True" Inherits="SME.RejectMaintenanceDE.M21M22PerubahanSyarat" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>M21M22PerubahanSyarat</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_mandatoryOnly.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
				<TR>
					<TD class="tdHeader1" colSpan="2">Informasi Loan
						<asp:label id="LBL_REGNO" runat="server" Visible="False"></asp:label><asp:label id="LBL_CUREF" runat="server" Visible="False"></asp:label><asp:label id="LBL_PRODID" runat="server" Visible="False"></asp:label><asp:label id="LBL_APPTYPE" runat="server" Visible="False"></asp:label>
						<asp:label id="LBL_PROD_SEQ" runat="server" Visible="False"></asp:label></TD>
				</TR>
				<TR>
					<TD class="td" vAlign="top" width="50%">
						<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 129px">Jenis Pengajuan</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue"><asp:textbox id="TXT_APPTYPE" runat="server" Width="175px" ReadOnly="True"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 129px">Jenis Kredit</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue"><asp:textbox id="TXT_PRODUCTDESC" runat="server" Width="175px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 129px">
									Pembentukan</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue"><asp:textbox id="TXT_REVOLVING" runat="server" Width="175px" ReadOnly="True"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 129px">AA No.</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue">
									<asp:textbox id="TXT_AA_NO" runat="server" Width="175px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 129px">No. Rekening</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue">
									<asp:textbox id="TXT_FACILITYNO" runat="server" Width="175px"></asp:textbox></TD>
							</TR>
						</TABLE>
					</TD>
					<TD class="td" vAlign="top" width="50%">
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 129px">Keterangan</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue"><asp:textbox id="TXT_CP_NOTES" runat="server" Width="100%" Height="135px" TextMode="MultiLine"></asp:textbox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR id="tr" runat="server">
					<TD class="TDBGColor2" align="center" colSpan="2"><asp:button id="BTN_Save" runat="server" CssClass="Button1" Text="Save" onclick="BTN_Save_Click"></asp:button></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
