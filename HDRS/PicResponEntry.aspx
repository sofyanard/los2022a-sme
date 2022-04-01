<%@ Page language="c#" Codebehind="PicResponEntry.aspx.cs" AutoEventWireup="True" Inherits="SME.HDRS.PicResponEntry" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PicResponEntry</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- #include file="../include/cek_all.html" -->
		<!-- #include file="../include/popup.html" --><LINK href="../style.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function keluar()
		{
			if (confirm("Are you sure want to finish ?"))
				document.Fmain.submit();
		}
		
			
		</script>
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder">
							<TABLE id="Table8">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>PIC RESPON ENTRY</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</TR>
					<tr>
						<td align="center"><asp:placeholder id="Placeholder1" runat="server"></asp:placeholder><asp:label id="HTH_PICTRACK" runat="server" Visible="False"></asp:label><asp:label id="TXT_SEND_TO" runat="server" Visible="False"></asp:label><asp:label id="TXT_SEND_BY" runat="server" Visible="False"></asp:label></td>
					</tr>
					<tr>
						<!--../dataentry/custproduct.aspx?regno=<%=Request.QueryString["regno"]%>&curef=<%=Request.QueryString["curef"]%>&sta=view-->
						<td colSpan="2" align="center"><iframe id="if2" name="if2" src="" width="100%" scrolling="auto" height="100"></iframe>
						</td>
					</tr>
					<TR>
						<TD class="tdHeader1" colSpan="2">END USER INFO</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Area/Group</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_AREA" runat="server" BorderStyle="None" ReadOnly="True" Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Unit</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_UNIT" runat="server" BorderStyle="None" ReadOnly="True" Width="300px"></asp:textbox></TD>
								</TR>
							</TABLE>
							<asp:label id="LBL_r" runat="server" Visible="False"></asp:label><asp:label id="LBL_REKANANTYPEID" runat="server" Visible="False"></asp:label><asp:label id="LBL_AP_PROG_CODE" runat="server" Visible="False"></asp:label></TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1">HRS#</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_HRS" runat="server" ReadOnly="True" Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="150">Tanggal Entry</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_TGL" runat="server" ReadOnly="True" Width="300px"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<tr>
						<td></td>
					</tr>
					<TR>
						<TD class="tdHeader1" colSpan="2">SEND MESSAGE</TD>
					</TR>
					<tr align="center">
						<td vAlign="top" width="100%" colSpan="2">
							<table id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="left" border="1">
								<TR>
									<TD align="center" width="15%" bgColor="#b5c7e7"><STRONG>APPLICATION</STRONG></TD>
									<TD align="center" width="17%" bgColor="#b5c7e7"><STRONG>CUSTOMER NAME</STRONG></TD>
									<TD align="center" width="18%" bgColor="#b5c7e7"><STRONG>PROBLEM TYPE</STRONG></TD>
									<TD align="center" width="50%" bgColor="#b5c7e7"><STRONG>DESCRIPTION</STRONG></TD>
								</TR>
								<tr>
									<td align="center" width="15%" valign="top"><asp:textbox id="TXT_NO_AP" ReadOnly="True" Width="100%" Runat="server" CssClass="Mandatory"></asp:textbox></td>
									<td align="center" width="17%" valign="top"><asp:textbox id="TXT_CUST" ReadOnly="True" Width="100%" Runat="server" CssClass="Mandatory"></asp:textbox></td>
									<td align="center" width="18%" valign="top"><asp:dropdownlist id="DDL_PROBLEM" Width="100%" Runat="server" CssClass="Mandatory" Enabled="False"></asp:dropdownlist></td>
									<td align="center" width="50%" valign="top"><asp:textbox id="TXT_DESC" ReadOnly="True" Width="100%" Runat="server" TextMode="MultiLine" Height="150px"
											MaxLength="100000" CssClass="Mandatory"></asp:textbox></td>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<td vAlign="top" width="100%" colSpan="2">
							<table id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="left" border="1">
								<TR>
									<TD align="center" width="25%" bgColor="#b5c7e7"><STRONG>Email</STRONG></TD>
									<TD align="center" width="25%" bgColor="#b5c7e7"><STRONG>No. Telp/HP</STRONG></TD>
								</TR>
								<tr>
									<td align="center" width="25%"><asp:textbox id="TXT_EMAIL" Width="100%" Height="30px" Runat="server" MaxLength="500" ReadOnly="True"></asp:textbox></td>
									<td align="center" width="25%"><asp:textbox id="TXT_TELP" Width="100%" Runat="server" Height="30px" MaxLength="500" ReadOnly="True"></asp:textbox></td>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<TD vAlign="top" width="50%" colSpan="2">
							<table cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD><ASP:DATAGRID id="DATA_EXPORT" runat="server" Width="100%" PageSize="5" CellPadding="1" AutoGenerateColumns="False"
											AllowPaging="True">
											<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
											<Columns>
												<asp:BoundColumn Visible="False" DataField="ID_UPLOAD_HELPDESK" HeaderText="No">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle Width="10px"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="FILE_UPLOAD_HELPDESK_NAME" HeaderText="Destination File">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												</asp:BoundColumn>
												<asp:TemplateColumn>
													<HeaderStyle Width="50%" CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
													<ItemTemplate>
														<asp:HyperLink id="UPL_HELPDESK_DOWNLOAD" runat="server" Target="_blank">Download</asp:HyperLink>
													</ItemTemplate>
												</asp:TemplateColumn>
											</Columns>
											<PagerStyle Mode="NumericPages"></PagerStyle>
										</ASP:DATAGRID></TD>
								</TR>
							</table>
						</TD>
					</tr>
					<tr>
						<td></td>
					</tr>
					<TR>
						<TD class="tdHeader1" colSpan="2">RESPON</TD>
					</TR>
					<tr align="center">
						<td vAlign="top" width="50%">
							<table id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="left" border="1">
								<TR>
									<TD align="center" width="30%" bgColor="#b5c7e7"><STRONG>DESCRIPTION</STRONG></TD>
								</TR>
								<tr>
									<td align="center" width="30%"><asp:textbox id="TXT_RESPON" Width="100%" Runat="server" CssClass="Mandatory" TextMode="MultiLine"
											Height="150px" MaxLength="8000"></asp:textbox></td>
								</tr>
							</table>
						</td>
						<TD vAlign="top" width="50%" rowSpan="2">
							<table cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD><ASP:DATAGRID id="DATA_EXPORT_RESPON" runat="server" Width="100%" PageSize="5" CellPadding="1"
											AutoGenerateColumns="False" AllowPaging="True">
											<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
											<Columns>
												<asp:BoundColumn Visible="False" HeaderText="No" DataField="ID_UPLOAD_HELPDESK_RESPON">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle Width="10px"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="FILE_UPLOAD_HELPDESK_NAME_RESPON" HeaderText="Destination File">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												</asp:BoundColumn>
												<asp:TemplateColumn>
													<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
													<ItemTemplate>
														<asp:HyperLink id="UPL_HELPDESK_DOWNLOAD2" runat="server" Target="_blank">Download</asp:HyperLink>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn>
													<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
													<ItemTemplate>
														<asp:LinkButton id="UPL_HELPDESK_DELETE2" runat="server" CommandName="delete">Delete</asp:LinkButton>
													</ItemTemplate>
												</asp:TemplateColumn>
											</Columns>
											<PagerStyle Mode="NumericPages"></PagerStyle>
										</ASP:DATAGRID></TD>
								</TR>
							</table>
						</TD>
					</tr>
					<tr>
						<td></td>
					</tr>
					<TR>
						<TD class="tdHeader1" colSpan="2">FILE EXPORT</TD>
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
									<TD class="TDBGColorValue"><asp:label id="LBL_STATUS" runat="server" ForeColor="Red"></asp:label><asp:regularexpressionvalidator id="Regularexpressionvalidator1" runat="server" ErrorMessage="Only xls, doc, txt, pdf, docx, xlsx or zip files are allowed!"
											ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.xls|.XLS|.doc|.DOC|.txt|.TXT|.zip|.ZIP|.pdf|.PDF|.docx|DOCX|.xlsx|.XLSX|)$" ControlToValidate="TXT_FILE_UPLOAD"></asp:regularexpressionvalidator></TD>
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
									<TD align="center" colSpan="3"><asp:button id="UPLOAD" runat="server" Text="Upload" onclick="UPLOAD_Click"></asp:button></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="3"></TD>
								</TR>
								<tr id="TR_SND" runat="server">
									<TD class="TDBGColor1" width="75">Send To</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class='A"TDBGColorValue"' style="HEIGHT: 10px"><asp:dropdownlist id="DDL_PIC" Width="200px" Runat="server" CssClass="Mandatory" Height="27px"></asp:dropdownlist><asp:button id="Button1" Runat="server" CssClass="button1" Text="SEND"></asp:button></TD>
								</tr>
								<TR>
									<TD align="left" colSpan="3"><FONT color="#0000ff">Note : disarankan utk mempercepat 
											proses tidak meng-klik tulisan download, tp di klik kanan saja dari tulisan 
											download tersebut, kemudian pilih "save target as"...simpan di lokal komputer</FONT></TD>
								</TR>
							</table>
						</TD>
					</tr>
					<tr align="center">
						<td class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2"><asp:button id="BTN_SAVE" runat="server" CssClass="Button1" Text="SAVE" onclick="BTN_SAVE_Click"></asp:button>&nbsp;&nbsp;&nbsp;
							<asp:button id="BTN_ACQ" runat="server" Width="121px" CssClass="Button1" Text="ACQUIRE INFO" onclick="BTN_ACQ_Click"></asp:button><asp:textbox id="TXT_TEMP" runat="server" BorderStyle="None" ReadOnly="True" Width="1px"></asp:textbox>&nbsp;&nbsp;
							<asp:button id="BTN_UPDATE" runat="server" Width="129px" CssClass="Button1" Text="UPDATE STATUS" onclick="BTN_UPDATE_Click"></asp:button></td>
					</tr>
					<TR id="TR_ACQ" runat="server">
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:hyperlink id="HL_ACCOUNT" runat="server" ForeColor="Blue" Visible="False">Acquire Info</asp:hyperlink></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
