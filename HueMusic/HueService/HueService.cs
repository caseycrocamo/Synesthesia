using Q42.HueApi;
using Q42.HueApi.Interfaces;
using Q42.HueApi.Models.Bridge;
using Q42.HueApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace HueService
{
    public class HueService
    {
        public IBridgeLocator locator = new HttpBridgeLocator();


        public ILocalHueClient client;

        public async Task<IEnumerable<LocatedBridge>> FindBridges()
        {
             return await locator.LocateBridgesAsync(TimeSpan.FromSeconds(5));
        }

        public async Task<string> RegisterApplication(string applicationName, string deviceName)
        {
            IEnumerable<LocatedBridge> bridges = await FindBridges();
            client = new LocalHueClient(bridges.First().IpAddress);
            Console.WriteLine("Please press the button on your Hue Bridge");
            System.Threading.Thread.Sleep(5000);
            return await client.RegisterAsync(applicationName, deviceName);

        }

        public async void InitializeClient(string appKey)
        {
            IEnumerable<LocatedBridge> bridges = await FindBridges();
            client = new LocalHueClient(bridges.First().IpAddress);
            client.Initialize(appKey);
        }

        public void BlinkOnce()
        {
            var command = new LightCommand();
            command.On = true;
            command.Alert = Alert.Once;
            client.SendCommandAsync(command);
        }
    }
}
