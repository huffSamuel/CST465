<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RequriedTextBox.ascx.cs" Inherits="CST465Project.WebForms.RequriedTextBox" %>

<asp:Label runat="server" AssociatedControlID="uxTextBox" ID="uxLabel"></asp:Label>
<asp:TextBox runat="server" ID="uxTextBox"></asp:TextBox>
<asp:RequiredFieldValidator  ID="uxValidator" ControlToValidate="uxTextBox" runat ="server" Text="*"></asp:RequiredFieldValidator>