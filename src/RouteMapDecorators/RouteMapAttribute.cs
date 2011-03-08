using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace RouteMapDecorators
{
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
	public class RouteMapAttribute : Attribute
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

		public string Name { get; set; }

		public string Url { get; set; }

		public int Order { get; set; }

		public virtual RouteValueDictionary GetDefaults()
		{
			if (string.IsNullOrEmpty(Defaults))
			{
				return null;
			}

			var defaults = new RouteValueDictionary();
			ParseStringToDefaultsRouteValueDictionary(Defaults, defaults);

			return defaults;
		}

		public virtual RouteValueDictionary GetConstraints()
		{
			if (string.IsNullOrEmpty(Constraints))
			{
				return null;
			}

			var constraints = new RouteValueDictionary();
			ParseStringToConstraintsRouteValueDictionary(Constraints, constraints);

			return constraints;
		}

		protected virtual void ParseStringToDefaultsRouteValueDictionary(string valueString, RouteValueDictionary dictionary)
		{
			ParseStringToRouteValueDictionary(valueString, dictionary);
		}

		protected virtual void ParseStringToConstraintsRouteValueDictionary(string valueString, RouteValueDictionary dictionary)
		{
			ParseStringToRouteValueDictionary(valueString, dictionary);
		}

		protected void ParseStringToRouteValueDictionary(string valueString, RouteValueDictionary dictionary)
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
