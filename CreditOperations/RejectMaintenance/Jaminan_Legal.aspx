<%@ Page language="c#" Codebehind="Jaminan_Legal.aspx.cs" AutoEventWireup="True" Inherits="SME.CreditOperations.RejectMaintenance.Jaminan_Legal" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Jaminan_Legal</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE cellSpacing="0" cellPadding="0" width="100%">
					<tr>
						<td class="tdHeader1"><B>Jenis Pengikatan Jaminan</B></td>
					</tr>
					<tr>
						<td>
							<TABLE cellSpacing="2" cellPadding="2" width="100%">
								<tr>
									<td class="td" vAlign="top" width="50%">
										<TABLE cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<td class="TDBGColor1" width="150">Jenis Pengikatan</td>
												<td width="15"></td>
												<td class="TDBGColorValue"><asp:dropdownlist id="DDL_CL_IKATTYPE" Runat="server"></asp:dropdownlist></td>
											</tr>
										</TABLE>
										<asp:label id="LBL_CUREF" Runat="server" Visible="False"></asp:label>
										<asp:label id="LBL_CL_SEQ" Runat="server" Visible="False"></asp:label>
										<asp:label id="LBL_REGNO" Runat="server" Visible="False"></asp:label>
									</td>
									<td class="td" vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<td class="TDBGColor1" width="150">Collateral Mortgage</td>
												<td width="15"></td>
												<td class="TDBGColorValue">
													<asp:RadioButtonList id="RBL_LEGALSTACOL" runat="server"></asp:RadioButtonList></td>
											</tr>
										</TABLE>
									</td>
								</tr>
							</TABLE>
						</td>
					</tr>
					<TR>
						<TD class="TDBGColor2" align="center"><asp:button id="BTN_SAVE_JAMINAN" Runat="server" CssClass="button1" Text="Save" onclick="BTN_SAVE_JAMINAN_Click"></asp:button></TD>
					</TR>
					<tr>
						<td class="tdHeader1"><B>Jaminan Detail</B></td>
					</tr>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
