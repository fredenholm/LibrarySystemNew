<%@ Page Title="" Language="C#" MasterPageFile="~/Page.Master" AutoEventWireup="true" CodeBehind="Author.aspx.cs" Inherits="LibrarySystem.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <style>
    .Author-Box
     	{ 
     	    border:1px solid #bbb;
            background-color:#eee;
            float:left;
            width:300px;
            margin:10px;
            padding:5px;
     	}
    </style>
    <div class="Author-Box">
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
                    <td><asp:Button ID="AuthorFNBtn" Text='<%#Eval("FirstName") %>' CommandArgument='<%#Eval("Aid") %>' runat="server" CommandName="Author" OnCommand="AuthorFNBtn_Command" /></td>
                    <td><%#Eval("LastName") %></td>
                    <td><%#Eval("BirthYear") %></td>
                </tr>
                <br/>
            </ItemTemplate>
        </asp:Repeater>
        <asp:Button ID="PreviousBtn" runat="server" Text="Previous" OnClick="PreviousBtn_Click"/>
        <asp:Button ID="NextBtn" runat="server" Text="Next" OnClick="NextBtn_Click"/>
    </div>
</asp:Content>
