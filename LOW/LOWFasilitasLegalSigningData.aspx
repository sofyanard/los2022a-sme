<%@ Page language="c#" Codebehind="LOWFasilitasLegalSigningData.aspx.cs" AutoEventWireup="True" Inherits="SME.LOW.LOWFasilitasLegalSigningData" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" > 

<html>
  <head>
    <title>LOWFasilitasLegalSigningData</title>
    <meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" Content="C#">
    <meta name=vs_defaultClientScript content="JavaScript">
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file = "../include/cek_entries.html" -->
		<!-- #include file="../include/cek_mandatoryOnly.html" -->
		<!-- #include file="../include/onepost.html" -->
		<!-- #include file="../include/exportpost.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<center>
			<form id="Form1" method="post" runat="server">
				<TABLE cellSpacing="0" cellPadding="0" width="100%">
					<tr>
						<td class="tdHeader1"><B>Struktur Kredit</B></td>
					</tr>
					<tr>
						<td>
							<TABLE cellSpacing="2" cellPadding="2" width="100%">
								<tr>
									<td class="td" vAlign="top" width="50%">
										<TABLE cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<td class="TDBGColor1" width="150">Limit</td>
												<td width="15"></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_CP_LIMIT" Columns="35" ReadOnly Runat="server" CssClass="angka"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Tenor</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_CP_TENOR" Columns="35" ReadOnly Runat="server"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Interest/P.a</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_CP_INTEREST" Columns="35" ReadOnly Runat="server"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Interest Type</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_CP_INTTYPE" Columns="35" ReadOnly Runat="server"></asp:textbox></td>
											</tr>
										</TABLE>
									</td>
									<td class="td" vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<td class="TDBGColor1" width="150">Tujuan Penggunaan</td>
												<td width="15"></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_CP_LOANPURPOSE" Columns="35" ReadOnly Runat="server"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Sifat Kredit</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_REVOLVING" Columns="35" ReadOnly Runat="server"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">No. PK Pertama
												</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CP_PKNO" Columns="35" Runat="server" CssClass="mandatory"
														MaxLength="35"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Tanggal PK Pertama
												</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CP_PKDATEDAY" Columns="2" Runat="server"
														CssClass="mandatory" MaxLength="2"></asp:textbox><asp:dropdownlist id="DDL_CP_PKDATEMONTH" Runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CP_PKDATEYEAR" Columns="4" Runat="server"
														CssClass="mandatory" MaxLength="4"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">No. Addendum PK
												</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CP_PKNOADD" Columns="35" Runat="server"
														MaxLength="35"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Tanggal Addendum PK
												</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CP_PKDATEADDDAY" Columns="2" Runat="server"
														MaxLength="2"></asp:textbox><asp:dropdownlist id="DDL_CP_PKDATEADDMONTH" Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CP_PKDATEADDYEAR" Columns="4" Runat="server"
														MaxLength="4"></asp:textbox></td>
											</tr>
										</TABLE>
									</td>
								</tr>
							</TABLE>
						</td>
					</tr>
					<tr>
						<td class="tdHeader1"><B>Biaya-biaya</B></td>
					</tr>
					<tr>
						<td style="HEIGHT: 95px">
							<TABLE cellSpacing="2" cellPadding="2" width="100%">
								<tr>
									<td class="td" vAlign="top" width="50%">
										<TABLE cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<td class="TDBGColor1" width="150">Biaya Administrasi</td>
												<td width="15"></td>
												<td class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CP_BEAADM" Columns="25" Runat="server"
														onblur="FormatCurrency(this)" MaxLength="21"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Biaya Provisi</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CP_BEAPROVISI_PCT" Columns="6" Runat="server"
														CssClass="angkamandatory" MaxLength="6" Width="50px" AutoPostBack="True"></asp:textbox>%
													<asp:textbox id="TXT_CP_BEAPROVISI" runat="server" ReadOnly="True"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Biaya Notaris</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CP_BEANOTARIS" Columns="25" Runat="server"
														onblur="FormatCurrency(this)" CssClass="angkamandatory" MaxLength="21"></asp:textbox></td>
											</tr>
										</TABLE>
									</td>
									<td class="td" vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<td class="TDBGColor1" width="150">Biaya Pengikatan</td>
												<td width="15"></td>
												<td class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CP_BEAIKAT" Columns="25" Runat="server"
														onblur="FormatCurrency(this)" CssClass="angkamandatory" MaxLength="21"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Biaya Meterai</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CP_BEAMATERAI" Columns="25" Runat="server"
														onblur="FormatCurrency(this)" CssClass="angkamandatory" MaxLength="21"></asp:textbox></td>
											</tr>
											<TR>
												<TD class="TDBGColor1">Upfront Fee</TD>
												<TD></TD>
												<TD class="TDBGColorValue">
													<asp:textbox onkeypress="return digitsonly()" id="TXT_CP_BEAUPFRONTFEE" CssClass="angkamandatory"
														onblur="FormatCurrency(this)" Runat="server" Columns="25" MaxLength="21"></asp:textbox></TD>
											</TR>
										</TABLE>
									</td>
								</tr>
							</TABLE>
						</td>
					</tr>
					<tr>
						<td class="tdHeader1"><B>Asuransi Kredit</B></td>
					</tr>
					<tr>
						<td><asp:datagrid id="DataGrid1" runat="server" Width="100%" CellPadding="1" AutoGenerateColumns="False"
								PageSize="3" AllowPaging="True">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="SEQ">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="ICT_DESC" HeaderText="Type">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="INSRCOMPDESC" HeaderText="Nama Perusahaan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="INSRTYPEDESC" HeaderText="Insurance Type">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AN_POLICYNO" HeaderText="No Polis">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AN_CUR" HeaderText="Mata Uang">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AN_VALUE" HeaderText="Nilai Pertanggungan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AN_DATESTART" HeaderText="Tanggal Mulai">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AN_DATEEND" HeaderText="Tanggal Akhir">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AN_PERCENTAGE" HeaderText="% Pertanggungan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AN_PREMI" HeaderText="Premi">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="ICT_LEADDESC" HeaderText="Status">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="IC_ID" HeaderText="IC_ID"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="IT_ID" HeaderText="IT_ID"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="RATE" HeaderText="RATE"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="ICT_ID" HeaderText="ICT_ID"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="CUR_ID" HeaderText="CUR_ID"></asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Function">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="BTNEDIT" runat="server" CommandName="edit">Edit</asp:LinkButton>&nbsp;
											<asp:LinkButton id="BTNDEL" runat="server" CommandName="delete">Delete</asp:LinkButton>&nbsp;
											<asp:LinkButton id="BTNLNK_PRINT" runat="server" CommandName="print">Print</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</asp:datagrid><BR>
							<%if (Request.QueryString["na"] != "0") {%>
							<TABLE cellSpacing="2" cellPadding="2" width="100%">
								<tr>
									<td class="td" vAlign="top" width="50%">
										<TABLE cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD class="TDBGColor1" width="150">Jenis Asuransi</TD>
												<TD width="15"></TD>
												<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CP_INSRTYPE" Runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
											</TR>
											<tr>
												<td class="TDBGColor1" width="150">Nama Perusahaan</td>
												<td width="15"></td>
												<td class="TDBGColorValue"><asp:dropdownlist id="DDL_CP_INSRCOMP" Runat="server"></asp:dropdownlist></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Comments on Asuransi</td>
												<td></td>
												<td class="TDBGColorValue"><asp:dropdownlist id="DDL_ICRATE" Runat="server"></asp:dropdownlist></td>
											</tr>
											<TR>
												<TD class="TDBGColor1">Type</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_INSURANCECOMPANYTYPE" Runat="server"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">No Polis</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CP_POLICYNO" Columns="25" Runat="server"
														MaxLength="20"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Lead Insurance</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:radiobuttonlist id="RDO_LEAD" runat="server" Width="150px" Height="16px" RepeatDirection="Horizontal">
														<asp:ListItem Value="1" Selected="True">Ya</asp:ListItem>
														<asp:ListItem Value="0">Tidak</asp:ListItem>
													</asp:radiobuttonlist></TD>
											</TR>
										</TABLE>
									</td>
									<TD class="td" vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD class="TDBGColor1" width="150">Mata uang</TD>
												<TD width="15"></TD>
												<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CP_CUR" runat="server"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="150">Nilai Pertanggungan</TD>
												<TD width="15"></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CP_INSRAMNT" Columns="25" Runat="server"
														onblur="FormatCurrency(this)" CssClass="angka" MaxLength="20"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="150">Tanggal mulai</TD>
												<TD width="15"></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_DATESTART_DAY" Columns="2" Runat="server"
														MaxLength="2"></asp:textbox><asp:dropdownlist id="DDL_DATESTART_MONTH" Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_DATESTART_YEAR" Columns="4" Runat="server"
														MaxLength="4"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="150">Tanggal akhir</TD>
												<TD width="15"></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_DATEEND_DAY" Columns="2" Runat="server"
														MaxLength="2"></asp:textbox><asp:dropdownlist id="DDL_DATEEND_MONTH" Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_DATEEND_YEAR" Columns="4" Runat="server"
														MaxLength="4"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">% Pertanggungan</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CP_INSRPCT" Columns="4" Runat="server"
														CssClass="angkamandatory" MaxLength="4"></asp:textbox>%</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Premi</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CP_INSRPREMI" Columns="25" Runat="server"
														onblur="FormatCurrency(this)" MaxLength="20"></asp:textbox></TD>
											</TR>
										</TABLE>
									</TD>
								</tr>
								<TR>
									<TD class="td" vAlign="top" align="center" width="50%" colSpan="2"><asp:button id="BTN_TAMBAH" runat="server" Text="Tambah" width="75px" cssclass="button1"></asp:button><asp:label id="LBL_H_SEQ" Runat="server" Visible="False">0</asp:label><asp:button id="BTN_CANCEL" runat="server" Text="Cancel" width="75px" cssclass="button1" Visible="False"></asp:button></TD>
								</TR>
							</TABLE>
							<%}%>
						</td>
					</tr>
					<TR>
						<TD class="tdHeader1"><B>Jenis Pengikatan</B></TD>
					</TR>
					<TR>
						<TD class="td" colSpan="2">
							<TABLE cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="150">PERJANJIAN KREDIT</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue"><asp:radiobuttonlist id="RBL_LEGALSTA" runat="server" RepeatDirection="Horizontal"></asp:radiobuttonlist></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<% if (Request.QueryString["na"] != "2") { %>
					<TR>
						<TD class="tdHeader1" align="center" colSpan="2">Document Export</TD>
					</TR>
					<TR>
						<TD vAlign="top" colSpan="2">
							<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
								<TR>
									<TD style="WIDTH: 477px" vAlign="top">
										<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 11px" width="75">Format</TD>
												<TD style="WIDTH: 15px; HEIGHT: 11px">:</TD>
												<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_FORMAT_TYPE" runat="server" Width="304px" AutoPostBack="True"></asp:dropdownlist><asp:button id="BTN_EXPORT" runat="server" Width="64px" Text="Export"></asp:button></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Status</TD>
												<TD>:</TD>
												<TD class="TDBGColorValue" style="WIDTH: 338px"><asp:label id="LBL_STATUS_EXPORT" runat="server" ForeColor="Red"></asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1"></TD>
												<TD></TD>
												<TD class="TDBGColorValue" style="WIDTH: 338px"><asp:label id="LBL_STATUSEXPORT" runat="server" ForeColor="Red"></asp:label></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 388px; HEIGHT: 21px" align="center" colSpan="3"></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 388px" align="center" colSpan="3"></TD>
											</TR>
										</TABLE>
									</TD>
									<TD id="IHIU" vAlign="top" width="50%">
										<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD id="IHIUaa"><ASP:DATAGRID id="DATA_EXPORT" runat="server" Width="468px" CellPadding="1" AutoGenerateColumns="False"
														PageSize="1">
														<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
														<Columns>
															<asp:BoundColumn Visible="False" DataField="pk_id">
																<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="FU_FILENAME" HeaderText="File Name">
																<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
															</asp:BoundColumn>
															<asp:TemplateColumn>
																<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
																<ItemTemplate>
																	<asp:HyperLink id="HL_DOWNLOAD" runat="server" Target="_blank">Download</asp:HyperLink>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn>
																<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
																<ItemTemplate>
																	<asp:LinkButton id="LinkButton1" runat="server" CommandName="delete">Delete</asp:LinkButton>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:BoundColumn Visible="False" DataField="FU_USERID" HeaderText="User ID"></asp:BoundColumn>
														</Columns>
													</ASP:DATAGRID></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<%}%>
					<TR>
						<TD class="TDBGColor2" align="center"><asp:label id="LBL_PRODUCTID" Runat="server" Visible="False"></asp:label><asp:label id="LBL_REGNO" Runat="server" Visible="False"></asp:label><asp:label id="LBL_TC" Runat="server" Visible="False"></asp:label><asp:button id="BTN_SAVE" Runat="server" CssClass="button1" Text="Save"></asp:button><asp:label id="LBL_CUREF" Runat="server" Visible="False"></asp:label><asp:label id="LBL_APPTYPE" Runat="server" Visible="False"></asp:label><asp:label id="LBL_PROD_SEQ" Runat="server" Visible="False"></asp:label></TD>
					</TR>
				</TABLE>
			</form>
		</center>
	</body>
</HTML>
