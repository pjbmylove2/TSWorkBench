using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TSWorkBench.Models;
using TSWorkBench.Pages;
using TSWorkBench.Storage;
using TSWorkBench.Theme;

namespace TSWorkBench.Forms
{
    public partial class MainForm : DarkForm, IAppHost
    {
        private readonly Dictionary<NavButton, PageBase> pages = new Dictionary<NavButton, PageBase>();
        private PageBase current;
        private Workspace workspace;

        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(Workspace workspace) : this()
        {
            this.workspace = workspace;
            AddPage(navDashboard, new DashboardPage());
            AddPage(navList, new WorkListPage());
            AddPage(navPlanned, new WorkListPage { PlannedMode = true });
            AddPage(navKnowledge, new KnowledgePage());
            AddPage(navReports, new ReportsPage());
            AddPage(navReleases, new ReleasesPage());
            AddPage(navImport, new ImportPage());
            AddPage(navSettings, new SettingsPage());
        }

        public Workspace Workspace => workspace;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (workspace == null)
            {
                return;
            }

            UpdateWorkspaceLabel();
            navDashboard.Checked = true;
            ShowLoadErrors();
            StartDailyBackup();
        }

        /// <summary>오늘 백업이 없으면 뒤에서 만든다. 화면은 기다리지 않고, 실패는 오류 로그에만 남긴다.</summary>
        private void StartDailyBackup()
        {
            var ws = workspace;
            Task.Run(() =>
            {
                try
                {
                    BackupService.RunDaily(ws, DateTime.Now);
                }
                catch (Exception ex)
                {
                    ErrorLog.Write("자동 백업 실패", ex);
                }
            });
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Control | Keys.N:
                    QuickAdd();
                    return true;
                case Keys.Control | Keys.Shift | Keys.N:
                    NewItem();
                    return true;
                case Keys.F5:
                    RefreshCurrentPage();
                    return true;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        public void OpenItem(WorkItem item)
        {
            using (var form = new WorkItemForm(workspace, item))
            {
                form.ShowDialog(this);
            }

            RefreshCurrentPage();
        }

        public void NewItem()
        {
            OpenItem(workspace.NewItem(WorkType.FieldVisit, DateTime.Now));
        }

        public void ShowList(string preset)
        {
            navList.Checked = true;
            ((WorkListPage)pages[navList]).ApplyPreset(preset);
        }

        public void ReloadWorkspace(string dataFolder)
        {
            workspace = Workspace.Open(dataFolder, Program.TemplatesSource);
            LocationStore.Save(dataFolder);
            UpdateWorkspaceLabel();
            ShowLoadErrors();
            RefreshCurrentPage();
            StartDailyBackup();
        }

        public void RefreshCurrentPage()
        {
            UpdateWorkspaceLabel();
            current?.RefreshData();
        }

        public ContextMenuStrip CreateItemMenu(DarkGrid grid)
        {
            var menu = DarkMenuRenderer.CreateMenu();
            Func<WorkItem> selected = () => grid.SelectedTag<WorkItem>();
            menu.Items.Add("열기", null, (s, e) => Run(selected(), OpenItem));
            menu.Items.Add("복제해서 새 업무 (반복 업무)", null, (s, e) => Run(selected(), i => OpenItem(workspace.Duplicate(i, DateTime.Now))));
            menu.Items.Add("현장 조치 보고서 만들기", null, (s, e) => Run(selected(), i => ItemActions.FieldReport(workspace, i)));
            menu.Items.Add("Notion용 Markdown 복사", null, (s, e) => Run(selected(), i => ItemActions.CopyMarkdown(workspace, i)));
            menu.Items.Add("업무 폴더 열기", null, (s, e) => Run(selected(), i => ItemActions.OpenFolder(workspace, i)));
            menu.Items.Add(new ToolStripSeparator());
            menu.Items.Add("휴지통으로 이동", null, (s, e) => Run(selected(), i =>
            {
                if (ItemActions.MoveToTrash(this, workspace, i))
                {
                    RefreshCurrentPage();
                }
            }));

            // 오른쪽 버튼으로 누른 행을 먼저 선택한다.
            grid.CellMouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
                {
                    grid.CurrentCell = grid.Rows[e.RowIndex].Cells[Math.Max(0, e.ColumnIndex)];
                }
            };
            return menu;
        }

        private void Run(WorkItem item, Action<WorkItem> action)
        {
            if (item == null)
            {
                return;
            }

            try
            {
                action(item);
            }
            catch (Exception ex)
            {
                ItemActions.ShowError(this, "작업", ex);
            }
        }

        private void AddPage(NavButton nav, PageBase page)
        {
            page.Attach(this);
            page.Dock = DockStyle.Fill;
            page.Visible = false;
            pnlContent.Controls.Add(page);
            pages[nav] = page;
            nav.CheckedChanged += (s, e) =>
            {
                if (nav.Checked)
                {
                    ShowPage(page);
                }
            };
        }

        private void ShowPage(PageBase page)
        {
            if (current != null)
            {
                current.Visible = false;
            }

            current = page;
            lblPageTitle.Text = page.PageTitle;
            lblPageSubtitle.Text = page.PageSubtitle;
            page.RefreshData();
            page.Visible = true;
        }

        private void QuickAdd()
        {
            using (var form = new QuickAddForm(workspace))
            {
                if (form.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                if (form.OpenDetail)
                {
                    OpenItem(form.CreatedItem);
                }
                else
                {
                    RefreshCurrentPage();
                }
            }
        }

        private void UpdateWorkspaceLabel()
        {
            var user = string.IsNullOrWhiteSpace(workspace.Settings.UserName) ? "(설정에서 이름 입력)" : workspace.Settings.UserName;
            lblWorkspace.Text = user + "\n" + workspace.Root + "\n업무 " + workspace.Items.All.Count + "건";
        }

        private void ShowLoadErrors()
        {
            var errors = workspace.Items.LoadErrors.Concat(workspace.Releases.LoadErrors).ToList();
            if (errors.Count == 0)
            {
                return;
            }

            MessageBox.Show(this, "읽지 못한 파일이 있습니다. 같은 폴더의 .bak 파일(직전 저장본)로 복구할 수 있습니다.\n\n"
                + string.Join("\n", errors.Take(10)), "파일 읽기 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnQuickAdd_Click(object sender, EventArgs e)
        {
            QuickAdd();
        }

        private void btnNewItem_Click(object sender, EventArgs e)
        {
            NewItem();
        }
    }
}
