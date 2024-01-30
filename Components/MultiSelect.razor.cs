using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SelectListDemo.Components
{
    public partial class MultiSelect : ComponentBase
    {
        [Parameter]
        public MultiSelectList SelectListDemo { get; set; } = default!;

        private bool selectAll = true;

        public void Reset()
        {
            selectAll = true;
            foreach (var item in SelectListDemo)
                item.Selected = true;
        }

        private string getSelectionDisplayClass()
        {
            const string displayClass = "select-multi";

            if (selectAll || SelectListDemo.Where(x => x.Selected).Count() <= 1)
                return ("");

            return displayClass;
        }

        private string SelectionDisplay()
        {
            if (!SelectListDemo.Any())
                return "";

            if (selectAll)
                return "הכל";

            var s = "";

            var selectedItems = SelectListDemo.Where(x => x.Selected);

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
            var currentItem = SelectListDemo.Single(x => x.Value == itemValue);
            currentItem.Selected = !currentItem.Selected;

            var countSelected = SelectListDemo.Where(x => x.Selected).Count();
            var countAll = SelectListDemo.Count();

            selectAll = countSelected == countAll;

            StateHasChanged();
        }

        private void toggleAll()
        {
            selectAll = !selectAll;

            if (selectAll)
                foreach (var item in SelectListDemo)
                    item.Selected = true;
            else
                foreach (var item in SelectListDemo)
                    item.Selected = false;

            StateHasChanged();
        }

    }
}
