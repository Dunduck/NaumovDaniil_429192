namespace CatStore
{
    partial class AddModelCatForm
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.colourTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ageTB = new System.Windows.Forms.TextBox();
            this.breedTB = new System.Windows.Forms.TextBox();
            this.genderTB = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.Image = global::CatStore.Properties.Resources.cat;
            this.pictureBox1.Location = new System.Drawing.Point(16, 67);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 94);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // colourTB
            // 
            this.colourTB.Location = new System.Drawing.Point(359, 230);
            this.colourTB.MaxLength = 50;
            this.colourTB.Name = "colourTB";
            this.colourTB.Size = new System.Drawing.Size(194, 20);
            this.colourTB.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(248, 172);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Порода кошки";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(248, 202);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Пол кошки";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(248, 233);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Цвет кошки";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(248, 265);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Возраст кошки";
            // 
            // ageTB
            // 
            this.ageTB.Location = new System.Drawing.Point(359, 262);
            this.ageTB.MaxLength = 2;
            this.ageTB.Name = "ageTB";
            this.ageTB.Size = new System.Drawing.Size(194, 20);
            this.ageTB.TabIndex = 16;
            // 
            // breedTB
            // 
            this.breedTB.Location = new System.Drawing.Point(359, 169);
            this.breedTB.MaxLength = 50;
            this.breedTB.Name = "breedTB";
            this.breedTB.Size = new System.Drawing.Size(194, 20);
            this.breedTB.TabIndex = 13;
            // 
            // genderTB
            // 
            this.genderTB.Location = new System.Drawing.Point(359, 199);
            this.genderTB.MaxLength = 1;
            this.genderTB.Name = "genderTB";
            this.genderTB.Size = new System.Drawing.Size(194, 20);
            this.genderTB.TabIndex = 14;
            // 
            // AddModelCatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.colourTB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ageTB);
            this.Controls.Add(this.breedTB);
            this.Controls.Add(this.genderTB);
            this.Controls.Add(this.pictureBox1);
            this.Name = "AddModelCatForm";
            this.Text = "Добавление модели кошки";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox colourTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ageTB;
        private System.Windows.Forms.TextBox breedTB;
        private System.Windows.Forms.TextBox genderTB;
    }
}