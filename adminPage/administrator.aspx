<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site1.Master" AutoEventWireup="true" CodeBehind="administrator.aspx.cs" Inherits="Assignment_4_Parker_Noah.administratorPage.administrator" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
    <br />
</p>
<p>
    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
</p>
    <p>
        <asp:GridView ID="GridView2" runat="server">
        </asp:GridView>
</p>
    <p>
</p>
    <p>
        <strong>Add new Member: </strong>&nbsp;&nbsp;&nbsp; <strong>
        <asp:Button ID="addMemberButton" runat="server" CssClass="auto-style1" Height="33px" Text="ADD" Width="116px" OnClick="addMemberButton_Click" />
        </strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>&nbsp;NetUser:</strong></p>
    <p>
        First Name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
        <asp:TextBox ID="addMFnameTXT" runat="server"></asp:TextBox>
        &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
        
&nbsp;&nbsp;&nbsp;Username:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="usernameM" runat="server"></asp:TextBox>
    </p>
    <p>
        Last Name:&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="addMLnameTXT" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Password:&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="passwordM" runat="server"></asp:TextBox>
    </p>
    <p>
        Date Joined:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="addMDateTXT" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</p>
    <p>
        Phone Number:&nbsp;&nbsp;
        <asp:TextBox ID="addMPhoneTXT" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</p>
    <p>
        Email:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <asp:TextBox ID="addMEmailTXT" runat="server"></asp:TextBox>
</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        <strong>Add new Instructor: </strong>&nbsp;&nbsp;&nbsp; <strong>
        <asp:Button ID="addInstructorButton" runat="server" CssClass="auto-style1" Height="33px" Text="ADD" Width="107px" OnClick="addInstructorButton_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; NetUser:</strong></p>
    <p>
        First Name:&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="addIFnameTXT" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Username:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="usernameI" runat="server"></asp:TextBox>
    </p>
    <p>
        Last Name:&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="addILnameTXT" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; Password:&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="passwordI" runat="server"></asp:TextBox>
    </p>
    <p>
        Phone Number:&nbsp;&nbsp; <asp:TextBox ID="addIPhoneTXT" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </p>
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </p>
    <p>
        &nbsp;</p>
    <p>
        <strong>Delete Member: </strong>&nbsp;&nbsp;&nbsp; <strong>
        <asp:Button ID="deleteMemberButton" runat="server" CssClass="auto-style1" Height="33px" Text="DELETE" Width="136px" OnClick="deleteMemberButton_Click" />
        </strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong>Delete Instructor: </strong>&nbsp;&nbsp;&nbsp; <strong>
        <asp:Button ID="deleteInstructorButton" runat="server" CssClass="auto-style1" Height="33px" Text="DELETE" Width="120px" OnClick="deleteInstructorButton_Click" />
        </strong>
</p>
    <p>
        Member ID:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="deleteMIDTXT" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Instructor ID:&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="deleteIIDTXT" runat="server"></asp:TextBox>
&nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        <strong>Assign Section:&nbsp;&nbsp;
        <asp:Button ID="assignButton" runat="server" CssClass="auto-style1" OnClick="assignButton_Click" Text="ASSIGN" />
        </strong></p>
    <p>
        Member ID:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="assignTXT" runat="server"></asp:TextBox>
        &nbsp;</p>
    <p>
        Section ID:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="sectionTXT" runat="server"></asp:TextBox>
&nbsp;&nbsp;</p>
    <p>
</p>
</asp:Content>
