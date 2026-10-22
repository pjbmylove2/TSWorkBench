using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using TSWorkBench.Models;

namespace TSWorkBench.Theme
{
    /// <summary>OmniSight와 같은 다크 팔레트. 색은 여기 한 곳에서만 정한다.</summary>
    public static class DarkTheme
    {
        public static readonly Color Back = Color.FromArgb(33, 33, 33);          // #212121 폼·본문
        public static readonly Color Panel = Color.FromArgb(47, 47, 47);         // #2F2F2F 카드·메뉴
        public static readonly Color Input = Color.FromArgb(56, 56, 58);         // 입력칸
        public static readonly Color Line = Color.FromArgb(64, 64, 64);          // #404040 구분선·헤더
        public static readonly Color Button = Color.FromArgb(64, 65, 68);        // #404144
        public static readonly Color ButtonHover = Color.FromArgb(78, 79, 83);
        public static readonly Color ButtonDown = Color.FromArgb(90, 91, 96);
        public static readonly Color GridRow = Color.FromArgb(45, 45, 48);       // #2D2D30
        public static readonly Color GridAltRow = Color.FromArgb(53, 53, 56);    // #353538
        public static readonly Color GridHeader = Color.FromArgb(51, 51, 51);    // #333333
        public static readonly Color Selection = Color.FromArgb(70, 70, 75);     // #46464B
        public static readonly Color Text = Color.FromArgb(236, 236, 236);       // #ECECEC
        public static readonly Color Muted = Color.FromArgb(160, 160, 160);
        public static readonly Color Accent = Color.RosyBrown;                   // #BC8F8F 선택·강조
        public static readonly Color AccentHover = Color.FromArgb(204, 163, 163);
        public static readonly Color Ok = Color.FromArgb(46, 204, 113);          // #2ECC71
        public static readonly Color Danger = Color.FromArgb(231, 76, 60);       // #E74C3C
        public static readonly Color Warning = Color.FromArgb(241, 196, 15);
        public static readonly Color Info = Color.FromArgb(52, 152, 219);


        public static Color StatusColor(WorkStatus status)
        {
            switch (status)
            {
                case WorkStatus.Received: return Info;
                case WorkStatus.Analyzing: return Color.FromArgb(155, 89, 182);
                case WorkStatus.InProgress: return Color.FromArgb(230, 126, 34);
                case WorkStatus.Verifying: return Warning;
                case WorkStatus.Done: return Ok;
                case WorkStatus.OnHold: return Color.FromArgb(127, 140, 141);
                default: return Color.DimGray;
            }
        }

        public static Color PriorityColor(Priority priority)
        {
            switch (priority)
            {
                case Priority.Urgent: return Danger;
                case Priority.High: return Color.FromArgb(230, 126, 34);
                case Priority.Low: return Muted;
                default: return Text;
            }
        }

        /// <summary>Windows 10 2004+ / 11의 창 제목 표시줄을 어둡게 한다. 지원하지 않는 OS에서는 아무 일도 하지 않는다.</summary>
        public static void ApplyTitleBar(IntPtr handle)
        {
            try
            {
                var on = 1;
                if (DwmSetWindowAttribute(handle, DwmwaUseImmersiveDarkMode, ref on, sizeof(int)) != 0)
                {
                    DwmSetWindowAttribute(handle, DwmwaUseImmersiveDarkModeOld, ref on, sizeof(int));
                }

                var caption = ToColorRef(Back);
                DwmSetWindowAttribute(handle, DwmwaCaptionColor, ref caption, sizeof(int));
                var border = ToColorRef(Line);
                DwmSetWindowAttribute(handle, DwmwaBorderColor, ref border, sizeof(int));
                var text = ToColorRef(Text);
                DwmSetWindowAttribute(handle, DwmwaTextColor, ref text, sizeof(int));
            }
            catch (DllNotFoundException)
            {
            }
            catch (EntryPointNotFoundException)
            {
            }
        }

        /// <summary>스크롤바를 어둡게 한다 (Windows 10 1809+). 실패해도 기능에는 영향 없다.</summary>
        public static void DarkScrollBars(Control control)
        {
            if (!control.IsHandleCreated)
            {
                return;
            }

            try
            {
                SetWindowTheme(control.Handle, "DarkMode_Explorer", null);
            }
            catch (DllNotFoundException)
            {
            }
            catch (EntryPointNotFoundException)
            {
            }
        }

        /// <summary>여러 줄 입력칸·목록 상자의 스크롤바를 모두 어둡게 한다. 아직 안 만들어진 컨트롤은 만들어질 때 적용한다.</summary>
        public static void DarkScrollBarsAll(Control root)
        {
            foreach (Control c in root.Controls)
            {
                var box = c as TextBoxBase;
                if ((box != null && box.Multiline) || c is ListBox)
                {
                    if (c.IsHandleCreated)
                    {
                        DarkScrollBars(c);
                    }
                    else
                    {
                        c.HandleCreated += (s, e) => DarkScrollBars((Control)s);
                    }
                }

                DarkScrollBarsAll(c);
            }
        }

        private static int ToColorRef(Color c)
        {
            return c.R | (c.G << 8) | (c.B << 16);
        }

        private const int DwmwaUseImmersiveDarkModeOld = 19;
        private const int DwmwaUseImmersiveDarkMode = 20;
        private const int DwmwaBorderColor = 34;
        private const int DwmwaCaptionColor = 35;
        private const int DwmwaTextColor = 36;

        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attribute, ref int value, int size);

        [DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
        private static extern int SetWindowTheme(IntPtr hwnd, string appName, string idList);
    }
}
