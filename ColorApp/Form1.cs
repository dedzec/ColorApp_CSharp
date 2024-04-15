namespace ColorApp
{
    public partial class Form1 : Form
    {
        bool buttonPressed = false;
        private NotifyIcon trayIcon;

        public Form1()
        {
            InitializeComponent();

            this.Width = 338;
            this.Height = 316;
            // Define o estilo do formulário para que não seja redimensionável
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Fixa a borda do formulário
            this.MaximizeBox = false; // Desativa o botão de maximizar

            try
            {
                trayIcon = new NotifyIcon()
                {
                    Icon = Properties.Resources.logo,
                    Text = "ColorApp",
                    Visible = true
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao inicializar o ícone da bandeja: " + ex.Message);
            }
            InitializeTrayIcon();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            Thread thread = new Thread(BackgroundThread) { IsBackground = true };
            thread.Start();
        }

        void BackgroundThread()
        {
            while (true)
            {
                if (buttonPressed)
                {
                    Point cursorPosition = Cursor.Position;

                    // Exibir os valores de X e Y no textBox1
                    textBox1.Text = $"{cursorPosition.X}, {cursorPosition.Y}";

                    Color selectedColor = GetColorAt(cursorPosition);
                    panel1.BackColor = selectedColor;

                    // Exibir os valores de HEX no textBox3
                    string hexValeu = ColorTranslator.ToHtml(selectedColor);
                    textBox3.Text = hexValeu;

                    // Exibir os valores de RGB no textBox2
                    string rbgValeu = $"{selectedColor.R}, {selectedColor.G}, {selectedColor.B}";
                    textBox2.Text = rbgValeu;

                    // Calcular os valores de HSB
                    float hue = selectedColor.GetHue();
                    float saturation = selectedColor.GetSaturation();
                    float brightness = selectedColor.GetBrightness();

                    // Formatar os valores de HSB com duas casas decimais
                    string formattedHue = hue.ToString("F2");
                    string formattedSaturation = saturation.ToString("F2");
                    string formattedBrightness = brightness.ToString("F2");

                    // Exibir os valores de HSB no textBox4
                    textBox4.Text = $"{formattedHue}, {formattedSaturation}, {formattedBrightness}";

                    // Converter a cor para CMYK
                    float cyan = 1 - (selectedColor.R / 255f);
                    float magenta = 1 - (selectedColor.G / 255f);
                    float yellow = 1 - (selectedColor.B / 255f);

                    float black = Math.Min(cyan, Math.Min(magenta, yellow));
                    cyan = (cyan - black) / (1 - black);
                    magenta = (magenta - black) / (1 - black);
                    yellow = (yellow - black) / (1 - black);

                    // Arredondar os valores de CMYK para o número inteiro mais próximo
                    int roundedCyan = (int)Math.Round(cyan * 100);
                    int roundedMagenta = (int)Math.Round(magenta * 100);
                    int roundedYellow = (int)Math.Round(yellow * 100);
                    int roundedBlack = (int)Math.Round(black * 100);

                    // Exibir os valores de CMYK no textBox5
                    textBox5.Text = $"{roundedCyan}, {roundedMagenta}, {roundedYellow}, {roundedBlack}";
                }
            }
        }

        Color GetColorAt(Point location)
        {
            using (Bitmap pixelContainer = new Bitmap(1, 1))
            {
                using (Graphics g = Graphics.FromImage(pixelContainer))
                {
                    g.CopyFromScreen(location, Point.Empty, pixelContainer.Size);
                }

                return pixelContainer.GetPixel(0, 0);
            }
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            buttonPressed = true;
            Cursor = Cursors.Cross;
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            buttonPressed = false;
            Cursor = Cursors.Default;
        }

        private void Abrir_Click(object? sender, EventArgs e)
        {
            // Exibe o formulário principal quando o item "Abrir" é clicado
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void Sair_Click(object? sender, EventArgs e)
        {
            // Fecha o aplicativo quando o item "Sair" é clicado
            Application.Exit();
        }

        private void InitializeTrayIcon()
        {
            // Crie o menu de contexto
            ContextMenuStrip contextMenu = new ContextMenuStrip();

            // Adicione as opções ao menu de contexto
            ToolStripMenuItem openMenuItem = new ToolStripMenuItem("Abrir");
            openMenuItem.Click += abrirToolStripMenuItem_Click;
            contextMenu.Items.Add(openMenuItem);

            ToolStripMenuItem closeMenuItem = new ToolStripMenuItem("Fechar");
            closeMenuItem.Click += fecharToolStripMenuItem_Click;
            contextMenu.Items.Add(closeMenuItem);

            // Atribua o menu de contexto ao ícone da bandeja
            trayIcon.ContextMenuStrip = contextMenu;

            // Adicione manipuladores de eventos para os cliques no ícone da bandeja
            trayIcon.Click += TrayIcon_Click;
            trayIcon.DoubleClick += TrayIcon_DoubleClick;
        }

        private void abrirToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void fecharToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TrayIcon_Click(object? sender, EventArgs e)
        {
            // Manipular eventos de clique do mouse na bandeja
        }

        private void TrayIcon_DoubleClick(object? sender, EventArgs e)
        {
            // Manipular eventos de clique duplo do mouse na bandeja
            // Aqui você pode exibir ou ocultar o formulário principal
            // por exemplo:
            this.Visible = !this.Visible;
        }

        /*private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Implemente a lógica para abrir o aplicativo
            // Por exemplo, exiba o formulário principal
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
        }

        private void fecharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Implemente a lógica para fechar o aplicativo
            // Por exemplo, você pode chamar o método Close()
            this.Close();
        }*/

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Esconder o formulário em vez de fechá-lo
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Visible = false;
            }
            base.OnFormClosing(e);
        }

        // Certifique-se de limpar o ícone da bandeja quando o formulário for fechado
        protected override void Dispose(bool disposing)
        {
            if (disposing && trayIcon != null)
            {
                trayIcon.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}