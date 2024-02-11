﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace r_s_restaurent
{
    public partial class _default : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-505DFRT;Initial Catalog=rshotel;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            con.Open();

            roomDisplayRowCount();
            staffDisplayRowCount();
            clientDisplayRowCount();

            SqlCommand cmd2 = new SqlCommand("select top 3 * from room order by room_id desc", con);
            SqlDataReader dr2 = cmd2.ExecuteReader();
            DataList1.DataSource = dr2;
            DataList1.DataBind();
            dr2.Close();

            showStaff();
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "ViewDetail")
            {
                int roomId = Convert.ToInt32(e.CommandArgument);
                Response.Redirect($"roomDetails.aspx?id={roomId}");
            }
            /*
            else if (e.CommandName == "BookNow")
            {
                int roomId = Convert.ToInt32(e.CommandArgument);
                Response.Redirect($"bookRoom.aspx?RoomId={roomId}");
            }*/
        }

        private void roomDisplayRowCount()
        {
            // Assuming 'con' is an instance of SqlConnection and is properly configured
            try
            {
                //con.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM room", con);
                int rowCount = Convert.ToInt32(cmd.ExecuteScalar());
                roomCount.Text = rowCount.ToString();
                //Response.Write(rowCount);
            }
            catch (Exception ex)
            {
                // Handle any errors that might occur
                //lblRowCount.Text = "Error fetching row count.";
                // Log the error (ex.Message) for debugging purposes
            }
            finally
            {
                // Always close the connection
               
            }
        }

        private void staffDisplayRowCount()
        {
            // Assuming 'con' is an instance of SqlConnection and is properly configured
            try
            {
                //con.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM staff", con);
                int rowCount = Convert.ToInt32(cmd.ExecuteScalar());
                staffCount.Text = rowCount.ToString();
                //Response.Write(rowCount);
            }
            catch (Exception ex)
            {
                // Handle any errors that might occur
                //lblRowCount.Text = "Error fetching row count.";
                // Log the error (ex.Message) for debugging purposes
            }
            finally
            {
                // Always close the connection

            }
        }

        private void clientDisplayRowCount()
        {
            // Assuming 'con' is an instance of SqlConnection and is properly configured
            try
            {
                //con.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM [user]", con);
                int rowCount = Convert.ToInt32(cmd.ExecuteScalar());
                clientCount.Text = rowCount.ToString();
                //Response.Write(rowCount);
            }
            catch (Exception ex)
            {
                // Handle any errors that might occur
                //lblRowCount.Text = "Error fetching row count.";
                // Log the error (ex.Message) for debugging purposes
            }
            finally
            {
                // Always close the connection

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("about.aspx");
        }

        private void showStaff()
        {
            
            SqlCommand staffCmd = new SqlCommand("select * from staff order by staff_id desc", con);
            SqlDataReader staffDr = staffCmd.ExecuteReader();


            DataList2.DataSource = staffDr;
            DataList2.DataBind();
            staffDr.Close();
        }
    }
}