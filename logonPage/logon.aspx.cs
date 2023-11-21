using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_4_Parker_Noah.logonPage
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        KarateLinqToSQLDataContext dbcon;
        string conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\parke\\source\\repos\\ParkerKalthoff\\Assignment-4-Parker-Noah\\KarateSchool.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False";

        protected void Page_Load(object sender, EventArgs e)
        {
            dbcon = new KarateLinqToSQLDataContext(conn);
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            string nUserName = Login1.UserName;
            string nPassword = Login1.Password;


            HttpContext.Current.Session["nUserName"] = nUserName;
            HttpContext.Current.Session["uPass"] = nPassword;

            NetUser myUser = (from x in dbcon.NetUsers
                              where 
                                x.UserName      == HttpContext.Current.Session["nUserName"].ToString()
                              &&    
                                x.UserPassword  == HttpContext.Current.Session["uPass"].ToString()

                              select x).First();
            if (myUser != null)
            {
                //Add UserID and User type to the Session
                HttpContext.Current.Session["UserID"] = myUser.UserID;
                HttpContext.Current.Session["UserType"] = myUser.UserType;

            }
            if (myUser != null && HttpContext.Current.Session["userType"].ToString().Trim() == "Member")
            {

                FormsAuthentication.RedirectFromLoginPage(HttpContext.Current.Session["nUserName"].ToString(), true);

                Response.Redirect("~/memberPage/member.aspx"); /* Member Page */
            }
            else if (myUser != null && HttpContext.Current.Session["userType"].ToString().Trim() == "Instructor")
            {

                FormsAuthentication.RedirectFromLoginPage(HttpContext.Current.Session["nUserName"].ToString(), true);

                Response.Redirect("~/[Folder Name]/[ASPX NAME].aspx"); /* Instructor Page */
            }
            else
                Response.Redirect("Logon.aspx", true);


        }
    }
}