<%@ Page language="c#" Codebehind="CRSS.aspx.cs" AutoEventWireup="True" Inherits="SME.Scoring.CRSS" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CRSS</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include  file="../include/cek_all.html" -->
		<!-- #include  file="../include/onepost.html" -->
		<!-- #include  file="../include/ConfirmBox.html" -->
		<script language="javascript">
		/**
		function update()
		{
			ans = confirm("Are you sure you want to update?");
		
			if (ans)
			{
				return true;
			}
			else 
			{
				return false;
			}
		}**/
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
				<TBODY>
					<TR>
						<TD class="tdNoBorder"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
							<TABLE id="Table6">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Scoring&nbsp;: CRSS</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="../Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" vAlign="top" colSpan="2">Personal Data</TD>
					</TR>
					<!-- ************************* separator *************------------------------------------------------------------------------------------------------------------------------------------------->
					<!-- ************************* separator *************------------------------------------------------------------------------------------------------------------------------------------------->
					<TR>
						<TD style="HEIGHT: 20px" align="center" colSpan="2">
							<!-- #############################################################################################################################################################-->
							<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100%" border="1">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 162px">Nama Pemohon:</TD>
									<TD style="WIDTH: 277px"><asp:textbox id="txt_SC_NMMOHON" runat="server" ReadOnly="True" Width="100%" BorderStyle="None"></asp:textbox></TD>
									<TD class="TDBGColor1" style="WIDTH: 171px">Tgl. Aplikasi:</TD>
									<TD><asp:textbox onkeypress="return numbersonly()" id="txt_SC_TGLAPP_dd" Width="25px" Enabled="False"
											MaxLength="2" Runat="server" Columns="2"></asp:textbox><asp:dropdownlist id="ddl_SC_TGLAPP_mm" Width="100px" Enabled="False" Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="txt_SC_TGLAPP_yy" Width="50px" Enabled="False"
											MaxLength="4" Runat="server" Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 162px">Alamat:</TD>
									<TD style="WIDTH: 277px" rowSpan="3"><asp:textbox id="txt_SC_ALAMAT" runat="server" ReadOnly="True" Width="100%" BorderStyle="None"
											Height="71px" TextMode="MultiLine"></asp:textbox></TD>
									<TD class="TDBGColor1" style="WIDTH: 171px">No. Aplikasi:</TD>
									<TD><asp:textbox id="txt_SC_AANO" runat="server" ReadOnly="True" Width="100%" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 162px">&nbsp;</TD>
									<TD class="TDBGColor1" style="WIDTH: 171px">No. Customer:</TD>
									<TD><asp:textbox id="txt_SC_REFNO" runat="server" ReadOnly="True" Width="100%" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 162px; HEIGHT: 24px">&nbsp;</TD>
									<TD class="TDBGColor1" style="WIDTH: 171px; HEIGHT: 24px">Group/Cabang/CBC:</TD>
									<TD style="HEIGHT: 24px"><asp:textbox id="txt_SC_CABANG" runat="server" ReadOnly="True" Width="100%" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 162px; HEIGHT: 24px">Kota:</TD>
									<TD style="WIDTH: 277px; HEIGHT: 24px"><asp:textbox id="txt_SC_KOTA" runat="server" ReadOnly="True" Width="100%" BorderStyle="None"></asp:textbox></TD>
									<TD class="TDBGColor1" style="WIDTH: 171px; HEIGHT: 24px">Team Leader:</TD>
									<TD style="HEIGHT: 24px"><asp:textbox id="txt_SC_TEAMLEAD" runat="server" ReadOnly="True" Width="100%" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 162px">Kode Pos:</TD>
									<TD style="WIDTH: 277px"><asp:textbox id="txt_SC_KDPOS" runat="server" ReadOnly="True" Width="100%" BorderStyle="None"></asp:textbox></TD>
									<TD class="TDBGColor1" style="WIDTH: 171px">Relationship Manager:</TD>
									<TD><asp:textbox id="txt_SC_RELMNGR" runat="server" ReadOnly="True" Width="100%" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 162px">No. Telepon:</TD>
									<TD style="WIDTH: 277px"><asp:textbox id="txt_SC_TELP" runat="server" ReadOnly="True" Width="100%" BorderStyle="None"></asp:textbox></TD>
									<TD class="TDBGColor1" style="WIDTH: 171px">Nama Analis:</TD>
									<TD><asp:textbox id="txt_SC_NMANALIS" runat="server" ReadOnly="True" Width="100%" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 162px">Bidang Usaha:</TD>
									<TD style="WIDTH: 277px"><asp:textbox id="txt_SC_BIDUSAHA" runat="server" ReadOnly="True" Width="100%" BorderStyle="None"></asp:textbox></TD>
									<TD class="TDBGColor1" style="WIDTH: 171px">Bisnis Unit:</TD>
									<TD><asp:textbox id="txt_SC_BINISUNIT" runat="server" ReadOnly="True" Width="100%" BorderStyle="None"></asp:textbox></TD>
								</TR>
							</TABLE>
							<!-- #############################################################################################################################################################--></TD>
					</TR>
					<!-- diremark dulu tgl 21 sept 2004 ------
						<TR>
							<td class="tdNoBorder" align="center" colSpan="2">
								<table width="100%">
									<tr>
										<td width="60%">Nasabah menyerahkan laporan keuangan dua periode</td>
										<td width="30%"><asp:radiobutton id="RBTN_LAPKEU1" runat="server"></asp:radiobutton></td>
										<td width="30%"><asp:radiobutton id="RadioButton2" runat="server"></asp:radiobutton></td>
									</tr>
								</table>
							</td>
						</TR>
						------------------------------------------------------------------------------------------------------------------------------------------->
					<TR>
						<TD style="HEIGHT: 1px" align="center" colSpan="2"></TD>
					</TR>
					<tr>
						<td class="tdHeader1" colSpan="2"></td>
					</tr>
					<!--  separator ------------------------------------------------------------------------------------------------------------------------------------------>
					<TR>
						<!--<td align="center" colSpan="2">--></TR>
				</TBODY>
			</TABLE>
			<table cellSpacing="0" cellPadding="0" width="100%" border="1">
				<TBODY>
					<TR>
						<TD style="PADDING-LEFT: 10px" align="left" width="346"><B>1. Financial Ratio</B></TD>
						<TD style="PADDING-LEFT: 10px; WIDTH: 299px" align="left" width="299" colSpan="2"><nobr></B>Score: 
								1, 4, 8, 10</nobr></TD>
						<TD style="PADDING-RIGHT: 10px" align="center" width="30%" colSpan="4"><asp:textbox onkeypress="return numbersonly()" id="txt_FinancialRatio" style="TEXT-ALIGN: center"
								runat="server" ReadOnly="True" Width="100%" MaxLength="2" Height="30px" Font-Size="Medium" BackColor="Gainsboro" Font-Bold="True"></asp:textbox></TD>
					</TR>
					<tr class="TblAlternating">
						<td style="PADDING-LEFT: 10px; HEIGHT: 20px" align="left" width="346">&nbsp;&nbsp;&nbsp;a. 
							Equity Return</td>
						</TD>
						<td style="PADDING-LEFT: 10px; WIDTH: 299px; HEIGHT: 20px" align="left" width="299"
							colSpan="2"><nobr>1: Good</nobr></td>
						<td style="PADDING-RIGHT: 10px; HEIGHT: 20px" align="center" width="30%" colSpan="4"><asp:textbox onkeypress="return numbersonly()" id="txt_SC_FC_EQUITYRETURN" style="TEXT-ALIGN: center"
								tabIndex="1" runat="server" Width="100%" MaxLength="2" Font-Bold="True" CssClass="mandatory"></asp:textbox></td>
					</tr>
					<tr>
						<td style="PADDING-LEFT: 10px; HEIGHT: 24px" align="left" width="346">&nbsp;&nbsp;&nbsp;b. 
							Return on Total Capital</td>
						</TD>
						<td style="PADDING-LEFT: 10px; WIDTH: 299px; HEIGHT: 24px" align="left" width="299"
							colSpan="2"><nobr>4: Satisfactory</nobr></td>
						<td style="PADDING-RIGHT: 10px; HEIGHT: 24px" align="left" width="30%" colSpan="4"><asp:textbox onkeypress="return numbersonly()" id="txt_SC_FC_TOTCAPITAL" style="TEXT-ALIGN: center"
								tabIndex="2" runat="server" Width="100%" MaxLength="2" Font-Bold="True" CssClass="mandatory"></asp:textbox></td>
					</tr>
					<!--  START baris 5 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
					<tr class="TblAlternating" id="br5">
						<td style="PADDING-LEFT: 10px" align="left" width="346">&nbsp;&nbsp;&nbsp;c. Gross 
							Cash Flow as % of&nbsp; Net Liabilities</td>
						</TD>
						<td style="PADDING-LEFT: 10px; WIDTH: 299px" align="left" width="299" colSpan="2"><nobr>8: 
								Not Meaningfull / Older than 2 Years</nobr></td>
						<td style="PADDING-RIGHT: 10px" align="center" width="30%" colSpan="4"><asp:textbox onkeypress="return numbersonly()" id="txt_SC_FC_NETLIABI" style="TEXT-ALIGN: center"
								tabIndex="3" runat="server" Width="100%" MaxLength="2" Font-Bold="True" CssClass="mandatory"></asp:textbox></td>
					</tr>
					<!--  START baris 6 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
					<tr id="br6" bgColor="#ffffff">
						<td style="PADDING-LEFT: 10px" align="left" width="346">&nbsp;&nbsp;&nbsp;d. 
							Liquidity/Financial Structure</td>
						</TD>
						<td style="PADDING-LEFT: 10px; WIDTH: 299px" align="left" width="299" colSpan="2"><nobr>10: 
								Unsatisfactory</nobr></td>
						<td style="PADDING-RIGHT: 10px" align="center" width="30%" colSpan="4"><asp:textbox onkeypress="return numbersonly()" id="txt_SC_FC_LIQUIDITY" style="TEXT-ALIGN: center"
								tabIndex="4" runat="server" Width="100%" MaxLength="2" Font-Bold="True" CssClass="mandatory"></asp:textbox></td>
					</tr>
					<!--  START baris 7 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
					<tr class="TblAlternating" id="br7">
						<td style="PADDING-LEFT: 10px; HEIGHT: 13px" align="left" width="346">&nbsp;&nbsp;&nbsp;e. 
							Revenue Development</td>
						</TD>
						<td style="WIDTH: 299px; HEIGHT: 13px" align="center" width="299" colSpan="2">&nbsp;</td>
						<td style="PADDING-RIGHT: 10px" align="center" width="30%" colSpan="4"><asp:textbox onkeypress="return numbersonly()" id="txt_SC_FC_REVENUEDEV" style="TEXT-ALIGN: center"
								tabIndex="5" runat="server" Width="100%" MaxLength="2" Font-Bold="True" CssClass="mandatory"></asp:textbox></td>
					</tr>
					<!--  START baris 8 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
					<tr id="br8" bgColor="#ffffff">
						<td style="PADDING-LEFT: 10px; HEIGHT: 23px" align="left" width="346">&nbsp;&nbsp;&nbsp;f. 
							Gross Cash Flow as % Total Output</td>
						</TD>
						<td style="WIDTH: 299px; HEIGHT: 23px" align="center" width="299" colSpan="2">&nbsp;</td>
						<td style="PADDING-RIGHT: 10px; HEIGHT: 23px" align="center" width="30%" colSpan="4"><asp:textbox onkeypress="return numbersonly()" id="txt_SC_FC_TOTALOUT" style="TEXT-ALIGN: center"
								tabIndex="6" runat="server" Width="100%" MaxLength="2" Font-Bold="True" CssClass="mandatory"></asp:textbox></td>
					</tr>
					<!--  START baris 9 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
					<TR>
						<TD style="PADDING-LEFT: 10px; HEIGHT: 25px" align="left" width="346" colSpan="7">&nbsp;</TD>
					</TR>
					<tr id="br9">
						<td style="PADDING-LEFT: 10px" align="left" width="346"><STRONG>2. Legal Status</STRONG></td>
						</TD>
						<td style="PADDING-LEFT: 10px; WIDTH: 299px" align="left" width="299" colSpan="2"><nobr></B>Score: 
								1 - 4</nobr></td>
						<td style="PADDING-RIGHT: 10px" align="center" width="30%" colSpan="4"><asp:textbox onkeypress="return numbersonly()" id="txt_SC_LEGALSTAT" style="TEXT-ALIGN: center"
								tabIndex="7" runat="server" Width="100%" MaxLength="2" Height="30px" Font-Size="Medium" Font-Bold="True" CssClass="mandatory"></asp:textbox></td>
					</tr>
					<!--  START baris 10 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
					<TR class="TblAlternating">
						<TD style="PADDING-LEFT: 10px; HEIGHT: 22px" align="left" width="346"><nobr>&nbsp;&nbsp; 
								1 = Sole proprietorship/partnership with personally liable partners supported 
								by private assets</nobr></TD>
						<TD style="WIDTH: 299px; HEIGHT: 22px" align="center" width="299" colSpan="2">&nbsp;&nbsp;</TD>
						<TD style="PADDING-RIGHT: 10px; HEIGHT: 22px" align="center" width="30%" colSpan="4">&nbsp;</TD>
					</TR>
					<TR>
						<TD style="PADDING-LEFT: 10px; HEIGHT: 21px" align="left" width="346">&nbsp;&nbsp; 
							3 = Sole proprietorship/partnership&nbsp;without private assets</TD>
						<TD style="WIDTH: 299px; HEIGHT: 21px" align="center" width="299" colSpan="2">&nbsp;</TD>
						<TD style="PADDING-RIGHT: 10px" align="center" width="30%" colSpan="4">&nbsp;</TD>
					</TR>
					<TR class="TblAlternating">
						<TD style="PADDING-LEFT: 10px" align="left" width="346">&nbsp;&nbsp; 2 = Publicly 
							listed Perseroan Terbatas (PT)</TD>
						<TD style="WIDTH: 299px" align="center" width="299" colSpan="2">&nbsp;&nbsp;</TD>
						<TD style="PADDING-RIGHT: 10px" align="center" width="30%" colSpan="4"></TD>
					</TR>
					<TR>
						<TD style="PADDING-LEFT: 10px" align="left" width="346">&nbsp;&nbsp; 4 = Non-listed 
							Perseroan terbatas</TD>
						<TD style="WIDTH: 299px" align="center" width="299" colSpan="2">&nbsp;</TD>
						<TD style="PADDING-RIGHT: 10px" align="center" width="30%" colSpan="4">&nbsp;</TD>
					</TR>
					<TR class="TblAlternating">
						<TD style="PADDING-LEFT: 10px; HEIGHT: 22px" align="left" width="346">&nbsp;&nbsp;&nbsp;1 
							= Publicly listed state owned companies</TD>
						<TD style="WIDTH: 299px; HEIGHT: 22px" align="center" width="299" colSpan="2">&nbsp;&nbsp;</TD>
						<TD style="PADDING-RIGHT: 10px; HEIGHT: 22px" align="center" width="30%" colSpan="4">&nbsp;</TD>
					</TR>
					<TR>
						<TD style="PADDING-LEFT: 10px" align="left" width="346">&nbsp;&nbsp; 2 = Non-listed 
							state owned companies</TD>
						<TD style="WIDTH: 299px" align="center" width="299" colSpan="2">&nbsp;&nbsp;</TD>
						<TD style="PADDING-RIGHT: 10px" align="center" width="30%" colSpan="4">&nbsp;</TD>
					</TR>
					<TR>
						<TD style="PADDING-LEFT: 10px; HEIGHT: 25px" align="left" width="346" colSpan="7">&nbsp;</TD>
					</TR>
					<tr>
						<td style="PADDING-LEFT: 10px; HEIGHT: 20px" align="left" width="346"><STRONG>3. 
								Relationship</STRONG></td>
						</TD>
						<td style="PADDING-LEFT: 10px; WIDTH: 299px; HEIGHT: 20px" align="left" width="299"
							colSpan="2"><nobr></B>Score: 1, 4, 6</nobr></td>
						<td style="PADDING-RIGHT: 10px; HEIGHT: 20px" align="center" width="30%" colSpan="4"><asp:textbox onkeypress="return numbersonly()" id="txt_Relationship" style="TEXT-ALIGN: center"
								runat="server" ReadOnly="True" Width="100%" MaxLength="2" Height="30px" Font-Size="Medium" BackColor="Gainsboro" Font-Bold="True"></asp:textbox></td>
					</tr>
					<tr class="TblAlternating">
						<td style="PADDING-LEFT: 10px; HEIGHT: 22px" align="left" width="346">&nbsp;&nbsp;&nbsp;a. 
							Provision of Information</td>
						</TD>
						<td style="PADDING-LEFT: 10px; WIDTH: 299px; HEIGHT: 22px" align="left" width="299"
							colSpan="2"><nobr>1: No objections / as agreed</nobr></td>
						<td style="PADDING-RIGHT: 10px; HEIGHT: 22px" align="center" width="30%" colSpan="4"><asp:textbox onkeypress="return numbersonly()" id="txt_SC_R_PROVINFO" style="TEXT-ALIGN: center"
								tabIndex="8" runat="server" Width="100%" MaxLength="2" Font-Bold="True" CssClass="mandatory"></asp:textbox></td>
					</tr>
					<!--  START baris 12 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
					<tr>
						<td style="PADDING-LEFT: 10px" align="left" width="346">&nbsp;&nbsp;&nbsp;b. 
							Conduct of Accont</td>
						</TD>
						<td style="PADDING-LEFT: 10px; WIDTH: 299px" align="left" width="299" colSpan="2"><nobr>4: 
								Not know (insignificant account/new relationship)</nobr></td>
						<td style="PADDING-RIGHT: 10px" align="center" width="30%" colSpan="4"><asp:textbox onkeypress="return numbersonly()" id="txt_SC_R_CONDACC" style="TEXT-ALIGN: center"
								tabIndex="9" runat="server" Width="100%" MaxLength="2" Font-Bold="True" CssClass="mandatory"></asp:textbox></td>
					</tr>
					<tr class="TblAlternating">
						<td style="PADDING-LEFT: 10px" align="left" width="346">&nbsp;&nbsp;&nbsp;c. 
							Honoring of Agreement</td>
						</TD>
						<td style="PADDING-LEFT: 10px; WIDTH: 299px" align="left" width="299" colSpan="2"><nobr>6: 
								Tense</nobr></td>
						<td style="PADDING-RIGHT: 10px" align="center" width="30%" colSpan="4"><asp:textbox onkeypress="return numbersonly()" id="txt_SC_R_HONAGREE" style="TEXT-ALIGN: center"
								tabIndex="10" runat="server" Width="100%" MaxLength="2" Font-Bold="True" CssClass="mandatory"></asp:textbox></td>
					</tr>
					<TR>
						<TD style="PADDING-LEFT: 10px; HEIGHT: 25px" align="left" width="346" colSpan="7">&nbsp;</TD>
					</TR>
					<tr>
						<td style="PADDING-LEFT: 10px" align="left" width="346"><STRONG>4. Market Position</STRONG></td>
						</TD>
						<td style="PADDING-LEFT: 10px; WIDTH: 299px" align="left" width="299" colSpan="2"><nobr></B>Score: 
								1-10 / least risky to riskiest</nobr></td>
						<td style="PADDING-RIGHT: 10px" align="center" width="30%" colSpan="4"><asp:textbox onkeypress="return numbersonly()" id="txt_MarketPosition" style="TEXT-ALIGN: center"
								runat="server" ReadOnly="True" Width="100%" MaxLength="2" Height="30px" Font-Size="Medium" BackColor="Gainsboro" Font-Bold="True"></asp:textbox></td>
					</tr>
					<tr class="TblAlternating">
						<td style="PADDING-LEFT: 10px" align="left" width="346">&nbsp;&nbsp;&nbsp;a. 
							Product Quality, Adequate of&nbsp; Product Range</td>
						</TD>
						<td style="WIDTH: 299px" align="center" width="299" colSpan="2">&nbsp;</td>
						<td style="PADDING-RIGHT: 10px" align="center" width="30%" colSpan="4"><asp:textbox onkeypress="return numbersonly()" id="txt_SC_MP_PRODQUAL" style="TEXT-ALIGN: center"
								tabIndex="11" runat="server" Width="100%" MaxLength="2" Font-Bold="True" CssClass="mandatory"></asp:textbox></td>
					</tr>
					<tr>
						<td style="PADDING-LEFT: 10px" align="left" width="346">&nbsp;&nbsp;&nbsp;b. 
							Marketing Strategy &amp; Distribution System</td>
						</TD>
						<td style="WIDTH: 299px" align="center" width="299" colSpan="2">&nbsp;</td>
						<td style="PADDING-RIGHT: 10px" align="center" width="30%" colSpan="4"><asp:textbox onkeypress="return numbersonly()" id="txt_SC_MP_MARKETSTRA" style="TEXT-ALIGN: center"
								tabIndex="12" runat="server" Width="100%" MaxLength="2" Font-Bold="True" CssClass="mandatory"></asp:textbox></td>
					</tr>
					<TR class="TblAlternating">
						<TD style="PADDING-LEFT: 10px" align="left" width="346">&nbsp;&nbsp; c. Demand 
							situation, Competitive Situation</TD>
						<TD style="WIDTH: 299px" align="center" width="299" colSpan="2">&nbsp;</TD>
						<TD style="PADDING-RIGHT: 10px" align="center" width="30%" colSpan="4"><asp:textbox onkeypress="return numbersonly()" id="txt_SC_MP_DEMANDSIT" style="TEXT-ALIGN: center"
								tabIndex="13" runat="server" Width="100%" MaxLength="2" Font-Bold="True" CssClass="mandatory"></asp:textbox></TD>
					</TR>
					<tr>
						<td style="PADDING-RIGHT: 10px; PADDING-LEFT: 10px" align="left" width="346">&nbsp;&nbsp;&nbsp;d. 
							Depencence (on one supplier or major buyer)</td>
						</TD>
						<td style="WIDTH: 299px" align="center" width="299" colSpan="2">&nbsp;</td>
						<td style="PADDING-RIGHT: 10px" align="center" width="30%" colSpan="4"><asp:textbox onkeypress="return numbersonly()" id="txt_SC_MP_DEPENDENCE" style="TEXT-ALIGN: center"
								tabIndex="14" runat="server" Width="100%" MaxLength="2" Font-Bold="True" CssClass="mandatory"></asp:textbox></td>
					</tr>
					<tr class="TblAlternating">
						<td style="PADDING-LEFT: 10px" align="left" width="346"><nobr>&nbsp;&nbsp;&nbsp;e. Risk 
								(Environmental, Product Liabilities, Product Develomment)</nobr></td>
						</TD>
						<td style="WIDTH: 299px" align="center" width="299" colSpan="2">&nbsp;</td>
						<td style="PADDING-RIGHT: 10px" align="center" width="30%" colSpan="4"><asp:textbox onkeypress="return numbersonly()" id="txt_SC_MP_RISKS" style="TEXT-ALIGN: center"
								tabIndex="15" runat="server" Width="100%" MaxLength="2" Font-Bold="True" CssClass="mandatory"></asp:textbox></td>
					</tr>
					<TR>
						<TD style="PADDING-LEFT: 10px; HEIGHT: 25px" align="left" width="346" colSpan="7">&nbsp;</TD>
					</TR>
					<tr>
						<td style="PADDING-LEFT: 10px" align="left" width="346"><STRONG>5. Management</STRONG></td>
						</TD>
						<td style="PADDING-LEFT: 10px; WIDTH: 299px" align="left" width="299" colSpan="2"><nobr></B>Score: 
								1 - 10 least risky to riskiest</nobr></td>
						<td style="PADDING-RIGHT: 10px" align="center" width="30%" colSpan="4"><asp:textbox onkeypress="return numbersonly()" id="txt_Management" style="TEXT-ALIGN: center"
								runat="server" ReadOnly="True" Width="100%" MaxLength="2" Height="30px" Font-Size="Medium" BackColor="Gainsboro" Font-Bold="True"></asp:textbox></td>
					</tr>
					<tr class="TblAlternating">
						<td style="PADDING-LEFT: 10px; HEIGHT: 22px" align="left" width="346">&nbsp;&nbsp;&nbsp;a. 
							Capability &amp; Integrity</td>
						</TD>
						<td style="WIDTH: 299px; HEIGHT: 22px" align="center" width="299" colSpan="2">&nbsp;</td>
						<td style="PADDING-RIGHT: 10px; HEIGHT: 22px" align="center" width="30%" colSpan="4"><asp:textbox onkeypress="return numbersonly()" id="txt_SC_M_CAPABILITY" style="TEXT-ALIGN: center"
								tabIndex="16" runat="server" Width="100%" MaxLength="2" Font-Bold="True" CssClass="mandatory"></asp:textbox></td>
					</tr>
					<tr id="br34" bgColor="#ffffff">
						<td style="PADDING-LEFT: 10px" align="left" width="346">&nbsp;&nbsp;&nbsp;b. 
							Strategic Vision</td>
						</TD>
						<td style="WIDTH: 299px" align="center" width="299" colSpan="2">&nbsp;</td>
						<td style="PADDING-RIGHT: 10px" align="center" width="30%" colSpan="4"><asp:textbox onkeypress="return numbersonly()" id="txt_SC_M_STRAVISI" style="TEXT-ALIGN: center"
								tabIndex="17" runat="server" Width="100%" MaxLength="2" Font-Bold="True" CssClass="mandatory"></asp:textbox></td>
					</tr>
					<TR class="TblAlternating">
						<TD style="PADDING-LEFT: 10px" align="left" width="346">&nbsp;&nbsp;&nbsp;c. 
							Internal Control</TD>
						</TD>
						<TD style="WIDTH: 299px" align="center" width="299" colSpan="2">&nbsp;</TD>
						<TD style="PADDING-RIGHT: 10px" align="center" width="30%" colSpan="4"><asp:textbox onkeypress="return numbersonly()" id="txt_SC_M_INTCTRL" style="TEXT-ALIGN: center"
								tabIndex="18" runat="server" Width="100%" MaxLength="2" Font-Bold="True" CssClass="mandatory"></asp:textbox></TD>
					</TR>
					<TR>
						<TD style="PADDING-LEFT: 10px; HEIGHT: 16px" align="left" width="346">&nbsp;&nbsp;&nbsp;d. 
							External Register Audit</TD>
						</TD>
						<TD style="WIDTH: 299px; HEIGHT: 16px" align="center" width="299" colSpan="2">&nbsp;</TD>
						<TD style="PADDING-RIGHT: 10px" align="center" width="30%" colSpan="4"><asp:textbox onkeypress="return numbersonly()" id="txt_SC_M_EXTREGAUDIT" style="TEXT-ALIGN: center"
								tabIndex="19" runat="server" Width="100%" MaxLength="2" Font-Bold="True" CssClass="mandatory"></asp:textbox></TD>
					</TR>
					<TR class="TblAlternating">
						<TD style="PADDING-LEFT: 10px" align="left" width="346">&nbsp;&nbsp;&nbsp;e. 
							Succession</TD>
						<TD style="WIDTH: 299px" align="center" width="299" colSpan="2">&nbsp;</TD>
						<TD style="PADDING-RIGHT: 10px" align="center" width="30%" colSpan="4"><asp:textbox onkeypress="return numbersonly()" id="txt_SC_M_SUCCESSION" style="TEXT-ALIGN: center"
								tabIndex="20" runat="server" Width="100%" MaxLength="2" Font-Bold="True" CssClass="mandatory"></asp:textbox></TD>
					</TR>
					<TR>
						<TD style="PADDING-LEFT: 10px; HEIGHT: 25px" align="left" width="346" colSpan="7">&nbsp;</TD>
					</TR>
					<TR>
						<TD style="PADDING-LEFT: 10px" align="left" width="346"><STRONG>6. Viability</STRONG></TD>
						</TD>
						<TD style="PADDING-LEFT: 10px; WIDTH: 299px" align="left" width="299" colSpan="2"><nobr></B>Score: 
								1 - 10 / least risky to riskiest</nobr></TD>
						<TD style="PADDING-RIGHT: 10px" align="center" width="30%" colSpan="4"><asp:textbox onkeypress="return numbersonly()" id="txt_Viability" style="TEXT-ALIGN: center"
								runat="server" ReadOnly="True" Width="100%" MaxLength="2" Height="30px" Font-Size="Medium" BackColor="Gainsboro" Font-Bold="True"></asp:textbox></TD>
					</TR>
					<TR class="TblAlternating">
						<TD style="PADDING-LEFT: 10px" align="left" width="346">&nbsp;&nbsp;&nbsp;a. 
							Availability of New Capital</TD>
						</TD>
						<TD style="WIDTH: 299px" align="center" width="299" colSpan="2">&nbsp;</TD>
						<TD style="PADDING-RIGHT: 10px" align="center" width="30%" colSpan="4"><asp:textbox onkeypress="return numbersonly()" id="txt_SC_V_NEWCAPITAL" style="TEXT-ALIGN: center"
								tabIndex="21" runat="server" Width="100%" MaxLength="2" Font-Bold="True" CssClass="mandatory"></asp:textbox></TD>
					</TR>
					<TR>
						<TD style="PADDING-LEFT: 10px" align="left" width="346">&nbsp;&nbsp;&nbsp;b. 
							Willingness to Solve Problem</TD>
						</TD>
						<TD style="WIDTH: 299px" align="center" width="299" colSpan="2">&nbsp;</TD>
						<TD style="PADDING-RIGHT: 10px" align="center" width="30%" colSpan="4"><asp:textbox onkeypress="return numbersonly()" id="txt_SC_V_SOLVPROB" style="TEXT-ALIGN: center"
								tabIndex="22" runat="server" Width="100%" MaxLength="2" Font-Bold="True" CssClass="mandatory"></asp:textbox></TD>
					</TR>
					<TR class="TblAlternating">
						<TD style="PADDING-LEFT: 10px" align="left" width="346">&nbsp;&nbsp;&nbsp;c. 
							Product Development &amp; Improvement</TD>
						</TD>
						<TD style="WIDTH: 299px" align="center" width="299" colSpan="2">&nbsp;</TD>
						<TD style="PADDING-RIGHT: 10px" align="center" width="30%" colSpan="4"><asp:textbox onkeypress="return numbersonly()" id="txt_SC_V_PRODDEV" style="TEXT-ALIGN: center"
								tabIndex="23" runat="server" Width="100%" MaxLength="2" Font-Bold="True" CssClass="mandatory"></asp:textbox></TD>
					</TR>
					<TR>
						<TD style="PADDING-LEFT: 10px" align="left" width="346">&nbsp;&nbsp;&nbsp;d. 
							Operational Problems</TD>
						</TD>
						<TD style="WIDTH: 299px" align="center" width="299" colSpan="2">&nbsp;</TD>
						<TD style="PADDING-RIGHT: 10px" align="center" width="30%" colSpan="4"><asp:textbox onkeypress="return numbersonly()" id="txt_SC_V_OPPROBLEM" style="TEXT-ALIGN: center"
								tabIndex="24" runat="server" Width="100%" MaxLength="2" Font-Bold="True" CssClass="mandatory"></asp:textbox></TD>
					</TR>
					<TR class="TblAlternating">
						<TD style="PADDING-LEFT: 10px; HEIGHT: 23px" align="left" width="346">&nbsp;&nbsp;&nbsp;e. 
							Manpower Problem</TD>
						<TD style="HEIGHT: 23px" align="center" width="301" colSpan="4">&nbsp;</TD>
						<TD style="PADDING-RIGHT: 10px; HEIGHT: 23px" align="center" width="30%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_SC_V_MANPROBLEM" style="TEXT-ALIGN: center"
								tabIndex="25" runat="server" Width="100%" MaxLength="2" Font-Bold="True" CssClass="mandatory"></asp:textbox></TD>
					</TR>
					<TR>
						<TD style="PADDING-LEFT: 10px; HEIGHT: 25px" align="left" width="346" colSpan="7">&nbsp;</TD>
					</TR>
					<TR>
						<TD style="PADDING-LEFT: 10px" align="left" width="346"><STRONG><nobr>7. Development Since 
									Latest Annual Report &amp; Future Prospect</nobr></STRONG></TD>
						<TD style="PADDING-LEFT: 10px" align="left" width="301" colSpan="4"><nobr></B>Score: 1, 
								3, 5, 7, 10</nobr></TD>
						<TD style="PADDING-RIGHT: 10px" align="center" width="30%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_Develop" style="TEXT-ALIGN: center" runat="server"
								ReadOnly="True" Width="100%" MaxLength="2" Height="30px" Font-Size="Medium" BackColor="Gainsboro" Font-Bold="True"></asp:textbox></TD>
					</TR>
					<TR class="TblAlternating">
						<TD style="PADDING-LEFT: 10px" align="left" width="346">&nbsp;&nbsp;&nbsp;a. 
							Interim Development &amp; Provitability Outlook</TD>
						<TD style="PADDING-LEFT: 10px" align="left" width="301" colSpan="4"><nobr>1: Very good</nobr></TD>
						<TD style="PADDING-RIGHT: 10px" align="center" width="30%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_SC_D_INTDEV" style="TEXT-ALIGN: center"
								tabIndex="26" runat="server" Width="100%" MaxLength="2" Font-Bold="True" CssClass="mandatory"></asp:textbox></TD>
					</TR>
					<TR>
						<TD style="PADDING-LEFT: 10px" align="left" width="346">&nbsp;&nbsp;&nbsp;b. 
							Medium/Long Term Industry Outlook</TD>
						<TD style="PADDING-LEFT: 10px" align="left" width="301" colSpan="4"><nobr>3: Good</nobr></TD>
						<TD style="PADDING-RIGHT: 10px" align="center" width="30%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_SC_D_INDOUTLOOK" style="TEXT-ALIGN: center"
								tabIndex="27" runat="server" Width="100%" MaxLength="2" Font-Bold="True" CssClass="mandatory"></asp:textbox></TD>
					</TR>
					<TR class="TblAlternating">
						<TD style="PADDING-LEFT: 10px; HEIGHT: 19px" align="left" width="346">&nbsp;</TD>
						<TD style="PADDING-LEFT: 10px; HEIGHT: 19px" align="left" width="301" colSpan="4"><nobr>5: 
								Satisfactory</nobr></TD>
						<TD style="PADDING-RIGHT: 10px; HEIGHT: 19px" align="center" width="30%" colSpan="2">&nbsp;</TD>
					</TR>
					<TR>
						<TD style="PADDING-LEFT: 10px" align="left" width="346">&nbsp;</TD>
						<TD style="PADDING-LEFT: 10px" align="left" width="301" colSpan="4"><nobr>7: Not 
								favorable but still acceptable</nobr></TD>
						<TD style="PADDING-RIGHT: 10px" align="center" width="30%" colSpan="2">&nbsp;
						</TD>
					</TR>
					<TR class="TblAlternating">
						<TD style="PADDING-LEFT: 10px" align="left" width="346">&nbsp;</TD>
						<TD style="PADDING-LEFT: 10px" align="left" width="301" colSpan="4"><nobr>10: Poor</nobr></TD>
						<TD style="PADDING-RIGHT: 10px" align="center" width="30%" colSpan="2">&nbsp;</TD>
					</TR>
					<TR>
						<TD style="PADDING-LEFT: 10px; HEIGHT: 25px" align="left" colSpan="7">&nbsp;</TD>
					</TR>
					<TR>
						<TD style="PADDING-LEFT: 10px" align="left"><STRONG>Determination of BI Rating (Risk 
								Factor) and Loan Loss Provisions</STRONG></TD>
						<TD style="PADDING-LEFT: 10px" align="left" width="301" colSpan="4"><STRONG>Total</STRONG></TD>
						<TD style="PADDING-RIGHT: 10px" align="center" width="30%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_Total" style="TEXT-ALIGN: center" runat="server"
								ReadOnly="True" Width="100%" MaxLength="2" Height="30px" Font-Size="Medium" BackColor="Gainsboro" Font-Bold="True"></asp:textbox></TD>
					</TR>
					<TR>
						<TD style="PADDING-LEFT: 10px" align="left" width="346">&nbsp;</TD>
						<TD style="PADDING-LEFT: 10px" align="left" width="301" colSpan="4"><STRONG>Actual Risk 
								Factor</STRONG></TD>
						<TD style="PADDING-RIGHT: 10px" align="center" width="30%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_Score" style="TEXT-ALIGN: center" runat="server"
								ReadOnly="True" Width="100%" MaxLength="2" Height="30px" Font-Size="Medium" BackColor="Gainsboro" Font-Bold="True"></asp:textbox></TD>
					</TR>
					<TR>
						<TD style="PADDING-LEFT: 10px" align="center" width="40%" colSpan="7"><asp:button id="btn_Calculate" tabIndex="28" runat="server" CssClass="button1" Text="Calculate" onclick="btn_Calculate_Click"></asp:button></TD>
					</TR>
				</TBODY>
			</table>
			</TD></TR></TBODY></TABLE></TD></TR>
			<table width="100%">
				<TBODY>
					<TR>
						<TD vAlign="top" align="center" colSpan="2">
							<table width="100%">
								<TBODY>
									<tr>
										<td class="tdBGColor2" align="center"><asp:button id="btn_Save" tabIndex="29" runat="server" CssClass="Button1" Text="Save" onclick="btn_Save_Click"></asp:button>&nbsp;<asp:button id="btn_UpdateStatus" tabIndex="30" runat="server" CssClass="Button1" Text="Update Status" onclick="btn_UpdateStatus_Click"></asp:button></td>
									</tr>
								</TBODY>
							</table>
						</TD>
					</TR>
				</TBODY>
			</table>
		</form>
	</body>
</HTML>
