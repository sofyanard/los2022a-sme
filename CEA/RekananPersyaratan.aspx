<%@ Page language="c#" Codebehind="RekananPersyaratan.aspx.cs" AutoEventWireup="True" Inherits="SME.CEA.RekananPersyaratan" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>RekananPersyaratan</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Style.css" type="text/css" rel="stylesheet">
  </HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<!--
					<TR>
						<TD class="tdNoBorder" style="WIDTH: 509px">
							<TABLE id="Table4">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Initial Data Entry: 
											Artikel 230</B></TD>
								</TR>
							</TABLE>
							<asp:Label id="LBL_REGNO" runat="server"></asp:Label>
							<asp:Label id="LBL_CUREF" runat="server"></asp:Label>
							<asp:Label id="LBL_TC" runat="server"></asp:Label>
							<asp:Label id="LBL_MC" runat="server"></asp:Label>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</TR>
					
					<tr>
						<asp:label id="SYARAT_TYPEIDE" runat="server"></asp:label></tr>
					<TR>
						<TD class="tdHeader1" colSpan="2">Persyaratan Rekanan</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 18px" vAlign="top" width="50%" colSpan="2">
							<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="100%" border="0">
							</TABLE>
							<TABLE id="Table2" style="WIDTH: 948px; HEIGHT: 16px" cellSpacing="1" cellPadding="1" width="948"
								border="0">
							</TABLE>
							<asp:placeholder id="PH_ARTIKEL" runat="server"></asp:placeholder></TD>
					</TR>
				</TABLE> --></TABLE>
				<table width="100%">
					<TR>
						<TD class="tdHeader1" colSpan="2">Persyaratan Rekanan</TD>
					</TR>
					<tr>
						<TD colSpan="2"><ASP:DATAGRID id="DatGrd" runat="server" Width="100%" CellPadding="1" AutoGenerateColumns="False"
								PageSize="12">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="jenis" HeaderText="Jenis">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="subjenis" HeaderText="Sub Jenis">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</tr>
					<tr>
						<td align="center" class="TDBGColor2">
							<%if (Request.QueryString["sta"] != "view") { %>
							<INPUT class="button1" style="WIDTH: 100px" type="button" value="OK" onclick="javascript:window.close()"></td>
						<% } %>
					</tr>
				</table>
			</center>
		</form>
	</body>
</HTML>
