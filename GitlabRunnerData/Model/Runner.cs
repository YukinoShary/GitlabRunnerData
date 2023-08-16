namespace GitlabRunnerData.Model
{
    public class Runner
    {
        public bool active { get; set; }
        public bool paused { get; set; }
        public string? description { get; set; }
        public int id { get; set; }
        public string? ip_address { get; set; }
        public bool is_shared { get; set; }
        public string? runner_type { get; set; }
        public string? name { get; set; }
        public bool online { get; set; }
        public string? status { get; set; }
    }
}
