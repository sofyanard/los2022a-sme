<%@ Page language="c#" Codebehind="Messages.aspx.cs" AutoEventWireup="True" Inherits="SME.Facilities.Messages" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Messages</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<script language="javascript">
			function SearchMsgTo(TheForm, TheObject)
			{	
				Urlnya = "../Facilities/SearchUser.aspx" + "?ufrm=" + TheForm + "&uobj=" + TheObject;
				window.open(Urlnya,"SearchUser","status=no,scrollbars=no,width=800,height=600")
			}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder">
							<TABLE id="Table8">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Messaging</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A>
							<A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A>
						</TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" width="100%" colSpan="2">Sent Message</TD>
					</TR>
					<TR>
						<TD colSpan="2"><ASP:DATAGRID id="DG_SENTMSG" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="1"
								Width="100%">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="MSG_ID">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="No">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="30px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="MSG_SENDDATE" HeaderText="Send Date">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="MSG_RECVBY" HeaderText="To">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="MSG_TEXT" HeaderText="Message">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="MSG_RECVSTAT" HeaderText="Status">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:ButtonColumn Text="Delete" HeaderText="Function" CommandName="Delete">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
									</asp:ButtonColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
					<TR>
						<TD vAlign="top" colSpan="2">
							<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="129">To</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_MSGTO" runat="server" Width="75%" BorderStyle="None" ReadOnly="True"></asp:textbox>&nbsp;
										<asp:textbox id="TXT_TEMPMSGTO" runat="server" Width="1px" BorderStyle="None" ontextchanged="TXT_TEMPMSGTO_TextChanged"></asp:textbox>&nbsp;
										<INPUT id="BTN_SEARCHMSGTO" onclick="SearchMsgTo('Form1','TXT_TEMPMSGTO', '')" type="button"
											value="Search" name="BTN_SEARCHMSGTO">
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="129">Message</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_MSGTEXT" Width="100%" Height="150" TextMode="MultiLine" Runat="server"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor2" align="center" colSpan="3"><asp:button id="BTN_SAVE" Width="100px" Runat="server" CssClass="button1" Text="Save" onclick="BTN_SAVE_Click"></asp:button></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<tr>
						<td colSpan="2"></td>
					</tr>
					<TR>
						<TD class="tdHeader1" width="100%" colSpan="2">Received Message</TD>
					</TR>
					<TR>
						<TD colSpan="2"><ASP:DATAGRID id="DG_RECVMSG" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="1"
								Width="100%">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="MSG_ID">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="No">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="30px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="MSG_SENDDATE" HeaderText="Send Date">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="MSG_SENDBY" HeaderText="From">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="MSG_TEXT" HeaderText="Message">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="MSG_RECVSTAT" HeaderText="Status">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:ButtonColumn Text="Accept" HeaderText="Function" CommandName="Accept">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
									</asp:ButtonColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
