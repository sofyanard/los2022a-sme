<%@ Page language="c#" Codebehind="WorksheetReportCRP.aspx.cs" AutoEventWireup="True" Inherits="SME.ITTP.WorksheetReportCRP" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>WorksheetReportCRP</title>
		<script language="javascript">
			function print_frame() {
			//window.parent.framelkkn.focus();
			tr_print.style.display = "none";
			tr_print2.style.display = "none";
			window.print();
			tr_print.style.display = "";
			}
		</script>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_all.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="fListApp" method="post" runat="server">
			<center>
				<table id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR id="tr_print">
						<TD class="tdNoBorder" style="HEIGHT: 43px"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
							<TABLE id="Table6">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Worksheet Report</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" style="HEIGHT: 43px" align="right"><A href="ListCustomer.aspx?si="></A><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</TR>
					<TR id="tr_print2">
						<TD style="WIDTH: 178px" align="center"></TD>
						<TD style="WIDTH: 655px" align="center" colSpan="2"><INPUT class="Button1" id="BTN_PRINT" style="WIDTH: 75px" onclick="print_frame(); window.close();"
								type="button" value="Print" name="BTN_PRINT" runat="server">&nbsp;<INPUT class="Button1" id="BTN_BACK" style="WIDTH: 75px" onclick="javascript:history.back();"
								type="button" value="Back" name="BTN_BACK"></TD>
					</TR>
				</table>
				<table width="70%">
					<TR>
						<TD class="tdHeader1">Customer Risk Profile Worksheet
						</TD>
					</TR>
					<TR>
						<TD>Print Date :
							<asp:label id="print_date" runat="server" Width="88px">print_date</asp:label><asp:label id="LBL_AP_REGNO" runat="server" Width="88px">LBL_AP_REGNO</asp:label><asp:label id="LBL_CUREF" runat="server" Width="88px">LBL_CUREF</asp:label><asp:label id="LBL_TRACK" runat="server" Width="88px">LBL_TRACK</asp:label></TD>
					</TR>
				</table>
				<table width="70%">
					<TR>
						<TD align="center" width="5%" bgColor="lightblue">1</TD>
						<TD colSpan="3">Customer Information
						</TD>
					</TR>
					<TR>
						<TD bgColor="lightblue"></TD>
						<TD width="20%">CIF Number
						</TD>
						<TD width="1%">:</TD>
						<TD><asp:textbox id="TXT_CU_CIF" runat="server" Width="200px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
					</TR>
					<TR>
						<TD bgColor="lightblue"></TD>
						<TD width="20%">Customer Name</TD>
						<TD width="1%">:</TD>
						<TD><asp:textbox id="TXT_NAME" runat="server" Width="200px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
					</TR>
					<TR>
						<TD bgColor="lightblue"></TD>
						<TD width="20%">ID Type</TD>
						<TD width="1%">:</TD>
						<TD><asp:textbox id="TXT_IDDESC" runat="server" Width="200px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
					</TR>
					<TR>
						<TD bgColor="#add8e6"></TD>
						<TD width="20%">No ID</TD>
						<TD width="1%"></TD>
						<TD><asp:textbox id="TXT_IDNO" runat="server" Width="200px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
					</TR>
					<TR>
						<TD bgColor="lightblue"></TD>
						<TD width="20%">Address</TD>
						<TD width="1%">:</TD>
						<TD><asp:textbox id="TXT_ADDR" runat="server" Width="200px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
					</TR>
					<TR>
						<TD bgColor="lightblue"></TD>
						<TD width="20%">Approval By</TD>
						<TD width="1%">:</TD>
						<TD><asp:textbox id="TXT_APRV" runat="server" Width="200px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
					</TR>
					<TR>
						<TD bgColor="lightblue"></TD>
						<TD width="20%">RM/PIC</TD>
						<TD width="1%">:</TD>
						<TD><asp:textbox id="AP_RELMNGR" runat="server" Width="200px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="center" bgColor="lightblue">2</TD>
						<TD width="20%">Services Applied</TD>
						<TD width="1%">:</TD>
						<TD><asp:textbox id="Textbox6" runat="server" Width="200px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
					</TR>
					<TR>
						<TD bgColor="#add8e6"></TD>
						<TD width="20%"></TD>
						<TD width="1%"></TD>
						<TD></TD>
					</TR>
					<TR>
						<TD align="center" bgColor="lightblue">3</TD>
						<TD width="20%">Result</TD>
						<TD width="1%">:</TD>
						<TD><asp:datagrid id="dgratinghistory" runat="server" Width="500px" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="CU_REF" HeaderText="Ref #">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="AP_REGNO" HeaderText="REGNO"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="AP_SIGNDATE" HeaderText="Application Date" DataFormatString="{0:dd-MMM-yyyy}">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="KATEGORI" HeaderText="Klasifikasi">
										<HeaderStyle Width="10%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="profilrisk" HeaderText="Profil Risiko">
										<HeaderStyle Width="10%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="RISKAPPETITE" HeaderText="Risk Appetite">
										<HeaderStyle Width="10%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="KLASIFIKASIID" HeaderText="Kategori">
										<HeaderStyle Width="10%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="riskprof" HeaderText="Kategori Risk Profile Produk">
										<HeaderStyle Width="10%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="rekomendasi" HeaderText="Rekomendasi Produk">
										<HeaderStyle Width="30%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="catatan" HeaderText="Catatan">
										<HeaderStyle Width="20%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
							</asp:datagrid></TD>
					</TR>
					<TR>
						<TD bgColor="lightblue"></TD>
						<TD width="20%"></TD>
						<TD width="1%"></TD>
						<TD></TD>
					</TR>
					<TR>
						<TD align="center" bgColor="lightblue">4</TD>
						<TD width="20%">Document</TD>
						<TD width="1%">:</TD>
						<TD><ASP:DATAGRID id="DataGrid3" runat="server" Width="500px" AutoGenerateColumns="False" CellPadding="1">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="CU_REF"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="AP_REGNO" SortExpression="AP_REGNO" HeaderText="Application #">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="DOCDESC" HeaderText="Document Type">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="120px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="DOCID" HeaderText="Document ID">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AT_RECEIVEDATE" HeaderText="Receive Date">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AT_EXPDATE" HeaderText="Expired Date">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
					<TR>
						<TD bgColor="lightblue"></TD>
						<TD width="20%"></TD>
						<TD width="1%"></TD>
						<TD></TD>
					</TR>
					<TR>
						<TD align="center" bgColor="lightblue">5</TD>
						<TD colSpan="3">Remark/Special Instruction</TD>
					</TR>
					<TR>
						<TD bgColor="lightblue"></TD>
						<TD colSpan="3"><asp:textbox id="TXT_REMARK" runat="server" Width="600px" Height="46px"></asp:textbox></TD>
					</TR>
					</TD></TR></table>
				</TABLE></center>
		</form>
	</body>
</HTML>
