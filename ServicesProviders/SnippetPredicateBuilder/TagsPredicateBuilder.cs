using System.Linq;
using Entities.Models;
using LinqKit;
using ServicesProviders.RequestModel;

namespace ServicesProviders.SnippetPredicateBuilder
{
    internal class TagsPredicateBuilder : IPredicateBuilder
    {
        private readonly IPredicateBuilder _wrappedBuilder;

        public TagsPredicateBuilder(IPredicateBuilder wrappedBuilder)
        {
            _wrappedBuilder = wrappedBuilder;
        }

        public ExpressionStarter<SnippetPost> BuildPredicate(FilterRequest filterRequest)
        {
            var predicate = PredicateBuilder.New<SnippetPost>().And(x => true);
            
            var expr = _wrappedBuilder.BuildPredicate(filterRequest);

            if (filterRequest.Tags != null)
            {
                expr.And(x => x.Tags.Any(item => filterRequest.Tags.Contains(item.Id)));
                
            }

            if (filterRequest.TagsExclude != null)
            {
                expr.And(x=> x.Tags.Any(item => !filterRequest.TagsExclude.Contains(item.Id)));
            }
            
            return expr;
        }
    }
}