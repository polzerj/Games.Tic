namespace TicTacToe
{
    partial class Spielauswahl
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
            this.btnT = new System.Windows.Forms.Button();
            this.btnM = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnT
            // 
            this.btnT.Location = new System.Drawing.Point(12, 25);
            this.btnT.Name = "btnT";
            this.btnT.Size = new System.Drawing.Size(128, 38);
            this.btnT.TabIndex = 0;
            this.btnT.Text = "TicTacToe";
            this.btnT.UseVisualStyleBackColor = true;
            this.btnT.Click += new System.EventHandler(this.btnT_Click);
            // 
            // btnM
            // 
            this.btnM.Location = new System.Drawing.Point(146, 25);
            this.btnM.Name = "btnM";
            this.btnM.Size = new System.Drawing.Size(128, 38);
            this.btnM.TabIndex = 1;
            this.btnM.Text = "Mühle (in Entwicklung)";
            this.btnM.UseVisualStyleBackColor = true;
            this.btnM.Click += new System.EventHandler(this.btnM_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Wähle das Programm welches du starten willst.";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Spielauswahl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 81);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnM);
            this.Controls.Add(this.btnT);
            this.Name = "Spielauswahl";
            this.Text = "Spielauswahl";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnT;
        private System.Windows.Forms.Button btnM;
        private System.Windows.Forms.Label label1;
    }
}