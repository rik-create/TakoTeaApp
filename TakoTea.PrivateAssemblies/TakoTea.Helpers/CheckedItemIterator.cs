using MaterialSkin.Controls;
using System;
using System.Windows.Forms;
using TakoTea.Interfaces;
namespace TakoTea.Helpers
{
    public class CheckedItemIterator : ICheckedItemIterator
    {
        private readonly CheckedListBox _checkedListBox;
        private int _currentIndex;
        public CheckedItemIterator(CheckedListBox checkedListBox)
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
            return _currentIndex >= 0 && _currentIndex < _checkedListBox.Items.Count &&
                _checkedListBox.GetItemCheckState(_currentIndex) == CheckState.Checked
                ? _checkedListBox.Items[_currentIndex].ToString()
                : throw new InvalidOperationException("No more checked items.");
        }
    }
}
