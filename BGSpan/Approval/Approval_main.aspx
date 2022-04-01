<%@ Page language="c#" Codebehind="Approval_main.aspx.cs" AutoEventWireup="True" Inherits="SME.BGSpan.Approval.Approval_main" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Approval Main</title>
		<META content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY>
		<form id="Form1" method="post" runat="server">
			<center>
				<table id="Table1" cellSpacing="0" cellPadding="0" width="100%">
					<tr>
						<td style="WIDTH: 495px">
							<TABLE id="Table4">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Approval</B></TD>
								</TR>
							</TABLE>
						</td>
						<td class="tdNoBorder" align="right"><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="../../Image/back.jpg"></asp:imagebutton><A href=".../../Body.aspx"><IMG src="../../Image/MainMenu.jpg"></A><A href="../../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A></td>
					</tr>
					<tr>
						<td class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></td>
					</tr>
					<tr>
						<td class="tdHeader1" width="50%" colSpan="2">Customer Info</td>
					</tr>
				</table>
					<table id="Table2" cellSpacing="0" cellPadding="0" width="100%">
					<tr>
						<td align="center">
						<iframe id=if1 style="WIDTH: 100%; HEIGHT: 185px" name=if1 src="/SME/BGSpan/appinfo.aspx?regno=<%=Request.QueryString["regno"]%>&amp;curef=<%=Request.QueryString["curef"]%>&amp;sta=view" scrolling=no> </iframe>
						</td>
					</tr>
				</table>
				<TR id="TR_INFO_CRM" runat="server">
					<TD vAlign="top" width="100%">
						<TABLE id="Table9" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR>
								<TD class="tdheader1">Transaction Info</TD>
							</TR>
							<TR>
								<TD><asp:textbox id="txt_acqinfo" Height="150" TextMode="MultiLine" ReadOnly="True" Runat="server"
										Width="100%"></asp:textbox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				</TABLE>
				<table id="Table3" cellSpacing="2" cellPadding="2" width="100%">
					<tr>
						<td vAlign="top"><asp:table id="tbl_prod" runat="server" Width="100%" CellPadding="0" CellSpacing="0" CssClass="BackGroundList"></asp:table><br>
							<br>
							&nbsp;
							<BR>
						</td>
						<td align="right"><iframe id="if2" style="WIDTH: 800px; HEIGHT: 300px" name="if2" src="" frameBorder="no"
								scrolling="auto"></iframe>
						</td>
					</tr>
				</table>
				<TABLE id="Table5" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdHeader1" width="50%" colSpan="2">Limit Exposure</TD>
					</TR>
				</TABLE>
				<TABLE id="Table6" cellSpacing="2" cellPadding="2" width="100%">
					<tr>
						<td class="TDBGColor1" style="WIDTH: 135px" align="right">Limit Rp.</td>
						<td style="WIDTH: 12px">:</td>
						<td class="TDBGColor1" style="WIDTH: 122px"><asp:label id="lbl_limexp" Runat="server"></asp:label></td>
						<td style="WIDTH: 110px"></td>
						<td class="TDBGColor1" style="WIDTH: 136px">Apply Value Rp.</td>
						<td style="WIDTH: 12px">:</td>
						<td class="TDBGColor1" style="WIDTH: 112px" align="right"><asp:label id="lbl_reqlim" Runat="server"></asp:label></td>
						<td></td>
					</tr>
				</TABLE>
				<table id="Table7" cellSpacing="2" cellPadding="2" width="100%">
				</table>
				<table id="Table8" cellSpacing="2" cellPadding="2" width="100%">
					<tr>
						<td class="tdHeader1" style="WIDTH: 910px; HEIGHT: 14px" vAlign="top">Check for 
							Approve
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 910px; HEIGHT: 27px" vAlign="top"><asp:checkboxlist id="cbl_prod" Height="12px" Runat="server" Width="278px"></asp:checkboxlist><asp:checkboxlist id="cbl_prodrej" Height="12px" Runat="server" Width="936px"></asp:checkboxlist></td>
					</tr>
					<tr>
						<td class="tdHeader1" style="WIDTH: 910px" vAlign="top"><STRONG>Decision</STRONG></td>
					</tr>
					<tr>
					</tr>
				</table>
				<table>
					<tr id="tr_approve" runat="server">
						<td class="TDBGColor1" style="WIDTH: 154px" vAlign="top"><asp:label id="lbl_aprvwith" Runat="server">Approve With</asp:label></td>
						<td style="WIDTH: 387px" vAlign="top"><asp:textbox id="txt_aprvwith" runat="server" Width="392px"></asp:textbox></td>
						<td style="WIDTH: 423px" vAlign="top"><asp:button id="btn_aprvrej" Runat="server" Width="155px" CssClass="button1" Text="Approve"></asp:button>&nbsp;&nbsp;
							<STRONG></STRONG>
							<asp:label id="LBL_APRV_ROUTING" runat="server" Font-Bold="True" ForeColor="Blue"></asp:label></td>
					</tr>
					<tr id="tr_reject" runat="server">
						<td class="TDBGColor1" style="WIDTH: 154px" vAlign="top"><asp:label id="lbl_rejreason" Runat="server">Reject Reason</asp:label></td>
						<td style="WIDTH: 406px" vAlign="top"><asp:dropdownlist id="ddl_rjreason" Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return kutip_satu()" id="txt_rjreason" runat="server" Width="104px"
								MaxLength="250" Columns="250"></asp:textbox></td>
						<td style="WIDTH: 423px" vAlign="top"><asp:button id="btn_reject" Runat="server" Width="155" CssClass="button1" Text="Reject"></asp:button><asp:textbox id="TXT_VERIFY" runat="server" ReadOnly="True" Width="1px" BorderStyle="None"></asp:textbox></td>
					</tr>
					<tr align="center">
						<td colSpan="3"><asp:button id="btn_info" Runat="server" CssClass="button1" Text="Acquire Information"></asp:button><asp:button id="btn_decision" Runat="server" CssClass="button1" Text="Decisions History"></asp:button><asp:textbox id="TXT_TEMP" runat="server" ReadOnly="True" Width="1px" BorderStyle="None"></asp:textbox></td>
					</tr>
				</table>
			</center>
		</form>
	</BODY>
</HTML>
