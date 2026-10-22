using System;
using System.Windows.Forms;

namespace TSWorkBench.Theme
{
    /// <summary>모든 창의 바탕. 어두운 배경·글꼴과 어두운 제목 표시줄을 적용한다.</summary>
    public class DarkForm : Form
    {
        public DarkForm()
        {
            BackColor = DarkTheme.Back;
            ForeColor = DarkTheme.Text;
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            DarkTheme.ApplyTitleBar(Handle);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            FontManager.Apply(this);
            DarkTheme.DarkScrollBarsAll(this);
        }
    }
}
