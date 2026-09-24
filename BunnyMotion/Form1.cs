namespace BunnyMotion
{
    public partial class Bunny : Form
    {
        private System.Drawing.Image BunnyPoses(string TypePose)
        {
            return Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets", $"{TypePose}.jpg"));
        }
        public Bunny()
        {
            InitializeComponent();
            this.BackgroundImage = BunnyPoses("idle");
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
