<%@ Page language="c#" Codebehind="KewajibanSpotDerivDataComplet.aspx.cs" AutoEventWireup="True" Inherits="SME.DCM.DataCompleteness.Treasury.KewajibanSpotDerivDataComplet" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>AccountDataComplet</TITLE>
		<META content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../Style.css" type="text/css" rel="stylesheet">
		<STYLE type="text/css">.pl { MARGIN-RIGHT: 3px }
		</STYLE>
	</HEAD>
	<BODY MS_POSITIONING="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<CENTER>
				<TABLE width="100%" border="0">
					<TR>
						<TD align="left">
							<TABLE id="Table1">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B> Data Kewajiban Spot 
											&amp; Derivatif</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../../../Body.aspx"><IMG src="../../../Image/MainMenu.jpg"></A><A href="../../../Logout.aspx" target="_top"><IMG src="../../../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">General Data</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_CIF" runat="server">CIF# :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CIF" runat="server" Width="100%" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_CUSTNAME" runat="server">Customer Name :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CUSTNAME" runat="server" width="100%" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_NO_TRANSAKSI" runat="server">Nomor Referensi Transaksi :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NO_TRANSAKSI" runat="server" width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_JENIS" runat="server">Jenis :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_JENIS" runat="server" width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_KONTRAK" runat="server">Kontrak :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_KONTRAK" runat="server" width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_JNSVALUTA" runat="server">Jenis Valuta :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_JNSVALUTA" runat="server" width="100%"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_UNDERLYINGVAR" runat="server">Underlying Variable :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_UNDERLYINGVAR" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_GOLPHKLAWAN" runat="server">Golongan Pihak Lawan :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_GOLPHKLAWAN" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_HUBDGNBANK" runat="server">Hubungan Dengan Bank :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_HUBDGNBANK" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_STTSPHKLAWAN" runat="server">Status Pihak Lawan :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_STTSPHKLAWAN" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_NGRPHKLAWAN" runat="server">Negara Pihak Lawan :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_NGRPHKLAWAN" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" align="center" colSpan="2">
							<asp:button id="BTN_SAVE" CssClass="button1" Text="SAVE" Runat="server"></asp:button>&nbsp;&nbsp;
							<asp:button id="BTN_CLR" Width="68px" CssClass="button1" Text="CLEAR" Runat="server"></asp:button>
						</TD>
					</TR>
				</TABLE>
			</CENTER>
		</FORM>
	</BODY>
</HTML>
