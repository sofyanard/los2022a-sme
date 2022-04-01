<%@ Page language="c#" Codebehind="ScenarioPrint.aspx.cs" AutoEventWireup="True" Inherits="SME.AccountPlanning.DealAnalyzer.ScenarioPrint" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<TITLE>ScenarioPrint</TITLE>
		<META content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		  function cetak()
		  {
		    TRPRINT.style.display = "none";
		    window.print();
		    TRPRINT.style.display = "";
		  }
		</script>
</HEAD>
	<BODY MS_POSITIONING="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<CENTER>
				<TABLE width="100%" border="0">
					<TR>
						<TD class="tdNoBorder" align="right" colSpan="2"><IMG src="../../Image/LogoMandiri.jpg">
						</TD>
					</TR>
					<TR>
						<TD align="center" colSpan="2"><asp:label id="LBL_TITLE_PAGE" runat="server" Font-Bold="True" Font-Size="200%">DEAL ANALYZER</asp:label></TD>
					</TR>
					<TR>
						<TD colSpan="2"></TD>
					</TR>
					<TR>
						<TD class="td" style="HEIGHT: 7px" vAlign="top" width="50%">
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_CIF" runat="server">CIF No. :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:label id="LBL_CIF" runat="server" Width="100%"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_CUST_NAME" runat="server">Customer Name :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:label id="LBL_CUST_NAME" runat="server" Width="100%"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_ADDRESS" runat="server">Address :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:label id="LBL_ADDRESS" runat="server" Width="100%"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_KOTA" runat="server">Kota :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:label id="LBL_KOTA" runat="server" Width="100%"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_GROUP_NAME" runat="server">Customer Group Name :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:label id="LBL_GROUP_NAME" runat="server" Width="100%"></asp:label></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" style="HEIGHT: 7px" vAlign="top" width="50%">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_CUST_DATE" runat="server">Customer Date :</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2"><asp:label id="LBL_CUST_DATE" runat="server" Width="100%"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_RM" runat="server">Relationship Manager :</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2"><asp:label id="LBL_RM" runat="server" Width="100%"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_RM_GROUP_NAME" runat="server">RM Group Name :</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2"><asp:label id="LBL_RM_GROUP_NAME" runat="server" Width="100%"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_RM_UNIT_NAME" runat="server">RM Unit Name :</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2"><asp:label id="LBL_RM_UNIT_NAME" runat="server" Width="100%"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_RELATIONSHIP" runat="server">Length of relationship :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:label id="LBL_RELATIONSHIP" runat="server" Width="100%"></asp:label></TD>
									<TD><asp:label id="LBL_TXT_DAYS" runat="server">Years</asp:label></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD colSpan="2"></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">SCENARIO :
							<asp:label id="LBL_SCENARIO" runat="server"></asp:label><asp:label id="LBL_SEQ_SCENARIO" runat="server" Visible="False"></asp:label></TD>
					</TR>
					<TR>
						<TD colSpan="2"></TD>
					</TR>
				</TABLE>
				<TABLE id="TBL_SCENARIO" width="100%" border="1" runat="server">
				</TABLE>
				<TABLE width="100%" border="0">
					<TR>
						<TD align="left" width="50%">
							<TABLE id="Table5">
								<TR>
									<TD><asp:label id="Label1" runat="server" Font-Bold="True">Total Income</asp:label></TD>
								</TR>
								<TR>
									<TD><asp:label id="Label3" runat="server">Total Net Interest Income</asp:label></TD>
								</TR>
								<TR>
									<TD><asp:label id="Label5" runat="server">Total Fee Based Income</asp:label></TD>
								</TR>
								<TR>
									<TD><asp:label id="Label2" runat="server" Font-Bold="True">RORA</asp:label></TD>
								</TR>
								<TR>
									<TD><asp:label id="Label4" runat="server">Total Cash Loan</asp:label></TD>
								</TR>
								<TR>
									<TD><asp:label id="Label6" runat="server">Total Non Cash Loan</asp:label></TD>
								</TR>
								<TR>
									<TD><asp:label id="Label7" runat="server" Font-Bold="True">Total Income/Cost for Customer</asp:label></TD>
								</TR>
							</TABLE>
						</TD>
						<TD align="right" width="50%" bgColor="#e5ebf4">
							<TABLE id="Table6">
								<TR>
									<TD><asp:label id="LBL_TOT_INCOME" runat="server" Font-Bold="True"></asp:label></TD>
								</TR>
								<TR>
									<TD><asp:label id="LBL_NII" runat="server"></asp:label></TD>
								</TR>
								<TR>
									<TD><asp:label id="LBL_FBI" runat="server"></asp:label></TD>
								</TR>
								<TR>
									<TD><asp:label id="LBL_RORA" runat="server" Font-Bold="True"></asp:label></TD>
								</TR>
								<TR>
									<TD><asp:label id="LBL_CASH" runat="server"></asp:label></TD>
								</TR>
								<TR>
									<TD><asp:label id="LBL_NON_CASH" runat="server"></asp:label></TD>
								</TR>
								<TR>
									<TD><asp:label id="LBL_INCOME_COST_CUST" runat="server" Font-Bold="True"></asp:label></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR id="TRPRINT">
						<TD class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2"><INPUT onclick="cetak()" type="button" value="Print" style="FONT-WEIGHT: bold; FONT-SIZE: 150%; COLOR: white; BACKGROUND-COLOR: #18386b">
						</TD>
					</TR>
				</TABLE>
			</CENTER>
		</FORM>
	</BODY>
</HTML>
