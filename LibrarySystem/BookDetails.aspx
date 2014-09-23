<%@ Page Title="" Language="C#" MasterPageFile="~/Page.Master" AutoEventWireup="true" CodeBehind="BookDetails.aspx.cs" Inherits="LibrarySystem.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater ID="rptBooksDetails" runat="server">
        <HeaderTemplate>
            <tr>
                <th><%#Session["rptBookArg"] %></th>
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
                <td><%#Eval("SignId") %></td>
                <td><%#Eval("PublicationYear") %></td>
                <td><%#Eval("Publisher") %></td>
                <td><%#Eval("LibNo") %></td>
            </tr>
            <br/>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
