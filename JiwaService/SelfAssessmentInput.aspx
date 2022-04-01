<%@ Page language="c#" Codebehind="SelfAssessmentInput.aspx.cs" AutoEventWireup="True" Inherits="SME.JiwaService.SelfAssessmentInput" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>SELF ASSESSMENT</TITLE>
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
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>SELF ASSESSMENT</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="/SME/Body.aspx"><IMG src="/SME/Image/MainMenu.jpg"></A><A href="/SME/Logout.aspx" target="_top"><IMG src="/SME/Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" colSpan="2"></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" vAlign="top" width="50%" colSpan="2">PROVIDER INFORMATION</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%">Name :</TD>
									<TD class="TDBGColorValue" width="50%"><asp:textbox onkeypress="return kutip_satu()" id="TXT_NAME" runat="server" Width="100%" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%">Group Name :</TD>
									<TD class="TDBGColorValue" width="50%"><asp:textbox onkeypress="return kutip_satu()" id="TXT_GROUP" runat="server" Width="100%" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD>
										<asp:label id="TXT_GROUPID" runat="server" Visible="False"></asp:label>
										<asp:label id="TXT_ID" runat="server" Visible="False"></asp:label>
									</TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%">Information Date :</TD>
									<TD class="TDBGColorValue" width="50%"><asp:textbox onkeypress="return kutip_satu()" id="TXT_DATE" runat="server" Width="100%" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%">Department Name :</TD>
									<TD class='A"TDBGColorValue"' width="50%"><asp:dropdownlist id="DDL_DEPT_NAME" runat="server" CssClass="Mandatory" AutoPostBack="True" Width="100%" onselectedindexchanged="DDL_DEPT_NAME_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD vAlign="top" align="center" width="50%" colSpan="2"><asp:button id="BTN_INSERT" runat="server" Width="100px" Text="INSERT" Font-Bold="True" onclick="BTN_INSERT_Click"></asp:button></TD>
					</TR>
					<TR id="TR_QUESTION" runat="server">
						<TD colSpan="2"><ASP:DATAGRID id="DGR_SELF" runat="server" Width="100%" AllowPaging="True" CellPadding="1" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="SEQ"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="G_CODE"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="D_CODE"></asp:BoundColumn>
									<asp:BoundColumn DataField="LANGKAH_SEQ" HeaderText="No" Visible="False">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="ACTION" HeaderText="Action">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="UKURAN" HeaderText="Ukuran">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="LANGKAH_DESC" HeaderText="Langkah-Langkah">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="SERVICE_CODE" HeaderText="Jiwa Service">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Score">
										<HeaderStyle Width="10%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:radiobuttonlist id="RBL_SELF" runat="server" RepeatDirection="Horizontal"></asp:radiobuttonlist>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Bukti">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle Width="15%"></ItemStyle>
										<ItemTemplate>
											<asp:TextBox Width="100%" Runat="server" id="TXT_BUKTI"></asp:TextBox>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" width="50%" colSpan="2">
							<asp:button id="BTN_SAVE" runat="server" Width="80px" CssClass="Button1" Text="SAVE" onclick="BTN_SAVE_Click"></asp:button>&nbsp;&nbsp;
							<asp:button id="BTN_CLEAR" runat="server" Width="80px" CssClass="Button1" Text="CLEAR" onclick="BTN_CLEAR_Click"></asp:button>
						</TD>
					</TR>
					<TR>
						<TD>1 : Tidak Dilaksanakan 
							&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;4 
							: Dilaksanakan dan direview dengan bukti<br>
							2 : Dilaksanakan tanpa bukti &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;5 : Dilaksanakan, 
							direview, dan di-follow up dengan<br>
							3 : Dilaksanakan dengan bukti &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
							bukti dan 'ukuran' pencapaian tercapai
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%">Total Score :</TD>
									<TD class="TDBGColorValue" width="50%"><asp:textbox onkeypress="return kutip_satu()" id="TXT_SCORE" runat="server" Width="100%" ReadOnly="True"
											ForeColor="#ff0000"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%">Category :</TD>
									<TD class="TDBGColorValue" width="50%"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CATEGORY" runat="server" Width="100%" ReadOnly="True"
											ForeColor="#ff0000"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="tdHeader1" vAlign="top" width="50%" colSpan="2">REMARK</TD>
					</TR>
					<TR>
						<TD vAlign="top" align="center" colSpan="2"><asp:textbox id="TXT_REMARK" Width="100%" Runat="server" Height="70px" TextMode="MultiLine"></asp:textbox></TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" width="50%" colSpan="2">
							<asp:button id="BTN_SAVE_REMARK" runat="server" Width="80px" CssClass="Button1" Text="SAVE" onclick="BTN_SAVE_REMARK_Click"></asp:button>&nbsp;&nbsp;
							<asp:button id="BTN_CLEAR_REMARK" runat="server" Width="80px" CssClass="Button1" Text="CLEAR" onclick="BTN_CLEAR_REMARK_Click"></asp:button>
						</TD>
					</TR>
				</TABLE>
			</CENTER>
		</FORM>
	</BODY>
</HTML>
