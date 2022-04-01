<%@ Page language="c#" Codebehind="LOWM21M22PerubahanSyarat.aspx.cs" AutoEventWireup="True" Inherits="SME.LOW.LOWM21M22PerubahanSyarat" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>LOWM21M22PerubahanSyarat</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_mandatoryOnly.html" -->
		<!-- #include file="../include/cek_entries.html" -->
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
								<TD class="TDBGColorValue"><asp:textbox id="TXT_APPTYPE" runat="server" Width="300px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 129px">Jenis Kredit</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue"><asp:textbox id="TXT_PRODUCTDESC" onkeypress="return kutip_satu()" runat="server" Width="300px"
										ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 129px">
									Pembentukan</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue"><asp:textbox id="TXT_REVOLVING" onkeypress="return kutip_satu()" runat="server" Width="300px"
										ReadOnly="True" AutoPostBack="True" BorderStyle="None"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 129px">AA No.</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_AA_NO" runat="server" AutoPostBack="True" CssClass="mandatory" Enabled="False"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD>&nbsp;</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Limit</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue"><asp:textbox id="TXT_LIMIT" runat="server" ReadOnly="True" Width="300px" BorderStyle="None" MaxLength="15"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Tenor</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue"><asp:textbox id="TXT_TENORDESC" runat="server" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Tujuan Penggunaan</TD>
								<TD></TD>
								<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CP_LOANPURPOSE" runat="server" Width="280px"></asp:dropdownlist></TD>
							</TR>
						</TABLE>
					</TD>
					<TD class="td" vAlign="top" width="50%">
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 129px">Keterangan</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue"><asp:textbox id="TXT_CP_NOTES" runat="server" Width="100%" CssClass="mandatory" Height="135px"
										onkeypress="return kutip_satu()" TextMode="MultiLine"></asp:textbox></TD>
							</TR>
						</TABLE>
						<asp:dropdownlist id="DDL_FACILITYNO" runat="server" AutoPostBack="True" Enabled="False" Visible="False"></asp:dropdownlist>
					</TD>
				</TR>
				<TR id="TR_STATUS" runat="server">
					<TD class="TDBGColor2" align="center" colSpan="2">
						<asp:Label ID="labelStatus" Runat="Server" Font-Bold="True" Font-Names="Arial" Font-Size="Medium"
							ForeColor="Red"></asp:Label>
					</TD>
				</TR>
				<TR id="tr" runat="server">
					<TD class="TDBGColor2" align="center" colSpan="2"><asp:button id="BTN_Save" runat="server" CssClass="Button1" Text="Save"></asp:button></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
