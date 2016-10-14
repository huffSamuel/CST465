<%@ Page Language="C#"  MasterPageFile="~/WebForms/siteMaster.Master" AutoEventWireup ="true" CodeBehind="ValidateForm.aspx.cs" Inherits="CST465Project.WebForms.ValidateForm" Title="Validate Form"%>

<%@ Register TagPrefix="CST" TagName="RequiredTextBox" Src="~/WebForms/RequriedTextBox.ascx" %>

<asp:Content ID="content1" ContentPlaceHolderID="head" runat="server">
    <title></title>
</asp:Content>

<asp:Content ID="content2" ContentPlaceHolderID="uxContentPlaceHolderMain" runat="server">
    <asp:Panel runat="server">
        <cst:RequiredTextBox runat="server" ID="uxName" LabelText="Name: " ValidationGroup="default"></cst:RequiredTextBox> <br />
        <CST:RequiredTextBox runat="server" ID="uxFavoriteColor" LabelText="Favorite Color: " ValidationGroup="default"/> <br />
        <CST:RequiredTextBox runat="server" ID="uxCity" LabelText="City: " ValidationGroup="default"/>

        <asp:Button Text="Submit" ID="uxSubmit" runat="server" OnClick="uxSubmit_Click"/>

    </asp:Panel>
</asp:Content>
