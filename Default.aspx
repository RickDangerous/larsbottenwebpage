<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Title="Lars Botten Photography" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Master_Content" Runat="Server">

<asp:Image ID="i_main" runat="server" ImageUrl="Admin/_dynimg/Frontpage/0.jpg" Width="750" Height="500" />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Master_Content_Description" Runat="Server">

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

</asp:Content>