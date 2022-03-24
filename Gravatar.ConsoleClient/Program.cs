using Dodo.Gravatar;
using System;
using System.Threading.Tasks;

namespace Gravatar.ConsoleClient
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            GravatarApi api = new GravatarApi();
            var response = await api.GetProfileAsync("julio.yepes@3ysolutions.com.co"); 
            Console.WriteLine($"Name: {response.Name}");
            Console.WriteLine($"Display name: {response.DisplayName}");
            Console.WriteLine($"Photo: {response.Photo}");
            Console.ReadLine();
        }
    }
}
