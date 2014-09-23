<%@ Page Title="" Language="C#" MasterPageFile="~/Page.Master" AutoEventWireup="true" CodeBehind="WebForm4.aspx.cs" Inherits="LibrarySystem.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater ID="rptAuthorDetails" runat="server">
        <HeaderTemplate>
            <tr>
                <th><%#Session["rptAuthorArg"] %></th>
            </tr>
            <tr>
                <th>ISBN</th>
                <th>Title</th>
            </tr>
            <br/>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%#Eval("Aid") %></td>
                <td><%#Eval("FirstName") %></td>
                <td><%#Eval("LastName") %></td>
                <td><%#Eval("BirthYear") %></td>
                <asp:Button runat="server" text="Books" Font-Size="X-Small"/>
            </tr>
            <br/>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
