<%@ Page language="c#" Codebehind="ListAssignment.aspx.cs" AutoEventWireup="True" Inherits="SME.CreditOperation.ListAssignment" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Credit Operations List</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table4" width="100%" border="0">
					<TR>
						<TD class="tdNoBorder"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
							<TABLE id="Table2">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Assignment List</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD colSpan="2"><STRONG>Find Application&nbsp;&nbsp; :&nbsp;
								<asp:textbox id="TXT_AP_REGNO" runat="server"></asp:textbox>&nbsp;
								<asp:button id="BtnFind" runat="server" Text="Cari"></asp:button>&nbsp;</STRONG></TD>
					</TR>
					<TR>
						<TD colSpan="2"><ASP:DATAGRID id="DatGrd" runat="server" CellPadding="1" Width="100%" PageSize="1" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="AP_REGNO" HeaderText="Application No.">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="120px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="CU_REF" HeaderText="CU_REF"></asp:BoundColumn>
									<asp:BoundColumn DataField="CU_NAME" HeaderText="Nama Pemohon">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AP_SIGNDATE" HeaderText="Tanggal Aplikasi" DataFormatString="{0:dd-MMM-yyyy}">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="150px"></ItemStyle>
									</asp:BoundColumn>
									<asp:ButtonColumn Text="Lihat" CommandName="View">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
									</asp:ButtonColumn>
									<asp:BoundColumn Visible="False" DataField="AP_APPRSTATUS" HeaderText="AP_APPRSTATUS"></asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Status Penilaian">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="90px"></ItemStyle>
										<ItemTemplate>
											<asp:Image id="IMG_LA_APPRSTATUS" runat="server"></asp:Image>
											<asp:Label id="LBL_LA_APPRSTATUS" runat="server"></asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn Visible="False" DataField="CHECKBI" HeaderText="CHECKBI"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="BS_COMPLETE" HeaderText="BS_COMPLETE">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Status IDI BI">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="90px"></ItemStyle>
										<ItemTemplate>
											<asp:Image id="IMG_BS_COMPLETE" runat="server"></asp:Image>
											<asp:Label id="LBL_BS_COMPLETE" runat="server"></asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn>
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="90px"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="LB_UPDATESTATUS" runat="server" Text="Update Status" CommandName="UpdateStatus"
												CausesValidation="false">Update Status</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</ASP:DATAGRID></TD>
					</TR>
					</TABLE>
			</center>
		</form>
	</body>
</HTML>
