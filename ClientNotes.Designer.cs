namespace Wheeler_Matthew_Semester_Project
{
    partial class ClientNotes
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newClientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientLookUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbNoteQuery = new System.Windows.Forms.ListBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.rtbNewNote = new System.Windows.Forms.RichTextBox();
            this.rtbViewNote = new System.Windows.Forms.RichTextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem,
            this.newClientToolStripMenuItem,
            this.clientLookUpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(875, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // homeToolStripMenuItem
            // 
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.homeToolStripMenuItem.Text = "Home";
            // 
            // newClientToolStripMenuItem
            // 
            this.newClientToolStripMenuItem.Name = "newClientToolStripMenuItem";
            this.newClientToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.newClientToolStripMenuItem.Text = "New Client";
            // 
            // clientLookUpToolStripMenuItem
            // 
            this.clientLookUpToolStripMenuItem.Name = "clientLookUpToolStripMenuItem";
            this.clientLookUpToolStripMenuItem.Size = new System.Drawing.Size(99, 20);
            this.clientLookUpToolStripMenuItem.Text = "Client Look-Up";
            // 
            // lbNoteQuery
            // 
            this.lbNoteQuery.FormattingEnabled = true;
            this.lbNoteQuery.Location = new System.Drawing.Point(12, 72);
            this.lbNoteQuery.Name = "lbNoteQuery";
            this.lbNoteQuery.Size = new System.Drawing.Size(148, 95);
            this.lbNoteQuery.TabIndex = 2;
            this.lbNoteQuery.SelectedIndexChanged += new System.EventHandler(this.lbNoteQuery_SelectedIndexChanged);
            this.lbNoteQuery.SelectedValueChanged += new System.EventHandler(this.lbNoteQuery_SelectedIndexChanged);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(537, 177);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 3;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // rtbNewNote
            // 
            this.rtbNewNote.Location = new System.Drawing.Point(474, 249);
            this.rtbNewNote.Name = "rtbNewNote";
            this.rtbNewNote.Size = new System.Drawing.Size(378, 236);
            this.rtbNewNote.TabIndex = 4;
            this.rtbNewNote.Text = "";
            // 
            // rtbViewNote
            // 
            this.rtbViewNote.Location = new System.Drawing.Point(12, 249);
            this.rtbViewNote.Name = "rtbViewNote";
            this.rtbViewNote.Size = new System.Drawing.Size(400, 236);
            this.rtbViewNote.TabIndex = 5;
            this.rtbViewNote.Text = "";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(719, 177);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(50, 56);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(25, 13);
            this.lblName.TabIndex = 7;
            this.lblName.Text = "Null";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(9, 56);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(35, 13);
            this.lblID.TabIndex = 8;
            this.lblID.Text = "label1";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(33, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 43);
            this.label1.TabIndex = 9;
            this.label1.Text = "Click appropriate the date to view note(s)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(148, 233);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Client Notes";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(620, 233);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "New Client Note";
            // 
            // ClientNotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 563);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.rtbViewNote);
            this.Controls.Add(this.rtbNewNote);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.lbNoteQuery);
            this.Controls.Add(this.menuStrip1);
            this.Name = "ClientNotes";
            this.Text = "ClientNotes";
            this.Load += new System.EventHandler(this.ClientNotes_Load_1);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newClientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientLookUpToolStripMenuItem;
        private System.Windows.Forms.ListBox lbNoteQuery;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.RichTextBox rtbNewNote;
        private System.Windows.Forms.RichTextBox rtbViewNote;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}