<%@ Page language="c#" Codebehind="MainPRRK.aspx.cs" AutoEventWireup="True" Inherits="SME.PRRK.MainPRRK" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PRRK/CRA</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_entries.html" -->
		<!-- #include file="../include/popup.html" -->
		<!-- #include file="../include/onepost.html" -->
		<!-- #include file="../include/ConfirmBox.html" -->
		<!-- #include file="../include/exportpost.html" -->
        <%= popUp%>
		<script language="javascript">
			/**
			function update()
			{
				conf = confirm("Are you sure you want to update?");
				if (conf)
				{
					return true;
				}
				else
				{
					return false;
				}
			}**/

			function update1()
			{
				if (processing) {
					alert("Forward is in progress. Please wait ...");
					return false;
				}
				
				conf = confirm("Are you sure you want to forward?");
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
		<script language="vbscript">
			function CekTombol()
				set obj = document.Form1
				if obj.CB_FORWARD.checked then
					obj.DDL_USERID.disabled		= false
					obj.BtnFoward.style.display	= ""
					obj.updatestatus.style.display	= "none"
				else
					obj.DDL_USERID.disabled = true
					obj.BtnFoward.style.display		= "none"
					obj.updatestatus.style.display	= ""
				end if
			end function
		</script>
        <!---->
        <script language="javascript">
            var popupWindow = null;
            function PopupPage(href, width, height) {
                if (popupWindow != null) return;
                var X = (screen.width - width) / 2;
                var Y = (screen.height - height) / 2;

                popupWindow = window.open(href, null,
                "height=" + height + "px,width=" + width + "px,left=" + X + ",top=" + Y +
                ",status=no,toolbar=no,titlebar=no,menubar=no,location=no,dependent=yes,scrollbars=yes");
                        }
        </script>
        <script for=window event=onfocus language="javascript">
         // focuspopup()
            if (popupWindow!=null)
            {
                if (popupWindow.closed)
                    popupWindow = null;
                else popupWindow.focus();
            }
        </script>
        <script for=window event=onunload language="javascript">
         // closepopup()
            if (popupWindow!=null)
            {
                popupWindow.close();
                popupWindow = null;
            }
        </script>
        <!---->
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table7" style="Z-INDEX: 100; LEFT: 0px; POSITION: absolute; TOP: 624px" cellSpacing="0"
					cellPadding="0" width="100%" border="0">
				</TABLE>
				<TABLE id="Table8" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 648px" cellSpacing="0"
					cellPadding="0" width="100%" border="0">
				</TABLE>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
							<TABLE id="Table2">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Approval In Principal</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right">
							<asp:ImageButton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg"></asp:ImageButton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">Informasi Umum</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">No. Aplikasi</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_AP_REGNO" runat="server" Width="300px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">No. Referensi</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_REF" runat="server" Width="300px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tanggal Aplikasi</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_AP_SIGNDATE" runat="server" Width="300px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Sub-Segment/Program</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PROGRAMDESC" runat="server" Width="300px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Unit</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_BRANCH_NAME" runat="server" Width="300px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Supervisi</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_AP_TEAMLEADER" runat="server" ReadOnly="True" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Analis</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_AP_RELMNGR" runat="server" ReadOnly="True" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nama KAP</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_PK_ANALIS" onkeypress="return kutip_satu()" runat="server" Width="175px"
											MaxLength="50"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Komen untuk KAP</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:DropDownList id="DDL_BU_COMMENTS" runat="server"></asp:DropDownList></TD>
								</TR> <!-- Additional Field : Right --></TABLE>
							<asp:Label id="LBL_CU_CUSTTYPEID" runat="server" Visible="False"></asp:Label>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="150">
										Nama Pemohon</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_NAME" runat="server" ReadOnly="True" Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Alamat</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_ADDRESS1" runat="server" Width="300px" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 11px">&nbsp;</TD>
									<TD style="HEIGHT: 11px">
										<asp:textbox id="TXT_VERIFY" runat="server" BorderStyle="None" Width="1px"></asp:textbox>
										<asp:textbox id="TXT_VERIFY2" runat="server" BorderStyle="None" Width="1px"></asp:textbox></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 11px"><asp:textbox id="TXT_ADDRESS2" runat="server" Width="300px" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">&nbsp;</TD>
									<TD></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_ADDRESS3" runat="server" Width="300px" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Kota</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px">
										<asp:textbox id="TXT_CITY" runat="server" ReadOnly="True" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">No. Telepon</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PHONENUM" runat="server" Width="300px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Bidang Usaha</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_BUSINESSTYPE" runat="server" ReadOnly="True" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR> <!-- 14 --> <!-- 21 --> <!-- Additional Field : Right --></TABLE>
						</TD>
					</TR>
					<!--<TR>
						<TD align="center" colSpan="2">
							</TD>
					</TR>-->
					<TR>
						<TD class="tdHeader1" colSpan="2" id="TR_DOC3" runat="server">Documents
						</TD>
					</TR>
					<TR id="TR_DOC4" runat="server">
						<TD width="50%" valign="top">
							<table cellpadding="0" cellspacing="0" width="100%" id="Table9">
								<TR>
									<TD class="TDBGColor1" width="75">
										File</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><INPUT id="TXT_FILE_UPLOAD" type="file" size="39" name="File1" runat="Server" style="WIDTH: 350px; HEIGHT: 19px"></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Status</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:Label id="LBL_STATUS" runat="server" ForeColor="Red"></asp:Label>
										<asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" ErrorMessage="Only xls, doc, txt or zip files are allowed!"
											ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.xls|.XLS|.doc|.DOC|.txt|.TXT|.zip|.ZIP)$"
											ControlToValidate="TXT_FILE_UPLOAD"></asp:RegularExpressionValidator></TD>
								</TR>
								<TR>
									<TD></TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:Label id="LBL_STATUSREPORT" runat="server" ForeColor="Red"></asp:Label></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 21px" align="center" colSpan="3"></TD>
								</TR>
								<TR>
									<TD colspan="3" align="center">
										<asp:Button id="BTN_UPLOAD" runat="server" Text="Upload"></asp:Button></TD>
								</TR>
							</table>
						</TD>
						<TD width="50%" valign="top" style="HEIGHT: 42px">
							<table cellpadding="0" cellspacing="0" width="100%" id="Table10">
								<TR>
									<TD>
										<ASP:DATAGRID id="DatGrid" runat="server" Width="470px" AutoGenerateColumns="False" PageSize="1"
											CellPadding="1">
											<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
											<Columns>
												<asp:BoundColumn Visible="False" DataField="SEQ" HeaderText="Seq"></asp:BoundColumn>
												<asp:BoundColumn HeaderText="No.">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center" Width="35px"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="FU_FILENAME" HeaderText="File Name">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												</asp:BoundColumn>
												<asp:TemplateColumn>
													<HeaderStyle Width="50px" CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
													<ItemTemplate>
														<asp:HyperLink id="HL_DOWNLOAD" runat="server" Target="_blank">Download</asp:HyperLink>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn>
													<HeaderStyle Width="40px" CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
													<ItemTemplate>
														&nbsp;
														<asp:LinkButton id="LinkButton1" runat="server" CommandName="delete">Hapus</asp:LinkButton>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:BoundColumn Visible="False" DataField="FU_USERID" HeaderText="FU_USERID"></asp:BoundColumn>
											</Columns>
										</ASP:DATAGRID></TD>
								</TR>
							</table>
						</TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2" id="TR_KET1" runat="server">Keterangan</TD>
					</TR>
					<TR>
						<TD vAlign="top" colSpan="2" id="TR_KET2" runat="server">
							<asp:TextBox id="TXT_PK_KETERANGAN" runat="server" Width="100%" TextMode="MultiLine" onkeypress="return kutip_satu()"
								Height="75px"></asp:TextBox></TD>
					</TR>
					<TR id="TR_FWD" runat="server">
						<TD vAlign="top" colSpan="2" height="50">
							&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox id="CB_FORWARD" runat="server" Text=" Foward : " onclick="CekTombol()"></asp:CheckBox>
							&nbsp;&nbsp;<asp:DropDownList id="DDL_USERID" runat="server" Width="250px" Enabled="False"></asp:DropDownList>
						</TD>
					</TR>
					<TR id="TR_DOC1" runat="server">
						<TD class="tdHeader1" vAlign="top" align="left" width="50%" colSpan="2">Document 
							Export</TD>
					</TR>
					<!--					<TR>
						<TD vAlign="top" align="left" width="50%" colSpan="2"></TD>
					</TR>
