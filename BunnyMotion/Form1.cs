namespace BunnyMotion
{
    public partial class Bunny : Form
    {
        private System.Drawing.Image BunnyPoses(string TypePose)
        {
            return Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets", $"{TypePose}.png")) ?? Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets", $"{TypePose}.jpg"));
        }
        private async Task ChargeMessage(string message, int delay = 80)
        {
            await Task.Delay(1000);
            lblBallon.Text = "";
            foreach (char c in message)
            {
                lblBallon.Text += c;
                await Task.Delay(delay);
            }
        }
        public Bunny()
        {
            InitializeComponent();
            this.BackgroundImage = BunnyPoses("idle");
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await ChargeMessage("Olá! Eu sou Bunny, seu amigo eletrônico. Vamos buscar aventuras!!");
            await ChargeMessage("Conheço brincadeiras incriveis para brincar com você!!");
            await ChargeMessage("Bunny o coelho... Bunny o Bunny, this Bunn... Bunny for Bunny");
            //this.BackgroundImage = BunnyPoses("happy");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
