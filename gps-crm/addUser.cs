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
    public partial class addUser : Form
    {
        public addUser()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void addUser_Load(object sender, EventArgs e)
        {
            buttonCreate.Enabled = false;
            buttonCreate.DialogResult = DialogResult.None;
        }

        private void checkInput(object sender, EventArgs e)
        {
            if (textBoxName.Text.Trim() == string.Empty) return;
            if (textBoxEmail.Text.Trim() == string.Empty) return;
            if (textBoxSignature.Text.Trim() == string.Empty) return;
            if (textBoxPassword.Text.Trim() == string.Empty) return;
            if (textBoxRepeat.Text.Trim() == string.Empty) return;
            if (textBoxPassword.Text.Trim() != textBoxRepeat.Text.Trim()) return;
            buttonCreate.Enabled = true;


        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            byte[] csb = Convert.FromBase64String(gps_crm.Properties.Resources.database);
            string cs = Encoding.Default.GetString(csb);
            using (var con = new MySqlConnection(cs))
            {
                con.Open();

                string sql = string.Format("INSERT INTO  `gps-crm`.agents VALUES ('{0}', '{1}','{2}','{3}', 0)",
                    textBoxName.Text.Trim(), textBoxEmail.Text.Trim(), textBoxSignature.Text,
                    Convert.ToBase64String(Encoding.UTF8.GetBytes(textBoxPassword.Text.Trim())));
                using (var cmd = new MySqlCommand(sql, con))
                {
                    try
                    {
                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show("User created successfully");
                            buttonCreate.DialogResult = DialogResult.OK;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Error in creating user");
                    }
                }
            }
        }
    }
}
