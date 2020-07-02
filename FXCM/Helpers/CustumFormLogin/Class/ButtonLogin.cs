using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FXCM.Helpers.CustumFormLogin.Class
{
    public sealed class ButtonLogin : Button
    {
        private Color _btnColor;
        private Color _color = Color.Teal;
        private Color _mHovercolor = Color.FromArgb(0, 0, 140);
        private Color _clickcolor = Color.FromArgb(160, 180, 200);
        private int _textX = 6;
        private int _textY = -20;
        private string _text;

        public string DisplayText
        {
            get => _text;
            set
            {
                _text = value;
                Invalidate();
            }
        }
        public Color BZBackColor
        {
            get => _color;
            set
            {
                _color = value;
                Invalidate();
            }
        }

        public Color MouseHoverColor
        {
            get => _mHovercolor;
            set
            {
                _mHovercolor = value;
                Invalidate();
            }
        }

        public Color MouseClickColor1
        {
            get => _clickcolor;
            set
            {
                _clickcolor = value;
                Invalidate();
            }
        }


        public int TextLocation_X
        {
            get => _textX;
            set
            {
                _textX = value;
                Invalidate();
            }
        }
        public int TextLocation_Y
        {
            get => _textY;
            set
            {
                _textY = value;
                Invalidate();
            }
        }
        public ButtonLogin()
        {
            Size = new Size(31, 24);
            ForeColor = Color.White;
            FlatStyle = FlatStyle.Flat;
            Font = new Font("Microsoft YaHei UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Text = "_";
            _text = Text;
        }
        //method mouse enter
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            _btnColor = _color;
            _color = _mHovercolor;
        }
        //method mouse leave
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _color = _btnColor;
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            _color = _clickcolor;
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            _color = _btnColor;
        }


        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            _text = Text;
            if (_textX == 100 && _textY == 25)
            {
                _textX = Width / 3 + 10;
                _textY = Height / 2 - 1;
            }

            var p = new Point(_textX, _textY);
            pe.Graphics.FillRectangle(new SolidBrush(_color), ClientRectangle);
            pe.Graphics.DrawString(_text, Font, new SolidBrush(ForeColor), p);
        }
    }
}
