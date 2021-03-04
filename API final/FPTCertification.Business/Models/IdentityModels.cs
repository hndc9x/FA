using FPTCertification.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FPTCertification.Business.Models
{
    public class RequestLoginModel
    {


        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
    }
    public class TokenResponseLoginModel
    {
        [JsonProperty("user_id")]
        public string UserId { get; set; }
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        [JsonProperty("role")]
        public string Role { get; set; }
    }

    public class ResponseAllUser : Mapping<AppUser>
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

        [JsonProperty("activated")]
        public bool Activated { get; set; }
    }
}
