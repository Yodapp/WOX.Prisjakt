using System;
using System.Collections.Generic;
using System.Diagnostics;
using Wox.Plugin;

namespace WOX.Prisjakt
{
    public class Main : IPlugin
    {
        private static string prisjaktQueryUrl = "https://www.prisjakt.nu/#rparams=ss=";

        public void Init(PluginInitContext context)
        {
            
        }

        public List<Result> Query(Query query)
        {
            var product = query.Search;

            var result = new Result
            {
                Title = "Search on Prisjakt...",
                IcoPath = "Images\\prisjakt.png",
                SubTitle = string.Format("Keyword: {0}", product),
                Action = (Func<ActionContext, bool>)(c =>
                {
                    SearchPrisjakt(product);
                    return true;
                })
            };

            return new List<Result> { result };
        }

        public void SearchPrisjakt(string query)
        {
            Process.Start(string.Format("{0}{1}", prisjaktQueryUrl, Uri.EscapeDataString(query)));
        }
    }
}
