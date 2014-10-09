<%@ Page Title="" Language="C#" MasterPageFile="~/Page.Master" AutoEventWireup="true" CodeBehind="Books.aspx.cs" Inherits="LibrarySystem.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
       
        

    </style>
       <asp:Repeater ID="rptBooks" runat="server">
        <HeaderTemplate>
            <tr>
                <th><%#Session["rptAuthorArg"] %></th>
            </tr>
            <div class="thpos" >
                <table>
                    <th>ISBN</th>
                    <th>Title</th>
                </table>
               
            </div>
            <br />
            <br/>
        </HeaderTemplate>
        <ItemTemplate>
            <table>
                <td><%#Eval("ISBN") %></td>
                <td><%#Eval("Title") %></td>
            </table>
            <br/>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
