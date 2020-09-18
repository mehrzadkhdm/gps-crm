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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] csb = Convert.FromBase64String(gps_crm.Properties.Resources.database);
            string cs = Encoding.Default.GetString(csb);
            using (var con = new MySqlConnection(cs))
            {
                con.Open();

                string sql = string.Format("SELECT * FROM `gps-crm`.agents WHERE name='{0}' AND password='{1}'",
                    textBoxUser.Text, Convert.ToBase64String(Encoding.UTF8.GetBytes(textBoxPass.Text)));
                using (var cmd = new MySqlCommand(sql, con))
                {
                    cmd.ExecuteNonQuery();

                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (!rdr.HasRows)
                            return;
                        while (rdr.Read())
                        {
                            this.Tag = rdr;
                        }
                        this.Hide();
                        if (rdr[4].ToString() == "1")
                        {
                            adminForm myForm = new adminForm(this);
                            myForm.Closed += (s, args) => this.Close();
                            myForm.Show();
                        }
                        else
                        {
                            agentForm myForm = new agentForm(this);
                            myForm.Closed += (s, args) => this.Close();
                            myForm.Show();

                        }
                        //dataInfos.Add(new dataInfo(rdr[3].ToString(), rdr[4].ToString(), DateTime.Parse(rdr[5].ToString())));
                    }
                }
            }

        }

        private void textBoxUser_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                textBoxPass.Focus();
        }

        private void textBoxPass_Enter(object sender, EventArgs e)
        {
            textBoxPass.SelectAll();
        }

        private void textBoxPass_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.Focus();
                button1_Click(sender, e);
            }

        }

        private void textBoxUser_Enter(object sender, EventArgs e)
        {
            textBoxUser.SelectAll();
        }
    }
}
