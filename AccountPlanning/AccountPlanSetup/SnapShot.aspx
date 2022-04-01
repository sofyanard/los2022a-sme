<%@ Page language="c#" Codebehind="SnapShot.aspx.cs" AutoEventWireup="True" Inherits="SME.AccountPlanning.AccountPlanSetup.SnapShot" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ClientSnapShot</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<table width="100%" border="0">
					<tr>
						<td align="left" width="50%">
							<table id="Table1">
								<tr>
									<td class="tdBGColor2" style="WIDTH: 400px" align="center"><b>Client Snapshot</b></td>
								</tr>
							</table>
						</td>
						<td class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/image/Back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../../Body.aspx"><IMG height="25" src="../../Image/MainMenu.jpg" width="106"></A>
							<A href="../../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A>
						</td>
					</tr>
					<tr>
						<td class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></td>
					</tr>
					<tr>
						<td class="tdHeader1" colSpan="2">KEY FINANCIAL</td>
					</tr>
					<!-- ************************* separator *************------------------------------------------------------------------------------------------------------------------------------------------->
					<TR>
						<TD class="tdNoBorder" vAlign="top" align="center" colSpan="2"><table width="100%">
								<tr>
									<td class="td" vAlign="top" width="30%"><ASP:DATAGRID id="DG_FinancialKey" runat="server" Width="100%" CellPadding="1" PageSize="1" AutoGenerateColumns="False">
											<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
											<Columns>
												<asp:BoundColumn DataField="BS_DATE_PERIODE" HeaderText="Periode Laporan">
													<HeaderStyle HorizontalAlign="Center" Width="70%" CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:ButtonColumn Text="Retrieve" CommandName="retrieve">
													<HeaderStyle HorizontalAlign="Center" CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:ButtonColumn>
												<asp:ButtonColumn Text="Delete" CommandName="delete">
													<HeaderStyle HorizontalAlign="Center" CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:ButtonColumn>
											</Columns>
										</ASP:DATAGRID></td>
								</tr>
							</table>
						</TD>
					</TR>
					<!-- ************************* separator *************------------------------------------------------------------------------------------------------------------------------------------------->
					<!-- 
						<TR>
							<TD align="center" colSpan="2">
								<table width="100%">
									<TBODY>
										<tr>
											<td class="tdBGColor2" align="center"><asp:button id="BTN_DEL" runat="server" Width="100px" CssClass="Button1" Text="Delete"></asp:button>&nbsp;
												<asp:button id="BTN_RTRV" runat="server" Width="100px" CssClass="Button1" Text="Retrieve"></asp:button>&nbsp;
											</td>
										</tr>
									</TBODY>
								</table>
							</TD>
						</TR>
						-->
					<!-- diremark dulu tgl 21 sept 2004 ------
						<TR>
							<td class="tdNoBorder" align="center" colSpan="2">
								<table width="100%">
									<tr>
										<td width="60%">Nasabah menyerahkan laporan keuangan dua periode</td>
										<td width="20%"><asp:radiobutton id="RBTN_LAPKEU1" runat="server"></asp:radiobutton></td>
										<td width="20%"><asp:radiobutton id="RadioButton2" runat="server"></asp:radiobutton></td>
									</tr>
								</table>
							</td>
						</TR>
						------------------------------------------------------------------------------------------------------------------------------------------->
					<!--  separator ------------------------------------------------------------------------------------------------------------------------------------------><asp:panel id="PnlNeraca" runat="server" Visible="True">
						<TR>
							<td class="td" align="center" colSpan="2">
								<table cellSpacing="0" cellPadding="0" width="100%">
									<tr>
										<td class="tdSmallHeader" align="center" width="24%" rowSpan="2">Pos-pos neraca</td>
										<td class="tdSmallHeader" align="center" width="76%" colSpan="12">Neraca</td>
									</tr>
									<tr>
										<td class="tdSmallHeader" align="center" width="19%" colSpan="3">Tahun ke n-2/bln</td>
										<td class="tdSmallHeader" align="center" width="19%" colSpan="3">Tahun ke n-1/bln</td>
										<td class="tdSmallHeader" align="center" width="19%" colSpan="3">Tahun ke n/bln</td>
										<td class="tdSmallHeader" align="center" width="19%" colSpan="3">Tahun Proyeksi/bln</td>
									</tr>
									<!--  START baris 1 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br0">
										<td class="TDBGColor1" style="PADDING-RIGHT: 15px" align="right" width="24%">Date 
											Periode</td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_B1" tabIndex="1" runat="server" CssClass="mandatory2"
												Columns="4" MaxLength="2" BackColor="#E0E0E0" ReadOnly="True" Enabled="False"></asp:textbox><asp:dropdownlist id="DDL_BLN_B1" tabIndex="2" runat="server" CssClass="mandatory2" BackColor="#E0E0E0"
												Enabled="False"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_YEAR_B1" tabIndex="3" runat="server" CssClass="mandatory2"
												Columns="4" MaxLength="4"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_C1" tabIndex="38" runat="server" CssClass="mandatory2"
												Columns="4" MaxLength="2" BackColor="#E0E0E0"></asp:textbox><asp:dropdownlist id="DDL_BLN_C1" tabIndex="39" runat="server" CssClass="mandatory2" BackColor="#E0E0E0"
												Enabled="False"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_YEAR_C1" tabIndex="40" runat="server"
												CssClass="mandatory2" Columns="4" MaxLength="4"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_D1" tabIndex="75" runat="server" CssClass="mandatory2"
												Columns="4" MaxLength="2" BackColor="#E0E0E0" ReadOnly="True" Enabled="False"></asp:textbox><asp:dropdownlist id="DDL_BLN_D1" tabIndex="76" runat="server" CssClass="mandatory2" BackColor="#E0E0E0"
												Enabled="False"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_YEAR_D1" tabIndex="77" runat="server"
												CssClass="mandatory2" Columns="4" MaxLength="4"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_E1" tabIndex="115" runat="server"
												CssClass="mandatory2" Columns="4" MaxLength="2" BackColor="#E0E0E0" ReadOnly="True"></asp:textbox><asp:dropdownlist id="DDL_BLN_E1" tabIndex="116" runat="server" CssClass="mandatory2" BackColor="#E0E0E0"
												Enabled="False"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_YEAR_E1" tabIndex="117" runat="server"
												CssClass="mandatory2" Columns="4" MaxLength="4"></asp:textbox></td>
									</tr>
									<tr id="br2">
										<td class="TDBGColor" style="PADDING-RIGHT: 40px; HEIGHT: 20px" align="left" width="24%"
											colSpan="13"><STRONG>&nbsp;&nbsp;&nbsp;ASSETS</STRONG></td>
									</tr>
									<!--  START baris 3 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br3">
										<td class="TDBGColor1" style="PADDING-RIGHT: 15px" align="left" width="24%">Cash 
											&amp; Cash Equivalents</td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B5" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'B'), FormatCurrency_noDec(document.Form1.TXT_B12),FormatCurrency_noDec(document.Form1.TXT_B17),FormatCurrency_noDec(document.Form1.TXT_B18),FormatCurrency_noDec(document.Form1.TXT_B26),FormatCurrency_noDec(document.Form1.TXT_B29),FormatCurrency_noDec(document.Form1.TXT_B30), FormatCurrency_noDec(document.Form1.TXT_B34),FormatCurrency_noDec(document.Form1.TXT_B35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="7" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C5" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'C'), FormatCurrency_noDec(document.Form1.TXT_C12),FormatCurrency_noDec(document.Form1.TXT_C17),FormatCurrency_noDec(document.Form1.TXT_C18),FormatCurrency_noDec(document.Form1.TXT_C26),FormatCurrency_noDec(document.Form1.TXT_C29),FormatCurrency_noDec(document.Form1.TXT_C30), FormatCurrency_noDec(document.Form1.TXT_C34),FormatCurrency_noDec(document.Form1.TXT_C35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="44" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D5" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'D'), FormatCurrency_noDec(document.Form1.TXT_D12),FormatCurrency_noDec(document.Form1.TXT_D17),FormatCurrency_noDec(document.Form1.TXT_D18),FormatCurrency_noDec(document.Form1.TXT_D26),FormatCurrency_noDec(document.Form1.TXT_D29),FormatCurrency_noDec(document.Form1.TXT_D30), FormatCurrency_noDec(document.Form1.TXT_D34),FormatCurrency_noDec(document.Form1.TXT_D35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="84" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_E5" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'E'), FormatCurrency_noDec(document.Form1.TXT_E12),FormatCurrency_noDec(document.Form1.TXT_E17),FormatCurrency_noDec(document.Form1.TXT_E18),FormatCurrency_noDec(document.Form1.TXT_E26),FormatCurrency_noDec(document.Form1.TXT_E29),FormatCurrency_noDec(document.Form1.TXT_E30), FormatCurrency_noDec(document.Form1.TXT_E34),FormatCurrency_noDec(document.Form1.TXT_E35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="121" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 4 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br4">
										<td class="TDBGColor1" style="PADDING-RIGHT: 15px" align="left" width="24%">Receivables</td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B6" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'B'), FormatCurrency_noDec(document.Form1.TXT_B12),FormatCurrency_noDec(document.Form1.TXT_B17),FormatCurrency_noDec(document.Form1.TXT_B18),FormatCurrency_noDec(document.Form1.TXT_B26),FormatCurrency_noDec(document.Form1.TXT_B29),FormatCurrency_noDec(document.Form1.TXT_B30), FormatCurrency_noDec(document.Form1.TXT_B34),FormatCurrency_noDec(document.Form1.TXT_B35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="8" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C6" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'C'), FormatCurrency_noDec(document.Form1.TXT_C12),FormatCurrency_noDec(document.Form1.TXT_C17),FormatCurrency_noDec(document.Form1.TXT_C18),FormatCurrency_noDec(document.Form1.TXT_C26),FormatCurrency_noDec(document.Form1.TXT_C29),FormatCurrency_noDec(document.Form1.TXT_C30), FormatCurrency_noDec(document.Form1.TXT_C34),FormatCurrency_noDec(document.Form1.TXT_C35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="45" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D6" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'D'), FormatCurrency_noDec(document.Form1.TXT_D12),FormatCurrency_noDec(document.Form1.TXT_D17),FormatCurrency_noDec(document.Form1.TXT_D18),FormatCurrency_noDec(document.Form1.TXT_D26),FormatCurrency_noDec(document.Form1.TXT_D29),FormatCurrency_noDec(document.Form1.TXT_D30), FormatCurrency_noDec(document.Form1.TXT_D34),FormatCurrency_noDec(document.Form1.TXT_D35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="85" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_E6" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'E'), FormatCurrency_noDec(document.Form1.TXT_E12),FormatCurrency_noDec(document.Form1.TXT_E17),FormatCurrency_noDec(document.Form1.TXT_E18),FormatCurrency_noDec(document.Form1.TXT_E26),FormatCurrency_noDec(document.Form1.TXT_E29),FormatCurrency_noDec(document.Form1.TXT_E30), FormatCurrency_noDec(document.Form1.TXT_E34),FormatCurrency_noDec(document.Form1.TXT_E35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="122" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 5 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br5">
										<td class="TDBGColor1" style="PADDING-RIGHT: 15px; COLOR: black" align="left" width="24%">Total 
											Assets</td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B7" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(3,'B'), FormatCurrency_noDec(document.Form1.TXT_B12),FormatCurrency_noDec(document.Form1.TXT_B17),FormatCurrency_noDec(document.Form1.TXT_B18),FormatCurrency_noDec(document.Form1.TXT_B26),FormatCurrency_noDec(document.Form1.TXT_B29),FormatCurrency_noDec(document.Form1.TXT_B30), FormatCurrency_noDec(document.Form1.TXT_B34),FormatCurrency_noDec(document.Form1.TXT_B35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="9" runat="server" Width="100%" BackColor="Transparent" ForeColor="Transparent"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C7" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(3,'C'), FormatCurrency_noDec(document.Form1.TXT_C12),FormatCurrency_noDec(document.Form1.TXT_C17),FormatCurrency_noDec(document.Form1.TXT_C18),FormatCurrency_noDec(document.Form1.TXT_C26),FormatCurrency_noDec(document.Form1.TXT_C29),FormatCurrency_noDec(document.Form1.TXT_C30), FormatCurrency_noDec(document.Form1.TXT_C34),FormatCurrency_noDec(document.Form1.TXT_C35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="46" runat="server" Width="100%" BackColor="White"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D7" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(3,'D'), FormatCurrency_noDec(document.Form1.TXT_D12),FormatCurrency_noDec(document.Form1.TXT_D17),FormatCurrency_noDec(document.Form1.TXT_D18),FormatCurrency_noDec(document.Form1.TXT_D26),FormatCurrency_noDec(document.Form1.TXT_D29),FormatCurrency_noDec(document.Form1.TXT_D30), FormatCurrency_noDec(document.Form1.TXT_D34),FormatCurrency_noDec(document.Form1.TXT_D35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="86" runat="server" Width="100%" BackColor="White"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_E7" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(3,'E'), FormatCurrency_noDec(document.Form1.TXT_E12),FormatCurrency_noDec(document.Form1.TXT_E17),FormatCurrency_noDec(document.Form1.TXT_E18),FormatCurrency_noDec(document.Form1.TXT_E26),FormatCurrency_noDec(document.Form1.TXT_E29),FormatCurrency_noDec(document.Form1.TXT_E30), FormatCurrency_noDec(document.Form1.TXT_E34),FormatCurrency_noDec(document.Form1.TXT_E35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="123" runat="server" Width="100%" BackColor="White"></asp:textbox></td>
									</tr>
									<!--  START baris 6 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br6">
										<td class="TDBGColor1" style="PADDING-RIGHT: 15px" align="left" width="24%">
											<P>Payables</P>
										</td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B8" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'B'), FormatCurrency_noDec(document.Form1.TXT_B12),FormatCurrency_noDec(document.Form1.TXT_B17),FormatCurrency_noDec(document.Form1.TXT_B18),FormatCurrency_noDec(document.Form1.TXT_B26),FormatCurrency_noDec(document.Form1.TXT_B29),FormatCurrency_noDec(document.Form1.TXT_B30), FormatCurrency_noDec(document.Form1.TXT_B34),FormatCurrency_noDec(document.Form1.TXT_B35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="10" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C8" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'C'), FormatCurrency_noDec(document.Form1.TXT_C12),FormatCurrency_noDec(document.Form1.TXT_C17),FormatCurrency_noDec(document.Form1.TXT_C18),FormatCurrency_noDec(document.Form1.TXT_C26),FormatCurrency_noDec(document.Form1.TXT_C29),FormatCurrency_noDec(document.Form1.TXT_C30), FormatCurrency_noDec(document.Form1.TXT_C34),FormatCurrency_noDec(document.Form1.TXT_C35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="47" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D8" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'D'), FormatCurrency_noDec(document.Form1.TXT_D12),FormatCurrency_noDec(document.Form1.TXT_D12),FormatCurrency_noDec(document.Form1.TXT_D17),FormatCurrency_noDec(document.Form1.TXT_D18),FormatCurrency_noDec(document.Form1.TXT_D26),FormatCurrency_noDec(document.Form1.TXT_D29),FormatCurrency_noDec(document.Form1.TXT_D30), FormatCurrency_noDec(document.Form1.TXT_D34),FormatCurrency_noDec(document.Form1.TXT_D35),FormatCurrency_noDec(document.Form1.TXT_D26),FormatCurrency_noDec(document.Form1.TXT_D29),FormatCurrency_noDec(document.Form1.TXT_D30), FormatCurrency_noDec(document.Form1.TXT_D34),FormatCurrency_noDec(document.Form1.TXT_D35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="87" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_E8" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'E'), FormatCurrency_noDec(document.Form1.TXT_E12),FormatCurrency_noDec(document.Form1.TXT_E17),FormatCurrency_noDec(document.Form1.TXT_E18),FormatCurrency_noDec(document.Form1.TXT_E26),FormatCurrency_noDec(document.Form1.TXT_E29),FormatCurrency_noDec(document.Form1.TXT_E30), FormatCurrency_noDec(document.Form1.TXT_E34),FormatCurrency_noDec(document.Form1.TXT_E35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="124" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 7 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br7">
										<td class="TDBGColor1" style="PADDING-RIGHT: 15px" align="left" width="24%">Total 
											Loans</td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B9" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'B'), FormatCurrency_noDec(document.Form1.TXT_B12),FormatCurrency_noDec(document.Form1.TXT_B17),FormatCurrency_noDec(document.Form1.TXT_B18),FormatCurrency_noDec(document.Form1.TXT_B26),FormatCurrency_noDec(document.Form1.TXT_B29),FormatCurrency_noDec(document.Form1.TXT_B30), FormatCurrency_noDec(document.Form1.TXT_B34),FormatCurrency_noDec(document.Form1.TXT_B35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="11" runat="server" Width="100%" BackColor="White"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C9" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'C'), FormatCurrency_noDec(document.Form1.TXT_C12),FormatCurrency_noDec(document.Form1.TXT_C17),FormatCurrency_noDec(document.Form1.TXT_C18),FormatCurrency_noDec(document.Form1.TXT_C26),FormatCurrency_noDec(document.Form1.TXT_C29),FormatCurrency_noDec(document.Form1.TXT_C30), FormatCurrency_noDec(document.Form1.TXT_C34),FormatCurrency_noDec(document.Form1.TXT_C35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="48" runat="server" Width="100%" BackColor="White"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D9" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'D'), FormatCurrency_noDec(document.Form1.TXT_D12),FormatCurrency_noDec(document.Form1.TXT_D17),FormatCurrency_noDec(document.Form1.TXT_D18),FormatCurrency_noDec(document.Form1.TXT_D26),FormatCurrency_noDec(document.Form1.TXT_D29),FormatCurrency_noDec(document.Form1.TXT_D30), FormatCurrency_noDec(document.Form1.TXT_D34),FormatCurrency_noDec(document.Form1.TXT_D35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="88" runat="server" Width="100%" BackColor="White"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_E9" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'E'), FormatCurrency_noDec(document.Form1.TXT_E12),FormatCurrency_noDec(document.Form1.TXT_E17),FormatCurrency_noDec(document.Form1.TXT_E18),FormatCurrency_noDec(document.Form1.TXT_E26),FormatCurrency_noDec(document.Form1.TXT_E29),FormatCurrency_noDec(document.Form1.TXT_E30), FormatCurrency_noDec(document.Form1.TXT_E34),FormatCurrency_noDec(document.Form1.TXT_E35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="125" runat="server" Width="100%" BackColor="White"></asp:textbox></td>
									</tr>
									<!--  START baris 8 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br8">
										<td class="TDBGColor1" style="PADDING-RIGHT: 15px" align="left" width="24%">Investment</td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B10" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'B'), FormatCurrency_noDec(document.Form1.TXT_B12),FormatCurrency_noDec(document.Form1.TXT_B17),FormatCurrency_noDec(document.Form1.TXT_B18),FormatCurrency_noDec(document.Form1.TXT_B26),FormatCurrency_noDec(document.Form1.TXT_B29),FormatCurrency_noDec(document.Form1.TXT_B30), FormatCurrency_noDec(document.Form1.TXT_B34),FormatCurrency_noDec(document.Form1.TXT_B35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="12" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C10" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'C'), FormatCurrency_noDec(document.Form1.TXT_C12),FormatCurrency_noDec(document.Form1.TXT_C17),FormatCurrency_noDec(document.Form1.TXT_C18),FormatCurrency_noDec(document.Form1.TXT_C26),FormatCurrency_noDec(document.Form1.TXT_C29),FormatCurrency_noDec(document.Form1.TXT_C30), FormatCurrency_noDec(document.Form1.TXT_C34),FormatCurrency_noDec(document.Form1.TXT_C35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="49" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D10" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'D'), FormatCurrency_noDec(document.Form1.TXT_D12),FormatCurrency_noDec(document.Form1.TXT_D17),FormatCurrency_noDec(document.Form1.TXT_D18),FormatCurrency_noDec(document.Form1.TXT_D26),FormatCurrency_noDec(document.Form1.TXT_D29),FormatCurrency_noDec(document.Form1.TXT_D30), FormatCurrency_noDec(document.Form1.TXT_D34),FormatCurrency_noDec(document.Form1.TXT_D35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="89" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_E10" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'E'), FormatCurrency_noDec(document.Form1.TXT_E12),FormatCurrency_noDec(document.Form1.TXT_E17),FormatCurrency_noDec(document.Form1.TXT_E18),FormatCurrency_noDec(document.Form1.TXT_E26),FormatCurrency_noDec(document.Form1.TXT_E29),FormatCurrency_noDec(document.Form1.TXT_E30), FormatCurrency_noDec(document.Form1.TXT_E34),FormatCurrency_noDec(document.Form1.TXT_E35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="126" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 8 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br8">
										<td class="TDBGColor1" style="PADDING-RIGHT: 15px" align="left" width="24%">Working 
											Capital</td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B11" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'B'), FormatCurrency_noDec(document.Form1.TXT_B12),FormatCurrency_noDec(document.Form1.TXT_B17),FormatCurrency_noDec(document.Form1.TXT_B18),FormatCurrency_noDec(document.Form1.TXT_B26),FormatCurrency_noDec(document.Form1.TXT_B29),FormatCurrency_noDec(document.Form1.TXT_B30), FormatCurrency_noDec(document.Form1.TXT_B34),FormatCurrency_noDec(document.Form1.TXT_B35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="12" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C11" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'C'), FormatCurrency_noDec(document.Form1.TXT_C12),FormatCurrency_noDec(document.Form1.TXT_C17),FormatCurrency_noDec(document.Form1.TXT_C18),FormatCurrency_noDec(document.Form1.TXT_C26),FormatCurrency_noDec(document.Form1.TXT_C29),FormatCurrency_noDec(document.Form1.TXT_C30), FormatCurrency_noDec(document.Form1.TXT_C34),FormatCurrency_noDec(document.Form1.TXT_C35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="49" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D11" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'D'), FormatCurrency_noDec(document.Form1.TXT_D12),FormatCurrency_noDec(document.Form1.TXT_D17),FormatCurrency_noDec(document.Form1.TXT_D18),FormatCurrency_noDec(document.Form1.TXT_D26),FormatCurrency_noDec(document.Form1.TXT_D29),FormatCurrency_noDec(document.Form1.TXT_D30), FormatCurrency_noDec(document.Form1.TXT_D34),FormatCurrency_noDec(document.Form1.TXT_D35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="89" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_E11" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'E'), FormatCurrency_noDec(document.Form1.TXT_E12),FormatCurrency_noDec(document.Form1.TXT_E17),FormatCurrency_noDec(document.Form1.TXT_E18),FormatCurrency_noDec(document.Form1.TXT_E26),FormatCurrency_noDec(document.Form1.TXT_E29),FormatCurrency_noDec(document.Form1.TXT_E30), FormatCurrency_noDec(document.Form1.TXT_E34),FormatCurrency_noDec(document.Form1.TXT_E35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="126" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 22 SEPARATOR UTK ISI NERACA -----------------------------------------------------></table>
								<!-- %%%%%%%%%%%%%%%%%%%%%%%%%%%%%% END SEPARATOR UTK ISI NERACA %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%% -----------------------------------------------------></td>
						</TR>
						<!-- %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%% SEPARATOR UNTUK KOMPONEN LABA RUGI %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%% --------------------------------------------------------->
						<tr>
							<td vAlign="top" align="center" colSpan="2">
								<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
									<TBODY>
										<!-- separator ------------------------------------------------------------------------------------------------------------------------------------------><asp:panel id="Panel1" runat="server" Visible="True">
											<TR>
												<TD class="td" align="center" colSpan="2">
													<TABLE cellSpacing="0" cellPadding="0" width="100%">
														<TR>
															<TD class="tdSmallHeader" align="center" width="24%" rowSpan="2">Pos-pos laba rugi</TD>
															<TD class="tdSmallHeader" align="center" width="76%" colSpan="13">Laba Rugi&nbsp;</TD>
														</TR>
														<TR>
															<TD class="tdSmallHeader" align="center" width="19%" colSpan="3">Tahun ke n-2/bln</TD>
															<TD class="tdSmallHeader" align="center" width="19%" colSpan="3">Tahun ke n-1/bln</TD>
															<TD class="tdSmallHeader" align="center" width="19%" colSpan="3">Tahun ke n/bln</TD>
															<TD class="tdSmallHeader" align="center" width="19%" colSpan="3">Tahun Proyeksi/bln</TD>
														</TR> <!--  START baris 1 SEPARATOR UTK ISI NERACA ----------------------------------------------------->  <!--  START baris 3 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
														<TR id="br3"> <!-- Net Sales -->
															<TD class="TDBGColor1" style="PADDING-RIGHT: 15px" align="right" width="24%">Revenue</TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_B14" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'B'), FormatCurrency_noDec(document.Form1.TXT_B43), FormatCurrency_noDec(document.Form1.TXT_B44), FormatCurrency_noDec(document.Form1.TXT_B45), FormatCurrency_noDec(document.Form1.TXT_B47), FormatCurrency_noDec(document.Form1.TXT_B48), FormatCurrency_noDec(document.Form1.TXT_B49), FormatCurrency_noDec(document.Form1.TXT_B55), FormatCurrency_noDec(document.Form1.TXT_B57), FormatCurrency_noDec(document.Form1.TXT_B58), FormatCurrency_noDec(document.Form1.TXT_B60), FormatCurrency_noDec(document.Form1.TXT_B61)"
																	style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="7" runat="server" Width="100%"></asp:textbox></TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_C14" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'C'), FormatCurrency_noDec(document.Form1.TXT_C43), FormatCurrency_noDec(document.Form1.TXT_C44), FormatCurrency_noDec(document.Form1.TXT_C45), FormatCurrency_noDec(document.Form1.TXT_C47), FormatCurrency_noDec(document.Form1.TXT_C48), FormatCurrency_noDec(document.Form1.TXT_C49), FormatCurrency_noDec(document.Form1.TXT_C55), FormatCurrency_noDec(document.Form1.TXT_C57), FormatCurrency_noDec(document.Form1.TXT_C58), FormatCurrency_noDec(document.Form1.TXT_C60), FormatCurrency_noDec(document.Form1.TXT_C61)"
																	style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="34" runat="server" Width="100%"></asp:textbox></TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_D14" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'D'),  FormatCurrency_noDec(document.Form1.TXT_D43), FormatCurrency_noDec(document.Form1.TXT_D44), FormatCurrency_noDec(document.Form1.TXT_D45), FormatCurrency_noDec(document.Form1.TXT_D47), FormatCurrency_noDec(document.Form1.TXT_D48), FormatCurrency_noDec(document.Form1.TXT_D49), FormatCurrency_noDec(document.Form1.TXT_D55), FormatCurrency_noDec(document.Form1.TXT_D57), FormatCurrency_noDec(document.Form1.TXT_D58), FormatCurrency_noDec(document.Form1.TXT_D60), FormatCurrency_noDec(document.Form1.TXT_D61)"
																	style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="61" runat="server" Width="100%"></asp:textbox></TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_E14" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'E'),  FormatCurrency_noDec(document.Form1.TXT_E43), FormatCurrency_noDec(document.Form1.TXT_E44), FormatCurrency_noDec(document.Form1.TXT_E45), FormatCurrency_noDec(document.Form1.TXT_E47), FormatCurrency_noDec(document.Form1.TXT_E48), FormatCurrency_noDec(document.Form1.TXT_E49), FormatCurrency_noDec(document.Form1.TXT_E55), FormatCurrency_noDec(document.Form1.TXT_E57), FormatCurrency_noDec(document.Form1.TXT_E58), FormatCurrency_noDec(document.Form1.TXT_E60), FormatCurrency_noDec(document.Form1.TXT_E61)"
																	style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="88" runat="server" Width="100%"></asp:textbox></TD>
														</TR> <!--  START baris 4 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
														<TR id="br4"> <!-- Cost Of Goods Sales -->
															<TD class="TDBGColor1" style="PADDING-RIGHT: 15px" align="right" width="24%">EBIT</TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_B15" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'B'), FormatCurrency_noDec(document.Form1.TXT_B43), FormatCurrency_noDec(document.Form1.TXT_B44), FormatCurrency_noDec(document.Form1.TXT_B45), FormatCurrency_noDec(document.Form1.TXT_B47), FormatCurrency_noDec(document.Form1.TXT_B48), FormatCurrency_noDec(document.Form1.TXT_B49), FormatCurrency_noDec(document.Form1.TXT_B55), FormatCurrency_noDec(document.Form1.TXT_B57), FormatCurrency_noDec(document.Form1.TXT_B58), FormatCurrency_noDec(document.Form1.TXT_B60), FormatCurrency_noDec(document.Form1.TXT_B61)"
																	style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="7" runat="server" Width="100%"></asp:textbox></TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_C15" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'C'), FormatCurrency_noDec(document.Form1.TXT_C43), FormatCurrency_noDec(document.Form1.TXT_C44), FormatCurrency_noDec(document.Form1.TXT_C45), FormatCurrency_noDec(document.Form1.TXT_C47), FormatCurrency_noDec(document.Form1.TXT_C48), FormatCurrency_noDec(document.Form1.TXT_C49), FormatCurrency_noDec(document.Form1.TXT_C55), FormatCurrency_noDec(document.Form1.TXT_C57), FormatCurrency_noDec(document.Form1.TXT_C58), FormatCurrency_noDec(document.Form1.TXT_C60), FormatCurrency_noDec(document.Form1.TXT_C61)"
																	style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="34" runat="server" Width="100%"></asp:textbox></TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_D15" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'D'),  FormatCurrency_noDec(document.Form1.TXT_D43), FormatCurrency_noDec(document.Form1.TXT_D44), FormatCurrency_noDec(document.Form1.TXT_D45), FormatCurrency_noDec(document.Form1.TXT_D47), FormatCurrency_noDec(document.Form1.TXT_D48), FormatCurrency_noDec(document.Form1.TXT_D49), FormatCurrency_noDec(document.Form1.TXT_D55), FormatCurrency_noDec(document.Form1.TXT_D57), FormatCurrency_noDec(document.Form1.TXT_D58), FormatCurrency_noDec(document.Form1.TXT_D60), FormatCurrency_noDec(document.Form1.TXT_D61)"
																	style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="61" runat="server" Width="100%"></asp:textbox></TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_E15" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'E'),  FormatCurrency_noDec(document.Form1.TXT_E43), FormatCurrency_noDec(document.Form1.TXT_E44), FormatCurrency_noDec(document.Form1.TXT_E45), FormatCurrency_noDec(document.Form1.TXT_E47), FormatCurrency_noDec(document.Form1.TXT_E48), FormatCurrency_noDec(document.Form1.TXT_E49), FormatCurrency_noDec(document.Form1.TXT_E55), FormatCurrency_noDec(document.Form1.TXT_E57), FormatCurrency_noDec(document.Form1.TXT_E58), FormatCurrency_noDec(document.Form1.TXT_E60), FormatCurrency_noDec(document.Form1.TXT_E61)"
																	style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="88" runat="server" Width="100%"></asp:textbox></TD>
														</TR> <!--  START baris 5 SEPARATOR UTK ISI laba rugi ----------------------------------------------------->
														<TR> <!-- % Sale  Row 16 -->
															<TD class="TDBGColor1" style="PADDING-RIGHT: 15px" align="right" width="24%">EBIT 
																margins</TD>
															<TD width="1%"></TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_B16" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
																	tabIndex="9" runat="server" Width="100%" BackColor="Transparent"></asp:textbox></TD>
															<TD width="1%"></TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_C16" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
																	tabIndex="36" runat="server" Width="100%" BackColor="Transparent"></asp:textbox></TD>
															<TD width="1%"></TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_D16" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
																	tabIndex="63" runat="server" Width="100%" BackColor="Transparent"></asp:textbox></TD>
															<TD width="1%"></TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_E16" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
																	tabIndex="90" runat="server" Width="100%" BackColor="Transparent"></asp:textbox></TD>
														</TR>
														<TR id="br6"> <!-- Hitung -->
															<TD class="TDBGColor1" style="PADDING-RIGHT: 15px" align="right" width="24%">NPAT</TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_B17" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
																	tabIndex="10" runat="server" Width="100%" Visible="True" BackColor="Transparent"></asp:textbox></TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_C17" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
																	tabIndex="37" runat="server" Width="100%" BackColor="Transparent"></asp:textbox></TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_D17" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
																	tabIndex="64" runat="server" Width="100%" BackColor="Transparent"></asp:textbox></TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_E17" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
																	tabIndex="91" runat="server" Width="100%" BackColor="Transparent"></asp:textbox></TD>
														</TR> <!--  START baris 8 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
														<TR> <!-- '% of Sales	 Gross Margin	Row 18	  -->
															<TD class="TDBGColor1" style="PADDING-RIGHT: 15px" align="right" width="24%">NPAT 
																margins</TD>
															<TD width="1%"></TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_B18" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
																	tabIndex="11" runat="server" Width="100%" BackColor="Transparent"></asp:textbox></TD>
															<TD width="1%"></TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_C18" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
																	tabIndex="38" runat="server" Width="100%" BackColor="Transparent"></asp:textbox></TD>
															<TD width="1%"></TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_D18" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
																	tabIndex="65" runat="server" Width="100%" BackColor="Transparent"></asp:textbox></TD>
															<TD width="1%"></TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_E18" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
																	tabIndex="92" runat="server" Width="100%" BackColor="Transparent"></asp:textbox></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD class="tdBGColor2" align="center" colSpan="2">
													<asp:button id="BTN_SIMPAN" runat="server" Width="120px" CssClass="BUTTON1" Text="Save" onclick="BTN_SIMPAN_Click"></asp:button><!-- <asp:button id="BTNPROSES" runat="server" Width="150px" CssClass="BUTTON1" Text="Proses / Calculate"></asp:button>&nbsp;&nbsp; -->
													<asp:button id="BTNCLEAR" runat="server" Width="120px" CssClass="BUTTON1" Text="Clear" onclick="BTNCLEAR_Click"></asp:button></TD>
											</TR>
										</asp:panel></TBODY></TABLE>
							</td>
						</tr>
						<!-- %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%% END SEPARATOR UMTUK KOMPONEN LABA RUGI %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%% --------------------------------------------------------->
						<!-- ************************* separator *************--------->
						<tr>
							<td class="tdHeader1" colSpan="2">BUSINESS AND STRATEGY</td>
						</tr>
						<TR>
							<TD class="td" style="HEIGHT: 7px" vAlign="top" width="50%" colSpan="2">
								<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="TDBGColor1" width="20%"><asp:label id="LBL_TXT_SCENARIO" runat="server">Description of business :</asp:label></TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_DESCRIPTION_OF_BUSINESS" runat="server" Width="100%" Visible="True" CssClass="Mandatory"
												Height="98px" TextMode="MultiLine"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" width="20%"><asp:label id="Label2" runat="server">Client's strategy and priorities :</asp:label></TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_CLIENTS_STRATEGY_AND_PRIORITIES" runat="server" Width="100%" CssClass="Mandatory"
												Height="98px" TextMode="MultiLine"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" width="20%"><asp:label id="Label3" runat="server">Recent developments :</asp:label></TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_RECENT_DEVELOPMENTS" runat="server" Width="100%" CssClass="Mandatory" Height="98px"
												TextMode="MultiLine"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" width="20%"><asp:label id="Label4" runat="server">Implications for Bank Pundi :</asp:label></TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_IMPLICATIONS_FOR_MANDIRI" runat="server" Width="100%" CssClass="Mandatory"
												Height="98px" TextMode="MultiLine"></asp:textbox></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD vAlign="top" align="center" colSpan="2">
								<table width="100%">
									<tr>
										<td class="tdBGColor2" align="center"><asp:button id="BTN_SAVE_BUSINESS_AND_STRATEGY" runat="server" Width="100px" CssClass="Button1"
												Text=" Save " onclick="BTN_SAVE_BUSINESS_AND_STRATEGY_Click"></asp:button></td>
									</tr>
								</table>
							</TD>
						</TR>
						<tr>
							<td class="tdHeader1" colSpan="2">COMPETITIVE SCAN
							</td>
						</tr>
						<TR>
							<TD class="td" vAlign="top" align="center" width="50%" colSpan="2"><asp:datagrid id="DGR_SCENARIO" runat="server" AutoGenerateColumns="False" Width="100%" AllowPaging="True">
									<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
									<Columns>
										<asp:BoundColumn Visible="True" DataField="CU_CIF" HeaderText="CU_CIF"></asp:BoundColumn>
										<asp:BoundColumn Visible="True" DataField="ID_AP_VARIABLE" HeaderText="ID_AP_VARIABLE"></asp:BoundColumn>
										<asp:BoundColumn DataField="product" HeaderText="Product">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:TemplateColumn HeaderText="Primary bank" ItemStyle-Width="35%" ItemStyle-VerticalAlign="Top">
											<HeaderStyle CssClass="tdSmallHeader" VerticalAlign="Top"></HeaderStyle>
											<ItemTemplate>
												<asp:TextBox Width="100%" BackColor="#e0dfe3" Runat="server" ID="TXT_PRIMARY_BANK_GRID" TextMode="MultiLine"
													ReadOnly="True"></asp:TextBox>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn HeaderText="Other banks" ItemStyle-Width="35%">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemTemplate>
												<asp:TextBox Width="100%" BackColor="#e0dfe3" Runat="server" ID="TXT_OTHER_BANKS_GRID" TextMode="MultiLine"
													ReadOnly="True"></asp:TextBox>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn HeaderText="Function" ItemStyle-Width="7%">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
											<ItemTemplate>
												<asp:LinkButton id="LNK_VIEW" runat="server" CommandName="edit">View</asp:LinkButton>&nbsp;
												<asp:LinkButton id="LNK_DELETE" runat="server" CommandName="delete">Delete</asp:LinkButton>
											</ItemTemplate>
										</asp:TemplateColumn>
									</Columns>
									<PagerStyle Mode="NumericPages"></PagerStyle>
								</asp:datagrid></TD>
						</TR>
						<TR>
							<td colSpan="2">
								<table width="100%">
									<TR>
										<TD class="TDBGColor1" width="15%"><asp:label id="LBL_TXT_CIF" runat="server">Product :</asp:label></TD>
										<TD class="TDBGColorValue" width="100%"><asp:dropdownlist id="DDL_PRODUCT" runat="server" Width="100%"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" vAlign="top" width="15%"><asp:label id="LBL_TXT_CUST_NAME" runat="server">Primary Bank :</asp:label></TD>
										<TD class="TDBGColorValue" width="100%"><asp:textbox id="TXT_PRIMARY_BANK" runat="server" Width="100%" Height="70px" TextMode="MultiLine"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" vAlign="top" width="15%"><asp:label id="LBL_TXT_ADDRESS" runat="server">Other Banks :</asp:label></TD>
										<TD class="TDBGColorValue" width="100%"><asp:textbox id="TXT_OTHER_BANK" runat="server" Width="100%" Height="70px" TextMode="MultiLine"></asp:textbox></TD>
									</TR>
								</table>
							</td>
						</TR>
						<TR>
							<TD vAlign="top" align="center" colSpan="2">
								<table width="100%">
									<tr>
										<td class="tdBGColor2" align="center"><asp:button id="BTN_SAVE_COMPITIVE" runat="server" Width="100px" CssClass="Button1" Text=" Save " onclick="BTN_SAVE_COMPITIVE_Click"></asp:button></td>
									</tr>
								</table>
							</TD>
						</TR>
						<tr>
							<td class="tdHeader1" colSpan="2">STRATEGIES TO GROW ANCHORS
							</td>
						</tr>
						<TR>
							<TD class="td" vAlign="top" align="center" width="50%" colSpan="2"><asp:datagrid id="StrategiesToGrowAnchors" runat="server" AutoGenerateColumns="False" Width="100%"
									Visible="True" AllowPaging="True">
									<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
									<Columns>
										<asp:BoundColumn Visible="True" DataField="CU_CIF" HeaderText="CU_CIF"></asp:BoundColumn>
										<asp:BoundColumn DataField="SEQ" HeaderText="#">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:TemplateColumn HeaderText="Key Support Needed to Grow Anchors">
											<HeaderStyle CssClass="tdSmallHeader" VerticalAlign="Top"></HeaderStyle>
											<ItemStyle Width="90%" VerticalAlign="Top"></ItemStyle>
											<ItemTemplate>
												<asp:TextBox Width="100%" BackColor="#e0dfe3" Runat="server" ID="TXT_KEY_SUPPORT" TextMode="MultiLine"
													ReadOnly="True" Height="50px"></asp:TextBox>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn HeaderText="Function">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center" Width="7%"></ItemStyle>
											<ItemTemplate>
												<asp:LinkButton id="Linkbutton1" runat="server" CommandName="edit">View</asp:LinkButton>&nbsp;
												<asp:LinkButton id="Linkbutton2" runat="server" CommandName="delete">Delete</asp:LinkButton>
											</ItemTemplate>
										</asp:TemplateColumn>
									</Columns>
									<PagerStyle Mode="NumericPages"></PagerStyle>
								</asp:datagrid></TD>
						</TR>
						<TR>
							<td colSpan="2">
								<table width="100%">
									<TR id="TR_NO" runat="server">
										<TD class="TDBGColor1" width="15%"><asp:label id="Label5" runat="server">No :</asp:label></TD>
										<TD class="TDBGColorValue" width="100%"><asp:textbox id="TXT_SEQ_GROW_ANCHORS" runat="server" Width="100%" ReadOnly="True"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" vAlign="top" width="15%"><asp:label id="Label6" runat="server">Key Support Needed :</asp:label></TD>
										<TD class="TDBGColorValue" width="100%"><asp:textbox id="TXT_KEY_SUPPORT_NEEDED" runat="server" Width="100%" Height="70px" TextMode="MultiLine"></asp:textbox></TD>
									</TR>
								</table>
							</td>
						</TR>
						<TR>
							<TD vAlign="top" align="center" colSpan="2">
								<table width="100%">
									<tr>
										<td class="tdBGColor2" align="center"><asp:button id="BTN_SAVE_STRATEGIES_TO_GROW_ANCHORS" runat="server" Width="100px" CssClass="Button1"
												Text=" Save " onclick="BTN_SAVE_STRATEGIES_TO_GROW_ANCHORS_Click"></asp:button></td>
									</tr>
								</table>
							</TD>
						</TR>
						<tr>
							<td class="tdHeader1" id="Td2" vAlign="middle" colSpan="2" runat="server">DOCUMENTS</td>
						</tr>
						<tr>
							<td>
								<table width="100%" align="center">
									<tr>
										<td vAlign="top" width="50%">
											<table cellSpacing="0" cellPadding="0" width="100%">
												<TR>
													<TD class="TDBGColor1" width="75">File</TD>
													<TD style="WIDTH: 15px">:</TD>
													<TD class="TDBGColorValue"><INPUT id="TXT_FILE_UPLOAD" style="WIDTH: 344px; HEIGHT: 19px" type="file" size="38" name="File1"
															runat="Server"></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Status</TD>
													<TD>:</TD>
													<TD class="TDBGColorValue"><asp:label id="LBL_STATUS" runat="server" ForeColor="Red"></asp:label><asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" ErrorMessage="Only xls, doc, txt, pdf, docx, xlsx or zip files are allowed!"
															ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.xls|.XLS|.doc|.DOC|.txt|.TXT|.zip|.ZIP|.pdf|.PDF|.docx|.DOCX|.xlsx|.XLSX|)$" ControlToValidate="TXT_FILE_UPLOAD"></asp:regularexpressionvalidator></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1"></TD>
													<TD></TD>
													<TD class="TDBGColorValue"><asp:label id="LBL_STATUSREPORT" runat="server" ForeColor="Red"></asp:label></TD>
												</TR>
												<TR>
													<TD style="HEIGHT: 21px" align="center" colSpan="3"><asp:button id="BTN_UPLOAD" runat="server" Text="Upload" onclick="BTN_UPLOAD_Click"></asp:button></TD>
												</TR>
												<TR>
													<TD align="center" colSpan="3"></TD>
												</TR>
											</table>
										</td>
									</tr>
								</table>
							</td>
							<td vAlign="top" width="50%"><asp:datagrid id="DATA_UPLOAD" runat="server" AutoGenerateColumns="False" PageSize="5" CellPadding="1"
									Width="100%" AllowPaging="True">
									<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
									<Columns>
										<asp:BoundColumn Visible="True" DataField="ID_UPLOAD_DATA_SNAPSHOT" HeaderText="ID_UPLOAD_DATA_SNAPSHOT">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="FILE_UPLOAD_NAME" HeaderText="Destination File">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:TemplateColumn>
											<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
											<ItemTemplate>
												<asp:HyperLink id="FILE_DOWNLOAD" runat="server" Target="_blank">Download</asp:HyperLink>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn>
											<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
											<ItemTemplate>
												<asp:LinkButton id="FILE_DELETE" runat="server" CommandName="delete">Delete</asp:LinkButton>
											</ItemTemplate>
										</asp:TemplateColumn>
									</Columns>
									<PagerStyle Mode="NumericPages"></PagerStyle>
								</asp:datagrid></td>
						</tr>
					<!-- separator --------------></table>
				</TD></TR></asp:panel></TABLE></center>
		</form>
	</body>
</HTML>
