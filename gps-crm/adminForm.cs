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
        public string myEmail = "";
        public List<string> myUsers = new List<string>();
        public List<string> myAgents = new List<string>();

        public adminForm(Form form)
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
            AddUser();
        }

        private void addToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            AddUser();
        }

        private void AddUser()
        {
            Form form = new addUser();
            DialogResult result = form.ShowDialog();
            if (result == DialogResult.OK)
                updateRows();
        }

        //private void AddProduct()
        //{
        //    Form form = new addProduct(this);
        //    DialogResult result = form.ShowDialog();
        //    if (result == DialogResult.OK)
        //        updateRows();
        //}

        private void updateRows()
        {
            //byte[] csb = Convert.FromBase64String(gps_crm.Properties.Resources.database);
            //string cs = Encoding.Default.GetString(csb);
            myUsers = new List<string>();
            myAgents = new List<string>();

            dataGridViewUser.Rows.Clear();
            using (var con = new MySqlConnection(cs))
            {
                con.Open();

                string sql = string.Format("SELECT * FROM `gps-crm`.agents");
                string search = textBoxSearch.Text.Trim();
                if (search.Length > 1)
                {
                    sql = string.Format("SELECT * FROM `gps-crm`.agents WHERE name LIKE '%{0}%' OR email LIKE '%{0}%'", search);
                }
                using (var cmd = new MySqlCommand(sql, con))
                {
                    cmd.ExecuteNonQuery();

                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                dataGridViewUser.Rows.Add(rdr[0], rdr[1]);
                                myAgents.Add(rdr[1].ToString());
                                //Datagrid
                            }
                        }
                    }
                }
            }

            dataGridViewClient.Rows.Clear();

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
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                dataGridViewClient.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6]);
                                myUsers.Add(rdr[2].ToString());
                                //Datagrid
                            }
                        }
                    }
                }
            }

            //------------
            dataGridViewProducts.Rows.Clear();

            using (var con = new MySqlConnection(cs))
            {
                con.Open();

                string sql = string.Format("SELECT * FROM `gps-crm`.products;");
                string search = textBoxSearch.Text.Trim();
                //if (search.Length > 1)
                //{
                //    sql = string.Format("SELECT * FROM `gps-crm`.clients where agentEmail = '{0}' and (fName like '%{1}%' or lName like '%{1}%' or email like '%{1}%')", myEmail, search);
                //}
                using (var cmd = new MySqlCommand(sql, con))
                {
                    cmd.ExecuteNonQuery();

                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                dataGridViewProducts.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4]);
                                //myUsers.Add(rdr[2].ToString());
                                //Datagrid
                            }
                        }
                    }
                }
            }


        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveUser();
        }

        private void editToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ViewUser();
        }
        private void ViewUser()
        {
            foreach (DataGridViewRow row in dataGridViewUser.SelectedRows)
            {

                Form form = new viewUser(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString());
                form.ShowDialog();
            }
            updateRows();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form form = new addClient(this);
            DialogResult result = form.ShowDialog();
            //if(result==DialogResult.OK)
            updateRows();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewUser.SelectedRows)
            {

                Form form = new viewClient(row.Cells[0].Value.ToString(), row.Cells[2].Value.ToString());
                form.ShowDialog();
            }
            updateRows();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to delete client ?", "Delete", MessageBoxButtons.OKCancel);
            if (result == DialogResult.Cancel)
                return;
            foreach (DataGridViewRow row in dataGridViewUser.SelectedRows)
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
        private void RemoveClient()
        {

        }
        private void RemoveProduct()
        {
            DialogResult result = MessageBox.Show("Do you want to delete the product ?", "Delete", MessageBoxButtons.OKCancel);
            if (result == DialogResult.Cancel)
                return;
            foreach (DataGridViewRow row in dataGridViewProducts.SelectedRows)
            {
                using (var con = new MySqlConnection(cs))
                {
                    con.Open();

                    string sql = string.Format("DELETE FROM `gps-crm`.products WHERE id ='{0}'", row.Cells["id"].Value.ToString());
                    using (var cmd = new MySqlCommand(sql, con))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            updateRows();

        }
        private void RemoveUser()
        {
            DialogResult result = MessageBox.Show("Do you want to delete agent/admin ?", "Delete", MessageBoxButtons.OKCancel);
            if (result == DialogResult.Cancel)
                return;
            string sql;
            foreach (DataGridViewRow row in dataGridViewUser.SelectedRows)
            {
                // check if the any client of the user exist in the admin acount
                bool stopDelete = false;
                using (var con = new MySqlConnection(cs))
                {
                    con.Open();

                    sql = string.Format("SELECT * FROM `gps-crm`.clients WHERE agentEmail ='{0}'", row.Cells[1].Value.ToString());
                    using (var cmd = new MySqlCommand(sql, con))
                    {
                        cmd.ExecuteNonQuery();
                        using (MySqlDataReader rdr = cmd.ExecuteReader())
                        {
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    if (myAgents.Contains(rdr[1].ToString()))
                                    {
                                        MessageBox.Show(string.Format("client {0} already exists", rdr[1].ToString()), "Warning");
                                        stopDelete = true;
                                        break;
                                    }

                                    //dataGridView1.Rows.Add(rdr[0], rdr[1]);
                                    //myAgents.Add(rdr[1].ToString());
                                    //Datagrid
                                }
                            }
                        }

                    }
                }
                if (stopDelete) return;
                // transfer clients to admin
                //
                using (var con = new MySqlConnection(cs))
                {
                    con.Open();

                    sql = string.Format("UPDATE `gps-crm`.clients SET agentEmail ='{0}' WHERE agentEmail = '{1}'", myEmail, row.Cells[1].Value.ToString());
                    using (var cmd = new MySqlCommand(sql, con))
                    {
                        cmd.ExecuteNonQuery();
                        //using (MySqlDataReader rdr = cmd.ExecuteReader())
                        //{
                        //    if (rdr.HasRows)
                        //    {
                        //        while (rdr.Read())
                        //        {
                        //            if (myAgents.Contains(rdr[1].ToString()))
                        //            {
                        //                MessageBox.Show(string.Format("client {0} already exists", rdr[1].ToString()), "Warning");
                        //                stopDelete = true;
                        //                break;
                        //            }

                        //            //dataGridView1.Rows.Add(rdr[0], rdr[1]);
                        //            //myAgents.Add(rdr[1].ToString());
                        //            //Datagrid
                        //        }
                        //    }
                        //}

                    }
                }

                using (var con = new MySqlConnection(cs))
                {
                    con.Open();

                    sql = string.Format("DELETE FROM `gps-crm`.agents WHERE name ='{0}'", row.Cells[0].Value.ToString());
                    using (var cmd = new MySqlCommand(sql, con))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            updateRows();
        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ViewUser();
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveUser();
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

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //addClient();
        }

        private void addToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form form = new addProduct(this);
            DialogResult result = form.ShowDialog();
            //if(result==DialogResult.OK)
            updateRows();

        }

        private void removeToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            RemoveProduct();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Form form = new addProduct(this);
            DialogResult result = form.ShowDialog();
            //if(result==DialogResult.OK)
            updateRows();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            RemoveProduct();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewProducts.SelectedRows)
            {

                Form form = new viewProduct(row.Cells["id"].Value.ToString());
                form.ShowDialog();
            }
            updateRows();

        }

        private void addToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            // add quotes

        }
    }
}
