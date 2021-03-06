﻿using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using FabioSereno.App_awsDotNetCoreStringSortApi.Interfaces;
using FabioSereno.App_awsDotNetCoreStringSortApi.Models;

namespace FabioSereno.App_awsDotNetCoreStringSortApi.Utils
{
    public class StringSortUtil : IStringSortUtil
    {
        private readonly ILogger<StringSortUtil> _logger;

        public StringSortUtil(ILogger<StringSortUtil> logger)
        {
            _logger = logger;
        }

        /// <inheritdoc/>
        public string Sort(string commaSeperatedString)
        {
            _logger.LogInformation("Starting Sort process");

            var itemsToSort = GetSortItems(commaSeperatedString);
            Sort(itemsToSort);

            var result = Join(itemsToSort);

            _logger.LogInformation("Finished Sort process");

            return result;
        }

        /// <inheritdoc/>
        public List<SortItem> GetSortItems(string commaSeperatedString)
        {
            _logger.LogInformation("Started splitting items");

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

            _logger.LogInformation("Finished splitting items");

            return itemsToSort;
        }

        /// <inheritdoc/>
        public string Join(List<SortItem> sortedItems)
        {
            _logger.LogInformation("Started Join process of sorted items");

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

            _logger.LogInformation("Finished Join process of sorted items");

            return result;
        }

        /// <summary>
        /// Calls Sort on collection, passing in IComparer for sorting logic
        /// </summary>
        /// <param name="itemsToSort">List of SortItems to sort</param>
        private void Sort(List<SortItem> itemsToSort)
        {
            _logger.LogInformation("Sort the items");
            itemsToSort?.Sort(new SortItem.NaturalSorter());
        }
    }
}