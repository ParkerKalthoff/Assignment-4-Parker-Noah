using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_4_Parker_Noah.instructorPage
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
                if (HttpContext.Current.Session["userType"].ToString().Trim() == "Member" || HttpContext.Current.Session["userType"].ToString().Trim() == "Administrator")
                {
                    Session.Clear();
                    Session.RemoveAll();
                    Session.Abandon();
                    Session.Abandon();
                    FormsAuthentication.SignOut();
                    Response.Redirect("logonpage/logon.aspx", true);
                }
            } else
            {
                Response.Redirect("../logonpage/logon.aspx", true);

            }


            int sessionUserID = int.Parse(HttpContext.Current.Session["UserID"].ToString());

            var query = from section in dbcon.Sections
                        join member in dbcon.Members on section.Member_ID equals member.Member_UserID
                        where section.Instructor_ID == sessionUserID
                        group new { Section = section, Member = member } by section.SectionID into grouped
                        select new
                        {
                            SectionName = grouped.First().Section.SectionName,
                            First_Name = grouped.First().Member.MemberFirstName,
                            Last_Name = grouped.First().Member.MemberLastName,
                        };

            GridView1.DataSource = query.ToList();
            GridView1.DataBind();
        }
    }
}