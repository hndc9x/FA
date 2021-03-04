using FPTCertification.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPTCertification.Business.Models
{
    public class RequestCreateExam : Mapping<Exam>
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("certification_id")]
        public int CertificationId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("short_description")]
        public string ShortDescription { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("img_url")]
        public string ImageUrl { get; set; }

    }
    public class ResponseOnLyExam : Mapping<Exam>
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("certification_id")]
        public int CertificationId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("short_description")]
        public string ShortDescription { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("img_url")]
        public string ImageUrl { get; set; }
    }
    public class RequestUpdateExam : Mapping<Exam>
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("certification_id")]
        public int CertificationId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("short_description")]
        public string ShortDescription { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("img_url")]
        public string ImageUrl { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

    }
}
