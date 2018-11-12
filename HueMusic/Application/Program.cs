using Synesthesia.Data;
using System;
using System.Threading.Tasks;

namespace Application
{
    class Program
    {
        static async Task MainAsync(string[] args)
        {
            var lights = new HueService.HueService();
            var dataService = new DataService();
            string appKey = "";
            Console.WriteLine("Welcome to Synesthesia");
            Console.WriteLine("Connecting to Hue Bridge...");

            try
            {
                var settings = await dataService.GetSettings();
                if(settings == null)
                {
                    settings = await dataService.InitializeSettings();
                }
                if (string.IsNullOrEmpty(settings.AppKey))
                {
                    Console.WriteLine("The app must be registered with your Hue Bridge to continue.");
                    appKey = lights.RegisterApplication("Synesthesia", "CaseyPC").Result;
                    await dataService.SetAppKey(appKey);
                }
                else
                {
                    appKey = settings.AppKey;
                }
                lights.InitializeClient(appKey);
                lights.BlinkOnce();
                Console.WriteLine("Connected!");
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"An error occurred :(\nMessage:{e.Message}\nError:{e.InnerException.ToString()}");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        static void Main(string[] args)
        {
            MainAsync(args).Wait();
            Console.Read();
        }
    }
}
