using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace TSWorkBench.Theme
{
    /// <summary>대시보드 숫자 카드: 위에 제목, 가운데 큰 숫자, 왼쪽에 색 막대. 누르면 Click.</summary>
    public class StatTile : Control
    {
        private string caption = "제목";
        private string valueText = "0";
        private Color barColor = DarkTheme.Accent;
        private bool hover;

        public StatTile()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            BackColor = DarkTheme.Panel;
            ForeColor = DarkTheme.Text;
            Size = new Size(200, 92);
            Cursor = Cursors.Hand;
        }

        [Category("Appearance")]
        [DefaultValue("제목")]
        public string Caption
        {
            get { return caption; }
            set
            {
                caption = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        [DefaultValue("0")]
        public string ValueText
        {
            get { return valueText; }
            set
            {
                valueText = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        public Color BarColor
        {
            get { return barColor; }
            set
            {
                barColor = value;
                Invalidate();
            }
        }

        protected override void OnMouseEnter(System.EventArgs e)
        {
            base.OnMouseEnter(e);
            hover = true;
            Invalidate();
        }

        protected override void OnMouseLeave(System.EventArgs e)
        {
            base.OnMouseLeave(e);
            hover = false;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.Clear(hover ? DarkTheme.Selection : BackColor);
            using (var bar = new SolidBrush(barColor))
            using (var captionFont = FontManager.CreateFont(9.5f))
            using (var valueFont = FontManager.CreateFont(24f, FontStyle.Bold))
            using (var mutedBrush = new SolidBrush(DarkTheme.Muted))
            using (var textBrush = new SolidBrush(ForeColor))
            {
                g.FillRectangle(bar, 0, 0, 5, Height);
                g.DrawString(caption, captionFont, mutedBrush, 18, 12);
                g.DrawString(valueText, valueFont, textBrush, 14, 34);
            }
        }
    }
}
