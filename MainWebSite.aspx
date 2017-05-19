<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MainWebSite.aspx.cs" Inherits="MainWebSite" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Fotorot" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentLogo" Runat="Server">
    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="https://dabuttonfactory.com/button.png?t=Wyloguj&amp;f=Calibri-Bold&amp;ts=17&amp;tc=fff&amp;tshs=1&amp;tshc=000&amp;hp=20&amp;vp=8&amp;c=5&amp;bgt=gradient&amp;bgc=b6d7a8&amp;ebgc=38761d" OnClick="ImageButton1_Click1" />
&nbsp;<asp:ImageButton ID="ImageButton2" runat="server" Height="30px" ImageUrl="https://dabuttonfactory.com/button.png?t=Dodaj+zdj%C4%99cie&amp;f=Calibri-Bold&amp;ts=17&amp;tc=fff&amp;tshs=1&amp;tshc=000&amp;hp=20&amp;vp=8&amp;c=5&amp;bgt=gradient&amp;bgc=90dd96&amp;ebgc=328238" OnClick="ImageButton2_Click" />

&nbsp;<asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">LinkButton</asp:LinkButton>
&nbsp;
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentBody" Runat="Server">
        <asp:GridView AutoGenerateColumns="false" ID="GridView1" runat="server" GridLines="None" HorizontalAlign="Center">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <img src='HandlerImage.ashx?id=<%#Eval("Id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <RowStyle HorizontalAlign="Center" />
        </asp:GridView>
</asp:Content>

