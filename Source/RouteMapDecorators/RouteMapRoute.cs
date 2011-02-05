using System.Web.Routing;

namespace RouteMapDecorators
{
	public class RouteMapRoute : Route
	{
		public RouteMapRoute(string url, IRouteHandler routeHandler)
			: base(url, routeHandler)
		{
		}

		public int Order { get; set; }

		public string Name { get; set; }
	}
}