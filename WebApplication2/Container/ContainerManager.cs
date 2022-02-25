using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Reflection;
using System.Reflection.Emit;
using Autofac;
using Autofac.Integration.Mvc;
using WebGrease;
using DeepClonerDemo.AppModel;
using AppServices;

namespace WebApplication2
{
    
    public class ContainerManager
    {
        public static void StartContainer()
        {
            var builder = new ContainerBuilder();

            SetupResolveRules(builder);

            // use a provided extension method to register all the controllers in an assembly

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            // create a new container with the component registrations

            var container = builder.Build();

            // use the static DependencyResolver.SetResolver method
            // to let ASP.NET MVC know that it should locate services
            // using the AutofacDependencyResolver
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private static void SetupResolveRules(ContainerBuilder builder)
        {

            //register the db context
            builder.RegisterType<Model1Container>().As<Model1Container>().InstancePerRequest();
            //register the core services
            //Register  business the services
            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(DictService))).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerRequest();

        }
    }
}