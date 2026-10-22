using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TSWorkBench.Models;
using TSWorkBench.Storage;

namespace TSWorkBench.Forms
{
    /// <summary>콤보박스 채우기·선택 도우미.</summary>
    public static class UiHelpers
    {
        public static void FillChoices<T>(ComboBox combo, T selected) where T : struct, Enum
        {
            combo.Items.Clear();
            foreach (var choice in Labels.Choices<T>())
            {
                combo.Items.Add(choice);
                if (choice.Value.Equals(selected))
                {
                    combo.SelectedItem = choice;
                }
            }
        }

        public static T ChoiceValue<T>(ComboBox combo, T fallback) where T : struct, Enum
        {
            var choice = combo.SelectedItem as Choice<T>;
            return choice != null ? choice.Value : fallback;
        }

        /// <summary>자유 입력 콤보: 기준 정보 + 이미 쓴 값을 목록으로 넣고, 현재 값을 글자로 둔다.</summary>
        public static void FillNames(ComboBox combo, IEnumerable<string> names, string current)
        {
            combo.BeginUpdate();
            combo.Items.Clear();
            foreach (var name in names.Where(n => !string.IsNullOrWhiteSpace(n)).Select(n => n.Trim()).Distinct().OrderBy(n => n))
            {
                combo.Items.Add(name);
            }

            combo.EndUpdate();
            combo.Text = current ?? "";
        }

        public static IEnumerable<string> CustomerNames(Workspace ws)
        {
            return MasterData.Names(ws.Masters.Customers).Concat(ws.Items.All.Select(i => i.Customer));
        }

        public static IEnumerable<string> SiteNames(Workspace ws)
        {
            return MasterData.Names(ws.Masters.Sites).Concat(ws.Items.All.Select(i => i.Site));
        }

        public static IEnumerable<string> EquipmentNames(Workspace ws)
        {
            return MasterData.Names(ws.Masters.Equipments).Concat(ws.Items.All.Select(i => i.Equipment));
        }

        public static IEnumerable<string> ProgramNames(Workspace ws)
        {
            return ws.Programs.Select(p => p.Name).Concat(ws.Releases.All.Select(r => r.Program));
        }

        public static IEnumerable<string> SystemNames(Workspace ws)
        {
            return MasterData.Names(ws.Masters.Systems).Concat(ws.Items.All.Select(i => i.TargetSystem));
        }
    }
}
