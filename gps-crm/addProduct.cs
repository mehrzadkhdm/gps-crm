using MySql.Data.MySqlClient;
using System;
using System.Text;
using System.Windows.Forms;

namespace gps_crm
{
    public partial class addProduct : Form
    {
        public Form agentForm;

        public addProduct(Form form)
        {
            InitializeComponent();
            agentForm = form;
        }
        private void checkInput(object sender, EventArgs e)
        {
            if (textBoxProduct.Text.Trim() == string.Empty) { buttonOk.Enabled = false; return; }
            if (textBoxName.Text.Trim() == string.Empty) { buttonOk.Enabled = false; return; }
            if (textBoxProduct.Text.Trim() == string.Empty) { buttonOk.Enabled = false; return; }
            if (textBoxDescription.Text.Trim() == string.Empty) { buttonOk.Enabled = false; return; }
            buttonOk.Enabled = true;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void addProduct_Load(object sender, EventArgs e)
        {
            buttonOk.Enabled = false;
        }

        private void textBoxProduct_TextChanged(object sender, EventArgs e)
        {
            checkInput(sender, e);
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            checkInput(sender, e);
        }

        private void textBoxPrice_TextChanged(object sender, EventArgs e)
        {
            checkInput(sender, e);
        }

        private void textBoxDescription_TextChanged(object sender, EventArgs e)
        {
            checkInput(sender, e);
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            byte[] csb = Convert.FromBase64String(gps_crm.Properties.Resources.database);
            string cs = Encoding.Default.GetString(csb);
            bool close = false;
            using (var con = new MySqlConnection(cs))
            {
                con.Open();
                // INSERT INTO  `gps-crm`.products (product, name, price, description) VALUES ('ysteyueu', 'prod 2','1.43','test peopm cjk')
                string sql = string.Format("INSERT INTO  `gps-crm`.products (product, name, price, description) VALUES ('{0}', '{1}','{2}','{3}')",
                    textBoxProduct.Text.Trim(), textBoxName.Text.Trim(), textBoxPrice.Text.Trim(),
                    textBoxDescription.Text.Trim());
                using (var cmd = new MySqlCommand(sql, con))
                {
                    try
                    {
                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show("Product added successfully");
                            buttonOk.DialogResult = DialogResult.OK;
                            close = true;

                        }
                    }
                    catch
                    {
                        MessageBox.Show("Error in adding product");
                    }
                }
            }
            if (close)
                Close();

        }
    }
}
