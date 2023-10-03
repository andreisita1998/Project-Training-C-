using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRTRAINING
{
    public partial class TaskC : System.Web.UI.UserControl
    {
        private FisiereController fisiereController = new FisiereController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IsAuthenticated"] == null || !(bool)Session["IsAuthenticated"])
            {
                Response.Redirect("~/Login.aspx");
            }

            if (!IsPostBack)
            {
                LoadActivitati();
                BindGrid();
            }
        }

        private void LoadActivitati()
        {
            string query = "SELECT IdActivitate, Titlu FROM Activitati";
            DataTable activitatiData = fisiereController.GetTableData(query, null);
            ddlActivitati.DataSource = activitatiData;
            ddlActivitati.DataTextField = "Titlu";
            ddlActivitati.DataValueField = "IdActivitate";
            ddlActivitati.DataBind();
        }

        private void BindGrid()
        {
            string query = "SELECT Id, Nume, Descriere, Url FROM Files";
            DataTable fisiereData = fisiereController.GetTableData(query, null);
            fileGridView.DataSource = fisiereData;
            fileGridView.DataBind();
        }

        protected void btnUploadFile_Click(object sender, EventArgs e)
        {
            string fileDescription = fileDescriptionTextBox.Text;
            HttpPostedFile uploadedFile = fileUploadControl.PostedFile;
            int selectedActivitateId = Convert.ToInt32(ddlActivitati.SelectedValue);

            if (uploadedFile != null && uploadedFile.ContentLength > 0)
            {
                try
                {
                    string fileName = Path.GetFileName(uploadedFile.FileName);
                    string fileExtension = Path.GetExtension(fileName);
                    string uniqueFileName = DateTime.Now.Ticks.ToString() + fileExtension;
                    string uploadDirectory = Server.MapPath("~/userfiles/files/");

                    if (!Directory.Exists(uploadDirectory))
                    {
                        Directory.CreateDirectory(uploadDirectory);
                    }

                    string filePath = Path.Combine(uploadDirectory, uniqueFileName);
                    uploadedFile.SaveAs(filePath);

                    fisiereController.UploadFile(selectedActivitateId, fileName, fileDescription, filePath);

                    Response.Write("Fișierul a fost încărcat cu succes!");

                    BindGrid();
                }
                catch (Exception ex)
                {
                    Response.Write("A apărut o eroare la încărcarea fișierului: " + ex.Message);
                }
            }
            else
            {
                Response.Write("Nu ați ales un fișier pentru încărcare.");
            }
        }

        protected void fileGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            fileGridView.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void fileGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            fileGridView.EditIndex = -1;
            BindGrid();
        }

        protected void fileGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int fileId = Convert.ToInt32(fileGridView.DataKeys[e.RowIndex].Values["Id"]);
            TextBox updatedDescriptionTextBox = fileGridView.Rows[e.RowIndex].FindControl("txtUpdatedDescription") as TextBox;

            if (updatedDescriptionTextBox != null)
            {
                string updatedDescription = updatedDescriptionTextBox.Text;
                fisiereController.UpdateFileDescription(fileId, updatedDescription);
            }

            fileGridView.EditIndex = -1;
            BindGrid();
        }

        protected void fileGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int fileId = Convert.ToInt32(fileGridView.DataKeys[e.RowIndex].Values["Id"]);
            fisiereController.DeleteFile(fileId);
            BindGrid();
        }
    }
}