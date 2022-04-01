<%@ Page language="c#" Codebehind="DataPerkreditanIn.aspx.cs" AutoEventWireup="false" Inherits="SME.DCM.DataDictionary.DataInitiation.RejectInitiation.DataPerkreditanIn" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DataCIFIn</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
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
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>DATA&nbsp;PERKREDITAN 
											REQUEST</B></TD>
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
					<tr>
						<td colSpan="2"></td>
					</tr>
					<TR>
						<td colSpan="2">
							<table width="100%">
								<tr>
									<TD>
										<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="80%">
											<TR width="100%">
												<TD class="TDBGColor1" width="15%">Field Name</TD>
												<TD>:</TD>
												<TD class="TDBGColorValue" Width="60%">
													<asp:textbox id="TXT_NO_CIF" runat="server" Width="100%"></asp:textbox>
												</TD>
												<TD Width="25%"><asp:Button Runat="server" ID="BTN_SRCHFIELDNAME" Text="Find" Width="100%" CssClass="BUTTON1"></asp:Button></TD>
											</TR>
										</TABLE>
									</TD>
									<td>
										<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="80%">
											<TR width="100%">
												<TD class="TDBGColor1" width="15%">Description</TD>
												<TD>:</TD>
												<TD class="TDBGColorValue" Width="60%">
													<asp:textbox id="Textbox1" runat="server" Width="100%"></asp:textbox>
												</TD>
												<TD Width="25%"><asp:Button Runat="server" ID="BTN_SRCHDESC" Text="Find" Width="100%" CssClass="BUTTON1"></asp:Button></TD>
											</TR>
										</TABLE>
									</td>
								</tr>
							</table>
						</td>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">DATA PERKREDITAN</TD>
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
							</ASP:DATAGRID></TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" colSpan="2"><asp:button id="Button1" runat="server" Width="100px" CssClass="BUTTON1" Text="SAVE"></asp:button>
							<asp:button id="Button2" Width="70px" CssClass="button1" Text="FINISH" Runat="server"></asp:button></TD>
					</TR>
				</table>
			</CENTER>
		</form>
	</body>
</HTML>
