﻿using Autofac;
using Autofac.Integration.WebApi;
using EM.Management.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.IO;

namespace EM.Management.Web
{
    public class AutofacWebapiConfig
    {
        private static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }


        private static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            return  builder.RegistComponentsWithSpecifiedSuffix("Repository","Cache","Service");
        }

        public static void Run()
        {
            AutofacWebapiConfig.Initialize(GlobalConfiguration.Configuration);
        }

    }
}