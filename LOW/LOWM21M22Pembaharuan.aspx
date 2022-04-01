<%@ Page language="c#" Codebehind="LOWM21M22Pembaharuan.aspx.cs" AutoEventWireup="True" Inherits="SME.LOW.LOWM21M22Pembaharuan" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" > 

<html>
  <head>
    <title>LOWM21M22Pembaharuan</title>
    <meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" Content="C#">
    <meta name=vs_defaultClientScript content="JavaScript">
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
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

