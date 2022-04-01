<%@ Page language="c#" Codebehind="KeputusanMain.aspx.cs" AutoEventWireup="True" Inherits="SME.CEA.KeputusanMain" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>KeputusanMain</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_entries.html" -->
		<!-- #include file="../include/cek_all.html" -->
		<!-- #include file="../include/popup.html" -->
		<!-- #include file="../include/onepost.html" -->
		<!-- #include file="../include/ConfirmBox.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table4" width="100%" border="0">
				<TR>
					<TD style="WIDTH: 482px" align="left">
						<TABLE id="Table3">
							<TR>
								<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Keputusan&nbsp;- Main</B></TD>
							</TR>
						</TABLE>
					</TD>
					<td align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></td>
				</TR>
				<TR>
					<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="MenuKeputusanMain" runat="server"></asp:placeholder></TD>
				</TR>
				<TR>
					<TD class="tdHeader1" colSpan="2">Info Rekanan</TD>
				</TR>
				<TR>
					<TD class="td" style="WIDTH: 50%" vAlign="top" width="483">
						<TABLE id="Table16" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 129px">No. Aplikasi</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue"><asp:textbox id="TXT_REGNUM" runat="server" BorderStyle="None" ReadOnly="True" Width="300px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Jenis Rekanan</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue"><asp:textbox id="TXT_JNS_REK" runat="server" BorderStyle="None" ReadOnly="True" Width="300px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Nama Rekanan</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue"><asp:textbox id="TXT_REK_NAME" runat="server" BorderStyle="None" ReadOnly="True" Width="300px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Contact Person</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue"><asp:textbox id="TXT_CP" runat="server" BorderStyle="None" ReadOnly="True" Width="300px"></asp:textbox></TD>
							</TR>
						</TABLE>
						<asp:label id="LBL_CU_CUSTTYPEID" runat="server" Visible="False"></asp:label><asp:label id="LBL_AP_PROG_CODE" runat="server" Visible="False"></asp:label></TD>
					<TD class="td" vAlign="top" width="50%">
						<TABLE id="Table23" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD class="TDBGColor1">Alamat Rekanan</TD>
								<TD style="WIDTH: 15px">:</TD>
								<TD class="TDBGColorValue"><asp:textbox id="TXT_ADDRESS1" runat="server" ReadOnly="True" Width="300px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="HEIGHT: 11px">&nbsp;</TD>
								<TD style="HEIGHT: 11px"></TD>
								<TD class="TDBGColorValue" style="HEIGHT: 11px"><asp:textbox id="TXT_ADDRESS2" runat="server" ReadOnly="True" Width="300px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Kota</TD>
								<TD>:</TD>
								<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_CITY" runat="server" BorderStyle="None" ReadOnly="True" Width="300px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">No. Telepon Kantor</TD>
								<TD></TD>
								<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_TELP" runat="server" ReadOnly="True" Width="300px"></asp:textbox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD class="tdHeader1" colSpan="2">Document Upload</TD>
				</TR>
				<tr>
					<TD vAlign="top" width="50%">
						<table cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD class="TDBGColor1" width="75">File</TD>
								<TD style="WIDTH: 15px">:</TD>
								<TD class="TDBGColorValue"><INPUT id="TXT_FILE_UPLOAD" type="file" size="30" name="File1" runat="Server"></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Status</TD>
								<TD>:</TD>
								<TD class="TDBGColorValue"><asp:label id="LBL_STATUS" runat="server" ForeColor="Red"></asp:label><asp:regularexpressionvalidator id="Regularexpressionvalidator1" runat="server" ErrorMessage="Only xls, doc, txt or zip files are allowed!"
										ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.xls|.XLS|.doc|.DOC|.txt|.TXT|.zip|.ZIP)$" ControlToValidate="TXT_FILE_UPLOAD"></asp:regularexpressionvalidator></TD>
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
					<TD vAlign="top" width="50%" rowSpan="2">
						<table cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD><ASP:DATAGRID id="DATA_EXPORT" runat="server" Width="100%" PageSize="1" CellPadding="1" AutoGenerateColumns="False">
										<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
										<Columns>
											<asp:BoundColumn Visible="False" DataField="ID_UPLOAD_XLS" HeaderText="No" ItemStyle-Width="10px">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="FILE_UPLOAD_XLS_NAME" HeaderText="Destination File">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn>
												<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
												<ItemTemplate>
													<asp:HyperLink id="XLS_DOWNLOAD" runat="server" Target="_blank">Download</asp:HyperLink>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
												<ItemTemplate>
													<asp:LinkButton id="XLS_DELETE" runat="server" CommandName="delete">Delete</asp:LinkButton>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
									</ASP:DATAGRID></TD>
							</TR>
						</table>
					</TD>
					<!--<td></td>--></tr>
				<TR>
					<TD class="tdHeader1" vAlign="top" width="50%" colSpan="2">SANKSI INTERNAL</TD>
				</TR>
				<TR>
					<TD colSpan="2"><ASP:DATAGRID id="Datagrid1" runat="server" Width="100%" CellPadding="1" AutoGenerateColumns="False"
							AllowPaging="True">
							<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
							<Columns>
								<asp:BoundColumn HeaderText="Registrasi#" DataField="REKANAN_REF">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="SANKSIDESC" HeaderText="JENIS SANKSI">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="PROBLEMDESC" HeaderText="PELANGGARAN">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="LETTER#" HeaderText="NO. SURAT">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="LETTER_DATE" HeaderText="TGL SURAT">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="JANGKA_WAKTU" HeaderText="JANGKA WAKTU">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="RFSTATUS" HeaderText="STATUS">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</ASP:DATAGRID></TD>
				</TR>
				<TR>
					<TD class="tdHeader1" vAlign="top" width="50%" colSpan="2">SANKSI EKSTERNAL</TD>
				</TR>
				<TR>
					<TD colSpan="2"><ASP:DATAGRID id="DatGrdExt" runat="server" Width="100%" CellPadding="1" AutoGenerateColumns="False"
							AllowPaging="True">
							<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
							<Columns>
								<asp:BoundColumn HeaderText="Registrasi#" DataField="REKANAN_REF">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="SANKSI" HeaderText="SANKSI">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="PERMASALAHAN" HeaderText="PELANGGARAN">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NO_SURAT" HeaderText="NO. SURAT">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="TGL_SURAT" HeaderText="TGL SURAT">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="JANGKA_WAKTU" HeaderText="JANGKA WAKTU">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="STATUS_SANKSI" HeaderText="STATUS">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</ASP:DATAGRID></TD>
				</TR>
				<TR>
					<TD class="tdHeader1" colSpan="2">Score</TD>
				</TR>
				<TR>
					<TD class="td" style="WIDTH: 50%" vAlign="top" width="483">
						<TABLE id="Table26" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD class="TDBGColor1">Score Kualitatif</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue"><asp:textbox id="TXT_SCORE_KUAL" runat="server" BorderStyle="None" ReadOnly="True" Width="300px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Score Kuantitatif</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue"><asp:textbox id="TXT_SCORE_KUAN" runat="server" BorderStyle="None" ReadOnly="True" Width="300px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Score Wawancara</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue"><asp:textbox id="TXT_SCORE_INTERVIEW" runat="server" BorderStyle="None" ReadOnly="True" Width="300px"></asp:textbox></TD>
							</TR>
						</TABLE>
						<asp:label id="Label1" runat="server" Visible="False"></asp:label><asp:label id="Label2" runat="server" Visible="False"></asp:label></TD>
					<TD class="td" vAlign="top" width="50%"></TD>
				</TR>
				<TR>
					<TD class="tdHeader1" colSpan="2">Approval Committee Akreditasi</TD>
				</TR>
				<TR>
					<TD colSpan="2"><ASP:DATAGRID id="DatGrd" runat="server" Width="100%" PageSize="5" CellPadding="1" AutoGenerateColumns="False"
							AllowPaging="True">
							<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="regnum"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="id_komite"></asp:BoundColumn>
								<asp:BoundColumn DataField="NAMA" HeaderText="Name">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="DECISION" HeaderText="Decision">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="DATE_RA" HeaderText="Date">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Function">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:LinkButton id="LinkButton1" runat="server" Text="Delete" CausesValidation="false" CommandName="Delete"></asp:LinkButton>&nbsp;&nbsp;
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</ASP:DATAGRID></TD>
				</TR>
				<TR>
					<TD class="td" vAlign="top" width="50%" colSpan="2">
						<TABLE id="Table8" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 129px">Nama</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD><asp:dropdownlist id="DDL_COMMITTEE" runat="server"></asp:dropdownlist></TD>
								<TD class="TDBGColorValue" style="WIDTH: 304px">
									<TABLE id="Table9" cellSpacing="1" cellPadding="1" width="100%" border="0">
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 138px"><asp:label id="LBL_CO" runat="server">Decision :</asp:label></TD>
											<TD class="TDBGColorValue" style="HEIGHT: 35px" align="left"><asp:radiobuttonlist id="RDO_DECISION" runat="server" Width="150px" AutoPostBack="True" Height="9px"
													RepeatDirection="Horizontal" onselectedindexchanged="RDO_DECISION_SelectedIndexChanged">
													<asp:ListItem Value="1" Selected="True">Approve</asp:ListItem>
													<asp:ListItem Value="0">Reject</asp:ListItem>
												</asp:radiobuttonlist></TD>
										</TR>
									</TABLE>
								</TD>
								<TD class="TDBGColorValue"><asp:button id="BTN_INSERT" Width="141px" Text="Insert Commitee" CssClass="button1" Runat="server" onclick="BTN_INSERT_Click"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<tr id="TR_ALASAN" runat="server">
					<td>
						<table>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 250px">Alasan Ditolak</TD>
								<TD style="WIDTH: 26px"></TD>
								<TD class="TDBGColorValue" align="left"><asp:textbox id="TXT_CAT" runat="server" Width="450px" Height="100px" TextMode="MultiLine" MaxLength="100"></asp:textbox></TD>
							</TR>
						</table>
					</td>
				</tr>
				<TR>
					<TD align="center" colSpan="2"><asp:button id="BTN_ACQUIRE_INFO" Text="Acquire Info" CssClass="button1" Runat="server" onclick="BTN_ACQUIRE_INFO_Click"></asp:button><asp:button id="BTN_UPDATE" Text="Update Status" CssClass="button1" Runat="server" onclick="BTN_UPDATE_Click"></asp:button><asp:textbox id="TXT_TEMP" runat="server" BorderStyle="None" ReadOnly="True" Width="1px" ontextchanged="TXT_TEMP_TextChanged"></asp:textbox><asp:label id="lbl_regnum" runat="server" Visible="False"></asp:label><asp:label id="lbl_rekananref" runat="server" Visible="False"></asp:label><asp:label id="jml_komite" runat="server" Visible="False"></asp:label>
						<asp:label id="ID_ASURANSI" runat="server" Visible="False"></asp:label>
						<asp:label id="rekanantype" runat="server" Visible="False"></asp:label>
						<asp:label id="ID_REKANAN" runat="server" Visible="False"></asp:label></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
