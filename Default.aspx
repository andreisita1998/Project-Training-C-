<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PRTRAINING.Default" MasterPageFile="~/Site.Master" %>
<%@ Register Src="TaskC.ascx" TagName="TaskC" TagPrefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h1>Task List</h1>
        <asp:DropDownList ID="ddlUsers" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlUsers_SelectedIndexChanged">
            <asp:ListItem Text="-alegeti-" Value="" />
        </asp:DropDownList>
        <br /><br />
        <asp:GridView ID="gvActivities" runat="server" AutoGenerateColumns="False" DataKeyNames="IdActivitate" OnRowDeleting="gvActivities_RowDeleting">
            <Columns>
                <asp:BoundField DataField="IdActivitate" HeaderText="ID" />
                <asp:BoundField DataField="Titlu" HeaderText="Activitate" />
                <asp:BoundField DataField="Nume" HeaderText="Persoana alocata" />
                <asp:BoundField DataField="Descriere" HeaderText="Descriere" />
                <asp:BoundField DataField="stare" HeaderText="Stare" />
                <asp:BoundField DataField="Deadline" HeaderText="Data" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:TemplateField HeaderText="Actiuni">
                    <ItemTemplate>
                        <a href='<%# "Task.aspx?Id=" + Eval("IdActivitate") %>' class="btn btn-sm btn-primary">Editare</a>
                        <asp:LinkButton ID="lnkDelete" runat="server" OnClientClick="return confirm('Sunteți sigur că doriți să ștergeți această activitate?');"
                            CommandName="Delete" CommandArgument='<%# Eval("IdActivitate") %>' class="btn btn-sm btn-danger" OnRowDeleting="gvActivities_RowDeleting">Stergere</asp:LinkButton>
                        <asp:Button ID="btnTakeInLucru" runat="server" Text="Preia in lucru" OnClick="btnTakeInLucru_Click"
    CommandArgument='<%# Eval("IdActivitate") %>' OnClientClick="return confirm('Sunteți sigur că doriți să preluați această activitate în lucru?');"
    Visible='<%# Eval("Stare").ToString() != "in lucru" && Eval("Stare").ToString() != "finalizat" %>'
    class="btn btn-sm btn-danger" CausesValidation="false" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />
        <asp:Button ID="btnAddTask" runat="server" Text="Adauga task" OnClick="btnAddTask_Click" class="btn btn-success" />
        <asp:Button ID="btnGoToTaskPage" runat="server" Text="Deschide pagina Task Foldere" OnClick="btnGoToTaskPage_Click" CssClass="btn btn-primary" />
        <i id="btnOpenFileModal" class="fas fa-file" style="cursor: pointer;"></i>
        <asp:Button ID="btnDetaliiTestare" runat="server" Text="Detalii Testare" OnClick="btnDetaliiTestare_Click" CssClass="btn btn-primary" />
    </div>

    <div id="fileUploadModal" class="modal fade" role="dialog">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <uc:TaskC ID="taskCControl" runat="server" />
            </div>
        </div>
    </div>
    <script>
        $(document).ready(function () {
            $("#btnOpenFileModal").click(function () {
                $("#fileUploadModal").modal("show");
            });
        });
    </script>
</asp:Content>
