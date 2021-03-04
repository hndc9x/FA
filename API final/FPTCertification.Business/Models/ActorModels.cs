using FPTCertification.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPTCertification.Business.Models
{
    // create
    public class RequestCreateActorModel : Mapping<Actor>
    {
        // field
        [JsonProperty("firstname")]
        public string FirstName { get; set; }
        [JsonProperty("lastname")]
        public string LastName { get; set; }
    }
    // update
    public class RequestUpdateActorModel
    {
        // field
    }
    // get select
    // api/Actor/select
    // lay ra list cacs ResponseSelectActorModel
    public class ResponseSelectActorModel
    {
        //id
        //name
    }
    // get only
    // api/Actor/only
    // lay ra list cacs ResponseOnlyActorModel
    public class ResponseOnlyActorModel : Mapping<Actor>
    {
        //id
        //name
        //ShortDescription
        //Description
        [JsonProperty("id")]
        public int ID { get; set; }
        [JsonProperty("firstname")]
        public string FirstName { get; set; }
        [JsonProperty("lastname")]
        public string LastName { get; set; }
    }
    // get all
    // api/Actor/all
    // lay ra list cacs ResponseOnlyActorModel
    public class ResponseAllActorModel
    {
        //id
        //name
        //ShortDescription
        //Description
        //List<ResponseSelectCertificationModel> list = new ...
    }
}
