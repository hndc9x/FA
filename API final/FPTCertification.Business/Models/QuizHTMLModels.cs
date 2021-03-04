using FPTCertification.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPTCertification.Business.Models
{
    public class RequestCreateQuizHTML : Mapping<QuizHTML>
    {
        [JsonProperty("name")]
        public string Ten { get; set; }

        [JsonProperty("dapan1")]
        public string DapAn1 { get; set; }

        [JsonProperty("dapan2")]
        public string DapAn2 { get; set; }
        [JsonProperty("dapan3")]
        public string DapAn3 { get; set; }

        [JsonProperty("dapan4")]
        public string DapAn4 { get; set; }
    }

    // Update
    public class RequestUpdateQuizHTML : Mapping<QuizHTML>
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Ten { get; set; }

        [JsonProperty("dapan1")]
        public string DapAn1 { get; set; }

        [JsonProperty("dapan2")]
        public string DapAn2 { get; set; }
        [JsonProperty("dapan3")]
        public string DapAn3 { get; set; }

        [JsonProperty("dapan4")]
        public string DapAn4 { get; set; }
    }

    // Get select
    // api/Skills/select
    public class ResponseSelectQuizHTML : Mapping<QuizHTML>
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    // Get only
    // api/Skills/only
    public class ResponseOnlyQuizHTML : Mapping<QuizHTML>
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Ten { get; set; }

        [JsonProperty("dapan1")]
        public string DapAn1 { get; set; }

        [JsonProperty("dapan2")]
        public string DapAn2 { get; set; }
        [JsonProperty("dapan3")]
        public string DapAn3 { get; set; }

        [JsonProperty("dapan4")]
        public string DapAn4 { get; set; }
    }

    // Get all
    // api/Skills/all
    public class ResponseAllQuizHTML : Mapping<QuizHTML>
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Ten { get; set; }

        [JsonProperty("dapan1")]
        public string DapAn1 { get; set; }

        [JsonProperty("dapan2")]
        public string DapAn2 { get; set; }
        [JsonProperty("dapan3")]
        public string DapAn3 { get; set; }

        [JsonProperty("dapan4")]
        public string DapAn4 { get; set; }
    }
}
