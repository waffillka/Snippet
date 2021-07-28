using Entities.Models;
using LinqKit;
using ServicesProviders.RequestModel;

namespace ServicesProviders.SnippetPredicateBuilder
{
    internal class DatePredicateBuilder : IPredicateBuilder
    {
        private readonly IPredicateBuilder _wrappedBuilder;
        public DatePredicateBuilder(IPredicateBuilder wrappedBuilder)
        {
            _wrappedBuilder = wrappedBuilder;
        }

        public ExpressionStarter<SnippetPost> BuildPredicate(FilterRequest filterRequest)
        {
            var predicate = PredicateBuilder.New<SnippetPost>().And(snippet => true);
            
            if(filterRequest.Date != null)
            {
                predicate.And(snippet => snippet.Date.CompareTo(filterRequest.Date) == 0);
            }
            else if(filterRequest.To != null && filterRequest.From != null)
            {
                predicate.And(snippet => snippet.Date.CompareTo(filterRequest.From) > 0 && snippet.Date.CompareTo(filterRequest.To) < 0);
            }

            return _wrappedBuilder.BuildPredicate(filterRequest).And(predicate);
        }

    }
}