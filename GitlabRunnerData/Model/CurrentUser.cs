using System.Security.Principal;

namespace GitlabRunnerData.Model
{
    public class CurrentUser
    {
        public string? access_token { get; set; }
        public string? refresh_token { get; set; }
        public int? expires_in { get; set; }
        public DateTime? created_at { get; set; }
        public int id { get; set; }
        public string? username { get; set; }
        public string? email { get; set; }
        public string? name { get; set; }
        public string? state { get; set; }
        public string? avatar_url { get; set; }
        public string? web_url { get; set; }
        public bool? is_admin { get; set; }
        public string? bio { get; set; }
        public string? location { get; set; }
        public string? public_email { get; set; }
        public string? website_url { get; set; }
        public string? organization { get; set; }
        public DateTime? last_sign_in_at { get; set; }
        public DateTime? confirmed_at { get; set; }
        public string? last_activity_on { get; set; }
        public int? projects_limit { get; set; }
        public DateTime? current_sign_in_at { get; set; }
        public bool? external { get; set; }
        public bool? private_profile { get; set; }
        public string? current_sign_in_ip { get; set; }
        public string? last_sign_in_ip { get; set; }
        public int? namespace_id { get; set; }
        public bool islogin { get; set; }
    }
}
