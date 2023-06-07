namespace Pizza_Shop
{
    partial class CartPage
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.pictureBoxPizzaShop = new System.Windows.Forms.PictureBox();
            this.pictureBoxProfileIcon = new System.Windows.Forms.PictureBox();
            this.panelCenter = new System.Windows.Forms.Panel();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPizzaShop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfileIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.Firebrick;
            this.panelTop.Controls.Add(this.pictureBoxPizzaShop);
            this.panelTop.Controls.Add(this.pictureBoxProfileIcon);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1102, 66);
            this.panelTop.TabIndex = 0;
            // 
            // pictureBoxPizzaShop
            // 
            this.pictureBoxPizzaShop.Image = global::Pizza_Shop.Properties.Resources.symbol;
            this.pictureBoxPizzaShop.Location = new System.Drawing.Point(21, 0);
            this.pictureBoxPizzaShop.Name = "pictureBoxPizzaShop";
            this.pictureBoxPizzaShop.Size = new System.Drawing.Size(109, 61);
            this.pictureBoxPizzaShop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPizzaShop.TabIndex = 1;
            this.pictureBoxPizzaShop.TabStop = false;
            // 
            // pictureBoxProfileIcon
            // 
            this.pictureBoxProfileIcon.Image = global::Pizza_Shop.Properties.Resources.Profile_Symbol;
            this.pictureBoxProfileIcon.Location = new System.Drawing.Point(966, 0);
            this.pictureBoxProfileIcon.Name = "pictureBoxProfileIcon";
            this.pictureBoxProfileIcon.Size = new System.Drawing.Size(72, 66);
            this.pictureBoxProfileIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxProfileIcon.TabIndex = 0;
            this.pictureBoxProfileIcon.TabStop = false;
            // 
            // panelCenter
            // 
            this.panelCenter.Location = new System.Drawing.Point(62, 224);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(930, 567);
            this.panelCenter.TabIndex = 1;
            // 
            // CartPage
            // 
            this.BackgroundImage = global::Pizza_Shop.Properties.Resources.pizzabg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1102, 816);
            this.Controls.Add(this.panelCenter);
            this.Controls.Add(this.panelTop);
            this.DoubleBuffered = true;
            this.Name = "CartPage";
            this.Text = "Pizza Shop";
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPizzaShop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfileIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.PictureBox pictureBoxPizzaShop;
        private System.Windows.Forms.PictureBox pictureBoxProfileIcon;
        private System.Windows.Forms.Panel panelCenter;
    }
}