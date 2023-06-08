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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "Rita",
            "Large",
            "10",
            "Topping 1, Topping 2"}, -1);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "Pump",
            "1 L",
            "8",
            "Null"}, -1);
            this.panelTop = new System.Windows.Forms.Panel();
            this.pictureBoxPizzaShop = new System.Windows.Forms.PictureBox();
            this.pictureBoxProfileIcon = new System.Windows.Forms.PictureBox();
            this.panelCenter = new System.Windows.Forms.Panel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
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
            this.pictureBoxPizzaShop.Click += new System.EventHandler(this.pictureBoxPizzaShop_Click);
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
            this.panelCenter.Controls.Add(this.button2);
            this.panelCenter.Controls.Add(this.button1);
            this.panelCenter.Controls.Add(this.label1);
            this.panelCenter.Controls.Add(this.textBox1);
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
            listViewItem1.StateImageIndex = 0;
            listViewItem2.StateImageIndex = 0;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(930, 240);
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
            this.columnHeader4.Width = 150;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(17, 282);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(385, 92);
            this.textBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 259);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Notes";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Brown;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Location = new System.Drawing.Point(727, 511);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(179, 35);
            this.button1.TabIndex = 8;
            this.button1.Text = "Place Order";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Brown;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.Location = new System.Drawing.Point(17, 511);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(179, 35);
            this.button2.TabIndex = 9;
            this.button2.Text = "Back";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
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
            this.panelCenter.PerformLayout();
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}