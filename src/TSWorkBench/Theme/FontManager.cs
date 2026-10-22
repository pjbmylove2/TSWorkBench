using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TSWorkBench.Theme
{
    /// <summary>
    /// 실행 파일에 넣은 나눔고딕을 읽어 모든 컨트롤에 적용한다. OmniSight UI\Utils\FontManager와 같은 방식.
    /// 폰트를 못 읽어도 프로그램은 멈추지 않고 맑은 고딕을 쓴다.
    /// </summary>
    public static class FontManager
    {
        public const string ResourceName = "TSWorkBench.Resources.NanumGothic.ttf";
        private const string FallbackFontName = "맑은 고딕";

        private static PrivateFontCollection privateFonts;
        private static FontFamily customFamily;
        private static IntPtr fontMemory = IntPtr.Zero;
        private static IntPtr gdiFontHandle = IntPtr.Zero;
        private static bool initializationAttempted;

        private static readonly object Sync = new object();
        private static readonly Dictionary<string, Font> SharedFonts = new Dictionary<string, Font>();
        private static readonly ConditionalWeakTable<Control, object> HookedControls = new ConditionalWeakTable<Control, object>();
        private static readonly object HookMarker = new object();

        public static string ActiveFontName => customFamily != null ? customFamily.Name : FallbackFontName;

        public static bool IsCustomFontLoaded => customFamily != null;

        /// <summary>프로그램 시작 때 한 번. 폰트 데이터는 종료할 때까지 비관리 메모리에 고정한다.</summary>
        public static void Initialize()
        {
            initializationAttempted = true;
            try
            {
                using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(ResourceName))
                {
                    if (stream == null)
                    {
                        ErrorLog.Write("글꼴 리소스를 찾을 수 없음: " + ResourceName);
                        return;
                    }

                    var length = (int)stream.Length;
                    var data = new byte[length];
                    var offset = 0;
                    while (offset < length)
                    {
                        var read = stream.Read(data, offset, length - offset);
                        if (read <= 0)
                        {
                            throw new EndOfStreamException("글꼴 데이터를 모두 읽지 못했습니다.");
                        }

                        offset += read;
                    }

                    // PrivateFontCollection은 AddMemoryFont 뒤에도 이 메모리를 참조한다.
                    fontMemory = Marshal.AllocCoTaskMem(length);
                    Marshal.Copy(data, 0, fontMemory, length);
                    privateFonts = new PrivateFontCollection();
                    privateFonts.AddMemoryFont(fontMemory, length);

                    // TextBox·Label 등은 GDI로 그리므로 GDI에도 같은 폰트를 등록해야 실제로 나눔고딕이 보인다.
                    uint installed = 0;
                    gdiFontHandle = AddFontMemResourceEx(fontMemory, (uint)length, IntPtr.Zero, ref installed);

                    if (privateFonts.Families.Length > 0)
                    {
                        customFamily = privateFonts.Families[0];
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.Write("글꼴 읽기 실패", ex);
                customFamily = null;
            }
        }

        /// <summary>직접 그리기용 새 Font. 호출한 쪽이 Dispose한다.</summary>
        public static Font CreateFont(float size, FontStyle style = FontStyle.Regular)
        {
            try
            {
                return customFamily != null ? new Font(customFamily, size, style) : new Font(FallbackFontName, size, style);
            }
            catch (ArgumentException)
            {
                return customFamily != null ? new Font(customFamily, size) : new Font(FallbackFontName, size);
            }
        }

        /// <summary>
        /// 컨트롤 트리 전체의 글꼴 계열만 바꾼다(크기·굵기는 유지).
        /// 나중에 추가되는 자식 컨트롤도 ControlAdded로 같은 글꼴을 쓴다.
        /// </summary>
        public static void Apply(Control root)
        {
            if (!initializationAttempted || root == null || root.IsDisposed)
            {
                return;
            }

            ApplyToControl(root);
            object marker;
            if (!HookedControls.TryGetValue(root, out marker))
            {
                HookedControls.Add(root, HookMarker);
                root.ControlAdded += (sender, args) => Apply(args.Control);
            }

            foreach (Control child in root.Controls)
            {
                Apply(child);
            }
        }

        public static void ApplyToMenu(ToolStrip menu)
        {
            if (!initializationAttempted)
            {
                return;
            }

            menu.Font = GetSharedFont(menu.Font);
            foreach (ToolStripItem item in menu.Items)
            {
                item.Font = GetSharedFont(item.Font ?? menu.Font);
            }
        }

        /// <summary>프로그램 종료 때 한 번.</summary>
        public static void Release()
        {
            lock (Sync)
            {
                foreach (var font in SharedFonts.Values)
                {
                    font.Dispose();
                }

                SharedFonts.Clear();
            }

            privateFonts?.Dispose();
            privateFonts = null;
            customFamily = null;
            if (gdiFontHandle != IntPtr.Zero)
            {
                RemoveFontMemResourceEx(gdiFontHandle);
                gdiFontHandle = IntPtr.Zero;
            }

            if (fontMemory != IntPtr.Zero)
            {
                Marshal.FreeCoTaskMem(fontMemory);
                fontMemory = IntPtr.Zero;
            }
        }

        private static void ApplyToControl(Control control)
        {
            control.Font = GetSharedFont(control.Font);

            // DataGridView는 셀 스타일마다 폰트를 따로 가질 수 있다.
            var grid = control as DataGridView;
            if (grid != null)
            {
                ApplyGridStyle(grid.DefaultCellStyle, grid.Font);
                ApplyGridStyle(grid.RowsDefaultCellStyle, grid.Font);
                ApplyGridStyle(grid.AlternatingRowsDefaultCellStyle, grid.Font);
                ApplyGridStyle(grid.ColumnHeadersDefaultCellStyle, grid.Font);
                ApplyGridStyle(grid.RowHeadersDefaultCellStyle, grid.Font);
                foreach (DataGridViewColumn column in grid.Columns)
                {
                    ApplyGridStyle(column.DefaultCellStyle, grid.Font);
                }
            }
        }

        private static void ApplyGridStyle(DataGridViewCellStyle style, Font inherited)
        {
            if (style != null)
            {
                style.Font = GetSharedFont(style.Font ?? inherited);
            }
        }

        /// <summary>크기·굵기·단위가 같은 글꼴은 하나만 만들어 같이 쓴다 (GDI 핸들이 늘지 않게).</summary>
        private static Font GetSharedFont(Font source)
        {
            source = source ?? SystemFonts.DefaultFont;
            if (string.Equals(source.Name, ActiveFontName, StringComparison.OrdinalIgnoreCase))
            {
                return source;
            }

            var key = source.Size.ToString("R", System.Globalization.CultureInfo.InvariantCulture) + "|" + (int)source.Style + "|" + (int)source.Unit;
            lock (Sync)
            {
                Font cached;
                if (SharedFonts.TryGetValue(key, out cached))
                {
                    return cached;
                }

                try
                {
                    cached = customFamily != null
                        ? new Font(customFamily, source.Size, source.Style, source.Unit)
                        : new Font(FallbackFontName, source.Size, source.Style, source.Unit);
                }
                catch (ArgumentException)
                {
                    cached = customFamily != null
                        ? new Font(customFamily, source.Size, FontStyle.Regular, source.Unit)
                        : new Font(FallbackFontName, source.Size, FontStyle.Regular, source.Unit);
                }

                SharedFonts.Add(key, cached);
                return cached;
            }
        }

        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr font, uint length, IntPtr reserved, ref uint installed);

        [DllImport("gdi32.dll")]
        private static extern bool RemoveFontMemResourceEx(IntPtr handle);
    }
}
