namespace Wheeler_Matthew_Semester_Project
{
    partial class HomePage
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
            this.btnNewClient = new System.Windows.Forms.Button();
            this.btnClientLookUp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNewClient
            // 
            this.btnNewClient.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnNewClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.btnNewClient.Location = new System.Drawing.Point(205, 205);
            this.btnNewClient.Name = "btnNewClient";
            this.btnNewClient.Size = new System.Drawing.Size(165, 138);
            this.btnNewClient.TabIndex = 0;
            this.btnNewClient.Text = "New Client";
            this.btnNewClient.UseVisualStyleBackColor = false;
            this.btnNewClient.Click += new System.EventHandler(this.newClientButton_Click);
            // 
            // btnClientLookUp
            // 
            this.btnClientLookUp.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnClientLookUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.btnClientLookUp.Location = new System.Drawing.Point(441, 205);
            this.btnClientLookUp.Name = "btnClientLookUp";
            this.btnClientLookUp.Size = new System.Drawing.Size(165, 138);
            this.btnClientLookUp.TabIndex = 1;
            this.btnClientLookUp.Text = "Client Look-Up";
            this.btnClientLookUp.UseVisualStyleBackColor = false;
            this.btnClientLookUp.Click += new System.EventHandler(this.clientLookUpButton_Click);
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(800, 580);
            this.Controls.Add(this.btnClientLookUp);
            this.Controls.Add(this.btnNewClient);
            this.Name = "HomePage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home Page";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNewClient;
        private System.Windows.Forms.Button btnClientLookUp;
    }
}

