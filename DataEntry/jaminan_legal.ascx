<%@ Control Language="c#" AutoEventWireup="True" Codebehind="jaminan_legal.ascx.cs" Inherits="SME.DataEntry.jaminan_legal" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<TABLE cellSpacing="0" cellPadding="0" width="100%">
	<tr>
		<td class="tdHeader1"><B>Jenis Pengikatan Jaminan</B></td>
	</tr>
	<tr>
		<td>
			<TABLE cellSpacing="2" cellPadding="2" width="100%">
				<tr>
					<td class="td" vAlign="top" width="50%">
						<TABLE cellSpacing="0" cellPadding="0" width="100%">
							<tr>
								<td class="TDBGColor1" width="150">Jenis Pengikatan</td>
								<td width="15"></td>
								<td class="TDBGColorValue"><asp:dropdownlist id="DDL_CL_IKATTYPE" Runat="server"></asp:dropdownlist></td>
							</tr>
						</TABLE>
						<asp:label id="LBL_CUREF" Runat="server" Visible="False"></asp:label>
						<asp:label id="LBL_CL_SEQ" Runat="server" Visible="False"></asp:label>
						<asp:label id="LBL_REGNO" Runat="server" Visible="False"></asp:label>
					</td>
					<td class="td" vAlign="top">
						<TABLE cellSpacing="0" cellPadding="0" width="100%">
							<tr>
								<td class="TDBGColor1" width="150">Collateral Mortgage</td>
								<td width="15"></td>
								<td class="TDBGColorValue">
									<asp:RadioButtonList id="RBL_LEGALSTACOL" runat="server"></asp:RadioButtonList></td>
							</tr>
						</TABLE>
					</td>
				</tr>
			</TABLE>
		</td>
	</tr>
	<!--<TR>
		<TD class="TDBGColor2" align="center"><asp:button id="BTN_SAVE_JAMINAN" Runat="server" CssClass="button1" Text="Save"></asp:button></TD>
	</TR>-->
	<tr>
		<td class="tdHeader1"><B>Jaminan Detail</B></td>
	</tr>
</TABLE>
