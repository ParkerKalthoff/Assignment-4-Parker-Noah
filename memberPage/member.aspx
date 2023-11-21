<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site1.Master" AutoEventWireup="true" CodeBehind="member.aspx.cs" Inherits="Assignment_4_Parker_Noah.memberPage.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8" />
    <title>Member Page</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>Welcome Back!</h2>
    </div>

    <asp:GridView ID="GridView1" runat="server"></asp:GridView>

</asp:Content>
