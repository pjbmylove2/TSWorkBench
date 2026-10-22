using System;
using System.Collections.Generic;
using System.Linq;
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
            if (workspace.Items.LoadErrors.Count == 0)
            {
                return;
            }

            MessageBox.Show(this, "읽지 못한 업무 파일이 있습니다. 같은 폴더의 item.json.bak으로 복구할 수 있습니다.\n\n"
                + string.Join("\n", workspace.Items.LoadErrors.Take(10)), "업무 파일 읽기 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
