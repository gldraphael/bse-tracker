namespace BSETracker.Web.Models
{
    public class Announcement
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string PDF { get; set; }

        override public string ToString() => Newtonsoft.Json.JsonConvert.SerializeObject(this);
    }
}
