<%@ Page language="c#" Codebehind="FIRSS_BPR.aspx.cs" AutoEventWireup="True" Inherits="SME.Scoring.FIRSS_BPR" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>FIRSS_BRP</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include  file="../include/cek_entries.html" -->
		<!-- #include  file="../include/cek_mandatoryOnly.html" -->
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
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Scoring&nbsp;: BPR</B></TD>
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
					<TR>
						<TD style="HEIGHT: 225px" align="center" colSpan="2">
							<!--##########################################################################################################################################-->
							<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100%" border="1">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 162px">Nama Pemohon:</TD>
									<TD style="WIDTH: 277px"><asp:textbox id="txt_SB_NMMOHON" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:textbox></TD>
									<TD class="TDBGColor1" style="WIDTH: 171px">Tgl. Aplikasi:</TD>
									<TD><asp:textbox onkeypress="return numbersonly()" id="txt_SB_TGLAPP_dd" Width="25px" Enabled="False"
											MaxLength="2" Runat="server" Columns="2"></asp:textbox><asp:dropdownlist id="ddl_SB_TGLAPP_mm" Width="100px" Enabled="False" Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="txt_SB_TGLAPP_yy" Width="50px" Enabled="False"
											MaxLength="4" Runat="server" Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 162px">Alamat:</TD>
									<TD style="WIDTH: 277px" rowSpan="3"><asp:textbox id="txt_SB_ALAMAT" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"
											Height="71px" TextMode="MultiLine"></asp:textbox></TD>
									<TD class="TDBGColor1" style="WIDTH: 171px">No. Aplikasi:</TD>
									<TD><asp:textbox id="txt_SB_AANO" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 162px">&nbsp;</TD>
									<TD class="TDBGColor1" style="WIDTH: 171px">No. Customer:</TD>
									<TD><asp:textbox id="txt_SB_REFNO" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 162px; HEIGHT: 24px">&nbsp;</TD>
									<TD class="TDBGColor1" style="WIDTH: 171px; HEIGHT: 24px">Group/Cabang/CBC:</TD>
									<TD style="HEIGHT: 24px"><asp:textbox id="txt_SB_CABANG" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 162px; HEIGHT: 24px">Kota:</TD>
									<TD style="WIDTH: 277px; HEIGHT: 24px"><asp:textbox id="txt_SB_KOTA" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:textbox></TD>
									<TD class="TDBGColor1" style="WIDTH: 171px; HEIGHT: 24px">Team Leader:</TD>
									<TD style="HEIGHT: 24px"><asp:textbox id="txt_SB_TEAMLEAD" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 162px">Kode Pos:</TD>
									<TD style="WIDTH: 277px"><asp:textbox id="txt_SB_KDPOS" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:textbox></TD>
									<TD class="TDBGColor1" style="WIDTH: 171px">Relationship Manager:</TD>
									<TD><asp:textbox id="txt_SB_RELMNGR" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 162px">No. Telepon:</TD>
									<TD style="WIDTH: 277px"><asp:textbox id="txt_SB_TELP" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:textbox></TD>
									<TD class="TDBGColor1" style="WIDTH: 171px">Nama Analis:</TD>
									<TD><asp:textbox id="txt_SB_NMANALIS" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 162px">Bidang Usaha:</TD>
									<TD style="WIDTH: 277px"><asp:textbox id="txt_SB_BIDUSAHA" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:textbox></TD>
									<TD class="TDBGColor1" style="WIDTH: 171px">Bisnis Unit:</TD>
									<TD><asp:textbox id="txt_SB_BINISUNIT" runat="server" BorderStyle="None" ReadOnly="True" Width="100%"></asp:textbox></TD>
								</TR>
							</TABLE>
							<!--##########################################################################################################################################--></TD>
					</TR>
					<tr>
						<td colSpan="2"></td>
					</tr>
					<TR>
					</TR>
				</TBODY>
			</TABLE>
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD class="tdSmallHeader" style="PADDING-LEFT: 10px; HEIGHT: 29px" align="left" width="60%"
						colSpan="7">I. ENVIRONMENTAL FACTORS <FONT class="font5">(to be completed only once 
							per country) (intermediate scores are permitted)</FONT></TD>
					</TD></TR>
				<TR>
					<TD style="PADDING-LEFT: 10px; WIDTH: 470px; HEIGHT: 22px" align="left" width="470"><B>1. 
							Stability of Home State</B></TD>
					<TD style="PADDING-LEFT: 10px; WIDTH: 274px; HEIGHT: 22px" align="left" width="274"
						colSpan="2"></B></NOBR></TD>
					<TD style="HEIGHT: 22px" align="left" width="10%" colSpan="4"><STRONG></STRONG></TD>
				</TR>
				<tr class="TblAlternating">
					<td style="PADDING-LEFT: 10px; WIDTH: 470px; HEIGHT: 20px" align="left" width="470">&nbsp;&nbsp;&nbsp; 
						a) Political Conditions</td>
					</TD></TD>
					<td style="HEIGHT: 20px" align="left" width="274" colSpan="2"><asp:dropdownlist id="ddl_SB_POLCON" runat="server" Width="400px" CssClass="mandatory" tabIndex="1">
							<asp:ListItem Value="0">- SELECT -</asp:ListItem>
							<asp:ListItem Value="1">Stable Political System</asp:ListItem>
							<asp:ListItem Value="3">Uncertain Stability of Political System</asp:ListItem>
							<asp:ListItem Value="5">Political Instability/Obstruction</asp:ListItem>
						</asp:dropdownlist></td>
					<td style="HEIGHT: 20px" align="center" width="10%" colSpan="4"><asp:textbox id="txt_SB_POLCON" style="PADDING-RIGHT: 10px; TEXT-ALIGN: center" runat="server"
							ReadOnly="True" Width="50px" BackColor="#DCDCDC" Font-Bold="True"></asp:textbox></td>
				</tr>
				<tr>
					<td style="PADDING-LEFT: 10px; WIDTH: 470px; HEIGHT: 15px" align="left" width="470">&nbsp;&nbsp;&nbsp; 
						b) Economic Condition</td>
					<td style="HEIGHT: 15px" align="center" width="274" colSpan="2"><asp:dropdownlist id="ddl_SB_ECONCON" runat="server" Width="400px" CssClass="mandatory" tabIndex="2">
							<asp:ListItem Value="0">- SELECT -</asp:ListItem>
							<asp:ListItem Value="1">Growing Economy</asp:ListItem>
							<asp:ListItem Value="3">Moderate Growth/Stable Economy</asp:ListItem>
							<asp:ListItem Value="5">Regressive/Weak Economy</asp:ListItem>
						</asp:dropdownlist></NOBR></td>
					<td style="HEIGHT: 15px" align="center" width="10%" colSpan="4"><asp:textbox id="txt_SB_ECONCON" style="PADDING-RIGHT: 10px; TEXT-ALIGN: center" runat="server"
							ReadOnly="True" Width="50px" BackColor="#DCDCDC" Font-Bold="True"></asp:textbox></td>
				</tr>
				<TR class="TblAlternating">
					<TD style="PADDING-LEFT: 10px; WIDTH: 470px; HEIGHT: 19px" align="left" width="470"></TD>
					<TD style="HEIGHT: 19px" align="center" width="274" colSpan="2"></TD>
					<TD style="HEIGHT: 19px" align="center" width="10%" colSpan="4"></TD>
				</TR>
				<TR>
					<TD style="PADDING-LEFT: 10px; WIDTH: 470px" align="left" width="470"><STRONG>2. 
							Financial System</STRONG></TD>
					</STRONG></TD>
					<TD align="center" width="274" colSpan="2"></TD>
					<TD align="center" width="10%" colSpan="4"></TD>
				</TR>
				<TR class="TblAlternating">
					<TD style="PADDING-LEFT: 10px; WIDTH: 470px; HEIGHT: 17px" align="left" width="470">&nbsp;&nbsp;&nbsp; 
						a) Legal Framework (Bank Laws, Accounting Regulations, Tax Law)
					</TD>
					<TD style="HEIGHT: 17px" align="center" width="274" colSpan="2"><asp:dropdownlist id="ddl_SB_LEGALFRM" runat="server" Width="400px" CssClass="mandatory" tabIndex="3">
							<asp:ListItem Value="0">- SELECT -</asp:ListItem>
							<asp:ListItem Value="1">Appropriate</asp:ListItem>
							<asp:ListItem Value="3">Essentially Adequate</asp:ListItem>
							<asp:ListItem Value="5">With Some Weaknesses</asp:ListItem>
							<asp:ListItem Value="7">Laws and Regulations Substandard</asp:ListItem>
							<asp:ListItem Value="10">Laws and Regulations Poor</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD style="HEIGHT: 17px" align="center" width="10%" colSpan="4"><asp:textbox id="txt_SB_LEGALFRM" style="PADDING-RIGHT: 10px; TEXT-ALIGN: center" runat="server"
							ReadOnly="True" Width="50px" BackColor="#DCDCDC" Font-Bold="True"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="PADDING-LEFT: 10px; WIDTH: 470px; HEIGHT: 15px" align="left" width="470">
					&nbsp;&nbsp;&nbsp; b) Performance of Regulatory Authorities (Supervision, 
					Control)
					<TD style="HEIGHT: 15px" align="center" width="274" colSpan="2"><asp:dropdownlist id="ddl_SB_PERFRA" runat="server" Width="400px" CssClass="mandatory" tabIndex="4">
							<asp:ListItem Value="0">- SELECT -</asp:ListItem>
							<asp:ListItem Value="1">Very Good</asp:ListItem>
							<asp:ListItem Value="3">Good</asp:ListItem>
							<asp:ListItem Value="4">Average</asp:ListItem>
							<asp:ListItem Value="7">Substandard</asp:ListItem>
							<asp:ListItem Value="10">Poor</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD style="HEIGHT: 15px" align="center" width="10%" colSpan="4"><asp:textbox id="txt_SB_PERFRA" style="PADDING-RIGHT: 10px; TEXT-ALIGN: center" runat="server"
							ReadOnly="True" Width="50px" BackColor="#DCDCDC" Font-Bold="True"></asp:textbox></TD>
				</TR>
				<TR class="TblAlternating">
					<TD style="PADDING-LEFT: 10px; WIDTH: 470px; HEIGHT: 17px" align="left" width="470">&nbsp;&nbsp;&nbsp; 
						c) Access to Money/Capital Market</TD>
					<TD style="HEIGHT: 17px" align="center" width="274" colSpan="2"><asp:dropdownlist id="ddl_SB_ACCMONEY" runat="server" Width="400px" CssClass="mandatory" tabIndex="5">
							<asp:ListItem Value="0">- SELECT -</asp:ListItem>
							<asp:ListItem Value="1">Free Access to Domestic and International Markets</asp:ListItem>
							<asp:ListItem Value="3">Restricted access to domestic and international markets</asp:ListItem>
							<asp:ListItem Value="5">No Access to International markets, domestic Markets not Developed</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD style="HEIGHT: 17px" align="center" width="10%" colSpan="4"><asp:textbox id="txt_SB_ACCMONEY" style="PADDING-RIGHT: 10px; TEXT-ALIGN: center" runat="server"
							ReadOnly="True" Width="50px" BackColor="#DCDCDC" Font-Bold="True"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="PADDING-LEFT: 10px; WIDTH: 470px; HEIGHT: 21px" align="left" width="470"></TD>
					<TD style="HEIGHT: 21px" align="center" width="274" colSpan="2"></TD>
					<TD style="HEIGHT: 21px" align="center" width="10%" colSpan="4"></TD>
				</TR>
				<TR>
					<TD class="tdSmallHeader" style="PADDING-LEFT: 10px; HEIGHT: 28px" align="left" width="60%"
						colSpan="7">II. FINANCIAL ANALYSIS (only defined scores permitted)</TD>
				</TR>
				<TR>
					<TD style="PADDING-LEFT: 10px; WIDTH: 470px; HEIGHT: 21px" align="left" width="470"><STRONG>1. 
							Auditing Report</STRONG></TD>
					<TD style="HEIGHT: 21px" align="center" width="274" colSpan="2"><STRONG>Diaudit</STRONG></TD>
					<TD style="HEIGHT: 21px" align="center" width="10%" colSpan="4"></TD>
				</TR>
				<TR class="TblAlternating">
					<TD style="PADDING-LEFT: 10px; WIDTH: 470px; HEIGHT: 16px" align="left" width="470">&nbsp;&nbsp;&nbsp; 
						a) Auditor's Reputation</TD>
					<TD style="HEIGHT: 16px" align="center" width="274" colSpan="2"><asp:dropdownlist id="ddl_SB_AUDITREP" runat="server" Width="400px" CssClass="mandatory" tabIndex="6">
							<asp:ListItem Value="0">- SELECT -</asp:ListItem>
							<asp:ListItem Value="1">Internationally Reputed</asp:ListItem>
							<asp:ListItem Value="2">Nationally Reputed</asp:ListItem>
							<asp:ListItem Value="5">Auditor Unknown</asp:ListItem>
							<asp:ListItem Value="7">Auditor has Negative Reputation/No Auditing</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD style="HEIGHT: 16px" align="center" width="10%" colSpan="4"><asp:textbox id="txt_SB_AUDITREP" style="PADDING-RIGHT: 10px; TEXT-ALIGN: center" runat="server"
							ReadOnly="True" Width="50px" BackColor="#DCDCDC" Font-Bold="True"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="PADDING-LEFT: 10px; WIDTH: 470px; HEIGHT: 18px" align="left" width="470">&nbsp;&nbsp;&nbsp; 
						b) Auditor's Opinion</TD>
					<TD style="HEIGHT: 18px" align="center" width="274" colSpan="2"><asp:dropdownlist id="ddl_SB_AUDITOPI" runat="server" Width="400px" CssClass="mandatory" tabIndex="7">
							<asp:ListItem Value="0">- SELECT -</asp:ListItem>
							<asp:ListItem Value="1">Unqualified Opinion</asp:ListItem>
							<asp:ListItem Value="3">Qualified Opinion: Non-Material</asp:ListItem>
							<asp:ListItem Value="7">Qualified Opinion: Material</asp:ListItem>
							<asp:ListItem Value="8">No Opinion/Auditor Refuses to Give Opinion</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD style="HEIGHT: 18px" align="center" width="10%" colSpan="4"><asp:textbox id="txt_SB_AUDITOPI" style="PADDING-RIGHT: 10px; TEXT-ALIGN: center" runat="server"
							ReadOnly="True" Width="50px" BackColor="#DCDCDC" Font-Bold="True"></asp:textbox></TD>
				</TR>
				<TR class="TblAlternating">
					<TD style="PADDING-LEFT: 10px; WIDTH: 470px; HEIGHT: 21px" align="left" width="470"></TD>
					<TD style="HEIGHT: 21px" align="center" width="274" colSpan="2"></TD>
					<TD style="HEIGHT: 21px" align="center" width="10%" colSpan="4"></TD>
				</TR>
				<TR>
					<TD style="PADDING-LEFT: 10px; WIDTH: 470px; HEIGHT: 21px" align="left" width="470"><STRONG>Financial 
							Data</STRONG></TD>
					<TD style="HEIGHT: 21px" align="center" width="274" colSpan="2"></TD>
					<TD style="HEIGHT: 21px" align="center" width="10%" colSpan="4"></TD>
				</TR>
				<TR class="TblAlternating">
					<TD style="PADDING-LEFT: 10px; WIDTH: 470px; HEIGHT: 21px" align="left" width="470"><STRONG>2. 
							Profitability</STRONG></TD>
					<TD style="HEIGHT: 21px" align="center" width="274" colSpan="2"></TD>
					<TD style="HEIGHT: 21px" align="center" width="10%" colSpan="4"></TD>
				</TR>
				<TR>
					<TD style="PADDING-LEFT: 10px; WIDTH: 470px; HEIGHT: 20px" align="left" width="470">&nbsp;&nbsp;&nbsp; 
						a) Return on Equity</TD>
					<TD style="HEIGHT: 20px" align="center" width="274" colSpan="2"><asp:dropdownlist id="ddl_SB_ROE" runat="server" Width="400px" CssClass="mandatory" tabIndex="8">
							<asp:ListItem Value="0">- SELECT -</asp:ListItem>
							<asp:ListItem Value="1">Unchanged Very Good</asp:ListItem>
							<asp:ListItem Value="2">Good</asp:ListItem>
							<asp:ListItem Value="3">Constantly Satisfactory</asp:ListItem>
							<asp:ListItem Value="4">Declining/Eratic</asp:ListItem>
							<asp:ListItem Value="5">Poor</asp:ListItem>
							<asp:ListItem Value="10">Negative</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD style="HEIGHT: 20px" align="center" width="10%" colSpan="4"><asp:textbox id="txt_SB_ROE" style="PADDING-RIGHT: 10px; TEXT-ALIGN: center" runat="server" ReadOnly="True"
							Width="50px" BackColor="#DCDCDC" Font-Bold="True"></asp:textbox></TD>
				</TR>
				<TR class="TblAlternating">
					<TD style="PADDING-LEFT: 10px; WIDTH: 470px; HEIGHT: 17px" align="left" width="470">&nbsp;&nbsp;&nbsp; 
						b) Net Interest Income/Quick &amp; Risk Assets</TD>
					<TD style="HEIGHT: 17px" align="center" width="274" colSpan="2"><asp:dropdownlist id="ddl_SB_NETINT" runat="server" Width="400px" CssClass="mandatory" tabIndex="9">
							<asp:ListItem Value="0">- SELECT -</asp:ListItem>
							<asp:ListItem Value="1">Unchanged Very Good</asp:ListItem>
							<asp:ListItem Value="2">Good</asp:ListItem>
							<asp:ListItem Value="3">Constantly Satisfactory</asp:ListItem>
							<asp:ListItem Value="4">Declining/Eratic</asp:ListItem>
							<asp:ListItem Value="5">Poor</asp:ListItem>
							<asp:ListItem Value="10">Negative</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD style="HEIGHT: 17px" align="center" width="10%" colSpan="4"><asp:textbox id="txt_SB_NETINT" style="PADDING-RIGHT: 10px; TEXT-ALIGN: center" runat="server"
							ReadOnly="True" Width="50px" BackColor="#DCDCDC" Font-Bold="True"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="PADDING-LEFT: 10px; WIDTH: 470px; HEIGHT: 21px" align="left" width="470"><STRONG>3. 
							Efficiency</STRONG></TD>
					<TD style="HEIGHT: 21px" align="center" width="274" colSpan="2"></TD>
					<TD style="HEIGHT: 21px" align="center" width="10%" colSpan="4"></TD>
				</TR>
				<TR class="TblAlternating">
					<TD style="PADDING-LEFT: 10px; WIDTH: 470px; HEIGHT: 20px" align="left" width="470">&nbsp;&nbsp;&nbsp; 
						c) Operating Expenses/Net Revenue</TD>
					<TD style="HEIGHT: 20px" align="center" width="274" colSpan="2"><asp:dropdownlist id="ddl_SB_OPREX" runat="server" Width="400px" CssClass="mandatory" tabIndex="10">
							<asp:ListItem Value="0">- SELECT -</asp:ListItem>
							<asp:ListItem Value="1">Unchanged Very Good</asp:ListItem>
							<asp:ListItem Value="2">Good</asp:ListItem>
							<asp:ListItem Value="3">Constantly Satisfactory</asp:ListItem>
							<asp:ListItem Value="4">Declining/Eratic</asp:ListItem>
							<asp:ListItem Value="5">Poor</asp:ListItem>
							<asp:ListItem Value="10">Negative</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD style="HEIGHT: 20px" align="center" width="10%" colSpan="4"><asp:textbox id="txt_SB_OPREX" style="PADDING-RIGHT: 10px; TEXT-ALIGN: center" runat="server"
							ReadOnly="True" Width="50px" BackColor="#DCDCDC" Font-Bold="True"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="PADDING-LEFT: 10px; WIDTH: 470px; HEIGHT: 21px" align="left" width="470"><STRONG>4. 
							Capital</STRONG></TD>
					<TD style="HEIGHT: 21px" align="center" width="274" colSpan="2"></TD>
					<TD style="HEIGHT: 21px" align="center" width="10%" colSpan="4"></TD>
				</TR>
				<TR class="TblAlternating">
					<TD style="PADDING-LEFT: 10px; WIDTH: 470px; HEIGHT: 15px" align="left" width="470">&nbsp;&nbsp;&nbsp; 
						d) Net Worth/Total Assets</TD>
					<TD style="HEIGHT: 15px" align="center" width="274" colSpan="2"><asp:dropdownlist id="ddl_SB_NETWORTH" runat="server" Width="400px" CssClass="mandatory" tabIndex="11">
							<asp:ListItem Value="0">- SELECT -</asp:ListItem>
							<asp:ListItem Value="1">Unchanged Very Good</asp:ListItem>
							<asp:ListItem Value="2">Good</asp:ListItem>
							<asp:ListItem Value="3">Constantly Satisfactory</asp:ListItem>
							<asp:ListItem Value="4">Declining/Eratic</asp:ListItem>
							<asp:ListItem Value="5">Poor</asp:ListItem>
							<asp:ListItem Value="10">Negative</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD style="HEIGHT: 15px" align="center" width="10%" colSpan="4"><asp:textbox id="txt_SB_NETWORTH" style="PADDING-RIGHT: 10px; TEXT-ALIGN: center" runat="server"
							ReadOnly="True" Width="50px" BackColor="#DCDCDC" Font-Bold="True"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="PADDING-LEFT: 10px; WIDTH: 470px; HEIGHT: 13px" align="left" width="470"><STRONG>5. 
							Quality of Assets</STRONG></TD>
					<TD style="HEIGHT: 13px" align="center" width="274" colSpan="2"><asp:dropdownlist id="ddl_SB_QLTYASSET" runat="server" Width="400px" CssClass="mandatory" tabIndex="12">
							<asp:ListItem Value="0">- SELECT -</asp:ListItem>
							<asp:ListItem Value="1">Very Good</asp:ListItem>
							<asp:ListItem Value="2">Good</asp:ListItem>
							<asp:ListItem Value="3">Average</asp:ListItem>
							<asp:ListItem Value="4">Below Average</asp:ListItem>
							<asp:ListItem Value="5">Poor</asp:ListItem>
							<asp:ListItem Value="10">Negative</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD style="HEIGHT: 13px" align="center" width="10%" colSpan="4"><asp:textbox id="txt_SB_QLTYASSET" style="PADDING-RIGHT: 10px; TEXT-ALIGN: center" runat="server"
							ReadOnly="True" Width="50px" BackColor="#DCDCDC" Font-Bold="True"></asp:textbox></TD>
				</TR>
				<TR class="TblAlternating">
					<TD style="PADDING-LEFT: 10px; WIDTH: 470px; HEIGHT: 19px" align="left" width="470"><STRONG>6. 
							Recent Profitability Trend, Stability</STRONG></TD>
					<TD style="HEIGHT: 19px" align="center" width="274" colSpan="2"><asp:dropdownlist id="ddl_SB_RECPROFIT" runat="server" Width="400px" CssClass="mandatory" tabIndex="13">
							<asp:ListItem Value="0">- SELECT -</asp:ListItem>
							<asp:ListItem Value="1">Very Good</asp:ListItem>
							<asp:ListItem Value="2">Good</asp:ListItem>
							<asp:ListItem Value="3">Average</asp:ListItem>
							<asp:ListItem Value="4">Below Average</asp:ListItem>
							<asp:ListItem Value="5">Poor</asp:ListItem>
							<asp:ListItem Value="10">Negative</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD style="HEIGHT: 19px" align="center" width="10%" colSpan="4"><asp:textbox id="txt_SB_RECPROFIT" style="PADDING-RIGHT: 10px; TEXT-ALIGN: center" runat="server"
							ReadOnly="True" Width="50px" BackColor="#DCDCDC" Font-Bold="True"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="PADDING-LEFT: 10px; WIDTH: 470px; HEIGHT: 21px" align="left" width="470"><STRONG>7. 
							Performance Outlook</STRONG></TD>
					<TD style="HEIGHT: 21px" align="center" width="274" colSpan="2"><asp:dropdownlist id="ddl_SB_PERFOUTLOOK" runat="server" Width="400px" CssClass="mandatory" tabIndex="14">
							<asp:ListItem Value="0">- SELECT -</asp:ListItem>
							<asp:ListItem Value="1">Very Good</asp:ListItem>
							<asp:ListItem Value="2">Good</asp:ListItem>
							<asp:ListItem Value="3">Average</asp:ListItem>
							<asp:ListItem Value="4">Below Average</asp:ListItem>
							<asp:ListItem Value="5">Poor</asp:ListItem>
							<asp:ListItem Value="10">Negative</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD style="HEIGHT: 21px" align="center" width="10%" colSpan="4"><asp:textbox id="txt_SB_PERFOUTLOOK" style="PADDING-RIGHT: 10px; TEXT-ALIGN: center" runat="server"
							ReadOnly="True" Width="50px" BackColor="#DCDCDC" Font-Bold="True"></asp:textbox></TD>
				</TR>
				<TR class="TblAlternating">
					<TD style="PADDING-LEFT: 10px; WIDTH: 470px; HEIGHT: 21px" align="left" width="470"></TD>
					<TD style="HEIGHT: 21px" align="center" width="274" colSpan="2"></TD>
					<TD style="HEIGHT: 21px" align="center" width="10%" colSpan="4"></TD>
				</TR>
				<TR>
					<TD class="tdSmallHeader" style="PADDING-LEFT: 10px; HEIGHT: 26px" align="left" width="60%"
						colSpan="7">III. QUALITY FACTORS (only defined scores permitted)</TD>
				</TR>
				<TR class="TblAlternating">
					<TD style="PADDING-LEFT: 10px; WIDTH: 470px; HEIGHT: 21px" align="left" width="470"><STRONG>1. 
							Business Policy, Long-Term Strategy &amp; Planning </STRONG>
					</TD>
					<TD style="HEIGHT: 21px" align="center" width="274" colSpan="2"><asp:dropdownlist id="ddl_SB_BUSSPLCY" runat="server" Width="400px" CssClass="mandatory" tabIndex="15">
							<asp:ListItem Value="0">- SELECT -</asp:ListItem>
							<asp:ListItem Value="1">Conceptually Consistent/Comprehensive, Foresighted, Risk-Conscious</asp:ListItem>
							<asp:ListItem Value="7">Adequate/Prudent/Lacking in Profile</asp:ListItem>
							<asp:ListItem Value="13">Limited Foresight, Follows Inititives of Competitors</asp:ListItem>
							<asp:ListItem Value="17">Undefined or Inconsistent/Risky/Overly Aggressive</asp:ListItem>
							<asp:ListItem Value="21">Erratic, Irrational</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD style="HEIGHT: 21px" align="center" width="10%" colSpan="4"><asp:textbox id="txt_SB_BUSSPLCY" style="PADDING-RIGHT: 10px; TEXT-ALIGN: center" runat="server"
							ReadOnly="True" Width="50px" BackColor="#DCDCDC" Font-Bold="True"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="PADDING-LEFT: 10px; WIDTH: 470px; HEIGHT: 16px" align="left" width="470"><STRONG>2. 
							Risk Management for Measuring, Evaluating and Steering Bank - Operational 
							Risks, Deposit Structure</STRONG></TD>
					<TD style="HEIGHT: 16px" align="center" width="274" colSpan="2"><STRONG><asp:dropdownlist id="ddl_SB_RISKMAN" runat="server" Width="400px" CssClass="mandatory" tabIndex="16">
								<asp:ListItem Value="0">- SELECT -</asp:ListItem>
								<asp:ListItem Value="1">Very Good</asp:ListItem>
								<asp:ListItem Value="5">Good</asp:ListItem>
								<asp:ListItem Value="9">Average</asp:ListItem>
								<asp:ListItem Value="12">Substandard</asp:ListItem>
								<asp:ListItem Value="13">Poor</asp:ListItem>
							</asp:dropdownlist></STRONG></TD>
					<TD style="HEIGHT: 16px" align="center" width="10%" colSpan="4"><STRONG><asp:textbox id="txt_SB_RISKMAN" style="PADDING-RIGHT: 10px; TEXT-ALIGN: center" runat="server"
								ReadOnly="True" Width="50px" BackColor="#DCDCDC" Font-Bold="True"></asp:textbox></STRONG></TD>
				</TR>
				<TR class="TblAlternating">
					<TD style="PADDING-LEFT: 10px; WIDTH: 470px; HEIGHT: 17px" align="left" width="470"><STRONG>3. 
							Quality of Management</STRONG></TD>
					<TD style="HEIGHT: 17px" align="center" width="274" colSpan="2"><asp:dropdownlist id="ddl_SB_QLTYMAN" runat="server" Width="400px" CssClass="mandatory" tabIndex="17">
							<asp:ListItem Value="0">- SELECT -</asp:ListItem>
							<asp:ListItem Value="1">Very Good</asp:ListItem>
							<asp:ListItem Value="5">Good</asp:ListItem>
							<asp:ListItem Value="9">Qualified but Inconsistent Senior Management</asp:ListItem>
							<asp:ListItem Value="11">Substandard, Frequent Senior Management Turnover</asp:ListItem>
							<asp:ListItem Value="13">Poor/Inadequate</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD style="HEIGHT: 17px" align="center" width="10%" colSpan="4"><asp:textbox id="txt_SB_QLTYMAN" style="PADDING-RIGHT: 10px; TEXT-ALIGN: center" runat="server"
							ReadOnly="True" Width="50px" BackColor="#DCDCDC" Font-Bold="True"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="PADDING-LEFT: 10px; WIDTH: 470px; HEIGHT: 15px" align="left" width="470"><STRONG>4. 
							Quality of Bank Services &amp; Innovations</STRONG></TD>
					<TD style="HEIGHT: 15px" align="center" width="274" colSpan="2"><asp:dropdownlist id="ddl_SB_QLTYBANK" runat="server" Width="400px" CssClass="mandatory" tabIndex="18">
							<asp:ListItem Value="0">- SELECT -</asp:ListItem>
							<asp:ListItem Value="1">Very Good</asp:ListItem>
							<asp:ListItem Value="5">Good</asp:ListItem>
							<asp:ListItem Value="9">Average</asp:ListItem>
							<asp:ListItem Value="11">Substandard</asp:ListItem>
							<asp:ListItem Value="13">Poor</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD style="HEIGHT: 15px" align="center" width="10%" colSpan="4"><asp:textbox id="txt_SB_QLTYBANK" style="PADDING-RIGHT: 10px; TEXT-ALIGN: center" runat="server"
							ReadOnly="True" Width="50px" BackColor="#DCDCDC" Font-Bold="True"></asp:textbox></TD>
				</TR>
				<TR class="TblAlternating">
					<TD style="PADDING-LEFT: 10px; WIDTH: 470px; HEIGHT: 21px" align="left" width="470"></TD>
					<TD style="HEIGHT: 21px" align="center" width="274" colSpan="2"></TD>
					<TD style="HEIGHT: 21px" align="center" width="10%" colSpan="4"></TD>
				</TR>
				<TR>
					<TD class="tdSmallHeader" style="PADDING-LEFT: 10px; HEIGHT: 26px" align="left" width="60%"
						colSpan="7">
						<P>IV. EXTERNAL RATING</P>
					</TD>
				</TR>
				<TR class="TblAlternating">
					<TD style="PADDING-LEFT: 10px; WIDTH: 470px; HEIGHT: 21px" align="left" width="470"><STRONG>1. 
							Market Standing</STRONG></TD>
					<TD style="HEIGHT: 21px" align="center" width="274" colSpan="2"><asp:dropdownlist id="ddl_SB_MARKET" runat="server" Width="400px" CssClass="mandatory" tabIndex="19">
							<asp:ListItem Value="0">- SELECT -</asp:ListItem>
							<asp:ListItem Value="1">Very Good</asp:ListItem>
							<asp:ListItem Value="2">Good</asp:ListItem>
							<asp:ListItem Value="3">Average</asp:ListItem>
							<asp:ListItem Value="4">Substandard</asp:ListItem>
							<asp:ListItem Value="5">Poor</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD style="HEIGHT: 21px" align="center" width="10%" colSpan="4"><asp:textbox id="txt_SB_MARKET" style="PADDING-RIGHT: 10px; TEXT-ALIGN: center" runat="server"
							ReadOnly="True" Width="50px" BackColor="#DCDCDC" Font-Bold="True"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="PADDING-LEFT: 10px; WIDTH: 470px; HEIGHT: 17px" align="left" width="470"><STRONG>2. 
							Penilaian Kesehatan Menurut Bank Indonesia</STRONG></TD>
					<TD style="HEIGHT: 17px" align="center" width="274" colSpan="2"><asp:dropdownlist id="ddl_SB_SEHAT" runat="server" Width="400px" CssClass="mandatory" tabIndex="20">
							<asp:ListItem Value="0">- SELECT -</asp:ListItem>
							<asp:ListItem Value="1">Sehat</asp:ListItem>
							<asp:ListItem Value="4">Cukup Sehat</asp:ListItem>
							<asp:ListItem Value="7">Kurang Sehat</asp:ListItem>
							<asp:ListItem Value="10">Tidak Sehat</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD style="HEIGHT: 17px" align="center" width="10%" colSpan="4"><asp:textbox id="txt_SB_SEHAT" style="PADDING-RIGHT: 10px; TEXT-ALIGN: center" runat="server"
							ReadOnly="True" Width="50px" BackColor="#DCDCDC" Font-Bold="True"></asp:textbox></TD>
				</TR>
				<TR class="TblAlternating">
					<TD style="PADDING-LEFT: 10px; WIDTH: 470px; HEIGHT: 14px" align="left" width="470">&nbsp;&nbsp;&nbsp; 
						Per Posisi:
						<asp:textbox onkeypress="return numbersonly()" id="txt_SB_POSISI_dd" Width="25px" MaxLength="2"
							Runat="server" Columns="2" Visible="False" ReadOnly="True">1</asp:textbox></NOBR><asp:dropdownlist id="ddl_SB_POSISI_mm" Width="100px" Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="txt_SB_POSISI_yy" Width="50px" MaxLength="4"
							Runat="server" Columns="4"></asp:textbox></TD>
					<TD style="HEIGHT: 14px" align="center" width="274" colSpan="2"><asp:textbox id="txt_SB_NILAI" style="TEXT-ALIGN: center" runat="server" Width="400px" CssClass="mandatory"
							Font-Bold="True" tabIndex="21"></asp:textbox></TD>
					<TD style="HEIGHT: 14px" align="center" width="10%" colSpan="4"></TD>
				</TR>
				<TR>
					<TD style="PADDING-LEFT: 10px; WIDTH: 470px; HEIGHT: 21px" align="left" width="470"></TD>
					<TD style="HEIGHT: 21px" align="center" width="274" colSpan="2"></TD>
					<TD style="HEIGHT: 21px" align="center" width="10%" colSpan="4"></TD>
				</TR>
				<TR>
					<TD class="tdSmallHeader" style="PADDING-LEFT: 10px; HEIGHT: 26px" align="left" width="60%"
						colSpan="7">
						<P>V. OUTSIDE ASSISTANCE</P>
					</TD>
				</TR>
				<TR>
					<TD style="PADDING-LEFT: 10px; WIDTH: 470px; HEIGHT: 17px" align="left" width="470"><STRONG>Probability 
							of Outside Assistance</STRONG></TD>
					<TD style="HEIGHT: 17px" align="center" width="274" colSpan="2"><asp:dropdownlist id="ddl_SB_PROFIT" runat="server" Width="400px" CssClass="mandatory" tabIndex="22">
							<asp:ListItem Value="0">- SELECT -</asp:ListItem>
							<asp:ListItem Value="1">Certain: State Guarantee or Support Assured Due to Bank's International Importance</asp:ListItem>
							<asp:ListItem Value="2">State Support Very Likely, Bank Domestically Important</asp:ListItem>
							<asp:ListItem Value="3">Other Outside Assistance than State Support Certain</asp:ListItem>
							<asp:ListItem Value="6">State Support or Other Outside Assistance Probable</asp:ListItem>
							<asp:ListItem Value="10">Outside Assistance not Very Likely</asp:ListItem>
							<asp:ListItem Value="11">No Outside Assistance</asp:ListItem>
							<asp:ListItem Value="17">Additional Burdens Arising from Owners/Concern Possible</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD style="HEIGHT: 17px" align="center" width="10%" colSpan="4"><asp:textbox id="txt_SB_PROFIT" style="PADDING-RIGHT: 10px; TEXT-ALIGN: center" runat="server"
							ReadOnly="True" Width="50px" BackColor="#DCDCDC" Font-Bold="True"></asp:textbox></TD>
				</TR>
				<TR class="TblAlternating">
					<TD style="PADDING-LEFT: 10px; WIDTH: 470px; HEIGHT: 21px" align="left" width="470"></TD>
					<TD style="HEIGHT: 21px" align="center" width="274" colSpan="2"></TD>
					<TD style="HEIGHT: 21px" align="center" width="10%" colSpan="4"></TD>
				</TR>
				<TR>
					<TD style="PADDING-LEFT: 10px; WIDTH: 470px; HEIGHT: 21px" align="left" width="470"><STRONG>TOTAL 
							SCORE FI&nbsp; - RATING</STRONG></TD>
					<TD style="HEIGHT: 21px" align="center" width="274" colSpan="2"><asp:textbox id="txt_FIRating" style="TEXT-ALIGN: center" runat="server" ReadOnly="True" Width="400px"
							BackColor="Gainsboro" Font-Bold="True" Height="30px" Font-Size="Medium"></asp:textbox></TD>
					<TD style="HEIGHT: 21px" align="center" width="10%" colSpan="4"></TD>
				</TR>
				<TR class="TblAlternating">
					<TD style="PADDING-LEFT: 10px; WIDTH: 470px; HEIGHT: 21px" align="left" width="470"><STRONG>BANK 
							MANDIRI - RATING</STRONG></TD>
					<TD style="HEIGHT: 21px" align="center" width="274" colSpan="2"><asp:textbox id="txt_MandiriRating" style="TEXT-ALIGN: center" runat="server" ReadOnly="True"
							Width="400px" BackColor="Gainsboro" Font-Bold="True" Height="30px" Font-Size="Medium"></asp:textbox></TD>
					<TD style="HEIGHT: 21px" align="center" width="10%" colSpan="4"></TD>
				</TR>
				<TR>
					<TD align="center" valign="middle" height="50" width="100%" colSpan="7">
						<P>
							<asp:button id="btn_Calculate" runat="server" CssClass="Button1" Text="Calculate" tabIndex="23" onclick="btn_Calculate_Click"></asp:button></P>
					</TD>
				</TR>
			</table>
			</TD></TR></TBODY></TABLE></TD></TR>
			<table width="100%">
				<TR>
					<TD vAlign="top" align="center" colSpan="2">
						<table width="100%">
							<TBODY>
								<tr>
									<td class="tdBGColor2" align="center"><asp:button id="btn_Save" runat="server" CssClass="Button1" Text="Save" tabIndex="24" onclick="btn_Save_Click"></asp:button><asp:button id="btn_UpdateStatus" runat="server" CssClass="Button1" Text="Update Status" tabIndex="25" onclick="btn_UpdateStatus_Click"></asp:button></td>
								</tr>
							</TBODY>
						</table>
					</TD>
				</TR>
			</table>
		</form>
	</body>
</HTML>
