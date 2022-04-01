<%@ Page language="c#" Codebehind="UnitSurvey.aspx.cs" AutoEventWireup="True" Inherits="SME.MAS.SupervisionManagement.BusinessRecoverySupervision.UnitSurvey.UnitSurvey" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>UnitSurvey</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../../Style.css" type="text/css" rel="stylesheet">
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
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>UNIT SURVEY</B></TD>
								</TR>
							</TABLE>
						</TD>
						<td align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg"></asp:imagebutton><A href="../../../../Body.aspx"><IMG src="../../../../Image/MainMenu.jpg"></A><A href="../../../../Logout.aspx" target="_top"><IMG src="../../../../Image/Logout.jpg"></A></td>
					</TR>
					<tr>
						<td></td>
					</tr>
					<TR>
						<TD colSpan="2"><ASP:DATAGRID id="DatGrd" runat="server" AutoGenerateColumns="False" CellPadding="1" AllowPaging="True"
								Width="100%">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="seq" HeaderText="No." Visible="False">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="jenis_survey" HeaderText="Jenis Survey">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="nama_responden" HeaderText="Nama Responden">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="unit_code" HeaderText="Unit">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="phone#" HeaderText="No.Telp/HP">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="ask1" HeaderText="Pertanyaan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="answer1" HeaderText="Jawaban">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Function">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="edit_data" runat="server" CommandName="edit_data">Edit</asp:LinkButton>&nbsp;
											<asp:LinkButton id="delete_data" runat="server" CommandName="delete_data">Delete</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">INFO RESPONDEN</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table4" cellSpacing="1" cellPadding="2" width="100%">
								<TR>
									<TD class="TDBGColor1">Jenis Survey :</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_JNS_SURVEY" runat="server" Width="300px"
											MaxLength="100"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nama Responden :</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_NM_RESPONDEN" runat="server" Width="300px"
											MaxLength="100"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"></TD>
									<TD class="TDBGColor1"></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Pertanyaan 1 :</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_ASK1" runat="server" Width="300px" MaxLength="100"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Pertanyaan 2 :</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_ASK2" runat="server" Width="300px" MaxLength="100"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Pertanyaan 3 :</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_ASK3" runat="server" Width="300px" MaxLength="100"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Pertanyaan 4 :</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_ASK4" runat="server" Width="300px" MaxLength="100"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Pertanyaan 5 :</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_ASK5" runat="server" Width="300px" MaxLength="100"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Pertanyaan 6 :</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_ASK6" runat="server" Width="300px" MaxLength="100"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Pertanyaan 7 :</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_ASK7" runat="server" Width="300px" MaxLength="100"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Pertanyaan 8 :</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_ASK8" runat="server" Width="300px" MaxLength="100"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table65" cellSpacing="1" cellPadding="2" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 141px">Unit</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:dropdownlist id="DDL_UNIT" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">No Telepon/HP :</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_TELEPON" runat="server" Width="300px" MaxLength="100"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"></TD>
									<TD class="TDBGColor1"></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jawaban 1 :</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_JWB1" runat="server" Width="300px" MaxLength="100"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jawaban 2 :</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_JWB2" runat="server" Width="300px" MaxLength="100"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jawaban 3 :</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_JWB3" runat="server" Width="300px" MaxLength="100"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jawaban 4 :</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_JWB4" runat="server" Width="300px" MaxLength="100"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jawaban 5 :</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_JWB5" runat="server" Width="300px" MaxLength="100"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jawaban 6 :</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_JWB6" runat="server" Width="300px" MaxLength="100"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jawaban 7 :</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_JWB7" runat="server" Width="300px" MaxLength="100"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jawaban 8 :</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_JWB8" runat="server" Width="300px" MaxLength="100"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<tr>
						<td></td>
					</tr>
					<tr align="center">
						<td class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2"><asp:button id="BTN_INSERT" runat="server" Width="75px" CssClass="Button1" Text="INSERT" onclick="BTN_INSERT_Click"></asp:button>&nbsp;&nbsp;
							<asp:button id="BTN_CLEAR" runat="server" Width="75px" CssClass="Button1" Text="CLEAR" onclick="BTN_CLEAR_Click"></asp:button></td>
					</tr>
					<tr>
						<td><asp:label id="TXT_SEQ" Runat="server" Visible="False"></asp:label></td>
					</tr>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
