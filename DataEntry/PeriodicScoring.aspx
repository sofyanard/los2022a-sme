<%@ Page language="c#" Codebehind="PeriodicScoring.aspx.cs" AutoEventWireup="True" Inherits="SME.DataEntry.PeriodicScoring" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PeriodicScoring</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include  file="../include/cek_all.html" -->
		<!-- #include file="../include/popup.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
				<tr>
					<td class="tdHeader1" align="center" width="100%" colSpan="2"><asp:textbox id="TXT_CP_CUREF" runat="server" Visible="False" Width="61px"></asp:textbox><asp:label id="LBL_APPTYPE" runat="server" Visible="False"></asp:label><asp:label id="LBL_REGNO" runat="server" Visible="False"></asp:label><asp:label id="LBL_PRODID" runat="server" Visible="False"></asp:label><asp:label id="LBL_PRODUCT" runat="server" Font-Bold="True"></asp:label><asp:label id="LBL_RATENO" runat="server" Visible="False"></asp:label><asp:label id="LBL_PROD_SEQ" runat="server" Visible="False"></asp:label></td>
				</tr>
				<TR>
					<TD vAlign="top" width="50%">
						<FIELDSET>
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="170">Jenis Pengajuan</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_APPTYPE" runat="server" Width="300px" ReadOnly="True"
											BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="170">Jenis Kredit</TD>
									<TD style="WIDTH: 1px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PRODUCT" runat="server" Width="300px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="170">Pembentukan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_REVOLVING" runat="server" Width="300px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="170">Limit
									</TD>
									<TD style="WIDTH: 1px"></TD>
									<TD class="TDBGColorValue">
										<asp:label id="LBL_CURRENCY" runat="server"></asp:label>&nbsp;
										<asp:textbox onkeypress="return numbersonly()" id="TXT_CP_LIMIT" runat="server" Width="300px"
											ReadOnly="True" BorderStyle="None" CssClass="angka" MaxLength="15"></asp:textbox>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="170">Tenor</TD>
									<TD style="WIDTH: 1px; HEIGHT: 12px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_OLDTENOR" runat="server" ReadOnly="True" CssClass="angka" MaxLength="3"
											Columns="3">0</asp:textbox>&nbsp;
										<asp:label id="LBL_OLDTENOR" runat="server"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tujuan Penggunaan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CP_LOANPURPOSE" runat="server" Width="280px" Enabled="False"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</FIELDSET>
					</TD>
					<TD vAlign="top" width="50%">
						<FIELDSET>
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="170">Keterangan
										<asp:dropdownlist id="DDL_CP_NOREK" runat="server" Visible="False" CssClass="mandatory" Enabled="False"></asp:dropdownlist><asp:textbox id="TXT_CP_NOREK" runat="server" Width="176px" ReadOnly="True" MaxLength="2" Columns="4"
											Visible="False"></asp:textbox>
									</TD>
									<TD style="WIDTH: 3px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CP_KETERANGAN" runat="server" Width="250px"
											CssClass="" Height="65px" TextMode="MultiLine"></asp:textbox></TD>
								</TR>
							</TABLE>
						</FIELDSET>
						<asp:checkbox id="CHECK_IDC" runat="server" Visible="False" Font-Bold="True" AutoPostBack="True"
							Text="IDC"></asp:checkbox></TD>
				</TR>
				<tr>
					<td class="tdbgcolor2" colSpan="2"><asp:button id="update" runat="server" Width="100px" CssClass="Button1" Text="Save" onclick="update_Click"></asp:button></td>
				</tr>
			</TABLE>
		</form>
		</SCRIPT>
	</body>
</HTML>
