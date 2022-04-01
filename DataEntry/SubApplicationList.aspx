<%@ Page language="c#" Codebehind="SubApplicationList.aspx.cs" AutoEventWireup="True" Inherits="SME.DataEntry.SubApplicationList" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SubApplicationList</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/popup.html" -->
		<script language="javascript">
			function batal()
			{
				conf = confirm("Are you sure you want to cancel?");
				if (conf)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder">
							<TABLE id="Table2">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Sub Application List</B>
									</TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><A href="/SME/Body.aspx"></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="../Image/back.jpg"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A>
							<A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"> </A>
						</TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<TR>
						<TD vAlign="top" align="center" colSpan="2">
							<TABLE width="100%">
								<TR>
									<TD class="tdBGColor1" style="WIDTH: 239px; HEIGHT: 20px" width="239">Ketentuan 
										kredit</TD>
									<TD style="WIDTH: 12px; HEIGHT: 20px" align="center"></TD>
									<TD style="HEIGHT: 20px" width="28%">
										<asp:DropDownList id="DDL_KETKREDIT" runat="server" AutoPostBack="True"></asp:DropDownList></TD>
									<TD style="HEIGHT: 20px" width="50%">&nbsp;</TD>
								</TR>
								<TR>
									<TD class="tdBGColor1" style="WIDTH: 239px" width="239">Product</TD>
									<TD style="WIDTH: 12px" align="center"></TD>
									<TD width="28%">
										<asp:DropDownList id="DDL_PRODLIST" runat="server" AutoPostBack="True"></asp:DropDownList></TD>
									<TD width="50%">&nbsp;</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD vAlign="top" align="center" colSpan="2"><asp:datagrid id="DGR_SUBAPP" runat="server" AllowSorting="True" Width="100%" AllowPaging="True"
								AutoGenerateColumns="False" PageSize="5">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="AP_REGNO" SortExpression="APPLICATION.AP_REGNO" HeaderText="Application No.">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="CU_REF" HeaderText="Ref #">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="NAME" SortExpression="[NAME]" HeaderText="Nama Pemohon">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" HeaderText="Tanggal Aplikasi">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" HeaderText="Nama RM">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CP_LIMIT" SortExpression="CP_LIMIT" HeaderText="Limit" DataFormatString="{0:0,00.00}">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" HeaderText="AP_CURRTRACK"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="SU_BRANCH" HeaderText="SU_BRANCH"></asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Function">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="LinkButton1" runat="server" Text="View" CausesValidation="false" CommandName="View"></asp:LinkButton>&nbsp; 
											&nbsp;
											<asp:LinkButton id="LNK_CANCEL" runat="server" Text="View" CausesValidation="false" CommandName="Cancel">Cancel</asp:LinkButton>&nbsp;
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</asp:datagrid></TD>
					</TR>
					<TR>
						<TD class="tdbgcolor2" vAlign="top" align="center" colSpan="2">&nbsp;
							<asp:label id="LBL_SORTTYPE" runat="server" Visible="False">ASC</asp:label><asp:label id="LBL_PROG_CODE" runat="server" Visible="False"></asp:label>
							<%if (Request.QueryString["de"] == "1") {%>
							<asp:button id="BTN_ADD" runat="server" Width="100px" Enabled="False" CssClass="button1" Text="Add" onclick="BTN_ADD_Click"></asp:button>
							<% } %>
							<asp:label id="LBL_SORTEXP" runat="server" Visible="False">APPLICATION.AP_REGNO</asp:label>
							<asp:label id="LBL_AP_RELMNGR" runat="server" Visible="False"></asp:label></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
