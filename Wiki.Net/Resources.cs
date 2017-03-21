namespace Wiki.Net
{
    public static class Resources
    {
        public static readonly string CrsfToken = "api.php?action=query&meta=tokens";

        public static readonly string Search = "api.php?action=query&list=search&srsearch={0}";

        public static readonly string ParseSection = "api.php?action=parse&prop={2}&page={0}&section={1}";

        public static readonly string Sections = "api.php?action=parse&prop=sections&page={0}";
    }
}