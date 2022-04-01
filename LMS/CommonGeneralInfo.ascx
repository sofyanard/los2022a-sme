<%@ Control Language="c#" AutoEventWireup="True" Codebehind="CommonGeneralInfo.ascx.cs" Inherits="SME.LMS.CommonGeneralInfo" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
	<TR>
		<TD class="tdHeader1" colSpan="2">Info Nasabah</TD>
	</TR>
	<TR>
		<TD class="td" vAlign="top" width="50%">
			<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
				<TR>
					<TD class="TDBGColor1" style="WIDTH: 129px">LMS Application No.</TD>
					<TD style="WIDTH: 15px">:</TD>
					<TD class="TDBGColorValue"><asp:textbox id="TXT_LMS_REGNO" runat="server" ReadOnly="True" Width="300px" BorderStyle="None"></asp:textbox></TD>
				</TR>
				<TR>
					<TD class="TDBGColor1" style="WIDTH: 129px">LMS Received Date</TD>
					<TD style="WIDTH: 15px">:</TD>
					<TD class="TDBGColorValue"><asp:textbox id="TXT_LMS_RECVDATE" runat="server" ReadOnly="True" Width="300px" BorderStyle="None"></asp:textbox></TD>
				</TR>
				<TR>
					<TD class="TDBGColor1" style="WIDTH: 129px"></TD>
					<TD style="WIDTH: 15px"></TD>
					<TD class="TDBGColorValue"></TD>
				</TR>
				<TR>
					<TD class="TDBGColor1">Relationship Manager</TD>
					<TD>:</TD>
					<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_CU_RM" runat="server" ReadOnly="True" Width="300px" BorderStyle="None"></asp:textbox></TD>
				</TR>
				<TR>
					<TD class="TDBGColor1">Team Leader</TD>
					<TD>:</TD>
					<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_CU_TL" runat="server" ReadOnly="True" Width="300px" BorderStyle="None"></asp:textbox></TD>
				</TR>
			</TABLE>
		</TD>
		<TD class="td" vAlign="top">
			<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
				<TBODY>
					<TR>
						<TD class="TDBGColor1" style="WIDTH: 129px">CIF No.</TD>
						<TD style="WIDTH: 15px">:</TD>
						<TD class="TDBGColorValue"><asp:textbox id="TXT_CIFNO" runat="server" ReadOnly="True" Width="300px" BorderStyle="None"></asp:textbox></TD>
					</TR>
					<TR>
						<TD class="TDBGColor1" style="WIDTH: 129px">Nama</TD>
						<TD style="WIDTH: 15px">:</TD>
						<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_NAME" runat="server" ReadOnly="True" Width="300px" BorderStyle="None"></asp:textbox></TD>
					</TR>
					<TR>
						<TD class="TDBGColor1" style="WIDTH: 129px">Jenis Identitas</TD>
						<TD style="WIDTH: 15px">:</TD>
						<TD class="TDBGColorValue"><asp:textbox id="TXT_ID_TYPE" runat="server" ReadOnly="True" Width="300px" BorderStyle="None"></asp:textbox></TD>
					</TR>
					<TR>
						<TD class="TDBGColor1" style="WIDTH: 129px">No. Identitas</TD>
						<TD style="WIDTH: 15px">:</TD>
						<TD class="TDBGColorValue"><asp:textbox id="TXT_ID_NO" runat="server" ReadOnly="True" Width="300px" BorderStyle="None"></asp:textbox></TD>
					</TR>
					<TR>
						<TD class="TDBGColor1" style="WIDTH: 129px">Alamat</TD>
						<TD style="WIDTH: 15px">:</TD>
						<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_ADDR1" runat="server" ReadOnly="True" Width="300px" BorderStyle="None"></asp:textbox></TD>
					</TR>
					<TR>
						<TD class="TDBGColor1" style="WIDTH: 129px"></TD>
						<TD style="WIDTH: 15px"></TD>
						<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_ADDR2" runat="server" ReadOnly="True" Width="300px" BorderStyle="None"></asp:textbox></TD>
					</TR>
					<TR>
						<TD class="TDBGColor1" style="WIDTH: 129px"></TD>
						<TD style="WIDTH: 15px"></TD>
						<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_ADDR3" runat="server" ReadOnly="True" Width="300px" BorderStyle="None"></asp:textbox></TD>
					</TR>
					<TR>
						<TD class="TDBGColor1" style="WIDTH: 129px"></TD>
						<TD style="WIDTH: 15px"></TD>
						<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_ADDR4" runat="server" ReadOnly="True" Width="300px" BorderStyle="None"></asp:textbox></TD>
					</TR>
				</TBODY>
			</TABLE>
		</TD>
	</TR>
</TABLE>
