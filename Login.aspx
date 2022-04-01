<%@ Page language="c#" Codebehind="Login.aspx.cs" AutoEventWireup="True" Inherits="SME.Login" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Login</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="style.css" type="text/css" rel="stylesheet">
		<LINK rev="stylesheet" href="design.css" type="text/css" rel="stylesheet">
		<script language="JavaScript">
			if (top != self) { top.location = self.location; }
		</script>
		<!-- #include file="include/cek_all.html" -->
	</HEAD>
	<body onload="document.Form1.TXT_USERNAME.focus()" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table height="100%" width="100%" bgColor="#ffffff" border="0">
				<tr>
					<td vAlign="middle" align="center">
						<table cellSpacing="0" cellPadding="0" border="0">
							<tr>
								<td rowSpan="3"><IMG height="223" src="image/login01.jpg" width="208"></td>
								<td><IMG height="40" src="image/login02.jpg" width="178"></td>
								<td vAlign="bottom" rowSpan="3"><IMG height="223" src="image/login04.jpg" width="55"></td>
							</tr>
							<tr>
								<td align="right" bgColor="white">
									<table height="158" width="100%" border="0">
										<tr>
											<td height="15"><font style="FONT-SIZE: 8pt" face="Verdana,arial" color="#63a1dc">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;User 
													ID</font></td>
										</tr>
										<tr>
											<td height="15">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:textbox id="TXT_USERNAME" onkeypress="return kutip_satu()" style="COLOR: #46468e; BACKGROUND-COLOR: #fcffe1"
													runat="server"></asp:textbox></td>
										</tr>
										<tr>
											<td height="15"><font style="FONT-SIZE: 8pt" face="Verdana,arial" color="#63a1dc">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Password</font></td>
										</tr>
										<tr>
											<td height="15">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:textbox id="TXT_PASSWORD" style="COLOR: #46468e; BACKGROUND-COLOR: #fcffe1" runat="server"
													TextMode="Password"></asp:textbox></td>
										</tr>
										<tr>
											<td align="center" height="15"><BR>
										<tr>
											<td align="center"><asp:button id="BTN_SUBMIT" style="BORDER-RIGHT: whitesmoke 1px solid; BORDER-TOP: whitesmoke 1px solid; FONT-WEIGHT: 700; FONT-SIZE: 11px; BORDER-LEFT: whitesmoke 1px solid; COLOR: white; BORDER-BOTTOM: whitesmoke 1px solid; FONT-FAMILY: tahoma; BACKGROUND-COLOR: #63a1dc"
													runat="server" Width="88px" Text="L o g i n" onclick="BTN_SUBMIT_Click"></asp:button></td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td><IMG height="24" src="image/login03.jpg" width="178"></td>
							</tr>
							<tr>
								<td align="center" colSpan="3"><span class="copy">Copyright © 2013. All rights 
										reserved.</span></td>
							</tr>
						</table>
						<asp:label id="Label1" runat="server" ForeColor="Red" Font-Bold="True"></asp:label></td>
				</tr>
				<tr>
					<td height="200"></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
