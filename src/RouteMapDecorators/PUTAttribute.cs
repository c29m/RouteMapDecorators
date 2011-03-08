namespace RouteMapDecorators
{
	public class PUTAttribute : RouteMapActionMethodSelectorAttribute
	{
		public PUTAttribute(string url)
			: base(url)
		{
		}

		public PUTAttribute(string url, string defaults, string constraints)
			: base(url, defaults, constraints)
		{
		}

		public PUTAttribute(string name, string url)
			: base(name, url)
		{
		}

		public PUTAttribute(string name, string url, string defaults, string constraints)
			: base(name, url, defaults, constraints)
		{
		}


		#region Overrides of RouteMapActionMethodSelectorAttribute

		protected override string GetActionHttpMethod()
		{
			return "PUT";
		}

		#endregion
	}
}