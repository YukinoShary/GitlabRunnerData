using GitlabRunnerData.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace GitlabRunnerData
{
    public class OAuth
    {
        public const string client_id = "client_id";
        public const string secret = "secret";
        public const string redirect_uri = "https://yukinoshary.github.io";
        private static HttpClient client = new HttpClient();
        public static Dictionary<string, CurrentUser> currentUserList { get; set; } = new Dictionary<string, CurrentUser>();

        /// <summary>
        /// OAuthの流れ、gitlabからredirect戻されて、parameterに付けてるcodeでgitlabのaccess tokenをリクエストする
        /// </summary>
        /// <param name="uuid">userのsession</param>
        /// <param name="code">gitlabのredirect uriに付けているcode</param>
        /// <returns></returns>
        public async static Task GetAccessToken(string uuid, string code)
        {
            string baseUri = "https://git.dolylab.cc/oauth/token";
            string parameters = $"?client_id={client_id}&client_secret={secret}&code={code}&grant_type=authorization_code&redirect_uri={redirect_uri}";
            HttpResponseMessage message = await client.GetAsync(baseUri + parameters);
            message.EnsureSuccessStatusCode();
            string result = await message.Content.ReadAsStringAsync();
            var j = JObject.Parse(result);
            var current = currentUserList[uuid];
            current.access_token = j["access_token"]?.ToString();
            current.refresh_token = j["refresh_token"]?.ToString();
            current.expires_in = j["expires_in"]?.ToObject<int>();
            current.created_at = j["created_at"]?.ToObject<DateTime>();
            current.islogin = true;
            currentUserList[uuid] = current;
        }

        /// <summary>
        /// gitlabに保存したuserデータをアクセスする
        /// </summary>
        /// <param name="uuid">userのsession</param>
        /// <returns></returns>
        public async static Task GetUserDetail(string uuid)
        {
            string baseUri = "https://git.dolylab.cc/oauth/user";
            string parameter = $"?access_token={currentUserList[uuid].access_token}";
            HttpResponseMessage message = await client.GetAsync(baseUri + parameter);
            message.EnsureSuccessStatusCode();
            string result = await message.Content.ReadAsStringAsync();
            var j = JObject.Parse(result);
            var current = currentUserList[uuid];
            current.id = int.Parse(j["id"].ToString());
            current.email = j["email"]?.ToString();
            current.username = j["username"]?.ToString();
            current.name = j["name"]?.ToString();
            current.state = j["state"]?.ToString();
            current.avatar_url = j["avatar_url"]?.ToString();
            current.web_url = j["web_url"]?.ToString();
            current.is_admin = j["is_admin"]?.ToObject<bool>();
            current.bio = j["bio"]?.ToString();
            current.location = j["location"]?.ToString();
            current.public_email = j["public_email"]?.ToString();
            current.website_url = j["website_url"]?.ToString();
            current.organization = j["organization"]?.ToString();
            current.last_sign_in_at = j["last_sign_in_at"]?.ToObject<DateTime>();
            current.confirmed_at = j["confirmed_at"]?.ToObject<DateTime>();
            current.last_activity_on = j["last_activity_on"]?.ToString();
            current.projects_limit = int.Parse(j["projects_limit"].ToString());
            current.current_sign_in_at = j["current_sign_in_at"]?.ToObject<DateTime>();
            current.external = j["external"]?.ToObject<bool>();
            current.private_profile = j["private_profile"]?.ToObject<bool>();
            current.current_sign_in_ip = j["current_sign_in_ip"]?.ToString();
            current.last_sign_in_ip = j["last_sign_in_ip"]?.ToString();
            current.namespace_id = int.Parse(j["namespace_id"].ToString());
        }
    }
}
