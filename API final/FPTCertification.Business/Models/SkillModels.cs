using FPTCertification.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPTCertification.Business.Models
{
    // Create
    public class RequestCreateSkill : Mapping<Skill>
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("short_description")]
        public string ShortDescription { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    // Update
    public class RequestUpdateSkill : Mapping<Skill>
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("short_description")]
        public string ShortDescription { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("activated")]
        public bool Activated { get; set; }
    }

    // Update Status
    public class RequestUpdateStatusSkill : Mapping<Skill>
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("activated")]
        public bool Activated { get; set; }
    }

    // Get select
    // api/Skills/select
    public class ResponseSelectSkill : Mapping<Skill>
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    // Get only
    // api/Skills/only
    public class ResponseOnlySkill : Mapping<Skill>
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("short_description")]
        public string ShortDescription { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("activated")]
        public bool Activated { get; set; }
    }

    // Get all
    // api/Skills/all
    public class ResponseAllSkill : Mapping<Skill>
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("short_description")]
        public string ShortDescription { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("certifications")]
        public List<ResponseSelectCertification> Certifications { get; set; }
    }
}
