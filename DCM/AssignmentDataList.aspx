<%@ Page language="c#" Codebehind="AssignmentDataList.aspx.cs" AutoEventWireup="True" Inherits="SME.DCM.AssignmentDataList" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AssignmentDataList</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../Style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0">
				<tr>
					<td align="left">
						<TABLE id="Table31">
							<TR>
								<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>ASSIGNMENT LIST</B></TD>
							</TR>
						</TABLE>
					</td>
					<TD class="tdNoBorder" align="right"><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
				</tr>
				<TR>
					<TD align="center" colSpan="2">
						<TABLE class="td" id="Table1" style="WIDTH: 590px; HEIGHT: 200px" cellSpacing="1" cellPadding="1"
							width="590" border="1">
							<TR>
								<TD class="tdHeader1" style="HEIGHT: 33px">Search Criteria</TD>
							</TR>
							<TR>
								<TD vAlign="bottom" align="center">
									<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="TDBGColor1" style="HEIGHT: 17px">Data#</TD>
											<TD style="HEIGHT: 17px">:</TD>
											<TD class="TDBGColorValue" style="WIDTH: 342px; HEIGHT: 17px" width="342"><asp:textbox id="TXT_DATA" runat="server" MaxLength="30" Width="280px"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="HEIGHT: 2px">Customer Name</TD>
											<TD style="HEIGHT: 2px">:</TD>
											<TD class="TDBGColorValue" style="WIDTH: 342px; HEIGHT: 2px" width="342"><asp:textbox id="TXT_CUST_NAME" runat="server" MaxLength="40" Width="280px"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="HEIGHT: 2px">CIF#</TD>
											<TD style="HEIGHT: 2px">:</TD>
											<TD class="TDBGColorValue" style="WIDTH: 342px; HEIGHT: 2px" width="342"><asp:textbox id="TXT_CIF" runat="server" MaxLength="11" Width="280px"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="HEIGHT: 12px">Account Type</TD>
											<TD style="HEIGHT: 12px">:</TD>
											<TD class="TDBGColorValue" style="WIDTH: 342px; HEIGHT: 12px"><asp:dropdownlist id="DDL_ACC_TYPE" runat="server"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="HEIGHT: 6px">Account#</TD>
											<TD style="HEIGHT: 6px">:</TD>
											<TD class="TDBGColorValue" style="WIDTH: 342px; HEIGHT: 6px"><asp:textbox id="TXT_ACC" runat="server" MaxLength="20" Width="280px"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 521px" vAlign="top" align="center" colSpan="3"></TD>
										</TR>
									</TABLE>
									<asp:button id="btn_Find" runat="server" Width="56px" CssClass="button1" Text="FIND" onclick="btn_Find_Click"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD align="center" colSpan="2">&nbsp;</TD>
				</TR>
				<TR>
					<TD colSpan="2"><ASP:DATAGRID id="DatGrd" runat="server" Width="100%" AllowPaging="True" CellPadding="1" AutoGenerateColumns="False">
							<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
							<Columns>
								<asp:BoundColumn HeaderText="Data#" DataField="">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="" HeaderText="Customer Name">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="" HeaderText="CIF#">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="" HeaderText="Account#">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:ButtonColumn Text="View" HeaderText="Function" CommandName="View">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
								</asp:ButtonColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</ASP:DATAGRID></TD>
				</TR>
			</table>
		</form>
	</body>
</HTML>
