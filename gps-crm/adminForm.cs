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
        public adminForm(Form form)
        {
            InitializeComponent();
            loginForm = form;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
    }
}
