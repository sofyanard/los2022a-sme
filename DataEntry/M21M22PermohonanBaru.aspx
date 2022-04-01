<%@ Page language="c#" Codebehind="M21M22PermohonanBaru.aspx.cs" AutoEventWireup="True" Inherits="SME.DataEntry.StrucCreditDetail" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Struktur Kredit Permohonan Baru</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include  file="../include/cek_mandatoryOnly.html" -->
		<!-- #include  file="../include/cek_entries.html" -->
		<!-- #include  file="../include/popup.html" -->
		<!-- #include  file="../include/child.html" -->
        <script language="javascript">
            function IsNumeric(n)
            {
                return !isNaN(parseFloat(n)) && isFinite(n);
            }

            function HitungLimit()
            {
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
				<tr>
					<td class="tdHeader1" align="center" width="100%" colSpan="2">
						<asp:label id="LBL_PROD_SEQ" runat="server" Visible="False"></asp:label>
						<asp:label id="LBL_REGNO" runat="server" Visible="False"></asp:label>
						<asp:label id="LBL_PRODID" runat="server" Visible="False"></asp:label>
						<asp:label id="LBL_APPTYPE" runat="server" Visible="False"></asp:label>
						<asp:label id="LBL_PRODUCT" runat="server" Font-Bold="True"></asp:label>
						<asp:label id="LBL_RATENO" runat="server" Visible="False"></asp:label>
						<asp:label id="LBL_CU_REF" runat="server" Visible="False"></asp:label>
						<asp:label id="LBL_KET_CODE" runat="server" Visible="False"></asp:label>
					</td>
				</tr>
				<TR>
					<TD vAlign="top" width="50%">
						<FIELDSET>
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1">Jenis Pengajuan</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_APPTYPE" runat="server" Width="300px" ReadOnly="True"
											BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jenis Kredit</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_PRODUCT" runat="server" ReadOnly="True"
											AutoPostBack="True" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">
										Pembentukan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_REVOLVING" runat="server" ReadOnly="True" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tujuan Penggunaan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CP_LOANPURPOSE" runat="server" CssClass="mandatory" Width="280px"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Limit Awal yang diminta (dlm Valuta)</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:Label id="LBL_CP_LIMITAWAL" runat="server"></asp:Label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="170">Limit dlm Valuta&nbsp;yang diminta</TD>
									<TD style="WIDTH: 3px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CP_EXLIMITVAL" onkeyup="HitungLimit()"
											runat="server" onblur="FormatCurrency(this);FormatCurrency(document.getElementById('TXT_CP_LIMIT'))" CssClass="mandatory"
											Width="300px" MaxLength="15"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="170">
										Kurs Valuta</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CP_EXRPLIMIT" onkeyup="HitungLimit()" runat="server"
											 onblur="FormatCurrency(this);FormatCurrency(document.getElementById('TXT_CP_LIMIT'))" CssClass="mandatory" Width="300px" MaxLength="15"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Limit (Rp)</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
                                        <asp:textbox id="TXT_CP_LIMIT" runat="server"
											BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"><asp:label id="LBL_INSTALLMENT" runat="server"></asp:label></TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CP_INSTALLMENT" runat="server" Width="300px"
											AutoPostBack="True" CssClass="angkamandatory" Columns="4" MaxLength="15"></asp:textbox></TD>
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
										<asp:textbox onkeypress="return numbersonly()" id="TXT_CP_GRACEPERIOD" runat="server" Columns="3"
											MaxLength="2"></asp:textbox>&nbsp;Bulan</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Frekuensi Angsuran</TD>
									<TD></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 12px">
										<asp:dropdownlist id="DDL_CP_PAYMENTID" runat="server"></asp:dropdownlist></TD>
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
						<asp:CheckBox id="CHK_CP_REVATACCT" runat="server" Font-Bold="True" Text="Rekening Koran"></asp:CheckBox>
						<asp:checkbox id="CHECK_IDC" runat="server" Font-Bold="True" AutoPostBack="True" Text="IDC"></asp:checkbox>
					</TD>
					<TD vAlign="top" width="50%">
						<FIELDSET>
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1"><asp:label id="LBL_INTERESTTYPE" runat="server"></asp:label></TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue"><asp:label id="LBL_INTEREST" runat="server"></asp:label>%
										<asp:label id="LBL_VARCODE" runat="server"></asp:label>&nbsp;
										<asp:label id="LBL_VARIANCE" runat="server"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="170">Keterangan</TD>
									<TD style="WIDTH: 3px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CP_KETERANGAN" runat="server" Width="300px"
											TextMode="MultiLine" Height="100px" MaxLength="500"></asp:textbox></TD>
								</TR>
								<TR>
									<TD>
										<asp:Label id="LBL_DECSTA" runat="server" Visible="False"></asp:Label>
										<asp:DropDownList id="DDL_PROJECT_CODE" runat="server" Visible="False"></asp:DropDownList>
										<asp:Label id="LBL_PROJECT_CODE" runat="server" Visible="False"></asp:Label>
									</TD>
									<TD style="WIDTH: 3px"></TD>
									<TD></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="170">Total Limit Exposure</TD>
									<TD style="WIDTH: 3px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_LIMITEXPOSURE" runat="server" ReadOnly="True"
											CssClass="angka" Width="300px" MaxLength="15"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="170">Total Limit Aplikasi</TD>
									<TD style="WIDTH: 3px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_SUMLIMIT" runat="server" ReadOnly="True"
											CssClass="angka" Width="300px" MaxLength="15"></asp:textbox></TD>
								</TR>
							</TABLE>
							<FIELDSET>
                                <%if (Request.QueryString["de"] == "1") {%>
								
								<INPUT class="Button1" id="btn_Rate1"  style="WIDTH: 165px" 
                                    onclick="javascript:PopupPage('arAlternateRate.aspx?regno=<%=Request.QueryString["regno"]%>&curef=<%=Request.QueryString["curef"]%>&apptype=<%=Request.QueryString["apptype"]%>&prodid=<%=Request.QueryString["prodid"]%>&prodseq=<%=Request.QueryString["prod_seq"]%>&acckind=1&view=<%=Request.QueryString["view"]%>&de=<%=Request.QueryString["de"]%>','1000','350');" 
                                    type="button" value="Alternatif Suku Bunga" name="btn_Rate1"> 
								<INPUT class="Button1" id="btn_Pay1"  style="WIDTH: 310px" 
                                    onclick="javascript:PopupPage('arAlternatePayment.aspx?regno=<%=Request.QueryString["regno"]%>&curef=<%=Request.QueryString["curef"]%>&apptype=<%=Request.QueryString["apptype"]%>&prodid=<%=Request.QueryString["prodid"]%>&prodseq=<%=Request.QueryString["prod_seq"]%>&view=<%=Request.QueryString["view"]%>&de=<%=Request.QueryString["de"]%>','950','350');" 
                                    type="button" value="Jadwal Pencairan / Alternatif Angsuran" name="btn_Pay1">
							
								<INPUT class="Button1" id="BTN_EBIZCARD" style="WIDTH: 165px" runat="server" type="button"
									value="eBiz Card Info" name="btn_Rate1">
								
								<%}%>
								<BR>
								&nbsp;&nbsp;
							</FIELDSET>
						</FIELDSET>
					</TD>
				</TR>
                <TR id="TR1" runat="server">
					<TD vAlign="top" align="center" colSpan="2">
						<fieldset>
							<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="100%">
                                <TR>
									<TD class="TDBGColor1">Suku Bunga Flat</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue" style="font-weight: bold">
                                        <asp:textbox onkeypress="return digitsonly()" 
                                            id="FlatRate" runat="server" Width="80px"
                                            MaxLength="15">0</asp:textbox>%
                                        perYear</TD>
								</TR>
								<TR style="visibility:collapse">
									<TD class="TDBGColor1">Suku Bunga Flat</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue">
                                        <asp:textbox onkeypress="return digitsonly()" 
                                            id="TXT_RATE" runat="server" Width="42px"
											onblur="FormatCurrency(this)" MaxLength="15" ReadOnly="True">0</asp:textbox>%<asp:DropDownList 
                                            ID="DDL_Operator" runat="server">
                                            <asp:ListItem Selected="True">+</asp:ListItem>
                                            <asp:ListItem>-</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:TextBox onkeypress="return digitsonly()" ID="TXT_RATE_CHG" runat="server" Width="45px"></asp:TextBox>
                                        %</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">&nbsp;Angsuran</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue" style="font-weight: bold">
										<asp:textbox CssClass="mandatory" onkeypress="return numbersonly()" 
                                            id="TXT_FLAT_INSTALMENT" runat="server" Columns="4"
											MaxLength="2" ReadOnly="True" Width="199px">0</asp:textbox>&nbsp;perMonth</TD>
								</TR>
								<TR runat="server" id="TR_ANUITY_ISNTALMENT">
									<TD class="TDBGColor1">Angsuran Anuitas</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue" style="font-weight: bold">
                                        <asp:textbox CssClass="mandatory" onkeypress="return digitsonly()" 
                                            id="TXT_ANUITY_INSTALMENT" runat="server" 
                                            Columns="4" MaxLength="3" ReadOnly="True" Width="200px">0</asp:textbox>&nbsp;perMonth</TD>
								</TR>
                                <TR>
									<TD class="TDBGColor1">Suku Bunga Anuitas</TD>
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
                                        <asp:Button ID="BTN_Instalment" runat="server" Text="Hitung Angsuran" 
                                            CssClass="Button1" onclick="Button1_Click" Width="174px" />
									</TD>
								</TR>
							</TABLE>
						</fieldset>
					</TD>
				</TR>
				<TR id="TR_IDC" runat="server">
					<TD vAlign="top" align="center" colSpan="2">
						<fieldset>
							<TABLE id="Table8" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1">IDC a/c - Plafond</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_IDC_CAPAMNT" runat="server" Width="300px"
											onblur="FormatCurrency(this)" MaxLength="15">0</asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">IDC Loan Term</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return numbersonly()" id="TXT_IDC_JWAKTU" runat="server" Columns="4"
											MaxLength="2">0</asp:textbox>&nbsp;
										<asp:Label id="LBL_IDC_TENOR" runat="server"></asp:Label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Main a/c&nbsp;- IDC Ratio</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_IDC_RATIO" runat="server" Columns="4" MaxLength="3">0</asp:textbox>%</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">IDC a/c - % Kapitalis</TD>
									<TD style="WIDTH: 1px"></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return digitsonly()" id="TXT_IDC_CAPRATIO" runat="server" Columns="4"
											CssClass="mandatoryColor" MaxLength="3">0</asp:textbox>%</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="170">
										IDC Interest</TD>
									<TD style="WIDTH: 1px"></TD>
									<TD class="TDBGColorValue">
										<asp:DropDownList id="DDL_IDC_INTERESTTYPE" runat="server" AutoPostBack="True"></asp:DropDownList>
										<asp:textbox onkeypress="return digitsonly()" id="TXT_IDC_PRIMEVARCODE" runat="server" ReadOnly="True"
											Width="40px" MaxLength="10"></asp:textbox>%
										<asp:dropdownlist id="DDL_IDC_VARCODE" runat="server" Width="40px">
											<asp:ListItem Value="+" Selected="True">+</asp:ListItem>
											<asp:ListItem Value="-">-</asp:ListItem>
										</asp:dropdownlist>
										<asp:textbox onkeypress="return digitsonly()" id="TXT_IDC_VARIANCE" runat="server" Width="40px"
											MaxLength="10"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="170"></TD>
									<TD style="WIDTH: 1px"></TD>
									<TD class="TDBGColorValue">&nbsp; 
										<%if (Request.QueryString["de"] != "0") {%>
										<INPUT class="Button1" id="btn_Rate2" onclick="javascript:PopupPage('arAlternateRate.aspx?regno=<%=Request.QueryString["regno"]%>&curef=<%=Request.QueryString["curef"]%>&apptype=<%=Request.QueryString["apptype"]%>&prodid=<%=Request.QueryString["prodid"]%>&prodseq=<%=Request.QueryString["prod_seq"]%>&acckind=2&view=<%=Request.QueryString["view"]%>','1000','350');" type="button" value="Alternate Rate" name="btn_Rate2">
										<!--
										tidak diperlukan lagi...
										<INPUT class="Button1" id="btn_Pay2" onclick="javascript:PopupPage('arAlternatePayment.aspx?regno=<%=Request.QueryString["regno"]%>&curef=<%=Request.QueryString["curef"]%>&apptype=<%=Request.QueryString["apptype"]%>&prodid=<%=Request.QueryString["prodid"]%>&prodseq=<%=Request.QueryString["prod_seq"]%>','950','350');" type="button" value="Alternate Payment Schedule" name="btn_Pay2">
										-->
                                        <%}%>
									</TD>
								</TR>
							</TABLE>
						</fieldset>
					</TD>
				</TR>
				<TR id="tr" runat="server">
					<TD class="TDBGColor2" align="center" colSpan="2"><asp:button id="update" 
                            runat="server" CssClass="Button1" Text="Simpan"></asp:button></TD>
				</TR>
				<TR>
					<td align="center" colSpan="2">
						<table id="Table4" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<td align="center" colSpan="5">
									<table id="Table5" cellSpacing="0" cellPadding="0" width="100%">
										<tr>
											<td><ASP:DATAGRID id="DatGrd" runat="server" Width="100%" CellPadding="1" AutoGenerateColumns="False"
													AllowPaging="True" PageSize="10" HorizontalAlign="Center">
													<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
													<Columns>
														<asp:BoundColumn Visible="False" DataField="CL_SEQ"></asp:BoundColumn>
														<asp:BoundColumn DataField="cl_desc" HeaderText="Collateral Description">
															<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="coltypedesc" HeaderText="Collateral Type">
															<HeaderStyle Width="20%" CssClass="tdSmallHeader"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="lc_percentage" HeaderText="% of Use">
															<HeaderStyle Width="10%" CssClass="tdSmallHeader"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="cl_value" HeaderText="Start Nomial">
															<HeaderStyle Width="15%" CssClass="tdSmallHeader"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="lc_value" HeaderText="End Nominal">
															<HeaderStyle Width="15%" CssClass="tdSmallHeader"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:ButtonColumn Text="Delete" HeaderText="Function" CommandName="Delete">
															<HeaderStyle Width="15%" CssClass="tdSmallHeader"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:ButtonColumn>
													</Columns>
													<PagerStyle Mode="NumericPages"></PagerStyle>
												</ASP:DATAGRID>
											</td>
										</tr>
									</table>
								</td>
							</TR>
							<TR id="TR_STATUS" runat="server">
								<TD class="TDBGColor2" align="center" colSpan="2">
									<asp:Label ID="labelStatus" Runat="Server" Font-Bold="True" Font-Names="Arial" Font-Size="Medium"
										ForeColor="Red"></asp:Label>
								</TD>
							</TR>
							<TR>
								<TD align="left">
									<table id="Table6" cellSpacing="0" cellPadding="0" width="100%">
										<tr align="center">
											<TD width="20%"><asp:dropdownlist id="DDL_CL_ID" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
											<TD><asp:textbox id="TXT_CL_DESC" runat="server" Width="179px" ReadOnly="True"></asp:textbox></TD>
											<TD width="10%"><asp:textbox onkeypress="return digitsonly()" id="TXT_LC_PERCENTAGE" runat="server" Width="48px"
													CssClass="angka"></asp:textbox></TD>
											<TD width="15%"><asp:textbox id="TXT_LC_VALUE" runat="server" ReadOnly="True" CssClass="angka"></asp:textbox></TD>
											<TD width="15%"><asp:textbox id="TXT_ENDVALUE" runat="server" ReadOnly="True" CssClass="angka"></asp:textbox></TD>
											<TD width="15%"><asp:button id="calc" runat="server" Text="hitung"></asp:button>&nbsp;<asp:button id="insert" runat="server" Text="insert"></asp:button></TD>
										</tr>
									</table>
								</TD>
							</TR>
						</table>
					</td>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
