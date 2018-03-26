using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text != string.Empty && TextBox2.Text != string.Empty)
            {
                ShowReport();
            }
            else
            {
                Showall();
            }
                      
            
        }

        private void Showall()
        {
            ReportViewer1.Reset();


            DataTable dt = GetallData();
            ReportDataSource ds = new ReportDataSource("DataSet1", dt);
            ReportViewer1.LocalReport.DataSources.Add(ds);

            ReportViewer1.LocalReport.ReportPath = "Report2.rdlc";

            ReportViewer1.LocalReport.Refresh();
        }

        private DataTable GetallData()
        {
            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["dbado1ConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("select * from vw_pro_information", con);
                
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        private void ShowReport()
        {
            ReportViewer1.Reset();

            
            DataTable dt = GetData(TextBox1.Text.ToString(), TextBox2.Text.ToString());
            ReportDataSource ds = new ReportDataSource("DataSet1", dt);
            ReportViewer1.LocalReport.DataSources.Add(ds);
          
            ReportViewer1.LocalReport.ReportPath = "Report1.rdlc";
         
            ReportParameter[] param = new ReportParameter[]{
                new ReportParameter("sdate",TextBox1.Text),
                new ReportParameter("edate",TextBox2.Text),
            };
            ReportViewer1.LocalReport.SetParameters(param);
          
            ReportViewer1.LocalReport.Refresh();
        }

        private DataTable GetData(string dateTime1, string dateTime2)
        {
            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["dbado1ConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("Sp_DisplayData", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@sdate", SqlDbType.NVarChar).Value = TextBox1.Text;
                cmd.Parameters.Add("@edate", SqlDbType.NVarChar).Value = TextBox2.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
    }
}