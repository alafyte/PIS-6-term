namespace ASPCMVC06.Constraints
{
    public class StringRouteContraint : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            values.TryGetValue("MResearch", out var mResearch);
            values.TryGetValue("string", out var stringVar);

            return (mResearch is not null && stringVar is not null) || (mResearch is null && stringVar is null);

        }
    }
}
