using Snippet.Common.Enums;

namespace Snippet.Common.Parameters
{
    public abstract class ParamsBase
    {
        public int Page { get; set; } = 0;
        public int PageSize { get; set; } = 20;
        public string OrderBy { get; set; } = string.Empty;
        public OrderDirection OrderDirection { get; set; }
    }
}