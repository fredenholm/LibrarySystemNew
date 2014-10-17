<%@ Page Title="" Language="C#" MasterPageFile="~/Page.Master" AutoEventWireup="true" CodeBehind="EditAdminAuthor.aspx.cs" Inherits="LibrarySystem.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:label runat="server" Text="ID: "></asp:label>
        <asp:label runat="server" ID="Aid"></asp:label>
        <br />
        <asp:label runat="server" Text="FirstName: "></asp:label>
        <asp:TextBox runat="server" ID="AFN"></asp:TextBox>
        <br />
        <asp:label runat="server" Text="Lastname: "></asp:label>
        <asp:TextBox runat="server" ID="ALN"></asp:TextBox>
        <br />
        <asp:label runat="server" Text="BirthYear: "></asp:label>
        <asp:TextBox runat="server" ID="Birthyear"></asp:TextBox>
        <br />
        <asp:Button runat="server" id="createBtn" Text="Accept" OnClick="createBtn_Click" />
        <asp:Button runat="server" ID="cancelBtn" Text="Cancel" OnClick="cancelBtn_Click" />

</asp:Content>
