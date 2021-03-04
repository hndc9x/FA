using FPTCertification.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPTCertification.Business.Models
{
    public class AdminRequestCreateTestPaper : Mapping<TestPaper>
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("type")]
        public string TestType { get; set; }

        [JsonProperty("question_type")]
        public string QuestionTypeCode { get; set; }

        // timing
        [JsonProperty("open_time")]
        public DateTime OpenTime { get; set; }

        [JsonProperty("open_time_enable")]
        public bool OpenTimeEnable { get; set; }

        [JsonProperty("close_time")]
        public DateTime CloseTime { get; set; }

        [JsonProperty("close_time_enable")]
        public bool CloseTimeEnable { get; set; }

        [JsonProperty("duration")]
        public TimeSpan Duration { get; set; }

        [JsonProperty("duration_enable")]
        public bool DurationEnable { get; set; }

        // grade
        public double TotalGrace { get; set; }
        public double GradeToPass { get; set; }
        public int Attempts { get; set; }
    }

    public class UserResponseGetTestPaper : Mapping<TestPaper>
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("type")]
        public string TestType { get; set; }


        [JsonProperty("question_type")]
        public string QuestionTypeCode { get; set; }

        // timing
        [JsonProperty("open_time")]
        public DateTime OpenTime { get; set; }

        [JsonProperty("close_time")]
        public DateTime CloseTime { get; set; }

        [JsonProperty("duration")]
        public TimeSpan Duration { get; set; }

        // grade
        [JsonProperty("total_grace")]
        public double TotalGrace { get; set; }

        [JsonProperty("attempts")]
        public int Attempts { get; set; }
    }
}
