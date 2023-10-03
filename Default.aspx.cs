using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;

namespace PRTRAINING
{
    public partial class Default : System.Web.UI.Page
    {
        private DefaultController defaultController = new DefaultController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IsAuthenticated"] == null || !(bool)Session["IsAuthenticated"])
            {
                Response.Redirect("~/Login.aspx");
            }

            if (!IsPostBack)
            {
                BindUsersDropdown();
            }

            BindGrid();
        }

        protected void BindGrid()
        {
            string userName = ddlUsers.SelectedValue;
            DataTable dt = defaultController.GetActivities(userName);

            gvActivities.DataSource = dt;
            gvActivities.DataBind();
        }

        protected void BindUsersDropdown()
        {
            DataTable dt = defaultController.GetDistinctUsers();

            ddlUsers.DataSource = dt;
            ddlUsers.DataTextField = "Nume";
            ddlUsers.DataValueField = "Nume";
            ddlUsers.DataBind();

            ddlUsers.Items.Insert(0, new ListItem("-alegeti-", ""));
        }

        protected void ddlUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void btnTakeInLucru_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int idActivitate = Convert.ToInt32(btn.CommandArgument);
            defaultController.UpdateActivityStatus(idActivitate);
            BindGrid();
        }

        protected void gvActivities_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int idActivitate = Convert.ToInt32(gvActivities.DataKeys[e.RowIndex].Value);
            defaultController.DeleteActivity(idActivitate);
            BindGrid();
        }

        protected void btnAddTask_Click(object sender, EventArgs e)
        {
            Response.Redirect("Task.aspx");
        }

        protected void btnGoToTaskPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("TaskD.aspx");
        }

        protected void btnDetaliiTestare_Click(object sender, EventArgs e)
        {
            Response.Redirect("Buguri.aspx");
        }

        
       
    }
}