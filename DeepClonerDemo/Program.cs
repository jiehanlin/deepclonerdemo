using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using AppServices;
using DeepClonerDemo.AppModel;
using Force.DeepCloner;

namespace DeepClonerDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = BuildContainer();
            var service = container.Resolve<IDictService>();
            var dict = service.GetDictType();
            var result = dict.DeepClone();
            foreach (var item in result)
            {
                Console.WriteLine(item.DictionaryType);
            }

            Console.ReadLine();
        }

        static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Model1Container>().As<Model1Container>();
            builder.RegisterType<DictService>().As<IDictService>();
            return builder.Build();
        }
    }
}
