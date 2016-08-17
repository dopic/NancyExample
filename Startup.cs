using Microsoft.AspNetCore.Builder;
using Nancy.Owin;

namespace NancyExample
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            //Iniciado usando o Owin
            app.UseOwin(x => x.UseNancy());
            
            //Custom Bootstrapper
            /*app.UseOwin(x => x.UseNancy(opt =>{
                opt.Bootstrapper = null
            }));*/
        }
    }
}