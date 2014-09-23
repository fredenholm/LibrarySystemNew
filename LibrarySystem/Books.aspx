<%@ Page Title="" Language="C#" MasterPageFile="~/Page.Master" AutoEventWireup="true" CodeBehind="Books.aspx.cs" Inherits="LibrarySystem.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <asp:Repeater ID="rptBooks" runat="server">
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
                <td><%#Eval("ISBN") %></td>
                <td><%#Eval("Title") %></td>
            </tr>
            <br/>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
