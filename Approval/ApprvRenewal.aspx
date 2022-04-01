<%@ Page language="c#" Codebehind="ApprvRenewal.aspx.cs" AutoEventWireup="True" Inherits="SME.Approval.ApprvRenewal" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ApprvRenewal</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include  file="../include/cek_all.html" -->
		<!-- #include  file="../include/cek_mandatoryOnly.html" -->
		<!-- #include file="../include/popup.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
				<TR>
					<TD align="center" width="100%" colSpan="2">
						<%if (Request.QueryString["sta"] != "view") {%>
						<asp:linkbutton id="lb_struc" Runat="server" Font-Bold="True">Credit Structure</asp:linkbutton>
						<BR>
						<br>
						<TABLE id="Table8" cellSpacing="1" cellPadding="1" width="100%" border="1">
							<TR>
								<TD>
									<TABLE id="Table9" cellSpacing="1" cellPadding="1" width="100%" border="1">
										<TR>
											<TD class="TDBGColor1">Project Info</TD>
											<TD style="WIDTH: 15px">:</TD>
											<TD>
												<asp:DropDownList id="DDL_PROJECT" runat="server" Width="150px"></asp:DropDownList>
												<asp:Button id="btn_Save" runat="server" Visible="False" Text="Save" onclick="btn_Save_Click"></asp:Button>
												<asp:Label id="LBL_PRJ_CODE" runat="server" Visible="False"></asp:Label></TD>
										</TR>
									</TABLE>
								</TD>
								<TD>
									<TABLE id="Table10" cellSpacing="1" cellPadding="1" width="100%" border="1">
										<TR>
											<TD class="TDBGColor1">Earmark Amount</TD>
											<TD style="WIDTH: 15px">:</TD>
											<TD>
												<asp:Label id="LBL_EARMARK_AMOUNT" runat="server"></asp:Label></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
						<BR>
						<%}%>
						<TABLE id="kreditAwal" cellSpacing="2" cellPadding="2" width="100%" runat="server">
							<TR>
								<TD class="td" vAlign="top" width="50%">
									<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="100%">
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 140px">Limit</TD>
											<TD style="WIDTH: 15px"></TD>
											<TD class="TDBGColorValue">Rp.
												<asp:textbox id="txt_limit" runat="server" ReadOnly MaxLength="15" Columns="50" Width="150px"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 140px">Jangka Waktu</TD>
											<TD style="WIDTH: 15px"></TD>
											<TD class="TDBGColorValue"><asp:textbox id="txt_tenor" runat="server" ReadOnly MaxLength="3" Columns="5" Width="40px"></asp:textbox>&nbsp;
												<asp:textbox id="txt_tenorcode" runat="server" ReadOnly MaxLength="5" Columns="5" Width="40px"></asp:textbox><asp:textbox onkeypress="return numbersonly()" id="txt_tenor_year" runat="server" MaxLength="4"
													Columns="4" Width="36px" Visible="False"></asp:textbox><asp:textbox id="txt_tenor_day" onkeyup="return numbersonly()" runat="server" MaxLength="3" Columns="3"
													CssClass="angkamandatory">0</asp:textbox><asp:dropdownlist id="ddl_tenor_month" runat="server"></asp:dropdownlist></TD>
										</TR>
										<TR id="tr_fix" runat="server">
											<TD class="TDBGColor1" style="WIDTH: 140px">SUku Bunga Fix</TD>
											<TD style="WIDTH: 15px"></TD>
											<TD class="TDBGColorValue"><asp:textbox id="txt_fix" runat="server" ReadOnly MaxLength="6" Columns="10" Width="40px"></asp:textbox>%</TD>
										</TR>
										<TR id="tr_float" runat="server">
											<TD class="TDBGColor1" style="WIDTH: 140px; HEIGHT: 22px">Suku Bunga Mengambang</TD>
											<TD style="WIDTH: 15px; HEIGHT: 22px"></TD>
											<TD class="TDBGColorValue" style="HEIGHT: 22px"><asp:dropdownlist id="ddl_rate" runat="server" Enabled="False" Visible="False"></asp:dropdownlist><asp:textbox id="txt_rate" runat="server" ReadOnly MaxLength="10" Columns="10" Width="40px"></asp:textbox>%
												<asp:dropdownlist id="ddl_varcode" runat="server" Enabled="False"></asp:dropdownlist><asp:textbox id="txt_variance" runat="server" ReadOnly MaxLength="10" Columns="10" Width="40px"></asp:textbox>%
											</TD>
										</TR>
										<TR id="tr_install" runat="server">
											<TD class="TDBGColor1" style="WIDTH: 140px">Installment</TD>
											<TD style="WIDTH: 15px"></TD>
											<TD class="TDBGColorValue"><asp:textbox id="txt_installment" runat="server" ReadOnly MaxLength="15" Columns="10" Width="152px"></asp:textbox></TD>
										</TR>
									</TABLE>
								</TD>
								<TD class="td" vAlign="top">
									<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 164px">Tujuan Penggunaan</TD>
											<TD style="WIDTH: 15px"></TD>
											<TD class="TDBGColorValue"><asp:textbox id="txt_purpose" runat="server" ReadOnly MaxLength="200" Columns="200" Width="280px"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 164px">Sifat Kredit</TD>
											<TD style="WIDTH: 15px"></TD>
											<TD class="TDBGColorValue"><asp:textbox id="txt_sifat" runat="server" ReadOnly MaxLength="100" Columns="100" Width="176px"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 164px; HEIGHT: 18px">Total Agunan dalam Rp.</TD>
											<TD style="WIDTH: 15px; HEIGHT: 18px"></TD>
											<TD class="TDBGColorValue" style="HEIGHT: 18px"><asp:textbox id="txt_totcoll" runat="server" ReadOnly MaxLength="100" Columns="100" Width="100px"></asp:textbox><asp:textbox id="txt_exrplimit" runat="server" MaxLength="50" Columns="50" Width="24px" Visible="False"
													Height="16px"></asp:textbox><asp:textbox id="txt_exlimitval" runat="server" MaxLength="50" Columns="50" Width="24px" Visible="False"
													Height="16px"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 164px" vAlign="top"><asp:label id="lbl_exlimitval" runat="server" Visible="False"></asp:label>Remark</TD>
											<TD style="WIDTH: 15px"></TD>
											<TD class="TDBGColorValue"><asp:textbox id="txt_remark" runat="server" MaxLength="50" Columns="50" Width="280px" Height="40px"
													TextMode="MultiLine"></asp:textbox></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
						<TABLE id="tbl_idc" cellSpacing="0" cellPadding="0" width="100%" runat="server">
							<TR>
								<TD class="TDBGColor1" width="170">Main a/c-IDC Ratio</TD>
								<TD style="WIDTH: 1px"></TD>
								<TD class="TDBGColorValue"><asp:label id="LBL_IDC_RATIO" runat="server" Visible="False"></asp:label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" width="170">IDC Loan Term</TD>
								<TD style="WIDTH: 1px; HEIGHT: 24px"></TD>
								<TD class="TDBGColorValue"><asp:label id="LBL_IDC_JWAKTU" runat="server" Visible="False"></asp:label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" width="170">IDC a/c - % Kapitalis&nbsp;</TD>
								<TD style="WIDTH: 3px"></TD>
								<TD class="TDBGColorValue"><asp:label id="LBL_IDC_CAPRATIO" runat="server" Visible="False"></asp:label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" width="170">IDC variance code and percentage</TD>
								<TD style="WIDTH: 3px"></TD>
								<TD class="TDBGColorValue"><asp:dropdownlist id="ddl_idcprimevar" runat="server" Enabled="False" AutoPostBack="True"></asp:dropdownlist>%
									<asp:dropdownlist id="ddl_idcvarcode" runat="server" Width="40px" Enabled="False">
										<asp:ListItem Value="+" Selected="True">+</asp:ListItem>
										<asp:ListItem Value="-">-</asp:ListItem>
									</asp:dropdownlist><asp:label id="LBL_IDC_VARIANCE" runat="server" Visible="False"></asp:label><asp:dropdownlist id="ddl_idcinttype" runat="server" Enabled="False" AutoPostBack="True"></asp:dropdownlist><asp:label id="LBL_IDC_PRIMEVAR" runat="server" Visible="False"></asp:label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" width="170">IDC a/c - Plafond</TD>
								<TD style="WIDTH: 3px"></TD>
								<TD class="TDBGColorValue"><asp:label id="LBL_IDC_CAPAMNT" runat="server" Visible="False"></asp:label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<tr>
					<td class="tdHeader1" align="center" width="100%" colSpan="2"><asp:textbox id="TXT_CP_CUREF" runat="server" Width="61px" Visible="False"></asp:textbox><asp:label id="LBL_PRODUCT" runat="server" Font-Bold="True"></asp:label><asp:label id="LBL_RATENO" runat="server" Visible="False"></asp:label></td>
				</tr>
				<TR>
					<TD vAlign="top" width="50%">
						<FIELDSET>
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="170">Jenis Pengajuan</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:label id="LBL_APPTYPE" runat="server"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="170">Jenis Kredit</TD>
									<TD style="WIDTH: 1px"></TD>
									<TD class="TDBGColorValue"><asp:label id="LBL_PRODUCT_DESC" runat="server"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="170">Pembentukan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:label id="LBL_REVOLVING" runat="server"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="170">Limit
									</TD>
									<TD style="WIDTH: 1px"></TD>
									<TD class="TDBGColorValue"><asp:label id="LBL_CURRENCY" runat="server"></asp:label>&nbsp;<asp:label id="LBL_CP_LIMIT" runat="server"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="170">Tenor</TD>
									<TD style="WIDTH: 1px; HEIGHT: 12px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_OLDTENOR" runat="server" ReadOnly="True" MaxLength="3" Columns="3" BorderStyle="None"
											CssClass="angka">0</asp:textbox>&nbsp;
										<asp:label id="LBL_OLDTENOR" runat="server"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tujuan Penggunaan</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:DropDownList id="DDL_CP_LOANPURPOSE" runat="server" Enabled="False" Width="250px"></asp:DropDownList></TD>
								</TR>
							</TABLE>
						</FIELDSET>
					
						<%if (Request.QueryString["sta"] != "view") {%>
						<INPUT class="Button1" id="btn_Rate1"  style="WIDTH: 165px" onclick="javascript:PopupPage('../DataEntry/arAlternateRate.aspx?regno=<%=Request.QueryString["regno"]%>&curef=<%=Request.QueryString["curef"]%>&apptype=<%=Request.QueryString["apptype"]%>&prodid=<%=Request.QueryString["prod"]%>&prodseq=<%=Request.QueryString["prod_seq"]%>&acckind=1&view=<%=Request.QueryString["view"]%>','1000','350');" type="button" value="Alternate Rate" name="btn_Rate1"> 
						<INPUT class="Button1" id="btn_Pay1"  style="WIDTH: 310px" onclick="javascript:PopupPage('../DataEntry/arAlternatePayment.aspx?regno=<%=Request.QueryString["regno"]%>&curef=<%=Request.QueryString["curef"]%>&apptype=<%=Request.QueryString["apptype"]%>&prodid=<%=Request.QueryString["prod"]%>&prodseq=<%=Request.QueryString["prod_seq"]%>&view=<%=Request.QueryString["view"]%>','950','350');" type="button" value="Draw Down Schedule/Alternate Payment" name="btn_Pay1">
						<INPUT class="Button1" id="BTN_EBIZCARD" type="button" value="eBiz Card Info" name="BTN_EBIZCARD" runat="server">
						<%}%>
					
					</TD>
					<TD vAlign="top" width="50%">
						<FIELDSET>
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<!--
								<TR>
									<TD class="TDBGColor1" width="170">No. Rekening</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"></TD>
								</TR>
								-->
								<TR>
									<TD class="TDBGColor1" width="170">Request Tenor</TD>
									<TD style="WIDTH: 1px; HEIGHT: 10px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 10px">
										<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="100%" border="0">
											<TR>
												<TD><asp:radiobuttonlist id="RDO_TENORTYPE" runat="server" Width="240px" Enabled="False" Height="8px" RepeatDirection="Horizontal"
														AutoPostBack="True">
														<asp:ListItem Value="1" Selected="True">Days/Month</asp:ListItem>
														<asp:ListItem Value="0">Maturity Date</asp:ListItem>
													</asp:radiobuttonlist></TD>
											</TR>
											<TR>
												<TD colSpan="2"><asp:textbox id="TXT_NEWTENOR" onkeyup="return numbersonly()" runat="server" MaxLength="3" Columns="3"
														CssClass="mandatory">0</asp:textbox>
													<asp:dropdownlist id="DDL_NEWTENOR" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_NEWTENOR_DAY" runat="server" MaxLength="2"
														Columns="4" Width="24px" Visible="False"></asp:textbox><asp:dropdownlist id="DDL_NEWTENOR_MONTH" runat="server" Visible="False"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_NEWTENOR_YEAR" runat="server" MaxLength="4"
														Columns="4" Width="36px" Visible="False"></asp:textbox></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="170">Keterangan</TD>
									<TD style="WIDTH: 3px"></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return kutip_satu()" id="TXT_CP_KETERANGAN" runat="server" ReadOnly="True"
											Width="250px" Height="65px" TextMode="MultiLine"></asp:textbox>
										<asp:dropdownlist id="DDL_CP_NOREK" runat="server" Enabled="False" Visible="False"></asp:dropdownlist>
										<asp:label id="LBL_ACC_NO" Visible="False" runat="server"></asp:label>
									</TD>
								</TR>
							</TABLE>
						</FIELDSET>
						<asp:checkbox id="CHECK_IDC" runat="server" Font-Bold="True" Enabled="False" Visible="False" AutoPostBack="True"
							Text="IDC"></asp:checkbox><asp:label id="LBL_INTERESTTYPE" runat="server" Visible="False"></asp:label><asp:label id="LBL_INTEREST" runat="server" Visible="False"></asp:label><asp:label id="LBL_VARIANCE" runat="server" Visible="False"></asp:label><asp:label id="LBL_VARCODE" runat="server" Visible="False"></asp:label><asp:textbox onkeypress="return numbersonly()" id="TXT_CP_INSTALLMENT" runat="server" Columns="4"
							Width="136px" Visible="False" CssClass="angkamandatory" AutoPostBack="True"></asp:textbox><asp:textbox id="TXT_CP_INTEREST" runat="server" ReadOnly="True" MaxLength="2" Columns="4" Visible="False"
							CssClass="angka"></asp:textbox><asp:label id="lbl_decsta" runat="server" Visible="False"></asp:label></TD>
				</TR>
				<TR>
					<TD class="tdheader1" vAlign="top" colSpan="2">Decision
						<asp:label id="lbl_usergroup" Runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" colSpan="2">
						<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%">
							<TBODY>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 161px; HEIGHT: 15px">Decision Status</TD>
									<TD style="WIDTH: 14px; HEIGHT: 14px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 14px"><asp:textbox id="txt_decsta" runat="server" ReadOnly="True" MaxLength="10" Columns="10" Width="288px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 161px; HEIGHT: 15px">Override Status</TD>
									<TD style="WIDTH: 14px; HEIGHT: 14px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 14px"><asp:textbox id="txt_decovrsta" runat="server" ReadOnly="True" MaxLength="100" Columns="100"
											Width="40px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 161px; HEIGHT: 15px">Override Reason</TD>
									<TD style="WIDTH: 14px; HEIGHT: 15px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 15px"><asp:dropdownlist id="ddl_decovrreason" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 161px"></TD>
									<TD style="WIDTH: 14px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="txt_decovrreason" runat="server" MaxLength="100"
											Columns="100" Width="223px" TextMode="MultiLine" CssClass="mandatory"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 161px; HEIGHT: 15px" vAlign="top">Remark</TD>
									<TD style="WIDTH: 14px; HEIGHT: 15px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 15px"><asp:textbox onkeypress="return kutip_satu()" id="txt_decremark" runat="server" MaxLength="50"
											Columns="50" Width="288px" TextMode="MultiLine" Rows="5"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 161px">
										<asp:TextBox id="TXT_NEGATIVE" runat="server" Visible="False">NO</asp:TextBox></TD>
					</TD>
					<TD style="WIDTH: 14px"></TD>
					<TD class="TDBGColorValue" align="left">
						<%if (Request.QueryString["sta"] != "view") {%>
						<asp:button id="btn_override" Runat="server" CssClass="button1" Text="Override"></asp:button>
						<asp:Button id="BTN_EARMARK" runat="server" CssClass="button1" Text="Re-Earmark"></asp:Button>
						<%}%>
					</TD>
				</TR>
				<TR id="tr_confirm_negative" runat="server">
					<TD style="WIDTH: 161px"></TD>
					<TD style="WIDTH: 14px"></TD>
					<TD class="TDBGColorValue" align="left">
						<asp:Label id="Label1" runat="server" Font-Bold="True" ForeColor="Red">Hasil Earmark akan negatif. Lanjutkan ?</asp:Label>
						<asp:Button id="BTN_NEGATIVE_YES" runat="server" Width="75px" Text="Yes"></asp:Button>
						<asp:Button id="BTN_NEGATIVE_NO" runat="server" Width="75px" Text="No"></asp:Button></TD>
				</TR>
			</TABLE>
			</TD></TR></TBODY></TABLE>
		</form>
	</body>
</HTML>
