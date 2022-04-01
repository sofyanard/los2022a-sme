<%@ Page language="c#" Codebehind="ViewCollateral.aspx.cs" AutoEventWireup="True" Inherits="SME.ITTP.ViewCollateral" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ViewCollateral</title>
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
						<TD class="tdHeader1" colSpan="2">Agunan</TD>
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
									<asp:BoundColumn Visible="False" DataField="ap_regno"></asp:BoundColumn>
									<asp:BoundColumn DataField="apptypedesc" HeaderText="Jenis Permohonan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="productdesc" HeaderText="Produk">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="coltypedesc" HeaderText="Jenis Agunan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="cl_desc" HeaderText="No Deposito / Keterangan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="cl_currency" HeaderText="Mata Uang">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="cl_foreignval" HeaderText="Nilai Agunan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="cl_exchangerate" HeaderText="Exchange Rate">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="cl_value" HeaderText="Nilai Agunan (Dlm Rp)">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="accrdtodesc" HeaderText="Penilaian Oleh">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="certtypedesc" HeaderText="Bukti Kepemilikan">
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
