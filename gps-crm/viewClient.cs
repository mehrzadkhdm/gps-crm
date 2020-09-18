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
    public partial class viewClient : Form
    {
        public string name;
        public string email;
        static byte[] csb = Convert.FromBase64String(gps_crm.Properties.Resources.database);
        public string cs = Encoding.Default.GetString(csb);

        public viewClient(string n, string e)
        {
            InitializeComponent();
            name = n;
            email = e;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void viewClient_Load(object sender, EventArgs e)
        {
            buttonUpdate.Enabled = false;
            buttonUpdate.DialogResult = DialogResult.None;
            using (var con = new MySqlConnection(cs))
            {
                con.Open();

                string sql = string.Format("SELECT * FROM `gps-crm`.clients WHERE fName='{0}' AND email = '{1}'", name, email);
                using (var cmd = new MySqlCommand(sql, con))
                {
                    cmd.ExecuteNonQuery();

                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (!rdr.HasRows)
                            return;
                        while (rdr.Read())
                        {
                            textBoxfName.Text = rdr[0].ToString();
                            textBoxlName.Text = rdr[1].ToString();
                            textBoxEmail.Text = rdr[2].ToString();
                            textBoxCompany.Text = rdr[3].ToString();
                            textBoxPhone.Text = rdr[4].ToString();
                            textBoxCellPhone.Text = rdr[5].ToString();
                        }
                    }
                }
            }

        }

        private void checkInput(object sender, EventArgs e)
        {
            if (textBoxEmail.Text.Trim() == string.Empty) return;
            if (textBoxPhone.Text.Trim() == string.Empty) return;
            buttonUpdate.Enabled = true;
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            byte[] csb = Convert.FromBase64String(gps_crm.Properties.Resources.database);
            string cs = Encoding.Default.GetString(csb);
            bool close = false;
            using (var con = new MySqlConnection(cs))
            {
                con.Open();

                string sql = string.Format("UPDATE `gps-crm`.clients SET email='{0}', company='{1}', phone='{2}', cellphone='{3}' WHERE fName = '{4}' AND lName='{5}'",
                    textBoxEmail.Text.Trim(), textBoxCompany.Text.Trim(),
                    textBoxPhone.Text.Trim(), textBoxCellPhone.Text.Trim(),
                    textBoxfName.Text.Trim(), textBoxlName.Text.Trim()); 
                using (var cmd = new MySqlCommand(sql, con))
                {
                    try
                    {
                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show("Client updated successfully");
                            buttonUpdate.DialogResult = DialogResult.OK;
                            close = true;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Error in updating client");
                    }
                }
            }
            if (close)
                Close();
        }
    }
}
