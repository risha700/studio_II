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
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
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
            this.pictureBoxProfileIcon.Location = new System.Drawing.Point(1030, 0);
            this.pictureBoxProfileIcon.Name = "pictureBoxProfileIcon";
            this.pictureBoxProfileIcon.Size = new System.Drawing.Size(72, 66);
            this.pictureBoxProfileIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxProfileIcon.TabIndex = 0;
            this.pictureBoxProfileIcon.TabStop = false;
            // 
            // panelCenter
            // 
            this.panelCenter.Controls.Add(this.button1);
            this.panelCenter.Controls.Add(this.listView1);
            this.panelCenter.Location = new System.Drawing.Point(79, 111);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(930, 567);
            this.panelCenter.TabIndex = 1;
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.SystemColors.Window;
            this.listView1.CheckBoxes = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(31, 26);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(403, 276);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Size";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Price";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Toppings";
            this.columnHeader4.Width = 73;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(767, 491);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 55);
            this.button1.TabIndex = 1;
            this.button1.Text = "Back to menu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            this.panelCenter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.PictureBox pictureBoxPizzaShop;
        private System.Windows.Forms.PictureBox pictureBoxProfileIcon;
        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button button1;
    }
}