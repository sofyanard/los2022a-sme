<%@ Page language="c#" Codebehind="AppraisalEntry.aspx.cs" AutoEventWireup="True" Inherits="SME.Appraisal.AppraisalEntry" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Appraisal Entry</title>
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
									<TD class="TDBGColor1" width="150">Nama Agency</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_AGENCY" runat="server" Width="200px" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<tr>
									<td class="TDBGColor1" width="150">Nama Pemeriksa</td>
									<td width="15"></td>
									<td class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_APPR_PEMERIKSA" runat="server" Width="200px"
											CssClass="mandatory" MaxLength="50"></asp:textbox></td>
								</tr>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 23px" width="150">Tanggal Appraisal</TD>
									<TD style="HEIGHT: 22px" width="15"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 22px"><asp:textbox onkeypress="return numbersonly()" id="TXT_APPR_DATE_DAY" CssClass="mandatory" MaxLength="2"
											Runat="server" Columns="2"></asp:textbox><asp:dropdownlist id="DDL_APPR_DATE_MONTH" CssClass="mandatory" Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_APPR_DATE_YEAR" CssClass="mandatory" MaxLength="4"
											Runat="server" Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="150">Nama Jaminan</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_APPR_NAME" runat="server" Width="200px"
											CssClass="mandatory" MaxLength="50"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="150">Alamat Jaminan</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_APPR_ADDR" runat="server" Width="200px"
											CssClass="mandatory" MaxLength="50"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="150">Jaminan Atas Nama</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_APPR_ATASNAMA" runat="server" Width="200px"
											MaxLength="50"></asp:textbox></TD>
								</TR>
							</TABLE>
							<asp:label id="LBL_REGNO" runat="server" Visible="False"></asp:label><asp:label id="LBL_CUREF" runat="server" Visible="False"></asp:label><asp:label id="LBL_CL_SEQ" runat="server" Visible="False"></asp:label><asp:label id="LBL_GRP_CO" runat="server" Visible="False"></asp:label><asp:label id="LBL_GRP_COOFF" runat="server" Visible="False"></asp:label></td>
						<td class="td" vAlign="top" width="50%">
							<TABLE cellSpacing="0" cellPadding="0" width="100%">
								<tr>
									<td class="TDBGColor1" width="150">Ikatan Jaminan</td>
									<td width="15"></td>
									<td class="TDBGColorValue"><asp:dropdownlist id="DDL_APPR_IKATCODE" runat="server" CssClass="mandatory"></asp:dropdownlist></td>
								</tr>
								<TR>
									<TD class="TDBGColor1" width="150">Dokumen Kepemilikan</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CERTTYPEID" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="150">No. Sertifikat/Surat</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_APPR_NOSERTIFIKAT" runat="server" Width="150px"
											MaxLength="30"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="150">Tanggal Penerbitan Sertifikat/Surat&nbsp;</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_APPR_SERFDATE_DAY" MaxLength="2" Runat="server"
											Columns="2"></asp:textbox><asp:dropdownlist id="DDL_APPR_SERFDATE_MONTH" ReadOnly Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_APPR_SERFDATE_YEAR" MaxLength="4" Runat="server"
											Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="150">Tanggal Kadaluarsa Sertifikat</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_APPR_SERFEXPDATE_DAY" MaxLength="2" Runat="server"
											Columns="2"></asp:textbox><asp:dropdownlist id="DDL_APPR_SERFEXPDATE_MONTH" ReadOnly Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_APPR_SERFEXPDATE_YEAR" MaxLength="4" Runat="server"
											Columns="4"></asp:textbox></TD>
								</TR>
							</TABLE>
						</td>
					</tr>
					<TR>
						<TD class="tdHeader1" vAlign="top" align="center" colSpan="2"><B>HASIL PENILAIAN 
								JAMINAN</B></TD>
					</TR>
					<tr>
						<td class="td" vAlign="top" width="50%">
							<TABLE cellSpacing="0" cellPadding="0" width="100%">
								<tr>
									<td class="TDBGColor1" width="150">Nilai Pasar</td>
									<td width="15"></td>
									<td class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_APPR_VALUE" onblur="FormatCurrency(this)"
											runat="server" Width="150px" CssClass="mandatory" MaxLength="20"></asp:textbox><asp:textbox onkeypress="return digitsonly()" id="TXT_APPR_SAFETYMARGIN" onblur="FormatCurrency(this)"
											onkeyup="HitungSafetyMargin()" runat="server" Width="50px" CssClass="mandatory" MaxLength="5" Visible="False"></asp:textbox></td>
								</tr>
								<!--<TR>
									<TD class="TDBGColor1" width="150">Nilai Safety margin</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue">&nbsp;%</TD>
								</TR>-->
								<TR>
									<TD class="TDBGColor1" width="150">Nilai Pasar After Safety margin&nbsp;</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_APPR_AFTERSMVALUE" onblur="FormatCurrency(this)"
											runat="server" Width="150px" CssClass="mandatory" MaxLength="20"></asp:textbox></TD>
								</TR>
							</TABLE>
							<asp:label id="lbl_TC" runat="server" Visible="False"></asp:label><asp:label id="lbl_MC" runat="server" Visible="False"></asp:label>
							<asp:label id="lbl_ISDELETE" runat="server" Visible="False"></asp:label></td>
						<td class="td" vAlign="top" width="50%">
							<TABLE cellSpacing="0" cellPadding="0" width="100%">
								<tr>
									<td class="TDBGColor1" style="HEIGHT: 8px" width="150">Marketability</td>
									<td style="HEIGHT: 8px" width="15"></td>
									<td class="TDBGColorValue" style="HEIGHT: 9px"><asp:dropdownlist id="DDL_APPR_MRCODE" runat="server"></asp:dropdownlist></td>
								</tr>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 20px" width="150">Permasalahan</TD>
									<TD style="HEIGHT: 20px" width="15"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:dropdownlist id="DDL_APPR_PMCODE" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 20px" width="150">Pengikatan Sempurna</TD>
									<TD style="HEIGHT: 20px" width="15"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:dropdownlist id="DDL_APPR_IKSCODE" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="150">Penguasaan</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_APPR_KUCODE" runat="server"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</td>
					</tr>
					<tr>
						<td class="td" vAlign="top" width="100%" colSpan="2">
							<TABLE cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="150">Keterangan</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_APPR_REMARK" runat="server" Width="100%"
											Height="72px" TextMode="MultiLine"></asp:textbox></TD>
								</TR>
							</TABLE>
						</td>
					</tr>
					<TR>
						<TD class="tdHeader1" style="HEIGHT: 10px" colSpan="2">Document Upload
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 540px" vAlign="top" width="540">
							<table cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="75">File</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><INPUT id="TXT_FILE_UPLOAD" type="file" size="38" name="File1" runat="Server"></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Status</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:label id="LBL_STATUS" runat="server" ForeColor="Red"></asp:label><asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" ErrorMessage="Only xls, doc, txt or zip files are allowed!"
											ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.xls|.XLS|.doc|.DOC|.txt|.TXT|.zip|.ZIP)$" ControlToValidate="TXT_FILE_UPLOAD"></asp:regularexpressionvalidator></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"></TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:label id="LBL_STATUSREPORT" runat="server" ForeColor="Red"></asp:label></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 21px" align="center" colSpan="3"><asp:button id="BTN_UPLOAD" runat="server" Text="Upload" onclick="BTN_UPLOAD_Click"></asp:button></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="3"></TD>
								</TR>
							</table>
						</TD>
						<TD style="HEIGHT: 42px" vAlign="top">
							<TABLE cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD><ASP:DATAGRID id="DatGrid" runat="server" Width="100%" CellPadding="1" PageSize="1" AutoGenerateColumns="False">
											<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
											<Columns>
												<asp:BoundColumn Visible="False" DataField="SEQ" HeaderText="Seq"></asp:BoundColumn>
												<asp:BoundColumn HeaderText="No.">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center" Width="35px"></ItemStyle>
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
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2"><asp:button id="BTN_REENTRY" runat="server" CssClass="Button1" Visible="False" Text="Re-Entry" onclick="BTN_REENTRY_Click"></asp:button>&nbsp;
							<asp:button id="BTN_SAVE" runat="server" Width="100px" CssClass="Button1" Text="Save" onclick="BTN_SAVE_Click"></asp:button>&nbsp;
							<asp:button id="BTN_DELETE" runat="server" Width="100px" CssClass="Button1" Text="Delete" onclick="BTN_DELETE_Click"></asp:button>&nbsp;
							<asp:button id="BTN_UPDATE" runat="server" CssClass="Button1" Text="Update Status " onclick="BTN_UPDATE_Click"></asp:button></TD>
					</TR>
				</TABLE>
				</TD></TR></TABLE></center>
		</form>
		<script language="vbscript">
		function HitungSafetyMargin()
			set obj = document.Form1
			setlocale("in")
			APPR_VALUE = replace(obj.TXT_APPR_VALUE.value,".","")
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
			obj.TXT_APPR_AFTERSMVALUE.value = formatnumber(APPR_AFTERSMVALUE,2)
		end function
		</script>
	</body>
</HTML>
