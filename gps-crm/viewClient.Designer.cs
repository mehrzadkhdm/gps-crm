namespace gps_crm
{
    partial class viewClient
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.textBoxCellPhone = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxPhone = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxCompany = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxlName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxfName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonOk.Location = new System.Drawing.Point(12, 250);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 10;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(244, 250);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdate.TabIndex = 11;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // textBoxCellPhone
            // 
            this.textBoxCellPhone.Location = new System.Drawing.Point(125, 195);
            this.textBoxCellPhone.Name = "textBoxCellPhone";
            this.textBoxCellPhone.Size = new System.Drawing.Size(194, 20);
            this.textBoxCellPhone.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 198);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "Cell Phone";
            // 
            // textBoxPhone
            // 
            this.textBoxPhone.Location = new System.Drawing.Point(125, 160);
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.Size = new System.Drawing.Size(194, 20);
            this.textBoxPhone.TabIndex = 25;
            this.textBoxPhone.TextChanged += new System.EventHandler(this.checkInput);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Phone";
            // 
            // textBoxCompany
            // 
            this.textBoxCompany.Location = new System.Drawing.Point(125, 125);
            this.textBoxCompany.Name = "textBoxCompany";
            this.textBoxCompany.Size = new System.Drawing.Size(194, 20);
            this.textBoxCompany.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Company";
            // 
            // textBoxlName
            // 
            this.textBoxlName.Enabled = false;
            this.textBoxlName.Location = new System.Drawing.Point(125, 55);
            this.textBoxlName.Name = "textBoxlName";
            this.textBoxlName.Size = new System.Drawing.Size(194, 20);
            this.textBoxlName.TabIndex = 21;
            this.textBoxlName.TextChanged += new System.EventHandler(this.checkInput);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Last Name";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(125, 90);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(194, 20);
            this.textBoxEmail.TabIndex = 22;
            this.textBoxEmail.TextChanged += new System.EventHandler(this.checkInput);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Email";
            // 
            // textBoxfName
            // 
            this.textBoxfName.Enabled = false;
            this.textBoxfName.Location = new System.Drawing.Point(125, 20);
            this.textBoxfName.Name = "textBoxfName";
            this.textBoxfName.Size = new System.Drawing.Size(194, 20);
            this.textBoxfName.TabIndex = 19;
            this.textBoxfName.TextChanged += new System.EventHandler(this.checkInput);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "First Name";
            // 
            // viewClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 305);
            this.Controls.Add(this.textBoxCellPhone);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxPhone);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxCompany);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxlName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxfName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.buttonOk);
            this.Name = "viewClient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "View/Edit user";
            this.Load += new System.EventHandler(this.viewClient_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.TextBox textBoxCellPhone;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxPhone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxCompany;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxlName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxfName;
        private System.Windows.Forms.Label label1;
    }
}