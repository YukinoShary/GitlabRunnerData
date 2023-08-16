using Microsoft.AspNetCore.Mvc;

namespace GitlabRunnerData
{
    public class RedirectController : Controller
    {
        [HttpGet("{code}")]
        public async Task CodeRead(string code)
        {
            //GitLabから戻すauthorization codeを処理
            string uuid = HttpContext.Session.GetString("UserSession");
            await OAuth.GetAccessToken(uuid, code);
            await OAuth.GetUserDetail(uuid);
        }
    }
}
