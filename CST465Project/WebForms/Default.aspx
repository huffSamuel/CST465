<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CST465Project.WebForms.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Default</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label AssociatedControlID="uxName" runat="server">Name: </asp:Label>
        <asp:TextBox ID="uxName" runat="server"></asp:TextBox> <br />

        <asp:Label AssociatedControlID="uxPriority" runat="server">Priority: </asp:Label>
        <asp:DropDownList ID="uxPriority" runat="server">
            <asp:ListItem Value="high" Selected="True">High</asp:ListItem>
            <asp:ListItem Value="medium">Medium</asp:ListItem>
            <asp:ListItem Value="low">Low</asp:ListItem>
        </asp:DropDownList> <br />

        <asp:Label AssociatedControlID="uxSubject" runat="server">Subject: </asp:Label>
        <asp:TextBox ID="uxSubject" runat="server"></asp:TextBox> <br />

        <asp:Label AssociatedControlID="uxDescription" runat="server">Description: </asp:Label>
        <asp:TextBox TextMode="MultiLine" ID="uxDescription" runat="server"></asp:TextBox> <br />

        <asp:Button ID="uxSubmit" Text="Submit" OnClick="uxSubmit_Click" runat="server" /> <br />

        <asp:Literal id="uxFormOutput" runat="server"></asp:Literal> <br />
        <asp:Literal ID="uxEventOutput" runat="server"></asp:Literal>

    </div>
    </form>
</body>
</html>
