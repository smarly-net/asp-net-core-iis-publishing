using System;
using System.IO;
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
                .UseContentRoot(Directory.GetCurrentDirectory())
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
						"Hello. The Time is: " +
						DateTime.Now.ToString("hh:mm:ss tt"));
			});
		}
	}
}
