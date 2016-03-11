namespace View.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.BetLabel = new System.Windows.Forms.Label();
            this.EnoughButton = new System.Windows.Forms.Button();
            this.TakeButton = new System.Windows.Forms.Button();
            this.MoneyLabel = new System.Windows.Forms.Label();
            this.PointLabel = new System.Windows.Forms.Label();
            this.Shirt = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.играToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.новаяИграToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.правилаИгрыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.Shirt)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BetLabel
            // 
            this.BetLabel.BackColor = System.Drawing.Color.Transparent;
            this.BetLabel.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BetLabel.Location = new System.Drawing.Point(806, 714);
            this.BetLabel.Name = "BetLabel";
            this.BetLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.BetLabel.Size = new System.Drawing.Size(171, 31);
            this.BetLabel.TabIndex = 12;
            this.BetLabel.Text = "Ставка : 0";
            // 
            // EnoughButton
            // 
            this.EnoughButton.BackColor = System.Drawing.Color.ForestGreen;
            this.EnoughButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EnoughButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EnoughButton.Location = new System.Drawing.Point(510, 623);
            this.EnoughButton.Name = "EnoughButton";
            this.EnoughButton.Size = new System.Drawing.Size(102, 37);
            this.EnoughButton.TabIndex = 11;
            this.EnoughButton.Text = "Хватит";
            this.EnoughButton.UseVisualStyleBackColor = false;
            this.EnoughButton.Click += new System.EventHandler(this.EnoughButton_Click);
            // 
            // TakeButton
            // 
            this.TakeButton.BackColor = System.Drawing.Color.ForestGreen;
            this.TakeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TakeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TakeButton.Location = new System.Drawing.Point(402, 623);
            this.TakeButton.Name = "TakeButton";
            this.TakeButton.Size = new System.Drawing.Size(102, 37);
            this.TakeButton.TabIndex = 10;
            this.TakeButton.Text = "Взять еще";
            this.TakeButton.UseVisualStyleBackColor = false;
            this.TakeButton.Click += new System.EventHandler(this.TakeButton_Click);
            // 
            // MoneyLabel
            // 
            this.MoneyLabel.AutoSize = true;
            this.MoneyLabel.BackColor = System.Drawing.Color.Transparent;
            this.MoneyLabel.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MoneyLabel.Location = new System.Drawing.Point(806, 745);
            this.MoneyLabel.Name = "MoneyLabel";
            this.MoneyLabel.Size = new System.Drawing.Size(171, 31);
            this.MoneyLabel.TabIndex = 9;
            this.MoneyLabel.Text = "Деньги : 1000";
            // 
            // PointLabel
            // 
            this.PointLabel.BackColor = System.Drawing.Color.Transparent;
            this.PointLabel.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PointLabel.Location = new System.Drawing.Point(806, 683);
            this.PointLabel.Name = "PointLabel";
            this.PointLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.PointLabel.Size = new System.Drawing.Size(171, 31);
            this.PointLabel.TabIndex = 8;
            this.PointLabel.Text = "Очки : 0";
            // 
            // Shirt
            // 
            this.Shirt.Image = ((System.Drawing.Image)(resources.GetObject("Shirt.Image")));
            this.Shirt.Location = new System.Drawing.Point(12, 36);
            this.Shirt.Name = "Shirt";
            this.Shirt.Size = new System.Drawing.Size(108, 152);
            this.Shirt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Shirt.TabIndex = 7;
            this.Shirt.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.играToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(986, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // играToolStripMenuItem
            // 
            this.играToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.новаяИграToolStripMenuItem});
            this.играToolStripMenuItem.Name = "играToolStripMenuItem";
            this.играToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.играToolStripMenuItem.Text = "Игра";
            // 
            // новаяИграToolStripMenuItem
            // 
            this.новаяИграToolStripMenuItem.Name = "новаяИграToolStripMenuItem";
            this.новаяИграToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.новаяИграToolStripMenuItem.Text = "Новая игра";
            this.новаяИграToolStripMenuItem.Click += new System.EventHandler(this.новаяИграToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.правилаИгрыToolStripMenuItem});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // правилаИгрыToolStripMenuItem
            // 
            this.правилаИгрыToolStripMenuItem.Name = "правилаИгрыToolStripMenuItem";
            this.правилаИгрыToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.правилаИгрыToolStripMenuItem.Text = "Правила игры";
            this.правилаИгрыToolStripMenuItem.Click += new System.EventHandler(this.правилаИгрыToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(986, 785);
            this.Controls.Add(this.BetLabel);
            this.Controls.Add(this.EnoughButton);
            this.Controls.Add(this.TakeButton);
            this.Controls.Add(this.MoneyLabel);
            this.Controls.Add(this.PointLabel);
            this.Controls.Add(this.Shirt);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.Shirt)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label BetLabel;
        private System.Windows.Forms.Button EnoughButton;
        private System.Windows.Forms.Button TakeButton;
        private System.Windows.Forms.Label MoneyLabel;
        private System.Windows.Forms.Label PointLabel;
        private System.Windows.Forms.PictureBox Shirt;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem играToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem новаяИграToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem правилаИгрыToolStripMenuItem;
    }
}

