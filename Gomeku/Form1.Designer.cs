namespace Gomeku
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
            this.pictureBox_Board = new System.Windows.Forms.PictureBox();
            this.button_Undo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Board)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_Board
            // 
            this.pictureBox_Board.Image = global::Gomeku.Properties.Resources.board;
            this.pictureBox_Board.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_Board.Name = "pictureBox_Board";
            this.pictureBox_Board.Size = new System.Drawing.Size(750, 750);
            this.pictureBox_Board.TabIndex = 0;
            this.pictureBox_Board.TabStop = false;
            this.pictureBox_Board.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown);
            this.pictureBox_Board.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // button_Undo
            // 
            this.button_Undo.Location = new System.Drawing.Point(0, 749);
            this.button_Undo.Name = "button_Undo";
            this.button_Undo.Size = new System.Drawing.Size(374, 41);
            this.button_Undo.TabIndex = 1;
            this.button_Undo.Text = "悔棋";
            this.button_Undo.UseVisualStyleBackColor = true;
            this.button_Undo.Click += new System.EventHandler(this.button_Undo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 790);
            this.Controls.Add(this.button_Undo);
            this.Controls.Add(this.pictureBox_Board);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Gomoku";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Board)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_Board;
        private System.Windows.Forms.Button button_Undo;
    }
}

