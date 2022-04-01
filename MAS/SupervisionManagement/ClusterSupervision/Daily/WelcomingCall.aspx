<%@ Page language="c#" Codebehind="WelcomingCall.aspx.cs" AutoEventWireup="True" Inherits="SME.MAS.SupervisionManagement.ClusterSupervision.Daily.WelcomingCall" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>WelcomingCall</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../../Style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="form1" method="post" runat="server">
			<!-- <center> -->
			<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
				<TR>
					<TD class="tdNoBorder">
						<TABLE id="Table8">
							<TR>
								<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>WELCOMING CALL</B></TD>
							</TR>
						</TABLE>
					</TD>
					<td align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg"></asp:imagebutton><A href="../../../../Body.aspx"><IMG src="../../../../Image/MainMenu.jpg"></A><A href="../../../../Logout.aspx" target="_top"><IMG src="../../../../Image/Logout.jpg"></A></td>
				</TR>
				<tr>
					<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
				</tr>
				<TR id="TR_FIND" runat="server">
					<TD class="tdNoBorder" vAlign="top" width="50%">
						<TABLE id="Table20" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD class="TDBGColor1" width="129">Account Number :</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue" style="WIDTH: 208px"><asp:textbox id="TXT_ACC_NUM" runat="server" MaxLength="15" Width="200px"></asp:textbox></TD>
								<td><asp:button id="BTN_SEARCH_ACC_NUMBER" Runat="server" Text="Search" onclick="BTN_SEARCH_ACC_NUMBER_Click"></asp:button></td>
							</TR>
						</TABLE>
					</TD>
					<TD class="tdNoBorder" vAlign="top" width="50%">
						<TABLE id="Table20" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD class="TDBGColor1" width="129">Nama Debitur&nbsp;:</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue" style="WIDTH: 208px"><asp:textbox id="TXT_CUST" runat="server" MaxLength="15" Width="200px"></asp:textbox></TD>
								<td><asp:button id="BTN_SEARCH_CUST" Runat="server" Text="Search" onclick="BTN_SEARCH_CUST_Click"></asp:button></td>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD colSpan="2"><ASP:DATAGRID id="DatGrd" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False"
							CellPadding="1">
							<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
							<Columns>
								<asp:BoundColumn HeaderText="Account#" DataField="acc_number">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn HeaderText="Customer Name" DataField="cust_name">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn HeaderText="Tgl. Booking" DataField="book_date_welcoming">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn HeaderText="Unit" DataField="unit_code">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Indikasi Pemyimpangan">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:DropDownList Runat="server" ID="DDL_INDIKASI"></asp:DropDownList>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Ket. Penyimpangan">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:TextBox Runat="server" Width="200px" TextMode="MultiLine" ID="TXT_KET_PENYIMPANGAN"></asp:TextBox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Ket. No. Hp">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:DropDownList Runat="server" ID="DDL_KET_NOHP"></asp:DropDownList>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</ASP:DATAGRID></TD>
				</TR>
				<tr align="center">
					<td class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2"><asp:button id="BTN_SAVE" runat="server" Width="75px" Text="SAVE" CssClass="Button1" onclick="BTN_SAVE_Click"></asp:button></td>
				</tr>
			</TABLE>
		</form>
	</body>
</HTML>
