using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Assignment_4_Parker_Noah.administratorPage
{
    public partial class administrator : System.Web.UI.Page
    {


        string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\nkalt\\source\\repos\\ParkerKalthoff\\Assignment-4-Parker-Noah\\KarateSchool.mdf;Integrated Security=True;Connect Timeout=30";
        KarateLinqToSQLDataContext dbcon;

        public void RefreshData()
        {
            try
            {
                //sql connection object
                using (SqlConnection conn = new SqlConnection(connString))
                {

                    //retrieve the SQL Server instance version
                    string query1 = "select * from Member";
                    string query2 = "select * from Instructor";
                    // open connection
                    conn.Open();
                    //define the SqlCommand object
                    SqlCommand cmd1 = new SqlCommand(query1, conn);
                    SqlCommand cmd2 = new SqlCommand(query2, conn);


                    //set the SqlDataAdapter object
                    SqlDataAdapter dAdapter1 = new SqlDataAdapter(cmd1);
                    SqlDataAdapter dAdapter2 = new SqlDataAdapter(cmd2);

                    //define dataset
                    DataSet ds1 = new DataSet();
                    DataSet ds2 = new DataSet();

                    //fill dataset with query results
                    dAdapter1.Fill(ds1);
                    dAdapter2.Fill(ds2);

                    //set DataGridView control to read-only
                    //resultGridView = true;

                    //set the DataGridView control's data source/data table
                    GridView1.DataSource = ds1.Tables[0];
                    GridView2.DataSource = ds2.Tables[0];
                    //close connection
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                //display error message
                MessageBox.Show("Exception: " + ex.Message);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            dbcon = new KarateLinqToSQLDataContext(connString);

            if (Session.Count != 0)
            {
                if (HttpContext.Current.Session["userType"].ToString().Trim() == "Member" || HttpContext.Current.Session["userType"].ToString().Trim() == "Instructor")
                {
                    Session.Clear();
                    Session.RemoveAll();
                    Session.Abandon();
                    Session.Abandon();
                    FormsAuthentication.SignOut();
                    Response.Redirect("logonpage/logon.aspx", true);
                }
            }
            else
            {
                Response.Redirect("../logonpage/logon.aspx", true);

            }


            var queryResult1 = (from x in dbcon.Members
                               select x);
            var queryResult2 = (from x in dbcon.Instructors
                                select x);

            GridView1.DataSource = queryResult1.ToList();
            GridView1.DataBind();
            GridView2.DataSource = queryResult2.ToList();
            GridView2.DataBind();
        }

        protected void deleteMemberButton_Click(object sender, EventArgs e)
        {
            try
            {
                //sql connection object
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    string idNumber = deleteMIDTXT.Text.Trim();
                    string deleteQuery = "DELETE from Member WHERE Member_UserID='" + idNumber + "'";

                    try
                    {
                        //open connection
                        conn.Open();

                        //connect query
                        SqlCommand sqlcom = new SqlCommand(deleteQuery, conn);

                        DialogResult confirmDelete = MessageBox.Show("Are your sure you want to delete the record with idNumber=" + idNumber + "?");
                        if (confirmDelete == DialogResult.No)
                        {
                            return;
                        }
                        sqlcom.ExecuteNonQuery();
                        MessageBox.Show("Delete successful");
                        //Refresh data in the DataGridView
                        RefreshData();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    //close connection
                    conn.Close();
                }
            }
            catch (SqlException ex)
            {
                //display error message
                MessageBox.Show("Exception: " + ex.Message);
            }
        }

        protected void deleteInstructorButton_Click(object sender, EventArgs e)
        {
            try
            {
                //sql connection object
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    string idNumber = deleteIIDTXT.Text.Trim();
                    string deleteQuery = "DELETE from Instructor WHERE InstructorID='" + idNumber + "'";

                    try
                    {
                        //open connection
                        conn.Open();

                        //connect query
                        SqlCommand sqlcom = new SqlCommand(deleteQuery, conn);

                        DialogResult confirmDelete = MessageBox.Show("Are your sure you want to delete the record with idNumber=" + idNumber + "?");
                        if (confirmDelete == DialogResult.No)
                        {
                            return;
                        }
                        sqlcom.ExecuteNonQuery();
                        MessageBox.Show("Delete successful");
                        //Refresh data in the DataGridView
                        RefreshData();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    //close connection
                    conn.Close();
                }
            }
            catch (SqlException ex)
            {
                //display error message
                MessageBox.Show("Exception: " + ex.Message);
            }
        }

        protected void addMemberButton_Click(object sender, EventArgs e)
        {
            int memberID = Convert.ToInt32(addMIDTXT.Text.Trim());
            string fName = addMFnameTXT.Text.Trim();
            string lName = addMLnameTXT.Text.Trim();
            DateTime dateJoined = Convert.ToDateTime(addMDateTXT.Text.Trim());
            int phone = Convert.ToInt32(addMPhoneTXT.Text.Trim());
            string email = addMEmailTXT.Text.Trim();

            try
            {
                //sql connection object
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    //query
                    string insertQuery = "INSERT INTO Member(Member_UserID, MemberFirstName, " +
                        "MemberLastName, MemberDateJoined, MemberPhoneNumber, MemberEmail)" +
                        " VALUES('" + memberID + "'," + "'" + fName + "'," + lName + ","
                        + dateJoined + "," + phone + "," + email + ")";

                    try
                    {
                        //open connection
                        conn.Open();

                        //connect query
                        SqlCommand sqlcom = new SqlCommand(insertQuery, conn);

                        sqlcom.ExecuteNonQuery();
                        MessageBox.Show("Done");
                        //Refresh data in the DataGridView
                        RefreshData();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    //close connection
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                //display error message
                MessageBox.Show("Exception: " + ex.Message);
            }
        }

        protected void addInstructorButton_Click(object sender, EventArgs e)
        {
            int memberID = Convert.ToInt32(addIIDTXT.Text.Trim());
            string fName = addIFnameTXT.Text.Trim();
            string lName = addILnameTXT.Text.Trim();
            int phone = Convert.ToInt32(addIPhoneTXT.Text.Trim());

            try
            {
                //sql connection object
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    //query
                    string insertQuery = "INSERT INTO Instructor(InstructorID, InstructorFirstName, " +
                        "InstructorLastName, InstructorPhoneNumber)" +
                        " VALUES('" + memberID + "'," + "'" + fName + "'," + lName + "," + phone + ")";

                    try
                    {
                        //open connection
                        conn.Open();

                        //connect query
                        SqlCommand sqlcom = new SqlCommand(insertQuery, conn);

                        sqlcom.ExecuteNonQuery();
                        MessageBox.Show("Done");
                        //Refresh data in the DataGridView
                        RefreshData();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    //close connection
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                //display error message
                MessageBox.Show("Exception: " + ex.Message);
            }
        }

        protected void assignButton_Click(object sender, EventArgs e)
        {
            string memberID = assignTXT.Text.Trim();
            string sectionID = sectionTXT.Text.Trim();

            try
            {
                //sql connection object
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    //query
                    string updateQuery = "Update Section SET "
                        + "MemberID='" + memberID + "' WHERE SectionID='" + sectionID + "'";

                    try
                    {
                        //open connection
                        conn.Open();

                        //connect query
                        SqlCommand sqlcom = new SqlCommand(updateQuery, conn);

                        sqlcom.ExecuteNonQuery();
                        MessageBox.Show("Record updated");
                        //Refresh data in the DataGridView
                        RefreshData();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    //close connection
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                //display error message
                MessageBox.Show("Exception: " + ex.Message);
            }
        }
    }
}