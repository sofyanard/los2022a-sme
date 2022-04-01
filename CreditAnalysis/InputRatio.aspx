<%@ Page language="c#" Codebehind="InputRatio.aspx.cs" AutoEventWireup="True" Inherits="SME.CreditAnalysis.InputRatio" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Upload File</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<script language="vbscript">
		function HitungProyeksi(str1)
			//set Nil1 = eval("document.Form1.TXT_CA_"&str1&"1")
			//set Nil2 = eval("document.Form1.TXT_CA_"&str1&"2")
			//set Hsl  = eval("document.Form1.TXT_PR_"&str1)
			//CurrentLocal = getlocale()
			//setlocale(1033)
			
			//mNil1 = replace(Nil1.value,",",".")
			//if isnumeric(mNil1) then
				//mNil1 = cdbl(mNil1)
			//else
				//mNil1 = 1
			//end if
			//mNil2 = replace(Nil2.value,",",".")
			//if isnumeric(mNil2) then
				//mNil2 = cdbl(mNil2)
			//else
				//mNil2 = 0
			//end if
			//mHsl = 100
			//if mNil1 <> 0 then
				//mHsl = ((mNil2-mNil1)/mNil1) * 100
			//end if
			//Nil1.value = formatnumber(mNil1,2)
			//Nil2.value = formatnumber(mNil2,2)
			//Hsl.value = formatnumber(mHsl,2)
			//if trim(str2) = "1" then
				//Nil2.focus()
			//end if
			//setlocale(CurrentLocal)
		end function
		
		function HitungTrade(str1)
			'CurrentLocal = getlocale()
			setlocale("in")
			if str1 = "3" then
				set CA_DAYSRECEIVABLE	= document.Form1.TXT_PR_DAYSRECEIVABLE
				set CA_DAYSINVENTORY	= document.Form1.TXT_PR_DAYSINVENTORY
				set CA_DAYSACCOUNTPAY	= document.Form1.TXT_PR_DAYSACCOUNTPAY
				set CA_TRADECYCLE		= document.Form1.TXT_PR_TRADECYCLE
			else
				set CA_DAYSRECEIVABLE	= eval("document.Form1.TXT_CA_DAYSRECEIVABLE"&str1)
				set CA_DAYSINVENTORY	= eval("document.Form1.TXT_CA_DAYSINVENTORY"&str1)
				set CA_DAYSACCOUNTPAY	= eval("document.Form1.TXT_CA_DAYSACCOUNTPAY"&str1)
				set CA_TRADECYCLE		= eval("document.Form1.TXT_CA_TRADECYCLE"&str1)
			end if
			
			'DAYSRECEIVABLE	= replace(CA_DAYSRECEIVABLE.value, "," , ".")
			DAYSRECEIVABLE	= CA_DAYSRECEIVABLE.value
			if isnumeric(DAYSRECEIVABLE) then
				DAYSRECEIVABLE = cdbl(DAYSRECEIVABLE)
			else
				DAYSRECEIVABLE = 0
			end if
			
			'DAYSINVENTORY	= replace(CA_DAYSINVENTORY.value, "," , ".")
			DAYSINVENTORY	= CA_DAYSINVENTORY.value
			if isnumeric(DAYSINVENTORY) then
				DAYSINVENTORY = cdbl(DAYSINVENTORY)
			else
				DAYSINVENTORY = 0
			end if
			
			'DAYSACCOUNTPAY	= replace(CA_DAYSACCOUNTPAY.value, "," , ".")
			DAYSACCOUNTPAY	= CA_DAYSACCOUNTPAY.value
			if isnumeric(DAYSACCOUNTPAY) then
				DAYSACCOUNTPAY = cdbl(DAYSACCOUNTPAY)
			else
				DAYSACCOUNTPAY = 0
			end if
			
			TRADECYCLE = DAYSRECEIVABLE + DAYSINVENTORY - DAYSACCOUNTPAY
			CA_TRADECYCLE.value = TRADECYCLE
			'CA_TRADECYCLE.value = formatnumber(TRADECYCLE,2)
			'setlocale(CurrentLocal)
		end function
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
				<TR>
					<TD class="tdHeader1" colSpan="2">Ratio</TD>
				</TR>
				<TR>
					<TD width="50%" valign="top">
						<table cellpadding="0" cellspacing="0" width="100%">
							<TR>
								<TD colspan="3"><b>&nbsp;Tahun</b></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" width="50%">Tahun I</TD>
								<TD style="WIDTH: 15px">:</TD>
								<TD class="TDBGColorValue">
									<asp:TextBox id="TXT_PR_YEAR1" runat="server" Width="50px" MaxLength="4" CssClass="angka" AutoPostBack="True" ontextchanged="TXT_PR_YEAR1_TextChanged"></asp:TextBox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Tahun II</TD>
								<TD>:</TD>
								<TD class="TDBGColorValue">
									<asp:TextBox id="TXT_PR_YEAR2" runat="server" Width="50px" MaxLength="4" CssClass="angka" AutoPostBack="True" ontextchanged="TXT_PR_YEAR2_TextChanged"></asp:TextBox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">&nbsp;</TD>
								<TD>&nbsp;</TD>
								<TD class="TDBGColorValue">&nbsp;</TD>
							</TR>
						</table>
					</TD>
					<TD width="50%" valign="top" style="HEIGHT: 42px">
						<table cellpadding="0" cellspacing="0" width="100%">
							<TR>
								<TD colspan="3"><b>&nbsp;Investasi</b></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">NPV</TD>
								<TD style="WIDTH: 15px">:</TD>
								<TD class="TDBGColorValue" width="65%">
									<asp:TextBox id="TXT_PR_NPV" runat="server" Width="50px" CssClass="angka"></asp:TextBox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">IRR</TD>
								<TD>:</TD>
								<TD class="TDBGColorValue">
									<asp:TextBox id="TXT_PR_IRR" runat="server" Width="50px" CssClass="angka"></asp:TextBox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Payback</TD>
								<TD>:</TD>
								<TD class="TDBGColorValue">
									<asp:TextBox id="TXT_PR_PAYBACK" runat="server" Width="50px" CssClass="angka"></asp:TextBox></TD>
							</TR>
						</table>
					</TD>
				</TR>
				<TR>
					<TD width="50%" valign="top">
						<table cellpadding="0" cellspacing="0" width="100%" border="1">
							<tr>
								<td class="tdSmallHeader">Ratio</td>
								<td class="tdSmallHeader" width="50">Tahun I</td>
								<td class="tdSmallHeader" width="50">Tahun II</td>
								<td class="tdSmallHeader" width="60">
									Proyeksi</td>
							</tr>
							<tr>
								<td colspan="4"><b>&nbsp;Rentabilitas</b></td>
							</tr>
							<tr>
								<td>&nbsp;- ROA (%)</td>
								<td align="center">
									<asp:TextBox id="TXT_CA_ROA1" runat="server" Width="50px" CssClass="angka" onkeyup="HitungProyeksi('ROA')"></asp:TextBox></td>
								<td align="center">
									<asp:TextBox id="TXT_CA_ROA2" runat="server" Width="50px" CssClass="angka" onkeyup="HitungProyeksi('ROA')"></asp:TextBox></td>
								<td align="center">
									<asp:TextBox id="TXT_PR_ROA" runat="server" Width="50px" CssClass="angka"></asp:TextBox></td>
							</tr>
							<tr>
								<td>&nbsp;- ROE (%)</td>
								<td align="center">
									<asp:TextBox id="TXT_CA_ROE1" runat="server" Width="50px" CssClass="angka" onkeyup="HitungProyeksi('ROE')"></asp:TextBox></td>
								<td align="center">
									<asp:TextBox id="TXT_CA_ROE2" runat="server" Width="50px" CssClass="angka" onkeyup="HitungProyeksi('ROE')"></asp:TextBox></td>
								<td align="center">
									<asp:TextBox id="TXT_PR_ROE" runat="server" Width="50px" CssClass="angka"></asp:TextBox></td>
							</tr>
							<tr>
								<td>&nbsp;- Net Profit Margin (%)</td>
								<td align="center">
									<asp:TextBox id="TXT_CA_NETPROFITMARGIN1" runat="server" Width="50px" CssClass="angka" onkeyup="HitungProyeksi('NETPROFITMARGIN')"></asp:TextBox></td>
								<td align="center">
									<asp:TextBox id="TXT_CA_NETPROFITMARGIN2" runat="server" Width="50px" CssClass="angka" onkeyup="HitungProyeksi('NETPROFITMARGIN')"></asp:TextBox></td>
								<td align="center">
									<asp:TextBox id="TXT_PR_NETPROFITMARGIN" runat="server" Width="50px" CssClass="angka"></asp:TextBox></td>
							</tr>
							<tr>
								<td>&nbsp;- ROI (%)</td>
								<td align="center">
									<asp:TextBox id="TXT_CA_ROI1" runat="server" Width="50px" CssClass="angka" onkeyup="HitungProyeksi('ROI')"></asp:TextBox></td>
								<td align="center">
									<asp:TextBox id="TXT_CA_ROI2" runat="server" Width="50px" CssClass="angka" onkeyup="HitungProyeksi('ROI')"></asp:TextBox></td>
								<td align="center">
									<asp:TextBox id="TXT_PR_ROI" runat="server" Width="50px" CssClass="angka"></asp:TextBox></td>
							</tr>
							<tr>
								<td>&nbsp;- Networth</td>
								<td align="center">
									<asp:TextBox id="TXT_CA_NETWORTH1" runat="server" Width="50px" CssClass="angka" onkeyup="HitungProyeksi('NETWORTH')"></asp:TextBox></td>
								<td align="center">
									<asp:TextBox id="TXT_CA_NETWORTH2" runat="server" Width="50px" CssClass="angka" onkeyup="HitungProyeksi('NETWORTH')"></asp:TextBox></td>
								<td align="center">
									<asp:TextBox id="TXT_PR_NETWORTH" runat="server" Width="50px" CssClass="angka"></asp:TextBox></td>
							</tr>
							<tr>
								<td colspan="4"><b>&nbsp;Pertumbuhan</b></td>
							</tr>
							<tr>
								<td>&nbsp;- Penjualan</td>
								<td align="center">
									<asp:TextBox id="TXT_CA_PENJUALAN1" runat="server" Width="50px" CssClass="angka" onkeyup="HitungProyeksi('PENJUALAN')"></asp:TextBox></td>
								<td align="center">
									<asp:TextBox id="TXT_CA_PENJUALAN2" runat="server" Width="50px" CssClass="angka" onkeyup="HitungProyeksi('PENJUALAN')"></asp:TextBox></td>
								<td align="center">
									<asp:TextBox id="TXT_PR_PENJUALAN" runat="server" Width="50px" CssClass="angka"></asp:TextBox></td>
							</tr>
							<tr>
								<td>&nbsp;- Laba Bersih</td>
								<td align="center">
									<asp:TextBox id="TXT_CA_LABABERSIH1" runat="server" Width="50px" CssClass="angka" onkeyup="HitungProyeksi('LABABERSIH')"></asp:TextBox></td>
								<td align="center">
									<asp:TextBox id="TXT_CA_LABABERSIH2" runat="server" Width="50px" CssClass="angka" onkeyup="HitungProyeksi('LABABERSIH')"></asp:TextBox></td>
								<td align="center">
									<asp:TextBox id="TXT_PR_LABABERSIH" runat="server" Width="50px" CssClass="angka"></asp:TextBox></td>
							</tr>
							<tr>
								<td colspan="4"><b>&nbsp;Leverage</b></td>
							</tr>
							<tr>
								<td>&nbsp;- Debt Equity Ratio (%)</td>
								<td align="center">
									<asp:TextBox id="TXT_CA_DEBTEQUITY1" runat="server" Width="50px" CssClass="angka" onkeyup="HitungProyeksi('DEBTEQUITY')"></asp:TextBox></td>
								<td align="center">
									<asp:TextBox id="TXT_CA_DEBTEQUITY2" runat="server" Width="50px" CssClass="angka" onkeyup="HitungProyeksi('DEBTEQUITY')"></asp:TextBox></td>
								<td align="center">
									<asp:TextBox id="TXT_PR_DEBTEQUITY" runat="server" Width="50px" CssClass="angka"></asp:TextBox></td>
							</tr>
							<tr>
								<td>&nbsp;- Total Aktiva/Modal (%)</td>
								<td align="center">
									<asp:TextBox id="TXT_CA_TOTALAKTIVA1" runat="server" Width="50px" CssClass="angka" onkeyup="HitungProyeksi('TOTALAKTIVA')"></asp:TextBox></td>
								<td align="center">
									<asp:TextBox id="TXT_CA_TOTALAKTIVA2" runat="server" Width="50px" CssClass="angka" onkeyup="HitungProyeksi('TOTALAKTIVA')"></asp:TextBox></td>
								<td align="center">
									<asp:TextBox id="TXT_PR_TOTALAKTIVA" runat="server" Width="50px" CssClass="angka"></asp:TextBox></td>
							</tr>
							<tr>
								<td><b>&nbsp;Collateral Coverage (%)</b></td>
								<td align="center">
									<asp:TextBox id="TXT_CA_COLLATERALCOV1" runat="server" Width="50px" CssClass="angka" onkeyup="HitungProyeksi('COLLATERALCOV')"></asp:TextBox></td>
								<td align="center">
									<asp:TextBox id="TXT_CA_COLLATERALCOV2" runat="server" Width="50px" CssClass="angka" onkeyup="HitungProyeksi('COLLATERALCOV')"></asp:TextBox></td>
								<td align="center">
									<asp:TextBox id="TXT_PR_COLLATERALCOV" runat="server" Width="50px" CssClass="angka"></asp:TextBox></td>
							</tr>
						</table>
					</TD>
					<TD width="50%" valign="top" style="HEIGHT: 42px">
						<table cellpadding="0" cellspacing="0" width="100%" border="1">
							<tr>
								<td class="tdSmallHeader">Ratio</td>
								<td class="tdSmallHeader" width="50">Tahun I</td>
								<td class="tdSmallHeader" width="50">Tahun II</td>
								<td class="tdSmallHeader" width="60">
									Proyeksi</td>
							</tr>
							<tr>
								<td colspan="4"><b>&nbsp;Likuiditas</b></td>
							</tr>
							<tr>
								<td>&nbsp;- Current Ratio (%)</td>
								<td align="center">
									<asp:TextBox id="TXT_CA_CURRENTRATIO1" runat="server" Width="50px" CssClass="angka" onkeyup="HitungProyeksi('CURRENTRATIO')"></asp:TextBox></td>
								<td align="center">
									<asp:TextBox id="TXT_CA_CURRENTRATIO2" runat="server" Width="50px" CssClass="angka" onkeyup="HitungProyeksi('CURRENTRATIO')"></asp:TextBox></td>
								<td align="center">
									<asp:TextBox id="TXT_PR_CURRENTRATIO" runat="server" Width="50px" CssClass="angka"></asp:TextBox></td>
							</tr>
							<tr>
								<td>&nbsp;- Debt Service Coverage (%)</td>
								<td align="center">
									<asp:TextBox id="TXT_CA_DEBTSERVICE1" runat="server" Width="50px" CssClass="angka" onkeyup="HitungProyeksi('DEBTSERVICE')"></asp:TextBox></td>
								<td align="center">
									<asp:TextBox id="TXT_CA_DEBTSERVICE2" runat="server" Width="50px" CssClass="angka" onkeyup="HitungProyeksi('DEBTSERVICE')"></asp:TextBox></td>
								<td align="center">
									<asp:TextBox id="TXT_PR_DEBTSERVICE" runat="server" Width="50px" CssClass="angka"></asp:TextBox></td>
							</tr>
							<tr>
								<td colspan="4"><b>&nbsp;Activity</b></td>
							</tr>
							<tr>
								<td>&nbsp;- Cash Velocity</td>
								<td align="center">
									<asp:TextBox id="TXT_CA_CASHVELOCITY1" runat="server" Width="50px" CssClass="angka" onkeyup="HitungProyeksi('CASHVELOCITY')"></asp:TextBox></td>
								<td align="center">
									<asp:TextBox id="TXT_CA_CASHVELOCITY2" runat="server" Width="50px" CssClass="angka" onkeyup="HitungProyeksi('CASHVELOCITY')"></asp:TextBox></td>
								<td align="center">
									<asp:TextBox id="TXT_PR_CASHVELOCITY" runat="server" Width="50px" CssClass="angka"></asp:TextBox></td>
							</tr>
							<tr>
								<td style="HEIGHT: 21px">
									&nbsp;- Days Receivable</td>
								<td align="center" style="HEIGHT: 21px">
									<asp:TextBox id="TXT_CA_DAYSRECEIVABLE1" runat="server" Width="50px" CssClass="angka" onkeyup="HitungTrade('1')"></asp:TextBox></td>
								<td align="center" style="HEIGHT: 21px">
									<asp:TextBox id="TXT_CA_DAYSRECEIVABLE2" runat="server" Width="50px" CssClass="angka" onkeyup="HitungTrade('2')"></asp:TextBox></td>
								<td align="center" style="HEIGHT: 21px">
									<asp:TextBox id="TXT_PR_DAYSRECEIVABLE" runat="server" Width="50px" CssClass="angka" onkeyup="HitungTrade('3')"></asp:TextBox></td>
							</tr>
							<tr>
								<td>
									&nbsp;- Days Inventory</td>
								<td align="center">
									<asp:TextBox id="TXT_CA_DAYSINVENTORY1" runat="server" Width="50px" CssClass="angka" onkeyup="HitungTrade('1')"></asp:TextBox></td>
								<td align="center">
									<asp:TextBox id="TXT_CA_DAYSINVENTORY2" runat="server" Width="50px" CssClass="angka" onkeyup="HitungTrade('2')"></asp:TextBox></td>
								<td align="center">
									<asp:TextBox id="TXT_PR_DAYSINVENTORY" runat="server" Width="50px" CssClass="angka" onkeyup="HitungTrade('3')"></asp:TextBox></td>
							</tr>
							<tr>
								<td>
									&nbsp;- Days Account Payable</td>
								<td align="center">
									<asp:TextBox id="TXT_CA_DAYSACCOUNTPAY1" runat="server" Width="50px" CssClass="angka" onkeyup="HitungTrade('1')"></asp:TextBox></td>
								<td align="center">
									<asp:TextBox id="TXT_CA_DAYSACCOUNTPAY2" runat="server" Width="50px" CssClass="angka" onkeyup="HitungTrade('2')"></asp:TextBox></td>
								<td align="center">
									<asp:TextBox id="TXT_PR_DAYSACCOUNTPAY" runat="server" Width="50px" CssClass="angka" onkeyup="HitungTrade('3')"></asp:TextBox></td>
							</tr>
							<tr>
								<td>&nbsp;- Trade Cycle</td>
								<td align="center">
									<asp:TextBox id="TXT_CA_TRADECYCLE1" runat="server" Width="50px" CssClass="angka" onkeyup="HitungProyeksi('TRADECYCLE')"
										ReadOnly="True"></asp:TextBox></td>
								<td align="center">
									<asp:TextBox id="TXT_CA_TRADECYCLE2" runat="server" Width="50px" CssClass="angka" onkeyup="HitungProyeksi('TRADECYCLE')"
										ReadOnly="True"></asp:TextBox></td>
								<td align="center">
									<asp:TextBox id="TXT_PR_TRADECYCLE" runat="server" Width="50px" CssClass="angka" ReadOnly="True"></asp:TextBox></td>
							</tr>
							<tr>
								<td>&nbsp;- Total Asset Turn Over</td>
								<td align="center">
									<asp:TextBox id="TXT_CA_TOTALASSET1" runat="server" Width="50px" CssClass="angka" onkeyup="HitungProyeksi('TOTALASSET')"></asp:TextBox></td>
								<td align="center">
									<asp:TextBox id="TXT_CA_TOTALASSET2" runat="server" Width="50px" CssClass="angka" onkeyup="HitungProyeksi('TOTALASSET')"></asp:TextBox></td>
								<td align="center">
									<asp:TextBox id="TXT_PR_TOTALASSET" runat="server" Width="50px" CssClass="angka"></asp:TextBox></td>
							</tr>
							<tr>
								<td colspan="4"><b>&nbsp;Biaya</b></td>
							</tr>
							<tr>
								<td>&nbsp;- Laba Kotor/Penjualan (%)</td>
								<td align="center">
									<asp:TextBox id="TXT_CA_LABAKOTOR1" runat="server" Width="50px" CssClass="angka" onkeyup="HitungProyeksi('LABAKOTOR')"></asp:TextBox></td>
								<td align="center">
									<asp:TextBox id="TXT_CA_LABAKOTOR2" runat="server" Width="50px" CssClass="angka" onkeyup="HitungProyeksi('LABAKOTOR')"></asp:TextBox></td>
								<td align="center">
									<asp:TextBox id="TXT_PR_LABAKOTOR" runat="server" Width="50px" CssClass="angka"></asp:TextBox></td>
							</tr>
							<tr>
								<td>&nbsp;- Biaya Umum &amp; Adm Penjualan</td>
								<td align="center">
									<asp:TextBox id="TXT_CA_BIAYAADM1" runat="server" Width="50px" CssClass="angka" onkeyup="HitungProyeksi('BIAYAADM')"></asp:TextBox></td>
								<td align="center">
									<asp:TextBox id="TXT_CA_BIAYAADM2" runat="server" Width="50px" CssClass="angka" onkeyup="HitungProyeksi('BIAYAADM')"></asp:TextBox></td>
								<td align="center">
									<asp:TextBox id="TXT_PR_BIAYAADM" runat="server" Width="50px" CssClass="angka"></asp:TextBox></td>
							</tr>
						</table>
					</TD>
				</TR>
				<TR>
					<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2"><asp:button id="BTN_SAVE" runat="server" Text="Save" CssClass="Button1" onclick="BTN_SAVE_Click"></asp:button></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
