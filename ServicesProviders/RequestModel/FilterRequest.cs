using System;
using System.Collections.Generic;

namespace ServicesProviders.RequestModel
{
    public class FilterRequest
    {
        public List<ulong>? Authors { get; set; }
        public List<ulong>? AuthorsExclude { get; set; }
        public List<ulong>? Tags { get; set; }
        public List<ulong>? TagsExclude { get; set; }
        public List<ulong>? Langs { get; set; }
        public List<ulong>? LangsExclude { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
    }
}