<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Employee_data._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-top:15%;margin-left:30%">
        <div>
           <asp:Label ID="Label1" runat="server" Text="Label">Username</asp:Label> &nbsp;&nbsp;
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
             Style="color:red" ErrorMessage="User name required" ControlToValidate="TextBox1">
                </asp:RequiredFieldValidator> 
            <br />
        </div>
        <div style="margin-top:2%">
     <asp:Label ID="Label2" runat="server" Text="Label">Password </asp:Label> &nbsp;&nbsp;
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"            
           Style="color:red"  ErrorMessage="Password required" ControlToValidate="TextBox2">
            </asp:RequiredFieldValidator> 
        </div>
        <div style="margin-top:2%;margin-left:15%">
             <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />
        </div>       

    </div>

</asp:Content>
