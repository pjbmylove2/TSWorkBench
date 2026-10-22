using System;
using System.Drawing;
using System.Windows.Forms;

namespace TSWorkBench.Theme
{
    /// <summary>OmniSight 결과 그리드와 같은 색의 DataGridView. 기본은 읽기 전용·행 단위 선택.</summary>
    public class DarkGrid : DataGridView
    {
        public DarkGrid()
        {
            DoubleBuffered = true;
            AutoGenerateColumns = false;
            AllowUserToAddRows = false;
            AllowUserToDeleteRows = false;
            AllowUserToResizeRows = false;
            ReadOnly = true;
            MultiSelect = false;
            RowHeadersVisible = false;
            SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            BorderStyle = BorderStyle.None;
            CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            ColumnHeadersHeight = 32;
            EnableHeadersVisualStyles = false;
            BackgroundColor = DarkTheme.Back;
            GridColor = DarkTheme.Line;
            RowTemplate.Height = 28;

            ColumnHeadersDefaultCellStyle.BackColor = DarkTheme.GridHeader;
            ColumnHeadersDefaultCellStyle.ForeColor = DarkTheme.Text;
            ColumnHeadersDefaultCellStyle.SelectionBackColor = DarkTheme.GridHeader;
            ColumnHeadersDefaultCellStyle.SelectionForeColor = DarkTheme.Text;
            ColumnHeadersDefaultCellStyle.Padding = new Padding(4, 0, 0, 0);

            DefaultCellStyle.BackColor = DarkTheme.GridRow;
            DefaultCellStyle.ForeColor = DarkTheme.Text;
            DefaultCellStyle.SelectionBackColor = DarkTheme.Selection;
            DefaultCellStyle.SelectionForeColor = Color.White;
            DefaultCellStyle.Padding = new Padding(4, 0, 4, 0);
            AlternatingRowsDefaultCellStyle.BackColor = DarkTheme.GridAltRow;
            ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;

            // 가로·세로 스크롤바는 그리드가 만들 때 같이 생기는 자식 컨트롤이다.
            foreach (Control child in Controls)
            {
                if (child is ScrollBar)
                {
                    child.HandleCreated += (s, e) => DarkTheme.DarkScrollBars((Control)s);
                }
            }
        }

        /// <summary>현재 선택한 행의 Tag. 없으면 null.</summary>
        public T SelectedTag<T>() where T : class
        {
            return CurrentRow?.Tag as T;
        }
    }
}
