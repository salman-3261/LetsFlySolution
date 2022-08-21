using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using LetsFly.Business;
using LetsFly.Business.AutoMapper;
using LetsFly.Business.Interface;
using LetsFly.DataLayer;
using LetsFly.DataLayer.Interface;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using Swashbuckle.Application;
using Unity;
using Unity.Lifetime;

namespace WebAPIProject
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            UnityContainer container = new UnityContainer();
            container.RegisterInstance(AutoMapperService.AutoMapperStart());
            RegisterContainer(container);

            config.DependencyResolver = new UnityResolver(container);

            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "SwaggerUI",
                routeTemplate: "",
                defaults: null,
                constraints: null,
                handler: new RedirectHandler(message => message.RequestUri.ToString(), "swagger")
                );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
        static void RegisterContainer(UnityContainer container)
        {
            container.RegisterType<ICustomerService, CustomerService>(new HierarchicalLifetimeManager());
            container.RegisterType<ICustomerData, CustomerData>(new HierarchicalLifetimeManager());
        }
    }
}
