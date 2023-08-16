namespace GitlabRunnerData.Model
{
    public class Pipeline
    {
        public int id { get; set; }
        public int iid { get; set; }
        public int project_id { get; set; }
        public string? sha { get; set; }
        public string? @ref { get; set; }
        public string? status { get; set; }
        public string? source { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get;set; }
        public string? web_url { get; set; }
    }
}
