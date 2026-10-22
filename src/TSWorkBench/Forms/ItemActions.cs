using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using TSWorkBench.Models;
using TSWorkBench.Services;
using TSWorkBench.Storage;

namespace TSWorkBench.Forms
{
    /// <summary>업무 카드 창과 목록의 오른쪽 클릭 메뉴가 같이 쓰는 동작.</summary>
    public static class ItemActions
    {
        public static void OpenPath(string path)
        {
            if (!File.Exists(path) && !Directory.Exists(path))
            {
                MessageBox.Show("파일이나 폴더를 찾을 수 없습니다.\n" + path, "열기", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Process.Start(new ProcessStartInfo(path) { UseShellExecute = true });
        }

        public static void OpenFolder(Workspace ws, WorkItem item)
        {
            var folder = ws.Items.FolderOf(item);
            Directory.CreateDirectory(folder);
            OpenPath(folder);
        }

        public static void FieldReport(Workspace ws, WorkItem item)
        {
            var path = new ReportGenerator(ws).SaveFieldReport(item);
            OpenPath(path);
        }

        public static void CopyMarkdown(Workspace ws, WorkItem item)
        {
            Clipboard.SetText(new ReportGenerator(ws).ItemMarkdown(item));
            MessageBox.Show("Notion용 Markdown을 클립보드에 복사했습니다.\nNotion 페이지에 붙여넣기(Ctrl+V) 하세요.", "복사 완료",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static bool MoveToTrash(IWin32Window owner, Workspace ws, WorkItem item)
        {
            var answer = MessageBox.Show(owner, item.Id + " " + item.Title + "\n\n이 업무를 휴지통(데이터 폴더\\Trash)으로 옮길까요?\n파일은 지워지지 않습니다.",
                "휴지통으로 이동", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (answer != DialogResult.Yes)
            {
                return false;
            }

            ws.Items.MoveToTrash(item);
            return true;
        }

        public static void ShowError(IWin32Window owner, string what, Exception ex)
        {
            MessageBox.Show(owner, what + " 중 오류가 났습니다.\n\n" + ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
