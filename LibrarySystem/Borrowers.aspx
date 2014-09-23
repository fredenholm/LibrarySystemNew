<%@ Page Title="" Language="C#" MasterPageFile="~/Page.Master" AutoEventWireup="true" CodeBehind="Borrowers.aspx.cs" Inherits="LibrarySystem.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Repeater ID="rptBorrow" runat="server">
        <ItemTemplate>
            <tr>
                <td><%#Eval("firstname") %></td
                <td><%#Eval("lastename") %></td>
                <td><%#Eval("Address") %></td>
                <td><%#Eval("telno") %></td>
                <td><%#Eval("Categoryid") %></td>
                <td><asp:Button ID ="RenewBook" runat="server" Text="Renew loan" /></td>
            </tr>
            <br/>
            <asp:Repeater ID="rptBorrowBooks" runat="server">
                   <ItemTemplate>
                       <tr>
                        <td><%#Eval("ISBN") %></td
                        <td><%#Eval("Title") %></td>
                        <td><%#Eval("SignId") %></td>
                        <td><%#Eval("PublicationYear") %></td>
                        <td><%#Eval("Publisher") %></td>
                        <td><%#Eval("LibNo") %></td>
                        <td><asp:Button ID ="RenewBook" runat="server" Text="aS loan" /></td>
                    </tr>
            <br/>
    </ItemTemplate>
            </asp:Repeater>
        </ItemTemplate>
</asp:Repeater>
</asp:Content>