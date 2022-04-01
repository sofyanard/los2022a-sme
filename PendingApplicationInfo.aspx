<%@ Page language="c#" Codebehind="PendingApplicationInfo.aspx.cs" AutoEventWireup="True" Inherits="SME.PendingApplicationInfo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Pending Application Info</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="style.css" type="text/css" rel="stylesheet">
		<!-- #include file="include/child.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD class="tdH" align="center" bgColor="#f0f0f0" colSpan="2"><IMG height="71" src="image/log01.jpg" width="328"></TD>
				</TR>
				<TR>
					<TD class="tdheader1" vAlign="top" width="50%">Pending Application Info</TD>
				</TR>
				<TR>
					<TD class="td" vAlign="top" width="50%"><asp:datagrid id="DGR_PENDING" runat="server" Width="100%" AutoGenerateColumns="False">
							<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="TRACKCODE" HeaderText="TRACK CODE">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="TRACKNAME" HeaderText="TRACK NAME">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="APPCOUNT" HeaderText="JUMLAH APLIKASI" DataFormatString="{0} item">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<tr>
					<td></td>
				</tr>
				<TR>
					<TD class="tdheader1" vAlign="top" width="50%">Message</TD>
				</TR>
				<TR>
					<TD class="td" vAlign="top" width="50%"><asp:datagrid id="DGR_MSG" runat="server" Width="100%" AutoGenerateColumns="False">
							<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
							<Columns>
								<asp:BoundColumn DataField="MSG_SENDBY" HeaderText="From">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="MSG_TEXT" HeaderText="Message">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<tr>
					<td></td>
				</tr>
				<TR>
					<TD class="tdH" colSpan="2"></TD>
				</TR>
				<TR>
					<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2"><INPUT class="button1" style="WIDTH: 100px; HEIGHT: 26px" type="button" size="20" value="Close"
							onclick='javascript:window.close()'></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
