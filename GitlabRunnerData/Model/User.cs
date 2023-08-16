namespace GitlabRunnerData.Model
{
    public class User
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? username { get; set; }
        public string? state { get; set; }
        public string? avatar_url { get; set; }
        public string? web_url { get; set; }
        public DateTime created_at { get; set; }
        public string? bio { get; set; }
        public string? location { get; set; }
        public string? public_email { get; set; }
        public string? skype { get; set; }
        public string? linkedin { get; set; }
        public string? twitter { get; set; }
        public string? website_url { get; set; }
        public string? organization { get; set; }
    }
}
