<%@ Page language="c#" Codebehind="DetailDataRequest.aspx.cs" AutoEventWireup="True" Inherits="SME.DCM.DataDictionary.ApprovalDataInitiation.DetailDataRequest" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>DetailDataRequest</TITLE>
		<META content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../Style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY MS_POSITIONING="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<CENTER>
				<TABLE width="100%" border="0">
					<TR>
						<TD align="left">
							<TABLE id="Table1">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>DETAIL DATA REQUEST</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/image/Back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../../../Body.aspx"><IMG height="25" src="../../../Image/MainMenu.jpg" width="106"></A>
							<A href="../../../Logout.aspx" target="_top"><IMG src="../../../Image/Logout.jpg"></A>
						</TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">DETAIL DATA REQUEST</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" colSpan="2">
							<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100%" border="0">
								<TR>
									<TD><asp:radiobuttonlist id="RDO_RB1" runat="server" RepeatDirection="Horizontal">
											<asp:ListItem Value="CIF ACCOUNT">DATA CUSTOMER INFORMATION FILE (CIF)</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD colSpan="2"><ASP:DATAGRID id="DGR_CIF" runat="server" Width="100%" AllowPaging="True" CellPadding="1" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="FIELDSNAME" HeaderText="FIELDS NAME">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="FIELDSDESCRIPTION" HeaderText="DESCRIPTION">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left" Width="50%"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="CHECK FOR SELECT">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
										<ItemTemplate>
											<asp:CheckBox id="CHK_DATA_CIF" runat="server"></asp:CheckBox>&nbsp;
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
					<TR>
						<TD colSpan="2"></TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" colSpan="2">
							<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="100%" border="0">
								<TR>
									<TD><asp:radiobuttonlist id="Radiobuttonlist1" runat="server" RepeatDirection="Horizontal">
											<asp:ListItem Value="DATA DANA PIHAK KETIGA">DATA DANA PIHAK KETIGA</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" align="center" width="50%" colSpan="2"><asp:datagrid id="DGR_DANA" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="FIELDSNAME" HeaderText="FIELDS NAME">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="FIELDSDESCRIPTION" HeaderText="DESCRIPTION">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left" Width="50%"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="CHECK FOR SELECT">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
										<ItemTemplate>
											<asp:CheckBox id="CHK_DATA_DANA" runat="server"></asp:CheckBox>&nbsp;
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</asp:datagrid></TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" colSpan="2">
							<TABLE id="Table5" cellSpacing="1" cellPadding="1" width="100%" border="0">
								<TR>
									<TD><asp:radiobuttonlist id="Radiobuttonlist2" runat="server" RepeatDirection="Horizontal">
											<asp:ListItem Value="DATA PERKREDITAN">DATA PERKREDITAN</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" align="center" width="50%" colSpan="2"><asp:datagrid id="DGR_PERKREDITAN" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="FIELDSNAME" HeaderText="FIELDS NAME">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="FIELDSDESCRIPTION" HeaderText="DESCRIPTION">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left" Width="50%"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="CHECK FOR SELECT">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
										<ItemTemplate>
											<asp:CheckBox id="CHK_DATA_KREDIT" runat="server"></asp:CheckBox>&nbsp;
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</asp:datagrid></TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" colSpan="2">
							<TABLE id="Table6" cellSpacing="1" cellPadding="1" width="100%" border="0">
								<TR>
									<TD><asp:radiobuttonlist id="Radiobuttonlist3" runat="server" RepeatDirection="Horizontal">
											<asp:ListItem Value="DATA AGUNAN">DATA AGUNAN</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" align="center" width="50%" colSpan="2"><asp:datagrid id="DGR_AGUNAN" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="FIELDSNAME" HeaderText="FIELDS NAME">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="FIELDSDESCRIPTION" HeaderText="DESCRIPTION">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left" Width="50%"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="CHECK FOR SELECT">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
										<ItemTemplate>
											<asp:CheckBox id="CHK_DATA_AGUNAN" runat="server"></asp:CheckBox>&nbsp;
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</asp:datagrid></TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" colSpan="2">
							<TABLE id="Table8" cellSpacing="1" cellPadding="1" width="100%" border="0">
								<TR>
									<TD><asp:radiobuttonlist id="Radiobuttonlist4" runat="server" RepeatDirection="Horizontal">
											<asp:ListItem Value="DATA TRADE">DATA TRADE</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" align="center" width="50%" colSpan="2"><asp:datagrid id="DGR_TRADE" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="FIELDSNAME" HeaderText="FIELDS NAME">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="FIELDSDESCRIPTION" HeaderText="DESCRIPTION">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left" Width="50%"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="CHECK FOR SELECT">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
										<ItemTemplate>
											<asp:CheckBox id="CHK_DATA_TRADE" runat="server"></asp:CheckBox>&nbsp;
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</asp:datagrid></TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" colSpan="2">
							<TABLE id="Table7" cellSpacing="1" cellPadding="1" width="100%" border="0">
								<TR>
									<TD><asp:radiobuttonlist id="Radiobuttonlist5" runat="server" RepeatDirection="Horizontal">
											<asp:ListItem Value="DATA TRADE">DATA TREASURY</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" align="center" width="50%" colSpan="2"><asp:datagrid id="DGR_TREASURY" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="FIELDSNAME" HeaderText="FIELDS NAME">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="FIELDSDESCRIPTION" HeaderText="DESCRIPTION">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left" Width="50%"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="CHECK FOR SELECT">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
										<ItemTemplate>
											<asp:CheckBox id="CHK_DATA_TREASURY" runat="server"></asp:CheckBox>&nbsp;
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</asp:datagrid></TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" colSpan="2">
							<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="100%" border="0">
								<TR>
									<TD>
										<asp:radiobuttonlist id="RDO_RB2" runat="server" RepeatDirection="Horizontal">
											<asp:ListItem Value="HISTORICAL ACCOUNT">DATA HISTORICAL TRANSACTION</asp:ListItem>
										</asp:radiobuttonlist>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD colSpan="2"><ASP:DATAGRID id="DGR_HISTORICAL_TRANSACTION" runat="server" Width="100%" AllowPaging="True" CellPadding="1"
								AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="TYPE" HeaderText="TRANSACTION TYPE">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left" Width="20%"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="FIELDSNAME" HeaderText="FIELDS NAME">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="FIELDSDESCRIPTION" HeaderText="DESCRIPTION">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left" Width="50%"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="CHECK FOR SELECT">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
										<ItemTemplate>
											<asp:CheckBox id="CHK_DATA_HISTORICAL_TRANSACTION" runat="server"></asp:CheckBox>&nbsp;
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID>
						</TD>
					</TR>
				</TABLE>
			</CENTER>
		</FORM>
	</BODY>
</HTML>
