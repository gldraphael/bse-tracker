using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BSETracker.Web.Models;
using Microsoft.AspNetCore.NodeServices;

namespace BSETracker.Web.Services
{
    public class BseClient
    {
        private readonly INodeServices _nodeServices;
        private readonly HttpClient _http;
        public BseClient(INodeServices nodeServices, HttpClient http) 
        {
            _nodeServices = nodeServices;
            _http = http;
        }

        public async Task<IEnumerable<Announcement>> GetAnnouncements()
        {
            const string url = "https://www.bseindia.com/corporates/ann.aspx?curpg=1&annflag=1&dt=&dur=A&dtto=&cat=&scrip=541154&anntype=C";
            var html = await _http.GetStringAsync(url);
            return await _nodeServices.InvokeAsync<Announcement[]>("./Node/getAnnouncements", html);
        }
    }
}