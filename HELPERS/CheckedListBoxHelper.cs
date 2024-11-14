using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakoTea.PATTERNS;

namespace TakoTea.HELPERS
{
    public static class CheckedListBoxHelper
    {
        // This method uses the Iterator to get all checked items from the MaterialCheckedListBox.
        public static IEnumerable<string> GetCheckedItemsFromIterator(MaterialCheckedListBox checkedListBox)
        {
            var iterator = new CheckedItemIterator(checkedListBox);
            while (iterator.HasNext())
            {
                yield return iterator.Next();
            }
        }
    }
}
