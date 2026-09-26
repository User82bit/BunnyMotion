using System.Drawing.Drawing2D;

namespace BunnyMotion
{
    public partial class Bunny : Form
    {
        private Image BunnyPoses(string typePose)
        {
            string pathPng = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets", $"{typePose}.png");
            string pathJpg = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets", $"{typePose}.jpg");
            string pathJpeg = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets", $"{typePose}.jpeg");

            if (File.Exists(pathPng)) return Image.FromFile(pathPng);
            if (File.Exists(pathJpg)) return Image.FromFile(pathJpg);
            if (File.Exists(pathJpeg)) return Image.FromFile(pathJpeg);

            return null;
        }

        private void AtualizarCenario(string background, string poseAtual)
        {
            int largura = pictureBoxForm.Width > 0 ? pictureBoxForm.Width : 344;
            int altura = pictureBoxForm.Height > 0 ? pictureBoxForm.Height : 311;

            Bitmap canvas = new Bitmap(largura, altura);

            using (Graphics g = Graphics.FromImage(canvas))
            {
                using (Image fundo = BunnyPoses(background))
                {
                    if (fundo != null)
                        g.DrawImage(fundo, 0, 0, largura, altura);
                }

                using (Image personagem = BunnyPoses(poseAtual))
                {
                    if (personagem != null)
                    {
                        float scale = 0.75f;
                        int newW = (int)(personagem.Width * scale);
                        int newH = (int)(personagem.Height * scale);
                        int posX = -4;
                        int posY = 15;

                        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        g.DrawImage(personagem, posX, posY, newW, newH);
                    }
                }
            }

            if (pictureBoxForm.Image != null)
            {
                pictureBoxForm.Image.Dispose();
            }

            pictureBoxForm.Image = canvas;
        }

        private async Task ChargeMessage(string message, int wait = 1000, int delay = 80)
        {
            await Task.Delay(wait);
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

            pictureBoxForm.Dock = DockStyle.Fill;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            AtualizarCenario("Background1Bunny", "idle");

            await ChargeMessage("Olá! Eu sou Bunny, seu amigo eletrônico. Vamos buscar aventuras!!", wait : 100);

            //AtualizarCenario("Background1Bunny", "happy");

            await ChargeMessage("Conheço brincadeiras incriveis para brincar com você!!");
            await ChargeMessage("Bunny o coelho... Bunny o Bunny, this Bunn... Bunny for Bunny");
        }

        private void label1_Click(object sender, EventArgs e) { }

        private void pictureBox2_Click(object sender, EventArgs e) { }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}