<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Fotorot" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .auto-style1 {
        width: 100%;
    }
    .newStyle1 {
        font-family: calibri;
    }
    .auto-style2 {
        font-family: calibri;
        font-size: large;
        text-align: right;
        width: 297px;
    }
    .auto-style3 {
        width: 200px;
    }
    .auto-style7 {
        font-family: calibri;
        font-size: large;
    }
        .auto-style8 {
            font-family: calibri;
            font-size: large;
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentLogo" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentBody" Runat="Server">
    <table class="auto-style1">
    <tr>
        <td class="auto-style2">Login:</td>
        <td class="auto-style3">
            <asp:TextBox ID="TextBoxUN" runat="server" Height="22px" Width="188px"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxUN" ErrorMessage="Podaj login" ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">Hasło:</td>
        <td class="auto-style3">
            <asp:TextBox ID="TextBoxPass" runat="server" Height="22px" Width="188px" TextMode="Password"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxPass" ErrorMessage="Podaj hasło" ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">Powtórz hasło:</td>
        <td class="auto-style3">
            <asp:TextBox ID="TextBoxCPass" runat="server" Height="22px" Width="188px" TextMode="Password"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxCPass" ErrorMessage="Podaj hasło drugi raz" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBoxPass" ControlToValidate="TextBoxCPass" ErrorMessage="Hasła muszą się zgadzać" ForeColor="Red"></asp:CompareValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td class="auto-style3">
            <asp:ImageButton ID="ImageButton1" runat="server" Height="30px" ImageUrl="https://dabuttonfactory.com/button.png?t=Zarejestruj&amp;f=Calibri-Bold&amp;ts=17&amp;tc=fff&amp;tshs=1&amp;tshc=000&amp;hp=20&amp;vp=8&amp;c=5&amp;bgt=gradient&amp;bgc=90dd96&amp;ebgc=328238" Width="94px" OnClick="ImageButton1_Click" />
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style8" colspan="3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server" CssClass="auto-style7" ForeColor="Red"></asp:Label>
        </td>
    </tr>
</table>
</asp:Content>

