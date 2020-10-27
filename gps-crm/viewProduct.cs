using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gps_crm
{
    public partial class viewProduct : Form
    {
        public string id;
        static byte[] csb = Convert.FromBase64String(gps_crm.Properties.Resources.database);
        public string cs = Encoding.Default.GetString(csb);

        public viewProduct(string sid)
        {
            InitializeComponent();
            id = sid;
        }

        private void viewProduct_Load(object sender, EventArgs e)
        {
            buttonOk.Enabled = false;
            buttonOk.DialogResult = DialogResult.None;
            using (var con = new MySqlConnection(cs))
            {
                con.Open();

                string sql = string.Format("SELECT * FROM `gps-crm`.products WHERE id='{0}';",id);
                using (var cmd = new MySqlCommand(sql, con))
                {
                    cmd.ExecuteNonQuery();

                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (!rdr.HasRows)
                            return;
                        while (rdr.Read())
                        {
                            textBoxProduct.Text = rdr[0].ToString();
                            textBoxName.Text = rdr[1].ToString();
                            textBoxPrice.Text = rdr[2].ToString();
                            textBoxDescription.Text = rdr[3].ToString();
                        }
                    }
                }
            }

        }
        private void checkInput(object sender, EventArgs e)
        {
            if (textBoxProduct.Text.Trim() == string.Empty) { buttonOk.Enabled = false; return; }
            if (textBoxName.Text.Trim() == string.Empty) { buttonOk.Enabled = false; return; }
            if (textBoxProduct.Text.Trim() == string.Empty) { buttonOk.Enabled = false; return; }
            if (textBoxDescription.Text.Trim() == string.Empty) { buttonOk.Enabled = false; return; }
            buttonOk.Enabled = true;
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

                string sql = string.Format("UPDATE `gps-crm`.products SET product='{0}', name='{1}', price='{2}', description='{3}' WHERE id = '{4}';",
                    textBoxProduct.Text.Trim(), textBoxName.Text.Trim(),
                    textBoxPrice.Text.Trim(), textBoxDescription.Text.Trim(),id);
                using (var cmd = new MySqlCommand(sql, con))
                {
                    try
                    {
                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show("product updated successfully");
                            buttonOk.DialogResult = DialogResult.OK;
                            close = true;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Error in updating product");
                    }
                }
            }
            if (close)
                Close();
        }

    }
}


