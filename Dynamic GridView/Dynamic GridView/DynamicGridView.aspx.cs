using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Collections.Generic;
using System.Web.UI;

public partial class Dynamic_GridView_DynamicGridView : System.Web.UI.Page
{
    string connectionString = ConfigurationManager.ConnectionStrings["Ginie"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dtResp = GetResponsibilitiesData();
            DynamicGridView(dtResp);
        }
    }

    private DataTable GetResponsibilitiesData()
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            string sql = "select Seq, MenuText, MenuParent, MenuCode, Publish from MenuBars867 where Publish = 'YES'";
            SqlCommand cmd = new SqlCommand(sql, con);

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();

            return dt;
        }
    }

    protected void DynamicGridView(DataTable dtResp)
    {
        if (dtResp.Rows.Count > 0)
        {
            // turning OFF column auto generation
            GridDyanmic.AutoGenerateColumns = true;

            // assigning data source to GridView
            GridDyanmic.DataSource = dtResp;
            GridDyanmic.DataBind();

            // Clear existing columns
            GridDyanmic.Columns.Clear();

            // Dynamically creating BoundFields or Columns using from the data source
            foreach (DataColumn col in dtResp.Columns)
            {
                BoundField boundField = new BoundField();
                boundField.DataField = col.ColumnName;
                boundField.HeaderText = col.ColumnName;
                GridDyanmic.Columns.Add(boundField);
            }

            // turning ON column auto generation
            GridDyanmic.AutoGenerateColumns = false;
        }
    }
}