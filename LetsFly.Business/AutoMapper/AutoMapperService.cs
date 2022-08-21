using AutoMapper;
using LetsFly.BusinessObject;
using LetsFly.DataObj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsFly.Business.AutoMapper
{
    public class AutoMapperService
    {
        public static IMapper AutoMapperStart()
        {
            MapperConfiguration configuration = new MapperConfiguration(config =>
            {
                #region Account
                config.CreateMap<CustomerBo, CustomerDo>();
                #endregion
            });
            configuration.AssertConfigurationIsValid();
            return configuration.CreateMapper();
        }
    }
}
