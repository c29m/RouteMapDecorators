RouteMapDecorators
==================
Register Asp.NET MVC routes explicitly through ActionFilter attributes.

Example
-------
	public class ProductController : Controller
	{
		[RouteMap("product/details/{id}")]
		public ActionResult Details(Guid id)
		{
			...
		}
	}
