using FPTCertification.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPTCertification.Business.Models
{
    // Create
    public class RequestCreateClasses : Mapping<Classes>
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("short_description")]
        public string ShortDescription { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("activated")]
        public bool Activated { get; set; }
    }

    //Update
    public class RequesteUpdateClasses : Mapping<Classes>
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("short_description")]
        public string ShortDescription { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("activated")]
        public bool Activated{ get; set; }
    }

    // Update Status Classes
    public class RequestUpdateStatusClass : Mapping<Classes>
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("activated")]
        public bool Activated { get; set; }
    }

    //Get Only
    public class ReponseGetOnlyClasses : Mapping<Classes>
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("short_description")]
        public string ShortDescription { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("activated")]
        public bool Activated { get; set; }
    }
    //Get All
    public class ReponseGetAllClasses : Mapping<Classes>
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("short_description")]
        public string ShortDescription { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("activated")]
        public bool Activated { get; set; }

        [JsonProperty("member")]
        public List<ResponseSelectMember> Member { get; set; }
    }
    
    //Get Select Classes
    public class ReponseSelectClasses : Mapping<Classes>
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
