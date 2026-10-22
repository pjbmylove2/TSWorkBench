using System.ComponentModel;
using System.Windows.Forms;
using TSWorkBench.Models;
using TSWorkBench.Storage;
using TSWorkBench.Theme;

namespace TSWorkBench.Pages
{
    /// <summary>메인 창이 페이지에 제공하는 기능.</summary>
    public interface IAppHost
    {
        Workspace Workspace { get; }

        /// <summary>업무 카드 편집 창을 연다. 닫히면 화면을 새로 고친다.</summary>
        void OpenItem(WorkItem item);

        void NewItem();

        /// <summary>업무 목록으로 가서 미리 정한 조건(active, overdue, due7, followup, doneMonth)을 건다.</summary>
        void ShowList(string preset);

        /// <summary>데이터 폴더가 바뀌었을 때 전체를 다시 읽는다.</summary>
        void ReloadWorkspace(string dataFolder);

        void RefreshCurrentPage();

        ContextMenuStrip CreateItemMenu(DarkGrid grid);
    }

    /// <summary>메인 창 오른쪽에 들어가는 화면들의 바탕.</summary>
    public class PageBase : UserControl
    {
        public PageBase()
        {
            BackColor = DarkTheme.Back;
            ForeColor = DarkTheme.Text;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected IAppHost Host { get; private set; }

        protected Workspace Ws => Host.Workspace;

        public virtual string PageTitle => "";

        public virtual string PageSubtitle => "";

        /// <summary>F1을 누르면 열 사용설명서 제목의 앞부분 (예: "3.7"). 없으면 사용설명서 처음.</summary>
        public virtual string HelpTopic => null;

        public virtual void Attach(IAppHost host)
        {
            Host = host;
        }

        /// <summary>화면이 보일 때마다 불린다. 저장소의 최신 내용으로 다시 그린다.</summary>
        public virtual void RefreshData()
        {
        }
    }
}
