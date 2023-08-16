namespace GitlabRunnerData.Model
{
    public class Project
    {
        public int id { get; set; }
        public string? description { get; set; }
        public string? name { get; set; }
        public string? name_with_namespace { get; set; }
        public string? path { get; set; }
        public string? path_with_namespace { get; set; }
        public DateTime created_at { get; set; }
    }
}
