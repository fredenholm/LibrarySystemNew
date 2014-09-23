<%@ Page Title="" Language="C#" MasterPageFile="~/Page.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="LibrarySystem.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater ID="rptAuthors" runat="server">
        <HeaderTemplate>
            <tr>
                <th>Author id</th>
                <th>First name</th>
                <th>Last name</th>
                <th>Birth year</th>
            </tr>
            <br/>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%#Eval("Aid") %></td>
                <td><%#Eval("FirstName") %> </td>
                <td><%#Eval("LastName") %></td>
                <td><%#Eval("BirthYear") %></td>
                
            </tr>
            <br/>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
