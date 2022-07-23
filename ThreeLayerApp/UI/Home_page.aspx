<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home_page.aspx.cs" Inherits="UI.Home_page" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
    <tr>
      <td>Name</td>
      <td>
          <asp:TextBox runat="server" ID="txtname" /></td>
    </tr>

     <tr>
      <td>Adress</td>
      <td><asp:TextBox runat="server" ID="txtadress" /></td>
    </tr>

     <tr>
      <td>Country</td>
      <td><asp:TextBox runat="server" ID="txtcountry" /></td>
    </tr>

     <tr>
      <td>City</td>
      <td><asp:TextBox runat="server" ID="txtcity" /></td>
    </tr>

     <tr>
      <td>PinCode</td>
      <td><asp:TextBox runat="server" ID="txtpincode" /></td>
    </tr>
     <tr>
      <td>Type of Modify :</td>
      <td>
          <asp:DropDownList ID="drType" runat="server" AutoPostBack="True" 
              Height="25px" Width="125px">
              <asp:ListItem>New Custmer</asp:ListItem>
              <asp:ListItem>Update Custmer</asp:ListItem>
          </asp:DropDownList>
      </td>
    </tr>
    </table>
        <asp:Button Text="Save Custmer" ID="add" runat="server" 
            onclick="add_Click" /> <asp:Button ID="Button1" Text="Show All Custmers" 
            runat="server" onclick="Button1_Click" />

        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
            GridLines="None" AutoGenerateColumns="False" 
            onrowediting="GridView1_RowEditing" 
            onselectedindexchanged="GridView1_SelectedIndexChanged" 
            onselectedindexchanging="GridView1_SelectedIndexChanging">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" />
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="Adress" HeaderText="Adress" />
                <asp:BoundField DataField="Country" HeaderText="Country" />
                <asp:BoundField DataField="City" HeaderText="City" />
                <asp:BoundField DataField="PinCode" HeaderText="PinCode" />
                <asp:CommandField ShowSelectButton="True" />
                <asp:CommandField ShowEditButton="True" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
    </div>
    </form>
</body>
</html>
