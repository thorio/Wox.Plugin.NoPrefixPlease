using System.Collections.Generic;
using System.Diagnostics;
using System.Web;

namespace Wox.Plugin.NoPrefixPlease
{
	class Plugin : IPlugin
	{
		public void Init(PluginInitContext context)
		{
		}

		public List<Result> Query(Query query)
		{
			return new List<Result>() {
				new Result() {
					Action = context => Search(query.RawQuery),
					Title = query.RawQuery,
					Score = 0,
					IcoPath = "icon.png",
				}
			};
		}

		private bool Search(string query)
		{
			var url = Configuration.GetKey("SearchUrl")
				.Replace("{?}", HttpUtility.UrlEncode(query));
			Process.Start(url);

			return true;
		}
	}
}
