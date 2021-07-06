<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Customerchecker.aspx.cs" Inherits="Employee_data.Customerchecker" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"   
            BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px"   
            CellPadding="4" ForeColor="Black" GridLines="Vertical">  
            <AlternatingRowStyle BackColor="White" />  
            <Columns>  
                <asp:TemplateField HeaderText="ID">  
                    <EditItemTemplate>  
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("CustomerId") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                    <ItemTemplate>  
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("CustomerId") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>  
                <asp:TemplateField HeaderText="Name">  
                    <EditItemTemplate>  
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("CustomerName") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                    <ItemTemplate>  
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("CustomerName") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>  
                <asp:TemplateField HeaderText="City">  
                    <EditItemTemplate>  
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("City") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                    <ItemTemplate>  
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("City") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>  
                <asp:TemplateField HeaderText="Status">  
                    <EditItemTemplate>  
                        <asp:CheckBox ID="CheckBox1" Text='<%# Bind("CustomerId") %>' runat="server" />  
                    </EditItemTemplate>  
                    <ItemTemplate>  
                        <asp:CheckBox ID="CheckBox1" Text='<%# Bind("CustomerId") %>' runat="server" />  
                    </ItemTemplate>  
                </asp:TemplateField>  
                       <asp:TemplateField HeaderText="City">  
                    <EditItemTemplate>  
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Status") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                    <ItemTemplate>  
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("Status") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>
                       <asp:TemplateField HeaderText="City">  
                    <EditItemTemplate>  
                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("ApproveorReject") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                    <ItemTemplate>  
                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("ApproveorReject") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>
            </Columns>  
            <FooterStyle BackColor="#CCCC99" />  
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />  
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />  
            <RowStyle BackColor="#F7F7DE" />  
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />  
            <SortedAscendingCellStyle BackColor="#FBFBF2" />  
            <SortedAscendingHeaderStyle BackColor="#848384" />  
            <SortedDescendingCellStyle BackColor="#EAEAD3" />  
            <SortedDescendingHeaderStyle BackColor="#575357" />  
        </asp:GridView>  
    <asp:DropDownList ID="DropDownList1" runat="server">
     <asp:ListItem Selected="True" Text="--Select--" Value="--Select--"></asp:ListItem>
    <asp:ListItem Text="Approve" Value="Approve"></asp:ListItem>
    <asp:ListItem Text="Reject" Value="Reject"></asp:ListItem> 
    </asp:DropDownList>
    <textarea id="TextArea1" runat="server" cols="20" rows="1"></textarea>
    <asp:Button ID="Button1" OnClick="Button1_Click" runat="server" Text="Submit" />
</asp:Content>
