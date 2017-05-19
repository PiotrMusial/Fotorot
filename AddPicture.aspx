<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddPicture.aspx.cs" Inherits="AddPicture" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Fotorot" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .newStyle1 {
            font-family: calibri;
        }
        .auto-style1 {
            font-family: calibri;
            font-size: large;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentLogo" Runat="Server">
    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">LinkButton</asp:LinkButton>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentBody" Runat="Server">
    <asp:FileUpload ID="FileUpload1" runat="server" Height="30px" />
    <br />
    <br />
    <asp:ImageButton ID="ImageButton1" runat="server" Height="30px" ImageUrl="https://dabuttonfactory.com/button.png?t=Dodaj&amp;f=Calibri-Bold&amp;ts=17&amp;tc=fff&amp;tshs=1&amp;tshc=000&amp;hp=20&amp;vp=8&amp;c=5&amp;bgt=gradient&amp;bgc=90dd96&amp;ebgc=328238" OnClick="ImageButton1_Click" />
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" CssClass="auto-style1"></asp:Label>
    <br />
</asp:Content>

