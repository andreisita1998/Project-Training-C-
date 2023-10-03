<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Buguri.aspx.cs" Inherits="PRTRAINING.Buguri" MasterPageFile="~/Site.Master"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Buguri</h1>
    <div class="form-group">
        <label for="ddlActivitati">Selectați activitatea:</label>
        <asp:DropDownList ID="ddlActivitati" runat="server" CssClass="form-control">
        </asp:DropDownList>
    </div>
    <div class="form-group">
        <label for="txtBug">Descriere Bug:</label>
        <asp:TextBox ID="txtBug" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4"></asp:TextBox>
    </div>
    <asp:Button ID="btnAdaugaBug" runat="server" Text="Adaugă Bug" OnClick="btnAdaugaBug_Click" CssClass="btn btn-success" />
    <hr />
    <h2>Listă Buguri</h2>
    <asp:GridView ID="gvBuguri" runat="server" AutoGenerateColumns="False" DataKeyNames="IdBug" OnRowCommand="gvBuguri_RowCommand">
        <Columns>
            <asp:BoundField DataField="IdBug" HeaderText="ID Bug" />
            <asp:BoundField DataField="IdActivitate" HeaderText="ID Activitate" />
            <asp:BoundField DataField="Bug" HeaderText="Descriere Bug" />
            <asp:BoundField DataField="Status" HeaderText="Status" />
            <asp:BoundField DataField="DA" HeaderText="Data Adăugare" DataFormatString="{0:dd/MM/yyyy HH:mm:ss}" />
            <asp:TemplateField HeaderText="Acțiuni">
                <ItemTemplate>
                    <asp:Button runat="server" Text="Rezolvat" CommandName="Rezolvat" CommandArgument='<%# Eval("IdBug") %>'
                        OnClientClick="return confirm('Sunteți sigur că doriți să marcați acest bug ca rezolvat?');"
                        CssClass='<%# Eval("Status").ToString() == "0" ? "btn btn-success" : "btn btn-secondary" %>'
                        Enabled='<%# Eval("Status").ToString() == "0" %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>