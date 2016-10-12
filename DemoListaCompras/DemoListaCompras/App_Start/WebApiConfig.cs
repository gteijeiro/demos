using DemoListaCompras.Controller;
using DemoListaCompras.Data;
using DemoListaCompras.Data.Contracts;
using DemoListaCompras.Infrastructure;
using DemoListaCompras.Logic;
using DemoListaCompras.Logic.Contracts;
using Microsoft.Practices.Unity;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DemoListaCompras.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );

            config.Formatters.Remove(config.Formatters.XmlFormatter);

            var container = new UnityContainer();
            container.RegisterType<ICompraContext, CompraContext>(new HierarchicalLifetimeManager());
            container.RegisterType<ICompraData, CompraData>(new HierarchicalLifetimeManager());
            container.RegisterType<Logic.Contracts.ICompraLogic, CompraLogic>(new HierarchicalLifetimeManager());


            config.DependencyResolver = new UnityResolver(container);

            ////var cors = new EnableCorsAttribute("localhost:29947", "*", "*");
            //var cors = new EnableCorsAttribute("http://localhost:40128", "*", "*");

            //config.EnableCors(cors);
        }
    }
}
