namespace RouteMapDecorators
{
	public class GETAttribute : RouteMapActionMethodSelectorAttribute
	{
		public GETAttribute(string url) : base(url)
		{
		}

		public GETAttribute(string url, string defaults, string constraints) : base(url, defaults, constraints)
		{
		}

		public GETAttribute(string name, string url) : base(name, url)
		{
		}

		public GETAttribute(string name, string url, string defaults, string constraints) : base(name, url, defaults, constraints)
		{
		}


		#region Overrides of RouteMapActionMethodSelectorAttribute

		protected override string GetActionHttpMethod()
		{
			return "GET";
		}

		#endregion
	}
}