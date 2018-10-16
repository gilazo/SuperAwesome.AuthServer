using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;
using SuperAwesome.AuthServer.Application;
using SuperAwesome.AuthServer.Application.Users;
using SuperAwesome.AuthServer.Infrastructure;

namespace SuperAwesome.AuthServer.Presentation.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvc()
                .AddJsonOptions(opt =>
                {
                    opt.SerializerSettings.ContractResolver = new DefaultContractResolver { NamingStrategy = new CamelCaseNamingStrategy() };
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddTransient<Algorithm>(_ => Configuration.GetValue<string>("HashType"));
            services.AddTransient<IHeader<string>>(s => new JwtHeader(s.GetService<Algorithm>()));
            services.AddTransient<ISerialize<Claims>, JsonSerializer<Claims>>();
            services.AddTransient<Secret>(_ => new Secret(Configuration.GetValue<string>("Secret")));
            services.AddTransient<HashFactory>(s => new HashFactory(Enum.Parse<HashType>(s.GetService<Algorithm>()), s.GetService<IHeader<string>>()));
            services.AddTransient<IGet<User>, DemoUsers>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
