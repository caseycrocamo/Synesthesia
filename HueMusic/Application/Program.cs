using System;


namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Synesthesia");
            Console.WriteLine("Connecting to Hue Bridge...");
            //todo connect with appKey after it is generated
            HueService.HueService lights = new HueService.HueService();
            //todo persist appkey in config file
            string appKey = lights.RegisterApplication("Synesthesia", "CaseyPC").Result;
            
            lights.InitializeClient(appKey);
            lights.BlinkOnce();
            Console.WriteLine("Connected!");
        }
    }
}
