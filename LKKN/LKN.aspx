<%@ Page language="c#" Codebehind="LKN.aspx.cs" AutoEventWireup="True" Inherits="SME.LKKN1.LKN" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Laporan Kunjungan Nasabah</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_mandatory.html" -->
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE cellSpacing="1" cellPadding="1" width="100%">
					<TR>
						<TD class="tdNoBorder" style="WIDTH: 669px" align="center"></TD>
						<TD class="tdNoBorder" align="center" colSpan="2" style="WIDTH: 742px"><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg" align="right"></A><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg" align="right"></A></TD>
						<TD class="tdNoBorder" style="WIDTH: 669px" align="center">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 669px" align="center"></TD>
						<TD class="tdHeader1" style="WIDTH: 742px" align="center" colSpan="2">LAPORAN 
							KUNJUNGAN NASABAH</TD>
						<TD style="WIDTH: 669px" align="center"></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 669px" vAlign="top" align="center">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<FONT face="Tahoma" size="2">&nbsp;
							</FONT>
						</TD>
						<TD vAlign="top" align="center" colSpan="2" style="WIDTH: 80%">
							<TABLE class="td" id="Table1" width="100%" style="HEIGHT: 298px">
								<TR>
									<TD style="WIDTH: 272px; HEIGHT: 24px"><b><FONT face="Tahoma" size="2"> Nama Calon/Nasabah 
												yang dikunjungi</FONT></b></TD>
									<TD style="HEIGHT: 24px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 24px">
										<asp:textbox id="TXT_CUST_NAME" runat="server" Width="200px" MaxLength="100" Font-Size="X-Small"
											ForeColor="Blue"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 272px; HEIGHT: 24px" vAlign="top"><b><FONT face="Tahoma" size="2"> Alamat 
												kunjungan</FONT></b></TD>
									<TD style="HEIGHT: 24px" vAlign="top">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 24px" vAlign="top">
										<asp:TextBox id="TXT_ADDR" runat="server" Width="98%" TextMode="MultiLine" Rows="5" Font-Size="X-Small"
											ForeColor="Blue"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 272px"><b><FONT face="Tahoma" size="2"> Tanggal kunjungan</FONT></b></TD>
									<TD>:</TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_LKN_DAY" runat="server" Columns="4" Width="35px" MaxLength="2" Font-Size="X-Small"
											ForeColor="Blue" CssClass="mandatory"></asp:textbox>
										<asp:dropdownlist id="DDL_LKN_MONTH" runat="server" Font-Size="X-Small" ForeColor="Blue" CssClass="mandatory"></asp:dropdownlist>
										<asp:textbox id="TXT_LKN_YEAR" runat="server" Columns="4" Width="70px" MaxLength="4" Font-Size="X-Small"
											ForeColor="Blue" CssClass="mandatory"></asp:textbox>
										<asp:Label id="TXT_LKNDATE" runat="server" ForeColor="White" Visible="False"></asp:Label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 272px"><b><FONT face="Tahoma" size="2"> Tujuan kunjungan</FONT></b></TD>
									<TD>:</TD>
									<TD>
										<P><FONT face="Tahoma" size="2">(beri tanda [x] pada kolom yang sesuai)</FONT>
										</P>
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 272px">
										<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ForeColor="White" ControlToValidate="RBL_LKN_PURPOSE"
											ErrorMessage="Tujuan Kunjungan"></asp:RequiredFieldValidator></TD>
									<TD></TD>
									<TD>
										<P>
											<asp:radiobuttonlist id="RBL_LKN_PURPOSE" runat="server" ForeColor="Black" Font-Size="X-Small" Width="100%"
												CssClass="mandatory" RepeatLayout="Flow">
												<asp:ListItem Value="1">Prospek calon nasabah</asp:ListItem>
												<asp:ListItem Value="2">Pemohon kredit baru</asp:ListItem>
												<asp:ListItem Value="3">Perpanjangan kredit</asp:ListItem>
												<asp:ListItem Value="4">Penagihan kredit</asp:ListItem>
												<asp:ListItem Value="5">Review kredit</asp:ListItem>
												<asp:ListItem Value="6">lainnya</asp:ListItem>
											</asp:radiobuttonlist></P>
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 272px; HEIGHT: 26px" vAlign="top"></TD>
									<TD style="HEIGHT: 26px" vAlign="top"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 26px" vAlign="top" align="left">
										<P>&nbsp;&nbsp;&nbsp;&nbsp;
											<asp:textbox id="TXT_LKN_PURPOSELAIN" runat="server" ForeColor="Blue" Font-Size="X-Small" MaxLength="100"
												Width="208px"></asp:textbox>&nbsp;</P>
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 272px"><b><FONT face="Tahoma" size="2"> Nama officer yang dikunjungi</FONT></b></TD>
									<TD>:</TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_LKN_OFFICER" runat="server" Width="224px" MaxLength="100" Font-Size="X-Small"
											ForeColor="Blue" CssClass="mandatory"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD style="WIDTH: 669px" vAlign="top" align="center"></TD>
					</TR>
				</TABLE>
				<TABLE cellSpacing="2" cellPadding="2" width="80%" align="center" border="0">
					<TR>
						<TD align="center" width="100%">
							<TABLE id="Table2" style="WIDTH: 563px; HEIGHT: 125px" cellSpacing="0" cellPadding="0"
								width="563" border="0">
								<TR>
									<TD style="WIDTH: 362px; HEIGHT: 23px"></TD>
									<TD align="center" style="HEIGHT: 23px"><FONT face="Tahoma" size="2">Tanda tangan,</FONT></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 362px; HEIGHT: 78px">
										<asp:ValidationSummary id="ValidationSummary1" runat="server" ShowSummary="False" ShowMessageBox="True"
											HeaderText="Anda belum mengisi "></asp:ValidationSummary></TD>
									<TD style="HEIGHT: 78px"></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 362px"></TD>
									<TD align="center"><FONT face="Tahoma" size="2">(</FONT>
										<asp:textbox id="TXT_CALONNASABAH" runat="server" MaxLength="100" Width="173px" Font-Size="X-Small"
											ForeColor="Blue"></asp:textbox>&nbsp;<FONT face="Tahoma" size="2">)</FONT></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					</TR>
					<tr>
						<td width="100%" align="center">
							<asp:button id="SaveBtn" runat="server" CssClass="Button1" Text="Save All" onclick="SaveBtn_Click"></asp:button>&nbsp;
							<asp:button id="PrintBtn" runat="server" CssClass="Button1" Text="Print" onclick="PrintBtn_Click"></asp:button>&nbsp;
						</td>
					</tr>
				</TABLE>
		</form>
		</CENTER>
	</body>
</HTML>
