<%@ Page language="c#" Codebehind="EarmarkMain.aspx.cs" AutoEventWireup="True" Inherits="SME.BGSpan.EarmarkLimitFasilitas.EarmarkMain" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>EarmarkMain</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY>
		<form id="Form1" method="post" runat="server">
			<center>
				<table id="Table1" cellSpacing="0" cellPadding="0" width="100%">
					<tr>
						<td style="WIDTH: 495px">
							<TABLE id="Table4">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Earmark</B></TD>
								</TR>
							</TABLE>
						</td>
						<td class="tdNoBorder" align="right"><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="../../Image/back.jpg"></asp:imagebutton><A href=".../../Body.aspx"><IMG src="../../Image/MainMenu.jpg"></A><A href="../../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A></td>
					</tr>
					<tr>
						<td class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></td>
					</tr>
					<tr>
						<td class="tdHeader1" width="50%" colSpan="2">Customer Info</td>
					</tr>
				</table>
				<table id="Table2" cellSpacing="0" cellPadding="0" width="100%">
					<tr>
						<td align="center">
							<!-- <iframe id=if1 style="WIDTH: 100%; HEIGHT: 185px" name=if1 src="/SME/BGSpan/appinfo.aspx?regno=<%=Request.QueryString["regno"]%>&amp;curef=<%=Request.QueryString["curef"]%>&amp;sta=view" scrolling=no> </iframe>
						--></td>
					</tr>
				</table>
				<TR id="TR_INFO_CRM" runat="server">
					<TD width="100%" vAlign="top">
						<TABLE id="Table9" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR>
								<TD class="tdheader1">Transaction Info</TD>
							</TR>
							<TR>
								<TD><asp:textbox id="txt_acqinfo" Width="100%" Runat="server" ReadOnly="True" TextMode="MultiLine"
										Height="150"></asp:textbox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				</TABLE>
				<table id="Table3" cellSpacing="2" cellPadding="2" width="100%">
					<tr>
						<td vAlign="top"><asp:table id="tbl_prod" runat="server" Width="100%" CssClass="BackGroundList" CellSpacing="0"
								CellPadding="0"></asp:table><br>
							<br>
							&nbsp;
							<BR>
						</td>
						<td align="right"><iframe id="if2" style="WIDTH: 800px; HEIGHT: 300px" name="if2" src="" frameBorder="no"
								scrolling="auto"></iframe>
						</td>
					</tr>
				</table>
				<table id="Table5" cellSpacing="2" cellPadding="2" width="100%">
					<tr>
						<td class="tdHeader1" width="50%" colSpan="2">EARMARK</td>
					</tr>
					<tr>
						<td width="50%">
							<table width="100%">
								<TR>
									<TD class="TDBGColor1">Nomor BG:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NO_BG" runat="server" Width="200px" Height="24px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_TGLBG" runat="server">Tanggal BG:</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGLBG_DAY" runat="server" Width="24px"
											Columns="4" MaxLength="2"></asp:textbox><asp:dropdownlist id="DDL_TGLBG_MONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_TGLBG_YEAR" runat="server" Width="36px"
											Columns="4" MaxLength="4"></asp:textbox></TD>
								</TR>
							</table>
						</td>
						<td>
							<table width="100%">
								<TR>
									<TD class="TDBGColor1">Nominal Penerbitan:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NOTERBIT" runat="server" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Outstanding Limit:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_LIMIT" runat="server" BorderStyle="None"></asp:textbox></TD>
								</TR>
							</table>
						</td>
					</tr>
					<tr>
						<TD class="TDBGColor2" vAlign="top" align="center" colSpan="2" height="10"><asp:button id="BTN_SAVE" runat="server" Width="100px" CssClass="button1" Text="SAVE"></asp:button>&nbsp;&nbsp;&nbsp;
						</TD>
					</tr>
				</table>
			</center>
		</form>
	</BODY>
</HTML>
