<%@ Page language="c#" Codebehind="PG.aspx.cs" AutoEventWireup="True" Inherits="SME.ITTP.PG" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PG</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include  file="../include/cek_all.html" -->
		<script language="javascript">
		  function fillText(sTXT)
		  {
		    objTXT = eval('document.Form1.TXT_' + sTXT)
		    objDDL = eval('document.Form1.DDL_' + sTXT)
		    objTXT.value = objDDL.options[objDDL.selectedIndex].text;
		  }
		</script>
		</SCRIPT>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE cellSpacing="2" cellPadding="2" width="100%">
				<TBODY>
					<TR>
						<TD class="tdHeader1" colSpan="2">Portfolio Guidline 2010</TD>
					</TR>
					<!--				
					<TBODY>					
						<TR>
							<TD class="td" width="100%" colSpan="2">
								<table id="FORMAT_H" width="100%" runat="server">
									<TR>
										<TD class="td" colSpan="2">
											<table width="100%"> -->
					<TR width="100%">
						<TD colSpan="2"><ASP:DATAGRID id="DGR_QUAL2" runat="server" CellPadding="1" AutoGenerateColumns="False" Width="100%">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="NO" HeaderText="NOID"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="YEAR" HeaderText="YEAR"></asp:BoundColumn>
									<asp:BoundColumn DataField="CLASS" HeaderText="CLASS">
										<HeaderStyle Width="30%" CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="INDUSTRY" HeaderText="INDUSTRY">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
					<!--											</table>
										</TD>
									</TR>
								</table>
							</TD>
						</TR>
		</form>
		</TBODY> --></TBODY></TABLE>
		</form>
	</body>
</HTML>
