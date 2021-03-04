using FPTCertification.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPTCertification.Business.Models
{
    public class RequestCreateQuestionType : Mapping<QuestionType>
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public class ResponseGetQuestionType : Mapping<QuestionType>
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("activated")]
        public bool Activated { get; set; }
    }

    public class ResponseSelectQuestionType : Mapping<QuestionType>
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
