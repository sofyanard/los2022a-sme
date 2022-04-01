<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DocumentUpload2.ascx.cs" Inherits="SME.CommonForm.DocumentUpload2" %>
<script src="../jQuery/Main/jquery-1.7.1.min.js" type="text/javascript"></script>
<script language="javascript" type="text/javascript">
    $(document).ready(function () {
        $("#Button1").click(function (e) {
            e.preventDefault();
            var whostname = window.location.hostname
            var wpathname = window.location.pathname;
            var wpathname2 = wpathname.split('/');
            var wappname = wpathname2[1];
            var wappurl = 'http://' + whostname + '/' + wappname;
            var ajaxhndlurl = wappurl + '/CommonForm/DocumentUpload2Handler.ashx';
            var ufilename = document.getElementById("FileUpload1").value;
            $.ajax({
                url: ajaxhndlurl + '?fname=' + ufilename,
                type: "POST",
                success: function (result) {
                    $("#div1").html(result);
                },
                error: function (xhr, status, error) {
                    var err = eval("(" + xhr.responseText + ")");
                    alert(err.Message);
                }
            });
        });
    });
</script>
<div>
    <asp:FileUpload ID="FileUpload1" runat="server" />
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" Text="Upload File" />
    <br />
    <br />
    <asp:Label ID="Label1" runat="server"></asp:Label>
    <div id="div1"></div>
</div>