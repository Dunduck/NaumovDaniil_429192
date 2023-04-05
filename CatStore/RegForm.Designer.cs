namespace CatStore
{
    partial class RegForm
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
            this.logTB = new System.Windows.Forms.TextBox();
            this.passTB = new System.Windows.Forms.TextBox();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.regBtn = new MaterialSkin.Controls.MaterialButton();
            this.backBtn = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // logTB
            // 
            this.logTB.Location = new System.Drawing.Point(289, 181);
            this.logTB.MaxLength = 30;
            this.logTB.Name = "logTB";
            this.logTB.Size = new System.Drawing.Size(212, 20);
            this.logTB.TabIndex = 16;
            // 
            // passTB
            // 
            this.passTB.Location = new System.Drawing.Point(289, 239);
            this.passTB.MaxLength = 30;
            this.passTB.Name = "passTB";
            this.passTB.Size = new System.Drawing.Size(212, 20);
            this.passTB.TabIndex = 15;
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.Location = new System.Drawing.Point(345, 129);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(96, 19);
            this.materialLabel3.TabIndex = 14;
            this.materialLabel3.Text = "Регистрация";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(189, 239);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(57, 19);
            this.materialLabel2.TabIndex = 13;
            this.materialLabel2.Text = "Пароль";
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(195, 181);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(46, 19);
            this.materialLabel1.TabIndex = 12;
            this.materialLabel1.Text = "Логин";
            // 
            // regBtn
            // 
            this.regBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.regBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.regBtn.Depth = 0;
            this.regBtn.HighEmphasis = true;
            this.regBtn.Icon = null;
            this.regBtn.Location = new System.Drawing.Point(298, 287);
            this.regBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.regBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.regBtn.Name = "regBtn";
            this.regBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.regBtn.Size = new System.Drawing.Size(191, 36);
            this.regBtn.TabIndex = 10;
            this.regBtn.Text = "Зарегистрироваться";
            this.regBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.regBtn.UseAccentColor = false;
            this.regBtn.UseVisualStyleBackColor = true;
            this.regBtn.Click += new System.EventHandler(this.regBtn_Click);
            // 
            // backBtn
            // 
            this.backBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.backBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.backBtn.Depth = 0;
            this.backBtn.HighEmphasis = true;
            this.backBtn.Icon = null;
            this.backBtn.Location = new System.Drawing.Point(711, 82);
            this.backBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.backBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.backBtn.Name = "backBtn";
            this.backBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.backBtn.Size = new System.Drawing.Size(71, 36);
            this.backBtn.TabIndex = 17;
            this.backBtn.Text = "Назад";
            this.backBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.backBtn.UseAccentColor = false;
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // RegForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.logTB);
            this.Controls.Add(this.passTB);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.regBtn);
            this.Name = "RegForm";
            this.Text = "Магазин котиков";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox logTB;
        private System.Windows.Forms.TextBox passTB;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialButton regBtn;
        private MaterialSkin.Controls.MaterialButton backBtn;
    }
}