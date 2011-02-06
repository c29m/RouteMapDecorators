using System.Web.Routing;
using NUnit.Framework;

namespace RouteMapDecorators.Tests
{
	[TestFixture]
	public class IntegrationFixture
	{
		[Test]
		public void ShouldCreateRoutesMatchingRouteMapAttributes()
		{
			var routeCollection = new RouteCollection();
			routeCollection.MapRouteMaps(x => x.InControllers(typeof(TestingController)));

			Assert.That(routeCollection.Count, Is.EqualTo(3));

			var route2 = (RouteMapRoute) routeCollection[0];
			var route1 = (RouteMapRoute) routeCollection[1];
			var route3 = (RouteMapRoute) routeCollection[2];

			Assert.That(route1.Order, Is.EqualTo(0));
			Assert.That(route2.Order, Is.EqualTo(-10));
			Assert.That(route3.Order, Is.EqualTo(10));

			Assert.That(route1.Url, Is.EqualTo("me/thod1"));
			Assert.That(route2.Url, Is.EqualTo("me/thod2"));
			Assert.That(route3.Url, Is.EqualTo("me/thod3/{param1}"));

			Assert.That(route1.Defaults["controller"], Is.EqualTo("Testing"));
			Assert.That(route1.Defaults["action"], Is.EqualTo("Method1"));

			Assert.That(route2.Defaults["action"], Is.EqualTo("Method2"));

			Assert.That(route3.Defaults["action"], Is.EqualTo("Method3"));
			Assert.That(route3.Defaults["param1"], Is.EqualTo("value1"));
			Assert.That(route3.Constraints["param1"], Is.EqualTo("^[a-z0-9]*$"));
		}
	}
}