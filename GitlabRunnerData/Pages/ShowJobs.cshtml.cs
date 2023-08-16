using GitlabRunnerData.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GitlabRunnerData.Pages
{
    public class ShowJobsModel : PageModel
    {
        public List<Job> jobDetail { get; set; } = new List<Job>();

        /// <summary>
        /// ShowJobs�̃y�[�W��GET���@�Ń��N�G�X�g����鎞�ɌĂяo��
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnGetAsync()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserSession")))
            {
                //���߂ēo�^���郆�[�U��uuid��t����session�ɋL�^����
                string uuid = Guid.NewGuid().ToString();
                CurrentUser lu = new CurrentUser();
                lu.islogin = false;
                OAuth.currentUserList[uuid] = lu;
                HttpContext.Session.SetString("UserSession", uuid);
            }
            if (OAuth.currentUserList[(HttpContext.Session.GetString("UserSession"))].islogin)
            {
                //���O�C���������[�U�Ƀ����i�[�̃W���u�f�[�^��W������
                jobDetail = await GetAllJobs();
                return Page();
            }
            else
            {
                //���O�C�����Ă��Ȃ����[�U��GitLab�̃��O�C���y�[�W��redirect����
                string redirectUri = "https://git.dolylab.cc/oauth/authorize?client_id=" 
                    + OAuth.client_id +
                    "&redirect_uri=" +
                    OAuth.redirect_uri +
                    "&response_type=code&state=STATE&scope=read_user";
                return Redirect(redirectUri);
            }
        }

        /// <summary>
        /// Runner����S�ẴW���u�̏����擾����
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
