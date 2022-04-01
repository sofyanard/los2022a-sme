<%@ Page language="c#" Codebehind="BCG_Facility.aspx.cs" AutoEventWireup="True" Inherits="SME.Scoring.Version01.BCG_Facility" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Scoring</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table2" style="HEIGHT: 16px" cellSpacing="1" cellPadding="1" width="80%" border="0">
					<TR>
						<TD>
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD class="tdHeader1" style="HEIGHT: 1px" colSpan="3"><asp:label id="LABEL" runat="server" Width="56px" Height="16px">Facility</asp:label></TD>
								</TR>
							</TABLE>
							<TABLE id="Table1" style="WIDTH: 761px; HEIGHT: 464px" width="761" border="0">
								<TR>
									<TD style="WIDTH: 73px" vAlign="top">
										<asp:PlaceHolder id="PH_FACILITY" runat="server"></asp:PlaceHolder></TD>
									<TD vAlign="top" align="right">
										<iframe id="if_apptype" style="WIDTH: 99.98%; HEIGHT: 97.2%" name="if_apptype" src="" frameBorder="no"
											width="100%" scrolling="yes"></iframe>
									</TD>
								</TR>
							</TABLE>
							<asp:label id="LBL_AP_REGNO" runat="server" Visible="False"></asp:label>
							<asp:label id="LBL_CU_REF" runat="server" Visible="False"></asp:label><!--
							<TABLE id="Table1" style="HEIGHT: 131px" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD class="tdHeader1" colSpan="3">Original Facility Rating
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 416px; HEIGHT: 18px" width="416">Average 
										Collateral Coverage (%)</TD>
									<TD style="HEIGHT: 18px" width="15"></TD>
									<TD style="HEIGHT: 18px"><asp:textbox id="TXT_SB_AVGCOLL" runat="server" Width="136px" Height="19px" CssClass="angka"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 416px">LGD (%)</TD>
									<TD></TD>
									<TD><asp:textbox id="TXT_SB_AVGLGD" runat="server" Width="136px" Height="19px" CssClass="angka"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 416px">Exposure at Default (%)</TD>
									<TD></TD>
									<TD><asp:textbox id="TXT_SB_EXPOSURE" runat="server" Width="136px" Height="19px" CssClass="angka"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 416px">Expected Loss (%)</TD>
									<TD></TD>
									<TD><asp:textbox id="TXT_SB_EXPLOSS" runat="server" Width="136px" Height="19px" CssClass="angka"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 416px">Facility Rating</TD>
									<TD></TD>
									<TD><asp:dropdownlist id="DDL_SB_FACRATING" runat="server"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
							--></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
