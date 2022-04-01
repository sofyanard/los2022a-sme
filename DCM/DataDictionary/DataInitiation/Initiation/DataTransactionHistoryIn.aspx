<%@ Page language="c#" Codebehind="DataTransactionHistoryIn.aspx.cs" AutoEventWireup="false" Inherits="SME.DCM.DataDictionary.DataInitiation.Initiation.DataTransactionHistoryIn" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DataTransactionHistoryIn</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../../../Style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<CENTER>
				<table width="100%" border="0">
					<tr>
						<td align="left">
							<TABLE id="Table31">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>DATA TRANSACTION REQUEST</B></TD>
								</TR>
							</TABLE>
						</td>
						<TD class="tdNoBorder" align="right"><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="../../../../image/Back.jpg"></asp:imagebutton><A href="../../../Body.aspx"><IMG height="25" src="../../../../Image/MainMenu.jpg" width="106"></A>
							<A href="../../../../Logout.aspx" target="_top"><IMG src="../../../../Image/Logout.jpg"></A>
						</TD>
					</tr>
					<tr>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</tr>
					<TR>
						<TD class="tdHeader1" colSpan="2">DATA HISTORICAL TRANSACTION</TD>
					</TR>
					<TR id="TR_RBI" runat="server">
						<TD class="td" vAlign="top" colSpan="2">
							<TABLE id="Table18" cellSpacing="1" cellPadding="1" width="100%" border="0">
								<TR>
									<TD><asp:radiobuttonlist id="RDO_RBI" runat="server" RepeatDirection="Horizontal" Width="150px" Enabled="False">
											<asp:ListItem Value="LOAN ACCOUNT">LOAN ACCOUNT</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD colSpan="2"><ASP:DATAGRID id="DGR_PROBLEM" runat="server" AutoGenerateColumns="False" CellPadding="1" AllowPaging="True"
								Width="100%">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn HeaderText="NO" DataField="#">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="FIELDS NAME" DataField="#">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="30%"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="" HeaderText="DESCRIPTION">
										<HeaderStyle CssClass="tdSmallHeader" Width="500px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="50%"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="CHECK FOR SELECT">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
										<ItemTemplate>
											<asp:CheckBox id="edit_cab" runat="server"></asp:CheckBox>&nbsp;
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" colSpan="2"><asp:button id="Button1" runat="server" Width="100px" CssClass="BUTTON1" Text="SAVE"></asp:button></TD>
					</TR>
					<tr>
						<td colSpan="2"></td>
					</tr>
					<TR id="Tr1" runat="server">
						<TD class="td" vAlign="top" colSpan="2">
							<TABLE id="Table18" cellSpacing="1" cellPadding="1" width="100%" border="0">
								<TR>
									<TD><asp:radiobuttonlist id="Radiobuttonlist1" runat="server" RepeatDirection="Horizontal" Width="1000px"
											Enabled="False">
											<asp:ListItem Value="LOAN ACCOUNT">SAVING & GIRO ACCOUNT</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD colSpan="2"><ASP:DATAGRID id="Datagrid1" runat="server" AutoGenerateColumns="False" CellPadding="1" AllowPaging="True"
								Width="100%">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn HeaderText="NO" DataField="#">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="FIELDS NAME" DataField="#">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="30%"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="" HeaderText="DESCRIPTION">
										<HeaderStyle CssClass="tdSmallHeader" Width="500px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="50%"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="CHECK FOR SELECT">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
										<ItemTemplate>
											<asp:CheckBox id="Checkbox1" runat="server"></asp:CheckBox>&nbsp;
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" colSpan="2"><asp:button id="Button2" runat="server" Width="100px" CssClass="BUTTON1" Text="SAVE"></asp:button></TD>
					</TR>
					<tr>
						<td colSpan="2"></td>
					</tr>
					<TR id="Tr2" runat="server">
						<TD class="td" vAlign="top" colSpan="2">
							<TABLE id="Table18" cellSpacing="1" cellPadding="1" width="100%" border="0">
								<TR>
									<TD><asp:radiobuttonlist id="Radiobuttonlist2" runat="server" RepeatDirection="Horizontal" Width="1000px"
											Enabled="False">
											<asp:ListItem Value="LOAN ACCOUNT">TIME DEPOSIT ACCOUNT</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD colSpan="2"><ASP:DATAGRID id="Datagrid2" runat="server" AutoGenerateColumns="False" CellPadding="1" AllowPaging="True"
								Width="100%">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn HeaderText="NO" DataField="#">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="FIELDS NAME" DataField="#">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="30%"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="" HeaderText="DESCRIPTION">
										<HeaderStyle CssClass="tdSmallHeader" Width="500px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="50%"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="CHECK FOR SELECT">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
										<ItemTemplate>
											<asp:CheckBox id="Checkbox2" runat="server"></asp:CheckBox>&nbsp;
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" colSpan="2"><asp:button id="Button3" runat="server" Width="100px" CssClass="BUTTON1" Text="SAVE"></asp:button></TD>
					</TR>
					<tr>
						<td colSpan="2"></td>
					</tr>
					<TR id="Tr3" runat="server">
						<TD class="td" vAlign="top" colSpan="2">
							<TABLE id="Table18" cellSpacing="1" cellPadding="1" width="100%" border="0">
								<TR>
									<TD><asp:radiobuttonlist id="Radiobuttonlist3" runat="server" RepeatDirection="Horizontal" Width="1000px"
											Enabled="False">
											<asp:ListItem Value="LOAN ACCOUNT">TRADE</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD colSpan="2"><ASP:DATAGRID id="Datagrid3" runat="server" AutoGenerateColumns="False" CellPadding="1" AllowPaging="True"
								Width="100%">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn HeaderText="NO" DataField="#">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="FIELDS NAME" DataField="#">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="30%"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="" HeaderText="DESCRIPTION">
										<HeaderStyle CssClass="tdSmallHeader" Width="500px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="50%"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="CHECK FOR SELECT">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
										<ItemTemplate>
											<asp:CheckBox id="Checkbox3" runat="server"></asp:CheckBox>&nbsp;
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" colSpan="2"><asp:button id="Button4" runat="server" Width="100px" CssClass="BUTTON1" Text="SAVE"></asp:button></TD>
					</TR>
					<tr>
						<td colSpan="2"></td>
					</tr>
					<TR id="Tr4" runat="server">
						<TD class="td" vAlign="top" colSpan="2">
							<TABLE id="Table18" cellSpacing="1" cellPadding="1" width="100%" border="0">
								<TR>
									<TD><asp:radiobuttonlist id="Radiobuttonlist4" runat="server" RepeatDirection="Horizontal" Width="1000px"
											Enabled="False">
											<asp:ListItem Value="LOAN ACCOUNT">TREASURY</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD colSpan="2"><ASP:DATAGRID id="Datagrid4" runat="server" AutoGenerateColumns="False" CellPadding="1" AllowPaging="True"
								Width="100%">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn HeaderText="NO" DataField="#">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="FIELDS NAME" DataField="#">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="30%"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="" HeaderText="DESCRIPTION">
										<HeaderStyle CssClass="tdSmallHeader" Width="500px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="50%"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="CHECK FOR SELECT">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
										<ItemTemplate>
											<asp:CheckBox id="Checkbox4" runat="server"></asp:CheckBox>&nbsp;
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" colSpan="2"><asp:button id="Button5" runat="server" Width="100px" CssClass="BUTTON1" Text="SAVE"></asp:button></TD>
					</TR>
				</table>
			</CENTER>
		</form>
	</body>
</HTML>
