<%@ Page language="c#" Codebehind="DataRekanan.aspx.cs" AutoEventWireup="True" Inherits="SME.CEA.DataRekanan" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>DataRekanan</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_entries.html" -->
  </HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table4" width="100%" border="0">
				<TR>
					<TD align="left">
						<TABLE id="Table31">
							<TR>
								<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Data Rekanan</B></TD>
							</TR>
						</TABLE>
					</TD>
					<TD class="tdNoBorder" align="right"><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
				</TR>
				<TR>
					<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="MenuKeputusanMain" runat="server"></asp:placeholder></TD>
				</TR>
				<TR>
					<TD class="tdHeader1" colSpan="2">Info Rekanan</TD>
				</TR>
				<TR>
					<TD class="td" vAlign="top" width="50%">
						<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 129px">No. Registrasi</TD>
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
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
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
								<TD class="TDBGColor1">File</TD>
								<TD style="WIDTH: 15px">:</TD>
								<TD class="TDBGColorValue"><INPUT id="TXT_FILE_UPLOAD" type="file" size="30" name="File1" runat="Server"></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Status</TD>
								<TD>:</TD>
								<TD class="TDBGColorValue"><asp:label id="LBL_STATUS" runat="server" ForeColor="Red"></asp:label><asp:regularexpressionvalidator id="Regularexpressionvalidator2" runat="server" ControlToValidate="TXT_FILE_UPLOAD"
										ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.xls|.XLS|.doc|.DOC|.txt|.TXT|.zip|.ZIP)$" ErrorMessage="Only xls, doc, txt or zip files are allowed!"></asp:regularexpressionvalidator></TD>
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
								<TD><ASP:DATAGRID id="DATA_EXPORT" runat="server" Width="100%" PageSize="5" CellPadding="1" AutoGenerateColumns="False" AllowPaging="True">
<AlternatingItemStyle CssClass="TblAlternating">
</AlternatingItemStyle>

<Columns>
<asp:BoundColumn Visible="False" DataField="ID_UPLOAD_XLS" HeaderText="No">
<HeaderStyle CssClass="tdSmallHeader">
</HeaderStyle>

<ItemStyle Width="10px">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="FILE_UPLOAD_XLS_NAME" HeaderText="Destination File">
<HeaderStyle CssClass="tdSmallHeader">
</HeaderStyle>
</asp:BoundColumn>
<asp:TemplateColumn>
<HeaderStyle Width="45px" CssClass="tdSmallHeader">
</HeaderStyle>

<ItemStyle HorizontalAlign="Center" Width="60px">
</ItemStyle>

<ItemTemplate>
													<asp:HyperLink id="XLS_DOWNLOAD" runat="server" Target="_blank">Download</asp:HyperLink>
												
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn>
<HeaderStyle Width="45px" CssClass="tdSmallHeader">
</HeaderStyle>

<ItemStyle HorizontalAlign="Center">
</ItemStyle>

<ItemTemplate>
													<asp:LinkButton id="XLS_DELETE" runat="server" CommandName="delete">Delete</asp:LinkButton>
												
</ItemTemplate>
</asp:TemplateColumn>
</Columns>

<PagerStyle Mode="NumericPages">
</PagerStyle>
									</ASP:DATAGRID></TD>
							</TR>
						</table>
					</TD>
				</tr>
			</TABLE>
		</form>
	</body>
</HTML>
