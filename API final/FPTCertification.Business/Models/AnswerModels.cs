using FPTCertification.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPTCertification.Business.Models
{
    public class RequestCreateAnswer : Mapping<Answer>
    {
        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("question_id")]
        public int QuestionId { get; set; }

        [JsonProperty("position")]
        public int Position { get; set; }

        [JsonProperty("true_answer")]
        public bool TrueAnswer { get; set; }
    }

    public class RequestUpdateAnswer : Mapping<Answer>
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("question_id")]
        public int QuestionId { get; set; }

        [JsonProperty("position")]
        public int Position { get; set; }

        [JsonProperty("true_answer")]
        public bool TrueAnswer { get; set; }
    }

    public class ResponseSelectAnswer : Mapping<Answer>
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("true_answer")]
        public bool TrueAnswer { get; set; }
    }
}
