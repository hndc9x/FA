using FPTCertification.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPTCertification.Business.Models
{
    public class RequestCreateQuestion : Mapping<Question>
    {
        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("skill")]
        public int? SkillId { get; set; }

        [JsonProperty("answers")]
        public IList<RequestCreateAnswer> Answers { get; set; } 
    }

    public class RequestUpdateQuestion : Mapping<Question>
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("skill")]
        public int? SkillId { get; set; }

        [JsonProperty("answers")]
        public IList<RequestUpdateAnswer> Answers { get; set; }
    }
}
