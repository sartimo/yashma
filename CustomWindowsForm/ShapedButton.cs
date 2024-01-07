namespace CustomWindowsForm
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    public class ShapedButton : Button
    {
        private Color clr1;
        private Color clr2;
        private Color color1 = Color.DodgerBlue;
        private Color color2 = Color.MidnightBlue;
        private Color m_hovercolor1 = Color.Turquoise;
        private Color m_hovercolor2 = Color.DarkSlateGray;
        private int color1Transparent = 250;
        private int color2Transparent = 250;
        private Color clickcolor1 = Color.Yellow;
        private Color clickcolor2 = Color.Red;
        private int angle = 90;
        private int textX = 100;
        private int textY = 0x19;
        private string text = "";
        public Color buttonborder = Color.FromArgb(220, 220, 220);
        public bool showButtonText = true;
        public int borderWidth = 2;
        public Color borderColor = Color.Transparent;
        private ButtonsShapes buttonShape;

        public ShapedButton()
        {
            base.Size = new Size(100, 40);
            this.BackColor = Color.Transparent;
            base.FlatStyle = FlatStyle.Flat;
            base.FlatAppearance.BorderSize = 0;
            base.FlatAppearance.MouseOverBackColor = Color.Transparent;
            base.FlatAppearance.MouseDownBackColor = Color.Transparent;
            this.text = this.Text;
        }

        private void DrawCircularButton(Graphics g)
        {
            Color color = Color.FromArgb(this.color1Transparent, this.color1);
            Brush brush = new LinearGradientBrush(base.ClientRectangle, color, Color.FromArgb(this.color2Transparent, this.color2), (float) this.angle);
            g.FillEllipse(brush, 5, 5, base.Width - 10, base.Height - 10);
            int num = 0;
            while (true)
            {
                if (num >= this.borderWidth)
                {
                    if (this.showButtonText)
                    {
                        Point point = new Point(this.textX, this.textY);
                        SolidBrush brush2 = new SolidBrush(this.ForeColor);
                        g.DrawString(this.text, this.Font, brush2, (PointF) point);
                    }
                    brush.Dispose();
                    return;
                }
                g.DrawEllipse(new Pen(new SolidBrush(this.buttonborder)), 5 + num, 5, base.Width - 10, base.Height - 10);
                num++;
            }
        }

        private void DrawRoundRectangularButton(Graphics g)
        {
            Color color = Color.FromArgb(this.color1Transparent, this.color1);
            Brush brush = new LinearGradientBrush(base.ClientRectangle, color, Color.FromArgb(this.color2Transparent, this.color2), (float) this.angle);
            Region region = new Region(new Rectangle(5, 5, base.Width, base.Height));
            GraphicsPath path = new GraphicsPath();
            path.AddArc(5, 5, 40, 40, 180f, 90f);
            path.AddLine(0x19, 5, base.Width - 0x19, 5);
            path.AddArc(base.Width - 0x2d, 5, 40, 40, 270f, 90f);
            path.AddLine(base.Width - 5, 0x19, base.Width - 5, base.Height - 0x19);
            path.AddArc(base.Width - 0x2d, base.Height - 0x2d, 40, 40, 0f, 90f);
            path.AddLine(0x19, base.Height - 5, base.Width - 0x19, base.Height - 5);
            path.AddArc(5, base.Height - 0x2d, 40, 40, 90f, 90f);
            path.AddLine(5, 0x19, 5, base.Height - 0x19);
            region.Intersect(path);
            g.FillRegion(brush, region);
            int num = 0;
            while (true)
            {
                if (num >= this.borderWidth)
                {
                    if (this.showButtonText)
                    {
                        Point point = new Point(this.textX, this.textY);
                        SolidBrush brush2 = new SolidBrush(this.ForeColor);
                        g.DrawString(this.text, this.Font, brush2, (PointF) point);
                    }
                    brush.Dispose();
                    return;
                }
                g.DrawArc(new Pen(this.buttonborder), 5 + num, 5 + num, 40, 40, 180, 90);
                g.DrawLine(new Pen(this.buttonborder), 0x19, 5 + num, base.Width - 0x19, 5 + num);
                g.DrawArc(new Pen(this.buttonborder), (base.Width - 0x2d) - num, 5 + num, 40, 40, 270, 90);
                g.DrawLine(new Pen(this.buttonborder), 5 + num, 0x19, 5 + num, base.Height - 0x19);
                g.DrawLine(new Pen(this.buttonborder), (base.Width - 5) - num, 0x19, (base.Width - 5) - num, base.Height - 0x19);
                g.DrawArc(new Pen(this.buttonborder), (base.Width - 0x2d) - num, (base.Height - 0x2d) - num, 40, 40, 0, 90);
                g.DrawLine(new Pen(this.buttonborder), 0x19, (base.Height - 5) - num, base.Width - 0x19, (base.Height - 5) - num);
                g.DrawArc(new Pen(this.buttonborder), 5 + num, (base.Height - 0x2d) - num, 40, 40, 90, 90);
                num++;
            }
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            this.color1 = this.clr1;
            this.color2 = this.clr2;
            base.Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            this.color1 = this.clickcolor1;
            this.color2 = this.clickcolor2;
            this.buttonborder = this.borderColor;
            this.SetBorderColor(this.borderColor);
            base.Invalidate();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            this.clr1 = this.color1;
            this.clr2 = this.color2;
            this.color1 = this.m_hovercolor1;
            this.color2 = this.m_hovercolor2;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.color1 = this.clr1;
            this.color2 = this.clr2;
            this.SetBorderColor(this.borderColor);
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            this.OnMouseLeave(mevent);
            this.color1 = this.clr1;
            this.color2 = this.clr2;
            this.SetBorderColor(this.borderColor);
            base.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            switch (this.buttonShape)
            {
                case ButtonsShapes.RoundRect:
                    this.DrawRoundRectangularButton(e.Graphics);
                    break;

                case ButtonsShapes.Circle:
                    this.DrawCircularButton(e.Graphics);
                    break;

                default:
                    break;
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.textX = (base.Width / 3) - 1;
            this.textY = (base.Height / 3) + 5;
        }

        private void SetBorderColor(Color bdrColor)
        {
            int num = 0;
            int green = bdrColor.G - 40;
            int blue = bdrColor.B - 40;
            if ((bdrColor.R - 40) < 0)
            {
                num = 0;
            }
            if (green < 0)
            {
                green = 0;
            }
            if (blue < 0)
            {
                blue = 0;
            }
            this.buttonborder = Color.FromArgb(num, green, blue);
        }

        public ButtonsShapes ButtonShape
        {
            get => 
                this.buttonShape;
            set
            {
                this.buttonShape = value;
                base.Invalidate();
            }
        }

        public string ButtonText
        {
            get => 
                this.text;
            set
            {
                this.text = value;
                base.Invalidate();
            }
        }

        public int BorderWidth
        {
            get => 
                this.borderWidth;
            set
            {
                this.borderWidth = value;
                base.Invalidate();
            }
        }

        public Color BorderColor
        {
            get => 
                this.borderColor;
            set
            {
                this.borderColor = value;
                if (this.borderColor == Color.Transparent)
                {
                    this.buttonborder = Color.FromArgb(220, 220, 220);
                }
                else
                {
                    this.SetBorderColor(this.borderColor);
                }
            }
        }

        public Color StartColor
        {
            get => 
                this.color1;
            set
            {
                this.color1 = value;
                base.Invalidate();
            }
        }

        public Color EndColor
        {
            get => 
                this.color2;
            set
            {
                this.color2 = value;
                base.Invalidate();
            }
        }

        public Color MouseHoverColor1
        {
            get => 
                this.m_hovercolor1;
            set
            {
                this.m_hovercolor1 = value;
                base.Invalidate();
            }
        }

        public Color MouseHoverColor2
        {
            get => 
                this.m_hovercolor2;
            set
            {
                this.m_hovercolor2 = value;
                base.Invalidate();
            }
        }

        public Color MouseClickColor1
        {
            get => 
                this.clickcolor1;
            set
            {
                this.clickcolor1 = value;
                base.Invalidate();
            }
        }

        public Color MouseClickColor2
        {
            get => 
                this.clickcolor2;
            set
            {
                this.clickcolor2 = value;
                base.Invalidate();
            }
        }

        public int Transparent1
        {
            get => 
                this.color1Transparent;
            set
            {
                this.color1Transparent = value;
                if (this.color1Transparent <= 0xff)
                {
                    base.Invalidate();
                }
                else
                {
                    this.color1Transparent = 0xff;
                    base.Invalidate();
                }
            }
        }

        public int Transparent2
        {
            get => 
                this.color2Transparent;
            set
            {
                this.color2Transparent = value;
                if (this.color2Transparent <= 0xff)
                {
                    base.Invalidate();
                }
                else
                {
                    this.color2Transparent = 0xff;
                    base.Invalidate();
                }
            }
        }

        public int GradientAngle
        {
            get => 
                this.angle;
            set
            {
                this.angle = value;
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

        public bool ShowButtontext
        {
            get => 
                this.showButtonText;
            set
            {
                this.showButtonText = value;
                base.Invalidate();
            }
        }

        public enum ButtonsShapes
        {
            RoundRect,
            Circle
        }
    }
}
