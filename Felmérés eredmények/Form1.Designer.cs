namespace Felmérés_eredmények
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listBoxSubjects = new System.Windows.Forms.ListBox();
            this.buttonOrderByDate = new System.Windows.Forms.Button();
            this.ToolStripMenuItemEditSubject = new System.Windows.Forms.ToolStripMenuItem();
            this.újAlanyFelvételeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.újEredményRögzítéseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eredményekKezeléseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.újEredményRögzítéseToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.textBoxNotes = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelNumberOfSubjects = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.alanyokToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.újAlanyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteSubjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eredményToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewSubjectStateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eredményTörléseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.biztonságiMentésToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonOrder = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxSubjects
            // 
            this.listBoxSubjects.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxSubjects.FormattingEnabled = true;
            this.listBoxSubjects.ItemHeight = 25;
            this.listBoxSubjects.Location = new System.Drawing.Point(8, 62);
            this.listBoxSubjects.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listBoxSubjects.Name = "listBoxSubjects";
            this.listBoxSubjects.Size = new System.Drawing.Size(451, 329);
            this.listBoxSubjects.TabIndex = 0;
            this.listBoxSubjects.SelectedValueChanged += new System.EventHandler(this.ListBoxSubjects_SelectedValueChanged);
            this.listBoxSubjects.DoubleClick += new System.EventHandler(this.ListBoxSubjects_DoubleClick);
            // 
            // buttonOrderByDate
            // 
            this.buttonOrderByDate.Location = new System.Drawing.Point(488, 117);
            this.buttonOrderByDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonOrderByDate.Name = "buttonOrderByDate";
            this.buttonOrderByDate.Size = new System.Drawing.Size(165, 98);
            this.buttonOrderByDate.TabIndex = 2;
            this.buttonOrderByDate.Text = "rendezés utolsó alkalom dátuma szerint";
            this.buttonOrderByDate.UseVisualStyleBackColor = true;
            this.buttonOrderByDate.Click += new System.EventHandler(this.ButtonOrderByDate_Click);
            // 
            // ToolStripMenuItemEditSubject
            // 
            this.ToolStripMenuItemEditSubject.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ToolStripMenuItemEditSubject.Name = "ToolStripMenuItemEditSubject";
            this.ToolStripMenuItemEditSubject.Size = new System.Drawing.Size(84, 27);
            this.ToolStripMenuItemEditSubject.Text = "Alanyok";
            // 
            // újAlanyFelvételeToolStripMenuItem
            // 
            this.újAlanyFelvételeToolStripMenuItem.Name = "újAlanyFelvételeToolStripMenuItem";
            this.újAlanyFelvételeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.újAlanyFelvételeToolStripMenuItem.Size = new System.Drawing.Size(236, 28);
            this.újAlanyFelvételeToolStripMenuItem.Text = "Új";
            this.újAlanyFelvételeToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_ClickNewSubject);
            // 
            // újEredményRögzítéseToolStripMenuItem
            // 
            this.újEredményRögzítéseToolStripMenuItem.Name = "újEredményRögzítéseToolStripMenuItem";
            this.újEredményRögzítéseToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.újEredményRögzítéseToolStripMenuItem.Size = new System.Drawing.Size(236, 28);
            this.újEredményRögzítéseToolStripMenuItem.Text = "Kijelölt törlése";
            this.újEredményRögzítéseToolStripMenuItem.Click += new System.EventHandler(this.DeleteSubjectToolStripMenuItem_Click);
            // 
            // eredményekKezeléseToolStripMenuItem
            // 
            this.eredményekKezeléseToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.eredményekKezeléseToolStripMenuItem.Name = "eredményekKezeléseToolStripMenuItem";
            this.eredményekKezeléseToolStripMenuItem.Size = new System.Drawing.Size(117, 27);
            this.eredményekKezeléseToolStripMenuItem.Text = "Eredmények";
            // 
            // újEredményRögzítéseToolStripMenuItem1
            // 
            this.újEredményRögzítéseToolStripMenuItem1.Name = "újEredményRögzítéseToolStripMenuItem1";
            this.újEredményRögzítéseToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.újEredményRögzítéseToolStripMenuItem1.Size = new System.Drawing.Size(341, 28);
            this.újEredményRögzítéseToolStripMenuItem1.Text = "Új rögzítése, megjegyzés";
            this.újEredményRögzítéseToolStripMenuItem1.Click += new System.EventHandler(this.NewSubjectStateToolStripMenuItem_Click);
            // 
            // textBoxNotes
            // 
            this.textBoxNotes.Enabled = false;
            this.textBoxNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNotes.Location = new System.Drawing.Point(683, 62);
            this.textBoxNotes.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.textBoxNotes.MinimumSize = new System.Drawing.Size(400, 4);
            this.textBoxNotes.Multiline = true;
            this.textBoxNotes.Name = "textBoxNotes";
            this.textBoxNotes.Size = new System.Drawing.Size(467, 336);
            this.textBoxNotes.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(679, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "megjegyzések";
            // 
            // labelNumberOfSubjects
            // 
            this.labelNumberOfSubjects.AutoSize = true;
            this.labelNumberOfSubjects.Location = new System.Drawing.Point(7, 38);
            this.labelNumberOfSubjects.Name = "labelNumberOfSubjects";
            this.labelNumberOfSubjects.Size = new System.Drawing.Size(65, 20);
            this.labelNumberOfSubjects.TabIndex = 13;
            this.labelNumberOfSubjects.Text = "alanyok";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alanyokToolStripMenuItem,
            this.eredményToolStripMenuItem,
            this.biztonságiMentésToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1231, 31);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // alanyokToolStripMenuItem
            // 
            this.alanyokToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.újAlanyToolStripMenuItem,
            this.DeleteSubjectToolStripMenuItem});
            this.alanyokToolStripMenuItem.Name = "alanyokToolStripMenuItem";
            this.alanyokToolStripMenuItem.Size = new System.Drawing.Size(84, 27);
            this.alanyokToolStripMenuItem.Text = "Alanyok";
            // 
            // újAlanyToolStripMenuItem
            // 
            this.újAlanyToolStripMenuItem.Name = "újAlanyToolStripMenuItem";
            this.újAlanyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.N)));
            this.újAlanyToolStripMenuItem.Size = new System.Drawing.Size(263, 28);
            this.újAlanyToolStripMenuItem.Text = "Új alany";
            this.újAlanyToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_ClickNewSubject);
            // 
            // DeleteSubjectToolStripMenuItem
            // 
            this.DeleteSubjectToolStripMenuItem.Name = "DeleteSubjectToolStripMenuItem";
            this.DeleteSubjectToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.DeleteSubjectToolStripMenuItem.Size = new System.Drawing.Size(263, 28);
            this.DeleteSubjectToolStripMenuItem.Text = "Kijelölt törlése";
            this.DeleteSubjectToolStripMenuItem.Click += new System.EventHandler(this.DeleteSubjectToolStripMenuItem_Click);
            // 
            // eredményToolStripMenuItem
            // 
            this.eredményToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewSubjectStateToolStripMenuItem,
            this.eredményTörléseToolStripMenuItem});
            this.eredményToolStripMenuItem.Name = "eredményToolStripMenuItem";
            this.eredményToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.M)));
            this.eredményToolStripMenuItem.Size = new System.Drawing.Size(195, 27);
            this.eredményToolStripMenuItem.Text = "Eredmények és adatok";
            // 
            // NewSubjectStateToolStripMenuItem
            // 
            this.NewSubjectStateToolStripMenuItem.Name = "NewSubjectStateToolStripMenuItem";
            this.NewSubjectStateToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.R)));
            this.NewSubjectStateToolStripMenuItem.Size = new System.Drawing.Size(443, 28);
            this.NewSubjectStateToolStripMenuItem.Text = "Új eredmény, megjegyzés";
            this.NewSubjectStateToolStripMenuItem.Click += new System.EventHandler(this.NewSubjectStateToolStripMenuItem_Click);
            // 
            // eredményTörléseToolStripMenuItem
            // 
            this.eredményTörléseToolStripMenuItem.Name = "eredményTörléseToolStripMenuItem";
            this.eredményTörléseToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.M)));
            this.eredményTörléseToolStripMenuItem.Size = new System.Drawing.Size(443, 28);
            this.eredményTörléseToolStripMenuItem.Text = "Eredmények és adatok kezelése";
            this.eredményTörléseToolStripMenuItem.Click += new System.EventHandler(this.ManageRecordsToolStripMenuItem_Click);
            // 
            // biztonságiMentésToolStripMenuItem
            // 
            this.biztonságiMentésToolStripMenuItem.Name = "biztonságiMentésToolStripMenuItem";
            this.biztonságiMentésToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.B)));
            this.biztonságiMentésToolStripMenuItem.Size = new System.Drawing.Size(163, 27);
            this.biztonságiMentésToolStripMenuItem.Text = "Biztonsági mentés";
            this.biztonságiMentésToolStripMenuItem.Click += new System.EventHandler(this.ButtonDbBackup_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeight = 29;
            this.dataGridView1.Location = new System.Drawing.Point(8, 416);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.dataGridView1.MaximumSize = new System.Drawing.Size(1300, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.Size = new System.Drawing.Size(1142, 0);
            this.dataGridView1.TabIndex = 14;
            // 
            // buttonOrder
            // 
            this.buttonOrder.Location = new System.Drawing.Point(488, 242);
            this.buttonOrder.Name = "buttonOrder";
            this.buttonOrder.Size = new System.Drawing.Size(165, 84);
            this.buttonOrder.TabIndex = 16;
            this.buttonOrder.Text = "rendezés ABC szerint";
            this.buttonOrder.UseVisualStyleBackColor = true;
            this.buttonOrder.Click += new System.EventHandler(this.ButtonOrder_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1231, 522);
            this.Controls.Add(this.buttonOrder);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.labelNumberOfSubjects);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxNotes);
            this.Controls.Add(this.listBoxSubjects);
            this.Controls.Add(this.buttonOrderByDate);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(948, 540);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Állapotfelmérés nyilvántartás";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox listBoxSubjects;
        private System.Windows.Forms.Button buttonOrderByDate;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemEditSubject;
        private System.Windows.Forms.ToolStripMenuItem újAlanyFelvételeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem újEredményRögzítéseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eredményekKezeléseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem újEredményRögzítéseToolStripMenuItem1;
        private System.Windows.Forms.TextBox textBoxNotes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelNumberOfSubjects;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem alanyokToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem újAlanyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteSubjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eredményToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewSubjectStateToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem eredményTörléseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem biztonságiMentésToolStripMenuItem;
        private System.Windows.Forms.Button buttonOrder;
    }
}

