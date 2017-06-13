namespace Search.Models
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public class SearchHit
    {
        public SearchHit()
        {
            this.PropertyBag = new Dictionary<string, object>();
        }

       // public string Key { get; set; }

        public string info { get; set; }

        public string Brand { get; set; }

        public string Price { get; set; }

        public string Rating { get; set; }

        public string Varietal { get; set; }

        public string Region { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public string Vintage { get; set; }

        public string Awards { get; set; }

        public string imageURL { get; set; }

        public string Description { get; set; }

        public IDictionary<string, object> PropertyBag { get; set; }
    }
}