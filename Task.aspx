<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Task.aspx.cs" Inherits="PRTRAINING.Task" MasterPageFile="Site.Master" %>
<%@ Register Src="TaskC.ascx" TagName="TaskC" TagPrefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1>Task Details</h1>
        <asp:TextBox ID="txtIdUser" runat="server" Text="IdUser"></asp:TextBox><br />
        <asp:TextBox ID="txtTitle" runat="server" Text="Titlu" /><br />
        <asp:DropDownList ID="ddlStatus" runat="server"><asp:ListItem Text="-alegeti-" Value="" /></asp:DropDownList><br />
        <textarea id="txtDescription" name="txtDescription" runat="server" rows="4" cols="50">Descriere</textarea><br />
        <asp:TextBox ID="txtDeadline" runat="server" Text="Deadline" /><br />
        <asp:Button ID="btnSave" runat="server" Text="Salveaza" OnClick="btnSave_Click" />
        <asp:Button ID="btnRenunta" runat="server" Text="Renunta" OnClick="btnRenunta_Click" />
        <div id="divMessage" runat="server" class="msg"></div>
    </div>
</asp:Content>