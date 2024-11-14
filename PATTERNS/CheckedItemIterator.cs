using System.Collections;
using MaterialSkin.Controls;
using System.Windows.Forms;
using TakoTea.Interfaces;
using System;
using System.Collections.Generic;


namespace TakoTea.PATTERNS
{

    public class CheckedItemIterator : ICheckedItemIterator
    {
        private readonly MaterialCheckedListBox _checkedListBox;
        private int _currentIndex;

        public CheckedItemIterator(MaterialCheckedListBox checkedListBox)
        {
            _checkedListBox = checkedListBox;
            _currentIndex = -1; // Start before the first item
        }

        public bool HasNext()
        {
            // Find the next checked item
            for (int i = _currentIndex + 1; i < _checkedListBox.Items.Count; i++)
            {
                if (_checkedListBox.GetItemCheckState(i) == CheckState.Checked)
                {
                    _currentIndex = i;
                    return true;
                }
            }
            return false;
        }

        public string Next()
        {
            if (_currentIndex >= 0 && _currentIndex < _checkedListBox.Items.Count &&
                _checkedListBox.GetItemCheckState(_currentIndex) == CheckState.Checked)
            {
                return _checkedListBox.Items[_currentIndex].ToString();
            }
            throw new InvalidOperationException("No more checked items.");
        }

        private IEnumerable<string> GetCheckedItemsFromIterator(MaterialCheckedListBox checkedListBox)
        {
            var iterator = new CheckedItemIterator(checkedListBox);
            while (iterator.HasNext())
            {
                yield return iterator.Next();
            }
        }
    }

}
