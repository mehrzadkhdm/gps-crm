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
    public partial class agentForm : Form
    {
        public Form loginForm;
        public string myEmail = "";
        static byte[] csb = Convert.FromBase64String(gps_crm.Properties.Resources.database);
        public string cs = Encoding.Default.GetString(csb);

        public agentForm(Form form)
        {
            InitializeComponent();
            loginForm = form;
            MySqlDataReader rdr = (MySqlDataReader)loginForm.Tag;
            myEmail = rdr[1].ToString();
            Tag = myEmail;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            updateRows();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form form = new addClient(this);
            form.ShowDialog();
        }

        private void addToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Form form = new addClient(this);
            DialogResult result = form.ShowDialog();
            //if(result==DialogResult.OK)
            updateRows();
        }
        private void updateRows()
        {
            //byte[] csb = Convert.FromBase64String(gps_crm.Properties.Resources.database);
            //string cs = Encoding.Default.GetString(csb);
            dataGridView1.Rows.Clear();
            using (var con = new MySqlConnection(cs))
            {
                con.Open();

                string sql = string.Format("SELECT * FROM `gps-crm`.clients WHERE agentEmail = '{0}'", myEmail);
                string search = textBoxSearch.Text.Trim();
                if (search.Length > 1)
                {
                    sql = string.Format("SELECT * FROM `gps-crm`.clients where agentEmail = '{0}' and (fName like '%{1}%' or lName like '%{1}%' or email like '%{1}%')", myEmail, search);
                }
                using (var cmd = new MySqlCommand(sql, con))
                {
                    cmd.ExecuteNonQuery();

                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (!rdr.HasRows)
                            return;
                        while (rdr.Read())
                        {
                            dataGridView1.Rows.Add(rdr[0], rdr[1],rdr[2], rdr[3], rdr[4], rdr[5], rdr[6]);
                            //Datagrid
                        }
                    }
                }
            }

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to delete client ?", "Delete", MessageBoxButtons.OKCancel);
            if (result == DialogResult.Cancel)
                return;
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                using (var con = new MySqlConnection(cs))
                {
                    con.Open();

                    string sql = string.Format("DELETE FROM `gps-crm`.clients WHERE email ='{0}'", row.Cells[2].Value.ToString());
                    using (var cmd = new MySqlCommand(sql, con))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            updateRows();
        }

        private void editToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {

                Form form = new viewClient(row.Cells[0].Value.ToString(), row.Cells[2].Value.ToString());
                form.ShowDialog();
            }
            updateRows();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new addClient(this);
            DialogResult result = form.ShowDialog();
            //if(result==DialogResult.OK)
            updateRows();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBoxSearch.Clear();
            updateRows();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            updateRows();
        }
    }
}
