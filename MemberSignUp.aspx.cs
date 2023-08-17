using System;
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
    public partial class WebForm5 : System.Web.UI.Page

    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;


        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //sign up button click event
        protected void Button1_Click(object sender, EventArgs e)
        {

            if (checkMemberExist())
            {
                Response.Write("<script>alert('Member already exist with this ID. Try other ID');</script>");
            }

            SignUpNewUser();


            //Response.Write("<script>alert('Not Valid credentials');</script>");
        }

        bool checkMemberExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from member_master_table where member_id='"+txtbxMemberID.Text.Trim()+"'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >=1)
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

        void SignUpNewUser()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO member_master_table(full_name,dob,contact_no,email,state,city,pincode,full_address,member_id,password,account_status) values(@full_name,@dob,@contact_no,@email,@state,@city,@pincode,@full_address,@member_id,@password,@account_status)", con);
                cmd.Parameters.AddWithValue("@full_name", txtbxfullName.Text.Trim());
                cmd.Parameters.AddWithValue("@dob", txtbxdob.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_no", txtbxcontactNumber.Text.Trim());
                cmd.Parameters.AddWithValue("@email", txtbxemailId.Text.Trim());
                cmd.Parameters.AddWithValue("@state", ddState.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@city", txtbxcity.Text.Trim());
                cmd.Parameters.AddWithValue("@pincode", txtbxpinCode.Text.Trim());
                cmd.Parameters.AddWithValue("@full_address", txtbxFullAddress.Text.Trim());
                cmd.Parameters.AddWithValue("@member_id", txtbxMemberID.Text.Trim());
                cmd.Parameters.AddWithValue("@password", txtbxPass.Text.Trim());
                cmd.Parameters.AddWithValue("@account_status", "pending");

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Sign Up Successful. Go to User Login to Login');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}