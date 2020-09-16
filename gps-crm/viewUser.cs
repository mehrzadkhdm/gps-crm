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
    public partial class viewUser : Form
    {
        public string name;
        public string email;
        static byte[] csb = Convert.FromBase64String(gps_crm.Properties.Resources.database);
        public string cs = Encoding.Default.GetString(csb);

        public viewUser(string n, string e)
        {
            InitializeComponent();
            name = n;
            email = e;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void viewUser_Load(object sender, EventArgs e)
        {
            buttonUpdate.Enabled = false;
            buttonUpdate.DialogResult = DialogResult.None;
            using (var con = new MySqlConnection(cs))
            {
                con.Open();

                string sql = string.Format("SELECT * FROM `gps-crm`.agents WHERE name='{0}' AND email = '{1}'", name, email);
                using (var cmd = new MySqlCommand(sql, con))
                {
                    cmd.ExecuteNonQuery();

                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (!rdr.HasRows)
                            return;
                        while (rdr.Read())
                        {
                            textBoxName.Text = rdr[0].ToString();
                            textBoxEmail.Text = rdr[1].ToString();
                            signatureHTML.DocumentText = rdr[2].ToString();
                            //dataGridView1.Rows.Add(rdr[0], rdr[1]);
                            //Datagrid
                        }
                    }
                }
            }

        }

        private void checkInput(object sender, EventArgs e)
        {
            if (textBoxName.Text.Trim() == string.Empty) return;
            if (textBoxEmail.Text.Trim() == string.Empty) return;
            //signatureHTML
            //if (textBoxSignature.Text.Trim() == string.Empty) return;
            if (textBoxPassword.Text.Trim() == string.Empty) return;
            if (textBoxRepeat.Text.Trim() == string.Empty) return;
            if (textBoxPassword.Text.Trim() != textBoxRepeat.Text.Trim()) return;
            buttonUpdate.Enabled = true;


        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            byte[] csb = Convert.FromBase64String(gps_crm.Properties.Resources.database);
            string cs = Encoding.Default.GetString(csb);
            bool close = false;
            using (var con = new MySqlConnection(cs))
            {
                con.Open();

                string sql = string.Format("INSERT INTO  `gps-crm`.agents VALUES ('{0}', '{1}','{2}','{3}', 0)",
                    textBoxName.Text.Trim(), textBoxEmail.Text.Trim(), signatureHTML.DocumentText,
                    Convert.ToBase64String(Encoding.UTF8.GetBytes(textBoxPassword.Text.Trim()))); ;
                using (var cmd = new MySqlCommand(sql, con))
                {
                    try
                    {
                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show("User created successfully");
                            buttonUpdate.DialogResult = DialogResult.OK;
                            close = true;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Error in creating user");
                    }
                }
            }
            if (close)
                Close();
        }
    }
}
