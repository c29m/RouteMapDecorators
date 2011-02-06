RouteMapDecorators
==================
Register Asp.NET MVC routes explicitly through ActionFilter attributes.

Example
-------

In your controllers:
	public class ProductController : Controller
	{
		[RouteMap("product/details/{id}")]
		public ActionResult Details(Guid id)
		{
			...
		}
	}

In your Global.asx.cs:
	public class MvcApplication : HttpApplication
	{
		static void RegisterRoutes(RouteCollection routes)
		{
			routes.MapRouteMaps(x => x.InAllControllersFromAssembly(typeof(ProductController).Assembly));
		}
		
		protected void Application_Start()
		{
			...
			
			RegisterRoutes(RouteTable.Routes);
		}
	}
