using GitlabRunnerData.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GitlabRunnerData.Pages
{
    public class ShowJobsModel : PageModel
    {
        public List<Job> jobDetail { get; set; } = new List<Job>();

        /// <summary>
        /// ShowJobsのページがGET方法でリクエストされる時に呼び出す
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnGetAsync()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserSession")))
            {
                //初めて登録するユーザにuuidを付けてsessionに記録する
                string uuid = Guid.NewGuid().ToString();
                CurrentUser lu = new CurrentUser();
                lu.islogin = false;
                OAuth.currentUserList[uuid] = lu;
                HttpContext.Session.SetString("UserSession", uuid);
            }
            if (OAuth.currentUserList[(HttpContext.Session.GetString("UserSession"))].islogin)
            {
                //ログインしたユーザにランナーのジョブデータを展示する
                jobDetail = await GetAllJobs();
                return Page();
            }
            else
            {
                //ログインしていないユーザをGitLabのログインページにredirectする
                string redirectUri = "https://git.dolylab.cc/oauth/authorize?client_id=" 
                    + OAuth.client_id +
                    "&redirect_uri=" +
                    OAuth.redirect_uri +
                    "&response_type=code&state=STATE&scope=read_user";
                return Redirect(redirectUri);
            }
        }

        /// <summary>
        /// Runnerから全てのジョブの情報を取得する
        /// </summary>
        /// <returns></returns>
        public async Task<List<Job>> GetAllJobs()
        {
            RunnerRequest rr = new RunnerRequest();
            List<Job>? jobs = new List<Job>();
            jobs.AddRange(await rr.GetJobsList(1));
            Console.WriteLine(jobs.Last().started_at);
            List<Runner> runner = await rr.GetRunnerList();
            if (runner != null)
            {
                for (int i = 1; i < 3; i++)
                {
                    jobs.AddRange(await rr.GetJobsList(i));
                    foreach(var j in jobs)
                    {
                        j.runner = runner[i];
                    }
                }
                return jobs;
            }
            else
                return null;
        }

        
    }
}
