using System;
using System.Drawing;
using System.Windows.Forms;

namespace TSWorkBench.Theme
{
    /// <summary>
    /// 다크 콤보박스. 기본 Flat 콤보는 테두리·화살표 칸을 흰색으로 그리므로
    /// 목록 항목은 직접 그리고(OwnerDraw), WM_PAINT 뒤에 테두리와 화살표 칸을 덧칠한다.
    /// </summary>
    public class DarkComboBox : ComboBox
    {
        private const int WmPaint = 0x000F;

        public DarkComboBox()
        {
            FlatStyle = FlatStyle.Flat;
            DrawMode = DrawMode.OwnerDrawFixed;
            BackColor = DarkTheme.Input;
            ForeColor = DarkTheme.Text;
            ItemHeight = 19;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            var selected = (e.State & DrawItemState.Selected) != 0 && (e.State & DrawItemState.ComboBoxEdit) == 0;
            using (var back = new SolidBrush(selected ? DarkTheme.Selection : BackColor))
            {
                e.Graphics.FillRectangle(back, e.Bounds);
            }

            if (e.Index >= 0)
            {
                TextRenderer.DrawText(e.Graphics, GetItemText(Items[e.Index]), Font, e.Bounds, ForeColor,
                    TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPrefix | TextFormatFlags.EndEllipsis);
            }
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg != WmPaint || Width < 20)
            {
                return;
            }

            using (var g = Graphics.FromHwnd(Handle))
            using (var border = new Pen(DarkTheme.Line))
            using (var inner = new Pen(BackColor))
            using (var button = new SolidBrush(DarkTheme.Button))
            using (var arrow = new SolidBrush(DarkTheme.Text))
            {
                var r = ClientRectangle;
                g.DrawRectangle(inner, 1, 1, r.Width - 3, r.Height - 3);
                g.DrawRectangle(border, 0, 0, r.Width - 1, r.Height - 1);

                var buttonWidth = SystemInformation.HorizontalScrollBarArrowWidth;
                var box = new Rectangle(r.Width - buttonWidth - 1, 1, buttonWidth, r.Height - 2);
                g.FillRectangle(button, box);
                var cx = box.Left + box.Width / 2;
                var cy = box.Top + box.Height / 2;
                g.FillPolygon(arrow, new[] { new Point(cx - 4, cy - 2), new Point(cx + 4, cy - 2), new Point(cx, cy + 3) });
            }
        }
    }
}
