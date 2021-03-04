using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPTCertification.Business.Models
{
    public class Mapping
    {

    }
    public class Mapping<TDest> : Mapping
    {
        public static IMapper Mapper { get; private set; }
        public Mapping()
        {
            Mapper = Global.Mapper;
        }
        public void ToModel(TDest obj)
        {
            Mapper = Mapper ?? Global.Mapper;
            Mapper.Map(obj, this);
        }

        public TDest ToEntity()
        {
            Mapper = Mapper ?? Global.Mapper;
            return Mapper.Map<TDest>(this);
        }

        public TDest CopyTo(TDest dest)
        {
            Mapper = Mapper ?? Global.Mapper;
            return Mapper.Map(this, dest);
        }
    }
}
