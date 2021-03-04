using FPTCertification.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPTCertification.Business.Models
{
    // Create Certification
    public class RequestCreateCertification : Mapping<Certification>
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("short_description")]
        public string ShortDescription { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("skills")]
        public IList<ResponseSelectSkill> Skills { get; set; }

        [JsonProperty("img_url")]
        public string ImageUrl { get; set; }
    }

    // Update a Certification
    public class RequestUpdateCertification : Mapping<Certification>
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("short_description")]
        public string ShortDescription { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("activated")]
        public bool Activated { get; set; }

        [JsonProperty("skills")]
        public IList<ResponseSelectSkill> Skills { get; set; }
    }

    // Change Status
    public class RequestUpdateStatusCertification : Mapping<Certification>
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("activated")]
        public bool Activated { get; set; }
    }

    // Get Select Certification
    public class ResponseSelectCertification : Mapping<Certification>
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    // Get All Certification
    public class ResponseAllCertification : Mapping<Certification>
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("short_description")]
        public string ShortDescription { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("skills")]
        public List<ResponseSelectSkill> Skills { get; set; }
    }
}
