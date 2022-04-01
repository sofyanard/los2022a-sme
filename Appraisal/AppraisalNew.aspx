<%@ Register TagPrefix="uc1" TagName="DocUpload" Src="../CommonForm/DocumentUpload.ascx" %>
<%@ Page language="c#" Codebehind="AppraisalNew.aspx.cs" AutoEventWireup="True" Inherits="SME.Appraisal.AppraisalNew" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>AppraisalNew</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_mandatoryOnly.html" -->
		<!-- #include file="../include/cek_entries.html" -->
		<script language="javascript">
			function update()
			{
				conf = confirm("Are you sure you want to update?");
				if (conf)
				{
					return true;
				}
				else
				{
					return false;
				}
			}

			function update1()
			{
				conf = confirm("Are you sure you want to Re-Entry?");
				if (conf)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		</script>
</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE cellSpacing="2" cellPadding="2" width="100%">
					<tr>
						<td class="td" vAlign="top" width="50%">
							<TABLE cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="150">Nama KJPP</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_AGENCY" runat="server" ReadOnly="True" Width="200px"></asp:textbox></TD>
								</TR>
								<tr>
									<td class="TDBGColor1" width="150">Nama Credit Admin</td>
									<td width="15"></td>
									<td class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_APPR_PEMERIKSA" runat="server" ReadOnly="True"
											Width="200px" MaxLength="50"></asp:textbox></td>
								</tr>
								<TR>
									<TD class="TDBGColor1" width="150">Keterangan Agunan</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_COL_DESC" runat="server" ReadOnly="True"
											Width="200px" MaxLength="50"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="150">ID Agunan</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_COL_ID" runat="server" ReadOnly="True"
											Width="200px" MaxLength="50"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 23px" width="150">Tanggal Penilaian</TD>
									<TD style="HEIGHT: 22px" width="15"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 22px">
                                        <asp:textbox onkeypress="return numbersonly()" id="TXT_APPR_DATE_DAY" 
                                            MaxLength="2" Columns="2"
											Runat="server" CssClass="mandatory"></asp:textbox>
                                        <asp:dropdownlist id="DDL_APPR_DATE_MONTH" Runat="server" CssClass="mandatory"></asp:dropdownlist>
                                        <asp:textbox onkeypress="return numbersonly()" id="TXT_APPR_DATE_YEAR" 
                                            MaxLength="4" Columns="4"
											Runat="server" CssClass="mandatory"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="150">Mata Uang</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CL_CURRENCY" runat="server" Enabled="False"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="150">Lokasi Agunan</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CL_COLLOC" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="150">Penilaian Menurut</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CL_VALACCRDTO" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="150">Jenis Agunan</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CL_JNSAGUNAN" runat="server"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
							<asp:label id="LBL_REGNO" runat="server" Visible="False"></asp:label><asp:label id="LBL_CUREF" runat="server" Visible="False"></asp:label><asp:label id="LBL_CL_SEQ" runat="server" Visible="False"></asp:label><asp:label id="LBL_GRP_CO" runat="server" Visible="False"></asp:label><asp:label id="LBL_GRP_COOFF" runat="server" Visible="False"></asp:label><asp:label id="lbl_TC" runat="server" Visible="False"></asp:label><asp:label id="lbl_MC" runat="server" Visible="False"></asp:label><asp:label id="lbl_ISDELETE" runat="server" Visible="False"></asp:label></td>
						<td class="td" vAlign="top" width="50%">
							<TABLE cellSpacing="0" cellPadding="0" width="100%">
								<tr id="tr1" runat="server">
									<td class="TDBGColor1" width="150">Nilai Bank (Rp)</td>
									<td width="15"></td>
									<td class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_VALUE_BANK" onblur="FormatCurrency(this)"
											runat="server" Width="150px" MaxLength="20" CssClass="mandatory"></asp:textbox></td>
								</tr>
								<tr>
									<td class="TDBGColor1" width="150">Nilai Pasar (Rp)</td>
									<td width="15"></td>
									<td class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_VALUE_PASAR" onblur="FormatCurrency(this)"
											runat="server" Width="150px" MaxLength="20" CssClass="mandatory"></asp:textbox></td>
								</tr>
								<tr>
									<td class="TDBGColor1" width="150">Nilai Likuidasi (Rp)</td>
									<td width="15"></td>
									<td class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_VALUE_LIKUIDASI" onblur="FormatCurrency(this);"
											runat="server" Width="150px" MaxLength="20" CssClass="mandatory"></asp:textbox></td>
								</tr>
								<tr>
									<td class="TDBGColor1" width="150">Safety Margin</td>
									<td width="15"></td>
									<td class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_APPR_SAFETYMARGIN" onblur="FormatCurrency(this);"
											runat="server" Width="50px" MaxLength="5" CssClass=""></asp:textbox>&nbsp;%
									</td>
								</tr>
								<tr>
									<td class="TDBGColor1" width="150">Score</td>
									<td width="15"></td>
									<td class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_SCORE" runat="server" Width="50px" MaxLength="5"
											CssClass="mandatory"></asp:textbox></td>
								</tr>
								<tr>
									<td class="TDBGColor1" width="150">Marketability</td>
									<td width="15"></td>
									<td class="TDBGColorValue"><asp:dropdownlist id="DDL_APPR_MRCODE" runat="server" CssClass="mandatory"></asp:dropdownlist></td>
								</tr>
								<TR>
									<TD class="TDBGColor1" width="150">Pengikatan Sempurna</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_APPR_IKSCODE" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="150">Penguasaan</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_APPR_KUCODE" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="150">Permasalahan</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_APPR_PMCODE" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</td>
					</tr>
					<TR>
						<TD class="tdHeader1" width="100%" colSpan="2">Document Upload</TD>
					</TR>
					<TR>
						<TD vAlign="top" width="50%">
							<table cellSpacing="0" cellPadding="0" width="100%">
								<tr>
									<td><asp:datagrid id="DG_TEMPLATE" runat="server" Width="100%" AutoGenerateColumns="False" PageSize="1"
											CellPadding="1">
											<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
											<Columns>
												<asp:BoundColumn DataField="SEQ" HeaderText="No">
													<HeaderStyle HorizontalAlign="Center" Width="10%" CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="TEMPLATE_DESC" HeaderText="Source File">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:TemplateColumn>
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
													<ItemTemplate>
														<asp:HyperLink id="HP_DOWNLOAD" runat="server" Target="_blank">Download</asp:HyperLink>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:BoundColumn Visible="False" DataField="TEMPLATE_FILENAME"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="TEMPLATE_PATH"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="TEMPLATE_URL"></asp:BoundColumn>
											</Columns>
										</asp:datagrid></td>
								</tr>
							</table>
						</TD>
						<TD vAlign="top" width="50%" rowSpan="2">
							<table cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD><ASP:DATAGRID id="DG_UPLOAD" runat="server" Width="100%" AutoGenerateColumns="False" PageSize="1"
											CellPadding="1">
											<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
											<Columns>
												<asp:BoundColumn Visible="False" DataField="AP_REGNO"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="CU_REF"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="CL_SEQ"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="FU_SEQ"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="FU_USERID" HeaderText="User ID"></asp:BoundColumn>
												<asp:BoundColumn DataField="FU_FILENAME" HeaderText="File Name">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												</asp:BoundColumn>
												<asp:TemplateColumn>
													<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
													<ItemTemplate>
														<asp:HyperLink id="FU_DOWNLOAD" runat="server" Target="_blank">Download</asp:HyperLink>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn>
													<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
													<ItemTemplate>
														<asp:LinkButton id="FU_DELETE" runat="server" CommandName="delete">Delete</asp:LinkButton>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:BoundColumn Visible="False" DataField="FU_URL" HeaderText="Download URL"></asp:BoundColumn>
											</Columns>
										</ASP:DATAGRID></TD>
								</TR>
							</table>
						</TD>
					</TR>
					<TR>
						<TD vAlign="top" width="50%">
							<table cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="75">File</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><INPUT id="TXT_FILE_UPLOAD" type="file" size="30" name="TXT_FILE_UPLOAD" runat="Server"></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Status</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:label id="LBL_STATUS" runat="server" ForeColor="Red"></asp:label><asp:regularexpressionvalidator id="Regularexpressionvalidator2" runat="server" ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.xls|.XLS|.doc|.DOC|.txt|.TXT|.zip|.ZIP)$"
											ControlToValidate="TXT_FILE_UPLOAD" ErrorMessage="Only xls, doc, txt or zip files are allowed!"></asp:regularexpressionvalidator></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"></TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:label id="LBL_STATUSREPORT" runat="server" ForeColor="Red"></asp:label></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 21px" align="center" colSpan="3"><asp:label id="LBL_SUMBERDATA" runat="server"></asp:label></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="3"><asp:button id="BTN_UPLOAD" runat="server" Text="Upload" onclick="BTN_UPLOAD_Click"></asp:button></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="3"></TD>
								</TR>
								<TR>
									<TD align="left" colSpan="3"><FONT color="#0000ff">Note : disarankan utk mempercepat 
											proses tidak meng-klik tulisan download, tp di klik kanan saja dari tulisan 
											download tersebut, kemudian pilih "save target as"...simpan di lokal komputer</FONT></TD>
								</TR>
							</table>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2">
                            <asp:button id="BTN_REENTRY" runat="server" Visible="False" CssClass="Button1" 
                                Text="Input Ulang" onclick="BTN_REENTRY_Click"></asp:button>&nbsp;
							<asp:button id="BTN_SAVE" runat="server" Width="100px" CssClass="Button1" 
                                Text="Simpan" onclick="BTN_SAVE_Click"></asp:button>&nbsp;
							<asp:button id="BTN_DELETE" runat="server" Width="100px" CssClass="Button1" 
                                Text="Hapus" onclick="BTN_DELETE_Click"></asp:button>&nbsp;
							<asp:button id="BTN_UPDATE" runat="server" CssClass="Button1" Text="Update Status " onclick="BTN_UPDATE_Click"></asp:button></TD>
					</TR>
				</TABLE></TD></TR></TABLE></center>
		</form>
		<script language="vbscript">
		function HitungSafetyMargin()
			set obj = document.Form1
			setlocale("in")
			APPR_VALUE = replace(obj.TXT_VALUE_PASAR.value,".","")
			APPR_AFTERSMVALUE = replace(obj.TXT_VALUE_LIKUIDASI.value,".","")
			if isnumeric(APPR_VALUE) then
				APPR_VALUE = cdbl(APPR_VALUE)
			else
				APPR_VALUE = 0
			end if
			if isnumeric(APPR_AFTERSMVALUE) then
				APPR_AFTERSMVALUE = cdbl(APPR_AFTERSMVALUE)
			else
				APPR_AFTERSMVALUE = 0
			end if
			APPR_SAFETYMARGIN = ((APPR_VALUE - APPR_AFTERSMVALUE) / APPR_VALUE) * 100
			if isnumeric(APPR_SAFETYMARGIN) then
				APPR_SAFETYMARGIN = cdbl(APPR_SAFETYMARGIN)
			else
				APPR_SAFETYMARGIN = 0
			end if
			obj.TXT_APPR_SAFETYMARGIN.value = formatnumber(APPR_SAFETYMARGIN,2)
		end function
		function HitungNilaiLikuidasi()
			set obj = document.Form1
			setlocale("in")
			APPR_VALUE = replace(obj.TXT_VALUE_PASAR.value,".","")
			if isnumeric(APPR_VALUE) then
				APPR_VALUE = cdbl(APPR_VALUE)
			else
				APPR_VALUE = 0
			end if
			APPR_SAFETYMARGIN = replace(obj.TXT_APPR_SAFETYMARGIN.value,".","")
			if isnumeric(APPR_SAFETYMARGIN) then
				APPR_SAFETYMARGIN = cdbl(APPR_SAFETYMARGIN)
			else
				APPR_SAFETYMARGIN = 0
			end if
			APPR_AFTERSMVALUE = APPR_VALUE - (APPR_VALUE * APPR_SAFETYMARGIN / 100)
			obj.TXT_VALUE_LIKUIDASI.value = formatnumber(APPR_AFTERSMVALUE,2)
		end function
		</script>
	</body>
</HTML>
