using System;
using System.Collections.Generic;

namespace Business.Dto.Search
{
    public class SearchResultDto
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
    public class FacetsData
    {
        public string field { get; set; }
        public string label { get; set; }
        public string type { get; set; }
        public bool collapse { get; set; }
        public bool facet_active { get; set; }
        public List<FacetsValue> values { get; set; }
    }
    public class FacetsValue
    {
        public bool active { get; set; }
        public string label { get; set; }
        public string type { get; set; }
        public string value { get; set; }
        public int count { get; set; }
    }
    public class Facets
    {
        public string CoffeeProcessing { get; set; }
    }

    public class Price
    {
        public double MinPrice { get; set; }
        public double MaxPrice { get; set; }
    }

    public class Filter
    {
        public string SearchText { get; set; }
        public string Category { get; set; }
        public Facets facets { get; set; }
        public Price price { get; set; }
    }
}
