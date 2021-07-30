// using Entities.Models;
// using LinqKit;
// using ServicesProviders.RequestModel;
//
// namespace ServicesProviders.SnippetPredicateBuilder
// {
//     internal class AuthorPredicateBuilder : IPredicateBuilder
//     {
//         private IPredicateBuilder _wrappedBuilder;
//
//         public AuthorPredicateBuilder(IPredicateBuilder wrappedBuilder)
//         {
//             _wrappedBuilder = wrappedBuilder;
//         }
//         public ExpressionStarter<SnippetPost> BuildPredicate(FilterRequest filterRequest)
//         {
//             var predicate = PredicateBuilder.New<SnippetPost>().And(x => true);
//
//             //what if it's null?
//             if (filterRequest.Authors != null)
//             {
//                 predicate.And(x => filterRequest.Authors.Contains(x.Id));
//             }
//
//             if (filterRequest.AuthorsExclude != null)
//             {
//                 predicate.And(x => !filterRequest.AuthorsExclude.Contains(x.Id));
//             }
//             
//             return _wrappedBuilder.BuildPredicate(filterRequest).And(predicate);
//         }
//     }
// }