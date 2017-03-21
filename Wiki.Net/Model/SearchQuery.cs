using System.Collections.Generic;

namespace Wiki.Net.Model
{
    public class SearchQuery
    {
        public Searchinfo searchinfo { get; set; }
        public List<Search> search { get; set; }
    }
}