namespace pkl_app_1_jude
{
    partial class FormUtama
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
            this.latihanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ganjilGenapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.numerikTambahKaliToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tanggalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.latihanToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // latihanToolStripMenuItem
            // 
            this.latihanToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ganjilGenapToolStripMenuItem,
            this.numerikTambahKaliToolStripMenuItem,
            this.tanggalToolStripMenuItem});
            this.latihanToolStripMenuItem.Name = "latihanToolStripMenuItem";
            this.latihanToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.latihanToolStripMenuItem.Text = "Latihan";
            // 
            // ganjilGenapToolStripMenuItem
            // 
            this.ganjilGenapToolStripMenuItem.Name = "ganjilGenapToolStripMenuItem";
            this.ganjilGenapToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.ganjilGenapToolStripMenuItem.Text = "String Nama";
            this.ganjilGenapToolStripMenuItem.Click += new System.EventHandler(this.ganjilGenapToolStripMenuItem_Click);
            // 
            // numerikTambahKaliToolStripMenuItem
            // 
            this.numerikTambahKaliToolStripMenuItem.Name = "numerikTambahKaliToolStripMenuItem";
            this.numerikTambahKaliToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.numerikTambahKaliToolStripMenuItem.Text = "Numerik Tambah Kali";
            this.numerikTambahKaliToolStripMenuItem.Click += new System.EventHandler(this.numerikTambahKaliToolStripMenuItem_Click);
            // 
            // tanggalToolStripMenuItem
            // 
            this.tanggalToolStripMenuItem.Name = "tanggalToolStripMenuItem";
            this.tanggalToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.tanggalToolStripMenuItem.Text = "Tanggal";
            this.tanggalToolStripMenuItem.Click += new System.EventHandler(this.tanggalToolStripMenuItem_Click);
            // 
            // FormUtama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormUtama";
            this.Text = "FormUtama";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem latihanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ganjilGenapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem numerikTambahKaliToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tanggalToolStripMenuItem;
    }
}