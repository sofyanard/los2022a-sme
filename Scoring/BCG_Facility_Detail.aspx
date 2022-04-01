<%@ Page language="c#" Codebehind="BCG_Facility_Detail.aspx.cs" AutoEventWireup="True" Inherits="SME.Scoring.BCG_Facility_Detail" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Scoring</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_all.html" -->
		<!-- #include file="../include/onepost.html" -->
		<!-- #include file="../include/ConfirmBox.html" -->
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table2" style="HEIGHT: 368px" cellSpacing="1" cellPadding="1" width="90%" border="0">
					<TR>
						<TD>
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD class="tdHeader1" style="HEIGHT: 1px; TEXT-ALIGN: center" colSpan="3"><asp:label id="LABEL" runat="server" Width="143px" Height="16px">Application Type</asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 345px; HEIGHT: 24px" vAlign="middle">Ketentuan 
										Kredit
									</TD>
									<TD style="WIDTH: 14px; HEIGHT: 24px" width="14"></TD>
									<TD style="HEIGHT: 24px" vAlign="middle"><asp:textbox id="TXT_KETENTUANKREDIT" runat="server" Width="328px" Height="19px" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 345px; HEIGHT: 5px">Limit</TD>
									<TD style="WIDTH: 14px; HEIGHT: 5px" width="14"></TD>
									<TD style="HEIGHT: 5px"><asp:dropdownlist id="DDL_CURRENCY" runat="server" AutoPostBack="True" Enabled="False" onselectedindexchanged="DDL_CURRENCY_SelectedIndexChanged"></asp:dropdownlist><asp:textbox id="TXT_TOTALLIMIT" runat="server" Width="136px" Height="19px" ReadOnly="True"></asp:textbox><asp:label id="LBL_TOTALLIMIT" runat="server" Visible="False"></asp:label><asp:label id="LBL_CURRENTLIMIT" runat="server" Visible="False"></asp:label></TD>
								</TR>
								<TR style="DISPLAY: none">
									<TD class="TDBGColor1" style="WIDTH: 345px; HEIGHT: 21px"></TD>
									<TD style="WIDTH: 14px; HEIGHT: 21px" width="14"></TD>
									<TD style="HEIGHT: 21px">Exchange Rate :
										<asp:textbox id="TXT_EXCHANGERATE" runat="server" Width="136px" Height="19px" ReadOnly="True"
											Visible="False"></asp:textbox><asp:label id="LBL_STATUS" runat="server" Visible="False"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 345px; HEIGHT: 17px"></TD>
									<TD style="WIDTH: 14px; HEIGHT: 17px" width="14"></TD>
									<TD style="HEIGHT: 17px"><asp:textbox id="TXT_LIMITINMILLION" runat="server" Width="136px" Height="19px" ReadOnly="True"></asp:textbox>&nbsp;(x1000000)</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 345px; HEIGHT: 17px">Loan Periode</TD>
									<TD style="WIDTH: 14px; HEIGHT: 17px" width="14"></TD>
									<TD style="HEIGHT: 17px">1</TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 3px" colSpan="3"></TD>
								</TR>
							</TABLE>
							<asp:label id="LBL_CU_REF" runat="server" Visible="False"></asp:label><asp:label id="LBL_COLLATERAL" runat="server"></asp:label><BR>
							<TABLE id="Table1" style="HEIGHT: 131px" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD class="tdHeader1" colSpan="3"><asp:label id="Label1" runat="server" Visible="False"></asp:label>Facility 
										Rating
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 346px; HEIGHT: 18px">Probability of Default 
										(%)</TD>
									<TD style="HEIGHT: 18px" width="15"></TD>
									<TD style="HEIGHT: 18px"><asp:textbox onkeypress="return numbersonly();" id="TXT_FAC_AVERAGEPD" runat="server" Width="1px"
											Height="19px" CssClass="angka" BorderStyle="None"></asp:textbox><asp:label id="LBL_A1011" runat="server" Font-Bold="True"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 346px; HEIGHT: 18px">Collateral Coverage (%)</TD>
									<TD style="HEIGHT: 18px" width="15"></TD>
									<TD style="HEIGHT: 18px"><asp:textbox onkeypress="return numbersonly();" id="TXT_FAC_COLLCOVERAGE" runat="server" Width="1px"
											Height="19px" CssClass="angka" BorderStyle="None"></asp:textbox><asp:label id="LBL_G0028" runat="server" Font-Bold="True"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 346px">LGD (%)</TD>
									<TD></TD>
									<TD><asp:textbox onkeypress="return numbersonly();" id="TXT_FAC_LGD" runat="server" Width="1px" Height="19px"
											CssClass="angka" BorderStyle="None"></asp:textbox><asp:label id="LBL_G0029" runat="server" Font-Bold="True"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 346px; HEIGHT: 21px">Exposure at Default (%)</TD>
									<TD style="HEIGHT: 21px"></TD>
									<TD style="HEIGHT: 21px"><asp:textbox onkeypress="return numbersonly();" id="TXT_FAC_EAD" runat="server" Width="1px" Height="19px"
											CssClass="angka" BorderStyle="None"></asp:textbox><asp:label id="LBL_A1012" runat="server" Font-Bold="True"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 346px">Expected Loss (%)</TD>
									<TD></TD>
									<TD><asp:textbox onkeypress="return numbersonly();" id="TXT_FAC_EL" runat="server" Width="1px" Height="19px"
											CssClass="angka" BorderStyle="None"></asp:textbox><asp:label id="LBL_G0030" runat="server" Font-Bold="True"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 346px">Facility Rating</TD>
									<TD></TD>
									<TD><asp:textbox id="TXT_FAC_RISKCLASS" runat="server" Width="1px" Height="19px" ReadOnly="True"
											BorderStyle="None"></asp:textbox><asp:label id="LBL_A1013" runat="server" Font-Bold="True"></asp:label></TD>
								</TR>
							</TABLE>
							<asp:label id="LBL_AP_REGNO" runat="server" Visible="False"></asp:label><asp:label id="LBL_PRODUCTID" runat="server" Visible="False"></asp:label><asp:label id="LBL_SR_BCGRISKGRADE" runat="server" Visible="False"></asp:label><asp:label id="LBL_PROD_SEQ" runat="server" Visible="False"></asp:label><asp:label id="LBL_KETCODE" runat="server" Visible="False"></asp:label><asp:label id="LBL_INDUSTRIALCODE" runat="server" Visible="False"></asp:label><asp:label id="LBL_TRY" runat="server" Visible="False">0</asp:label>
							<asp:label id="LBL_SCOREBCG_SEQ" runat="server" Visible="False"></asp:label></TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" align="center"><asp:button id="BTN_RATE" runat="server" Width="140px" CssClass="Button1" Text="Rate" onclick="BTN_RATE_Click"></asp:button>&nbsp;
							<%if (Request.QueryString["scr"] != "0") {%>
							<asp:button id="btnUpdateStatus" runat="server" Width="140" CssClass="Button1" Text="Update Status" onclick="btnUpdateStatus_Click"></asp:button>
							<%}%>
						</TD>
					</TR>
				</TABLE>
			</center>
		</form>
		<script language="javascript">
		/**
	function update() {
		ans = confirm("Are you sure you want to update?");
		
		if (ans) {
			return true;
		}
		else {
			return false;
		}
	}**/
		</script>
	</body>
</HTML>
