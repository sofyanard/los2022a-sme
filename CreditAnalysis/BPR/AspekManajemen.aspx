<%@ Page language="c#" Codebehind="AspekManajemen.aspx.cs" AutoEventWireup="True" Inherits="SME.CreditAnalysis.BPR.AspekManajemen" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AspekManajemen</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder"><!--<img src="../Image/HeaderDetailDataEntry.jpg">--></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="left" colSpan="2">
							<TABLE id="Table2">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 250px" align="center"><B>Credit Analysis : Aspek 
											Manajemen</B></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">
							ASPEK MANAJEMEN</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="50%">
							<asp:TextBox id="TXT_CA_MANAJEMEN" runat="server" TextMode="MultiLine" Rows="25" Columns="125"></asp:TextBox>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2"><asp:button id="BTN_SAVE" runat="server" CssClass="Button1" Text="Save" onclick="BTN_SAVE_Click"></asp:button>&nbsp;</TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
