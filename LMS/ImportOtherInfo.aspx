<%@ Register TagPrefix="uc1" TagName="GenInfo" Src="CommonGeneralInfo.ascx" %>
<%@ Page language="c#" Codebehind="ImportOtherInfo.aspx.cs" AutoEventWireup="True" Inherits="SME.LMS.ImportOtherInfo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ImportOtherInfo</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/popup.html" -->
		<!-- #include file="../include/onepost.html" -->
		<!-- #include file="../include/exportpost.html" -->
		<script language="javascript">		
		function confirmFwd()
		{
			conf = confirm("Apakah Anda yakin ingin forward ke approval?\nPastikan Anda sudah mencetak hasil scoring.");
			if (conf)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		
		// Fungsi ini sebenarnya sudah ada di include/cek_entries.html
		// tapi dipisah karena kalau pake #include file, mekanisme protection-screen jadi bermasalah
		function kutip_satu()
			{
				if ((event.keyCode == 35) || (event.keyCode == 39))
				{
					return false;
				} else
				{
					return true;
				}	
			}
		</script>
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder" style="WIDTH: 539px"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
							<TABLE id="Table2">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Import Other Info</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<TR>
						<TD colSpan="2">
							<uc1:GenInfo id="GenInfo1" runat="server"></uc1:GenInfo>
						</TD>
					</TR>
					<TR>
						<TD class="tdHeader1" style="HEIGHT: 10px" colSpan="2">Document Upload
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 540px" vAlign="top" width="540">
							<table cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="75">File</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><INPUT id="TXT_FILE_UPLOAD" style="WIDTH: 344px; HEIGHT: 19px" type="file" size="38" name="File1"
											runat="Server"></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Status</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:label id="LBL_STATUS" runat="server" ForeColor="Red"></asp:label><asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" ErrorMessage="Only xls, doc, txt or zip files are allowed!"
											ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.xls|.XLS|.doc|.DOC|.txt|.TXT|.zip|.ZIP)$" ControlToValidate="TXT_FILE_UPLOAD"></asp:regularexpressionvalidator></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"></TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:label id="LBL_STATUSREPORT" runat="server" ForeColor="Red"></asp:label></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 21px" align="center" colSpan="3"><asp:button id="BTN_UPLOAD" runat="server" Text="Upload" onclick="BTN_UPLOAD_Click"></asp:button></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="3"></TD>
								</TR>
							</table>
						</TD>
						<TD style="HEIGHT: 42px" vAlign="top">
							<TABLE cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD><ASP:DATAGRID id="DatGrid" runat="server" Width="100%" AutoGenerateColumns="False" PageSize="1"
											CellPadding="1">
											<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
											<Columns>
												<asp:BoundColumn Visible="False" DataField="LMS_REGNO" HeaderText="LMS App No"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="SEQ" HeaderText="Seq"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="FU_USERID" HeaderText="User ID"></asp:BoundColumn>
												<asp:BoundColumn DataField="FU_FILENAME" HeaderText="File Name">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												</asp:BoundColumn>
												<asp:TemplateColumn>
													<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
													<ItemTemplate>
														<asp:HyperLink id="FU_DOWNLOAD" runat="server" Target="_blank">Download</asp:HyperLink>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn>
													<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
													<ItemTemplate>
														<asp:LinkButton id="FU_DELETE" runat="server" CommandName="delete">Delete</asp:LinkButton>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:BoundColumn Visible="False" DataField="FU_URL" HeaderText="Download URL"></asp:BoundColumn>
											</Columns>
										</ASP:DATAGRID></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
