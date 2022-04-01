<%@ Page language="c#" Codebehind="DataTransactionHistory.aspx.cs" AutoEventWireup="True" Inherits="SME.DCM.DataDictionary.DataInitiation.RejectInitiation.DataTransactionHistory" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DataTransactionHistory</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../../../Style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<FORM id="form1" method="post" runat="server">
			<!-- <center> -->
			<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
				<TR>
					<TD class="tdNoBorder" width="50%">
						<TABLE id="Table2">
							<TR>
								<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>DATA TRANSACTION REQUEST</B></TD>
							</TR>
						</TABLE>
					</TD>
					<TD align="right">
						<A href="ListCustomer.aspx?si="></A>
						<asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton>
						<A href="../../../../Body.aspx"><IMG src="../../../../Image/MainMenu.jpg"></A> <A href="../../../../Logout.aspx" target="_top">
							<IMG src="../../../../Image/Logout.jpg"></A>
					</TD>
				</TR>
				<TR>
					<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
				</TR>
				<TR>
					<TD class="tdHeader1" colSpan="2">DATA HISTORICAL TRANSACTION</TD>
				</TR>
				<TR id="TR_FIND" runat="server">
					<TD class="td" vAlign="top" colSpan="2">
						<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR>
								<TD>
									<asp:radiobuttonlist id="RDO_LOAN_ACCOUNT" runat="server" RepeatDirection="Horizontal" Width="300px" AutoPostBack="True" onselectedindexchanged="RDO_LOAN_ACCOUNT_SelectedIndexChanged">
										<asp:ListItem Value="1">LOAN ACCOUNT</asp:ListItem>
									</asp:radiobuttonlist>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD colSpan="2"><ASP:DATAGRID id="DGR_LOAN" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False"
							CellPadding="1" PageSize="5">
							<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
							<Columns>
								<asp:BoundColumn DataField="FIELDSNAME" HeaderText="FIELDS NAME">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" Width="40%"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="FIELDSDESCRIPTION" HeaderText="DESCRIPTION">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" Width="40%"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="CHECK FOR SELECT">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:CheckBox Runat="server" ID="CHK_LOAN"></asp:CheckBox>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</ASP:DATAGRID></TD>
				</TR>
				<TR id="Tr1" runat="server">
					<TD class="td" vAlign="top" colSpan="2">
						<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR>
								<TD>
									<asp:radiobuttonlist id="RDO_SAVING_GIRO" runat="server" RepeatDirection="Horizontal" Width="300px" AutoPostBack="True" onselectedindexchanged="RDO_SAVING_GIRO_SelectedIndexChanged">
										<asp:ListItem Value="2">SAVING &amp; GIRO ACCOUNT</asp:ListItem>
									</asp:radiobuttonlist>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD colSpan="2"><ASP:DATAGRID id="DGR_SAVING_GIRO" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False"
							CellPadding="1" PageSize="5">
							<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
							<Columns>
								<asp:BoundColumn DataField="FIELDSNAME" HeaderText="FIELDS NAME">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" Width="40%"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="FIELDSDESCRIPTION" HeaderText="DESCRIPTION">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" Width="40%"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="CHECK FOR SELECT">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:CheckBox Runat="server" ID="CHK_SAVING_GIRO"></asp:CheckBox>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</ASP:DATAGRID>
					</TD>
				</TR>
				<TR id="Tr2" runat="server">
					<TD class="td" vAlign="top" colSpan="2">
						<TABLE id="Table5" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR>
								<TD>
									<asp:radiobuttonlist id="RDO_TIME_DEPOSIT" runat="server" RepeatDirection="Horizontal" Width="300px" AutoPostBack="True" onselectedindexchanged="RDO_TIME_DEPOSIT_SelectedIndexChanged">
										<asp:ListItem Value="3">TIME DEPOSIT ACCOUNT</asp:ListItem>
									</asp:radiobuttonlist>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD colSpan="2"><ASP:DATAGRID id="DGR_TIME_DEPOSIT" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False"
							CellPadding="1" PageSize="5">
							<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
							<Columns>
								<asp:BoundColumn DataField="FIELDSNAME" HeaderText="FIELDS NAME">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" Width="40%"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="FIELDSDESCRIPTION" HeaderText="DESCRIPTION">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" Width="40%"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="CHECK FOR SELECT">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:CheckBox Runat="server" ID="CHK_TIMEDEPOSIT"></asp:CheckBox>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</ASP:DATAGRID>
					</TD>
				</TR>
				<TR id="Tr3" runat="server">
					<TD class="td" vAlign="top" colSpan="2">
						<TABLE id="Table6" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR>
								<TD>
									<asp:radiobuttonlist id="RDO_TRADE" runat="server" RepeatDirection="Horizontal" Width="300px" AutoPostBack="True" onselectedindexchanged="RDO_TRADE_SelectedIndexChanged">
										<asp:ListItem Value="4">TRADE</asp:ListItem>
									</asp:radiobuttonlist>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD colSpan="2"><ASP:DATAGRID id="DGR_TRADE" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False"
							CellPadding="1" PageSize="5">
							<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
							<Columns>
								<asp:BoundColumn DataField="FIELDSNAME" HeaderText="FIELDS NAME">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" Width="40%"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="FIELDSDESCRIPTION" HeaderText="DESCRIPTION">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" Width="40%"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="CHECK FOR SELECT">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:CheckBox Runat="server" ID="CHK_TRADETRANSACTION"></asp:CheckBox>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</ASP:DATAGRID>
					</TD>
				</TR>
				<TR id="Tr4" runat="server">
					<TD class="td" vAlign="top" colSpan="2">
						<TABLE id="Table7" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR>
								<TD>
									<asp:radiobuttonlist id="RDO_TREASURY" runat="server" RepeatDirection="Horizontal" Width="300px" AutoPostBack="True" onselectedindexchanged="RDO_TREASURY_SelectedIndexChanged">
										<asp:ListItem Value="5">TREASURY</asp:ListItem>
									</asp:radiobuttonlist>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD colSpan="2"><ASP:DATAGRID id="DGR_TREASURY" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False"
							CellPadding="1" PageSize="5">
							<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
							<Columns>
								<asp:BoundColumn DataField="FIELDSNAME" HeaderText="FIELDS NAME">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" Width="40%"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="FIELDSDESCRIPTION" HeaderText="DESCRIPTION">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" Width="40%"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="CHECK FOR SELECT">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:CheckBox Runat="server" ID="CHK_TREASURY"></asp:CheckBox>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</ASP:DATAGRID>
					</TD>
				</TR>
			</TABLE>
		</FORM>
	</BODY>
</HTML>
