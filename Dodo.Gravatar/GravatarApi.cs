using Dodo.Gravatar.Extensions;
using Dodo.Gravatar.Models;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Dodo.Gravatar
{
    public class GravatarApi
    {

        public async Task<GravatarInfo> GetProfileAsync(string email)
        {

            using (HttpClient HttpClient = new HttpClient())
            {
                var userInfo = new GravatarInfo { 
                    Name = email.Split('@')[0], 
                    DisplayName= email.Split('@')[0],
                    Photo = $"https://www.gravatar.com/avatar/{email.ToMd5()}?d=robohash" };
                try
                {
                    HttpClient.BaseAddress = new Uri("https://en.gravatar.com/");
                    HttpClient.DefaultRequestHeaders.UserAgent.ParseAdd("dodo-docs");

                    var response = await HttpClient.GetFromJsonAsync<Response>($"{email.ToMd5()}.json");
                    var entry = response.entry.FirstOrDefault();


                    userInfo.Name = entry?.name.formatted ?? (entry.displayName ?? "");
                    userInfo.Photo = entry.photos != null && entry.photos.Any() && !string.IsNullOrWhiteSpace(entry.photos.First().value) ? entry.photos.First().value : "";
                    userInfo.DisplayName = entry?.displayName ?? (entry.displayName ?? "");
                }
                catch (Exception)
                {
                    return userInfo;
                }
    
                return userInfo;
            }


        }
    }
}
