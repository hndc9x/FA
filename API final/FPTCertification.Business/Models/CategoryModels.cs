using FPTCertification.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPTCertification.Business.Models
{
    public class RequestCreateCategory : Mapping<Category>
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("short_description")]
        public string ShortDescription { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public class RequestUpdateCategory : Mapping<Category>
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

        [JsonProperty("url_slug")]
        public string UrlSlug { get; set; }
    }

    public class ResponseOnlyCategory : Mapping<Category>
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
}
