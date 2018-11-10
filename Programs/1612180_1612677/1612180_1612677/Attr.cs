using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1612180_1612677
{
    // luu nhung thuoc tinh cua brush
    public class BrushAttr
    {
        public BrushAttr(Color _color, String _typeBrush)
        {
            color = _color;
            typeBrush = _typeBrush;
        }

        public BrushAttr(BrushAttr brushAttr)
        {
            // mac dinh la mau trang
            if (brushAttr == null)
            {
                color = Color.White;
                typeBrush = "SolidBrush";
            }
            else
            {
                color = brushAttr.color;
                typeBrush = brushAttr.typeBrush;
            }
        }

        public Color color { get; set; }
        public String typeBrush { get; set; }
    }

    // luu nhung thuoc tinh cua font
    public class FontAttr
    {
        public FontAttr(String _text, string _fontFamily, int _size)
        {
            text = _text;
            fontFamily = _fontFamily;
            size = _size;
        }

        public FontAttr(FontAttr fontAttr)
        {
            text = fontAttr.text;
            fontFamily = fontAttr.fontFamily;
            size = fontAttr.size;
        }

        public string fontFamily { get; set; }
        public int size { get; set; }
        public String text { get; set; }
    }

    // luu nhung thuoc tinh cua pen
    public class PenAttr
    {
        public PenAttr(Color _color, DashStyle _dashStyle, int _width)
        {
            color = _color;
            dashStyle = _dashStyle;
            width = _width;
        }

        public PenAttr(PenAttr penAttr)
        {
            color = penAttr.color;
            dashStyle = penAttr.dashStyle;
            width = penAttr.width;
        }

        public Color color { get; set; }
        public DashStyle dashStyle { get; set; }
        public int width { get; set; }
    }
}