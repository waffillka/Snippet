namespace Snippet.Common.Parameters
{
    public class ParamsBase
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 20;

        public string SortOption { get; set; } = string.Empty;
    }
}