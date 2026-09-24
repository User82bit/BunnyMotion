namespace BunnyMotion
{
    partial class Bunny
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Bunny));
            pictureBox1 = new PictureBox();
            lblBallon = new Label();
            notifyIcon1 = new NotifyIcon(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(-4, 160);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(445, 354);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // lblBallon
            // 
            lblBallon.AutoSize = true;
            lblBallon.BackColor = Color.White;
            lblBallon.Location = new Point(22, 302);
            lblBallon.Name = "lblBallon";
            lblBallon.Size = new Size(299, 25);
            lblBallon.TabIndex = 1;
            lblBallon.Text = "Bem vindo ao sistema BunnyMotion";
            lblBallon.Click += label1_Click;
            // 
            // notifyIcon1
            // 
            notifyIcon1.Text = "notifyIcon1";
            notifyIcon1.Visible = true;
            // 
            // Bunny
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(438, 404);
            Controls.Add(lblBallon);
            Controls.Add(pictureBox1);
            Name = "Bunny";
            Text = "Bunny";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label lblBallon;
        private NotifyIcon notifyIcon1;
    }
}
