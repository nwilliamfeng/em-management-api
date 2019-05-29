﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using Autofac;
using Autofac.Integration.WebApi;
using EM.Management.Service;

namespace EM.Management.Web
{
    public static class AutofacExtension
    {
       
        public static IContainer RegistComponentsWithSpecifiedSuffix(this ContainerBuilder builder, params string[] suffixs)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            var amblys = AppDomain.CurrentDomain.GetAssemblies().Where(x => x.ManifestModule.Name.Contains("EM.Management"));
            builder.RegisterAssemblyTypes(typeof(PlatformService).Assembly).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof(EM.Management.Data.MySQL.PlatformRepository).Assembly).Where(t => t.Name.EndsWith("Repository")).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof(EM.Management.Data.Redis.RedisCache).Assembly).Where(t => t.Name.EndsWith("Cache")).AsImplementedInterfaces();

            return builder.Build();
        }
    }
}