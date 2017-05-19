<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="StartLoginPage.aspx.cs" Inherits="StartLoginPage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Fotorot" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .auto-style1 {
        width: 100%;
    }
    .auto-style2 {
        width: 297px;
        text-align: right;
    }
    .auto-style3 {
        width: 131px;
    }
    .newStyle1 {
        font-family: calibri;
    }
    .auto-style4 {
        width: 297px;
        text-align: right;
        height: 26px;
        font-family: calibri;
        font-size: large;
    }
    .auto-style5 {
        width: 131px;
        height: 26px;
    }
    .auto-style6 {
        height: 26px;
    }
    .newStyle2 {
        font-family: calibri;
    }
    .auto-style7 {
        font-family: calibri;
        font-size: large;
    }
        .newStyle3 {
            font-family: calibri;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentLogo" Runat="Server">
    <asp:ImageButton ID="ImageButton2" runat="server" Height="30px" ImageUrl="https://dabuttonfactory.com/button.png?t=Zarejestruj&amp;f=Calibri-Bold&amp;ts=17&amp;tc=fff&amp;tshs=1&amp;tshc=000&amp;hp=20&amp;vp=8&amp;c=5&amp;bgt=gradient&amp;bgc=90dd96&amp;ebgc=328238" OnClick="ImageButton2_Click" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentBody" Runat="Server">
    <table class="auto-style1">
    <tr>
        <td class="auto-style2"><span class="auto-style7">Login</span>:</td>
        <td class="auto-style3">
            <asp:TextBox ID="TextBoxUserName" runat="server" Height="22px" Width="180px"></asp:TextBox>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style4">Hasło:</td>
        <td class="auto-style5">
            <asp:TextBox ID="TextBoxPassword" runat="server" Height="22px" Width="180px" TextMode="Password"></asp:TextBox>
        </td>
        <td class="auto-style6"></td>
    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td class="auto-style3">
            <asp:ImageButton ID="ImageButton1" runat="server" Height="30px" ImageUrl="https://dabuttonfactory.com/button.png?t=Zaloguj&amp;f=Calibri-Bold&amp;ts=17&amp;tc=fff&amp;tshs=1&amp;tshc=000&amp;hp=20&amp;vp=8&amp;c=5&amp;bgt=gradient&amp;bgc=90dd96&amp;ebgc=328238" OnClick="ImageButton1_Click" />
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td class="auto-style3">
            <asp:Label ID="Label1" runat="server" CssClass="auto-style7" ForeColor="Red"></asp:Label>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td class="auto-style3">
            <asp:Label ID="Label2" runat="server" CssClass="auto-style7" ForeColor="Red"></asp:Label>
        </td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>

