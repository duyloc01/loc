using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using tuanntgcs18661ApplicationDev.Data;
using tuanntgcs18661ApplicationDev.Models;

[assembly: HostingStartup(typeof(tuanntgcs18661ApplicationDev.Areas.Identity.IdentityHostingStartup))]
namespace tuanntgcs18661ApplicationDev.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}