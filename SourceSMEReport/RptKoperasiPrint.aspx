<%@ Page language="c#" Codebehind="RptKoperasiPrint.aspx.cs" AutoEventWireup="True" Inherits="SME.SourceSMEReport.RptKoperasiPrint" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RptKoperasiPrint</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="style.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		  function cetak()
		  {
		    TRPRINT.style.display = "none";
		    window.print();
		    TRPRINT.style.display = "";
		  }
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD align="center" class="HeaderReport"><B></B></TD>
					</TR>
					<TR>
						<TD class="TitleHeaderReport" align="left">RELATIONSHIP REPORT - KOPERASI DAN 
							KELOMPOK</TD>
					</TR>
					<TR>
						<TD class="TitleReport" align="left">
							<asp:Label id="LBL_PERIODE" runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD class="TitleReport" align="left">
							<asp:Label id="LBL_REGION" runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD class="TitleReport" align="left">
							<asp:Label id="LBL_BRANCH" runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD class="TitleReport" align="left">
							<asp:Label id="lbl_bussgrp" runat="server" ForeColor="Black"></asp:Label></TD>
					</TR>
					<!--					
					<TR>
						<TD class="TitleReport" align="center">
							<asp:Label id="lbl_ps" runat="server" ForeColor="Black">PS</asp:Label></TD>
					</TR>
-->
					<TR>
						<TD class="TDBGColorValue">
							<asp:Table id="TBL_CONTENT" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"
								Width="100%" CellPadding="0" CellSpacing="0">
								<asp:TableRow>
									<asp:TableCell Width="40px" Text="CIF" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="120px" Text="KOPERASI/PERUSAHAAN" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="120px" Text="LOS APPLICATION #" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="200px" Text="ACCOUNT #" CssClass="HeaderPrint"></asp:TableCell>
                                    <asp:TableCell Width="120px" Text="LOS APPLICATION #(SUB)" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="120px" Text="NAMA KELOMPOK" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="80px" Text="CIF" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="80px" Text="A/A" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="60px" Text="FAC" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="100px" Text="SEQ" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="100px" Text="PRODUCT TYPE" CssClass="HeaderPrint"></asp:TableCell>
									<asp:TableCell Width="80px" Text="LIMIT" CssClass="HeaderPrint"></asp:TableCell>
								</asp:TableRow>
							</asp:Table>
						</TD>
					</TR>
					<TR id="TRPRINT">
						<TD align="center">
							<INPUT type="button" onclick="cetak()" Width="125px" Value="Print" CssClass="Button1"></ASP:BUTTON>
						</TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
