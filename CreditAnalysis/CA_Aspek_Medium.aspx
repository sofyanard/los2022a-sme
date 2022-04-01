<%@ Page language="c#" Codebehind="CA_Aspek_Medium.aspx.cs" AutoEventWireup="True" Inherits="TestSME.CreditAnalysis.CA_Aspek_Middle" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CA_Aspek_Middle</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
				<TR>
					<TD class="tdNoBorder"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
						<TABLE id="Table6">
							<TR>
								<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Credit Analysis&nbsp;: 
										Aspek - Aspek</B></TD>
							</TR>
						</TABLE>
					</TD>
					<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="../Image/back.jpg"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
				</TR>
				<TR>
					<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
				</TR>
				<TR>
					<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="SubMenu" runat="server"></asp:placeholder></TD>
				</TR>
				<TR>
					<TD class="tdHeader1" colSpan="2">ASPEK LEGALITAS</TD>
				</TR>
				<TR>
					<TD class="td" width="100%" colSpan="2">
						<table width="100%" border="1">
							<tr>
								<td class="tdHeader1" width="75%" colSpan="2">Legalitas</td>
								<td class="tdHeader1" width="25%">Catatan</td>
							</tr>
							<tr>
								<td style="BORDER-RIGHT: #ffffff 1px groove; BORDER-TOP: #ffffff 1px groove; PADDING-LEFT: 10px; BORDER-LEFT: #ffffff 1px groove; COLOR: black; BORDER-BOTTOM: #ffffff 1px groove; BACKGROUND-COLOR: #e5ebf4; TEXT-ALIGN: left"
									width="50%">Legalitas Mandiri Perusahaan</td>
								<td width="25%"><asp:radiobutton id="OPT_LPM1" runat="server" Checked="True" Text="Sah"></asp:radiobutton>&nbsp;&nbsp;&nbsp;<asp:radiobutton id="OPT_LPM2" runat="server" Text="Tidak Sah"></asp:radiobutton></td>
								<td width="25%"><asp:textbox id="TXT_LPM" runat="server" Width="100%"></asp:textbox></td>
							</tr>
							<!-- -->
							<tr>
								<td style="BORDER-RIGHT: #ffffff 1px groove; BORDER-TOP: #ffffff 1px groove; PADDING-LEFT: 10px; BORDER-LEFT: #ffffff 1px groove; COLOR: black; BORDER-BOTTOM: #ffffff 1px groove; BACKGROUND-COLOR: #e5ebf4; TEXT-ALIGN: left"
									width="50%">Legalitas Usaha (Ijin-ijin)</td>
								<td width="25%"><asp:radiobutton id="OPT_LUI1" runat="server" Checked="True" Text="Sah"></asp:radiobutton>&nbsp;&nbsp;&nbsp;
									<asp:radiobutton id="OPT_LUI2" runat="server" Text="Tidak Sah"></asp:radiobutton></td>
								<td width="25%"><asp:textbox id="TXT_LUI" runat="server" Width="100%"></asp:textbox></td>
							</tr>
							<!-- -->
							<tr>
								<td style="BORDER-RIGHT: #ffffff 1px groove; BORDER-TOP: #ffffff 1px groove; PADDING-LEFT: 10px; BORDER-LEFT: #ffffff 1px groove; COLOR: black; BORDER-BOTTOM: #ffffff 1px groove; BACKGROUND-COLOR: #e5ebf4; TEXT-ALIGN: left"
									width="50%">Legalitas Pemohon</td>
								<td width="25%"><asp:radiobutton id="OPT_LP1" runat="server" Checked="True" Text="Sah"></asp:radiobutton>&nbsp;&nbsp;&nbsp;<asp:radiobutton id="OPT_LP2" runat="server" Text="Tidak Sah"></asp:radiobutton></td>
								<td width="25%"><asp:textbox id="TXT_LP" runat="server" Width="100%"></asp:textbox></td>
							</tr>
							<!-- -->
							<tr>
								<td style="BORDER-RIGHT: #ffffff 1px groove; BORDER-TOP: #ffffff 1px groove; PADDING-LEFT: 10px; BORDER-LEFT: #ffffff 1px groove; COLOR: black; BORDER-BOTTOM: #ffffff 1px groove; BACKGROUND-COLOR: #e5ebf4; TEXT-ALIGN: left"
									width="50%">Legalitas Kontrak Kerja</td>
								<td style="BORDER-RIGHT: #ffffff 1px groove; BORDER-TOP: #ffffff 1px groove; BORDER-LEFT: #ffffff 1px groove; COLOR: black; BORDER-BOTTOM: #ffffff 1px groove; BACKGROUND-COLOR: white"
									width="25%"><asp:radiobutton id="OPT_LKK1" runat="server" Checked="True" Text="Sah"></asp:radiobutton>&nbsp;&nbsp;&nbsp;<asp:radiobutton id="OPT_LKK2" runat="server" Text="Tidak Sah"></asp:radiobutton></td>
								<td width="25%"><asp:textbox id="TXT_LKK" runat="server" Width="100%"></asp:textbox></td>
							</tr>
						</table>
					</TD>
				</TR>
				<!-- SEPARATOR -------------------------->
				<TR>
					<TD colSpan="2">&nbsp;</TD>
				</TR>
				<TR>
					<TD class="tdHeader1" colSpan="2">PENJELASAN ASPEK LEGAL</TD>
				</TR>
				<TR>
					<TD class="td" vAlign="top" align="center" width="50%" colSpan="2"><asp:textbox id="Textbox4" runat="server" Columns="125" Rows="15" TextMode="MultiLine"></asp:textbox></TD>
				</TR>
				<TR>
					<td colSpan="2">&nbsp;</td>
				</TR>
				<!-- separator ---------------------------->
				<% if (Request.QueryString["industry"]=="yes") { %>
				<TR>
					<TD class="td" align="center" width="100%" colSpan="2">
						<table width="100%" border="1">
							<tr>
								<td style="BORDER-RIGHT: #ffffff 1px groove; BORDER-TOP: #ffffff 1px groove; BORDER-LEFT: #ffffff 1px groove; COLOR: black; BORDER-BOTTOM: #ffffff 1px groove; BACKGROUND-COLOR: #e5ebf4; TEXT-ALIGN: left"
									width="100%" colSpan="2"><b>Industri Review</b></td>
							</tr>
							<tr>
								<td style="BORDER-RIGHT: #ffffff 1px groove; BORDER-TOP: #ffffff 1px groove; PADDING-LEFT: 10px; BORDER-LEFT: #ffffff 1px groove; COLOR: black; BORDER-BOTTOM: #ffffff 1px groove; HEIGHT: 31px; BACKGROUND-COLOR: #e5ebf4"
									width="25%">Manajemen Quality</td>
								<td width="75%" style="HEIGHT: 31px">
									<asp:DropDownList id="DDL_MQUALITY" runat="server" AutoPostBack="True" Width="100%" onselectedindexchanged="DDL_MQUALITY_SelectedIndexChanged"></asp:DropDownList><BR>
									<asp:TextBox id="TXT_MQUALITY" runat="server" Width="100%" TextMode="MultiLine" Height="60px"></asp:TextBox></td>
							</tr>
							<tr>
								<td style="BORDER-RIGHT: #ffffff 1px groove; BORDER-TOP: #ffffff 1px groove; PADDING-LEFT: 10px; BORDER-LEFT: #ffffff 1px groove; COLOR: black; BORDER-BOTTOM: #ffffff 1px groove; BACKGROUND-COLOR: #e5ebf4"
									width="25%">Information Disclosure</td>
								<td width="75%">
									<asp:DropDownList id="DDL_INFDISCLOSURE" runat="server" Width="100%" AutoPostBack="True" onselectedindexchanged="DDL_INFDISCLOSURE_SelectedIndexChanged"></asp:DropDownList><BR>
									<asp:TextBox id="TXT_INFDISCLOSURE" runat="server" Width="100%" TextMode="MultiLine" Height="60px"></asp:TextBox></td>
							</tr>
							<tr>
								<td style="BORDER-RIGHT: #ffffff 1px groove; BORDER-TOP: #ffffff 1px groove; PADDING-LEFT: 10px; BORDER-LEFT: #ffffff 1px groove; COLOR: black; BORDER-BOTTOM: #ffffff 1px groove; HEIGHT: 16px; BACKGROUND-COLOR: #e5ebf4"
									width="25%">Company/Group Reputation</td>
								<td width="75%">
									<asp:DropDownList id="DDL_COMPGROUP" runat="server" Width="100%" AutoPostBack="True" onselectedindexchanged="DDL_COMPGROUP_SelectedIndexChanged"></asp:DropDownList><BR>
									<asp:TextBox id="TXT_COMPGROUP" runat="server" Width="100%" TextMode="MultiLine" Height="60px"></asp:TextBox></td>
							</tr>
							<tr>
								<td style="BORDER-RIGHT: #ffffff 1px groove; BORDER-TOP: #ffffff 1px groove; PADDING-LEFT: 10px; BORDER-LEFT: #ffffff 1px groove; COLOR: black; BORDER-BOTTOM: #ffffff 1px groove; BACKGROUND-COLOR: #e5ebf4"
									width="25%">Capital Support Guarantee</td>
								<td width="75%">
									<asp:DropDownList id="DDL_CAPSUPPORT" runat="server" Width="100%" AutoPostBack="True" onselectedindexchanged="DDL_CAPSUPPORT_SelectedIndexChanged"></asp:DropDownList><BR>
									<asp:TextBox id="TXT_CAPSUPPORT" runat="server" Width="100%" TextMode="MultiLine" Height="60px"></asp:TextBox></td>
							</tr>
							<tr>
								<td style="BORDER-RIGHT: #ffffff 1px groove; BORDER-TOP: #ffffff 1px groove; BORDER-LEFT: #ffffff 1px groove; COLOR: black; BORDER-BOTTOM: #ffffff 1px groove; BACKGROUND-COLOR: #e5ebf4; TEXT-ALIGN: left"
									width="100%" colSpan="2"><b>Business Outlook</b></td>
							</tr>
							<tr>
								<td style="BORDER-RIGHT: #ffffff 1px groove; BORDER-TOP: #ffffff 1px groove; PADDING-LEFT: 10px; BORDER-LEFT: #ffffff 1px groove; COLOR: black; BORDER-BOTTOM: #ffffff 1px groove; HEIGHT: 16px; BACKGROUND-COLOR: #e5ebf4"
									width="25%">Market Share</td>
								<td style="HEIGHT: 16px" width="75%">
									<asp:DropDownList id="DDL_MARKETSHR" runat="server" Width="100%" AutoPostBack="True" onselectedindexchanged="DDL_MARKETSHR_SelectedIndexChanged"></asp:DropDownList><BR>
									<asp:TextBox id="TXT_MARKETSHR" runat="server" Width="100%" TextMode="MultiLine" Height="60px"></asp:TextBox></td>
							</tr>
							<tr>
								<td style="BORDER-RIGHT: #ffffff 1px groove; BORDER-TOP: #ffffff 1px groove; PADDING-LEFT: 10px; BORDER-LEFT: #ffffff 1px groove; COLOR: black; BORDER-BOTTOM: #ffffff 1px groove; HEIGHT: 18px; BACKGROUND-COLOR: #e5ebf4"
									width="25%">Product Competitiveness</td>
								<td style="HEIGHT: 18px" width="75%">
									<asp:DropDownList id="DDL_PRODCOMPTIVE" runat="server" Width="100%" AutoPostBack="True" onselectedindexchanged="DDL_PRODCOMPTIVE_SelectedIndexChanged"></asp:DropDownList><BR>
									<asp:TextBox id="TXT_PRODCOMPTIVE" runat="server" Width="100%" TextMode="MultiLine" Height="60px"></asp:TextBox></td>
							</tr>
							<tr>
								<td style="BORDER-RIGHT: #ffffff 1px groove; BORDER-TOP: #ffffff 1px groove; PADDING-LEFT: 10px; BORDER-LEFT: #ffffff 1px groove; COLOR: black; BORDER-BOTTOM: #ffffff 1px groove; HEIGHT: 20px; BACKGROUND-COLOR: #e5ebf4"
									width="25%">Cost Effienciency</td>
								<td width="75%" style="HEIGHT: 20px">
									<asp:DropDownList id="DDL_COSTEFF" runat="server" Width="100%" AutoPostBack="True" onselectedindexchanged="DDL_COSTEFF_SelectedIndexChanged"></asp:DropDownList><BR>
									<asp:TextBox id="TXT_COSTEFF" runat="server" Width="100%" TextMode="MultiLine" Height="60px"></asp:TextBox></td>
							</tr>
							<tr>
								<td style="BORDER-RIGHT: #ffffff 1px groove; BORDER-TOP: #ffffff 1px groove; PADDING-LEFT: 10px; BORDER-LEFT: #ffffff 1px groove; COLOR: black; BORDER-BOTTOM: #ffffff 1px groove; BACKGROUND-COLOR: #e5ebf4"
									width="25%">3rd Party Effiency</td>
								<td width="75%">
									<asp:DropDownList id="DDL_3RDPARTY" runat="server" Width="100%" AutoPostBack="True" onselectedindexchanged="DDL_3RDPARTY_SelectedIndexChanged"></asp:DropDownList><BR>
									<asp:TextBox id="TXT_3RDPARTY" runat="server" Width="100%" TextMode="MultiLine" Height="60px"></asp:TextBox></td>
							</tr>
						</table>
					</TD>
				</TR>
				<% } %>
				<!-- separator ---------------------------------------->
				<TR>
					<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2"><asp:button id="BTN_SAVE" runat="server" Text="Save" Width="143px" CssClass="Button1"></asp:button>&nbsp;</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
