<%@ Page language="c#" Codebehind="M21M22Pembaharuan.aspx.cs" AutoEventWireup="True" Inherits="SME.DataEntry.M21M22Pembaharuan" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>Struktur Kredit Pembaharuan</TITLE>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include  file="../include/cek_all.html" -->
		<!-- #include file="../include/popup.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
				<tr>
					<td class="tdHeader1" align="center" width="100%" colSpan="2"><asp:textbox id="TXT_CP_CUREF" runat="server" Visible="False" Width="61px"></asp:textbox><asp:label id="LBL_APPTYPE" runat="server" Visible="False"></asp:label><asp:label id="LBL_REGNO" runat="server" Visible="False"></asp:label><asp:label id="LBL_PRODID" runat="server" Visible="False"></asp:label><asp:label id="LBL_PRODUCT" runat="server" Font-Bold="True"></asp:label><asp:label id="LBL_RATENO" runat="server" Visible="False"></asp:label><asp:label id="LBL_PROD_SEQ" runat="server" Visible="False"></asp:label></td>
				</tr>
				<TR>
					<TD vAlign="top" width="50%">
						<FIELDSET>
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="170">Jenis Pengajuan</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_APPTYPE" runat="server" Width="300px" ReadOnly="True"
											BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="170">Jenis Kredit</TD>
									<TD style="WIDTH: 1px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PRODUCT" runat="server" Width="300px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="170">Pembentukan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_REVOLVING" runat="server" Width="300px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="170">Limit
									</TD>
									<TD style="WIDTH: 1px"></TD>
									<TD class="TDBGColorValue">
										<asp:label id="LBL_CURRENCY" runat="server"></asp:label>&nbsp;
										<asp:textbox onkeypress="return numbersonly()" id="TXT_CP_LIMIT" runat="server" Width="300px"
											ReadOnly="True" BorderStyle="None" CssClass="angka" MaxLength="15"></asp:textbox>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="170">Tenor</TD>
									<TD style="WIDTH: 1px; HEIGHT: 12px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_OLDTENOR" runat="server" ReadOnly="True" CssClass="angka" MaxLength="3"
											Columns="3">0</asp:textbox>&nbsp;
										<asp:label id="LBL_OLDTENOR" runat="server"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tujuan Penggunaan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CP_LOANPURPOSE" runat="server" Width="280px" Enabled="False"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</FIELDSET>
						
						<INPUT class="Button1" id="btn_Rate1"  style="WIDTH: 165px" onclick="javascript:PopupPage('arAlternateRate.aspx?regno=<%=Request.QueryString["regno"]%>&curef=<%=Request.QueryString["curef"]%>&apptype=<%=Request.QueryString["apptype"]%>&prodid=<%=Request.QueryString["prodid"]%>&prodseq=<%=Request.QueryString["prod_seq"]%>&acckind=1&view=<%=Request.QueryString["view"]%>&de=<%=Request.QueryString["de"]%>','1000','350');" type="button" value="Alternate Rate" name="btn_Rate1"> 
						<INPUT class="Button1" id="btn_Pay1"  style="WIDTH: 310px" onclick="javascript:PopupPage('arAlternatePayment.aspx?regno=<%=Request.QueryString["regno"]%>&curef=<%=Request.QueryString["curef"]%>&apptype=<%=Request.QueryString["apptype"]%>&prodid=<%=Request.QueryString["prodid"]%>&prodseq=<%=Request.QueryString["prod_seq"]%>&view=<%=Request.QueryString["view"]%>&de=<%=Request.QueryString["de"]%>','950','350');" type="button" value="Draw Down Schedule/Alternate Payment" name="btn_Pay1">
						<asp:dropdownlist id="DDL_PRJ_NAME" runat="server" Enabled="False" Visible=False></asp:dropdownlist>
						
						<INPUT class="Button1" id="BTN_EBIZCARD" type="button" value="eBiz Card Info" runat="server"
							NAME="BTN_EBIZCARD"> 
					</TD>
					<TD vAlign="top" width="50%">
						<FIELDSET>
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<!--
								Informasi No Rekening sudah ada di Ketentuan_Kredit
								<TR>
									<TD class="TDBGColor1" width="170">No. Rekening</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
									</TD>
								</TR>
								-->
								<TR>
									<TD class="TDBGColor1" width="170">Request Tenor</TD>
									<TD style="WIDTH: 1px; HEIGHT: 10px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 10px">
										<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="100%" border="0">
											<TR>
												<TD><asp:radiobuttonlist id="RDO_TENORTYPE" runat="server" Width="240px" Height="8px" AutoPostBack="True"
														RepeatDirection="Horizontal">
														<asp:ListItem Value="1" Selected="True">Days/Month</asp:ListItem>
														<asp:ListItem Value="0">Maturity Date</asp:ListItem>
													</asp:radiobuttonlist></TD>
											</TR>
											<TR>
												<TD colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_NEWTENOR_DAY" runat="server" Visible="False"
														Width="24px" MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_NEWTENOR_MONTH" runat="server" Visible="False"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_NEWTENOR_YEAR" runat="server" Visible="False"
														Width="36px" MaxLength="4" Columns="4"></asp:textbox><asp:textbox id="TXT_CP_INTEREST" runat="server" Visible="False" ReadOnly="True" CssClass="angka"
														MaxLength="2" Columns="4"></asp:textbox><asp:textbox id="TXT_NEWTENOR" onkeyup="return numbersonly()" runat="server" CssClass="angkamandatory"
														MaxLength="3" Columns="3">0</asp:textbox><asp:dropdownlist id="DDL_NEWTENOR" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="170">
										<asp:label id="LBL_INTERESTTYPE" runat="server" Visible="False"></asp:label>Keterangan
										<asp:label id="LBL_INTEREST" runat="server" Visible="False"></asp:label>
										<asp:label id="LBL_VARIANCE" runat="server" Visible="False"></asp:label>
										<asp:label id="LBL_VARCODE" runat="server" Visible="False"></asp:label>
										<asp:dropdownlist id="DDL_CP_NOREK" runat="server" Visible="False" CssClass="mandatory" Enabled="False"></asp:dropdownlist><asp:textbox id="TXT_CP_NOREK" runat="server" Width="176px" ReadOnly="True" MaxLength="2" Columns="4" Visible=False></asp:textbox>
									</TD>
									<TD style="WIDTH: 3px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CP_KETERANGAN" runat="server" Width="250px"
											CssClass="" Height="65px" TextMode="MultiLine"></asp:textbox></TD>
								</TR>
							</TABLE>
						</FIELDSET>
						<asp:checkbox id="CHECK_IDC" runat="server" Visible="False" Font-Bold="True" AutoPostBack="True"
							Text="IDC"></asp:checkbox></TD>
				</TR>
                <TR id="TR1" runat="server">
					<TD vAlign="top" align="center" colSpan="2">
						<fieldset>
							<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="100%">
                                <TR>
									<TD class="TDBGColor1">Flat Rate</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue" style="font-weight: bold">
                                        <asp:textbox onkeypress="return digitsonly()" 
                                            id="FlatRate" runat="server" Width="80px"
                                            MaxLength="15">0</asp:textbox>%
                                        perMonth</TD>
								</TR>
								<TR style="visibility:collapse">
									<TD class="TDBGColor1">Flat Rate</TD>
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
				<tr>
					<td class="tdbgcolor2" colSpan="2"><asp:button id="update" runat="server" Width="100px" CssClass="Button1" Text="Save"></asp:button></td>
				</tr>
				<TR id="TR_STATUS" runat="server">
					<TD class="TDBGColor2" align="center" colSpan="2">
						<asp:Label ID="labelStatus" Runat="Server" Font-Bold="True" Font-Names="Arial" Font-Size="Medium"
							ForeColor="Red"></asp:Label>
					</TD>
				</TR>
				<TR id="TR_IDC" runat="server">
					<TD vAlign="top" colSpan="2">
						<TABLE id="Table8" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD class="TDBGColor1" width="170">Main a/c-IDC Ratio</TD>
								<TD style="WIDTH: 1px"></TD>
								<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_IDC_RATIO" runat="server" Width="300px"
										CssClass="angka" MaxLength="15"></asp:textbox><asp:textbox onkeypress="return numbersonly()" id="TXT_CP_INSTALLMENT" runat="server" Visible="False"
										Width="136px" CssClass="angkamandatory" Columns="4" AutoPostBack="True"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" width="170">IDC Loan Term</TD>
								<TD style="WIDTH: 1px; HEIGHT: 24px"></TD>
								<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_IDC_JWAKTU" runat="server" Width="300px"
										CssClass="angka" MaxLength="15"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" width="170">IDC a/c - % Kapitalis&nbsp;</TD>
								<TD style="WIDTH: 3px"></TD>
								<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_IDC_CAPRATIO" runat="server" Width="136px"
										CssClass="angka" MaxLength="3"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" width="170">IDC variance code and percentage</TD>
								<TD style="WIDTH: 3px"></TD>
								<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_IDC_PRIMEVARCODE" runat="server" Width="40px"
										MaxLength="10"></asp:textbox>%
									<asp:dropdownlist id="DDL_IDC_VARCODE" runat="server" Width="40px">
										<asp:ListItem Value="+" Selected="True">+</asp:ListItem>
										<asp:ListItem Value="-">-</asp:ListItem>
									</asp:dropdownlist><asp:textbox onkeypress="return kutip_satu()" id="TXT_IDC_VARIANCE" runat="server" Width="40px"
										MaxLength="10"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" width="170">IDC a/c - Plafond</TD>
								<TD style="WIDTH: 3px"></TD>
								<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_IDC_CAPAMNT" runat="server" Width="137"
										CssClass="angka" MaxLength="15"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" width="170"></TD>
								<TD style="WIDTH: 3px"></TD>
								<TD class="TDBGColorValue">
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
		</SCRIPT>
	</body>
</HTML>
