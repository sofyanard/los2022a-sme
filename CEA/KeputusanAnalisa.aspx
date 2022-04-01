<%@ Page language="c#" Codebehind="KeputusanAnalisa.aspx.cs" AutoEventWireup="True" Inherits="SME.CEA.KeputusanAnalisa" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>KeputusanAnalisa</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../Style.css">
		<!-- #include file="../include/cek_entries.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table4" border="0" width="100%">
				<TR>
					<TD align="left">
						<TABLE id="Table3">
							<TR>
								<TD style="WIDTH: 400px" class="tdBGColor2" align="center"><B>Keputusan&nbsp;- Main</B></TD>
							</TR>
						</TABLE>
					</TD>
					<td align="right"><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></td>
				</TR>
				<TR>
					<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:hyperlink id="HL_MAIN" runat="server" Visible="False" NavigateUrl="Main.aspx">Main</asp:hyperlink><asp:hyperlink id="HL_KUALITATIF" runat="server" Visible="False" NavigateUrl="AnalisaKualitatifKuantitatif.aspx">Inisiasi</asp:hyperlink><asp:hyperlink id="HL_SANKSI" runat="server" Visible="False" NavigateUrl="AnalisaSanksi.aspx">Verifikasi</asp:hyperlink><asp:hyperlink id="HL_Inisiasi" runat="server" Visible="False" NavigateUrl="TenagaAhli.aspx">Analisa</asp:hyperlink></TD>
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
								<TD class="TDBGColorValue"><asp:textbox id="TXT_NO_Reg" runat="server" BorderStyle="None" ReadOnly="True" Width="300px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Jenis Rekanan</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue"><asp:textbox id="TXT_JNS_REK" runat="server" BorderStyle="None" ReadOnly="True" Width="300px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Nama Rekanan</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue"><asp:textbox id="TXT_NAMA_REK" runat="server" BorderStyle="None" ReadOnly="True" Width="300px"></asp:textbox></TD>
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
								<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_NoTelp" runat="server" ReadOnly="True" Width="300px"></asp:textbox></TD>
							</TR>
							<!--<TR>
										<TD class="TDBGColor1">Nama Analis</TD>
										<TD>:</TD>
										<TD class="TDBGColorValue"><asp:textbox id="Textbox2" runat="server" Width="175px" ReadOnly="True"></asp:textbox></TD>
									</TR>--></TABLE>
					</TD>
				</TR>
				<tr>
				</tr>
				<TR>
					<TD class="tdHeader1" colSpan="2">Document Upload</TD>
				</TR>
			</TABLE>
			<TABLE id="Table1" class="td" border="1" cellSpacing="1" cellPadding="1" width="90%" height="35">
				<tr>
					<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
					<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
					<td>
						<table cellSpacing="0" cellPadding="0" width="472" style="WIDTH: 472px; HEIGHT: 106px">
							<TR>
								<TD class="TDBGColor1" width="75">File</TD>
								<TD style="WIDTH: 15px">:</TD>
								<TD class="TDBGColorValue"><INPUT style="WIDTH: 344px; HEIGHT: 19px" id="File2" size="38" type="file" name="File1"
										runat="Server"></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Status</TD>
								<TD>:</TD>
								<TD class="TDBGColorValue"><asp:label id="Label3" runat="server" ForeColor="Red"></asp:label><asp:regularexpressionvalidator id="Regularexpressionvalidator1" runat="server" ControlToValidate="TXT_FILE_UPLOAD"
										ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.xls|.XLS|.doc|.DOC|.txt|.TXT|.zip|.ZIP)$" ErrorMessage="Only xls, doc, txt or zip files are allowed!"></asp:regularexpressionvalidator></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1"></TD>
								<TD></TD>
								<TD class="TDBGColorValue"><asp:label id="Label4" runat="server" ForeColor="Red"></asp:label></TD>
							</TR>
							<TR>
								<TD style="COLOR: #3333ff; HEIGHT: 21px" colSpan="3" align="center"><asp:button id="Button2" runat="server" Text="Upload"></asp:button></TD>
							</TR>
							<TR>
								<TD colSpan="3" align="left">
									<P style="COLOR: #0000ff">Note: disarankan utk mempercepat proses tidak meng-klik 
										tulisan download, tapi diklik kanan saja dari tulisan download tersebut, 
										kemudian pilih "save target as".... simpan di lokal komputer</P>
								</TD>
							</TR>
						</table>
					</td>
					<TD align="center"><ASP:DATAGRID id="DATA_EXPORT" runat="server" Width="473px" AutoGenerateColumns="False" CellPadding="1"
							PageSize="1">
							<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
							<Columns>
								<asp:BoundColumn Visible="True" DataField="ID_UPLOAD_RORAC" HeaderText="No" ItemStyle-Width="10px">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="FILE_UPLOAD_RORAC_NAME" HeaderText="Destination File">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn>
									<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
									<ItemTemplate>
										<asp:LinkButton ID="Download_File" Runat="server" CommandName="download">Download</asp:LinkButton>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn>
									<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:LinkButton id="UPL_RORAC_DELETE" runat="server" CommandName="delete">Delete</asp:LinkButton>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
						</ASP:DATAGRID></TD>
				</tr>
				<tr>
					<td></td>
				</tr>
				<TR>
					<TD class="tdHeader1" colSpan="2">Sanksi &amp; Score</TD>
				</TR>
				<TR>
					<TD class="td" vAlign="top" width="50%">
						<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 129px">Sanksi</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue"><asp:textbox id="Textbox1" runat="server" BorderStyle="None" ReadOnly="True" Width="300px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Score Kualitatif</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue"><asp:textbox id="Textbox2" runat="server" BorderStyle="None" ReadOnly="True" Width="300px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Score Kuantitatif</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue"><asp:textbox id="Textbox3" runat="server" BorderStyle="None" ReadOnly="True" Width="300px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Score Wawancara</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue"><asp:textbox id="Textbox4" runat="server" BorderStyle="None" ReadOnly="True" Width="300px"></asp:textbox></TD>
							</TR>
						</TABLE>
						<asp:label id="Label1" runat="server" Visible="False"></asp:label><asp:label id="Label2" runat="server" Visible="False"></asp:label></TD>
					<TD class="td" vAlign="top" width="50%">
					</TD>
				</TR>
				<tr>
				</tr>
				<tr>
				</tr>
				<TR>
					<TD class="tdHeader1" colSpan="2">Approval Committee Akreditasi</TD>
				</TR>
			</TABLE>
			<!--
			<table cellSpacing="0" cellPadding="0" width="50%">
				<TR>
					<TD class="TDBGColor1" width="75">File</TD>
					<TD style="WIDTH: 15px">:</TD>
					<TD class="TDBGColorValue"><INPUT style="WIDTH: 344px; HEIGHT: 19px" id="TXT_FILE_UPLOAD" size="38" type="file" name="File1"
							runat="Server"></TD>
				</TR>
				<TR>
					<TD class="TDBGColor1">Status</TD>
					<TD>:</TD>
					<TD class="TDBGColorValue"><asp:label id="LBL_STATUS" runat="server" ForeColor="Red"></asp:label><asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" ControlToValidate="TXT_FILE_UPLOAD"
							ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.xls|.XLS|.doc|.DOC|.txt|.TXT|.zip|.ZIP)$" ErrorMessage="Only xls, doc, txt or zip files are allowed!"></asp:regularexpressionvalidator></TD>
				</TR>
				<TR>
					<TD class="TDBGColor1"></TD>
					<TD></TD>
					<TD class="TDBGColorValue"><asp:label id="LBL_STATUSREPORT" runat="server" ForeColor="Red"></asp:label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 21px" colSpan="3" align="center"><asp:button id="BTN_UPLOAD" runat="server" Text="Upload"></asp:button></TD>
				</TR>
				<TR>
					<TD colSpan="3" align="center"></TD>
				</TR>
			</table>
			<br>
			<center>
				<table class="td" border="1" cellSpacing="1" cellPadding="1" width="60%" height="35">
					<TR>
						<TD class="tdHeader1" colSpan="7" height="35">Uploaded Data</TD>
					</TR>
					<TR>
						<TD colSpan="2">
							<ASP:DATAGRID id="DatGrd" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False"
								CellPadding="1"></ASP:DATAGRID>
						</TD>
					</TR>
				</table>
			</center>
			-->
			<table id="Table3" cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<td align="center">
						<asp:Button ID="BTN_UPDATE" Text="Update Status" Runat="server" CssClass="button1"></asp:Button>
					</td>
				</tr>
				<tr>
					<td align="center"><asp:placeholder id="PlaceHolder1" runat="server"></asp:placeholder><asp:label id="lbl_regno" runat="server" Visible="False"></asp:label><asp:label id="lbl_curef" runat="server" Visible="False"></asp:label></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
