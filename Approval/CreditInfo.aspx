<%@ Page language="c#" Codebehind="CreditInfo.aspx.cs" AutoEventWireup="True" Inherits="SME.Approval.CreditInfo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CreditInfo</title>
		<meta content="True" name="vs_snapToGrid">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<script language="javascript">
			function GetOut(str)
			{
				document.f1.action = str;
				document.f1.submit();
			}
			
			function calculate()
			{	
				nil	= parseFloat(document.fCreInfo.txt_decexlimitval.value);
				cur	= parseFloat(document.fCreInfo.txt_decexrplimit.value);
				if (isNaN(nil))
					nil = 0;
				if (isNaN(cur))
					cur	= 0;
				hsl	= nil*cur;
				document.fCreInfo.txt_declimit.value = hsl;
		}
		</script>
		<!-- #include file="../include/cek_entries.html" -->
		<!-- #include file="../include/cek_mandatoryOnly.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form name="f1" action="approval.aspx" method="post" target="main">
		</form>
		<form id="fCreInfo" name="fCreInfo" method="post" runat="server">
			<center>
				<table id="endi" cellSpacing="2" cellPadding="2" width="100%" runat="server">
					<tr>
						<td class="td" vAlign="top" width="50%">
							<table cellSpacing="0" cellPadding="0" width="100%">
								<tr>
									<td class="TDBGColor1" style="WIDTH: 140px">Limit</td>
									<td style="WIDTH: 15px"></td>
									<td class="TDBGColorValue">Rp.
										<asp:textbox id="txt_limit" runat="server" ReadOnly MaxLength="15" Columns="50" Width="150px"></asp:textbox><asp:label id="mc" runat="server" Visible="False"></asp:label></td>
								</tr>
								<tr>
									<td class="TDBGColor1" style="WIDTH: 140px">Tenor</td>
									<td style="WIDTH: 15px"></td>
									<td class="TDBGColorValue"><asp:textbox id="txt_tenor" runat="server" ReadOnly MaxLength="3" Columns="5" Width="40px"></asp:textbox>&nbsp;<asp:textbox id="txt_tenorcode" runat="server" ReadOnly MaxLength="5" Columns="5" Width="40px"></asp:textbox></td>
								</tr>
								<tr id="tr_fix" runat="server">
									<td class="TDBGColor1" style="WIDTH: 140px">Interest/p.a Fix</td>
									<td style="WIDTH: 15px"></td>
									<td class="TDBGColorValue"><asp:textbox id="txt_fix" runat="server" ReadOnly MaxLength="6" Columns="10" Width="40px"></asp:textbox>%</td>
								</tr>
								<tr id="tr_float" runat="server">
									<td class="TDBGColor1" style="WIDTH: 140px; HEIGHT: 22px">Interest Floating</td>
									<td style="WIDTH: 15px; HEIGHT: 22px"></td>
									<td class="TDBGColorValue" style="HEIGHT: 22px"><asp:dropdownlist id="ddl_rate" runat="server" Visible="False" Enabled="False"></asp:dropdownlist><asp:textbox id="txt_rate" runat="server" ReadOnly MaxLength="10" Columns="10" Width="40px"></asp:textbox>%
										<asp:dropdownlist id="ddl_varcode" runat="server" Enabled="False"></asp:dropdownlist><asp:textbox id="txt_variance" runat="server" ReadOnly MaxLength="10" Columns="10" Width="40px"></asp:textbox>%
									</td>
								</tr>
								<tr id="tr_install" runat="server">
									<td class="TDBGColor1" style="WIDTH: 140px">Installment</td>
									<td style="WIDTH: 15px"></td>
									<td class="TDBGColorValue"><asp:textbox id="txt_installment" runat="server" ReadOnly MaxLength="15" Columns="10" Width="152px"></asp:textbox></td>
								</tr>
							</table>
							<asp:label id="LBL_PROD_SEQ" runat="server" Visible="False"></asp:label>
						</td>
						<td class="td" vAlign="top">
							<table cellSpacing="0" cellPadding="0" width="100%">
								<tr>
									<td class="TDBGColor1" style="WIDTH: 164px">Tujuan Penggunaan</td>
									<td style="WIDTH: 15px"></td>
									<td class="TDBGColorValue"><asp:textbox id="txt_purpose" runat="server" ReadOnly MaxLength="200" Columns="200" Width="280px"></asp:textbox></td>
								</tr>
								<tr>
									<td class="TDBGColor1" style="WIDTH: 164px">Sifat Kredit</td>
									<td style="WIDTH: 15px"></td>
									<td class="TDBGColorValue"><asp:textbox id="txt_sifat" runat="server" ReadOnly MaxLength="100" Columns="100" Width="176px"></asp:textbox></td>
								</tr>
								<tr>
									<td class="TDBGColor1" style="WIDTH: 164px; HEIGHT: 18px">Total Collaterals In Rp.</td>
									<td style="WIDTH: 15px; HEIGHT: 18px"></td>
									<td class="TDBGColorValue" style="HEIGHT: 18px"><asp:textbox id="txt_totcoll" runat="server" ReadOnly MaxLength="100" Columns="100" Width="100px"></asp:textbox><asp:textbox id="txt_exrplimit" runat="server" MaxLength="50" Columns="50" Width="24px" Visible="False"
											Height="16px"></asp:textbox><asp:textbox id="txt_exlimitval" runat="server" MaxLength="50" Columns="50" Width="24px" Visible="False"
											Height="16px"></asp:textbox></td>
								</tr>
								<tr>
									<td class="TDBGColor1" style="WIDTH: 164px" vAlign="top"><asp:label id="lbl_exlimitval" runat="server" Visible="False"></asp:label>Remark</td>
									<td style="WIDTH: 15px"></td>
									<td class="TDBGColorValue"><asp:textbox id="txt_remark" runat="server" MaxLength="50" Columns="50" Width="280px" Height="40px"
											TextMode="MultiLine"></asp:textbox></td>
								</tr>
							</table>
							<asp:label id="lbl_userid" runat="server" Visible="False"></asp:label><asp:label id="lbl_curef" runat="server" Visible="False"></asp:label><asp:label id="lbl_regno" runat="server" Visible="False"></asp:label><asp:label id="lbl_apptype" runat="server" Visible="False"></asp:label><asp:label id="lbl_prod" runat="server" Visible="False"></asp:label><asp:label id="lbl_track" runat="server" Visible="False"></asp:label><asp:label id="lbl_interest" runat="server" Visible="False"></asp:label>
						</td>
					</tr>
				</table>
				<table id="Table4" cellSpacing="2" cellPadding="2" width="100%">
					<tr>
						<td align="center" width="50%" colSpan="2"><asp:linkbutton id="lb_struc" Font-Bold="True" Runat="server" onclick="lb_struc_Click">Credit Structure</asp:linkbutton></td>
					</tr>
					<tr>
						<td class="tdHeader1" width="50%" colSpan="2">Decision
							<asp:label id="lbl_usergroup" Runat="server"></asp:label></td>
					</tr>
					<tr>
						<td class="td" vAlign="top" width="50%">
							<table cellSpacing="0" cellPadding="0" width="100%">
								<tr>
									<td class="TDBGColor1" style="WIDTH: 140px">Limit</td>
									<td style="WIDTH: 15px"></td>
									<td class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="txt_decexlimitval" runat="server" MaxLength="15"
											onblur="FormatCurrency(this)" Columns="50" Width="173px" Height="19px" AutoPostBack="True" ontextchanged="txt_decexlimitval_TextChanged"></asp:textbox></td>
								</tr>
								<tr>
									<td class="TDBGColor1" style="WIDTH: 140px">Exchange Rate</td>
									<td style="WIDTH: 15px"></td>
									<td class="TDBGColorValue"><asp:textbox id="txt_decexrplimit" runat="server" MaxLength="15" Columns="50" Width="173px" Height="19px"
											Readonly></asp:textbox></td>
								</tr>
								<tr>
									<td class="TDBGColor1" style="WIDTH: 140px">Limit to Rupiah</td>
									<td style="WIDTH: 15px"></td>
									<td class="TDBGColorValue">
										<asp:textbox id="txt_declimitchg" runat="server" Width="24px" Columns="50" MaxLength="50" Readonly="True"
											Visible="False"></asp:textbox>
										&nbsp;Rp.<asp:textbox id="txt_declimit" runat="server" MaxLength="15" Columns="50" Width="150px" Readonly></asp:textbox></td>
								</tr>
								<tr>
									<td class="TDBGColor1" style="WIDTH: 140px">Tenor</td>
									<td style="WIDTH: 15px"></td>
									<td class="TDBGColorValue"><asp:textbox id="txt_dectenor" runat="server" onkeypress="return numbersonly()" MaxLength="6"
											Columns="50" Width="40px"></asp:textbox>&nbsp;<asp:dropdownlist id="ddl_dectenorcode" runat="server" Width="79px"></asp:dropdownlist></td>
								</tr>
								<tr id="tr_decfix" runat="server">
									<td class="TDBGColor1" style="WIDTH: 140px">Interest/p.a Fix</td>
									<td style="WIDTH: 15px"></td>
									<td class="TDBGColorValue"><asp:textbox id="txt_decfix" runat="server" MaxLength="6" Columns="10" Width="40px"></asp:textbox>%</td>
								</tr>
								<tr id="tr_decfloat" runat="server">
									<td class="TDBGColor1" style="WIDTH: 140px; HEIGHT: 8px">Interest Floating</td>
									<td style="WIDTH: 15px; HEIGHT: 8px"></td>
									<td class="TDBGColorValue" style="HEIGHT: 8px"><asp:dropdownlist id="ddl_decrate" runat="server" Visible="False" Enabled="False"></asp:dropdownlist><asp:textbox id="txt_decrate" runat="server" ReadOnly MaxLength="10" Columns="10" Width="40px"></asp:textbox>%
										<asp:dropdownlist id="ddl_decvarcode" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return digitsonly()" id="txt_decvariance" runat="server" MaxLength="6"
											Columns="10" Width="40px"></asp:textbox>%
									</td>
								</tr>
								<tr id="tr_decgraceperiode" runat="server">
									<td class="TDBGColor1" style="WIDTH: 140px">Grace Period</td>
									<td style="WIDTH: 15px"></td>
									<td class="TDBGColorValue">
										<asp:textbox onkeypress="return digitsonly()" id="txt_decgraceperiode" runat="server" Columns="3"
											MaxLength="6"></asp:textbox>&nbsp;Bulan
									</td>
								</tr>
								<tr id="tr_decpayfreq" runat="server">
									<td class="TDBGColor1" style="WIDTH: 140px">Repayment Frequency</td>
									<td style="WIDTH: 15px"></td>
									<td class="TDBGColorValue"><asp:dropdownlist id="ddl_decpayfreq" runat="server"></asp:dropdownlist></td>
								</tr>
								<tr id="tr_decinstall" runat="server">
									<td class="TDBGColor1" style="WIDTH: 140px">Installment</td>
									<td style="WIDTH: 15px"></td>
									<td class="TDBGColorValue">Rp.
										<asp:textbox id="txt_decinstallment" runat="server" ReadOnly MaxLength="15" Columns="10" Width="152px"></asp:textbox></td>
								</tr>
							</table>
						</td>
						<td class="td" vAlign="top">
							<table cellSpacing="0" cellPadding="0" width="100%">
								<tr>
									<td class="TDBGColor1" style="WIDTH: 161px; HEIGHT: 15px">Decision Status</td>
									<td style="WIDTH: 14px; HEIGHT: 14px"></td>
									<td class="TDBGColorValue" style="HEIGHT: 14px"><asp:textbox id="txt_decsta" runat="server" ReadOnly MaxLength="10" Columns="10" Width="288px"></asp:textbox></td>
								</tr>
								<tr>
									<td class="TDBGColor1" style="WIDTH: 161px; HEIGHT: 15px">Override Status</td>
									<td style="WIDTH: 14px; HEIGHT: 14px"></td>
									<td class="TDBGColorValue" style="HEIGHT: 14px"><asp:textbox id="txt_decovrsta" runat="server" ReadOnly MaxLength="100" Columns="100" Width="40px"></asp:textbox></td>
								</tr>
								<tr>
									<td class="TDBGColor1" style="WIDTH: 161px; HEIGHT: 15px">Override Reason</td>
									<td style="WIDTH: 14px; HEIGHT: 15px"></td>
									<td class="TDBGColorValue" style="HEIGHT: 15px"><asp:dropdownlist id="ddl_decovrreason" runat="server" CssClass="mandatory"></asp:dropdownlist></td>
								</tr>
								<tr>
									<td style="WIDTH: 161px"></td>
									<td style="WIDTH: 14px"></td>
									<td class="TDBGColorValue"><asp:textbox id="txt_decovrreason" runat="server" MaxLength="100" Columns="100" Width="223px"
											onkeypress="return kutip_satu()" TextMode="MultiLine" CssClass="mandatory"></asp:textbox></td>
								</tr>
								<tr>
									<td class="TDBGColor1" style="WIDTH: 161px; HEIGHT: 15px" vAlign="top">Remark</td>
									<td style="WIDTH: 14px; HEIGHT: 15px"></td>
									<td class="TDBGColorValue" style="HEIGHT: 15px"><asp:textbox id="txt_decremark" runat="server" MaxLength="50" Columns="50" Width="288px" onkeypress="return kutip_satu()"
											TextMode="MultiLine" Rows="5"></asp:textbox></td>
								</tr>
								<tr>
									<td style="WIDTH: 161px"></td>
									<td style="WIDTH: 14px"></td>
									<td class="TDBGColorValue" align="right"><asp:label id="lbl_decsta" runat="server" Visible="False"></asp:label><asp:button id="btn_override" Runat="server" Text="Override" onclick="btn_override_Click"></asp:button></td>
									<!--<asp:button id="btn_save" Runat="server" Text="Save"></asp:button>--></tr>
							</table>
						</td>
					</tr>
					<tr>
						<td colSpan="2"><b>IDC</b></td>
					</tr>
					<tr>
						<td class="td" vAlign="top" width="50%" colSpan="2">
							<table cellSpacing="0" cellPadding="0" width="100%">
								<tr>
									<td class="TDBGColor1" style="WIDTH: 140px">Main a/c-IDC Ratio</td>
									<td style="WIDTH: 15px"></td>
									<td class="TDBGColorValue"><asp:textbox id="txt_idcratio" runat="server" ReadOnly MaxLength="100" Columns="100" Width="100px"></asp:textbox></td>
								</tr>
								<tr>
									<td class="TDBGColor1" style="WIDTH: 140px">IDC Loan Term</td>
									<td style="WIDTH: 15px"></td>
									<td class="TDBGColorValue"><asp:textbox id="txt_idcterm" runat="server" ReadOnly MaxLength="100" Columns="100" Width="100px"></asp:textbox></td>
								</tr>
								<tr>
									<td class="TDBGColor1" style="WIDTH: 140px">IDC a/c - % Kapitalis</td>
									<td style="WIDTH: 15px"></td>
									<td class="TDBGColorValue"><asp:textbox id="txt_idccapratio" runat="server" ReadOnly MaxLength="100" Columns="100" Width="100px"></asp:textbox></td>
								</tr>
								<tr>
									<td class="TDBGColor1" style="WIDTH: 140px">IDC variance code and percentage</td>
									<td style="WIDTH: 15px"></td>
									<td class="TDBGColorValue"><asp:dropdownlist id="ddl_idcprimevar" runat="server" Visible="False" Enabled="False"></asp:dropdownlist><asp:dropdownlist id="ddl_idcinttype" runat="server" AutoPostBack="True" onselectedindexchanged="ddl_idcinttype_SelectedIndexChanged"></asp:dropdownlist><asp:textbox id="txt_idcprimevar" runat="server" ReadOnly MaxLength="100" Columns="100" Width="40px"></asp:textbox><asp:dropdownlist id="ddl_idcvarcode" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return digitsonly()" id="txt_idcvariance" runat="server" MaxLength="100"
											Columns="100" Width="40px"></asp:textbox>%
									</td>
								</tr>
								<tr>
									<td class="TDBGColor1" style="WIDTH: 140px">IDC a/c - Plafond</td>
									<td style="WIDTH: 15px"></td>
									<td class="TDBGColorValue"><asp:textbox id="txt_idccapamt" runat="server" ReadOnly MaxLength="100" Columns="100" Width="100px"></asp:textbox></td>
								</tr>
							</table>
						</td>
					</tr>
				</table>
			</center>
		</form>
	</body>
</HTML>
