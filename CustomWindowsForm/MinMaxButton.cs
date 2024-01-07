namespace CustomWindowsForm
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public class MinMaxButton : Button
    {
        private Color clr1;
        private Color color = Color.Gray;
        private Color m_hovercolor = Color.FromArgb(180, 200, 240);
        private Color clickcolor = Color.FromArgb(160, 180, 200);
        private int textX = 6;
        private int textY = -20;
        private string text = "_";
        private CustomFormState _customFormState;

        public MinMaxButton()
        {
            base.Size = new Size(0x1f, 0x18);
            this.ForeColor = Color.White;
            base.FlatStyle = FlatStyle.Flat;
            this.Text = "_";
            this.text = this.Text;
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            this.color = this.clickcolor;
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
            this.color = this.clr1;
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            this.color = this.clr1;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            int num;
            base.OnPaint(pe);
            switch (this._customFormState)
            {
                case CustomFormState.Normal:
                    pe.Graphics.FillRectangle(new SolidBrush(this.color), base.ClientRectangle);
                    num = 0;
                    while (true)
                    {
                        if (num >= 2)
                        {
                            break;
                        }
                        pe.Graphics.DrawRectangle(new Pen(this.ForeColor), (this.textX + num) + 1, this.textY, 10, 10);
                        pe.Graphics.FillRectangle(new SolidBrush(this.ForeColor), this.textX + 1, this.textY - 1, 12, 4);
                        num++;
                    }
                    break;

                case CustomFormState.Maximize:
                    pe.Graphics.FillRectangle(new SolidBrush(this.color), base.ClientRectangle);
                    num = 0;
                    while (true)
                    {
                        if (num >= 2)
                        {
                            break;
                        }
                        pe.Graphics.DrawRectangle(new Pen(this.ForeColor), this.textX + 5, this.textY, 8, 8);
                        pe.Graphics.FillRectangle(new SolidBrush(this.ForeColor), this.textX + 5, this.textY - 1, 9, 4);
                        pe.Graphics.DrawRectangle(new Pen(this.ForeColor), this.textX + 2, this.textY + 5, 8, 8);
                        pe.Graphics.FillRectangle(new SolidBrush(this.ForeColor), this.textX + 2, this.textY + 4, 9, 4);
                        num++;
                    }
                    break;

                default:
                    break;
            }
        }

        public CustomFormState CFormState
        {
            get => 
                this._customFormState;
            set
            {
                this._customFormState = value;
                base.Invalidate();
            }
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

        public enum CustomFormState
        {
            Normal,
            Maximize
        }
    }
}
