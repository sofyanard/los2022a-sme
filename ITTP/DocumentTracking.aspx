<%@ Page language="c#" Codebehind="DocumentTracking.aspx.cs" AutoEventWireup="True" Inherits="SME.ITTP.DocumentTracking" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DocumentTracking</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Style.css" type="text/css" rel="stylesheet">
		<!-- #include  file="../include/cek_mandatoryOnly.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table4" width="100%" border="0">
				<TR>
					<TD align="left" colSpan="1">
						<TABLE id="Table3">
							<TR>
								<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Document Tracking</B></TD>
							</TR>
						</TABLE>
					</TD>
					<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
				</TR>
				<TR>
					<TD class="tdNoBorder" align="center" colSpan="2" height="41"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
				</TR>
				<tr>
					<td class="tdHeader1" colSpan="2">Info Pemohon</td>
				</tr>
				<tr>
					<td align="center" colSpan="2"><iframe id=if1 
      style="WIDTH: 100%; HEIGHT: 185px" name=if1 
      src="/SME/ITTP/appinfo.aspx?regno=<%=Request.QueryString["regno"]%>&amp;curef=<%=Request.QueryString["curef"]%>&amp;sta=view" 
      scrolling=no> </iframe>
					</td>
				</tr>
				<tr>
					<td colSpan="2">
						<TABLE cellSpacing="2" cellPadding="2" width="100%">
						</TABLE>
					</td>
				</tr>
				<tr>
					<td class="tdHeader1" colSpan="2">Pending Document to be Received
						<asp:label id="TXT_AP_REGNO" Visible="False" Runat="server"></asp:label><asp:label id="TXT_CU_REF" Visible="False" Runat="server"></asp:label></td>
				</tr>
				<TR>
					<TD colSpan="2"><ASP:DATAGRID id="DatGrdRecv" runat="server" CellPadding="1" PageSize="1" AutoGenerateColumns="False"
							Width="100%">
							<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="SEQ" HeaderText="No">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" Width="40px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="DOCTYPEDESC" HeaderText="Jenis ">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="DOCDESC" HeaderText="Deskripsi">
									<HeaderStyle CssClass="tdSmallHeader" Width="30%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="AT_KETERANGAN" HeaderText="Keterangan">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn Visible="False" HeaderText="Available">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
									<ItemTemplate>
										<asp:Image id="IMG_AT_FIX" runat="server"></asp:Image>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn Visible="False" DataField="AT_FIX"></asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Original">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
									<ItemTemplate>
										<asp:Image id="IMG_ORIGINAL" runat="server"></asp:Image>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn Visible="False" DataField="ORIGINAL"></asp:BoundColumn>
								<asp:BoundColumn DataField="SENDERNAME" HeaderText="Sent By">
									<HeaderStyle CssClass="tdSmallHeader" Width="15%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="DTP_DESC" HeaderText="Send Purpose">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NOTES" HeaderText="Notes">
									<HeaderStyle CssClass="tdSmallHeader" Width="20%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Receive">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:CheckBox id="CHK_RECEIVE" runat="server"></asp:CheckBox>
										<asp:Image id="IMG_RECEIVE" runat="server"></asp:Image>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn Visible="False" DataField="RECVBY"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="DOCTYPEID"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="SEQ"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="DOCID"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="PURPOSEID"></asp:BoundColumn>
							</Columns>
						</ASP:DATAGRID></TD>
				</TR>
				<TR>
					<TD class="TDBGColor2" align="center" colSpan="2"><asp:button id="BTN_RECEIVE" Runat="server" Text="CONFIRM RECEIVE" CssClass="button1" onclick="BTN_RECEIVE_Click"></asp:button></TD>
				</TR>
				<tr>
					<td class="tdHeader1" colSpan="2">New Document Item</td>
				</tr>
				<TR>
					<TD style="HEIGHT: 48px" colSpan="2">
						<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100%" border="1">
							<TR>
								<TD style="WIDTH: 200px" align="right">Item</TD>
								<TD>
									<P align="left"><asp:dropdownlist id="DDL_NEWITEM" runat="server" Width="489px"></asp:dropdownlist><asp:checkbox id="CHK_NEWITEM_ORIGINAL" runat="server" Text="Original"></asp:checkbox><asp:button id="BTN_INSERT" runat="server" Text="Insert" onclick="BTN_INSERT_Click"></asp:button></P>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD class="tdH" colSpan="2"></TD>
				</TR>
				<tr>
					<td class="tdHeader1" colSpan="2">Document in Possession</td>
				</tr>
				<TR>
					<TD colSpan="2"><ASP:DATAGRID id="DatGrdSend" runat="server" CellPadding="1" PageSize="1" AutoGenerateColumns="False"
							Width="100%">
							<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="SEQ" HeaderText="No">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" Width="40px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="DOCTYPEDESC" HeaderText="Jenis ">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="DOCDESC" HeaderText="Deskripsi">
									<HeaderStyle Width="30%" CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="AT_KETERANGAN" HeaderText="Keterangan">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn Visible="False" HeaderText="Available">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
									<ItemTemplate>
										<asp:Image id="IMG_AT_FIX_SEND" runat="server"></asp:Image>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn Visible="False" DataField="AT_FIX"></asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Original">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
									<ItemTemplate>
										<asp:CheckBox id="CHK_ORIGINAL" runat="server"></asp:CheckBox>
										<asp:Image id="IMG_ORIGINAL_SEND" runat="server"></asp:Image>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn Visible="False" DataField="ORIGINAL"></asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Sent To">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
									<ItemTemplate>
										<asp:Label id="LBL_SENDTO" runat="server"></asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Sent Purpose">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:Label id="LBL_DTP_DESC" runat="server"></asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Notes">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
									<ItemTemplate>
										<asp:TextBox id="TXT_NOTES" Width="100%" runat="server"></asp:TextBox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn Visible="False" DataField="NOTES"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="RECVBY"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="DOCTYPEID"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="SEQ"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="DOCID"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="PURPOSEID"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="SENDTO"></asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Send">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:CheckBox id="CHK_SEND" runat="server"></asp:CheckBox>
										<asp:Image id="IMG_SEND" runat="server"></asp:Image>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn Visible="False" DataField="SENDINGTONAME"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="DTP_DESC"></asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Function">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:LinkButton id="LNK_DELETE" runat="server" CommandName="delete">Delete</asp:LinkButton>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
						</ASP:DATAGRID></TD>
				</TR>
				<TR>
					<TD class="TDBGColor2" align="center" colSpan="2">
						<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD width="20%"></TD>
								<TD width="1%"></TD>
								<TD width="40%"><STRONG>Send To:</STRONG></TD>
								<TD width="5%"></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD align="right">Branch</TD>
								<TD align="center">:</TD>
								<TD><asp:dropdownlist id="DDL_SENDTOBRANCH" runat="server" CssClass="mandatory" AutoPostBack="True" onselectedindexchanged="DDL_SENDTOBRANCH_SelectedIndexChanged"></asp:dropdownlist></TD>
								<TD></TD>
								<TD rowSpan="3"><asp:button id="BTN_SEND" Runat="server" Text="CONFIRM SEND" CssClass="button1" Height="35px" onclick="BTN_SEND_Click"></asp:button></TD>
							</TR>
							<TR>
								<TD align="right">User</TD>
								<TD align="center">:</TD>
								<TD><asp:dropdownlist id="DDL_SENDTO" runat="server" CssClass="mandatory" onselectedindexchanged="DDL_SENDTO_SelectedIndexChanged"></asp:dropdownlist></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD align="right">Purpose</TD>
								<TD align="center">:</TD>
								<TD><asp:dropdownlist id="DDL_PURPOSEID" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
								<TD></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
