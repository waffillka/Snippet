// using Entities.Models;
// using LinqKit;
// using ServicesProviders.RequestModel;
//
// namespace ServicesProviders.SnippetPredicateBuilder
// {
//     internal class LangsPredicateBuilder : IPredicateBuilder
//     {
//         private readonly IPredicateBuilder _wrappedBuilder;
//         public LangsPredicateBuilder(IPredicateBuilder wrappedBuilder)
//         {
//             _wrappedBuilder = wrappedBuilder;
//         }
//
//         public ExpressionStarter<SnippetPost> BuildPredicate(FilterRequest filterRequest)
//         {
//             var predicate = PredicateBuilder.New<SnippetPost>().And(snippet => true);
//             
//             if(filterRequest.Langs != null)
//             {
//                 predicate.And(snippet => filterRequest.Langs.Contains(snippet.Id));
//             }
//             if(filterRequest.LangsExclude != null)
//             {
//                 predicate.And(snippet => !filterRequest.LangsExclude.Contains(snippet.Id));
//             }
//
//             return _wrappedBuilder.BuildPredicate(filterRequest).And(predicate);
//         }
//
//     }
// }