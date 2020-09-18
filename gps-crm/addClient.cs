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
    public partial class addClient : Form
    {
        public Form agentForm;
        public addClient(Form form)
        {
            InitializeComponent();
            agentForm = form;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void addClient_Load(object sender, EventArgs e)
        {
            buttonCreate.Enabled = false;
            buttonCreate.DialogResult = DialogResult.None;
        }

        private void checkInput(object sender, EventArgs e)
        {
            if (textBoxfName.Text.Trim() == string.Empty) return;
            if (textBoxlName.Text.Trim() == string.Empty) return;
            if (textBoxEmail.Text.Trim() == string.Empty) return;
            if (textBoxPhone.Text.Trim() == string.Empty) return;
            buttonCreate.Enabled = true;
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            byte[] csb = Convert.FromBase64String(gps_crm.Properties.Resources.database);
            string cs = Encoding.Default.GetString(csb);
            bool close = false;
            using (var con = new MySqlConnection(cs))
            {
                con.Open();

                string sql = string.Format("INSERT INTO  `gps-crm`.clients VALUES ('{0}', '{1}','{2}','{3}', '{4}','{5}','{6}')",
                    textBoxfName.Text.Trim(), textBoxlName.Text.Trim(),textBoxEmail.Text.Trim(), 
                    textBoxCompany.Text.Trim(), textBoxPhone.Text.Trim(), textBoxCellPhone.Text.Trim(),
                    agentForm.Tag.ToString());
                using (var cmd = new MySqlCommand(sql, con))
                {
                    try
                    {
                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show("User created successfully");
                            buttonCreate.DialogResult = DialogResult.OK;
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
