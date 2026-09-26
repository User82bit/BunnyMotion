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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Bunny));
            pictureBoxForm = new PictureBox();
            lblBallon = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBoxForm).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxForm
            // 
            resources.ApplyResources(pictureBoxForm, "pictureBoxForm");
            pictureBoxForm.BackColor = SystemColors.Window;
            pictureBoxForm.Name = "pictureBoxForm";
            pictureBoxForm.TabStop = false;
            pictureBoxForm.Click += pictureBox2_Click;
            // 
            // lblBallon
            // 
            resources.ApplyResources(lblBallon, "lblBallon");
            lblBallon.Name = "lblBallon";
            lblBallon.Click += label1_Click_1;
            // 
            // Bunny
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            ControlBox = false;
            Controls.Add(lblBallon);
            Controls.Add(pictureBoxForm);
            DoubleBuffered = true;
            MaximizeBox = false;
            Name = "Bunny";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxForm).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBoxForm;
        private Label lblBallon;
    }
}
