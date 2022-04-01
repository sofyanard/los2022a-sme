<%@ Page language="c#" Codebehind="InfoCollateral.aspx.cs" AutoEventWireup="True" Inherits="SME.CustomerInfo.InfoCollateral" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>InfoCollateral</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function cek()
		{
			persen = parseInt(document.Form1.TXT_CL_PERCENT.value);
			if (isNaN(persen))
				persen = 0;
			if (persen>100)
			{
				alert("persen tidak boleh lebih dari 100%");
				document.Form1.TXT_CL_PERCENT.value	= 0;
			}
				
		}
		function keluar()
		{
			if (confirm("Are you sure want to finish ?"))
				document.Fmain.submit();
		}
		</script>
		<!-- #include  file="../include/cek_entries.html" -->
		<!-- #include  file="../include/cek_mandatoryOnly.html" -->
  </HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<center>
			<form id="Fmain" name="Fmain" action="SearchCustomer.aspx?mc=030" method="post" target="main">
			</form>
			<form id="Form1" name="Form1" method="post" runat="server">
				<center>
					<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
						<TR>
							<TD class="td" vAlign="top" width="50%">
								<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="TDBGColor1">AA No.</TD>
										<TD></TD>
										<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_AI_AA_NO" runat="server" AutoPostBack="True" CssClass="mandatory" onselectedindexchanged="DDL_AI_AA_NO_SelectedIndexChanged"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Kode / No. Fasilitas</TD>
										<TD></TD>
										<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_AI_FACILITY" runat="server" AutoPostBack="True" CssClass="mandatory" onselectedindexchanged="DDL_AI_FACILITY_SelectedIndexChanged"></asp:dropdownlist>&nbsp;
											<asp:dropdownlist id="DDL_ACC_SEQ" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Jaminan</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_STATUS" runat="server" Visible="False"
												Width="24px">insert</asp:textbox><asp:dropdownlist id="DDL_CL_SEQ" runat="server" AutoPostBack="True" CssClass="mandatory" onselectedindexchanged="DDL_CL_SEQ_SelectedIndexChanged"></asp:dropdownlist></TD>
									</TR>
								</TABLE>
							</TD>
							<TD class="td" vAlign="top">
								<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
									<!--<TR>
										<TD class="TDBGColor1" id="TDHIDE">Persen</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CL_PERCENT" runat="server" CssClass="mandatory"
												onkeyup="cek()" MaxLength="20" Width="48px" AutoPostBack="True"></asp:textbox>%</TD>
									</TR>-->
									<TR>
										<TD class="TDBGColor1" style="HEIGHT: 21px">Nilai</TD>
										<TD style="HEIGHT: 21px"></TD>
										<TD class="TDBGColorValue" style="HEIGHT: 21px"><asp:dropdownlist id="DDL_CURR" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CL_VALUE" runat="server" CssClass="mandatory"
												MaxLength="15" Width="200px"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Core Collateral ID</TD>
										<TD></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_SIBS_COLID" runat="server" CssClass="mandatory"
												Width="200px" MaxLength="35" ReadOnly="True"></asp:textbox></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD class="TDBGColor2" vAlign="top" align="center" colSpan="2"><asp:button id="BTN_SAVE" runat="server" CssClass="Button1" Width="75px" Text="Save" onclick="BTN_SAVE_Click"></asp:button>&nbsp;<asp:button id="Button1" runat="server" CssClass="Button1" Width="75px" Text="Cancel" onclick="Button1_Click"></asp:button>&nbsp;<INPUT class="Button1" onclick="keluar()" type="button" value="Finish" style="WIDTH: 75px" disabled></TD>
						</TR>
						<TR>
							<TD class="td" vAlign="top" align="center" colSpan="2"><ASP:DATAGRID id="DatGrd" runat="server" Width="100%" HorizontalAlign="Center" PageSize="3" AllowPaging="True"
									AutoGenerateColumns="False" CellPadding="1">
									<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
									<Columns>
										<asp:BoundColumn DataField="AA_NO" HeaderText="AA No.">
											<HeaderStyle Width="5%" CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="PRODUCTID" HeaderText="No. Fasilitas">
											<HeaderStyle Width="8%" CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="acc_seq" HeaderText="Sequence">
											<HeaderStyle Width="8%" CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn Visible="False" DataField="acc_no" HeaderText="No. Rekening">
											<HeaderStyle Width="10%" CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="cl_desc" HeaderText="Jaminan">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn Visible="False" DataField="cl_percent" HeaderText="Persen">
											<HeaderStyle Width="10%" CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Right"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="currencyid" HeaderText="Currency">
											<HeaderStyle Width="5%" CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="cl_value" HeaderText="Nilai" DataFormatString="{0:0,00.00}">
											<HeaderStyle Width="10%" CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Right"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="sibs_colid" HeaderText="Core Collateral ID">
											<HeaderStyle Width="10%" CssClass="tdSmallHeader"></HeaderStyle>
										</asp:BoundColumn>
										<asp:ButtonColumn Text="" CommandName="Edit">
											<HeaderStyle Width="5%" CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:ButtonColumn>
										<asp:ButtonColumn Text="" CommandName="Delete">
											<HeaderStyle Width="5%" CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:ButtonColumn>
										<asp:BoundColumn Visible="False" DataField="cl_seq" HeaderText="cl_seq"></asp:BoundColumn>
										<asp:BoundColumn Visible="False" DataField="coltypedesc" HeaderText="cl_type"></asp:BoundColumn>
									</Columns>
									<PagerStyle Mode="NumericPages"></PagerStyle>
								</ASP:DATAGRID></TD>
						</TR>
					</TABLE>
				</center>
			</form>
		</center>
	</body>
</HTML>
