namespace RealEstateBot
{
    using System.Linq;
    using Microsoft.Azure.Search.Models;
    using Search.Azure.Services;
    using Search.Models;

    public class RealEstateMapper : IMapper<DocumentSearchResult, GenericSearchResult>
    {
        public GenericSearchResult Map(DocumentSearchResult documentSearchResult)
        {
            var searchResult = new GenericSearchResult();

            searchResult.Results = documentSearchResult.Results.Select(r => ToSearchHit(r)).ToList();
            searchResult.Facets = documentSearchResult.Facets?.ToDictionary(kv => kv.Key, kv => kv.Value.Select(f => ToFacet(f)));

            return searchResult;
        }

        private static GenericFacet ToFacet(FacetResult facetResult)
        {
            return new GenericFacet
            {
                Value = facetResult.Value,
                Count = facetResult.Count.Value
            };
        }

        private static SearchHit ToSearchHit(SearchResult hit)
        {
            return new SearchHit
            {
                Brand = (string)hit.Document["Brand"],
                info = GetTitleForItem(hit),
                imageURL = (string)hit.Document["imageURL"],
                Description = (string)hit.Document["Description"]
            };
        }

        private static string GetTitleForItem(SearchResult result)
        {
            
            var price = result.Document["Price"];
            var varietal = result.Document["Varietal"];
            var region = result.Document["Region"];
            var vintage = result.Document["Vintage"];
            return $"a {vintage} {varietal} from {region} for {price}";
        }
    }
}
