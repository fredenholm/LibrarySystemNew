<%@ Page Title="" Language="C#" MasterPageFile="~/Page.Master" AutoEventWireup="true" CodeBehind="WebForm6.aspx.cs" Inherits="LibrarySystem.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<asp:Repeater ID="rptBorrow" runat="server">
        <HeaderTemplate>
            <tr>
                <th><%#Session["rptBorrow"] %></th>
            </tr>
           
            <br/>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%#Eval("PersonId") %></td>
                <td><%#Eval("firstname") %></td
                <td><%#Eval("lastname") %></td>
                <td><%#Eval("Address") %></td>
                <td><%#Eval("telno") %></td>
                <td><%#Eval("Categoryid") %></td>  
                    
            </tr>
            <br/>
        </ItemTemplate>
</asp:Repeater>

</asp:Content>