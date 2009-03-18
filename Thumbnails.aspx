<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Thumbnails.aspx.cs" Inherits="Thumbnails" Title="Thumbnails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Master_Content" Runat="Server">

<div id="preload" style="background-color: #888888; width:750px; height: 500px; position: absolute; visibility: hidden">
    <img src="_img/ajax-loader.gif" alt="preloading images" style="position: absolute; left: 330px; top: 225px;"/>
</div>
<div id="thumbnails" style="visibility: visible;">
    <%=EVIL_HTML_OF_DOOM %>
</div>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Master_Content_Description" Runat="Server">

<div class="descriptionHead" style="padding-right: 5px;"><asp:Label ID="l_credits_1_t" runat="server" />&nbsp;<asp:Label ID="l_credits_1" runat="server" /></div>
<div class="descriptionText">
    <div style="float: left; padding-right: 5px; color: #888888"><asp:Label ID="l_credits_2_t" runat="server" /></div><div><asp:Label ID="l_credits_2" runat="server" /></div>
    <div style="float: left; padding-right: 5px; color: #888888"><asp:Label ID="l_credits_3_t" runat="server" /></div><div><asp:Label ID="l_credits_3" runat="server" /></div>
    <div style="float: left; padding-right: 5px; color: #888888"><asp:Label ID="l_credits_4_t" runat="server" /></div><div><asp:Label ID="l_credits_4" runat="server" /></div>
    <div style="float: left; padding-right: 5px; color: #888888"><asp:Label ID="l_credits_5_t" runat="server" /></div><div><asp:Label ID="l_credits_5" runat="server" /></div>
    <div style="float: left; padding-right: 5px; color: #888888"><asp:Label ID="l_credits_6_t" runat="server" /></div><div><asp:Label ID="l_credits_6" runat="server" /></div>
</div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Master_Content_Navigation" Runat="Server">

<div class="thumbnav">
    <p align="left">
    </p>
</div>

<div class="nav">
    <div style="text-align: center">
    </div>
</div>

<script type="text/javascript">

function OnLoadPage()
{
    setTimeout(Swap, 5000);
}

function Swap()
{
    document.getElementById("preload").style.visibility = 'hidden';
    document.getElementById("thumbnails").style.visibility = 'visible';
}

//OnLoadPage();

</script>

</asp:Content>