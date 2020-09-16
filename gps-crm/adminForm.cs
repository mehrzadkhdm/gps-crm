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
    public partial class adminForm : Form
    {
        public Form loginForm;
        static byte[] csb = Convert.FromBase64String(gps_crm.Properties.Resources.database);
        public string cs = Encoding.Default.GetString(csb);

        public adminForm(Form form)
        {
            InitializeComponent();
            loginForm = form;
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
            Form form = new addUser();
            form.ShowDialog();
        }

        private void addToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Form form = new addUser();
            form.ShowDialog();
        }
        private void updateRows()
        {
            //byte[] csb = Convert.FromBase64String(gps_crm.Properties.Resources.database);
            //string cs = Encoding.Default.GetString(csb);
            dataGridView1.Rows.Clear();
            using (var con = new MySqlConnection(cs))
            {
                con.Open();

                string sql = string.Format("SELECT * FROM `gps-crm`.agents");
                using (var cmd = new MySqlCommand(sql, con))
                {
                    cmd.ExecuteNonQuery();

                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (!rdr.HasRows)
                            return;
                        while (rdr.Read())
                        {
                            dataGridView1.Rows.Add(rdr[0], rdr[1]);
                            //Datagrid
                        }
                    }
                }
            }

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                using (var con = new MySqlConnection(cs))
                {
                    con.Open();

                    string sql = string.Format("DELETE FROM `gps-crm`.agents WHERE name ='{0}' AND role=0", row.Cells[0].Value.ToString());
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

                Form form = new viewUser(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString());
                form.ShowDialog();
            }
            updateRows();
        }
        
    }
}
