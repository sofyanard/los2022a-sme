<%@ Page language="c#" Codebehind="SetorJamDataComplet.aspx.cs" AutoEventWireup="True" Inherits="SME.DCM.DataCompleteness.Trade.SetorJamDataComplet" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>LCDataComplet</TITLE>
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
				<asp:label id="Label33" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server"
					Visible="False">Label</asp:label>
				<TABLE width="100%" border="0">
					<TR>
						<TD align="left">
							<TABLE id="Table1">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Setoran Jaminan</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../../../Body.aspx"><IMG src="../../../Image/MainMenu.jpg"></A><A href="../../../Logout.aspx" target="_top"><IMG src="../../../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">General&nbsp;Data</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_CIF" runat="server">CIF # :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CIF" runat="server" Width="100%" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_NAME" runat="server">Customer Name :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NAME" runat="server" Width="100%" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_JNS_VALUTA" runat="server">Jenis Valuta :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_JNS_VALUTA" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_NILAI_SETORJAM" runat="server">Nilai Setoran Jaminan :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NILAI_SETORJAM" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_MM_TGLSETORJAM" runat="server">Tgl. Setoran Jaminan :</asp:label></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return numbersonly()" id="TXT_DD_TGLSETORJAM" runat="server" Columns="2"
											MaxLength="2" CssClass="pl"></asp:textbox>
										<asp:dropdownlist id="DDL_MM_TGLSETORJAM" runat="server" CssClass="pl"></asp:dropdownlist>
										<asp:textbox onkeypress="return numbersonly()" id="TXT_YY_TGLSETORJAM" runat="server" Columns="4"
											MaxLength="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_MM_TGLBLOKIR" runat="server">Tgl. Blokir :</asp:label></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return numbersonly()" id="TXT_DD_TGLBLOKIR" runat="server" Columns="2"
											MaxLength="2" CssClass="pl"></asp:textbox>
										<asp:dropdownlist id="DDL_MM_TGLBLOKIR" runat="server" CssClass="pl"></asp:dropdownlist>
										<asp:textbox onkeypress="return numbersonly()" id="TXT_YY_TGLBLOKIR" runat="server" Columns="4"
											MaxLength="4"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_JENISBLOKIR" runat="server">Jenis Blokir :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_JENISBLOKIR" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_NILAIBLOKIR" runat="server"> Nilai Blokir :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NILAIBLOKIR" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_GOLONGANPMLK" runat="server"> Golongan Pemilik :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_GOLONGANPMLK" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_HUBDGNBANK" runat="server">Hubungan Dengan Bank :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_HUBDGNBANK" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_TUJUANBERHUBDGNBANK" runat="server">Tujuan Berhubungan dgn Bank :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_TUJUANBERHUBDGNBANK" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_STATUSPEMILIK" runat="server"> Status Pemilik :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_STATUSPEMILIK" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR align="center">
						<TD class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2">
							<asp:button id="BTN_SAVE" runat="server" Width="76px" Text="SAVE" CssClass="Button1"></asp:button>&nbsp;&nbsp;
							<asp:button id="BTN_CLEAR" runat="server" Width="76px" Text="CLEAR" CssClass="Button1"></asp:button>
							<!--<asp:button id="BTN_UPDATE" runat="server" Width="121px" Text="UPDATE STATUS" CssClass="Button1"></asp:button>-->
						</TD>
					</TR>
				</TABLE>
			</CENTER>
		</FORM>
	</BODY>
</HTML>
