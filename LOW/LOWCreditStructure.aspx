<%@ Page language="c#" Codebehind="LOWCreditStructure.aspx.cs" AutoEventWireup="True" Inherits="SME.LOW.LOWCreditStructure" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" > 

<html>
  <head>
    <title>LOWCreditStructure</title>
    <meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" Content="C#">
    <meta name=vs_defaultClientScript content="JavaScript">
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/popup.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout" topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table2" cellSpacing="2" cellPadding="2" width="100%">
				
				<!-- <%if (Request.QueryString["sta"] != "view"){%> -->
				
				<TR>
					<TD class="tdNoBorder" style="WIDTH: 421px"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
						<TABLE id="Table3">
							<TR>
								<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Detail Data Entry : 
										Credit Structure</B></TD>
							</TR>
						</TABLE>
					</TD>
					<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A>
						<asp:ImageButton id="BTN_BACK" runat="server" ImageUrl="../Image/back.jpg"></asp:ImageButton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
				</TR>
				<TR>
					<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
				</TR>
				
				<%}%>
				
				<TR>
					<TD class="tdHeader1" colSpan="2">Credit Structure</TD>
				</TR>
				<TR>
					<TD colSpan="2" class="td">
						<TABLE id="Table5" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR>
								<TD>
									<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="100%" border="0">
										<TR>
											<TD class="tdbgcolor1">Ketentuan Kredit</TD>
											<TD>:</TD>
											<TD>
												<asp:DropDownList id="DDL_KETENTUAN_KREDIT" runat="server" AutoPostBack="True"></asp:DropDownList></TD>
										</TR>
										<TR>
											<TD class="tdbgcolor1">AA No.</TD>
											<TD>:</TD>
											<TD>
												<asp:Label id="LBL_AA_NO" runat="server"></asp:Label></TD>
										</TR>
										<TR>
											<TD class="tdbgcolor1">No Rekening</TD>
											<TD>:</TD>
											<TD>
												<asp:Label id="LBL_ACC_NO" runat="server"></asp:Label></TD>
										</TR>
										<TR>
											<TD class="tdbgcolor1">Facility Code</TD>
											<TD>:</TD>
											<TD>
												<asp:Label id="LBL_PRODUCTID" runat="server"></asp:Label></TD>
										</TR>
										<TR>
											<TD class="tdbgcolor1">Seq</TD>
											<TD>:</TD>
											<TD>
												<asp:Label id="LBL_ACC_SEQ" runat="server"></asp:Label></TD>
										</TR>
										<TR>
											<TD class="tdbgcolor1">Earmark Amount (Rp)</TD>
											<TD>:</TD>
											<TD>
												<asp:Label id="LBL_EARMARK_AMOUNT" runat="server"></asp:Label>
												<asp:Button id="BTN_REFRESH" runat="server" Text="Refresh" Visible="False"></asp:Button></TD>
										</TR>
										<TR>
											<TD></TD>
											<TD></TD>
											<TD></TD>
										</TR>
									</TABLE>
								</TD>
								<TD>
									<TABLE id="Table6" cellSpacing="1" cellPadding="1" width="100%" border="0">
										<TR>
											<TD colspan="3">Earmark by Project</TD>
										</TR>
										<TR>
											<TD class="tdbgcolor1">Project</TD>
											<TD>:</TD>
											<TD>
												<asp:DropDownList id="ddl_PRJ_CODE" runat="server" Width="150px"></asp:DropDownList>
												<asp:Button id="btn_Save" runat="server" Visible="False" Text="Save"></asp:Button>
												<asp:Label id="LBL_PRJ_CODE" runat="server" Visible="False"></asp:Label></TD>
										</TR>
										<TR>
											<TD>Earmark by Facility</TD>
											<TD></TD>
											<TD></TD>
										</TR>
										<TR>
											<TD class="tdbgcolor1">Company</TD>
											<TD>:</TD>
											<TD>
												<asp:Label id="LBL_CUREF_CHANN" runat="server"></asp:Label></TD>
										</TR>
										<TR>
											<TD class="tdbgcolor1">Remaining eMAS Limit</TD>
											<TD>:</TD>
											<TD>
												<asp:Label id="LBL_REMAIN_EMAS_LIMIT" runat="server"></asp:Label></TD>
										</TR>
										<TR>
											<TD class="tdbgcolor1">Pending Accept Limit</TD>
											<TD>:</TD>
											<TD>
												<asp:Label id="LBL_PENDING_ACCEPT_LIMIT" runat="server"></asp:Label></TD>
										</TR>
										<TR>
											<TD class="tdbgcolor1">Unutilized Limit</TD>
											<TD>:</TD>
											<TD>
												<asp:Label id="LBL_UNUTILIZED_LIMIT" runat="server"></asp:Label></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
						&nbsp;&nbsp;
						<asp:TextBox id="TXT_NEGATIVE" runat="server" Visible="False">NO</asp:TextBox>
						
						<% if (Request.QueryString["de"] == "1") { %>
						
						<TABLE id="Table7" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR>
								<TD>
									<asp:Button id="BTN_PROJECTLIST" runat="server" Visible="False" Text="View Project List"></asp:Button>&nbsp;
									<INPUT type="button" size="10" value="View Project List" onclick="javascript:PopupPage('../ProjectInfo.aspx?targetFormID=Form1', '800','600');">&nbsp;
									<asp:Button id="BTN_REEARMARK" runat="server" Text="Re-Earmark" Visible="True"></asp:Button>&nbsp;</TD>
							</TR>
							<TR id="tr_confirm_negative" runat="server">
								<TD>
									<asp:Label id="Label1" runat="server" ForeColor="Red" Font-Bold="True">Hasil earmarking akan negatif. Lanjutkan ?</asp:Label>&nbsp;
									<asp:Button id="BTN_NEGATIVE_OK" runat="server" Text="Yes" Width="75px"></asp:Button>&nbsp;
									<asp:Button id="BTN_NEGATIVE_CANCEL" runat="server" Text="No" Width="75px"></asp:Button></TD>
							</TR>
						</TABLE>
						
						<% } %>
						
					</TD>
				</TR>
				<TR>
					<td vAlign="top" width="100%" colSpan="2">
						<asp:Table id="Table1" runat="server" ForeColor="Black" Width="100%" CellPadding="0" CellSpacing="0"
							BorderColor="White" BorderStyle="Dotted" BorderWidth="1px" GridLines="Both">
							<asp:TableRow>
								<asp:TableCell Width="2%"></asp:TableCell>
								<asp:TableCell Width="31%"></asp:TableCell>
								<asp:TableCell Width="2%"></asp:TableCell>
								<asp:TableCell Width="31%"></asp:TableCell>
								<asp:TableCell Width="2%"></asp:TableCell>
								<asp:TableCell Width="32%"></asp:TableCell>
							</asp:TableRow>
						</asp:Table><BR>
					</td>
				</TR>
				<TR id="TR_COLL" runat="server">
					<TD vAlign="top" width="100%" colSpan="2">
						
						<iframe id="IF_COLL" src="CustProductColl.aspx?regno=<%=Request.QueryString["regno"]%>&ket_code=<%=DDL_KETENTUAN_KREDIT.SelectedValue%>&curef=<%=Request.QueryString["curef"]%>&de=<%=Request.QueryString["de"]%>" scrolling=auto width="100%" height="300" frameborder=no>
						</iframe>
						
					</TD>
				</TR>
				<tr>
					<td width="100%" colspan="2"><iframe id="ProdDetail" name="ProdDetail" tabIndex="0" frameBorder="no" width="100%" height="950"
							scrolling="auto"></iframe>
					</td>
				</tr>
			</TABLE>
		</form>
	</body>
</HTML>
