<%@ Page language="c#" Codebehind="RatingDetailHistory.aspx.cs" AutoEventWireup="True" Inherits="SME.ITTP.RatingDetailHistory" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RatingDetailHistory</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
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
						<TD class="tdHeader1" colSpan="2">Rating Detail History</TD>
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
									<asp:BoundColumn Visible="False" DataField="QUALITATIVEID"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="SUBQUALITATIVEID"></asp:BoundColumn>
									<asp:BoundColumn DataField="QUALITATIVEDESC" HeaderText="Assesment Parameter">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="SUBQUALITATIVEDESC" HeaderText="Assesment Sub Parameter">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="subsubqualitativedesc" HeaderText="Jawaban">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="SCORE" HeaderText="Score">
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
