namespace GitlabRunnerData;
using Model;
using Newtonsoft.Json;

public class RunnerRequest
{
    private HttpClient client = new HttpClient();
    private const string runnerToken = "request";

    /// <summary>
    /// このランナーが実行したジョブのリスト
    /// </summary>
    /// <param name="runnerId"></param>
    /// <returns></returns>
    public async Task<List<Job>?> GetJobsList(int runnerId)
    {
        if(!client.DefaultRequestHeaders.Contains("PRIVATE-TOKEN"))
            client.DefaultRequestHeaders.Add("PRIVATE-TOKEN", runnerToken);
        HttpResponseMessage message = await client.GetAsync("https://git.dolylab.cc/api/v4/runners/" + runnerId + "/jobs");
        message.EnsureSuccessStatusCode();
        string result = await message.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<Job>>(result);
    }

    /// <summary>
    /// このgitlabサーバに登録したランナーのリスト
    /// </summary>
    /// <returns></returns>
    public async Task<List<Runner>?> GetRunnerList()
    {
        if (!client.DefaultRequestHeaders.Contains("PRIVATE-TOKEN"))
            client.DefaultRequestHeaders.Add("PRIVATE-TOKEN", runnerToken);
        HttpResponseMessage message = await client.GetAsync("https://git.dolylab.cc/api/v4/runners/all");
        message.EnsureSuccessStatusCode();
        string result = await message.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<Runner>>(result);
    }
}
