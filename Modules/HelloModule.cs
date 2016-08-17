using Nancy;
using System.Threading.Tasks;
using System.Threading;
using NancyExample.Services;

using static System.Console;

namespace NancyExample.Modules
{
    public class HelloModule: NancyModule 
    {
        //Resolução de dependências automáticas (caso exista apenas uma implementação para a interface)
        public HelloModule (IMessageProvider provider)
        {
            this.Before.AddItemToEndOfPipeline((ctx, ct) =>
            {
                WriteLine("Antes");
                return Task.FromResult(ctx.Response);
            });

            this.After.AddItemToEndOfPipeline((ctx, ct) =>
            {
                WriteLine("Depois");
                return Task.FromResult(ctx.Response);
            });


            //Permite routing customizável
            //Aceita constraints e valores padrões
            Get("/{name}/{age:int}",  e =>
            {
                //return $"Hello {e.name} ({e.age})";
                return provider.GetMessage();                
            });

            Get("/{name|Douglas}",  e =>
            {
                return $"Hello {e.name} ({e.name.HasValue})";
                                
            });

           /* Get("/", async e =>
            {                
                return await Task.Run<string>(()=>{
                    Thread.Sleep(1000);
                    return "Teste";                    
                });
            }, ctx =>{
                //Optional Condition to execute the route
                return  true;
            });*/
        }
    } 
}