<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Sequence.aspx.cs" Inherits="Sequence" Title="Lars Botten Photography" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Master_Content" Runat="Server">

<%=JS %>

<div id="div_main_image">
    <asp:Image ID="main_image" runat="server" Width="750" Height="500" />
</div>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Master_Content_Description" Runat="Server">

<!--
<div class="descriptionHead">BOTTEN PHOTOGRAPHY AS</div>
<div class="descriptionText">
Torggata11<br />
0188 Oslo, Norway<br />
phone: +47 90 54 21 01<br />
fax: +47 22 41 11 04<br />
<a href="mailto:lars@botten.net">lars@botten.net</a><br />&nbsp;
</div>

<div class="descriptionHead">ARIS / BIRD-PRODUCTION</div>
<div class="descriptionText">
26, rue Beranger<br />
75 003 Paris, France<br />
phone: +33 (0) 142 76 8860<br />
fax: +33 (0) 142 76 8866<br />
<a href="mailto:info@bird-production.com">info@bird-production.com</a><br />
<a href="http://www.bird-production.com" target="_blank">www.bird-production.com</a></div>
</div>
-->
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
        <asp:HyperLink ID="hl_thumbnails" runat="server" onclick="new Effect.Opacity('div_main_image', {duration:0.3, from:1.0, to:0.0})" onmouseover="$('ctl00_Master_Content_Navigation_Image1').src='_img/thumbs_icon.png'" onmouseout="$('ctl00_Master_Content_Navigation_Image1').src='_img/thumbs_icon_hoover.png'">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/_img/thumbs_icon_hoover.png" AlternateText="Thumbnails" CssClass="thumbicon"/>&nbsp;thumbnails
        </asp:HyperLink>
    </p>
</div>

<div class="nav">
    <div style="text-align: center">
        <a href="#" onclick="Previous()">
            <img src="_img/arrow_left_hoover.png" class="naviconleft" onmouseover="this.src='_img/arrow_left.png'" onmouseout="this.src='_img/arrow_left_hoover.png'">
        </a>
        <div id="pagerinfo" style="display: inline;"></div>
        <a href="#" onclick="Next()">
            <img src="_img/arrow_right_hoover.png" class="naviconright" onmouseover="this.src='_img/arrow_right.png'" onmouseout="this.src='_img/arrow_right_hoover.png'">
        </a>
    </div>
</div>

<script type="text/javascript">

var pager = 0;
<%=EVIL_PAGER_OF_DOOM %>

function ImagesInitialize()
{
    $('ctl00_Master_Content_main_image').src = Images[pager];
    $('pagerinfo').innerHTML = " " + (pager+1) + " to " + Images.length + " ";
}

function Next()
{
    if(Images.length > (pager+1))
    {
        pager++;
        $('ctl00_Master_Content_main_image').src = Images[pager];
        $('pagerinfo').innerHTML = " " + (pager+1) + " to " + Images.length + " ";
    }
}

function Previous()
{
    if(pager-1 >= 0)
    {
        pager--;
        $('ctl00_Master_Content_main_image').src = Images[pager];
        $('pagerinfo').innerHTML = " " + (pager+1) + " to " + Images.length + " ";
    }
}

ImagesInitialize();

</script>

</asp:Content>