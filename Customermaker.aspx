<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Customermaker.aspx.cs" Inherits="Employee_data.Customermaker" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
             <asp:FileUpload ID="FileUpload1" runat="server" />
            <asp:Button Text="Upload" OnClick = "Upload" runat="server" />
</asp:Content>
