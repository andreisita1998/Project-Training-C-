<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TaskD.aspx.cs" Inherits="PRTRAINING.TaskD" MasterPageFile="~/Site.Master" %>
<%@ Register Src="TaskC.ascx" TagName="TaskC" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc:TaskC ID="taskCControl" runat="server" />
</asp:Content>