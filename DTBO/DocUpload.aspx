<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DocUpload.aspx.cs" Inherits="SME.DTBO.DocUpload" %>
<%@ Register src="../CommonForm/DocumentUpload.ascx" tagname="DocumentUpload" tagprefix="uc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <title>DocUpload</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include  file="../include/cek_entries.html" -->
		<!-- #include  file="../include/cek_mandatory.html" -->
		<!-- #include  file="../include/cek_mandatoryOnly.html" -->
</head>
    <body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					
                    <tr>
                            <td>
                                <uc1:DocumentUpload ID="DocumentUploadDTBO" runat="server" />
                            </td>
                        </tr>
					
				</TABLE>
			</center>
		</form>
	</body>
</html>
