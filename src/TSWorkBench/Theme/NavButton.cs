using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace TSWorkBench.Theme
{
    /// <summary>
    /// 메뉴·섹션 전환 버튼. 같은 부모 안에서 하나만 눌린다(RadioButton).
    /// 눌린 버튼은 강조색 막대를 왼쪽(세로 메뉴) 또는 아래(가로 탭)에 그린다.
    /// </summary>
    public class NavButton : RadioButton
    {
        private bool barAtBottom;

        public NavButton()
        {
            Appearance = Appearance.Button;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            FlatAppearance.CheckedBackColor = DarkTheme.Selection;
            FlatAppearance.MouseOverBackColor = DarkTheme.ButtonHover;
            FlatAppearance.MouseDownBackColor = DarkTheme.ButtonDown;
            BackColor = DarkTheme.Panel;
            ForeColor = DarkTheme.Text;
            UseVisualStyleBackColor = false;
            Cursor = Cursors.Hand;
            TextAlign = ContentAlignment.MiddleLeft;
            Padding = new Padding(14, 0, 0, 0);
        }

        /// <summary>true면 가로 탭처럼 아래에 막대를 그린다.</summary>
        [DefaultValue(false)]
        [Category("Appearance")]
        public bool BarAtBottom
        {
            get { return barAtBottom; }
            set
            {
                barAtBottom = value;
                Invalidate();
            }
        }

        protected override void OnCheckedChanged(System.EventArgs e)
        {
            base.OnCheckedChanged(e);
            ForeColor = Checked ? Color.White : DarkTheme.Text;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (!Checked)
            {
                return;
            }

            using (var brush = new SolidBrush(DarkTheme.Accent))
            {
                var bar = barAtBottom ? new Rectangle(0, Height - 3, Width, 3) : new Rectangle(0, 0, 4, Height);
                e.Graphics.FillRectangle(brush, bar);
            }
        }
    }
}
