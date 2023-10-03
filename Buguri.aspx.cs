using System;
using System.Web.UI.WebControls;

namespace PRTRAINING
{
    public partial class Buguri : System.Web.UI.Page
    {
        private BuguriController buguriController = new BuguriController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IsAuthenticated"] == null || !(bool)Session["IsAuthenticated"])
            {
                Response.Redirect("~/Login.aspx");
            }
            if (!IsPostBack)
            {
                BindActivitati();
                BindGrid();
            }
        }

        protected void BindActivitati()
        {
            ddlActivitati.DataSource = buguriController.LoadActivitati();
            ddlActivitati.DataTextField = "Titlu";
            ddlActivitati.DataValueField = "IdActivitate";
            ddlActivitati.DataBind();
        }

        protected void btnAdaugaBug_Click(object sender, EventArgs e)
        {
            int idActivitate = Convert.ToInt32(ddlActivitati.SelectedValue);
            string bug = txtBug.Text;

            buguriController.AdaugaBug(idActivitate, bug);

            txtBug.Text = string.Empty;
            BindGrid();
        }

        protected void gvBuguri_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Rezolvat")
            {
                int idBug = Convert.ToInt32(e.CommandArgument);
                buguriController.MarcazaBugRezolvat(idBug);
                BindGrid();
            }
        }

        private void BindGrid()
        {
            gvBuguri.DataSource = buguriController.GetBuguri();
            gvBuguri.DataBind();
        }
    }
}