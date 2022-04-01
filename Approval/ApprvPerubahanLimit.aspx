<%@ Page language="c#" Codebehind="ApprvPerubahanLimit.aspx.cs" AutoEventWireup="True" Inherits="SME.Approval.ApprvPerubahanLimit" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ApprvPerubahanLimit</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_entries.html" -->
		<!-- #include file="../include/cek_mandatoryOnly.html" -->
		<!-- #include file="../include/popup.html" -->
        <script language="javascript">
            function IsNumeric(n) {
                return !isNaN(parseFloat(n)) && isFinite(n);
            }

            function HitungLimit() {
                var CP_EXLIMITVAL = window.document.getElementById('TXT_CP_EXLIMITVAL').value;
                var CP_EXRPLIMIT = window.document.getElementById('TXT_CP_EXRPLIMIT').value;
                var CP_LIMIT;
                var EXLIMIT;
                var EXRPLIMIT;

                if (IsNumeric(parseFloat(CP_EXLIMITVAL)))
                    EXLIMIT = parseFloat(CP_EXLIMITVAL.replace(/\./g, ''));
                else
                    EXLIMIT = 0;

                if (IsNumeric(parseFloat(CP_EXRPLIMIT)))
                    EXRPLIMIT = parseFloat(CP_EXRPLIMIT.replace(/\./g, ''));
                else
                    EXRPLIMIT = 0;
                CP_LIMIT = EXLIMIT * EXRPLIMIT;
                /*CP_LIMIT = CP_LIMIT.replace('.', ',');*/
                window.document.getElementById('TXT_CP_LIMIT').value = CP_LIMIT;
            }
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
				<TR>
					<TD align="center" width="100%" colSpan="2">
						<%if (Request.QueryString["sta"] != "view") {%>
						<asp:linkbutton id="lb_struc" Font-Bold="True" Runat="server" onclick="lb_struc_Click">Credit Structure</asp:linkbutton><BR>
						<BR>
						<TABLE id="Table7" cellSpacing="1" cellPadding="1" width="100%" border="1">
							<TR>
								<TD>
									<TABLE id="Table9" cellSpacing="1" cellPadding="1" width="100%" border="1">
										<TR>
											<TD class="TDBGColor1">Project Info</TD>
											<TD style="WIDTH: 15px">:</TD>
											<TD>
												<asp:DropDownList id="DDL_PROJECT_CODE" runat="server" Width="150px"></asp:DropDownList>
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
									<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%">
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 140px">Limit</TD>
											<TD style="WIDTH: 15px"></TD>
											<TD class="TDBGColorValue">Rp.
												<asp:textbox id="txt_limit" runat="server" Width="150px" MaxLength="15" ReadOnly Columns="50"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 140px">Jangka Waktu</TD>
											<TD style="WIDTH: 15px"></TD>
											<TD class="TDBGColorValue">
												<asp:textbox id="txt_tenor" runat="server" Width="40px" MaxLength="3" ReadOnly Columns="5"></asp:textbox>&nbsp;
												<asp:textbox id="txt_tenorcode" runat="server" Width="40px" MaxLength="5" ReadOnly Columns="5"></asp:textbox></TD>
										</TR>
										<TR id="tr_fix" runat="server">
											<TD class="TDBGColor1" style="WIDTH: 140px">Suku Bunga Fix</TD>
											<TD style="WIDTH: 15px"></TD>
											<TD class="TDBGColorValue">
												<asp:textbox id="txt_fix" runat="server" Width="40px" MaxLength="6" ReadOnly Columns="10"></asp:textbox>%</TD>
										</TR>
										<TR id="tr_float" runat="server">
											<TD class="TDBGColor1" style="WIDTH: 140px; HEIGHT: 22px">Suku Bunga Mengambang</TD>
											<TD style="WIDTH: 15px; HEIGHT: 22px"></TD>
											<TD class="TDBGColorValue" style="HEIGHT: 22px">
												<asp:dropdownlist id="ddl_rate" runat="server" Visible="False" Enabled="False"></asp:dropdownlist>
												<asp:textbox id="txt_rate" runat="server" Width="40px" MaxLength="10" ReadOnly Columns="10"></asp:textbox>%
												<asp:dropdownlist id="ddl_varcode" runat="server" Enabled="False"></asp:dropdownlist>
												<asp:textbox id="txt_variance" runat="server" Width="40px" MaxLength="10" ReadOnly Columns="10"></asp:textbox>%
											</TD>
										</TR>
										<TR id="tr_install" runat="server">
											<TD class="TDBGColor1" style="WIDTH: 140px">Installment</TD>
											<TD style="WIDTH: 15px"></TD>
											<TD class="TDBGColorValue">
												<asp:textbox id="txt_installment" runat="server" Width="152px" MaxLength="15" ReadOnly Columns="10"></asp:textbox></TD>
										</TR>
									</TABLE>
								</TD>
								<TD class="td" vAlign="top">
									<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 164px">Tujuan Penggunaan</TD>
											<TD style="WIDTH: 15px"></TD>
											<TD class="TDBGColorValue">
												<asp:textbox id="txt_purpose" runat="server" Width="280px" MaxLength="200" ReadOnly Columns="200"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 164px">Sifat Kredit</TD>
											<TD style="WIDTH: 15px"></TD>
											<TD class="TDBGColorValue">
												<asp:textbox id="txt_sifat" runat="server" Width="176px" MaxLength="100" ReadOnly Columns="100"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 164px; HEIGHT: 18px">Total Agunan dalam Rp.</TD>
											<TD style="WIDTH: 15px; HEIGHT: 18px"></TD>
											<TD class="TDBGColorValue" style="HEIGHT: 18px">
												<asp:textbox id="txt_totcoll" runat="server" Width="100px" MaxLength="100" ReadOnly Columns="100"></asp:textbox>
												<asp:textbox id="txt_exrplimit" runat="server" Visible="False" Width="24px" MaxLength="50" Columns="50"
													Height="16px"></asp:textbox>
												<asp:textbox id="txt_exlimitval" runat="server" Visible="False" Width="24px" MaxLength="50" Columns="50"
													Height="16px"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 164px" vAlign="top">
												<asp:label id="lbl_exlimitval" runat="server" Visible="False"></asp:label>Remark</TD>
											<TD style="WIDTH: 15px"></TD>
											<TD class="TDBGColorValue">
												<asp:textbox id="txt_remark" runat="server" Width="280px" MaxLength="50" Columns="50" TextMode="MultiLine"
													Height="40px"></asp:textbox></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<tr>
					<td class="tdHeader1" align="center" width="100%" colSpan="2">
						<asp:label id="LBL_ACC_SEQ" runat="server" Visible="False"></asp:label>
						<asp:textbox id="TXT_CP_CUREF" runat="server" Visible="False" Width="56px"></asp:textbox>
						<asp:Label id="LBL_RATENO" runat="server" Visible="False"></asp:Label>
						<asp:label id="LBL_TITLE" runat="server"></asp:label></td>
				</tr>
				<TR>
					<TD vAlign="top" width="50%">
						<FIELDSET>
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="180">Jenis Pengajuan</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue">
										<asp:Label id="LBL_APPTYPE" runat="server"></asp:Label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">AA No.</TD>
									<TD style="WIDTH: 1px"></TD>
									<TD class="TDBGColorValue">
										<asp:label id="LBL_AA_NO" runat="server"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 17px">Kode Fasilitas</TD>
									<TD style="WIDTH: 1px; HEIGHT: 17px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px">
										<asp:Label id="LBL_PRODUCTID" runat="server"></asp:Label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 17px">No Rekening</TD>
									<TD style="WIDTH: 1px; HEIGHT: 17px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px">
										<asp:Label id="LBL_ACC_NO" runat="server"></asp:Label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Pembentukan</TD>
									<TD style="WIDTH: 1px"></TD>
									<TD class="TDBGColorValue">
										<asp:Label id="LBL_PRODUCT" runat="server"></asp:Label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Limit Lama -&nbsp;</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:Label id="LBL_CP_LIMITLAMA" runat="server"></asp:Label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="180">
										Perubahan Limit -&nbsp;</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:dropdownlist id="DDL_CP_LIMITCHG" runat="server" CssClass="mandatory" Enabled="False">
											<asp:ListItem Value="+" Selected="True">+</asp:ListItem>
											<asp:ListItem Value="-">-</asp:ListItem>
										</asp:dropdownlist><asp:textbox onkeypress="return digitsonly()" onkeyup="HitungLimit()" id="TXT_CP_EXLIMITVAL"
											onblur="FormatCurrency(this), FormatCurrency(document.getElementById('TXT_CP_LIMIT'))" runat="server" Width="200px" MaxLength="15"
											CssClass="mandatory"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="180">
										Exchange Rate Rp.</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" onkeyup="HitungLimit()" onblur="FormatCurrency(this), FormatCurrency(document.getElementById('TXT_CP_LIMIT'))"
											id="TXT_CP_EXRPLIMIT" runat="server" Width="200px" MaxLength="15" CssClass="mandatory"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Perubahan Limit&nbsp;in Rp.</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:TextBox onkeypress="return kutip_satu()" id="TXT_CP_LIMIT" runat="server" Width="200px"
											MaxLength="15" ReadOnly="True" BorderStyle="None"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tujuan Penggunaan</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:DropDownList id="DDL_CP_LOANPURPOSE" runat="server" Enabled="False" Width="250px"></asp:DropDownList></TD>
								</TR>
							</TABLE>
						</FIELDSET>
						<asp:Label id="LBL_CURR2" runat="server" visible="false">LBL_CURR1</asp:Label>
						<asp:Label id="LBL_CURR1" runat="server" visible="false"></asp:Label>
						<asp:dropdownlist id="DDL_CP_NOREK" runat="server" Visible="False" AutoPostBack="True"></asp:dropdownlist>
						<asp:TextBox onkeypress="return kutip_satu()" id="TXT_PRODUCTID" runat="server" Visible="False"
							MaxLength="10" Columns="5"></asp:TextBox>
						<asp:Label id="LBL_DECSTA" runat="server" visible="false"></asp:Label>
						<asp:Label id="LBL_CP_LIMIT" runat="server" Visible="False"></asp:Label>
					</TD>
					<TD vAlign="top" width="50%">
						<FIELDSET>
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="100">Keterangan</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CP_KETERANGAN" runat="server" Width="300px"
											Height="120px" TextMode="MultiLine" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD colSpan="3"></TD>
								</TR>
							</TABLE>
						</FIELDSET>
						<asp:textbox onkeypress="return numbersonly()" id="TXT_NEWTENOR" runat="server" Visible="False"
							Width="136px" CssClass="angkamandatory" Columns="4"></asp:textbox>
						<asp:Label id="LBL_NEWTENORCODE" runat="server" Visible="False"></asp:Label>
						<asp:Label id="LBL_VARIANCE" runat="server" Visible="False"></asp:Label>
						<asp:Label id="LBL_INSTALLMENT" runat="server" Visible="False"></asp:Label>
						<asp:Label id="LBL_VARCODE" runat="server" Visible="False"></asp:Label>
						<asp:Label id="LBL_CURR3" runat="server" Visible="False"></asp:Label>
						<asp:Label id="LBL_INTEREST" runat="server" Visible="False"></asp:Label>
						<asp:Label id="LBL_FLOATING" runat="server" Visible="False"></asp:Label>
						<asp:Label id="LBL_INTERESTTYPE" runat="server" Visible="False"></asp:Label><asp:textbox onkeypress="return numbersonly()" id="TXT_CP_INSTALLMENT" runat="server" CssClass="angkamandatory"
							Width="136px" Columns="4" Visible="False"></asp:textbox>
					</TD>
				</TR>
				<TR id="tr" runat="server">
					<TD class="tdheader1" align="center" colSpan="2">
						Decision
						<asp:label id="lbl_usergroup" Runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="2">
						<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 161px; HEIGHT: 15px">Decision Status</TD>
								<TD style="WIDTH: 14px; HEIGHT: 14px"></TD>
								<TD class="TDBGColorValue" style="HEIGHT: 14px">
									<asp:textbox id="txt_decsta" runat="server" Width="288px" ReadOnly="True" MaxLength="10" Columns="10"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 161px; HEIGHT: 15px">Override Status</TD>
								<TD style="WIDTH: 14px; HEIGHT: 14px"></TD>
								<TD class="TDBGColorValue" style="HEIGHT: 14px">
									<asp:textbox id="txt_decovrsta" runat="server" Width="40px" ReadOnly="True" MaxLength="100" Columns="100"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 161px; HEIGHT: 15px">Override Reason</TD>
								<TD style="WIDTH: 14px; HEIGHT: 15px"></TD>
								<TD class="TDBGColorValue" style="HEIGHT: 15px">
									<asp:dropdownlist id="ddl_decovrreason" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 161px"></TD>
								<TD style="WIDTH: 14px"></TD>
								<TD class="TDBGColorValue">
									<asp:textbox onkeypress="return kutip_satu()" id="txt_decovrreason" runat="server" Width="223px"
										MaxLength="100" Columns="100" CssClass="mandatory" TextMode="MultiLine"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 161px; HEIGHT: 15px" vAlign="top">Remark</TD>
								<TD style="WIDTH: 14px; HEIGHT: 15px"></TD>
								<TD class="TDBGColorValue" style="HEIGHT: 15px">
									<asp:textbox onkeypress="return kutip_satu()" id="txt_decremark" runat="server" Width="288px"
										MaxLength="50" Columns="50" TextMode="MultiLine" Rows="5"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 161px">
									<asp:TextBox id="TXT_NEGATIVE" runat="server" Visible="False">NO</asp:TextBox></TD>
								<TD style="WIDTH: 14px"></TD>
								<TD class="TDBGColorValue" align="left">
									<%if (Request.QueryString["sta"] != "view") {%>
									<asp:button id="btn_override" CssClass="button1" Text="Override" Runat="server" onclick="btn_override_Click"></asp:button>
									<asp:Button id="BTN_EARMARK" runat="server" CssClass="button1" Text="Re-Earmark" onclick="BTN_EARMARK_Click"></asp:Button>
									<%}%>
								</TD>
							</TR>
							<TR id="tr_confirm_negative" runat="server">
								<TD style="WIDTH: 161px"></TD>
								<TD style="WIDTH: 14px"></TD>
								<TD class="TDBGColorValue" align="left">
									<asp:Label id="Label1" runat="server" Font-Bold="True" ForeColor="Red">Hasil Earmark akan negatif. Lanjutkan ?</asp:Label>
									<asp:Button id="BTN_NEGATIVE_YES" runat="server" Width="75px" Text="Yes" onclick="BTN_NEGATIVE_YES_Click"></asp:Button>
									<asp:Button id="BTN_NEGATIVE_NO" runat="server" Width="75px" Text="No" onclick="BTN_NEGATIVE_NO_Click"></asp:Button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
