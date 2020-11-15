using System;
using System.Collections.Generic;
using Interfaces;
using Models;

namespace Utils
{
    public class StringSortUtil : IStringSortUtil
    {
        /// <inheritdoc/>
        public string Sort(string commaSeperatedString)
        {
            var itemsToSort = GetSortItems(commaSeperatedString);
            Sort(itemsToSort);

            var result = Join(itemsToSort);
            return result;
        }

        /// <inheritdoc/>
        public List<SortItem> GetSortItems(string commaSeperatedString)
        {
            var itemsToSort = new List<SortItem>();
            if (String.IsNullOrEmpty(commaSeperatedString))
            {
                return itemsToSort;
            }

            var characterGroups = commaSeperatedString.Split(',');

            foreach (var characterGroup in characterGroups)
            {
               itemsToSort.Add( new SortItem() { Value = characterGroup.Trim() });
            }

            return itemsToSort;
        }

        /// <inheritdoc/>
        public string Join(List<SortItem> sortedItems)
        {
            var result = string.Empty;

            if (sortedItems == null || sortedItems?.Count == 0) {
                return result;
            }

            foreach (var item in sortedItems)
            {
                if (!String.IsNullOrEmpty(result))
                {
                    result = $"{result},{item.Value}";
                }
                else
                {
                    result = $"{item.Value}";
                }
            }
            return result;
        }

        /// <summary>
        /// Calls Sort on collection, passing in IComparer for sorting logic
        /// </summary>
        /// <param name="itemsToSort">List of SortItems to sort</param>
        private void Sort(List<SortItem> itemsToSort)
        {
            itemsToSort?.Sort(new SortItem.NaturalSorter());
        }
    }
}