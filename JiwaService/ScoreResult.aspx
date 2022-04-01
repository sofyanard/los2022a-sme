<%@ Page language="c#" Codebehind="ScoreResult.aspx.cs" AutoEventWireup="True" Inherits="SME.JiwaService.ScoreResult" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>SCORING RESULT</TITLE>
		<META content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<CENTER>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder">
							<TABLE id="Table2">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>SCORING RESULT</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/image/Back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="/SME/Body.aspx"><IMG src="/SME/Image/MainMenu.jpg"></A><A href="/SME/Logout.aspx" target="_top"><IMG src="/SME/Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" colSpan="2"></TD>
					</TR>
					<TR>
						<TD vAlign="top" width="50%">
							<TABLE cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<td><asp:datagrid id="DATA_TEMPLATE" runat="server" Width="100%" AutoGenerateColumns="False" PageSize="1"
											CellPadding="1">
											<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
											<Columns>
												<asp:BoundColumn DataField="ID_TEMPLATE_JIWASERVICE" Visible="False">
													<HeaderStyle HorizontalAlign="Center" Width="10%" CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="NAMA_TEMPLATE_JIWASERVICE" HeaderText="SOURCE FILE">
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
											</Columns>
										</asp:datagrid></td>
								</TR>
							</TABLE>
						</TD>
						<TD vAlign="top" width="50%">
							<TABLE cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD><ASP:DATAGRID id="DATA_EXPORT" runat="server" Width="100%" AutoGenerateColumns="False" PageSize="5"
											CellPadding="1" AllowPaging="True">
											<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
											<Columns>
												<asp:BoundColumn DataField="ID_UPLOAD_EXP" HeaderText="No">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle Width="10px" HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="FILE_UPLOAD_EXP_NAME" HeaderText="DESTINATION FILE">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												</asp:BoundColumn>
												<asp:TemplateColumn>
													<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
													<ItemTemplate>
														<asp:HyperLink id="SCORING_DOWNLOAD" runat="server" Target="_blank">Download</asp:HyperLink>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn>
													<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
													<ItemTemplate>
														<asp:LinkButton id="SCORING_DELETE" runat="server" CommandName="delete">Delete</asp:LinkButton>
													</ItemTemplate>
												</asp:TemplateColumn>
											</Columns>
											<PagerStyle Mode="NumericPages"></PagerStyle>
										</ASP:DATAGRID></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD vAlign="top" align="center" width="50%" colSpan="2"><asp:label id="TXT_XLSNAME" Runat="server" Visible="False"></asp:label></TD>
					</TR>
					<TR>
						<TD vAlign="top" width="50%">
							<table cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="30%">File :</TD>
									<TD class="TDBGColorValue" width="50%"><INPUT id="TXT_FILE_UPLOAD" style="WIDTH: 100%; HEIGHT: 19px" type="file" size="38" name="File1"
											runat="Server"></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="30%">Status :</TD>
									<TD class="TDBGColorValue" width="50%"><asp:label id="LBL_STATUS" runat="server" ForeColor="Red"></asp:label><asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" ControlToValidate="TXT_FILE_UPLOAD"
											ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.xls|.XLS)$" ErrorMessage="Hanya file xls yang diperbolehkan!"></asp:regularexpressionvalidator></TD>
								</TR>
								<TR>
									<TD></TD>
									<TD class="TDBGColorValue" width="50%"><asp:label id="LBL_STATUSREPORT" runat="server" ForeColor="Red"></asp:label></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 21px" align="center" colSpan="2"><asp:button id="BTN_UPLOAD" runat="server" Text="Upload" Font-Bold="True" Width="80px" onclick="BTN_UPLOAD_Click"></asp:button></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="2"></TD>
								</TR>
							</table>
						</TD>
					<TR>
						<TD style="COLOR: dodgerblue">Note : disarankan untuk mempercepat proses tidak 
							meng-klik tulisan download, tapi di klik kanan saja dari tulisan download 
							tersebut, kemudian pilih "save" target as"...simpan di lokal komputer
						</TD>
					</TR>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="7" height="35">RESULT UPLOAD</TD>
					</TR>
					<TR>
						<TD colSpan="2"><ASP:DATAGRID id="DatGrd" runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="1"
								AllowPaging="True">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="SEQ_PERTANYAAN" HeaderText="No">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AKTIVITAS" HeaderText="Aktivitas">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PERTANYAAN" HeaderText="Langkah-langkah">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="SCORE" HeaderText="Score">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
					<TR>
						<TD></TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%">Total Score :</TD>
									<TD class="TDBGColorValue" width="50%"><asp:textbox onkeypress="return kutip_satu()" id="TXT_SCORE" runat="server" Width="100%" ForeColor="#ff0000"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%">Category :</TD>
									<TD class="TDBGColorValue" width="50%"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CATEGORY" runat="server" Width="100%" ForeColor="#ff0000"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TABLE>
			</CENTER>
		</FORM>
	</BODY>
</HTML>
