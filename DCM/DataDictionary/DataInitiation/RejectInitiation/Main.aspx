<%@ Page language="c#" Codebehind="Main.aspx.cs" AutoEventWireup="false" Inherits="SME.DCM.Data_Dictionary.DataInitiation.RejectInitiation.Main" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>GeneralInformationIn</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../../style.css" type="text/css" rel="stylesheet">
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
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>GENERAL INFORMATION</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="../../../../image/Back.jpg"></asp:imagebutton><A href="../../../Body.aspx"><IMG height="25" src="../../../../Image/MainMenu.jpg" width="106"></A>
							<A href="../../../../Logout.aspx" target="_top"><IMG src="../../../../Image/Logout.jpg"></A>
						</TD>
					</TR>
					<tr>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</tr>
					<TR>
						<TD class="tdHeader1" colSpan="2">REQUEST DATA</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Request #</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_AREA" runat="server" BorderStyle="None" ReadOnly="True" Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Request Purpose</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class='A"TDBGColorValue"' style="HEIGHT: 10px"><asp:dropdownlist CssClass="Mandatory" id="DDL_PURPOSE" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
							<asp:label id="LBL_r" runat="server" Visible="False"></asp:label><asp:label id="LBL_REKANANTYPEID" runat="server" Visible="False"></asp:label><asp:label id="LBL_AP_PROG_CODE" runat="server" Visible="False"></asp:label></TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1">Request Date</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CODE" runat="server" ReadOnly="True" Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="150">Remark*</TD>
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
						<TD class="tdHeader1" colSpan="2">Request Criteria</TD>
					</TR>
					<TR>
						<TD><ASP:DATAGRID id="Datagrid1" runat="server" Width="100%" PageSize="5" CellPadding="1" AutoGenerateColumns="False"
								AllowPaging="True">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="ID_UPLOAD_HELPDESK" HeaderText="No">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle Width="10px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="FILE_UPLOAD_HELPDESK_NAME" HeaderText="Description">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn>
										<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="Linkbutton1" runat="server" CommandName="delete">Delete</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
					<TR>
						<TD align="center" width="50%" bgColor="#b5c7e7" colspan="2"><STRONG>Description</STRONG></TD>
					</TR>
					<tr>
						<td align="center" width="50%" valign="top" colspan="2"><asp:textbox id="DESC_TXT" Width="100%" Runat="server" TextMode="MultiLine" Height="75px" MaxLength="8000"
								CssClass="Mandatory"></asp:textbox></td>
					</tr>
					<TR>
						<TD align="center" colspan="2"><asp:button id="Button1" runat="server" Text="INSERT"></asp:button></TD>
					</TR>
					<tr>
						<td></td>
					</tr>
					<TR id="TR_EX_JUDUL" runat="server">
						<TD class="tdHeader1" colSpan="2">File Upload</TD>
					</TR>
					<tr id="TR_EX_CONTENT" runat="server">
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
									<TD align="center" colSpan="3"><asp:button id="UPLOAD" runat="server" Text="Upload"></asp:button></TD>
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
													<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
													<ItemTemplate>
														<asp:HyperLink id="UPL_HELPDESK_DOWNLOAD" runat="server" Target="_blank">Download</asp:HyperLink>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn>
													<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
													<ItemTemplate>
														<asp:LinkButton id="UPL_HELPDESK_DELETE" runat="server" CommandName="delete">Delete</asp:LinkButton>
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
					<tr align="center">
						<td class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2">
							<asp:button id="BTN_SAVE" runat="server" Width="61px" CssClass="Button1" Text="SAVE"></asp:button>&nbsp;
							<asp:button id="BTN_SEND" Runat="server" CssClass="button1" Text="UPDATE STATUS" Width="129px"></asp:button>&nbsp;
							<asp:button id="Button2" Width="70px" CssClass="button1" Runat="server" Text="FINISH"></asp:button>
						</td>
					</tr>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
