using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SelectListDemo.Components
{
    public partial class MultiSelect : ComponentBase
    {
        [Parameter]
        public MultiSelectList SelectList { get; set; } = default!;

        private bool selectAll = false;
        private static List<string> currentSelection = new();

		protected override void OnParametersSet()
		{
			base.OnParametersSet();
            //prevent resetting the selection when the SelectList hasn't changed
            if (currentSelection.SequenceEqual(SelectList.Where(x => x.Selected).Select(x => x.Value)))
                return;
			Reset();
		}

        public void Reset()
        {
			selectAll = false;
            foreach (var item in SelectList)
                item.Selected = false;
        }

        private string getSelectionDisplayClass()
        {
            const string displayClass = "select-multi";

            if (selectAll || SelectList.Where(x => x.Selected).Count() <= 1)
                return ("");

            return displayClass;
        }

        private string SelectionDisplay()
        {
            if (!SelectList.Any())
                return "";

            if (selectAll)
                return "הכל";

            var s = "";

            var selectedItems = SelectList.Where(x => x.Selected);

            if (selectedItems.Count() > 0)
            {
                foreach (var item in selectedItems) { s += ", " + item.Text; }
                s = s.Substring(2);
            }
            else
                s = "יש לבחור לפחות פריט אחד מתוך הרשימה";

            return s;
        }

        private void toggleItem(string itemValue)
        {
            SaveCurrentSelection();
			var countSelected = currentSelection.Count();
            var countAll = SelectList.Count();

            selectAll = countSelected == countAll;
		}

		private void toggleAll()
        {
            if (selectAll)
                foreach (var item in SelectList)
                    item.Selected = true;
            else
                foreach (var item in SelectList)
                    item.Selected = false;
			SaveCurrentSelection();
		}

		private void SaveCurrentSelection()
        {
			currentSelection = SelectList.Where(x => x.Selected).Select(x => x.Value).ToList();
		}
    }
}
