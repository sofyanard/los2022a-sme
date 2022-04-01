<%@ Page language="c#" Codebehind="ScoringHubunganBank.aspx.cs" AutoEventWireup="True" Inherits="SME.Scoring.ScoringHubunganBank" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Neraca</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_entries.html" -->
		<script language="javascript">
		function cek_mandatory_hubbank(frm, alamat)
		{
			max_elm = (frm.elements.length) - 2;
			lanjut = true;
			for (var i=1; i<=max_elm; i++)
			{
				elm = frm.elements[i];
				nm_kolom = "kotak";
				if (elm.className == "mandatory" && (elm.value == "") && (elm.type == "text" || elm.type == "select-one"))
				{
					r = elm.parentElement.parentElement;
					d = r.cells(0).innerText;
					alert(d + " tidak boleh kosong...");
					lanjut = false;
					elm.focus();
					return false;
				}
			}
			if (lanjut)
			{

				if (alamat != undefined && alamat != "" )
					frm.action = alamat;

				return true;
			}
		}
		</script>
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" style="Z-INDEX: 101; LEFT: -24px; POSITION: absolute; TOP: 8px" cellSpacing="2"
					cellPadding="2" width="100%">
					<TBODY>
						<!-- ************************* separator *************------------------------------------------------------------------------------------------------------------------------------------------->
						<!-- ************************* separator *************------------------------------------------------------------------------------------------------------------------------------------------->
						<!-- ************************* separator *************------------------------------------------------------------------------------------------------------------------------------------------->
						<!-- ************************* separator *************------------------------------------------------------------------------------------------------------------------------------------------->
						<!--  separator ------------------------------------------------------------------------------------------------------------------------------------------>
						<TR>
							<td class="tdNoBorder" align="center" colSpan="2">x
								<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="tdHeader1" align="center" width="100%" colSpan="2">Hubungan Dengan Bank</TD>
									</TR>
								</TABLE>
								<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 360px; HEIGHT: 12px">
											<P>Fasilitas Kredit Saat Ini</P>
										</TD>
										<TD style="WIDTH: 9px; HEIGHT: 12px"></TD>
										<TD style="HEIGHT: 12px"><asp:dropdownlist id="DDL_FACKREDIT" runat="server" Width="232px"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 360px; HEIGHT: 25px">Total Limit Aplikasi</TD>
										<TD style="WIDTH: 9px; HEIGHT: 25px"></TD>
										<TD style="HEIGHT: 25px"><asp:textbox id="TXT_LMT_CREDIT_CURR" runat="server" BackColor="Gainsboro" ReadOnly="True"></asp:textbox>&nbsp;&nbsp; 
											dalam ribuan :&nbsp;&nbsp;
											<asp:textbox onkeypress="return numbersonly()" id="TXT_LMT_CREDIT_CURR_MILL" onblur="FormatCurrency(this)"
												runat="server" MaxLength="8" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 360px">Total Exposure (termasuk aplikasi ini)</TD>
										<TD style="WIDTH: 9px"></TD>
										<TD><asp:textbox id="TXT_TTL_EXP" runat="server" BackColor="Gainsboro" ReadOnly="True"></asp:textbox>&nbsp;&nbsp; 
											dalam ribuan : &nbsp;
											<asp:textbox onkeypress="return numbersonly()" id="TXT_TTL_EXP_MILL" onblur="FormatCurrency(this)"
												runat="server" MaxLength="8" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 360px; HEIGHT: 11px">Saat ini menjadi 
											nasabah&nbsp;BM</TD>
										<TD style="WIDTH: 9px; HEIGHT: 11px"></TD>
										<TD style="HEIGHT: 11px"><asp:dropdownlist id="DDL_BUSINESS_CURR_BM" runat="server" Enabled="False">
												<asp:ListItem Value="N">TIDAK</asp:ListItem>
												<asp:ListItem Value="Y">YA</asp:ListItem>
											</asp:dropdownlist>
											<asp:dropdownlist id="DDL_BUSINESS_PAST_BM" runat="server" Visible="False" Enabled="False">
												<asp:ListItem Value="N">TIDAK</asp:ListItem>
												<asp:ListItem Value="Y">YA</asp:ListItem>
											</asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 360px; HEIGHT: 16px">Mulai menjadi nasabah BM 
											/ selected bank lain (MM/YYYY)</TD>
										<TD style="WIDTH: 9px; HEIGHT: 16px"></TD>
										<TD style="HEIGHT: 16px"><asp:textbox onkeypress="return numbersonly()" id="TXT_MULAI_BM_MM" runat="server" MaxLength="2"
												Columns="2" ReadOnly="True" BackColor="Gainsboro"></asp:textbox><asp:textbox onkeypress="return numbersonly()" id="TXT_MULAI_BM_YY" runat="server" MaxLength="4"
												Columns="4" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 334px; HEIGHT: 17px" colSpan="3"></TD>
										<TD style="WIDTH: 9px; HEIGHT: 17px"></TD>
										<TD style="HEIGHT: 17px"></TD>
									</TR>
									<TR>
										<TD class="tdHeader1" align="center" colSpan="3">Applicant</TD>
										<TD style="WIDTH: 9px; HEIGHT: 25px"></TD>
										<TD style="HEIGHT: 25px"></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 360px; HEIGHT: 26px">Kolektibilitas perusahaan 
											saat ini di bank lain (IDI BI)</TD>
										<TD style="WIDTH: 9px; HEIGHT: 26px"></TD>
										<TD style="HEIGHT: 26px"><asp:dropdownlist id="DDL_APP_BI_COLL_CURR" runat="server" Width="128px" Height="24px" Enabled="False"
												CssClass="mandatory"></asp:dropdownlist></TD>
										<TD style="WIDTH: 9px; HEIGHT: 26px"></TD>
										<TD style="HEIGHT: 26px"></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 360px; HEIGHT: 26px">Kolektibilitas perusahaan 
											12 bulan terakhir di bank lain (IDI BI)</TD>
										<TD style="WIDTH: 9px; HEIGHT: 26px"></TD>
										<TD style="HEIGHT: 26px"><asp:dropdownlist id="DDL_APP_BI_COLL_CURR_12BLN" runat="server" Width="128px" Height="24px" Enabled="False"
												CssClass="mandatory"></asp:dropdownlist></TD>
										<TD style="WIDTH: 9px; HEIGHT: 26px"></TD>
										<TD style="HEIGHT: 26px"></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 360px; HEIGHT: 16px">Kolektibilitas perusahaan 
											saat ini di Bank Mandiri</TD>
										<TD style="WIDTH: 9px; HEIGHT: 16px"></TD>
										<TD style="HEIGHT: 16px"><asp:dropdownlist id="DDL_APP_BM_COLL_CURR" runat="server" Width="192px" Height="24px" Enabled="False" onselectedindexchanged="DDL_APP_BM_COLL_CURR_SelectedIndexChanged"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 360px; HEIGHT: 19px">Kolektibilitas terburuk 
											12 Bulan&nbsp;terakhir di BM</TD>
										<TD style="WIDTH: 9px; HEIGHT: 19px"></TD>
										<TD style="HEIGHT: 19px"><asp:dropdownlist id="DDL_BUSINESS_BM_COLL_W12" runat="server" Width="192px" Enabled="False" CssClass="mandatory" onselectedindexchanged="DDL_BUSINESS_BM_COLL_W12_SelectedIndexChanged"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 360px; HEIGHT: 21px">Frekuensi Kolektibilitas 
											perusahaan&nbsp;12 Bulan Terakhir</TD>
										<TD style="WIDTH: 9px; HEIGHT: 21px"></TD>
										<TD style="HEIGHT: 21px">2A
											<asp:textbox onkeypress="return numbersonly()" id="TXT_NUM_APP_COLL_12_2A" runat="server" MaxLength="1"
												Columns="2" ReadOnly="True" BackColor="Gainsboro"></asp:textbox>&nbsp;2B&nbsp;
											<asp:textbox onkeypress="return numbersonly()" id="TXT_NUM_APP_COLL_12_2B" runat="server" MaxLength="1"
												Columns="2" ReadOnly="True" BackColor="Gainsboro"></asp:textbox>&nbsp;2C
											<asp:textbox onkeypress="return numbersonly()" id="TXT_NUM_APP_COLL_12_2C" runat="server" MaxLength="1"
												Columns="2" ReadOnly="True" BackColor="Gainsboro"></asp:textbox>&nbsp;&gt;= 
											3
											<asp:textbox onkeypress="return numbersonly()" id="TXT_NUM_APP_COLL_12_3PLUS" runat="server"
												MaxLength="1" Columns="2" ReadOnly="True" BackColor="Gainsboro"></asp:textbox>Kali</TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 360px; HEIGHT: 22px">Perusahaan Tercatat dalam 
											Daftar Hitam di BM</TD>
										<TD style="WIDTH: 9px; HEIGHT: 22px"></TD>
										<TD style="HEIGHT: 22px"><asp:dropdownlist id="DDL_PERUSH_BLBM_CURR" runat="server" Enabled="False">
												<asp:ListItem Value="N">TIDAK</asp:ListItem>
												<asp:ListItem Value="Y">YA</asp:ListItem>
											</asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 360px">
											Perusahaan Tercatat&nbsp;dalam Daftar Hitam di BI</TD>
										<TD style="WIDTH: 9px"><STRONG></STRONG></TD>
										<TD><asp:dropdownlist id="DDL_PERUSH_BLBI_CURR" runat="server" Enabled="False" CssClass="mandatory" onselectedindexchanged="DDL_PERUSH_BLBI_CURR_SelectedIndexChanged">
												<asp:ListItem Value="N">TIDAK</asp:ListItem>
												<asp:ListItem Value="Y">YA</asp:ListItem>
											</asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 360px; HEIGHT: 2px">WatchList</TD>
										<TD style="WIDTH: 9px; HEIGHT: 2px"></TD>
										<TD style="HEIGHT: 2px"><asp:dropdownlist id="DDL_WATCH_LIST" runat="server" Enabled="False">
												<asp:ListItem Value="N">TIDAK</asp:ListItem>
												<asp:ListItem Value="Y">YA</asp:ListItem>
											</asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 360px; HEIGHT: 16px">KMK Limit di Bank Mandiri 
											pada Saat Ini (dalam ribuan)</TD>
										<TD style="WIDTH: 9px; HEIGHT: 16px"></TD>
										<TD style="HEIGHT: 16px"><asp:textbox onkeypress="return numbersonly()" id="TXT_KMK_LMT_BM_CURR" onblur="FormatCurrency(this)"
												runat="server" MaxLength="8" Enabled="False">0</asp:textbox></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 334px" colSpan="3"><FONT style="BACKGROUND-COLOR: #e5ebf4"></FONT></TD>
									</TR>
									<TR>
										<TD class="tdHeader1" align="center" colSpan="3">
											Pemilik</TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 360px; HEIGHT: 13px">Kolektibilitas Pemilik 
											saat ini di BM&nbsp;</TD>
										<TD style="WIDTH: 9px; HEIGHT: 13px"></TD>
										<TD style="HEIGHT: 13px"><asp:dropdownlist id="DDL_KEY_BM_COLL" runat="server" Width="192px" Enabled="False"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 360px">Frekuensi Kolektibilitas Pemilik &gt;= 
											2C 12 Bulan Terakhir</TD>
										<TD style="WIDTH: 9px"></TD>
										<TD><asp:textbox onkeypress="return numbersonly()" id="TXT_KEY_BM_COLL_2C" runat="server" Width="32px"
												MaxLength="1" ReadOnly="True" BackColor="Gainsboro"></asp:textbox>Kali</TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 360px">Pemilik Tercatat&nbsp;dalam Daftar 
											Hitam di BM</TD>
										<TD style="WIDTH: 9px"></TD>
										<TD><asp:dropdownlist id="DDL_KEY_BM_BL" runat="server" Enabled="False">
												<asp:ListItem Value="N">TIDAK</asp:ListItem>
												<asp:ListItem Value="Y">YA</asp:ListItem>
											</asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 360px; HEIGHT: 19px">Pemilik tercatat dalam 
											Daftar Hitam di BI</TD>
										<TD style="WIDTH: 9px; HEIGHT: 19px"></TD>
										<TD style="HEIGHT: 19px"><asp:dropdownlist id="DDL_KEY_BI_BM" runat="server" Enabled="False" CssClass="mandatory">
												<asp:ListItem Value="N">TIDAK</asp:ListItem>
												<asp:ListItem Value="Y">YA</asp:ListItem>
											</asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 360px; HEIGHT: 19px">Kolektibilitas Pemilik 
											saat ini di bank lain (IDI BI)</TD>
										<TD style="WIDTH: 9px; HEIGHT: 19px"></TD>
										<TD style="HEIGHT: 19px"><asp:dropdownlist id="DDL_KEY_BI_COLL_LVL" runat="server" Enabled="False"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 360px; HEIGHT: 19px">Kolektibilitas Pemilik 12 
											bulan terakhir di bank lain (IDI BI)</TD>
										<TD style="WIDTH: 9px; HEIGHT: 19px"></TD>
										<TD style="HEIGHT: 19px"><asp:dropdownlist id="DDL_KEY_BI_COLL_LVL_12BLN" runat="server" Enabled="False"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 360px; HEIGHT: 17px" colSpan="3"></TD>
									</TR>
									<TR>
										<TD class="tdHeader1" colSpan="3">Key Person
											<asp:Label id="LBL_JUDUL" runat="server" Visible="False">[ Management ]</asp:Label></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 360px; HEIGHT: 16px">Kolektibilitas&nbsp;Key 
											Person saat&nbsp;ini&nbsp;di BM</TD>
										<TD style="WIDTH: 9px; HEIGHT: 16px"></TD>
										<TD style="HEIGHT: 16px"><asp:dropdownlist id="DDL_MGM_BM_COLL_CURR" runat="server" Enabled="False"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 360px">Frekuensi Kolektibilitas&nbsp;Key 
											Person&nbsp;&gt;= 2C 12 Bulan Terakhir</TD>
										<TD style="WIDTH: 9px"></TD>
										<TD><asp:textbox onkeypress="return numbersonly()" id="TXT_MGM_BM_COLL_2C" runat="server" MaxLength="1"
												Columns="2" ReadOnly="True" BackColor="Gainsboro"></asp:textbox>Kali</TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 360px; HEIGHT: 21px">
											Key Person&nbsp;Tercatat&nbsp;dalam Daftar Hitam di BI</TD>
										<TD style="WIDTH: 9px; HEIGHT: 21px"></TD>
										<TD style="HEIGHT: 21px"><asp:dropdownlist id="DDL_MGM_BLBI" runat="server" DESIGNTIMEDRAGDROP="158" Enabled="False">
												<asp:ListItem Value="N">TIDAK</asp:ListItem>
												<asp:ListItem Value="Y">YA</asp:ListItem>
											</asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 360px">Kolektibilitas&nbsp;Key Person saat ini 
											di bank lain (IDI BI)</TD>
										<TD style="WIDTH: 9px"></TD>
										<TD><asp:dropdownlist id="DDL_MGM_BI_COLL_LVL" runat="server" Enabled="False"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 360px">Kolektibilitas&nbsp;Key Person 12 bulan 
											terakhir di bank lain (IDI BI)</TD>
										<TD style="WIDTH: 9px"></TD>
										<TD><asp:dropdownlist id="DDL_MGM_BI_COLL_LVL_12BLN" runat="server" Enabled="False"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 360px">
											Key Person&nbsp;Tercatat&nbsp;dalam Daftar Hitam di BM</TD>
										<TD style="WIDTH: 9px"></TD>
										<TD><asp:dropdownlist id="DDL_MGM_BLBM" runat="server" Enabled="False">
												<asp:ListItem Value="N">TIDAK</asp:ListItem>
												<asp:ListItem Value="Y">YA</asp:ListItem>
											</asp:dropdownlist></TD>
									</TR>
								</TABLE>
							</td>
						</TR>
						<!-- ************************* separator *************------------------------------------------------------------------------------------------------------------------------------------------->
						<TR>
							<TD class="TDBGColor2" vAlign="top" align="center" colSpan="2"><asp:button id="BTN_SAVE" runat="server" Width="100px" Text="Save" CssClass="Button1" onclick="BTN_SAVE_Click"></asp:button></TD>
						</TR>
					</TBODY>
				</TABLE>
			</center>
		</form>
		</TR></TBODY></TABLE></TR></TBODY></TABLE>
		<CENTER></CENTER>
		</FORM>
	</body>
</HTML>
