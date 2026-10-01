using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;

namespace BunnyMotion
{
    public partial class MoveBunny : Form
    {
        private readonly List<Image> frames = new();
        private readonly System.Windows.Forms.Timer timer = new() { Interval = 16 };

        private int frameIndex;
        private int tick;
        private bool facingLeft;
        private Point target;
        private const int Speed = 3;

        public MoveBunny()
        {
            InitializeComponent();
        }

        private void LoadFrames()
        {
            string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets", "frames");
            if (!Directory.Exists(dir)) return;

            var files = Directory.GetFiles(dir)
                .Where(f => f.EndsWith(".png", StringComparison.OrdinalIgnoreCase)
                         || f.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase)
                         || f.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase))
                .OrderBy(f => NaturalKey(f));

            foreach (var file in files)
            {
                // copia para a memória e libera o arquivo no disco
                using var temp = Image.FromFile(file);
                frames.Add(new Bitmap(temp));
            }
        }

        // faz frame2 vir antes de frame10
        private static int NaturalKey(string path)
        {
            var m = Regex.Match(Path.GetFileNameWithoutExtension(path), @"\d+");
            return m.Success ? int.Parse(m.Value) : 0;
        }

        private void PickNewTarget()
        {
            var area = Screen.PrimaryScreen!.WorkingArea;
            target = new Point(
                Random.Shared.Next(area.Left, area.Right - Width),
                Random.Shared.Next(area.Top, area.Bottom - Height));
        }

        private void MoveBunny_Load(object? sender, EventArgs e)
        {
            LoadFrames();

            Location = new Point(100, 100);
            PickNewTarget();

            timer.Tick += OnTick;
            timer.Start();
        }

        private void OnTick(object? sender, EventArgs e)
        {
            int dx = target.X - Location.X;
            int dy = target.Y - Location.Y;
            double dist = Math.Sqrt(dx * dx + dy * dy);

            if (dist <= Speed)
            {
                PickNewTarget();
            }
            else
            {
                Location = new Point(
                    Location.X + (int)(dx / dist * Speed),
                    Location.Y + (int)(dy / dist * Speed));

                bool goingLeft = dx < 0;
                if (goingLeft != facingLeft)
                {
                    facingLeft = goingLeft;
                    Invalidate();
                }
            }

            // troca de frame a cada ~150 ms
            if (frames.Count > 0 && ++tick % 9 == 0)
            {
                frameIndex = (frameIndex + 1) % frames.Count;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (frames.Count == 0) return;

            var g = e.Graphics;
            g.InterpolationMode = InterpolationMode.NearestNeighbor; // use HighQualityBicubic se não for pixel art
            g.PixelOffsetMode = PixelOffsetMode.Half;

            if (facingLeft)
            {
                // espelha o sprite horizontalmente
                g.TranslateTransform(ClientSize.Width, 0);
                g.ScaleTransform(-1, 1);
            }

            g.DrawImage(frames[frameIndex], ClientRectangle);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                timer.Stop();
                timer.Dispose();
                foreach (var f in frames) f.Dispose();
                frames.Clear();
            }
            base.Dispose(disposing);
        }
    }
}