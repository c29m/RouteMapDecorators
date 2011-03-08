using System.Web.Routing;

namespace RouteMapDecorators
{
	public interface IRouteMapAttribute
	{
		string Name { get; set; }

		string Url { get; set; }

		int Order { get; set; }

		RouteValueDictionary GetDefaults();

		RouteValueDictionary GetConstraints();
	}
}