using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ELibraryManagementSystem
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {   
                if (Session["role"].Equals(""))
                                {
                                    LBUserLogin.Visible = true;
                                    LBSignUp.Visible = true;


                                    LBLogout.Visible = false;
                                    LBHelloUser.Visible = false;

                                    LBadminLogin.Visible = true;
                                    LBAuthorManage.Visible = false;
                                    LBPublisherManage.Visible = false;
                                    LBMemberManage.Visible = false;
                                    LBBookInven.Visible = false;
                                    LBBookIssue.Visible = false;
                                }
                else if (Session["role"].Equals("member"))
                {
                    LBUserLogin.Visible = false;
                    LBSignUp.Visible = false;


                    LBLogout.Visible = true;
                    LBHelloUser.Visible = true;
                    LBHelloUser.Text = "Hello "+Session["fullname"].ToString();

                    LBadminLogin.Visible = true;
                    LBAuthorManage.Visible = false;
                    LBPublisherManage.Visible = false;
                    LBMemberManage.Visible = false;
                    LBBookInven.Visible = false;
                    LBBookIssue.Visible = false;
                }
                else if (Session["role"].Equals("admin"))
                {
                    LBUserLogin.Visible = false;
                    LBSignUp.Visible = false;


                    LBLogout.Visible = true;
                    LBHelloUser.Visible = true;
                    LBHelloUser.Text = "Hello " + Session["fullname"].ToString();


                    LBadminLogin.Visible = false;
                    LBAuthorManage.Visible = true;
                    LBPublisherManage.Visible = true;
                    LBMemberManage.Visible = true;
                    LBBookInven.Visible = true;
                    LBBookIssue.Visible = true;
                }
                
            }
            catch (Exception ex)
            {
                
            }
            
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("Adminlogin.aspx");
        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddAuthor.aspx");
        }

        protected void LinkButton12_Click(object sender, EventArgs e)
        {
            Response.Redirect("PublisherDetails.aspx");
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddBookDetails.aspx");
        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            Response.Redirect("BookIssue.aspx");
        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Response.Redirect("MemberDetails.aspx");
        }

        //Logout button
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Session["member_id"] = "";
            Session["fullname"] = "";
            Session["role"] = "";
            Session["status"] = "";

            LBUserLogin.Visible = true;
            LBSignUp.Visible = true;


            LBLogout.Visible = false;
            LBHelloUser.Visible = false;

            LBadminLogin.Visible = true;
            LBAuthorManage.Visible = false;
            LBPublisherManage.Visible = false;
            LBMemberManage.Visible = false;
            LBBookInven.Visible = false;
            LBBookIssue.Visible = false;

            Response.Write("<script>alert('Logout Successfull');</script>");
            Response.Redirect("HomePage.aspx");
        }

        //view profile
        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("MemberProfile.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("MemberLogin.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("MemberSignUp.aspx");
        }

        protected void LBViewBook_Click(object sender, EventArgs e)
        {
            Response.Redirect("Viewbook.aspx");
        }
    }
}