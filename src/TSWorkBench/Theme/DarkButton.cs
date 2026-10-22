using System.ComponentModel;
using System.Windows.Forms;

namespace TSWorkBench.Theme
{
    /// <summary>평면 다크 버튼. Accent = true면 강조색(RosyBrown) 버튼.</summary>
    public class DarkButton : Button
    {
        private bool accent;

        public DarkButton()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            UseVisualStyleBackColor = false;
            Cursor = Cursors.Hand;
            ApplyColors();
        }

        [DefaultValue(false)]
        [Category("Appearance")]
        public bool Accent
        {
            get { return accent; }
            set
            {
                accent = value;
                ApplyColors();
            }
        }

        private void ApplyColors()
        {
            BackColor = accent ? DarkTheme.Accent : DarkTheme.Button;
            ForeColor = accent ? System.Drawing.Color.White : DarkTheme.Text;
            FlatAppearance.MouseOverBackColor = accent ? DarkTheme.AccentHover : DarkTheme.ButtonHover;
            FlatAppearance.MouseDownBackColor = accent ? DarkTheme.Accent : DarkTheme.ButtonDown;
        }
    }
}
