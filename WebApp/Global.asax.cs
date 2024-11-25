using AutoMapper;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebApp.App_Start;
using WebApp.Domain.Entities.Comp;
using WebApp.Domain.Entities.DatabaseTables;
using WebApp.Domain.Entities.User;
using WebApp.Models;

namespace WebApp
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundlesConfig.RegisterBundles(BundleTable.Bundles);

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<UserDBTable, User>();
                cfg.CreateMap<SessionDBTable, Session>();
                cfg.CreateMap<User_Signin_Data, SingInUser>();
                cfg.CreateMap<SingInUser, User_Signin_Data>();
                cfg.CreateMap<User_Signin_Data, UserDBTable>();
                cfg.CreateMap<UserDBTable, User_Signin_Data>();
                cfg.CreateMap<CoCardDBTable, CoCard>();
                cfg.CreateMap<CoCard, CoCardDBTable>();
                cfg.CreateMap<CoCard, CompCard>();
                cfg.CreateMap<CompCard, CoCard>();
                cfg.CreateMap<CoCardDBTable, CompCard>();
                cfg.CreateMap<CompCard, CoCardDBTable>();
            });
        }
    }
}
