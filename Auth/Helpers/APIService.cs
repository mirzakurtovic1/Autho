using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using Model;

namespace AuthoWeb
{
    class APIService
    {
        private string _route = null;
        public static string _username { get; set; }
        public static string _password { get; set; }
        //string https = "https://localhost:44307/api";
        string https = "http://localhost:62310/api";
        public APIService(string route)
        {
            _route = route;
        }

        public async Task<T> Get<T>(object search)
        {

            var url = $"{https}/{ _route}";
            //var result =await $"{ Properties.Settings.Default.APIUrl}/{ _route}".GetJsonAsync<T>();

            if (search != null)
            {
                url += "?";
                url += await search.ToQueryString();
            }

            return await url.GetJsonAsync<T>();
        }
        public async Task<T> GetById<T>(object id)
        {

            var url = $"{https}/{ _route}/{id}";
            return await url.GetJsonAsync<T>();
        }

        public async Task<T> Insert<T>(object request)
        {
            var url = $"{https}/{ _route}";
            return await url.PostJsonAsync(request).ReceiveJson<T>();
        }

        public async Task<T> Update<T>(object id, object request)
        {
            var url = $"{https}/{ _route}/{id}";
            var result = await url.PutJsonAsync(request).ReceiveJson<T>();
            return result;
        }
        public async Task<T> Delete<T>(object id)
        {
            var url = $"{https}/{ _route}/{id}";
            return await url.DeleteAsync().ReceiveJson<T>();
        }

    }
}