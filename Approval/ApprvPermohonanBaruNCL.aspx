<%@ Page language="c#" Codebehind="ApprvPermohonanBaruNCL.aspx.cs" AutoEventWireup="True" Inherits="SME.Approval.ApprvPermohonanBaruNCL" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ApprvPermohonanBaruNCL</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include  file="../include/cek_entries.html" -->
		<!-- #include  file="../include/popup.html" -->
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
						
						<asp:linkbutton id="lb_struc" Font-Bold="True" Runat="server">Credit Structure</asp:linkbutton><BR>
						<br>
						<TABLE id="Table7" cellSpacing="1" cellPadding="1" width="100%" border="1">
							<TR>
								<TD>
									<TABLE id="Table9" cellSpacing="1" cellPadding="1" width="100%" border="1">
										<TR>
											<TD class="TDBGColor1">Project Info</TD>
											<TD style="WIDTH: 15px">:</TD>
											<TD>
												<asp:DropDownList id="DDL_PROJECT_CODE" runat="server" Width="150px"></asp:DropDownList>
												<asp:Button id="btn_Save" runat="server" Visible="False" Text="Save" ></asp:Button>
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
												<asp:textbox id="txt_limit" runat="server" Width="150px" MaxLength="15" Columns="50" ReadOnly></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 140px">Tenor</TD>
											<TD style="WIDTH: 15px"></TD>
											<TD class="TDBGColorValue">
												<asp:textbox id="txt_tenor" runat="server" Width="40px" MaxLength="3" Columns="5" ReadOnly></asp:textbox>&nbsp;
												<asp:textbox id="txt_tenorcode" runat="server" Width="40px" MaxLength="5" Columns="5" ReadOnly></asp:textbox></TD>
										</TR>
										<TR id="tr_fix" runat="server">
											<TD class="TDBGColor1" style="WIDTH: 140px">Interest/p.a Fix</TD>
											<TD style="WIDTH: 15px"></TD>
											<TD class="TDBGColorValue">
												<asp:textbox id="txt_fix" runat="server" Width="40px" MaxLength="6" Columns="10" ReadOnly></asp:textbox>%</TD>
										</TR>
										<TR id="tr_float" runat="server">
											<TD class="TDBGColor1" style="WIDTH: 140px; HEIGHT: 22px">Interest Floating</TD>
											<TD style="WIDTH: 15px; HEIGHT: 22px"></TD>
											<TD class="TDBGColorValue" style="HEIGHT: 22px">
												<asp:dropdownlist id="ddl_rate" runat="server" Visible="False" Enabled="False"></asp:dropdownlist>
												<asp:textbox id="txt_rate" runat="server" Width="40px" MaxLength="10" Columns="10" ReadOnly></asp:textbox>%
												<asp:dropdownlist id="ddl_varcode" runat="server" Enabled="False"></asp:dropdownlist>
												<asp:textbox id="txt_variance" runat="server" Width="40px" MaxLength="10" Columns="10" ReadOnly></asp:textbox>%
											</TD>
										</TR>
										<TR id="tr_install" runat="server">
											<TD class="TDBGColor1" style="WIDTH: 140px">Installment</TD>
											<TD style="WIDTH: 15px"></TD>
											<TD class="TDBGColorValue">
												<asp:textbox id="txt_installment" runat="server" Width="152px" MaxLength="15" Columns="10" ReadOnly></asp:textbox></TD>
										</TR>
									</TABLE>
								</TD>
								<TD class="td" vAlign="top">
									<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 164px">Tujuan Penggunaan</TD>
											<TD style="WIDTH: 15px"></TD>
											<TD class="TDBGColorValue">
												<asp:textbox id="txt_purpose" runat="server" Width="280px" MaxLength="200" Columns="200" ReadOnly></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 164px">Sifat Kredit</TD>
											<TD style="WIDTH: 15px"></TD>
											<TD class="TDBGColorValue">
												<asp:textbox id="txt_sifat" runat="server" Width="176px" MaxLength="100" Columns="100" ReadOnly></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 164px; HEIGHT: 18px">Total Collaterals In Rp.</TD>
											<TD style="WIDTH: 15px; HEIGHT: 18px"></TD>
											<TD class="TDBGColorValue" style="HEIGHT: 18px">
												<asp:textbox id="txt_totcoll" runat="server" Width="100px" MaxLength="100" Columns="100" ReadOnly></asp:textbox>
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
												<asp:textbox id="txt_remark" runat="server" Width="280px" MaxLength="50" Columns="50" Height="40px"
													TextMode="MultiLine"></asp:textbox></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<tr>
					<td class="tdHeader1" align="center" width="100%" colSpan="2"><asp:label id="LBL_PRODUCT" runat="server" Font-Bold="True"></asp:label><asp:label id="LBL_RATENO" runat="server" Visible="False"></asp:label>
						<asp:label id="LBL_VARCODE" runat="server" Visible="False"></asp:label>
						<asp:label id="LBL_VARIANCE" runat="server" Visible="False"></asp:label>
						<asp:label id="LBL_INTEREST" runat="server" Visible="False"></asp:label>
						<asp:label id="LBL_INTERESTTYPE" runat="server" Visible="False"></asp:label>
						<asp:Label id="LBL_PROJECT_CODE" runat="server" Visible="False"></asp:Label>
					</td>
				</tr>
				<TR>
					<TD vAlign="top" width="50%">
						<FIELDSET>
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1">Jenis Pengajuan</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue">
										<asp:Label id="LBL_APPTYPE_DESC" runat="server"></asp:Label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jenis Kredit</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:Label id="LBL_PRODUCT_DESC" runat="server"></asp:Label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Sifat Kredit</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:Label id="LBL_REVOLVING" runat="server"></asp:Label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tujuan Penggunaan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CP_LOANPURPOSE" runat="server" Enabled="False"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="170">
										Limit Awal diminta (dlm Valuta)</TD>
									<TD style="WIDTH: 3px"></TD>
									<TD class="TDBGColorValue"><asp:label id="LBL_CP_LIMITAWAL" runat="server"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="170">Limit dlm Valuta yang diminta</TD>
									<TD style="WIDTH: 3px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CP_EXLIMITVAL" onblur="FormatCurrency(this), FormatCurrency(document.getElementById('TXT_CP_LIMIT'))"
											onkeyup="HitungLimit()" runat="server" AutoPostBack="True" Width="200px" CssClass="mandatory"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="170">
										Kurs Valuta</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CP_EXRPLIMIT" onblur="FormatCurrency(this), FormatCurrency(document.getElementById('TXT_CP_LIMIT'))"
											onkeyup="HitungLimit()" runat="server" Width="200px" CssClass="mandatory"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Limit (Rp)</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:Label id="LBL_CP_LIMIT" runat="server"></asp:Label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Installment</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:Label id="LBL_CP_INSTALLMENT" runat="server"></asp:Label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">
										Jangka Waktu</TD>
									<TD></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 12px"><asp:textbox onkeypress="return numbersonly()" id="TXT_CP_JANGKAWKT" runat="server" AutoPostBack="True"
											CssClass="mandatory" Columns="3" MaxLength="3">0</asp:textbox><asp:dropdownlist id="DDL_CP_TENORCODE" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
								</TR>
								<TR id="tr_decfloat" runat="server">
									<TD class="TDBGColor1">Bunga / p.a: Floating</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue">
										<asp:TextBox id="txt_decrate" runat="server" Columns="3" ReadOnly="True"></asp:TextBox>%
										<asp:DropDownList id="ddl_decvarcode" runat="server"></asp:DropDownList>
										<asp:TextBox id="txt_decvariance" runat="server" Columns="3" onkeypress="return digitsonly()"></asp:TextBox>
										<asp:DropDownList id="ddl_decrate" runat="server" Visible="False"></asp:DropDownList></TD>
								</TR>
								<TR id="tr_decfix" runat="server">
									<TD class="TDBGColor1">Bunga / p.a: Fix</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue">
										<asp:TextBox id="txt_decfix" runat="server" Columns="5"></asp:TextBox>
										<asp:DropDownList id="ddl_idcprimevar" runat="server" Visible="False"></asp:DropDownList></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="170">Keterangan</TD>
									<TD style="WIDTH: 3px"></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return kutip_satu()" id="TXT_CP_KETERANGAN" runat="server" Width="100%"
											Enabled="False" TextMode="MultiLine" Height="48px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="170">Total Limit Exposure</TD>
									<TD style="WIDTH: 3px"></TD>
									<TD class="TDBGColorValue">
										<asp:Label id="LBL_LIMITEXPOSURE" runat="server"></asp:Label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="170">Total Application Value</TD>
									<TD style="WIDTH: 3px"></TD>
									<TD class="TDBGColorValue">
										<asp:Label id="LBL_SUMLIMIT" runat="server"></asp:Label></TD>
								</TR>
							</TABLE>
						</FIELDSET>
						<asp:checkbox id="CHECK_IDC" runat="server" Font-Bold="True" Visible="False" AutoPostBack="True"
							Text="IDC"></asp:checkbox>
						<asp:label id="LBL_DECSTA" runat="server" Visible="False"></asp:label>
						<asp:TextBox id="TXT_CP_LIMIT" runat="server" Visible="True" Width="1px"></asp:TextBox></TD>
					<TD vAlign="top" width="50%">
						<FIELDSET>
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="180">Tanggal Penerbitan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CP_ISSUEDATE_DD" runat="server" Width="24px"
											Columns="4" MaxLength="2" Enabled="False"></asp:textbox><asp:dropdownlist id="DDL_CP_ISSUEDATE_MM" runat="server" Enabled="False"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CP_ISSUEDATE_YY" runat="server" Width="36px"
											Columns="4" MaxLength="4" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tanggal Jatuh Tempo</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CP_DUEDATE_DD" runat="server" Width="24px"
											Columns="4" MaxLength="2" Enabled="False"></asp:textbox><asp:dropdownlist id="DDL_CP_DUEDATE_MM" runat="server" Enabled="False"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CP_DUEDATE_YY" runat="server" Width="36px"
											Columns="4" MaxLength="4" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Dasar Permohonan Penerbitan</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:Label id="LBL_CP_REQUEST" runat="server"></asp:Label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Ditujukan Kepada</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:Label id="LBL_CP_ISSUETO" runat="server"></asp:Label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Alamat</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:Label id="LBL_CP_ISSUEADDR2" runat="server"></asp:Label><BR>
										<asp:Label id="LBL_CP_ISSUEADDR1" runat="server"></asp:Label><BR>
										<asp:Label id="LBL_CP_ISSUEADDR3" runat="server"></asp:Label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nama Barang / Komoditi</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:Label id="LBL_CP_COMMODITYNAME" runat="server"></asp:Label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jumlah</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:Label id="LBL_CP_COMMODITYAMNT" runat="server"></asp:Label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nilai FOB/CIF/CNF</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:Label id="LBL_CP_VALUE" runat="server"></asp:Label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Bank Koresponden</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:dropdownlist id="DDL_CP_BANKCORR" runat="server" Enabled="False"></asp:dropdownlist>
										<asp:dropdownlist id="DDL_CP_BANKCORRCITY" runat="server" Enabled="False" Visible="False"></asp:dropdownlist>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Alamat</TD>
									<TD width="17"></TD>
									<TD class="TDBGColorValue">
										<asp:Label id="LBL_CP_BANKADDR1" runat="server"></asp:Label><BR>
										<asp:Label id="LBL_CP_BANKADDR2" runat="server"></asp:Label><BR>
										<asp:Label id="LBL_CP_BANKADDR3" runat="server"></asp:Label></TD>
								</TR>
							</TABLE>
						</FIELDSET>
						
						<%if (Request.QueryString["sta"] != "view") {%>						
						<INPUT class="Button1" id="btn_Rate1"  style="WIDTH: 165px" onclick="javascript:PopupPage('../DataEntry/arAlternateRate.aspx?regno=<%=Request.QueryString["regno"]%>&curef=<%=Request.QueryString["curef"]%>&apptype=<%=Request.QueryString["apptype"]%>&prodid=<%=Request.QueryString["prod"]%>&prodseq=<%=Request.QueryString["prod_seq"]%>&acckind=1&view=<%=Request.QueryString["view"]%>','1000','350');" type="button" value="Alternate Rate" name="btn_Rate1"> 
						<INPUT class="Button1" id="btn_Pay1"  style="WIDTH: 310px" onclick="javascript:PopupPage('../DataEntry/arAlternatePayment.aspx?regno=<%=Request.QueryString["regno"]%>&curef=<%=Request.QueryString["curef"]%>&apptype=<%=Request.QueryString["apptype"]%>&prodid=<%=Request.QueryString["prod"]%>&prodseq=<%=Request.QueryString["prod_seq"]%>','950','350');" type="button" value="Draw Down Schedule/Alternate Payment" name="btn_Pay1">
						<INPUT class="Button1" id="BTN_EBIZCARD" type="button" value="eBiz Card Info" runat="server" NAME="BTN_EBIZCARD">
						<%}%>
						
					</TD>
				</TR>
				<TR id="TR_IDC" runat="server">
					<TD vAlign="top" align="center" colSpan="2">
						<TABLE id="Table8" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD class="TDBGColor1">IDC a/c - Plafond</TD>
								<TD width="15"></TD>
								<TD class="TDBGColorValue">
									<asp:Label id="LBL_IDC_CAPAMNT" runat="server"></asp:Label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">IDC Loan Term</TD>
								<TD width="15"></TD>
								<TD class="TDBGColorValue">
									<asp:Label id="LBL_IDC_JWAKTU" runat="server"></asp:Label>&nbsp;
									<asp:Label id="LBL_IDC_TENOR" runat="server"></asp:Label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Main a/c&nbsp;- IDC Ratio</TD>
								<TD width="15"></TD>
								<TD class="TDBGColorValue">
									<asp:Label id="LBL_IDC_RATIO" runat="server"></asp:Label>%</TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">IDC a/c - % Kapitalis</TD>
								<TD style="WIDTH: 1px"></TD>
								<TD class="TDBGColorValue">
									<asp:Label id="LBL_IDC_CAPRATIO" runat="server"></asp:Label>%</TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" width="170">IDC Interest</TD>
								<TD style="WIDTH: 1px"></TD>
								<TD class="TDBGColorValue">
									<asp:DropDownList id="DDL_IDC_INTERESTTYPE" runat="server" AutoPostBack="True" Enabled="False"></asp:DropDownList>
									<asp:Label id="LBL_IDC_PRIMEVARCODE" runat="server"></asp:Label>%
									<asp:dropdownlist id="DDL_IDC_VARCODE" runat="server" Width="40px" Enabled="False">
										<asp:ListItem>-- PILIH --</asp:ListItem>
										<asp:ListItem Value="+" Selected="True">+</asp:ListItem>
										<asp:ListItem Value="-">-</asp:ListItem>
									</asp:dropdownlist>
									<asp:Label id="LBL_IDC_VARIANCE" runat="server"></asp:Label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" width="170"></TD>
								<TD style="WIDTH: 1px"></TD>
								<TD class="TDBGColorValue">
									
									<%if (Request.QueryString["sta"] != "view") {%>
									&nbsp;<INPUT class="Button1" id="btn_Rate2" onclick="javascript:PopupPage('../DataEntry/arAlternateRate.aspx?regno=<%=Request.QueryString["regno"]%>&curef=<%=Request.QueryString["curef"]%>&apptype=<%=Request.QueryString["apptype"]%>&prodid=<%=Request.QueryString["prodid"]%>&prodseq=<%=Request.QueryString["prod_seq"]%>&acckind=2&view=<%=Request.QueryString["view"]%>','1000','350');" type="button" value="Alternate Rate" name="btn_Rate2">
									<INPUT class="Button1" id="btn_Pay2" onclick="javascript:PopupPage('../DataEntry/arAlternatePayment.aspx?regno=<%=Request.QueryString["regno"]%>&curef=<%=Request.QueryString["curef"]%>&apptype=<%=Request.QueryString["apptype"]%>&prodid=<%=Request.QueryString["prodid"]%>&prodseq=<%=Request.QueryString["prod_seq"]%>&view=<%=Request.QueryString["view"]%>','950','350');" type="button" value="Alternate Payment Schedule" name="btn_Pay2">
									<%}%>
									
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD class="tdheader1" vAlign="top" align="center" colSpan="2">Decision
						<asp:label id="lbl_usergroup" Runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" colSpan="2">
						<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 161px; HEIGHT: 15px">Status Pemutusan</TD>
								<TD style="WIDTH: 14px; HEIGHT: 14px"></TD>
								<TD class="TDBGColorValue" style="HEIGHT: 14px">
									<asp:textbox id="txt_decsta" runat="server" Width="288px" ReadOnly="True" ColumnsMaxLength="10"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 161px; HEIGHT: 15px">Status Override</TD>
								<TD style="WIDTH: 14px; HEIGHT: 14px"></TD>
								<TD class="TDBGColorValue" style="HEIGHT: 14px">
									<asp:textbox id="txt_decovrsta" runat="server" Width="40px" ReadOnly="True" ColumnsMaxLength="100"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 161px; HEIGHT: 15px">Alasan Override</TD>
								<TD style="WIDTH: 14px; HEIGHT: 15px"></TD>
								<TD class="TDBGColorValue" style="HEIGHT: 15px">
									<asp:dropdownlist id="ddl_decovrreason" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 161px"></TD>
								<TD style="WIDTH: 14px"></TD>
								<TD class="TDBGColorValue">
									<asp:textbox onkeypress="return kutip_satu()" id="txt_decovrreason" runat="server" Width="223px"
										Columns="100" CssClass="mandatory" MaxLength="100" TextMode="MultiLine"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 161px; HEIGHT: 15px" vAlign="top">Remark</TD>
								<TD style="WIDTH: 14px; HEIGHT: 15px"></TD>
								<TD class="TDBGColorValue" style="HEIGHT: 15px">
									<asp:textbox onkeypress="return kutip_satu()" id="txt_decremark" runat="server" Width="288px"
										Columns="50" MaxLength="50" TextMode="MultiLine" Rows="5"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 161px">
									<asp:TextBox id="TXT_NEGATIVE" runat="server" Visible="False">NO</asp:TextBox></TD>
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
									<asp:Label id="Label1" runat="server" Font-Bold="True" ForeColor="Red">Hasil Earmark akan negatif. Lanjutkan ?</asp:Label>&nbsp;
									<asp:Button id="BTN_NEGATIVE_YES" runat="server" Width="75px" Text="Yes"></asp:Button>&nbsp;
									<asp:Button id="BTN_NEGATIVE_NO" runat="server" Width="75px" Text="No"></asp:Button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
