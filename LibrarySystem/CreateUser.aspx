﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Page.Master" AutoEventWireup="true" CodeBehind="CreateUser.aspx.cs" Inherits="LibrarySystem.CreateUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label runat="server" Text="PersonId: "></asp:Label><asp:TextBox runat="server" ID="PersonId"></asp:TextBox><br />
    <asp:Label runat="server" Text="Username: "></asp:Label><asp:TextBox runat="server" ID="username"></asp:TextBox><br />
    <asp:Label runat="server" Text="Password: "></asp:Label><asp:TextBox runat="server" ID="password" TextMode="Password"></asp:TextBox><br />
    <asp:Label runat="server" Text="E-mail: "></asp:Label><asp:TextBox runat="server" ID="email" TextMode="Email"></asp:TextBox><br />
    <asp:Button runat="server" id="createBtn" Text="Create" OnClick="createBtn_Click"/><asp:Button runat="server" ID="cancelBtn" Text="Cancel" OnClick="cancelBtn_Click" /></asp:Content>
