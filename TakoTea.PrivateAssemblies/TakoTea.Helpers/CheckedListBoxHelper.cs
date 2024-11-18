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
    }



    }

