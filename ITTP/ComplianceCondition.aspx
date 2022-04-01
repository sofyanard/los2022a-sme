<%@ Page language="c#" Codebehind="ComplianceCondition.aspx.cs" AutoEventWireup="True" Inherits="SME.ITTP.ComplianceCondition" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ComplianceCondition</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../SourceSMEReport/style.css" type="text/css" rel="stylesheet">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include  file="../include/cek_entries.html" -->
		<!-- #include  file="../include/onepost.html" -->
		<!-- #include  file="../include/ConfirmBox.html" -->
		<!-- #include  file="../include/cek_mandatoryOnly.html" -->
		<!-- #include file="../include/popup.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<table cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
							<TABLE id="Table6">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Compliance Condition</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<tr>
						<td class="tdHeader1" colSpan="2">
							<asp:label id="lbl_userid" Runat="server" Visible="False"></asp:label><asp:label id="LBL_PROD_SEQ" Runat="server" Visible="False"></asp:label><asp:label id="LBL_PRODUCTID" Runat="server" Visible="False"></asp:label><asp:label id="TXT_CU_REF" Runat="server" Visible="False"></asp:label><asp:label id="LBL_APPTYPE" Runat="server" Visible="False"></asp:label><asp:label id="LBL_TC" Runat="server" Visible="False"></asp:label><asp:label id="LBL_REGNO" Runat="server" Visible="False"></asp:label>Customer 
							Info</td>
					</tr>
					<tr>
						<td align="center" colSpan="2" style="HEIGHT: 201px"><iframe id=if1 
      style="WIDTH: 100%; HEIGHT: 185px" name=if1 
      src="/SME/ITTP/appinfo.aspx?regno=<%=Request.QueryString["regno"]%>&amp;curef=<%=Request.QueryString["curef"]%>&amp;sta=view" 
      scrolling=no> </iframe>
						</td>
					</tr>
					<tr>
						<td colspan="2">
							<asp:textbox id="txt_acqinfo" Height="50" Width="100%" ReadOnly="True" Runat="server" TextMode="MultiLine"></asp:textbox>
							<CENTER></CENTER>
						</td>
					</tr>
					<TR>
						<TD class="tdHeader1" colSpan="2">
							<P align="center">Compliance Condition</P>
						</TD>
					</TR>
					<tr>
						<td style="HEIGHT: 63px" vAlign="top" colSpan="2">
							<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="150">Condition</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_PROSES" Runat="server" Width="750px" ReadOnly CssClass="mandatory"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tanggal Dipenuhi</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL" Runat="server" CssClass="mandatory"
											MaxLength="2" Columns="2"></asp:textbox><asp:dropdownlist id="DDL_BLN" Runat="server" ReadOnly CssClass="mandatory"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN" Runat="server" CssClass="mandatory"
											MaxLength="4" Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Keterangan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_KET" Runat="server" Width="512px" Columns="35"
											TextMode="MultiLine" Height="54px"></asp:textbox>&nbsp;</TD>
								</TR>
							</TABLE>
						</td>
					</tr>
					<TR>
						<TD class="tdBGCOlor2" colSpan="2"><asp:button id="BTN_DF_INPUT" Runat="server" Width="80px" CssClass="button1" Text="Save" onclick="BTN_DF_INPUT_Click"></asp:button>&nbsp;&nbsp;&nbsp;
							<asp:button id="BTN_PRINT" Runat="server" Visible="False" Width="80px" CssClass="button1" Text="Print"></asp:button>&nbsp;&nbsp;
							<asp:button id="BTN_RETURNBU" Runat="server" Width="96px" CssClass="button1" Text="Return to BU" onclick="BTN_RETURNTOBU_Click"></asp:button>&nbsp;&nbsp;
							<asp:button id="BTN_UPDATE" Runat="server" CssClass="button1" Text="Update Status" Enabled="False" onclick="BTN_UPDATE_Click"></asp:button>
							<asp:textbox id="TXT_TEMP" runat="server" BorderStyle="None" Width="1px" ReadOnly="True" ontextchanged="TXT_TEMP_TextChanged"></asp:textbox></TD>
					</TR>
					<TR>
						<TD class="td" colSpan="2"><asp:datagrid id="DGR_LIST" Runat="server" Width="100%" PageSize="1" AutoGenerateColumns="False"
								CellPadding="1">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="des" HeaderText="Syarat">
										<HeaderStyle Width="30%" CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="sy_accdate" HeaderText="Tanggal Dipenuhi" DataFormatString="{0:dd-MMM-yyyy}">
										<HeaderStyle Width="10%" CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="sy_ket" HeaderText="Keterangan">
										<HeaderStyle Width="50%" CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="seq" HeaderText="seq"></asp:BoundColumn>
									<asp:TemplateColumn>
										<HeaderStyle Width="60px" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="Linkbutton1" runat="server" CommandName="delete">delete</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</asp:datagrid></TD>
					</TR>
					<TR>
						<TD align="center" colSpan="2"></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">
							<P align="center">Perjanjian Kredit</P>
						</TD>
					</TR>
					<tr>
						<td colSpan="2">
							<TABLE cellSpacing="2" cellPadding="2" width="100%">
								<tr>
									<td class="td" vAlign="top" width="50%">
										<TABLE cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<td class="TDBGColor1" style="WIDTH: 301px" width="301">Nomor PK Pertama</td>
												<td width="15"></td>
												<td class="TDBGColorValue">&nbsp;
													<asp:textbox onkeypress="return kutip_satu()" id="TXT_CP_PKNO" Runat="server" MaxLength="35"
														Columns="35"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1" style="WIDTH: 301px">Tanggal PK Pertama</td>
												<td></td>
												<td class="TDBGColorValue">&nbsp;
													<asp:textbox onkeypress="return numbersonly()" id="TXT_CP_PKDATEDAY" Runat="server" MaxLength="2"
														Columns="2"></asp:textbox><asp:dropdownlist id="DDL_CP_PKDATEMONTH" Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CP_PKDATEYEAR" Runat="server" MaxLength="4"
														Columns="4"></asp:textbox></td>
											</tr>
										</TABLE>
									</td>
									<td class="td" vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<td class="TDBGColor1" style="WIDTH: 258px" width="258">No. Adendum PK</td>
												<td width="15"></td>
												<td class="TDBGColorValue">&nbsp;
													<asp:textbox onkeypress="return kutip_satu()" id="TXT_CP_PKNOADD" Runat="server" MaxLength="35"
														Columns="35"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1" style="WIDTH: 258px">Tanggal Adendum PK</td>
												<td></td>
												<td class="TDBGColorValue">&nbsp;
													<asp:textbox onkeypress="return numbersonly()" id="TXT_CP_PKDATEADDDAY" Runat="server" MaxLength="2"
														Columns="2"></asp:textbox><asp:dropdownlist id="DDL_CP_PKDATEADDMONTH" Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CP_PKDATEADDYEAR" Runat="server" MaxLength="4"
														Columns="4"></asp:textbox></td>
											</tr>
										</TABLE>
									</td>
								</tr>
							</TABLE>
						</td>
					</tr>
					<TR>
						<TD align="center" colSpan="2"></TD>
					</TR>
				</table>
			</center>
		</form>
	</body>
</HTML>
