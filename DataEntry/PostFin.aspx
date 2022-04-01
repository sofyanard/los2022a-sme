<%@ Page language="c#" Codebehind="PostFin.aspx.cs" AutoEventWireup="True" Inherits="SME.DataEntry.PostFin" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PostFin</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_mandatoryOnly.html" -->
		<!-- #include file="../include/cek_entries.html" -->
		<!-- #include file="../include/child.html" -->
		<!-- #include  file="../include/popup.html" -->
		<script language="vbscript">
			function HitungLimit()
			SetLocale("in")
			set obj = document.Form1
			if isnumeric(obj.TXT_CP_EXLIMITVAL.value) then
				EXLIMIT = cdbl(obj.TXT_CP_EXLIMITVAL.value)
			else
				EXLIMIT = 0
			end if
			
			if isnumeric(obj.TXT_CP_EXRPLIMIT.value) then
				EXRPLIMIT = cdbl(obj.TXT_CP_EXRPLIMIT.value)
			else
				EXRPLIMIT = 0
			end if
			obj.TXT_CP_LIMIT.value = EXLIMIT * EXRPLIMIT
			obj.TXT_CP_LIMIT.value = replace(obj.TXT_CP_LIMIT.value, ".", ",")
		end function
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
				<tr>
					<td class="tdHeader1" align="center" width="100%" colSpan="2">
						<asp:label id="LBL_PROD_SEQ" runat="server" Visible="False"></asp:label>
						<asp:label id="LBL_AA_NO" runat="server" Visible="False"></asp:label>
						<asp:label id="LBL_ACC_SEQ" runat="server" Visible="False"></asp:label><asp:textbox id="TXT_CP_CUREF" runat="server" Visible="False" Width="56px"></asp:textbox><asp:label id="LBL_PRODID" runat="server" Visible="False"></asp:label><asp:label id="LBL_REGNO" runat="server" Visible="False"></asp:label><asp:label id="LBL_APPTYPE" runat="server" Visible="False"></asp:label><asp:label id="LBL_PRODUCT" runat="server" Font-Bold="True"></asp:label>
						<asp:Label id="LBL_RATENO" runat="server" Visible="False"></asp:Label>
						<asp:label id="LBL_CU_REF" runat="server" Visible="False"></asp:label>
						<asp:label id="LBL_KET_CODE" runat="server" Visible="False"></asp:label>
					</td>
				</tr>
				<TR>
					<TD vAlign="top" width="50%">
						<FIELDSET>
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="180">Jenis Pengajuan</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_APPTYPE" runat="server" ReadOnly="True"
											Width="200px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">NCL Product</TD>
									<TD style="WIDTH: 1px"></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return kutip_satu()" id="TXT_NCLPROD" runat="server" Width="300px" ReadOnly="True"
											BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jenis Kredit</TD>
									<TD style="WIDTH: 1px"></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return kutip_satu()" id="TXT_PRODUCT" runat="server" Width="300px" ReadOnly="True"
											BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">
										Pembentukan</TD>
									<TD style="WIDTH: 1px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_REVOLVING" runat="server" ReadOnly="True" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tujuan Penggunaan</TD>
									<TD style="WIDTH: 1px"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CP_LOANPURPOSE" runat="server" CssClass="mandatory" Width="280px"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Limit Awal yang diminta (Rp)</TD>
									<TD style="WIDTH: 1px"></TD>
									<TD class="TDBGColorValue">
										<asp:Label id="LBL_LIMIT_AWAL" runat="server"></asp:Label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="180">
										Limit&nbsp;-&nbsp;
										<asp:Label id="LBL_CURR2" runat="server"></asp:Label></TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" onkeyup="HitungLimit()" id="TXT_CP_EXLIMITVAL"
											onblur="FormatCurrency(this), FormatCurrency(document.Form1.TXT_CP_LIMIT)" runat="server" CssClass="mandatory" AutoPostBack="True"
											Width="200px" MaxLength="15"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="180">
										Exchange Rate to&nbsp;Rp.</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" onkeyup="HitungLimit()" onblur="FormatCurrency(this), FormatCurrency(document.Form1.TXT_CP_LIMIT)"
											id="TXT_CP_EXRPLIMIT" runat="server" CssClass="mandatory" Width="200px" MaxLength="15"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Request Limit&nbsp;in Rp.</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CP_LIMIT" runat="server" ReadOnly="True"
											CssClass="angkamandatory" Width="200px" MaxLength="15"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tenor</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_CP_JANGKAWKT" runat="server" onkeypress="return kutip_satu()" CssClass="mandatory"
											Columns="3" AutoPostBack="True" MaxLength="3"></asp:textbox>
										<asp:dropdownlist id="DDL_CP_TENORCODE" runat="server" CssClass="mandatory" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</FIELDSET>
					</TD>
					<TD vAlign="top" width="50%">
						<FIELDSET>
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="170">&nbsp; Installment</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CP_INSTALLMENT" runat="server" CssClass="angkamandatory"
											Width="200px" Columns="4" MaxLength="15" BorderStyle="None" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">
										<asp:Label id="LBL_INTERESTTYPE" runat="server"></asp:Label></TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:Label id="LBL_INTEREST" runat="server">0</asp:Label>%
										<asp:Label id="LBL_VARCODE" runat="server"></asp:Label>&nbsp;
										<asp:Label id="LBL_VARIANCE" runat="server"></asp:Label></TD>
								</TR>
								<TR>
									<TD>
										<asp:textbox onkeypress="return numbersonly()" id="TXT_NEWTENOR" runat="server" Visible="False"
											Width="136px" CssClass="angkamandatory" Columns="4"></asp:textbox></TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:Label id="LBL_DECSTA" runat="server" Visible="False"></asp:Label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Keterangan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CP_KETERANGAN" runat="server" Width="200px"
											Height="80px" TextMode="MultiLine" MaxLength="500"></asp:textbox></TD>
								</TR>
							</TABLE>
						</FIELDSET>
						<INPUT class="Button1" id="btn_Pay1" style="WIDTH: 310px" onclick="javascript:PopupPage('arAlternatePayment.aspx?regno=<%=Request.QueryString['regno']%>&amp;curef=<%=Request.QueryString['curef']%>&amp;apptype=<%=Request.QueryString['apptype']%>&amp;prodid=<%=Request.QueryString['prodid']%>&amp;prodseq=<%=Request.QueryString['prod_seq']%>&amp;view=<%=Request.QueryString['view']%>&amp;de=<%=Request.QueryString['de']%>','950','350');" type="button" value="Draw Down Schedule/Alternate Payment" name="btn_Pay1">
						<asp:Label id="LBL_CURR3" runat="server" Visible="False"></asp:Label>
						<asp:Label id="LBL_PRODUCTID" runat="server" Visible="False"></asp:Label>
					</TD>
				</TR>
				<TR id="tr" runat="server">
					<TD class="TDBGColor2" align="center" colSpan="2"><asp:button id="update" runat="server" CssClass="Button1" Text="Update"></asp:button></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
