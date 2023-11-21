<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="logon.aspx.cs" Inherits="Assignment_4_Parker_Noah.logonPage.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.3.1/dist/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
    <title></title>
    <style>
        .myClass {

            position: fixed;
            margin: 25%;
            margin-left: 40%;
            margin-top: 15%;
            height: 20%;
            overflow: auto;
            border: 2px solid grey;
        }


    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="myClass">
            <asp:Login ID="Login1" runat="server" OnAuthenticate="Login1_Authenticate" class="form-control"></asp:Login>
        </div>
    </form>
    <nav class="navbar navbar-expand-lg navbar-light bg-light"><p> Username and passwords are the same, try user(1-10), instructor(11-15), or admin20 </p></nav>
    
</body>
</html>
