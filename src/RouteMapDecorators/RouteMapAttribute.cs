using System;
using System.Web.Routing;

namespace RouteMapDecorators
{
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
	public class RouteMapAttribute : Attribute, IRouteMapAttribute
	{
		protected readonly string Constraints;
		protected readonly string Defaults;

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
		/// <param name = "constraints">A dictionary of key values formatted as: 'myParam=regex;otherParam=regex;</param>
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

			Defaults = defaults;
			Constraints = constraints;
		}


		#region IRouteMapAttribute Members

		public string Name { get; set; }

		public string Url { get; set; }

		public int Order { get; set; }

		public virtual RouteValueDictionary GetDefaults()
		{
			if (string.IsNullOrEmpty(Defaults))
			{
				return null;
			}

			return ParseStringToDefaultsRouteValueDictionary(Defaults);
		}

		public virtual RouteValueDictionary GetConstraints()
		{
			if (string.IsNullOrEmpty(Constraints))
			{
				return null;
			}

			return ParseStringToConstraintsRouteValueDictionary(Constraints);
		}

		#endregion


		protected virtual RouteValueDictionary ParseStringToDefaultsRouteValueDictionary(string valueString)
		{
			return RouteMapRegistry.ParseStringToRouteValueDictionary(valueString);
		}

		protected virtual RouteValueDictionary ParseStringToConstraintsRouteValueDictionary(string valueString)
		{
			return RouteMapRegistry.ParseStringToRouteValueDictionary(valueString);
		}
	}
}
