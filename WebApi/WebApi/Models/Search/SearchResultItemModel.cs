using System;
using CMS.Helpers;
using CMS.Search;

namespace WebApi.Models
{
    public class SearchResultItemModel
    {
        //
        // Summary:
        //     Gets or sets the image of a result item.
        public string Image { get; set; }
        //
        // Summary:
        //     Gets the date associated with search item. Contains data from the field configured
        //     as 'Date field' in search index configuration. If no date information found,
        //     contains System.DateTime.MinValue.
        public DateTime Date { get; set; }
        //
        // Summary:
        //     Gets the content of the search item. Contains data from the field configured
        //     as 'Content field' in search index configuration.
        public string Content { get; set; }
        //
        // Summary:
        //     Gets the title of the search item. Contains data from the field configured as
        //     'Title field' in search index configuration.
        public string Title { get; set; }
        //
        // Summary:
        //     Gets or sets the score of a result item.
        public double Price { get; set; }
        //
        // Summary:
        //     Gets or sets the ObjectType of a result item.
        public string Type { get; set; }
    }
}