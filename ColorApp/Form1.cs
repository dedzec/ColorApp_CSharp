namespace ColorApp
{
    public partial class Form1 : Form
    {
        bool buttonPressed = false;
        private NotifyIcon trayIcon;

        public Form1()
        {
            InitializeComponent();
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
                MessageBox.Show("Erro ao inicializar o �cone da bandeja: " + ex.Message);
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
                    Color selectedColor = GetColorAt(cursorPosition);
                    panel1.BackColor = selectedColor;
                    string hexValeu = ColorTranslator.ToHtml(selectedColor);
                    textBox1.Text = hexValeu;
                    string rbgValeu = $"R:{selectedColor.R}, G:{selectedColor.G}, B:{selectedColor.B}";
                    textBox2.Text = rbgValeu;
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
            // Exibe o formul�rio principal quando o item "Abrir" � clicado
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void Sair_Click(object? sender, EventArgs e)
        {
            // Fecha o aplicativo quando o item "Sair" � clicado
            Application.Exit();
        }

        private void InitializeTrayIcon()
        {
            // Crie o menu de contexto
            ContextMenuStrip contextMenu = new ContextMenuStrip();

            // Adicione as op��es ao menu de contexto
            ToolStripMenuItem openMenuItem = new ToolStripMenuItem("Abrir");
            openMenuItem.Click += abrirToolStripMenuItem_Click;
            contextMenu.Items.Add(openMenuItem);

            ToolStripMenuItem closeMenuItem = new ToolStripMenuItem("Fechar");
            closeMenuItem.Click += fecharToolStripMenuItem_Click;
            contextMenu.Items.Add(closeMenuItem);

            // Atribua o menu de contexto ao �cone da bandeja
            trayIcon.ContextMenuStrip = contextMenu;

            // Adicione manipuladores de eventos para os cliques no �cone da bandeja
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
            // Aqui voc� pode exibir ou ocultar o formul�rio principal
            // por exemplo:
            this.Visible = !this.Visible;
        }

        /*private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Implemente a l�gica para abrir o aplicativo
            // Por exemplo, exiba o formul�rio principal
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
        }

        private void fecharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Implemente a l�gica para fechar o aplicativo
            // Por exemplo, voc� pode chamar o m�todo Close()
            this.Close();
        }*/

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Esconder o formul�rio em vez de fech�-lo
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Visible = false;
            }
            base.OnFormClosing(e);
        }

        // Certifique-se de limpar o �cone da bandeja quando o formul�rio for fechado
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