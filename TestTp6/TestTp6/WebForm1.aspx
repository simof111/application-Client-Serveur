<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="TestTp6.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:SqlDataSource ID="dsEtudiant" runat="server" 
            ConflictDetection="CompareAllValues" 
            ConnectionString="<%$ ConnectionStrings:ConnectionStringTP6 %>" 
            DeleteCommand="DELETE FROM [Class] WHERE [Code] = @original_Code AND (([Nom] = @original_Nom) OR ([Nom] IS NULL AND @original_Nom IS NULL))" 
            InsertCommand="INSERT INTO [Class] ([Code], [Nom]) VALUES (@Code, @Nom)" 
            OldValuesParameterFormatString="original_{0}" 
            SelectCommand="SELECT Etudiant.CIN, Etudiant.Nom, Class.Nom AS Class FROM Class INNER JOIN Etudiant ON Class.Code = Etudiant.Class" 
            UpdateCommand="UPDATE [Class] SET [Nom] = @Nom WHERE [Code] = @original_Code AND (([Nom] = @original_Nom) OR ([Nom] IS NULL AND @original_Nom IS NULL))">
            <DeleteParameters>
                <asp:Parameter Name="original_Code" Type="Int32" />
                <asp:Parameter Name="original_Nom" Type="String" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Code" Type="Int32" />
                <asp:Parameter Name="Nom" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Nom" Type="String" />
                <asp:Parameter Name="original_Code" Type="Int32" />
                <asp:Parameter Name="original_Nom" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="dsClass" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionStringTP6 %>" 
            SelectCommand="SELECT * FROM [Class]"></asp:SqlDataSource>
        <asp:FormView ID="FormView1" runat="server" AllowPaging="True" 
            DataKeyNames="CIN" DataSourceID="dsEtudiant">
            <EditItemTemplate>
                CIN:
                <asp:Label ID="CINLabel1" runat="server" Text='<%# Eval("CIN") %>' />
                <br />
                Nom:
                <asp:TextBox ID="NomTextBox" runat="server" Text='<%# Bind("Nom") %>' />
                <br />
                Class:
                <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="dsClass" 
                    DataTextField="Nom" DataValueField="Code" SelectedValue='<%# Bind("Class") %>'>
                </asp:DropDownList>
                <br />
                <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" 
                    CommandName="Update" Text="Update" />
&nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" 
                    CommandName="Cancel" Text="Cancel" />
            </EditItemTemplate>
            <InsertItemTemplate>
                CIN:
                <asp:TextBox ID="CINTextBox" runat="server" Text='<%# Bind("CIN") %>' />
                <br />
                Nom:
                <asp:TextBox ID="NomTextBox" runat="server" Text='<%# Bind("Nom") %>' />
                <br />
                Class:
                <asp:TextBox ID="ClassTextBox" runat="server" Text='<%# Bind("Class") %>' />
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
                Class:
                <asp:Label ID="ClassLabel" runat="server" Text='<%# Bind("Class") %>' />
                <br />
                <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" 
                    CommandName="Edit" Text="Edit" />
&nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" 
                    CommandName="Delete" Text="Delete" />
                &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" 
                    CommandName="New" Text="New" />
            </ItemTemplate>
        </asp:FormView>
    </div>
    </form>
</body>
</html>
