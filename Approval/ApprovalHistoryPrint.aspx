<%@ Page language="c#" Codebehind="ApprovalHistoryPrint.aspx.cs" AutoEventWireup="True" Inherits="SME.Approval.ApprovalHistoryPrint" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Approval History Print</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function cetak()
		{
			//ID_TOP.style.display	= "none";
			ID_BOTTOM.style.display	= "none";
			window.print();
			//ID_TOP.style.display	= "";
			ID_BOTTOM.style.display	= "";
		}
		function keluar(tc, mc)
		{
			a = confirm("Are you sure want to finish ?")
			if (a)
				window.location = "DisbursementSheet.aspx?tc=" + tc + "&mc=" + mc;
		}
		function buka(str1,str2)
		{
			if ((str1=="01") && (str2=="0"))
			{
				ID011.style.display	= "none";
				ID012.style.display	= "none";
			}
		}
		</script>
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<CENTER>
				<table cellSpacing="2" cellPadding="2" width="100%">
					<TBODY>
						<tr>
							<td vAlign="top" align="center">
								<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="670">
									<TBODY>
										<TR>
											<TD class="HeaderReport"><asp:label id="LBL_APREGNO" runat="server" Visible="False"></asp:label>
												<!-- <asp:label id="LBL_APPTYPE1" runat="server" Visible="False"></asp:label>WORKSHEET --><asp:label id="LBL_KET_CODE" runat="server" Visible="False"></asp:label>APPROVAL 
												HISTORY
												<asp:label id="LBL_PRODUCTID" runat="server" Visible="False"></asp:label><asp:label id="LBL_PROD_SEQ" runat="server" Visible="False"></asp:label></TD>
										</TR>
										<TR>
											<TD>&nbsp;&nbsp;
												<asp:label id="Label1" runat="server">Print Date                  :</asp:label>&nbsp;
												<asp:label id="LBL_PRINT" runat="server"></asp:label><asp:label id="LBL_CASH" runat="server" Visible="False"></asp:label></TD>
										</TR>
										<TR>
											<TD class="td" vAlign="top">
												<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
													<TBODY>
														<TR>
															<TD class="NoReport">&nbsp; 1</TD>
															<TD></TD>
															<TD class="TDBGColorValue" colSpan="2"><b>Services Applied</b></TD>
														</TR>
														<asp:panel id="Panel04" runat="server" Visible="False"></asp:panel><asp:panel id="Panel05" runat="server" Visible="False"></asp:panel><asp:panel id="Panel01" runat="server" Visible="False"></asp:panel><asp:panel id="Panel07" runat="server" Visible="False"></asp:panel><asp:panel id="Panel03" runat="server" Visible="False"></asp:panel><asp:panel id="Panel06" runat="server" Visible="False"></asp:panel><asp:panel id="Panel02" runat="server" Visible="False"></asp:panel><asp:panel id="PanelACC" Visible="False" Runat="server"></asp:panel><asp:panel id="Panel041" runat="server" Visible="False"></asp:panel><asp:panel id="Panel011" runat="server" Visible="False"></asp:panel>
														<TR>
															<TD class="NoReport"></TD>
															<TD></TD>
															<TD class="TDBGColorValue"></TD>
															<TD class="TDBGColorValue"></TD>
														</TR>
														<TR>
															<TD class="NoReport">&nbsp;</TD>
															<TD></TD>
															<TD class="TDBGColorValue" colSpan="2">
																<asp:PlaceHolder id="PlaceHolder1" runat="server"></asp:PlaceHolder></TD>
														</TR>
														<TR>
															<TD class="NoReport"></TD>
															<TD></TD>
															<TD class="TDBGColorValue" colSpan="2"></TD>
														</TR>
													</TBODY>
												</TABLE>
											</TD>
										</TR>
										<TR id="ID_BOTTOM">
											<TD class="TDBGColor2" vAlign="top"><INPUT class="button1" onclick="cetak()" type="button" value="PRINT"></TD>
										</TR>
									</TBODY>
								</TABLE>
								&nbsp;</td>
						</tr>
					</TBODY>
				</table>
			</CENTER>
		</form>
	</body>
</HTML>
