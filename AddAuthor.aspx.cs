using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ELibraryManagementSystem
{


    public partial class user : System.Web.UI.Page
    {


        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        
        //ADD
        protected void Button2_Click(object sender, EventArgs e)
        {   if(checkAuthorExist())
            {
                Response.Write("<script>alert('Author already exist!');</script>");
            }
            else
            {
                NewAuthor();
                clearform();
            }

        }


        //UPDATE
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkAuthorExist())
            {
                updateAuthor();
                clearform();
            }
            else
            {
                Response.Write("<script>alert('Author does not exist!');</script>");
            }
        }


        //DELETE
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkAuthorExist())
            {
                deleteAuthor();
                clearform();
            }
            else
            {
                Response.Write("<script>alert('Author does not exist!');</script>");
            }
        }


        //Go button click
        protected void Button1_Click(object sender, EventArgs e)
        {
            getAuthorByID();
        }

        void getAuthorByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from author_master_table where authour_id='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0][1].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid Author ID');</script>");
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }


        bool checkAuthorExist()
         {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == System.Data.ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("select * from author_master_table where authour_id='" + TextBox1.Text.Trim() + "'", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count >= 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                    return false;
                }

         }

        void NewAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO author_master_table(authour_id,authour_name) values(@authour_id,@authour_name)", con);
                cmd.Parameters.AddWithValue("@authour_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@authour_name", TextBox2.Text.Trim());
                

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Author Added Successful.');</script>");
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void updateAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("UPDATE author_master_table SET authour_name =@authour_name WHERE authour_id="+TextBox1.Text.Trim()+" ", con);
                cmd.Parameters.AddWithValue("@authour_name", TextBox2.Text.Trim());


                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Author Updated Successful.');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void deleteAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("DELETE from author_master_table WHERE authour_id=" + TextBox1.Text.Trim() + "", con);
                cmd.Parameters.AddWithValue("@authour_name", TextBox2.Text.Trim());


                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Author Deleted Successful.');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void clearform()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";

            GridView1.DataBind();
        }
    }
}