<%@ Page language="c#" Codebehind="ApprvPermohonanBaruCL.aspx.cs" AutoEventWireup="True" Inherits="SME.Approval.ApprvPermohonanBaruCL" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ApprvPermohonanBaruCL</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include  file="../include/cek_entries.html" -->
		<!-- #include  file="../include/cek_mandatoryOnly.html" -->
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
	    <style type="text/css">
            .style1
            {
                background-color: #e5ebf4;
                color: black;
                border: 1px groove #FFFFFF;
                text-align: right;
                height: 13px;
            }
            .style2
            {
                height: 13px;
            }
            .style3
            {
                BORDER-BOTTOM: #000000 1px outset;
                background-color: white;
                color: black;
                height: 13px;
            }
        </style>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
				<TR>
					<TD align="center" width="100%" colSpan="2">
						
						<%if (Request.QueryString["sta"] != "view") {%>
						
						<asp:linkbutton id="lb_struc" Font-Bold="True" Runat="server">Credit Structure</asp:linkbutton><BR>
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
												<asp:Button id="btn_Save" runat="server" Visible="False" Text="Save" ></asp:Button>
												<asp:Label id="LBL_PRJ_CODE" runat="server" Visible="False"></asp:Label></TD>
										</TR>
									</TABLE>
								</TD>
								<TD>
									<TABLE id="Table10" cellSpacing="1" cellPadding="1" width="100%" border="1">
										<TR>
											<TD class="TDBGColor1">Earmark Amount (Rp)</TD>
											<TD style="WIDTH: 15px">:</TD>
											<TD>
												<asp:Label id="LBL_EARMARK_AMOUNT" runat="server"></asp:Label></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
						
						<%}%>
						
						<TABLE id="kreditAwal" cellSpacing="2" cellPadding="2" width="100%" runat="server">
							<TR>
								<TD class="td" vAlign="top" width="50%">
									<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%">
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 140px">Limit</TD>
											<TD style="WIDTH: 15px"></TD>
											<TD class="TDBGColorValue">Rp.
												<asp:textbox id="txt_limit" runat="server" MaxLength="15" Width="150px" Columns="50" ReadOnly></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 140px">Tenor</TD>
											<TD style="WIDTH: 15px"></TD>
											<TD class="TDBGColorValue">
												<asp:textbox id="txt_tenor" runat="server" MaxLength="3" Width="40px" Columns="5" ReadOnly></asp:textbox>&nbsp;
												<asp:textbox id="txt_tenorcode" runat="server" MaxLength="5" Width="40px" Columns="5" ReadOnly></asp:textbox></TD>
										</TR>
										<TR id="tr_fix" runat="server">
											<TD class="TDBGColor1" style="WIDTH: 140px">Interest/p.a Fix</TD>
											<TD style="WIDTH: 15px"></TD>
											<TD class="TDBGColorValue">
												<asp:textbox id="txt_fix" runat="server" MaxLength="6" Width="40px" Columns="10" ReadOnly></asp:textbox>%</TD>
										</TR>
										<TR id="tr_float" runat="server">
											<TD class="TDBGColor1" style="WIDTH: 140px; HEIGHT: 22px">Interest Floating</TD>
											<TD style="WIDTH: 15px; HEIGHT: 22px"></TD>
											<TD class="TDBGColorValue" style="HEIGHT: 22px">
												<asp:dropdownlist id="ddl_rate" runat="server" Visible="False" Enabled="False"></asp:dropdownlist>
												<asp:textbox id="txt_rate" runat="server" MaxLength="10" Width="40px" Columns="10" ReadOnly></asp:textbox>%
												<asp:dropdownlist id="ddl_varcode" runat="server" Enabled="False"></asp:dropdownlist>
												<asp:textbox id="txt_variance" runat="server" MaxLength="10" Width="40px" Columns="10" ReadOnly></asp:textbox>%
											</TD>
										</TR>
										<TR id="tr_install" runat="server">
											<TD class="TDBGColor1" style="WIDTH: 140px">Installment</TD>
											<TD style="WIDTH: 15px"></TD>
											<TD class="TDBGColorValue">
												<asp:textbox id="txt_installment" runat="server" MaxLength="15" Width="152px" Columns="10" ReadOnly></asp:textbox></TD>
										</TR>
									</TABLE>
								</TD>
								<TD class="td" vAlign="top">
									<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 164px">Tujuan Penggunaan</TD>
											<TD style="WIDTH: 15px"></TD>
											<TD class="TDBGColorValue">
												<asp:textbox id="txt_purpose" runat="server" MaxLength="200" Width="280px" Columns="200" ReadOnly></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 164px">Sifat Kredit</TD>
											<TD style="WIDTH: 15px"></TD>
											<TD class="TDBGColorValue">
												<asp:textbox id="txt_sifat" runat="server" MaxLength="100" Width="176px" Columns="100" ReadOnly></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 164px; HEIGHT: 18px">Total Collaterals In Rp.</TD>
											<TD style="WIDTH: 15px; HEIGHT: 18px"></TD>
											<TD class="TDBGColorValue" style="HEIGHT: 18px">
												<asp:textbox id="txt_totcoll" runat="server" MaxLength="100" Width="100px" Columns="100" ReadOnly></asp:textbox>
												<asp:textbox id="txt_exrplimit" runat="server" Visible="False" MaxLength="50" Width="24px" Columns="50"
													Height="16px"></asp:textbox>
												<asp:textbox id="txt_exlimitval" runat="server" Visible="False" MaxLength="50" Width="24px" Columns="50"
													Height="16px"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 164px" vAlign="top">
												<asp:label id="lbl_exlimitval" runat="server" Visible="False"></asp:label>Remark</TD>
											<TD style="WIDTH: 15px"></TD>
											<TD class="TDBGColorValue">
												<asp:textbox id="txt_remark" runat="server" MaxLength="50" Width="280px" Columns="50" TextMode="MultiLine"
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
						<asp:label id="LBL_PRODUCT" runat="server"></asp:label><asp:label id="LBL_INTERESTTYPE" runat="server" Visible="False"></asp:label>
						<asp:label id="LBL_VARIANCE" runat="server" Visible="False"></asp:label>
						<asp:label id="LBL_VARCODE" runat="server" Visible="False"></asp:label>
						<asp:label id="LBL_INTEREST" runat="server" Visible="False"></asp:label></td>
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
									<TD class="TDBGColor1">
										Pembentukan</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:Label id="LBL_REVOLVING" runat="server"></asp:Label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tujuan Penggunaan</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:DropDownList id="DDL_CP_LOANPURPOSE" runat="server" Enabled="False" Width="250px"></asp:DropDownList></TD>
								</TR>
								<TR>
									<TD class="style1">
										Limit Awal diminta (dlm Valuta)</TD>
									<TD class="style2"></TD>
									<TD class="style3">
										<asp:Label id="LBL_CP_LIMITAWAL" runat="server"></asp:Label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="170">Limit&nbsp;dlm Valuta yang diminta</TD>
									<TD style="WIDTH: 3px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CP_EXLIMITVAL" onkeyup="HitungLimit()"
											runat="server" onblur="FormatCurrency(this), FormatCurrency(document.getElementById('TXT_CP_LIMIT'))" CssClass="mandatory" Width="200px"
											MaxLength="15"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="170">
										Kurs Valuta ke Rp</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CP_EXRPLIMIT" onkeyup="HitungLimit()" runat="server"
											onblur="FormatCurrency(this), FormatCurrency(document.getElementById('TXT_CP_LIMIT'))" CssClass="mandatory" Width="200px" MaxLength="15"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Limit (Rp)</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:TextBox id="TXT_CP_LIMIT" runat="server" AutoPostBack="True" Width="250px" BorderStyle="None"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">
										<asp:label id="LBL_INSTALLMENT" runat="server"></asp:label></TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:Label id="LBL_CP_INSTALLMENT" runat="server"></asp:Label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jangka Waktu</TD>
									<TD></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 12px"><asp:textbox onkeypress="return numbersonly()" id="TXT_CP_JANGKAWKT" runat="server" AutoPostBack="True"
											CssClass="mandatory" Columns="3" MaxLength="3">0</asp:textbox><asp:dropdownlist id="DDL_CP_TENORCODE" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Grace Period</TD>
									<TD></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 12px">
										<asp:TextBox onkeypress="return numbersonly()" id="TXT_CP_GRACEPERIOD" runat="server" MaxLength="2"
											Columns="3"></asp:TextBox>&nbsp;Bulan</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Frekuensi Angsuran</TD>
									<TD></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 12px"><asp:dropdownlist id="DDL_CP_PAYMENTID" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"></TD>
									<TD></TD>
									<TD class="TDBGColorValue"></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Alih Debitur</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:CheckBox id="CHK_ALIHDEB" runat="server" AutoPostBack="True" Text="Yes"></asp:CheckBox></TD>
								</TR>
								<TR id="TR_OLDCIFNO" runat="server">
									<TD class="TDBGColor1">Old CIF No.</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_OLDCIFNO" runat="server" CssClass="mandatory" MaxLength="19"></asp:textbox></TD>
								</TR>
								<TR id="TR_OLDACCNO" runat="server">
									<TD class="TDBGColor1">Old ACC No.</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_OLDACCNO" runat="server" CssClass="mandatory" MaxLength="19"></asp:textbox></TD>
								</TR>
							</TABLE>
						</FIELDSET>
						<asp:CheckBox id="CHK_CP_REVATACCT" runat="server" Font-Bold="True" Text="Rekening Koran" Enabled="False"></asp:CheckBox>
						<asp:checkbox id="CHECK_IDC" runat="server" Font-Bold="True" AutoPostBack="True" Text="IDC" Enabled="False"></asp:checkbox>
						<asp:Label id="LBL_CP_LIMIT" runat="server" Visible="False"></asp:Label>
					</TD>
					<TD vAlign="top" width="50%">
						<FIELDSET>
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR id="tr_decfloat" runat="server">
									<TD class="TDBGColor1" style="HEIGHT: 16px">Bunga / p.a: Floating</TD>
									<TD width="15" style="HEIGHT: 16px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 16px">
										<asp:TextBox id="txt_decrate" runat="server" Columns="3" ReadOnly="True"></asp:TextBox>%
										<asp:DropDownList id="ddl_decvarcode" runat="server"></asp:DropDownList>
										<asp:TextBox id="txt_decvariance" runat="server" Columns="3" onkeypress="return digitsonly()"></asp:TextBox>
										<asp:DropDownList id="ddl_decrate" runat="server" Visible="False"></asp:DropDownList></TD>
								</TR>
								<TR id="tr_decfix" runat="server">
									<TD class="TDBGColor1" style="HEIGHT: 20px">Bunga / p.a: Fix</TD>
									<TD width="15" style="HEIGHT: 20px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 20px">
										<asp:TextBox id="txt_decfix" runat="server" Columns="5"></asp:TextBox>
										<asp:DropDownList id="ddl_idcprimevar" runat="server" Visible="False"></asp:DropDownList></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="170">Keterangan</TD>
									<TD style="WIDTH: 3px"></TD>
									<TD class="TDBGColorValue">
										<asp:TextBox id="TXT_CP_KETERANGAN" runat="server" ReadOnly="True" Width="100%" MaxLength="500"
											Height="100px" TextMode="MultiLine"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD>
										<asp:Label id="LBL_DECSTA" runat="server" Visible="False"></asp:Label>
									</TD>
									<TD style="WIDTH: 3px"></TD>
									<TD></TD>
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
						
						<%if (Request.QueryString["sta"] != "view") {%>
						
						<INPUT class="Button1" id="btn_Rate1"  style="WIDTH: 165px" onclick="javascript:PopupPage('../DataEntry/arAlternateRate.aspx?regno=<%=Request.QueryString["regno"]%>&curef=<%=Request.QueryString["curef"]%>&apptype=<%=Request.QueryString["apptype"]%>&prodid=<%=Request.QueryString["prod"]%>&prodseq=<%=Request.QueryString["prod_seq"]%>&acckind=1&view=<%=Request.QueryString["view"]%>','1000','350');" type="button" value="Alternate Rate" name="btn_Rate1"> 
						<INPUT class="Button1" id="btn_Pay1"  style="WIDTH: 310px" onclick="javascript:PopupPage('../DataEntry/arAlternatePayment.aspx?regno=<%=Request.QueryString["regno"]%>&curef=<%=Request.QueryString["curef"]%>&apptype=<%=Request.QueryString["apptype"]%>&prodid=<%=Request.QueryString["prod"]%>&prodseq=<%=Request.QueryString["prod_seq"]%>&view=<%=Request.QueryString["view"]%>','950','350');" type="button" value="Draw Down Schedule/Alternate Payment" name="btn_Pay1">
						
						<INPUT class="Button1" id="BTN_EBIZCARD" type="button" value="eBiz Card Info" name="btn_Rate1"
							runat="server">
						<%}%>
						
					</TD>
				</TR>
                <TR id="TR1" runat="server">
					<TD vAlign="top" align="center" colSpan="2">
						<fieldset>
							<TABLE id="Table11" cellSpacing="0" cellPadding="0" width="100%">
                                <TR>
									<TD class="TDBGColor1">Flat Rate</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue" style="font-weight: bold">
                                        <asp:textbox onkeypress="return digitsonly()" 
                                            id="FlatRate" runat="server" Width="80px"
                                            MaxLength="15">0</asp:textbox>%
                                        perYear</TD>
								</TR>
								<TR style="visibility:collapse">
									<TD class="TDBGColor1">Flat Rate</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue">
                                        <asp:textbox onkeypress="return digitsonly()" 
                                            id="TXT_RATE_FLAT_PUNDI" runat="server" Width="42px"
											onblur="FormatCurrency(this)" MaxLength="15" ReadOnly="True">0</asp:textbox>%<asp:DropDownList 
                                            ID="DDL_Operator" runat="server">
                                            <asp:ListItem Selected="True">+</asp:ListItem>
                                            <asp:ListItem>-</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:TextBox onkeypress="return digitsonly()" ID="TXT_RATE_CHG" runat="server" Width="45px"></asp:TextBox>
                                        %</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">&nbsp;Instalment</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue" style="font-weight: bold">
										<asp:textbox CssClass="mandatory" onkeypress="return numbersonly()" 
                                            id="TXT_FLAT_INSTALMENT" runat="server" Columns="4"
											MaxLength="2" ReadOnly="True" Width="199px">0</asp:textbox>&nbsp;perMonth</TD>
								</TR>
								<TR runat="server" id="TR_ANUITY_ISNTALMENT">
									<TD class="TDBGColor1">Anuity Instalment</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue" style="font-weight: bold">
                                        <asp:textbox CssClass="mandatory" onkeypress="return digitsonly()" 
                                            id="TXT_ANUITY_INSTALMENT" runat="server" 
                                            Columns="4" MaxLength="3" ReadOnly="True" Width="200px">0</asp:textbox>&nbsp;perMonth</TD>
								</TR>
                                <TR>
									<TD class="TDBGColor1">Anuity Rate</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue" style="font-weight: bold">
                                        <asp:textbox CssClass="mandatory" onkeypress="return digitsonly()" 
                                            id="TXT_ANN_INSTALMENT" runat="server" 
                                            Columns="4" MaxLength="3" ReadOnly="True" Width="47px">0</asp:textbox>%</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="170"></TD>
									<TD style="WIDTH: 1px"></TD>
									<TD class="TDBGColorValue">
                                        <asp:Button ID="BTN_Instalment" runat="server" Text="Calculate Instalment" 
                                            CssClass="Button1" onclick="Button1_Click" Width="174px" />
									</TD>
								</TR>
							</TABLE>
						</fieldset>
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
									<asp:Label id="LBL_IDC_CAPRATIO" runat="server" DESIGNTIMEDRAGDROP="156"></asp:Label>%</TD>
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
									
									<%if (Request.QueryString["sta"] != "view") {%>&nbsp;&nbsp;						
									<%}%>
									
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD class="tdheader1" vAlign="top" align="center" colSpan="2">Keputusan
						<asp:label id="lbl_usergroup" Runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" colSpan="2">
						<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD class="TDBGColor1">Status Pemutusan</TD>
								<TD style="WIDTH: 14px; HEIGHT: 14px"></TD>
								<TD class="TDBGColorValue" style="HEIGHT: 14px">
									<asp:textbox id="txt_decsta" runat="server" MaxLength="10" Width="288px" Columns="10" ReadOnly="True"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Status Override</TD>
								<TD style="WIDTH: 14px; HEIGHT: 14px"></TD>
								<TD class="TDBGColorValue" style="HEIGHT: 14px">
									<asp:textbox id="txt_decovrsta" runat="server" MaxLength="100" Width="40px" Columns="100" ReadOnly="True"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Alasan Override</TD>
								<TD style="WIDTH: 14px; HEIGHT: 15px"></TD>
								<TD class="TDBGColorValue" style="HEIGHT: 15px">
									<asp:dropdownlist id="ddl_decovrreason" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD></TD>
								<TD style="WIDTH: 14px"></TD>
								<TD class="TDBGColorValue">
									<asp:textbox onkeypress="return kutip_satu()" id="txt_decovrreason" runat="server" MaxLength="100"
										Width="223px" Columns="100" TextMode="MultiLine" CssClass="mandatory"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" vAlign="top">Catatan</TD>
								<TD style="WIDTH: 14px; HEIGHT: 15px"></TD>
								<TD class="TDBGColorValue" style="HEIGHT: 15px">
									<asp:textbox onkeypress="return kutip_satu()" id="txt_decremark" runat="server" MaxLength="50"
										Width="288px" Columns="50" TextMode="MultiLine" Rows="5"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 161px">
									<asp:TextBox id="TXT_NEGATIVE" runat="server" Visible="False">NO</asp:TextBox></TD>
								<TD style="WIDTH: 14px"></TD>
								<TD class="TDBGColorValue" align="left">
									
									<%if (Request.QueryString["sta"] != "view") {%>
									<asp:button id="btn_override" CssClass="button1" Text="Override" Runat="server"></asp:button>						
									<asp:Button id="BTN_EARMARK" runat="server" CssClass="button1" Text="Re-Earmark"></asp:Button>
                                    <%}%>
								</TD>
							</TR>
							<TR id="tr_confirm_negative" runat="server">
								<TD style="WIDTH: 161px"></TD>
								<TD style="WIDTH: 14px"></TD>
								<TD class="TDBGColorValue" align="left">
									<asp:Label id="Label1" runat="server" Font-Bold="True" ForeColor="Red">Hasil Earmarking akan negatif. Lanjutkan ?</asp:Label>&nbsp;
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
