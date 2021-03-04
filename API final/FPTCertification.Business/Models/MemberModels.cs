using FPTCertification.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPTCertification.Business.Models
{
    // Create
    public class RequestCreateMember : Mapping<Member>
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("fullname")]
        public string FullName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("birthday")]
        public DateTime Birthday { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("class")]
        public int ClassId { get; set; }
    }

    // Update 
    public class AdminRequestUpdateMember : Mapping<Member>
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("class")]
        public int ClassId { get; set; }

        [JsonProperty("activated")]
        public bool Activated { get; set; }
    }

    // List All Member 
    public class ResponseAllMember : Mapping<Member>
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("fullname")]
        public string FullName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("birthday")]
        public DateTime Birthday { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("class")]
        public int ClassId { get; set; }

        [JsonProperty("activated")]
        public bool Activated { get; set; }
    }

    //List Select Member 
    public class ResponseSelectMember : Mapping<Member>
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("username")]
        public string UserName { get; set; }
    }
}
