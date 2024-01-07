namespace CustomWindowsForm
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class Form2 : Form
    {
        private bool mouseDown;
        private Point lastLocation;
        private IContainer components = null;
        private Panel panel1;
        private Label label3;
        private Label label2;
        private Label label1;
        private ButtonZ _CloseButton;
        private ButtonZ buttonZ1;
        private TextBox textBox2;
        private Label label4;
        private TextBox textBox1;

        public Form2()
        {
            this.InitializeComponent();
        }

        private void buttonZ1_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        protected override void Dispose(bool disposing)
        {
            if (!(!disposing || ReferenceEquals(this.components, null)))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(Form2));
            this.panel1 = new Panel();
            this.textBox2 = new TextBox();
            this.label4 = new Label();
            this.textBox1 = new TextBox();
            this.buttonZ1 = new ButtonZ();
            this.label3 = new Label();
            this.label2 = new Label();
            this.label1 = new Label();
            this._CloseButton = new ButtonZ();
            this.panel1.SuspendLayout();
            base.SuspendLayout();
            this.panel1.BackColor = Color.FromArgb(30, 30, 30);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.buttonZ1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this._CloseButton);
            this.panel1.Location = new Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(0x183, 0x185);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseDown += new MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new MouseEventHandler(this.panel1_MouseUp);
            this.textBox2.Location = new Point(0x66, 0x166);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Size(0xfb, 20);
            this.textBox2.TabIndex = 12;
            this.textBox2.Text = "44wJKzwrzWY7dxLov4EjVia3wmwaj6ige6a8C6eHKXKtVy8PTU3SnCG6A6do3vL4Cu3kLUedKwjomDKe754QhshVJw52xFV";
            this.label4.AutoSize = true;
            this.label4.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label4.ForeColor = Color.White;
            this.label4.Location = new Point(30, 0x167);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x47, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Monero: ";
            this.label4.TextAlign = ContentAlignment.TopCenter;
            this.textBox1.Location = new Point(0x66, 0x143);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(0xfb, 20);
            this.textBox1.TabIndex = 10;
            this.textBox1.Text = "bc1qlnzcep4l4ac0ttdrq7awxev9ehu465f2vpt9x0";
            this.buttonZ1.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.buttonZ1.BZBackColor = Color.FromArgb(30, 30, 30);
            this.buttonZ1.DisplayText = "X";
            this.buttonZ1.FlatStyle = FlatStyle.Flat;
            this.buttonZ1.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.buttonZ1.ForeColor = Color.White;
            this.buttonZ1.Location = new Point(0x15b, 8);
            this.buttonZ1.MouseClickColor1 = Color.FromArgb(60, 60, 160);
            this.buttonZ1.MouseHoverColor = Color.FromArgb(50, 50, 50);
            this.buttonZ1.Name = "buttonZ1";
            this.buttonZ1.Size = new Size(0x1f, 0x18);
            this.buttonZ1.TabIndex = 9;
            this.buttonZ1.Text = "X";
            this.buttonZ1.TextLocation_X = 6;
            this.buttonZ1.TextLocation_Y = 1;
            this.buttonZ1.UseVisualStyleBackColor = true;
            this.buttonZ1.Click += new EventHandler(this.buttonZ1_Click);
            this.label3.AutoSize = true;
            this.label3.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label3.ForeColor = Color.White;
            this.label3.Location = new Point(30, 0x144);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x41, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Bitcoin: ";
            this.label3.TextAlign = ContentAlignment.TopCenter;
            this.label2.AutoSize = true;
            this.label2.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label2.ForeColor = Color.White;
            this.label2.Location = new Point(11, 8);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0xef, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Chaos Ransomware Builder v5.2";
            this.label2.TextAlign = ContentAlignment.TopCenter;
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label1.ForeColor = Color.White;
            this.label1.Location = new Point(3, 0x2e);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x188, 240);
            this.label1.TabIndex = 6;
            this.label1.Text = manager.GetString("label1.Text");
            this.label1.TextAlign = ContentAlignment.TopCenter;
            this._CloseButton.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this._CloseButton.BZBackColor = Color.FromArgb(30, 30, 30);
            this._CloseButton.DisplayText = "X";
            this._CloseButton.FlatStyle = FlatStyle.Flat;
            this._CloseButton.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this._CloseButton.ForeColor = Color.White;
            this._CloseButton.Location = new Point(0x188, 0x18);
            this._CloseButton.MouseClickColor1 = Color.FromArgb(60, 60, 160);
            this._CloseButton.MouseHoverColor = Color.FromArgb(50, 50, 50);
            this._CloseButton.Name = "_CloseButton";
            this._CloseButton.Size = new Size(0x1f, 0x18);
            this._CloseButton.TabIndex = 5;
            this._CloseButton.Text = "X";
            this._CloseButton.TextLocation_X = 6;
            this._CloseButton.TextLocation_Y = 1;
            this._CloseButton.UseVisualStyleBackColor = true;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(0x19, 0x19, 0x19);
            base.ClientSize = new Size(0x187, 0x18a);
            base.Controls.Add(this.panel1);
            base.FormBorderStyle = FormBorderStyle.None;
            base.Name = "Form2";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            base.ResumeLayout(false);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            this.mouseDown = true;
            this.lastLocation = e.Location;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.mouseDown)
            {
                base.Location = new Point((base.Location.X - this.lastLocation.X) + e.X, (base.Location.Y - this.lastLocation.Y) + e.Y);
                base.Update();
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            this.mouseDown = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
