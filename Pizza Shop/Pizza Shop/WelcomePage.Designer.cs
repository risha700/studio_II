namespace Pizza_Shop
{
    partial class WelcomePage
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
            this.buttonTrackOrder = new System.Windows.Forms.Button();
            this.buttonMakeOrder = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPizzaShop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfileIcon)).BeginInit();
            this.panelCenter.SuspendLayout();
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
            this.panelCenter.Controls.Add(this.buttonTrackOrder);
            this.panelCenter.Controls.Add(this.buttonMakeOrder);
            this.panelCenter.Location = new System.Drawing.Point(72, 143);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(930, 531);
            this.panelCenter.TabIndex = 1;
            // 
            // buttonTrackOrder
            // 
            this.buttonTrackOrder.BackColor = System.Drawing.Color.Gainsboro;
            this.buttonTrackOrder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonTrackOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonTrackOrder.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonTrackOrder.Location = new System.Drawing.Point(323, 213);
            this.buttonTrackOrder.Name = "buttonTrackOrder";
            this.buttonTrackOrder.Size = new System.Drawing.Size(271, 76);
            this.buttonTrackOrder.TabIndex = 1;
            this.buttonTrackOrder.Text = "Track Order";
            this.buttonTrackOrder.UseVisualStyleBackColor = false;
            this.buttonTrackOrder.Click += new System.EventHandler(this.buttonTrackOrder_Click);
            // 
            // buttonMakeOrder
            // 
            this.buttonMakeOrder.BackColor = System.Drawing.Color.Firebrick;
            this.buttonMakeOrder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonMakeOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonMakeOrder.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonMakeOrder.Location = new System.Drawing.Point(323, 106);
            this.buttonMakeOrder.Name = "buttonMakeOrder";
            this.buttonMakeOrder.Size = new System.Drawing.Size(271, 77);
            this.buttonMakeOrder.TabIndex = 0;
            this.buttonMakeOrder.Text = "Make Order";
            this.buttonMakeOrder.UseVisualStyleBackColor = false;
            this.buttonMakeOrder.Click += new System.EventHandler(this.buttonMakeOrder_Click);
            // 
            // WelcomePage
            // 
            this.BackgroundImage = global::Pizza_Shop.Properties.Resources.pizzabg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1102, 816);
            this.Controls.Add(this.panelCenter);
            this.Controls.Add(this.panelTop);
            this.DoubleBuffered = true;
            this.Name = "WelcomePage";
            this.Text = "Pizza Shop";
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPizzaShop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfileIcon)).EndInit();
            this.panelCenter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.PictureBox pictureBoxPizzaShop;
        private System.Windows.Forms.PictureBox pictureBoxProfileIcon;
        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.Button buttonMakeOrder;
        private System.Windows.Forms.Button buttonTrackOrder;
    }
}