<%@ Page language="c#" Codebehind="BookingDetail.aspx.cs" AutoEventWireup="True" Inherits="SME.CreditOperations.Booking.BookingDetail" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>BookingDetail</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
		<!-- #include file = "../../include/cek_entries.html" -->
		<!-- #include file = "../../include/onepost.html" -->
		<!-- #include  file="../../include/popup.html" -->
        <%= popUp%>
		<script language="javascript">
			function update() 
			{
				if (processing) {
					alert("Update is in progress. Please wait ...");
					return false;	
				}				
				ans = confirm("Are you sure you want to update?");
				if (ans) 
				{
					A_object = eval("document.getElementById('TXT_CU_CIF')");
					if (A_object.value == "") 
					{
						ans = confirm("CIF has not been filled in, proceed?");
					}
					if (ans) 
					{
						return true;
					}
					else 
					{
						return false;
					}
				}
				else 
				{
					return false;
				}
			}			

			function confirming() 
			{
					a_object = eval("document.getElementById('TXT_CU_CIF')");
					if (a_object.value == "") 
					{
						ans = confirm("CIF has not been filled in, proceed?");
						if (ans) 
						{
							return true;
						}
						else
						{
							return false;
						}
					}
					else {
						return true;
					}
			}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<table cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
							<TABLE id="Table2">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Booking : Detail</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right">
							<asp:ImageButton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg"></asp:ImageButton><A href="../../Body.aspx"><IMG src="/SME/Image/MainMenu.jpg"></A><A href="../../Logout.aspx" target="_top"><IMG src="/SME/Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<tr>
						<td class="tdHeader1" colSpan="2">Info Pemohon</td>
					</tr>
					<TR>
						<TD class="td" vAlign="top" width="50%" rowspan="2">
							<TABLE cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="150" style="HEIGHT: 2px">No. Aplikasi</TD>
									<TD style="HEIGHT: 2px" width="15"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 2px">
										<asp:textbox id="TXT_AP_REGNO" Runat="server" ReadOnly Columns="35" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">No. Referensi</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_CU_REF" Columns="35" ReadOnly Runat="server" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tanggal Aplikasi</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_AP_SIGNDATE" Runat="server" ReadOnly Columns="35" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Sub-Segment/Program</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_PROGRAMDESC" Runat="server" ReadOnly Columns="35" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Unit</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_BRANCH_NAME" Runat="server" ReadOnly Columns="35" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Supervisi</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_AP_TMLDRNM" Runat="server" ReadOnly Columns="35" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Analis</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_AP_RMNM" Runat="server" ReadOnly Columns="35" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Segmen</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_BU_DESC" Runat="server" ReadOnly Columns="35" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="150">Nama Pemohon</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_CU_NAME" Runat="server" ReadOnly Columns="35" Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Alamat</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_CU_ADDR1" Runat="server" ReadOnly Columns="35" Width="300px"></asp:textbox><BR>
										<asp:textbox id="TXT_CU_ADDR2" Runat="server" ReadOnly Columns="35" Width="300px"></asp:textbox><BR>
										<asp:textbox id="TXT_CU_ADDR3" Runat="server" ReadOnly Columns="35" Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Kota</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_CU_CITYNM" Runat="server" ReadOnly Columns="35" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">No. Telp</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_CU_PHN" Runat="server" ReadOnly Columns="35" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Bidang Usaha</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_BUSSTYPEDESC" Runat="server" ReadOnly Columns="35" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<tr>
						<TD class="td" vAlign="top" width="50%">
							<TABLE cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="150">CIF</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_CIF" Runat="server" Columns="35" MaxLength="20"></asp:textbox>
										<asp:label id="LBL_CU_CIF" Runat="server" Visible="False"></asp:label></TD>
								</TR>
							</TABLE>
						</TD>
					</tr>
					<tr>
						<td colSpan="2"><asp:datagrid id="Datagrid2" runat="server" Width="100%" CellPadding="1" AutoGenerateColumns="False"
								PageSize="20">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="PRODUCTID"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="APPTYPE"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="PROD_SEQ"></asp:BoundColumn>
									<asp:BoundColumn DataField="FACILITY" HeaderText="Fasilitas">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Fungsi">
										<HeaderStyle Width="10%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:radiobuttonlist id="RBL_FAC" runat="server" RepeatDirection="Horizontal">
												<asp:ListItem Value="1">Lanjut</asp:ListItem>
												<asp:ListItem Value="0">Tunda</asp:ListItem>
											</asp:radiobuttonlist>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn Visible="False" DataField="CP_CONFIRMBOOK"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="ALLOWCHG"></asp:BoundColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</asp:datagrid></td>
					</tr>
					<TR>
						<TD class="TDBGColor2" align="center" colSpan="2">
							<asp:label id="LBL_REGNO" Runat="server" Visible="False"></asp:label>
							<asp:label id="LBL_CUREF" Runat="server" Visible="False"></asp:label>
							<asp:label id="LBL_TC" Runat="server" Visible="False"></asp:label>&nbsp;
							<asp:button id="BTN_CONFIRM" Runat="server" Text="Confirm" CssClass="button1"></asp:button>&nbsp;
							<asp:button id="BTN_UNCONFIRM" Runat="server" Text="Unconfirm" CssClass="button1"></asp:button>&nbsp;
							<asp:button id="BTN_UPDATE" Runat="server" Text="Update Status" CssClass="button1" onclick="BTN_UPDATE_Click"></asp:button>&nbsp;
							<asp:button id="BTN_ACQINFO" Runat="server" Text="Kembali ke Monitoring" 
                                CssClass="button1"></asp:button>
							<asp:textbox id="TXT_TEMP" runat="server" BorderStyle="None" Width="1px"></asp:textbox>
						</TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" align="center" colSpan="2"><asp:placeholder id="SubMenu" runat="server"></asp:placeholder></TD>
					</TR>
					<tr>
						<td colspan="2" align="center">
							
							<IFRAME id="frm_content" name="frm_content" frameBorder="0" width="100%" height="700" scrolling="no"
							src="DetailBiaya.aspx?regno=<%= Request.QueryString["regno"] %>&curef=<%= Request.QueryString["curef"] %>" >
							</IFRAME>
						
						</td>
					</tr>
				</table>
			</center>
		</form>
	</body>
</HTML>
