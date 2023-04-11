namespace pkl_app_1_jude
{
    partial class FormArray2Dimensi
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
            this.PanelChessBoard = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PanelChessBoard
            // 
            this.PanelChessBoard.Location = new System.Drawing.Point(12, 62);
            this.PanelChessBoard.Name = "PanelChessBoard";
            this.PanelChessBoard.Size = new System.Drawing.Size(503, 376);
            this.PanelChessBoard.TabIndex = 0;
            this.PanelChessBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelChessBoard_Paint);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Gambar Papan Catur";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormArray2Dimensi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.PanelChessBoard);
            this.Name = "FormArray2Dimensi";
            this.Text = "FormArray2Dimensi";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelChessBoard;
        private System.Windows.Forms.Button button1;
    }
}