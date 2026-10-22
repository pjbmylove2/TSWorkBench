using System.Drawing;
using System.Windows.Forms;

namespace TSWorkBench.Theme
{
    /// <summary>오른쪽 클릭 메뉴·드롭다운 메뉴를 다크 색으로 그린다.</summary>
    public sealed class DarkMenuRenderer : ToolStripProfessionalRenderer
    {
        public DarkMenuRenderer() : base(new DarkColors())
        {
        }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            e.TextColor = e.Item.Enabled ? DarkTheme.Text : DarkTheme.Muted;
            base.OnRenderItemText(e);
        }

        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            e.ArrowColor = DarkTheme.Text;
            base.OnRenderArrow(e);
        }

        public static ContextMenuStrip CreateMenu()
        {
            return new ContextMenuStrip { Renderer = new DarkMenuRenderer(), BackColor = DarkTheme.Panel, ForeColor = DarkTheme.Text };
        }

        private sealed class DarkColors : ProfessionalColorTable
        {
            public override Color ToolStripDropDownBackground => DarkTheme.Panel;
            public override Color ImageMarginGradientBegin => DarkTheme.Panel;
            public override Color ImageMarginGradientMiddle => DarkTheme.Panel;
            public override Color ImageMarginGradientEnd => DarkTheme.Panel;
            public override Color MenuBorder => DarkTheme.Line;
            public override Color MenuItemBorder => DarkTheme.Selection;
            public override Color MenuItemSelected => DarkTheme.Selection;
            public override Color MenuItemSelectedGradientBegin => DarkTheme.Selection;
            public override Color MenuItemSelectedGradientEnd => DarkTheme.Selection;
            public override Color MenuItemPressedGradientBegin => DarkTheme.Selection;
            public override Color MenuItemPressedGradientEnd => DarkTheme.Selection;
            public override Color SeparatorDark => DarkTheme.Line;
            public override Color SeparatorLight => DarkTheme.Line;
        }
    }
}
