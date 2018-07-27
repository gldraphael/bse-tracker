using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.NodeServices;
using Microsoft.AspNetCore.NodeServices.HostingModels;
using Microsoft.Extensions.DependencyInjection;

namespace BSETracker.ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            const string url = "https://www.bseindia.com/corporates/ann.aspx?curpg=1&annflag=1&dt=&dur=A&dtto=&cat=&scrip=541154&anntype=C";
            HttpClient client = new HttpClient();
            var html = await client.GetStringAsync(url);

            var services = new ServiceCollection();
            services.AddLogging()
                    .AddNodeServices();
            using(var serviceProvider = services.BuildServiceProvider())
            {
                var nodeServices = serviceProvider.GetRequiredService<INodeServices>();

                try
                {
                    var result = await nodeServices.InvokeAsync<Announcement[]>("./getAnnouncements", html);
                    foreach(var s in result) 
                    {
                        Console.WriteLine(s);
                    }
                }
                catch(NodeInvocationException e) 
                {
                    Console.Error.WriteLine(e.StackTrace);
                }
            }
            
        }
    }

    class Announcement
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string PDF { get; set; }

        override public string ToString() => Newtonsoft.Json.JsonConvert.SerializeObject(this);
    }
}
