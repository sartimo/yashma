namespace CustomWindowsForm
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public class ButtonX : Button
    {
        private Color clr1;
        private Color color = Color.Teal;
        private Color m_hovercolor = Color.FromArgb(0, 0, 140);
        private Color clickcolor = Color.FromArgb(160, 180, 200);
        private int textX = 6;
        private int textY = -20;
        private string text = "_";
        private bool isChanged = true;

        public ButtonX()
        {
            base.Size = new Size(0x1f, 0x18);
            this.ForeColor = Color.White;
            base.FlatStyle = FlatStyle.Flat;
            this.Font = new Font("Microsoft YaHei UI", 20.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.Text = "_";
            this.text = this.Text;
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            if (this.isChanged)
            {
                this.color = this.clickcolor;
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            this.clr1 = this.color;
            this.color = this.m_hovercolor;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (this.isChanged)
            {
                this.color = this.clr1;
            }
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            if (this.isChanged)
            {
                this.color = this.clr1;
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            this.text = this.Text;
            if ((this.textX == 100) && (this.textY == 0x19))
            {
                this.textX = (base.Width / 3) + 10;
                this.textY = (base.Height / 2) - 1;
            }
            Point point = new Point(this.textX, this.textY);
            pe.Graphics.FillRectangle(new SolidBrush(this.color), base.ClientRectangle);
            pe.Graphics.DrawString(this.text, this.Font, new SolidBrush(this.ForeColor), (PointF) point);
        }

        public string DisplayText
        {
            get => 
                this.text;
            set
            {
                this.text = value;
                base.Invalidate();
            }
        }

        public Color BZBackColor
        {
            get => 
                this.color;
            set
            {
                this.color = value;
                base.Invalidate();
            }
        }

        public Color MouseHoverColor
        {
            get => 
                this.m_hovercolor;
            set
            {
                this.m_hovercolor = value;
                base.Invalidate();
            }
        }

        public Color MouseClickColor1
        {
            get => 
                this.clickcolor;
            set
            {
                this.clickcolor = value;
                base.Invalidate();
            }
        }

        public bool ChangeColorMouseHC
        {
            get => 
                this.isChanged;
            set
            {
                this.isChanged = value;
                base.Invalidate();
            }
        }

        public int TextLocation_X
        {
            get => 
                this.textX;
            set
            {
                this.textX = value;
                base.Invalidate();
            }
        }

        public int TextLocation_Y
        {
            get => 
                this.textY;
            set
            {
                this.textY = value;
                base.Invalidate();
            }
        }
    }
}
