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
        private int lastSelectedProductKey;
        public ProductsScreen()
        {
            InitializeComponent();

            // Start
            ShowProducts();
        }

        private void ShowProducts()
        {
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
            if (textBoxProductName.Text == null 
                || textBoxProductBrand.Text == null
                || comboBoxProductCategory.Text == null
                || textBoxProductPrice.Text == null)
            {
                MessageBox.Show("Bitte fülle alle Werte aus!");
                return;
            }

            string productName = textBoxProductName.Text;
            string productBrand = textBoxProductBrand.Text;
            string productCategory = comboBoxProductCategory.Text;
            string productPrice = textBoxProductPrice.Text;

            

            string query = string.Format("insert into Products values('{0}','{1}','{2}','{3}')", productName, productBrand, productCategory, productPrice);
            ExecuteQuery(query);


            ClearAllFields();
            ShowProducts();
        }


        private void btnProductEdit_Click(object sender, EventArgs e)
        {
            if (lastSelectedProductKey == 0)
            {
                MessageBox.Show("Bitte wähle zuerst ein Produkt aus.");
                return;
            }

            string productName = textBoxProductName.Text;
            string productBrand = textBoxProductBrand.Text;
            string productCategory = comboBoxProductCategory.Text;
            string productPrice = textBoxProductPrice.Text;

            string query = string.Format("UPDATE Products SET Name='{0}', Brand='{1}', Category='{2}', Price='{3}' WHERE Id={4}",
                productName, productBrand, productCategory, productPrice, lastSelectedProductKey);
            ExecuteQuery(query);

            ShowProducts();
        }

        private void btnProductClear_Click(object sender, EventArgs e)
        {
            ClearAllFields();
        }
        private void btnProductDelete_Click(object sender, EventArgs e)
        {
            if (lastSelectedProductKey == 0)
            {
                MessageBox.Show("Bitte wähle zuerst ein Produkt aus.");
                return ;
            }
            string query = string.Format("DELETE FROM PRODUCTS WHERE Id={0}", lastSelectedProductKey);
            ExecuteQuery(query);


            ShowProducts();
        }
        private void productsDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxProductName.Text = productsDGV.SelectedRows[0].Cells[1].Value.ToString();
            textBoxProductBrand.Text = productsDGV.SelectedRows[0].Cells[2].Value.ToString();
            comboBoxProductCategory.Text = productsDGV.SelectedRows[0].Cells[3].Value.ToString();
            textBoxProductPrice.Text = productsDGV.SelectedRows[0].Cells[4].Value.ToString();

            lastSelectedProductKey = (int)productsDGV.SelectedRows[0].Cells[0].Value;
        }

        private void ClearAllFields()
        {
            textBoxProductBrand.Text = String.Empty;
            textBoxProductName.Text = String.Empty;
            textBoxProductPrice.Text = String.Empty;
            comboBoxProductCategory.Text = String.Empty;
            comboBoxProductCategory.SelectedItem = null;
        }

 
        private void ExecuteQuery(string query)
        {
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }
    }
}
