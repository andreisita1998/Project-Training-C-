using System;
using PRTRAINING.Controllers; 

namespace PRTRAINING
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.IsAuthenticated)
                {
                    Response.Redirect("Default.aspx");
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            LoginController loginController = new LoginController();

            if (loginController.AuthenticateUser(username, password))
            {
               
                Session["IsAuthenticated"] = true;
                Session["Username"] = username;
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                lblMessage.Text = "Autentificare eșuată. Verificați numele de utilizator și parola.";
                lblMessage.Visible = true;
            }
        }
    }
}