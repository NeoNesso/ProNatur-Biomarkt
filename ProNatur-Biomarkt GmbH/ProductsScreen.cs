using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ProNatur_Biomarkt_GmbH
{
    public partial class ProductsScreen : Form
{
        private SqlConnection sqlConnection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=""C:\Users\Internet\Documents\Pro-Natur Biomarkt GmbH.mdf"";Integrated Security = True; Connect Timeout = 30");
        public ProductsScreen()
        {
            InitializeComponent();

            // Start
            sqlConnection.Open();

            string query = "select * from Products";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);

            DataSet ds = new DataSet();
            sqlDataAdapter.Fill(ds);

            productsDGV.DataSource = ds.Tables[0];
            productsDGV.Columns[0].Visible = false;

            sqlConnection.Close();
        }

        private void btnProductSave_Click(object sender, EventArgs e)
        {
            string productName = textBoxProductName.Text;
        }

        private void btnProductEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnProductClear_Click(object sender, EventArgs e)
        {

        }

        private void btnProductDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
