using Application.Interface;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Shared.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public static class ServiceEntensions
    {
        public static void AddSharedInfraestruture(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IDateTimeService, DateTimeService>();
        }
    }
}
