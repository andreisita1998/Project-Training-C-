using System;
using System.Web.UI;

namespace PRTRAINING
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckAuthentication();
                SetUsernameLabel();
            }
        }

        protected void CheckAuthentication()
        {
            if (Session["IsAuthenticated"] != null && (bool)Session["IsAuthenticated"])
            {
                // Utilizatorul este autentificat, astfel încât arătăm butonul de logout
                logoutLi.Visible = true;
                lblUtilizator.Text = "Utilizator: " + Session["Username"] + "   ";
            }
            else
            {
                // Utilizatorul nu este autentificat, ascundem butonul de logout
                logoutLi.Visible = false;
                lblUtilizator.Text = string.Empty;
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            // Deconectare și redirecționare către pagina de login
            Session["IsAuthenticated"] = false;
            Session["Username"] = null;
            Response.Redirect("~/Login.aspx");
        }
        protected void SetUsernameLabel()
        {
            if (Session["IsAuthenticated"] != null && (bool)Session["IsAuthenticated"])
            {
                userInfo.InnerText = "Utilizator: " + Session["Username"] + " ";
            }
            else
            {
                userInfo.InnerText = string.Empty;
            }
        }
    }
}