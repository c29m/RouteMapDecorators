using System;
using System.Web.Routing;

namespace RouteMapDecorators
{
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
	public class RouteMapAttribute : Attribute
	{
		/// <summary>
		/// </summary>
		/// <param name = "url">The url pattern that invokes the action when matched.</param>
		public RouteMapAttribute(string url)
			: this(null, url, null, null)
		{
		}

		/// <summary>
		/// </summary>
		/// <param name = "url">The url pattern that invokes the action when matched.</param>
		/// <param name = "defaults">A dictionary of key values formatted as: 'myParam=defValue;otherParam=someValue;</param>
		/// <param name = "constraints">A dictionary of key values formatted as: 'myParam=[regex];otherParam=[regex];</param>
		public RouteMapAttribute(string url, string defaults, string constraints)
			: this(null, url, defaults, constraints)
		{
		}

		/// <summary>
		/// </summary>
		/// <param name = "name">The name of the route. Optional.</param>
		/// <param name = "url">The url pattern that invokes the action when matched.</param>
		public RouteMapAttribute(string name, string url)
			: this(name, url, null, null)
		{
		}

		/// <summary>
		/// </summary>
		/// <param name = "name">The name of the route. Optional.</param>
		/// <param name = "url">The url pattern that invokes the action when matched.</param>
		/// <param name = "defaults">A dictionary of key values formatted as: 'myParam=defValue;otherParam=someValue;'</param>
		/// <param name = "constraints">A dictionary of key values formatted as: 'myParam=regex;otherParam=regex;'</param>
		public RouteMapAttribute(string name, string url, string defaults, string constraints)
		{
			Name = name;
			Url = url;

			if (!string.IsNullOrEmpty(defaults))
			{
				Defaults = new RouteValueDictionary();
				ParseToRouteValueDictionary(defaults, Defaults);
			}

			if (!string.IsNullOrEmpty(constraints))
			{
				Constraints = new RouteValueDictionary();
				ParseToRouteValueDictionary(constraints, Constraints);
			}
		}

		public string Name { get; set; }

		public string Url { get; set; }

		public int Order { get; set; }

		public RouteValueDictionary Defaults { get; set; }

		public RouteValueDictionary Constraints { get; set; }

		private static void ParseToRouteValueDictionary(string valueString, RouteValueDictionary dictionary)
		{
			var defaultsPairs = valueString.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

			foreach (var defaultsPair in defaultsPairs)
			{
				var keyValue = defaultsPair.Split(new[] { '=' });
				dictionary[keyValue[0]] = keyValue[1];
			}
		}
	}
}