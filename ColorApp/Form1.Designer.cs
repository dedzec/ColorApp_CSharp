namespace ColorApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            panel1 = new Panel();
            textBox2 = new TextBox();
            label3 = new Label();
            textBox3 = new TextBox();
            label4 = new Label();
            textBox4 = new TextBox();
            label5 = new Label();
            textBox5 = new TextBox();
            label6 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(32, 15);
            label1.TabIndex = 0;
            label1.Text = "Pixel";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 181);
            label2.Name = "label2";
            label2.Size = new Size(124, 15);
            label2.TabIndex = 1;
            label2.Text = "Selecione a cor da tela";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(46, 12);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(103, 23);
            textBox1.TabIndex = 2;
            // 
            // button1
            // 
            button1.Location = new Point(12, 209);
            button1.Name = "button1";
            button1.Size = new Size(137, 53);
            button1.TabIndex = 3;
            button1.Text = "Mantenha o mouse pressionado";
            button1.UseVisualStyleBackColor = true;
            button1.MouseDown += button1_MouseDown;
            button1.MouseUp += button1_MouseUp;
            // 
            // panel1
            // 
            panel1.Location = new Point(171, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(139, 250);
            panel1.TabIndex = 4;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(46, 41);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(103, 23);
            textBox2.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 44);
            label3.Name = "label3";
            label3.Size = new Size(29, 15);
            label3.TabIndex = 6;
            label3.Text = "RGB";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(46, 70);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(103, 23);
            textBox3.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 73);
            label4.Name = "label4";
            label4.Size = new Size(29, 15);
            label4.TabIndex = 8;
            label4.Text = "HEX";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(46, 98);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(103, 23);
            textBox4.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 101);
            label5.Name = "label5";
            label5.Size = new Size(29, 15);
            label5.TabIndex = 10;
            label5.Text = "HSB";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(46, 127);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(103, 23);
            textBox5.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(4, 130);
            label6.Name = "label6";
            label6.Size = new Size(40, 15);
            label6.TabIndex = 12;
            label6.Text = "CMYK";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(322, 277);
            Controls.Add(label6);
            Controls.Add(textBox5);
            Controls.Add(label5);
            Controls.Add(textBox4);
            Controls.Add(label4);
            Controls.Add(textBox3);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(panel1);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Color Picker";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private Button button1;
        private Panel panel1;
        private TextBox textBox2;
        private Label label3;
        private TextBox textBox3;
        private Label label4;
        private TextBox textBox4;
        private Label label5;
        private TextBox textBox5;
        private Label label6;
    }
}