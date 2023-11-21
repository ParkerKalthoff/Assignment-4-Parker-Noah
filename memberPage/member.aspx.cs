using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_4_Parker_Noah.memberPage
{

    public partial class WebForm1 : System.Web.UI.Page
    {

        
        string conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\parke\\source\\repos\\ParkerKalthoff\\Assignment-4-Parker-Noah\\KarateSchool.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False";
        KarateLinqToSQLDataContext dbcon;

        protected void Page_Load(object sender, EventArgs e)
        {
            dbcon = new KarateLinqToSQLDataContext(conn);

            if (Session.Count != 0)
            {
                if (HttpContext.Current.Session["userType"].ToString().Trim() == "Instructor" || HttpContext.Current.Session["userType"].ToString().Trim() == "Administrator")
                {
                    Session.Clear();
                    Session.RemoveAll();
                    Session.Abandon();
                    Session.Abandon();
                    FormsAuthentication.SignOut();
                    Response.Redirect("logonpage/logon.aspx", true);
                }
            }


            int sessionUserID = int.Parse(HttpContext.Current.Session["UserID"].ToString());

            var queryResult = (from x in dbcon.Sections
                             where x.Member_ID == sessionUserID
                             select x);

            GridView1.DataSource = queryResult.ToList();
            GridView1.DataBind();
        }
    }
}