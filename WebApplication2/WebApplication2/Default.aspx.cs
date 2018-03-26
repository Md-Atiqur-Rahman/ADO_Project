using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class _Default : Page
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=MainAdo;Trusted_connection=true;");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGrid();
                DateTime today = System.DateTime.Today;
                Calendar2.TodaysDate = today;
                Calendar2.SelectedDate = Calendar2.TodaysDate;
                Calendar2.Visible = false;

            }
            
        }

        private void LoadGrid()
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select * from vw_pro_information", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
           
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Sp_InsertData", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", TextBox7.Text);
            cmd.Parameters.AddWithValue("@name", TextBox1.Text);
            //cmd.Parameters.AddWithValue("@Date", TextBox2.Text);
            DateTime today =DateTime.Parse( Calendar2.SelectedDate.ToShortDateString());
            Calendar2.TodaysDate = today;
            Calendar2.SelectedDate = Calendar2.TodaysDate;
            cmd.Parameters.AddWithValue("@Date", Calendar2.SelectedDate.ToString("dd-MM-yyyy"));
            cmd.Parameters.AddWithValue("@add", TextBox3.Text);
            cmd.Parameters.AddWithValue("@qty", TextBox4.Text);
            cmd.Parameters.AddWithValue("@price", TextBox5.Text);
            cmd.Parameters.AddWithValue("@dis", TextBox6.Text);

           
           
            con.Open();

            if(cmd.ExecuteNonQuery()>0)
            {
                Clear();
                LoadGrid();
                Save.Visible = true;
                TextBox2.Text = "";
                //TextBox2.Visible = false;
                //btnchange.Visible = false;
                con.Close();

            }
            //Clear();
            //LoadGrid();
            //con.Close(); 
        }

        protected void update_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Sp_UpdateData", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", TextBox1.Text);
            //cmd.Parameters.AddWithValue("@Date", TextBox2.Text);
            DateTime today = DateTime.Parse(Calendar2.SelectedDate.ToShortDateString());
            Calendar2.TodaysDate = today;
            Calendar2.SelectedDate = Calendar2.TodaysDate;
            cmd.Parameters.AddWithValue("@Date", Calendar2.SelectedDate.ToString("dd-MM-yyyy"));
            cmd.Parameters.AddWithValue("@add", TextBox3.Text);
            cmd.Parameters.AddWithValue("@qty", TextBox4.Text);
            cmd.Parameters.AddWithValue("@price", TextBox5.Text);
            cmd.Parameters.AddWithValue("@dis", TextBox6.Text);
            cmd.Parameters.AddWithValue("@id",TextBox7.Text);


            con.Open();
            if(cmd.ExecuteNonQuery()>0)
            {
                 Clear();
            LoadGrid();
            Save.Visible = true;
            TextBox2.Text = "";
            TextBox2.Visible = false;
            //btnchange.Visible = false;
            con.Close(); 
            }
           
        }

        private void Clear()
        {
            TextBox1.Text = "";
            //TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
            
        }

       

        protected void Edit_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from vw_pro_information where id='" + TextBox7.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
          
            TextBox1.Text = dt.Rows[0]["Pname"].ToString();
            TextBox2.Visible = true;
            Calendar2.Visible = false;
            TextBox2.Enabled = false;
            TextBox2.Text = dt.Rows[0]["Odate"].ToString();
            //btnchange.Visible = true;
            //DateTime today=Convert.ToDateTime( dt.Rows[0]["Odate"].ToString());
            //Calendar2.TodaysDate = today;
            //Calendar2.SelectedDate = Calendar2.TodaysDate;
            
         // Calendar2.SelectedDate =DateTime.Parse( dt.Rows[0]["Odate"].ToString());
            TextBox3.Text = dt.Rows[0]["ShippingAdd"].ToString();
            TextBox4.Text = dt.Rows[0]["Qty"].ToString();
            TextBox5.Text = dt.Rows[0]["UnitPrice"].ToString();
            TextBox6.Text = dt.Rows[0]["Discount"].ToString();


            GridView1.DataSource = dt;
            GridView1.DataBind();
            Save.Visible = false;
           
           
        
           
        }

        protected void delete_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Sp_DeleteData", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", TextBox7.Text);


            con.Open();
            cmd.ExecuteNonQuery();
            Clear();
            LoadGrid();
            con.Close();
        }

        //protected void btnchange_Click(object sender, EventArgs e)
        //{
        //    TextBox2.Enabled = false;
        //    Calendar2.Visible = true;
        //    Calendar2.Enabled = true;
        //}

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (Calendar2.Visible) 
            { 
            Calendar2.Visible = false;
            }
            else
            {
                Calendar2.Visible = true;
            }
        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            TextBox2.Text = Calendar2.SelectedDate.ToString("d");
            Calendar2.Visible = false;
        }
    }
}