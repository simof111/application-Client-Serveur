<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="tp.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

    
        <asp:SqlDataSource ID="dsetudiant" runat="server" 
            ConnectionString="<%$ ConnectionStrings:C:\USERS\ZAKARIA\DESKTOP\DEVELOPPEM-ENT\WEB COTE SRVEUR\SOLTP6\PRAPP\APP_DATA\DATATP6.MDFConnectionString %>" 
            DeleteCommand="DELETE FROM [Etudiant] WHERE [CIN] = @CIN" 
            InsertCommand="INSERT INTO [Etudiant] ([CIN], [Nom], [Class]) VALUES (@CIN, @Nom, @Class)" 
            SelectCommand="SELECT Etudiant.CIN, Etudiant.Nom,Etudiant.Class, Class.Nom AS ClassNom FROM Class INNER JOIN Etudiant ON Class.Code = Etudiant.Class" 
            UpdateCommand="UPDATE [Etudiant] SET [Nom] = @Nom, [Class] = @Class WHERE [CIN] = @CIN">
            <DeleteParameters>
                <asp:Parameter Name="CIN" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="CIN" Type="Int32" />
                <asp:Parameter Name="Nom" Type="String" />
                <asp:Parameter Name="Class" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Nom" Type="String" />
                <asp:Parameter Name="Class" Type="String" />
                <asp:Parameter Name="CIN" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <asp:FormView ID="FormView1" runat="server" AllowPaging="True" 
            BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" 
            CellPadding="4" DataKeyNames="CIN" DataSourceID="dsetudiant" GridLines="Both">
            <EditItemTemplate>
                CIN:
                <asp:Label ID="CINLabel1" runat="server" Text='<%# Eval("CIN") %>' />
                <br />
                Nom:
                <asp:TextBox ID="NomTextBox" runat="server" Text='<%# Bind("Nom") %>' />
                <br />
                ClassNom:
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                    DataSourceID="SqlDataSource1" DataTextField="Nom" DataValueField="Code" 
                    Height="17px" SelectedValue='<%# Bind("Class") %>' Width="116px">
                </asp:DropDownList>
                <br />
                <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" 
                    CommandName="Update" Text="Update" />
                &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" 
                    CausesValidation="False" CommandName="Cancel" Text="Cancel" />
            </EditItemTemplate>
            <EditRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
            <InsertItemTemplate>
                CIN:
                <asp:TextBox ID="CINTextBox" runat="server" Text='<%# Bind("CIN") %>' />
                <br />
                Nom:
                <asp:TextBox ID="NomTextBox" runat="server" Text='<%# Bind("Nom") %>' />
                <br />
                ClassNom:
                <asp:TextBox ID="NomTextBox0" runat="server" Text='<%# Bind("Class") %>' />
                <br />
                <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" 
                    CommandName="Insert" Text="Insert" />
                &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" 
                    CausesValidation="False" CommandName="Cancel" Text="Cancel" />
            </InsertItemTemplate>
            <ItemTemplate>
                CIN:
                <asp:Label ID="CINLabel" runat="server" Text='<%# Eval("CIN") %>' />
                <br />
                Nom:
                <asp:Label ID="NomLabel" runat="server" Text='<%# Bind("Nom") %>' />
                <br />
                ClassNom:
                <asp:Label ID="ClassNomLabel" runat="server" Text='<%# Bind("ClassNom") %>' />
                <br />
                <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" 
                    CommandName="Edit" Text="Edit" />
                &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" 
                    CommandName="Delete" Text="Delete" />
                &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" 
                    CommandName="New" Text="New" />
            </ItemTemplate>
            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
            <RowStyle BackColor="White" ForeColor="#003399" />
        </asp:FormView>
    
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:C:\USERS\ZAKARIA\DESKTOP\DEVELOPPEM-ENT\WEB COTE SRVEUR\SOLTP6\PRAPP\APP_DATA\DATATP6.MDFConnectionString %>" 
        SelectCommand="SELECT * FROM [Class]"></asp:SqlDataSource>
    </form>
</body>
</html>
