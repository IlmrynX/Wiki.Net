using System.Collections.Generic;

namespace Wiki.Net.Model
{
    public class Parse
    {
        public string title { get; set; }
        public int pageid { get; set; }
        public List<Section> sections { get; set; }
        public Text text { get; set; }
    }
}