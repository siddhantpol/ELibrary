﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ELibraryManagementSystem
{
    public partial class userLogin : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("select * from member_master_table where member_id='"+ TextBox1.Text.Trim() + "' and password='"+ TextBox2.Text.Trim() + "'",con);
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows) 
                {
                    while (rdr.Read())
                    {
                        Response.Write("<script>alert('Login Successfull');</script>");
                        Session["member_id"] = rdr.GetValue(8).ToString();
                        Session["fullname"] = rdr.GetValue(8).ToString();
                        Session["role"] = "member";
                        Session["status"] = rdr.GetValue(10).ToString();
                    }
                    Response.Redirect("HomePage.aspx");

                }
                else
                {
                    Response.Write("<script>alert('Wrong Details');</script>");
                }



            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('"+ex.Message+"');</script>");
            }
        }
    }
}