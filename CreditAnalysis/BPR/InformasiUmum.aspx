<%@ Page language="c#" Codebehind="InformasiUmum.aspx.cs" AutoEventWireup="True" Inherits="SME.CreditAnalysis.BPR.InformasiUmum" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>InformasiUmum</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../../include/onepost.html" -->
		<!-- #include file="../../include/ConfirmBox.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table2" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px">
					<TR>
						<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Credit Analysis : 
								Informasi Umum</B></TD>
					</TR>
				</TABLE>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder"><!--<img src="../Image/HeaderDetailDataEntry.jpg">--></TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">INFORMASI UMUM NASABAH</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px; HEIGHT: 17px">App #</TD>
									<TD style="WIDTH: 15px; HEIGHT: 17px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_AP_REGNO" runat="server" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Ref #</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_REF" runat="server" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tanggal Aplikasi</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_AP_SIGNDATE" runat="server" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Sub-Segment/Program</TD>
									<TD></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_PROGRAMDESC" runat="server" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Cabang/CBC/Group</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_BRANCH_NAME" runat="server" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Team Leader</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TextBox5" runat="server" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Relationship Manager</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_AP_RELMNGR" runat="server" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Analis Business Unit</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TextBox7" runat="server" ReadOnly="True"></asp:textbox></TD>
								</TR> <!-- Additional Field : Right --></TABLE>
						</TD>
						<TD class="td" vAlign="top">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="150">
										<P>Nama Pemohon</P>
									</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="txtName" runat="server" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" vAlign="top" width="150">Alamat</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
										<P><asp:textbox id="txtAddr1" runat="server" ReadOnly="True"></asp:textbox><asp:textbox id="txtAddr2" runat="server" ReadOnly="True"></asp:textbox><asp:textbox id="txtAddr3" runat="server" ReadOnly="True"></asp:textbox></P>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="150">Kota</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="txtCity" runat="server" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="150">No. Telp.</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="txtTelp" runat="server" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nama Usaha</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="txtBussType" runat="server" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Business Unit</TD>
									<TD></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="txtBussUnitDesc" runat="server" ReadOnly="True"></asp:textbox></TD>
								</TR> <!-- 14 --> <!-- 21 --> <!-- Additional Field : Right --></TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2"><asp:button id="BTN_UPDATESTATUS" runat="server" Text="Update Status" CssClass="Button1" onclick="BTN_UPDATESTATUS_Click"></asp:button>&nbsp;</TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
