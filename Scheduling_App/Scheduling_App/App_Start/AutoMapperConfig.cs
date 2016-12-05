using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Scheduling_App.ViewModels;
using Scheduling_App.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace Scheduling_App.App_Start
{
    public class AutoMapperConfig
    {
        public static void InitializeMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<FromDatabase>();
                cfg.AddProfile<ToDatabase>();
            });
        }
    }

    public class FromDatabase : Profile
    {
        protected override void Configure()
        {
            //base.Configure();
            CreateMap<User, UserVM>();
            
  
        }
    }

    public class ToDatabase : Profile
    {
        protected override void Configure()
        {
            //base.Configure();
           
            CreateMap<UserVM, User>();
            
        }
    }
}