-->
					<TR id="TR_DOC2" runat="server">
						<TD style="WIDTH: 540px" vAlign="top" width="540">
							<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 7px" width="75">Format</TD>
									<TD style="WIDTH: 15px; HEIGHT: 7px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 7px"><asp:dropdownlist id="DDL_FORMAT_TYPE" runat="server" Width="280px" AutoPostBack="True"></asp:dropdownlist><asp:button id="BTN_EXPORT" runat="server" Width="64px" Text="Export"></asp:button></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Status</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:label id="LBL_STATUS_EXPORT" runat="server" ForeColor="Red"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"></TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:label id="LBL_STATUSEXPORT" runat="server" ForeColor="Red"></asp:label></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 21px" align="center" colSpan="3">
										<asp:Label id="lbl_PRRK_Forward" runat="server" Visible="False">Forward PRRK Preparation to </asp:Label>
										<asp:Label id="lbl_PRRK_Complete" runat="server" Visible="False">PRRK Complete, return to </asp:Label></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="3"></TD>
								</TR>
							</TABLE>
						</TD>
						<TD style="HEIGHT: 42px" vAlign="top" width="50%">
							<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD>
										<ASP:DATAGRID id="DATA_EXPORT" runat="server" Width="100%" CellPadding="1" PageSize="1" AutoGenerateColumns="False">
											<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
											<Columns>
												<asp:BoundColumn Visible="False" DataField="nota_id">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="FU_FILENAME" HeaderText="File Name">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												</asp:BoundColumn>
												<asp:TemplateColumn>
													<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
													<ItemTemplate>
														<asp:HyperLink id="HL_DOWNLOAD" runat="server" Target="_blank">Download</asp:HyperLink>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn>
													<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
													<ItemTemplate>
														<asp:LinkButton id="Linkbutton1" runat="server" CommandName="delete">Delete</asp:LinkButton>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:BoundColumn Visible="False" DataField="FU_USERID" HeaderText="User ID"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="KET_CODE"></asp:BoundColumn>
											</Columns>
										</ASP:DATAGRID></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" width="50%" colSpan="2" align="left">
							<asp:button id="BTN_APPROVE" runat="server" Text="Setuju" CssClass="Button1" 
                                Width="150px" onclick="BTN_APPROVE_Click"></asp:button>
							<asp:button id="BTN_REJECT" runat="server" Text="Tolak" CssClass="Button1" 
                                Width="150px" onclick="BTN_REJECT_Click"></asp:button>
							<asp:button id="BtnSave" runat="server" Text=" Simpan" CssClass="Button1" 
                                Visible="False" onclick="BtnSave_Click"></asp:button>
							<asp:button id="BtnFoward" runat="server" Text="Foward" CssClass="Button1" style="DISPLAY:none"></asp:button>&nbsp;
							<asp:button id="updatestatus" runat="server" Text="Update Status" CssClass="Button1" Visible="False" onclick="updatestatus_Click"></asp:button>
							<asp:button id="BTN_VIEWNOTA" runat="server" Text="View Nota PS Assign" CssClass="Button1" Visible="False"></asp:button>
						</TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
