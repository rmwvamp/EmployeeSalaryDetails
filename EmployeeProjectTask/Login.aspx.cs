using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace EmployeeProjectTask
{
    public partial class Login1 : System.Web.UI.Page
    {
         string str = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        string username, password = string.Empty;

        protected void btnLogin_Click(object sender, EventArgs e)
        {
             try
            {
                
                    username = ConfigurationManager.AppSettings["username"];
                    password = ConfigurationManager.AppSettings["password"];
                    if (username == txtUsername.Text.Trim() && password == txtPassword.Text.Trim())
                    {
                        Session["admin"] = username;
                        //Response.Redirect("Weclome.aspx", false);
                        //Response.Redirect("/Emplouyeeelcome.aspx",false);
                        Response.Redirect("Employee/Welcome.aspx",false);

                    }
                    else
                    {
                        showErrorMsg("Admin");
                    }

                
                


            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
              

            }
        }
        private void showErrorMsg(string userType)
        {
            lblMsg.Visible = true;
            lblMsg.Text = "<b>" + userType + "</b> credentials are incorrect..!";
            lblMsg.CssClass = "alert alert-danger";

        }

        private void clear()
        {
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
    
    }
}