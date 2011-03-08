using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;

namespace RouteMapDecorators
{
	public static class RouteMapRegistry
	{
		public static void MapRouteMaps(this RouteCollection routes, Action<RouteMapRegistration> registrationExpression)
		{
			var registration = new RouteMapRegistration();
			registrationExpression.Invoke(registration);

			Map(routes, registration);
		}

		internal static void Map(RouteCollection routes, RouteMapRegistration registration)
		{
			var routeMapRoutes = new List<RouteMapRoute>();

			foreach (var action in registration.Actions)
			{
				var controllerType = action.DeclaringType;
				var controllerName = GetControllerName(controllerType);
				var actionName = GetActionName(action);

				var routeMapAttributes = GetCustomAttributes<RouteMapAttribute>(action, false);

				foreach (var routeMapAttribute in routeMapAttributes)
				{
					var routeMapRoute = new RouteMapRoute(routeMapAttribute.Url, new MvcRouteHandler())
					{
						Order = routeMapAttribute.Order,
						Defaults = routeMapAttribute.GetDefaults() ?? new RouteValueDictionary(),
						Constraints = routeMapAttribute.GetConstraints() ?? new RouteValueDictionary()
					};

					routeMapRoute.Defaults["controller"] = controllerName;
					routeMapRoute.Defaults["action"] = actionName;

					routeMapRoutes.Add(routeMapRoute);
				}
			}

			foreach (var routeMapRoute in routeMapRoutes.OrderBy(x => x.Order))
			{
				routes.Add(routeMapRoute.Name, routeMapRoute);
			}
		}

		internal static string GetActionName(MethodInfo action)
		{
			return action.Name;
		}

		internal static string GetControllerName(Type controller)
		{
			var controllerName = controller.Name;

			if (!controllerName.EndsWith("Controller"))
			{
				throw new Exception("The [" + controllerName + "] controller name must end with \"Controller\".");
			}

			controllerName = controllerName.Substring(0, controllerName.Length - "Controller".Length);

			return controllerName;
		}

		internal static IEnumerable<Type> GetControllers(IEnumerable<Assembly> assemblies)
		{
			return assemblies
				.SelectMany(assembly => assembly.GetExportedTypes())
				.Where(type => !type.IsAbstract)
				.Where(type => typeof(Controller).IsAssignableFrom(type))
				.ToList();
		}

		internal static IEnumerable<MethodInfo> GetActionsWithRouteMaps(IEnumerable<Type> controllerTypes)
		{
			return controllerTypes
				.SelectMany(type => type.GetMethods())
				.Where(m => GetCustomAttributes<RouteMapAttribute>(m, false).Count() > 0)
				.ToList();
		}

		internal static IEnumerable<TType> GetCustomAttributes<TType>(MethodInfo methodInfo, bool inherit)
		{
			return methodInfo.GetCustomAttributes(typeof(TType), inherit).Cast<TType>();
		}
	}
}