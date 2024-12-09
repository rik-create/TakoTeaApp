// In TakoTea.Helpers project
using MaterialSkin.Controls;
using System.Collections.Generic;
using System.Windows.Forms;
namespace TakoTea.Helpers
{
    public static class CheckedListBoxHelper
    {
        public static IEnumerable<string> GetCheckedItemsFromIterator(CheckedListBox checkedListBox)
        {
            CheckedItemIterator iterator = new CheckedItemIterator(checkedListBox);
            while (iterator.HasNext())
            {
                yield return iterator.Next();
            }
        }
        public static void ClearAllCheckBoxes(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c is CheckBox checkBox)
                {
                    checkBox.Checked = false;
                }
                else if (c.HasChildren)
                {
                    ClearAllCheckBoxes(c); // Recursively clear checkboxes in child controls
                }
            }
        }
        public static void ClearAllCheckedListBoxesInPanel(Panel panel)
        {
            foreach (Control c in panel.Controls)
            {
                if (c is CheckedListBox checkedListBox)
                {
                    for (int i = 0; i < checkedListBox.Items.Count; i++)
                    {
                        checkedListBox.SetItemChecked(i, false);
                    }
                }
                else if (c.HasChildren)
                {
                    ClearAllCheckedListBoxesInPanel(c as Panel); // Recursively clear in child panels
                }
            }
        }
    }



    }

