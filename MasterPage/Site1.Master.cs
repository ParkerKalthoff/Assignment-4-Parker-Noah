using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_4_Parker_Noah.MasterPage
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        KarateLinqToSQLDataContext dbcon;
        string conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\parke\\source\\repos\\ParkerKalthoff\\Assignment-4-Parker-Noah\\KarateSchool.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False";

        protected void Page_Load(object sender, EventArgs e)
        {
            


            dbcon = new KarateLinqToSQLDataContext(conn);
            

            int sessionUserID = int.Parse(HttpContext.Current.Session["UserID"].ToString());

            if (HttpContext.Current.Session["UserType"].ToString().Trim() == "Member") { 
            Member myUser = (from x in dbcon.Members
                              where x.Member_UserID == sessionUserID 
                              select x).First();

            lblUserName.Text = myUser.MemberFirstName +" "+ myUser.MemberLastName;
            } else if (HttpContext.Current.Session["UserType"].ToString().Trim() == "Instructor")
            {
                Instructor myUser = (from x in dbcon.Instructors
                                     where x.InstructorID == sessionUserID
                                 select x).First();
                lblUserName.Text = myUser.InstructorFirstName + " " + myUser.InstructorLastName;
            }
        }
    }
}