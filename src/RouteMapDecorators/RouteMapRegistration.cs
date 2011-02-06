using System;
using System.Collections.Generic;
using System.Reflection;

namespace RouteMapDecorators
{
	public class RouteMapRegistration
	{
		internal readonly List<MethodInfo> Actions = new List<MethodInfo>();

		public void InAllControllersFromAssembly(Assembly assembly)
		{
			var controllerTypes = RouteMapRegistry.GetControllers(new[] { assembly });
			var actionsWithRouteMaps = RouteMapRegistry.GetActionsWithRouteMaps(controllerTypes);
			Actions.AddRange(actionsWithRouteMaps);
		}

		public void InControllers(IEnumerable<Type> controllerTypes)
		{
			var actionsWithRouteMaps = RouteMapRegistry.GetActionsWithRouteMaps(controllerTypes);
			Actions.AddRange(actionsWithRouteMaps);
		}

		public void InControllers(Type controllerType, params Type[] controllerTypes)
		{
			InControllers(new[] { controllerType });
			InControllers(controllerTypes);
		}
	}
}