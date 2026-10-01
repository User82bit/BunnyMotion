using System.Drawing.Drawing2D;
using NAudio.Wave;

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
                using (Image SpechBallon = BunnyPoses("SpeechBallon"))
                {
                    if (SpechBallon != null)
                    {
                        float scaleX = 0.38f;
                        float scaleY = 0.3f;
                        int newW = (int)(SpechBallon.Width * scaleX);
                        int newH = (int)(SpechBallon.Height * scaleY);
                        int posX = -16;
                        int posY = 125;

                        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        g.DrawImage(SpechBallon, posX, posY, newW, newH);
                    }
                }
            }

            if (pictureBoxForm.Image != null)
            {
                pictureBoxForm.Image.Dispose();
            }

            pictureBoxForm.Image = canvas;
        }

        private async Task ChargeMessage(string message, int wait = 1000, int delay = 100)
        {
            await Task.Delay(wait);
            lblBallon.Text = "";
            string soundPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets", "Bunny_Click.mp3");
            using var soundReader = new AudioFileReader(soundPath);
            using var soundPlayer = new WaveOut();
            soundPlayer.Init(soundReader);

            foreach (char c in message)
            {
                lblBallon.Text += c;
                if (c != ' ')
                {
                    soundPlayer.Stop();
                    soundReader.Position = 0;
                    soundPlayer.Play();
                    await Task.Delay(delay);
                }
            }
        }

        private async Task<(string Input, bool ConditionMatched)> GetUserInput(Func<string, bool>? condition = null)
        {
            whiteBox.Clear();
            whiteBox.Visible = true;
            var inputSource = new TaskCompletionSource<(string Input, bool ConditionMatched)>();
            KeyEventHandler onKeyDown = (_, keyEvent) =>
            {
                if (keyEvent.KeyCode != Keys.Enter)
                    return;

                keyEvent.SuppressKeyPress = true;
                string userInput = whiteBox.Text.Trim();
                if (!string.IsNullOrWhiteSpace(userInput))
                    inputSource.TrySetResult((userInput, condition?.Invoke(userInput) ?? false));
            };

            whiteBox.KeyDown += onKeyDown;
            whiteBox.Focus();
            try
            {
                return await inputSource.Task;
            }
            finally
            {
                whiteBox.KeyDown -= onKeyDown;
                whiteBox.Visible = false;
            }
        }

        public void ChargeMoveBunny()
        {
            // Chamar o outro Form BunnyMotion.MoveBunny sem fechar o atual Bunny
            var moveBunnyForm = new MoveBunny();
            moveBunnyForm.Show();
        }

        public Bunny()
        {
            InitializeComponent();

            pictureBoxForm.Dock = DockStyle.Fill;
            this.lblBallon.Font = new Font("Arial", 10, FontStyle.Bold);
        }

        private async void Bunny_Load(object sender, EventArgs e)
        {
            AtualizarCenario("Background1Bunny", "idle");

            await ChargeMessage("Bem vindo a BunnyMotion, eu sou Bunny's Bunes.", wait: 10);

            //AtualizarCenario("Background1Bunny", "happy");

            await ChargeMessage("Estamos felizes em ter você conosco... ");
            await ChargeMessage("... ... ...", delay: 350);
            await ChargeMessage("Gostaria de dizer seu nome?");
            string[] negativeAnswers = ["não", "nao", "n", "no"];
            var (name, isNegation) = await GetUserInput(input =>
                negativeAnswers.Contains(input, StringComparer.OrdinalIgnoreCase));
            if (isNegation)
            {
                await ChargeMessage("Tudo bem! Se mudar de ideia, é só me contar.");
                return;
            }

            await ChargeMessage($"Prazer em te conhecer, {name}!");
            await ChargeMessage("");
            ChargeMoveBunny();
        }

        private void pictureBox2_Click(object sender, EventArgs e) 
        { 
        
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}