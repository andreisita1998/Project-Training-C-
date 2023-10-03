using System;
using System.Data;
using PRTRAINING.Controllers;

namespace PRTRAINING
{
    public partial class Task : System.Web.UI.Page
    {
        private TaskController taskController = new TaskController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IsAuthenticated"] == null || !(bool)Session["IsAuthenticated"])
            {
                Response.Redirect("~/Login.aspx");
            }

            if (!IsPostBack)
            {
                BindStatusDropdown();

                if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
                {
                    int taskId = Convert.ToInt32(Request.QueryString["Id"]);
                    BindTaskDetails(taskId);
                }
            }
        }

        protected void BindStatusDropdown()
        {
            DataTable dt = taskController.GetStatusList();

            ddlStatus.DataSource = dt;
            ddlStatus.DataTextField = "Nume";
            ddlStatus.DataValueField = "Nume";
            ddlStatus.DataBind();
        }

        protected void BindTaskDetails(int taskId)
        {
            DataTable dt = taskController.GetTaskDetails(taskId);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];

                txtTitle.Text = row["Titlu"].ToString();
                ddlStatus.SelectedValue = row["Stare"].ToString();
                txtDescription.Value = row["Descriere"].ToString();
                txtDeadline.Text = Convert.ToDateTime(row["Deadline"]).ToString("yyyy-MM-dd");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
            {
                int taskId = Convert.ToInt32(Request.QueryString["Id"]);
                UpdateTask(taskId);
            }
            else
            {
                AddTask();
            }
        }

        protected void AddTask()
        {
            string title = txtTitle.Text;
            string description = txtDescription.Value;
            string status = ddlStatus.SelectedValue;
            DateTime deadline = DateTime.ParseExact(txtDeadline.Text, "yyyy-MM-dd", null);
            int userId = Convert.ToInt32(txtIdUser.Text);

            taskController.AddTask(title, description, status, deadline, userId);

            Response.Redirect("Default.aspx");
        }

        protected void UpdateTask(int taskId)
        {
            string title = txtTitle.Text;
            string description = txtDescription.Value;
            string status = ddlStatus.SelectedValue;
            DateTime deadline = DateTime.ParseExact(txtDeadline.Text, "yyyy-MM-dd", null);
            int userId = Convert.ToInt32(txtIdUser.Text);

            taskController.UpdateTask(taskId, title, description, status, deadline, userId);

            Response.Redirect("Default.aspx");
        }

        protected void btnRenunta_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}