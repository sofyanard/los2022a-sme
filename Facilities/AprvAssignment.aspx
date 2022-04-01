<%@ Page language="c#" Codebehind="AprvAssignment.aspx.cs" AutoEventWireup="True" Inherits="SME.Facilities.AprvAssignment" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ApprovalAssignment</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_entries.html" -->
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<table id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<tr>
						<td class="tdNoBorder"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
							<table id="Table4">
								<tr>
									<td class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Approval Assignment</B></td>
								</tr>
							</table>
						</td>
						<td class="tdNoBorder" align="right"><A href="AprvFindCustomer.aspx?mc=061"><img src="../Image/back.jpg"></A><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></td>
					</tr>
					<tr>
						<td class="tdHeader1" vAlign="top" width="50%" colspan="2">Assign Application</td>
					</tr>
					<tr>
						<td class="td" vAlign="top" width="50%" colspan="2">
							<table id="Table3" cellSpacing="0" cellPadding="0" width="944" style="WIDTH: 944px; HEIGHT: 100px">
								<tr>
									<td class="TDBGColor1" style="WIDTH: 146px">Application No</td>
									<td style="WIDTH: 19px"></td>
									<td class="TDBGColorValue"><asp:textbox id="txt_regno" runat="server" ReadOnly="True" MaxLength="20"></asp:textbox></td>
								</tr>
								<tr>
									<td class="TDBGColor1" style="WIDTH: 146px">Unit</td>
									<td style="WIDTH: 19px"></td>
									<td class="TDBGColorValue">
										<asp:textbox id="txt_branch" runat="server" Width="296px" ReadOnly="True" MaxLength="100"></asp:textbox>
										<asp:textbox id="txt_branchcode" runat="server" Visible="False" Width="29px"></asp:textbox>
									</td>
								</tr>
								<tr>
									<td class="TDBGColor1" style="WIDTH: 146px">Current Track</td>
									<td style="WIDTH: 19px"></td>
									<td class="TDBGColorValue">
										<asp:textbox id="txt_currtrack" runat="server" ReadOnly="True" Width="502px" MaxLength="100"></asp:textbox>
										<asp:textbox id="txt_trackcode" runat="server" Visible="False" Width="23px"></asp:textbox>
									</td>
								</tr>
								<tr>
									<td class="TDBGColor1" style="WIDTH: 146px">Current Approval</td>
									<td style="WIDTH: 19px"></td>
									<td class="TDBGColorValue">
										<asp:textbox id="txt_currAprv" runat="server" Width="225px" ReadOnly="True" MaxLength="100"></asp:textbox>
										<asp:textbox id="txt_aprvcode" runat="server" Visible="False" Width="25px"></asp:textbox>
									</td>
								</tr>
								<tr>
									<td class="TDBGColor1" style="WIDTH: 146px">Assign To</td>
									<td style="WIDTH: 19px"></td>
									<td class="TDBGColorValue"><asp:dropdownlist id="ddl_assignto" runat="server"></asp:dropdownlist></td>
								</tr>
							</table>
						</td>
					</tr>
					<TR>
						<TD class="td" vAlign="top" align="center" width="50%" colspan="2">
							<asp:button id="btn_assign" runat="server" Width="125px" Text="Assign" onclick="btn_assign_Click"></asp:button></TD>
					</TR>
				</table>
			</center>
		</form>
	</body>
</HTML>
