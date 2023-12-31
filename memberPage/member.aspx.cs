﻿using System;
using System.Collections;
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
            } else
            {
                Response.Redirect("../logonpage/logon.aspx", true);
            }


            int sessionUserID = int.Parse(HttpContext.Current.Session["UserID"].ToString());
            var query = from section in dbcon.Sections
                        join instructor in dbcon.Instructors on section.Instructor_ID equals instructor.InstructorID
                        where section.Member_ID == sessionUserID
                        group new { Section = section, Instructor = instructor } by section.SectionID into grouped
                        select new
                        {
                            SectionName = grouped.First().Section.SectionName,
                            InstructorFirstName = grouped.First().Instructor.InstructorFirstName,
                            InstructorLastName = grouped.First().Instructor.InstructorLastName,
                            SectionFee = grouped.First().Section.SectionFee,
                            SectionStartDate = grouped.First().Section.SectionStartDate
                        };

            GridView1.DataSource = query.ToList();
            GridView1.DataBind();
        }
    }
}