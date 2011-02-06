using System.Web.Mvc;

namespace RouteMapDecorators.Tests
{
	public class TestingController : Controller
	{
		[RouteMap("me/thod1")]
		public ActionResult Method1()
		{
			return null;
		}

		[RouteMap("me/thod2", Order = -10)]
		public ActionResult Method2()
		{
			return null;
		}

		[RouteMap("me/thod3/{param1}", "param1=value1", "param1=^[a-z0-9]*$", Order = 10)]
		public ActionResult Method3()
		{
			return null;
		}

		public ActionResult Method4()
		{
			return null;
		}
	}
}