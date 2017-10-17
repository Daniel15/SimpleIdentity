/*
 * Copyright (c) 2015 Daniel Lo Nigro (Daniel15)
 * 
 * This source code is licensed under the BSD-style license found in the 
 * LICENSE file in the root directory of this source tree. 
 */

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Daniel15.SimpleIdentity.Sample
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; set; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			// Add Identity services to the services container.
			services.AddIdentity<SimpleIdentityUser, SimpleIdentityRole>()
				.AddSimpleIdentity<SimpleIdentityUser>(Configuration.GetSection("Auth"))
				.AddDefaultTokenProviders();

			// Add MVC services to the services container.
			services.AddMvc();
		}

		// Configure is called after ConfigureServices is called.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
		{
			loggerFactory.AddConsole();

			// Configure the HTTP request pipeline.

			// Add the following to the request pipeline only in development environment.
			if (env.IsDevelopment())
			{
				app.UseBrowserLink();
				app.UseDeveloperExceptionPage();
			}
			else
			{
				// Add Error handling middleware which catches all application specific errors and
				// sends the request to the following path or controller action.
				app.UseExceptionHandler("/Home/Error");
			}

			// Add static files to the request pipeline.
			app.UseStaticFiles();

			// Add cookie-based authentication to the request pipeline.
			app.UseAuthentication();

			// Add MVC to the request pipeline.
			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}"
				);
			});
		}
	}
}
