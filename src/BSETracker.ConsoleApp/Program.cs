using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BSETracker.ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            const string url = "https://www.bseindia.com/corporates/ann.aspx?curpg=1&annflag=1&dt=&dur=A&dtto=&cat=&scrip=541154&anntype=C";
            HttpClient client = new HttpClient();
            Console.WriteLine(await client.GetStringAsync(url));
        }
    }
}
