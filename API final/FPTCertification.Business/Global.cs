using AutoMapper;
using AutoMapper.Configuration;
using FPTCertification.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FPTCertification.Business
{
    public class Global
    {
        public static IMapper Mapper { get; private set; }
        public static MapperConfigurationExpression BaseMapping { get; private set; }
        public Global()
        {

        }
        public static void Init()
        {
            BaseMapping = BaseMapping ?? new MapperConfigurationExpression();
            //var subClass = typeof(Mapping).Assembly.GetTypes().Where(type => type.IsSubclassOf(typeof(Mapping))).Select(type => type.GetType());
            var subClass = AppDomain.CurrentDomain.GetAssemblies()
                   .SelectMany(t => t.GetTypes())
                   .Where(t => typeof(Mapping).IsAssignableFrom(t) && t.IsClass && !t.IsAbstract);
            foreach (var item in subClass)
            {
                var source = item.BaseType?.GetGenericArguments().FirstOrDefault();
                if (source != null)
                {
                    BaseMapping.CreateMap(source, item).ReverseMap();
                }
            }
            var config = new MapperConfiguration(BaseMapping);
            Mapper = new Mapper(config);
            
        }
        public static void AddMapping<TSource, TDest>()
        {
            Init();
            BaseMapping.CreateMap<TSource, TDest>().ReverseMap();
            var config = new MapperConfiguration(BaseMapping);
            Mapper = new Mapper(config);
        }
    }
    
}
