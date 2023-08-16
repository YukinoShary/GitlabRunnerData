using System;
namespace GitlabRunnerData.Model
{
    public class Job
    {
        public int id { get; set; }
        public string? ip_address { get; set; }
        public string? status { get; set; }
        public string? name { get; set; }
        public string? @ref {get; set;}
        public bool? tag { get; set; }
        public DateTime created_at { get; set; }
        public DateTime started_at { get; set; }
        public DateTime finished_at { get; set; }
        public float duration { get; set; }
        public string? web_url { get; set; }
        public User? user { get; set; }
        public Commit? commit { get; set; }
        public Pipeline? pipeline { get; set; }

        public Project? project { get; set; }
        public Runner? runner { get; set; }
    }
}
