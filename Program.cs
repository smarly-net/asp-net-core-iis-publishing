using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace IISDeploy
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var host = new WebHostBuilder()
						.UseKestrel()
						.UseIISIntegration()
						.UseStartup<Startup>()
						.Build();

			host.Run();
		}
	}

	public class Startup
	{
		public void Configure(IApplicationBuilder app)
		{
			app.Run(async (context) =>
			{
				await context.Response.WriteAsync(
						"Hello World. The Time is: " +
						DateTime.Now.ToString("hh:mm:ss tt"));
			});
		}
	}
}
