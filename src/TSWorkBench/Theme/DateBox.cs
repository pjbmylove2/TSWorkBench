using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace TSWorkBench.Theme
{
    /// <summary>
    /// 어두운 날짜 입력칸. DateTimePicker는 다크 색을 받지 않아서 직접 만든다.
    /// 빈칸 = 값 없음(null). "▾"로 달력을 열고, 직접 2026-10-22 14:30처럼 입력해도 된다.
    /// </summary>
    [DefaultEvent("ValueChanged")]
    public class DateBox : UserControl
    {
        private readonly TextBox text;
        private readonly Button drop;
        private DateTime? value;
        private bool showTime;

        public DateBox()
        {
            text = new TextBox
            {
                BorderStyle = BorderStyle.None,
                BackColor = DarkTheme.Input,
                ForeColor = DarkTheme.Text,
                Dock = DockStyle.Fill
            };
            drop = new Button
            {
                Text = "▾",
                Dock = DockStyle.Right,
                Width = 24,
                FlatStyle = FlatStyle.Flat,
                BackColor = DarkTheme.Button,
                ForeColor = DarkTheme.Text,
                TabStop = false,
                Cursor = Cursors.Hand
            };
            drop.FlatAppearance.BorderSize = 0;

            var holder = new Panel { Dock = DockStyle.Fill, Padding = new Padding(6, 4, 2, 0), BackColor = DarkTheme.Input };
            holder.Controls.Add(text);
            Controls.Add(holder);
            Controls.Add(drop);

            BackColor = DarkTheme.Input;
            Size = new Size(140, 25);
            text.Leave += (s, e) => CommitText();
            text.KeyDown += OnTextKeyDown;
            drop.Click += (s, e) => ShowCalendar();
        }

        public event EventHandler ValueChanged;

        [DefaultValue(false)]
        public bool ShowTime
        {
            get { return showTime; }
            set
            {
                showTime = value;
                ShowValue();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime? Value
        {
            get { return value; }
            set
            {
                var changed = this.value != value;
                this.value = value;
                ShowValue();
                if (changed)
                {
                    ValueChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        private string Format => showTime ? "yyyy-MM-dd HH:mm" : "yyyy-MM-dd";

        private void ShowValue()
        {
            text.Text = value.HasValue ? value.Value.ToString(Format, CultureInfo.InvariantCulture) : "";
            text.ForeColor = DarkTheme.Text;
        }

        private void OnTextKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CommitText();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.F4 || (e.Alt && e.KeyCode == Keys.Down))
            {
                ShowCalendar();
            }
        }

        private void CommitText()
        {
            var raw = text.Text.Trim();
            if (raw.Length == 0)
            {
                Value = null;
                return;
            }

            DateTime parsed;
            if (DateTime.TryParse(raw, CultureInfo.GetCultureInfo("ko-KR"), DateTimeStyles.AllowWhiteSpaces, out parsed))
            {
                Value = showTime ? parsed : parsed.Date;
            }
            else
            {
                text.ForeColor = DarkTheme.Danger;
            }
        }

        private void ShowCalendar()
        {
            var calendar = new MonthCalendar { MaxSelectionCount = 1, ShowToday = true };
            if (value.HasValue)
            {
                calendar.SetDate(value.Value);
            }

            var host = new ToolStripControlHost(calendar) { Margin = Padding.Empty, Padding = Padding.Empty };
            var popup = new ToolStripDropDown { Padding = Padding.Empty };
            popup.Items.Add(host);
            calendar.DateSelected += (s, e) =>
            {
                var time = value.HasValue && showTime ? value.Value.TimeOfDay : (showTime ? DateTime.Now.TimeOfDay : TimeSpan.Zero);
                Value = e.Start.Date + new TimeSpan(time.Hours, time.Minutes, 0);
                popup.Close();
            };
            popup.Closed += (s, e) => BeginInvoke(new Action(popup.Dispose));
            popup.Show(this, new Point(0, Height));
        }
    }
}
