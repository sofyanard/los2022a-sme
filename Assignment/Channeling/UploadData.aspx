<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" > 
<%@ Page language="c#" Codebehind="UploadData.aspx.cs" AutoEventWireup="True" Inherits="SME.Assignment.Channeling.UploadData" %>
<%@ Register TagPrefix="uc1" TagName="DocumentExport" Src="../../CommonForm/DocumentExport.ascx" %>
<%@ Register TagPrefix="uc1" TagName="DocumentUpload" Src="../../CommonForm/DocumentUpload.ascx" %>
<HTML>
	<HEAD>
		<title>ListInitiation</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../../include/cek_all.html" -->
		<!-- aaa -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="fSppkMonitor" method="post" runat="server">
			<center>
				<table id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder" style="WIDTH: 805px"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
							<TABLE id="Table6">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Batch Info</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListInitiation.aspx?mc=<%=Request.QueryString["mc"]%>"></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="../../Image/back.jpg"></asp:imagebutton><A href="../../Body.aspx"><IMG src="../../Image/MainMenu.jpg"></A>
							<A href="../../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A>
						</TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">File Document</TD>
					</TR>
					<tr>
						<td style="HEIGHT: 28px" colSpan="2">
							<TABLE id="Table1" class="td" border="1" cellSpacing="1" cellPadding="1" width="100%" height="35">
								<TR>
									<TD class="tdHeader1" colSpan="7">Documents</TD>
								</TR>
								<tr>
									<TD align="center" width="48%">
										<ASP:DATAGRID id="DATA_TEMPLATE" runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="1"
											PageSize="1">
											<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
											<Columns>
												<asp:BoundColumn Visible="False" DataField="ID_TEMPLATE_CHANNELING">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="NAMA_TEMPLATE_CHANNELING" HeaderText="Source File" ItemStyle-HorizontalAlign="Center">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												</asp:BoundColumn>
												<asp:TemplateColumn>
													<HeaderStyle Width="35%" CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
													<ItemTemplate>
														<asp:HyperLink id="HL_DOWNLOAD" runat="server" Target="_blank">Download</asp:HyperLink>
													</ItemTemplate>
												</asp:TemplateColumn>
											</Columns>
										</ASP:DATAGRID>
									</TD>
									<TD align="center" width="48%">
										<ASP:DATAGRID id="DATA_EXPORT" runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="1"
											PageSize="1">
											<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
											<Columns>
												<asp:BoundColumn Visible="True" DataField="ID_UPLOAD_CHANNELING" HeaderText="No">
													<HeaderStyle CssClass="tdSmallHeader"  Width="5%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="FILE_UPLOAD_CHANNELING_NAME" HeaderText="Destination File">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:TemplateColumn>
													<HeaderStyle CssClass="tdSmallHeader" Width="15%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
													<ItemTemplate>
														<asp:HyperLink id="UPL_CHANNELING_DOWNLOAD" runat="server" Target="_blank">Download</asp:HyperLink>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn>
													<HeaderStyle CssClass="tdSmallHeader" Width="15%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
													<ItemTemplate>
														<asp:LinkButton id="UPL_CHANNELING_DELETE" runat="server" CommandName="delete">Delete</asp:LinkButton>
													</ItemTemplate>
												</asp:TemplateColumn>
											</Columns>
										</ASP:DATAGRID>
									</TD>
								</tr>
							</TABLE>
							<br>
							<table cellSpacing="0" cellPadding="0" width="50%">
								<TR>
									<TD class="TDBGColor1" width="75">File</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><INPUT style="WIDTH: 344px; HEIGHT: 19px" id="TXT_FILE_UPLOAD" size="38" type="file" name="File1"
											runat="Server"></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Status</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:label id="LBL_STATUS" runat="server" ForeColor="Red"></asp:label><asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" ControlToValidate="TXT_FILE_UPLOAD"
											ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.xls|.XLS|.doc|.DOC|.txt|.TXT|.zip|.ZIP)$" ErrorMessage="Only xls, doc, txt or zip files are allowed!"></asp:regularexpressionvalidator></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"></TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:label id="LBL_STATUSREPORT" runat="server" ForeColor="Red"></asp:label></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 21px" colSpan="3" align="center"><asp:button id="BTN_UPLOAD" runat="server" Text="Upload" onclick="BTN_UPLOAD_Click"></asp:button></TD>
								</TR>
								<TR>
									<TD colSpan="3" align="center"></TD>
								</TR>
							</table>
						</td>
					</tr>
					<TR>
						<TD class="tdHeader1" colSpan="2">Data Uploaded</TD>
					</TR>
					<tr>
						<td style="WIDTH: 50%" colSpan="2">
							<asp:datagrid id="dgListChan" runat="server" Width="100%" Height="30%" AutoGenerateColumns="False"
								AllowPaging="True" PageSize="10">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="CU_REF" HeaderText="Application #" Visible = "False">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AP_REGNO" HeaderText="Application #">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CU_NAME" HeaderText="Customer Name #">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn>
										<HeaderStyle Width="20%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="LinkButton1" runat="server" CommandName="Edit">Edit</asp:LinkButton>
											<asp:LinkButton id="Linkbutton2" runat="server" CommandName="Delete">Delete</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</asp:datagrid></td>
					</tr>
					<TR>
						<TD class="td" vAlign="top" width="50%" colSpan="2">
							<TABLE id="Table8" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD style="WIDTH: 129px">Request BI Checking
									</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue" style="WIDTH: 117px" width="117"><asp:radiobuttonlist id="RDO_BI_CHECKING" runat="server" Width="150px" RepeatDirection="Horizontal" AutoPostBack="True">
											<asp:ListItem Value="1" Selected="True">Ya</asp:ListItem>
											<asp:ListItem Value="0">Tidak</asp:ListItem>
										</asp:radiobuttonlist></TD>
									<TD class="TDBGColorValue" style="WIDTH: 304px">
										<TABLE id="Table9" cellSpacing="1" cellPadding="1" width="100%" border="0">
											<TR>
												<TD style="WIDTH: 138px"><asp:label id="LBL_CO" runat="server">Group Pelaksana :</asp:label></TD>
												<TD><asp:dropdownlist id="DDL_GRPUNIT" runat="server"></asp:dropdownlist></TD>
											</TR>
										</TABLE>
									</TD>
									<TD class="TDBGColorValue">Tanggal Terakhir Checking:
										<asp:textbox id="TXT_BS_RECVDATE" runat="server" BorderStyle="None" ReadOnly="True"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" colSpan="2"><asp:button id="BTN_SAVE" runat="server" CssClass="Button1" Width="100px" Text="Save" onclick="BTN_SAVE_Click"></asp:button></TD>
					</TR>
				</table>
			</center>
		</form>
	</body>
</HTML>
