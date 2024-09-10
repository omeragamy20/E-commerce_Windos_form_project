namespace Ecommerce.PresentationV2
{
    partial class product_details
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
            pictureBox1 = new PictureBox();
            LB_Name = new Label();
            Price = new Label();
            label1 = new Label();
            label2 = new Label();
            Description = new RichTextBox();
            Home = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(12, 14);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(308, 297);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // LB_Name
            // 
            LB_Name.AutoSize = true;
            LB_Name.BackColor = SystemColors.HotTrack;
            LB_Name.Font = new Font("Viner Hand ITC", 24F, FontStyle.Bold | FontStyle.Italic);
            LB_Name.ForeColor = SystemColors.ButtonFace;
            LB_Name.Location = new Point(25, 354);
            LB_Name.Name = "LB_Name";
            LB_Name.Size = new Size(304, 65);
            LB_Name.TabIndex = 1;
            LB_Name.Text = "Product Name";
            LB_Name.Click += LB_Name_Click;
            // 
            // Price
            // 
            Price.AutoSize = true;
            Price.Font = new Font("Stencil", 19F, FontStyle.Italic);
            Price.Location = new Point(534, 354);
            Price.Name = "Price";
            Price.Size = new Size(27, 38);
            Price.TabIndex = 3;
            Price.Text = ".";
            Price.Click += Price_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.MidnightBlue;
            label1.Font = new Font("Stencil", 19F, FontStyle.Italic);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(519, 273);
            label1.Name = "label1";
            label1.Size = new Size(110, 38);
            label1.TabIndex = 4;
            label1.Text = "Price";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.MidnightBlue;
            label2.Font = new Font("Stencil", 19F, FontStyle.Italic);
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(448, 14);
            label2.Name = "label2";
            label2.Size = new Size(222, 38);
            label2.TabIndex = 5;
            label2.Text = "Description";
            // 
            // Description
            // 
            Description.Location = new Point(346, 83);
            Description.Name = "Description";
            Description.Size = new Size(419, 148);
            Description.TabIndex = 8;
            Description.Text = "";
            // 
            // Home
            // 
            Home.BackColor = Color.MidnightBlue;
            Home.Font = new Font("Stencil", 19F, FontStyle.Italic);
            Home.ForeColor = SystemColors.Control;
            Home.Location = new Point(671, 369);
            Home.Name = "Home";
            Home.Size = new Size(117, 69);
            Home.TabIndex = 9;
            Home.Text = "Home";
            Home.UseVisualStyleBackColor = false;
            Home.Click += Home_Click;
            // 
            // product_details
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Home);
            Controls.Add(Description);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Price);
            Controls.Add(LB_Name);
            Controls.Add(pictureBox1);
            Name = "product_details";
            Text = "product_details";
            Load += product_details_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label LB_Name;
        private Label Price;
        private Label label1;
        private Label label2;
        private RichTextBox Description;
        private Label home;
        private Button Home;
    }
}