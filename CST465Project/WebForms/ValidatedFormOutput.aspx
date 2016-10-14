<%@ Page Language="C#"  MasterPageFile="~/WebForms/siteMaster.Master" AutoEventWireup="true" CodeBehind="ValidatedFormOutput.aspx.cs" Inherits="CST465Project.WebForms.ValidatedFormOutput" Title="Validated Output" %>

<asp:Content ID="content1" ContentPlaceHolderID="head" runat="server">
    <title></title>
</asp:Content>

<asp:Content ID="content2" ContentPlaceHolderID="uxContentPlaceHolderMain" runat="server">
    <asp:PlaceHolder ID="uxInvalidDataArea" Visible="false" runat="server">
        <p>This form did not receive the parameters expected</p>
    </asp:PlaceHolder>

    <asp:PlaceHolder ID="uxValidDataArea" Visible="false" runat="server">
        <div>
            Name: <asp:Literal ID="uxName" runat="server"></asp:Literal>
        </div>

        <div>
            Favorite Color: <asp:Literal ID="uxFavoriteColor" runat="server"></asp:Literal>
        </div>

        <div>
            City: <asp:Literal ID="uxCity" runat="server"></asp:Literal>
        </div>
    </asp:PlaceHolder>
</asp:Content>
