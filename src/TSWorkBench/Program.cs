using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using TSWorkBench.Forms;
using TSWorkBench.Storage;

namespace TSWorkBench
{
    internal static class Program
    {
        /// <summary>실행 파일 옆 Templates\ — 데이터 폴더에 템플릿이 없을 때 여기서 복사한다.</summary>
        public static string TemplatesSource => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates");

        /// <summary>
        /// 실행 인자: --data "폴더"  이번 실행만 그 데이터 폴더를 쓴다 (예제 체험·테스트용, 기억하지 않음).
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += OnThreadException;

            var argFolder = ArgValue(args, "--data");
            var folder = argFolder ?? LocationStore.Load();
            while (true)
            {
                if (string.IsNullOrWhiteSpace(folder))
                {
                    folder = AskDataFolder(null, null);
                    if (folder == null)
                    {
                        return;
                    }
                }

                Workspace ws;
                try
                {
                    ws = Workspace.Open(folder, TemplatesSource);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("데이터 폴더를 열 수 없습니다.\n" + folder + "\n\n" + ex.Message, "TS WorkBench", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    folder = null;
                    argFolder = null;
                    continue;
                }

                if (argFolder == null)
                {
                    LocationStore.Save(folder);
                }

                Application.Run(new MainForm(ws));
                return;
            }
        }

        /// <summary>데이터 폴더 고르기. 취소하면 null.</summary>
        public static string AskDataFolder(IWin32Window owner, string initial)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.Description = "업무 데이터를 저장할 폴더를 선택하세요.\n(OneDrive 등 백업되는 위치를 권장합니다. 없으면 '새 폴더 만들기')";
                dialog.ShowNewFolderButton = true;
                dialog.SelectedPath = initial ?? Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                return dialog.ShowDialog(owner) == DialogResult.OK ? dialog.SelectedPath : null;
            }
        }

        private static string ArgValue(string[] args, string name)
        {
            for (var i = 0; i < args.Length - 1; i++)
            {
                if (string.Equals(args[i], name, StringComparison.OrdinalIgnoreCase))
                {
                    return args[i + 1];
                }
            }

            return null;
        }

        private static void OnThreadException(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show("예상하지 못한 오류가 났습니다. 입력 중인 내용은 저장 후 다시 시도하세요.\n\n" + e.Exception.Message,
                "TS WorkBench", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
