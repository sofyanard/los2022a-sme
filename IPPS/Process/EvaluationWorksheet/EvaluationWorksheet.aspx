<%@ Page language="c#" Codebehind="EvaluationWorksheet.aspx.cs" AutoEventWireup="True" Inherits="SME.IPPS.Process.EvaluationWorksheet.EvaluationWorksheet" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>EvaluationWorksheet</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY MS_POSITIONING="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<CENTER>
				<TABLE width="100%" border="0">
					<TR>
						<TD align="left" width="50%">
							<TABLE id="Table1">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Evaluation Worksheet</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="/sme/Body.aspx"><IMG src="/sme/Image/MainMenu.jpg"></A>
							<A href="/sme/Logout.aspx" target="_top"><IMG src="/sme/Image/Logout.jpg"></A>
						</TD>
					</TR>
				</TABLE>
				<TABLE width="100%" align="center" border="0">
					<tr>
						<TD class="tdHeader1">Upload Info</TD>
					</tr>
					<TR>
						<TD class="td" vAlign="top" align="center" width="50%" colSpan="2"><asp:datagrid id="dg_upload_info" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="SEQ" Visible="False">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="No" HeaderText="No.">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="jenis_peraturan" HeaderText="Jenis Peraturan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="judul_peraturan" HeaderText="Judul Peraturan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="tgl_upload" HeaderText="Tanggal Upload">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="remarks" HeaderText="Remark">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</asp:datagrid></TD>
					</TR>
				</TABLE>
				<TABLE width="100%" align="center" border="0">
					<tr>
						<TD class="tdHeader1">Action Plan</TD>
					</tr>
					<TR>
						<TD class="td" vAlign="top" align="center" width="50%" colSpan="2"><asp:datagrid id="dg_action_plan" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="SEQ" Visible="False">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="No" HeaderText="No.">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Policy" HeaderText="Policy">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="next_review_date" HeaderText="Next Review Date">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="remarks" HeaderText="Remark">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Function">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="link_edit" runat="server" CommandName="edit">Edit</asp:LinkButton>
											<asp:LinkButton id="link_delete" runat="server" CommandName="delete">Delete</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</asp:datagrid></TD>
					</TR>
				</TABLE>
				<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
					<tr>
						<td width="50%" border="0">
							<table id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TBODY>
									<TR>
										<TD class="TDBGColor1" style="HEIGHT: 10px" width="40%">Policy&nbsp;:</TD>
										<TD class="TDBGColorValue" style="HEIGHT: 10px" width="60%">
											<asp:dropdownlist id="ddl_policy" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="HEIGHT: 7px" width="40%">Next Review Date&nbsp;:</TD>
										<TD class="TDBGColorValue" style="HEIGHT: 7px" width="60%">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_DAY" runat="server" Width="24px" Columns="4"
												MaxLength="2"></asp:textbox>
											<asp:dropdownlist id="DDL_MONTH" runat="server"></asp:dropdownlist>
											<asp:textbox onkeypress="return numbersonly()" id="TXT_YEAR" runat="server" Width="36px" Columns="4"
												MaxLength="4"></asp:textbox>
										</TD>
									</TR>
								</TBODY>
							</table>
						</td>
						<td width="50%" border="0">
							<table id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TBODY>
									<TR>
										<TD class="TDBGColor1" style="HEIGHT: 10px" width="40%">Remark&nbsp;:</TD>
										<TD valign="top" rowspan="2" class="TDBGColorValue" style="HEIGHT: 10px" width="60%">
											<asp:textbox id="txt_remark" Runat="server" Width="100%" TextMode="MultiLine"></asp:textbox></TD>
									</TR>
									<tr>
										<td></td>
									</tr>
								</TBODY>
							</table>
						</td>
					</tr>
				</TABLE>
				<BR>
				<table id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TBODY>
						<TR>
							<TD align="right" width="50%">
							<asp:button id="btn_insert" runat="server" Text="Insert" CssClass="button1"></asp:button></TD>
							<td align="left" width="50%">
								<asp:button id="btn_clear" runat="server" Text="Clear" CssClass="button1"></asp:button>&nbsp;&nbsp;</td>
						</TR>
					</TBODY>
				</table>
				<BR>
				<table id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TBODY>
						<TR>
							<TD align="center" width="100%" class="TDBGColor2">
							<asp:button id="btn_update_status" runat="server" Text="Update Status" CssClass="button1"></asp:button></TD>
						</TR>
					</TBODY>
				</table>
			</CENTER>
		</FORM>
	</BODY>
</HTML>
