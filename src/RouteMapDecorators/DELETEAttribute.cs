namespace RouteMapDecorators
{
	public class DELETEAttribute : RouteMapActionMethodSelectorAttribute
	{
		public DELETEAttribute(string url)
			: base(url)
		{
		}

		public DELETEAttribute(string url, string defaults, string constraints)
			: base(url, defaults, constraints)
		{
		}

		public DELETEAttribute(string name, string url)
			: base(name, url)
		{
		}

		public DELETEAttribute(string name, string url, string defaults, string constraints)
			: base(name, url, defaults, constraints)
		{
		}


		#region Overrides of RouteMapActionMethodSelectorAttribute

		protected override string GetActionHttpMethod()
		{
			return "DELETE";
		}

		#endregion
	}
}