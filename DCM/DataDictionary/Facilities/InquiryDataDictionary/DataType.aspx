<%@ Page language="c#" Codebehind="DataType.aspx.cs" AutoEventWireup="True" Inherits="SME.DCM.DataDictionary.Facilities.InquiryDataDictionary.DataType" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DataType</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../../../Style.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function click_rb()
		{
			for ( i=0 ; i<29; i++)
			{
				if (eval("document.Form1.RB_1("+i+").checked"))
				{
					eval("id"+i+"2.style.fontWeight		= 700");
					eval("id"+i+"1.style.backgroundColor= document.Form1.cs1.value");
					eval("id"+i+"2.style.backgroundColor= document.Form1.cs1.value");
				}
				else
				{
					eval("id"+i+"2.style.fontWeight		= 500");
					eval("id"+i+"1.style.backgroundColor= document.Form1.cs3.value");
					eval("id"+i+"2.style.backgroundColor= document.Form1.cs2.value");
				}
			}
		}

		function mouse_over(i)
		{
			eval("id"+i+"1.style.backgroundColor= document.Form1.cs4.value");
			eval("id"+i+"2.style.backgroundColor= document.Form1.cs4.value");
		}

		function klik(i)
		{
			eval("document.Form1.RB_1("+i+").checked=true");
		}

		function mouse_out(i)
		{
			if (eval("document.Form1.RB_1("+i+").checked"))
				click_rb();
			else
			{
				eval("id"+i+"1.style.backgroundColor= document.Form1.cs3.value");
				eval("id"+i+"2.style.backgroundColor= document.Form1.cs2.value");
			}
		}

		function view_report(mc)
		{
			for ( i=0 ; i<29; i++)
			{
				if (eval("document.Form1.RB_1("+i+").checked"))
					window.location	= eval("document.Form1.RB_1("+i+").value") + "?mc=" + mc;
//				    window.location	=  eval("document.Form1.RB_1("+i+").value") + "?Posisi="+i
 		    }
		}
		</script>
	</HEAD>
	<body onload="click_rb()" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<input type="hidden" value="#fffff0" name="cs1"> <input type="hidden" value="white" name="cs2">
			<input type="hidden" value="#e5ebf4" name="cs3"> <input type="hidden" value="whitesmoke" name="cs4">
			<!--<center> -->
			<TABLE id="Table4" width="100%" border="0">
				<TR>
					<TD align="left" colSpan="1">
						<TABLE id="Table3">
							<TR>
								<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>INQUIRY DATA DICTIONARY</B></TD>
							</TR>
						</TABLE>
					</TD>
					<td align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg"></asp:imagebutton><A href="../../../../Body.aspx"><IMG src="../../../../Image/MainMenu.jpg"></A><A href="../../../../Logout.aspx" target="_top"><IMG src="../../../../Image/Logout.jpg"></A></td>
				</TR>
				<tr>
					<td colSpan="2">
						<table cellSpacing="2" cellPadding="2" width="100%" border="1">
							<TR>
								<TD class="tdHeader1" colSpan="4" align="center">DATA TYPE</TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" id="id01" onmouseover="mouse_over('0')" onclick="klik('0')" onmouseout="mouse_out('0')"
									align="center"><INPUT onclick="click_rb()" type="radio" CHECKED value="CIFDetailData.aspx" name="RB_1"></TD>
								<td class="TDBGColorValue" id="id02" onmouseover="mouse_over('0')" onclick="klik('0')"
									onmouseout="mouse_out('0')">&nbsp;
									<asp:label id="LBL_1" runat="server">CUSTOMER INFORMATION FILE (CIF)</asp:label></td>
							</TR>
							<TR>
								<TD class="TDBGColor1" id="id41" onmouseover="mouse_over('1')" onclick="klik('1')" onmouseout="mouse_out('4')"
									align="center"><INPUT onclick="click_rb()" type="radio" value="DanaDetailData.aspx" name="RB_1"></TD>
								<TD class="TDBGColorValue" id="id42" onmouseover="mouse_over('1')" onclick="klik('1')"
									onmouseout="mouse_out('4')">&nbsp;
									<asp:label id="Label6" runat="server">DANA PIHAK KETIGA</asp:label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" id="id21" onmouseover="mouse_over('2')" onclick="klik('2')" onmouseout="mouse_out('2')"
									align="center"><INPUT onclick="click_rb()" type="radio" value="CreditDetailData.aspx" name="RB_1"></TD>
								<TD class="TDBGColorValue" id="id22" onmouseover="mouse_over('2')" onclick="klik('2')"
									onmouseout="mouse_out('2')">&nbsp;
									<asp:label id="Label4" runat="server">PERKREDITAN</asp:label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" id="id21" onmouseover="mouse_over('3')" onclick="klik('3')" onmouseout="mouse_out('2')"
									align="center"><INPUT onclick="click_rb()" type="radio" value="CollateralDetailData.aspx" name="RB_1"></TD>
								<TD class="TDBGColorValue" id="id22" onmouseover="mouse_over('3')" onclick="klik('3')"
									onmouseout="mouse_out('2')">&nbsp;
									<asp:label id="Label1" runat="server">AGUNAN</asp:label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" id="id21" onmouseover="mouse_over('4')" onclick="klik('4')" onmouseout="mouse_out('2')"
									align="center"><INPUT onclick="click_rb()" type="radio" value="TradeDetailData.aspx" name="RB_1"></TD>
								<TD class="TDBGColorValue" id="id22" onmouseover="mouse_over('4')" onclick="klik('4')"
									onmouseout="mouse_out('2')">&nbsp;
									<asp:label id="Label2" runat="server">TRADE</asp:label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" id="id21" onmouseover="mouse_over('5')" onclick="klik('5')" onmouseout="mouse_out('2')"
									align="center"><INPUT onclick="click_rb()" type="radio" value="TreasuryDetailData.aspx" name="RB_1"></TD>
								<TD class="TDBGColorValue" id="id22" onmouseover="mouse_over('5')" onclick="klik('5')"
									onmouseout="mouse_out('2')">&nbsp;
									<asp:label id="Label3" runat="server">TREASURY</asp:label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" id="id21" onmouseover="mouse_over('6')" onclick="klik('6')" onmouseout="mouse_out('2')"
									align="center"><INPUT onclick="click_rb()" type="radio" value="LoanAccount.aspx" name="RB_1"></TD>
								<TD class="TDBGColorValue" id="id22" onmouseover="mouse_over('6')" onclick="klik('6')"
									onmouseout="mouse_out('2')">&nbsp;
									<asp:label id="Label5" runat="server">HISTORICAL TRANSACTION</asp:label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor2" colSpan="4" height="90%" align="center">
									<INPUT class="BUTTON1" onclick="view_report('<%=Request["mc"]%>')" type="button" value="VIEW REPORT">
								</TD>
							</TR>
						</table>
					</td>
				</tr>
			</TABLE>
			<CENTER></CENTER>
		</form>
	</body>
</HTML>
