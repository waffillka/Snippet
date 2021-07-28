namespace ServicesProviders.IPredicateBuilder
{
    protected internal interface IPredicateBuilder
    {
        ExpressionStarter<SnippetPost> BuildPredicate(FilterRequest filterRequest);
    }
}