namespace RouteMapDecorators
{
	public class POSTAttribute : RouteMapActionMethodSelectorAttribute
	{
		public POSTAttribute(string url)
			: base(url)
		{
		}

		public POSTAttribute(string url, string defaults, string constraints)
			: base(url, defaults, constraints)
		{
		}

		public POSTAttribute(string name, string url)
			: base(name, url)
		{
		}

		public POSTAttribute(string name, string url, string defaults, string constraints)
			: base(name, url, defaults, constraints)
		{
		}


		#region Overrides of RouteMapActionMethodSelectorAttribute

		protected override string GetActionHttpMethod()
		{
			return "POST";
		}

		#endregion
	}
}