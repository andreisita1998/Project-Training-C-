<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TaskC.ascx.cs" Inherits="PRTRAINING.TaskC" %>

<h1>Task Foldere</h1>

<div class="form-group">
    <label for="ddlActivitati">Selectați activitatea:</label>
    <asp:DropDownList ID="ddlActivitati" runat="server" CssClass="form-control">
    </asp:DropDownList>
</div>
<div class="form-group">
    <label for="fileDescription">Descriere fișier:</label>
    <asp:TextBox ID="fileDescriptionTextBox" runat="server" CssClass="form-control" placeholder="Descriere fișier"></asp:TextBox>
</div>
<div class="form-group">
    <label for="file">Alege fișierul:</label>
    <asp:FileUpload ID="fileUploadControl" runat="server" CssClass="form-control-file" />
</div>
<asp:Button ID="btnUploadFile" runat="server" Text="Încarcă fisier" CssClass="btn btn-success" OnClick="btnUploadFile_Click" />

<asp:GridView ID="fileGridView" runat="server" AutoGenerateColumns="False" OnRowEditing="fileGridView_RowEditing" OnRowUpdating="fileGridView_RowUpdating" OnRowDeleting="fileGridView_RowDeleting" OnRowCancelingEdit="fileGridView_RowCancelingEdit" DataKeyNames="Id">
    <Columns>
        <asp:BoundField DataField="Id" HeaderText="ID" />
        <asp:BoundField DataField="Nume" HeaderText="Nume" />
        <asp:BoundField DataField="Descriere" HeaderText="Descriere" />
        <asp:TemplateField HeaderText="Descărcare">
            <ItemTemplate>
                <asp:HyperLink ID="fileDownloadLink" runat="server" Text="Descarcă" NavigateUrl='<%# Eval("Url") %>' />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:CommandField ShowEditButton="True" ButtonType="Button" EditText="Editează" CancelText="Anulează" UpdateText="Actualizează" />
        <asp:TemplateField HeaderText="Șterge">
            <ItemTemplate>
                <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete" Text="Șterge" OnClientClick="return confirm('Sunteți sigur că doriți să ștergeți acest fișier?');" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Descriere actualizată">
            <ItemTemplate>
                <asp:TextBox ID="txtUpdatedDescription" runat="server" Text='<%# Bind("Descriere") %>'></asp:TextBox>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>